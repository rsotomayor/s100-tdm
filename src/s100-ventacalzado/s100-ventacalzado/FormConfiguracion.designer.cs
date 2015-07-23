namespace s100_ventacalzado
{
    partial class FormConfiguracion
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
            this.buttonGrabar = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.tabControlConfiguracion = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPacketSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDBPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIdDevice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUrlMaestrosPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrlPost = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxGpsLog = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTimeoutLogGps = new System.Windows.Forms.TextBox();
            this.tabControlConfiguracion.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGrabar
            // 
            this.buttonGrabar.Location = new System.Drawing.Point(50, 222);
            this.buttonGrabar.Name = "buttonGrabar";
            this.buttonGrabar.Size = new System.Drawing.Size(119, 20);
            this.buttonGrabar.TabIndex = 1;
            this.buttonGrabar.Text = "Guardar";
            this.buttonGrabar.Click += new System.EventHandler(this.buttonGrabar_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 246);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // tabControlConfiguracion
            // 
            this.tabControlConfiguracion.Controls.Add(this.tabPage1);
            this.tabControlConfiguracion.Controls.Add(this.tabPage2);
            this.tabControlConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.tabControlConfiguracion.Name = "tabControlConfiguracion";
            this.tabControlConfiguracion.SelectedIndex = 0;
            this.tabControlConfiguracion.Size = new System.Drawing.Size(240, 216);
            this.tabControlConfiguracion.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBoxPacketSize);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBoxDBPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBoxIdDevice);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxUrlMaestrosPrefix);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxUrlPost);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 193);
            this.tabPage1.Text = "Parámetros";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.Text = "Packet Size:";
            // 
            // textBoxPacketSize
            // 
            this.textBoxPacketSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxPacketSize.Location = new System.Drawing.Point(110, 143);
            this.textBoxPacketSize.Name = "textBoxPacketSize";
            this.textBoxPacketSize.Size = new System.Drawing.Size(70, 19);
            this.textBoxPacketSize.TabIndex = 27;
            this.textBoxPacketSize.Text = "1024";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.Text = "DB Path:";
            // 
            // textBoxDBPath
            // 
            this.textBoxDBPath.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxDBPath.Location = new System.Drawing.Point(66, 118);
            this.textBoxDBPath.Name = "textBoxDBPath";
            this.textBoxDBPath.Size = new System.Drawing.Size(171, 19);
            this.textBoxDBPath.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.Text = "IdDevice:";
            // 
            // textBoxIdDevice
            // 
            this.textBoxIdDevice.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxIdDevice.Location = new System.Drawing.Point(66, 83);
            this.textBoxIdDevice.Name = "textBoxIdDevice";
            this.textBoxIdDevice.Size = new System.Drawing.Size(171, 19);
            this.textBoxIdDevice.TabIndex = 21;
            this.textBoxIdDevice.Text = "PDA001";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.Text = "UrlPrefix:";
            // 
            // textBoxUrlMaestrosPrefix
            // 
            this.textBoxUrlMaestrosPrefix.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxUrlMaestrosPrefix.Location = new System.Drawing.Point(66, 55);
            this.textBoxUrlMaestrosPrefix.Name = "textBoxUrlMaestrosPrefix";
            this.textBoxUrlMaestrosPrefix.Size = new System.Drawing.Size(171, 19);
            this.textBoxUrlMaestrosPrefix.TabIndex = 20;
            this.textBoxUrlMaestrosPrefix.Text = "http://ripley.rso.cl/apps/db/rpycal_maestros";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.Text = "UrlPost:";
            // 
            // textBoxUrlPost
            // 
            this.textBoxUrlPost.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxUrlPost.Location = new System.Drawing.Point(66, 30);
            this.textBoxUrlPost.Name = "textBoxUrlPost";
            this.textBoxUrlPost.Size = new System.Drawing.Size(171, 19);
            this.textBoxUrlPost.TabIndex = 18;
            this.textBoxUrlPost.Text = "http://ripley.rso.cl/apps/src/ws/wsgateway.php";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxGpsLog);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxTimeoutLogGps);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 190);
            this.tabPage2.Text = "Gps";
            // 
            // checkBoxGpsLog
            // 
            this.checkBoxGpsLog.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxGpsLog.Location = new System.Drawing.Point(30, 23);
            this.checkBoxGpsLog.Name = "checkBoxGpsLog";
            this.checkBoxGpsLog.Size = new System.Drawing.Size(182, 20);
            this.checkBoxGpsLog.TabIndex = 25;
            this.checkBoxGpsLog.Text = "Habilita Registro Posición";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(30, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.Text = "TimeOut Log:";
            // 
            // textBoxTimeoutLogGps
            // 
            this.textBoxTimeoutLogGps.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxTimeoutLogGps.Location = new System.Drawing.Point(131, 49);
            this.textBoxTimeoutLogGps.Name = "textBoxTimeoutLogGps";
            this.textBoxTimeoutLogGps.Size = new System.Drawing.Size(63, 19);
            this.textBoxTimeoutLogGps.TabIndex = 24;
            this.textBoxTimeoutLogGps.Text = "300";
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControlConfiguracion);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.buttonGrabar);
            this.Menu = this.mainMenu1;
            this.Name = "FormConfiguracion";
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.FormConfiguracion_Load);
            this.tabControlConfiguracion.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGrabar;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.TabControl tabControlConfiguracion;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDBPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIdDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUrlMaestrosPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUrlPost;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTimeoutLogGps;
        private System.Windows.Forms.CheckBox checkBoxGpsLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPacketSize;


    }
}