namespace OpenCBS.GUI.UserControl
{
    partial class WriteOffOkCancelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteOffOkCancelForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this._optionComboBox = new System.Windows.Forms.ComboBox();
            this._commentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._optionLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tabButtons);
            this.panel1.Name = "panel1";
            // 
            // tabButtons
            // 
            resources.ApplyResources(this.tabButtons, "tabButtons");
            this.tabButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tabButtons.Controls.Add(this.btnOk, 0, 0);
            this.tabButtons.Name = "tabButtons";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // _optionComboBox
            // 
            this._optionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._optionComboBox, "_optionComboBox");
            this._optionComboBox.Name = "_optionComboBox";
            // 
            // _commentTextBox
            // 
            resources.ApplyResources(this._commentTextBox, "_commentTextBox");
            this._commentTextBox.Name = "_commentTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _optionLabel
            // 
            resources.ApplyResources(this._optionLabel, "_optionLabel");
            this._optionLabel.Name = "_optionLabel";
            // 
            // WriteOffOkCancelForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this._commentTextBox);
            this.Controls.Add(this._optionComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._optionLabel);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteOffOkCancelForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tabButtons;
        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox _optionComboBox;
        private System.Windows.Forms.TextBox _commentTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _optionLabel;
    }
}