﻿﻿﻿﻿﻿﻿using System.Linq;
﻿﻿﻿﻿﻿﻿﻿using System.Windows.Forms;
﻿﻿﻿﻿﻿﻿﻿using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Savings;
using OpenCBS.Services;
using OpenCBS.Shared.Settings;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class RepaymentPresenter : IRepaymentPresenter, IRepaymentPresenterCallbacks
    {
        private Loan _loan;
        private ISavingsContract _saving;
        private readonly IRepaymentView _view;
        private readonly IRepaymentService _repaymentService;
        private readonly ITranslationService _translationService;
        private string _balanceString;

        public RepaymentPresenter(IRepaymentView view, IRepaymentService repaymentService, ITranslationService translationService)
        {
            _view = view;
            _repaymentService = repaymentService;
            _translationService = translationService;
        }

        public void Setup()
        {
            _repaymentService.Settings.Loan = _loan.Copy();
            _view.PrincipalMax = _loan.OLB;
            _view.RepaymentScripts = _repaymentService.GetAllRepaymentScriptsWithTypes();
            _view.PaymentMethods = ServicesProvider.GetInstance().GetPaymentMethodServices().GetAllPaymentMethods();
            _view.Title = _loan.Project.Client.Name + " " + _loan.Code;
            _repaymentService.Settings.ScriptName = _view.SelectedScript;
            _balanceString = _translationService.Translate("Available balance: ");
            if (!ApplicationSettings.GetInstance(User.CurrentUser.Md5).UseMandatorySavingAccount) return;
            _saving =
                (from item in _loan.Project.Client.Savings where item.Product.Code == "default" select item)
                    .FirstOrDefault();
            if (_saving != null)
                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);
        }

        public object View { get { return _view; } }

        public DialogResult Run(Loan loan)
        {
            _loan = loan;
            Setup();
            OnRefresh();
            _view.Attach(this);
            OnRefresh();
            _view.Run();
            return _view.DialogResult;
        }

        public void OnRepay()
        {
            _view.DialogResult = DialogResult.OK;
            _loan = ServicesProvider.GetInstance()
                                    .GetContractServices()
                                    .SaveInstallmentsAndRepaymentEvents(_loan,
                                                                        _repaymentService.Settings.Loan.InstallmentList,
                                                                        _repaymentService.Settings.Loan.Events);
            _view.Stop();
        }

        public void OnRefresh()
        {
            if (_repaymentService.Settings.Principal == _view.Principal &&
                _repaymentService.Settings.Interest == _view.Interest &&
                _repaymentService.Settings.Penalty == _view.Penalty &&
                _repaymentService.Settings.Commission == _view.Commission &&
                _repaymentService.Settings.Comment == _view.Comment &&
                _repaymentService.Settings.ScriptName == _view.SelectedScript &&
                _repaymentService.Settings.Date.Date == _view.Date.Date &&
                _repaymentService.Settings.Amount == _view.Amount) return;
            if (_repaymentService.Settings.Date.Date != _view.Date.Date)
            {
                _repaymentService.Settings.DateChanged = true;
                _repaymentService.Settings.Date = _view.Date;
                if (_saving != null)
                    _view.Description = _balanceString + _saving.GetBalance(_view.Date).Value.ToString("N2");
            }
            if (_repaymentService.Settings.Amount != _view.Amount)
            {
                _repaymentService.Settings.AmountChanged = true;
                _repaymentService.Settings.Amount = _view.Amount;
            }
            if (_repaymentService.Settings.ScriptName != _view.SelectedScript)
                _repaymentService.Settings.AmountChanged = true;
            _repaymentService.Settings.Loan = _loan.Copy();
            _repaymentService.Settings.Comment = _view.Comment;
            _repaymentService.Settings.Commission = _view.Commission;
            _repaymentService.Settings.Interest = _view.Interest;
            _repaymentService.Settings.Penalty = _view.Penalty;
            _repaymentService.Settings.Principal = _view.Principal;
            _repaymentService.Settings.ScriptName = _view.SelectedScript;
            _repaymentService.Settings.PaymentMethod = _view.SelectedPaymentMethod;
            _repaymentService.Repay();
            _repaymentService.Settings.DateChanged = false;
            _repaymentService.Settings.AmountChanged = false;
            if (_saving != null)
                _view.OkButtonEnabled = _repaymentService.Settings.Amount <= _saving.GetBalance(_view.Date).Value;
            RefreshAmounts();
        }

        public void OnCancel()
        {
            _view.DialogResult = DialogResult.Cancel;
            _view.Stop();
        }

        private void RefreshAmounts()
        {
            _view.Loan = _repaymentService.Settings.Loan;
            _view.Commission = _repaymentService.Settings.Commission;
            _view.Interest = _repaymentService.Settings.Interest;
            _view.Penalty = _repaymentService.Settings.Penalty;
            _view.Principal = _repaymentService.Settings.Principal;
            _view.Amount = _repaymentService.Settings.Commission + _repaymentService.Settings.Interest +
                           _repaymentService.Settings.Penalty + _repaymentService.Settings.Principal;
        }
    }
}
