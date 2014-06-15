using System;
using NUnit.Framework;
using OpenCBS.Engine.DatePolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class HolidayPolicyTests
    {
        [Test]
        public void IsNonWorkingDay_GivenAHolidayAndPassSameDate_ReturnsTrue()
        {
            var policy = new HolidayPolicy();
            policy.AddHoliday(new DateTime(2013, 5, 1));
            Assert.That(policy.IsNonWorkingDay(new DateTime(2013, 5, 1)), Is.EqualTo(true));
        }

        [Test]
        public void IsNonWorkingDay_GivenAHolidayAndPassDifferentDate_ReturnsFalse()
        {
            var policy = new HolidayPolicy();
            policy.AddHoliday(new DateTime(2013, 5, 1));
            Assert.That(policy.IsNonWorkingDay(new DateTime(2013, 5, 2)), Is.EqualTo(false));
        }
    }
}
