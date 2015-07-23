using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;
using System.Threading;
using MyLibrary;

namespace s100_ventacalzado
{

    public partial class FormSolicitud : Form
    {
        String eanActual_a;
        public FormSolicitud()
        {
            InitializeComponent();
        }

        private void FormSolicitud_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
            llenaComboBoxColor();
            llenaComboBoxTalla();
            DataTable dt = new DataTable();

            dt.Columns.Add("SKU");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Talla");
            dt.Columns.Add("Color");
            dt.Columns.Add("IdBodega");
            dt.Columns.Add("IdUbicacion");
            dt.Columns.Add("Stock");

            dataGridProductos.DataSource = dt;
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
                    comboBoxColor.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
 
            }
            catch (SQLiteException myException)
            {
                comboBoxColor.Items.Clear();
                // comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

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
                // comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

        }


        private int llenaTablaProductos(String ean_p,bool flagComboBoxInit_p)
        {
            String SKU=null;
            String idcolor = null, color = null;
            String idtalla = null, talla = null;
            if (ean_p == null)
            {
                return -1;
            }

            if (comboBoxColor.SelectedItem != null)
            {
                color = comboBoxColor.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxColor.SelectedItem;
                idcolor = selectedItem.Value();
            }

            if (comboBoxTalla.SelectedItem != null)
            {
                talla = comboBoxTalla.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxTalla.SelectedItem;
                idtalla = selectedItem.Value();
            }
            if (ean_p.Length > 0)
            {

                Producto myproducto = new Producto();
                String szRetval;
                int retval;

                try
                {
                    retval = myproducto.getRegistroByEanCalzado(ean_p, out szRetval);
                }
                catch
                {
                    StatusBar1.Text = "Error en consulta de producto";
                    FillFormClean();
                    return -1;
                }
                SKU = myproducto.SKU;
            }

            String url; 
            url = Configuracion.getUrlPost();


            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("wsname", "getProductosCalzadoBodega");
            nvc.Add("idusuario", Configuracion.getIdUsuario());
            nvc.Add("idtienda", Configuracion.getIdLocation());
            nvc.Add("idcolor", idcolor);
            nvc.Add("idtalla", idtalla);
            // Falta unificar EAN a SKU
            nvc.Add("SKU", SKU);
            nvc.Add("EAN", ean_p);
            nvc.Add("LIMIT", "1000");

            String xmlString;

            try
            {
                xmlString = Sync.myHttpPost(url, nvc);
            }
            catch 
            {
                MessageBox.Show("Error: no se puede conectar al servicio");
                buttonBuscar.Enabled = true;
                return -1;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("SKU");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Talla");
            dt.Columns.Add("Color");
            dt.Columns.Add("IdBodega");
            dt.Columns.Add("IdUbicacion");
            dt.Columns.Add("Stock");
            dt.Columns.Add("IdTalla");
            dt.Columns.Add("IdColor");

            String sku = "", nombre = "", stock = "", idbodega = "", idubicacion = "";
            String field = "";

            if (flagComboBoxInit_p == true)
            {
                comboBoxTalla.Items.Clear();
                comboBoxColor.Items.Clear();
            }

            myObjectList colorList = new myObjectList();
            myObjectList tallaList = new myObjectList();

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                try
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element: // The node is an element.
                                //MessageBox.Show(reader.Name);
                                field = reader.Name;

                                break;
                            case XmlNodeType.CDATA:
                            case XmlNodeType.Text: //Display the text in each element.
                                //MessageBox.Show(reader.Value);
                                switch (field)
                                {
                                    case "sku": sku = reader.Value; break;
                                    case "nombre": nombre = reader.Value; break;
                                    case "talla": talla = reader.Value; break;
                                    case "color": color = reader.Value; break;
                                    case "stock": stock = reader.Value; break;
                                    case "idubicacion": idubicacion = reader.Value; break;
                                    case "idbodega": idbodega = reader.Value; break;
                                    case "idtalla": idtalla = reader.Value; break;
                                    case "idcolor": idcolor = reader.Value; break;
                                    default: break;
                                }
                                break;
                            case XmlNodeType.EndElement: //Display the end of the element.
                                // MessageBox.Show(reader.Name);
                                if (reader.Name == "product")
                                {
                                    nombre = (nombre != null) ? nombre : "";
                                    talla = (talla != null) ? talla : "";
                                    color = (color != null) ? color : "";
                                    idbodega = (idbodega != null) ? idbodega : "";
                                    idubicacion = (idubicacion != null) ? idubicacion : "";
                                    idtalla = (idtalla != null) ? idtalla : "S/N";
                                    idcolor = (idcolor != null) ? idcolor : "S/N";

                                    dt.Rows.Add(sku, nombre, talla, color, idbodega, idubicacion, stock,idtalla,idcolor);

                                    if (flagComboBoxInit_p == true)
                                    {
                                        String id, descripcion;
                                        id = idcolor;
                                        descripcion = color;

                                        //Find Using Inline 
                                        bool exists;
                                        exists = colorList.Exists(delegate(myObject e) { return e.id_a == id; });

                                        if (exists == false)
                                        {
                                            colorList.Add(new myObject(id, descripcion));
                                        }


                                        id = idtalla;
                                        descripcion = talla;
                                        exists = tallaList.Exists(delegate(myObject e) { return e.id_a == id; });

                                        if (exists == false)
                                        {
                                            tallaList.Add(new myObject(id, descripcion));
                                        }
                                    }


                                }
                                break;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error en data XML desde el servidor");
                    buttonBuscar.Enabled = true;
                    return -1;
                }

            }

