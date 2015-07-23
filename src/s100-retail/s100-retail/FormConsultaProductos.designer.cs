namespace s100_retail
{
    partial class FormConsultaProductos
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
            this.comboBoxDepartamento = new System.Windows.Forms.ComboBox();
            this.comboBoxLinea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEAN = new System.Windows.Forms.TextBox();
            this.checkBoxCodNom = new System.Windows.Forms.CheckBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.dataGridProductos = new System.Windows.Forms.DataGrid();
            this.buttonConsultar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDepartamento
            // 
            this.comboBoxDepartamento.Location = new System.Drawing.Point(52, 3);
            this.comboBoxDepartamento.Name = "comboBoxDepartamento";
            this.comboBoxDepartamento.Size = new System.Drawing.Size(185, 22);
            this.comboBoxDepartamento.TabIndex = 0;
            // 
            // comboBoxLinea
            // 
            this.comboBoxLinea.Location = new System.Drawing.Point(52, 31);
            this.comboBoxLinea.Name = "comboBoxLinea";
            this.comboBoxLinea.Size = new System.Drawing.Size(185, 22);
            this.comboBoxLinea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.Text = "Dpto:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.Text = "Linea:";
            // 
            // textBoxEAN
            // 
            this.textBoxEAN.Location = new System.Drawing.Point(90, 60);
            this.textBoxEAN.Name = "textBoxEAN";
            this.textBoxEAN.Size = new System.Drawing.Size(146, 21);
            this.textBoxEAN.TabIndex = 5;
            // 
            // checkBoxCodNom
            // 
            this.checkBoxCodNom.Checked = true;
            this.checkBoxCodNom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCodNom.Location = new System.Drawing.Point(3, 59);
            this.checkBoxCodNom.Name = "checkBoxCodNom";
            this.checkBoxCodNom.Size = new System.Drawing.Size(81, 20);
            this.checkBoxCodNom.TabIndex = 6;
            this.checkBoxCodNom.Text = "Cod/Nom";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 246);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridProductos.Location = new System.Drawing.Point(0, 108);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.Size = new System.Drawing.Size(240, 138);
            this.dataGridProductos.TabIndex = 8;
            // 
            // buttonConsultar
            // 
            this.buttonConsultar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonConsultar.Location = new System.Drawing.Point(3, 84);
            this.buttonConsultar.Name = "buttonConsultar";
            this.buttonConsultar.Size = new System.Drawing.Size(72, 20);
            this.buttonConsultar.TabIndex = 9;
            this.buttonConsultar.Text = "Consultar";
            this.buttonConsultar.Click += new System.EventHandler(this.buttonConsultar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonLimpiar.Location = new System.Drawing.Point(81, 84);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(72, 20);
            this.buttonLimpiar.TabIndex = 10;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // FormConsultaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonConsultar);
            this.Controls.Add(this.dataGridProductos);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.checkBoxCodNom);
            this.Controls.Add(this.textBoxEAN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLinea);
            this.Controls.Add(this.comboBoxDepartamento);
            this.Menu = this.mainMenu1;
            this.Name = "FormConsultaProductos";
            this.Text = "Consulta Productos";
            this.Load += new System.EventHandler(this.FormConsultaProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDepartamento;
        private System.Windows.Forms.ComboBox comboBoxLinea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEAN;
        private System.Windows.Forms.CheckBox checkBoxCodNom;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.DataGrid dataGridProductos;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}