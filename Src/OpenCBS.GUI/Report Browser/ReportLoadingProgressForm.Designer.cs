namespace OpenCBS.GUI.Report_Browser
{
    partial class ReportLoadingProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportLoadingProgressForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.loaderControl = new OpenCBS.Controls.LoaderControl();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // elapsedTimeLabel
            // 
            resources.ApplyResources(this.elapsedTimeLabel, "elapsedTimeLabel");
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            // 
            // loaderControl
            // 
            resources.ApplyResources(this.loaderControl, "loaderControl");
            this.loaderControl.Name = "loaderControl";
            // 
            // ReportLoadingProgressForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loaderControl);
            this.Controls.Add(this.elapsedTimeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportLoadingProgressForm";
            this.Opacity = 0.98D;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private Controls.LoaderControl loaderControl;
    }
}