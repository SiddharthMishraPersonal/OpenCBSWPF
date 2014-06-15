using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Enums;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Service
{
    public class RepaymentService : IRepaymentService
    {
        public RepaymentSettings Settings { get; set; }

        public RepaymentService()
        {
            Settings = new RepaymentSettings();
        }

        public Loan Repay()
        {
            var newSettings = (RepaymentSettings)Settings.Clone();
            var script = RunScript(newSettings.ScriptName);
            if (newSettings.DateChanged)
                script.GetInitAmounts(newSettings);
            if (newSettings.AmountChanged)
                script.GetAmounts(newSettings);
            script.Repay(newSettings);
            Settings = newSettings;
            return Settings.Loan;
        }

        public decimal GetRepaymentAmount(DateTime date)
        {
            var newSettings = (RepaymentSettings)Settings.Clone();
            newSettings.Date = date;
            var script = RunScript(newSettings.ScriptName);
            script.GetInitAmounts(newSettings);
            return
                Math.Round(newSettings.Penalty + newSettings.Commission + newSettings.Interest + newSettings.Principal,
                           2);
        }

        public Dictionary<string, string> GetAllRepaymentScriptsWithTypes()
        {
            var scripts = new Dictionary<string, string>();
            var files = Directory
                .EnumerateFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts\\Repayment\\"), "*.py",
                                SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            foreach (var file in files)
            {
                var script = RunScript(file);
                scripts.Add(file, script.GetType());
            }
            return scripts;
        }

        private static dynamic RunScript(string scriptName)
        {
            var options = new Dictionary<string, object>();
#if DEBUG
            options["Debug"] = true;
#endif
            ScriptEngine engine = Python.CreateEngine(options);
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts\\Repayment\\" + scriptName);
            
            var assemby = typeof(ServicesProvider).Assembly;
            engine.Runtime.LoadAssembly(assemby);
            assemby = typeof(Installment).Assembly;
            engine.Runtime.LoadAssembly(assemby);
            assemby = typeof (OPaymentType).Assembly;
            engine.Runtime.LoadAssembly(assemby);

            return engine.ExecuteFile(file);
        }
    }
}
