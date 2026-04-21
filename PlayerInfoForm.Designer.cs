namespace HCIProjekat1
{
    partial class PlayerInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInfoForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lbPlayerNameDisplay = new Label();
            lbFirstName = new Label();
            lbLastName = new Label();
            lbDateOfBirth = new Label();
            lbPosition = new Label();
            lbInGameId = new Label();
            btnSave = new Button();
            tbInGameId = new TextBox();
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            comboPositions = new ComboBox();
            dgvPastTeams = new DataGridView();
            colSeason = new DataGridViewTextBoxColumn();
            colTeamName = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            cmsPastTeams = new ContextMenuStrip(components);
            cmsPastTeamsEdit = new ToolStripMenuItem();
            cmsPastTeamsDelete = new ToolStripMenuItem();
            btnAddPastTeam = new Button();
            btnUpdatePastTeam = new Button();
            btnDeletePastTeam = new Button();
            lbCountry = new Label();
            tbCountry = new TextBox();
            btnSavePlayer = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPastTeams).BeginInit();
            cmsPastTeams.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(lbPlayerNameDisplay);
            panel1.Name = "panel1";
            // 
            // lbPlayerNameDisplay
            // 
            resources.ApplyResources(lbPlayerNameDisplay, "lbPlayerNameDisplay");
            lbPlayerNameDisplay.BackColor = Color.Transparent;
            lbPlayerNameDisplay.ForeColor = Color.White;
            lbPlayerNameDisplay.Name = "lbPlayerNameDisplay";
            // 
            // lbFirstName
            // 
            resources.ApplyResources(lbFirstName, "lbFirstName");
            lbFirstName.BackColor = Color.Transparent;
            lbFirstName.ForeColor = Color.White;
            lbFirstName.Name = "lbFirstName";
            // 
            // lbLastName
            // 
            resources.ApplyResources(lbLastName, "lbLastName");
            lbLastName.BackColor = Color.Transparent;
            lbLastName.ForeColor = Color.White;
            lbLastName.Name = "lbLastName";
            // 
            // lbDateOfBirth
            // 
            resources.ApplyResources(lbDateOfBirth, "lbDateOfBirth");
            lbDateOfBirth.BackColor = Color.Transparent;
            lbDateOfBirth.ForeColor = Color.White;
            lbDateOfBirth.Name = "lbDateOfBirth";
            // 
            // lbPosition
            // 
            resources.ApplyResources(lbPosition, "lbPosition");
            lbPosition.BackColor = Color.Transparent;
            lbPosition.ForeColor = Color.White;
            lbPosition.Name = "lbPosition";
            // 
            // lbInGameId
            // 
            resources.ApplyResources(lbInGameId, "lbInGameId");
            lbInGameId.BackColor = Color.Transparent;
            lbInGameId.ForeColor = Color.White;
            lbInGameId.Name = "lbInGameId";
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tbInGameId
            // 
            resources.ApplyResources(tbInGameId, "tbInGameId");
            tbInGameId.Name = "tbInGameId";
            // 
            // tbFirstName
            // 
            resources.ApplyResources(tbFirstName, "tbFirstName");
            tbFirstName.Name = "tbFirstName";
            // 
            // tbLastName
            // 
            resources.ApplyResources(tbLastName, "tbLastName");
            tbLastName.Name = "tbLastName";
            // 
            // dtpDateOfBirth
            // 
            resources.ApplyResources(dtpDateOfBirth, "dtpDateOfBirth");
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            // 
            // comboPositions
            // 
            resources.ApplyResources(comboPositions, "comboPositions");
            comboPositions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPositions.FormattingEnabled = true;
            comboPositions.Items.AddRange(new object[] { resources.GetString("comboPositions.Items"), resources.GetString("comboPositions.Items1"), resources.GetString("comboPositions.Items2"), resources.GetString("comboPositions.Items3"), resources.GetString("comboPositions.Items4") });
            comboPositions.Name = "comboPositions";
            // 
            // dgvPastTeams
            // 
            resources.ApplyResources(dgvPastTeams, "dgvPastTeams");
            dgvPastTeams.AllowUserToAddRows = false;
            dgvPastTeams.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPastTeams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPastTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPastTeams.Columns.AddRange(new DataGridViewColumn[] { colSeason, colTeamName, colPosition });
            dgvPastTeams.ContextMenuStrip = cmsPastTeams;
            dgvPastTeams.MultiSelect = false;
            dgvPastTeams.Name = "dgvPastTeams";
            dgvPastTeams.RowHeadersVisible = false;
            dgvPastTeams.RowTemplate.Height = 25;
            dgvPastTeams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPastTeams.MouseDown += dgvPastTeams_MouseDown;
            // 
            // colSeason
            // 
            resources.ApplyResources(colSeason, "colSeason");
            colSeason.Name = "colSeason";
            // 
            // colTeamName
            // 
            resources.ApplyResources(colTeamName, "colTeamName");
            colTeamName.Name = "colTeamName";
            // 
            // colPosition
            // 
            resources.ApplyResources(colPosition, "colPosition");
            colPosition.Name = "colPosition";
            // 
            // cmsPastTeams
            // 
            resources.ApplyResources(cmsPastTeams, "cmsPastTeams");
            cmsPastTeams.Items.AddRange(new ToolStripItem[] { cmsPastTeamsEdit, cmsPastTeamsDelete });
            cmsPastTeams.Name = "cmsPastTeams";
            // 
            // cmsPastTeamsEdit
            // 
            resources.ApplyResources(cmsPastTeamsEdit, "cmsPastTeamsEdit");
            cmsPastTeamsEdit.Image = Properties.Resources.icons8_edit_24;
            cmsPastTeamsEdit.Name = "cmsPastTeamsEdit";
            cmsPastTeamsEdit.Click += cmsPastTeamsEdit_Click;
            // 
            // cmsPastTeamsDelete
            // 
            resources.ApplyResources(cmsPastTeamsDelete, "cmsPastTeamsDelete");
            cmsPastTeamsDelete.Image = Properties.Resources.icons8_delete_24;
            cmsPastTeamsDelete.Name = "cmsPastTeamsDelete";
            // 
            // btnAddPastTeam
            // 
            resources.ApplyResources(btnAddPastTeam, "btnAddPastTeam");
            btnAddPastTeam.BackColor = Color.Transparent;
            btnAddPastTeam.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddPastTeam.FlatAppearance.BorderSize = 0;
            btnAddPastTeam.Image = Properties.Resources.icons8_add_16_White1;
            btnAddPastTeam.Name = "btnAddPastTeam";
            btnAddPastTeam.UseVisualStyleBackColor = false;
            btnAddPastTeam.Click += btnAddPastTeam_Click;
            // 
            // btnUpdatePastTeam
            // 
            resources.ApplyResources(btnUpdatePastTeam, "btnUpdatePastTeam");
            btnUpdatePastTeam.BackColor = Color.Transparent;
            btnUpdatePastTeam.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnUpdatePastTeam.FlatAppearance.BorderSize = 0;
            btnUpdatePastTeam.Image = Properties.Resources.icons8_update_16_White;
            btnUpdatePastTeam.Name = "btnUpdatePastTeam";
            btnUpdatePastTeam.UseVisualStyleBackColor = false;
            btnUpdatePastTeam.Click += btnUpdatePastTeam_Click;
            // 
            // btnDeletePastTeam
            // 
            resources.ApplyResources(btnDeletePastTeam, "btnDeletePastTeam");
            btnDeletePastTeam.BackColor = Color.Transparent;
            btnDeletePastTeam.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnDeletePastTeam.FlatAppearance.BorderSize = 0;
            btnDeletePastTeam.Image = Properties.Resources.icons8_delete_16_White1;
            btnDeletePastTeam.Name = "btnDeletePastTeam";
            btnDeletePastTeam.UseVisualStyleBackColor = false;
            btnDeletePastTeam.Click += btnDeletePastTeam_Click;
            // 
            // lbCountry
            // 
            resources.ApplyResources(lbCountry, "lbCountry");
            lbCountry.BackColor = Color.Transparent;
            lbCountry.ForeColor = Color.White;
            lbCountry.Name = "lbCountry";
            // 
            // tbCountry
            // 
            resources.ApplyResources(tbCountry, "tbCountry");
            tbCountry.Name = "tbCountry";
            // 
            // btnSavePlayer
            // 
            resources.ApplyResources(btnSavePlayer, "btnSavePlayer");
            btnSavePlayer.Name = "btnSavePlayer";
            btnSavePlayer.UseVisualStyleBackColor = true;
            btnSavePlayer.Click += btnSavePlayer_Click;
            // 
            // PlayerInfoForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSavePlayer);
            Controls.Add(tbCountry);
            Controls.Add(lbCountry);
            Controls.Add(btnDeletePastTeam);
            Controls.Add(btnUpdatePastTeam);
            Controls.Add(btnAddPastTeam);
            Controls.Add(dgvPastTeams);
            Controls.Add(comboPositions);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
            Controls.Add(tbInGameId);
            Controls.Add(btnSave);
            Controls.Add(lbInGameId);
            Controls.Add(lbPosition);
            Controls.Add(lbDateOfBirth);
            Controls.Add(lbLastName);
            Controls.Add(lbFirstName);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlayerInfoForm";
            ShowInTaskbar = false;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPastTeams).EndInit();
            cmsPastTeams.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbPlayerNameDisplay;
        private Label lbFirstName;
        private Label lbLastName;
        private Label lbDateOfBirth;
        private Label lbPosition;
        private Label lbInGameId;
        private Button btnSave;
        private TextBox tbInGameId;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private DateTimePicker dtpDateOfBirth;
        private ComboBox comboPositions;
        private DataGridView dgvPastTeams;
        private Button btnAddPastTeam;
        private Button btnUpdatePastTeam;
        private Button btnDeletePastTeam;
        private ContextMenuStrip cmsPastTeams;
        private ToolStripMenuItem cmsPastTeamsEdit;
        private ToolStripMenuItem cmsPastTeamsDelete;
        private Label lbCountry;
        private TextBox tbCountry;
        private Button btnSavePlayer;
        private DataGridViewTextBoxColumn colSeason;
        private DataGridViewTextBoxColumn colTeamName;
        private DataGridViewTextBoxColumn colPosition;
    }
}