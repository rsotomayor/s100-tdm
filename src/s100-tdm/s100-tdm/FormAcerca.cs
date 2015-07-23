using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace s100_tdm
{
    public partial class FormAcerca : Form
    {
        public FormAcerca()
        {
            InitializeComponent();
        }

        private void FormAcerca_Load(object sender, EventArgs e)
        {
        }

        public void setLabelAcerca(string label_p)
        {
            labelAcerca.Text = label_p;


        }
    }
}