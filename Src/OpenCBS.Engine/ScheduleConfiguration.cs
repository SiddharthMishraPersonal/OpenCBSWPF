
using System;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class ScheduleConfiguration : IScheduleConfiguration
    {
        public DateTime StartDate { get; set; }

        public DateTime PreferredFirstInstallmentDate { get; set; }

        public int NumberOfInstallments { get; set; }

        public int GracePeriod { get; set; }

        public bool ChargeInterestDuringGracePeriod { get; set; }

        public decimal Amount { get; set; }

        public IPeriodPolicy PeriodPolicy { get; set; }

        public IYearPolicy YearPolicy { get; set; }

        public IRoundingPolicy RoundingPolicy { get; set; }

        public IInstallmentCalculationPolicy CalculationPolicy { get; set; }

        public IAdjustmentPolicy AdjustmentPolicy { get; set; }

        public decimal InterestRate { get; set; }

        public decimal PreviousInterestRate { get; set; }

        public IDateShiftPolicy DateShiftPolicy { get; set; }

        public ScheduleConfiguration()
        {
            ChargeInterestDuringGracePeriod = true;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool ChargeActualInterestForFirstInstallment { get; set; }
    }
}
