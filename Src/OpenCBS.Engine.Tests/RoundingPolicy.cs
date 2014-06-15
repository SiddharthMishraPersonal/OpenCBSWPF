using NUnit.Framework;
using OpenCBS.Engine.RoundingPolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class RoundingPolicy
    {
        [Test]
        public void TwoDecimalRoundingPolicy_RoundsToTwoDecimals()
        {
            var policy = new TwoDecimalRoundingPolicy();
            Assert.That(policy.Round(100.555m), Is.EqualTo(100.56));
            Assert.That(policy.Round(100.554m), Is.EqualTo(100.55));
        }

        [Test]
        public void IntegerRoundingPolicy_RoundsToInteger()
        {
            var policy = new IntegerRoundingPolicy();
            Assert.That(policy.Round(100.555m), Is.EqualTo(101));
            Assert.That(policy.Round(100.5m), Is.EqualTo(101));
            Assert.That(policy.Round(100.3m), Is.EqualTo(100));
        }
    }
}
