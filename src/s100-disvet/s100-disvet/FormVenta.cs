using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace s100_disvet
{
    public partial class FormVenta : Form
    {
        private DataSet ds = new DataSet();     //DataSet
        private DataTable dt = new DataTable();   //DataTable

        CarroCompras myCarroCompras_a;
        Producto myProducto_a;
        bool flagEncontrado_a;
        public FormVenta()
        {
            InitializeComponent();
            myCarroCompras_a = new CarroCompras();
            myProducto_a = new Producto();
            flagEncontrado_a = false;

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

            if (textBoxProducto.Text.Length == 0)
            {
                MessageBox.Show("Error en código de articulo");
            }
            if (myProducto_a.getRegistro(textBoxProducto.Text) == 0)
            {
                labelInfoProducto.Text = "SKU: " + myProducto_a.SKU + "\n";
                labelInfoProducto.Text = "PROD: " + myProducto_a.PROD + "\n";
                flagEncontrado_a = true;
            }
            else
            {
                labelInfoProducto.Text = "SKU: PRODUCTO NO ENCONTRADO";
                flagEncontrado_a = false;
            }


        }

        private void FormVenta_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Adios ..");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (flagEncontrado_a)
            {
                myCarroCompras_a.agregarProducto(myProducto_a);
            }
            else
            {
                MessageBox.Show("Producto no seleccionado");
            }
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {


            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();
            string filemaestros = Configuracion.getMaestrosFile();
            sqlConn.ConnectionString = "Data Source=" + filemaestros + ";Version=3;";


            SQLiteDataAdapter db;

            string sqlString;

            sqlString = "SELECT PRO.CODE, PRO.NAME,PRO.PRICESELL,PFL.SEMANAANTIGUEDAD,PFL.FLAGETIQUETA, PFL.FLAGREVENUE, PFL.FLAGRECOGIDA ";
            sqlString = sqlString + "FROM PRODUCTS PRO LEFT JOIN SVT_PRODUCTS_FLAG PFL ON ( PRO.ID = PFL.PRODUCT ) ";

            db = new SQLiteDataAdapter(sqlString, sqlConn);

            //Llena el DataSet
            ds.Reset();
            db.Fill(ds);

            //Asigna al DataTable la primer tabla (y la única) del DataSet
            dt = ds.Tables[0];
            dataGridProductos.DataSource = dt;

            sqlConn.Close();
   



        }

        private void dataGridProductos_CurrentCellChanged(object sender, EventArgs e)
        {
            DataRow row = ((DataTable)dataGridProductos.DataSource).Rows[dataGridProductos.CurrentRowIndex];

            string code;

            code = row[0].ToString();
            if (myProducto_a.getRegistro(code) == 0)
            {
                labelInfoProducto.Text = "SKU: " + myProducto_a.SKU + "\n";
                labelInfoProducto.Text = "PROD: " + myProducto_a.PROD + "\n";
                flagEncontrado_a = true;
            }
            else
            {
                labelInfoProducto.Text = "SKU: PRODUCTO NO ENCONTRADO";
                flagEncontrado_a = false;
            }

   
        }

        private void tabPageProductos_Click(object sender, EventArgs e)
        {

        }




    }
}