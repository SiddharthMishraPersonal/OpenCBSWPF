using System;
using NUnit.Framework;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Engine.AdjustmentPolicy;
using OpenCBS.Engine.Interfaces;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.RoundingPolicy;
using OpenCBS.Engine.YearPolicy;
using OpenCBS.Enums;
using OpenCBS.Shared;
using OpenCBS.Shared.Settings;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class OctopusScheduleConfigurationFactoryTests
    {
        private OctopusScheduleConfigurationFactory _factory;
        private Loan _loan;
        private ApplicationSettings _settings;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _settings = ApplicationSettings.GetInstance(string.Empty);
            _settings.AddParameter("DONOT_SKIP_WEEKENDS_IN_INSTALLMENTS_DATE", false);
            _settings.AddParameter("INCREMENTAL_DURING_DAYOFFS", false);
        }

        [SetUp]
        public void SetUp()
        {
            _factory = new OctopusScheduleConfigurationFactory(NonWorkingDateSingleton.GetInstance(string.Empty));
            _loan = new Loan
            {
                Amount = 0m,
                NbOfInstallments = 0,
                GracePeriod = 0,
                InterestRate = 0,
                StartDate = DateTime.Today,
                FirstInstallmentDate = DateTime.Today,
                Product = new LoanProduct
                {
                    LoanType = OLoanTypes.Flat,
                    Currency = new Currency { Name = "USD" },
                },
                InstallmentType = new InstallmentType { NbOfDays = 0, NbOfMonths = 1 },
            };
        }

        private IScheduleConfiguration GetConfiguration()
        {
            return _factory.Init().WithSettings(_settings).WithLoan(_loan).Finish().GetConfiguration();
        }
        
        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Loan cannot be null.")]
        public void GetConfiguration_NoLoan_ThrowsException()
        {
            _factory.Init().WithSettings(_settings).WithLoan(null);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Loan product cannot be null.")]
        public void GetConfiguration_NoLoanProduct_ThrowsException()
        {
            _loan.Product = null;
            GetConfiguration();
        }

        [Test]
        public void GetConfiguration_LoanType_CalculationPolicyIsProperlySet()
        {
            var configuration = GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<FlatInstallmentCalculationPolicy>());

            _loan.Product.LoanType = OLoanTypes.DecliningFixedInstallments;
            configuration = GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<AnnuityInstallmentCalculationPolicy>());

            _loan.Product.LoanType = OLoanTypes.DecliningFixedPrincipal;
            configuration = GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<FixedPrincipalInstallmentCalculationPolicy>());
        }

        [Test]
        public void GetConfiguration_Period_PeriodPolicyIsProperlySet()
        {
            var configuration = GetConfiguration();
            Assert.That(configuration.PeriodPolicy, Is.InstanceOf<Monthly30DayPeriodPolicy>());

            _loan.InstallmentType.NbOfMonths = 0;
            _loan.InstallmentType.NbOfDays = 1;
            configuration = GetConfiguration();
            Assert.That(configuration.PeriodPolicy, Is.InstanceOf<DailyPeriodPolicy>());

            _loan.InstallmentType.NbOfDays = 7;
            configuration = GetConfiguration();
            Assert.That(configuration.PeriodPolicy, Is.InstanceOf<CustomPeriodPolicy>());
            Assert.That(configuration.PeriodPolicy.GetNumberOfDays(DateTime.Today), Is.EqualTo(7));
        }

        [Test]
        public void GetConfiguration_YearPolicyIsAlways360DayYear()
        {
            var configuration = GetConfiguration();
            Assert.That(configuration.YearPolicy, Is.InstanceOf<ThreeHundredSixtyDayYearPolicy>());
        }

        [Test]
        public void GetConfiguration_RoundingPolicy_RoundingPolicyIsProperlySet()
        {
            _loan.Product.Currency.UseCents = true;
            var configuration = GetConfiguration();
            Assert.That(configuration.RoundingPolicy, Is.InstanceOf<TwoDecimalRoundingPolicy>());
            _loan.Product.Currency.UseCents = false;
            configuration = GetConfiguration();
            Assert.That(configuration.RoundingPolicy, Is.InstanceOf<IntegerRoundingPolicy>());
        }

        [Test]
        public void GetConfiguration_DateShiftPolicy_DateShiftPolicyIsProperlySet()
        {
            _settings.UpdateParameter("DONOT_SKIP_WEEKENDS_IN_INSTALLMENTS_DATE", false);
            _settings.UpdateParameter("INCREMENTAL_DURING_DAYOFFS", true);
            var configuration = GetConfiguration();
            Assert.That(configuration.DateShiftPolicy, Is.InstanceOf<ForwardDateShiftPolicy>());

            _settings.UpdateParameter("INCREMENTAL_DURING_DAYOFFS", false);
            configuration = GetConfiguration();
            Assert.That(configuration.DateShiftPolicy, Is.InstanceOf<BackwardDateShiftPolicy>());

            _settings.UpdateParameter("DONOT_SKIP_WEEKENDS_IN_INSTALLMENTS_DATE", true);
            configuration = GetConfiguration();
            Assert.That(configuration.DateShiftPolicy, Is.InstanceOf<NoDateShiftPolicy>());
        }

        [Test]
        public void GetConfiguration_AdjustmentPolicy_AdjustmentPolicyIsProperlySet()
        {
            _loan.Product.RoundingType = ORoundingType.Begin;
            var configuration = GetConfiguration();
            Assert.That(configuration.AdjustmentPolicy, Is.InstanceOf<FirstInstallmentAdjustmentPolicy>());
        }

        [Test]
        public void GetConfiguration_NumberOfInstallments_NumberOfInstallmentsIsProperlySet()
        {
            _loan.NbOfInstallments = 10;
            var configuration = GetConfiguration();
            Assert.That(configuration.NumberOfInstallments, Is.EqualTo(10));
        }

        [Test]
        public void GetConfiguration_GracePeriod_GracePeriodIsProperlySet()
        {
            _loan.GracePeriod = 2;
            var configuration = GetConfiguration();
            Assert.That(configuration.GracePeriod, Is.EqualTo(2));
        }

        [Test]
        public void GetConfiguration_InterestRate_InterestRateIsProperlySet()
        {
            _loan.InterestRate = 0.02m;
            var configuration = GetConfiguration();
            Assert.That(configuration.InterestRate, Is.EqualTo(24));
        }

        [Test]
        public void GetConfiguration_StartDate_StartDateIsProperlySet()
        {
            _loan.StartDate = new DateTime(2013, 1, 1);
            var configuration = GetConfiguration();
            Assert.That(configuration.StartDate, Is.EqualTo(new DateTime(2013, 1, 1)));
        }

        [Test]
        public void GetConfiguration_FirstRepaymentDate_FirstRepaymentDateIsProperlySet()
        {
            _loan.FirstInstallmentDate = new DateTime(2013, 2, 1);
            var configuration = GetConfiguration();
            Assert.That(configuration.PreferredFirstInstallmentDate, Is.EqualTo(new DateTime(2013, 2, 1)));
        }
    }
}
