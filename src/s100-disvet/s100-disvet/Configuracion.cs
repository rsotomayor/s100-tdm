using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace s100_disvet
{
    class Configuracion
    {
        public static string IdDispositivo_a = "pda001";
        public static string IdUsuario_a = "user001";
        public static string filetransacciones_a = "\\u\\tpm_transacciones.db";
        public static string filemaestros_a = "\\u\\tpm_maestros.db";

        public static string urlPost_a = "http://ripley.rso.cl/apps/src/ws/wsgateway.php";
        // public static string urlGetMaestro_a = "http://ripley.rso.cl/apps/src/ws/wsgateway.php";
        public static string urlGetMaestro_a = "http://ripley.rso.cl/apps/db/tpm_maestros.db";

        public static String getIdDispositivo()
        {
            return IdDispositivo_a;
        }

        public static void setIdDispositivo(String id_p)
        {
            IdDispositivo_a = id_p;
        }

        public static String getIdUsuario()
        {
            return IdUsuario_a;
        }

        public static void setIdUsuario(String id_p)
        {
            IdUsuario_a = id_p;
        }

        public static string getUrlPost()
        {
            return urlPost_a;
        }

        public static string getTransaccionesFile()
        {
            return filetransacciones_a;
        }

        public static string getMaestrosFile()
        {
            return filemaestros_a;
        }

        public static void setTransaccionesFile(string file_p)
        {
            filetransacciones_a = file_p;
        }

        public static void setMaestrosFile(string file_p)
        {
            filemaestros_a = file_p;
        }

        public static string getUrlMaestro()
        {
            return urlGetMaestro_a;
        }

        public static void setUrlMaestro(string url_p)
        {
            urlGetMaestro_a = url_p;
        }

    }
}
