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

namespace FamilyMed
{
    public partial class Acasa : Form
    {
        AdaugarePacient adaugarePacient;
        StergerePacient stergerePacient;
        CautarePacient cautarePacient;
        Ajutor ajutor;

        public static string nrPacientiTotal;
        public static string nrPacientiAdulti;
        public static string nrPacientiMinori;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "uqAijVuxmGKZXy2G79A9eADyjInVZ1NgEDQLmI1p",
            BasePath = "https://familymed-297e1-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        public Acasa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelData.Text = DateTime.Now.ToLongDateString();
            client = new FireSharp.FirebaseClient(config);

            extractNumarPacienti();
        }

        private async void extractNumarPacienti()
        {
            FirebaseResponse response = await client.GetTaskAsync("NumarPacienti");
            NumarPacienti nrPac = response.ResultAs<NumarPacienti>();

            nrPacientiTotal = nrPac.NumarTotal;
            nrPacientiAdulti = nrPac.NumarMinori;
            nrPacientiMinori = nrPac.NumarAdulti;

            //labelNrPacienti.Text = nrPac.NumarTotal;
            //labelNrPacientiSub18.Text = nrPac.NumarMinori;
            //labelNrPacientiPeste18.Text = nrPac.NumarAdulti;

            labelNrPacienti.Text = nrPacientiTotal;
            labelNrPacientiSub18.Text = nrPacientiMinori;
            labelNrPacientiPeste18.Text = nrPacientiAdulti;

        }

        private void adugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adaugarePacient = new AdaugarePacient();
            adaugarePacient.Show();
        }

        private void timerSecunda_Tick(object sender, EventArgs e)
        {
            labelTimp.Text = DateTime.Now.ToLongTimeString();
        }

        private void Acasa_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.Aquamarine,
                                                               Color.White,
                                                               90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stergerePacient = new StergerePacient();
            stergerePacient.Show();
        }

        private void cautareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cautarePacient = new CautarePacient();
            cautarePacient.Show();
        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ajutor = new Ajutor();
            ajutor.Show();
        }
    }
}
