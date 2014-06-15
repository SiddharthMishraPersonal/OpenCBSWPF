using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface IBaseScheduleConfiguration
    {
        DateTime StartDate { get; set; }
        DateTime PreferredFirstInstallmentDate { get; set; }
        int NumberOfInstallments { get; set; }
        int GracePeriod { get; set; }
        decimal Amount { get; set; }
        decimal InterestRate { get; set; }
    }
}
