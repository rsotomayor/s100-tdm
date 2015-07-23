using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLibrary;

namespace s100_ventacalzado
{
    public partial class FormEntradaSalida : Form
    {
        Producto myproducto_a;


        public FormEntradaSalida()
        {
            InitializeComponent();

            myproducto_a = new Producto();
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
            labelColor.Text = "Color: ";
            labelTalla.Text = "Talla: ";
            labelStockBodega.Text = "Stock Bodega: ";
            labelStockSector.Text = "Stock Sector: ";


            StatusBar1.Text = "";
        }


 

        private void FormInventario_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
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
                IngresarProducto();
            }
        }

        private void IngresarProducto()
        {
            String idmovimiento = null, movimiento;
            if (comboBoxMovimientos.SelectedItem != null)
            {
                movimiento = comboBoxMovimientos.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxMovimientos.SelectedItem;
                idmovimiento = selectedItem.Value();
            }
            else
            {
                MessageBox.Show("Debe seleccionar tipo movimiento");
                return;
            }

            String ean = textBoxBarCode.Text;
            if (textBoxBarCode.Text.Length == 0)
            {
                MessageBox.Show("Error en Articulo");
                textBoxBarCode.Text = "";
                textBoxBarCode.Focus();
                return;
            }

            int cantidad=0;

  
            if (radioButtonEntrada.Checked == true)
            {
                cantidad = (int)1; 
            }
            else
            {
                cantidad = (int)-1;
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
                textBoxBarCode.Text = null;
                textBoxBarCode.Focus();
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
                    retval = myproducto_a.ingresarCalzado(myproducto_a, idmovimiento, cantidad, idlocation, idbodega, place, myproducto_a.idcolor, myproducto_a.idtalla, out myResponse);
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
                StatusBar1.Text = "Error: en consulta stock total (IngresarProducto)";
                return;
            }

            labelStockSector.Text = "Stock Sector [" + place + "] : " + unidades;
            labelStockBodega.Text = "Stock Bodega [" + idbodega + "] : " + unidadesTotales;
            textBoxBarCode.Text = null;
            textBoxBarCode.Focus();

        }

        private void ButtonConsultar_Click(object sender, EventArgs e)
        {
            if (textBoxUbicacion.Text.Length > 0)
            {
                IngresarProducto();
            }
            else
            {
                MessageBox.Show("Sector no es válido");
            }

        }

        private void radioButtonEntrada_CheckedChanged(object sender, EventArgs e)
        {
            llenaComboBoxMovimientos(1);
        }

        private void radioButtonSalida_CheckedChanged(object sender, EventArgs e)
        {
            llenaComboBoxMovimientos(-1);
        }

        private void llenaComboBoxMovimientos(int es_p)
        {
            SQLiteConnection sqlConn;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string filemaestros = Configuracion.getMaestrosFile();
            sqlConn.ConnectionString = "Data Source=" + filemaestros + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
                return;
            }

            String table = Modelo.getTablePrefix() + "tipomovimiento";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT id,descripcion ";
            mycommand.CommandText += "FROM " + table + " ";
            if (es_p > 0)
            {
                mycommand.CommandText += "WHERE id > 0 ";
            }
            else
            {
                mycommand.CommandText += "WHERE id < 0 ";
            }

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                comboBoxMovimientos.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    comboBoxMovimientos.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                comboBoxMovimientos.Items.Clear();
                // comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }



        private void comboBoxMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }

 


    }
}