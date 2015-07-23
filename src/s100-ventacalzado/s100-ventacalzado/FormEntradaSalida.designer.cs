namespace s100_ventacalzado
{
    partial class FormEntradaSalida
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
            this.ButtonConsultar = new System.Windows.Forms.Button();
            this.textBoxUbicacion = new System.Windows.Forms.TextBox();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelInventario = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.labelEAN = new System.Windows.Forms.Label();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.labelSKU = new System.Windows.Forms.Label();
            this.labelTalla = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelStockBodega = new System.Windows.Forms.Label();
            this.labelStockSector = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.comboBoxMovimientos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonEntrada = new System.Windows.Forms.RadioButton();
            this.radioButtonSalida = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonLimpiar.Location = new System.Drawing.Point(119, 101);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(79, 22);
            this.ButtonLimpiar.TabIndex = 66;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // ButtonConsultar
            // 
            this.ButtonConsultar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonConsultar.Location = new System.Drawing.Point(28, 101);
            this.ButtonConsultar.Name = "ButtonConsultar";
            this.ButtonConsultar.Size = new System.Drawing.Size(79, 22);
            this.ButtonConsultar.TabIndex = 65;
            this.ButtonConsultar.Text = "Ejecutar";
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
            // textBoxBarCode
            // 
            this.textBoxBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxBarCode.Location = new System.Drawing.Point(73, 27);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(158, 19);
            this.textBoxBarCode.TabIndex = 62;
            this.textBoxBarCode.TextChanged += new System.EventHandler(this.textBoxBarCode_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(2, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 20);
            this.Label1.Text = "BarCode";
            // 
            // LabelInventario
            // 
            this.LabelInventario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.LabelInventario.Location = new System.Drawing.Point(6, 201);
            this.LabelInventario.Name = "LabelInventario";
            this.LabelInventario.Size = new System.Drawing.Size(221, 32);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.StatusBar1.Location = new System.Drawing.Point(0, 248);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 20);
            // 
            // labelEAN
            // 
            this.labelEAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelEAN.Location = new System.Drawing.Point(6, 135);
            this.labelEAN.Name = "labelEAN";
            this.labelEAN.Size = new System.Drawing.Size(97, 20);
            this.labelEAN.Text = "EAN";
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNombreProducto.Location = new System.Drawing.Point(6, 155);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(231, 20);
            this.labelNombreProducto.Text = "Nombre Producto";
            // 
            // labelSKU
            // 
            this.labelSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSKU.Location = new System.Drawing.Point(105, 135);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(132, 20);
            this.labelSKU.Text = "SKU";
            // 
            // labelTalla
            // 
            this.labelTalla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelTalla.Location = new System.Drawing.Point(6, 175);
            this.labelTalla.Name = "labelTalla";
            this.labelTalla.Size = new System.Drawing.Size(97, 20);
            this.labelTalla.Text = "Talla";
            // 
            // labelColor
            // 
            this.labelColor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelColor.Location = new System.Drawing.Point(105, 175);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(102, 20);
            this.labelColor.Text = "Color";
            // 
            // labelStockBodega
            // 
            this.labelStockBodega.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelStockBodega.Location = new System.Drawing.Point(3, 225);
            this.labelStockBodega.Name = "labelStockBodega";
            this.labelStockBodega.Size = new System.Drawing.Size(225, 20);
            this.labelStockBodega.Text = "Stock Bodega";
            // 
            // labelStockSector
            // 
            this.labelStockSector.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelStockSector.Location = new System.Drawing.Point(4, 201);
            this.labelStockSector.Name = "labelStockSector";
            this.labelStockSector.Size = new System.Drawing.Size(221, 20);
            this.labelStockSector.Text = "Stock Sector";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label2.Location = new System.Drawing.Point(3, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 20);
            this.Label2.Text = "Sector";
            // 
            // comboBoxMovimientos
            // 
            this.comboBoxMovimientos.Location = new System.Drawing.Point(73, 72);
            this.comboBoxMovimientos.Name = "comboBoxMovimientos";
            this.comboBoxMovimientos.Size = new System.Drawing.Size(161, 22);
            this.comboBoxMovimientos.TabIndex = 121;
            this.comboBoxMovimientos.SelectedIndexChanged += new System.EventHandler(this.comboBoxMovimientos_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(2, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.Text = "Motivos";
            // 
            // radioButtonEntrada
            // 
            this.radioButtonEntrada.Location = new System.Drawing.Point(6, 48);
            this.radioButtonEntrada.Name = "radioButtonEntrada";
            this.radioButtonEntrada.Size = new System.Drawing.Size(100, 20);
            this.radioButtonEntrada.TabIndex = 133;
            this.radioButtonEntrada.Text = "Entrada";
            this.radioButtonEntrada.CheckedChanged += new System.EventHandler(this.radioButtonEntrada_CheckedChanged);
            // 
            // radioButtonSalida
            // 
            this.radioButtonSalida.Location = new System.Drawing.Point(127, 48);
            this.radioButtonSalida.Name = "radioButtonSalida";
            this.radioButtonSalida.Size = new System.Drawing.Size(100, 20);
            this.radioButtonSalida.TabIndex = 134;
            this.radioButtonSalida.Text = "Salida";
            this.radioButtonSalida.CheckedChanged += new System.EventHandler(this.radioButtonSalida_CheckedChanged);
            // 
            // FormEntradaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.radioButtonSalida);
            this.Controls.Add(this.radioButtonEntrada);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxMovimientos);
            this.Controls.Add(this.labelStockSector);
            this.Controls.Add(this.labelStockBodega);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelTalla);
            this.Controls.Add(this.labelEAN);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.LabelInventario);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.ButtonConsultar);
            this.Controls.Add(this.textBoxUbicacion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.textBoxBarCode);
            this.Controls.Add(this.Label1);
            this.Menu = this.mainMenu1;
            this.Name = "FormEntradaSalida";
            this.Text = "Movimientos Entrada y Salida";
            this.Load += new System.EventHandler(this.FormInventario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonLimpiar;
        internal System.Windows.Forms.Button ButtonConsultar;
        internal System.Windows.Forms.TextBox textBoxUbicacion;
        internal System.Windows.Forms.TextBox textBoxBarCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label LabelInventario;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.Label labelEAN;
        internal System.Windows.Forms.Label labelNombreProducto;
        internal System.Windows.Forms.Label labelSKU;
        internal System.Windows.Forms.Label labelTalla;
        internal System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelStockBodega;
        private System.Windows.Forms.Label labelStockSector;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox comboBoxMovimientos;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonEntrada;
        private System.Windows.Forms.RadioButton radioButtonSalida;


    }
}