using System;
using System.ComponentModel.Composition;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Custom")]
    public class CustomPeriodPolicy : IPeriodPolicy
    {
        private int _numberOfDays;

        public CustomPeriodPolicy()
        {
            _numberOfDays = 0;
        }

        public CustomPeriodPolicy(int numberOfDays)
        {
            _numberOfDays = numberOfDays;
        }

        public DateTime GetNextDate(DateTime date)
        {
            return date.AddDays(_numberOfDays);
        }

        public DateTime GetNextRepaymentDate(DateTime date, IDateShiftPolicy shiftPolicy)
        {
            return shiftPolicy.ShiftDate(date.AddDays(_numberOfDays));
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddDays(-_numberOfDays);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return _numberOfDays;
        }

        public int GetNumberOfDays(Installment installment, IDateShiftPolicy shiftPolicy)
        {
            return (shiftPolicy.ShiftDate(installment.ExpectedDate) - shiftPolicy.ShiftDate(installment.StartDate)).Days;
        }

        public void SetNumberOfDays(int numberOfDays)
        {
            _numberOfDays = numberOfDays;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return (double) yearPolicy.GetNumberOfDays(date) / _numberOfDays;
        }
    }
}
