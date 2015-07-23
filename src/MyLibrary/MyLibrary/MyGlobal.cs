using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


using System.Data.SQLite;
using System.Security.Cryptography;
using System.Runtime.InteropServices;


public struct tFiles
{
    public string paramName_a;
    public string nombre_a;
    public string tipo_a;
    public byte[] file_a;
}

public struct tOperacion
{
    public String   idUsuario_a;
//    public DateTime fechaHora_a;
    public Int64 ts_a;

    public String   nota_a;

}

static public class Constants
{
    public const int ETIQUETAJEPROMOCIONAL = 0;
    public const int ETIQUETAJEREVENUE = 1;
    public const int RECOGIDA = 2;
    public const int CAJAS = 3;
    public const int AGREGAINVENTARIO = 10;
    public const int RESTAINVENTARIO = -10;

}

namespace MyLibrary
{

    public class MyGlobal
    {
        public static long   tsgps_a     = 0;
        public static double latitud_a = 0;
        public static double longitud_a = 0;
        public static double velocidad_a = 0.0;
        public static double rumbo_a     = 0.0;
        public static double altura_a    = 0.0;

        public enum BeepTypes
        {
            Simple = -1,
            Ok = 0x00000000,
            IconHand = 0x00000010,
            IconQuestion = 0x00000020,
            IconExclamation = 0x00000030,
            IconAsterisk = 0x00000040
        }

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(BeepTypes uType);

        public static string getMD5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string getSHA1Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            SHA1 md5Hasher = SHA1.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        public static long UnixTimeNow()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = DateTime.UtcNow - origin;

            return (long ) diff.TotalSeconds;

        }

        /// <summary>
        /// method for converting a System.DateTime value to a UNIX Timestamp
        /// </summary>
        /// <param name="value">date to convert</param>
        /// <returns></returns>
        public static double DateTimeToUnixTime(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (double)span.TotalSeconds;
        }


        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp_p)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp_p).ToLocalTime();
            return dtDateTime;
        }


        public static byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;

            if (File.Exists(fileName) == true)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(fileName).Length;
                buff = br.ReadBytes((int)numBytes);

                fs.Close();
            }       
            return buff;
        }


    }
}
