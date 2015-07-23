using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace s100_tdm
{
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
        }

        public void ingresaItem(String valor_p)
        {
            ListViewItem valor;
            valor = new ListViewItem();

            valor.Text = valor_p;
            listViewDebug.Items.Insert(0, valor);
        }
        private void FormDebug_Load(object sender, EventArgs e)
        {

        }
    }
}