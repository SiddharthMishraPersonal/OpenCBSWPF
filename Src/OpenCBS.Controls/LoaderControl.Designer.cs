namespace OpenCBS.Controls
{
    partial class LoaderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaderControl));
            this.loaderPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loaderPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loaderPictureBox
            // 
            this.loaderPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loaderPictureBox.Enabled = false;
            this.loaderPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loaderPictureBox.Image")));
            this.loaderPictureBox.InitialImage = null;
            this.loaderPictureBox.Location = new System.Drawing.Point(0, 0);
            this.loaderPictureBox.Name = "loaderPictureBox";
            this.loaderPictureBox.Size = new System.Drawing.Size(220, 18);
            this.loaderPictureBox.TabIndex = 0;
            this.loaderPictureBox.TabStop = false;
            // 
            // LoaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loaderPictureBox);
            this.Name = "LoaderControl";
            this.Size = new System.Drawing.Size(220, 18);
            ((System.ComponentModel.ISupportInitialize)(this.loaderPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox loaderPictureBox;
    }
}
