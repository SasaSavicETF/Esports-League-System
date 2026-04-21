namespace HCIProjekat1
{
    partial class AddSeasonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSeasonForm));
            lbEnterYear = new Label();
            tbEnterYear = new TextBox();
            lbEnterSplit = new Label();
            comboSplits = new ComboBox();
            btnSave = new Button();
            btnBack = new Button();
            SuspendLayout();
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
            // lbEnterSplit
            // 
            resources.ApplyResources(lbEnterSplit, "lbEnterSplit");
            lbEnterSplit.BackColor = Color.Transparent;
            lbEnterSplit.ForeColor = Color.White;
            lbEnterSplit.Name = "lbEnterSplit";
            // 
            // comboSplits
            // 
            comboSplits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSplits.FormattingEnabled = true;
            comboSplits.Items.AddRange(new object[] { resources.GetString("comboSplits.Items"), resources.GetString("comboSplits.Items1"), resources.GetString("comboSplits.Items2"), resources.GetString("comboSplits.Items3") });
            resources.ApplyResources(comboSplits, "comboSplits");
            comboSplits.Name = "comboSplits";
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
            // AddSeasonForm
            // 
            AcceptButton = btnSave;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(comboSplits);
            Controls.Add(lbEnterSplit);
            Controls.Add(tbEnterYear);
            Controls.Add(lbEnterYear);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSeasonForm";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbEnterYear;
        private TextBox tbEnterYear;
        private Label lbEnterSplit;
        private ComboBox comboSplits;
        private Button btnSave;
        private Button btnBack;
    }
}