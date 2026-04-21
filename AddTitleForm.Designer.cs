namespace HCIProjekat1
{
    partial class AddTitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTitleForm));
            lbTeamName = new Label();
            lbEnterYear = new Label();
            tbEnterYear = new TextBox();
            lbEnterTitleName = new Label();
            tbTitleName = new TextBox();
            btnSave = new Button();
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
            // lbEnterYear
            // 
            resources.ApplyResources(lbEnterYear, "lbEnterYear");
            lbEnterYear.BackColor = Color.Transparent;
            lbEnterYear.ForeColor = Color.White;
            lbEnterYear.Name = "lbEnterYear";
            // 
            // tbEnterYear
            // 
            resources.ApplyResources(tbEnterYear, "tbEnterYear");
            tbEnterYear.Name = "tbEnterYear";
            // 
            // lbEnterTitleName
            // 
            resources.ApplyResources(lbEnterTitleName, "lbEnterTitleName");
            lbEnterTitleName.BackColor = Color.Transparent;
            lbEnterTitleName.ForeColor = Color.White;
            lbEnterTitleName.Name = "lbEnterTitleName";
            // 
            // tbTitleName
            // 
            resources.ApplyResources(tbTitleName, "tbTitleName");
            tbTitleName.Name = "tbTitleName";
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Name = "btnBack";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // AddTitleForm
            // 
            AcceptButton = btnSave;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(tbTitleName);
            Controls.Add(lbEnterTitleName);
            Controls.Add(tbEnterYear);
            Controls.Add(lbEnterYear);
            Controls.Add(lbTeamName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTitleForm";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTeamName;
        private Label lbEnterYear;
        private TextBox tbEnterYear;
        private Label lbEnterTitleName;
        private TextBox tbTitleName;
        private Button btnSave;
        private Button btnBack;
    }
}