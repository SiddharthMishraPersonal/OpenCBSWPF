// Copyright © 2013 Open Octopus Ltd.
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
using System.Drawing;
using BrightIdeasSoftware;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Shared;

namespace OpenCBS.Controls
{
    public partial class ScheduleControl : System.Windows.Forms.UserControl
    {
        private string _amountFormatString;

        public ScheduleControl()
        {
            InitializeComponent();
            Setup();
            scheduleObjectListView.RowFormatter = FormatRow;
        }

        public void SetScheduleFor(Loan loan)
        {
            _amountFormatString = loan.UseCents ? "N2" : "N0";
            scheduleObjectListView.SetObjects(loan.InstallmentList);
        }

        private void Setup()
        {
            dateColumn.AspectToStringConverter =
            paymentDateColumn.AspectToStringConverter = value =>
            {
                var date = (DateTime?)value;
                return date.HasValue ? date.Value.ToString("dd.MM.yyyy") : string.Empty;
            };
            principalColumn.AspectToStringConverter =
            interestColumn.AspectToStringConverter =
            paidPrincipalColumn.AspectToStringConverter =
            paidInterestColumn.AspectToStringConverter =
            totalColumn.AspectToStringConverter =
            olbColumn.AspectToStringConverter = value =>
            {
                var amount = (OCurrency)value;
                return amount.Value.ToString(_amountFormatString);
            };
        }

        private static void FormatRow(OLVListItem item)
        {
            var installment = (Installment)item.RowObject;
            if (installment == null) return;
            if (installment.IsPending) item.BackColor = Color.Orange;
            if (installment.IsRepaid) item.BackColor = Color.FromArgb(61, 153, 57);
            if (installment.IsPending || installment.IsRepaid) item.ForeColor = Color.White;
        }
    }
}
