using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCIProjekat1
{
    public partial class AddPlayerToTheTeamForm : Form
    {
        private string TeamName;
        private int SeasonId;

        private string Language;
        public AddPlayerToTheTeamForm(string teamName, int seasonId)
        {
            InitializeComponent();
            TeamName = teamName;
            SeasonId = seasonId;
            lbTeamName.Text = TeamName;
            comboFreePlayers.DataSource = DBUtil.GetPlayersThatDidNotPlayThisSeason(SeasonId);
            comboFreePlayers.DisplayMember = "InGameId";

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
            if (comboFreePlayers.SelectedItem == null || comboPositions.SelectedItem == null)
            {
                if (UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Nisu sva polja popunjena.", "Greška", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Some fields are empty.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            DBUtil.InsertPastTeamsForPlayer(new PastTeamsForPlayer()
            {
                InGameId = (comboFreePlayers.SelectedItem as Player).InGameId,
                Season = new Season()
                {
                    SeasonId = SeasonId
                },
                TeamName = lbTeamName.Text.Trim(),
                Position = comboPositions.SelectedItem.ToString()
            });
            this.Close();
        }

        private void btnAddNewPlayer_Click(object sender, EventArgs e)
        {
            if (new PlayerInfoForm(null, true).ShowDialog() == DialogResult.Cancel)
            {
                comboFreePlayers.DataSource = DBUtil.GetPlayersThatDidNotPlayThisSeason(SeasonId);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
