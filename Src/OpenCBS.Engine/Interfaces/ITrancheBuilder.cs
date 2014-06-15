using System.Collections.Generic;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.Engine.Interfaces
{
    public interface ITrancheBuilder
    {
        List<Installment> BuildTranche(IEnumerable<Installment> schedule, IScheduleBuilder scheduleBuilder, IScheduleConfiguration scheduleConfiguration, ITrancheConfiguration trancheConfiguration);
    }
}
