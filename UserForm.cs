using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Windows.Forms.Design;

namespace HCIProjekat1
{
    public partial class UserForm : Form
    {
        private DataGridViewCell rightClickedCell;
        public static string Language;

        private string Username;
        public static string Background;

        private string TimeFormat;
        public UserForm(string username, string theme)
        {
            string language = theme.Split(",")[1];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();
            comboSeasons.DataSource = DBUtil.GetSeasons();
            comboSeasons.DisplayMember = "Display";
            FillMatchGrid();
            FillPhaseGrid();
            FillTeamsGrid();
            FillAllTeamsGrid();
            FillAllPlayersGrid();
            lbDateTime.Text = DateTime.Now.ToString();
            button1.Enabled = false;

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
                foreach (TabPage page in this.tabControlUserForm.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.SpringTheme;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                foreach (TabPage page in this.tabUserForm.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.SpringTheme;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                this.BackColor = ColorTranslator.FromHtml("#00e6bf");
                this.panel1.BackColor = ColorTranslator.FromHtml("#00e6bf");
                this.lbDateTime.ForeColor = Color.Black;
            }
            else if (Background.Equals("Summer"))
            {
                foreach (TabPage page in this.tabControlUserForm.TabPages)
                {
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                    page.BackgroundImage = Properties.Resources.SummerTheme;
                }
                foreach (TabPage page in this.tabUserForm.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.SummerTheme;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                this.BackColor = ColorTranslator.FromHtml("#ff5501");
                this.panel1.BackColor = ColorTranslator.FromHtml("#ff5001");
                this.lbDateTime.ForeColor = Color.Black;
            }
            else
            {
                foreach (TabPage page in this.tabControlUserForm.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.DarkTheme;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                foreach (TabPage page in this.tabUserForm.TabPages)
                {
                    page.BackgroundImage = Properties.Resources.DarkTheme;
                    page.BackgroundImageLayout = ImageLayout.Stretch;
                }
                this.BackColor = Color.Black;
                this.panel1.BackColor = Color.Black;
                this.lbDateTime.ForeColor = Color.White;
            }
            this.BackgroundImageLayout = ImageLayout.Center;

            // Postavljanje jezika na osnovu dobijenih podataka: 
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

        void FillMatchGrid()
        {
            dgvMatches.Rows.Clear();
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            foreach (var match in DBUtil.GetMatches(seasonId, tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = match
                };
                row.CreateCells(dgvMatches, match.Format, match.Team1, match.Result, match.Team2,
                    match.Date.ToString("yyyy-MM-dd"), match.Location, match.Phase.PhaseName,
                    match.Phase.Season.Display);
                dgvMatches.Rows.Add(row);
            }
        }

        void FillPhaseGrid()
        {
            dgvPhases.Rows.Clear();
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            foreach (var phase in DBUtil.GetPhasesBySeason(seasonId))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = phase
                };
                row.CreateCells(dgvPhases, phase.PhaseName, phase.StartDate.ToString("yyyy-MM-dd"),
                    phase.EndDate.ToString("yyyy-MM-dd"), phase.Season.Display);
                dgvPhases.Rows.Add(row);
            }
        }

        void FillTeamsGrid()
        {
            dgvTeamsPlacement.Rows.Clear();
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            foreach (var teamPlacement in DBUtil.GetTeamPlacementsBySeason(seasonId))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = teamPlacement
                };
                row.CreateCells(dgvTeamsPlacement, teamPlacement.Placement, teamPlacement.TeamName);
                dgvTeamsPlacement.Rows.Add(row);
            }
        }

