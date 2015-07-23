using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace s100_disvet
{
    static class Constants
    {
        public const int ETIQUETAJEPROMOCIONAL = 0;
        public const int ETIQUETAJEREVENUE = 1;
        public const int IMPRIME_SI = 1;
        public const int IMPRIME_NO = 0;
        public const int AGREGAINVENTARIO = 1;
        public const int RESTAINVENTARIO = -1;

    }

    class Producto
    {
        public String EAN;
        public String SKU;
        public String PROD;
        public double PRECIO;
        public int SemanaAntiguedad;
        public int flagEtiquetar;
        public int flagRevenue;
        public int flagRecogida;

        public int getRegistro(String ean_p)
        {
            SQLiteConnection sqlConn;
            int retval = -1;
            if (ean_p.Length == 0)
            {
                return retval;
            }
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string filemaestros = Configuracion.getMaestrosFile();
            sqlConn.ConnectionString = "Data Source=" + filemaestros + ";Version=3;";


            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
            }


            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT PRO.CODE, PRO.NAME,PRO.PRICESELL,PFL.SEMANAANTIGUEDAD,PFL.FLAGETIQUETA, PFL.FLAGREVENUE, PFL.FLAGRECOGIDA ";
            mycommand.CommandText = mycommand.CommandText + "FROM PRODUCTS PRO LEFT JOIN SVT_PRODUCTS_FLAG PFL ON ( PRO.ID = PFL.PRODUCT ) ";
            mycommand.CommandText = mycommand.CommandText + "WHERE ";
            mycommand.CommandText = mycommand.CommandText + "PRO.CODE = '" + ean_p + "' ; ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    EAN = ean_p;
                    SKU = reader.GetString(0);
                    PROD = reader.GetString(1);
                    PRECIO = reader.GetDouble(2);
                    SemanaAntiguedad = reader.GetInt16(3);
                    flagEtiquetar = reader.GetInt16(4);
                    flagRevenue = reader.GetInt16(5);
                    flagRecogida = reader.GetInt16(6);
                    retval = 0;
                }
                else
                {
                    EAN = ean_p;
                    SKU = "EAN NO ENCONTRADO";
                    PROD = "";
                    PRECIO = 0;
                    SemanaAntiguedad = 0;
                    flagEtiquetar = 0;
                    flagRevenue = 0;
                    flagRecogida = 0;

                    retval = 1;
                }
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
                retval = -1;
            }
            sqlConn.Close();
            return retval;
        }

        public int contar(Producto producto_p, int cantidad_p, String location_p)
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
                MessageBox.Show("Message: " + myException.Message + "\n");
            }


            SQLiteCommand mycommand;

            System.DateTime objCurrentDate = DateTime.Now;
            String FECHAHORA;
            String ID;
            String ATTRIBUTESETINSTANCE_ID = "NO APLICA";
            int REASON;

            if (cantidad_p > 0)
            {
                REASON = Constants.AGREGAINVENTARIO;
            }
            else
            {
                REASON = Constants.RESTAINVENTARIO;

            }

            FECHAHORA = objCurrentDate.Year + "-" + objCurrentDate.Month + "-" + objCurrentDate.Day;
            FECHAHORA = FECHAHORA + " " + objCurrentDate.Hour + ":" + objCurrentDate.Minute + ":" + objCurrentDate.Second;

            ID = MyGlobal.getMD5Hash(FECHAHORA + producto_p.EAN);


            mycommand = new SQLiteCommand(sqlConn);

            mycommand.CommandText = "INSERT INTO STOCKDIARY(ID,DATENEW,REASON,LOCATION,PRODUCT,UNITS,PRICE) ";


            mycommand.CommandText = mycommand.CommandText + "VALUES ( ";
            mycommand.CommandText = mycommand.CommandText + "'" + ID + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + FECHAHORA + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + REASON + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + location_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + producto_p.EAN + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + cantidad_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + producto_p.PRECIO + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
            }



            mycommand.CommandText = "INSERT INTO STOCKCURRENT(LOCATION,PRODUCT,ATTRIBUTESETINSTANCE_ID,UNITS) ";
            mycommand.CommandText = mycommand.CommandText + "VALUES ( ";
            mycommand.CommandText = mycommand.CommandText + "'" + location_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + producto_p.EAN + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + ATTRIBUTESETINSTANCE_ID + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + cantidad_p + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch
            {
                mycommand.CommandText = "UPDATE STOCKCURRENT ";
                mycommand.CommandText = mycommand.CommandText + " SET UNITS = UNITS + " + cantidad_p + " ";
                mycommand.CommandText = mycommand.CommandText + "WHERE ";
                mycommand.CommandText = mycommand.CommandText + "LOCATION = '" + location_p + "' AND ";
                mycommand.CommandText = mycommand.CommandText + "PRODUCT = '" + producto_p.EAN + "' AND ";
                mycommand.CommandText = mycommand.CommandText + "ATTRIBUTESETINSTANCE_ID = '" + ATTRIBUTESETINSTANCE_ID + "' ";

                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException2)
                {
                    MessageBox.Show("Message: " + myException2.Message + "\n");
                }


            }

            sqlConn.Close();
            return retval;


        }

        public double getStockCurrent(String ean_p, String location_p)
        {
            double unidades = 0;


            if (ean_p.Length == 0 || location_p.Length == 0)
            {
                return unidades;
            }

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
                MessageBox.Show("Message: " + myException.Message + "\n");
            }


            String ATTRIBUTESETINSTANCE_ID = "NO APLICA";
            SQLiteCommand mycommand;

            String sqlString;

            sqlString = "SELECT UNITS ";
            sqlString = sqlString + "FROM STOCKCURRENT ";
            sqlString = sqlString + "WHERE ";
            sqlString = sqlString + "LOCATION = '" + location_p + "' AND  ";
            sqlString = sqlString + "PRODUCT = '" + ean_p + "' AND  ";
            sqlString = sqlString + "ATTRIBUTESETINSTANCE_ID = '" + ATTRIBUTESETINSTANCE_ID + "'   ";


            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
                unidades = 0;
                sqlConn.Close();
                return unidades;
            }

            try
            {
                reader.Read();

                if (reader.HasRows)
                {
                    unidades = reader.GetDouble(0);
                }
                else
                {
                    unidades = 0;
                }


            }
            catch (SQLiteException myException)
            {
                MessageBox.Show("Message: " + myException.Message + "\n");
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }





    }
}
