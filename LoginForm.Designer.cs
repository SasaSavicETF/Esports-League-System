namespace HCIProjekat1
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lbUsername = new Label();
            tbUsername = new TextBox();
            lbPassword = new Label();
            tbPassword = new TextBox();
            btnTogglePassword = new Button();
            ttBtnTogglePassword = new ToolTip(components);
            btnLogin = new Button();
            lbSignUp = new Label();
            lbRegistration = new Label();
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
            btnTogglePassword.BackColor = Color.White;
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatAppearance.MouseOverBackColor = Color.Transparent;
            resources.ApplyResources(btnTogglePassword, "btnTogglePassword");
            btnTogglePassword.Image = Properties.Resources.icons8_show_24;
            btnTogglePassword.Name = "btnTogglePassword";
            ttBtnTogglePassword.SetToolTip(btnTogglePassword, resources.GetString("btnTogglePassword.ToolTip"));
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // btnLogin
            // 
            resources.ApplyResources(btnLogin, "btnLogin");
            btnLogin.Name = "btnLogin";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lbSignUp
            // 
            resources.ApplyResources(lbSignUp, "lbSignUp");
            lbSignUp.BackColor = Color.Transparent;
            lbSignUp.ForeColor = Color.White;
            lbSignUp.Name = "lbSignUp";
            // 
            // lbRegistration
            // 
            resources.ApplyResources(lbRegistration, "lbRegistration");
            lbRegistration.Cursor = Cursors.Hand;
            lbRegistration.ForeColor = SystemColors.Highlight;
            lbRegistration.Name = "lbRegistration";
            lbRegistration.Click += lbRegistration_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginBackground;
            Controls.Add(lbRegistration);
            Controls.Add(lbSignUp);
            Controls.Add(btnLogin);
            Controls.Add(btnTogglePassword);
            Controls.Add(tbPassword);
            Controls.Add(lbPassword);
            Controls.Add(tbUsername);
            Controls.Add(lbUsername);
            MaximizeBox = false;
            Name = "LoginForm";
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
        private Button btnLogin;
        private Label lbSignUp;
        private Label lbRegistration;
    }
}