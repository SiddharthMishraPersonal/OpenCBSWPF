namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface ISettingsService
    {
        string GetDatabaseName();
        void SetDatabaseName(string name);
        string GetSoftwareVersion();
        string GetUpdatePath();
        string GetNumberGroupSeparator();
        string GetNumberDecimalSeparator();
        void Init();
    }
}
