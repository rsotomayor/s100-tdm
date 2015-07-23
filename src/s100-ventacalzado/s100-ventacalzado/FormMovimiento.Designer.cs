namespace s100_ventacalzado
{
    partial class FormMovimiento
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
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStockDestino = new System.Windows.Forms.Label();
            this.labelStockOrigen = new System.Windows.Forms.Label();
            this.labelStockBodega = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelTalla = new System.Windows.Forms.Label();
            this.labelEAN = new System.Windows.Forms.Label();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.labelSKU = new System.Windows.Forms.Label();
            this.ButtonLimpiar = new System.Windows.Forms.Button();
            this.ButtonMover = new System.Windows.Forms.Button();
            this.textBoxOrigen = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxDestino.Location = new System.Drawing.Point(92, 28);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(139, 19);
            this.textBoxDestino.TabIndex = 138;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(10, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.Text = "Sector Destino";
            // 
            // labelStockDestino
            // 
            this.labelStockDestino.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelStockDestino.Location = new System.Drawing.Point(2, 202);
            this.labelStockDestino.Name = "labelStockDestino";
            this.labelStockDestino.Size = new System.Drawing.Size(229, 20);
            this.labelStockDestino.Text = "Stock Destino";
            // 
            // labelStockOrigen
            // 
            this.labelStockOrigen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelStockOrigen.Location = new System.Drawing.Point(4, 182);
            this.labelStockOrigen.Name = "labelStockOrigen";
            this.labelStockOrigen.Size = new System.Drawing.Size(228, 20);
            this.labelStockOrigen.Text = "Stock Origen";
            // 
            // labelStockBodega
            // 
            this.labelStockBodega.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelStockBodega.Location = new System.Drawing.Point(1, 225);
            this.labelStockBodega.Name = "labelStockBodega";
            this.labelStockBodega.Size = new System.Drawing.Size(230, 20);
            this.labelStockBodega.Text = "Stock Bodega";
            // 
            // labelColor
            // 
            this.labelColor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelColor.Location = new System.Drawing.Point(105, 156);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(102, 20);
            this.labelColor.Text = "Color";
            // 
            // labelTalla
            // 
            this.labelTalla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelTalla.Location = new System.Drawing.Point(3, 156);
            this.labelTalla.Name = "labelTalla";
            this.labelTalla.Size = new System.Drawing.Size(97, 20);
            this.labelTalla.Text = "Talla";
            // 
            // labelEAN
            // 
            this.labelEAN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelEAN.Location = new System.Drawing.Point(3, 116);
            this.labelEAN.Name = "labelEAN";
            this.labelEAN.Size = new System.Drawing.Size(97, 20);
            this.labelEAN.Text = "EAN";
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNombreProducto.Location = new System.Drawing.Point(3, 136);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(231, 20);
            this.labelNombreProducto.Text = "Nombre Producto";
            // 
            // labelSKU
            // 
            this.labelSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSKU.Location = new System.Drawing.Point(105, 116);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(132, 20);
            this.labelSKU.Text = "SKU";
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonLimpiar.Location = new System.Drawing.Point(126, 76);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(79, 22);
            this.ButtonLimpiar.TabIndex = 137;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // ButtonMover
            // 
            this.ButtonMover.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonMover.Location = new System.Drawing.Point(22, 76);
            this.ButtonMover.Name = "ButtonMover";
            this.ButtonMover.Size = new System.Drawing.Size(79, 22);
            this.ButtonMover.TabIndex = 136;
            this.ButtonMover.Text = "Mover";
            this.ButtonMover.Click += new System.EventHandler(this.ButtonMover_Click);
            // 
            // textBoxOrigen
            // 
            this.textBoxOrigen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxOrigen.Location = new System.Drawing.Point(92, 3);
            this.textBoxOrigen.Name = "textBoxOrigen";
            this.textBoxOrigen.Size = new System.Drawing.Size(139, 19);
            this.textBoxOrigen.TabIndex = 135;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label2.Location = new System.Drawing.Point(10, 3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(76, 20);
            this.Label2.Text = "Sector Origen";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxBarCode.Location = new System.Drawing.Point(73, 52);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(158, 19);
            this.textBoxBarCode.TabIndex = 134;
            this.textBoxBarCode.TextChanged += new System.EventHandler(this.textBoxBarCode_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(10, 51);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 20);
            this.Label1.Text = "BarCode";
            // 
            // StatusBar1
            // 
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.StatusBar1.Location = new System.Drawing.Point(0, 248);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 20);
            // 
            // FormMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.textBoxDestino);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelStockDestino);
            this.Controls.Add(this.labelStockOrigen);
            this.Controls.Add(this.labelStockBodega);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelTalla);
            this.Controls.Add(this.labelEAN);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.ButtonMover);
            this.Controls.Add(this.textBoxOrigen);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.textBoxBarCode);
            this.Controls.Add(this.Label1);
            this.Menu = this.mainMenu1;
            this.Name = "FormMovimiento";
            this.Text = "Movimiento Inventario";
            this.Load += new System.EventHandler(this.FormMovimiento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox textBoxDestino;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStockDestino;
        private System.Windows.Forms.Label labelStockOrigen;
        private System.Windows.Forms.Label labelStockBodega;
        internal System.Windows.Forms.Label labelColor;
        internal System.Windows.Forms.Label labelTalla;
        internal System.Windows.Forms.Label labelEAN;
        internal System.Windows.Forms.Label labelNombreProducto;
        internal System.Windows.Forms.Label labelSKU;
        internal System.Windows.Forms.Button ButtonLimpiar;
        internal System.Windows.Forms.Button ButtonMover;
        internal System.Windows.Forms.TextBox textBoxOrigen;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox textBoxBarCode;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.StatusBar StatusBar1;
    }
}