namespace s100_retail
{
    partial class FormCajas
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
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.dataGridCajas = new System.Windows.Forms.DataGrid();
            this.ButtonLimpiar = new System.Windows.Forms.Button();
            this.ButtonConsultar = new System.Windows.Forms.Button();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxBarCode.Location = new System.Drawing.Point(67, 3);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(170, 19);
            this.textBoxBarCode.TabIndex = 49;
            this.textBoxBarCode.TextChanged += new System.EventHandler(this.textBoxBarCode_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(5, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 20);
            this.Label1.Text = "BarCode";
            // 
            // labelResponse
            // 
            this.labelResponse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelResponse.Location = new System.Drawing.Point(3, 55);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(232, 34);
            this.labelResponse.Text = "....";
            // 
            // dataGridCajas
            // 
            this.dataGridCajas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridCajas.Location = new System.Drawing.Point(4, 94);
            this.dataGridCajas.Name = "dataGridCajas";
            this.dataGridCajas.Size = new System.Drawing.Size(233, 146);
            this.dataGridCajas.TabIndex = 52;
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonLimpiar.Location = new System.Drawing.Point(125, 29);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(84, 20);
            this.ButtonLimpiar.TabIndex = 56;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // ButtonConsultar
            // 
            this.ButtonConsultar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButtonConsultar.Location = new System.Drawing.Point(22, 29);
            this.ButtonConsultar.Name = "ButtonConsultar";
            this.ButtonConsultar.Size = new System.Drawing.Size(84, 20);
            this.ButtonConsultar.TabIndex = 55;
            this.ButtonConsultar.Text = "Consultar";
            this.ButtonConsultar.Click += new System.EventHandler(this.ButtonConsultar_Click);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 246);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // FormCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.ButtonConsultar);
            this.Controls.Add(this.dataGridCajas);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.textBoxBarCode);
            this.Controls.Add(this.Label1);
            this.Menu = this.mainMenu1;
            this.Name = "FormCajas";
            this.Text = "Cajas";
            this.Load += new System.EventHandler(this.FormCajas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox textBoxBarCode;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.DataGrid dataGridCajas;
        internal System.Windows.Forms.Button ButtonLimpiar;
        internal System.Windows.Forms.Button ButtonConsultar;
        private System.Windows.Forms.StatusBar StatusBar1;
    }
}