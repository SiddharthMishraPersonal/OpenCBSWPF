
using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface ITrancheConfiguration : IBaseScheduleConfiguration, ICloneable
    {
        bool ApplyNewInterestRateToOlb { get; set; }
        bool ChargeInterestDuringGracePeriod { get; set; }
    }
}
