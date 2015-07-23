using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace MyLibrary
{
    public class Configuracion
    {
        public static string IdLocation_a = null;
        public static string IdBodega_a = null;
        public static string Location_a = null;
        public static string IdUsuario_a = null;
        public static string IdRol_a = null;

        public static string IdDispositivo_a = null;
        public static int EANSIZE = 13 ;
        public static int RF_EANSIZE = 15;

        public static string currenPath_a = null;
        public static string dbPath_a =null;

        public static string fileTransacciones_a ;
        public static string fileMaestros_a;
        public static string fileConfiguracion_a;
        public static string fileCarroCompras_a;
        static bool flagLogGps_a = false;
        static int timeOutLogGps_a = 300  ;

        public static string urlPost_a = "http://10.0.156.232/ripley/upload.aspx";
        public static string urlMaestrosPrefix_a = "http://10.0.156.232/ripley/maestros/tpm_maestros";
        public static int packetSize_a=1024;


        public static int getPacketSize()
        {
            return packetSize_a;
        }

        public static void setPacketSize(int packetSize_p)
        {
            packetSize_a = packetSize_p;
        }
        public static int getTimeOutLogGPS() {
            return timeOutLogGps_a;
        }
        public static void setTimeOutLogGPS(int timeOutLogGps_p)
        {
            timeOutLogGps_a = timeOutLogGps_p;
        }

        public static bool getFlagLogGPS()
        {
            return flagLogGps_a;
        }

        public static void setFlagLogGPS(bool flagLogGps_p)
        {
            flagLogGps_a = flagLogGps_p;
        }

        public static String getIdDispositivo() 
        {
            return IdDispositivo_a;
        }
        public static String getIdLocation()
        {
            return IdLocation_a;
        }

        public static void setIdLocation(String id_p)
        {
            IdLocation_a = id_p;
        }


        public static String getLocation()
        {
            return Location_a;
        }

        public static void setLocation(String id_p)
        {
            Location_a = id_p;
        }

        public static void setIdBodega(String id_p)
        {
            IdBodega_a = id_p;
        }



        public static void setIdDispositivo(String id_p)
        {
            IdDispositivo_a = id_p;
        }

        public static String getIdUsuario()
        {
            return IdUsuario_a;
        }

        public static String getIdRol()
        {
            return IdRol_a;
        }

        public static String getIdBodega()
        {
            return IdBodega_a;
        }

        public static void setIdUsuario(String id_p)
        {
            IdUsuario_a = id_p;
        }

        public static void setIdRol(String idrol_p)
        {
            IdRol_a = idrol_p;
        }


        public static string getUrlPost()
        {
            return urlPost_a;
        }

        public static string getTransaccionesFile()
        {
            if (System.IO.Directory.Exists(dbPath_a))
            {
                fileTransacciones_a = dbPath_a + "\\" + Modelo.getTablePrefix() + "transacciones.db";
            }
            else
            {
                fileTransacciones_a = currenPath_a + "\\" + Modelo.getTablePrefix() + "transacciones.db";
            }
    
            return fileTransacciones_a;
        }

        public static string getCarroComprasFile()
        {
            if (System.IO.Directory.Exists(dbPath_a))
            {
                fileCarroCompras_a = dbPath_a + "\\" + Modelo.getTablePrefix() + "carrocompras.db";
            }
            else
            {
                fileCarroCompras_a = currenPath_a + "\\" + Modelo.getTablePrefix() + "carrocompras.db";
            }

            return fileCarroCompras_a;
        }


        public static void setTransaccionesFile(string file_p)
        {
            fileTransacciones_a = file_p;
        }

        public static void setMaestrosFile(string file_p)
        {
            fileMaestros_a = file_p;
        }

        public static string getDBPath()
        {
            return dbPath_a;
        }

        public static void setDBPath(String path_p)
        {
            dbPath_a = path_p;
        }

        public static void setCurrentPath(String currentpath_p)
        {
            currenPath_a = currentpath_p;
        }

        public static string getMaestrosFile()
        {
            if (System.IO.Directory.Exists(dbPath_a))
            {
                fileMaestros_a = dbPath_a + "\\" + Modelo.getTablePrefix() + "maestros.db";
            }
            else
            {
                fileMaestros_a = currenPath_a + "\\" + Modelo.getTablePrefix() + "maestros.db";
            }
            return fileMaestros_a;
        }

        public static void setConfiguracionFile(string file_p)
        {
            fileConfiguracion_a = file_p;
        }

        public static string getConfiguracionFile()
        {
            fileConfiguracion_a = currenPath_a + "\\" + Modelo.getTablePrefix() + "config.db";
            return fileConfiguracion_a;
        }

        public static string getUrlMaestroPrefix()
        {
            return urlMaestrosPrefix_a;
        }

        public static void setUrlMaestroPrefix(string url_p)
        {
            urlMaestrosPrefix_a = url_p;
        } 
   
        public static void readConfiguracion() {
            String dummy;
            getRegistroConfiguracion("urlpost",out urlPost_a);
            getRegistroConfiguracion("urlmaestrosprefix",out urlMaestrosPrefix_a);
            getRegistroConfiguracion("iddispositivo", out IdDispositivo_a);
            getRegistroConfiguracion("dbpath", out  dbPath_a);
            getRegistroConfiguracion("flagloggps", out dummy );
            if (dummy == "true")
            {
                flagLogGps_a = true;
            }
            else
            {
                flagLogGps_a = false;
            }
            getRegistroConfiguracion("timeoutloggps", out  dummy);
            timeOutLogGps_a = Convert.ToInt32(dummy);
            getRegistroConfiguracion("packetsize", out  dummy);
            packetSize_a = Convert.ToInt32(dummy);


        }

        public static int guardarParametro(String parametro_p,String valor_p,out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();

            string file = Configuracion.getConfiguracionFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            SQLiteCommand mycommand;

            String sqlString;
            String tableName = Modelo.getTablePrefix() + "PARAMETROS";

            sqlString = "INSERT INTO " + tableName  + "(ID,VALOR)  ";
            sqlString = sqlString + " VALUES ( '" + parametro_p + "','"+valor_p+"' ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch 
            {
                sqlString = "UPDATE " + tableName  + "  ";
                sqlString = sqlString + " SET VALOR = '"+ valor_p + "' ";
                sqlString = sqlString + " WHERE ID = '" + parametro_p + "' ; ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                retval = 0;
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = -1;
                }
            }


            return retval;

        }

        public static bool getEstadoActivacion(string idsoftware_p) {
            String registroActivacion;
            String clave;
            bool retval = false;
            if (getRegistroConfiguracion("keyactivacion", out registroActivacion) == 0)
            {
                String IMEI = PhoneInfo.GetIMEI();
                String feed = IMEI + idsoftware_p;
                clave = MyGlobal.getMD5Hash(feed); // no es muy buena la clave, pero sirve
                if (clave == registroActivacion)
                {
                    retval = true;
                }
            }
            return retval;
        }

        public static int getRegistroConfiguracion(String id_p,out String szRetval_p)
        {
            SQLiteConnection sqlConn;
            int retval = 0;
            szRetval_p = "KO";

            if (id_p.Length == 0)
            {
                return -1 ;
            }
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string fileconfiguracion = Configuracion.getConfiguracionFile();
            sqlConn.ConnectionString = "Data Source=" + fileconfiguracion + ";Version=3;";


            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                return -1;
            }
            String tableName = Modelo.getTablePrefix() + "PARAMETROS";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT VALOR ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableName + " ";
            mycommand.CommandText = mycommand.CommandText + "WHERE ";
            mycommand.CommandText = mycommand.CommandText + "ID = '" + id_p + "' ; ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    szRetval_p = reader.GetString(0);
                }
                else
                {
                    szRetval_p = "NOT FOUND";
                    retval = 1;
                }
            }
            catch (SQLiteException myException)
            {
                String szRetval = myException.Message;
                retval = -1;
            }
            sqlConn.Close();
            return retval;
        }

        
    }
}
