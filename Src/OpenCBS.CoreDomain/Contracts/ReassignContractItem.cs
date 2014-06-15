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

namespace OpenCBS.CoreDomain.Contracts
{
    public class ReassignContractItem
    {
        public int ContractId { get; set; }

        public string ContractCode { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientFatherName { get; set; }

        public string DistrictName { get; set; }

        public int StatusCode { get; set; }

        public decimal Olb { get; set; }

        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CloseDate { get; set; }

        public int NumberOfInstallments { get; set; }

        public string LoanProductName { get; set; }

        public string InstallmentType { get; set; }

        public decimal InterestRate { get; set; }

        public bool CanReassign { get; set; }
    }
}
