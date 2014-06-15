using System;
using System.Collections.Generic;
using System.Linq;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ISettingsService _settingsService;

        public DatabaseService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IList<string> FindAll()
        {
            var ds = ServicesProvider.GetInstance().GetDatabaseServices();
            return ds.GetOpenCbsDatabases().Select(x => x.Name).ToList().AsReadOnly();
        }

        public bool IsServerConnectionOk()
        {
            return ServicesProvider.GetInstance().GetDatabaseServices().CheckSQLServerConnection();
        }

        public bool IsVersionOk()
        {
            return ServicesProvider
                .GetInstance()
                .GetDatabaseServices()
                .CheckSQLDatabaseVersion(_settingsService.GetSoftwareVersion(), _settingsService.GetDatabaseName());
        }

        public void UpdateDatabase()
        {
            ServicesProvider
                .GetInstance()
                .GetDatabaseServices()
                .UpdateDatabase(
                    _settingsService.GetSoftwareVersion(), 
                    _settingsService.GetDatabaseName(),
                    _settingsService.GetUpdatePath());
        }
    }
}
