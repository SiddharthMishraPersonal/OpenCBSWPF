using System;
using System.ComponentModel;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2
{
    public class BackgroundTask : IBackgroundTask
    {
        public Action Action { get; set; }
        public Action OnSuccess { get; set; }
        public Action<Exception> OnError { get; set; }

        public void Run()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (sender, args) => Action();
            backgroundWorker.RunWorkerCompleted += (sender, args) =>
            {
                if (args.Error != null)
                {
                    OnError(args.Error);
                }
                else
                {
                    OnSuccess();
                }
            };
            backgroundWorker.RunWorkerAsync();
        }
    }
}
