namespace HCIProjekat1
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            lbUsername = new Label();
            tbUsername = new TextBox();
            lbPassword = new Label();
            tbPassword = new TextBox();
            btnTogglePassword = new Button();
            ttBtnTogglePassword = new ToolTip(components);
            btnConfirmPassword = new Button();
            lbConfirmPassword = new Label();
            tbConfirmPassword = new TextBox();
            btnSignUp = new Button();
            btnBack = new Button();
            lbInfo = new Label();
            tbInfo = new TextBox();
            ttBtnConfirmPassword = new ToolTip(components);
            SuspendLayout();
            // 
            // lbUsername
            // 
            resources.ApplyResources(lbUsername, "lbUsername");
            lbUsername.BackColor = Color.Transparent;
            lbUsername.ForeColor = Color.White;
            lbUsername.Name = "lbUsername";
            // 
            // tbUsername
            // 
            resources.ApplyResources(tbUsername, "tbUsername");
            tbUsername.Name = "tbUsername";
            // 
            // lbPassword
            // 
            resources.ApplyResources(lbPassword, "lbPassword");
            lbPassword.BackColor = Color.Transparent;
            lbPassword.ForeColor = Color.White;
            lbPassword.Name = "lbPassword";
            // 
            // tbPassword
            // 
            resources.ApplyResources(tbPassword, "tbPassword");
            tbPassword.Name = "tbPassword";
            tbPassword.UseSystemPasswordChar = true;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnTogglePassword.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            resources.ApplyResources(btnTogglePassword, "btnTogglePassword");
            btnTogglePassword.Image = Properties.Resources.icons8_show_24;
            btnTogglePassword.Name = "btnTogglePassword";
            ttBtnTogglePassword.SetToolTip(btnTogglePassword, resources.GetString("btnTogglePassword.ToolTip"));
            btnTogglePassword.UseVisualStyleBackColor = true;
            btnTogglePassword.Click += button1_Click;
            // 
            // btnConfirmPassword
            // 
            btnConfirmPassword.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnConfirmPassword.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            resources.ApplyResources(btnConfirmPassword, "btnConfirmPassword");
            btnConfirmPassword.Image = Properties.Resources.icons8_show_24;
            btnConfirmPassword.Name = "btnConfirmPassword";
            ttBtnTogglePassword.SetToolTip(btnConfirmPassword, resources.GetString("btnConfirmPassword.ToolTip"));
            ttBtnConfirmPassword.SetToolTip(btnConfirmPassword, resources.GetString("btnConfirmPassword.ToolTip1"));
            btnConfirmPassword.UseVisualStyleBackColor = true;
            btnConfirmPassword.Click += btnConfirmPassword_Click;
            // 
            // lbConfirmPassword
            // 
            resources.ApplyResources(lbConfirmPassword, "lbConfirmPassword");
            lbConfirmPassword.BackColor = Color.Transparent;
            lbConfirmPassword.ForeColor = Color.White;
            lbConfirmPassword.Name = "lbConfirmPassword";
            // 
            // tbConfirmPassword
            // 
            resources.ApplyResources(tbConfirmPassword, "tbConfirmPassword");
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnSignUp
            // 
            resources.ApplyResources(btnSignUp, "btnSignUp");
            btnSignUp.Name = "btnSignUp";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnBack
            // 
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Name = "btnBack";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lbInfo
            // 
            resources.ApplyResources(lbInfo, "lbInfo");
            lbInfo.BackColor = Color.Transparent;
            lbInfo.ForeColor = Color.White;
            lbInfo.Name = "lbInfo";
            // 
            // tbInfo
            // 
            resources.ApplyResources(tbInfo, "tbInfo");
            tbInfo.Name = "tbInfo";
            tbInfo.TextChanged += tbInfo_TextChanged;
            // 
            // SignUpForm
            // 
            AcceptButton = btnSignUp;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.SignUpBackground;
            Controls.Add(tbInfo);
            Controls.Add(lbInfo);
            Controls.Add(btnBack);
            Controls.Add(btnSignUp);
            Controls.Add(btnConfirmPassword);
            Controls.Add(tbConfirmPassword);
            Controls.Add(lbConfirmPassword);
            Controls.Add(btnTogglePassword);
            Controls.Add(tbPassword);
            Controls.Add(lbPassword);
            Controls.Add(tbUsername);
            Controls.Add(lbUsername);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUsername;
        private TextBox tbUsername;
        private Label lbPassword;
        private TextBox tbPassword;
        private Button btnTogglePassword;
        private ToolTip ttBtnTogglePassword;
        private Label lbConfirmPassword;
        private TextBox tbConfirmPassword;
        private Button btnConfirmPassword;
        private ToolTip ttBtnConfirmPassword;
        private Button btnSignUp;
        private Button btnBack;
        private Label lbInfo;
        private TextBox tbInfo;
    }
}