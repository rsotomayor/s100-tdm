namespace s100_tdm
{
    partial class FormDebug
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
            this.listViewDebug = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewDebug
            // 
            this.listViewDebug.Location = new System.Drawing.Point(3, 3);
            this.listViewDebug.Name = "listViewDebug";
            this.listViewDebug.Size = new System.Drawing.Size(224, 230);
            this.listViewDebug.TabIndex = 0;
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 280);
            this.Controls.Add(this.listViewDebug);
            this.Menu = this.mainMenu1;
            this.Name = "FormDebug";
            this.Text = "FormDebug";
            this.Load += new System.EventHandler(this.FormDebug_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDebug;
    }
}