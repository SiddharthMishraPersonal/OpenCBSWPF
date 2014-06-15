using OpenCBS.GUI.UserControl;

namespace OpenCBS.GUI.Accounting
{
    partial class AccountingJournals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingJournals));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.clbxFields = new System.Windows.Forms.CheckedListBox();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.dateTimePickerBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.bwRun = new System.ComponentModel.BackgroundWorker();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpMovements = new System.Windows.Forms.TabPage();
            this.olvBookings = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn_EventId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_CreditAccount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_DebitAccount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_EventType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_TransactionDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbxAllBookings = new System.Windows.Forms.CheckBox();
            this.tbpEvents = new System.Windows.Forms.TabPage();
            this.olvEvents = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn_Code = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Description = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Amnt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Fee = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_OLB = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_OverdueDays = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_OverduePrincipal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Date = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Interest = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_AccruedInterest = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbAllEvents = new System.Windows.Forms.CheckBox();
            this.timerClosure = new System.Windows.Forms.Timer(this.components);
            this.bwPostEvents = new System.ComponentModel.BackgroundWorker();
            this.bwPostBookings = new System.ComponentModel.BackgroundWorker();
            this.pnlRight.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbpMovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvBookings)).BeginInit();
            this.tbpEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.Controls.Add(this.btnView);
            this.pnlRight.Controls.Add(this.btnPost);
            this.pnlRight.Controls.Add(this.clbxFields);
            this.pnlRight.Controls.Add(this.cmbBranches);
            this.pnlRight.Controls.Add(this.lblBranch);
            this.pnlRight.Controls.Add(this.dateTimePickerBeginDate);
            this.pnlRight.Controls.Add(this.dateTimePickerEndDate);
            this.pnlRight.Controls.Add(this.lblBeginDate);
            this.pnlRight.Controls.Add(this.lblEndDate);
            this.pnlRight.Controls.Add(this.btnPreview);
            this.pnlRight.Name = "pnlRight";
            // 
            // btnView
            // 
            resources.ApplyResources(this.btnView, "btnView");
            this.btnView.Name = "btnView";
            this.btnView.Click += new System.EventHandler(this.BtnViewClick);
            // 
            // btnPost
            // 
            resources.ApplyResources(this.btnPost, "btnPost");
            this.btnPost.Name = "btnPost";
            this.btnPost.Click += new System.EventHandler(this.BtnPostClick);
            // 
            // clbxFields
            // 
            resources.ApplyResources(this.clbxFields, "clbxFields");
            this.clbxFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbxFields.CheckOnClick = true;
            this.clbxFields.FormattingEnabled = true;
            this.clbxFields.Name = "clbxFields";
            // 
            // cmbBranches
            // 
            resources.ApplyResources(this.cmbBranches, "cmbBranches");
            this.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranches.FormattingEnabled = true;
            this.cmbBranches.Name = "cmbBranches";
            // 
            // lblBranch
            // 
            resources.ApplyResources(this.lblBranch, "lblBranch");
            this.lblBranch.Name = "lblBranch";
            // 
            // dateTimePickerBeginDate
            // 
            resources.ApplyResources(this.dateTimePickerBeginDate, "dateTimePickerBeginDate");
            this.dateTimePickerBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBeginDate.Name = "dateTimePickerBeginDate";
            // 
            // dateTimePickerEndDate
            // 
            resources.ApplyResources(this.dateTimePickerEndDate, "dateTimePickerEndDate");
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            // 
            // lblBeginDate
            // 
            resources.ApplyResources(this.lblBeginDate, "lblBeginDate");
            this.lblBeginDate.Name = "lblBeginDate";
            // 
            // lblEndDate
            // 
            resources.ApplyResources(this.lblEndDate, "lblEndDate");
            this.lblEndDate.Name = "lblEndDate";
            // 
            // btnPreview
            // 
            resources.ApplyResources(this.btnPreview, "btnPreview");
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // bwRun
            // 
            this.bwRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwRunDoWork);
            this.bwRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwRunRunWorkerCompleted);
            // 
            // tbcMain
            // 
            resources.ApplyResources(this.tbcMain, "tbcMain");
            this.tbcMain.Controls.Add(this.tbpMovements);
            this.tbcMain.Controls.Add(this.tbpEvents);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            // 
            // tbpMovements
            // 
            resources.ApplyResources(this.tbpMovements, "tbpMovements");
            this.tbpMovements.Controls.Add(this.olvBookings);
            this.tbpMovements.Controls.Add(this.cbxAllBookings);
            this.tbpMovements.Name = "tbpMovements";
            // 
            // olvBookings
            // 
            resources.ApplyResources(this.olvBookings, "olvBookings");
            this.olvBookings.AllColumns.Add(this.olvColumn_EventId);
            this.olvBookings.AllColumns.Add(this.olvColumn_CreditAccount);
            this.olvBookings.AllColumns.Add(this.olvColumn_DebitAccount);
            this.olvBookings.AllColumns.Add(this.olvColumn_EventType);
            this.olvBookings.AllColumns.Add(this.olvColumn_Amount);
            this.olvBookings.AllColumns.Add(this.olvColumn_TransactionDate);
            this.olvBookings.CheckBoxes = true;
            this.olvBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn_EventId,
            this.olvColumn_CreditAccount,
            this.olvColumn_DebitAccount,
            this.olvColumn_EventType,
            this.olvColumn_Amount,
            this.olvColumn_TransactionDate});
            this.olvBookings.FullRowSelect = true;
            this.olvBookings.GridLines = true;
            this.olvBookings.HasCollapsibleGroups = false;
            this.olvBookings.Name = "olvBookings";
            this.olvBookings.OverlayText.Text = resources.GetString("resource.Text");
            this.olvBookings.UseCompatibleStateImageBehavior = false;
            this.olvBookings.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn_EventId
            // 
            this.olvColumn_EventId.AspectName = "EventId";
            this.olvColumn_EventId.CheckBoxes = true;
            resources.ApplyResources(this.olvColumn_EventId, "olvColumn_EventId");
            // 
            // olvColumn_CreditAccount
            // 
            this.olvColumn_CreditAccount.AspectName = "CreditAccount";
            this.olvColumn_CreditAccount.Groupable = false;
            resources.ApplyResources(this.olvColumn_CreditAccount, "olvColumn_CreditAccount");
            // 
            // olvColumn_DebitAccount
            // 
            this.olvColumn_DebitAccount.AspectName = "DebitAccount";
            this.olvColumn_DebitAccount.Groupable = false;
            resources.ApplyResources(this.olvColumn_DebitAccount, "olvColumn_DebitAccount");
            // 
            // olvColumn_EventType
            // 
            this.olvColumn_EventType.AspectName = "EventType";
            resources.ApplyResources(this.olvColumn_EventType, "olvColumn_EventType");
            // 
            // olvColumn_Amount
            // 
            this.olvColumn_Amount.AspectName = "Amount";
            this.olvColumn_Amount.AutoCompleteEditor = false;
            this.olvColumn_Amount.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvColumn_Amount.Groupable = false;
            resources.ApplyResources(this.olvColumn_Amount, "olvColumn_Amount");
            this.olvColumn_Amount.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColumn_TransactionDate
            // 
            this.olvColumn_TransactionDate.AspectName = "Date";
            this.olvColumn_TransactionDate.Groupable = false;
            resources.ApplyResources(this.olvColumn_TransactionDate, "olvColumn_TransactionDate");
            // 
            // cbxAllBookings
            // 
            resources.ApplyResources(this.cbxAllBookings, "cbxAllBookings");
            this.cbxAllBookings.Name = "cbxAllBookings";
            this.cbxAllBookings.CheckedChanged += new System.EventHandler(this.CbxAllBookingsCheckedChanged);
            // 
            // tbpEvents
            // 
            resources.ApplyResources(this.tbpEvents, "tbpEvents");
            this.tbpEvents.Controls.Add(this.olvEvents);
            this.tbpEvents.Controls.Add(this.cbAllEvents);
            this.tbpEvents.Name = "tbpEvents";
            // 
            // olvEvents
            // 
            resources.ApplyResources(this.olvEvents, "olvEvents");
            this.olvEvents.AllColumns.Add(this.olvColumn_Code);
            this.olvEvents.AllColumns.Add(this.olvColumn_Description);
            this.olvEvents.AllColumns.Add(this.olvColumn_Amnt);
            this.olvEvents.AllColumns.Add(this.olvColumn_Fee);
            this.olvEvents.AllColumns.Add(this.olvColumn_OLB);
            this.olvEvents.AllColumns.Add(this.olvColumn_OverdueDays);
            this.olvEvents.AllColumns.Add(this.olvColumn_OverduePrincipal);
            this.olvEvents.AllColumns.Add(this.olvColumn_Date);
            this.olvEvents.AllColumns.Add(this.olvColumn_Interest);
            this.olvEvents.AllColumns.Add(this.olvColumn_AccruedInterest);
            this.olvEvents.CheckBoxes = true;
            this.olvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn_Code,
            this.olvColumn_Description,
            this.olvColumn_Amnt,
            this.olvColumn_Fee,
            this.olvColumn_OLB,
            this.olvColumn_OverdueDays,
            this.olvColumn_OverduePrincipal,
            this.olvColumn_Date,
            this.olvColumn_Interest,
            this.olvColumn_AccruedInterest});
            this.olvEvents.FullRowSelect = true;
            this.olvEvents.GridLines = true;
            this.olvEvents.HasCollapsibleGroups = false;
            this.olvEvents.Name = "olvEvents";
            this.olvEvents.OverlayText.Text = resources.GetString("resource.Text1");
            this.olvEvents.UseCompatibleStateImageBehavior = false;
            this.olvEvents.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn_Code
            // 
            this.olvColumn_Code.AspectName = "Code";
            resources.ApplyResources(this.olvColumn_Code, "olvColumn_Code");
            // 
            // olvColumn_Description
            // 
            this.olvColumn_Description.AspectName = "Description";
            resources.ApplyResources(this.olvColumn_Description, "olvColumn_Description");
            // 
            // olvColumn_Amnt
            // 
            this.olvColumn_Amnt.AspectName = "Amount";
            resources.ApplyResources(this.olvColumn_Amnt, "olvColumn_Amnt");
            // 
            // olvColumn_Fee
            // 
            this.olvColumn_Fee.AspectName = "Fee";
            resources.ApplyResources(this.olvColumn_Fee, "olvColumn_Fee");
            // 
            // olvColumn_OLB
            // 
            this.olvColumn_OLB.AspectName = "OLB";
            this.olvColumn_OLB.Groupable = false;
            resources.ApplyResources(this.olvColumn_OLB, "olvColumn_OLB");
            // 
            // olvColumn_OverdueDays
            // 
            this.olvColumn_OverdueDays.AspectName = "OverdueDays";
            this.olvColumn_OverdueDays.Groupable = false;
            resources.ApplyResources(this.olvColumn_OverdueDays, "olvColumn_OverdueDays");
            // 
            // olvColumn_OverduePrincipal
            // 
            this.olvColumn_OverduePrincipal.AspectName = "OverduePrincipal";
            this.olvColumn_OverduePrincipal.AutoCompleteEditor = false;
            this.olvColumn_OverduePrincipal.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvColumn_OverduePrincipal.Groupable = false;
            resources.ApplyResources(this.olvColumn_OverduePrincipal, "olvColumn_OverduePrincipal");
            this.olvColumn_OverduePrincipal.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColumn_Date
            // 
            this.olvColumn_Date.AspectName = "Date";
            this.olvColumn_Date.Groupable = false;
            resources.ApplyResources(this.olvColumn_Date, "olvColumn_Date");
            // 
            // olvColumn_Interest
            // 
            this.olvColumn_Interest.AspectName = "Interest";
            resources.ApplyResources(this.olvColumn_Interest, "olvColumn_Interest");
            // 
            // olvColumn_AccruedInterest
            // 
            this.olvColumn_AccruedInterest.AspectName = "AccruedInterest";
            resources.ApplyResources(this.olvColumn_AccruedInterest, "olvColumn_AccruedInterest");
            // 
            // cbAllEvents
            // 
            resources.ApplyResources(this.cbAllEvents, "cbAllEvents");
            this.cbAllEvents.Name = "cbAllEvents";
            this.cbAllEvents.CheckedChanged += new System.EventHandler(this.CbAllEventsCheckedChanged);
            // 
            // timerClosure
            // 
            this.timerClosure.Interval = 5;
            this.timerClosure.Tick += new System.EventHandler(this.TimerClosureTick);
            // 
            // bwPostEvents
            // 
            this.bwPostEvents.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwPostEventsDoWork);
            this.bwPostEvents.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwPostEventsRunWorkerCompleted);
            // 
            // bwPostBookings
            // 
            this.bwPostBookings.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwPostBookingsDoWork);
            this.bwPostBookings.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwPostBookingsRunWorkerCompleted);
            // 
            // AccountingJournals
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.pnlRight);
            this.Name = "AccountingJournals";
            this.Load += new System.EventHandler(this.AccountingJournalsLoad);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.tbpMovements.ResumeLayout(false);
            this.tbpMovements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvBookings)).EndInit();
            this.tbpEvents.ResumeLayout(false);
            this.tbpEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.DateTimePicker dateTimePickerBeginDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.ComponentModel.BackgroundWorker bwRun;
        private System.Windows.Forms.CheckedListBox clbxFields;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpMovements;
        private BrightIdeasSoftware.ObjectListView olvBookings;
        private BrightIdeasSoftware.OLVColumn olvColumn_EventId;
        private BrightIdeasSoftware.OLVColumn olvColumn_CreditAccount;
        private BrightIdeasSoftware.OLVColumn olvColumn_DebitAccount;
        private BrightIdeasSoftware.OLVColumn olvColumn_EventType;
        private BrightIdeasSoftware.OLVColumn olvColumn_Amount;
        private BrightIdeasSoftware.OLVColumn olvColumn_TransactionDate;
        private System.Windows.Forms.TabPage tbpEvents;
        private BrightIdeasSoftware.ObjectListView olvEvents;
        private BrightIdeasSoftware.OLVColumn olvColumn_OLB;
        private BrightIdeasSoftware.OLVColumn olvColumn_OverdueDays;
        private BrightIdeasSoftware.OLVColumn olvColumn_Code;
        private BrightIdeasSoftware.OLVColumn olvColumn_OverduePrincipal;
        private BrightIdeasSoftware.OLVColumn olvColumn_Date;
        private BrightIdeasSoftware.OLVColumn olvColumn_Amnt;
        private BrightIdeasSoftware.OLVColumn olvColumn_Interest;
        private BrightIdeasSoftware.OLVColumn olvColumn_AccruedInterest;
        private BrightIdeasSoftware.OLVColumn olvColumn_Description;
        private System.Windows.Forms.CheckBox cbxAllBookings;
        private System.Windows.Forms.CheckBox cbAllEvents;
        private System.Windows.Forms.Button btnPost;
        private BrightIdeasSoftware.OLVColumn olvColumn_Fee;
        private System.Windows.Forms.Timer timerClosure;
        private System.Windows.Forms.Button btnView;
        private System.ComponentModel.BackgroundWorker bwPostEvents;
        private System.ComponentModel.BackgroundWorker bwPostBookings;

    }
}