namespace HCIProjekat1
{
    partial class AdminForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            TabControl = new TabControl();
            tabRequests = new TabPage();
            btnDeny = new Button();
            btnAccept = new Button();
            rtbInfo = new RichTextBox();
            lbPendingRequests = new Label();
            dgvRequests = new DataGridView();
            colUsername = new DataGridViewTextBoxColumn();
            cmsRequests = new ContextMenuStrip(components);
            tsmAccept = new ToolStripMenuItem();
            tsmDeny = new ToolStripMenuItem();
            colDateOfRequest = new DataGridViewTextBoxColumn();
            colInfo = new DataGridViewButtonColumn();
            tabAccounts = new TabPage();
            btnDeleteAccount = new Button();
            dummybtnSearch = new Button();
            tbSearchAccounts = new TextBox();
            dgvAccounts = new DataGridView();
            colAccountUsername = new DataGridViewTextBoxColumn();
            cmsAccounts = new ContextMenuStrip(components);
            tsmDelete = new ToolStripMenuItem();
            colDateOfCreation = new DataGridViewTextBoxColumn();
            colAccDateOfRequest = new DataGridViewTextBoxColumn();
            lbActiveAccounts = new Label();
            StatusPanel = new Panel();
            lbDateTime = new Label();
            btnLogOut = new Button();
            timer = new System.Windows.Forms.Timer(components);
            msStyles = new MenuStrip();
            tsmiStylesEdit = new ToolStripMenuItem();
            tsmiLanguage = new ToolStripMenuItem();
            tsmiLanguageSerbian = new ToolStripMenuItem();
            tsmiLanguageEnglish = new ToolStripMenuItem();
            tsmiStylesStyle = new ToolStripMenuItem();
            tsmiStyleSpring = new ToolStripMenuItem();
            tsmiStyleSummer = new ToolStripMenuItem();
            tsmiStylesDark = new ToolStripMenuItem();
            tsmiStylesTime = new ToolStripMenuItem();
            tsmiFormat = new ToolStripMenuItem();
            tsmiFormat12h = new ToolStripMenuItem();
            tsmiFormat24h = new ToolStripMenuItem();
            TabControl.SuspendLayout();
            tabRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            cmsRequests.SuspendLayout();
            tabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            cmsAccounts.SuspendLayout();
            StatusPanel.SuspendLayout();
            msStyles.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(tabRequests);
            TabControl.Controls.Add(tabAccounts);
            resources.ApplyResources(TabControl, "TabControl");
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // tabRequests
            // 
            tabRequests.Controls.Add(btnDeny);
            tabRequests.Controls.Add(btnAccept);
            tabRequests.Controls.Add(rtbInfo);
            tabRequests.Controls.Add(lbPendingRequests);
            tabRequests.Controls.Add(dgvRequests);
            resources.ApplyResources(tabRequests, "tabRequests");
            tabRequests.Name = "tabRequests";
            tabRequests.UseVisualStyleBackColor = true;
            // 
            // btnDeny
            // 
            resources.ApplyResources(btnDeny, "btnDeny");
            btnDeny.Name = "btnDeny";
            btnDeny.UseVisualStyleBackColor = true;
            btnDeny.Click += btnDeny_Click;
            // 
            // btnAccept
            // 
            resources.ApplyResources(btnAccept, "btnAccept");
            btnAccept.Name = "btnAccept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // rtbInfo
            // 
            rtbInfo.BackColor = Color.WhiteSmoke;
            rtbInfo.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(rtbInfo, "rtbInfo");
            rtbInfo.Name = "rtbInfo";
            rtbInfo.ReadOnly = true;
            // 
            // lbPendingRequests
            // 
            resources.ApplyResources(lbPendingRequests, "lbPendingRequests");
            lbPendingRequests.ForeColor = Color.White;
            lbPendingRequests.Name = "lbPendingRequests";
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Columns.AddRange(new DataGridViewColumn[] { colUsername, colDateOfRequest, colInfo });
            resources.ApplyResources(dgvRequests, "dgvRequests");
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowTemplate.Height = 25;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.CellContentClick += dgvRequests_CellContentClick;
            // 
            // colUsername
            // 
            colUsername.ContextMenuStrip = cmsRequests;
            resources.ApplyResources(colUsername, "colUsername");
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // cmsRequests
            // 
            cmsRequests.Items.AddRange(new ToolStripItem[] { tsmAccept, tsmDeny });
            cmsRequests.Name = "cmsRequests";
            resources.ApplyResources(cmsRequests, "cmsRequests");
            // 
            // tsmAccept
            // 
            tsmAccept.Image = Properties.Resources.icons8_accept_24__1_;
            tsmAccept.Name = "tsmAccept";
            resources.ApplyResources(tsmAccept, "tsmAccept");
            tsmAccept.Click += btnAccept_Click;
            // 
            // tsmDeny
            // 
            tsmDeny.Image = Properties.Resources.icons8_cancel_24;
            tsmDeny.Name = "tsmDeny";
            resources.ApplyResources(tsmDeny, "tsmDeny");
            tsmDeny.Click += btnDeny_Click;
            // 
            // colDateOfRequest
            // 
            colDateOfRequest.ContextMenuStrip = cmsRequests;
            resources.ApplyResources(colDateOfRequest, "colDateOfRequest");
            colDateOfRequest.Name = "colDateOfRequest";
            colDateOfRequest.ReadOnly = true;
            // 
            // colInfo
            // 
            colInfo.ContextMenuStrip = cmsRequests;
            resources.ApplyResources(colInfo, "colInfo");
            colInfo.Name = "colInfo";
            colInfo.ReadOnly = true;
            colInfo.Text = "Info";
            colInfo.UseColumnTextForButtonValue = true;
            // 
            // tabAccounts
            // 
            tabAccounts.Controls.Add(btnDeleteAccount);
            tabAccounts.Controls.Add(dummybtnSearch);
            tabAccounts.Controls.Add(tbSearchAccounts);
            tabAccounts.Controls.Add(dgvAccounts);
            tabAccounts.Controls.Add(lbActiveAccounts);
            resources.ApplyResources(tabAccounts, "tabAccounts");
            tabAccounts.Name = "tabAccounts";
            tabAccounts.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAccount
            // 
            resources.ApplyResources(btnDeleteAccount, "btnDeleteAccount");
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.UseVisualStyleBackColor = true;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // dummybtnSearch
            // 
            resources.ApplyResources(dummybtnSearch, "dummybtnSearch");
            dummybtnSearch.FlatAppearance.BorderColor = Color.WhiteSmoke;
            dummybtnSearch.FlatAppearance.BorderSize = 0;
            dummybtnSearch.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            dummybtnSearch.Image = Properties.Resources.icons8_search_24__1_;
            dummybtnSearch.Name = "dummybtnSearch";
            dummybtnSearch.UseVisualStyleBackColor = true;
            // 
            // tbSearchAccounts
            // 
            resources.ApplyResources(tbSearchAccounts, "tbSearchAccounts");
            tbSearchAccounts.Name = "tbSearchAccounts";
            tbSearchAccounts.TextChanged += tbSearchAccounts_TextChanged;
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Bahnschrift Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Columns.AddRange(new DataGridViewColumn[] { colAccountUsername, colDateOfCreation, colAccDateOfRequest });
            resources.ApplyResources(dgvAccounts, "dgvAccounts");
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.RowTemplate.Height = 25;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // colAccountUsername
            // 
            colAccountUsername.ContextMenuStrip = cmsAccounts;
            resources.ApplyResources(colAccountUsername, "colAccountUsername");
            colAccountUsername.Name = "colAccountUsername";
            // 
            // cmsAccounts
            // 
            cmsAccounts.Items.AddRange(new ToolStripItem[] { tsmDelete });
            cmsAccounts.Name = "contextMenuStrip1";
            resources.ApplyResources(cmsAccounts, "cmsAccounts");
            // 
            // tsmDelete
            // 
            tsmDelete.Image = Properties.Resources.icons8_delete_24;
            tsmDelete.Name = "tsmDelete";
            resources.ApplyResources(tsmDelete, "tsmDelete");
            tsmDelete.Click += btnDeleteAccount_Click;
            // 
            // colDateOfCreation
            // 
            colDateOfCreation.ContextMenuStrip = cmsAccounts;
            resources.ApplyResources(colDateOfCreation, "colDateOfCreation");
            colDateOfCreation.Name = "colDateOfCreation";
            // 
            // colAccDateOfRequest
            // 
            colAccDateOfRequest.ContextMenuStrip = cmsAccounts;
            resources.ApplyResources(colAccDateOfRequest, "colAccDateOfRequest");
            colAccDateOfRequest.Name = "colAccDateOfRequest";
            // 
            // lbActiveAccounts
            // 
            resources.ApplyResources(lbActiveAccounts, "lbActiveAccounts");
            lbActiveAccounts.ForeColor = Color.White;
            lbActiveAccounts.Name = "lbActiveAccounts";
            // 
            // StatusPanel
            // 
            StatusPanel.Controls.Add(lbDateTime);
            StatusPanel.Controls.Add(btnLogOut);
            resources.ApplyResources(StatusPanel, "StatusPanel");
            StatusPanel.Name = "StatusPanel";
            // 
            // lbDateTime
            // 
            resources.ApplyResources(lbDateTime, "lbDateTime");
            lbDateTime.Name = "lbDateTime";
            // 
            // btnLogOut
            // 
            resources.ApplyResources(btnLogOut, "btnLogOut");
            btnLogOut.Name = "btnLogOut";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // msStyles
            // 
            msStyles.BackColor = SystemColors.ActiveBorder;
            msStyles.Items.AddRange(new ToolStripItem[] { tsmiStylesEdit, tsmiStylesTime });
            resources.ApplyResources(msStyles, "msStyles");
            msStyles.Name = "msStyles";
            // 
            // tsmiStylesEdit
            // 
            tsmiStylesEdit.DropDownItems.AddRange(new ToolStripItem[] { tsmiLanguage, tsmiStylesStyle });
            tsmiStylesEdit.Name = "tsmiStylesEdit";
            resources.ApplyResources(tsmiStylesEdit, "tsmiStylesEdit");
            // 
            // tsmiLanguage
            // 
            tsmiLanguage.DropDownItems.AddRange(new ToolStripItem[] { tsmiLanguageSerbian, tsmiLanguageEnglish });
            tsmiLanguage.Image = Properties.Resources.icons8_language_24;
            tsmiLanguage.Name = "tsmiLanguage";
            resources.ApplyResources(tsmiLanguage, "tsmiLanguage");
            // 
            // tsmiLanguageSerbian
            // 
            tsmiLanguageSerbian.CheckOnClick = true;
            tsmiLanguageSerbian.Name = "tsmiLanguageSerbian";
            resources.ApplyResources(tsmiLanguageSerbian, "tsmiLanguageSerbian");
            tsmiLanguageSerbian.Click += tsmiLanguageSerbian_Click;
            // 
            // tsmiLanguageEnglish
            // 
            tsmiLanguageEnglish.CheckOnClick = true;
            tsmiLanguageEnglish.Name = "tsmiLanguageEnglish";
            resources.ApplyResources(tsmiLanguageEnglish, "tsmiLanguageEnglish");
            tsmiLanguageEnglish.Click += tsmiLanguageEnglish_Click;
            // 
            // tsmiStylesStyle
            // 
            tsmiStylesStyle.DropDownItems.AddRange(new ToolStripItem[] { tsmiStyleSpring, tsmiStyleSummer, tsmiStylesDark });
            tsmiStylesStyle.Image = Properties.Resources.icons8_theme_24;
            tsmiStylesStyle.Name = "tsmiStylesStyle";
            resources.ApplyResources(tsmiStylesStyle, "tsmiStylesStyle");
            // 
            // tsmiStyleSpring
            // 
            tsmiStyleSpring.CheckOnClick = true;
            tsmiStyleSpring.Image = Properties.Resources.icons8_leaf_24;
            tsmiStyleSpring.Name = "tsmiStyleSpring";
            resources.ApplyResources(tsmiStyleSpring, "tsmiStyleSpring");
            tsmiStyleSpring.Click += tsmiStyleSpring_Click;
            // 
            // tsmiStyleSummer
            // 
            tsmiStyleSummer.CheckOnClick = true;
            tsmiStyleSummer.Image = Properties.Resources.icons8_sun_24;
            tsmiStyleSummer.Name = "tsmiStyleSummer";
            resources.ApplyResources(tsmiStyleSummer, "tsmiStyleSummer");
            tsmiStyleSummer.Click += tsmiStyleSummer_Click;
            // 
            // tsmiStylesDark
            // 
            tsmiStylesDark.CheckOnClick = true;
            tsmiStylesDark.Image = Properties.Resources.icons8_dark_mode_24;
            tsmiStylesDark.Name = "tsmiStylesDark";
            resources.ApplyResources(tsmiStylesDark, "tsmiStylesDark");
            tsmiStylesDark.Click += tsmiStylesDark_Click;
            // 
            // tsmiStylesTime
            // 
            tsmiStylesTime.DropDownItems.AddRange(new ToolStripItem[] { tsmiFormat });
            tsmiStylesTime.Name = "tsmiStylesTime";
            resources.ApplyResources(tsmiStylesTime, "tsmiStylesTime");
            // 
            // tsmiFormat
            // 
            tsmiFormat.DropDownItems.AddRange(new ToolStripItem[] { tsmiFormat12h, tsmiFormat24h });
            tsmiFormat.Image = Properties.Resources.icons8_time_24;
            tsmiFormat.Name = "tsmiFormat";
            resources.ApplyResources(tsmiFormat, "tsmiFormat");
            // 
            // tsmiFormat12h
            // 
            tsmiFormat12h.CheckOnClick = true;
            tsmiFormat12h.Name = "tsmiFormat12h";
            resources.ApplyResources(tsmiFormat12h, "tsmiFormat12h");
            tsmiFormat12h.Click += tsmiFormat12h_Click;
            // 
            // tsmiFormat24h
            // 
            tsmiFormat24h.CheckOnClick = true;
            tsmiFormat24h.Name = "tsmiFormat24h";
            resources.ApplyResources(tsmiFormat24h, "tsmiFormat24h");
            tsmiFormat24h.Click += tsmiFormat24h_Click;
            // 
            // AdminForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(msStyles);
            Controls.Add(StatusPanel);
            Controls.Add(TabControl);
            MaximizeBox = false;
            Name = "AdminForm";
            TabControl.ResumeLayout(false);
            tabRequests.ResumeLayout(false);
            tabRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            cmsRequests.ResumeLayout(false);
            tabAccounts.ResumeLayout(false);
            tabAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            cmsAccounts.ResumeLayout(false);
            StatusPanel.ResumeLayout(false);
            StatusPanel.PerformLayout();
            msStyles.ResumeLayout(false);
            msStyles.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl TabControl;
        private TabPage tabRequests;
        private TabPage tabAccounts;
        private Label lbPendingRequests;
        private DataGridView dgvRequests;
        private RichTextBox rtbInfo;
        private Panel StatusPanel;
        private Button btnLogOut;
        private Button btnDeny;
        private Button btnAccept;
        private ContextMenuStrip cmsRequests;
        private ToolStripMenuItem tsmAccept;
        private ToolStripMenuItem tsmDeny;
        private Label lbActiveAccounts;
        private DataGridView dgvAccounts;
        private TextBox tbSearchAccounts;
        private Button dummybtnSearch;
        private Button btnDeleteAccount;
        private ContextMenuStrip cmsAccounts;
        private ToolStripMenuItem tsmDelete;
        private Label lbDateTime;
        private System.Windows.Forms.Timer timer;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colDateOfRequest;
        private DataGridViewButtonColumn colInfo;
        private DataGridViewTextBoxColumn colAccountUsername;
        private DataGridViewTextBoxColumn colDateOfCreation;
        private DataGridViewTextBoxColumn colAccDateOfRequest;
        private MenuStrip msStyles;
        private ToolStripMenuItem tsmiStylesEdit;
        private ToolStripMenuItem tsmiLanguage;
        private ToolStripMenuItem tsmiLanguageSerbian;
        private ToolStripMenuItem tsmiLanguageEnglish;
        private ToolStripMenuItem tsmiStylesStyle;
        private ToolStripMenuItem tsmiStyleSpring;
        private ToolStripMenuItem tsmiStyleSummer;
        private ToolStripMenuItem tsmiStylesDark;
        private ToolStripMenuItem tsmiStylesTime;
        private ToolStripMenuItem tsmiFormat;
        private ToolStripMenuItem tsmiFormat12h;
        private ToolStripMenuItem tsmiFormat24h;
    }
}