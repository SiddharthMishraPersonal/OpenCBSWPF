using System.ComponentModel.Composition;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Fixed principal")]
    public class FixedPrincipalInstallmentCalculationPolicy : BaseInstallmentCalculationPolicy, IInstallmentCalculationPolicy
    {
        public void Calculate(Installment installment, IScheduleConfiguration configuration)
        {
            var number = configuration.NumberOfInstallments - configuration.GracePeriod;
            installment.CapitalRepayment = configuration.RoundingPolicy.Round(configuration.Amount / number);
            installment.InterestsRepayment = CalculateInterest(installment, configuration, installment.OLB.Value);
        }
    }
}
