using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class UpgradePresenter : IUpgradePresenter
    {
        private readonly IUpgradeView _view;
        private readonly IErrorView _errorView;
        private readonly IBackgroundTaskFactory _backgroundTaskFactory;
        private readonly IDatabaseService _databaseService;

        public UpgradePresenter(
            IUpgradeView view, 
            IErrorView errorView, 
            IBackgroundTaskFactory backgroundTaskFactory,
            IDatabaseService databaseService)
        {
            _view = view;
            _errorView = errorView;
            _backgroundTaskFactory = backgroundTaskFactory;
            _databaseService = databaseService;
        }

        public void Run()
        {
            _view.Run();

            var task = _backgroundTaskFactory.GetTask();
            task.Action = () => _databaseService.UpdateDatabase();
            task.OnSuccess = () =>
            {
                _view.Upgraded = true;
                _view.Stop();
            };
            task.OnError = error =>
            {
                _errorView.Run(error.Message);
                _view.Upgraded = false;
                _view.Stop();
            };
            task.Run();
        }

        public object View
        {
            get { return _view; }
        }
    }
}
