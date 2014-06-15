using System.Collections.Generic;
using System.ComponentModel.Composition;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.AdjustmentPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "First installment")]
    public class FirstInstallmentAdjustmentPolicy : BaseAdjustmentPolicy, IAdjustmentPolicy
    {
        public void Adjust(List<Installment> schedule, IScheduleConfiguration configuration)
        {
            schedule[configuration.GracePeriod].CapitalRepayment += GetAdjustment(schedule, configuration);
            for (var i = configuration.GracePeriod + 1; i < schedule.Count; i++)
            {
                schedule[i].OLB = schedule[i - 1].OLB - schedule[i - 1].CapitalRepayment;
            }
        }
    }
}
