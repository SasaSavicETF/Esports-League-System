namespace HCIProjekat1
{
    partial class RegisterTeamForSeason
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterTeamForSeason));
            lbChooseTeam = new Label();
            comboTeams = new ComboBox();
            lbAddNewTeam = new Label();
            btnAddNewTeam = new Button();
            lbEnterTeamPlacement = new Label();
            tbEnterTeamPlacement = new TextBox();
            btnBack = new Button();
            btnSave = new Button();
            lbSeasonDisplay = new Label();
            SuspendLayout();
            // 
            // lbChooseTeam
            // 
            resources.ApplyResources(lbChooseTeam, "lbChooseTeam");
            lbChooseTeam.BackColor = Color.Transparent;
            lbChooseTeam.ForeColor = Color.White;
            lbChooseTeam.Name = "lbChooseTeam";
            // 
            // comboTeams
            // 
            comboTeams.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTeams.FormattingEnabled = true;
            resources.ApplyResources(comboTeams, "comboTeams");
            comboTeams.Name = "comboTeams";
            // 
            // lbAddNewTeam
            // 
            resources.ApplyResources(lbAddNewTeam, "lbAddNewTeam");
            lbAddNewTeam.BackColor = Color.Transparent;
            lbAddNewTeam.ForeColor = Color.White;
            lbAddNewTeam.Name = "lbAddNewTeam";
            // 
            // btnAddNewTeam
            // 
            btnAddNewTeam.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddNewTeam.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnAddNewTeam, "btnAddNewTeam");
            btnAddNewTeam.Image = Properties.Resources.icons8_add_16_White1;
            btnAddNewTeam.Name = "btnAddNewTeam";
            btnAddNewTeam.UseVisualStyleBackColor = true;
            btnAddNewTeam.Click += btnAddNewTeam_Click;
            // 
            // lbEnterTeamPlacement
            // 
            resources.ApplyResources(lbEnterTeamPlacement, "lbEnterTeamPlacement");
            lbEnterTeamPlacement.BackColor = Color.Transparent;
            lbEnterTeamPlacement.ForeColor = Color.White;
            lbEnterTeamPlacement.Name = "lbEnterTeamPlacement";
            // 
            // tbEnterTeamPlacement
            // 
            resources.ApplyResources(tbEnterTeamPlacement, "tbEnterTeamPlacement");
            tbEnterTeamPlacement.Name = "tbEnterTeamPlacement";
            // 
            // btnBack
            // 
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Name = "btnBack";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbSeasonDisplay
            // 
            resources.ApplyResources(lbSeasonDisplay, "lbSeasonDisplay");
            lbSeasonDisplay.BackColor = Color.Transparent;
            lbSeasonDisplay.ForeColor = Color.White;
            lbSeasonDisplay.Name = "lbSeasonDisplay";
            // 
            // RegisterTeamForSeason
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbSeasonDisplay);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Controls.Add(tbEnterTeamPlacement);
            Controls.Add(lbEnterTeamPlacement);
            Controls.Add(btnAddNewTeam);
            Controls.Add(lbAddNewTeam);
            Controls.Add(comboTeams);
            Controls.Add(lbChooseTeam);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterTeamForSeason";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbChooseTeam;
        private ComboBox comboTeams;
        private Label lbAddNewTeam;
        private Button btnAddNewTeam;
        private Label lbEnterTeamPlacement;
        private Label lbSeasonDisplay;
        private TextBox tbEnterTeamPlacement;
        private Button btnBack;
        private Button btnSave;
        private Label label1;
    }
}