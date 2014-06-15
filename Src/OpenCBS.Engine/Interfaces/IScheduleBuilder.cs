using System.Collections.Generic;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.Engine.Interfaces
{
    public interface IScheduleBuilder
    {
        List<Installment> BuildSchedule(IScheduleConfiguration configuration);
    }
}
