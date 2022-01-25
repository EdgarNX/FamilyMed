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

        private async void buttonInainte_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                FirebaseResponse response = await client.DeleteTaskAsync("Pacienti/" + textBoxCNP.Text);

                MessageBox.Show("Pacient sters din baza de date!");

                extractNumarPacienti();
                deleteFields();
            }
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

        private void textBoxCNP_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("CNP-ul pacientului trebuie sa contina 13 caractere!", pictureBoxCNP);
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
    }
}
