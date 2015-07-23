using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Windows.Forms;
using MyLibrary;


namespace s100_retail
{
    class Etiqueta
    {
        static String Id_a;
        public static int registraTransaccion(Producto producto_p, int opcion_p, String place_p,int cantidad_p,out String szRetval_p)
        {
            szRetval_p = "registraTransaccion";
            int retval = 0;
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();

            string file = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                String szRetval = myException.ToString();
                return -1;
            }


            SQLiteCommand mycommand;

 
            String IdUsuario = Configuracion.getIdUsuario();
            String idlocation = Configuracion.getIdLocation();
            long TS;
            TS = MyGlobal.UnixTimeNow();

            Id_a = "TTRANS" + idlocation + "-" + place_p + "-" + producto_p.EAN + "-" + opcion_p + "-" + IdUsuario + "-" + TS;
            Id_a = MyGlobal.getMD5Hash(Id_a);

            mycommand = new SQLiteCommand(sqlConn);


            String tableName = Modelo.getTablePrefix() + "TRANSACCIONES";


            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,LOCATION,EAN,IDUSUARIO,TS,IDOPCION,NIMPRESIONES,PRICE) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,LOCATION,EAN,SKU,IDUSUARIO,TS,IDOPCION,NIMPRESIONES,PRICE) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,LOCATION,PLACE,EAN,IDUSUARIO,TS,IDOPCION,NIMPRESIONES,PRICE) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,LOCATION,PLACE,EAN,SKU,IDUSUARIO,TS,IDOPCION,NIMPRESIONES,PRICE) ";
            }


            mycommand.CommandText = mycommand.CommandText + "VALUES ( ";
            mycommand.CommandText = mycommand.CommandText + "'" + Id_a + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + idlocation + "',";
            if ( place_p != null ) {
                mycommand.CommandText = mycommand.CommandText + "'" + place_p + "',";
            }
            mycommand.CommandText = mycommand.CommandText + "'" + producto_p.EAN + "',";
            if ( producto_p.SKU != null)
            {
                mycommand.CommandText = mycommand.CommandText + "'" + producto_p.SKU + "',";
            }

            mycommand.CommandText = mycommand.CommandText + "'" + IdUsuario + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + TS + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + opcion_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + cantidad_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + producto_p.PRECIO + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 3:" + myException.Message;
                sqlConn.Close();
                return -1;
            }

            sqlConn.Close();
            String IdEvento = "TTRANS";
            Modelo.registraEvento(Id_a, TS, IdEvento, out szRetval_p);
            return retval;
        }

        public static int actualizaTransaccion(Producto producto_p, int opcion_p, String place_p, int cantidad_p)
        {
            int retval = 0;
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();

            string filetransacciones = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filetransacciones + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                String szRetval = myException.ToString();
                return -1;
            }


            SQLiteCommand mycommand;


            mycommand = new SQLiteCommand(sqlConn);


            String tableName = Modelo.getTablePrefix() + "TRANSACCIONES";

            mycommand.CommandText = "UPDATE " + tableName + " ";
            mycommand.CommandText = mycommand.CommandText + " SET NIMPRESIONES = " + cantidad_p + " ";
            mycommand.CommandText = mycommand.CommandText + "WHERE ";
            mycommand.CommandText = mycommand.CommandText + "ID    = '" + Id_a + "' ";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch
            {
                sqlConn.Close();
                return -1;
            }

            sqlConn.Close();
            return retval;
        }

    }
}
