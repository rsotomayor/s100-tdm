namespace s100_tdm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItemEdgeLineConectar = new System.Windows.Forms.MenuItem();
            this.menuItemEdgeLineDesconectar = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelRut = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxRut = new System.Windows.Forms.TextBox();
            this.pictureBoxEnrolar = new System.Windows.Forms.PictureBox();
            this.pictureBoxVerificar = new System.Windows.Forms.PictureBox();
            this.pictureBoxIdentificar = new System.Windows.Forms.PictureBox();
            this.labelRespuesta = new System.Windows.Forms.Label();
            this.pictureBoxScan = new System.Windows.Forms.PictureBox();
            this.checkBoxES = new System.Windows.Forms.CheckBox();
            this.comboBoxServidor = new System.Windows.Forms.ComboBox();
            this.comboBoxFinger = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem6);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.menuItem10);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.MenuItems.Add(this.menuItem9);
            this.menuItem1.MenuItems.Add(this.menuItem8);
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "S100";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Inicio";
            // 
            // menuItem10
            // 
            this.menuItem10.Text = "Enrolar";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Debug";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Estado";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Text = "Limpiar";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "PDF";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click_1);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Salir";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.MenuItems.Add(this.menuItemEdgeLineConectar);
            this.menuItem6.MenuItems.Add(this.menuItemEdgeLineDesconectar);
            this.menuItem6.MenuItems.Add(this.menuItem7);
            this.menuItem6.Text = "EdgeLine";
            // 
            // menuItemEdgeLineConectar
            // 
            this.menuItemEdgeLineConectar.Text = "Conectar";
            this.menuItemEdgeLineConectar.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItemEdgeLineDesconectar
            // 
            this.menuItemEdgeLineDesconectar.Text = "Desconectar";
            this.menuItemEdgeLineDesconectar.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Text = "Acerca";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click_1);
            // 
            // labelNombre
            // 
            this.labelNombre.Location = new System.Drawing.Point(3, 2);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(50, 22);
            this.labelNombre.Text = "Nombre";
            // 
            // labelRut
            // 
            this.labelRut.Location = new System.Drawing.Point(3, 27);
            this.labelRut.Name = "labelRut";
            this.labelRut.Size = new System.Drawing.Size(50, 22);
            this.labelRut.Text = "Rut";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(47, 2);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(187, 21);
            this.textBoxNombre.TabIndex = 3;
            // 
            // textBoxRut
            // 
            this.textBoxRut.Location = new System.Drawing.Point(47, 27);
            this.textBoxRut.Name = "textBoxRut";
            this.textBoxRut.Size = new System.Drawing.Size(78, 21);
            this.textBoxRut.TabIndex = 4;
            // 
            // pictureBoxEnrolar
            // 
            this.pictureBoxEnrolar.Location = new System.Drawing.Point(151, 76);
            this.pictureBoxEnrolar.Name = "pictureBoxEnrolar";
            this.pictureBoxEnrolar.Size = new System.Drawing.Size(80, 40);
            this.pictureBoxEnrolar.Click += new System.EventHandler(this.pictureBoxEnrolar_Click);
            // 
            // pictureBoxVerificar
            // 
            this.pictureBoxVerificar.Location = new System.Drawing.Point(151, 118);
            this.pictureBoxVerificar.Name = "pictureBoxVerificar";
            this.pictureBoxVerificar.Size = new System.Drawing.Size(80, 40);
            this.pictureBoxVerificar.Click += new System.EventHandler(this.pictureBoxVerificar_Click);
            // 
            // pictureBoxIdentificar
            // 
            this.pictureBoxIdentificar.Location = new System.Drawing.Point(151, 160);
            this.pictureBoxIdentificar.Name = "pictureBoxIdentificar";
            this.pictureBoxIdentificar.Size = new System.Drawing.Size(80, 40);
            this.pictureBoxIdentificar.Click += new System.EventHandler(this.pictureBoxIdentificar_Click);
            // 
            // labelRespuesta
            // 
            this.labelRespuesta.Location = new System.Drawing.Point(7, 210);
            this.labelRespuesta.Name = "labelRespuesta";
            this.labelRespuesta.Size = new System.Drawing.Size(223, 22);
            this.labelRespuesta.Text = "Respuesta";
            this.labelRespuesta.ParentChanged += new System.EventHandler(this.labelRespuesta_ParentChanged);
            // 
            // pictureBoxScan
            // 
            this.pictureBoxScan.Location = new System.Drawing.Point(9, 78);
            this.pictureBoxScan.Name = "pictureBoxScan";
            this.pictureBoxScan.Size = new System.Drawing.Size(122, 113);
            // 
            // checkBoxES
            // 
            this.checkBoxES.Location = new System.Drawing.Point(191, 29);
            this.checkBoxES.Name = "checkBoxES";
            this.checkBoxES.Size = new System.Drawing.Size(42, 18);
            this.checkBoxES.TabIndex = 14;
            this.checkBoxES.Text = "E/S";
            // 
            // comboBoxServidor
            // 
            this.comboBoxServidor.Items.Add("Local");
            this.comboBoxServidor.Items.Add("Servidor");
            this.comboBoxServidor.Items.Add("Sinacofi");
            this.comboBoxServidor.Items.Add("Otro");
            this.comboBoxServidor.Location = new System.Drawing.Point(9, 52);
            this.comboBoxServidor.Name = "comboBoxServidor";
            this.comboBoxServidor.Size = new System.Drawing.Size(218, 22);
            this.comboBoxServidor.TabIndex = 22;
            // 
            // comboBoxFinger
            // 
            this.comboBoxFinger.Items.Add("1");
            this.comboBoxFinger.Items.Add("2");
            this.comboBoxFinger.Items.Add("3");
            this.comboBoxFinger.Items.Add("4");
            this.comboBoxFinger.Items.Add("5");
            this.comboBoxFinger.Items.Add("6");
            this.comboBoxFinger.Items.Add("7");
            this.comboBoxFinger.Items.Add("8");
            this.comboBoxFinger.Items.Add("9");
            this.comboBoxFinger.Items.Add("10");
            this.comboBoxFinger.Location = new System.Drawing.Point(155, 27);
            this.comboBoxFinger.Name = "comboBoxFinger";
            this.comboBoxFinger.Size = new System.Drawing.Size(30, 22);
            this.comboBoxFinger.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(132, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 22);
            this.label1.Text = "FP";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 235);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(227, 22);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 280);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFinger);
            this.Controls.Add(this.comboBoxServidor);
            this.Controls.Add(this.checkBoxES);
            this.Controls.Add(this.pictureBoxScan);
            this.Controls.Add(this.labelRespuesta);
            this.Controls.Add(this.pictureBoxIdentificar);
            this.Controls.Add(this.pictureBoxVerificar);
            this.Controls.Add(this.pictureBoxEnrolar);
            this.Controls.Add(this.textBoxRut);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelRut);
            this.Controls.Add(this.labelNombre);
            this.Menu = this.mainMenu1;
            this.Name = "FormInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormInicio_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelRut;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxRut;
        private System.Windows.Forms.PictureBox pictureBoxEnrolar;
        private System.Windows.Forms.PictureBox pictureBoxVerificar;
        private System.Windows.Forms.PictureBox pictureBoxIdentificar;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Label labelRespuesta;
        private System.Windows.Forms.PictureBox pictureBoxScan;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItemEdgeLineConectar;
        private System.Windows.Forms.MenuItem menuItemEdgeLineDesconectar;
        private System.Windows.Forms.CheckBox checkBoxES;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.ComboBox comboBoxServidor;
        private System.Windows.Forms.ComboBox comboBoxFinger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem10;
    }
}

