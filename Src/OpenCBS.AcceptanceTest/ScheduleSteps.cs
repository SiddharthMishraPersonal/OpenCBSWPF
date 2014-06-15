using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using OpenCBS.ArchitectureV2.Service;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Events.Loan;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Engine;
using OpenCBS.Enums;
using OpenCBS.Shared;
using OpenCBS.Services;
using OpenCBS.Shared.Settings;
using TechTalk.SpecFlow;

namespace OpenCBS.AcceptanceTest
{
    [Binding]
    public class ScheduleSteps
    {
        private static readonly ApplicationSettings Settings = ApplicationSettings.GetInstance("");
        private static readonly NonWorkingDateSingleton NonWorkingDays = NonWorkingDateSingleton.GetInstance("");

        private LoanProduct _loanProduct;
        private Loan _loan;
        private static OctopusScheduleConfigurationFactory _configurationFactory;
        private static CultureInfo _cultureInfo;

        private static void SetupHolidays()
        {
            var holidays = NonWorkingDateSingleton.GetInstance(string.Empty);
            holidays.PublicHolidays.Add(new DateTime(2006, 1, 1), "New Year");
            holidays.PublicHolidays.Add(new DateTime(2006, 3, 8), "Women's Day");
            holidays.PublicHolidays.Add(new DateTime(2006, 3, 21), "Idi Navruz");
            holidays.PublicHolidays.Add(new DateTime(2006, 3, 22), "Idi Navruz");
            holidays.PublicHolidays.Add(new DateTime(2006, 5, 1), "Labour Day");
            holidays.PublicHolidays.Add(new DateTime(2006, 5, 9), "Victory Day");
            holidays.PublicHolidays.Add(new DateTime(2006, 6, 27), "National Unitary Day");
            holidays.PublicHolidays.Add(new DateTime(2006, 9, 9), "Independence Day");
            holidays.PublicHolidays.Add(new DateTime(2006, 11, 6), "Constitution Day");
            holidays.PublicHolidays.Add(new DateTime(2006, 11, 26), "Idi Ramazan");
            holidays.PublicHolidays.Add(new DateTime(2007, 1, 6), "Idi Kurbon");
            holidays.PublicHolidays.Add(new DateTime(2013, 5, 1), "Labour Day");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Settings.UpdateParameter("INCREMENTAL_DURING_DAYOFFS", true);
            Settings.UpdateParameter("DONOT_SKIP_WEEKENDS_IN_INSTALLMENTS_DATE", false);
            Settings.UpdateParameter("USE_CENTS", false);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            SetupHolidays();
            Settings.AddParameter("INCREMENTAL_DURING_DAYOFFS", true);
            Settings.AddParameter("DONOT_SKIP_WEEKENDS_IN_INSTALLMENTS_DATE", false);
            Settings.AddParameter("USE_CENTS", false);
            Settings.AddParameter("PAY_FIRST_INSTALLMENT_REAL_VALUE", true);
            Settings.AddParameter("ALIGN_INSTALLMENTS_ON_REAL_DISBURSEMENT_DATE", false);
            Settings.AddParameter("WEEK_END_DAY1", 6);
            Settings.AddParameter("WEEK_END_DAY2", 0);

            NonWorkingDays.WeekEndDay1 = 6;
            NonWorkingDays.WeekEndDay2 = 0;

            _configurationFactory = new OctopusScheduleConfigurationFactory(NonWorkingDays);

            _cultureInfo = new CultureInfo("ru-RU");
        }

        private static void SetAccountingProcess(string value)
        {
            var accountingProcess = value == "Accrual" ? OAccountingProcesses.Accrual : OAccountingProcesses.Cash;
            Settings.UpdateParameter("ACCOUNTING_PROCESS", accountingProcess);
        }

        [Given(@"these settings")]
        public void GivenTheseSettings(Table table)
        {
            foreach (var row in table.Rows)
            {
                var name = row["Name"];
                var value = row["Value"];
                switch (row["Name"])
                {
                    case "USE_CENTS":
                    case "INCREMENTAL_DURING_DAYOFFS":
                    case "USE_DAILY_ACCRUAL_OF_PENALTY":
                    case "DONOT_SKIP_WEEKENDS_IN_INSTALLMENTS_DATE":
                        Settings.UpdateParameter(name, "Yes" == value);
                        break;

                    case "ACCOUNTING_PROCESS":
                        SetAccountingProcess(value);
                        break;
                }
            }
        }
        
        [Given(@"the ""(.*)"" loan product")]
        public void GivenTheLoanProduct(string loanProductName)
        {
            _loanProduct = LoanProducts.Instance[loanProductName];
            _loanProduct.Currency.UseCents = ReferenceEquals(Settings.GetSpecificParameter("USE_CENTS"), "1");
        }
        
        [When(@"I create a loan")]
        public void WhenICreateALoan(Table table)
        {
            _loanProduct.RoundingType = ParseTableValue<ORoundingType>(table, "Rounding");
            _loan = new Loan(_loanProduct,
                             ParseTableValue<decimal>(table, "Amount"),
                             ParseTableValue<decimal>(table, "Interest rate")/1200,
                             ParseTableValue<int>(table, "Installments"),
                             ParseTableValue<int>(table, "Grace period"),
                             ParseTableValue<DateTime>(table, "Start date"),
                             ParseTableValue<DateTime>(table, "First installment date"),
                             new User(),
                             Settings,
                             NonWorkingDays,
                             ProvisionTable.GetInstance(new User()),
                             ChartOfAccounts.GetInstance(new User()));
            _loan.InstallmentList = ServicesProvider.GetInstance().GetContractServices().SimulateScheduleCreation(_loan);
        }

