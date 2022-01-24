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
    public partial class Autentificare : Form
    {

        Acasa mainForm = new Acasa();
        public Autentificare()
        {
            InitializeComponent();
        }
        private void buttonInainte_Click(object sender, EventArgs e)
        {
            verifyAndOpenMainForm();
        }
        private void buttonInainte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                verifyAndOpenMainForm();
            }
        }
        private void textBoxParola_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                verifyAndOpenMainForm();
            }
        }
        private void verifyAndOpenMainForm()
        {
            if (textBoxUtilizator.Text.Length == 0 || textBoxParola.Text.Length == 0)
            {
                MessageBox.Show("Campurile UTILIZATOR si PAROLA trebuie completate!");
            }
            else
            {
                if (textBoxUtilizator.Text == "admin" && textBoxParola.Text == "admin")
                {
                    this.Hide();
                    mainForm.Closed += (s, args) => this.Close();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Nume de utilizator sau parola gresita!");
                }
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void Autentificare_Paint(object sender, PaintEventArgs e)
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
