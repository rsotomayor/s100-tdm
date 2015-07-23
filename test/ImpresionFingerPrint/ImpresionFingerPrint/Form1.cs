using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Intermec.Print;
using Intermec.Communication.Bluetooth;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace ImpresionFingerPrint
{
    public partial class Form1 : Form
    {
        private LinePrinter lp;
        private DeviceUtility deviceUtility1;
        private string xmlFileName = @"\Windows\pswdm0c.xml";
        private string deviceType = @"Printer";
        private string deviceSubtype = null;
        private string device = "";
        private string saltoLinea = "\r\n";        

        public Form1()
        {
            InitializeComponent();
        }
                
        public void DisplayStatus(object source, LinePrinter.StatusMessageArgs Status)
        {
            string temp;
            switch (Status.MessageType)
            {
                case LinePrinter.StatusMessageTypes.SM_NONE: temp = "NONE"; break;
                case LinePrinter.StatusMessageTypes.SM_WRITEINCOMPLETE: temp = "WRITEINCOMPLETE"; break;
                case LinePrinter.StatusMessageTypes.SM_STARTDOC: temp = "STARTDOC"; break;
                case LinePrinter.StatusMessageTypes.SM_STARTPAGE: temp = "STARTPAGE"; break;
                case LinePrinter.StatusMessageTypes.SM_ENDPAGE: temp = "ENDPAGE"; break;
                case LinePrinter.StatusMessageTypes.SM_ENDDOC: temp = "ENDDOC"; break;
                case LinePrinter.StatusMessageTypes.SM_USERCANCEL: temp = "USERCANCEL"; break;
                case LinePrinter.StatusMessageTypes.SM_CANCEL: temp = "CANCEL"; break;
                case LinePrinter.StatusMessageTypes.SM_FINISHED: temp = "FINISHED"; break;
                case LinePrinter.StatusMessageTypes.SM_COMPLETE: temp = "COMPLETE"; break;
                default: temp = "UNKNOWN"; break;
            }
            StatusBox.Text = "Status " + temp + "\r\n" + StatusBox.Text;
        }


        public void WarningHandler(object source, LinePrinter.WarningMessageArgs Error)
        {
            string temp;
            DialogResult result;
            temp = string.Format("{0} from {1} Printer \n\r\n\r Fix problem and continue printing?", NPCPErrorStr(Error.ErrorCode), Error.DeviceType);
            result = MessageBox.Show(temp, "Advertencia", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No) lp.Cancel();
        }

        public void ShowError(Exception e)
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
            MessageBox.Show(Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        static string NPCPErrorStr(int NPCPErr)
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
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }               

        public bool conectarImpresora(out string error)
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

        public bool estaConectado()
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
        


        private void button2_Click_1(object sender, EventArgs e)
        {
            string VALOR = "$1.000";
            string CODIGO = "123456789012";            
            if (abrirPuerto())
            {
                try
                {                    
                    lp.Write("10 FONT \"Swiss 721 BT\"");
                    lp.NewLine();
                    lp.Write("20 PRPOS 60,100");
                    lp.NewLine();
                    lp.Write("30 PRTXT \""+CODIGO+"\" ");
                    lp.NewLine();
                    lp.Write("40 FONT \"Swiss 721 BT\",18");
                    lp.NewLine();
                    lp.Write("50 PRPOS 60,20");
                    lp.NewLine();
                    lp.Write("60 PRTXT \"" + VALOR + "\" ");
                    lp.NewLine();
                    lp.Write("70 PRINTFEED");
                    lp.NewLine();
                    lp.Write("RUN");
                    lp.NewLine();                   
                }
                catch
                {
                    StatusBox.Text = "No puede enviar datos" + saltoLinea + StatusBox.Text;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deviceUtility1 = new DeviceUtility();            
            String error = "";
            if (conectarImpresora(out error))
            {
                abrirPuerto();
            }
            else { 
                if (error != "")
                {
                    MessageBox.Show(error);
                }
            }
            lp = new LinePrinter("config.xml", "PB21_PB22Bt_40COL");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (estaConectado())
            {
                MessageBox.Show("si");
            }
            else {
                MessageBox.Show("no");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lp.Write(this.textBox1.Text);
                lp.NewLine();
            }
            catch {
                MessageBox.Show("Error");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (abrirPuerto())
            {
                MessageBox.Show("ok");
            }
            else {
                MessageBox.Show("no se abre el puerto");
            }

        }


        private bool abrirPuerto(){
            string error = "";
            if (!estaConectado())
            {
                if (!conectarImpresora(out error)) {
                    return false;
                }
            }
            this.StatusBox.Text = "Abriendo Puerto" + saltoLinea + this.StatusBox.Text;
            try{
                lp.NewLine();
                lp.Write("NEW");
                lp.NewLine();
                this.StatusBox.Text = "Esta OK A" + saltoLinea + this.StatusBox.Text;
                return true;
            }catch{
                try
                {
                    lp = new LinePrinter("config.xml", "PB21_PB22Bt_40COL");
                    lp.Open();
                    this.StatusBox.Text = "Listo" + saltoLinea + this.StatusBox.Text;
                    lp.NewLine();
                    lp.Write("NEW");
                    lp.NewLine();
                    this.StatusBox.Text = "Esta OK B" + saltoLinea + this.StatusBox.Text;
                    return true;
                }
                catch {
                    this.StatusBox.Text = "Error al abrir puerto" + saltoLinea + this.StatusBox.Text;
                    return false;
                }
            }
        }

       
        private void cerrarPuerto(){
            try{
                lp.Close();
            }catch{
            
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {                                    
            if (abrirPuerto())
            {
                try
                {                    
                    String archivo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName), "comandos.fcs");
                    TextReader trs = new StreamReader(archivo);
                    String linea = trs.ReadLine();
                    Int32 numero_linea = 10;
                    while (linea != null)
                    {
                        linea = linea.Trim();
                        StatusBox.Text = linea + saltoLinea + StatusBox.Text;
                        lp.Write(numero_linea.ToString() + " " + linea);
                        lp.NewLine();
                        numero_linea += 10;
                        linea = trs.ReadLine();
                    }
                    lp.Write("RUN");
                    lp.NewLine();
                    trs.Close();
                }
                catch
                {
                    StatusBox.Text = "No puede enviar datos" + saltoLinea + StatusBox.Text;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (abrirPuerto())
            {
                try
                {
                    lp.WriteFile("r.bmp");
                    lp.NewLine();                    
                }
                catch
                {
                    StatusBox.Text = "No puede enviar datos" + saltoLinea + StatusBox.Text;
                }
            }
        }

    }
}