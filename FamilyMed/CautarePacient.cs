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

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace FamilyMed
{
    public partial class CautarePacient : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "uqAijVuxmGKZXy2G79A9eADyjInVZ1NgEDQLmI1p",
            BasePath = "https://familymed-297e1-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        IFirebaseClient client;
        public CautarePacient()
        {
            InitializeComponent();
        }

        private void CautarePacient_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.Aquamarine,
                                                               Color.White,
                                                               90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
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
            FirebaseResponse response = await client.GetTaskAsync("Pacienti/" + textBoxCNP.Text);

            if (response.Body != "null")
            {
                Data obj = response.ResultAs<Data>();

                if (obj.CNP == textBoxCNP.Text)
                {
                    labelNumePacient.Text = obj.Nume;
                    labelPrenumePacient.Text = obj.Prenume;
                    labelCNPPacient.Text = obj.CNP;
                    labelAdresaPacient.Text = obj.Adresa;
                    labelTelefonPacient.Text = obj.Telefon;
                    labelEmailPacienti.Text = obj.Email;
                    labelSexPacienti.Text = obj.Sex;
                    labelDataPacienti.Text = obj.DataNasterii;
                    labelInaltimePacienti.Text = obj.Inaltime;
                    labelGreutatePacienti.Text = obj.Greutate;
                    labelAlergiPacienti.Text = obj.Alergii;
                    labelBoliPacienti.Text = obj.Boli;
                }
                else
                {
                    MessageBox.Show("Pacientul nu exista in baza de date!");
                }
            }
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

        private void pictureBoxCNP_MouseHover(object sender, EventArgs e)
        {
            toolTipGeneral.Show("CNP-ul pacientului trebuie sa contina 13 caractere!", pictureBoxCNP);
        }

        private void CautarePacient_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
    }
}
