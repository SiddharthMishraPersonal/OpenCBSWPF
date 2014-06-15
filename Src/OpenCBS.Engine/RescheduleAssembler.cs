using System.Collections.Generic;
using System.Linq;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class RescheduleAssembler
    {
        public IEnumerable<Installment> AssembleRescheduling(
            IEnumerable<Installment> schedule,
            IScheduleConfiguration scheduleConfiguration,
            IScheduleConfiguration rescheduleConfiguration,
            IScheduleBuilder scheduleBuilder,
            decimal currentOlb)
        {
            // Build a new combined schedule

            // 1. To close all active installments before date of rescheduling.

            // Get the part of the schedule that comes before the rescheduling date...
            var newSchedule =
                from installment in schedule
                where installment.ExpectedDate <= rescheduleConfiguration.StartDate
                select installment;

            // Get overpaid principal = sum of paid principal after the rescheduling date...
            var overpaidPrincipal = (
                from installment in schedule
                where installment.PaidDate > rescheduleConfiguration.StartDate
                select installment
            ).Sum(installment => installment.PaidCapital.Value);

            //Add overpaid principal to paid principal of the last installment before the rescheduling
            if (newSchedule.Any())
                newSchedule.Last().PaidCapital += overpaidPrincipal;

            // Close all active installments before date of rescheduling
            var olbDifference = 0m;
            foreach (var installment in newSchedule)
            {
                installment.OLB += olbDifference;
                olbDifference += installment.CapitalRepayment.Value - installment.PaidCapital.Value;
                installment.CapitalRepayment = installment.PaidCapital;
                installment.InterestsRepayment = installment.PaidInterests;
            }

            // 2. To store amounts of interest paid, those for installments after date of rescheduling.
            var overpaidInterest = (
                from installment in schedule
                where installment.ExpectedDate > rescheduleConfiguration.StartDate
                select installment
            ).Sum(installment => installment.PaidInterests.Value);


            // 3. To get total of first calculated interest. It will be interest between last closed installment and date of rescheduling 
	        //    plus interest between date of rescheduling and first repayment date

            //    To calculate extra interest for used days.
            //    For the case when date of rescheduling < date of first installment
            
            var usedDays = 0;
            if (newSchedule.Any())
            {
                usedDays = (rescheduleConfiguration.StartDate - newSchedule.Last().ExpectedDate).Days;
            }
            var daysInYear = scheduleConfiguration.YearPolicy.GetNumberOfDays(rescheduleConfiguration.StartDate);
            var extraInterest = currentOlb*scheduleConfiguration.InterestRate/100*usedDays/daysInYear;

            // To calculate interest between date of rescheduling and first repayment date.
            var daysTillRepayment =
                (rescheduleConfiguration.PreferredFirstInstallmentDate - rescheduleConfiguration.StartDate).Days;
            decimal firstInterest = 0;
            if (rescheduleConfiguration.GracePeriod == 0 || rescheduleConfiguration.ChargeInterestDuringGracePeriod)
                firstInterest = currentOlb*rescheduleConfiguration.InterestRate/100*daysTillRepayment/daysInYear;

            // 4. We generate new schedule according to new parametrs.
            rescheduleConfiguration.Amount = currentOlb;
            rescheduleConfiguration.AdjustmentPolicy = scheduleConfiguration.AdjustmentPolicy;
            rescheduleConfiguration.CalculationPolicy = scheduleConfiguration.CalculationPolicy;
            rescheduleConfiguration.DateShiftPolicy = scheduleConfiguration.DateShiftPolicy;
            rescheduleConfiguration.PeriodPolicy = scheduleConfiguration.PeriodPolicy;
            rescheduleConfiguration.RoundingPolicy = scheduleConfiguration.RoundingPolicy;
            rescheduleConfiguration.YearPolicy = scheduleConfiguration.YearPolicy;
            var rescheduled = scheduleBuilder.BuildSchedule(rescheduleConfiguration);

            // Adjust the new schedule's installment numbers
            var increment = newSchedule.Count();
            foreach (var installment in rescheduled)
            {
                installment.Number += increment;
            }

            // Distribute the extra and overpaid interest
            if (rescheduleConfiguration.GracePeriod > 0 && !rescheduleConfiguration.ChargeInterestDuringGracePeriod)
                rescheduled[rescheduleConfiguration.GracePeriod].InterestsRepayment +=
                    rescheduleConfiguration.RoundingPolicy.Round(extraInterest);
            else
                rescheduled.First().InterestsRepayment =
                    rescheduleConfiguration.RoundingPolicy.Round(firstInterest + extraInterest);
            foreach (var installment in rescheduled)
            {
                if (installment.InterestsRepayment < overpaidInterest)
                {
                    installment.PaidInterests = installment.InterestsRepayment;
                    overpaidInterest -= installment.InterestsRepayment.Value;
                }
                else
                {
                    installment.PaidInterests = overpaidInterest;
                    break;
                }
            }

            var result = new List<Installment>();
            result.AddRange(newSchedule);
            result.AddRange(rescheduled);

            return result;
        }
    }
}
