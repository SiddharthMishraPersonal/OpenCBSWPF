using System;
using NUnit.Framework;
using OpenCBS.Engine.DatePolicy;

namespace OpenCBS.Engine.Test.DatePolicy
{
    [TestFixture]
    public class NoDateShiftPolicyTests
    {
        [Test]
        public void ShiftDate_AnyDate_ReturnsSameDate()
        {
            var policy = new NoDateShiftPolicy();
            var saturday = new DateTime(2013, 6, 8);
            var firstOfJanuary = new DateTime(2013, 1, 1);
            Assert.That(policy.ShiftDate(saturday), Is.EqualTo(saturday));
            Assert.That(policy.ShiftDate(firstOfJanuary), Is.EqualTo(firstOfJanuary));
        }
    }
}
