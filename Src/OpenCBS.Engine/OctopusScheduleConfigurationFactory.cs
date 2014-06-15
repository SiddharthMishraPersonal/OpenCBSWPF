using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.Interfaces;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Enums;
using OpenCBS.Shared;
using OpenCBS.Shared.Settings;

namespace OpenCBS.Engine
{
    public class OctopusScheduleConfigurationFactory : IScheduleConfigurationFactory
    {
        private IScheduleConfiguration _scheduleConfiguration;
        private readonly CompositionContainer _container;
        private ApplicationSettings _settings;
        private Loan _loan;

        [ImportMany(typeof(IPolicy))]
        private Lazy<IPolicy, IPolicyAttribute>[] Policies { get; set; }

        public OctopusScheduleConfigurationFactory(NonWorkingDateSingleton nonWorkingDate)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            _container = new CompositionContainer(catalog);
            var weekendPolicy = new WeekendPolicy();
            weekendPolicy.AddWeekend((DayOfWeek)nonWorkingDate.WeekEndDay1);
            weekendPolicy.AddWeekend((DayOfWeek)nonWorkingDate.WeekEndDay2);
            var holidayPolicy = new HolidayPolicy();
            foreach (var pair in nonWorkingDate.PublicHolidays)
            {
                holidayPolicy.AddHoliday(pair.Key);
            }
            var nonWorkingDayPolicy = new NonWorkingDayPolicy(weekendPolicy, holidayPolicy);
            _container.ComposeExportedValue<INonWorkingDayPolicy>(nonWorkingDayPolicy);
        }

        public OctopusScheduleConfigurationFactory(NonWorkingDateSingleton nonWorkingDate, ApplicationSettings settings)
            : this(nonWorkingDate)
        {
            _settings = settings;
        }

        public OctopusScheduleConfigurationFactory Init()
        {
            Compose();
            _scheduleConfiguration = new ScheduleConfiguration();
            return this;
        }

        public OctopusScheduleConfigurationFactory Finish()
        {
            _scheduleConfiguration.CalculationPolicy = GetPolicy<IInstallmentCalculationPolicy>(GetCalculationPolicyKey());
            _scheduleConfiguration.PeriodPolicy = GetPeriodPolicy();
            _scheduleConfiguration.YearPolicy = GetYearPolicy();
            _scheduleConfiguration.RoundingPolicy = GetRoundingPolicy();
            _scheduleConfiguration.DateShiftPolicy = GetDateShiftPolicy();
            _scheduleConfiguration.AdjustmentPolicy = GetAdjustmentPolicy();

            _scheduleConfiguration.Amount = _loan.Amount.Value;
            _scheduleConfiguration.NumberOfInstallments = _loan.NbOfInstallments;
            _scheduleConfiguration.GracePeriod = _loan.GracePeriod.HasValue ? _loan.GracePeriod.Value : 0;
            var numberOfPeriods = (decimal)_scheduleConfiguration
                .PeriodPolicy
                .GetNumberOfPeriodsInYear(_loan.StartDate, _scheduleConfiguration.YearPolicy);
            _scheduleConfiguration.InterestRate = _loan.InterestRate * 100;
            _scheduleConfiguration.StartDate = _loan.StartDate;
            _scheduleConfiguration.PreferredFirstInstallmentDate = _loan.FirstInstallmentDate;
            _scheduleConfiguration.ChargeInterestDuringGracePeriod = _loan.Product.ChargeInterestWithinGracePeriod;
            _scheduleConfiguration.ChargeActualInterestForFirstInstallment = _settings.PayFirstInterestRealValue;
            return this;
        }


        public OctopusScheduleConfigurationFactory WithSettings(ApplicationSettings settings)
        {
            _settings = settings;
            return this;
        }

        public OctopusScheduleConfigurationFactory WithLoan(Loan loan)
        {
            if (loan == null) throw new ArgumentException("Loan cannot be null.");
            if (loan.Product == null) throw new ArgumentException("Loan product cannot be null.");
            _loan = loan;
            return this;
        }

        public IScheduleConfiguration GetConfiguration()
        {
            return _scheduleConfiguration;
        }

        private void Compose()
        {
            _container.SatisfyImportsOnce(this);
        }

        private string GetCalculationPolicyKey()
        {
            var map = new Dictionary<OLoanTypes, string>
            {
                { OLoanTypes.Flat, "Flat" },
                { OLoanTypes.DecliningFixedInstallments, "Annuity" },
                { OLoanTypes.DecliningFixedPrincipal, "Fixed principal" },
            };
            return map.ContainsKey(_loan.Product.LoanType) ? map[_loan.Product.LoanType] : string.Empty;
        }

        private IPeriodPolicy GetPeriodPolicy()
        {
            if (_loan.InstallmentType.NbOfMonths == 0 && _loan.InstallmentType.NbOfDays == 1)
                return GetPolicy<IPeriodPolicy>("Daily");
            if (_loan.InstallmentType.NbOfMonths == 1 && _loan.InstallmentType.NbOfDays == 0)
            {
                if (_loan.Product.InterestScheme == OInterestScheme.Thirty360 || _loan.Product.InterestScheme == OInterestScheme.ThirtyActual)
                    return GetPolicy<IPeriodPolicy>("Monthly (30 day)");
                return GetPolicy<IPeriodPolicy>("Monthly");
            }
            var policy = (CustomPeriodPolicy)GetPolicy<IPeriodPolicy>("Custom");
            policy.SetNumberOfDays(_loan.InstallmentType.NbOfDays);
            return policy;
        }

        private IRoundingPolicy GetRoundingPolicy()
        {
            var key = _loan.Product.Currency.UseCents ? "Two decimal" : "Whole";
            return GetPolicy<IRoundingPolicy>(key);
        }

        private IYearPolicy GetYearPolicy()
        {
            string key;
            switch (_loan.Product.InterestScheme)
            {
                case OInterestScheme.Thirty360:
                case OInterestScheme.Actual360:
                    key = "360";
                    break;
                default:
                    key = "Actual";
                    break;
            }
            return GetPolicy<IYearPolicy>(key);
        }

        private IDateShiftPolicy GetDateShiftPolicy()
        {
            string key;
            if (_settings.DoNotSkipNonWorkingDays)
            {
                key = "No";
            }
            else
            {
                key = _settings.IsIncrementalDuringDayOff ? "Forward" : "Backward";
            }
            return GetPolicy<IDateShiftPolicy>(key);
        }

        private IAdjustmentPolicy GetAdjustmentPolicy()
        {
            string key;
            switch (_loan.Product.RoundingType)
            {
                case ORoundingType.Begin:
                    key = "First installment";
                    break;

                default:
                    key = "Last installment";
                    break;
            }
            return GetPolicy<IAdjustmentPolicy>(key);
        }

        private T GetPolicy<T>(string key) where T : IPolicy
        {
            return (T)(from policy in Policies
                       where policy.Metadata.Implementation == key
                       && policy.Value.GetType().GetInterfaces().Contains(typeof(T))
                       select policy.Value).FirstOrDefault();
        }
    }
}
