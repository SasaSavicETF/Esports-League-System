namespace HCIProjekat1
{
    partial class NewMatchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMatchForm));
            lbTeam1 = new Label();
            lbTeam2 = new Label();
            comboTeam1 = new ComboBox();
            comboTeam2 = new ComboBox();
            lbSelectedTeam1 = new Label();
            lbSelectedTeam2 = new Label();
            panel1 = new Panel();
            pbTeam2 = new PictureBox();
            pbTeam1 = new PictureBox();
            lbDisplayDate = new Label();
            lbDisplayResult = new Label();
            btnSaveMatch = new Button();
            lbFormat = new Label();
            comboFormat = new ComboBox();
            lbLocation = new Label();
            tbLocation = new TextBox();
            lbDate = new Label();
            dtpMatchDate = new DateTimePicker();
            lbPhase = new Label();
            comboPhase = new ComboBox();
            lbAdditionalInfo = new Label();
            lbResult = new Label();
            tbResult = new TextBox();
            btnAddTeam = new Button();
            btnAddPhase = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbTeam2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTeam1).BeginInit();
            SuspendLayout();
            // 
            // lbTeam1
            // 
            resources.ApplyResources(lbTeam1, "lbTeam1");
            lbTeam1.BackColor = Color.Transparent;
            lbTeam1.ForeColor = Color.White;
            lbTeam1.Name = "lbTeam1";
            // 
            // lbTeam2
            // 
            resources.ApplyResources(lbTeam2, "lbTeam2");
            lbTeam2.BackColor = Color.Transparent;
            lbTeam2.ForeColor = Color.White;
            lbTeam2.Name = "lbTeam2";
            // 
            // comboTeam1
            // 
            comboTeam1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTeam1.FormattingEnabled = true;
            resources.ApplyResources(comboTeam1, "comboTeam1");
            comboTeam1.Name = "comboTeam1";
            comboTeam1.SelectedIndexChanged += comboTeam1_SelectedIndexChanged;
            // 
            // comboTeam2
            // 
            comboTeam2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTeam2.FormattingEnabled = true;
            resources.ApplyResources(comboTeam2, "comboTeam2");
            comboTeam2.Name = "comboTeam2";
            comboTeam2.SelectedIndexChanged += comboTeam2_SelectedIndexChanged;
            // 
            // lbSelectedTeam1
            // 
            resources.ApplyResources(lbSelectedTeam1, "lbSelectedTeam1");
            lbSelectedTeam1.ForeColor = Color.White;
            lbSelectedTeam1.Name = "lbSelectedTeam1";
            // 
            // lbSelectedTeam2
            // 
            resources.ApplyResources(lbSelectedTeam2, "lbSelectedTeam2");
            lbSelectedTeam2.ForeColor = Color.White;
            lbSelectedTeam2.Name = "lbSelectedTeam2";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowText;
            panel1.Controls.Add(lbSelectedTeam1);
            panel1.Controls.Add(lbSelectedTeam2);
            panel1.Controls.Add(pbTeam2);
            panel1.Controls.Add(pbTeam1);
            panel1.Controls.Add(lbDisplayDate);
            panel1.Controls.Add(lbDisplayResult);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // pbTeam2
            // 
            pbTeam2.BackColor = Color.Transparent;
            resources.ApplyResources(pbTeam2, "pbTeam2");
            pbTeam2.Name = "pbTeam2";
            pbTeam2.TabStop = false;
            // 
            // pbTeam1
            // 
            pbTeam1.BackColor = Color.Transparent;
            resources.ApplyResources(pbTeam1, "pbTeam1");
            pbTeam1.Name = "pbTeam1";
            pbTeam1.TabStop = false;
            // 
            // lbDisplayDate
            // 
            resources.ApplyResources(lbDisplayDate, "lbDisplayDate");
            lbDisplayDate.ForeColor = Color.Black;
            lbDisplayDate.Name = "lbDisplayDate";
            // 
            // lbDisplayResult
            // 
            resources.ApplyResources(lbDisplayResult, "lbDisplayResult");
            lbDisplayResult.ForeColor = Color.White;
            lbDisplayResult.Name = "lbDisplayResult";
            // 
            // btnSaveMatch
            // 
            resources.ApplyResources(btnSaveMatch, "btnSaveMatch");
            btnSaveMatch.Name = "btnSaveMatch";
            btnSaveMatch.UseVisualStyleBackColor = true;
            btnSaveMatch.Click += btnSaveMatch_Click;
            // 
            // lbFormat
            // 
            resources.ApplyResources(lbFormat, "lbFormat");
            lbFormat.BackColor = Color.Transparent;
            lbFormat.ForeColor = Color.White;
            lbFormat.Name = "lbFormat";
            // 
            // comboFormat
            // 
            comboFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboFormat, "comboFormat");
            comboFormat.FormattingEnabled = true;
            comboFormat.Items.AddRange(new object[] { resources.GetString("comboFormat.Items"), resources.GetString("comboFormat.Items1"), resources.GetString("comboFormat.Items2") });
            comboFormat.Name = "comboFormat";
            // 
            // lbLocation
            // 
            resources.ApplyResources(lbLocation, "lbLocation");
            lbLocation.BackColor = Color.Transparent;
            lbLocation.ForeColor = Color.White;
            lbLocation.Name = "lbLocation";
            // 
            // tbLocation
            // 
            resources.ApplyResources(tbLocation, "tbLocation");
            tbLocation.Name = "tbLocation";
            // 
            // lbDate
            // 
            resources.ApplyResources(lbDate, "lbDate");
            lbDate.BackColor = Color.Transparent;
            lbDate.ForeColor = Color.White;
            lbDate.Name = "lbDate";
            // 
            // dtpMatchDate
            // 
            resources.ApplyResources(dtpMatchDate, "dtpMatchDate");
            dtpMatchDate.Format = DateTimePickerFormat.Custom;
            dtpMatchDate.Name = "dtpMatchDate";
            dtpMatchDate.ValueChanged += dtpMatchDate_ValueChanged;
            // 
            // lbPhase
            // 
            resources.ApplyResources(lbPhase, "lbPhase");
            lbPhase.BackColor = Color.Transparent;
            lbPhase.ForeColor = Color.White;
            lbPhase.Name = "lbPhase";
            // 
            // comboPhase
            // 
            comboPhase.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboPhase, "comboPhase");
            comboPhase.FormattingEnabled = true;
            comboPhase.Name = "comboPhase";
            // 
            // lbAdditionalInfo
            // 
            resources.ApplyResources(lbAdditionalInfo, "lbAdditionalInfo");
            lbAdditionalInfo.BackColor = Color.Transparent;
            lbAdditionalInfo.ForeColor = Color.White;
            lbAdditionalInfo.Name = "lbAdditionalInfo";
            // 
            // lbResult
            // 
            resources.ApplyResources(lbResult, "lbResult");
            lbResult.BackColor = Color.Transparent;
            lbResult.ForeColor = Color.White;
            lbResult.Name = "lbResult";
            // 
            // tbResult
            // 
            resources.ApplyResources(tbResult, "tbResult");
            tbResult.Name = "tbResult";
            tbResult.TextChanged += tbResult_TextChanged;
            // 
            // btnAddTeam
            // 
            btnAddTeam.BackColor = Color.Transparent;
            btnAddTeam.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddTeam.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnAddTeam, "btnAddTeam");
            btnAddTeam.ForeColor = Color.White;
            btnAddTeam.Image = Properties.Resources.icons8_add_16_White1;
            btnAddTeam.Name = "btnAddTeam";
            btnAddTeam.UseVisualStyleBackColor = false;
            btnAddTeam.Click += btnAddTeam_Click;
            // 
            // btnAddPhase
            // 
            btnAddPhase.BackColor = Color.Transparent;
            btnAddPhase.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddPhase.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnAddPhase, "btnAddPhase");
            btnAddPhase.ForeColor = Color.White;
            btnAddPhase.Image = Properties.Resources.icons8_add_16_White1;
            btnAddPhase.Name = "btnAddPhase";
            btnAddPhase.UseVisualStyleBackColor = false;
            btnAddPhase.Click += btnAddPhase_Click;
            // 
            // NewMatchForm
            // 
            AcceptButton = btnSaveMatch;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddPhase);
            Controls.Add(btnAddTeam);
            Controls.Add(tbResult);
            Controls.Add(lbResult);
            Controls.Add(lbAdditionalInfo);
            Controls.Add(comboPhase);
            Controls.Add(lbPhase);
            Controls.Add(dtpMatchDate);
            Controls.Add(lbDate);
            Controls.Add(tbLocation);
            Controls.Add(lbLocation);
            Controls.Add(comboFormat);
            Controls.Add(lbFormat);
            Controls.Add(btnSaveMatch);
            Controls.Add(panel1);
            Controls.Add(comboTeam2);
            Controls.Add(comboTeam1);
            Controls.Add(lbTeam2);
            Controls.Add(lbTeam1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewMatchForm";
            ShowInTaskbar = false;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbTeam2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTeam1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTeam1;
        private Label lbTeam2;
        private ComboBox comboTeam1;
        private ComboBox comboTeam2;
        private Label lbSelectedTeam1;
        private Label lbSelectedTeam2;
        private Panel panel1;
        private Label lbDisplayResult;
        private Label lbDisplayDate;
        private PictureBox pbTeam1;
        private PictureBox pbTeam2;
        private Button btnSaveMatch;
        private Label lbFormat;
        private ComboBox comboFormat;
        private Label lbLocation;
        private TextBox tbLocation;
        private Label lbDate;
        private DateTimePicker dtpMatchDate;
        private Label lbPhase;
        private ComboBox comboPhase;
        private Label lbAdditionalInfo;
        private Label lbResult;
        private TextBox tbResult;
        private Button btnAddTeam;
        private Button btnAddPhase;
    }
}