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


namespace s100_disvet
{
    public partial class FormSincronizacion : Form
    {
        delegate void SetTextCallback(int progress);
        public FormSincronizacion()
        {
            InitializeComponent();
        }

        public void SetProgress(int progress_p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.ProgressBar1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetProgress);
                this.Invoke(d, new object[] { progress_p });
            }
            else
            {
                ProgressBar1.Value = progress_p;

            }
        }


        public string HttpUploadFile(string url, NameValueCollection nvc, tFiles[] myFiles2Upload)
        {
            string retval = "CAAC-KO";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream postDataStream = Sync.GetPostStream(nvc, boundary, myFiles2Upload);
            wr.ContentLength = postDataStream.Length;
            this.SetProgress(10);


            Stream rs = wr.GetRequestStream();
            postDataStream.Position = 0;

            byte[] buffer = new byte[1024];
            int bytesRead = 0;

            this.SetProgress(25);
            while ((bytesRead = postDataStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            postDataStream.Close();
            rs.Close();
            this.SetProgress(75);

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                retval = string.Format("Sube OK: {0}", reader2.ReadToEnd());
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
            }
            finally
            {
                wr = null;
            }


            this.SetProgress(100);
            return retval;
        }

        public String HttpGetDownloadFile()
        {
            String data;
            string urlget = Configuracion.getUrlMaestro();
            String iddispositivo;
            String idusuario;

            iddispositivo = Configuracion.getIdDispositivo();
            idusuario = Configuracion.getIdUsuario();
            string id = iddispositivo + "|" + idusuario;

            urlget = urlget + "?wsname=getarchivomaestro";
            urlget = urlget + "&id=" + id;
            urlget = urlget + "&iddispositivo=" + iddispositivo;
            urlget = urlget + "&idusuario=" + idusuario;

            urlget = Configuracion.getUrlMaestro();
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(urlget);
                httpRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                System.IO.Stream dataStream = httpResponse.GetResponseStream();
                byte[] inBuf = new byte[10000000];
                int bytesToRead = (int)inBuf.Length;

                int bytesRead = 0;
                this.SetProgress(0);
                while (bytesToRead > 0)
                {
                    int n = dataStream.Read(inBuf, bytesRead, bytesToRead);
                    if (n == 0)
                        break;
                    bytesRead += n;
                    bytesToRead -= n;
                }

                if (bytesRead > (10000000 - 1024))
                {
                    data = "FILE TOO BIG, KO DOWNLOAD";
                    dataStream.Close();
                    return data;
                }

                string filemaestro = Configuracion.getMaestrosFile();
                string filemaestro_nuevo = "NEW_" + Configuracion.getMaestrosFile();
                string filemaestro_old = "OLD_" + Configuracion.getMaestrosFile() + ".old";


                FileStream fstr = new FileStream(filemaestro_nuevo, FileMode.OpenOrCreate, FileAccess.Write);
                fstr.Write(inBuf, 0, bytesRead);
                dataStream.Close();
                fstr.Close();
                this.SetProgress(100);

                httpResponse.Close();
                data = "OK DOWNLOAD";
                if (File.Exists(filemaestro))
                {
                    File.Copy(filemaestro, filemaestro_old);
                }
                File.Copy(filemaestro_nuevo, filemaestro);
            }//try
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                data = e.Message;
            }//catc
            return data;
        }


        private void ButtonSincronizaRecibir_Click(object sender, EventArgs e)
        {
            String responseFromServer;
            ButtonSincronizaRecibir.Enabled = false;
            responseFromServer = HttpGetDownloadFile();
            ButtonSincronizaRecibir.Enabled = true;
        }

        private void ButtonSincronizaEnviar_Click(object sender, EventArgs e)
        {
            ButtonSincronizaEnviar.Enabled = false;
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

            myFiles2Upload[0].paramName_a = "file";
            myFiles2Upload[0].nombre_a = "tpm_transacciones.db";
            myFiles2Upload[0].tipo_a = "object/sqlite3";
            myFiles2Upload[0].file_a = data;


            string response;

            try
            {
                string urlPost_a = Configuracion.getUrlPost();
                response = this.HttpUploadFile(urlPost_a, nvc, myFiles2Upload);
            }
            catch (Exception ex)
            {
                response = "Error en red de datos:" + ex.ToString().Substring(0, 20);
            }

            // RSO:  German, aqui se debiera manejar la llamada a los WS de Sinacofi
            labelSincronizacion.Text = response;

            MessageBox.Show(response);

            ButtonSincronizaEnviar.Enabled = true;
 
        }

    }
}