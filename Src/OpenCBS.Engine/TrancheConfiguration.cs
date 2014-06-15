using System;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class TrancheConfiguration : ITrancheConfiguration
    {
        public bool ApplyNewInterestRateToOlb { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime PreferredFirstInstallmentDate { get; set; }

        public int NumberOfInstallments { get; set; }

        public int GracePeriod { get; set; }

        public bool ChargeInterestDuringGracePeriod { get; set; }

        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; }

        public TrancheConfiguration()
        {
            ChargeInterestDuringGracePeriod = true;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
