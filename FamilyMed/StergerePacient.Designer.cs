namespace FamilyMed
{
    partial class StergerePacient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StergerePacient));
            this.pictureBoxCNP = new System.Windows.Forms.PictureBox();
            this.buttonInainte = new System.Windows.Forms.Button();
            this.textBoxCNP = new System.Windows.Forms.TextBox();
            this.labelCNP = new System.Windows.Forms.Label();
            this.labelDatePacienti = new System.Windows.Forms.Label();
            this.toolTipGeneral = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCNP)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCNP
            // 
            this.pictureBoxCNP.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCNP.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBoxCNP.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCNP.Image")));
            this.pictureBoxCNP.Location = new System.Drawing.Point(436, 108);
            this.pictureBoxCNP.Name = "pictureBoxCNP";
            this.pictureBoxCNP.Size = new System.Drawing.Size(55, 34);
            this.pictureBoxCNP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCNP.TabIndex = 40;
            this.pictureBoxCNP.TabStop = false;
            this.pictureBoxCNP.Visible = false;
            // 
            // buttonInainte
            // 
            this.buttonInainte.BackColor = System.Drawing.Color.Aquamarine;
            this.buttonInainte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInainte.Location = new System.Drawing.Point(248, 188);
            this.buttonInainte.Name = "buttonInainte";
            this.buttonInainte.Size = new System.Drawing.Size(123, 41);
            this.buttonInainte.TabIndex = 39;
            this.buttonInainte.Text = "Stergere";
            this.buttonInainte.UseVisualStyleBackColor = false;
            this.buttonInainte.Click += new System.EventHandler(this.buttonInainte_Click);
            // 
            // textBoxCNP
            // 
            this.textBoxCNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCNP.Location = new System.Drawing.Point(197, 108);
            this.textBoxCNP.Name = "textBoxCNP";
            this.textBoxCNP.Size = new System.Drawing.Size(233, 34);
            this.textBoxCNP.TabIndex = 38;
            this.textBoxCNP.MouseHover += new System.EventHandler(this.textBoxCNP_MouseHover);
            // 
            // labelCNP
            // 
            this.labelCNP.AutoSize = true;
            this.labelCNP.BackColor = System.Drawing.Color.Transparent;
            this.labelCNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCNP.Location = new System.Drawing.Point(104, 111);
            this.labelCNP.Name = "labelCNP";
            this.labelCNP.Size = new System.Drawing.Size(70, 29);
            this.labelCNP.TabIndex = 37;
            this.labelCNP.Text = "CNP:";
            // 
            // labelDatePacienti
            // 
            this.labelDatePacienti.AutoSize = true;
            this.labelDatePacienti.BackColor = System.Drawing.Color.Transparent;
            this.labelDatePacienti.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatePacienti.Location = new System.Drawing.Point(216, 33);
            this.labelDatePacienti.Name = "labelDatePacienti";
            this.labelDatePacienti.Size = new System.Drawing.Size(195, 36);
            this.labelDatePacienti.TabIndex = 41;
            this.labelDatePacienti.Text = "Date Pacient";
            // 
            // StergerePacient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 260);
            this.Controls.Add(this.labelDatePacienti);
            this.Controls.Add(this.pictureBoxCNP);
            this.Controls.Add(this.buttonInainte);
            this.Controls.Add(this.textBoxCNP);
            this.Controls.Add(this.labelCNP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StergerePacient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stergere Pacient";
            this.Load += new System.EventHandler(this.StergerePacient_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StergerePacient_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCNP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCNP;
        private System.Windows.Forms.Button buttonInainte;
        private System.Windows.Forms.TextBox textBoxCNP;
        private System.Windows.Forms.Label labelCNP;
        private System.Windows.Forms.Label labelDatePacienti;
        private System.Windows.Forms.ToolTip toolTipGeneral;
    }
}