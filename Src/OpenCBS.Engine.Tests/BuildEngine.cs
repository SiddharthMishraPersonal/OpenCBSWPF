using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Engine.AdjustmentPolicy;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.Interfaces;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.RoundingPolicy;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test
{
    static class ScheduleTools
    {
        public static void ForEachButFirst(this List<IInstallment> schedule, Action<IInstallment, IInstallment> action)
        {
            for (var i = 1; i < schedule.Count; i++)
            {
                action(schedule[i - 1], schedule[i]);
            }
        }
    }
    
    [TestFixture]
    public class BuildEngine
    {
        private IScheduleConfiguration _configuration;
        private IScheduleBuilder _builder;

        [SetUp]
        public void BuildEngine_Setup()
        {
            _configuration = new ScheduleConfiguration
            {
                Amount = 10000,
                GracePeriod = 0,
                InterestRate = 0.24m,
                NumberOfInstallments = 5,
                StartDate = new DateTime(2013, 1, 1),
                PreferredFirstInstallmentDate = new DateTime(2013, 2, 5),
                ChargeInterestDuringGracePeriod = true,
                PeriodPolicy = new MonthlyPeriodPolicy(),
                YearPolicy = new ActualNumberOfDayYearPolicy(),
                RoundingPolicy = new TwoDecimalRoundingPolicy(),
                CalculationPolicy = new FlatInstallmentCalculationPolicy(),
                AdjustmentPolicy = new LastInstallmentAdjustmentPolicy(),
                DateShiftPolicy = new NoDateShiftPolicy(),
            };
            _builder = new ScheduleBuilder();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Period policy cannot be null.")]
        public void BuildEngine_PeriodPolicyIsNull_ThrowsException()
        {
            _configuration.PeriodPolicy = null;
            _builder.BuildSchedule(_configuration);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Year policy cannot be null.")]
        public void BuildEngine_YearPolicyIsNull_ThrowsException()
        {
            _configuration.YearPolicy = null;
            _builder.BuildSchedule(_configuration);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Rounding policy cannot be null.")]
        public void BuildEngine_RoundingPolicyIsNull_ThrowsException()
        {
            _configuration.RoundingPolicy = null;
            _builder.BuildSchedule(_configuration);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Installment calculation policy cannot be null.")]
        public void BuildEngine_InstallmentCalculationPolicyIsNull_ThrowsException()
        {
            _configuration.CalculationPolicy = null;
            _builder.BuildSchedule(_configuration);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Adjustment policy cannot be null.")]
        public void BuildEngine_AdjustmentPolicyIsNull_ThrowsException()
        {
            _configuration.AdjustmentPolicy = null;
            _builder.BuildSchedule(_configuration);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException),
            ExpectedMessage = "Grace period should be less than the number of installments.")]
        public void BuildEngine_GracePeriodEqualsNumberOfInstallments_ThrowsException()
        {
            _configuration.GracePeriod = 5;
            _builder.BuildSchedule(_configuration);
        }

        [Test]
        public void BuildEngine_NumberOfInstallmentsMatches()
        {
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule.Count, Is.EqualTo(5));
        }

        [Test]
        public void BuildEngine_GracePeriod_NumberOfInstallmentsMatches()
        {
            _configuration.GracePeriod = 2;
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule.Count, Is.EqualTo(5));
        }

        [Test]
        public void BuildEngine_FirstOlbIsEqualToAmount()
        {
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].Olb, Is.EqualTo(_configuration.Amount));
        }

        [Test]
        public void BuildEngine_FirstInstallmentStartDateIsEqualToScheduleStartDate()
        {
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].StartDate, Is.EqualTo(_configuration.StartDate));
        }

        [Test]
        public void BuildEngine_FirstInstallmentEndDateIsEqualToPreferredFirstInstallmentDate()
        {
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].EndDate, Is.EqualTo(_configuration.PreferredFirstInstallmentDate));
        }

        [Test]
        public void BuildEngine_FirstInstallmentNumberIsOne()
        {
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].Number, Is.EqualTo(1));
        }

        [Test]
        public void BuildEngine_InstallmentNumbersAreConsequtive()
        {
            _builder.BuildSchedule(_configuration).ForEachButFirst((previous, current) =>
            {
                Assert.That(current.Number, Is.EqualTo(previous.Number + 1));
            });
        }

        [Test]
        public void BuildEngine_NextStartDateIsPreviousEndDate()
        {
            _builder.BuildSchedule(_configuration).ForEachButFirst((previous, current) =>
            {
                Assert.That(current.StartDate, Is.EqualTo(previous.EndDate));
            });
        }

        [Test]
        public void BuildEngine_NextOlbIsPreviousOlbMinusPrincipal()
        {
            _builder.BuildSchedule(_configuration).ForEachButFirst((previous, current) =>
            {
                Assert.That(current.Olb, Is.EqualTo(previous.Olb - current.Principal));
            });
        }

        [Test]
        public void BuildEngine_GracePeriod_OlbIsEqualToAmount()
        {
            _configuration.GracePeriod = 2;
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].Olb, Is.EqualTo(_configuration.Amount));
            Assert.That(schedule[1].Olb, Is.EqualTo(_configuration.Amount));
        }

        [Test]
        public void BuildEngine_GracePeriod_PrincipalIsEqualToZero()
        {
            _configuration.GracePeriod = 2;
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].Principal, Is.EqualTo(0));
            Assert.That(schedule[1].Principal, Is.EqualTo(0));
        }

        [Test]
        public void BuildEngine_GracePeriod_InterestIsGreaterThanZero()
        {
            _configuration.GracePeriod = 2;
            var schedule = _builder.BuildSchedule(_configuration);
            Assert.That(schedule[0].Interest, Is.GreaterThan(0));
            Assert.That(schedule[0].Interest, Is.GreaterThan(0));
        }
    }
}
