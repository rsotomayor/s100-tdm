using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;
using System.Threading;
using System.Data.SQLite;

using MyLibrary;

namespace s100_ventacalzado
{
    public partial class FormPedido : Form
    {
        delegate void SetAvanceCallback(Int64 value_p, String message_p);

        DateTime startOperation_a;
        Int64 iSize_a;
        bool flagCancelar_a = false;
        Thread newThreadUpload_a;
        public FormPedido()
        {
            InitializeComponent();
        }



        private int llenaTablaProductos()
        {
            int retval = -1;

            SQLiteConnection sqlConn;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file+ ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
                return -1;
            }

            mycommand = new SQLiteCommand(sqlConn);
            file = Configuracion.getMaestrosFile();
            mycommand.CommandText = "ATTACH '" + file + "' AS maestros";

            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Error 002:" + myException.Message);
                retval = retval - 1;
                return retval;
            }

            String table = Modelo.getTablePrefix() + "CARROCOMPRAS";
            String tableProducts = Modelo.getTablePrefix() + "products";

            mycommand.CommandText = "SELECT carro.sku,mae.nombre as producto,carro.idtalla as talla,carro.idcolor as color,carro.cantidad,carro.idbodega,carro.idubicacion,carro.talla,carro.color ";
            mycommand.CommandText += "FROM " + table + " carro ";
            mycommand.CommandText += "LEFT JOIN maestros." + tableProducts + " mae ON ( carro.SKU = mae.sku )";
            mycommand.CommandText += "WHERE  ";
            mycommand.CommandText += "carro.sku is not null ";

            SQLiteDataReader reader;

            try
            {
                String sku;
                int cantidad;

                String descripcion;
        
                String talla,color,idtalla,idcolor;
                String idbodega, idubicacion;

                DataTable dt = new DataTable();

                dt.Columns.Add("SKU");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Talla");
                dt.Columns.Add("Color");
                dt.Columns.Add("IdBodega");
                dt.Columns.Add("IdUbicacion");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("IdTalla");
                dt.Columns.Add("IdColor");

                reader = mycommand.ExecuteReader();
                while (reader.Read())
                {
                    sku = reader.GetString(0);
                    descripcion = reader.GetString(1);
   
                    idtalla = reader.GetString(2);
                    idcolor = reader.GetString(3);
                    cantidad = reader.GetInt32(4);
                    idbodega = reader.GetString(5);
                    idubicacion = reader.GetString(6);
                    talla = reader.GetString(7);
                    color = reader.GetString(8);

                    dt.Rows.Add(sku, descripcion,talla,color,idbodega,idubicacion,cantidad,idtalla,idcolor);
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


            //            DataTable dt = new DataTable();
//            dt.Clear();
//            dataGridProductos.DataSource = dt;
        }

        private void SetAvance(Int64 offset_p, String message_p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelSincronizacion.InvokeRequired)
            {
                SetAvanceCallback d = new SetAvanceCallback(SetAvance);
                this.Invoke(d, new object[] { offset_p, message_p });
            }
            else
            {
                if (message_p != null)
                {
                    this.labelSincronizacion.Text = message_p;
                    buttonProcesarPedido.Enabled = true;

                    FillFormClean();
                    llenaTablaProductos();
                }
                else
                {
                    double porcentaje;
                    porcentaje = 100.0 * offset_p / (1.0 * iSize_a);
                    porcentaje = Math.Round(porcentaje, 1);

                    //                    this.labelSincronizacion.Text = offset_p + "/" + iSize_a + " ( " + porcentaje.ToString() + " %) ";
                    if (porcentaje <= 100)
                    {
                        this.ProgressBar1.Value = (int)porcentaje;
                    }
                    else
                    {
                        this.ProgressBar1.Value = 100;


                    }
                }
            }
        }

        public int HttpUploadFile(string url, NameValueCollection nvc, tFiles[] myFiles2Upload, out String szRetcode_p)
        {
            String idlocal = Configuracion.getIdLocation();
            String idusuario = Configuracion.getIdUsuario();
            String myResponse;
            int packetSize = Configuracion.getPacketSize();


            int retcode = 0;
            szRetcode_p = "HttpUploadFile";
            string retval = "CAAC-KO";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest wr;
            try
            {
                wr = (HttpWebRequest)WebRequest.Create(url);
            }
            catch
            {
                szRetcode_p = "error Upload 001";
                return -1;
            }
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream postDataStream;
            try
            {
                postDataStream = Sync.GetPostStream(nvc, boundary, myFiles2Upload);
            }
            catch
            {
                szRetcode_p = "error Upload 002";
                return -1;
            }
            wr.ContentLength = postDataStream.Length;
            iSize_a = 100;
            this.SetAvance(10, null);

            Stream rs;
            try
            {
                rs = wr.GetRequestStream();
            }
            catch
            {
                try
                {
                    rs = wr.GetRequestStream();
                }
                catch
                {
                    szRetcode_p = "error en subir archivo [003]";
                    return -1;
                }
            }


            postDataStream.Position = 0;

            byte[] buffer = new byte[packetSize];
            int bytesRead = 0;

            this.SetAvance(25, null);

            try
            {
                bytesRead = postDataStream.Read(buffer, 0, buffer.Length);
            }
            catch
            {
                szRetcode_p = "error Upload 004";
                postDataStream.Close();
                rs.Close();
                return -1;
            }

            while ((bytesRead != 0) && flagCancelar_a == false)
            {
                try
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                catch
                {
                    flagCancelar_a = true;
                    retcode = -1;
                }
                try
                {
                    bytesRead = postDataStream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    szRetcode_p = "error Upload 004.1";
                    postDataStream.Close();
                    rs.Close();
                    return -1;
                }

            }
            postDataStream.Close();
            rs.Close();
            this.SetAvance(75, null);

            if (retcode == -1)
            {
                this.SetAvance(0, null);
                TimeSpan diff = DateTime.UtcNow - startOperation_a;
                String szNota = "Falla intermedia en subida de archivo";
                szRetcode_p = "Error: " + szNota;
                try
                {
                    Modelo.Log(idlocal, idusuario, "UPLOAD", "KO", szNota, out myResponse);
                }
                catch
                {
                    szRetcode_p = "Error en log file";
                    return -1;
                }


                return retcode;
            }

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                retcode = 0;
                wresp.Close();
            }
            catch (Exception ex)
            {
                retval = "Error uploading file" + ex.ToString();
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                retcode = -1;
            }
            finally
            {
                wr = null;
            }

