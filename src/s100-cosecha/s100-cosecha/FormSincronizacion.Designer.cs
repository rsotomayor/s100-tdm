namespace s100_cosecha
{
    partial class FormSincronizacion
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
            this.labelSincronizacion = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ButtonSincronizaEnviar = new System.Windows.Forms.Button();
            this.ButtonSincronizaRecibir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSincronizacion
            // 
            this.labelSincronizacion.Location = new System.Drawing.Point(15, 131);
            this.labelSincronizacion.Name = "labelSincronizacion";
            this.labelSincronizacion.Size = new System.Drawing.Size(211, 56);
            this.labelSincronizacion.Text = "....";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(15, 212);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(211, 20);
            // 
            // ButtonSincronizaEnviar
            // 
            this.ButtonSincronizaEnviar.Location = new System.Drawing.Point(38, 80);
            this.ButtonSincronizaEnviar.Name = "ButtonSincronizaEnviar";
            this.ButtonSincronizaEnviar.Size = new System.Drawing.Size(163, 37);
            this.ButtonSincronizaEnviar.TabIndex = 12;
            this.ButtonSincronizaEnviar.Text = "Enviar Transacciones";
            // 
            // ButtonSincronizaRecibir
            // 
            this.ButtonSincronizaRecibir.Location = new System.Drawing.Point(38, 37);
            this.ButtonSincronizaRecibir.Name = "ButtonSincronizaRecibir";
            this.ButtonSincronizaRecibir.Size = new System.Drawing.Size(163, 37);
            this.ButtonSincronizaRecibir.TabIndex = 11;
            this.ButtonSincronizaRecibir.Text = "Recibir Maestros";
            // 
            // FormSincronizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.labelSincronizacion);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.ButtonSincronizaEnviar);
            this.Controls.Add(this.ButtonSincronizaRecibir);
            this.Menu = this.mainMenu1;
            this.Name = "FormSincronizacion";
            this.Text = "Sincronización";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSincronizacion;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Button ButtonSincronizaEnviar;
        internal System.Windows.Forms.Button ButtonSincronizaRecibir;
    }
}