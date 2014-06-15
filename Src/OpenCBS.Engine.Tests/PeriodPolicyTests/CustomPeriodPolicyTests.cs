using System;
using NUnit.Framework;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test.PeriodPolicyTests
{
    [TestFixture]
    public class CustomPeriodPolicyTests
    {
        [Test]
        public void GetNextDate_WeeklyPeriod_ReturnsNextWeek()
        {
            var date = new DateTime(2013, 6, 11);
            var policy = new CustomPeriodPolicy(7);
            Assert.That(policy.GetNextDate(date), Is.EqualTo(new DateTime(2013, 6, 18)));
        }

        [Test]
        public void GetPreviousDate_WeeklyPeriod_ReturnsPreviousWeek()
        {
            var date = new DateTime(2013, 6, 11);
            var policy = new CustomPeriodPolicy(7);
            Assert.That(policy.GetPreviousDate(date), Is.EqualTo(new DateTime(2013, 6, 4)));
        }

        [Test]
        public void GetNumberOfDays_WeeklyPeriod_ReturnsSeven()
        {
            var date = new DateTime(2013, 6, 11);
            var policy = new CustomPeriodPolicy(7);
            Assert.That(policy.GetNumberOfDays(date), Is.EqualTo(7));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_WeeklyPeriodAndActualDayYearPolicy_ReturnsCorrectNumber()
        {
            var date = new DateTime(2013, 6, 11);
            var policy = new CustomPeriodPolicy(7);
            var yearPolicy = new ActualNumberOfDayYearPolicy();
            Assert.That(Math.Round(policy.GetNumberOfPeriodsInYear(date, yearPolicy), 2), Is.EqualTo(52.14));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_WeeklyPeriodAnd360DayYearPolicy_ReturnsCorrectNumber()
        {
            var date = new DateTime(2013, 6, 11);
            var policy = new CustomPeriodPolicy(7);
            var yearPolicy = new ThreeHundredSixtyDayYearPolicy();
            Assert.That(Math.Round(policy.GetNumberOfPeriodsInYear(date, yearPolicy), 2), Is.EqualTo(51.43));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_WeeklyPeriodAnd365DayYearPolicy_ReturnsCorrectNumber()
        {
            var date = new DateTime(2013, 6, 11);
            var policy = new CustomPeriodPolicy(7);
            var yearPolicy = new ThreeHundredSixtyFiveDayYearPolicy();
            Assert.That(Math.Round(policy.GetNumberOfPeriodsInYear(date, yearPolicy), 2), Is.EqualTo(52.14));
        }
    }
}
