namespace OpenCBS.Controls
{
    partial class ScheduleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleControl));
            this.scheduleObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.numberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.interestColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.principalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.totalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olbColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paidInterestColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paidPrincipalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paymentDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.scheduleObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // scheduleObjectListView
            // 
            this.scheduleObjectListView.AllColumns.Add(this.numberColumn);
            this.scheduleObjectListView.AllColumns.Add(this.dateColumn);
            this.scheduleObjectListView.AllColumns.Add(this.interestColumn);
            this.scheduleObjectListView.AllColumns.Add(this.principalColumn);
            this.scheduleObjectListView.AllColumns.Add(this.totalColumn);
            this.scheduleObjectListView.AllColumns.Add(this.olbColumn);
            this.scheduleObjectListView.AllColumns.Add(this.paidInterestColumn);
            this.scheduleObjectListView.AllColumns.Add(this.paidPrincipalColumn);
            this.scheduleObjectListView.AllColumns.Add(this.paymentDateColumn);
            this.scheduleObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.dateColumn,
            this.interestColumn,
            this.principalColumn,
            this.totalColumn,
            this.olbColumn,
            this.paidInterestColumn,
            this.paidPrincipalColumn,
            this.paymentDateColumn});
            resources.ApplyResources(this.scheduleObjectListView, "scheduleObjectListView");
            this.scheduleObjectListView.FullRowSelect = true;
            this.scheduleObjectListView.GridLines = true;
            this.scheduleObjectListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scheduleObjectListView.HeaderWordWrap = true;
            this.scheduleObjectListView.MultiSelect = false;
            this.scheduleObjectListView.Name = "scheduleObjectListView";
            this.scheduleObjectListView.ShowGroups = false;
            this.scheduleObjectListView.UseCompatibleStateImageBehavior = false;
            this.scheduleObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // numberColumn
            // 
            this.numberColumn.AspectName = "Number";
            this.numberColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.numberColumn, "numberColumn");
            // 
            // dateColumn
            // 
            this.dateColumn.AspectName = "ExpectedDate";
            this.dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.dateColumn, "dateColumn");
            // 
            // interestColumn
            // 
            this.interestColumn.AspectName = "InterestsRepayment";
            this.interestColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.interestColumn, "interestColumn");
            // 
            // principalColumn
            // 
            this.principalColumn.AspectName = "CapitalRepayment";
            this.principalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.principalColumn, "principalColumn");
            // 
            // totalColumn
            // 
            this.totalColumn.AspectName = "AmountHasToPayWithInterest";
            this.totalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.totalColumn, "totalColumn");
            // 
            // olbColumn
            // 
            this.olbColumn.AspectName = "OLB";
            this.olbColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.olbColumn, "olbColumn");
            // 
            // paidInterestColumn
            // 
            this.paidInterestColumn.AspectName = "PaidInterests";
            this.paidInterestColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.paidInterestColumn, "paidInterestColumn");
            // 
            // paidPrincipalColumn
            // 
            this.paidPrincipalColumn.AspectName = "PaidCapital";
            this.paidPrincipalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.paidPrincipalColumn, "paidPrincipalColumn");
            // 
            // paymentDateColumn
            // 
            this.paymentDateColumn.AspectName = "PaidDate";
            this.paymentDateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this.paymentDateColumn, "paymentDateColumn");
            // 
            // ScheduleControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scheduleObjectListView);
            this.Name = "ScheduleControl";
            ((System.ComponentModel.ISupportInitialize)(this.scheduleObjectListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView scheduleObjectListView;
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
