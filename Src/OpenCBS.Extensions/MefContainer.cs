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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using OpenCBS.CoreDomain;

namespace OpenCBS.Extensions
{
    public class MefContainer
    {
        private readonly CompositionContainer _container;
        private static MefContainer _instance;

        public static MefContainer Current
        {
            get { return _instance ?? (_instance = new MefContainer()); }
        }

        private MefContainer()
        {
            var extensionsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            extensionsFolder = Path.Combine(extensionsFolder, "Extensions");
            var catalog = new AggregateCatalog(
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new AssemblyCatalog(Assembly.GetAssembly(typeof(DatabaseConnection)))
                );

            if (Directory.Exists(extensionsFolder))
                catalog.Catalogs.Add(new DirectoryCatalog(extensionsFolder));

#if SAMPLE_EXTENSIONS
            var samples = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            samples = Path.Combine(samples, "OpenCBS.Extensions.Samples.dll");
            if (File.Exists(samples)) 
                catalog.Catalogs.Add(new AssemblyCatalog(samples));
#endif
            _container = new CompositionContainer(catalog);
            
        }

        public void Bind(object host)
        {
            _container.SatisfyImportsOnce(host);
        }
    }
}
