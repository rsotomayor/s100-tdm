namespace s100_retail
{
    partial class FormEtiquetajeRevenue
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
            this.ButtonLimpiar = new System.Windows.Forms.Button();
            this.textBoxUbicacion = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.ButtonImprimirRevenue = new System.Windows.Forms.Button();
            this.ButtonEnviar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.buttonImprimirPromocion = new System.Windows.Forms.Button();
            this.labelLinea = new System.Windows.Forms.Label();
            this.labelDepartamento = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelEAN = new System.Windows.Forms.Label();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.labelSemanaAntiguedad = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelSKU = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonLimpiar.Location = new System.Drawing.Point(121, 51);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(81, 20);
            this.ButtonLimpiar.TabIndex = 59;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // textBoxUbicacion
            // 
            this.textBoxUbicacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxUbicacion.Location = new System.Drawing.Point(65, 2);
            this.textBoxUbicacion.Name = "textBoxUbicacion";
            this.textBoxUbicacion.Size = new System.Drawing.Size(161, 19);
            this.textBoxUbicacion.TabIndex = 58;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 20);
            this.Label2.Text = "Sector";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxBarCode.Location = new System.Drawing.Point(65, 26);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(161, 19);
            this.textBoxBarCode.TabIndex = 57;
            this.textBoxBarCode.TextChanged += new System.EventHandler(this.textBoxBarCode_TextChanged);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 246);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 22);
            this.StatusBar1.Text = "Mensajes";
            // 
            // ButtonImprimirRevenue
            // 
            this.ButtonImprimirRevenue.Enabled = false;
            this.ButtonImprimirRevenue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonImprimirRevenue.Location = new System.Drawing.Point(9, 190);
            this.ButtonImprimirRevenue.Name = "ButtonImprimirRevenue";
            this.ButtonImprimirRevenue.Size = new System.Drawing.Size(104, 45);
            this.ButtonImprimirRevenue.TabIndex = 55;
            this.ButtonImprimirRevenue.Text = "Imprimir";
            this.ButtonImprimirRevenue.Click += new System.EventHandler(this.ButtonImprimirRevenue_Click);
            // 
            // ButtonEnviar
            // 
            this.ButtonEnviar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonEnviar.Location = new System.Drawing.Point(31, 51);
            this.ButtonEnviar.Name = "ButtonEnviar";
            this.ButtonEnviar.Size = new System.Drawing.Size(78, 20);
            this.ButtonEnviar.TabIndex = 54;
            this.ButtonEnviar.Text = "Consultar";
            this.ButtonEnviar.Click += new System.EventHandler(this.ButtonEnviar_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(2, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 20);
            this.Label1.Text = "BarCode";
            // 
            // buttonImprimirPromocion
            // 
            this.buttonImprimirPromocion.Enabled = false;
            this.buttonImprimirPromocion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonImprimirPromocion.Location = new System.Drawing.Point(122, 190);
            this.buttonImprimirPromocion.Name = "buttonImprimirPromocion";
            this.buttonImprimirPromocion.Size = new System.Drawing.Size(104, 45);
            this.buttonImprimirPromocion.TabIndex = 75;
            this.buttonImprimirPromocion.Text = "Imp Promoción";
            this.buttonImprimirPromocion.Click += new System.EventHandler(this.buttonImprimirPromocion_Click);
            // 
            // labelLinea
            // 
            this.labelLinea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelLinea.Location = new System.Drawing.Point(6, 144);
            this.labelLinea.Name = "labelLinea";
            this.labelLinea.Size = new System.Drawing.Size(220, 20);
            this.labelLinea.Text = "Linea";
            // 
            // labelDepartamento
            // 
            this.labelDepartamento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelDepartamento.Location = new System.Drawing.Point(6, 119);
            this.labelDepartamento.Name = "labelDepartamento";
            this.labelDepartamento.Size = new System.Drawing.Size(220, 25);
            this.labelDepartamento.Text = "Departamento";
            // 
            // labelStock
            // 
            this.labelStock.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelStock.Location = new System.Drawing.Point(118, 170);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(60, 20);
            this.labelStock.Text = "Stock";
            // 
            // labelEAN
            // 
            this.labelEAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelEAN.Location = new System.Drawing.Point(6, 74);
            this.labelEAN.Name = "labelEAN";
            this.labelEAN.Size = new System.Drawing.Size(103, 20);
            this.labelEAN.Text = "EAN";
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNombreProducto.Location = new System.Drawing.Point(6, 94);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(228, 20);
            this.labelNombreProducto.Text = "Nombre Producto";
            // 
            // labelSemanaAntiguedad
            // 
            this.labelSemanaAntiguedad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSemanaAntiguedad.Location = new System.Drawing.Point(184, 170);
            this.labelSemanaAntiguedad.Name = "labelSemanaAntiguedad";
            this.labelSemanaAntiguedad.Size = new System.Drawing.Size(50, 20);
            this.labelSemanaAntiguedad.Text = "SA:";
            // 
            // labelPrecio
            // 
            this.labelPrecio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelPrecio.Location = new System.Drawing.Point(6, 171);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(103, 16);
            this.labelPrecio.Text = "Precio";
            // 
            // labelSKU
            // 
            this.labelSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSKU.Location = new System.Drawing.Point(108, 74);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(129, 20);
            this.labelSKU.Text = "SKU";
            // 
            // FormEtiquetajeRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.labelLinea);
            this.Controls.Add(this.labelDepartamento);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelEAN);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelSemanaAntiguedad);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.buttonImprimirPromocion);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.textBoxUbicacion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.textBoxBarCode);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.ButtonImprimirRevenue);
            this.Controls.Add(this.ButtonEnviar);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Menu = this.mainMenu1;
            this.Name = "FormEtiquetajeRevenue";
            this.Text = "Etiquetaje Revenue";
            this.Load += new System.EventHandler(this.FormEtiquetajeRevenue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonLimpiar;
        internal System.Windows.Forms.TextBox textBoxUbicacion;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox textBoxBarCode;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.Button ButtonImprimirRevenue;
        internal System.Windows.Forms.Button ButtonEnviar;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.MainMenu mainMenu1;
        internal System.Windows.Forms.Button buttonImprimirPromocion;
        internal System.Windows.Forms.Label labelLinea;
        internal System.Windows.Forms.Label labelDepartamento;
        internal System.Windows.Forms.Label labelStock;
        internal System.Windows.Forms.Label labelEAN;
        internal System.Windows.Forms.Label labelNombreProducto;
        internal System.Windows.Forms.Label labelSemanaAntiguedad;
        internal System.Windows.Forms.Label labelPrecio;
        internal System.Windows.Forms.Label labelSKU;
    }
}