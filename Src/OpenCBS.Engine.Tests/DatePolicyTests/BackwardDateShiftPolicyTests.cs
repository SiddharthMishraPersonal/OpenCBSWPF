using System;
using NUnit.Framework;
using OpenCBS.Engine.DatePolicy;

namespace OpenCBS.Engine.Test.DatePolicy
{
    [TestFixture]
    public class BackwardDateShiftPolicyTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Non-working day policy cannot be null.")]
        public void ShiftDate_GivenNonWorkingDayPolicyIsNull_ThrowsException()
        {
            var dateShiftPolicy = new BackwardDateShiftPolicy(null);
            dateShiftPolicy.ShiftDate(DateTime.Today);
        }

        [Test]
        public void ShiftDate_GivenSaturdayAndSundayAsWeekendsAndPassSunday_ReturnsPreviousFirday()
        {
            var weekendPolicy = new WeekendPolicy();
            weekendPolicy.AddWeekend(DayOfWeek.Saturday);
            weekendPolicy.AddWeekend(DayOfWeek.Sunday);
            var dateShiftPolicy = new BackwardDateShiftPolicy(weekendPolicy);
            var sunday = new DateTime(2013, 6, 9);
            var friday = new DateTime(2013, 6, 7);
            Assert.That(dateShiftPolicy.ShiftDate(sunday), Is.EqualTo(friday));
        }

        [Test]
        public void ShiftDate_GivenFirstOfJanuaryAsHolidayAndPassThisDate_ReturnsThirtyFirstOfDecember()
        {
            var holidayPolicy = new HolidayPolicy();
            var firstOfJanuary = new DateTime(2013, 1, 1);
            holidayPolicy.AddHoliday(firstOfJanuary);
            var dateShiftPolicy = new BackwardDateShiftPolicy(holidayPolicy);
            var thirtyFirstOfDecember = new DateTime(2012, 12, 31);
            Assert.That(dateShiftPolicy.ShiftDate(firstOfJanuary), Is.EqualTo(thirtyFirstOfDecember));
        }
    }
}
