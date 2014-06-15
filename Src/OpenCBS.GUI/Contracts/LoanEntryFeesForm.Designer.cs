namespace OpenCBS.GUI.Contracts
{
    partial class LoanEntryFeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanEntryFeesForm));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this._entryFeesListView = new BrightIdeasSoftware.ObjectListView();
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._amountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._entryFeesListView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Controls.Add(this.okButton);
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // _entryFeesListView
            // 
            resources.ApplyResources(this._entryFeesListView, "_entryFeesListView");
            this._entryFeesListView.AllColumns.Add(this._nameColumn);
            this._entryFeesListView.AllColumns.Add(this._amountColumn);
            this._entryFeesListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this._entryFeesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumn,
            this._amountColumn});
            this._entryFeesListView.FullRowSelect = true;
            this._entryFeesListView.GridLines = true;
            this._entryFeesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._entryFeesListView.HeaderWordWrap = true;
            this._entryFeesListView.MultiSelect = false;
            this._entryFeesListView.Name = "_entryFeesListView";
            this._entryFeesListView.OverlayText.Text = resources.GetString("resource.Text");
            this._entryFeesListView.ShowGroups = false;
            this._entryFeesListView.UseCompatibleStateImageBehavior = false;
            this._entryFeesListView.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "ProductEntryFee.Name";
            resources.ApplyResources(this._nameColumn, "_nameColumn");
            this._nameColumn.IsEditable = false;
            // 
            // _amountColumn
            // 
            this._amountColumn.AspectName = "FeeValue";
            resources.ApplyResources(this._amountColumn, "_amountColumn");
            this._amountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LoanEntryFeesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._entryFeesListView);
            this.Controls.Add(this.buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanEntryFeesForm";
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._entryFeesListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private BrightIdeasSoftware.ObjectListView _entryFeesListView;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private BrightIdeasSoftware.OLVColumn _amountColumn;
    }
}