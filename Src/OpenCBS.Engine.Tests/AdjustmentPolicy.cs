using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Engine.AdjustmentPolicy;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class AdjustmentPolicy
    {
        private IScheduleConfiguration _configuration;
            
        [SetUp]
        public void SetUp()
        {
            _configuration = new ScheduleConfiguration
            {
                Amount = 3000,
            };
        }

        [Test]
        public void FirstInstallmentAdjustmentPolicy_WhenTotalIsMore_FirstInstallmentIsDecreased()
        {
            var installments = new List<IInstallment>
            {
                new Installment { Principal = 1001 },
                new Installment { Principal = 1001 },
                new Installment { Principal = 1001 },
            };
            var policy = new FirstInstallmentAdjustmentPolicy();
            policy.Adjust(installments, _configuration);
            Assert.That(installments[0].Principal, Is.EqualTo(998));
            Assert.That(installments[1].Principal, Is.EqualTo(1001));
            Assert.That(installments[2].Principal, Is.EqualTo(1001));
        }

        [Test]
        public void FirstInstallmentAdjustmentPolicy_WhenTotalIsLess_FirstInstallmentIsIncreased()
        {
            var installments = new List<IInstallment>
            {
                new Installment { Principal = 999 },
                new Installment { Principal = 999 },
                new Installment { Principal = 999 },
            };
            var policy = new FirstInstallmentAdjustmentPolicy();
            policy.Adjust(installments, _configuration);
            Assert.That(installments[0].Principal, Is.EqualTo(1002));
            Assert.That(installments[1].Principal, Is.EqualTo(999));
            Assert.That(installments[2].Principal, Is.EqualTo(999));
        }

        [Test]
        public void FirstIntallmentAdjustmentPolicy_OlbIsAdjusted()
        {
            var installments = new List<IInstallment>
            {
                new Installment { Principal = 999, Olb = 3000 },
                new Installment { Principal = 999, Olb = 2000 },
                new Installment { Principal = 999, Olb = 1000 },
            };
            var policy = new FirstInstallmentAdjustmentPolicy();
            policy.Adjust(installments, _configuration);
            Assert.That(installments[0].Olb, Is.EqualTo(3000));
            Assert.That(installments[1].Olb, Is.EqualTo(1998));
            Assert.That(installments[2].Olb, Is.EqualTo(999));
        }

        [Test]
        public void FirstInstallmentAdjustmentPolicy_GracePeriodOfOne_AdjustedToSecondInstallment()
        {
            _configuration.GracePeriod = 1;
            var installments = new List<IInstallment>
            {
                new Installment { Principal = 0 },
                new Installment { Principal = 999 },
                new Installment { Principal = 999 },
                new Installment { Principal = 999 },
            };
            var policy = new FirstInstallmentAdjustmentPolicy();
            policy.Adjust(installments, _configuration);
            Assert.That(installments[0].Principal, Is.EqualTo(0));
            Assert.That(installments[1].Principal, Is.EqualTo(1002));
        }


        [Test]
        public void LastInstallmentAdjustmentPolicy_WhenTotalIsMore_LastInstallmentIsDecreased()
        {
            var installments = new List<IInstallment>
            {
                new Installment { Principal = 1001 },
                new Installment { Principal = 1001 },
                new Installment { Principal = 1001 },
            };
            var policy = new LastInstallmentAdjustmentPolicy();
            policy.Adjust(installments, _configuration);
            Assert.That(installments[0].Principal, Is.EqualTo(1001));
            Assert.That(installments[1].Principal, Is.EqualTo(1001));
            Assert.That(installments[2].Principal, Is.EqualTo(998));
        }

        [Test]
        public void LastInstallmentAdjustmentPolicy_WhenTotalIsLess_LastInstallmentIsIncreased()
        {
            var installments = new List<IInstallment>
            {
                new Installment { Principal = 999 },
                new Installment { Principal = 999 },
                new Installment { Principal = 999 },
            };
            var policy = new LastInstallmentAdjustmentPolicy();
            policy.Adjust(installments, _configuration);
            Assert.That(installments[0].Principal, Is.EqualTo(999));
            Assert.That(installments[1].Principal, Is.EqualTo(999));
            Assert.That(installments[2].Principal, Is.EqualTo(1002));
        }
    }
}
