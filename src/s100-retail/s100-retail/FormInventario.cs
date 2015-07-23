using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLibrary;

namespace s100_retail
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
            labelPrecio.Text = "$ " + String.Format("{0:0,0}", producto_p.PRECIO);
            labelStock.Text = "Stock: " + producto_p.stock;
            labelSemanaAntiguedad.Text = "SA : " + producto_p.SemanaAntiguedad;

 
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


            StatusBar1.Text = "";
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
            if (textBoxBarCode.Text.Length >= Configuracion.EANSIZE)
            {
                consultarProducto();
            }
        }

        private void consultarProducto()
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

            LabelInventario.Text = "";

            String szRetval;
            int retval;

            try
            {
                retval = myproducto_a.getRegistroByEan(myproducto_a.EAN, out szRetval);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta de producto";
                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: NO ENCONTRADO";
                return;
            }


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


            String myResponse;
            String idbodega = null;
            try
            {
                retval = myproducto_a.contar(myproducto_a, cantidad, idlocation, idbodega,place, out myResponse);
            }
            catch
            {
                StatusBar1.Text = "Error en contar producto";
                return;
            }


            if ( retval != 0)
            {
                StatusBar1.Text = "Err: " + myResponse;
                MessageBox.Show(StatusBar1.Text);
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
                unidades = myproducto_a.getStockCurrentBodega(myproducto_a.EAN, idlocation, idbodega, place, out szRetval1);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta stock actual";
                return;
            }

            try
            {
                unidadesTotales = myproducto_a.getStockCurrentTotalBodega(myproducto_a.EAN, idlocation, idbodega, out szRetval2);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta stock total";
                return;
            }

            LabelInventario.Text = "Stock [" + place + "] = " + unidades + "\n";
            LabelInventario.Text = LabelInventario.Text + "Stock [Total] = " + unidadesTotales;

            textBoxBarCode.Text = null;
            textBoxBarCode.Focus();

        }

        private void ButtonConsultar_Click(object sender, EventArgs e)
        {
            consultarProducto();
        }



    }
}