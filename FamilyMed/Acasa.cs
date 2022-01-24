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
        AdaugarePacient adaugarePacient = new AdaugarePacient();

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

            //TODO: afiseaza aici numarul pacientilor

        }

        private async void countPatients()
        {
            FirebaseResponse response = await client.GetTaskAsync("Pacienti");
        }

        private void adugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
