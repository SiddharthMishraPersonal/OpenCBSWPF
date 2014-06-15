using System.ComponentModel.Composition;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Flat")]
    public class FlatInstallmentCalculationPolicy : BaseInstallmentCalculationPolicy, IInstallmentCalculationPolicy
    {
        public void Calculate(Installment installment, IScheduleConfiguration configuration)
        {
            var number = configuration.NumberOfInstallments - configuration.GracePeriod;
            installment.CapitalRepayment = configuration.RoundingPolicy.Round(configuration.Amount / number);
            installment.InterestsRepayment = CalculateInterest(installment, configuration, configuration.Amount);
        }
    }
}
