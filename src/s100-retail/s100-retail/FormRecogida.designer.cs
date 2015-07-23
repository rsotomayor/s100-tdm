namespace s100_retail
{
    partial class FormRecogida
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
            this.Label2 = new System.Windows.Forms.Label();
            this.textBoxUbicacion = new System.Windows.Forms.TextBox();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.LabelREAlarma = new System.Windows.Forms.Label();
            this.ButtonConsultar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.checkBoxMasMenos = new System.Windows.Forms.CheckBox();
            this.labelLinea = new System.Windows.Forms.Label();
            this.labelDepartamento = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelEAN = new System.Windows.Forms.Label();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.labelSemanaAntiguedad = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelSKU = new System.Windows.Forms.Label();
            this.checkBoxDiarioTotal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonLimpiar.Location = new System.Drawing.Point(113, 48);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(75, 20);
            this.ButtonLimpiar.TabIndex = 46;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label2.Location = new System.Drawing.Point(3, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 20);
            this.Label2.Text = "Sector";
            // 
            // textBoxUbicacion
            // 
            this.textBoxUbicacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxUbicacion.Location = new System.Drawing.Point(63, 2);
            this.textBoxUbicacion.Name = "textBoxUbicacion";
            this.textBoxUbicacion.Size = new System.Drawing.Size(161, 19);
            this.textBoxUbicacion.TabIndex = 45;
            // 
            // StatusBar1
            // 
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.StatusBar1.Location = new System.Drawing.Point(0, 248);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 20);
            this.StatusBar1.Text = "Mensajes";
            // 
            // LabelREAlarma
            // 
            this.LabelREAlarma.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.LabelREAlarma.ForeColor = System.Drawing.Color.Black;
            this.LabelREAlarma.Location = new System.Drawing.Point(4, 206);
            this.LabelREAlarma.Name = "LabelREAlarma";
            this.LabelREAlarma.Size = new System.Drawing.Size(233, 40);
            this.LabelREAlarma.Text = "......";
            this.LabelREAlarma.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonConsultar
            // 
            this.ButtonConsultar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonConsultar.Location = new System.Drawing.Point(35, 48);
            this.ButtonConsultar.Name = "ButtonConsultar";
            this.ButtonConsultar.Size = new System.Drawing.Size(72, 20);
            this.ButtonConsultar.TabIndex = 44;
            this.ButtonConsultar.Text = "Consultar";
            this.ButtonConsultar.Click += new System.EventHandler(this.ButtonConsultar_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(3, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 20);
            this.Label1.Text = "BarCode";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxBarCode.Location = new System.Drawing.Point(63, 24);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(161, 19);
            this.textBoxBarCode.TabIndex = 43;
            this.textBoxBarCode.TextChanged += new System.EventHandler(this.textBoxBarCode_TextChanged);
            // 
            // checkBoxMasMenos
            // 
            this.checkBoxMasMenos.Checked = true;
            this.checkBoxMasMenos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMasMenos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxMasMenos.Location = new System.Drawing.Point(15, 72);
            this.checkBoxMasMenos.Name = "checkBoxMasMenos";
            this.checkBoxMasMenos.Size = new System.Drawing.Size(61, 20);
            this.checkBoxMasMenos.TabIndex = 76;
            this.checkBoxMasMenos.Text = "+ / -";
            // 
            // labelLinea
            // 
            this.labelLinea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelLinea.Location = new System.Drawing.Point(4, 157);
            this.labelLinea.Name = "labelLinea";
            this.labelLinea.Size = new System.Drawing.Size(217, 22);
            this.labelLinea.Text = "Linea";
            // 
            // labelDepartamento
            // 
            this.labelDepartamento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelDepartamento.Location = new System.Drawing.Point(4, 135);
            this.labelDepartamento.Name = "labelDepartamento";
            this.labelDepartamento.Size = new System.Drawing.Size(217, 22);
            this.labelDepartamento.Text = "Departamento";
            // 
            // labelStock
            // 
            this.labelStock.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelStock.Location = new System.Drawing.Point(114, 179);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(64, 20);
            this.labelStock.Text = "Stock";
            // 
            // labelEAN
            // 
            this.labelEAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelEAN.Location = new System.Drawing.Point(4, 95);
            this.labelEAN.Name = "labelEAN";
            this.labelEAN.Size = new System.Drawing.Size(94, 20);
            this.labelEAN.Text = "EAN";
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNombreProducto.Location = new System.Drawing.Point(4, 115);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(217, 20);
            this.labelNombreProducto.Text = "Nombre Producto";
            // 
            // labelSemanaAntiguedad
            // 
            this.labelSemanaAntiguedad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSemanaAntiguedad.Location = new System.Drawing.Point(184, 179);
            this.labelSemanaAntiguedad.Name = "labelSemanaAntiguedad";
            this.labelSemanaAntiguedad.Size = new System.Drawing.Size(53, 20);
            this.labelSemanaAntiguedad.Text = "SA:";
            // 
            // labelPrecio
            // 
            this.labelPrecio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelPrecio.Location = new System.Drawing.Point(4, 179);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(104, 20);
            this.labelPrecio.Text = "Precio";
            // 
            // labelSKU
            // 
            this.labelSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSKU.Location = new System.Drawing.Point(104, 95);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(136, 20);
            this.labelSKU.Text = "SKU";
            // 
            // checkBoxDiarioTotal
            // 
            this.checkBoxDiarioTotal.Checked = true;
            this.checkBoxDiarioTotal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDiarioTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxDiarioTotal.Location = new System.Drawing.Point(110, 72);
            this.checkBoxDiarioTotal.Name = "checkBoxDiarioTotal";
            this.checkBoxDiarioTotal.Size = new System.Drawing.Size(100, 20);
            this.checkBoxDiarioTotal.TabIndex = 81;
            this.checkBoxDiarioTotal.Text = "Diaria/Total";
            // 
            // FormRecogida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.checkBoxDiarioTotal);
            this.Controls.Add(this.labelLinea);
            this.Controls.Add(this.labelDepartamento);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelEAN);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelSemanaAntiguedad);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.checkBoxMasMenos);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.textBoxUbicacion);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.LabelREAlarma);
            this.Controls.Add(this.ButtonConsultar);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.textBoxBarCode);
            this.Menu = this.mainMenu1;
            this.Name = "FormRecogida";
            this.Text = "Recogida";
            this.Load += new System.EventHandler(this.FormRecogida_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonLimpiar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox textBoxUbicacion;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.Label LabelREAlarma;
        internal System.Windows.Forms.Button ButtonConsultar;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox textBoxBarCode;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.CheckBox checkBoxMasMenos;
        internal System.Windows.Forms.Label labelLinea;
        internal System.Windows.Forms.Label labelDepartamento;
        internal System.Windows.Forms.Label labelStock;
        internal System.Windows.Forms.Label labelEAN;
        internal System.Windows.Forms.Label labelNombreProducto;
        internal System.Windows.Forms.Label labelSemanaAntiguedad;
        internal System.Windows.Forms.Label labelPrecio;
        internal System.Windows.Forms.Label labelSKU;
        private System.Windows.Forms.CheckBox checkBoxDiarioTotal;

    }
}