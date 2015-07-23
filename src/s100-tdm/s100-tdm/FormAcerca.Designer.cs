namespace s100_tdm
{
    partial class FormAcerca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAcerca));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelAcerca = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(11, 1);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(150, 34);
            // 
            // labelAcerca
            // 
            this.labelAcerca.Location = new System.Drawing.Point(12, 41);
            this.labelAcerca.Name = "labelAcerca";
            this.labelAcerca.Size = new System.Drawing.Size(197, 200);
            this.labelAcerca.Text = "labelAcerca";
            // 
            // FormAcerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 280);
            this.Controls.Add(this.labelAcerca);
            this.Controls.Add(this.pictureBoxLogo);
            this.Menu = this.mainMenu1;
            this.Name = "FormAcerca";
            this.Text = "Acerca ..";
            this.Load += new System.EventHandler(this.FormAcerca_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelAcerca;
    }
}