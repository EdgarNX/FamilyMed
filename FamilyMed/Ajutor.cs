using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyMed
{
    public partial class Ajutor : Form
    {
        public Ajutor()
        {
            InitializeComponent();
        }

        private void Ajutor_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.Aquamarine,
                                                               Color.White,
                                                               90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Ajutor_Load(object sender, EventArgs e)
        {
            labelAjutorPacienti.Text = "In sectiunea de Pacienti, urmatoarele activitati sunt posibile: adaugare, stergere, modificare, afisare;";
            labelAjutorBoli.Text = "In sectiunea de Boli, urmatoarele activitati sunt posibile: adaugare, stergere, modificare, afisare;";
            labelAjutorTratamente.Text = "In sectiunea de Tratamente, urmatoarele activitati sunt posibile: adaugare, stergere, modificare, afisare;";
            labelAjutorCelendar.Text = "In sectiunea de Calendar, se pot face programari cu pacientii si se pot adauga evenimente.";
        }
    }
}
