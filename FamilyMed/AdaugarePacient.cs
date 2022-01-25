using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace FamilyMed
{
    public partial class AdaugarePacient : Form
    {
        private bool dateChanged = false;

        private String sex;
        private String dataNasterii;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "uqAijVuxmGKZXy2G79A9eADyjInVZ1NgEDQLmI1p",
            BasePath = "https://familymed-297e1-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        IFirebaseClient client;
        private object numar;
        private string nrPacientiMinori = Acasa.nrPacientiMinori;
        private string nrPacientiTotal = Acasa.nrPacientiTotal;
        private string nrPacientiAdulti = Acasa.nrPacientiAdulti;

        public AdaugarePacient()
        {
            InitializeComponent();
        }

        private async void buttonInainte_Click(object sender, EventArgs e)
        {

            if (checkFields())
            {
                var data = new Data
                {
                    Nume = textBoxNume.Text,
                    Prenume = textBoxPrenume.Text,
                    CNP = textBoxCNP.Text,
                    Adresa = textBoxAdresa.Text,
                    Telefon = textBoxTelefon.Text,
                    Email = textBoxEmail.Text,
                    Sex = sex,
                    DataNasterii = dataNasterii,
                    Inaltime = textBoxInaltime.Text,
                    Greutate = textBoxGreutate.Text,
                    Alergii = textBoxAlergii.Text,
                    Boli = textBoxBoli.Text
                };

                if(CompareDates() < 6575)
                {
                    numar = new NumarPacienti
                    {
                        NumarTotal = (Int32.Parse(nrPacientiTotal) + 1).ToString(),
                        NumarAdulti = nrPacientiAdulti,
                        NumarMinori = (Int32.Parse(nrPacientiMinori) + 1).ToString()
                    };
                }
                else
                {
                    numar = new NumarPacienti
                    {
                        NumarTotal = (Int32.Parse(nrPacientiTotal) + 1).ToString(),
                        NumarAdulti = (Int32.Parse(nrPacientiAdulti) + 1).ToString(),
                        NumarMinori = nrPacientiMinori
                    };
                }

                FirebaseResponse responseNr = await client.UpdateTaskAsync("NumarPacienti", numar);
                NumarPacienti resultNr = responseNr.ResultAs<NumarPacienti>();

                

                SetResponse response = await client.SetTaskAsync("Pacienti/"+textBoxCNP.Text,data);
                Data result = response.ResultAs<Data>();

                MessageBox.Show("Pacient salvat in baza de date!");

                deleteFields();  
                extractNumarPacienti();
            }
        }

        private async void extractNumarPacienti()
        {
            FirebaseResponse response = await client.GetTaskAsync("NumarPacienti");
            NumarPacienti nrPac = response.ResultAs<NumarPacienti>();

            nrPacientiTotal = nrPac.NumarTotal;
            nrPacientiMinori = nrPac.NumarMinori;
            nrPacientiAdulti = nrPac.NumarAdulti;

            Acasa.nrPacientiMinori = nrPac.NumarMinori;
            Acasa.nrPacientiTotal = nrPac.NumarTotal;
            Acasa.nrPacientiAdulti = nrPac.NumarAdulti;
        }

        private int CompareDates()
        {
            DateTime dataNasteriiPacient = dateTimePickerData.Value.Date;
            DateTime todaysDate = DateTime.Today;

            double res = (todaysDate - dataNasteriiPacient).TotalDays;

            return (int)res;
        }

        private void deleteFields()
        {
            textBoxNume.Text = "";
            textBoxPrenume.Text = "";
            textBoxCNP.Text = "";
            textBoxAdresa.Text = "";
            textBoxTelefon.Text = "";
            textBoxEmail.Text = "";
            radioButtonSexF.Checked = false;
            radioButtonSexM.Checked = false;
            textBoxInaltime.Text = "";
            textBoxGreutate.Text = "";
            textBoxAlergii.Text = "";
            textBoxBoli.Text = "";
        }

        private void AdaugarePacient_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            extractNumarPacienti();
        }

        private bool checkFields()
        {
            //nume check
            if (textBoxNume.Text.Length == 0)
            {
                pictureBoxNume.Visible = true;
            }
            else
            {
                pictureBoxNume.Visible = false;
            }

            //prenume check
            if (textBoxPrenume.Text.Length == 0)
            {
                pictureBoxPrenume.Visible = true;
            }
            else
            {
                pictureBoxPrenume.Visible = false;
            }

            //CNP check
            if (textBoxCNP.Text.Length != 13 || !Regex.Match(textBoxCNP.Text, "^[0-9]").Success)
            {
                pictureBoxCNP.Visible = true;
            }
            else
            {
                pictureBoxCNP.Visible = false;
            }

            //adresa check
            if (textBoxAdresa.Text.Length == 0)
            {
                pictureBoxAdresa.Visible = true;
            }
            else
            {
                pictureBoxAdresa.Visible = false;
            }

            //telefon check
            if (textBoxTelefon.Text.Length != 10 || !Regex.Match(textBoxTelefon.Text, "^[0-9]").Success)
            {
                pictureBoxTelefon.Visible = true;
            }
            else
            {
                pictureBoxTelefon.Visible = false;
            }

            //sex check
            if (radioButtonSexM.Checked == false && radioButtonSexF.Checked == false)
            {
                pictureBoxSex.Visible = true;
            }
            else
            {
                pictureBoxSex.Visible = false;

                //set sex
                if (radioButtonSexF.Checked == true)
                {
                    sex = "F";
                }
                else
                {
                    sex = "M";
                }
            }

            //data nasterii check
            if (dateChanged != true)
            {
                pictureBoxDataNasterii.Visible = true;
            }
            else
            {
                pictureBoxDataNasterii.Visible = false;

                //set data nasterii
                dataNasterii = dateTimePickerData.Value.ToShortDateString();
            }

            //inaltime check
            if (textBoxInaltime.Text.Length == 0)
            {
                pictureBoxInaltime.Visible = true;
            }
            else
            {
                pictureBoxInaltime.Visible = false;
            }

            //greutate check
            if (textBoxGreutate.Text.Length == 0)
            {
                pictureBoxGreutate.Visible = true;
            }
            else
            {
                pictureBoxGreutate.Visible = false;
            }

            //check all
            if(pictureBoxNume.Visible || pictureBoxPrenume.Visible || pictureBoxCNP.Visible || pictureBoxAdresa.Visible || pictureBoxTelefon.Visible
                || pictureBoxSex.Visible || pictureBoxDataNasterii.Visible || pictureBoxInaltime.Visible || pictureBoxGreutate.Visible)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void pictureBoxNume_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Numele pacientului este obligatoriu!", pictureBoxNume);
        }

        private void pictureBoxPrenume_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Prenumele pacientului este obligatoriu!", pictureBoxPrenume);
        }

        private void pictureBoxCNP_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("CNP-ul pacientului este obligatoriu si trebuie sa contina 13 caractere!", pictureBoxCNP);
        }

        private void pictureBoxAdresa_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Adresa pacientului este obligatorie!", pictureBoxAdresa);
        }

        private void pictureBoxTelefon_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Numarul de telefon a pacientului este obligatoriu!", pictureBoxTelefon);
        }

        private void pictureBoxSex_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Sex-ul pacientului este obligatoriu!", pictureBoxSex);
        }

        private void pictureBoxDataNasterii_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Data dasterii a pacientului este obligatoriu!", pictureBoxDataNasterii);
        }

        private void pictureBoxInaltime_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Inaltimea pacientului este obligatoriu!", pictureBoxInaltime);
        }

        private void pictureBoxGreutate_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("Greutatea pacientului este obligatoriu!", pictureBoxGreutate);
        }

        private void dateTimePickerData_ValueChanged(object sender, EventArgs e)
        {
            dateChanged = true;
        }

        private void AdaugarePacient_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.Aquamarine,
                                                               Color.White,
                                                               90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
