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
    public partial class FormCajas : Form
    {
        Producto myproducto_a;

        public FormCajas()
        {
            InitializeComponent();
            myproducto_a = new Producto();
        }


        private void consultarProducto()
        {
            String szRetval="NA";
            int retval=-1;

            String ean = textBoxBarCode.Text;

            try
            {
                retval = myproducto_a.getRegistroCajasByEan(textBoxBarCode.Text, out szRetval);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta de producto";
                FillFormClean();
                labelResponse.Text = ean + "\n";
                return;
            }

            if (retval == 0)
            {
                FillForm();
            }
            else
            {
                FillFormClean();
                labelResponse.Text = ean;
            }


            try
            {
                Etiqueta.registraTransaccion(myproducto_a, Constants.CAJAS, null, 0, out szRetval);
            }
            catch
            {
                StatusBar1.Text = "Error al registrar transacción";
                return;
            }

            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();

        }

        private void FormCajas_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Focus();

        }


        private void ButtonConsultar_Click(object sender, EventArgs e)
        {
            consultarProducto();
        }


        private void FillForm()
        {
            labelResponse.Text = textBoxBarCode.Text + "\n";
            labelResponse.Text += myproducto_a.PROD;
            FillDataGrid(myproducto_a.EAN);
            StatusBar1.Text = "Lectura producto OK";
        }

/*
        public int getRegistroByEan(String ean_p, out String szRetval_p)
        {
            szRetval_p = "getRegistroByEan";
            SQLiteConnection sqlConn;
            int retval = -1;
            if (ean_p.Length == 0)
            {
                return retval;
            }
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tableProducts = Modelo.getTablePrefix() + "products";
            String tableProductEan = Modelo.getTablePrefix() + "productean";
            String tableDepartamentos = Modelo.getTablePrefix() + "departamento";
            String tableLineas = Modelo.getTablePrefix() + "linea";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,pro.precio,pro.semanaantiguedad,pro.flagetiqueta,pro.flagrevenue,pro.flagrecogida,pro.stock,pro.cantidadrecoger,pro.tiporecogida,dep.descripcion as departamento,lin.descripcion as linea ";
            mycommand.CommandText += "FROM " + tableProducts + " pro ";
            mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "LEFT JOIN " + tableDepartamentos + " dep ON ( pro.iddepartamento = dep.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableLineas + " lin ON ( pro.idlinea = lin.id) ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "pea.ean = '" + ean_p + "' ; ";

            SQLiteDataReader reader;

            EAN = ean_p;
            SKU = null;
            PROD = "";
            DPTO = "";
            LINEA = "";
            PRECIO = 0;
            SemanaAntiguedad = 0;
            flagEtiquetar = 0;
            flagRevenue = 0;
            flagRecogida = 0;

            stock = 0;


            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    szRetval_p = "OK ";
                    EAN = ean_p;
                    SKU = reader.GetString(0);
                    PROD = reader.GetString(1);
                    PRECIO = reader.GetDouble(2);
                    try
                    {
                        SemanaAntiguedad = reader.GetInt16(3);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        flagEtiquetar = reader.GetInt16(4);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        flagRevenue = reader.GetInt16(5);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        flagRecogida = reader.GetInt16(6);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        stock = reader.GetDouble(7);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        cantidadRecoger = reader.GetDouble(8);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        tipoRecogida = reader.GetString(9);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        DPTO = reader.GetString(10);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        LINEA = reader.GetString(11);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };


                    retval = 0;
                }
                else
                {
                    szRetval_p = "NOT FOUND";
                    retval = 1;
                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;

                retval = -1;
            }
            sqlConn.Close();
            return retval;
        }

*/


        private int FillDataGrid(String ean_p)
        {
            int retval = -1;
            String szRetval_p;

            SQLiteConnection sqlConn;
 
            if (ean_p.Length == 0)
            {
                return retval;
            }
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tableCajas = Modelo.getTablePrefix() + "cajas";
            String tableCajasSku = Modelo.getTablePrefix() + "cajassku";
            String tableProducts = Modelo.getTablePrefix() + "products";


            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT  pro.sku,pro.nombre,pro.flagrevenue ";
            mycommand.CommandText += "FROM " + tableCajas + " caj ";
            mycommand.CommandText += "JOIN " + tableCajasSku + " cjs ON ( caj.ean = cjs.ean) ";
            mycommand.CommandText += "LEFT JOIN " + tableProducts + " pro ON ( pro.sku = cjs.sku) ";

            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "caj.ean = '" + ean_p + "' ";
            mycommand.CommandText += "ORDER BY pro.flagrevenue DESC " ;

            SQLiteDataReader reader;

            reader = mycommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("SKU");
            dt.Columns.Add("Producto");
            dt.Columns.Add("FR");

            if (reader.HasRows)
            {
                String sku, nombre;
                int flagRevenue=0;

                while (reader.Read())
                {
                    sku    = reader.GetString(0);
                    nombre = reader.GetString(1);

                    try
                    {
                        flagRevenue = reader.GetInt16(2);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    dt.Rows.Add(sku, nombre, flagRevenue);
                   
                }
            }
            else
            {
               
            }


            dataGridCajas.DataSource = dt; 
            return retval;
        }




        private void FillFormClean()
        {
            textBoxBarCode.Text = "";
            labelResponse.Text = "";
            textBoxBarCode.Focus();
            StatusBar1.Text = "";
        }

        private void textBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarCode.Text.Length >= Configuracion.RF_EANSIZE)
            {
                consultarProducto();
            }

        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();
        }





    }
}