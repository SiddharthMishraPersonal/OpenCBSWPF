using System;
using NUnit.Framework;
using OpenCBS.Engine.DatePolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class WeekendPolicyTests
    {
        [Test]
        public void IsNonWorkingDay_GivenSaturdayAndSundayAsWeekends_WhenPassMondayToFridayReturnsFalse()
        {
            var policy = new WeekendPolicy();
            policy.AddWeekend(DayOfWeek.Saturday);
            policy.AddWeekend(DayOfWeek.Sunday);

            // 3rd to 7th June 2013 are working days
            for (var day = 3; day <= 7; day++)
            {
                var date = new DateTime(2013, 6, day);
                Assert.That(policy.IsNonWorkingDay(date), Is.EqualTo(false));
            }
        }

        [Test]
        public void IsNonWorkingDay_GivenSaturdayAndSundayAsWeekends_WhenPassSundayReturnsTrue()
        {
            var policy = new WeekendPolicy();
            policy.AddWeekend(DayOfWeek.Saturday);
            policy.AddWeekend(DayOfWeek.Sunday);
            var date = new DateTime(2013, 6, 9);
            Assert.That(policy.IsNonWorkingDay(date), Is.EqualTo(true));
        }

        [Test]
        public void IsNonWorkingDay_GivenFridayAndSundayAsWeekends_WhenPassFridayReturnsTrue()
        {
            var policy = new WeekendPolicy();
            policy.AddWeekend(DayOfWeek.Friday);
            policy.AddWeekend(DayOfWeek.Sunday);
            var date = new DateTime(2013, 6, 7);
            Assert.That(policy.IsNonWorkingDay(date), Is.EqualTo(true));
        }

        [Test]
        public void IsNonWorkingDay_GivenFridayAndSundayAsWeekends_WhenPassSaturdayReturnsFalse()
        {
            var policy = new WeekendPolicy();
            policy.AddWeekend(DayOfWeek.Friday);
            policy.AddWeekend(DayOfWeek.Sunday);
            var date = new DateTime(2013, 6, 8);
            Assert.That(policy.IsNonWorkingDay(date), Is.EqualTo(false));
        }
    }
}