        private static T ParseTableValue<T>(Table table, string key, T defaultValue = default(T))
        {
            var value = (
                from row in table.Rows
                where row["Name"] == key
                select row["Value"]
            ).FirstOrDefault();
            if (null == value) return default(T);

            if (typeof(int) == typeof(T))
                return (T)(object)int.Parse(value, _cultureInfo);

            if (typeof(decimal) == typeof(T))
                return (T)(object)decimal.Parse(value, _cultureInfo);

            if (typeof(DateTime) == typeof(T))
                return (T)(object)DateTime.Parse(value, _cultureInfo, DateTimeStyles.AssumeLocal);

            if (typeof(T) == typeof(bool))
                return (T)(object)("Yes" == value);

            if (typeof(T).IsEnum)
                return (T)Enum.Parse(typeof(T), value);

            return defaultValue;
        }
        
        [When(@"I set line of credit limit to (.*)")]
        public void WhenISetLineOfCreditLimitTo(decimal limit)
        {
            _loan.AmountUnderLoc = limit;
        }
        
        [When(@"I disburse on (.*)")]
        public void WhenIDisburseOn_(string dateString)
        {
            var date = DateTime.Parse(dateString, _cultureInfo, DateTimeStyles.AssumeLocal);
            _loan.Disburse(date, false, false);
        }

        [When(@"I repay ([0-9,]+) on ([0-9]{2}\.[0-9]{2}\.[0-9]{4})")]
        public void WhenIRepayOn_(string amountString, string dateString)
        {
            var date = DateTime.Parse(dateString, _cultureInfo, DateTimeStyles.AssumeLocal);
            var amount = Convert.ToDecimal(amountString, _cultureInfo);
            var re = new RepaymentService()
            {
                Settings = new RepaymentSettings
                    {
                        Loan = _loan,
                        Amount = amount,
                        AmountChanged = true,
                        Date = date,
                        ScriptName = "1_NormalRepayment.py"
                    }
            };
            _loan = re.Repay();
        }

        [When(@"I repay ([0-9,]+) on ([0-9]{2}\.[0-9]{2}\.[0-9]{4}) with no keep schedule")]
        public void WhenIRepayOn_WithNoKeepSchedule(string amountString, string dateString)
        {
            var date = DateTime.Parse(dateString, _cultureInfo, DateTimeStyles.AssumeLocal);
            var amount = Convert.ToDecimal(amountString, _cultureInfo);
            //var re = new RepaymentService();
            //_loan = re.Repay();
        }

        [When(
            @"I repay ([0-9,]+) on ([0-9]{2}\.[0-9]{2}\.[0-9]{4}) with ([0-9,]+) for commission with ([0-9,]+) for penalties with ([0-9,]+) for interest"
            )]
        public void WhenIRepayOn_WithForCommissionWithForPenaltiesWithForInterest(string amountString,
                                                                                  string dateString,
                                                                                  string commissionString,
                                                                                  string penaltyString,
                                                                                  string interestString)
        {
            var amount = Convert.ToDecimal(amountString, _cultureInfo);
            var date = DateTime.Parse(dateString, _cultureInfo, DateTimeStyles.AssumeLocal);
            var commission = Convert.ToDecimal(commissionString, _cultureInfo);
            var penalty = Convert.ToDecimal(penaltyString, _cultureInfo);
            var interest = Convert.ToDecimal(interestString, _cultureInfo);
            var re = new RepaymentService
            {
                Settings = new RepaymentSettings
                {
                    Loan = _loan,
                    Amount = amount,
                    Date = date,
                    Commission = commission,
                    Penalty = penalty,
                    Interest = interest,
                    Principal = amount - commission - penalty - interest,
                    ScriptName = "1_NormalRepayment.py"
                }
            };
            _loan = re.Repay();
        }


        [When(@"I accrue_penalties ([0-9,]+)")]
        public void WhenIAccrue_Penalties(string penaltyString)
        {
            var amount = Convert.ToDecimal(penaltyString, _cultureInfo);
            var accrualEvent = new LoanPenaltyAccrualEvent
            {
                Penalty = amount
            };
            _loan.Events.Add(accrualEvent);
        }
        
        [Then(@"the schedule is")]
        public void ThenTheScheduleIs(Table table)
        {
            var i = 0;
            foreach (var row in table.Rows)
            {
                var installment = _loan.InstallmentList[i];
                int number = Convert.ToInt32(row["Number"]);
                Assert.That(installment.Number, Is.EqualTo(number));

                var expectedDate = DateTime.Parse(row["Expected date"], _cultureInfo, DateTimeStyles.AssumeLocal);
                Assert.That(installment.ExpectedDate, Is.EqualTo(expectedDate));

                var expectedInterest = (OCurrency)Convert.ToDecimal(row["Expected interest"], _cultureInfo);
                Assert.That(installment.InterestsRepayment, Is.EqualTo(expectedInterest));

                var expectedPrincipal = (OCurrency)Convert.ToDecimal(row["Expected principal"], _cultureInfo);
                Assert.That(installment.CapitalRepayment, Is.EqualTo(expectedPrincipal));

                var olb = (OCurrency)Convert.ToDecimal(row["Olb"], _cultureInfo);
                Assert.That(installment.OLB, Is.EqualTo(olb));

                var paidPrincipal = (OCurrency)Convert.ToDecimal(row["Paid principal"], _cultureInfo);
                Assert.That(installment.PaidCapital, Is.EqualTo(paidPrincipal));

                var paidInterest = (OCurrency)Convert.ToDecimal(row["Paid interest"], _cultureInfo);
                Assert.That(installment.PaidInterests, Is.EqualTo(paidInterest));
                i++;
            }
        }
    }
}
