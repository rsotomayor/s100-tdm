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
using MyLibrary;

namespace s100_retail
{
    public partial class FormSincronizacion : Form
    {

        delegate void SetAvanceCallback(Int64 value_p, String message_p);

        Int64 iSize_a;
        bool flagCancelar_a = false;
        DateTime startOperation_a;
        private FormInicio m_parent;
        Thread newThreadDownload_a;
        Thread newThreadUpload_a;
        

        public FormSincronizacion(FormInicio form_p)
        {
            InitializeComponent();
            m_parent = form_p;
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
                    buttonSincronizaRecibir.Enabled = true;
                    buttonSincronizaEnviar.Enabled = true;
                } else 
                {
                    double porcentaje ;
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

 
        private void FormSincronizacion_Load(object sender, EventArgs e)
        {
            if (Configuracion.getIdUsuario() == "admin")
            {
                String resultado;
                if (Modelo.InitDataBaseConfiguracion(out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }
                Configuracion.readConfiguracion();
                buttonSincronizaEnviar.Enabled = false;
            }
        }

        public static Stream GetPostStreamFromNVC(NameValueCollection formData, string boundary)
        {
            Stream postDataStream = new System.IO.MemoryStream();
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in formData.Keys)
            {
                postDataStream.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, formData[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                postDataStream.Write(formitembytes, 0, formitembytes.Length);
            }
            postDataStream.Write(boundarybytes, 0, boundarybytes.Length);

            return postDataStream;
        }


        public int HttpUploadFile(string url, NameValueCollection nvc, tFiles[] myFiles2Upload,out String szRetcode_p)
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
            this.SetAvance(10,null);

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

            this.SetAvance(25,null);

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

            while ( (bytesRead != 0) && flagCancelar_a == false)
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
                String myResponse2;
                Modelo.BorraTransacciones(out myResponse2);
                myResponse = myResponse + ":" + myResponse2;
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
            string response="KO";
            startOperation_a = DateTime.UtcNow;

            String iddispositivo;
            String idusuario;

            iddispositivo = Configuracion.getIdDispositivo();
            idusuario = Configuracion.getIdUsuario();
            string id = iddispositivo + "|" + idusuario;

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("wsname", "enviatransacciones");
            nvc.Add("id", id);
            nvc.Add("iddispositivo", iddispositivo);
            nvc.Add("idusuario", idusuario);
            long ts;
            ts = MyGlobal.UnixTimeNow();
            nvc.Add("ts", ts.ToString());

            byte[] data;
            String myFileName;
       
            myFileName = Configuracion.getTransaccionesFile();

            data = MyGlobal.ReadByteArrayFromFile(myFileName);

            tFiles[] myFiles2Upload = new tFiles[1];

            myFiles2Upload[0].paramName_a = "transacciones";
            myFiles2Upload[0].nombre_a = "tpm_transacciones.db";
            myFiles2Upload[0].tipo_a = "object/sqlite3";
            myFiles2Upload[0].file_a = data;

            string urlPost_a = Configuracion.getUrlPost();

            int retval;
            try
            {
                retval = this.HttpUploadFile(urlPost_a, nvc, myFiles2Upload,out response);
            }
            catch (Exception ex)
            {
                response = "Error en red de datos:" + ex.ToString().Substring(0, 20);
                response = "Error en red de datos";
            }

            SetAvance(0,response);

        }


        private void ButtonSincronizaEnviar_Click(object sender, EventArgs e)
        {
            buttonSincronizaEnviar.Enabled = false;
            buttonSincronizaRecibir.Enabled = false;

            string message = "Envia Archivo Transacciones ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {   ThreadStart threadDelegate;
                try
                {
                    threadDelegate = new ThreadStart(uploadFile);
                }
                catch
                {
                    StatusBar1.Text = "Error al iniciar tarea";
                    buttonSincronizaEnviar.Enabled = true;
                    buttonSincronizaRecibir.Enabled = true;
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
                    buttonSincronizaEnviar.Enabled = true;
                    buttonSincronizaRecibir.Enabled = true;
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
                buttonSincronizaEnviar.Enabled = true;
                buttonSincronizaRecibir.Enabled = true;
            }

        }

        private void ButtonSincronizaRecibir_Click(object sender, EventArgs e)
        {
            buttonSincronizaRecibir.Enabled = false;
            buttonSincronizaEnviar.Enabled = false;
            flagCancelar_a = false;

            String sUrlToReadFileFrom = Configuracion.getUrlMaestroPrefix() + "-" + Configuracion.getIdLocation() + ".db";


            labelSincronizacion.Text = "URL: " + sUrlToReadFileFrom;

            HttpWebRequest hRequest2;

            try
            {
               hRequest2 = (HttpWebRequest)WebRequest.Create(sUrlToReadFileFrom);
            }
            catch
            {
                iSize_a = 0;
                MessageBox.Show("Error al obtener info del archivo: " + sUrlToReadFileFrom);
                buttonSincronizaRecibir.Enabled = true;
                buttonSincronizaEnviar.Enabled = true;
                return;
            }
            System.Net.HttpWebResponse response2;
            try
            {
                response2 = (System.Net.HttpWebResponse)hRequest2.GetResponse();
            }
            catch
            {
                iSize_a = 0;
                MessageBox.Show("Error al obtener info del archivo: " + sUrlToReadFileFrom);
                buttonSincronizaRecibir.Enabled = true;
                buttonSincronizaEnviar.Enabled = true;
                return;
            }

            response2.Close();
            // gets the size of the file in bytes
            iSize_a = response2.ContentLength;
            labelSincronizacion.Text = "URL: " + sUrlToReadFileFrom + " " + String.Format("{0:0,0}", (iSize_a / (1024))) + " [Kb]";


            string message = "Descargar Archivo Tamaño " + String.Format("{0:0,0}", (iSize_a / (1024)))  +" [Kb] ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                ProgressBar1.Maximum = 100;
                ProgressBar1.Minimum = 0;
                ThreadStart threadDelegate;

                try
                {
                    threadDelegate = new ThreadStart(downloadFile);
                }
                catch
                {
                    StatusBar1.Text = "Error al iniciar tarea";
                    buttonSincronizaRecibir.Enabled = true;
                    buttonSincronizaEnviar.Enabled = true;
                    flagCancelar_a = false;
                    return;
                }

                try
                {
                    newThreadDownload_a = new Thread(threadDelegate);
                }
                catch
                {
                    StatusBar1.Text = "Error al iniciar delegado";
                    buttonSincronizaRecibir.Enabled = true;
                    buttonSincronizaEnviar.Enabled = true;
                    flagCancelar_a = false;
                    return;
                }


                try
                {
                    newThreadDownload_a.Start();
                }
                catch
                {
                    StatusBar1.Text = "Error al iniciar descarga";
                }

            }
            else
            {
                buttonSincronizaRecibir.Enabled = true;
                buttonSincronizaEnviar.Enabled = true;
            }

            flagCancelar_a = false;

        }

