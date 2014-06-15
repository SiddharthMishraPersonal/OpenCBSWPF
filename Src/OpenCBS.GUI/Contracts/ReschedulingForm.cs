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
using System.Windows.Forms;
using OpenCBS.CoreDomain.Clients;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.Engine;
using OpenCBS.ExceptionsHandler;
using OpenCBS.GUI.UserControl;
using OpenCBS.Services;
using OpenCBS.Shared;

namespace OpenCBS.GUI.Contracts
{
    public partial class ReschedulingForm : SweetBaseForm
    {
        private Loan _contract;
        private readonly IClient _client;

        public ReschedulingForm(Loan contract, IClient pClient)
        {
            InitializeComponent();
            _client = pClient;
            _contract = contract;
            InitializeRescheduleComponents();
            Setup();
        }

        public void InitializeRescheduleComponents()
        {
            startDateTimePicker.Value = TimeProvider.Now > Contract.GetLastRepaymentDate()
                ? TimeProvider.Now : Contract.GetLastRepaymentDate();
            firstRepaymentDateTimePicker.Value = startDateTimePicker
                    .Value
                    .Date
                    .AddMonths(_contract.InstallmentType.NbOfMonths)
                    .AddDays(_contract.InstallmentType.NbOfDays);
            contractCodeLabel.Text = Contract.Code;
            _interestRateTextBox.Amount = Contract.InterestRate * 100;
            installmentsNumericUpDown.Minimum = 1;
            installmentsNumericUpDown.Value = 1;
        }

        private void LoadForm()
        {
            RefreshSchedule(Contract);
        }

        private void Setup()
        {
            Load += (sender, args) => LoadForm();
            _interestRateTextBox.TextChanged += (sender, args) => RecalculateAndRefreshSchedule();
            installmentsNumericUpDown.ValueChanged += (sender, args) =>
            {
                gracePeriodNumericUpDown.Maximum = installmentsNumericUpDown.Value - 1;
                RecalculateAndRefreshSchedule();
            };
            gracePeriodNumericUpDown.ValueChanged += (sender, args) => RecalculateAndRefreshSchedule();
            chargeInterestDuringGracePeriodCheckBox.CheckedChanged += (sender, args) => RecalculateAndRefreshSchedule();
            startDateTimePicker.ValueChanged += (sender, args) =>
            {
                if (startDateTimePicker.Value < _contract.StartDate)
                    startDateTimePicker.Value = _contract.StartDate;
                firstRepaymentDateTimePicker.Value = startDateTimePicker
                    .Value
                    .Date
                    .AddMonths(_contract.InstallmentType.NbOfMonths)
                    .AddDays(_contract.InstallmentType.NbOfDays);
                RecalculateAndRefreshSchedule();
            };
            firstRepaymentDateTimePicker.ValueChanged += (sender, args) =>
            {
                if (firstRepaymentDateTimePicker.Value < startDateTimePicker.Value)
                    firstRepaymentDateTimePicker.Value = startDateTimePicker.Value;
                RecalculateAndRefreshSchedule();
            };
            okButton.Click += (sender, args) => Reschedule();
        }

        private void RefreshSchedule(Loan loan)
        {
            scheduleUserControl.SetScheduleFor(loan);
        }

        private void RecalculateAndRefreshSchedule()
        {
            var rescheduleConfiguration = GetRescheduleConfiguration();
            var loan = ServicesProvider
                .GetInstance()
                .GetContractServices()
                .SimulateRescheduling(_contract, rescheduleConfiguration);
            RefreshSchedule(loan);
        }

        public Loan Contract
        {
            get { return _contract; }
        }

        private ScheduleConfiguration GetRescheduleConfiguration()
        {
            return new ScheduleConfiguration
            {
                NumberOfInstallments = (int) installmentsNumericUpDown.Value,
                InterestRate = _interestRateTextBox.Amount.HasValue ? _interestRateTextBox.Amount.Value : Contract.InterestRate*100,
                GracePeriod = (int) gracePeriodNumericUpDown.Value,
                ChargeInterestDuringGracePeriod = chargeInterestDuringGracePeriodCheckBox.Checked,
                StartDate = startDateTimePicker.Value.Date,
                PreferredFirstInstallmentDate = firstRepaymentDateTimePicker.Value.Date,
                PreviousInterestRate = _contract.InterestRate,
            };
        }

        private void Reschedule()
        {
            if (startDateTimePicker.Value < _contract.GetLastRepaymentDate())
            {
                Fail(GetString("RescheduleStartDateIsNotCorrect.Text"));
                return;
            }
            if (!Confirm(GetString("Confirm"))) return;
            try
            {                
                _contract.Rescheduled = true;
                _contract = ServicesProvider
                    .GetInstance()
                    .GetContractServices()
                    .Reschedule(_contract, _client, GetRescheduleConfiguration());
                _contract.NbOfInstallments = _contract.InstallmentList.Count;
                _contract.InterestRate = _interestRateTextBox.Amount.HasValue ? _interestRateTextBox.Amount.Value : Contract.InterestRate * 100;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }
    }
}
