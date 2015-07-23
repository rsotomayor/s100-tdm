using System;
using System.Collections.Generic;
using System.Text;
using Intermec.Print;
using Intermec.Communication.Bluetooth;
using System.IO;
using System.Diagnostics;

namespace MyLibrary
{
    public class Impresora
    {

        private static LinePrinter lp;
        private static DeviceUtility deviceUtility1;
        private static string xmlFileName = @"\Windows\pswdm0c.xml";
        private static string deviceType = @"Printer";        
        private static string deviceSubtype = null;
        private static string device = "";
        private static string saltoLinea = "\r\n";

        private static void WarningHandler(object source, LinePrinter.WarningMessageArgs Error)
        {
            string temp = string.Format("{0} from {1} Printer \n\r\n\r Fix problem and continue printing?", NPCPErrorStr(Error.ErrorCode), Error.DeviceType);
            //guardar temp al log
        }

        private static void ShowError(Exception e)
        {
            string Message = "Error desconocido en impresión";
            if (e is LinePrinterException)
            {
                LinePrinterException lpe = (LinePrinterException)e;
                if (lpe.ErrorType == LinePrinterException.ErrorTypes.CONFIG_ERROR)
                {
                    Message = "Error en la configuración\r\n\r\nPosible error en cofig.xml!";
                }
                else if (lpe.ErrorType == LinePrinterException.ErrorTypes.PRINTER_ERROR)
                {
                    Message = string.Format("NPCP Error en impresora\n\r\n\rError # {0} - {1}", lpe.ErrorCode, NPCPErrorStr(lpe.ErrorCode));
                }
            }
            //guardar Message en log
        }

        private static string NPCPErrorStr(int NPCPErr)
        {
            switch (NPCPErr)
            {
                case 102: return "La impresora no esta lista";
                case 104: return "No recibe";
                case 106: return "No Transmite";
                case 113: return "Error de Paridad en MAC";
                case 120: return "Frame invalido";
                case 121: return "NS != VR";
                case 122: return "NR != VS";
                case 123: return "Error en largo recibido";
                case 124: return "CRC Error";
                case 200: return "Frame Rechazado";
                case 201: return "Frame Rechazado";
                case 202: return "NR Error";
                case 203: return "NS Error";
                case 204: return "Desconectado";
                case 210: return "Bind Error";
                case 221: return "PLDU Invalido";
                case 222: return "Head Jam";
                case 223: return "Papel";
                case 224: return "Voltage Bajo";
                case 225: return "Sobre Voltage";
                case 226: return "Bateria Baja";
                case 227: return "Cubierta";
                case 228: return "Error al imprimir encabezado";
                case 229: return "Error en alimentación del papel";
                default: return "Desconocido";
            }
        }

        

        private static bool estaConectado()
        {
            try
            {
                deviceUtility1.CheckDevice(device);
                return true;
            }
            catch
            {
                return false;
            }
        }




