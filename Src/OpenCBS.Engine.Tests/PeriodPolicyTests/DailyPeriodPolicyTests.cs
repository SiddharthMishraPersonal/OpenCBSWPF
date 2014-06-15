using System;
using NUnit.Framework;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test.PeriodPolicyTests
{
    [TestFixture]
    public class DailyPeriodPolicyTests
    {
        [Test]
        public void GetNextDate_ReturnsNextDay()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            Assert.That(policy.GetNextDate(date), Is.EqualTo(new DateTime(2013, 6, 8)));
        }

        [Test]
        public void GetPreviousDate_ReturnsPreviousDay()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            Assert.That(policy.GetPreviousDate(date), Is.EqualTo(new DateTime(2013, 6, 6)));
        }

        [Test]
        public void GetNumberOfDays_ReturnsOne()
        {
            var date = DateTime.Today;
            var policy = new DailyPeriodPolicy();
            Assert.That(policy.GetNumberOfDays(date), Is.EqualTo(1));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_ActualDayYearPolicy_ReturnsActualNumberOfDays()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            var yearPolicy = new ActualNumberOfDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(365));
            date = new DateTime(2012, 6, 7);
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(366));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_360DayYearPolicy_Returns360()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            var yearPolicy = new ThreeHundredSixtyDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(360));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_365DayYearPolicy_Returns365()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            var yearPolicy = new ThreeHundredSixtyFiveDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(365));
            date = new DateTime(2012, 6, 7);
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(365));
        }
    }
}
