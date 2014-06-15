using System;
using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Service;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface IRepaymentService
    {
        RepaymentSettings Settings { get; set; }
        Loan Repay();
        decimal GetRepaymentAmount(DateTime date);
        Dictionary<string, string> GetAllRepaymentScriptsWithTypes();
    }
}
