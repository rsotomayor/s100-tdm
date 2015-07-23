using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SQLite;



namespace MyLibrary
{
    public class Local
    {
        String id_a;
        String descripcion_a;
        public int getRegistro(String id_p)
        {
            SQLiteConnection sqlConn;
            int retval = -1;
            if (id_p.Length == 0)
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
                String szRetval = myException.Message;
                return -1;
            }

            String tableProducts = Modelo.getTablePrefix() + "products";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT id, descripcion ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableProducts + "  ";
            mycommand.CommandText = mycommand.CommandText + "WHERE ";
            mycommand.CommandText = mycommand.CommandText + "id = '" + id_p + "' ; ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    id_a = id_p; //  reader.GetString(0);
                    descripcion_a = reader.GetString(1);

                    retval = 0;
                }
                else
                {
                    descripcion_a = "";
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

        public String getArray()
        {

            return "AA";  
        }

    }

}