            if (retcode == 0)
            {
                this.SetAvance(100, null);
                TimeSpan diff = DateTime.UtcNow - startOperation_a;
                String szNota = "Tiempo upload " + diff.TotalSeconds + "[seg]";
                szRetcode_p = "SUBE OK: " + szNota;
                Modelo.Log(idlocal, idusuario, "UPLOAD", "OK", szNota, out myResponse);
                String szRetval;
                Modelo.vaciaCarroCompras(out szRetval);
            }
            else
            {
                this.SetAvance(0, null);
                TimeSpan diff = DateTime.UtcNow - startOperation_a;
                String szNota = "Falla subida de archivo";
                szRetcode_p = "Error: " + szNota;
                Modelo.Log(idlocal, idusuario, "UPLOAD", "KO", szNota, out myResponse);
            }

            return retcode;
        }


        public void uploadFile()
        {
            string response = "KO";
            startOperation_a = DateTime.UtcNow;

            String iddispositivo;
            String idusuario;

            iddispositivo = Configuracion.getIdDispositivo();
            idusuario = Configuracion.getIdUsuario();
            string id = iddispositivo + "|" + idusuario;

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("wsname", "enviapedidos");
            nvc.Add("id", id);
            nvc.Add("iddispositivo", iddispositivo);
            nvc.Add("vendedor", idusuario);
            nvc.Add("idtienda", Configuracion.getIdLocation());
            nvc.Add("idbodega", "3901");

            long ts;
            ts = MyGlobal.UnixTimeNow();
            nvc.Add("ts", ts.ToString());

            byte[] data;
            String myFileName;

            myFileName = Configuracion.getCarroComprasFile();

            data = MyGlobal.ReadByteArrayFromFile(myFileName);

            tFiles[] myFiles2Upload = new tFiles[1];

            myFiles2Upload[0].paramName_a = "pedido";
            myFiles2Upload[0].nombre_a = "rpycal_carrocompras.db";
            myFiles2Upload[0].tipo_a = "object/sqlite3";
            myFiles2Upload[0].file_a = data;

            string urlPost_a = Configuracion.getUrlPost();
            //urlPost_a = "http://10.0.0.49/calzadopda/aspx_upload/pedidos.aspx";

            int retval;
            try
            {
                retval = this.HttpUploadFile(urlPost_a, nvc, myFiles2Upload, out response);
            }
            catch (Exception ex)
            {
                response = "Error en red de datos:" + ex.ToString().Substring(0, 20);
                response = "Error en red de datos";
            }

            SetAvance(0, response);

        }


        private void buttonProcesarPedido_Click(object sender, EventArgs e)
        {
            buttonProcesarPedido.Enabled = false;

            string message = "Envia Archivo Transacciones ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                ThreadStart threadDelegate;
                try
                {
                    threadDelegate = new ThreadStart(uploadFile);
                }
                catch
                {
                    StatusBar1.Text = "Error al iniciar tarea";
                    buttonProcesarPedido.Enabled = true;
                    flagCancelar_a = false;
                    return;
                }
                try
                {
                    newThreadUpload_a = new Thread(threadDelegate);
                }
                catch
                {
                    StatusBar1.Text = "Error al iniciar delegado";
                    buttonProcesarPedido.Enabled = true;
                    flagCancelar_a = false;
                    return;
                }

                try
                {
                    newThreadUpload_a.Start();
                }
                catch
                {
                    StatusBar1.Text = "Error al subir archivo";
                }

            }
            else
            {
                buttonProcesarPedido.Enabled = true;
            }

        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
            llenaTablaProductos();
        }

        private void buttonVaciarPedido_Click(object sender, EventArgs e)
        {
            string message = "Vaciar Pedido ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                FillFormClean();
                String szRetval;
                Modelo.vaciaCarroCompras(out szRetval);
                StatusBar1.Text = szRetval;
            }

        }

        private void buttonEliminarProducto_Click(object sender, EventArgs e)
        {
            String idusuario = Configuracion.getIdUsuario();
            for (int i = 0; i < (dataGridProductos.VisibleRowCount); i++)
            {
                if (dataGridProductos.IsSelected(i))
                {
                    String sku,idbodega,idubicacion, idcolor,idtalla,szRetval;
                    sku = Convert.ToString(dataGridProductos[i, 0]);
                    idtalla = Convert.ToString(dataGridProductos[i, 2]);
                    idcolor = Convert.ToString(dataGridProductos[i, 3]);
                    idbodega = Convert.ToString(dataGridProductos[i, 4]);
                    idubicacion = Convert.ToString(dataGridProductos[i, 5]);


                    Modelo.eliminaFromCarroComprasCalzado(idusuario, sku, idbodega,idubicacion,idcolor,idtalla,out szRetval);

                    StatusBar1.Text = "SKU: " + sku + " eliminado OK";
                }

            }
            FillFormClean();
            llenaTablaProductos();
        }




    }


}