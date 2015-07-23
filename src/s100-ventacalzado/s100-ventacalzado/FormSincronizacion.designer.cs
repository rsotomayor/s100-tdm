namespace s100_ventacalzado
{
    partial class FormSincronizacion
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
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonSincronizaEnviar = new System.Windows.Forms.Button();
            this.buttonSincronizaRecibir = new System.Windows.Forms.Button();
            this.labelSincronizacion = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(15, 214);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(211, 20);
            this.ProgressBar1.ParentChanged += new System.EventHandler(this.ProgressBar1_ParentChanged);
            // 
            // buttonSincronizaEnviar
            // 
            this.buttonSincronizaEnviar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonSincronizaEnviar.Location = new System.Drawing.Point(38, 36);
            this.buttonSincronizaEnviar.Name = "buttonSincronizaEnviar";
            this.buttonSincronizaEnviar.Size = new System.Drawing.Size(163, 26);
            this.buttonSincronizaEnviar.TabIndex = 4;
            this.buttonSincronizaEnviar.Text = "Enviar Transacciones";
            this.buttonSincronizaEnviar.Click += new System.EventHandler(this.ButtonSincronizaEnviar_Click);
            // 
            // buttonSincronizaRecibir
            // 
            this.buttonSincronizaRecibir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonSincronizaRecibir.Location = new System.Drawing.Point(38, 3);
            this.buttonSincronizaRecibir.Name = "buttonSincronizaRecibir";
            this.buttonSincronizaRecibir.Size = new System.Drawing.Size(163, 27);
            this.buttonSincronizaRecibir.TabIndex = 2;
            this.buttonSincronizaRecibir.Text = "Recibir Maestros";
            this.buttonSincronizaRecibir.Click += new System.EventHandler(this.ButtonSincronizaRecibir_Click);
            // 
            // labelSincronizacion
            // 
            this.labelSincronizacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSincronizacion.Location = new System.Drawing.Point(15, 110);
            this.labelSincronizacion.Name = "labelSincronizacion";
            this.labelSincronizacion.Size = new System.Drawing.Size(211, 97);
            this.labelSincronizacion.Text = "....";
            this.labelSincronizacion.ParentChanged += new System.EventHandler(this.labelSincronizacion_ParentChanged);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Configuración";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.MenuItems.Add(this.menuItem4);
            this.menuItem2.Text = "Datos";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Transacciones";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Maestros";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonCancelar.Location = new System.Drawing.Point(38, 68);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(163, 25);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 246);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // FormSincronizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelSincronizacion);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.buttonSincronizaEnviar);
            this.Controls.Add(this.buttonSincronizaRecibir);
            this.Menu = this.mainMenu1;
            this.Name = "FormSincronizacion";
            this.Text = "Sincronizacion";
            this.Load += new System.EventHandler(this.FormSincronizacion_Load);
            this.Closed += new System.EventHandler(this.FormSincronizacion_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Button buttonSincronizaEnviar;
        internal System.Windows.Forms.Button buttonSincronizaRecibir;
        private System.Windows.Forms.Label labelSincronizacion;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        internal System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.StatusBar StatusBar1;
    }
}