using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCIProjekat1
{
    public partial class PlayerInfoForm : Form
    {
        private Player Player;
        private DataGridViewCell rightClickedCell;

        // Da li se radi o dodavanju ili uređivanju igrača:
        private bool AddingPlayer = false;

        public PlayerInfoForm(string inGameId, bool addingPlayer)
        {
            InitializeComponent();
            Player = DBUtil.GetPlayer(inGameId);
            AddingPlayer = addingPlayer;
            if (!AddingPlayer)
            {
                if(UserForm.Language.Equals("en"))
                {
                    Text = "Player info."; 
                } else
                {
                    Text = "Informacije o igraču"; 
                }
                lbPlayerNameDisplay.Text = Player.InGameId;
                tbInGameId.Text = Player.InGameId;
                tbFirstName.Text = Player.FirstName;
                tbLastName.Text = Player.LastName;
                comboPositions.SelectedItem = Player.Position;
                dtpDateOfBirth.Value = Player.DateOfBirth;
                tbCountry.Text = Player.Country;
                btnSave.Visible = true;
                btnSavePlayer.Visible = false;
                FillPastTeamsGrid();
            }
            else
            {
                if (UserForm.Language.Equals("en"))
                {
                    Text = "Add Player";
                }
                else
                {
                    Text = "Dodavanje igrača";
                }

                // Za dodavanje igrača nije potrebno popunjavati DGV zato što ga tek dodajemo
                dgvPastTeams.Enabled = false;
                btnAddPastTeam.Enabled = false;
                btnUpdatePastTeam.Enabled = false;
                btnDeletePastTeam.Enabled = false;
                btnSave.Visible = false;
                btnSavePlayer.Visible = true;
            }

            if (UserForm.Background.Equals("Spring"))
            {
                this.BackgroundImage = Properties.Resources.PlayerInfoSpring;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (UserForm.Background.Equals("Summer"))
            {
                this.BackgroundImage = Properties.Resources.PlayerInfoSummer;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.PlayerInfoDark;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        void FillPastTeamsGrid()
        {
            dgvPastTeams.Rows.Clear();
            foreach (var team in DBUtil.GetPastTeamsForPlayer(Player.InGameId))
            {
                DataGridViewRow row = new DataGridViewRow
                {
                    Tag = team
                };
                row.CreateCells(dgvPastTeams, team.Season.Display, team.TeamName, team.Position);
                dgvPastTeams.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.UpdatePlayer(new Player()
                {
                    InGameId = tbInGameId.Text.Trim(),
                    FirstName = tbFirstName.Text.Trim(),
                    LastName = tbLastName.Text.Trim(),
                    Position = comboPositions.SelectedItem.ToString(),
                    DateOfBirth = dtpDateOfBirth.Value,
                    Country = tbCountry.Text.Trim()
                });
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPastTeams_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgvPastTeams.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    rightClickedCell = dgvPastTeams.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                }
            }
        }

        private void cmsPastTeamsEdit_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                dgvPastTeams.CurrentCell = rightClickedCell;
                dgvPastTeams.BeginEdit(true);

                rightClickedCell = null;
            }
        }

        private void btnAddPastTeam_Click(object sender, EventArgs e)
        {
            if (new AddPastTeamForPlayer(Player.InGameId).ShowDialog() == DialogResult.Cancel)
            {
                FillPastTeamsGrid();
            }
        }

        private void btnUpdatePastTeam_Click(object sender, EventArgs e)
        {
            if (dgvPastTeams.SelectedRows.Count == 0)
            {
                if(UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Nije odabran nijedan tim.", "Greška",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else
                {
                    MessageBox.Show("Xou haven't chosen a team.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                // Provjera validnosti sezone:
                string chosenSeason = dgvPastTeams.SelectedRows[0].Cells[0].Value.ToString();
                int chosenSeasonId = 0;
                List<Season> seasons = DBUtil.GetSeasons();
                Season matchingSeason = seasons.FirstOrDefault(season => season.Display.Equals(chosenSeason));
                if (matchingSeason == null)
                {
                    if (UserForm.Language.Equals("srb"))
                    {
                        MessageBox.Show("Unesena sezona ne postoji.", "Greška",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else
                    {
                        MessageBox.Show("The season does not exist", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    chosenSeasonId = matchingSeason.SeasonId;
                }

                // Provjera validnosti pozicije: 
                string[] validPositions = { "Top", "Jungle", "Mid", "Bot", "Support" };
                if (!validPositions.Contains(comboPositions.SelectedItem.ToString()))
                {
                    if (UserForm.Language.Equals("srb"))
                    {
                        MessageBox.Show("Unesena pozicija ne postoji. Dozvoljene pozicije su: " +
                            "Top, Jungle, Mid, Bot, Support", "Greška",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else
                    {
                        MessageBox.Show("Entered position does not exist. Allowed positions are: " +
                            "Top, Jungle, Mid, Bot, Support", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                        
                }

                DBUtil.UpdatePastTeamsForPlayer(new PastTeamsForPlayer()
                {
                    InGameId = Player.InGameId,
                    Season = new Season()
                    {
                        SeasonId = chosenSeasonId
                    },
                    TeamName = dgvPastTeams.SelectedRows[0].Cells[1].Value.ToString(),
                    Position = comboPositions.SelectedItem.ToString()
                });
                FillPastTeamsGrid();
            }
        }

        private void btnDeletePastTeam_Click(object sender, EventArgs e)
        {
            if (dgvPastTeams.SelectedRows.Count == 0)
            {
                if(UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Nije odabran nijedan tim.", "Greška", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    return;
                } else
                {
                    MessageBox.Show("You haven't chosen a team.", "Error", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    return;
                }
               
            }
            else
            {
                DataGridViewRow selectedRow = dgvPastTeams.SelectedRows[0];
                if (selectedRow != null)
                {
                    var team = selectedRow.Tag as PastTeamsForPlayer;
                    DBUtil.DeletePastTeamsForPlayer(team.InGameId);
                    dgvPastTeams.Rows.Remove(selectedRow);
                    FillPastTeamsGrid();
                }
            }
        }

        private void btnSavePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                Player = new Player()
                {
                    InGameId = tbInGameId.Text.Trim(),
                    FirstName = tbFirstName.Text.Trim(),
                    LastName = tbLastName.Text.Trim(),
                    Position = comboPositions.SelectedItem.ToString(),
                    DateOfBirth = dtpDateOfBirth.Value,
                    Country = tbCountry.Text.Trim()
                };

                DBUtil.InsertPlayer(Player);

                // Obavještenje o dodatom igraču:
                if(UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Igrač uspješno registrovan.", "Obavještenje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Player successfully added.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                

                // Omogućavanje dodavanja prošlih timova:
                dgvPastTeams.Enabled = true;
                btnAddPastTeam.Enabled = true;
                btnUpdatePastTeam.Enabled = true;
                btnDeletePastTeam.Enabled = true;
                btnSave.Visible = true;
                btnSavePlayer.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
