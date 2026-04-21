using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace HCIProjekat1
{
    public partial class LoginForm : Form
    {
        private SignUpForm SignUpForm = new SignUpForm();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.UseSystemPasswordChar)
            {
                tbPassword.UseSystemPasswordChar = false;
                btnTogglePassword.Image = global::HCIProjekat1.Properties.Resources.icons8_hide_24;
                ttBtnTogglePassword.SetToolTip(btnTogglePassword, "Sakrij lozinku");
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                btnTogglePassword.Image = global::HCIProjekat1.Properties.Resources.icons8_show_24;
                ttBtnTogglePassword.SetToolTip(btnTogglePassword, "Prikaži lozinku");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text.Trim()))
            {
                MessageBox.Show("Polje za korisnièko ime je prazno.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                MessageBox.Show("Polje za lozinku je prazno.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Account account = DBUtil.CheckAccountCredentials(tbUsername.Text.Trim(), tbPassword.Text.Trim());
                if (account != null)
                {
                    if (account.Type.Equals("Admin"))
                    {
                        ClearData();
                        this.Hide();
                        if (new AdminForm(account.Username, account.Theme).ShowDialog() == DialogResult.Cancel)
                        {
                            this.Show();
                        }
                    }
                    else if (account.Type.Equals("Obicni nalog"))
                    {
                        ClearData();
                        this.Hide();
                        if (new UserForm(account.Username, account.Theme).ShowDialog() == DialogResult.Cancel)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nalog još nije prihvaæen.", "Obavještenje",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Neispravna lozinka.", "Greška",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbRegistration_Click(object sender, EventArgs e)
        {
            ClearData();
            this.Hide();
            if (SignUpForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        void ClearData()
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }
    }
}