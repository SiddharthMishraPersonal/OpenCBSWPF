using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class RepaymentView : BaseView, IRepaymentView
    {
        public RepaymentView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
        }

        public void Attach(IRepaymentPresenterCallbacks presenterCallbacks)
        {
            _amountNumericUpDown.LostFocus += (sender, e) => presenterCallbacks.OnRefresh();
            _amountNumericUpDown.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Return) presenterCallbacks.OnRefresh(); };
            _dateTimePicker.LostFocus += (sender, e) => presenterCallbacks.OnRefresh();
            _principalNumericUpDown.LostFocus += (sender, e) => presenterCallbacks.OnRefresh();
            _principalNumericUpDown.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Return) presenterCallbacks.OnRefresh(); };
            _interestNumericUpDown.LostFocus += (sender, e) => presenterCallbacks.OnRefresh();
            _interestNumericUpDown.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Return) presenterCallbacks.OnRefresh(); };
            _penaltyNumericUpDown.LostFocus += (sender, e) => presenterCallbacks.OnRefresh();
            _penaltyNumericUpDown.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Return) presenterCallbacks.OnRefresh(); };
            _commissionNumericUpDown.LostFocus += (sender, e) => presenterCallbacks.OnRefresh();
            _commissionNumericUpDown.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Return) presenterCallbacks.OnRefresh(); };
            _typeOfRepaymentComboBox.SelectedIndexChanged += (sender, e) => presenterCallbacks.OnRefresh();
            _okButton.Click += (sender, e) => presenterCallbacks.OnRepay();
            _cancelButton.Click += (sender, e) => presenterCallbacks.OnCancel();
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }

        public Loan Loan
        {
            set { _scheduleControl.SetScheduleFor(value); }
        }

        public Dictionary<string, string> RepaymentScripts
        {
            set
            {
                _typeOfRepaymentComboBox.DataSource = value.ToList();
                _typeOfRepaymentComboBox.ValueMember = "Key";
                _typeOfRepaymentComboBox.DisplayMember = "Value";
            }
        }

        public List<PaymentMethod> PaymentMethods
        {
            set
            {
                _paymentMethodComboBox.DataSource = value;
                _paymentMethodComboBox.ValueMember = "Id";
                _paymentMethodComboBox.DisplayMember = "Name";
            }
        }

        public decimal Amount
        {
            get { return _amountNumericUpDown.Value; }
            set { _amountNumericUpDown.Value = value; }
        }

        public decimal Principal
        {
            get { return _principalNumericUpDown.Value; }
            set { _principalNumericUpDown.Value = value; }
        }

        public decimal PrincipalMax
        {
            get { return _penaltyNumericUpDown.Maximum; }
            set { _principalNumericUpDown.Maximum = value; }
        }

        public decimal Interest
        {
            get { return _interestNumericUpDown.Value; }
            set { _interestNumericUpDown.Value = value; }
        }

        public decimal Penalty
        {
            get { return _penaltyNumericUpDown.Value; }
            set { _penaltyNumericUpDown.Value = value; }
        }

        public decimal Commission
        {
            get { return _commissionNumericUpDown.Value; }
            set { _commissionNumericUpDown.Value = value; }
        }
        public DateTime Date
        {
            get { return _dateTimePicker.Value; }
            set { _dateTimePicker.Value = value; }
        }
        public bool OkButtonEnabled
        {
            get { return _okButton.Enabled; }
            set { _okButton.Enabled = value;
                _amountNumericUpDown.ForeColor = _okButton.Enabled ? Color.Black : Color.Red;
            }
        }
        public string Comment
        {
            get { return _commentRichTextBox.Text; }
            set { _commentRichTextBox.Text = value; }
        }

        public string Title
        {
            set { Text = value; }
        }

        public string SelectedScript
        {
            get { return _typeOfRepaymentComboBox.SelectedValue.ToString(); }
        }

        public PaymentMethod SelectedPaymentMethod
        {
            get { return (PaymentMethod) _paymentMethodComboBox.SelectedItem; }
            set { _paymentMethodComboBox.SelectedItem = value; }
        }

        public string Description
        {
            set { _descriptionLabel.Text = value; }
        }
    }
}
