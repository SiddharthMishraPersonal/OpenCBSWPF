using System;
using System.Collections.Generic;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class ScheduleBuilder : IScheduleBuilder
    {
        public List<Installment> BuildSchedule(IScheduleConfiguration configuration)
        {
            if (configuration.PeriodPolicy == null) throw new ArgumentException("Period policy cannot be null.");
            if (configuration.YearPolicy == null) throw new ArgumentException("Year policy cannot be null.");
            if (configuration.RoundingPolicy == null) throw new ArgumentException("Rounding policy cannot be null.");
            if (configuration.CalculationPolicy == null) throw new ArgumentException("Installment calculation policy cannot be null.");
            if (configuration.AdjustmentPolicy == null) throw new ArgumentException("Adjustment policy cannot be null.");
            if (configuration.DateShiftPolicy == null) throw new ArgumentException("Date shift policy cannot be null.");
            if (configuration.GracePeriod >= configuration.NumberOfInstallments) throw new ArgumentException("Grace period should be less than the number of installments.");

            var installment = BuildFirst(configuration);
            var result = new List<Installment> { installment };

            while ((installment = BuildNext(installment, configuration)) != null)
            {
                result.Add(installment);
            }

            configuration.AdjustmentPolicy.Adjust(result, configuration);

            // CalculationPolicy interest during grace period
            if (configuration.ChargeInterestDuringGracePeriod)
            {
                for (var i = 0; i < configuration.GracePeriod; i++)
                {
                    result[i].InterestsRepayment = CalculateInterest(result[i], configuration);
                }
            }
            // if the difference between start date and first installment date less or greater than period
            if (configuration.GracePeriod == 0 && configuration.ChargeInterestDuringGracePeriod)
            {
                result[0].InterestsRepayment = CalculateFirstInstallmentInterest(result[0], configuration);
            }

            // Initialize RepaymentDate's
            foreach (var i in result)
            {
                i.ExpectedDate = configuration.DateShiftPolicy.ShiftDate(i.ExpectedDate);
            }

            return result;
        }

        private static Installment BuildFirst(IScheduleConfiguration configuration)
        {
            var installment = new Installment
            {
                Number = 1,
                StartDate = configuration.StartDate,
                ExpectedDate = configuration.PreferredFirstInstallmentDate,
                OLB = configuration.Amount,
                CapitalRepayment = 0m,
                InterestsRepayment =  0m,
                FeesUnpaid = 0
            };
            if (configuration.GracePeriod == 0)
            {
                configuration.CalculationPolicy.Calculate(installment, configuration);
            }

            return installment;
        }

        private static Installment BuildNext(Installment previous, IScheduleConfiguration configuration)
        {
            if (previous == null) throw new ArgumentException("Previous installment cannot be null.");

            if (previous.Number == configuration.NumberOfInstallments) return null;
            var installment = new Installment
            {
                Number = previous.Number + 1,
                StartDate = previous.ExpectedDate,
                ExpectedDate = configuration.PeriodPolicy.GetNextDate(previous.ExpectedDate),
                InterestsRepayment = 0m,
                CapitalRepayment = 0m,
                OLB = previous.OLB - previous.CapitalRepayment,
                FeesUnpaid = 0
            };
            if (configuration.GracePeriod < installment.Number)
            {
                configuration.CalculationPolicy.Calculate(installment, configuration);
            }
            return installment;
        }

        private static decimal CalculateInterest(Installment installment, IScheduleConfiguration configuration)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment.ExpectedDate);//, configuration.DateShiftPolicy);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.ExpectedDate);
            var interest = installment.OLB*configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            //if schedule is flat
            if (configuration.CalculationPolicy.GetType() == typeof(FlatInstallmentCalculationPolicy))
            {
                var numberOfPeriods =
                    (decimal)
                        (configuration.PeriodPolicy.GetNumberOfPeriodsInYear(
                            configuration.PreferredFirstInstallmentDate, configuration.YearPolicy));
                interest = configuration.Amount*configuration.InterestRate/numberOfPeriods/100;
            }
            return configuration.RoundingPolicy.Round(interest.Value);
        }

        private static decimal CalculateFirstInstallmentInterest(Installment installment,
            IScheduleConfiguration configuration)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment, configuration.DateShiftPolicy);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.ExpectedDate);
            var interest = installment.OLB * configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            //if schedule is flat
            if (configuration.CalculationPolicy.GetType() == typeof(FlatInstallmentCalculationPolicy))
            {
                var numberOfPeriods =
                    (decimal)
                    (configuration.PeriodPolicy.GetNumberOfPeriodsInYear(
                        configuration.PreferredFirstInstallmentDate, configuration.YearPolicy));
                interest = configuration.Amount*configuration.InterestRate/numberOfPeriods/100;

                if (configuration.ChargeActualInterestForFirstInstallment)
                {
                    var nextDate = configuration.PeriodPolicy.GetNextDate(configuration.StartDate);
                    var numerator = (installment.ExpectedDate - configuration.StartDate).Days;
                    var denominator = (nextDate - configuration.StartDate).Days;
                    interest = interest*numerator/denominator;
                }
            }
            return configuration.RoundingPolicy.Round(interest.Value);
        }
    }
}
