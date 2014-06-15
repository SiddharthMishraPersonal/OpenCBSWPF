// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Clients;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.Engine;
using OpenCBS.Engine.Interfaces;
using OpenCBS.ExceptionsHandler;
using OpenCBS.GUI.UserControl;
using OpenCBS.Services;
using OpenCBS.Shared;

namespace OpenCBS.GUI.Contracts
{
    public partial class AddTrancheForm : SweetBaseForm
    {
        private Loan _contract;
        private readonly IClient _client;

        public AddTrancheForm(Loan contract, IClient pClient)
        {
            InitializeComponent();
            Setup();
            _client = pClient;
            _contract = contract;
            interestRateNumericUpDown.Value = contract.InterestRate * 100;
            if (contract.Product.InterestRate.HasValue) { /* checkBoxIRChanged.Enabled = false; */ }
            else
            {
                interestRateNumericUpDown.Minimum = Convert.ToDecimal(contract.Product.InterestRateMin * 100);
                interestRateNumericUpDown.Maximum = Convert.ToDecimal(contract.Product.InterestRateMax * 100);
            }
            InitializeTrancheComponents();
            FillComboBoxPaymentMethods();
        }

        public void InitializeTrancheComponents()
        {
            startDateTimePicker.Value = TimeProvider.Now;

            if (Contract.Product.NbOfInstallments != null)
            {
                installmentsNumericUpDown.Maximum = (decimal) Contract.Product.NbOfInstallments;
                installmentsNumericUpDown.Minimum = (decimal) Contract.Product.NbOfInstallments;
            }
            else
            {
                installmentsNumericUpDown.Maximum = (decimal) Contract.Product.NbOfInstallmentsMax;
                installmentsNumericUpDown.Minimum = (decimal) Contract.Product.NbOfInstallmentsMin;
            }
        }

        private void LoadForm()
        {
            RefreshSchedule(Contract);
        }

        private void Setup()
        {
            Load += (sender, args) => LoadForm();
            interestRateNumericUpDown.LostFocus += (sender, args) => RecalculateTrancheAndRefreshSchedule();
            interestRateNumericUpDown.KeyDown += (sender, args) => { if(args.KeyCode == Keys.Return) RecalculateTrancheAndRefreshSchedule(); };
            installmentsNumericUpDown.LostFocus += (sender, args) =>
            {
                gracePeriodNumericUpDown.Maximum = installmentsNumericUpDown.Value - 1;
                RecalculateTrancheAndRefreshSchedule();
            };
            installmentsNumericUpDown.KeyDown += (sender, args) =>
            {
                if (args.KeyCode != Keys.Return) return;
                gracePeriodNumericUpDown.Maximum = installmentsNumericUpDown.Value - 1;
                RecalculateTrancheAndRefreshSchedule();
            };
            gracePeriodNumericUpDown.LostFocus += (sender, args) => RecalculateTrancheAndRefreshSchedule();
            gracePeriodNumericUpDown.KeyDown += (sender, args) => { if (args.KeyCode == Keys.Return) RecalculateTrancheAndRefreshSchedule(); };
            amountTextbox.LostFocus += (sender, args) => RecalculateTrancheAndRefreshSchedule();
            amountTextbox.KeyDown += (sender, args) => { if (args.KeyCode == Keys.Return) RecalculateTrancheAndRefreshSchedule(); };
            startDateTimePicker.LostFocus += (sender, args) =>
            {
                firstRepaymentDateTimePicker.Value = startDateTimePicker
                    .Value
                    .Date
                    .AddMonths(_contract.InstallmentType.NbOfMonths)
                    .AddDays(_contract.InstallmentType.NbOfDays);
                RecalculateTrancheAndRefreshSchedule();
            };
            firstRepaymentDateTimePicker.LostFocus += (sender, args) => RecalculateTrancheAndRefreshSchedule();
            applyToOlbCheckbox.CheckedChanged += (sender, args) => RecalculateTrancheAndRefreshSchedule();
            okButton.Click += (sender, args) => AddTranche();
        }

        private void RefreshSchedule(Loan loan)
        {
            scheduleUserControl.SetScheduleFor(loan);
        }

        private void RecalculateTrancheAndRefreshSchedule()
        {
            var trancheConfiguration = GetTrancheConfiguration();
            if (trancheConfiguration.Amount == 0) return;
            var loan = ServicesProvider
                .GetInstance()
                .GetContractServices()
                .SimulateTranche(_contract, trancheConfiguration);
            RefreshSchedule(loan);
        }

        public Loan Contract
        {
            get { return _contract; }
        }

        private ITrancheConfiguration GetTrancheConfiguration()
        {
            decimal amount;
            decimal.TryParse(amountTextbox.Text, out amount);
            return new TrancheConfiguration
            {
                Amount = amount,
                ApplyNewInterestRateToOlb = applyToOlbCheckbox.Checked,
                GracePeriod = (int) gracePeriodNumericUpDown.Value,
                InterestRate = interestRateNumericUpDown.Value,
                NumberOfInstallments = (int) installmentsNumericUpDown.Value,
                PreferredFirstInstallmentDate = firstRepaymentDateTimePicker.Value.Date,
                StartDate = startDateTimePicker.Value.Date,
            };
        }

        private void tbDateOffset_KeyDown(object sender, KeyEventArgs e)
        {
            Keys c = e.KeyCode;

            if (c >= Keys.NumPad0 && c <= Keys.NumPad9) return;
            if (c >= Keys.D0 && c <= Keys.D9) return;
            if (e.KeyValue == 110 || e.KeyValue == 188) return;
            if (e.Control && (c == Keys.X || c == Keys.C || c == Keys.V || c == Keys.Z)) return;
            if (c == Keys.Delete || c == Keys.Back) return;
            if (c == Keys.Left || c == Keys.Right || c == Keys.Up || c == Keys.Down) return;
            e.SuppressKeyPress = true;
        }

        private void tbDateOffset_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (0 == tb.Text.Length) tb.Text = @"0";
        }

        private void AddTranche()
        {
            var configuration = GetTrancheConfiguration();

            var entryFeesForm = new LoanEntryFeesForm
            {
                EntryFees = _contract.LoanEntryFeesList.Select(fee =>
                {
                    var result = new LoanEntryFee
                    {
                        FeeValue = fee.ProductEntryFee.IsRate ? configuration.Amount * fee.FeeValue / 100 : fee.FeeValue,
                        Id = fee.Id,
                        ProductEntryFee = fee.ProductEntryFee,
                        ProductEntryFeeId = fee.ProductEntryFeeId
                    };
                    return result;
                }).ToList()
            };
            if (entryFeesForm.ShowDialog() != DialogResult.OK) return;

            try
            {

                _contract = ServicesProvider
                    .GetInstance()
                    .GetContractServices()
                    .AddTranche(_contract, _client, GetTrancheConfiguration(), entryFeesForm.EntryFees, (PaymentMethod)
                                                                                              cmbPaymentMethod.
                                                                                                  SelectedItem);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void FillComboBoxPaymentMethods()
        {
            List<PaymentMethod> paymentMethods =
                ServicesProvider.GetInstance().GetPaymentMethodServices().GetAllPaymentMethods();
            foreach (PaymentMethod method in paymentMethods)
                cmbPaymentMethod.Items.Add(method);

            cmbPaymentMethod.SelectedItem = paymentMethods[0];
        }
    }
}
