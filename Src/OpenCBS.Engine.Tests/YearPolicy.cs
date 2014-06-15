using System;
using NUnit.Framework;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class YearPolicy
    {
        [Test]
        public void YearPolicy_ActualDayYearPolicy_ReturnsNumberOfDaysInYear()
        {
            var yearPolicy = new ActualNumberOfDayYearPolicy();
            var nonLeapYearDate = new DateTime(2013, 6, 7);
            var leapYearDate = new DateTime(2012, 6, 7);
            Assert.That(yearPolicy.GetNumberOfDays(nonLeapYearDate), Is.EqualTo(365));
            Assert.That(yearPolicy.GetNumberOfDays(leapYearDate), Is.EqualTo(366));
        }

        [Test]
        public void YearPolicy_360DayYearPolicy_Returns360()
        {
            var yearPolicy = new ThreeHundredSixtyDayYearPolicy();
            var nonLeapYearDate = new DateTime(2013, 6, 7);
            var leapYearDate = new DateTime(2012, 6, 7);
            Assert.That(yearPolicy.GetNumberOfDays(nonLeapYearDate), Is.EqualTo(360));
            Assert.That(yearPolicy.GetNumberOfDays(leapYearDate), Is.EqualTo(360));
        }

        [Test]
        public void YearPolicy_365DayYearPolicy_Returns365()
        {
            var yearPolicy = new ThreeHundredSixtyFiveDayYearPolicy();
            var nonLeapYearDate = new DateTime(2013, 6, 7);
            var leapYearDate = new DateTime(2012, 6, 7);
            Assert.That(yearPolicy.GetNumberOfDays(nonLeapYearDate), Is.EqualTo(365));
            Assert.That(yearPolicy.GetNumberOfDays(leapYearDate), Is.EqualTo(365));
        }
    }
}
