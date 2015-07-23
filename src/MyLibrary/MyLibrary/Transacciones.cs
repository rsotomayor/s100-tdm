using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SQLite;

namespace MyLibrary
{
    public class Transacciones
    {

        public static Int64 getNumeroEventosDiariosByEAN(String ean_p,int idevento_p,out String szRetval_p)
        {
            szRetval_p = "Init: getNumeroEventosDiariosByEAN";
            SQLiteConnection sqlConn;
            Int64 NRECORD = 0;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file= Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";


            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                return -1;
            }

            String tableName;
            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";

            double tsNowInicio, tsNowTermino;
            DateTime tnow = DateTime.Now;
            DateTime fecha;
            fecha = new DateTime(tnow.Year, tnow.Month, tnow.Day, 0, 0, 0, 0);
            tsNowInicio = MyGlobal.DateTimeToUnixTime(fecha);
            fecha = new DateTime(tnow.Year, tnow.Month, tnow.Day, 23, 59, 59, 0);
            tsNowTermino = MyGlobal.DateTimeToUnixTime(fecha);

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT SUM(NIMPRESIONES) AS NRECORD ";
            mycommand.CommandText += "FROM " + tableName + " ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "TS >= " + tsNowInicio + " AND ";
            mycommand.CommandText += "TS <= " + tsNowTermino + " AND " ;
            mycommand.CommandText += "IDOPCION = " + idevento_p + " AND ";
            mycommand.CommandText += "EAN = '" + ean_p + "' ";

             

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    try
                    {
                        NRECORD = reader.GetInt64(0);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                }
                else
                {
                    szRetval_p = "NOT FOUND";
                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
            }
            sqlConn.Close();
            return NRECORD;
        }

        public static Int64 getNumeroEventosByEAN(String ean_p, int idevento_p, out String szRetval_p)
        {
            szRetval_p = "getNumeroEventosByEAN";
            SQLiteConnection sqlConn;
            Int64 NRECORD = 0;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string filemaestros = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filemaestros + ";Version=3;";


            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                return -1;
            }
            String tableName;
            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";



            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT SUM(NIMPRESIONES) AS NRECORD ";
            mycommand.CommandText += "FROM " + tableName + " ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "IDOPCION = " + idevento_p + " AND ";
            mycommand.CommandText += "EAN = '" + ean_p + "' ";



            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    try
                    {
                        NRECORD = reader.GetInt64(0);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                }
                else
                {
                    szRetval_p = "NOT FOUND";
                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
            }
            sqlConn.Close();
            return NRECORD;
        }

        public static Int64 getNumeroEventosDiariosBySKU(String sku_p, int idevento_p,out String szRetval_p)
        {
            szRetval_p = "getNumeroEventosDiariosBySKU";
            SQLiteConnection sqlConn;
            Int64 NRECORD = 0;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                return -1;
            }
            String tableName;
            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";

            double tsNowInicio, tsNowTermino;
            DateTime tnow = DateTime.Now;
            DateTime fecha;
            fecha = new DateTime(tnow.Year, tnow.Month, tnow.Day, 0, 0, 0, 0);
            tsNowInicio = MyGlobal.DateTimeToUnixTime(fecha);
            fecha = new DateTime(tnow.Year, tnow.Month, tnow.Day, 23, 59, 59, 0);
            tsNowTermino = MyGlobal.DateTimeToUnixTime(fecha);


            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT SUM(NIMPRESIONES) AS NRECORD ";
            mycommand.CommandText += "FROM " + tableName + " ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "TS >= " + tsNowInicio + " AND ";
            mycommand.CommandText += "TS <= " + tsNowTermino + " AND ";
            mycommand.CommandText += "IDOPCION = " + idevento_p + " AND ";
            mycommand.CommandText += "SKU = '" + sku_p + "' ";

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    try
                    {
                        NRECORD = reader.GetInt64(0);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                }
                else
                {
                    szRetval_p = "NOT FOUND";
                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
            }
            sqlConn.Close();
            return NRECORD;
        }
        public static Int64 getNumeroEventosBySKU(String sku_p, int idevento_p, out String szRetval_p)
        {
            szRetval_p = "getNumeroEventosBySKU";
            SQLiteConnection sqlConn;
            Int64 NRECORD = 0;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                return -1;
            }
            String tableName;
            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";


            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT SUM(NIMPRESIONES) AS NRECORD ";
            mycommand.CommandText += "FROM " + tableName + " ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "IDOPCION = " + idevento_p + " AND ";
            mycommand.CommandText += "SKU = '" + sku_p + "' ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    try
                    {
                        NRECORD = reader.GetInt64(0);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                }
                else
                {
                    szRetval_p = "NOT FOUND";
                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
            }
            sqlConn.Close();
            return NRECORD;
        }

    }
}
