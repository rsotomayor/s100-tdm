using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyLibrary;

namespace s100_ventacalzado
{
    public partial class FormMovimiento : Form
    {
        Producto myproducto_a;

        public FormMovimiento()
        {
            InitializeComponent();

            myproducto_a = new Producto();
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();

            textBoxOrigen.Text = "";
            textBoxDestino.Text = "";
            textBoxBarCode.Focus();
        }

        private void FillForm(Producto producto_p)
        {
            labelEAN.Text = "EAN:" + producto_p.EAN;
            labelSKU.Text = "SKU: " + producto_p.SKU;
            labelSKU.ForeColor = Color.Red;
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
            labelTalla.Text = "Talla: ";
            labelColor.Text = "Color: ";
            labelStockOrigen.Text = "Stock Origen: ";
            labelStockDestino.Text = "Stock Destino: ";
            labelStockBodega.Text = "Stock Bodega: ";

            textBoxBarCode.Text = "";

            StatusBar1.Text = "";
        }

        private void moverProducto()
        {
            String ean = textBoxBarCode.Text;
            if (textBoxBarCode.Text.Length == 0)
            {
                MessageBox.Show("Error en Articulo");
                textBoxBarCode.Text = "";
                textBoxBarCode.Focus();
                return;
            }

            if (textBoxOrigen.Text == textBoxDestino.Text)
            {
                MessageBox.Show("Origen no puede ser el mismo que el destino","Advertencia");
                FillFormClean();
                return;
            }


            myproducto_a.EAN = textBoxBarCode.Text;

            String location = Configuracion.getLocation();
            String idlocation = Configuracion.getIdLocation();

            String placeOrigen;
            if (textBoxOrigen.Text.Length == 0)
            {
                placeOrigen = null;
            }
            else
            {
                placeOrigen = textBoxOrigen.Text;
            }

            String placeDestino;
            if (textBoxDestino.Text.Length == 0)
            {
                placeDestino = null;
            }
            else
            {
                placeDestino = textBoxDestino.Text;
            }

            String szRetval;
            int retval=-1;

            try
            {
                retval = myproducto_a.getRegistroByEanCalzado(myproducto_a.EAN, out szRetval);
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
                // No registra producto
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
            int cantidad;

            cantidad = -1;

            String idbodega = Configuracion.getIdBodega();
            if (myproducto_a.flagContar == true )
            {
                try
                {
                    retval = myproducto_a.contarCalzado(myproducto_a, cantidad, idlocation, idbodega, placeOrigen, myproducto_a.idcolor, myproducto_a.idtalla, out myResponse);
                }
                catch
                {
                    StatusBar1.Text = "Error en contar producto";
                    return;
                }


                cantidad = 1;

                try
                {
                    retval = myproducto_a.contarCalzado(myproducto_a, cantidad, idlocation, idbodega, placeDestino, myproducto_a.idcolor, myproducto_a.idtalla, out myResponse);
                }
                catch
                {
                    StatusBar1.Text = "Error en contar producto";
                    return;
                }

            }
            else
            {
                StatusBar1.Text = "Error en atributos";
                textBoxBarCode.Text = null;
                textBoxBarCode.Focus();
                return;
            }


            double unidadesOrigen,unidadesDestino = 0;
            double unidadesTotales = 0;
            String szRetval1, szRetval2;

            try
            {
                unidadesOrigen = myproducto_a.getStockCurrentBodegaByColorTalla(myproducto_a.EAN, idlocation, idbodega, placeOrigen, myproducto_a.idcolor, myproducto_a.idtalla, out szRetval1);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta stock actual";
                return;
            }

            try
            {
                unidadesDestino = myproducto_a.getStockCurrentBodegaByColorTalla(myproducto_a.EAN, idlocation, idbodega,placeDestino, myproducto_a.idcolor,myproducto_a.idtalla,out szRetval1);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta stock actual";
                return;
            }

            try
            {
                unidadesTotales = myproducto_a.getStockCurrentTotalBodega(myproducto_a.EAN, idlocation, idbodega,out szRetval2);
            }
            catch
            {
                StatusBar1.Text = "Error: en consulta stock total (Mover)";
                return;
            }

            labelStockOrigen.Text = "Stock Origen [" + placeOrigen + "] :" + unidadesOrigen;
            labelStockDestino.Text = "Stock Destino [" + placeDestino + "] :" + unidadesDestino ;
            labelStockBodega.Text = "Stock Bodega [" + idbodega + "] :" + unidadesTotales;


            textBoxBarCode.Text = null;
            textBoxBarCode.Focus();

        }


        private void ButtonMover_Click(object sender, EventArgs e)
        {
            moverProducto();
            
        }

        private void textBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarCode.Text.Length >= Configuracion.EANSIZE)
            {
                moverProducto();
            }
        }

        private void FormMovimiento_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }


    }
}