namespace s100_retail
{
    partial class FormMaestros
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSincronizacion
            // 
            this.labelSincronizacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSincronizacion.Location = new System.Drawing.Point(15, 23);
            this.labelSincronizacion.Name = "labelSincronizacion";
            this.labelSincronizacion.Size = new System.Drawing.Size(211, 174);
            this.labelSincronizacion.Text = "....";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(15, 214);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(211, 20);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(67, 240);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(84, 20);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormMaestros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.labelSincronizacion);
            this.Menu = this.mainMenu1;
            this.Name = "FormMaestros";
            this.Text = "Maestros";
            this.Load += new System.EventHandler(this.FormMaestros_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSincronizacion;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Button buttonCancelar;
    }
}