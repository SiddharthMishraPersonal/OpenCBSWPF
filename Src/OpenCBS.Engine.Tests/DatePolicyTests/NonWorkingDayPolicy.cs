using System;
using NUnit.Framework;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.Test.DatePolicy
{
    [TestFixture]
    public class NonWorkingDayPolicyTests
    {
        private WeekendPolicy _weekendPolicy;
        private HolidayPolicy _holidayPolicy;
        private INonWorkingDayPolicy _policy;

        [SetUp]
        public void SetUp()
        {
            _weekendPolicy = new WeekendPolicy();
            _weekendPolicy.AddWeekend(DayOfWeek.Saturday);
            _weekendPolicy.AddWeekend(DayOfWeek.Sunday);
            _holidayPolicy = new HolidayPolicy();
            _holidayPolicy.AddHoliday(new DateTime(2013, 1, 1));
            _policy = new NonWorkingDayPolicy(_weekendPolicy, _holidayPolicy);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Weekend policy cannot be null.")]
        public void IsNonWorkingDay_GivenWeekendPolicyIsNull_ThrowsException()
        {
            var policy = new NonWorkingDayPolicy(null, _holidayPolicy);
            policy.IsNonWorkingDay(DateTime.Today);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Holiday policy cannot be null.")]
        public void IsNonWorkingDay_GivenHolidayPolicyIsNull_ThrowsException()
        {
            var policy = new NonWorkingDayPolicy(_weekendPolicy, null);
            policy.IsNonWorkingDay(DateTime.Today);
        }

        [Test]
        public void IsNonWorkingDay_GivenFirstOfJanuary_ReturnsTrue()
        {
            var firstOfJanuary = new DateTime(2013, 1, 1);
            Assert.That(_policy.IsNonWorkingDay(firstOfJanuary), Is.EqualTo(true));
        }

        [Test]
        public void IsNonWorkingDay_GivenSunday_ReturnsTrue()
        {
            var sunday = new DateTime(2013, 6, 9);
            Assert.That(_policy.IsNonWorkingDay(sunday), Is.EqualTo(true));
        }

        [Test]
        public void IsNonWorkingDay_GivenAWorkingDay_ReturnsFalse()
        {
            var workingDay = new DateTime(2013, 7, 10);
            Assert.That(_policy.IsNonWorkingDay(workingDay), Is.EqualTo(false));
        }
    }
}
