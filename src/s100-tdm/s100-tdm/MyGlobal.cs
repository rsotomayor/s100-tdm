using System;
using System.Collections.Generic;
using System.Text;

namespace s100_tdm
{
    class MyGlobal
    {
        static double Latitud_a = -33.44001855968913;
        static double Longitud_a = -70.6552004814148;
        static string urlPost_a = "http://solem.rso.cl/apps/src/s-caac/logger.php";

        public static long UnixTimeNow() {
        // Dim _TimeSpan As TimeSpan = DirectCast((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)), TimeSpan)
            // Return CLng(_TimeSpan.TotalSeconds)
            TimeSpan _TimeSpan;
            DateTime mydate = new DateTime(1970, 1, 1, 0, 0, 0);
//            _TimeSpan = DirectCast((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)), TimeSpan);
            _TimeSpan = DateTime.UtcNow - mydate;
           
            return (long) _TimeSpan.TotalSeconds;

        }

        public static double getLatitud()
        {

            return Latitud_a;
        }

        public static double getLongitud()
        {

            return Longitud_a;
        }
        public static string getUrlPost()
        {
            return urlPost_a;
        }

        public byte[] StringToBytes(String cadena)
        {
            System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
            return codificador.GetBytes(cadena);
        }


    }
}
