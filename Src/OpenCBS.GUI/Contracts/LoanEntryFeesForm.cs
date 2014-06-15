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

using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.Controls;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.GUI.Contracts
{
    public partial class LoanEntryFeesForm : Form
    {
        public LoanEntryFeesForm()
        {
            InitializeComponent();
            Setup();
        }

        public IList<LoanEntryFee> EntryFees
        {
            get { return (IList<LoanEntryFee>) _entryFeesListView.Objects; }
            set { _entryFeesListView.SetObjects(value); }
        }

        private void Setup()
        {
            ObjectListView.EditorRegistry.Register(typeof(decimal), typeof(AmountTextBox));
            _amountColumn.AspectToStringConverter = value =>
            {
                var amount = (decimal) value;
                return amount.ToString("N2");
            };
            _amountColumn.AspectPutter = (rowObject, value) =>
            {
                var entryFee = (LoanEntryFee) rowObject;
                decimal amount;
                decimal.TryParse(value.ToString(), out amount);
                entryFee.FeeValue = amount;
            };
        }
    }
}
