namespace s100_tdm
{
    partial class FormEnroll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.textBoxRut = new System.Windows.Forms.TextBox();
            this.labelRut = new System.Windows.Forms.Label();
            this.textBoxNombres = new System.Windows.Forms.TextBox();
            this.labelNombres = new System.Windows.Forms.Label();
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerFecNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxEnrolar = new System.Windows.Forms.PictureBox();
            this.labelRespuesta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxRut
            // 
            this.textBoxRut.Location = new System.Drawing.Point(74, 9);
            this.textBoxRut.Name = "textBoxRut";
            this.textBoxRut.Size = new System.Drawing.Size(67, 22);
            this.textBoxRut.TabIndex = 8;
            // 
            // labelRut
            // 
            this.labelRut.Location = new System.Drawing.Point(7, 9);
            this.labelRut.Name = "labelRut";
            this.labelRut.Size = new System.Drawing.Size(50, 22);
            this.labelRut.Text = "Rut";
            // 
            // textBoxNombres
            // 
            this.textBoxNombres.Location = new System.Drawing.Point(74, 37);
            this.textBoxNombres.Name = "textBoxNombres";
            this.textBoxNombres.Size = new System.Drawing.Size(155, 22);
            this.textBoxNombres.TabIndex = 11;
            // 
            // labelNombres
            // 
            this.labelNombres.Location = new System.Drawing.Point(7, 37);
            this.labelNombres.Name = "labelNombres";
            this.labelNombres.Size = new System.Drawing.Size(61, 22);
            this.labelNombres.Text = "Nombres";
            // 
            // textBoxApellidos
            // 
            this.textBoxApellidos.Location = new System.Drawing.Point(74, 67);
            this.textBoxApellidos.Name = "textBoxApellidos";
            this.textBoxApellidos.Size = new System.Drawing.Size(155, 22);
            this.textBoxApellidos.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.Text = "Apellidos";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(74, 98);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(155, 22);
            this.textBoxEmail.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.Text = "Email";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(74, 129);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(155, 22);
            this.textBoxCodigo.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 22);
            this.label3.Text = "Código";
            // 
            // dateTimePickerFecNacimiento
            // 
            this.dateTimePickerFecNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecNacimiento.Location = new System.Drawing.Point(74, 163);
            this.dateTimePickerFecNacimiento.Name = "dateTimePickerFecNacimiento";
            this.dateTimePickerFecNacimiento.Size = new System.Drawing.Size(152, 23);
            this.dateTimePickerFecNacimiento.TabIndex = 22;
            this.dateTimePickerFecNacimiento.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 22);
            this.label4.Text = "Fec. Nac.";
            // 
            // pictureBoxEnrolar
            // 
            this.pictureBoxEnrolar.Location = new System.Drawing.Point(74, 192);
            this.pictureBoxEnrolar.Name = "pictureBoxEnrolar";
            this.pictureBoxEnrolar.Size = new System.Drawing.Size(80, 40);
            this.pictureBoxEnrolar.Click += new System.EventHandler(this.pictureBoxEnrolar_Click_1);
            // 
            // labelRespuesta
            // 
            this.labelRespuesta.Location = new System.Drawing.Point(9, 240);
            this.labelRespuesta.Name = "labelRespuesta";
            this.labelRespuesta.Size = new System.Drawing.Size(223, 22);
            this.labelRespuesta.Text = "Respuesta";
            // 
            // FormEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 280);
            this.Controls.Add(this.labelRespuesta);
            this.Controls.Add(this.pictureBoxEnrolar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerFecNacimiento);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxApellidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNombres);
            this.Controls.Add(this.labelNombres);
            this.Controls.Add(this.textBoxRut);
            this.Controls.Add(this.labelRut);
            this.Menu = this.mainMenu1;
            this.Name = "FormEnroll";
            this.Text = "FormEnroll";
            this.Load += new System.EventHandler(this.FormEnroll_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRut;
        private System.Windows.Forms.Label labelRut;
        private System.Windows.Forms.TextBox textBoxNombres;
        private System.Windows.Forms.Label labelNombres;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecNacimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxEnrolar;
        private System.Windows.Forms.Label labelRespuesta;
    }
}