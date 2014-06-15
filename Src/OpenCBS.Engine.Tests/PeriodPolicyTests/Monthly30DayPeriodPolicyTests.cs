using System;
using NUnit.Framework;
using OpenCBS.Engine.Interfaces;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test.PeriodPolicyTests
{
    [TestFixture]
    public class Monthly30DayPeriodPolicyTests
    {
        [Test]
        public void GetNextDate_ReturnsNextMonth()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new Monthly30DayPeriodPolicy();
            Assert.That(policy.GetNextDate(date), Is.EqualTo(new DateTime(2013, 7, 7)));
        }

        [Test]
        public void GetPreviousDate_ReturnsPreviousMonth()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new Monthly30DayPeriodPolicy();
            Assert.That(policy.GetPreviousDate(date), Is.EqualTo(new DateTime(2013, 5, 7)));
        }

        [Test]
        public void GetNumberOfDays_Returns30()
        {
            var date1 = new DateTime(2013, 2, 1);
            var date2 = new DateTime(2013, 3, 1);
            var date3 = new DateTime(2013, 4, 1);
            var date4 = new DateTime(2013, 5, 1);
            var policy = new Monthly30DayPeriodPolicy();
            Assert.That(policy.GetNumberOfDays(date1), Is.EqualTo(30));
            Assert.That(policy.GetNumberOfDays(date2), Is.EqualTo(30));
            Assert.That(policy.GetNumberOfDays(date3), Is.EqualTo(30));
            Assert.That(policy.GetNumberOfDays(date4), Is.EqualTo(30));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_Returns12()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new Monthly30DayPeriodPolicy();
            IYearPolicy yearPolicy = new ActualNumberOfDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(12));
            yearPolicy = new ThreeHundredSixtyDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(12));
            yearPolicy = new ThreeHundredSixtyFiveDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(12));
        }
    }
}
