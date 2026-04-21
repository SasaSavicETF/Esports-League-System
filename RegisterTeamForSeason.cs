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
    public partial class RegisterTeamForSeason : Form
    {
        private int SeasonId;
        public RegisterTeamForSeason(int seasonId)
        {
            InitializeComponent();
            SeasonId = seasonId;
            lbSeasonDisplay.Text = DBUtil.FindSeasonById(SeasonId);
            comboTeams.DataSource = DBUtil.GetTeamsWithoutSeason(SeasonId);
            comboTeams.DisplayMember = "Name";

            if (UserForm.Background.Equals("Spring"))
            {
                this.BackgroundImage = Properties.Resources.AddForm;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (UserForm.Background.Equals("Summer"))
            {
                this.BackgroundImage = Properties.Resources.AddFormSummer;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.AddFormDark;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboTeams.SelectedItem == null || tbEnterTeamPlacement.Text == null
                || Convert.ToInt32(tbEnterTeamPlacement.Text) < 1
                || Convert.ToInt32(tbEnterTeamPlacement.Text) > 10)
            {
                if(UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Nisu sva polja popunjena.", "Greška", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return;
                } else
                {
                    MessageBox.Show("You haven't filled everything.", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return;
                }
                
            }

            try
            {
                string teamName = (comboTeams.SelectedItem as Team).Name;
                int placement = Convert.ToInt32(tbEnterTeamPlacement.Text.Trim());
                DBUtil.RegisterTeamForSeason(teamName, SeasonId, placement);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewTeam_Click(object sender, EventArgs e)
        {
            if (new AddTeamForm(false).ShowDialog() == DialogResult.Cancel)
            {
                comboTeams.DataSource = DBUtil.GetTeamsWithoutSeason(SeasonId);
                comboTeams.DisplayMember = "Name";
            }
        }
    }
}
