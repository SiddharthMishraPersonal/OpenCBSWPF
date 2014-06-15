using System;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Service
{
    public class RepaymentSettings : ICloneable
    {
        public Loan Loan { get; set; }
        public decimal Amount { get; set; }
        public bool AmountChanged { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Penalty { get; set; }
        public decimal Commission { get; set; }
        public DateTime Date { get; set; }
        public bool DateChanged { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Comment { get; set; }
        public string ScriptName { get; set; }

        public object Clone()
        {
            return new RepaymentSettings
            {
                Amount = Amount,
                AmountChanged = AmountChanged,
                Loan = Loan.Copy(),
                Principal = Principal,
                Interest = Interest,
                Penalty = Penalty,
                Commission = Commission,
                Date = Date,
                DateChanged = DateChanged,
                PaymentMethod = PaymentMethod,
                Comment = Comment,
                ScriptName = ScriptName
            };
        }
    }
}
