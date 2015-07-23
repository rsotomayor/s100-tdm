namespace s100_ventacalzado
{
    partial class FormTransacciones
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
            this.buttonBorraTransacciones = new System.Windows.Forms.Button();
            this.labelNImpresiones = new System.Windows.Forms.Label();
            this.labelNCuentasInventario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNCuentasPosicion = new System.Windows.Forms.Label();
            this.buttonIniciaInventario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBorraTransacciones
            // 
            this.buttonBorraTransacciones.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonBorraTransacciones.Location = new System.Drawing.Point(40, 147);
            this.buttonBorraTransacciones.Name = "buttonBorraTransacciones";
            this.buttonBorraTransacciones.Size = new System.Drawing.Size(157, 36);
            this.buttonBorraTransacciones.TabIndex = 0;
            this.buttonBorraTransacciones.Text = "Borra Transacciones";
            this.buttonBorraTransacciones.Click += new System.EventHandler(this.buttonBorraTransacciones_Click);
            // 
            // labelNImpresiones
            // 
            this.labelNImpresiones.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNImpresiones.Location = new System.Drawing.Point(12, 47);
            this.labelNImpresiones.Name = "labelNImpresiones";
            this.labelNImpresiones.Size = new System.Drawing.Size(198, 20);
            this.labelNImpresiones.Text = "Transacciones:";
            // 
            // labelNCuentasInventario
            // 
            this.labelNCuentasInventario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNCuentasInventario.Location = new System.Drawing.Point(12, 79);
            this.labelNCuentasInventario.Name = "labelNCuentasInventario";
            this.labelNCuentasInventario.Size = new System.Drawing.Size(198, 20);
            this.labelNCuentasInventario.Text = "Cuentas Inventario:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(51, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.Text = "Numero de Registros";
            // 
            // labelNCuentasPosicion
            // 
            this.labelNCuentasPosicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNCuentasPosicion.Location = new System.Drawing.Point(12, 110);
            this.labelNCuentasPosicion.Name = "labelNCuentasPosicion";
            this.labelNCuentasPosicion.Size = new System.Drawing.Size(198, 20);
            this.labelNCuentasPosicion.Text = "Cuentas Posición:";
            // 
            // buttonIniciaInventario
            // 
            this.buttonIniciaInventario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonIniciaInventario.Location = new System.Drawing.Point(40, 200);
            this.buttonIniciaInventario.Name = "buttonIniciaInventario";
            this.buttonIniciaInventario.Size = new System.Drawing.Size(157, 36);
            this.buttonIniciaInventario.TabIndex = 4;
            this.buttonIniciaInventario.Text = "Inicia Inventario a 0";
            this.buttonIniciaInventario.Click += new System.EventHandler(this.buttonIniciaInventario_Click);
            // 
            // FormTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonIniciaInventario);
            this.Controls.Add(this.labelNCuentasPosicion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNCuentasInventario);
            this.Controls.Add(this.labelNImpresiones);
            this.Controls.Add(this.buttonBorraTransacciones);
            this.Menu = this.mainMenu1;
            this.Name = "FormTransacciones";
            this.Text = "Transacciones";
            this.Load += new System.EventHandler(this.FormTransacciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBorraTransacciones;
        private System.Windows.Forms.Label labelNImpresiones;
        private System.Windows.Forms.Label labelNCuentasInventario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNCuentasPosicion;
        private System.Windows.Forms.Button buttonIniciaInventario;
    }
}