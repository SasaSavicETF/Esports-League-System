using MySql.Data.MySqlClient;
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
    public partial class NewMatchForm : Form
    {
        private int SeasonId;
        public NewMatchForm(int seasonId)
        {
            InitializeComponent();
            SeasonId = seasonId;
            comboTeam1.DataSource = DBUtil.GetTeamsBySeason(SeasonId);
            comboTeam1.DisplayMember = "Name";
            comboTeam2.DataSource = DBUtil.GetTeamsBySeason(SeasonId);
            comboTeam2.DisplayMember = "Name";
            comboPhase.DataSource = DBUtil.GetPhasesBySeason(SeasonId);
            comboPhase.DisplayMember = "PhaseName";

            if (UserForm.Background.Equals("Spring"))
            {
                this.BackgroundImage = Properties.Resources.NewMatchFormSpring;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (UserForm.Background.Equals("Summer"))
            {
                this.BackgroundImage = Properties.Resources.NewMatchFormSummer;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.NewMatchFormDark;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void comboTeam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(DBUtil.FindTeamPicture(comboTeam1.SelectedItem.ToString()));
            pbTeam1.Image = Image.FromStream(ms);
            lbSelectedTeam1.Text = comboTeam1.SelectedItem.ToString();
        }

        private void comboTeam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(DBUtil.FindTeamPicture((string)comboTeam2.SelectedItem.ToString()));
            pbTeam2.Image = Image.FromStream(ms);
            lbSelectedTeam2.Text = comboTeam2.SelectedItem.ToString();
        }

        private void btnSaveMatch_Click(object sender, EventArgs e)
        {
            try
            {
                // Provjera da li su sve vrijednosti unesene.
                if (comboFormat.SelectedItem == null)
                {
                    if(UserForm.Language.Equals("srb"))
                    {
                        MessageBox.Show("Format nije odabran.", "Greška", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    } else
                    {
                        MessageBox.Show("Format is not chosen.", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    }
                    
                }


                DBUtil.InsertMatch(new Match()
                {
                    Format = comboFormat.SelectedItem.ToString(),
                    Team1 = comboTeam1.SelectedItem.ToString(),
                    Result = tbResult.Text.Trim(),
                    Team2 = comboTeam2.SelectedItem.ToString(),
                    Date = dtpMatchDate.Value,
                    Location = tbLocation.Text.Trim(),
                    Phase = new Phase()
                    {
                        PhaseId = (comboPhase.SelectedItem as Phase).PhaseId
                    }
                });
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbResult_TextChanged(object sender, EventArgs e)
        {
            lbDisplayResult.Text = tbResult.Text;
        }

        private void dtpMatchDate_ValueChanged(object sender, EventArgs e)
        {
            lbDisplayDate.Text = dtpMatchDate.Value.ToString("dd.MM.yyyy.");
            lbDisplayDate.ForeColor = Color.White;
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            if (new RegisterTeamForSeason(SeasonId).ShowDialog() == DialogResult.Cancel)
            {
                // Resetovanje timova u sezoni:
                comboTeam1.DataSource = DBUtil.GetTeamsBySeason(SeasonId);
                comboTeam2.DataSource = DBUtil.GetTeamsBySeason(SeasonId);
            };
        }

        private void btnAddPhase_Click(object sender, EventArgs e)
        {
            if (new AddPhaseFrom(SeasonId).ShowDialog() == DialogResult.Cancel)
            {
                comboPhase.DataSource = DBUtil.GetPhasesBySeason(SeasonId);
            }
        }
    }
}
