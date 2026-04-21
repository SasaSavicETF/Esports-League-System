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
    public partial class AddPastTeamForPlayer : Form
    {
        private string InGameId;
        public AddPastTeamForPlayer(string inGameId)
        {
            InitializeComponent();
            InGameId = inGameId;
            comboSeasons.DataSource = DBUtil.GetSeasons();
            comboSeasons.DisplayMember = "Display";
            comboTeams.DataSource = DBUtil.GetTeams();
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
            DBUtil.InsertPastTeamsForPlayer(new PastTeamsForPlayer()
            {
                InGameId = InGameId,
                Season = new Season()
                {
                    SeasonId = (comboSeasons.SelectedItem as Season).SeasonId
                },
                TeamName = comboTeams.SelectedItem.ToString(),
                Position = comboPositions.SelectedItem.ToString()
            });
            this.Close();
        }
    }
}