        public static int imprimeRevenue(String ean_p, String sku_p, String nombreProducto_p, String departamento_p, String linea_p, double precio_p, String iddepartamento_p, String idlinea_p, out String szRetval_p)
        {
            // Aqui va la el formato de etiqueta blanca de acuerdo a:
            // 1) Codigo Barra                        ||||||||||||||||||||||
            // 2) nomproProducto_p (1,20)             BODY COLALESS VESTAL
            // 3) nomproProducto_p (21,20)            LR-851 BLANCO 36
            // 4) En Blanco
            // 5) departamento_p                      D116 CORSETERIA
            // 6) linea_p                             L000171 CONTROL
            // 7) Código sku_p                        1128171
            //                                        ------------
            // 8) precio_p                            |$  25.290 |
            //                                        ------------
            szRetval_p = "";
            int retval = -1; //Error desconocido
            string CODIGO = "000000000000";
            String VALOR = "$ " + String.Format("{0:0,0}", precio_p);

            String LINEA1 = " ", LINEA2 = " ", LINEA3 = " ", LINEA4 = " ";
            Int32 cantidad_letras = nombreProducto_p.Length;
            if (cantidad_letras > 20) //14
            {
                LINEA1 = nombreProducto_p.Substring(0, 20); //(0, 14)
                if (cantidad_letras < 40) //28
                {
                    LINEA2 = nombreProducto_p.Substring(20, (cantidad_letras - 20)); // 14, (cantidad_letras - 28)
                }
                else 
                {
                    LINEA2 = nombreProducto_p.Substring(20, 20); //(14, 14)
                }
            }
            else 
            {
                LINEA1 = nombreProducto_p;
            }

            //Valido que el largo del nombre del departamento no sea mayor a 8
            if (departamento_p.Length > 16) //con FONT 6, el length debe ser > 15, con 5 > 16
            {
                LINEA3 = departamento_p.Substring(0, 16);
            }
            else
            {
                LINEA3 = departamento_p;
            }
            //Valido que el largo del nombre de la linea no sea mayor a 8
            if (linea_p.Length > 15) //con FONT 6, el length debe ser > 14, con 5 > 15
            {
                LINEA4 = linea_p.Substring(0, 15);
            }
            else
            {
                LINEA4 = linea_p;
            }

            if (ean_p.Length == 13)
            {
                CODIGO = ean_p.Remove(12, 1);
            }

            if (abrirPuerto())
            {
                try
                {               
              /*
                    lp.Write("10 FONT \"Swiss 721 BT\", 20 : DIR 4 : ALIGN 2");
                    lp.NewLine();
                    lp.Write("20 PRPOS 75,105 : PRTXT \"RIPLEY\"");
                    lp.NewLine();
                    lp.Write("30 PRPOS 170,111 : BARSET \"EAN13\" : BARHEIGHT 70 : BARFONT \"Swiss 721 BT\"");
                    lp.NewLine();
                    lp.Write("40 BARFONT ON : PRBAR \"" + CODIGO + "\"");
                    lp.NewLine();
                    lp.Write("50 FONT \"Swiss 721 BT\", 8 : ALIGN 1");
                    lp.NewLine();
                    lp.Write("60 PRPOS 200,0 : PRTXT \"" + LINEA1 +"\"");
                    lp.NewLine();
                    lp.Write("70 PRPOS 223,0 : PRTXT \"" + LINEA2 + "\"");
                    lp.NewLine();
                    lp.Write("80 PRPOS 246,0 :PRTXT \"" + departamento_p + "\"");
                    lp.NewLine();
                    lp.Write("90 PRPOS 269,0 : PRTXT \"" + linea_p + "\"");
                    lp.NewLine();
                    lp.Write("100 PRPOS 310,0 : PRLINE 210,2 : PRPOS 360,0 : PRLINE 210,2");
                    lp.NewLine();
                    lp.Write("110 DIR 3 : PRPOS 360,1 : PRLINE 50,2");
                    lp.NewLine();
                    lp.Write("120 PRPOS 360,209 : PRLINE 50,2");
                    lp.NewLine();
                    lp.Write("130 FONT \"Swiss 721 Bold BT\", 10 : DIR 4 : PRPOS 305,0 : PRTXT \"" + sku_p + "\"");
                    lp.NewLine();
                    lp.Write("140 ALIGN 2 : PRPOS 352,105 : PRTXT \"" + VALOR +  "\"");
                    lp.NewLine();                                   
                    lp.Write("150 PRINTFEED");
                    lp.NewLine();
                    lp.Write("RUN");
                    lp.NewLine();                    
                    retval = 0;
        
                    */

                    lp.Write("10 FONT \"Swiss 721 BT\", 18 : DIR 4 : ALIGN 2");
                    lp.NewLine();
                    lp.Write("20 PRPOS 75,100 : PRTXT \"RIPLEY\"");  //75, 100
                    lp.NewLine();
                    lp.Write("30 PRPOS 170,114 : BARSET \"EAN13\" : BARHEIGHT 70 "); //170, 95
                    lp.NewLine();
                    lp.Write("40 BARFONT ON : PRBAR \"" + CODIGO + "\"");
                    lp.NewLine();
                    lp.Write("50 FONT \"Swiss 721 Bold BT\", 6 : ALIGN 1");
                    lp.NewLine();
                    lp.Write("60 PRPOS 200,5 : PRTXT \"" + LINEA1 +"\"");
                    lp.NewLine();
                    lp.Write("70 PRPOS 223,5 : PRTXT \"" + LINEA2 + "\"");
                    lp.NewLine();
                    lp.Write("80 FONT \"Swiss 721 BT\", 5 : DIR 4 : PRPOS 246,0 : PRTXT \" " + iddepartamento_p + "  " + LINEA3 + "\""); 
                    lp.NewLine();
                    lp.Write("90 FONT \"Swiss 721 BT\", 5 : DIR 4 : PRPOS 269,0 : PRTXT \" " + idlinea_p + "  " + LINEA4 + "\"");
                    lp.NewLine();
                    lp.Write("100 PRPOS 310,0 : PRLINE 210,2 : PRPOS 360,0 : PRLINE 210,2");
                    lp.NewLine();
                    lp.Write("110 DIR 3 : PRPOS 360,1 : PRLINE 50,2");
                    lp.NewLine();
                    lp.Write("120 PRPOS 360,209 : PRLINE 50,2");
                    lp.NewLine();
                    lp.Write("130 FONT \"Swiss 721 Bold BT\", 10 : DIR 4 : PRPOS 305,3 : PRTXT \"" + sku_p + "\"");
                    lp.NewLine();
                    lp.Write("140 ALIGN 2 : PRPOS 352,105 : PRTXT \"" + VALOR +  "\"");
                    lp.NewLine();                                   
                    lp.Write("150 PRINTFEED");
                    lp.NewLine();
                    lp.Write("RUN");
                    lp.NewLine();                    
                    retval = 0;


      /*
                    lp.Write("10 FONT \"Swiss 721 BT\"");
                    lp.NewLine();
                    lp.Write("20 PRPOS 75,105 : PRTXT \"RIPLEY\"");
                    lp.NewLine();
                    lp.Write("30 PRPOS 170,111 : BARSET \"EAN13\" : BARHEIGHT 70 : BARFONT \"Swiss 721 BT\"");
                    lp.NewLine();
                    lp.Write("40 BARFONT ON : PRBAR \"" + CODIGO + "\"");
                    lp.NewLine();
                    lp.Write("50 FONT \"Swiss 721 BT\", 8 : ALIGN 1");
                    lp.NewLine();
                    lp.Write("60 PRPOS 200,0 : PRTXT \"" + LINEA1 + "\"");
                    lp.NewLine();
                    lp.Write("70 PRPOS 223,0 : PRTXT \"" + LINEA2 + "\"");
                    lp.NewLine();
                    lp.Write("80 PRPOS 246,0 :PRTXT \"" + departamento_p + "\"");
                    lp.NewLine();
                    lp.Write("90 PRPOS 269,0 : PRTXT \"" + linea_p + "\"");
                    lp.NewLine();
                    lp.Write("100 PRPOS 310,0 : PRLINE 210,2 : PRPOS 360,0 : PRLINE 210,2");
                    lp.NewLine();
                    lp.Write("110 DIR 3 : PRPOS 360,1 : PRLINE 50,2");
                    lp.NewLine();
                    lp.Write("120 PRPOS 360,209 : PRLINE 50,2");
                    lp.NewLine();
                    lp.Write("130 FONT \"Swiss 721 Bold BT\", 10 : DIR 4 : PRPOS 305,0 : PRTXT \"" + sku_p + "\"");
                    lp.NewLine();
                    lp.Write("140 ALIGN 2 : PRPOS 352,105 : PRTXT \"" + VALOR + "\"");
                    lp.NewLine();
                    lp.Write("150 PRINTFEED");
                    lp.NewLine();
                    lp.Write("RUN");
                    lp.NewLine();
     */

                    retval = 0;


                }
                catch
                {
                    retval = -2;
                    szRetval_p = "Error en la comunicación con la impresora";
                }
            }

            return retval;
        }

