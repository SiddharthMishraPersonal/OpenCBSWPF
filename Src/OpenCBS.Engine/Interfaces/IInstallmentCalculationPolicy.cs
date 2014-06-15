
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.Engine.Interfaces
{
    public interface IInstallmentCalculationPolicy : IPolicy
    {
        void Calculate(Installment installment, IScheduleConfiguration configuration);
    }
}
