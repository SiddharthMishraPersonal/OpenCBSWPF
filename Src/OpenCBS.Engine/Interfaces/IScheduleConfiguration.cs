
using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface IScheduleConfiguration : IBaseScheduleConfiguration, ICloneable
    {
        IPeriodPolicy PeriodPolicy { get; set; }
        IYearPolicy YearPolicy { get; set; }
        IRoundingPolicy RoundingPolicy { get; set; }
        IInstallmentCalculationPolicy CalculationPolicy { get; set; }
        IAdjustmentPolicy AdjustmentPolicy { get; set; }
        IDateShiftPolicy DateShiftPolicy { get; set; }
        bool ChargeInterestDuringGracePeriod { get; set; }
        bool ChargeActualInterestForFirstInstallment { get; set; }
    }
}
