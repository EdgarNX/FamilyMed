namespace FamilyMed
{
    partial class Autentificare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autentificare));
            this.labelUtilizator = new System.Windows.Forms.Label();
            this.labelParola = new System.Windows.Forms.Label();
            this.textBoxUtilizator = new System.Windows.Forms.TextBox();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.labelAutentificare = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonInainte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUtilizator
            // 
            this.labelUtilizator.AutoSize = true;
            this.labelUtilizator.BackColor = System.Drawing.Color.Transparent;
            this.labelUtilizator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUtilizator.Location = new System.Drawing.Point(50, 125);
            this.labelUtilizator.Name = "labelUtilizator";
            this.labelUtilizator.Size = new System.Drawing.Size(112, 29);
            this.labelUtilizator.TabIndex = 0;
            this.labelUtilizator.Text = "Utilizator:";
            // 
            // labelParola
            // 
            this.labelParola.AutoSize = true;
            this.labelParola.BackColor = System.Drawing.Color.Transparent;
            this.labelParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParola.Location = new System.Drawing.Point(73, 225);
            this.labelParola.Name = "labelParola";
            this.labelParola.Size = new System.Drawing.Size(89, 29);
            this.labelParola.TabIndex = 1;
            this.labelParola.Text = "Parola:";
            // 
            // textBoxUtilizator
            // 
            this.textBoxUtilizator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUtilizator.Location = new System.Drawing.Point(200, 125);
            this.textBoxUtilizator.Name = "textBoxUtilizator";
            this.textBoxUtilizator.Size = new System.Drawing.Size(233, 34);
            this.textBoxUtilizator.TabIndex = 2;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParola.Location = new System.Drawing.Point(200, 225);
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.PasswordChar = '*';
            this.textBoxParola.Size = new System.Drawing.Size(233, 34);
            this.textBoxParola.TabIndex = 3;
            this.textBoxParola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxParola_KeyPress);
            // 
            // labelAutentificare
            // 
            this.labelAutentificare.AutoSize = true;
            this.labelAutentificare.BackColor = System.Drawing.Color.Transparent;
            this.labelAutentificare.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutentificare.Location = new System.Drawing.Point(221, 48);
            this.labelAutentificare.Name = "labelAutentificare";
            this.labelAutentificare.Size = new System.Drawing.Size(194, 36);
            this.labelAutentificare.TabIndex = 4;
            this.labelAutentificare.Text = "Autentificare";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(394, 285);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonInainte
            // 
            this.buttonInainte.BackColor = System.Drawing.Color.Aquamarine;
            this.buttonInainte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInainte.Location = new System.Drawing.Point(254, 316);
            this.buttonInainte.Name = "buttonInainte";
            this.buttonInainte.Size = new System.Drawing.Size(123, 41);
            this.buttonInainte.TabIndex = 7;
            this.buttonInainte.Text = "Inainte";
            this.buttonInainte.UseVisualStyleBackColor = false;
            this.buttonInainte.Click += new System.EventHandler(this.buttonInainte_Click);
            this.buttonInainte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonInainte_KeyPress);
            // 
            // Autentificare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 413);
            this.Controls.Add(this.buttonInainte);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelAutentificare);
            this.Controls.Add(this.textBoxParola);
            this.Controls.Add(this.textBoxUtilizator);
            this.Controls.Add(this.labelParola);
            this.Controls.Add(this.labelUtilizator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Autentificare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificare";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Autentificare_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUtilizator;
        private System.Windows.Forms.Label labelParola;
        private System.Windows.Forms.TextBox textBoxUtilizator;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.Label labelAutentificare;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonInainte;
    }
}