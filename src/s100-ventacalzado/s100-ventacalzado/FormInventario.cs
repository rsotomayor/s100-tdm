using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;

using MyLibrary;

namespace s100_ventacalzado
{
    public partial class FormInventario : Form
    {
        Producto myproducto_a;

    
  
        public FormInventario()
        {
            InitializeComponent();

            myproducto_a = new Producto();
        }

        private void FillForm(Producto producto_p)
        {
            labelEAN.Text = "EAN:" + producto_p.EAN;
            labelSKU.Text = "SKU: " + producto_p.SKU;
            labelSKU.ForeColor = Color.Red;
            labelDepartamento.Text = "DPTO: " + producto_p.DPTO;
            labelLinea.Text = "LIN: " + producto_p.LINEA;
            labelNombreProducto.Text = producto_p.PROD;
            labelColor.Text = "Color: " + producto_p.color;
            labelTalla.Text = "Talla: " + producto_p.talla;

 
            StatusBar1.Text = "Lectura producto OK";
        }

        private void FillFormClean()
        {
            labelEAN.Text = "EAN: ";
            labelSKU.Text = "SKU: ";
            labelNombreProducto.Text = "PROD: ";
            labelDepartamento.Text = "DPTO: ";
            labelLinea.Text = "LIN: ";
            StatusBar1.Text = "";
            labelStockSector.Text = "Stock Sector: ";
            labelStockBodega.Text = "Stock Sector: ";
            textBoxBarCode.Text = "";

        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }

        private void ButtonINVLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();
            textBoxBarCode.Focus();
        }

        private void menuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUbicacion.Text.Length == 0)
            {
                MessageBox.Show("Sector no es válido");
                return;
            }

            if (textBoxBarCode.Text.Length >= Configuracion.EANSIZE)
            {
                contarProducto();
            }
        }




        private void contarProducto()
        {
            String ean = textBoxBarCode.Text;
            if (textBoxBarCode.Text.Length == 0)
            {
                MessageBox.Show("Error en Articulo");
                textBoxBarCode.Text = "";
                textBoxBarCode.Focus();
                return;
            }

            int cantidad;
            if (checkBoxMasMenos.Checked == true)
            {
                cantidad = (int)1;//numericUpDownCantidad.Value; 
            }
            else
            {
                cantidad = (int)-1;//numericUpDownCantidad.Value; 
            }

            myproducto_a.EAN = textBoxBarCode.Text;

            String location = Configuracion.getLocation();
            String idlocation = Configuracion.getIdLocation();
            String place;
            if (textBoxUbicacion.Text.Length == 0)
            {
                place = null;
            }
            else
            {
                place = textBoxUbicacion.Text;
            }

            String szRetval;
            int retval;

            try
            {
               retval = myproducto_a.getRegistroByEanCalzado(myproducto_a.EAN, out szRetval);
            }
            catch
            {

                StatusBar1.Text = "Error en consulta de producto";
                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: ERR-001 NO ENCONTRADO";
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
                // No cuenta productos no encontrados
                return;
            }


            myproducto_a.flagContar = false;
            if (myproducto_a.idcolor.Trim().Length == 0 || myproducto_a.idtalla.Trim().Length == 0)
            {
                FormAsignaColorTalla myFormAsignaColorTalla = new FormAsignaColorTalla(myproducto_a);
                myFormAsignaColorTalla.ShowDialog();
                FillForm(myproducto_a);
            }
            else
            {
                myproducto_a.flagContar = true;
            }



            String myResponse;
            String idbodega = Configuracion.getIdBodega();

            if (myproducto_a.flagContar == true)
            {
                try
                {
                    retval = myproducto_a.contarCalzado(myproducto_a, cantidad, idlocation, idbodega, place, myproducto_a.idcolor, myproducto_a.idtalla, out myResponse);
                }
                catch
                {
                    StatusBar1.Text = "Error en contar producto";
                    return;
                }
            }
            else
            {
                retval = 1;
                myResponse = "Err:Atributos no seleccionados";
            }


            if ( retval != 0)
            {
                StatusBar1.Text = "Err: " + myResponse;
                textBoxBarCode.Text = null;
                textBoxBarCode.Focus();
                return;
            }
            else
            {
                StatusBar1.Text = "Cuenta: " + myResponse;
            }

            double unidades = 0;
            double unidadesTotales = 0;
            String szRetval1, szRetval2;

            try
            {
                unidades = myproducto_a.getStockCurrentBodegaByColorTalla(myproducto_a.EAN, idlocation, idbodega, place, myproducto_a.idcolor, myproducto_a.idtalla, out szRetval1);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta stock actual";
                return;
            }

            try
            {
                unidadesTotales = myproducto_a.getStockCurrentTotalBodegaByColorTalla(myproducto_a.EAN, idlocation, idbodega, myproducto_a.idcolor, myproducto_a.idtalla, out szRetval2);
            }
            catch
            {
                StatusBar1.Text = "Error: en consulta stock total (Contar )";
                return;
            }

//            LabelInventario.Text = "Stock [" + place + "] = " + unidades + "\n";
            //            LabelInventario.Text = LabelInventario.Text + "Stock [Total] = " + unidadesTotales;


            labelStockSector.Text = "Stock Sector [" + place + "] : " + unidades;
            labelStockBodega.Text = "Stock Bodega [" + idbodega + "] : " + unidadesTotales;
            textBoxBarCode.Text = null;
            textBoxBarCode.Focus();

        }

        private void ButtonConsultar_Click(object sender, EventArgs e)
        {
            if (textBoxUbicacion.Text.Length > 0)
            {
                contarProducto();
            }
            else
            {
                MessageBox.Show("Sector no es válido");
            }
        }

        private void checkBoxMasMenos_CheckStateChanged(object sender, EventArgs e)
        {
            textBoxBarCode.Focus();
        }


    }
}