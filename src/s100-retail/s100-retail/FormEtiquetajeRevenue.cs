using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyLibrary;

namespace s100_retail
{
    public partial class FormEtiquetajeRevenue : Form
    {
        Producto myproducto_a;

        public FormEtiquetajeRevenue()
        {
            InitializeComponent();
            myproducto_a = new Producto();
        }

        private void FillForm(Producto producto_p)
        {
            labelEAN.Text = producto_p.EAN;
            labelSKU.Text = "SKU: " + producto_p.SKU;
            labelSKU.ForeColor = Color.Red;
            //LabelidDepartamento.Text = "idDepto: " + producto_p.iddepartamento;
            labelDepartamento.Text = "DPTO: " + producto_p.iddepartamento + " - " + producto_p.DPTO;
            //LabelidLinea.Text = "idLinea: " + producto_p.idlinea;
            labelLinea.Text = "LINEA: " + producto_p.idlinea + " - " + producto_p.LINEA;
            labelNombreProducto.Text = producto_p.PROD;
            labelPrecio.Text = "$ " + String.Format("{0:0,0}", producto_p.PRECIO);
            labelStock.Text = "Stock: " + producto_p.stock;
            labelSemanaAntiguedad.Text = "SA: " + producto_p.SemanaAntiguedad;


            if (producto_p.flagRevenue == 1)
            {
                ButtonImprimirRevenue.Enabled = true;
                MyGlobal.MessageBeep(MyGlobal.BeepTypes.Ok);
            }
            else
            {
                ButtonImprimirRevenue.Enabled = false;
            }

            if (producto_p.flagEtiquetar == 1)
            {
                buttonImprimirPromocion.Enabled = true;
            }
            else
            {
                buttonImprimirPromocion.Enabled = false;
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
            //LabelidDepartamento.Text = "idDepto: ";
            labelDepartamento.Text = "DPTO: ";
            //LabelidLinea.Text = "idLinea: ";
            labelLinea.Text = "LINEA: ";
            labelSemanaAntiguedad.Text = "SA : ";

            ButtonImprimirRevenue.Enabled = false;
            buttonImprimirPromocion.Enabled = false;
            StatusBar1.Text = "";
        }

        private void ButtonImprimirRevenue_Click(object sender, EventArgs e)
        {
            ButtonImprimirRevenue.Enabled = false;
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

            errCode = Impresora.imprimeRevenue(myproducto_a.EAN, myproducto_a.SKU, myproducto_a.PROD, myproducto_a.DPTO, myproducto_a.LINEA, myproducto_a.PRECIO, myproducto_a.iddepartamento, myproducto_a.idlinea, out szRetval);

            if ( errCode == 0)
            {
                Etiqueta.actualizaTransaccion(myproducto_a, Constants.ETIQUETAJEREVENUE, place, cantidad);
                StatusBar1.Text = "Impresion Revenue OK";
            } else if ( errCode == -99 ) {
                Etiqueta.actualizaTransaccion(myproducto_a, Constants.ETIQUETAJEREVENUE, place, cantidad);
                StatusBar1.Text = "Dev: " + errCode + ", " + szRetval;
            }
            else
            {
                StatusBar1.Text = "Error Print: " + errCode + ", " + szRetval;
            }



            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();

        }

        private void FormEtiquetajeRevenue_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }



        private void buttonImprimirPromocion_Click(object sender, EventArgs e)
        {
            buttonImprimirPromocion.Enabled = false;
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

            if (errCode == 0)
            {
                Etiqueta.registraTransaccion(myproducto_a, Constants.ETIQUETAJEPROMOCIONAL, place, cantidad, out szRetval);
                StatusBar1.Text = "Impresión Promoción OK";
            }
            else if (errCode == -99)
            {
                Etiqueta.registraTransaccion(myproducto_a, Constants.ETIQUETAJEPROMOCIONAL, place, cantidad, out szRetval);
                StatusBar1.Text = "Dev: " + errCode + ", " + szRetval;
            }
            else
            {
                StatusBar1.Text = "Error Print: " + errCode + ", " + szRetval;
            }

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
                StatusBar1.Text = "Error en consulta de producto";
                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: NO ENCONTRADO";
                return;
            }


            if (retval == 0)
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
                Etiqueta.registraTransaccion(myproducto_a, Constants.ETIQUETAJEREVENUE, place, 0, out szRetval);
            }
            catch
            {
                StatusBar1.Text = "Error al registrar transacción";
                return;
            }
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
  

        }

        private void ButtonEnviar_Click(object sender, EventArgs e)
        {
            consultarProducto();
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();
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

        private void LabelidDepartamento_ParentChanged(object sender, EventArgs e)
        {

        }


    }
}