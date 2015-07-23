namespace s100_retail
{
    partial class FormInventario
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
            this.ButtonINVLimpiar = new System.Windows.Forms.Button();
            this.ButtonConsultar = new System.Windows.Forms.Button();
            this.textBoxUbicacion = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelInventario = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.checkBoxMasMenos = new System.Windows.Forms.CheckBox();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
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
            // ButtonINVLimpiar
            // 
            this.ButtonINVLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonINVLimpiar.Location = new System.Drawing.Point(120, 49);
            this.ButtonINVLimpiar.Name = "ButtonINVLimpiar";
            this.ButtonINVLimpiar.Size = new System.Drawing.Size(79, 22);
            this.ButtonINVLimpiar.TabIndex = 66;
            this.ButtonINVLimpiar.Text = "Limpiar";
            this.ButtonINVLimpiar.Click += new System.EventHandler(this.ButtonINVLimpiar_Click);
            // 
            // ButtonConsultar
            // 
            this.ButtonConsultar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonConsultar.Location = new System.Drawing.Point(29, 49);
            this.ButtonConsultar.Name = "ButtonConsultar";
            this.ButtonConsultar.Size = new System.Drawing.Size(79, 22);
            this.ButtonConsultar.TabIndex = 65;
            this.ButtonConsultar.Text = "Consultar";
            this.ButtonConsultar.Click += new System.EventHandler(this.ButtonConsultar_Click);
            // 
            // textBoxUbicacion
            // 
            this.textBoxUbicacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxUbicacion.Location = new System.Drawing.Point(73, 2);
            this.textBoxUbicacion.Name = "textBoxUbicacion";
            this.textBoxUbicacion.Size = new System.Drawing.Size(158, 19);
            this.textBoxUbicacion.TabIndex = 63;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label2.Location = new System.Drawing.Point(10, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 20);
            this.Label2.Text = "Sector";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxBarCode.Location = new System.Drawing.Point(73, 25);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(158, 19);
            this.textBoxBarCode.TabIndex = 62;
            this.textBoxBarCode.TextChanged += new System.EventHandler(this.textBoxBarCode_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(10, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 20);
            this.Label1.Text = "BarCode";
            // 
            // LabelInventario
            // 
            this.LabelInventario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.LabelInventario.Location = new System.Drawing.Point(7, 204);
            this.LabelInventario.Name = "LabelInventario";
            this.LabelInventario.Size = new System.Drawing.Size(221, 32);
            // 
            // checkBoxMasMenos
            // 
            this.checkBoxMasMenos.Checked = true;
            this.checkBoxMasMenos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMasMenos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxMasMenos.Location = new System.Drawing.Point(24, 75);
            this.checkBoxMasMenos.Name = "checkBoxMasMenos";
            this.checkBoxMasMenos.Size = new System.Drawing.Size(58, 20);
            this.checkBoxMasMenos.TabIndex = 75;
            this.checkBoxMasMenos.Text = "+ / -";
            // 
            // StatusBar1
            // 
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.StatusBar1.Location = new System.Drawing.Point(0, 248);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 20);
            // 
            // labelLinea
            // 
            this.labelLinea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelLinea.Location = new System.Drawing.Point(3, 160);
            this.labelLinea.Name = "labelLinea";
            this.labelLinea.Size = new System.Drawing.Size(217, 22);
            this.labelLinea.Text = "Linea";
            // 
            // labelDepartamento
            // 
            this.labelDepartamento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelDepartamento.Location = new System.Drawing.Point(3, 138);
            this.labelDepartamento.Name = "labelDepartamento";
            this.labelDepartamento.Size = new System.Drawing.Size(217, 22);
            this.labelDepartamento.Text = "Departamento";
            // 
            // labelStock
            // 
            this.labelStock.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelStock.Location = new System.Drawing.Point(114, 185);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(60, 20);
            this.labelStock.Text = "Stock";
            // 
            // labelEAN
            // 
            this.labelEAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelEAN.Location = new System.Drawing.Point(3, 98);
            this.labelEAN.Name = "labelEAN";
            this.labelEAN.Size = new System.Drawing.Size(97, 20);
            this.labelEAN.Text = "EAN";
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNombreProducto.Location = new System.Drawing.Point(3, 118);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(231, 20);
            this.labelNombreProducto.Text = "Nombre Producto";
            // 
            // labelSemanaAntiguedad
            // 
            this.labelSemanaAntiguedad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSemanaAntiguedad.Location = new System.Drawing.Point(180, 185);
            this.labelSemanaAntiguedad.Name = "labelSemanaAntiguedad";
            this.labelSemanaAntiguedad.Size = new System.Drawing.Size(54, 20);
            this.labelSemanaAntiguedad.Text = "SA:";
            // 
            // labelPrecio
            // 
            this.labelPrecio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelPrecio.Location = new System.Drawing.Point(5, 185);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(103, 20);
            this.labelPrecio.Text = "Precio";
            // 
            // labelSKU
            // 
            this.labelSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSKU.Location = new System.Drawing.Point(106, 98);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(132, 20);
            this.labelSKU.Text = "SKU";
            // 
            // FormInventario
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
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.checkBoxMasMenos);
            this.Controls.Add(this.LabelInventario);
            this.Controls.Add(this.ButtonINVLimpiar);
            this.Controls.Add(this.ButtonConsultar);
            this.Controls.Add(this.textBoxUbicacion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.textBoxBarCode);
            this.Controls.Add(this.Label1);
            this.Menu = this.mainMenu1;
            this.Name = "FormInventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.FormInventario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonINVLimpiar;
        internal System.Windows.Forms.Button ButtonConsultar;
        internal System.Windows.Forms.TextBox textBoxUbicacion;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox textBoxBarCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label LabelInventario;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.CheckBox checkBoxMasMenos;
        private System.Windows.Forms.StatusBar StatusBar1;
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