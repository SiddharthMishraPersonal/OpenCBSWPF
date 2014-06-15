using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface IInstallment
    {
        int Number { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        DateTime RepaymentDate { get; set; }
        decimal Principal { get; set; }
        decimal Interest { get; set; }
        decimal Olb { get; set; }
        decimal PaidPrincipal { get; set; }
        decimal PaidInterest { get; set; }
        DateTime? LastPaymentDate { get; set; }
    }
}
