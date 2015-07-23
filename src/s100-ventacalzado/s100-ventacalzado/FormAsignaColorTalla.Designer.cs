namespace s100_ventacalzado
{
    partial class FormAsignaColorTalla
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
            this.buttonAsignaAtributos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.comboBoxTalla = new System.Windows.Forms.ComboBox();
            this.labelSKU = new System.Windows.Forms.Label();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAsignaAtributos
            // 
            this.buttonAsignaAtributos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonAsignaAtributos.Location = new System.Drawing.Point(51, 158);
            this.buttonAsignaAtributos.Name = "buttonAsignaAtributos";
            this.buttonAsignaAtributos.Size = new System.Drawing.Size(129, 20);
            this.buttonAsignaAtributos.TabIndex = 0;
            this.buttonAsignaAtributos.Text = "Asigna Atributos";
            this.buttonAsignaAtributos.Click += new System.EventHandler(this.buttonAsignaAtributos_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.Text = "Color";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.Text = "Talla";
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBoxColor.Location = new System.Drawing.Point(62, 121);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(141, 20);
            this.comboBoxColor.TabIndex = 25;
            // 
            // comboBoxTalla
            // 
            this.comboBoxTalla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBoxTalla.Location = new System.Drawing.Point(62, 90);
            this.comboBoxTalla.Name = "comboBoxTalla";
            this.comboBoxTalla.Size = new System.Drawing.Size(141, 20);
            this.comboBoxTalla.TabIndex = 24;
            // 
            // labelSKU
            // 
            this.labelSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelSKU.Location = new System.Drawing.Point(3, 9);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(224, 20);
            this.labelSKU.Text = "SKU:";
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelNombreProducto.Location = new System.Drawing.Point(4, 31);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(224, 49);
            this.labelNombreProducto.Text = "Nombre:";

            // 
            // FormAsignaColorTalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.comboBoxTalla);
            this.Controls.Add(this.buttonAsignaAtributos);
            this.Menu = this.mainMenu1;
            this.Name = "FormAsignaColorTalla";
            this.Text = "Asigna Color/Talla";
            this.Load += new System.EventHandler(this.FormAsignaColorTalla_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAsignaAtributos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.ComboBox comboBoxTalla;
        private System.Windows.Forms.Label labelSKU;
        private System.Windows.Forms.Label labelNombreProducto;
    }
}