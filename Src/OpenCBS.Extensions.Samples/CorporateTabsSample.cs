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
using System.Windows.Forms;
using OpenCBS.CoreDomain.Clients;

namespace OpenCBS.Extensions.Samples
{
    /// <summary>
    /// This class is a sample implementation of the ICorporateTabs interface
    /// to give you and idea on how you can extend the Corporate client control tabs.
    /// 
    /// To enable this extension right click the OpenCBS.Extensions project,
    /// go to the Build tab and add SAMPLE_EXTENSIONS to Conditional compilation symbols.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(ICorporateTabs))]
    public class CorporateTabsSample : ICorporateTabs
    {
        public TabPage[] GetTabPages(Corporate corporate)
        {
            var page = new TabPage("TEST CORPORATE");
            return new[] { page };
        }

        public void Save(Corporate corporate, SqlTransaction tx)
        {
        }
    }
}
