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
    public class AnnuityScheduleFact
    {
        private IScheduleConfiguration _configuration;
        private IScheduleBuilder _builder;

        [SetUp]
        public void AnnuitySchedule_Setup()
        {
            _configuration = new ScheduleConfiguration
            {
                NumberOfInstallments = 12,
                Amount = 100000,
                InterestRate = 36m,
                StartDate = new DateTime(2013, 12, 10),
                PreferredFirstInstallmentDate = new DateTime(2014, 1, 10),
                PeriodPolicy = new MonthlyPeriodPolicy(),
                YearPolicy = new ThreeHundredSixtyDayYearPolicy(),
                RoundingPolicy = new IntegerRoundingPolicy(),
                CalculationPolicy = new AnnuityInstallmentCalculationPolicy(),
                AdjustmentPolicy = new LastInstallmentAdjustmentPolicy(),
                DateShiftPolicy = new NoDateShiftPolicy(),
            };
            _builder = new ScheduleBuilder();
        }

        [Test]
        public void AnnuitySchedule_SumOfPrincipal_IsEqualToAmount()
        {
            var list = _builder.BuildSchedule(_configuration);
            var sum = list.Sum(i => i.Principal);
            Assert.That(sum, Is.EqualTo(_configuration.Amount));
        }
    }
}
