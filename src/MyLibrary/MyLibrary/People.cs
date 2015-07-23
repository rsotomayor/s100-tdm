using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;


namespace MyLibrary
{
    public class People
    {
        public String id_a;
        public String name_a;
        public String idlocation_a;
        public String location_a;
        public String role_a;

        public int getRegistro(String id_p, out String szRetval_p)
        {
            SQLiteConnection sqlConn;
            int retval = -1;
            szRetval_p = "getRegistro";
            if (id_p.Length == 0)
            {
                szRetval_p = "Usuario No valido";
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tablePeople = Modelo.getTablePrefix() + "people";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT id, name ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tablePeople + " ";
            mycommand.CommandText = mycommand.CommandText + "WHERE ";
            mycommand.CommandText = mycommand.CommandText + "id = '" + id_p + "' ; ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    id_a   = id_p; //  reader.GetString(0);
                    name_a = reader.GetString(1);

                    retval = 0;
                }
                else
                {
                    name_a = "";
                    retval = 1;
                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;

                retval = -1;
            }
            sqlConn.Close();
            return retval;
        }

        public int getAuthUsuario(String name_p, String apppasswordsha1_p, String apppasswordmd5_p,out String szRetval_p)
        {
            SQLiteConnection sqlConn;
            int retval = -1;
            szRetval_p = "getAuthUsuario";

            if (name_p.Length == 0)
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tablePeople  = Modelo.getTablePrefix() + "people";
            String tableLocales = Modelo.getTablePrefix() + "locales";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT PEO.id, PEO.name,PEO.location as idlocation,LOC.descripcion as location,PEO.role as role ";
            mycommand.CommandText += "FROM " + tablePeople +" PEO ";
            mycommand.CommandText += "LEFT JOIN " + tableLocales + " LOC ON (PEO.location = LOC.id ) ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "lower(PEO.name) = '" + name_p + "' ";
            mycommand.CommandText += "AND ( PEO.apppassword = '" + apppasswordsha1_p + "' OR  PEO.apppassword = '" + apppasswordmd5_p + "' ) ; ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    try
                    {
                        id_a = reader.GetString(0);
                    }
                    catch (Exception e)
                    {
                        szRetval_p = e.Message;
                    };
  
                    name_a        = name_p; //  reader.GetString(1);
                    try
                    {
                        idlocation_a = reader.GetString(2);
                    }
                    catch (Exception e)
                    {
                        szRetval_p = e.Message;
                    };

                    try
                    {
                        location_a = reader.GetString(3);
                    }
                    catch (Exception e)
                    {
                        szRetval_p = e.Message;
                    };

                    try
                    {
                        role_a = reader.GetString(4);
                    }
                    catch (Exception e)
                    {
                        szRetval_p = e.Message;
                    };

                    retval = 0;
                }
                else
                {
                    name_a = "";
                    retval = 1;
                    szRetval_p = "NOT FOUND";

                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                retval = -1;
            }
            sqlConn.Close();
            return retval;
        }

    }



}
