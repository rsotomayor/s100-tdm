using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SQLite;
using System.Security.Cryptography;
using MyLibrary;

namespace s100_retail
{

    public partial class FormEtiquetajePromocional : Form
    {

        Producto myproducto_a;
        public FormEtiquetajePromocional()
        {
            InitializeComponent();
            myproducto_a = new Producto();
        }

        private void FillForm(Producto producto_p)
        {
            labelEAN.Text = producto_p.EAN;
            labelSKU.Text = "SKU: " + producto_p.SKU;
            labelSKU.ForeColor = Color.Red;
            labelDepartamento.Text = "DPTO: " + producto_p.DPTO;
            labelLinea.Text = "LIN: " + producto_p.LINEA;
            labelNombreProducto.Text = producto_p.PROD;
            labelPrecio.Text = "$ " + String.Format("{0:0,0}", producto_p.PRECIO);
            labelStock.Text = "Stock: " + producto_p.stock;
            labelSemanaAntiguedad.Text = "SA : " + producto_p.SemanaAntiguedad;

            if (producto_p.flagEtiquetar == 1)
            {
                MyGlobal.MessageBeep(MyGlobal.BeepTypes.Ok);
                ButtonImprimirPromocional.Enabled = true;
            } else 
            {
                ButtonImprimirPromocional.Enabled = false ;
            }
            StatusBar1.Text = "Lectura producto OK";
        }

        private void FillFormClean() 
        {
            labelEAN.Text = "EAN: ";
            labelSKU.Text = "SKU: ";
            labelNombreProducto.Text = "PROD: ";
            labelPrecio.Text = "PRECIO: ";
            labelStock.Text = "Stock: ";
            labelDepartamento.Text = "DPTO: ";
            labelLinea.Text = "LIN: ";
            labelSemanaAntiguedad.Text = "SA : ";
            ButtonImprimirPromocional.Enabled = false;

            StatusBar1.Text = "";
        }

        private void ButtonEnviarPromocional_Click(object sender, EventArgs e)
        {
            consultarProducto();
        }

        private void ButtonLimpiarPromocional_Click(object sender, EventArgs e)
        {
            FillFormClean();
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }

        private void ButtonImprimirPromocional_Click(object sender, EventArgs e)
        {
            ButtonImprimirPromocional.Enabled = false;
            int cantidad;
            cantidad = (int)1; // numericUpDownNumeroImpresiones.Value; 
            String place;
            if (textBoxUbicacion.Text.Length == 0)
            {
                place = null;
            }
            else
            {
                place = textBoxUbicacion.Text;
            }

            int errCode;
            String szRetval;

            errCode = Impresora.imprimePromocional(myproducto_a.SKU, myproducto_a.PRECIO, out szRetval);

            if ( errCode == 0)
            {
                Etiqueta.actualizaTransaccion(myproducto_a, Constants.ETIQUETAJEPROMOCIONAL, place, cantidad);
                StatusBar1.Text = "Impresión Promoción OK";
            } else if ( errCode == -99 ) {
                Etiqueta.actualizaTransaccion(myproducto_a, Constants.ETIQUETAJEPROMOCIONAL, place, cantidad);
                StatusBar1.Text = "Dev: " + errCode + ", " + szRetval;
            }
            else
            {
                StatusBar1.Text = "Error Print: " + errCode + ", " + szRetval;
            }

            textBoxBarCode.Focus();
        }


        private void FormEtiquetajePromocional_Load(object sender, EventArgs e)
        {

            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
 
        }

        private void consultarProducto()
        {

            String szRetval;
            int retval;
            String ean = textBoxBarCode.Text;

            try
            {
                retval = myproducto_a.getRegistroByEan(textBoxBarCode.Text, out szRetval);
             }
            catch
            {
                MessageBox.Show("Error en consulta de producto");
                StatusBar1.Text = "Error en consulta de producto";
                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: NO ENCONTRADO";
                return;
            }

            //MessageBox.Show(szRetval);

            if ( retval == 0)
            {
                FillForm(myproducto_a);
            }
            else
            {
                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: NO ENCONTRADO";
            }

            String place;
            if (textBoxUbicacion.Text.Length == 0)
            {
                place = null;
            }
            else
            {
                place = textBoxUbicacion.Text;
            }

            try
            {
                Etiqueta.registraTransaccion(myproducto_a, Constants.ETIQUETAJEPROMOCIONAL, place, 0, out szRetval);
            }
            catch
            {
                StatusBar1.Text = "Error al registrar transacción";
                return;
            }
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();

        }

        private void textBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarCode.Text.Length >= Configuracion.EANSIZE)
            {
                consultarProducto();
            }
        }

    }
}