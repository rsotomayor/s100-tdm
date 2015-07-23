using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Globalization;
using System.Data.SQLite;

namespace MyLibrary
{
    public class Producto
    {
        public String EAN;
        public String SKU;
        public String PROD;
        public String DPTO;
        public String LINEA;
        public double PRECIO;
        public int SemanaAntiguedad;
        public int flagEtiquetar;
        public int flagRevenue;
        public int flagRecogida;
        public double cantidadRecoger;
        public String tipoRecogida;
        public double stock;
        public String idcolor;
        public String idtalla;
        public String idlinea;
        public String iddepartamento;
        public String color;
        public String talla;
        public bool flagContar;

        int contador_a = 0;

        public static Int64 getNumeroProductos(out String szRetval_p)
        {
            szRetval_p = "getRegistroByEan";
            SQLiteConnection sqlConn;
            Int64 NRECORD=0;
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

            String tableProducts = Modelo.getTablePrefix() + "products";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT COUNT(*) AS NRECORD ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableProducts + " ";

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

        public static Int64 getNumeroProductosEan(out String szRetval_p)
        {
            szRetval_p = "getRegistroByEan";
            SQLiteConnection sqlConn;
            Int64 NRECORD = 0;
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

            String tableProductEan = Modelo.getTablePrefix() + "productean";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT COUNT(*) AS NRECORD ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableProductEan  + " ";

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

        public static Int64 getNumeroProductosByWhere(String mywhere_p, out String szRetval_p)
        {
            szRetval_p = "getRegistroByEan";
            SQLiteConnection sqlConn;
            Int64 NRECORD = 0;
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

            String tableProducts = Modelo.getTablePrefix() + "products";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT COUNT(*) AS NRECORD ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableProducts  + " ";
            mycommand.CommandText = mycommand.CommandText + mywhere_p;


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

        public int getRegistroByEan(String ean_p,out String szRetval_p)
        {
            szRetval_p = "getRegistroByEan";
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
                szRetval_p = myException.Message;
                return -1;
            }
           
       String tableProducts      = Modelo.getTablePrefix() + "products";
       String tableProductEan    = Modelo.getTablePrefix() + "productean";
       String tableDepartamentos = Modelo.getTablePrefix() + "departamento";
       String tableLineas        = Modelo.getTablePrefix() + "linea";

       mycommand = new SQLiteCommand(sqlConn);
       mycommand.CommandText = "SELECT pro.sku,pro.nombre,pro.precio,pro.semanaantiguedad,pro.flagetiqueta,pro.flagrevenue,pro.flagrecogida,pro.stock,pro.cantidadrecoger,pro.tiporecogida,dep.descripcion as departamento,lin.descripcion as linea,dep.iddepartamento,lin.idlinea ";
       mycommand.CommandText += "FROM " + tableProducts  + " pro ";
       mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
       mycommand.CommandText += "LEFT JOIN " + tableDepartamentos + " dep ON ( pro.iddepartamento = dep.id) ";
       mycommand.CommandText += "LEFT JOIN " + tableLineas + " lin ON ( pro.idlinea = lin.id) ";
       mycommand.CommandText += "WHERE ";
       mycommand.CommandText += "pea.ean = '" + ean_p + "' ; ";
      
        SQLiteDataReader reader;

        EAN = ean_p;
        SKU = null;
        PROD = "";
        iddepartamento = "";
        DPTO = "";
        idlinea = "";
        LINEA = "" ; 
        PRECIO = 0;
        SemanaAntiguedad = 0;
        flagEtiquetar = 0;
        flagRevenue = 0;
        flagRecogida = 0;

        stock = 0;

       try
       {
           reader = mycommand.ExecuteReader();
           reader.Read();
                     
           if (reader.HasRows)
           {
               szRetval_p = "OK ";
               EAN = ean_p;
               SKU = reader.GetString(0);
               PROD = reader.GetString(1);
               PRECIO = reader.GetDouble(2);


               try
               {
                   SemanaAntiguedad = reader.GetInt16(3);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               } ;

               try
               {
                   flagEtiquetar = reader.GetInt16(4);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               } ;

               try
               {
                   flagRevenue = reader.GetInt16(5);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               } ;

               try
               {
                   flagRecogida = reader.GetInt16(6);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               } ;

               try
               {
                   stock = reader.GetDouble(7);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
               try
               {
                   cantidadRecoger = reader.GetDouble(8);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
               try
               {
                   tipoRecogida = reader.GetString(9);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
               
               try
               {
                   DPTO = reader.GetString(10);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
               
               try
               {
                   LINEA = reader.GetString(11);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
               try
               {
                   iddepartamento = reader.GetString(12);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
               try
               {
                   idlinea = reader.GetString(13);
               }
               catch (Exception e)
               {
                   String mystr = e.Message;
               };
 
               retval = 0;
           }           

           else
           {
                szRetval_p = "NOT FOUND";
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

        public int getRegistroByEanCalzado(String ean_p, out String szRetval_p)
        {
            szRetval_p = "getRegistroByEanCalzado";
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tableProducts = Modelo.getTablePrefix() + "products";
            String tableProductEan = Modelo.getTablePrefix() + "productean";
            String tableDepartamentos = Modelo.getTablePrefix() + "departamento";
            String tableLineas = Modelo.getTablePrefix() + "linea";
            String tableColor = Modelo.getTablePrefix() + "color";
            String tableTalla = Modelo.getTablePrefix() + "talla";

            /*
            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,dep.descripcion as departamento,lin.descripcion as linea, col.descripcion as color, tal.descripcion as talla, pro.iddepartamento,pro.idlinea ,col.id as idcolor,tal.id as idtalla  ";
            mycommand.CommandText += "FROM " + tableProducts + " pro ";
            mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "LEFT JOIN " + tableDepartamentos + " dep ON ( pro.iddepartamento = dep.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableLineas + " lin ON ( pro.idlinea = lin.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableColor + " col ON ( pro.idcolor = col.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableTalla + " tal ON ( pro.idtalla = tal.id) ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "pea.ean = '" + ean_p + "' ; ";
            */

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,dep.descripcion as departamento,lin.descripcion as linea, pro.iddepartamento,pro.idlinea ,pro.idcolor,pro.idtalla,pro.color,pro.talla  ";
            mycommand.CommandText += "FROM " + tableProducts + " pro ";
            mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "LEFT JOIN " + tableDepartamentos + " dep ON ( pro.iddepartamento = dep.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableLineas + " lin ON ( pro.idlinea = lin.id) ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "pea.ean = '" + ean_p + "' ; ";

            SQLiteDataReader reader;

            EAN = ean_p;
            SKU = null;
            PROD = "";
            DPTO = "";
            LINEA = "";
            idcolor = "";
            idtalla = "";
            color = "";
            talla = "";
            idlinea = "";
            iddepartamento = "";

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    szRetval_p = "OK ";
                    EAN = ean_p;
                    SKU = reader.GetString(0);
                    PROD = reader.GetString(1);
                    try
                    {
                        DPTO = reader.GetString(2);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        LINEA = reader.GetString(3);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        iddepartamento = reader.GetString(4);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        idlinea = reader.GetString(5);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
   
                    try
                    {
                        idcolor = reader.GetString(6);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        idtalla = reader.GetString(7);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        color = reader.GetString(8);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        talla = reader.GetString(9);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    retval = 0;
                }
                else
                {
                    szRetval_p = "NO ENCONTRADO";
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

        public int getRegistroBySkuCalzado(String sku_p, out String szRetval_p)
        {
            szRetval_p = "getRegistroByEanCalzado";
            SQLiteConnection sqlConn;
            int retval = -1;
            if (sku_p.Length == 0)
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

            String tableProducts = Modelo.getTablePrefix() + "products";
            String tableProductEan = Modelo.getTablePrefix() + "productean";
            String tableDepartamentos = Modelo.getTablePrefix() + "departamento";
            String tableLineas = Modelo.getTablePrefix() + "linea";
            String tableColor = Modelo.getTablePrefix() + "color";
            String tableTalla = Modelo.getTablePrefix() + "talla";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,dep.descripcion as departamento,lin.descripcion as linea, pro.color, pro.talla, pro.iddepartamento,pro.idlinea,pea.ean ,col.id as idcolor,tal.id as idtalla    ";
            mycommand.CommandText += "FROM " + tableProducts + " pro ";
            mycommand.CommandText += "JOIN " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "LEFT JOIN " + tableDepartamentos + " dep ON ( pro.iddepartamento = dep.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableLineas + " lin ON ( pro.idlinea = lin.id) ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "pro.sku = '" + sku_p + "' ; ";

            SQLiteDataReader reader;

            EAN = null;
            SKU = sku_p;
            PROD = "";
            DPTO = "";
            LINEA = "";
            idcolor = "";
            idtalla = "";
            color = "";
            talla = "";
            idlinea = "";
            iddepartamento = "";


            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    szRetval_p = "OK ";
                    SKU = reader.GetString(0);
                    PROD = reader.GetString(1);
                    try
                    {
                        DPTO = reader.GetString(2);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        LINEA = reader.GetString(3);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        color = reader.GetString(4);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        talla = reader.GetString(5);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    iddepartamento = reader.GetString(6);
                    idlinea = reader.GetString(7);
                    EAN = reader.GetString(8);
                    try
                    {
                        idcolor = reader.GetString(9);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        idtalla = reader.GetString(10);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    retval = 0;
                }
                else
                {
                    szRetval_p = "NOT FOUND";
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


        public int getRegistroCajasByEan(String ean_p, out String szRetval_p)
        {
            szRetval_p = "getRegistroCajasByEan";
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tableCajas = Modelo.getTablePrefix() + "cajas";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.ean,pro.sku,pro.nombre ";
            mycommand.CommandText += "FROM " + tableCajas + " pro ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "pro.ean = '" + ean_p + "' ; ";


            SQLiteDataReader reader;

            EAN = ean_p;
            SKU = null;
            PROD = "";
            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    szRetval_p = "OK ";
                    EAN = ean_p;
                    SKU = reader.GetString(1);
                    PROD = reader.GetString(2);
                    retval = 0;
                }
                else
                {
                    szRetval_p = "NOT FOUND";
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

        public int getRegistroByEanLargo(String ean_p, int length_p,out String szRetval_p)
        {
            szRetval_p = "getRegistroByEan";
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
                szRetval_p = myException.Message;
                return -1;
            }

            String tableProducts = Modelo.getTablePrefix() + "products";
            String tableProductEan = Modelo.getTablePrefix() + "productean";
            String tableDepartamentos = Modelo.getTablePrefix() + "departamento";
            String tableLineas = Modelo.getTablePrefix() + "linea";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT pro.sku,pro.nombre,pro.precio,pro.semanaantiguedad,pro.flagetiqueta,pro.flagrevenue,pro.flagrecogida,pro.stock,pro.cantidadrecoger,pro.tiporecogida,dep.descripcion as departamento,lin.descripcion as linea ";
            mycommand.CommandText += "FROM  " + tableProducts + " pro ";
            mycommand.CommandText += "JOIN  " + tableProductEan + " pea ON ( pro.sku = pea.sku) ";
            mycommand.CommandText += "LEFT JOIN " + tableDepartamentos + " dep ON ( pro.iddepartamento = dep.id) ";
            mycommand.CommandText += "LEFT JOIN " + tableLineas + " lin ON ( pro.idlinea = lin.id) ";
            mycommand.CommandText += "WHERE ";
            mycommand.CommandText += "pea.length = '" + length_p + "' ";
            mycommand.CommandText += "AND pea.ean = '" + ean_p + "' ; ";

            SQLiteDataReader reader;

            EAN = ean_p;
            SKU = null;
            PROD = "";
            DPTO = "";
            LINEA = ""; 
            PRECIO = 0;
            SemanaAntiguedad = 0;
            flagEtiquetar = 0;
            flagRevenue = 0;
            flagRecogida = 0;
            stock = 0;


            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    szRetval_p = "OK ";
                    EAN = ean_p;
                    SKU = reader.GetString(0);
                    PROD = reader.GetString(1);
                    PRECIO = reader.GetDouble(2);
                    try
                    {
                        SemanaAntiguedad = reader.GetInt16(3);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        flagEtiquetar = reader.GetInt16(4);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        flagRevenue = reader.GetInt16(5);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        flagRecogida = reader.GetInt16(6);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        stock = reader.GetDouble(7);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        cantidadRecoger = reader.GetDouble(8);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };
                    try
                    {
                        tipoRecogida = reader.GetString(9);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        DPTO = reader.GetString(10);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    try
                    {
                        LINEA = reader.GetString(11);
                    }
                    catch (Exception e)
                    {
                        String mystr = e.Message;
                    };

                    retval = 0;
                }
                else
                {
                    szRetval_p = "NOT FOUND";
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

        public int ingresar(Producto producto_p, string idmovimiento_p, int cantidad_p, String location_p, String idbodega_p, String place_p, out String szRetval_p)
        {
            int retval = 0;
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();
            szRetval_p = "OK";

            string filetransacciones = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filetransacciones + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 1:" + myException.ToString();
                return -1;
            }


            SQLiteCommand mycommand;
            String idusuario = Configuracion.getIdUsuario();

            long TS;
            int REASON;
            REASON = int.Parse(idmovimiento_p);


            TS = MyGlobal.UnixTimeNow();
            contador_a++;
            String ID = "TSTOCK" + TS + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p + "-" + contador_a + "-" + idusuario;
            ID = MyGlobal.getMD5Hash(ID);
            mycommand = new SQLiteCommand(sqlConn);

            String cantidad, precio;
            cantidad = cantidad_p.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            precio = producto_p.PRECIO.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));

            String tableName = Modelo.getTablePrefix() + "STOCKDIARY";

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,IDUSUARIO,EAN,UNITS,PRICE) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,PLACE,IDUSUARIO,EAN,UNITS,PRICE) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,PLACE,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }

            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + ID + "',";
            mycommand.CommandText += "'" + TS + "',";
            mycommand.CommandText += "'" + REASON + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + producto_p.idcolor + "',";
            mycommand.CommandText += "'" + producto_p.idtalla + "',";

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }
            mycommand.CommandText += "'" + idusuario + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";
            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            mycommand.CommandText += "'" + cantidad + "',";
            mycommand.CommandText += "'" + precio + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 002-A:" + myException.Message;
                retval = retval + 1;
                return retval;
            }

            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String IDST;
            IDST = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p;
            IDST = MyGlobal.getMD5Hash(IDST);

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,UNITS) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,SKU,UNITS) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,PLACE,UNITS) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,SKU,PLACE,UNITS) ";
            }


            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + IDST + "',";
            mycommand.CommandText += "'" + FECHA + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";
            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }

            mycommand.CommandText += "'" + cantidad + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch
            {
                mycommand.CommandText = "UPDATE " + tableName + " ";
                mycommand.CommandText += " SET UNITS = UNITS + " + cantidad + " ";
                mycommand.CommandText += "WHERE ";
                mycommand.CommandText += "ID   = '" + IDST + "' ";

                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException2)
                {
                    szRetval_p = "Error 3: " + myException2.Message;
                    retval = retval + 1;
                }
            }

            sqlConn.Close();

            String IdEvento = "TINGRESO";
            String szRetval2;
            Modelo.registraEvento(ID, TS, IdEvento, out szRetval2);
            if (szRetval_p == "OK")
            {
                szRetval_p = szRetval2;
                retval = 0;
            }
            else
            {
                szRetval_p += szRetval2;
            }
            return retval;
        }

        public int ingresarCalzado(Producto producto_p, string idmovimiento_p, int cantidad_p, String location_p, String idbodega_p, String place_p, String idcolor_p, String idtalla_p, out String szRetval_p)
        {
            int retval = 0;
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();
            szRetval_p = "OK";

            string filetransacciones = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filetransacciones + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 1:" + myException.ToString();
                return -1;
            }


            SQLiteCommand mycommand;
            String idusuario = Configuracion.getIdUsuario();

            long TS;
            int REASON;
            REASON = int.Parse(idmovimiento_p);


            TS = MyGlobal.UnixTimeNow();
            contador_a++;
            String ID = "TSTOCK" + TS + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p + "-" + contador_a + "-" + idusuario;
            ID = MyGlobal.getMD5Hash(ID);
            mycommand = new SQLiteCommand(sqlConn);

            String cantidad, precio;
            cantidad = cantidad_p.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            precio = producto_p.PRECIO.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));

            String tableName = Modelo.getTablePrefix() + "STOCKDIARY";

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,IDUSUARIO,EAN,UNITS,PRICE) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,PLACE,IDUSUARIO,EAN,UNITS,PRICE) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,PLACE,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }

            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + ID + "',";
            mycommand.CommandText += "'" + TS + "',";
            mycommand.CommandText += "'" + REASON + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + idcolor_p + "',";
            mycommand.CommandText += "'" + idtalla_p + "',";

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }
            mycommand.CommandText += "'" + idusuario + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";
            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            mycommand.CommandText += "'" + cantidad + "',";
            mycommand.CommandText += "'" + precio + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 002-A:" + myException.Message;
                retval = retval + 1;
                return retval;
            }

            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String IDST;
            IDST = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p + "-" + idcolor_p + "-" + idtalla_p;
            IDST = MyGlobal.getMD5Hash(IDST);

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,UNITS) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,SKU,UNITS) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,PLACE,UNITS) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,SKU,PLACE,UNITS) ";
            }


            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + IDST + "',";
            mycommand.CommandText += "'" + FECHA + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + idcolor_p + "',";
            mycommand.CommandText += "'" + idtalla_p + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";
            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }

            mycommand.CommandText += "'" + cantidad + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch
            {
                mycommand.CommandText = "UPDATE " + tableName + " ";
                mycommand.CommandText += " SET UNITS = UNITS + " + cantidad + " ";
                mycommand.CommandText += "WHERE ";
                mycommand.CommandText += "ID   = '" + IDST + "' ";

                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException2)
                {
                    szRetval_p = "Error 3: " + myException2.Message;
                    retval = retval + 1;
                }
            }

            sqlConn.Close();

            String IdEvento = "TINGRESO";
            String szRetval2;
            Modelo.registraEvento(ID, TS, IdEvento, out szRetval2);
            if (szRetval_p == "OK")
            {
                szRetval_p = szRetval2;
                retval = 0;
            }
            else
            {
                szRetval_p += szRetval2;
            }
            return retval;
        }



        public int contar(Producto producto_p, int cantidad_p, String location_p,String idbodega_p,String place_p,out String szRetval_p)
        {
            int retval = 0;
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();
            szRetval_p = "OK";

            string filetransacciones = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filetransacciones + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 1:" + myException.ToString();
                return -1;
            }


            SQLiteCommand mycommand;
            String idusuario = Configuracion.getIdUsuario();
   
            long TS;
            int REASON;
            if (cantidad_p > 0)
            {
                REASON = Constants.AGREGAINVENTARIO;
            }
            else
            {
                REASON = Constants.RESTAINVENTARIO;
            }
 
            TS = MyGlobal.UnixTimeNow();
            contador_a++;
            String ID = "TSTOCK" + TS + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p + "-" + contador_a + "-" + idusuario;
            ID = MyGlobal.getMD5Hash(ID);
            mycommand = new SQLiteCommand(sqlConn);

            String cantidad, precio;
            cantidad = cantidad_p.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            precio = producto_p.PRECIO.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));

            String tableName = Modelo.getTablePrefix() + "STOCKDIARY";

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDUSUARIO,EAN,UNITS,PRICE) ";
            } else if ( place_p == null && producto_p.SKU != null ) {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            } else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,PLACE,IDUSUARIO,EAN,UNITS,PRICE) ";
            } else {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,PLACE,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }

            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + ID + "',";
            mycommand.CommandText += "'" + TS + "',";
            mycommand.CommandText += "'" + REASON + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            //mycommand.CommandText += "'" + producto_p.idcolor + "',";
            //mycommand.CommandText += "'" + producto_p.idtalla + "',";

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }
            mycommand.CommandText += "'" + idusuario + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";

            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            mycommand.CommandText += "'" + cantidad + "',";
            mycommand.CommandText += "'" + precio + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 002-B:" + myException.Message;
                retval = retval + 1;
                return retval;
            }


            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String IDST;
            IDST = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p;


            IDST = MyGlobal.getMD5Hash(IDST);

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,UNITS) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,SKU,UNITS) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,PLACE,UNITS) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,EAN,SKU,PLACE,UNITS) ";
            }


            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + IDST + "',";
            mycommand.CommandText += "'" + FECHA + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            //mycommand.CommandText += "'" + producto_p.idcolor + "',";
            //mycommand.CommandText += "'" + producto_p.idtalla + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";

            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }

            mycommand.CommandText += "'" + cantidad + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch 
            {
                mycommand.CommandText = "UPDATE " + tableName  + " ";
                mycommand.CommandText += " SET UNITS = UNITS + " + cantidad + " ";
                mycommand.CommandText += "WHERE ";
                mycommand.CommandText += "ID   = '" + IDST + "' ";

                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException2)
                {
                    szRetval_p = "Error 3: " + myException2.Message;
                    retval = retval + 1;
                }
            }

            sqlConn.Close();

            String IdEvento = "TSTOCK";
            String szRetval2;
            Modelo.registraEvento(ID, TS, IdEvento, out szRetval2);
            if (szRetval_p == "OK")
            {
                szRetval_p = szRetval2;
                retval = 0;
            }
            else
            {
                szRetval_p += szRetval2;
            }
            return retval;
        }

        public int contarCalzado(Producto producto_p, int cantidad_p, String location_p, String idbodega_p, String place_p, String idcolor_p, String idtalla_p, out String szRetval_p)
        {
            int retval = 0;
            SQLiteConnection sqlConn;
            sqlConn = new SQLiteConnection();
            szRetval_p = "OK";

            string filetransacciones = Configuracion.getTransaccionesFile();
            sqlConn.ConnectionString = "Data Source=" + filetransacciones + ";Version=3;";

            try
            {
                sqlConn.Open();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 1:" + myException.ToString();
                return -1;
            }


            SQLiteCommand mycommand;
            String idusuario = Configuracion.getIdUsuario();

            long TS;
            int REASON;
            if (cantidad_p > 0)
            {
                REASON = Constants.AGREGAINVENTARIO;
            }
            else
            {
                REASON = Constants.RESTAINVENTARIO;
            }

            TS = MyGlobal.UnixTimeNow();
            contador_a++;
            String ID = "TSTOCK" + TS + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p + "-" + contador_a + "-" + idusuario;
            ID = MyGlobal.getMD5Hash(ID);
            mycommand = new SQLiteCommand(sqlConn);

            String cantidad, precio;
            cantidad = cantidad_p.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));
            precio = producto_p.PRECIO.ToString("F12", CultureInfo.CreateSpecificCulture("es-MX"));

            String tableName = Modelo.getTablePrefix() + "STOCKDIARY";

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,IDUSUARIO,EAN,UNITS,PRICE) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,PLACE,IDUSUARIO,EAN,UNITS,PRICE) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,TS,REASON,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,PLACE,IDUSUARIO,EAN,SKU,UNITS,PRICE) ";
            }

            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + ID + "',";
            mycommand.CommandText += "'" + TS + "',";
            mycommand.CommandText += "'" + REASON + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + producto_p.idcolor + "',";
            mycommand.CommandText += "'" + producto_p.idtalla + "',";

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }
            mycommand.CommandText += "'" + idusuario + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";

            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            mycommand.CommandText += "'" + cantidad + "',";
            mycommand.CommandText += "'" + precio + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = "Error 002-B:" + myException.Message;
                retval = retval + 1;
                return retval;
            }


            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String IDST;
            IDST = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + idbodega_p + "-" + producto_p.EAN + "-" + place_p + "-" + idcolor_p + "-" + idtalla_p;


            IDST = MyGlobal.getMD5Hash(IDST);

            if (place_p == null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,UNITS) ";
            }
            else if (place_p == null && producto_p.SKU != null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,SKU,UNITS) ";
            }
            else if (place_p != null && producto_p.SKU == null)
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,PLACE,UNITS) ";
            }
            else
            {
                mycommand.CommandText = "INSERT INTO " + tableName + "(ID,FECHA,LOCATION,IDBODEGA,IDCOLOR,IDTALLA,EAN,SKU,PLACE,UNITS) ";
            }


            mycommand.CommandText += "VALUES ( ";
            mycommand.CommandText += "'" + IDST + "',";
            mycommand.CommandText += "'" + FECHA + "',";
            mycommand.CommandText += "'" + location_p + "',";
            mycommand.CommandText += "'" + idbodega_p + "',";
            mycommand.CommandText += "'" + producto_p.idcolor + "',";
            mycommand.CommandText += "'" + producto_p.idtalla + "',";
            mycommand.CommandText += "'" + producto_p.EAN + "',";

            if (producto_p.SKU != null)
            {
                mycommand.CommandText += "'" + producto_p.SKU + "',";
            }

            if (place_p != null)
            {
                mycommand.CommandText += "'" + place_p + "',";
            }

            mycommand.CommandText += "'" + cantidad + "');";

            try
            {
                mycommand.ExecuteNonQuery();
            }
            catch
            {
                mycommand.CommandText = "UPDATE " + tableName + " ";
                mycommand.CommandText += " SET UNITS = UNITS + " + cantidad + " ";
                mycommand.CommandText += "WHERE ";
                mycommand.CommandText += "ID   = '" + IDST + "' ";

                try
                {
                    mycommand.ExecuteNonQuery();
                }
                catch (SQLiteException myException2)
                {
                    szRetval_p = "Error 3: " + myException2.Message;
                    retval = retval + 1;
                }
            }

            sqlConn.Close();

            String IdEvento = "TSTOCK";
            String szRetval2;
            Modelo.registraEvento(ID, TS, IdEvento, out szRetval2);
            if (szRetval_p == "OK")
            {
                szRetval_p = szRetval2;
                retval = 0;
            }
            else
            {
                szRetval_p += szRetval2;
            }
            return retval;
        }

        public double getStockCurrentTotal(String ean_p, String location_p, out String szRetval_p)
        {
            double unidades = 0;

            szRetval_p ="getStockCurrentTotal";
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
                szRetval_p = myException.Message;
                return -1;

            }
            szRetval_p = "Consultando";
            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "SELECT SUM(UNITS) AS UNITS ";
            sqlString += "FROM " + tableName + " ";
            sqlString += "WHERE ";
            sqlString += "LOCATION = '" + location_p + "' AND  ";
            sqlString += "EAN      = '" + ean_p + "' AND ";
            sqlString += "FECHA    = '" + FECHA + "'  ; ";

            szRetval_p = sqlString;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
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
                szRetval_p = myException.Message;
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }

        public double getStockCurrent(String ean_p, String location_p,String place_p,out String szRetval_p)
        {
            double unidades = 0;
            szRetval_p = "getStockCurrent";

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
                szRetval_p = myException.Message;
                return -1;

            }
            szRetval_p = "Consultando";
            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String ID;
            ID = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + ean_p + "-" + place_p;
            ID = MyGlobal.getMD5Hash(ID);
   
            sqlString = "SELECT UNITS ";
            sqlString += "FROM " + tableName + " ";
            sqlString += "WHERE ";
            sqlString += "ID    = '" + ID + "'  ; ";
 

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
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
                szRetval_p = myException.Message;
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }

        public double getStockCurrentBodega(String ean_p, String location_p,String idbodega_p,String place_p, out String szRetval_p)
        {
            double unidades = 0;
            szRetval_p = "getStockCurrentBodega";

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
                szRetval_p = myException.Message;
                return -1;

            }
            szRetval_p = "Consultando";
            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String ID;

            ID = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + idbodega_p + "-" + ean_p + "-" + place_p;

            ID = MyGlobal.getMD5Hash(ID);

            sqlString = "SELECT UNITS ";
            sqlString += "FROM " + tableName + " ";
            sqlString += "WHERE ";
            sqlString += "ID    = '" + ID + "'  ; ";


            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
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
                szRetval_p = myException.Message;
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }

        public double getStockCurrentTotalBodega(String ean_p, String location_p, String idbodega_p,out String szRetval_p)
        {
            double unidades = 0;

            szRetval_p = "getStockCurrentTotalBodega";
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
                szRetval_p = myException.Message;
                return -1;

            }
            szRetval_p = "Consultando";
            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "SELECT SUM(UNITS) AS UNITS ";
            sqlString += "FROM " + tableName + " ";
            sqlString += "WHERE ";
            sqlString += "LOCATION = '" + location_p + "' AND  ";
            sqlString += "IDBODEGA = '" + idbodega_p + "' AND  ";
            sqlString += "EAN      = '" + ean_p + "' AND ";
            sqlString += "FECHA    = '" + FECHA + "'  ; ";

            szRetval_p = sqlString;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
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
                szRetval_p = myException.Message;
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }

        public double getStockCurrentBodegaByColorTalla(String ean_p, String location_p, String idbodega_p, String place_p, String idcolor_p, String idtalla_p, out String szRetval_p)
        {
            double unidades = 0;
            szRetval_p = "getStockCurrentBodega";

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
                szRetval_p = myException.Message;
                return -1;

            }
            szRetval_p = "Consultando";
            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";

            String ID;

            ID = "TSTOCKCURRENT" + FECHA + "-" + location_p + "-" + idbodega_p + "-" + ean_p + "-" + place_p + "-" + idcolor_p + "-" + idtalla_p;

            ID = MyGlobal.getMD5Hash(ID);

            sqlString = "SELECT UNITS ";
            sqlString += "FROM " + tableName + " ";
            sqlString += "WHERE ";
            sqlString += "ID    = '" + ID + "'  ; ";


            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
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
                szRetval_p = myException.Message;
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }

        public double getStockCurrentTotalBodegaByColorTalla(String ean_p, String location_p, String idbodega_p, String idcolor_p, String idtalla_p, out String szRetval_p)
        {
            double unidades = 0;

            szRetval_p = "getStockCurrentTotalBodega";
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
                szRetval_p = myException.Message;
                return -1;

            }
            szRetval_p = "Consultando";
            System.DateTime objCurrentDate = DateTime.Now;
            String FECHA;
            FECHA = String.Format("{0:yyyy-MM-dd}", objCurrentDate);

            SQLiteCommand mycommand;

            String sqlString;

            String tableName = Modelo.getTablePrefix() + "STOCKCURRENT";
            sqlString = "SELECT SUM(UNITS) AS UNITS ";
            sqlString += "FROM " + tableName + " ";
            sqlString += "WHERE ";
            sqlString += "LOCATION = '" + location_p + "' AND  ";
            sqlString += "IDBODEGA = '" + idbodega_p + "' AND  ";
            sqlString += "EAN      = '" + ean_p + "' AND ";
            sqlString += "IDCOLOR  = '" + idcolor_p + "' AND ";
            sqlString += "IDTALLA  = '" + idtalla_p + "'  ; ";

 //           sqlString += "FECHA    = '" + FECHA + "'  ; ";

            szRetval_p = sqlString;

            mycommand = new SQLiteCommand(sqlString, sqlConn);

            SQLiteDataReader reader;


            try
            {
                reader = mycommand.ExecuteReader();
            }
            catch (SQLiteException myException)
            {
                szRetval_p = myException.Message;
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
                szRetval_p = myException.Message;
                unidades = 0;
            }
            sqlConn.Close();
            return unidades;
        }



        private void GetImage(string fullName)
        {            
           
            SQLiteConnection sqlite_con = 
            new SQLiteConnection("Data Source=|DataDirectory|dbasedict.s3db;" + 
            "Version=3;New=False;Compress=True;");
            String querry2 = "select iimages from dictionario where word = '"; 

            SQLiteDataAdapter adap3 = new SQLiteDataAdapter(querry2, sqlite_con);
            DataSet set = new DataSet();
            adap3.Fill(set, "dictionario");
            DataTable dataTable = new DataTable();
            dataTable = (DataTable)set.Tables[0];
            MemoryStream ms = null;
            foreach (DataRow row in dataTable.Rows)            
            {
            int id = Convert.ToInt32(row["iimages"]);
            byte[] data = (byte[])row["dictionario"];
            ms = new MemoryStream(data);
            }

           
            // pictureBox1.Image = Image.FromStream(ms);            
        }


    }


}
