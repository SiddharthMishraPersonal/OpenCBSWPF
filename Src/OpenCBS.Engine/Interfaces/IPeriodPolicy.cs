using System;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.Engine.Interfaces
{
    public interface IPeriodPolicy : IPolicy
    {
        DateTime GetNextDate(DateTime date);
        DateTime GetNextRepaymentDate(DateTime date, IDateShiftPolicy shiftPolicy);
        DateTime GetPreviousDate(DateTime date);
        int GetNumberOfDays(DateTime date);
        int GetNumberOfDays(Installment instalment, IDateShiftPolicy shiftPolicy);
        double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy);
    }
}
