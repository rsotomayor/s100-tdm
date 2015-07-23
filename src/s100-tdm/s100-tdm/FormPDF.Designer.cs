namespace s100_tdm
{
    partial class FormPDF
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
            this.labelPDFRut = new System.Windows.Forms.Label();
            this.labelPDFNumeroSolicitud = new System.Windows.Forms.Label();
            this.labelPDFApellidoPaterno = new System.Windows.Forms.Label();
            this.labelPDFCodigoPais = new System.Windows.Forms.Label();
            this.labelPDFFechaVencimientoCedula = new System.Windows.Forms.Label();
            this.labelPDFNumeroSerieCedula = new System.Windows.Forms.Label();
            this.labelRegistroDiscapacidad = new System.Windows.Forms.Label();
            this.labelTipoDocumento = new System.Windows.Forms.Label();
            this.labelLargoMinucia = new System.Windows.Forms.Label();
            this.labelNumeroDedo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPDFRut
            // 
            this.labelPDFRut.Location = new System.Drawing.Point(4, 7);
            this.labelPDFRut.Name = "labelPDFRut";
            this.labelPDFRut.Size = new System.Drawing.Size(197, 22);
            this.labelPDFRut.Text = "Rut";
            // 
            // labelPDFNumeroSolicitud
            // 
            this.labelPDFNumeroSolicitud.Location = new System.Drawing.Point(4, 29);
            this.labelPDFNumeroSolicitud.Name = "labelPDFNumeroSolicitud";
            this.labelPDFNumeroSolicitud.Size = new System.Drawing.Size(197, 22);
            this.labelPDFNumeroSolicitud.Text = "Numero Solicitud";
            // 
            // labelPDFApellidoPaterno
            // 
            this.labelPDFApellidoPaterno.Location = new System.Drawing.Point(4, 51);
            this.labelPDFApellidoPaterno.Name = "labelPDFApellidoPaterno";
            this.labelPDFApellidoPaterno.Size = new System.Drawing.Size(197, 22);
            this.labelPDFApellidoPaterno.Text = "Apellido Paterno";
            // 
            // labelPDFCodigoPais
            // 
            this.labelPDFCodigoPais.Location = new System.Drawing.Point(4, 73);
            this.labelPDFCodigoPais.Name = "labelPDFCodigoPais";
            this.labelPDFCodigoPais.Size = new System.Drawing.Size(197, 22);
            this.labelPDFCodigoPais.Text = "Código Pais";
            // 
            // labelPDFFechaVencimientoCedula
            // 
            this.labelPDFFechaVencimientoCedula.Location = new System.Drawing.Point(4, 95);
            this.labelPDFFechaVencimientoCedula.Name = "labelPDFFechaVencimientoCedula";
            this.labelPDFFechaVencimientoCedula.Size = new System.Drawing.Size(197, 22);
            this.labelPDFFechaVencimientoCedula.Text = "Fecha Venc Cédula:";
            // 
            // labelPDFNumeroSerieCedula
            // 
            this.labelPDFNumeroSerieCedula.Location = new System.Drawing.Point(4, 117);
            this.labelPDFNumeroSerieCedula.Name = "labelPDFNumeroSerieCedula";
            this.labelPDFNumeroSerieCedula.Size = new System.Drawing.Size(197, 22);
            this.labelPDFNumeroSerieCedula.Text = "Número Serie Cédula:";
            // 
            // labelRegistroDiscapacidad
            // 
            this.labelRegistroDiscapacidad.Location = new System.Drawing.Point(4, 139);
            this.labelRegistroDiscapacidad.Name = "labelRegistroDiscapacidad";
            this.labelRegistroDiscapacidad.Size = new System.Drawing.Size(197, 22);
            this.labelRegistroDiscapacidad.Text = "Registro Discapacidad:";
            // 
            // labelTipoDocumento
            // 
            this.labelTipoDocumento.Location = new System.Drawing.Point(4, 161);
            this.labelTipoDocumento.Name = "labelTipoDocumento";
            this.labelTipoDocumento.Size = new System.Drawing.Size(197, 22);
            this.labelTipoDocumento.Text = "Tipo Documento:";
            // 
            // labelLargoMinucia
            // 
            this.labelLargoMinucia.Location = new System.Drawing.Point(4, 183);
            this.labelLargoMinucia.Name = "labelLargoMinucia";
            this.labelLargoMinucia.Size = new System.Drawing.Size(197, 22);
            this.labelLargoMinucia.Text = "Largo Minucia:";
            // 
            // labelNumeroDedo
            // 
            this.labelNumeroDedo.Location = new System.Drawing.Point(4, 205);
            this.labelNumeroDedo.Name = "labelNumeroDedo";
            this.labelNumeroDedo.Size = new System.Drawing.Size(197, 22);
            this.labelNumeroDedo.Text = "Numero Dedo:";
            // 
            // FormPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 280);
            this.Controls.Add(this.labelNumeroDedo);
            this.Controls.Add(this.labelLargoMinucia);
            this.Controls.Add(this.labelTipoDocumento);
            this.Controls.Add(this.labelRegistroDiscapacidad);
            this.Controls.Add(this.labelPDFNumeroSerieCedula);
            this.Controls.Add(this.labelPDFFechaVencimientoCedula);
            this.Controls.Add(this.labelPDFCodigoPais);
            this.Controls.Add(this.labelPDFApellidoPaterno);
            this.Controls.Add(this.labelPDFNumeroSolicitud);
            this.Controls.Add(this.labelPDFRut);
            this.Menu = this.mainMenu1;
            this.Name = "FormPDF";
            this.Text = "FormPDF";
            this.Load += new System.EventHandler(this.FormPDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPDFRut;
        private System.Windows.Forms.Label labelPDFNumeroSolicitud;
        private System.Windows.Forms.Label labelPDFApellidoPaterno;
        private System.Windows.Forms.Label labelPDFCodigoPais;
        private System.Windows.Forms.Label labelPDFFechaVencimientoCedula;
        private System.Windows.Forms.Label labelPDFNumeroSerieCedula;
        private System.Windows.Forms.Label labelRegistroDiscapacidad;
        private System.Windows.Forms.Label labelTipoDocumento;
        private System.Windows.Forms.Label labelLargoMinucia;
        private System.Windows.Forms.Label labelNumeroDedo;
    }
}