using System;
using System.ComponentModel.Composition;
using OpenCBS.CoreDomain.Contracts.Loans.CalculateInstallments.Declining;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Monthly")]
    public class MonthlyPeriodPolicy : IPeriodPolicy
    {
        public DateTime GetNextDate(DateTime date)
        {
            return date.AddMonths(1);
        }
        public DateTime GetNextRepaymentDate(DateTime date, IDateShiftPolicy shiftPolicy)
        {
            return shiftPolicy.ShiftDate(date.AddMonths(1));
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddMonths(-1);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return (date - GetPreviousDate(date)).Days;
        }

        public int GetNumberOfDays(Installment installment, IDateShiftPolicy shiftPolicy)
        {
            return (shiftPolicy.ShiftDate(installment.ExpectedDate) - shiftPolicy.ShiftDate(installment.StartDate)).Days;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return 12;
        }
    }
}
