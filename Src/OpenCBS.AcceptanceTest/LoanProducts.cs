using System.Collections.Generic;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.CoreDomain.Contracts.Loans.LoanRepayment;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Enums;

namespace OpenCBS.AcceptanceTest
{
    class LoanProducts
    {
        private static LoanProducts _instance;
        private readonly Dictionary<string, LoanProduct> _loanProducts = new Dictionary<string, LoanProduct>();

        public LoanProducts()
        {
            _loanProducts.Add("IL Monthly Repayment - Declining rate", Get_IL_MonthlyRepayment_DecliningRate());
            _loanProducts.Add("ANNUITY", Get_ANNUITY());
            _loanProducts.Add("ANNUITY - Cents", Get_ANNUITY_Cents());
            _loanProducts.Add("Annuity Monthly (30 day)", Get_Annuity_Monthly_30Day());
            _loanProducts.Add("SCG Declining Rate Fixed Principal", Get_SCG_DecliningRate_FixedPrincipal());
            _loanProducts.Add("SCG Declining Rate Fixed Principal - Cents", Get_SCG_DecliningRate_FixedPrincipal_Cents());
        }

        public LoanProduct this[string key]
        {
            get { return _loanProducts[key]; }
        }

        public static LoanProducts Instance
        {
            get { return _instance ?? (_instance = new LoanProducts()); }
        }

        private LoanProduct Get_IL_MonthlyRepayment_DecliningRate()
        {
            return new LoanProduct
            {
                Name = "IL Monthly Repayment - Declining rate",
                InstallmentType = new InstallmentType { Name = "Monthly", NbOfDays = 0, NbOfMonths = 1 },
                InterestRate = 3,
                GracePeriodMin = 0,
                GracePeriodMax = 0,
                LoanType = OLoanTypes.DecliningFixedInstallments,
                ChargeInterestWithinGracePeriod = true,
                KeepExpectedInstallment = false,
                AnticipatedTotalRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                AnticipatedPartialRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                NonRepaymentPenalties = new NonRepaymentPenaltiesNullableValues(0, 0, 0, 0.01),
                Currency = new Currency { UseCents = false }
            };
        }

        private LoanProduct Get_ANNUITY_Cents()
        {
            return new LoanProduct
            {
                Name = "ANNUITY - Cents",
                InstallmentType = new InstallmentType { Name = "Monthly", NbOfDays = 0, NbOfMonths = 1 },
                InterestRateMin = 1,
                InterestRateMax = 10,
                GracePeriodMin = 0,
                GracePeriodMax = 6,
                LoanType = OLoanTypes.DecliningFixedInstallments,
                ChargeInterestWithinGracePeriod = true,
                KeepExpectedInstallment = true,
                AnticipatedTotalRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingInterest,
                AnticipatedPartialRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingInterest,
                NonRepaymentPenalties = new NonRepaymentPenaltiesNullableValues(0, 0, 0, 0.01),
                Currency = new Currency { UseCents = true },
            };
        }

        private LoanProduct Get_ANNUITY()
        {
            return new LoanProduct
            {
                Name = "ANNUITY",
                InstallmentType = new InstallmentType { Name = "Monthly", NbOfDays = 0, NbOfMonths = 1 },
                InterestRateMin = 1,
                InterestRateMax = 10,
                GracePeriodMin = 0,
                GracePeriodMax = 6,
                LoanType = OLoanTypes.DecliningFixedInstallments,
                InterestScheme = OInterestScheme.Thirty360,
                ChargeInterestWithinGracePeriod = true,
                KeepExpectedInstallment = true,
                AnticipatedTotalRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                AnticipatedPartialRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingInterest,
                NonRepaymentPenalties = new NonRepaymentPenaltiesNullableValues(0, 0, 0, 0.01),
                Currency = new Currency { UseCents = false },
            };
        }

        private LoanProduct Get_Annuity_Monthly_30Day()
        {
            return new LoanProduct
            {
                Name = "Annuity Monthly (30 day)",
                InstallmentType = new InstallmentType { Name = "Monthly (30 day)", NbOfDays = 30, NbOfMonths = 0 },
                InterestRateMin = 1,
                InterestRateMax = 10,
                GracePeriodMin = 0,
                GracePeriodMax = 6,
                LoanType = OLoanTypes.DecliningFixedInstallments,
                ChargeInterestWithinGracePeriod = true,
                KeepExpectedInstallment = true,
                AnticipatedTotalRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                AnticipatedPartialRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingInterest,
                NonRepaymentPenalties = new NonRepaymentPenaltiesNullableValues(0, 0, 0, 0.01),
                Currency = new Currency { UseCents = false },
            };
        }

        private LoanProduct Get_SCG_DecliningRate_FixedPrincipal()
        {
            return new LoanProduct
            {
                Name = "SCG Declining Rate Fixed Principal",
                InstallmentType = new InstallmentType { Name = "Monthly", NbOfDays = 0, NbOfMonths = 1 },
                InterestRateMin = 1,
                InterestRateMax = 3,
                GracePeriodMin = 0,
                GracePeriodMax = 1,
                LoanType = OLoanTypes.DecliningFixedPrincipal,
                ChargeInterestWithinGracePeriod = true,
                KeepExpectedInstallment = false,
                AnticipatedTotalRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                AnticipatedPartialRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                NonRepaymentPenalties = new NonRepaymentPenaltiesNullableValues(0, 0, 0.01, 0),
                Currency = new Currency { UseCents = false },
            };
        }

        private LoanProduct Get_SCG_DecliningRate_FixedPrincipal_Cents()
        {
            return new LoanProduct
            {
                Name = "SCG Declining Rate Fixed Principal - Cents",
                InstallmentType = new InstallmentType { Name = "Monthly", NbOfDays = 0, NbOfMonths = 1},
                InterestRateMin = 1,
                InterestRateMax = 3,
                GracePeriodMin = 0,
                GracePeriodMax = 1,
                LoanType = OLoanTypes.DecliningFixedPrincipal,
                ChargeInterestWithinGracePeriod = true,
                KeepExpectedInstallment = false,
                AnticipatedTotalRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                AnticipatedPartialRepaymentPenaltiesBase = OAnticipatedRepaymentPenaltiesBases.RemainingOLB,
                NonRepaymentPenalties = new NonRepaymentPenaltiesNullableValues(0, 0, 0.01, 0),
                Currency = new Currency { UseCents = true },
            };
        }
    }
}