        public void renombraArchivo()
        {
            String idlocal=Configuracion.getIdLocation();
            String idusuario = Configuracion.getIdUsuario();
            String myResponse;

            String sFilePathToWriteFileTo1 = Configuracion.getMaestrosFile() + ".download";
            String sFilePathToWriteFileTo2 = Configuracion.getMaestrosFile();
            if (File.Exists(sFilePathToWriteFileTo2))
            {
                File.Delete(sFilePathToWriteFileTo2);
            }

            try
            {
                File.Move(sFilePathToWriteFileTo1, sFilePathToWriteFileTo2);
            }
            catch
            {
                SetAvance(-3, "Error al mover archivo bajado");
                Modelo.Log(idlocal, idusuario, "DOWNLOAD", "KO", "ERROR AL MOVER ARCHIVO EN PDA", out myResponse);
                return;
            }
            SetAvance(-4, "**** Download OK ****");
            TimeSpan diff = DateTime.UtcNow - startOperation_a;
            String szNota = "Tiempo download " + diff.TotalSeconds + "[seg]";
            Modelo.Log(idlocal, idusuario, "DOWNLOAD", "OK", szNota, out myResponse);

        }

        public void downloadFile()
        {
            String idlocal = Configuracion.getIdLocation();
            String idusuario = Configuracion.getIdUsuario();
            int packetSize = Configuracion.getPacketSize();
            String myResponse;
            startOperation_a = DateTime.UtcNow;
            String sUrlToReadFileFrom = Configuracion.getUrlMaestroPrefix() + "-" + Configuracion.getIdLocation() + ".db";
            String sFilePathToWriteFileTo = Configuracion.getMaestrosFile()+".download";

            HttpWebRequest hRequest;

            try
            {
                hRequest = (HttpWebRequest)WebRequest.Create(sUrlToReadFileFrom);
            } catch
            {
                // SetAvance(-1, "Transferencia no completada [001]");
                return;

            }
            HttpWebResponse response;
            SetAvance(0, null);

            try
            {

                response = (HttpWebResponse)hRequest.GetResponse();
            }
            catch
            {
                // SetAvance(-1, "Transferencia no completada [002]");
                return;
            }

            using ( response )
            {
                // Download the file to the fullFileName location
                Stream streamResponse;
                try
                {
                    streamResponse = response.GetResponseStream();
                }
                catch
                {
                    // SetAvance(-1, "Transferencia no completada [003]");
                    return;
                }

                if (streamResponse != null)
                {
                    System.IO.FileStream fstr ;
                    try
                    {
                        fstr = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write);

                    } catch 
                    {
                        // SetAvance(-1, "Transferencia no completada [004]");
                        return;
                    }
                    DateTime startTime = DateTime.UtcNow;
                    byte[] buffer = new byte[packetSize];
                    int bytesRead;
                    try
                    {
                        bytesRead = streamResponse.Read(buffer, 0, packetSize);

                    }
                    catch
                    {
                        // SetAvance(-1, "Transferencia no completada [004]");
                        return;
                    }

                    Int64 offset = bytesRead;
                    SetAvance(offset, null);
                    while (bytesRead > 0 && flagCancelar_a != true)
                    {
                        try
                        {
                            fstr.Write(buffer, 0, bytesRead);
                        }
                        catch
                        {
                            // SetAvance(-1, "Transferencia no completada [004]");
                            return;
                        }
                        DateTime nowTime = DateTime.UtcNow;
                        if ((nowTime - startTime).TotalMinutes > 20)
                        {
                            SetAvance(-1, "Timeout Error");
                        }
                        try
                        {
                            bytesRead = streamResponse.Read(buffer, 0, packetSize);
                        }
                        catch
                        {
                            // SetAvance(-1, "Transferencia no completada [004]");
                            return;
                        }
                        offset += bytesRead;
                        SetAvance(offset, null);

                    }
                    streamResponse.Close();
                    fstr.Close();
                    if (offset < iSize_a)
                    {
                        SetAvance(-1, "Transferencia no completada");
                        try
                        {
                            Modelo.Log(idlocal, idusuario, "DOWNLOAD", "KO", "Transferencia no completada", out myResponse);
                        } catch
                        {
                            // SetAvance(-1, "Transferencia no completada [004]");
                            return;
                        }
                    }
                    else
                    {
                        // Copia archivo
                        renombraArchivo();
                    }
                }
            }



            return;

        }


        private void labelSincronizacion_ParentChanged(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            FormConfiguracion myformConfiguracion_a = new FormConfiguracion();
            myformConfiguracion_a.ShowDialog();
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            flagCancelar_a = true;
            buttonSincronizaRecibir.Enabled = true;
            buttonSincronizaEnviar.Enabled = true;


        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            FormTransacciones myformTransacciones = new FormTransacciones();
            myformTransacciones.ShowDialog();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            FormMaestros myformMaestros = new FormMaestros();
            myformMaestros.ShowDialog();
        }

        private void FormSincronizacion_Closed(object sender, EventArgs e)
        {
            flagCancelar_a = true;
            buttonSincronizaRecibir.Enabled = true;
            buttonSincronizaEnviar.Enabled = true;

            m_parent.setInicioOperacion();

        }


 
    }
}