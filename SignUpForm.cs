using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCIProjekat1
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            if (tbConfirmPassword.UseSystemPasswordChar)
            {
                tbConfirmPassword.UseSystemPasswordChar = false;
                btnConfirmPassword.Image = global::HCIProjekat1.Properties.Resources.icons8_hide_24;
                ttBtnConfirmPassword.SetToolTip(btnConfirmPassword, "Sakrij lozinku");
            }
            else
            {
                tbConfirmPassword.UseSystemPasswordChar = true;
                btnConfirmPassword.Image = global::HCIProjekat1.Properties.Resources.icons8_show_24;
                ttBtnConfirmPassword.SetToolTip(btnConfirmPassword, "Prikaži lozinku");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text.Trim()))
            {
                MessageBox.Show("Polje za korisničko ime je prazno.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                MessageBox.Show("Polje za lozinku je prazno.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!tbPassword.Text.Trim().Equals(tbConfirmPassword.Text.Trim()))
            {
                MessageBox.Show("Niste potvrdili lozinku.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Provjera da li je korisničko ime dostupno u bazi:
                if (DBUtil.CheckUsernameAvailability(tbUsername.Text.Trim()))
                {
                    MessageBox.Show("Korisničko ime je već u upotrebi", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Unos u bazu podataka u WAITING statusu:
                DBUtil.RequestAccountAcceptance(new Account()
                {
                    // AccountId - nije potreban
                    Type = "Zahtjev",
                    Username = tbUsername.Text.Trim(),
                    Password = tbPassword.Text.Trim(),
                    // DateOfCreation - dodaje se nakon što ga admin prihvati
                    DateOfRequest = DateTime.Now,
                    Info = string.IsNullOrEmpty(tbInfo.Text.Trim()) ? null : tbInfo.Text.Trim()
                });

                // Obavještenje na ekranu:
                MessageBox.Show("Zahtjev za nalog uspješno poslan!", "Obavještenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearData();
            this.Close();
        }

        void ClearData()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbConfirmPassword.Clear();
            tbInfo.Clear();
        }

        private void tbInfo_TextChanged(object sender, EventArgs e)
        {
            lbInfo.Text = $"Dodatne informacije: ({tbInfo.Text.Length}/200)";
        }
    }
}