        public static int imprimePromocional(String sku_p, double precio_p,out String szRetval_p)
        {
            szRetval_p = "";            
            int retval = -1 ; //Error desconocido
            string CODIGO = sku_p;            
            string VALOR = "$ " + String.Format("{0:0,0}", precio_p);
                       
            if (abrirPuerto())
            {
                try
                {   
 
                    if (precio_p > 9999)
                    {
                        lp.Write("10 FONT \"Swiss 721 BT\",12");
                    }
                    else
                    {
                        lp.Write("10 FONT \"Swiss 721 BT\",16");
                    }


                    lp.NewLine();
                    lp.Write("20 PRPOS 180,60");
                    lp.NewLine();
                    lp.Write("30 ALIGN 5");
                    lp.NewLine();
                    lp.Write("40 PRTXT \"" + VALOR + "\" ");
                    lp.NewLine();
                    lp.Write("50 PRINTFEED");
                    lp.NewLine();
                    lp.Write("RUN");
                    lp.NewLine();
                    retval = 0;
                }
                catch
                {
                    retval = -2;
                    szRetval_p = "Error en la comunicación con la impresora";
                }
            }            
            return retval;
        }


        public static int iniciarImpresora(out String szRetval_p) {
            deviceUtility1 = new DeviceUtility();
            szRetval_p = "";
            if (conectarImpresora(out szRetval_p))
            {
                if (!abrirPuerto()) {
                    szRetval_p = "Error al abrir puerto impresora";
                    return -1;
                }
            }else{
                return -2;
            }
            szRetval_p = "Impresora OK";
            lp = new LinePrinter("config.xml", "PB21_PB22Bt_40COL");            
            return 0;
        }

        private static bool abrirPuerto()
        {
            string error = "";
            if (!estaConectado())
            {
                if (!conectarImpresora(out error))
                {
                    //NO SE PUEDE CONECTAR
                    return false;
                }
            }         

            try
            {
                lp.NewLine();
                lp.Write("NEW");
                lp.NewLine();                
                return true;
            }
            catch
            {
                try
                {
                    //SI NO PUEDE INTENTAR ABRIR PUERTO NUEVAMENTE
                    lp = new LinePrinter("config.xml", "PB21_PB22Bt_40COL");
                    lp.Open();                    
                    lp.NewLine();
                    lp.Write("NEW");
                    lp.NewLine();                    
                    return true;
                }
                catch
                {                    
                    //NO SE PUEDE ABRIR PUERTO
                    return false;
                }
            }
        }


        private static bool conectarImpresora(out string error)
        {
            error = "";
            try
            {
                deviceUtility1.Initialize(xmlFileName);
                device = deviceUtility1.GetDefaultDevice(deviceType, deviceSubtype);
                if (deviceUtility1.IsBondWithDeviceNeeded(device))
                {
                    deviceUtility1.BondWithDevice(device);
                }
                deviceUtility1.SetActiveDevice(deviceType, deviceSubtype, device);
                return true;
            }
            catch (DeviceUtilityException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return false;
        }


    }
}
