namespace HCIProjekat1
{
    partial class AddPastTeamForPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPastTeamForPlayer));
            lbChooseSeason = new Label();
            comboSeasons = new ComboBox();
            lbChooseTeam = new Label();
            comboTeams = new ComboBox();
            lbChoosePosition = new Label();
            comboPositions = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lbChooseSeason
            // 
            resources.ApplyResources(lbChooseSeason, "lbChooseSeason");
            lbChooseSeason.BackColor = Color.Transparent;
            lbChooseSeason.ForeColor = Color.White;
            lbChooseSeason.Name = "lbChooseSeason";
            // 
            // comboSeasons
            // 
            comboSeasons.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSeasons.FormattingEnabled = true;
            resources.ApplyResources(comboSeasons, "comboSeasons");
            comboSeasons.Name = "comboSeasons";
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
            // lbChoosePosition
            // 
            resources.ApplyResources(lbChoosePosition, "lbChoosePosition");
            lbChoosePosition.BackColor = Color.Transparent;
            lbChoosePosition.ForeColor = Color.White;
            lbChoosePosition.Name = "lbChoosePosition";
            // 
            // comboPositions
            // 
            comboPositions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPositions.FormattingEnabled = true;
            comboPositions.Items.AddRange(new object[] { resources.GetString("comboPositions.Items"), resources.GetString("comboPositions.Items1"), resources.GetString("comboPositions.Items2"), resources.GetString("comboPositions.Items3"), resources.GetString("comboPositions.Items4") });
            resources.ApplyResources(comboPositions, "comboPositions");
            comboPositions.Name = "comboPositions";
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddPastTeamForPlayer
            // 
            AcceptButton = btnSave;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSave);
            Controls.Add(comboPositions);
            Controls.Add(lbChoosePosition);
            Controls.Add(comboTeams);
            Controls.Add(lbChooseTeam);
            Controls.Add(comboSeasons);
            Controls.Add(lbChooseSeason);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPastTeamForPlayer";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbChooseSeason;
        private ComboBox comboSeasons;
        private Label lbChooseTeam;
        private ComboBox comboTeams;
        private Label lbChoosePosition;
        private ComboBox comboPositions;
        private Button btnSave;
    }
}