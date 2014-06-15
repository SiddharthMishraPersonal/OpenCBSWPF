using System;
using NUnit.Framework;
using OpenCBS.Engine.AdjustmentPolicy;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.Interfaces;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.RoundingPolicy;
using System.Linq;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class FlatSchedule
    {
        private IScheduleConfiguration _configuration;
        private IScheduleBuilder _builder;

        [SetUp]
        public void FlatSchedule_Setup()
        {
            _configuration = new ScheduleConfiguration
            {
                NumberOfInstallments = 5,
                Amount = 5000,
                InterestRate = 24m,
                StartDate = new DateTime(2013, 1, 1),
                PreferredFirstInstallmentDate = new DateTime(2013, 2, 1),
                PeriodPolicy = new Monthly30DayPeriodPolicy(),
                YearPolicy = new ThreeHundredSixtyDayYearPolicy(),
                RoundingPolicy = new TwoDecimalRoundingPolicy(),
                CalculationPolicy = new FlatInstallmentCalculationPolicy(),
                AdjustmentPolicy = new LastInstallmentAdjustmentPolicy(),
                DateShiftPolicy = new NoDateShiftPolicy(),
            };
            _builder = new ScheduleBuilder();
        }

        [Test]
        public void FlatSchedule_SumOfPrincipal_IsEqualToAmount()
        {
            Assert.That(_builder.BuildSchedule(_configuration).Sum(i => i.Principal), Is.EqualTo(_configuration.Amount));
        }

        [Test]
        public void FlatSchedule_SumOfUnevenPrincipal_IsEqualToAmount()
        {
            _configuration.NumberOfInstallments = 7;
            Assert.That(_builder.BuildSchedule(_configuration).Sum(i => i.Principal), Is.EqualTo(_configuration.Amount));
        }

        [Test]
        public void FlatSchedule_SumOfInterest_IsEqualToAmountByInterestRateByPeriod()
        {
            // 5000 * 24% * 30/360 * 5 = 700
            Assert.That(_builder.BuildSchedule(_configuration).Sum(i => i.Interest), Is.EqualTo(500));
        }
    }
}
