using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;


namespace s100_tdm
{
    class Sync
    {
        public static String sendCAAC(String rut_p,int idio_p,String idalternativacasino_p) {
            string urlPost_a = MyGlobal.getUrlPost();
            WebRequest request = WebRequest.Create(urlPost_a);
            request.Method = "POST";
            

            int flagVerifica = 1;
            int score = 90000;

            String postData;
            postData =  "" ;
            postData += "idusuario=" + rut_p ;
            postData += "&ts=" + MyGlobal.UnixTimeNow();
            postData += "&idacceso=PDA001"   ;
            postData += "&idio=" + idio_p    ;
            postData += "&flagverifica=" + flagVerifica;
            postData += "&score=" + score;
            postData += "&idalternativacasino=" + idalternativacasino_p;
            postData += "&latitud=" + MyGlobal.getLatitud().ToString();
            postData += "&longitud=" + MyGlobal.getLongitud().ToString();

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

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

            WebResponse response = request.GetResponse();

            // Display the status.
           // Console.WriteLine(CType(response, HttpWebResponse).StatusDescription);
  
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            String responseFromServer = reader.ReadToEnd();
            // Display the content.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;

        }

        public static String sendEnroll(Usuario usuario_p)
        {
            string urlPost_a = MyGlobal.getUrlPost();
            WebRequest request = WebRequest.Create(urlPost_a);
            request.Method = "POST";

            String postData;
            postData = "";
            postData += "idtransaccion=enrolaUsuario" ;
            postData += "&idusuario=" + usuario_p.idusuario_a;
            postData += "&rut=" + usuario_p.rut_a ;
            postData += "&nombres=" + usuario_p.nombres_a;
            postData += "&apellidos=" + usuario_p.apellidos_a;
            postData += "&email=" + usuario_p.email_a;
            postData += "&fechanacimiento=" + usuario_p.fechanacimiento_a;
            postData += "&ts=" + MyGlobal.UnixTimeNow();
            postData += "&latitud=" + MyGlobal.getLatitud().ToString();
            postData += "&longitud=" + MyGlobal.getLongitud().ToString();

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

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

            WebResponse response = request.GetResponse();

            // Display the status.
            // Console.WriteLine(CType(response, HttpWebResponse).StatusDescription);

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            String responseFromServer = reader.ReadToEnd();
            // Display the content.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;

        }


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

        public static Stream GetPostStreamFromNVC( NameValueCollection formData, string boundary)
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





    }
}
