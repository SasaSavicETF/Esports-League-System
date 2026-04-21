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
    public partial class AddPhaseFrom : Form
    {
        private int SeasonId;
        public AddPhaseFrom(int seasonId)
        {
            InitializeComponent();
            SeasonId = seasonId;
            lbSeason.Text = DBUtil.FindSeasonById(SeasonId);

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

        private void tbPhaseName_TextChanged(object sender, EventArgs e)
        {
            if (tbPhaseName.Text != null)
            {
                if (DBUtil.CheckIfPhaseAlreadyExists(tbPhaseName.Text.Trim(), SeasonId) != 0)
                {
                    if (UserForm.Language.Equals("srb"))
                    {
                        MessageBox.Show("Unesena faza već postoji za ovu sezonu.", "Greška", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("The phase you entered already exists for this season.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPhaseName.Text.Trim().Equals(""))
                {
                    if (UserForm.Language.Equals("srb"))
                    {
                        MessageBox.Show("Polje za naziv faze je prazno.", "Greška", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Phase Name field is empty.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                DBUtil.InsertPhase(new Phase()
                {
                    PhaseName = tbPhaseName.Text.Trim(),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Season = new Season()
                    {
                        SeasonId = SeasonId
                    }
                });
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
