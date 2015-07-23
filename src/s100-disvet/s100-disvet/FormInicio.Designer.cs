namespace s100_disvet
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemVentas = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItemTransferir = new System.Windows.Forms.MenuItem();
            this.menuItemSalir = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.labelMem = new System.Windows.Forms.Label();
            this.labelFree = new System.Windows.Forms.Label();
            this.labelTot = new System.Windows.Forms.Label();
            this.labelDev = new System.Windows.Forms.Label();
            this.labelBat = new System.Windows.Forms.Label();
            this.labelBatCargando = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            this.mainMenu1.MenuItems.Add(this.menuItemTransferir);
            this.mainMenu1.MenuItems.Add(this.menuItemSalir);
            this.mainMenu1.MenuItems.Add(this.menuItem5);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItemVentas);
            this.menuItem1.Text = "Clientes";
            // 
            // menuItemVentas
            // 
            this.menuItemVentas.Text = "Ventas";
            this.menuItemVentas.Click += new System.EventHandler(this.menuItemVentas_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItem6);
            this.menuItem2.Text = "Info";
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "Info Ventas";
            // 
            // menuItemTransferir
            // 
            this.menuItemTransferir.Text = "Transferir";
            this.menuItemTransferir.Click += new System.EventHandler(this.menuItemTransferir_Click);
            // 
            // menuItemSalir
            // 
            this.menuItemSalir.Text = "Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "?";
            // 
            // labelMem
            // 
            this.labelMem.ForeColor = System.Drawing.Color.Lime;
            this.labelMem.Location = new System.Drawing.Point(3, 6);
            this.labelMem.Name = "labelMem";
            this.labelMem.Size = new System.Drawing.Size(100, 20);
            this.labelMem.Text = "mem:  XX%";
            // 
            // labelFree
            // 
            this.labelFree.ForeColor = System.Drawing.Color.Lime;
            this.labelFree.Location = new System.Drawing.Point(3, 26);
            this.labelFree.Name = "labelFree";
            this.labelFree.Size = new System.Drawing.Size(100, 20);
            this.labelFree.Text = "free: XX.X mb";
            // 
            // labelTot
            // 
            this.labelTot.ForeColor = System.Drawing.Color.Lime;
            this.labelTot.Location = new System.Drawing.Point(3, 46);
            this.labelTot.Name = "labelTot";
            this.labelTot.Size = new System.Drawing.Size(100, 20);
            this.labelTot.Text = "tot: XXX.X mb";
            // 
            // labelDev
            // 
            this.labelDev.ForeColor = System.Drawing.Color.Lime;
            this.labelDev.Location = new System.Drawing.Point(3, 66);
            this.labelDev.Name = "labelDev";
            this.labelDev.Size = new System.Drawing.Size(100, 20);
            this.labelDev.Text = "dev: XXX.X mb";
            // 
            // labelBat
            // 
            this.labelBat.ForeColor = System.Drawing.Color.Lime;
            this.labelBat.Location = new System.Drawing.Point(140, 6);
            this.labelBat.Name = "labelBat";
            this.labelBat.Size = new System.Drawing.Size(97, 20);
            this.labelBat.Text = "bat: ";
            this.labelBat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelBatCargando
            // 
            this.labelBatCargando.ForeColor = System.Drawing.Color.Lime;
            this.labelBatCargando.Location = new System.Drawing.Point(140, 26);
            this.labelBatCargando.Name = "labelBatCargando";
            this.labelBatCargando.Size = new System.Drawing.Size(97, 20);
            this.labelBatCargando.Text = "cargando ";
            this.labelBatCargando.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(140, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.Text = "AC/DC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(140, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.Text = "app: XX.X mb";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 20);
            this.label3.Text = "dev: XXX.X mb";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 74);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(140, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.Text = "v 1.0.0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(12, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 20);
            this.label5.Text = "Id";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBatCargando);
            this.Controls.Add(this.labelBat);
            this.Controls.Add(this.labelDev);
            this.Controls.Add(this.labelTot);
            this.Controls.Add(this.labelFree);
            this.Controls.Add(this.labelMem);
            this.Menu = this.mainMenu1;
            this.Name = "FormInicio";
            this.Text = "DISVET";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMem;
        private System.Windows.Forms.Label labelFree;
        private System.Windows.Forms.Label labelTot;
        private System.Windows.Forms.Label labelDev;
        private System.Windows.Forms.Label labelBat;
        private System.Windows.Forms.Label labelBatCargando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemTransferir;
        private System.Windows.Forms.MenuItem menuItemSalir;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItemVentas;
    }
}

