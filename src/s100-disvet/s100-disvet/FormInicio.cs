using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace s100_disvet
{
    public partial class FormInicio : Form
    {
        FormVenta myFormVenta_a;
        FormSincronizacion myFormSincronizacion_a;

        public FormInicio()
        {
            InitializeComponent();
            myFormVenta_a = new FormVenta();
            myFormSincronizacion_a = new FormSincronizacion();

        }

        private void menuItemVentas_Click(object sender, EventArgs e)
        {
            myFormVenta_a.Show();       
        }

        private void menuItemTransferir_Click(object sender, EventArgs e)
        {
            myFormSincronizacion_a.Show(); 
        }

        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


    }
}