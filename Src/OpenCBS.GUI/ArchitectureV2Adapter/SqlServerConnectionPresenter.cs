using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.GUI.Database;

namespace OpenCBS.GUI.ArchitectureV2Adapter
{
    public class SqlServerConnectionPresenter : ISqlServerConnectionPresenter
    {
        private Form _form;

        public void Run()
        {
            _form = new FrmDatabaseSettings(FrmDatabaseSettingsEnum.SqlServerConnection, true, false);
            _form.Show();
        }

        public object View
        {
            get { return _form; }
        }
    }
}
