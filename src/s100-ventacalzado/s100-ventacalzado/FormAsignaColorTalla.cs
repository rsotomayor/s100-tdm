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
    public partial class FormAsignaColorTalla : Form
    {
        Producto myproducto_a;
        public FormAsignaColorTalla(Producto myproducto_p)
        {

            InitializeComponent();
            myproducto_a = myproducto_p;
            llenaComboBoxColor();
            llenaComboBoxTalla();

            labelSKU.Text = "SKU: " + myproducto_a.SKU;
            labelNombreProducto.Text = myproducto_a.PROD;

        }
        private void llenaComboBoxColor()
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

            String table = Modelo.getTablePrefix() + "COLOR";

            mycommand = new SQLiteCommand(sqlConn);


            mycommand.CommandText = "SELECT ID,DESCRIPCION ";
            mycommand.CommandText += "FROM " + table + " ORDER BY ID ASC";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                comboBoxColor.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    Item myitem = new Item(id, descripcion);
                    comboBoxColor.Items.Add(myitem);
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                comboBoxColor.Items.Clear();
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();


            if (myproducto_a.idcolor.Trim().Length > 0)
            {
                String id, descripcion;
                id = myproducto_a.idcolor;
                descripcion = myproducto_a.color;
                Item myitem = new Item(id, descripcion);
                comboBoxColor.Items.Add(myitem);
                comboBoxColor.SelectedItem = myitem;
                comboBoxColor.Enabled = false;
            }

            

        }

        private void llenaComboBoxTalla()
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

            String table = Modelo.getTablePrefix() + "TALLA";

            mycommand = new SQLiteCommand(sqlConn);


            mycommand.CommandText = "SELECT ID,DESCRIPCION ";
            mycommand.CommandText += "FROM " + table + " ORDER BY ID ASC";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                comboBoxTalla.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    comboBoxTalla.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                comboBoxTalla.Items.Clear();
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();


            if (myproducto_a.idtalla.Trim().Length > 0)
            {
                String id, descripcion;
                id = myproducto_a.idtalla;
                descripcion = myproducto_a.talla;
                Item myitem = new Item(id, descripcion);
                comboBoxTalla.Items.Add(myitem);
                comboBoxTalla.SelectedItem = myitem;
                comboBoxTalla.Enabled = false;
            }

        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTalla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAsignaAtributos_Click(object sender, EventArgs e)
        {
            String  color = null;

            if (comboBoxColor.SelectedItem != null)
            {
                color = comboBoxColor.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxColor.SelectedItem;
                myproducto_a.color = color;
                myproducto_a.idcolor = selectedItem.Value();
            }

            String  talla = null;
            if (comboBoxTalla.SelectedItem != null)
            {
                talla = comboBoxTalla.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxTalla.SelectedItem;
                myproducto_a.talla = talla;
                myproducto_a.idtalla = selectedItem.Value();
            }

            if (comboBoxTalla.SelectedItem == null || comboBoxColor.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar los atributos");
            }
            else
            {
                myproducto_a.flagContar = true;
                this.Close();
            }

        }

        private void FormAsignaColorTalla_Load(object sender, EventArgs e)
        {

        }

    }
}