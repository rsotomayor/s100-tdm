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
    public partial class FormConsultaTransacciones : Form
    {
        public FormConsultaTransacciones()
        {
            InitializeComponent();
        }

        private void FormConsultaTransacciones_Load(object sender, EventArgs e)
        {
            llenaComboBoxDepartamento();
            llenaComboBoxLinea();
            radioButtonPromocion.Checked = true;

            DataTable dt = new DataTable();
            dt.Clear();
            dataGridProductos.DataSource = dt;
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
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

        }


        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            buttonConsultar.Enabled = false;

            // Para Seleccionar ComboxBox Item
            String iddepartamento = null, departamento;
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



            llenaTablaByOperacion(iddepartamento, idlinea, idoperacion, checkBoxDiarioTotal.Checked);

            buttonConsultar.Enabled = true;

        }

        private int llenaTablaByOperacion(string iddepartamento_p,string idlinea_p,int idoperacion_p,bool diariototal_p)
        {
            int retval = -1;

            SQLiteConnection sqlConn;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
                return -1;
            }
            String sqlString;

            file = Configuracion.getMaestrosFile();
            sqlString = "ATTACH '" + file + "' AS maestros" ;
            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                String mystr = myException.Message;
                MessageBox.Show(mystr);
                return -1;
            }

            double tsNowInicio, tsNowTermino;
            DateTime tnow = DateTime.Now;
            DateTime fecha;
            fecha = new DateTime(tnow.Year, tnow.Month, tnow.Day, 0, 0, 0, 0);
            tsNowInicio = MyGlobal.DateTimeToUnixTime(fecha);
            fecha = new DateTime(tnow.Year, tnow.Month, tnow.Day, 23, 59, 59, 0);
            tsNowTermino = MyGlobal.DateTimeToUnixTime(fecha);

            String table = Modelo.getTablePrefix() + "TRANSACCIONES";
            String tableProducts = Modelo.getTablePrefix() + "products";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT tra.EAN,tra.SKU,tra.NIMPRESIONES,mae.nombre as producto,mae.tiporecogida,mae.cantidadrecoger,count(*) as NRECORD ";
            mycommand.CommandText += "FROM main." + table + " tra ";
            mycommand.CommandText += "JOIN maestros." + tableProducts + " mae ON ( tra.SKU = mae.sku )";
            mycommand.CommandText += "WHERE  ";
            mycommand.CommandText += "tra.ID is not null ";
            mycommand.CommandText += "AND tra.IDOPCION = " + idoperacion_p + " " ;

            if ( diariototal_p ) {
                mycommand.CommandText += "AND tra.tra.TS >= " + tsNowInicio + "  ";
                mycommand.CommandText += "AND TS <= " + tsNowTermino + " ";
            }

            if (iddepartamento_p != null)
            {
                mycommand.CommandText += "AND mae.iddepartamento = '" + iddepartamento_p + "' ";
            }

            if (idlinea_p != null)
            {
                mycommand.CommandText += "AND mae.idlinea = '" + idlinea_p + "' ";
            }


            mycommand.CommandText += "GROUP BY 1,2,3,4 ";
            mycommand.CommandText += "ORDER BY TS DESC ";


            // MessageBox.Show("SQL: " +mycommand.CommandText);
            SQLiteDataReader reader;

            try
            {
                String ean=null, sku=null,nombre=null,tiporecogida=null;
                int nimpresiones = 0, nrecord = 0;
                double cantidadrecoger=0;
  

                DataTable dt = new DataTable();
                if (idoperacion_p == Constants.RECOGIDA)
                {
                    dt.Columns.Add("EAN");
                    dt.Columns.Add("SKU");
                    dt.Columns.Add("PRODUCTO");
                    dt.Columns.Add("TIPO");
                    dt.Columns.Add("NR");
                    dt.Columns.Add("NO");

                }
                else
                {
                    dt.Columns.Add("EAN");
                    dt.Columns.Add("SKU");
                    dt.Columns.Add("PRODUCTO");
                    dt.Columns.Add("NI");
                    dt.Columns.Add("NR");
                }


                try
                {
                    reader = mycommand.ExecuteReader();
                }
                catch (Exception e)
                {
                    String mystr = e.Message;
                    MessageBox.Show(mystr);
                    return -1;
                };


                try
                {
                    reader.Read();
                }
                catch (Exception e)
                {
                    String mystr = e.Message;
                    MessageBox.Show(mystr);
                    return -1;
                };


               
                while (reader.HasRows)
                {

                    try
                    {
                        ean = reader.GetString(0);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        sku = reader.GetString(1);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };


                    try
                    {
                        nimpresiones = reader.GetInt16(2);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        nombre = reader.GetString(3);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };


                    try
                    {
                        tiporecogida = reader.GetString(4);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        cantidadrecoger = reader.GetDouble(5);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };


                    try
                    {
                        nrecord = reader.GetInt32(6);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };


                    if (idoperacion_p == Constants.RECOGIDA)
                    {
                        dt.Rows.Add(ean, sku, nombre, tiporecogida,nrecord,cantidadrecoger);
                    }
                    else
                    {
                        dt.Rows.Add(ean, sku, nombre, nimpresiones, nrecord);
                    }

 


                    try
                    {
                        reader.Read();
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                        MessageBox.Show(mystr);
                        return -1;
                    };
                }
            

                dataGridProductos.DataSource = dt; 
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();
            return retval;
        }

    


        
    }
}