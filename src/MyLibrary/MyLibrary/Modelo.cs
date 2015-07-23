using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SQLite;

namespace MyLibrary
{
    public class Modelo
    {
        static String tablePrefix_a = "RPYETI_";

        public static String getTablePrefix()
        {
            return tablePrefix_a;
        }

        public static void setTablePrefix(String tablePrefix_p)
        {
            tablePrefix_a = tablePrefix_p; ;
        }


        public static int InitDataBaseTransacciones(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
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
                resultado_p += "Error 0: " + myException.Message + "\n";
            }


            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" ( 
                  ID        VARCHAR(255) NOT NULL,
                  FECHA     DATE,
                  LOCATION  varchar(255) NOT NULL,
                  IDBODEGA  varchar(255) NOT NULL,
                  PLACE     varchar(255),
                  EAN       varchar(255) NOT NULL,
                  SKU       varchar(255),
                  UNITS     double NOT NULL,
                  PRIMARY KEY (ID)
                ) ; ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 1: " + myException.Message + "\n" ;
            }



            sqlString = "CREATE INDEX idx_scu1 ON " + tableName + "(LOCATION,EAN,FECHA)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error IN-2.2: " + myException.Message + "\n";
            }



            tableName = Modelo.getTablePrefix() + "STOCKDIARY";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255) NOT NULL,
                  TS            TIMESTAMP NOT NULL,
                  REASON        INT(11) NOT NULL,
                  LOCATION      VARCHAR(255) NOT NULL,
                  IDBODEGA      varchar(255) NOT NULL,
                  PLACE         VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  EAN           VARCHAR(255) NOT NULL,
                  SKU           VARCHAR(255),
                  UNITS         DOUBLE NOT NULL,
                  PRICE         DOUBLE,
                  PRIMARY KEY (ID)
                ) ;";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error IN-2.02: " + myException.Message + "\n";
            }

            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255),
                  LOCATION      VARCHAR(255),
                  PLACE         VARCHAR(255),
                  EAN           VARCHAR(255),
                  SKU           VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  TS            TIMESTAMP,
                  IDOPCION      SMALLINT(6) DEFAULT NULL,
                  NIMPRESIONES  SMALLINT(6) DEFAULT NULL,
                  PRICE         DOUBLE,
                  PRIMARY KEY (ID)
                ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 3: " + myException.Message + "\n";
            }

            sqlString = "CREATE INDEX idx_tra1 ON " + tableName + "(TS,IDOPCION,EAN)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 3.1: " + myException.Message + "\n";
            }

            sqlString = "CREATE INDEX idx_tra2 ON " + tableName + "(TS,IDOPCION,SKU)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 3.2: " + myException.Message + "\n";
            }


            tableName = Modelo.getTablePrefix() + "LOG";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255),
                  LOCATION      VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  TS            TIMESTAMP,
                  OPERACION     VARCHAR(50),
                  IDDISPOSITIVO VARCHAR(255),
                  RESULTADO     VARCHAR(50),
                  NOTA          VARCHAR(255),
                  PRIMARY KEY (ID)
                ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 4: " + myException.Message + "\n";
            }

            sqlString = "CREATE INDEX idx_log1 ON " + tableName + "(LOCATION,OPERACION,RESULTADO)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 5: "+ myException.Message +"\n";
            }

            tableName = Modelo.getTablePrefix() + "POSICION";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255),
                  TS            TIMESTAMP,
                  IDEVENTO      VARCHAR(10),
                  IDDISPOSITIVO VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  TSGPS         TIMESTAMP,
                  LATITUD       DOUBLE,
                  LONGITUD      DOUBLE,
                  VELOCIDAD     DOUBLE,
                  RUMBO         DOUBLE,
                  ALTURA        DOUBLE,
                  PRIMARY KEY (ID)
                ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 6: " + myException.Message + "\n";
            }


            sqlConn.Close();
            return retval;
        }


        public static int InitStockCurrent(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
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
                resultado_p += "Error 0: " + myException.Message + "\n";
            }


            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "UPDATE " + tableName;
            sqlString += @" SET UNITS = 0 WHERE 1 ; ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 1: " + myException.Message + "\n";
            }
            sqlConn.Close();
            return retval;
        }


        public static int InitDataBaseTransaccionesCalzado(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
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
                resultado_p += "Error 0: " + myException.Message + "\n";
            }


            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" ( 
                  ID        VARCHAR(255) NOT NULL,
                  FECHA     DATE,
                  LOCATION  varchar(255) NOT NULL,
                  IDBODEGA  varchar(255) NOT NULL,
                  PLACE     varchar(255),
                  IDCOLOR   varchar(255),
                  IDTALLA   varchar(255),
                  EAN       varchar(255) NOT NULL,
                  SKU       varchar(255),
                  UNITS     double NOT NULL,
                  PRIMARY KEY (ID)
                ) ; ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 1: " + myException.Message + "\n";
            }



            sqlString = "CREATE INDEX idx_scu1 ON " + tableName + "(LOCATION,IDBODEGA,EAN,FECHA)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error IN-2.02-A: " + myException.Message + "\n";
            }



            tableName = Modelo.getTablePrefix() + "STOCKDIARY";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255) NOT NULL,
                  TS            TIMESTAMP NOT NULL,
                  REASON        INT(11) NOT NULL,
                  LOCATION      VARCHAR(255) NOT NULL,
                  IDBODEGA      VARCHAR(255) NOT NULL,
                  PLACE         VARCHAR(255),
                  IDCOLOR       VARCHAR(255),
                  IDTALLA       VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  EAN           VARCHAR(255) NOT NULL,
                  SKU           VARCHAR(255),
                  UNITS         DOUBLE NOT NULL,
                  PRICE         DOUBLE,
                  PRIMARY KEY (ID)
                ) ;";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error IN-2.02-B: " + myException.Message + "\n";
            }

            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255),
                  LOCATION      VARCHAR(255),
                  PLACE         VARCHAR(255),
                  EAN           VARCHAR(255),
                  SKU           VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  TS            TIMESTAMP,
                  IDOPCION      SMALLINT(6) DEFAULT NULL,
                  NIMPRESIONES  SMALLINT(6) DEFAULT NULL,
                  PRICE         DOUBLE,
                  PRIMARY KEY (ID)
                ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 3: " + myException.Message + "\n";
            }

            sqlString = "CREATE INDEX idx_tra1 ON " + tableName + "(TS,IDOPCION,EAN)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 3.1: " + myException.Message + "\n";
            }

            sqlString = "CREATE INDEX idx_tra2 ON " + tableName + "(TS,IDOPCION,SKU)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 3.2: " + myException.Message + "\n";
            }


            tableName = Modelo.getTablePrefix() + "LOG";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255),
                  LOCATION      VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  TS            TIMESTAMP,
                  OPERACION     VARCHAR(50),
                  IDDISPOSITIVO VARCHAR(255),
                  RESULTADO     VARCHAR(50),
                  NOTA          VARCHAR(255),
                  PRIMARY KEY (ID)
                ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 4: " + myException.Message + "\n";
            }

            sqlString = "CREATE INDEX idx_log1 ON " + tableName + "(LOCATION,OPERACION,RESULTADO)";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 5: " + myException.Message + "\n";
            }

            tableName = Modelo.getTablePrefix() + "POSICION";
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID            VARCHAR(255),
                  TS            TIMESTAMP,
                  IDEVENTO      VARCHAR(10),
                  IDDISPOSITIVO VARCHAR(255),
                  IDUSUARIO     VARCHAR(255),
                  TSGPS         TIMESTAMP,
                  LATITUD       DOUBLE,
                  LONGITUD      DOUBLE,
                  VELOCIDAD     DOUBLE,
                  RUMBO         DOUBLE,
                  ALTURA        DOUBLE,
                  PRIMARY KEY (ID)
                ); ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p += "Error 6: " + myException.Message + "\n";
            }

            sqlConn.Close();
            return retval;
        }

        public static int InitDataBaseConfiguracion(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();

            string filetransacciones = Configuracion.getConfiguracionFile();
            sqlConn.ConnectionString = "Data Source=" + filetransacciones + ";Version=3;";


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
            sqlString = "CREATE TABLE IF NOT EXISTS " + tableName;
            sqlString += @" (
                  ID varchar(255) NOT NULL,
                  VALOR varchar(255) NOT NULL,
                  PRIMARY KEY (ID)
                ) ; ";

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }


            String valor;
            if (Configuracion.getRegistroConfiguracion("urlpost", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName ;
                sqlString += @"(ID,VALOR)  
                  VALUES ('urlpost','http://10.0.156.232/ripley/upload.aspx');
                  ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }

            }


            if (Configuracion.getRegistroConfiguracion("urlmaestrosprefix", out valor) == 1)
            {
                string url = "http://10.0.156.232/ripley/maestros/tpm_maestros";
                sqlString = "INSERT INTO " + tableName;
                
                sqlString += " (ID,VALOR)  " ;
                sqlString += " VALUES ('urlmaestrosprefix','" + url +"')" ;

                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }

            }

            if (Configuracion.getRegistroConfiguracion("iddispositivo", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName;
                sqlString += @"(ID,VALOR)  
                  VALUES ('iddispositivo','PDA001');
                  ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }

            }

            if (Configuracion.getRegistroConfiguracion("dbpath", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName;
                sqlString += "(ID,VALOR)  " ;
                sqlString += "VALUES('dbpath','')  " ;

                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }
            }

            if (Configuracion.getRegistroConfiguracion("flagloggps", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName;
                sqlString += @"(ID,VALOR)  
                  VALUES ('flagloggps','false');
                  ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }
            }

            if (Configuracion.getRegistroConfiguracion("timeoutloggps", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName;
                sqlString += @"(ID,VALOR)  
                  VALUES ('timeoutloggps','300');
                  ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }
            }

            if (Configuracion.getRegistroConfiguracion("keyactivacion", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName;
                sqlString += @"(ID,VALOR)  
                  VALUES ('keyactivacion','NA');
                  ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }

            }

            if (Configuracion.getRegistroConfiguracion("packetsize", out valor) == 1)
            {
                sqlString = "INSERT INTO " + tableName;
                sqlString += @"(ID,VALOR)  
                  VALUES ('packetsize','1024');
                  ";
                mycommand = new SQLiteCommand(sqlString, sqlConn);
                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException)
                {
                    resultado_p = myException.Message;
                    retval = retval - 1;
                }

            }


            sqlConn.Close();
            return retval;
        }

        public static int BorraDataBaseTransacciones(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
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
                resultado_p = myException.Message;
                return -1;
            }


            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "DROP TABLE IF EXISTS " + tableName ;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            tableName = Modelo.getTablePrefix() + "STOCKDIARY";
            sqlString = "DROP TABLE IF EXISTS " + tableName;
            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            sqlString = "DROP INDEX idx_tra1";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
            }

            sqlString = "DROP INDEX idx_tra2";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
            }

            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            sqlString = "DROP INDEX idx_log1";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
            }

            tableName = Modelo.getTablePrefix() + "LOG";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }


            tableName = Modelo.getTablePrefix() + "POSICION";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            sqlConn.Close();
            return retval;
        }

        public static int BorraTransacciones(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
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
                resultado_p = myException.Message;
                return -1;
            }


            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "DELETE FROM " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            tableName = Modelo.getTablePrefix() + "STOCKDIARY";
            sqlString = "DELETE FROM " + tableName;
            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            
            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";
            sqlString = "DELETE FROM  " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            tableName = Modelo.getTablePrefix() + "POSICION";
            sqlString = "DELETE FROM " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            sqlConn.Close();
            return retval;
        }

        public static int getNumeroRegistros(String tablename_p, out int contador_p, out String szRetval_p)
        {
            SQLiteConnection sqlConn;
            int retval = -1;
            szRetval_p = "getRegistro";
            contador_p = 0;
            if (tablename_p.Length == 0)
            {
                szRetval_p = "Tabla No valido";
                return retval;
            }
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


            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT count(*) as nregistros ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tablename_p + " ";


            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    contador_p = reader.GetInt32(0);
                    retval = 0;
                }
                else
                {
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

        public static int BorraDataBaseTransaccionesCalzado(out String resultado_p)
        {
            int retval = 0;
            resultado_p = "OK";
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
                resultado_p = myException.Message;
                return -1;
            }


            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            tableName = Modelo.getTablePrefix() + "STOCKDIARY";
            sqlString = "DROP TABLE IF EXISTS " + tableName;
            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            sqlString = "DROP INDEX idx_tra1";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
            }

            sqlString = "DROP INDEX idx_tra2";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
            }

            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }

            sqlString = "DROP INDEX idx_log1";
            mycommand = new SQLiteCommand(sqlString, sqlConn);
            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
            }

            tableName = Modelo.getTablePrefix() + "LOG";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }


            tableName = Modelo.getTablePrefix() + "POSICION";
            sqlString = "DROP TABLE IF EXISTS " + tableName;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                resultado_p = myException.Message;
                return -1;
            }



            sqlConn.Close();
            return retval;
        }


        public static int Log(String location_p, String idusuario_p, String operacion_p, String resultado_p, String nota_p, out String szRetval_p)
        {

            long TS;
            TS = MyGlobal.UnixTimeNow();

            szRetval_p = "OK";
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
                szRetval_p = myException.Message;
                return -1;
            }

            String ID = "TLOG" + location_p + "-" + idusuario_p + "-" + TS;
            ID = MyGlobal.getMD5Hash(ID);


            SQLiteCommand mycommand;
            mycommand = new SQLiteCommand(sqlConn);

            String iddispositivo = Configuracion.getIdDispositivo();

            String tableName = Modelo.getTablePrefix() + "LOG";
            mycommand.CommandText = "INSERT INTO " + tableName + "(ID,LOCATION,IDUSUARIO,TS,OPERACION,IDDISPOSITIVO,RESULTADO,NOTA) ";
            mycommand.CommandText = mycommand.CommandText + "VALUES ( ";
            mycommand.CommandText = mycommand.CommandText + "'" + ID + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + location_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + idusuario_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + TS + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + operacion_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + iddispositivo + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + resultado_p + "',";
            mycommand.CommandText = mycommand.CommandText + "'" + nota_p + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException2)
            {
                szRetval_p = myException2.Message;
                retval = retval + 1;
            }

            String IdEvento = "TLOG";
 
            sqlConn.Close();

            registraEvento(ID, TS, IdEvento, out szRetval_p);
            return retval;
        }

        public static int registraEvento(String id_p, long ts_p, String idevento_p, out String szRetval_p)
        {
            szRetval_p = "OK";
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
                szRetval_p = myException.Message;
                return -1;
            }
            SQLiteCommand mycommand;
            mycommand = new SQLiteCommand(sqlConn);

            
            String tableName = Modelo.getTablePrefix() + "POSICION";
            mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,IDEVENTO,IDDISPOSITIVO,IDUSUARIO,TSGPS,LATITUD,LONGITUD,VELOCIDAD,RUMBO,ALTURA) ";

            String iddispositivo = Configuracion.getIdDispositivo();
            String idusuario     = Configuracion.getIdUsuario();

            String latitud,longitud,velocidad,rumbo,altura;

            latitud  = MyGlobal.latitud_a.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            longitud = MyGlobal.longitud_a.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            velocidad = MyGlobal.velocidad_a.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            rumbo = MyGlobal.rumbo_a.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            altura = MyGlobal.altura_a.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));

            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + id_p + "',";
            mycommand.CommandText += "'" + ts_p + "',";
            mycommand.CommandText += "'" + idevento_p + "',";
            mycommand.CommandText += "'" + iddispositivo + "',";
            mycommand.CommandText += "'" + idusuario + "',";
            mycommand.CommandText += "'" + MyGlobal.tsgps_a + "',";
            mycommand.CommandText += "'" + latitud + "',";
            mycommand.CommandText += "'" + longitud + "',";
            mycommand.CommandText += "'" + velocidad + "',";
            mycommand.CommandText += "'" + rumbo + "',";
            mycommand.CommandText += "'" + altura + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 4:" + myException.Message;
                retval = retval + 1;
            }

            sqlConn.Close();

            return retval;
        }

        public static int initCarroCompras(out String szRetval_p)
        {
            szRetval_p = "initCarroCompras";
            SQLiteConnection sqlConn;
            int retval = -1;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 001:" + myException.Message;
                return -1;
            }

            String tableName ;

            mycommand = new SQLiteCommand(sqlConn);

            tableName = Modelo.getTablePrefix() + "CARROCOMPRAS";

            mycommand.CommandText = "DROP TABLE IF EXISTS " + tableName;

            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 002: " + myException.Message;
            }

            mycommand.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName;
            mycommand.CommandText += @" (
                  IDUSUARIO     VARCHAR(255),
                  SKU           VARCHAR(255),
                  IDBODEGA      VARCHAR(255),
                  IDUBICACION   VARCHAR(255),
                  IDCOLOR       VARCHAR(255),
                  IDTALLA       VARCHAR(255),
                  COLOR         VARCHAR(255),
                  TALLA         VARCHAR(255),
                  EAN           VARCHAR(255),
                  CANTIDAD      SMALLINT(6),
                  PRIMARY KEY (IDUSUARIO,SKU,IDBODEGA,IDUBICACION,IDCOLOR,IDTALLA)
                ); ";


            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 003: " + myException.Message;
            }


            sqlConn.Close();

            return retval;
        }


        public static int agregaCarroCompras(String idusuario_p,String sku_p,String idbodega_p,String idubicacion_p,out String szRetval_p)
        {
            szRetval_p = "agregaCarroCompras";
            SQLiteConnection sqlConn;
            int retval = -1;
            if (sku_p.Length == 0)
            {
                return retval;
            }
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 001:" + myException.Message;
                return -1;
            }

            String tableName;
            int cantidad = 1;
            string ean = sku_p;
            Producto myprod = new Producto();
            myprod.getRegistroBySkuCalzado(sku_p, out szRetval_p);
            ean = myprod.EAN;

            mycommand = new SQLiteCommand(sqlConn);
            tableName = Modelo.getTablePrefix() + "CARROCOMPRAS";

            mycommand.CommandText = "INSERT INTO " + tableName;
            mycommand.CommandText += "(IDUSUARIO,SKU,IDBODEGA,IDUBICACION,IDCOLOR,IDTALLA,EAN,CANTIDAD) ";
            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + idusuario_p + "',";
            mycommand.CommandText += "'" + sku_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + idubicacion_p + "',";
            mycommand.CommandText += "'" + myprod.idcolor + "',";
            mycommand.CommandText += "'" + myprod.idtalla + "',";
            mycommand.CommandText += "'" + ean + "',";
            mycommand.CommandText += "'" + cantidad + "');";



            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch 
            {
                mycommand.CommandText = "UPDATE " + tableName + "  ";
                mycommand.CommandText += " SET CANTIDAD = CANTIDAD + 1 ";
                mycommand.CommandText += " WHERE ";
                mycommand.CommandText += " IDUSUARIO = '" + idusuario_p + "'  ";
                mycommand.CommandText += " AND IDBODEGA  = '" + idbodega_p + "'  ";
                mycommand.CommandText += " AND IDUBICACION = '" + idubicacion_p + "'  ";
                mycommand.CommandText += " AND IDCOLOR = '" + myprod.idcolor + "'  ";
                mycommand.CommandText += " AND IDTALLA = '" + myprod.idtalla + "'  ";

                mycommand.CommandText += " AND SKU       = '" + sku_p + "' ; ";

                try
                {
                    mycommand.ExecuteNonQuery();
                    retval = 0;
                }
                catch (SQLiteException myException2)
                {
                    szRetval_p += "Error 002:" + myException2.Message;
                    retval = retval - 1;
                }
            }
            sqlConn.Close();

            return retval;
        }

        public static int agregaCarroComprasCalzado(String idusuario_p, String sku_p, String idbodega_p, String idubicacion_p, String idcolor_p, String idtalla_p, String color_p, String talla_p, out String szRetval_p)
        {
            szRetval_p = "agregaCarroCompras";
            SQLiteConnection sqlConn;
            int retval = -1;
            if (sku_p.Length == 0)
            {
                return retval;
            }
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 001:" + myException.Message;
                return -1;
            }

            String tableName;
            int cantidad = 1;
       
            string ean = sku_p;
            Producto myprod = new Producto();
            myprod.getRegistroBySkuCalzado(sku_p, out szRetval_p);
            ean = myprod.EAN;
    
            mycommand = new SQLiteCommand(sqlConn);
            tableName = Modelo.getTablePrefix() + "CARROCOMPRAS";

            mycommand.CommandText = "INSERT INTO " + tableName;
            mycommand.CommandText += "(IDUSUARIO,SKU,IDBODEGA,IDUBICACION,IDCOLOR,IDTALLA,COLOR,TALLA,EAN,CANTIDAD) ";
            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + idusuario_p + "',";
            mycommand.CommandText += "'" + sku_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + idubicacion_p + "',";
            mycommand.CommandText += "'" + idcolor_p + "',";
            mycommand.CommandText += "'" + idtalla_p + "',";
            mycommand.CommandText += "'" + color_p + "',";
            mycommand.CommandText += "'" + talla_p + "',";
            mycommand.CommandText += "'" + ean + "',";
            mycommand.CommandText += "'" + cantidad + "');";



            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch
            {
                mycommand.CommandText = "UPDATE " + tableName + "  ";
                mycommand.CommandText += " SET CANTIDAD = CANTIDAD + 1 ";
                mycommand.CommandText += " WHERE ";
                mycommand.CommandText += " IDUSUARIO = '" + idusuario_p + "'  ";
                mycommand.CommandText += " AND IDBODEGA  = '" + idbodega_p + "'  ";
                mycommand.CommandText += " AND IDUBICACION = '" + idubicacion_p + "'  ";
                mycommand.CommandText += " AND IDCOLOR = '" + idcolor_p + "'  ";
                mycommand.CommandText += " AND IDTALLA = '" + idtalla_p + "'  ";
                mycommand.CommandText += " AND SKU       = '" + sku_p + "' ; ";

                try
                {
                    mycommand.ExecuteNonQuery();
                    retval = 0;
                }
                catch (SQLiteException myException2)
                {
                    szRetval_p += "Error 002:" + myException2.Message;
                    retval = retval - 1;
                }
            }
            sqlConn.Close();

            return retval;
        }


        public static int vaciaCarroCompras(out String szRetval_p)
        {
            szRetval_p = "vacioCarroCompras";
            SQLiteConnection sqlConn;
            int retval = -1;

            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 001:" + myException.Message;
                return -1;
            }

            String tableName;
            mycommand = new SQLiteCommand(sqlConn);
            tableName = Modelo.getTablePrefix() + "CARROCOMPRAS";

            mycommand.CommandText = "DELETE FROM " + tableName + " ;" ;


            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 002:" + myException.Message;
                retval = retval - 1;
            }
            sqlConn.Close();

            return retval;
        }

        public static int eliminaFromCarroCompras(String idusuario_p,String sku_p,String idbodega_p,String idubicacion_p,out String szRetval_p)
        {
            szRetval_p = "eliminaFromCarroCompras";
            SQLiteConnection sqlConn;
            int retval = -1;
            if (sku_p.Length == 0)
            {
                return retval;
            }
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 001:" + myException.Message;
                return -1;
            }

            String tableName;
            mycommand = new SQLiteCommand(sqlConn);
            tableName = Modelo.getTablePrefix() + "CARROCOMPRAS";

            mycommand.CommandText = "DELETE FROM " + tableName  ;
            mycommand.CommandText += " WHERE ";
            mycommand.CommandText += " IDUSUARIO       = '" + idusuario_p + "'  ";
            mycommand.CommandText += " AND IDBODEGA    = '" + idbodega_p + "'  ";
            mycommand.CommandText += " AND IDUBICACION = '" + idubicacion_p + "'  ";
            mycommand.CommandText += " AND SKU         = '" + sku_p + "' ; ";

            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 002:" + myException.Message;
                retval = retval - 1;
            }
            sqlConn.Close();

            return retval;
        }

        public static int eliminaFromCarroComprasCalzado(String idusuario_p, String sku_p, String idbodega_p, String idubicacion_p, String idcolor_p, String idtalla_p, out String szRetval_p)
        {
            szRetval_p = " eliminaFromCarroComprasCalzado";
            SQLiteConnection sqlConn;
            int retval = -1;
            if (sku_p.Length == 0)
            {
                return retval;
            }
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string file = Configuracion.getCarroComprasFile();
            sqlConn.ConnectionString = "Data Source=" + file + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 001:" + myException.Message;
                return -1;
            }

            String tableName;
            mycommand = new SQLiteCommand(sqlConn);
            tableName = Modelo.getTablePrefix() + "CARROCOMPRAS";

            mycommand.CommandText = "DELETE FROM " + tableName;
            mycommand.CommandText += " WHERE ";
            mycommand.CommandText += " IDUSUARIO       = '" + idusuario_p + "'  ";
            mycommand.CommandText += " AND IDBODEGA    = '" + idbodega_p + "'  ";
            mycommand.CommandText += " AND IDUBICACION = '" + idubicacion_p + "'  ";
            mycommand.CommandText += " AND IDCOLOR     = '" + idcolor_p + "'  ";
            mycommand.CommandText += " AND IDTALLA     = '" + idtalla_p + "'  ";
            mycommand.CommandText += " AND SKU         = '" + sku_p + "' ; ";

            try
            {
                mycommand.ExecuteNonQuery();
                retval = 0;
            }
            catch (SQLiteException myException)
            {
                szRetval_p += "Error 002:" + myException.Message;
                retval = retval - 1;
            }
            sqlConn.Close();

            return retval;
        }



        public static int getRegistroUltimaOperacion(String idlocation_p, String tipooperacion_p, String resultado_p, out tOperacion operacion_p, out String szRetval_p)
        {
            int retval = -1;
            szRetval_p = "getUltimaSincronizacion";
            SQLiteConnection sqlConn;
            SQLiteCommand mycommand;

            sqlConn = new SQLiteConnection();
            string filemaestros = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filemaestros + ";Version=3;";
            DateTime FECHAHORA;
            FECHAHORA = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            tOperacion operacion = new tOperacion();
            operacion.idUsuario_a = "";

            operacion_p = operacion;



            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
                return retval;
            }

            String tableName = Modelo.getTablePrefix() + "LOG";
            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT IDUSUARIO,TS,NOTA,LOCATION ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableName + " ";
            mycommand.CommandText = mycommand.CommandText + "WHERE ";
