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
using System.Globalization;
using System.Windows.Forms;

namespace OpenCBS.Controls
{
    public class AmountTextBox : TextBox
    {
        public AmountTextBox()
        {
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            var separator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0];
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || (e.KeyChar == separator && Text.IndexOf(separator) == -1) && AllowDecimalSeparator)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public bool AllowDecimalSeparator { get; set; }

        public decimal? Amount
        {
            get
            {
                decimal result;
                return decimal.TryParse(Text, out result) ? result : (decimal?) null;
            }

            set
            {
                if (!value.HasValue)
                {
                    Text = string.Empty;
                    return;
                }
                if (!AllowDecimalSeparator)
                {
                    Text = string.Format("{0:N0}", value);
                    return;
                }

                var text = value.ToString();
                text = text.TrimEnd('0').TrimEnd(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToCharArray());
                value = decimal.Parse(text);
                var decimalPlaces = BitConverter.GetBytes(decimal.GetBits(value.Value)[3])[2];
                var format = @"{0:N" + decimalPlaces + "}";
                Text = string.Format(format, value);
            }
        }
    } 
}
 
