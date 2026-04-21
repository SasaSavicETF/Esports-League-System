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
    public partial class AddSeasonForm : Form
    {
        public AddSeasonForm()
        {
            InitializeComponent();

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int year;
            bool isCorrect = int.TryParse(tbEnterYear.Text, out year);
            if (isCorrect)
            {
                if (year < 2013 || year > 2050)
                {
                    if(UserForm.Language.Equals("srb"))
                    {
                        MessageBox.Show("Godina treba da bude u periodu od 2013-2050", "Greška",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else
                    {
                        MessageBox.Show("Year needs to be somewhere between 2013 to 2050", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            else
            {
                if (UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Neispravan tekst u polju za godinu.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else
                {
                    MessageBox.Show("Incorrect text in Year field.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    
            }
            if (comboSplits.SelectedItem == null)
            {
                if (UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Nisu sva polja popunjena.", "Greška", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                } else
                {
                    MessageBox.Show("Some fields are empty.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                    
            }

            try
            {
                DBUtil.InsertSeason(new Season()
                {
                    Year = Convert.ToInt32(tbEnterYear.Text.Trim()),
                    Split = comboSplits.SelectedItem.ToString()
                });
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
