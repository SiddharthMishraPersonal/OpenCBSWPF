using System;
using NUnit.Framework;
using OpenCBS.Engine.DatePolicy;

namespace OpenCBS.Engine.Test.DatePolicy
{
    [TestFixture]
    public class ForwardDateShiftPolicyTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Non-working day policy cannot be null.")]
        public void ShiftDate_GivenNonWorkingDayPolicyIsNull_ThrowsException()
        {
            var dateShiftPolicy = new ForwardDateShiftPolicy(null);
            dateShiftPolicy.ShiftDate(DateTime.Today);
        }

        [Test]
        public void ShiftDate_GivenFirstOfJanuaryAsHolidayAndPassThisDate_ReturnsSecondOfJanuary()
        {
            var holidayPolicy = new HolidayPolicy();
            var firstOfJanuary = new DateTime(2013, 1, 1);
            holidayPolicy.AddHoliday(firstOfJanuary);
            var dateShiftPolicy = new ForwardDateShiftPolicy(holidayPolicy);
            var secondOfJanuary = new DateTime(2013, 1, 2);
            Assert.That(dateShiftPolicy.ShiftDate(firstOfJanuary), Is.EqualTo(secondOfJanuary));
        }

        [Test]
        public void ShiftDate_GivenSaturdayAndSundayAsWeekendsAndPassSaturday_ReturnsNextMonday()
        {
            var weekendPolicy = new WeekendPolicy();
            weekendPolicy.AddWeekend(DayOfWeek.Saturday);
            weekendPolicy.AddWeekend(DayOfWeek.Sunday);
            var dateShiftPolicy = new ForwardDateShiftPolicy(weekendPolicy);
            var saturday = new DateTime(2013, 6, 8);
            var nextMonday = new DateTime(2013, 6, 10);
            Assert.That(dateShiftPolicy.ShiftDate(saturday), Is.EqualTo(nextMonday));
        }
    }
}
