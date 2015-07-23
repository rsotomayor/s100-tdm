namespace s100_retail
{
    partial class FormInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemAplicacion = new System.Windows.Forms.MenuItem();
            this.menuItemPromocional = new System.Windows.Forms.MenuItem();
            this.menuItemRevenue = new System.Windows.Forms.MenuItem();
            this.menuItemRecogida = new System.Windows.Forms.MenuItem();
            this.menuItemInventario = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemConsultaProductos = new System.Windows.Forms.MenuItem();
            this.menuItemOperaciones = new System.Windows.Forms.MenuItem();
            this.menuItemConsultaTransacciones = new System.Windows.Forms.MenuItem();
            this.menuItemCajas = new System.Windows.Forms.MenuItem();
            this.menuItemSincronizacion = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItemSalir = new System.Windows.Forms.MenuItem();
            this.menuItemGPS = new System.Windows.Forms.MenuItem();
            this.menuItemGpsEnabled = new System.Windows.Forms.MenuItem();
            this.menuItemGpsDisabled = new System.Windows.Forms.MenuItem();
            this.StatusBarInicio = new System.Windows.Forms.StatusBar();
            this.tabControlInicio = new System.Windows.Forms.TabControl();
            this.tabPageSesion = new System.Windows.Forms.TabPage();
            this.labelSincronizacion = new System.Windows.Forms.Label();
            this.labelTienda = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.tabPageRecursos = new System.Windows.Forms.TabPage();
            this.labelGeo = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelRecursos = new System.Windows.Forms.Label();
            this.tabPageRegistro = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOrganizacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelActivacion = new System.Windows.Forms.Label();
            this.buttonActivacion = new System.Windows.Forms.Button();
            this.tabControlInicio.SuspendLayout();
            this.tabPageSesion.SuspendLayout();
            this.tabPageRecursos.SuspendLayout();
            this.tabPageRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemAplicacion);
            this.mainMenu1.MenuItems.Add(this.menuItemGPS);
            // 
            // menuItemAplicacion
            // 
            this.menuItemAplicacion.MenuItems.Add(this.menuItemPromocional);
            this.menuItemAplicacion.MenuItems.Add(this.menuItemRevenue);
            this.menuItemAplicacion.MenuItems.Add(this.menuItemRecogida);
            this.menuItemAplicacion.MenuItems.Add(this.menuItemInventario);
            this.menuItemAplicacion.MenuItems.Add(this.menuItem1);
            this.menuItemAplicacion.MenuItems.Add(this.menuItemSincronizacion);
            this.menuItemAplicacion.MenuItems.Add(this.menuItem7);
            this.menuItemAplicacion.MenuItems.Add(this.menuItemSalir);
            this.menuItemAplicacion.Text = "Aplicación";
            // 
            // menuItemPromocional
            // 
            this.menuItemPromocional.Text = "Etiquetaje Promocional";
            this.menuItemPromocional.Click += new System.EventHandler(this.menuItemPromocional_Click);
            // 
            // menuItemRevenue
            // 
            this.menuItemRevenue.Text = "Etiquetaje Revenue";
            this.menuItemRevenue.Click += new System.EventHandler(this.menuItemRevenue_Click);
            // 
            // menuItemRecogida
            // 
            this.menuItemRecogida.Text = "Recogida";
            this.menuItemRecogida.Click += new System.EventHandler(this.menuItemRecogida_Click);
            // 
            // menuItemInventario
            // 
            this.menuItemInventario.Text = "Inventario";
            this.menuItemInventario.Click += new System.EventHandler(this.menuItemInventario_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItemConsultaProductos);
            this.menuItem1.MenuItems.Add(this.menuItemOperaciones);
            this.menuItem1.MenuItems.Add(this.menuItemConsultaTransacciones);
            this.menuItem1.MenuItems.Add(this.menuItemCajas);
            this.menuItem1.Text = "Consultas";
            // 
            // menuItemConsultaProductos
            // 
            this.menuItemConsultaProductos.Text = "Productos";
            this.menuItemConsultaProductos.Click += new System.EventHandler(this.menuItemConsultaProductos_Click);
            // 
            // menuItemOperaciones
            // 
            this.menuItemOperaciones.Text = "Operaciones";
            this.menuItemOperaciones.Click += new System.EventHandler(this.menuItemOperaciones_Click);
            // 
            // menuItemConsultaTransacciones
            // 
            this.menuItemConsultaTransacciones.Text = "Transacciones";
            this.menuItemConsultaTransacciones.Click += new System.EventHandler(this.menuItemConsultaTransacciones_Click);
            // 
            // menuItemCajas
            // 
            this.menuItemCajas.Enabled = false;
            this.menuItemCajas.Text = "Cajas";
            this.menuItemCajas.Click += new System.EventHandler(this.menuItemCajas_Click);
            // 
            // menuItemSincronizacion
            // 
            this.menuItemSincronizacion.Text = "Sincronización";
            this.menuItemSincronizacion.Click += new System.EventHandler(this.menuItemSincronizacion_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Text = "-";
            // 
            // menuItemSalir
            // 
            this.menuItemSalir.Text = "Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
            // 
            // menuItemGPS
            // 
            this.menuItemGPS.MenuItems.Add(this.menuItemGpsEnabled);
            this.menuItemGPS.MenuItems.Add(this.menuItemGpsDisabled);
            this.menuItemGPS.Text = "Gps";
            // 
            // menuItemGpsEnabled
            // 
            this.menuItemGpsEnabled.Text = "Habilitar";
            this.menuItemGpsEnabled.Click += new System.EventHandler(this.menuItemGpsEnabled_Click);
            // 
            // menuItemGpsDisabled
            // 
            this.menuItemGpsDisabled.Enabled = false;
            this.menuItemGpsDisabled.Text = "Deshabilitar";
            this.menuItemGpsDisabled.Click += new System.EventHandler(this.menuItemGpsDisabled_Click);
            // 
            // StatusBarInicio
            // 
            this.StatusBarInicio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.StatusBarInicio.Location = new System.Drawing.Point(0, 248);
            this.StatusBarInicio.Name = "StatusBarInicio";
            this.StatusBarInicio.Size = new System.Drawing.Size(240, 20);
            this.StatusBarInicio.Text = "Mensajes";
            // 
            // tabControlInicio
            // 
            this.tabControlInicio.Controls.Add(this.tabPageSesion);
            this.tabControlInicio.Controls.Add(this.tabPageRecursos);
            this.tabControlInicio.Controls.Add(this.tabPageRegistro);
            this.tabControlInicio.Location = new System.Drawing.Point(0, 0);
            this.tabControlInicio.Name = "tabControlInicio";
            this.tabControlInicio.SelectedIndex = 0;
            this.tabControlInicio.Size = new System.Drawing.Size(240, 246);
            this.tabControlInicio.TabIndex = 6;
            this.tabControlInicio.SelectedIndexChanged += new System.EventHandler(this.tabControlInicio_SelectedIndexChanged);
            // 
            // tabPageSesion
            // 
            this.tabPageSesion.Controls.Add(this.labelSincronizacion);
            this.tabPageSesion.Controls.Add(this.labelTienda);
            this.tabPageSesion.Controls.Add(this.labelUsuario);
            this.tabPageSesion.Controls.Add(this.PictureBox1);
            this.tabPageSesion.Controls.Add(this.labelVersion);
            this.tabPageSesion.Location = new System.Drawing.Point(0, 0);
            this.tabPageSesion.Name = "tabPageSesion";
            this.tabPageSesion.Size = new System.Drawing.Size(240, 223);
            this.tabPageSesion.Text = "Sesión";
            // 
            // labelSincronizacion
            // 
            this.labelSincronizacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSincronizacion.Location = new System.Drawing.Point(3, 108);
            this.labelSincronizacion.Name = "labelSincronizacion";
            this.labelSincronizacion.Size = new System.Drawing.Size(233, 114);
            this.labelSincronizacion.Text = "....";
            // 
            // labelTienda
            // 
            this.labelTienda.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelTienda.ForeColor = System.Drawing.Color.Black;
            this.labelTienda.Location = new System.Drawing.Point(6, 83);
            this.labelTienda.Name = "labelTienda";
            this.labelTienda.Size = new System.Drawing.Size(224, 20);
            this.labelTienda.Text = "Tienda:";
            // 
            // labelUsuario
            // 
            this.labelUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelUsuario.ForeColor = System.Drawing.Color.Black;
            this.labelUsuario.Location = new System.Drawing.Point(6, 59);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(225, 20);
            this.labelUsuario.Text = "Usuario:";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(87, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(149, 49);
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelVersion.ForeColor = System.Drawing.Color.Black;
            this.labelVersion.Location = new System.Drawing.Point(7, 6);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(74, 20);
            // 
            // tabPageRecursos
            // 
            this.tabPageRecursos.Controls.Add(this.labelGeo);
            this.tabPageRecursos.Controls.Add(this.labelStatus);
            this.tabPageRecursos.Controls.Add(this.labelRecursos);
            this.tabPageRecursos.Location = new System.Drawing.Point(0, 0);
            this.tabPageRecursos.Name = "tabPageRecursos";
            this.tabPageRecursos.Size = new System.Drawing.Size(232, 220);
            this.tabPageRecursos.Text = "Recursos";
            // 
            // labelGeo
            // 
            this.labelGeo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelGeo.ForeColor = System.Drawing.Color.Black;
            this.labelGeo.Location = new System.Drawing.Point(7, 180);
            this.labelGeo.Name = "labelGeo";
            this.labelGeo.Size = new System.Drawing.Size(230, 37);
            this.labelGeo.Text = "Geo:";
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(7, 71);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(230, 99);
            this.labelStatus.Text = "GPS:";
            // 
            // labelRecursos
            // 
            this.labelRecursos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelRecursos.Location = new System.Drawing.Point(7, 4);
            this.labelRecursos.Name = "labelRecursos";
            this.labelRecursos.Size = new System.Drawing.Size(226, 61);
            this.labelRecursos.Text = "Recursos:";
            // 
            // tabPageRegistro
            // 
            this.tabPageRegistro.Controls.Add(this.label3);
            this.tabPageRegistro.Controls.Add(this.textBoxOrganizacion);
            this.tabPageRegistro.Controls.Add(this.label2);
            this.tabPageRegistro.Controls.Add(this.textBoxEmail);
            this.tabPageRegistro.Controls.Add(this.label1);
            this.tabPageRegistro.Controls.Add(this.textBoxNombre);
            this.tabPageRegistro.Controls.Add(this.labelActivacion);
            this.tabPageRegistro.Controls.Add(this.buttonActivacion);
            this.tabPageRegistro.Location = new System.Drawing.Point(0, 0);
            this.tabPageRegistro.Name = "tabPageRegistro";
            this.tabPageRegistro.Size = new System.Drawing.Size(232, 220);
            this.tabPageRegistro.Text = "Registro";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.Text = "Organización:";
            // 
            // textBoxOrganizacion
            // 
            this.textBoxOrganizacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxOrganizacion.Location = new System.Drawing.Point(106, 61);
            this.textBoxOrganizacion.Name = "textBoxOrganizacion";
            this.textBoxOrganizacion.Size = new System.Drawing.Size(128, 19);
            this.textBoxOrganizacion.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxEmail.Location = new System.Drawing.Point(70, 31);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(164, 19);
            this.textBoxEmail.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxNombre.Location = new System.Drawing.Point(69, 4);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(164, 19);
            this.textBoxNombre.TabIndex = 2;
            // 
            // labelActivacion
            // 
            this.labelActivacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelActivacion.Location = new System.Drawing.Point(12, 129);
            this.labelActivacion.Name = "labelActivacion";
            this.labelActivacion.Size = new System.Drawing.Size(212, 80);
            this.labelActivacion.Text = "Estado Activación:";
            // 
            // buttonActivacion
            // 
            this.buttonActivacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonActivacion.Location = new System.Drawing.Point(45, 93);
            this.buttonActivacion.Name = "buttonActivacion";
            this.buttonActivacion.Size = new System.Drawing.Size(147, 24);
            this.buttonActivacion.TabIndex = 0;
            this.buttonActivacion.Text = "Solicitar Activación";
            this.buttonActivacion.Click += new System.EventHandler(this.buttonActivacion_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControlInicio);
            this.Controls.Add(this.StatusBarInicio);
            this.Menu = this.mainMenu1;
            this.Name = "FormInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.Closed += new System.EventHandler(this.FormInicio_Closed);
            this.tabControlInicio.ResumeLayout(false);
            this.tabPageSesion.ResumeLayout(false);
            this.tabPageRecursos.ResumeLayout(false);
            this.tabPageRegistro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.StatusBar StatusBarInicio;
        private System.Windows.Forms.MenuItem menuItemAplicacion;
        private System.Windows.Forms.MenuItem menuItemPromocional;
        private System.Windows.Forms.MenuItem menuItemRevenue;
        private System.Windows.Forms.MenuItem menuItemRecogida;
        private System.Windows.Forms.MenuItem menuItemInventario;
        private System.Windows.Forms.MenuItem menuItemSincronizacion;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItemSalir;
        private System.Windows.Forms.MenuItem menuItemGPS;
        private System.Windows.Forms.MenuItem menuItemGpsEnabled;
        private System.Windows.Forms.MenuItem menuItemGpsDisabled;
        private System.Windows.Forms.TabControl tabControlInicio;
        private System.Windows.Forms.TabPage tabPageSesion;
        private System.Windows.Forms.Label labelSincronizacion;
        private System.Windows.Forms.Label labelTienda;
        private System.Windows.Forms.Label labelUsuario;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TabPage tabPageRecursos;
        private System.Windows.Forms.Label labelRecursos;
        private System.Windows.Forms.TabPage tabPageRegistro;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonActivacion;
        private System.Windows.Forms.Label labelActivacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOrganizacion;
        private System.Windows.Forms.Label labelGeo;
        private System.Windows.Forms.MenuItem menuItemCajas;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemConsultaProductos;
        private System.Windows.Forms.MenuItem menuItemConsultaTransacciones;
        private System.Windows.Forms.MenuItem menuItemOperaciones;


    }
}

