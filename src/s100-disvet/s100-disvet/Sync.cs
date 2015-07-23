using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace s100_disvet
{
    class Sync
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


        public static void downloadFile()
        {
            // WebClient webClient = new WebClient();
            // webClient.DownloadFile("http://mysite.com/myfile.txt", @"c:\myfile.txt");
        }

    }
}
