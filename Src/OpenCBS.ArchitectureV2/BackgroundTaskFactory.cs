using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2
{
    public class BackgroundTaskFactory : IBackgroundTaskFactory
    {
        public IBackgroundTask GetTask()
        {
            return new BackgroundTask();
        }
    }
}
