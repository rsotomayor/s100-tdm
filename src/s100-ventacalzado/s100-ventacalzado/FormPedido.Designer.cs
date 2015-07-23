namespace s100_ventacalzado
{
    partial class FormPedido
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
            this.dataGridProductos = new System.Windows.Forms.DataGrid();
            this.buttonProcesarPedido = new System.Windows.Forms.Button();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelSincronizacion = new System.Windows.Forms.Label();
            this.buttonVaciarPedido = new System.Windows.Forms.Button();
            this.buttonEliminarProducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridProductos.Location = new System.Drawing.Point(5, 27);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.Size = new System.Drawing.Size(230, 135);
            this.dataGridProductos.TabIndex = 8;
            // 
            // buttonProcesarPedido
            // 
            this.buttonProcesarPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonProcesarPedido.Location = new System.Drawing.Point(59, 195);
            this.buttonProcesarPedido.Name = "buttonProcesarPedido";
            this.buttonProcesarPedido.Size = new System.Drawing.Size(112, 23);
            this.buttonProcesarPedido.TabIndex = 12;
            this.buttonProcesarPedido.Text = "Procesar Pedido";
            this.buttonProcesarPedido.Click += new System.EventHandler(this.buttonProcesarPedido_Click);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.StatusBar1.Location = new System.Drawing.Point(0, 248);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 20);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(14, 226);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(213, 20);
            // 
            // labelSincronizacion
            // 
            this.labelSincronizacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelSincronizacion.Location = new System.Drawing.Point(8, 4);
            this.labelSincronizacion.Name = "labelSincronizacion";
            this.labelSincronizacion.Size = new System.Drawing.Size(219, 20);
            this.labelSincronizacion.Text = "Listado Pedido";
            // 
            // buttonVaciarPedido
            // 
            this.buttonVaciarPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonVaciarPedido.Location = new System.Drawing.Point(124, 168);
            this.buttonVaciarPedido.Name = "buttonVaciarPedido";
            this.buttonVaciarPedido.Size = new System.Drawing.Size(102, 23);
            this.buttonVaciarPedido.TabIndex = 16;
            this.buttonVaciarPedido.Text = "Vaciar Pedido";
            this.buttonVaciarPedido.Click += new System.EventHandler(this.buttonVaciarPedido_Click);
            // 
            // buttonEliminarProducto
            // 
            this.buttonEliminarProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonEliminarProducto.Location = new System.Drawing.Point(14, 168);
            this.buttonEliminarProducto.Name = "buttonEliminarProducto";
            this.buttonEliminarProducto.Size = new System.Drawing.Size(107, 23);
            this.buttonEliminarProducto.TabIndex = 17;
            this.buttonEliminarProducto.Text = "Eliminar Producto";
            this.buttonEliminarProducto.Click += new System.EventHandler(this.buttonEliminarProducto_Click);
            // 
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonEliminarProducto);
            this.Controls.Add(this.buttonVaciarPedido);
            this.Controls.Add(this.labelSincronizacion);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.buttonProcesarPedido);
            this.Controls.Add(this.dataGridProductos);
            this.Menu = this.mainMenu1;
            this.Name = "FormPedido";
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.FormPedido_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGridProductos;
        private System.Windows.Forms.Button buttonProcesarPedido;
        private System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Label labelSincronizacion;
        private System.Windows.Forms.Button buttonVaciarPedido;
        private System.Windows.Forms.Button buttonEliminarProducto;
    }
}