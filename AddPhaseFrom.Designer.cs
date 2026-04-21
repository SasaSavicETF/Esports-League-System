namespace HCIProjekat1
{
    partial class AddPhaseFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhaseFrom));
            lbSeason = new Label();
            lbEnterPhaseName = new Label();
            tbPhaseName = new TextBox();
            lbEnterStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            label1 = new Label();
            dtpEndDate = new DateTimePicker();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lbSeason
            // 
            resources.ApplyResources(lbSeason, "lbSeason");
            lbSeason.BackColor = Color.Transparent;
            lbSeason.ForeColor = Color.White;
            lbSeason.Name = "lbSeason";
            // 
            // lbEnterPhaseName
            // 
            resources.ApplyResources(lbEnterPhaseName, "lbEnterPhaseName");
            lbEnterPhaseName.BackColor = Color.Transparent;
            lbEnterPhaseName.ForeColor = Color.White;
            lbEnterPhaseName.Name = "lbEnterPhaseName";
            // 
            // tbPhaseName
            // 
            resources.ApplyResources(tbPhaseName, "tbPhaseName");
            tbPhaseName.Name = "tbPhaseName";
            tbPhaseName.TextChanged += tbPhaseName_TextChanged;
            // 
            // lbEnterStartDate
            // 
            resources.ApplyResources(lbEnterStartDate, "lbEnterStartDate");
            lbEnterStartDate.BackColor = Color.Transparent;
            lbEnterStartDate.ForeColor = Color.White;
            lbEnterStartDate.Name = "lbEnterStartDate";
            // 
            // dtpStartDate
            // 
            resources.ApplyResources(dtpStartDate, "dtpStartDate");
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Name = "dtpStartDate";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // dtpEndDate
            // 
            resources.ApplyResources(dtpEndDate, "dtpEndDate");
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Name = "dtpEndDate";
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddPhaseFrom
            // 
            AcceptButton = btnSave;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSave);
            Controls.Add(dtpEndDate);
            Controls.Add(label1);
            Controls.Add(dtpStartDate);
            Controls.Add(lbEnterStartDate);
            Controls.Add(tbPhaseName);
            Controls.Add(lbEnterPhaseName);
            Controls.Add(lbSeason);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPhaseFrom";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbSeason;
        private Label lbEnterPhaseName;
        private TextBox tbPhaseName;
        private Label lbEnterStartDate;
        private DateTimePicker dtpStartDate;
        private Label label1;
        private DateTimePicker dtpEndDate;
        private Button btnSave;
    }
}