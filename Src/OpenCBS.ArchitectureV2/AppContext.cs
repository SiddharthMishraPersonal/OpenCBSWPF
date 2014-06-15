using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;
using StructureMap;

namespace OpenCBS.ArchitectureV2
{
    public class AppContext : ApplicationContext
    {
        private readonly IContainer _container;

        public AppContext(IContainer container)
        {
            _container = container;
            var databaseService = _container.GetInstance<IDatabaseService>();
            if (databaseService.IsServerConnectionOk())
            {
                MainForm = GetLoginForm();
            }
            else
            {
                MainForm = GetSqlServerConnectionForm();
            }
        }

        private Form GetLoginForm()
        {
            var presenter = _container.GetInstance<ILoginPresenter>();
            presenter.Run();
            return (Form) presenter.View;
        }

        private Form GetMainForm()
        {
            var settingsService = _container.GetInstance<ISettingsService>();
            settingsService.Init();
            Thread.CurrentThread.CurrentCulture.NumberFormat = new NumberFormatInfo
            {
                NumberGroupSeparator = settingsService.GetNumberGroupSeparator(),
                NumberDecimalSeparator = settingsService.GetNumberDecimalSeparator(),
            };

            var mainView = _container.GetInstance<IMainView>();
            mainView.Run();
            return (Form) mainView;
        }

        private Form GetUpgradeForm()
        {
            var presenter = _container.GetInstance<IUpgradePresenter>();
            presenter.Run();
            return (Form) presenter.View;
        }

        private Form GetSqlServerConnectionForm()
        {
            var presenter = _container.GetInstance<ISqlServerConnectionPresenter>();
            presenter.Run();
            return (Form) presenter.View;
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (sender is ILoginView)
            {
                var authService = _container.GetInstance<IAuthService>();
                if (authService.LoggedIn)
                {
                    var databaseService = _container.GetInstance<IDatabaseService>();
                    if (databaseService.IsVersionOk())
                    {
                        MainForm = GetMainForm();
                    }
                    else
                    {
                        MainForm = GetUpgradeForm();
                    }
                }
                else
                {
                    base.OnMainFormClosed(sender, e);
                }
            }
            else if (sender is IUpgradeView)
            {
                var view = (IUpgradeView) sender;
                if (view.Upgraded)
                {
                    MainForm = GetMainForm();
                }
                else
                {
                    base.OnMainFormClosed(sender, e);
                }
            }
            else if (sender is IMainView)
            {
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
