using System;

namespace OpenCBS.ArchitectureV2.Interface
{
    public interface IBackgroundTask
    {
        Action Action { get; set; }
        Action OnSuccess { get; set; }
        Action<Exception> OnError { get; set; }
        void Run();
    }
}
