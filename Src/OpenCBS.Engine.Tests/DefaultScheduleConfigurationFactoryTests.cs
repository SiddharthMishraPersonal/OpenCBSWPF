using System;
using NUnit.Framework;
using OpenCBS.Engine.AdjustmentPolicy;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.RoundingPolicy;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class DefaultScheduleConfigurationFactoryTests
    {
        private DefaultScheduleConfigurationFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DefaultScheduleConfigurationFactory();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid calculation policy.")]
        public void GetConfiguration_NoCalculationPolicy_ThrowsException()
        {
            _factory.Init().With("unknown").CalculationPolicy();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid period policy.")]
        public void GetConfiguration_NoPeriodPolicy_ThrowsException()
        {
            _factory.Init().With("unknown").PeriodPolicy();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid year policy.")]
        public void GetConfiguration_NoYearPolicy_ThrowException()
        {
            _factory.Init().With("unknown").YearPolicy();
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Invalid adjustment policy.")]
        public void GetConfiguration_NoAdjustmentPolicy_ThrowsException()
        {
            _factory.Init().With("unknown").AdjustmentPolicy();
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Invalid rounding policy.")]
        public void GetConfiguration_NoRoundingPolicy_ThrowsException()
        {
            _factory.Init().With("unknown").RoundingPolicy();
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Invalid date shift policy.")]
        public void GetConfiguration_NoDateShiftPolicy_ThrowsException()
        {
            _factory.Init().With("unknown").DateShiftPolicy();
        }

        [Test]
        public void GetConfiguration_CalculationPolicy_CalculationPolicyIsProperlySet()
        {
            var configuration = _factory.Init().With("Flat").CalculationPolicy().GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<FlatInstallmentCalculationPolicy>());
            configuration = _factory.Init().With("Fixed principal").CalculationPolicy().GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<FixedPrincipalInstallmentCalculationPolicy>());
            configuration = _factory.Init().With("Annuity").CalculationPolicy().GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<AnnuityInstallmentCalculationPolicy>());
        }

        [Test]
        public void GetConfiguration_PeriodPolicy_PeriodPolicyIsProperlySet()
        {
            var configuration = _factory.Init().With("Monthly (30 day)").PeriodPolicy().GetConfiguration();
            Assert.That(configuration.PeriodPolicy, Is.InstanceOf<Monthly30DayPeriodPolicy>());
            configuration = _factory.Init().With("Monthly").PeriodPolicy().GetConfiguration();
            Assert.That(configuration.PeriodPolicy, Is.InstanceOf<MonthlyPeriodPolicy>());
            configuration = _factory.Init().With("Daily").PeriodPolicy().GetConfiguration();
            Assert.That(configuration.PeriodPolicy, Is.InstanceOf<DailyPeriodPolicy>());
        }

        [Test]
        public void GetConfiguration_YearPolicy_YearPolicyIsProperlySet()
        {
            var configuration = _factory.Init().With("360").YearPolicy().GetConfiguration();
            Assert.That(configuration.YearPolicy, Is.InstanceOf<ThreeHundredSixtyDayYearPolicy>());
            configuration = _factory.Init().With("365").YearPolicy().GetConfiguration();
            Assert.That(configuration.YearPolicy, Is.InstanceOf<ThreeHundredSixtyFiveDayYearPolicy>());
            configuration = _factory.Init().With("Actual").YearPolicy().GetConfiguration();
            Assert.That(configuration.YearPolicy, Is.InstanceOf<ActualNumberOfDayYearPolicy>());
        }

        [Test]
        public void GetConfiguration_RoundingPolicy_RoundingPolicyIsProperlySet()
        {
            var configuration = _factory.Init().With("Whole").RoundingPolicy().GetConfiguration();
            Assert.That(configuration.RoundingPolicy, Is.InstanceOf<IntegerRoundingPolicy>());
            configuration = _factory.Init().With("Two decimal").RoundingPolicy().GetConfiguration();
            Assert.That(configuration.RoundingPolicy, Is.InstanceOf<TwoDecimalRoundingPolicy>());
        }

        [Test]
        public void GetConfiguration_AdjustmentPolicy_AdjustmentPolicyIsProperlySet()
        {
            var configuration = _factory.Init().With("First installment").AdjustmentPolicy().GetConfiguration();
            Assert.That(configuration.AdjustmentPolicy, Is.InstanceOf<FirstInstallmentAdjustmentPolicy>());
            configuration = _factory.Init().With("Last installment").AdjustmentPolicy().GetConfiguration();
            Assert.That(configuration.AdjustmentPolicy, Is.InstanceOf<LastInstallmentAdjustmentPolicy>());
        }

        [Test]
        public void GetConfiguration_DateShiftPolicy_DateShiftPolicyIsProperlySet()
        {
            var configuration = _factory.Init().With("Forward").DateShiftPolicy().GetConfiguration();
            Assert.That(configuration.DateShiftPolicy, Is.InstanceOf<ForwardDateShiftPolicy>());
            configuration = _factory.Init().With("Backward").DateShiftPolicy().GetConfiguration();
            Assert.That(configuration.DateShiftPolicy, Is.InstanceOf<BackwardDateShiftPolicy>());
        }

        [Test]
        public void GetConfiguration_NumberOfInstallments_NumberOfInstallmentsIsProperlySet()
        {
            var configuration = _factory.Init().With("5").Installments().GetConfiguration();
            Assert.That(configuration.NumberOfInstallments, Is.EqualTo(5));
        }

        [Test]
        public void GetConfiguration_GracePeriod_GracePeriodIsProperlySet()
        {
            var configuration = _factory.Init().With("1").GracePeriod().GetConfiguration();
            Assert.That(configuration.GracePeriod, Is.EqualTo(1));
        }

        [Test]
        public void GetConfiguration_Amount_AmountIsProperlySet()
        {
            var configuration = _factory.Init().With("5000").Amount().GetConfiguration();
            Assert.That(configuration.Amount, Is.EqualTo(5000m));
        }

        [Test]
        public void GetConfiguration_InterestRate_InterestRateIsProperlySet()
        {
            var configuration = _factory.Init().With("24").InterestRate().GetConfiguration();
            Assert.That(configuration.InterestRate, Is.EqualTo(24m));
        }

        [Test]
        public void GetConfiguration_StartDate_StartDateIsProperlySet()
        {
            var configuration = _factory.Init().With("01.01.2013").StartDate().GetConfiguration();
            Assert.That(configuration.StartDate, Is.EqualTo(new DateTime(2013, 1, 1)));
        }

        [Test]
        public void GetConfiguration_FirsRepaymentDate_FirstRepaymentDateIsProperlySet()
        {
            var configuration = _factory.Init().With("01.02.2013").FirstRepaymentDate().GetConfiguration();
            Assert.That(configuration.PreferredFirstInstallmentDate, Is.EqualTo(new DateTime(2013, 2, 1)));
        }
    }
}
