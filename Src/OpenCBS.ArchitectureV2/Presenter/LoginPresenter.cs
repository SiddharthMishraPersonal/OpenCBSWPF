using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.Presenter
{

    public class LoginPresenter : ILoginPresenter, ILoginPresenterCallbacks
    {
        private readonly ILoginView _view;
        private readonly IErrorView _errorView;
        private readonly IDatabaseService _databaseService;
        private readonly IAuthService _authService;
        private readonly ISettingsService _settingsService;
        private readonly IBackgroundTaskFactory _backgroundTaskFactory;

        public LoginPresenter(
            ILoginView view,
            IErrorView errorView,
            IDatabaseService databaseService,
            IAuthService authService,
            ISettingsService settingsService,
            IBackgroundTaskFactory backgroundTaskFactory)
        {
            _view = view;
            _errorView = errorView;
            _databaseService = databaseService;
            _authService = authService;
            _settingsService = settingsService;
            _backgroundTaskFactory = backgroundTaskFactory;
        }

        public void Ok()
        {
            _settingsService.SetDatabaseName(_view.Database);
            _authService.Login(_view.Username, _view.Password);
            if (_authService.LoggedIn)
            {
                _view.Stop();
            }
            else
            {
                _errorView.Run("Invalid username or password.");
            }
        }

        public void Run()
        {
            _view.Attach(this);

            var task = _backgroundTaskFactory.GetTask();
            IList<string> databases = new List<string>();
            task.Action = () =>
            {
                databases = _databaseService.FindAll();
            };
            task.OnSuccess = () =>
            {
                _view.StopDatabaseListRefresh();
                _view.ShowDatabases(databases);
                _view.Database = _settingsService.GetDatabaseName();
            };
            task.OnError = error =>
            {
                _view.StopDatabaseListRefresh();
                _errorView.Run(error.Message);
            };
            _view.StartDatabaseListRefresh();
            task.Run();
        }

        public object View
        {
            get { return _view; }
        }
    }
}
