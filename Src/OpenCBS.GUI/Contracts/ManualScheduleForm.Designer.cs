namespace OpenCBS.GUI.Contracts
{
    partial class ManualScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualScheduleForm));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.olvSchedule = new BrightIdeasSoftware.ObjectListView();
            this.numberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.interestColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.principalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.totalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olbColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paidInterestColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paidPrincipalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paymentDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            // 
            // olvSchedule
            // 
            resources.ApplyResources(this.olvSchedule, "olvSchedule");
            this.olvSchedule.AllColumns.Add(this.numberColumn);
            this.olvSchedule.AllColumns.Add(this.dateColumn);
            this.olvSchedule.AllColumns.Add(this.interestColumn);
            this.olvSchedule.AllColumns.Add(this.principalColumn);
            this.olvSchedule.AllColumns.Add(this.totalColumn);
            this.olvSchedule.AllColumns.Add(this.olbColumn);
            this.olvSchedule.AllColumns.Add(this.paidInterestColumn);
            this.olvSchedule.AllColumns.Add(this.paidPrincipalColumn);
            this.olvSchedule.AllColumns.Add(this.paymentDateColumn);
            this.olvSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.dateColumn,
            this.interestColumn,
            this.principalColumn,
            this.totalColumn,
            this.olbColumn,
            this.paidInterestColumn,
            this.paidPrincipalColumn,
            this.paymentDateColumn});
            this.olvSchedule.FullRowSelect = true;
            this.olvSchedule.GridLines = true;
            this.olvSchedule.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.olvSchedule.HeaderWordWrap = true;
            this.olvSchedule.MultiSelect = false;
            this.olvSchedule.Name = "olvSchedule";
            this.olvSchedule.OverlayText.Text = resources.GetString("resource.Text");
            this.olvSchedule.ShowGroups = false;
            this.olvSchedule.UseCompatibleStateImageBehavior = false;
            this.olvSchedule.View = System.Windows.Forms.View.Details;
            this.olvSchedule.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.HandleCellEditFinishing);
            this.olvSchedule.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.HandleCellEditStarting);
            // 
            // numberColumn
            // 
            this.numberColumn.AspectName = "Number";
            resources.ApplyResources(this.numberColumn, "numberColumn");
            this.numberColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberColumn.IsEditable = false;
            // 
            // dateColumn
            // 
            this.dateColumn.AspectName = "ExpectedDate";
            resources.ApplyResources(this.dateColumn, "dateColumn");
            this.dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // interestColumn
            // 
            this.interestColumn.AspectName = "InterestsRepayment";
            resources.ApplyResources(this.interestColumn, "interestColumn");
            this.interestColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // principalColumn
            // 
            this.principalColumn.AspectName = "CapitalRepayment";
            resources.ApplyResources(this.principalColumn, "principalColumn");
            this.principalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalColumn
            // 
            this.totalColumn.AspectName = "AmountHasToPayWithInterest";
            resources.ApplyResources(this.totalColumn, "totalColumn");
            this.totalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalColumn.IsEditable = false;
            // 
            // olbColumn
            // 
            this.olbColumn.AspectName = "OLB";
            resources.ApplyResources(this.olbColumn, "olbColumn");
            this.olbColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olbColumn.IsEditable = false;
            // 
            // paidInterestColumn
            // 
            this.paidInterestColumn.AspectName = "PaidInterests";
            resources.ApplyResources(this.paidInterestColumn, "paidInterestColumn");
            this.paidInterestColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paidInterestColumn.IsEditable = false;
            // 
            // paidPrincipalColumn
            // 
            this.paidPrincipalColumn.AspectName = "PaidCapital";
            resources.ApplyResources(this.paidPrincipalColumn, "paidPrincipalColumn");
            this.paidPrincipalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paidPrincipalColumn.IsEditable = false;
            // 
            // paymentDateColumn
            // 
            this.paymentDateColumn.AspectName = "PaidDate";
            resources.ApplyResources(this.paymentDateColumn, "paymentDateColumn");
            this.paymentDateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paymentDateColumn.IsEditable = false;
            // 
            // ManualScheduleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.olvSchedule);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ManualScheduleForm";
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private BrightIdeasSoftware.ObjectListView olvSchedule;
        private BrightIdeasSoftware.OLVColumn numberColumn;
        private BrightIdeasSoftware.OLVColumn dateColumn;
        private BrightIdeasSoftware.OLVColumn interestColumn;
        private BrightIdeasSoftware.OLVColumn principalColumn;
        private BrightIdeasSoftware.OLVColumn totalColumn;
        private BrightIdeasSoftware.OLVColumn olbColumn;
        private BrightIdeasSoftware.OLVColumn paidInterestColumn;
        private BrightIdeasSoftware.OLVColumn paidPrincipalColumn;
        private BrightIdeasSoftware.OLVColumn paymentDateColumn;
    }
}