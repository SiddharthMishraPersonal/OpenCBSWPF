using System.Windows.Forms;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class UpgradeView
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpgradeView));
            this.logoPicturebox = new System.Windows.Forms.PictureBox();
            this._upgradeLabel = new System.Windows.Forms.Label();
            this._upgradingProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPicturebox
            // 
            this.logoPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.logoPicturebox.BackgroundImage = global::OpenCBS.ArchitectureV2.Properties.Resources.Logo;
            resources.ApplyResources(this.logoPicturebox, "logoPicturebox");
            this.logoPicturebox.Name = "logoPicturebox";
            this.logoPicturebox.TabStop = false;
            // 
            // _upgradeLabel
            // 
            resources.ApplyResources(this._upgradeLabel, "_upgradeLabel");
            this._upgradeLabel.Name = "_upgradeLabel";
            // 
            // _upgradingProgressBar
            // 
            resources.ApplyResources(this._upgradingProgressBar, "_upgradingProgressBar");
            this._upgradingProgressBar.Name = "_upgradingProgressBar";
            this._upgradingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // UpgradeView
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._upgradingProgressBar);
            this.Controls.Add(this._upgradeLabel);
            this.Controls.Add(this.logoPicturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpgradeView";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Label _upgradeLabel;
        private ProgressBar _upgradingProgressBar;


    }
}
