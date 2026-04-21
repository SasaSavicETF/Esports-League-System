namespace HCIProjekat1
{
    partial class AddPlayerToTheTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPlayerToTheTeamForm));
            lbTeamName = new Label();
            lbChoosePlayer = new Label();
            comboFreePlayers = new ComboBox();
            lbEnterPosition = new Label();
            comboPositions = new ComboBox();
            btnSave = new Button();
            lbAnotherPlayer = new Label();
            btnAddNewPlayer = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lbTeamName
            // 
            resources.ApplyResources(lbTeamName, "lbTeamName");
            lbTeamName.BackColor = Color.Transparent;
            lbTeamName.ForeColor = Color.White;
            lbTeamName.Name = "lbTeamName";
            // 
            // lbChoosePlayer
            // 
            resources.ApplyResources(lbChoosePlayer, "lbChoosePlayer");
            lbChoosePlayer.BackColor = Color.Transparent;
            lbChoosePlayer.ForeColor = Color.White;
            lbChoosePlayer.Name = "lbChoosePlayer";
            // 
            // comboFreePlayers
            // 
            comboFreePlayers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFreePlayers.FormattingEnabled = true;
            resources.ApplyResources(comboFreePlayers, "comboFreePlayers");
            comboFreePlayers.Name = "comboFreePlayers";
            // 
            // lbEnterPosition
            // 
            resources.ApplyResources(lbEnterPosition, "lbEnterPosition");
            lbEnterPosition.BackColor = Color.Transparent;
            lbEnterPosition.ForeColor = Color.White;
            lbEnterPosition.Name = "lbEnterPosition";
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
            // lbAnotherPlayer
            // 
            resources.ApplyResources(lbAnotherPlayer, "lbAnotherPlayer");
            lbAnotherPlayer.BackColor = Color.Transparent;
            lbAnotherPlayer.ForeColor = Color.White;
            lbAnotherPlayer.Name = "lbAnotherPlayer";
            // 
            // btnAddNewPlayer
            // 
            btnAddNewPlayer.BackColor = Color.Transparent;
            btnAddNewPlayer.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddNewPlayer.FlatAppearance.BorderSize = 0;
            btnAddNewPlayer.FlatAppearance.MouseOverBackColor = Color.Transparent;
            resources.ApplyResources(btnAddNewPlayer, "btnAddNewPlayer");
            btnAddNewPlayer.Image = Properties.Resources.icons8_add_16_White1;
            btnAddNewPlayer.Name = "btnAddNewPlayer";
            btnAddNewPlayer.UseVisualStyleBackColor = false;
            btnAddNewPlayer.Click += btnAddNewPlayer_Click;
            // 
            // btnBack
            // 
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Name = "btnBack";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // AddPlayerToTheTeamForm
            // 
            AcceptButton = btnSave;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(btnAddNewPlayer);
            Controls.Add(lbAnotherPlayer);
            Controls.Add(btnSave);
            Controls.Add(comboPositions);
            Controls.Add(lbEnterPosition);
            Controls.Add(comboFreePlayers);
            Controls.Add(lbChoosePlayer);
            Controls.Add(lbTeamName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPlayerToTheTeamForm";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTeamName;
        private Label lbChoosePlayer;
        private ComboBox comboFreePlayers;
        private Label lbEnterPosition;
        private ComboBox comboPositions;
        private Button btnSave;
        private Label lbAnotherPlayer;
        private Button btnAddNewPlayer;
        private Button btnBack;
    }
}