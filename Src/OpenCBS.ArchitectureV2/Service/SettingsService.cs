using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.Services;
using OpenCBS.Shared.Settings;

namespace OpenCBS.ArchitectureV2.Service
{
    public class SettingsService : ISettingsService
    {
        public string GetDatabaseName()
        {
            return TechnicalSettings.DatabaseName;
        }

        public void SetDatabaseName(string name)
        {
            TechnicalSettings.DatabaseName = name;
        }

        public string GetSoftwareVersion()
        {
            return TechnicalSettings.SoftwareVersion;
        }

        public void Init()
        {
            ServicesProvider.GetInstance().GetApplicationSettingsServices().CheckApplicationSettings();
        }

        public string GetUpdatePath()
        {
            return UserSettings.GetUpdatePath;
        }

        public string GetNumberGroupSeparator()
        {
            return ApplicationSettings.GetInstance("").NumberGroupSeparator;
        }

        public string GetNumberDecimalSeparator()
        {
            return ApplicationSettings.GetInstance("").NumberDecimalSeparator;
        }
    }
}
