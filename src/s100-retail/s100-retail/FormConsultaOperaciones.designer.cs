namespace s100_retail
{
    partial class FormConsultaOperaciones
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
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.dataGridProductos = new System.Windows.Forms.DataGrid();
            this.buttonConsultar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonRecogida = new System.Windows.Forms.RadioButton();
            this.radioButtonRevenue = new System.Windows.Forms.RadioButton();
            this.radioButtonPromocion = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonRecogida);
            this.panel1.Controls.Add(this.radioButtonRevenue);
            this.panel1.Controls.Add(this.radioButtonPromocion);
            this.panel1.Location = new System.Drawing.Point(1, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 22);
            // 
            // radioButtonRecogida
            // 
            this.radioButtonRecogida.Location = new System.Drawing.Point(161, 0);
            this.radioButtonRecogida.Name = "radioButtonRecogida";
            this.radioButtonRecogida.Size = new System.Drawing.Size(78, 20);
            this.radioButtonRecogida.TabIndex = 2;
            this.radioButtonRecogida.Text = "Recogida";
            // 
            // radioButtonRevenue
            // 
            this.radioButtonRevenue.Location = new System.Drawing.Point(87, 1);
            this.radioButtonRevenue.Name = "radioButtonRevenue";
            this.radioButtonRevenue.Size = new System.Drawing.Size(77, 20);
            this.radioButtonRevenue.TabIndex = 1;
            this.radioButtonRevenue.Text = "Revenue";
            // 
            // radioButtonPromocion
            // 
            this.radioButtonPromocion.Location = new System.Drawing.Point(2, 1);
            this.radioButtonPromocion.Name = "radioButtonPromocion";
            this.radioButtonPromocion.Size = new System.Drawing.Size(82, 20);
            this.radioButtonPromocion.TabIndex = 0;
            this.radioButtonPromocion.Text = "Promoción";
            // 
            // FormConsultaOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonConsultar);
            this.Controls.Add(this.dataGridProductos);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLinea);
            this.Controls.Add(this.comboBoxDepartamento);
            this.Menu = this.mainMenu1;
            this.Name = "FormConsultaOperaciones";
            this.Text = "Consulta Productos";
            this.Load += new System.EventHandler(this.FormConsultaOperaciones_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDepartamento;
        private System.Windows.Forms.ComboBox comboBoxLinea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.DataGrid dataGridProductos;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonRevenue;
        private System.Windows.Forms.RadioButton radioButtonPromocion;
        private System.Windows.Forms.RadioButton radioButtonRecogida;
    }
}