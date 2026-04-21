using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCIProjekat1
{
    public partial class AdminForm : Form
    {
        private bool isSortedAscending = true;

        private string Language;
        private string Username;
        private string Background;

        private string TimeFormat;
        public AdminForm(string username, string theme)
        {
            string language = theme.Split(",")[1];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();
            lbDateTime.Text = DateTime.Now.ToString();
            FillRequestGrid();
            FillAccountGrid();

            Username = username;
            Background = theme.Split(",")[0];
            Language = theme.Split(",")[1];
            TimeFormat = theme.Split(",")[2];

            SetTheme();
        }

        void SetTheme()
        {
            // Postavljanje teme na osnovu dobijenih podataka: 
            if (Background.Equals("Spring"))
            {
                foreach (TabPage page in this.TabControl.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.AdminFormSpring;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                this.StatusPanel.BackColor = ColorTranslator.FromHtml("#00e6bf");
                this.BackgroundImage = Properties.Resources.AdminFormSpring;
                this.lbDateTime.ForeColor = Color.Black;
            }
            else if (Background.Equals("Summer"))
            {
                foreach (TabPage page in this.TabControl.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.AdminFormSummer;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                this.StatusPanel.BackColor = ColorTranslator.FromHtml("#ff5501");
                this.BackgroundImage = Properties.Resources.AdminFormSummer;
                this.lbDateTime.ForeColor = Color.Black;
            }
            else
            {
                foreach (TabPage page in this.TabControl.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.AdminFormDark;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                this.StatusPanel.BackColor = Color.Black;
                this.BackgroundImage = Properties.Resources.AdminFormDark;
                this.lbDateTime.ForeColor = Color.White;
            }
            this.BackgroundImageLayout = ImageLayout.Center;

            if (Language.Equals("srb"))
            {
                tsmiLanguageSerbian.Checked = true;
                Language = "";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
                Language = "srb";
            }
            else
            {
                tsmiLanguageEnglish.Checked = true;
                Language = "en";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
            }

            // Postavljanje formata vremena na osnovu dobijenih podataka: 
            if (TimeFormat.Equals("12"))
            {
                tsmiFormat12h.Checked = true;
                lbDateTime.Text = DateTime.Now.ToString();
            }
            else
            {
                tsmiFormat24h.Checked = true;
                lbDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
            }
        }

        void FillRequestGrid()
        {
            dgvRequests.Rows.Clear();
            foreach (var acc in DBUtil.GetAccounts(tbSearchAccounts.Text))
            {
                if (acc.Type.Equals("Zahtjev"))
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = acc
                    };
                    row.CreateCells(dgvRequests, acc.Username,
                        acc.DateOfRequest.HasValue ? acc.DateOfRequest.Value.ToString("yyyy-MM-dd") : "N/A");
                    dgvRequests.Rows.Add(row);
                }
            }
        }

        void FillAccountGrid()
        {
            dgvAccounts.Rows.Clear();
            foreach (var acc in DBUtil.GetAccounts(tbSearchAccounts.Text))
            {
                if (acc.Type.Equals("Obicni nalog"))
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = acc
                    };
                    row.CreateCells(dgvAccounts, acc.Username,
                        acc.DateOfCreation.HasValue ? acc.DateOfCreation.Value.ToString("yyyy-MM-dd") : "N/A",
                        acc.DateOfRequest.HasValue ? acc.DateOfRequest.Value.ToString("yyyy-MM-dd") : "N/A");
                    dgvAccounts.Rows.Add(row);
                }
            }
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRequests.Columns[e.ColumnIndex].HeaderText.Equals("Dodatne informacije:")
                && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Preuzimanje informacija o nalogu:
                var account = dgvRequests.Rows[e.RowIndex].Tag as Account;

                // Ispis informacija u TextBox:
                if (account != null)
                {
                    rtbInfo.Text = string.IsNullOrEmpty(account.Info) ? "Nema dodatnih informacija." : account.Info;
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            string text = Language.Equals("srb") ? "Da li zaista želite da se odjavite?" :
                "Do you really want to logout?";
            string prompt = Language.Equals("srb") ? "Potvrda" : "Confirmation";
            if (MessageBox.Show(text, prompt, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nije odabran nijedan zahtjev.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                rtbInfo.Clear();
                DataGridViewRow row = dgvRequests.SelectedRows[0];
                var account = row.Tag as Account;
                dgvRequests.Rows.Remove(row);
                DBUtil.AcceptRequest(account);
                FillRequestGrid();
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nije odabran nijedan zahtjev.", "Greška",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                rtbInfo.Clear();
                DataGridViewRow row = dgvRequests.SelectedRows[0];
                var account = row.Tag as Account;
                dgvRequests.Rows.Remove(row);
                DBUtil.DenyRequest(account.AccountId);
                FillRequestGrid();
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li stvarno želite obrišete ovaj nalog?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (dgvAccounts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nije izabran nijedan nalog.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow row = dgvAccounts.SelectedRows[0];
                    var account = row.Tag as Account;
                    dgvAccounts.Rows.Remove(row);
                    DBUtil.DeleteAccountById(account.AccountId);
                    FillAccountGrid();
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Text.Equals("Zahtjevi"))
            {
                FillRequestGrid();
            }
            else
            {
                FillAccountGrid();
            }
        }

        private void tbSearchAccounts_TextChanged(object sender, EventArgs e)
        {
            FillAccountGrid();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            isSortedAscending = !isSortedAscending;
            if (isSortedAscending)
            {
                dgvAccounts.Sort(dgvAccounts.Columns[1],
                    System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                dgvAccounts.Sort(dgvAccounts.Columns[1],
                    System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (TimeFormat.Equals("12"))
            {
                lbDateTime.Text = DateTime.Now.ToString();
            }
            else
            {
                lbDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
            }
        }

        private void tsmiLanguageSerbian_Click(object sender, EventArgs e)
        {
            if (!Language.Equals("srb"))
            {
                Language = ""; // Default
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);

                // Prebacivanje kontrola na srpski: 
                this.Controls.Clear();
                InitializeComponent();
                lbDateTime.Text = DateTime.Now.ToString();
                FillRequestGrid();
                FillAccountGrid();

                Language = "srb";
                SetTheme();

                // Ažuriranje baze podataka: 
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
            else
            {
                tsmiLanguageSerbian.Checked = true;
            }
        }

        private void tsmiLanguageEnglish_Click(object sender, EventArgs e)
        {
            if (!Language.Equals("en"))
            {
                Language = "en";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);

                // Prebacivanje kontrola na engleski:
                this.Controls.Clear();
                InitializeComponent();
                lbDateTime.Text = DateTime.Now.ToString();
                FillRequestGrid();
                FillAccountGrid();

                SetTheme();

                // Ažuriranje baze podataka:
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
            else
            {
                tsmiLanguageEnglish.Checked = false;
            }
        }

        private void tsmiStyleSpring_Click(object sender, EventArgs e)
        {
            if (!Background.Equals("Spring"))
            {
                Background = "Spring";
                SetTheme();

                // Ažuriranje baze podataka: 
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
        }

        private void tsmiStyleSummer_Click(object sender, EventArgs e)
        {
            if (!Background.Equals("Summer"))
            {
                Background = "Summer";
                SetTheme();

                // Ažuriranje baze podataka: 
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
        }

        private void tsmiStylesDark_Click(object sender, EventArgs e)
        {
            if (!Background.Equals("Dark"))
            {
                Background = "Dark";
                SetTheme();

                // Ažuriranje baze podataka: 
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
        }

        private void tsmiFormat12h_Click(object sender, EventArgs e)
        {
            if (!TimeFormat.Equals("12"))
            {
                tsmiFormat24h.Checked = false;
                TimeFormat = "12";
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
                lbDateTime.Text = DateTime.Now.ToString();
            }
            else
            {
                tsmiFormat12h.Checked = true;
            }
        }

        private void tsmiFormat24h_Click(object sender, EventArgs e)
        {
            if (!TimeFormat.Equals("24"))
            {
                tsmiFormat12h.Checked = false;
                TimeFormat = "24";
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
                lbDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
            }
            else
            {
                tsmiFormat24h.Checked = true;
            }
        }
    }
}
