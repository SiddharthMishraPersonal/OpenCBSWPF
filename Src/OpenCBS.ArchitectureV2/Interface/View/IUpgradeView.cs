namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IUpgradeView
    {
        void Run();
        void Stop();
        bool Upgraded { get; set; }
    }
}
