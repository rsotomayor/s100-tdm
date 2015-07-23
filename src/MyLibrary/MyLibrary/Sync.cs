using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;


namespace MyLibrary
{
    public class Sync
    {
        public static Stream GetPostStream(NameValueCollection formData, string boundary, tFiles[] myFiles2Upload)
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


            string headerTemplate;
            string header;
            byte[] headerbytes;

            foreach (tFiles value in myFiles2Upload)
            {
                headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                header = string.Format(headerTemplate, value.paramName_a, value.nombre_a, value.tipo_a);
                headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                postDataStream.Write(headerbytes, 0, headerbytes.Length);
                postDataStream.Write(value.file_a, 0, value.file_a.Length);
                postDataStream.Write(boundarybytes, 0, boundarybytes.Length);

            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            postDataStream.Write(trailer, 0, trailer.Length);

            return postDataStream;
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

        public static Stream GetPostStreamFromByteArray(string filePath, byte[] byteArray, string boundary, string paramName, string contentType)
        {
            Stream postDataStream = new System.IO.MemoryStream();


            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, filePath, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);



            postDataStream.Write(headerbytes, 0, headerbytes.Length);

            postDataStream.Write(byteArray, 0, byteArray.Length);

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            postDataStream.Write(trailer, 0, trailer.Length);

            return postDataStream;
        }

        public static string HttpPost(string url, NameValueCollection nvc)
        {
            string retval = "CAAC-KO";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wr.Timeout = wr.Timeout * 3;
            wr.ReadWriteTimeout = wr.ReadWriteTimeout * 3;
            
            Stream postDataStream = Sync.GetPostStreamFromNVC(nvc, boundary);
            wr.ContentLength = postDataStream.Length;


            Stream rs = wr.GetRequestStream();
            postDataStream.Position = 0;

            byte[] buffer = new byte[1024];
            int bytesRead = 0;


            while ((bytesRead = postDataStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            postDataStream.Close();
            rs.Close();


            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                retval = string.Format("RETVAL: {0}", reader2.ReadToEnd());
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


            return retval;
        }



        public static String Login(string idusuario_p, String password_p) {
            String retval;
            WebRequest request;

            String urlpost = Configuracion.getUrlPost();
            request = WebRequest.Create(urlpost);
            request.Method = "POST";
            retval = "OK";

            String postData = "";
            postData = "ws=auth" ;
            postData = postData + "&idusuario=" + idusuario_p ;
            postData = postData + "&password=" + password_p;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.

            Stream dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            /*
            WebResponse response = request.GetResponse();
            // Display the status.
            // Console.WriteLine(CType(response, HttpWebResponse).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
           String responseFromServer= reader.ReadToEnd();
            // Display the content.
            reader.Close();
            dataStream.Close();
            response.Close();
            if ( responseFromServer.IndexOf("OK",0) > 0 ) {
                retval = "KO";
            } else {
                retval = "OK";
            }
            */
            return retval;
        }

        public static Stream myGetPostStreamFromNVC(NameValueCollection formData, string boundary)
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

        public static string myHttpPost(string url, NameValueCollection nvc)
        {
            string retval = "CAAC-KO";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream postDataStream = myGetPostStreamFromNVC(nvc, boundary);
            wr.ContentLength = postDataStream.Length;


            Stream rs = wr.GetRequestStream();
            postDataStream.Position = 0;

            byte[] buffer = new byte[1024];
            int bytesRead = 0;


            while ((bytesRead = postDataStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            postDataStream.Close();
            rs.Close();


            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                retval = string.Format("{0}", reader2.ReadToEnd());
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


            return retval;
        }


    }
}
