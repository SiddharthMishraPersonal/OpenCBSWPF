
using System.Collections.Generic;
using System.Linq;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.AdjustmentPolicy
{
    public abstract class BaseAdjustmentPolicy
    {
        public decimal GetAdjustment(List<Installment> schedule, IScheduleConfiguration configuration)
        {
            return configuration.Amount - schedule.Sum(i => i.CapitalRepayment.Value);
        }
    }
}
