using OpenCBS.GUI.UserControl;

namespace OpenCBS.GUI.Configuration
{
    partial class AddTellerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTellerForm));
            this.tabctrlAddTeller = new System.Windows.Forms.TabControl();
            this.tabBasicTeller = new System.Windows.Forms.TabPage();
            this.chxIsVault = new System.Windows.Forms.CheckBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tabAdvancedTeller = new System.Windows.Forms.TabPage();
            this.lblMaxAmountWithdrawal = new System.Windows.Forms.Label();
            this.lblMinAmountWithdrawal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxAmountDeposit = new System.Windows.Forms.Label();
            this.tbMaxAmountWithdrawal = new System.Windows.Forms.TextBox();
            this.lblMinAmountDeposit = new System.Windows.Forms.Label();
            this.tbMinAmountWithdrawal = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbMaxAmountDeposit = new System.Windows.Forms.TextBox();
            this.lblMaxAmountTeller = new System.Windows.Forms.Label();
            this.tbMinAmountDeposit = new System.Windows.Forms.TextBox();
            this.lblMinAmountTeller = new System.Windows.Forms.Label();
            this.tbMaxAmountTeller = new System.Windows.Forms.TextBox();
            this.tbMinAmountTeller = new System.Windows.Forms.TextBox();
            this.tabctrlAddTeller.SuspendLayout();
            this.tabBasicTeller.SuspendLayout();
            this.tabAdvancedTeller.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabctrlAddTeller
            // 
            resources.ApplyResources(this.tabctrlAddTeller, "tabctrlAddTeller");
            this.tabctrlAddTeller.Controls.Add(this.tabBasicTeller);
            this.tabctrlAddTeller.Controls.Add(this.tabAdvancedTeller);
            this.tabctrlAddTeller.Name = "tabctrlAddTeller";
            this.tabctrlAddTeller.SelectedIndex = 0;
            // 
            // tabBasicTeller
            // 
            resources.ApplyResources(this.tabBasicTeller, "tabBasicTeller");
            this.tabBasicTeller.Controls.Add(this.chxIsVault);
            this.tabBasicTeller.Controls.Add(this.cmbBranch);
            this.tabBasicTeller.Controls.Add(this.cmbUser);
            this.tabBasicTeller.Controls.Add(this.cmbCurrency);
            this.tabBasicTeller.Controls.Add(this.lblBranch);
            this.tabBasicTeller.Controls.Add(this.cmbAccount);
            this.tabBasicTeller.Controls.Add(this.lblUser);
            this.tabBasicTeller.Controls.Add(this.lblCurrency);
            this.tabBasicTeller.Controls.Add(this.lblAccount);
            this.tabBasicTeller.Controls.Add(this.lblDescription);
            this.tabBasicTeller.Controls.Add(this.tbDesc);
            this.tabBasicTeller.Controls.Add(this.lblName);
            this.tabBasicTeller.Controls.Add(this.tbName);
            this.tabBasicTeller.Name = "tabBasicTeller";
            // 
            // chxIsVault
            // 
            resources.ApplyResources(this.chxIsVault, "chxIsVault");
            this.chxIsVault.Name = "chxIsVault";
            this.chxIsVault.CheckedChanged += new System.EventHandler(this.chxIsVault_CheckedChanged);
            // 
            // cmbBranch
            // 
            resources.ApplyResources(this.cmbBranch, "cmbBranch");
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // cmbUser
            // 
            resources.ApplyResources(this.cmbUser, "cmbUser");
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // cmbCurrency
            // 
            resources.ApplyResources(this.cmbCurrency, "cmbCurrency");
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // lblBranch
            // 
            resources.ApplyResources(this.lblBranch, "lblBranch");
            this.lblBranch.Name = "lblBranch";
            // 
            // cmbAccount
            // 
            resources.ApplyResources(this.cmbAccount, "cmbAccount");
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.SelectedIndexChanged += new System.EventHandler(this.cmbAccount_SelectedIndexChanged);
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // lblCurrency
            // 
            resources.ApplyResources(this.lblCurrency, "lblCurrency");
            this.lblCurrency.Name = "lblCurrency";
            // 
            // lblAccount
            // 
            resources.ApplyResources(this.lblAccount, "lblAccount");
            this.lblAccount.Name = "lblAccount";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // tbDesc
            // 
            resources.ApplyResources(this.tbDesc, "tbDesc");
            this.tbDesc.Name = "tbDesc";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // tabAdvancedTeller
            // 
            resources.ApplyResources(this.tabAdvancedTeller, "tabAdvancedTeller");
            this.tabAdvancedTeller.Controls.Add(this.lblMaxAmountWithdrawal);
            this.tabAdvancedTeller.Controls.Add(this.lblMinAmountWithdrawal);
            this.tabAdvancedTeller.Controls.Add(this.label1);
            this.tabAdvancedTeller.Controls.Add(this.lblMaxAmountDeposit);
            this.tabAdvancedTeller.Controls.Add(this.tbMaxAmountWithdrawal);
            this.tabAdvancedTeller.Controls.Add(this.lblMinAmountDeposit);
            this.tabAdvancedTeller.Controls.Add(this.tbMinAmountWithdrawal);
            this.tabAdvancedTeller.Controls.Add(this.textBox1);
            this.tabAdvancedTeller.Controls.Add(this.tbMaxAmountDeposit);
            this.tabAdvancedTeller.Controls.Add(this.lblMaxAmountTeller);
            this.tabAdvancedTeller.Controls.Add(this.tbMinAmountDeposit);
            this.tabAdvancedTeller.Controls.Add(this.lblMinAmountTeller);
            this.tabAdvancedTeller.Controls.Add(this.tbMaxAmountTeller);
            this.tabAdvancedTeller.Controls.Add(this.tbMinAmountTeller);
            this.tabAdvancedTeller.Name = "tabAdvancedTeller";
            // 
            // lblMaxAmountWithdrawal
            // 
            resources.ApplyResources(this.lblMaxAmountWithdrawal, "lblMaxAmountWithdrawal");
            this.lblMaxAmountWithdrawal.Name = "lblMaxAmountWithdrawal";
            // 
            // lblMinAmountWithdrawal
            // 
            resources.ApplyResources(this.lblMinAmountWithdrawal, "lblMinAmountWithdrawal");
            this.lblMinAmountWithdrawal.Name = "lblMinAmountWithdrawal";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblMaxAmountDeposit
            // 
            resources.ApplyResources(this.lblMaxAmountDeposit, "lblMaxAmountDeposit");
            this.lblMaxAmountDeposit.Name = "lblMaxAmountDeposit";
            // 
            // tbMaxAmountWithdrawal
            // 
            resources.ApplyResources(this.tbMaxAmountWithdrawal, "tbMaxAmountWithdrawal");
            this.tbMaxAmountWithdrawal.Name = "tbMaxAmountWithdrawal";
            this.tbMaxAmountWithdrawal.TextChanged += new System.EventHandler(this.tbMaxAmountWithdrawal_TextChanged);
            // 
            // lblMinAmountDeposit
            // 
            resources.ApplyResources(this.lblMinAmountDeposit, "lblMinAmountDeposit");
            this.lblMinAmountDeposit.Name = "lblMinAmountDeposit";
            // 
            // tbMinAmountWithdrawal
            // 
            resources.ApplyResources(this.tbMinAmountWithdrawal, "tbMinAmountWithdrawal");
            this.tbMinAmountWithdrawal.Name = "tbMinAmountWithdrawal";
            this.tbMinAmountWithdrawal.TextChanged += new System.EventHandler(this.tbMinAmountWithdrawal_TextChanged);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.tbMinAmountDeposit_TextChanged);
            // 
            // tbMaxAmountDeposit
            // 
            resources.ApplyResources(this.tbMaxAmountDeposit, "tbMaxAmountDeposit");
            this.tbMaxAmountDeposit.Name = "tbMaxAmountDeposit";
            this.tbMaxAmountDeposit.TextChanged += new System.EventHandler(this.tbMaxAmountDeposit_TextChanged);
            // 
            // lblMaxAmountTeller
            // 
            resources.ApplyResources(this.lblMaxAmountTeller, "lblMaxAmountTeller");
            this.lblMaxAmountTeller.Name = "lblMaxAmountTeller";
            // 
            // tbMinAmountDeposit
            // 
            resources.ApplyResources(this.tbMinAmountDeposit, "tbMinAmountDeposit");
            this.tbMinAmountDeposit.Name = "tbMinAmountDeposit";
            this.tbMinAmountDeposit.TextChanged += new System.EventHandler(this.tbMinAmountDeposit_TextChanged);
            // 
            // lblMinAmountTeller
            // 
            resources.ApplyResources(this.lblMinAmountTeller, "lblMinAmountTeller");
            this.lblMinAmountTeller.Name = "lblMinAmountTeller";
            // 
            // tbMaxAmountTeller
            // 
            resources.ApplyResources(this.tbMaxAmountTeller, "tbMaxAmountTeller");
            this.tbMaxAmountTeller.Name = "tbMaxAmountTeller";
            this.tbMaxAmountTeller.TextChanged += new System.EventHandler(this.tbMaxAmountTeller_TextChanged);
            // 
            // tbMinAmountTeller
            // 
            resources.ApplyResources(this.tbMinAmountTeller, "tbMinAmountTeller");
            this.tbMinAmountTeller.Name = "tbMinAmountTeller";
            this.tbMinAmountTeller.TextChanged += new System.EventHandler(this.tbMinAmountTeller_TextChanged);
            // 
            // AddTellerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabctrlAddTeller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTellerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddTellerForm_FormClosing);
            this.Load += new System.EventHandler(this.AddTellerForm_Load);
            this.Controls.SetChildIndex(this.tabctrlAddTeller, 0);
            this.tabctrlAddTeller.ResumeLayout(false);
            this.tabBasicTeller.ResumeLayout(false);
            this.tabBasicTeller.PerformLayout();
            this.tabAdvancedTeller.ResumeLayout(false);
            this.tabAdvancedTeller.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabctrlAddTeller;
        private System.Windows.Forms.TabPage tabBasicTeller;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TabPage tabAdvancedTeller;
        private System.Windows.Forms.Label lblMinAmountWithdrawal;
        private System.Windows.Forms.Label lblMinAmountDeposit;
        private System.Windows.Forms.TextBox tbMinAmountWithdrawal;
        private System.Windows.Forms.Label lblMaxAmountTeller;
        private System.Windows.Forms.TextBox tbMinAmountDeposit;
        private System.Windows.Forms.Label lblMinAmountTeller;
        private System.Windows.Forms.TextBox tbMaxAmountTeller;
        private System.Windows.Forms.TextBox tbMinAmountTeller;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxAmountDeposit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbMaxAmountDeposit;
        private System.Windows.Forms.Label lblMaxAmountWithdrawal;
        private System.Windows.Forms.TextBox tbMaxAmountWithdrawal;
        private System.Windows.Forms.CheckBox chxIsVault;

    }
}