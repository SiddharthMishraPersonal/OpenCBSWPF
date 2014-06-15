using System.Collections.Generic;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.Engine.Interfaces
{
    public interface IAdjustmentPolicy : IPolicy
    {
        void Adjust(List<Installment> schedule, IScheduleConfiguration configuration);
    }
}
