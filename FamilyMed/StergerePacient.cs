using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyMed
{
    public partial class StergerePacient : Form
    {
        private string nrPacientiMinori = Acasa.nrPacientiMinori;
        private string nrPacientiTotal = Acasa.nrPacientiTotal;
        private string nrPacientiAdulti = Acasa.nrPacientiAdulti;
        private String dataNasterii;
        private object numar;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "uqAijVuxmGKZXy2G79A9eADyjInVZ1NgEDQLmI1p",
            BasePath = "https://familymed-297e1-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        IFirebaseClient client;
        public StergerePacient()
        {
            InitializeComponent();
        }

        private void buttonInainte_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                IsThereAPatient();
            }
        }
        private async void IsThereAPatient()
        {
            FirebaseResponse response = await client.GetTaskAsync("Pacienti/"+textBoxCNP.Text);

            //MessageBox.Show("1" + response.Body);
            //MessageBox.Show("11" + response.GetType());
            //MessageBox.Show("111" + response.Body.GetType());
            //MessageBox.Show("2" + response.ToString());
            //MessageBox.Show("3" + response.Body.ToString());


            if (response.Body != "null")
            {
                Data obj = response.ResultAs<Data>();

                if (obj.CNP == textBoxCNP.Text)
                {
                    dataNasterii = obj.DataNasterii;
                    deletePatient();
                }
                else
                {
                    MessageBox.Show("Pacientul nu exista in baza de date!");
                }
            }
        }

        private async void deletePatient()
        {
            if (CompareDates() < 6575)
            {
                numar = new NumarPacienti
                {
                    NumarTotal = (Int32.Parse(nrPacientiTotal) - 1).ToString(),
                    NumarAdulti = nrPacientiAdulti,
                    NumarMinori = (Int32.Parse(nrPacientiMinori) - 1).ToString()
                };
            }
            else
            {
                numar = new NumarPacienti
                {
                    NumarTotal = (Int32.Parse(nrPacientiTotal) - 1).ToString(),
                    NumarAdulti = (Int32.Parse(nrPacientiAdulti) - 1).ToString(),
                    NumarMinori = nrPacientiMinori
                };
            }

            FirebaseResponse responseNr = await client.UpdateTaskAsync("NumarPacienti", numar);
            NumarPacienti resultNr = responseNr.ResultAs<NumarPacienti>();

            FirebaseResponse response = await client.DeleteTaskAsync("Pacienti/" + textBoxCNP.Text);

            MessageBox.Show("Pacient sters din baza de date!");

            extractNumarPacienti();
            deleteFields();
        }

        private int CompareDates()
        {
            DateTime dataNasteriiPacient = DateTime.Parse(dataNasterii);
            DateTime todaysDate = DateTime.Today;

            double res = (todaysDate - dataNasteriiPacient).TotalDays;

            return (int)res;
        }

        private void deleteFields()
        {
            textBoxCNP.Text = "";
        }

        private void StergerePacient_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            extractNumarPacienti();
        }

        private bool checkFields()
        {
            //CNP check
            if (textBoxCNP.Text.Length != 13 || !Regex.Match(textBoxCNP.Text, "^[0-9]").Success)
            {
                pictureBoxCNP.Visible = true;
            }
            else
            {
                pictureBoxCNP.Visible = false;
            }

            //check all
            if (!pictureBoxCNP.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void StergerePacient_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                   Color.Aquamarine,
                                                   Color.White,
                                                   90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
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

        private void pictureBoxCNP_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("CNP-ul pacientului trebuie sa contina 13 caractere!", pictureBoxCNP);
        }
    }
}
