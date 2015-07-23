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
    public partial class FormConsultaOperaciones : Form
    {
        public FormConsultaOperaciones()
        {
            InitializeComponent();
        }

        private void FormConsultaOperaciones_Load(object sender, EventArgs e)
        {
            radioButtonPromocion.Checked = true;
            llenaComboBoxDepartamento();
            llenaComboBoxLinea();
            DataTable dt = new DataTable();
            dt.Clear();
            dataGridProductos.DataSource = dt;
        }

        // Para Seleccionar ComboxBox Item
        //            if (comboBoxLocales.SelectedItem != null)
        //            {
        //                local = comboBoxLocales.SelectedItem.ToString();
        //                Item selectedItem = (Item)comboBoxLocales.SelectedItem;
        //                idlocal = selectedItem.Value();
        //            }
        ////                        idlocal = selectedItem.Value();
        // local = comboBoxLocales.SelectedItem.ToString();

        private void llenaComboBoxDepartamento()
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

            String table = Modelo.getTablePrefix() + "departamento";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT id,descripcion ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + table + " ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                comboBoxDepartamento.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    comboBoxDepartamento.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                comboBoxDepartamento.Items.Clear();
                // comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

        }

        private void llenaComboBoxLinea()
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

            String table = Modelo.getTablePrefix() + "linea";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT id,descripcion ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + table + " ";

            SQLiteDataReader reader;
            
            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                comboBoxLinea.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    comboBoxLinea.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                comboBoxLinea.Items.Clear();
                // comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            llenaComboBoxDepartamento();
            llenaComboBoxLinea();
            radioButtonPromocion.Checked = true;
            DataTable dt = new DataTable();
            dt.Clear();
            dataGridProductos.DataSource = dt;
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            buttonConsultar.Enabled = false;
            // Para Seleccionar ComboxBox Item
            String iddepartamento=null,departamento;
            if (comboBoxDepartamento.SelectedItem != null)
            {
                departamento = comboBoxDepartamento.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxDepartamento.SelectedItem;
                iddepartamento = selectedItem.Value();
            }

            String idlinea = null, linea;
            if (comboBoxLinea.SelectedItem != null)
            {
                linea = comboBoxLinea.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxLinea.SelectedItem;
                idlinea = selectedItem.Value();
            }
            int idoperacion;

            if (radioButtonPromocion.Checked == true)
            {
                idoperacion = 0;
            }
            else if (radioButtonRevenue.Checked == true)
            {
                idoperacion = 1;
            }
            else if (radioButtonRecogida.Checked == true)
            {
                idoperacion = 2;
            }
            else
            {
                idoperacion = 0;
            }
            
            llenaTablaByOperacion(iddepartamento,idlinea,idoperacion);

            buttonConsultar.Enabled = true;

        }

        private int llenaTablaByOperacion(string iddepartamento_p,string idlinea_p,int idoperacion_p)
        {
            int retval = -1;

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
                return -1;
            }

            String table = Modelo.getTablePrefix() + "products";
            String tableProductEan = Modelo.getTablePrefix() + "productean";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,pro.precio,pro.semanaantiguedad,pro.stock,pea.ean,pro.tiporecogida,pro.cantidadrecoger ";
            mycommand.CommandText += "FROM " + table + " pro ";
            mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "WHERE  ";
            mycommand.CommandText += "pro.sku is not null ";

            if (iddepartamento_p != null)
            {
                mycommand.CommandText += "AND pro.iddepartamento = '" + iddepartamento_p + "' ";
            }

            if (idlinea_p != null)
            {
                mycommand.CommandText += "AND pro.idlinea = '" + idlinea_p + "' ";
            }

            if (idoperacion_p == 0)
            {
                mycommand.CommandText += "AND pro.flagetiqueta = 1 ";
            } else if (idoperacion_p == 1)
            {
                mycommand.CommandText += "AND pro.flagrevenue = 1 ";
            } else if (idoperacion_p == 2)
            {
                mycommand.CommandText += "AND pro.flagrecogida = 1 ";
            }

            SQLiteDataReader reader;

            try
            {
                String sku, nombre;
                double precio=0;
                int semanaantiguedad=0;
                double stock=0;
                String ean;
                String tiporecogida;
                double cantidadrecoger = 0;


                DataTable dt = new DataTable();


                if (idoperacion_p == 0 || idoperacion_p == 1)
                {
                    dt.Columns.Add("SKU");
                    dt.Columns.Add("EAN");
                    dt.Columns.Add("Producto");
                    dt.Columns.Add("Precio");
                    dt.Columns.Add("SA");
                    dt.Columns.Add("Stock");
                }
                else if (idoperacion_p == 2)
                {
                    dt.Columns.Add("SKU");
                    dt.Columns.Add("EAN");
                    dt.Columns.Add("Producto");
                    dt.Columns.Add("Precio");
                    dt.Columns.Add("TR");
                    dt.Columns.Add("Cant");
                }

                reader = mycommand.ExecuteReader();
                while (reader.Read())
                {
                    sku = reader.GetString(0);
                    nombre = reader.GetString(1);


                    try
                    {
                        precio = reader.GetDouble(2);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        semanaantiguedad = reader.GetInt16(3);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };


                    try
                    {
                        stock = reader.GetDouble(4);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    ean = reader.GetString(5);
                    tiporecogida = reader.GetString(6);
                    try
                    {
                        cantidadrecoger = reader.GetDouble(7);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };



                    if (idoperacion_p == 0 || idoperacion_p == 1)
                    {
                        dt.Rows.Add(sku, ean, nombre, precio, semanaantiguedad, stock);
                    }
                    else if (idoperacion_p == 2)
                    {
                        dt.Rows.Add(sku, ean, nombre, precio, tiporecogida,cantidadrecoger);
                    }

                }

                dataGridProductos.DataSource = dt; 
            }
            catch (SQLiteException myException)
            {
                comboBoxDepartamento.Items.Clear();
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();
            return retval;
        }

        
    }
}