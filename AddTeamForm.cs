using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HCIProjekat1
{
    public partial class AddTeamForm : Form
    {
        private bool IsUpdate = false;
        private byte[] TeamLogoInBytes;
        public AddTeamForm(bool isUpdate)
        {
            InitializeComponent();
            IsUpdate = isUpdate;

            if (UserForm.Background.Equals("Spring"))
            {
                this.BackgroundImage = Properties.Resources.AddTeamFormSpring;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (UserForm.Background.Equals("Summer"))
            {
                this.BackgroundImage = Properties.Resources.AddTeamFormSummer;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.AddTeamFormDark;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public void SetValuesForUpdate(Team team)
        {
            // Isključujemo opciju mijenjanja imena tima zbog Infinite Loop-a:
            tbTeamName.Text = team.Name;
            tbTeamName.Enabled = false;
            // Isto vrijedi i za godinu osnivanja, iz logičnih razloga:
            tbYearOfEstablishment.Text = team.YearOfEstablishment.ToString();
            tbYearOfEstablishment.Enabled = false;

            tbCountry.Text = team.Country;
            MemoryStream ms = new MemoryStream(team.Picture);
            pbDisplayTeamPicture.Image = System.Drawing.Image.FromStream(ms);
            TeamLogoInBytes = ms.ToArray();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelPicture_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panelPicture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                HandleFile(files[0]);
                lbDragPictureHere.Visible = false;
                btnUploadPicture.Visible = false;
                lbPictureUploaded.Visible = true;
                btnCorrect.Visible = true;
                btnChangePicture.Visible = true;
            }
        }

        private void HandleFile(string filePath)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            TeamLogoInBytes = ms.ToArray();
            pbDisplayTeamPicture.Image = img;
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            if (ofdUploadPicture.ShowDialog() == DialogResult.OK)
            {
                HandleFile(ofdUploadPicture.FileName);
                lbDragPictureHere.Visible = false;
                btnUploadPicture.Visible = false;
                lbPictureUploaded.Visible = true;
                btnCorrect.Visible = true;
                btnChangePicture.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbTeamName.Text == null || tbYearOfEstablishment.Text == null || tbCountry.Text == null)
            {
                if(UserForm.Language.Equals("srb"))
                {
                    MessageBox.Show("Nisu sva obavezna polja popunjena.", "Greška", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                } else
                {
                    MessageBox.Show("Some fields are empty.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                
            }
            else
            {
                try
                {
                    if (!IsUpdate)
                    {
                        DBUtil.InsertTeam(new Team()
                        {
                            Name = tbTeamName.Text.Trim(),
                            YearOfEstablishment = Convert.ToInt32(tbYearOfEstablishment.Text.Trim()),
                            Country = tbCountry.Text.Trim(),
                            Picture = TeamLogoInBytes
                        });
                    }
                    else
                    {
                        DBUtil.UpdateTeam(new Team()
                        {
                            Name = tbTeamName.Text.Trim(),
                            YearOfEstablishment = Convert.ToInt32(tbYearOfEstablishment.Text.Trim()),
                            Country = tbCountry.Text.Trim(),
                            Picture = TeamLogoInBytes
                        });
                    }
                    this.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbTeamName_TextChanged(object sender, EventArgs e)
        {
            lbDisplayTeamName.Text = tbTeamName.Text.Trim();
        }
    }
}
