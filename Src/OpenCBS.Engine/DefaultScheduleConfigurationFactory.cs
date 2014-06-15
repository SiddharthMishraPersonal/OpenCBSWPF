using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Linq;
using System.Reflection;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class DefaultScheduleConfigurationFactory : IScheduleConfigurationFactory
    {
        private IScheduleConfiguration _scheduleConfiguration;
        private string _key;
        private readonly CultureInfo _cultureInfo;

        private readonly CompositionContainer _container;

        [ImportMany(typeof(IPolicy))]
        private Lazy<IPolicy, IPolicyAttribute>[] Policies { get; set; }

        public DefaultScheduleConfigurationFactory Init()
        {
            Compose();
            _scheduleConfiguration = new ScheduleConfiguration();
            return this;
        }

        public DefaultScheduleConfigurationFactory()
        {
            _cultureInfo = new CultureInfo("ru-RU");
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            _container = new CompositionContainer(catalog);
            var weekendPolicy = new WeekendPolicy();
            weekendPolicy.AddWeekend(DayOfWeek.Saturday);
            weekendPolicy.AddWeekend(DayOfWeek.Sunday);
            var holidayPolicy = new HolidayPolicy();
            var nonWorkingDayPolicy = new NonWorkingDayPolicy(weekendPolicy, holidayPolicy);
            _container.ComposeExportedValue<INonWorkingDayPolicy>(nonWorkingDayPolicy);
        }

        private void Compose()
        {
            _container.SatisfyImportsOnce(this);
        }

        private T GetPolicy<T>() where T : IPolicy
        {
            return (T)(from policy in Policies
                       where policy.Metadata.Implementation == _key 
                       && policy.Value.GetType().GetInterfaces().Contains(typeof(T))
                       select policy.Value).FirstOrDefault();
        }

        public DefaultScheduleConfigurationFactory With(string key)
        {
            _key = key;
            return this;
        }

        public DefaultScheduleConfigurationFactory CalculationPolicy()
        {
            _scheduleConfiguration.CalculationPolicy = GetPolicy<IInstallmentCalculationPolicy>();
            if (_scheduleConfiguration.CalculationPolicy == null) throw new ArgumentException("Invalid calculation policy.");
            return this;
        }

        public DefaultScheduleConfigurationFactory PeriodPolicy()
        {
            _scheduleConfiguration.PeriodPolicy = GetPolicy<IPeriodPolicy>();
            if (_scheduleConfiguration.PeriodPolicy == null) throw new ArgumentException("Invalid period policy.");
            return this;
        }

        public DefaultScheduleConfigurationFactory YearPolicy()
        {
            _scheduleConfiguration.YearPolicy = GetPolicy<IYearPolicy>();
            if (_scheduleConfiguration.YearPolicy == null) throw new ArgumentException("Invalid year policy.");
            return this;
        }

        public DefaultScheduleConfigurationFactory RoundingPolicy()
        {
            _scheduleConfiguration.RoundingPolicy = GetPolicy<IRoundingPolicy>();
            if (_scheduleConfiguration.RoundingPolicy == null) throw new ArgumentException("Invalid rounding policy.");
            return this;
        }

        public DefaultScheduleConfigurationFactory AdjustmentPolicy()
        {
            _scheduleConfiguration.AdjustmentPolicy = GetPolicy<IAdjustmentPolicy>();
            if (_scheduleConfiguration.AdjustmentPolicy == null) throw new ArgumentException("Invalid adjustment policy.");
            return this;
        }

        public DefaultScheduleConfigurationFactory DateShiftPolicy()
        {
            _scheduleConfiguration.DateShiftPolicy = GetPolicy<IDateShiftPolicy>();
            if (_scheduleConfiguration.DateShiftPolicy == null) throw new ArgumentException("Invalid date shift policy.");
            return this;
        }

        public DefaultScheduleConfigurationFactory Installments()
        {
            _scheduleConfiguration.NumberOfInstallments = int.Parse(_key);
            return this;
        }

        public DefaultScheduleConfigurationFactory GracePeriod()
        {
            _scheduleConfiguration.GracePeriod = int.Parse(_key);
            return this;
        }

        public DefaultScheduleConfigurationFactory Amount()
        {
            _scheduleConfiguration.Amount = decimal.Parse(_key, _cultureInfo);
            return this;
        }

        public DefaultScheduleConfigurationFactory InterestRate()
        {
            _scheduleConfiguration.InterestRate = decimal.Parse(_key, _cultureInfo);
            return this;
        }

        public DefaultScheduleConfigurationFactory StartDate()
        {
            _scheduleConfiguration.StartDate = DateTime.Parse(_key, _cultureInfo, DateTimeStyles.AssumeLocal);
            return this;
        }

        public DefaultScheduleConfigurationFactory FirstRepaymentDate()
        {
            _scheduleConfiguration.PreferredFirstInstallmentDate = DateTime.Parse(_key, _cultureInfo, DateTimeStyles.AssumeLocal);
            return this;
        }

        public IScheduleConfiguration GetConfiguration()
        {
            return _scheduleConfiguration;
        }
    }
}