            if (flagComboBoxInit_p == true)
            {
                foreach (myObject mycolor in colorList)
                {
                    Item myitem = new Item(mycolor.id_a, mycolor.descripcion_a);
                    comboBoxColor.Items.Add(myitem);
                }

                foreach (myObject mytalla in tallaList)
                {
                    Item myitem = new Item(mytalla.id_a, mytalla.descripcion_a);
                    comboBoxTalla.Items.Add(myitem);
                }
            }
       
            dataGridProductos.DataSource = dt;

            return 0;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            buttonBuscar.Enabled = false;
            eanActual_a = textBoxBarCode.Text;
            llenaTablaProductos(textBoxBarCode.Text,true);
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
            buttonBuscar.Enabled = true;


        }


        private int llenaTablaProductosBaseDatos(string iddepartamento_p, string idlinea_p,string color_p,string talla_p)
        {
            // Esta función no se usa, pero queda documentada
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
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,pro.stock,pro.talla,pro.color ";
            mycommand.CommandText += "FROM " + table + " pro ";
            mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "WHERE  ";
            mycommand.CommandText += "pro.sku is not null ";

            if (iddepartamento_p != null)
            {
                mycommand.CommandText += "AND pro.iddepartamento = '" + iddepartamento_p + "' ";
            }

            if (idlinea_p != null )
            {
                mycommand.CommandText += "AND pro.idlinea = '" + idlinea_p + "' ";
            }

            if (color_p != null && color_p.Length>0)
            {
                mycommand.CommandText += "AND pro.color = '" + color_p + "' ";
            }

            if (talla_p != null && talla_p.Length >0)
            {
                mycommand.CommandText += "AND pro.talla = '" + talla_p + "' ";
            }


            SQLiteDataReader reader;

            try
            {
                String sku, descripcion;
                double stock = 0;
                String talla,color;

                DataTable dt = new DataTable();

         
                dt.Columns.Add("SKU");
                dt.Columns.Add("Descripción");
                dt.Columns.Add("Stock");
                dt.Columns.Add("Talla");
                dt.Columns.Add("Color");
   

                reader = mycommand.ExecuteReader();
                while (reader.Read())
                {
                    sku = reader.GetString(0);
                    descripcion = reader.GetString(1);


                    try
                    {
                        stock = reader.GetDouble(2);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    talla = reader.GetString(3);
                    color = reader.GetString(4);
                    dt.Rows.Add(sku, descripcion,stock,talla,color);
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


        private void FillFormClean()
        {
            ((DataTable)dataGridProductos.DataSource).Rows.Clear();
            comboBoxColor.SelectedIndex = -1;
            comboBoxTalla.SelectedIndex = -1;
            textBoxBarCode.Text = "";
            buttonBuscar.Enabled = true;
            textBoxBarCode.Focus();
            //            DataTable dt = new DataTable();
//            dt.Clear();
//            dataGridProductos.DataSource = dt;
        }


        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int numeroFilas;
            DataTable dt = new DataTable();

            dt = (DataTable) dataGridProductos.DataSource  ;

            numeroFilas = dt.Rows.Count;

            String idusuario = Configuracion.getIdUsuario();
            for (int i = 0; i < (numeroFilas); i++)
            {
                if (dataGridProductos.IsSelected(i))
                {
                    String sku, idbodega, idubicacion, idcolor, idtalla, color, talla, szRetval;
                    sku = Convert.ToString(dataGridProductos[i, 0]);
                    talla = Convert.ToString(dataGridProductos[i, 2]);
                    color = Convert.ToString(dataGridProductos[i, 3]);
                    idbodega = Convert.ToString(dataGridProductos[i, 4]);
                    idubicacion = Convert.ToString(dataGridProductos[i, 5]);
                    idtalla = Convert.ToString(dataGridProductos[i, 7]);
                    idcolor = Convert.ToString(dataGridProductos[i, 8]);

                    // Modelo.agregaCarroCompras(idusuario,sku, idbodega,idubicacion,out szRetval);
                    Modelo.agregaCarroComprasCalzado(idusuario, sku, idbodega, idubicacion,idcolor,idtalla,color,talla, out szRetval);

                    StatusBar1.Text = "SKU: " + sku + " agregado OK";
                }
            }

        }

        private void buttonProcesar_Click(object sender, EventArgs e)
        {
            FormPedido myformpedido = new FormPedido();
            myformpedido.ShowDialog();
        }

        private void textBoxBarCode_TextChanged(object sender, EventArgs e)
        {

            if (textBoxBarCode.Text.Length >= Configuracion.EANSIZE)
            {
                buttonBuscar.Enabled = false;
                Producto myproducto = new Producto();
                String szRetval;
                int retval;

                try
                {
                    retval = myproducto.getRegistroByEanCalzado(textBoxBarCode.Text, out szRetval);
                }
                catch
                {
                    StatusBar1.Text = "Error en consulta de producto";
                    FillFormClean();
                    return;
                }


                String idcolor = null, color = null;

                if (comboBoxColor.SelectedItem != null)
                {
                    color = comboBoxColor.SelectedItem.ToString();
                    Item selectedItem = (Item)comboBoxColor.SelectedItem;
                    idcolor = selectedItem.Value();
                }

                String idtalla = null, talla = null;
                if (comboBoxTalla.SelectedItem != null)
                {
                    talla = comboBoxTalla.SelectedItem.ToString();
                    Item selectedItem = (Item)comboBoxTalla.SelectedItem;
                    idtalla = selectedItem.Value();
                }

                if (retval == 0)
                {
                    eanActual_a = textBoxBarCode.Text;
                    llenaTablaProductos(textBoxBarCode.Text,true);
                }
                else
                {
                    FillFormClean();
                }
                textBoxBarCode.Text = "";
                buttonBuscar.Enabled = true;
                textBoxBarCode.Focus();
                buttonBuscar.Enabled = true;

            }
        }

        private void comboBoxTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = false;
            llenaTablaProductos(eanActual_a,false);
            buttonBuscar.Enabled = true;
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = false;
            llenaTablaProductos(eanActual_a,false);
            buttonBuscar.Enabled = true;
        }




    }


}