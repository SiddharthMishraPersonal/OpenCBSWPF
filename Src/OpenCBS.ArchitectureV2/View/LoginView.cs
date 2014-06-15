using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Controls;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class LoginView : BaseView, ILoginView
    {
        private readonly LoaderControl _loader = new LoaderControl();

        public LoginView(ITranslationService translationService) : base(translationService)
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }

        public void StartDatabaseListRefresh()
        {
            Cursor = Cursors.WaitCursor;
            _databaseComboBox.Enabled = false;
            _usernameTextBox.Enabled = false;
            _passwordTextBox.Enabled = false;
            _loginButton.Enabled = false;
            _loader.AttachTo(_databaseComboBox);
            _loader.Start();
        }

        public void StopDatabaseListRefresh()
        {
            _loader.Stop();
            Cursor = Cursors.Arrow;
            _databaseComboBox.Enabled = true;
            _usernameTextBox.Enabled = true;
            _passwordTextBox.Enabled = true;
            _loginButton.Enabled = true;
            _usernameTextBox.Focus();
        }

        public void ShowDatabases(IList<string> databases)
        {
            var dict = databases.ToDictionary(i => i, i => i);
            _databaseComboBox.ValueMember = "Key";
            _databaseComboBox.DisplayMember = "Value";
            _databaseComboBox.DataSource = new BindingSource(dict, null);
        }

        public string Username
        {
            get { return _usernameTextBox.Text; }
            set { _usernameTextBox.Text = value; }
        }

        public string Password
        {
            get { return _passwordTextBox.Text; }
            set { _passwordTextBox.Text = value; }
        }

        public string Database
        {
            get
            {
                if (_databaseComboBox.SelectedValue == null)
                    return null;
                return _databaseComboBox.SelectedValue.ToString();
            }
            set
            {
                if (value == null)
                    _databaseComboBox.SelectedIndex = -1;
                else
                    _databaseComboBox.SelectedValue = value;
            }
        }

        public void Attach(ILoginPresenterCallbacks presenterCallbacks)
        {
            _loginButton.Click += (sender, e) => presenterCallbacks.Ok();
        }
    }
}
