using System;
using System.Collections.Generic;
using System.Linq;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class TrancheBuilder : ITrancheBuilder
    {
        private DateTime GetLastEndDate(IEnumerable<Installment> schedule, ITrancheConfiguration trancheConfiguration)
        {
            var installment = (from i in schedule
                               where i.ExpectedDate <= trancheConfiguration.StartDate
                               select i).LastOrDefault();
            if (installment == null) return schedule.First().StartDate;
            return installment.ExpectedDate;
        }

        private decimal GetExtraInterest(IEnumerable<Installment> schedule,
                                         IScheduleConfiguration scheduleConfiguration,
                                         ITrancheConfiguration trancheConfiguration)
        {
            var days = (trancheConfiguration.StartDate - GetLastEndDate(schedule, trancheConfiguration)).Days;
            var daysInYear = scheduleConfiguration.YearPolicy.GetNumberOfDays(trancheConfiguration.StartDate);
            var olb = schedule.Sum(i => i.CapitalRepayment.Value - i.PaidCapital.Value);
            var interest = olb * scheduleConfiguration.InterestRate / 100 * days / daysInYear;
            return scheduleConfiguration.RoundingPolicy.Round(interest);
        }

        public List<Installment> BuildTranche(IEnumerable<Installment> schedule, IScheduleBuilder scheduleBuilder, IScheduleConfiguration scheduleConfiguration, ITrancheConfiguration trancheConfiguration)
        {
            var rhc = (IScheduleConfiguration)scheduleConfiguration.Clone();
            rhc.Amount = trancheConfiguration.Amount;
            rhc.NumberOfInstallments = trancheConfiguration.NumberOfInstallments;
            rhc.GracePeriod = trancheConfiguration.GracePeriod;
            rhc.InterestRate = trancheConfiguration.InterestRate;
            rhc.StartDate = trancheConfiguration.StartDate;
            rhc.PreferredFirstInstallmentDate = trancheConfiguration.PreferredFirstInstallmentDate;

            var lhc = (IScheduleConfiguration)rhc.Clone();
            lhc.Amount = schedule.Sum(i => i.CapitalRepayment.Value - i.PaidCapital.Value);
            if (!trancheConfiguration.ApplyNewInterestRateToOlb)
            {
                lhc.InterestRate = scheduleConfiguration.InterestRate;
            }

            var lhs = scheduleBuilder.BuildSchedule(lhc);
            var rhs = scheduleBuilder.BuildSchedule(rhc);

            var result = new List<Installment>();

            // Merge the two schedules
            var max = Math.Max(lhs.Count, rhs.Count);
            for (var i = 0; i < max; i++)
            {
                var lhi = i >= lhs.Count ? null : lhs[i];
                var rhi = i >= rhs.Count ? null : rhs[i];

                Installment installment;

                if (lhi == null)
                {
                    installment = rhi;
                }
                else if (rhi == null)
                {
                    installment = lhi;
                }
                else
                {
                    installment = new Installment
                    {
                        Number = lhi.Number,
                        StartDate = lhi.StartDate,
                        ExpectedDate = lhi.ExpectedDate,
                        //RepaymentDate = lhi.RepaymentDate,
                        CapitalRepayment = lhi.CapitalRepayment + rhi.CapitalRepayment,
                        InterestsRepayment = lhi.InterestsRepayment + rhi.InterestsRepayment,
                        OLB = lhi.OLB + rhi.OLB,
                    };
                }
                result.Add(installment);
            }

            result[0].InterestsRepayment += GetExtraInterest(schedule, scheduleConfiguration, trancheConfiguration);
            return result;
        }
    }
}
