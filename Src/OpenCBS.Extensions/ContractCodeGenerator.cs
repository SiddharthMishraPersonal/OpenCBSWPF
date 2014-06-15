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

using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Globalization;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Clients;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.Shared.Settings;

namespace OpenCBS.Extensions
{
    [Export(typeof(IContractCodeGenerator))]
    [ExportMetadata("Implementation", "Default")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ContractCodeGenerator : IContractCodeGenerator
    {
        public string GenerateContractCode(IClient client, Loan loan, SqlTransaction transaction)
        {
            var settings = ApplicationSettings.GetInstance(User.CurrentUser.Md5);
            var pattern = settings.ContractCodeTemplate;
            var clientName = client is Person ? (client as Person).LastName : client.Name;
            clientName = clientName.Replace(" ", string.Empty);
            clientName = clientName.Length < 5 ? clientName : clientName.Substring(0, 5);
            return pattern
                .Replace("BC", loan.BranchCode)
                .Replace("DT", client.District.Name.Substring(0, 1 == client.District.Name.Length ? 1 : 2))
                .Replace("YY", loan.StartDate.Year.ToString(CultureInfo.InvariantCulture).Substring(2, 2))
                .Replace("yyyy", loan.StartDate.Year.ToString(CultureInfo.InvariantCulture))
                .Replace("LO", loan.LoanOfficer.Name.Substring(0, 2).ToUpper())
                .Replace("PC", loan.Product.Code)
                .Replace("LC", (client.LoanCycle + 1).ToString(CultureInfo.InvariantCulture))
                .Replace("JC", client.Projects.Count.ToString(CultureInfo.InvariantCulture))
                .Replace("ID", client.Id.ToString(CultureInfo.InvariantCulture))
                .Replace("LN", clientName.ToUpper()) + "/" + loan.Id;
        }
    }
}
