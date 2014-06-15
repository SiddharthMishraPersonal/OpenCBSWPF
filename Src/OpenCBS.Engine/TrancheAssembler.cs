using System.Collections.Generic;
using System.Linq;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;
using IInstallment = OpenCBS.Engine.Interfaces.IInstallment;

namespace OpenCBS.Engine
{
    public class TrancheAssembler
    {
        public IEnumerable<Installment> AssembleTranche(
            IEnumerable<Installment> schedule,
            IScheduleConfiguration scheduleConfiguration,
            ITrancheConfiguration trancheConfiguration,
            IScheduleBuilder scheduleBuilder,
            ITrancheBuilder trancheBuilder)
        {
            // Build a new combined schedule
            var trancheSchedule = trancheBuilder.BuildTranche(schedule, scheduleBuilder, scheduleConfiguration, trancheConfiguration);

            // Get an interested paid in advance, whereas "in advance" means after the new tranche date
            var overpaidInterest = (
                from installment in schedule
                where installment.ExpectedDate > trancheConfiguration.StartDate
                select installment
            ).Sum(installment => installment.PaidInterests.Value);

            // Get the part of the schedule that comes before the tranche date...
            var newSchedule =
                from installment in schedule
                where installment.ExpectedDate <= trancheConfiguration.StartDate
                select installment;

            // ...and force close it (set expected equal to paid)
            var olbDifference = 0m;
            foreach (var installment in newSchedule)
            {
                installment.OLB += olbDifference;
                olbDifference += installment.CapitalRepayment.Value - installment.PaidCapital.Value;
                if (!(installment.CapitalRepayment == installment.PaidCapital && installment.InterestsRepayment == installment.PaidInterests))
                {
                    installment.PaidDate = trancheConfiguration.StartDate;
                }
                installment.CapitalRepayment = installment.PaidCapital;
                installment.InterestsRepayment = installment.PaidInterests;
            }

            // Adjust the new schedule's installment numbers
            var increment = newSchedule.Count();
            foreach (var installment in trancheSchedule)
            {
                installment.Number += increment;
            }
            var result = new List<Installment>();
            result.AddRange(newSchedule);

            // Distribute the overpaid interest
            foreach (var installment in trancheSchedule)
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

            result.AddRange(trancheSchedule);
            return result;
        }
    }
}
