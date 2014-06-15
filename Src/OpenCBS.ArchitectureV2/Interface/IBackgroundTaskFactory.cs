namespace OpenCBS.ArchitectureV2.Interface
{
    public interface IBackgroundTaskFactory
    {
        IBackgroundTask GetTask();
    }
}
