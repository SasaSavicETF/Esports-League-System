namespace HCIProjekat1
{
    partial class AddTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTeamForm));
            panelPreview = new Panel();
            lbDisplayTeamName = new Label();
            pbDisplayTeamPicture = new PictureBox();
            lbTeamName = new Label();
            tbTeamName = new TextBox();
            lbYearOfEstablishment = new Label();
            tbYearOfEstablishment = new TextBox();
            lbCountry = new Label();
            tbCountry = new TextBox();
            lbPicture = new Label();
            panelPicture = new Panel();
            btnUploadPicture = new Button();
            btnChangePicture = new Button();
            btnCorrect = new Button();
            lbPictureUploaded = new Label();
            lbDragPictureHere = new Label();
            btnSave = new Button();
            btnBack = new Button();
            ofdUploadPicture = new OpenFileDialog();
            panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDisplayTeamPicture).BeginInit();
            panelPicture.SuspendLayout();
            SuspendLayout();
            // 
            // panelPreview
            // 
            panelPreview.BackColor = Color.Black;
            panelPreview.Controls.Add(lbDisplayTeamName);
            panelPreview.Controls.Add(pbDisplayTeamPicture);
            resources.ApplyResources(panelPreview, "panelPreview");
            panelPreview.Name = "panelPreview";
            // 
            // lbDisplayTeamName
            // 
            resources.ApplyResources(lbDisplayTeamName, "lbDisplayTeamName");
            lbDisplayTeamName.BackColor = Color.Transparent;
            lbDisplayTeamName.ForeColor = Color.White;
            lbDisplayTeamName.Name = "lbDisplayTeamName";
            // 
            // pbDisplayTeamPicture
            // 
            pbDisplayTeamPicture.BackColor = Color.Transparent;
            resources.ApplyResources(pbDisplayTeamPicture, "pbDisplayTeamPicture");
            pbDisplayTeamPicture.Name = "pbDisplayTeamPicture";
            pbDisplayTeamPicture.TabStop = false;
            // 
            // lbTeamName
            // 
            resources.ApplyResources(lbTeamName, "lbTeamName");
            lbTeamName.BackColor = Color.Transparent;
            lbTeamName.ForeColor = Color.White;
            lbTeamName.Name = "lbTeamName";
            // 
            // tbTeamName
            // 
            resources.ApplyResources(tbTeamName, "tbTeamName");
            tbTeamName.Name = "tbTeamName";
            tbTeamName.TextChanged += tbTeamName_TextChanged;
            // 
            // lbYearOfEstablishment
            // 
            resources.ApplyResources(lbYearOfEstablishment, "lbYearOfEstablishment");
            lbYearOfEstablishment.BackColor = Color.Transparent;
            lbYearOfEstablishment.ForeColor = Color.White;
            lbYearOfEstablishment.Name = "lbYearOfEstablishment";
            // 
            // tbYearOfEstablishment
            // 
            resources.ApplyResources(tbYearOfEstablishment, "tbYearOfEstablishment");
            tbYearOfEstablishment.Name = "tbYearOfEstablishment";
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
            // lbPicture
            // 
            resources.ApplyResources(lbPicture, "lbPicture");
            lbPicture.BackColor = Color.Transparent;
            lbPicture.ForeColor = Color.White;
            lbPicture.Name = "lbPicture";
            // 
            // panelPicture
            // 
            panelPicture.AllowDrop = true;
            panelPicture.BorderStyle = BorderStyle.FixedSingle;
            panelPicture.Controls.Add(btnUploadPicture);
            panelPicture.Controls.Add(btnChangePicture);
            panelPicture.Controls.Add(btnCorrect);
            panelPicture.Controls.Add(lbPictureUploaded);
            panelPicture.Controls.Add(lbDragPictureHere);
            resources.ApplyResources(panelPicture, "panelPicture");
            panelPicture.Name = "panelPicture";
            panelPicture.DragDrop += panelPicture_DragDrop;
            panelPicture.DragEnter += panelPicture_DragEnter;
            // 
            // btnUploadPicture
            // 
            resources.ApplyResources(btnUploadPicture, "btnUploadPicture");
            btnUploadPicture.Name = "btnUploadPicture";
            btnUploadPicture.UseVisualStyleBackColor = true;
            btnUploadPicture.Click += btnUploadPicture_Click;
            // 
            // btnChangePicture
            // 
            resources.ApplyResources(btnChangePicture, "btnChangePicture");
            btnChangePicture.Name = "btnChangePicture";
            btnChangePicture.UseVisualStyleBackColor = true;
            btnChangePicture.Click += btnUploadPicture_Click;
            // 
            // btnCorrect
            // 
            btnCorrect.FlatAppearance.BorderColor = Color.WhiteSmoke;
            resources.ApplyResources(btnCorrect, "btnCorrect");
            btnCorrect.Image = Properties.Resources.icons8_correct_24;
            btnCorrect.Name = "btnCorrect";
            btnCorrect.UseVisualStyleBackColor = true;
            // 
            // lbPictureUploaded
            // 
            resources.ApplyResources(lbPictureUploaded, "lbPictureUploaded");
            lbPictureUploaded.Name = "lbPictureUploaded";
            // 
            // lbDragPictureHere
            // 
            resources.ApplyResources(lbDragPictureHere, "lbDragPictureHere");
            lbDragPictureHere.Name = "lbDragPictureHere";
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
            // ofdUploadPicture
            // 
            resources.ApplyResources(ofdUploadPicture, "ofdUploadPicture");
            // 
            // AddTeamForm
            // 
            AcceptButton = btnSave;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(panelPicture);
            Controls.Add(lbPicture);
            Controls.Add(tbCountry);
            Controls.Add(lbCountry);
            Controls.Add(tbYearOfEstablishment);
            Controls.Add(lbYearOfEstablishment);
            Controls.Add(tbTeamName);
            Controls.Add(lbTeamName);
            Controls.Add(panelPreview);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTeamForm";
            ShowInTaskbar = false;
            panelPreview.ResumeLayout(false);
            panelPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDisplayTeamPicture).EndInit();
            panelPicture.ResumeLayout(false);
            panelPicture.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelPreview;
        private Label lbDisplayTeamName;
        private PictureBox pbDisplayTeamPicture;
        private Label lbTeamName;
        private TextBox tbTeamName;
        private Label lbYearOfEstablishment;
        private TextBox tbYearOfEstablishment;
        private Label lbCountry;
        private TextBox tbCountry;
        private Label lbPicture;
        private Panel panelPicture;
        private Label lbDragPictureHere;
        private Label lbPictureUploaded;
        private Button btnChangePicture;
        private Button btnCorrect;
        private Button btnUploadPicture;
        private Button btnSave;
        private Button btnBack;
        private OpenFileDialog ofdUploadPicture;
    }
}