        void FillTeamPlayersGrid(int seasonId, string teamName)
        {
            dgvTeamPlayers.Rows.Clear();
            foreach (var player in DBUtil.GetPlayersBySeason(seasonId, teamName))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = player
                };
                row.CreateCells(dgvTeamPlayers, player.InGameId, player.Position);
                dgvTeamPlayers.Rows.Add(row);
            }
        }

        void FillAllTeamsGrid()
        {
            dgvAllTeams.Rows.Clear();
            foreach (var team in DBUtil.GetTeams())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = team
                };
                row.CreateCells(dgvAllTeams, team.Name, team.YearOfEstablishment, team.Country);
                dgvAllTeams.Rows.Add(row);
            }
        }

        void FillAllPlayersGrid()
        {
            dgvAllPlayers.Rows.Clear();
            foreach (var player in DBUtil.GetPlayers())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = player
                };
                row.CreateCells(dgvAllPlayers, player.InGameId, player.FirstName, player.LastName,
                    player.Position, player.DateOfBirth.ToString("yyyy-MM-dd"), player.Country);
                dgvAllPlayers.Rows.Add(row);
            }
        }

        void FillTitlesGrid(string teamName)
        {
            dgvTitles.Rows.Clear();
            foreach (var title in DBUtil.GetTitlesForTeam(teamName))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = title
                };
                row.CreateCells(dgvTitles, title.Name, title.YearWon);
                dgvTitles.Rows.Add(row);
            }
        }

        // Bojenje ćelija na osnovu teksta unutar njih:
        private void dgvMatches_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMatches.Columns[e.ColumnIndex].HeaderText.Equals("Sezona:"))
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().Contains("Winter"))
                    {
                        e.CellStyle.BackColor = Color.DodgerBlue;
                    }
                    else if (e.Value.ToString().Contains("Spring"))
                    {
                        e.CellStyle.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void tbSearchMatches_TextChanged(object sender, EventArgs e)
        {
            FillMatchGrid();
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            if (new NewMatchForm(seasonId).ShowDialog() == DialogResult.Cancel)
            {
                FillMatchGrid();
            }
        }

        private void btnUpdateMatch_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvMatches.SelectedRows[0];

            // Provjera formata:
            if (!selectedRow.Cells[0].Value.ToString().Equals("Bo1") &&
                !selectedRow.Cells[0].Value.ToString().Equals("Bo3") &&
                !selectedRow.Cells[0].Value.ToString().Equals("Bo5"))
            {
                string text = Language.Equals("srb") ? "Uneseni format ne postoji. Dozvoljeni formati su: " +
                    "Bo1 Bo3 i Bo5" : "Format does not exist. Allowed formats are: Bo1, Bo3 and Bo5";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Provjera da li unesena faza postoji u sezoni:
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            string phaseName = selectedRow.Cells[6].Value.ToString().Trim();
            int findPhaseResult = DBUtil.CheckIfPhaseAlreadyExists(phaseName, seasonId);
            int phaseId = 0;
            // Ukoliko nije pronašlo nijednu fazu pod tim imenom, onda ona ne postoji:
            if (findPhaseResult == 0)
            {
                string text = Language.Equals("srb") ? "Unesena faza ne postoji. Kreirajte željenu " +
                    "fazu prije unošenja." : "Phase does not exits. If you want a new phase, click Create" +
                    "button";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Ukoliko je pronašlo fazu, vraća njen ID kako bi se moglo izvršiti ažuriranje:
                phaseId = findPhaseResult;
            }

            // SVE OSTALO PROVJERAVAJU TRIGGERI

            try
            {
                // Unos u bazu podataka:
                DBUtil.UpdateMatch(new Match()
                {
                    MatchId = (selectedRow.Tag as Match).MatchId,
                    Format = selectedRow.Cells[0].Value.ToString(),
                    Team1 = selectedRow.Cells[1].Value.ToString(),
                    Result = selectedRow.Cells[2].Value.ToString(),
                    Team2 = selectedRow.Cells[3].Value.ToString(),
                    Date = DateTime.Parse(selectedRow.Cells[4].Value.ToString()),
                    Location = selectedRow.Cells[5].Value.ToString(),
                    Phase = new Phase()
                    {
                        PhaseName = phaseName,
                        PhaseId = phaseId,
                        Season = new Season()
                        {
                            SeasonId = seasonId,
                            Split = (comboSeasons.SelectedItem as Season).Split,
                            Year = (comboSeasons.SelectedItem as Season).Year
                        }
                    }
                });
                // Nakon ažuriranja baze, resetujemo DataGridView i zatvaramo prozor
                FillMatchGrid();
            }
            catch (Exception ex)
            {
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(ex.Message, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteMatch_Click(object sender, EventArgs e)
        {
            if (dgvMatches.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije odabran nijedan red." : "You haven't chosen " +
                    "a row.";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow row = dgvMatches.SelectedRows[0];
                var match = row.Tag as Match;
                if (match != null)
                {
                    DBUtil.DeleteMatchById(match.MatchId);
                }
                dgvMatches.Rows.Remove(row);
                FillMatchGrid();
            }
        }

        private void cmsMatchesEdit_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                dgvMatches.CurrentCell = rightClickedCell;
                dgvMatches.BeginEdit(true);

                // Resetovanje:
                rightClickedCell = null;
            }
        }

        private void dgvMatches_MouseDown(object sender, MouseEventArgs e)
        {
            // Provjera da li se radi o desnom kliku na mišu:
            if (e.Button == MouseButtons.Right)
            {
                // Dobijanje kliknute ćelije:
                var hitTestInfo = dgvMatches.HitTest(e.X, e.Y);

                // Provjera da li je ono što je kliknuto ćelija:
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    rightClickedCell = dgvMatches.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                }
            }
        }

        private void btnAddPhase_Click(object sender, EventArgs e)
        {
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            if (new AddPhaseFrom(seasonId).ShowDialog() == DialogResult.Cancel)
            {
                FillPhaseGrid();
            }
        }

        private void dgvPhases_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgvPhases.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    rightClickedCell = dgvPhases.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                }
            }
        }

        private void cmsPhasesEdit_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                dgvPhases.CurrentCell = rightClickedCell;
                dgvPhases.BeginEdit(true);

                // Resetovanje:
                rightClickedCell = null;
            }
        }

        private void btnUpdatePhase_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvPhases.SelectedRows[0];

                // Provjera da li je naziv faze u redu:
                string phaseName = selectedRow.Cells[0].Value.ToString();
                int phaseId = (selectedRow.Tag as Phase).PhaseId;
                int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;

                // Ukoliko je već neka faza u sezoni pod istim imenom, prijavljuje se greška:
                // Takođe, ne računa se faza koju trenutno ažuriramo:
                int checkPhaseResult = DBUtil.CheckIfPhaseAlreadyExists(phaseName, seasonId);
                if (checkPhaseResult != 0 && checkPhaseResult != phaseId)
                {
                    string text = Language.Equals("srb") ? "Unesena faza već postoji." : "Phase already " +
                        "exists";
                    string prompt = Language.Equals("srb") ? "Greška" : "Error";
                    MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ukoliko nije, ažuriramo bazu: 
                DBUtil.UpdatePhase(new Phase()
                {
                    PhaseId = phaseId,
                    PhaseName = phaseName,
                    StartDate = DateTime.Parse(selectedRow.Cells[1].Value.ToString()),
                    EndDate = DateTime.Parse(selectedRow.Cells[2].Value.ToString()),
                    Season = new Season()
                    {
                        SeasonId = seasonId,
                        Split = (comboSeasons.SelectedItem as Season).Split,
                        Year = (comboSeasons.SelectedItem as Season).Year
                    }
                });
                FillPhaseGrid();
            }
            catch (IOException ex)
            {
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(ex.Message, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletePhase_Click(object sender, EventArgs e)
        {
            if (dgvPhases.SelectedRows.Count == 0)
            {
                string text1 = Language.Equals("srb") ? "Nije odabrana nijedna faza." : "You haven't chosen a" +
                    " phase.";
                string prompt1 = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text1, prompt1, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string text = Language.Equals("srb") ? "Ukoliko obrišete ovu fazu, brišu se i svi mečevi " +
                "odigrani u toj fazi. Da li pristajete?" : "If you delete this phase, all matches played " +
                "in that phase will also be deleted. Do you want to proceed?";
            string prompt = Language.Equals("srb") ? "Upozorenje" : "Warning";
            if (MessageBox.Show(text, prompt, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dgvPhases.SelectedRows[0];
                var phase = (selectedRow.Tag as Phase);
                DBUtil.DeletePhaseById(phase);
                dgvPhases.Rows.Remove(selectedRow);
                // Ažuriranje tabele za mečeve: 
                FillMatchGrid();
            }
        }

        private void dgvTeamsPlacement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Provjera da li smo kliknuli na ćeliju iz kolone tipa DataGridViewLinkColumn:
            if ((dgvTeamsPlacement.Columns[e.ColumnIndex].HeaderText.Equals("Naziv tima:") ||
                dgvTeamsPlacement.Columns[e.ColumnIndex].HeaderText.Equals("Team name:"))
                && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Popunjavanje info panela:
                string teamName = dgvTeamsPlacement.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Team team = DBUtil.GetTeamInfo(teamName);
                MemoryStream ms = new MemoryStream(DBUtil.FindTeamPicture(teamName));
                pbTeamLogo.Image = Image.FromStream(ms);
                lbTeamName.Text = team.Name;
                if (Language.Equals("en"))
                {
                    lbYearOfEstablishment.Text = $"Year Est.: {team.YearOfEstablishment}";
                    lbCountry.Text = $"Country: {team.Country}";
                }
                else
                {
                    lbYearOfEstablishment.Text = $"Godina: {team.YearOfEstablishment}";
                    lbCountry.Text = $"Država: {team.Country}";
                }

                // Popunjavanje DataGridView-a sa igračima: 
                int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
                FillTeamPlayersGrid(seasonId, teamName);
            }
        }

        private void btnAddPlayerForTeam_Click(object sender, EventArgs e)
        {
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            if (new AddPlayerToTheTeamForm(lbTeamName.Text.Trim(),
                seasonId).ShowDialog() == DialogResult.Cancel)
            {
                FillTeamPlayersGrid(seasonId, lbTeamName.Text.Trim());
            }
        }

        private void btnPlayerInfo_Click(object sender, EventArgs e)
        {
            if (dgvTeamPlayers.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije odabran nijedan igrač." : "You haven't chosen a" +
                    " player.";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow row = dgvTeamPlayers.SelectedRows[0];
                string inGameId = row.Cells[0].Value.ToString();
                if (new PlayerInfoForm(inGameId, false).ShowDialog() == DialogResult.Cancel)
                {
                    int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
                    FillTeamPlayersGrid(seasonId, lbTeamName.Text.Trim());
                }
            }
        }

        private void btnDeletePlayerForTeam_Click(object sender, EventArgs e)
        {
            if (dgvTeamPlayers.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije odabran nijedan igrač." : "You haven't chosen a" +
                    " player.";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow selectedRow = dgvTeamPlayers.SelectedRows[0];
                if (selectedRow != null)
                {
                    var playerAtTheTime = selectedRow.Tag as Player;
                    if (playerAtTheTime != null)
                    {
                        DBUtil.DeletePastTeamsForPlayer(playerAtTheTime.InGameId);
                    }
                    dgvTeamPlayers.Rows.Remove(selectedRow);
                    int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
                    FillTeamPlayersGrid(seasonId, lbTeamName.Text.Trim());
                }
            }
        }

        private void btnAddPlacement_Click(object sender, EventArgs e)
        {
            int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
            if (new RegisterTeamForSeason(seasonId).ShowDialog() == DialogResult.Cancel)
            {
                FillTeamsGrid();
            }
        }

        private void btnDeletePlacement_Click(object sender, EventArgs e)
        {
            if (dgvTeamsPlacement.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije odabran nijedan tim." : "You haven't chosen a" +
                    " team.";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string text = Language.Equals("srb") ? "Ukoliko obrišete učešće ovog tima u sezoni, obrisaće se i svi " +
                    "mečevi tog tima za istu sezonu, kao i evidencija o igračima koji su za njega " +
                    "nastupali. Da li želite da nastavite?" : "If you delete the team from this season, " +
                    "all matches the selected team has played in, including the player evidence for that " +
                    "season will also be deleted. Do you want to proceed?";
                string prompt = Language.Equals("srb") ? "Upozorenje" : "Warning";
                if (MessageBox.Show(text, prompt, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dgvTeamsPlacement.SelectedRows[0];
                    var team = selectedRow.Tag as TeamPlacement;
                    int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
                    if (team != null)
                    {
                        DBUtil.DeleteTeamForSeason(team.TeamName, seasonId);
                    }
                    dgvTeamsPlacement.Rows.Remove(selectedRow);
                    FillTeamsGrid();
                }
            }
        }

        private void dgvTeamsPlacement_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgvTeamsPlacement.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    rightClickedCell = dgvTeamsPlacement.Rows[hitTestInfo.RowIndex].Cells[0];
                }
            }
        }

        private void cmsTeamPlacementsEdit_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                dgvTeamsPlacement.CurrentCell = rightClickedCell;
                dgvTeamsPlacement.BeginEdit(true);

                // Resetovanje:
                rightClickedCell = null;
            }
        }

        private void btnUpdatePlacement_Click(object sender, EventArgs e)
        {
            try
            {
                string teamName = dgvTeamsPlacement.SelectedRows[0].Cells[1].Value.ToString();
                int seasonId = (comboSeasons.SelectedItem as Season).SeasonId;
                int placement = Convert.ToInt32(dgvTeamsPlacement.SelectedRows[0].Cells[0].Value.ToString());
                DBUtil.UpdateTeamForSeason(teamName, seasonId, placement);
                FillTeamsGrid();
            }
            catch (Exception ex)
            {
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(ex.Message, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSeason_Click(object sender, EventArgs e)
        {
            if (new AddSeasonForm().ShowDialog() == DialogResult.Cancel)
            {
                comboSeasons.DataSource = DBUtil.GetSeasons();
                comboSeasons.DisplayMember = "Display";
            }
        }

        private void comboSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCurrentTab();
        }
        private void tabUserForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCurrentTab();
        }

        private void RefreshCurrentTab()
        {
            if (tabUserForm.SelectedTab.Text.Equals("Mečevi"))
            {
                tbFilter.Enabled = true;
                FillMatchGrid();
            }
            else if (tabUserForm.SelectedTab.Text.Equals("Faze"))
            {
                tbFilter.Enabled = false;
                FillPhaseGrid();
            }
            else if (tabUserForm.SelectedTab.Text.Equals("Učesnici"))
            {
                tbFilter.Enabled = false;
                FillTeamsGrid();
            }
        }

        private void dgvAllTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvAllTeams.Rows[e.RowIndex];
            if (selectedRow != null)
            {
                lbTeamNameTabTeams.Text = (selectedRow.Tag as Team).Name.ToString();
                MemoryStream ms = new MemoryStream((selectedRow.Tag as Team).Picture);
                pbTeamLogoTeamsTab.Image = Image.FromStream(ms);

                // Popunjavanje DGV za titule: 
                FillTitlesGrid((selectedRow.Tag as Team).Name);
                btnAddTitle.Enabled = true;
                btnUpdateTitle.Enabled = true;
                btnDeleteTitle.Enabled = true;
            }
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            if (dgvAllTeams.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabran nijedan tim." : "You haven't chosen a " +
                    "team";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvAllTeams.SelectedRows[0];
            string teamName = selectedRow.Cells[0].Value.ToString();
            if (new AddTitleForm(teamName).ShowDialog() == DialogResult.Cancel)
            {
                FillTitlesGrid(teamName);
            }
        }

        private void dgvTitles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgvTitles.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    rightClickedCell = dgvTitles.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                }
            }
        }

        private void cmsTitlesEdit_Click(object sender, EventArgs e)
        {
            if (rightClickedCell != null)
            {
                dgvTitles.CurrentCell = rightClickedCell;
                dgvTitles.BeginEdit(true);

                // Resetovanje:
                rightClickedCell = null;
            }
        }

        private void btnUpdateTitle_Click(object sender, EventArgs e)
        {
            if (dgvTitles.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabrana nijedna titula." : "You haven't chosen a " +
                    "title";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DBUtil.UpdateTitle(new Title()
                {
                    TitleId = (dgvTitles.SelectedRows[0].Tag as Title).TitleId,
                    YearWon = Convert.ToInt32(dgvTitles.SelectedRows[0].Cells[1].Value.ToString()),
                    Name = dgvTitles.SelectedRows[0].Cells[0].Value.ToString(),
                    TeamName = dgvAllTeams.SelectedRows[0].Cells[0].Value.ToString()
                });
                FillTitlesGrid(dgvAllTeams.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(ex.Message, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTitle_Click(object sender, EventArgs e)
        {
            if (dgvTitles.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabrana nijedna titula." : "You haven't chosen a " +
                    "title";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow selectedRow = dgvTitles.SelectedRows[0];
                var title = selectedRow.Tag as Title;
                DBUtil.DeleteTitleById(title.TitleId);
                dgvTitles.Rows.Remove(selectedRow);
                FillTitlesGrid(dgvAllTeams.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void dgvAllTeams_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgvAllTeams.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    rightClickedCell = dgvAllTeams.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                }
            }
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            if (new AddTeamForm(false).ShowDialog() == DialogResult.Cancel)
            {
                FillAllTeamsGrid();
            }
        }

        private void btnUpdateTeam_Click(object sender, EventArgs e)
        {
            if (dgvAllTeams.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabran nijedan tim." : "You haven't chosen a " +
                     "team";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var team = dgvAllTeams.SelectedRows[0].Tag as Team;
                AddTeamForm updateTeam = new AddTeamForm(true);
                updateTeam.SetValuesForUpdate(team);
                if (updateTeam.ShowDialog() == DialogResult.Cancel)
                {
                    FillAllTeamsGrid();
                }
            }
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (dgvAllTeams.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabran nijedan tim." : "You haven't chosen a " +
                    "team";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string text = Language.Equals("srb") ? "Ukoliko obrišete ovaj tim, biće obrisani svi mečevi " +
                    "u kojima se taj tim pojavio, svi igrači koji su u nekom periodu igrali za taj tim, kao " +
                    "i titule za odbran tim. Da li zaista želite da ga obrišete?" : "If you delete the chosen " +
                    "team, all matches the team has played in, players that played for the team and titles " +
                    "that the team has won will also be deleted. Do you still want to proceed?";
                string prompt = Language.Equals("srb") ? "Upozorenje" : "Warning";
                if (MessageBox.Show(text, prompt, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dgvAllTeams.SelectedRows[0];
                    var team = selectedRow.Tag as Team;
                    DBUtil.DeleteTeamByName(team.Name);
                    dgvAllTeams.Rows.Remove(selectedRow);
                    FillAllTeamsGrid();
                }
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (new PlayerInfoForm(null, true).ShowDialog() == DialogResult.Cancel)
            {
                FillAllPlayersGrid();
            }
        }

        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            if (dgvAllPlayers.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabran nijedan igrač." : "You haven't chosen a " +
                    "player";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string inGameId = (dgvAllPlayers.SelectedRows[0].Tag as Player).InGameId;
                if (new PlayerInfoForm(inGameId, false).ShowDialog() == DialogResult.Cancel)
                {
                    FillAllPlayersGrid();
                }
            }
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            if (dgvAllPlayers.SelectedRows.Count == 0)
            {
                string text = Language.Equals("srb") ? "Nije izabran nijedan igrač." : "You haven't chosen a " +
                    "player";
                string prompt = Language.Equals("srb") ? "Greška" : "Error";
                MessageBox.Show(text, prompt, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow selectedRow = dgvAllPlayers.SelectedRows[0];
                var player = selectedRow.Tag as Player;
                DBUtil.DeletePlayerById(player.InGameId);
                dgvAllPlayers.Rows.Remove(selectedRow);
                FillAllPlayersGrid();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            string text = Language.Equals("srb") ? "Da li zaista želite da se odjavite?" :
                "Do you really want to logout?";
            string prompt = Language.Equals("srb") ? "Potvrda" : "Confirmation";
            if (MessageBox.Show(text, prompt, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timerUserForm_Tick(object sender, EventArgs e)
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

        private void tsmiLanguageEnglish_Click(object sender, EventArgs e)
        {
            if (!Language.Equals("en"))
            {
                Language = "en";
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);

                // Prebacivanje kontrola na engleski:
                this.Controls.Clear();
                InitializeComponent();
                comboSeasons.DataSource = DBUtil.GetSeasons();
                comboSeasons.DisplayMember = "Display";
                FillMatchGrid();
                FillPhaseGrid();
                FillTeamsGrid();
                FillAllTeamsGrid();
                FillAllPlayersGrid();
                lbDateTime.Text = DateTime.Now.ToString();

                SetTheme();

                // Ažuriranje baze podataka:
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
            else
            {
                tsmiLanguageEnglish.Checked = true;
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
                comboSeasons.DataSource = DBUtil.GetSeasons();
                comboSeasons.DisplayMember = "Display";
                FillMatchGrid();
                FillPhaseGrid();
                FillTeamsGrid();
                FillAllTeamsGrid();
                FillAllPlayersGrid();
                lbDateTime.Text = DateTime.Now.ToString();

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
                DBUtil.UpdateThemeForAccount(this.Username, Background + "," + Language + "," + TimeFormat);
            }
        }

        private void tsmiStyleDark_Click(object sender, EventArgs e)
        {
            if (!Background.Equals("Dark"))
            {
                Background = "Dark";
                SetTheme();
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
