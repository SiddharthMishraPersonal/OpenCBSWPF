using System.Windows.Forms;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class LoginView
    {
        private System.Windows.Forms.Button _loginButton;
        private TextBox _usernameTextBox;
        private TextBox _passwordTextBox;
        private Label _usernameLabel;
        private Label _passwordLabel;
        private PictureBox logoPicturebox;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this._loginButton = new System.Windows.Forms.Button();
            this._usernameTextBox = new System.Windows.Forms.TextBox();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._databaseComboBox = new System.Windows.Forms.ComboBox();
            this._databaseLabel = new System.Windows.Forms.Label();
            this.logoPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // _loginButton
            // 
            resources.ApplyResources(this._loginButton, "_loginButton");
            this._loginButton.BackColor = System.Drawing.SystemColors.Control;
            this._loginButton.Name = "_loginButton";
            this._loginButton.UseVisualStyleBackColor = false;
            // 
            // _usernameTextBox
            // 
            resources.ApplyResources(this._usernameTextBox, "_usernameTextBox");
            this._usernameTextBox.Name = "_usernameTextBox";
            // 
            // _passwordTextBox
            // 
            resources.ApplyResources(this._passwordTextBox, "_passwordTextBox");
            this._passwordTextBox.Name = "_passwordTextBox";
            // 
            // _usernameLabel
            // 
            resources.ApplyResources(this._usernameLabel, "_usernameLabel");
            this._usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this._usernameLabel.Name = "_usernameLabel";
            // 
            // _passwordLabel
            // 
            resources.ApplyResources(this._passwordLabel, "_passwordLabel");
            this._passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this._passwordLabel.Name = "_passwordLabel";
            // 
            // _databaseComboBox
            // 
            resources.ApplyResources(this._databaseComboBox, "_databaseComboBox");
            this._databaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._databaseComboBox.FormattingEnabled = true;
            this._databaseComboBox.Name = "_databaseComboBox";
            // 
            // _databaseLabel
            // 
            resources.ApplyResources(this._databaseLabel, "_databaseLabel");
            this._databaseLabel.BackColor = System.Drawing.Color.Transparent;
            this._databaseLabel.Name = "_databaseLabel";
            // 
            // logoPicturebox
            // 
            this.logoPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.logoPicturebox.BackgroundImage = global::OpenCBS.ArchitectureV2.Properties.Resources.Logo;
            resources.ApplyResources(this.logoPicturebox, "logoPicturebox");
            this.logoPicturebox.Name = "logoPicturebox";
            this.logoPicturebox.TabStop = false;
            // 
            // LoginView
            // 
            this.AcceptButton = this._loginButton;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._databaseComboBox);
            this.Controls.Add(this.logoPicturebox);
            this.Controls.Add(this._usernameTextBox);
            this.Controls.Add(this._passwordTextBox);
            this.Controls.Add(this._loginButton);
            this.Controls.Add(this._databaseLabel);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private ComboBox _databaseComboBox;
        private Label _databaseLabel;

    }
}