//            mycommand.CommandText = mycommand.CommandText + "LOCATION  = '" + idlocation_p + "' AND ";
            mycommand.CommandText = mycommand.CommandText + "OPERACION = '" + tipooperacion_p + "' AND ";
            mycommand.CommandText = mycommand.CommandText + "RESULTADO = '" + resultado_p + "' ";
            mycommand.CommandText = mycommand.CommandText + "ORDER BY TS DESC LIMIT 1";

            SQLiteDataReader reader;
            String location=null;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    try
                    {
                        operacion.idUsuario_a = reader.GetString(0);
                        szRetval_p = "OK";
                    }
                    catch (Exception e)
                    {
                        szRetval_p = "Error CU-01: " + e.Message;
                    };

                    try
                    {
                        operacion.ts_a = reader.GetInt64(1);
                        szRetval_p = "OK";
                    }
                    catch (Exception e)
                    {
                        szRetval_p = "Error CU-02: " + e.Message;
                    };

                    try
                    {
                        operacion.nota_a = reader.GetString(2);
                        szRetval_p = "OK";
                    }
                    catch (Exception e)
                    {
                        szRetval_p = "Error CU-03: " + e.Message;
                    };

                    try
                    {
                        location = reader.GetString(3);
                        szRetval_p = "OK";
                    }
                    catch (Exception e)
                    {
                        szRetval_p = "Error CU-04: " + e.Message;
                    };
                    szRetval_p = mycommand.CommandText + "Fecha Hora = " + operacion.ts_a;
                }
                else
                {
                    szRetval_p = "NOT FOUND";
                    retval = -2;

                }
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error CU-05: " + myException.Message;
            }
            sqlConn.Close();
            operacion_p = operacion;
            if (location == idlocation_p)
            {
                retval = 0;
            }
            return retval;
        }




    }
}
