using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using Intermec.DataCollection;
using System.Data.SQLite;
using System.Net;
using System.IO;
using System.Xml.Serialization;

public struct tFiles
{
    public string paramName_a;
    public string nombre_a;
    public string tipo_a;
    public byte[] file_a;
}    

namespace s100_tdm
{
    public partial class FormInicio : Form
    {
        String version_a = "v0.2.0";
        delegate void SetTextCallback(int progress);
        string idtransaccion_a;
        private Thread demoThread = null;

        #region Methods
        #region private void DebugString() DebugLine()
        /// <summary>
        /// Adds a string to the debug text box, if debug check box is checked.
        /// </summary>
        /// <param name="s">String to add to text box.</param>
        private void DebugString(string s)
        {
            myformdebug_a.ingresaItem(s);

        }
        /// <summary>
        /// Adds a line to the debug text box, if debug check box is checked.
        /// </summary>
        /// <param name="s">String to add to text box.</param>
        private void DebugLine(string s)
        {
            myformdebug_a.ingresaItem(s);
        }
        #endregion



        #region private void HandleILVEnrollSearchDatabase(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleILVEnroll
        /// delegate when the fingerprint information received in the ENROLL
        /// ILV is to be searched for in the database.  This function is invoked
        /// on the application UI thread by the CN3PIV object when an ENROLL ILV
        /// is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing ENROLL ILV.</param>
        private void HandleILVEnrollSearchDatabase(MSUSBMessage msg)
        {
            /*
            MSUSBMessage searchTemplateILV = null;

            ArrayList ilvs = ExtractEnroll(msg);
            if (ilvs != null)
            {
                for (int i = 0; i < ilvs.Count; i++)
                {
                    MSUSBMessage ilv = (MSUSBMessage)ilvs[i];
                    switch (ilv.I)
                    {
                        case MSUSBMessage.ILV.ID_PK_COMP:
                            {
                                searchTemplateILV = ilv;
                            }
                            break;
                    }
                }
                if (searchTemplateILV != null)
                {
                    DoVerifyMatch(searchTemplateILV);
                }
                else
                {
                    UpdateDBUI();
                }
            }
            else
            {
                switch (msg.V[0])
                {
                    case MSUSBMessage.ILV.ILVERR_TIMEOUT:
                        DBStatusLabel.Text = "Timed Out";
                        PIVFPRStatusLabel.Text = "Timed Out";
                        break;
                    case MSUSBMessage.ILV.ILVERR_CMDE_ABORTED:
                        DBStatusLabel.Text = "Cancelled";
                        PIVFPRStatusLabel.Text = "Cancelled";
                        break;
                    default:
                        DBStatusLabel.Text = "Rdr Resp " + msg.V[0].ToString("X2") + " " + msg.V[1].ToString("X2");
                        PIVFPRStatusLabel.Text = "Rdr Resp " + msg.V[0].ToString("X2") + " " + msg.V[1].ToString("X2");
                        break;
                }
                UpdateDBUI();
            }

            m_cn3piv.HandleILVEnroll -= HandleILVEnrollSearchDatabase;
            SystemSettings.ScreenOrientation = ScreenOrientation.Angle0;
            */
        }
        #endregion


        #region private void HandleMSRMessage(MDPMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRMessage
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when an any MSR message is received.
        /// </summary>
        /// <param name="msg">MDPMessage received by CN3PIV object.</param>
        private void HandleMSRMessage(MDPMessage msg)
        {
            // DebugLine("RX: " + msg.ToString());
        }
        #endregion


        #region private void HandleMSRMessagePing(MDPMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRMessagePing
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when an MSR Ping message is received.
        /// </summary>
        /// <param name="msg">MDPMessage received by CN3PIV object.</param>
        private void HandleMSRMessagePing(MDPMessage msg)
        {
             DebugLine(System.Text.ASCIIEncoding.ASCII.GetString(msg.Data, 0, 4));
             DebugLine(System.Text.ASCIIEncoding.ASCII.GetString(msg.Data, 0, 4));
        }
        #endregion

        #region private ArrayList ExtractEnroll(MSUSBMessage msg)
        /// <summary>
        /// Helper function which examines an ENROLL message reply and, if it
        /// looks OK, extracts internal ILV messages into an ArrayList.
        /// </summary>
        /// <param name="msg">ENROLL ILV reply message.</param>
        /// <returns>ArrayList containing MSUSBMessage objects which represent
        /// ILV messages contained in ENROLL ILV reply.  Null if ENROLL ILV
        /// message was inappropriate or contained no ILVs.</returns>
        private ArrayList ExtractEnroll(MSUSBMessage msg)
        {
            ArrayList ilvs = null;

            DebugLine("ExtractEnroll+");
            ulong ui64L = msg.L;
            uint ui32L = (uint)ui64L;
            uint ui32LBytes = (uint)(ui64L >> 32);

            byte requestStatus = msg.V[0];
            DebugLine("request status " + requestStatus.ToString("X2"));
            if (requestStatus == MSUSBMessage.ILV.ILV_OK)
            {
                byte enrollStatus = msg.V[1];
                DebugLine("enroll status" + enrollStatus.ToString("X2"));
                if (enrollStatus == MSUSBMessage.ILV.ILVSTS_OK)
                {
                    DebugLine("enroll successful");
                    ilvs = msg.GetILVList(6);
                    DebugLine(ilvs.Count.ToString() + " ILVs");
                }
            }

            DebugLine("ExtractEnroll-");
            return ilvs;
        }
        #endregion

        #region private void HandleILVEnrollAddToDatabase(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleILVEnroll
        /// delegate when the fingerprint information received in the ENROLL
        /// ILV is to be added to the database.  This function is invoked on
        /// the application UI thread by the CN3PIV object when an ENROLL ILV
        /// is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing ENROLL ILV.</param>
        private void HandleILVEnrollAddToDatabase(MSUSBMessage msg)
        {
            DebugLine("HandleILVEnrollAddToDatabase+");

            MSUSBMessage imageILV = null;

            ArrayList ilvs = ExtractEnroll(msg);
            if (ilvs != null)
            {
                DBEntry entry = new DBEntry();
                for (int i = 0; i < ilvs.Count; i++)
                {
                    MSUSBMessage ilv = (MSUSBMessage)ilvs[i];
                    switch (ilv.I)
                    {
                        case MSUSBMessage.ILV.ID_PK_COMP:
                            {
                                DebugLine(" ID_PK_COMP");
                                entry.m_minutiae = ilv.Message;
                            }
                            break;

                        case MSUSBMessage.ILV.ID_EXPORT_IMAGE:
                            {
                                DebugLine(" ID_EXPORT_IMAGE");
                                imageILV = ilv;
                            }
                            break;

                        default:
                            {
                                DebugLine(" I " + ilv.I.ToString("X2") + " unknown");
                            }
                            break;
                    }
                }

                if (imageILV != null)
                {
                    if (MessageBox.Show("Captura de Huella OK." + idtransaccion_a + "?", idtransaccion_a+ "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        {
                            entry.m_wsq = m_cn3piv.ILV2WSQ(imageILV);
                            /*
                            if (TabControl.SelectedIndex == 0)
                            {
                                entry.m_name = PIVFPRNameTextBox.Text;
                            }
                            else
                            {
                                entry.m_name = DBNameTextBox.Text;
                            }
                            m_entries.Add(entry);
                            SaveDB();
                             */
                        }
                        Cursor.Current = Cursors.Default;
#if true
          int BMPNumberOfColors = 0;
          int BMPAllColorsImportant = 0;
          /*                      
            FileStream fs;
            BinaryWriter bw;


            fs = File.Create("fingerprint.ilv");
            bw = new BinaryWriter(fs);
            fs.Write(imageILV.Message, 0, imageILV.Message.Length);
            bw.Close();
            fs.Close();
          */
//          byte[] bmp = m_cn3piv.ILV2BMP(imageILV, BMPNumberOfColors);

  
/*
          myFileName_a = "\\SD Card\\s100\\data\\" + Rut_a + "ILV2BMP.bmp";
          fs = File.Create(myFileName_a);
          bw = new BinaryWriter(fs);
          fs.Write(bmp, 0, bmp.Length);
          bw.Close();
          fs.Close();

          myFileName_a = "\\SD Card\\s100\\data\\" + Rut_a + "ILV2WSQ.wsq";

          fs = File.Create(myFileName_a);
          bw = new BinaryWriter(fs);
          fs.Write(entry.m_wsq, 0, entry.m_wsq.Length);
          bw.Close();
          fs.Close();

          bmp = m_cn3piv.WSQ2BMP(entry.m_wsq, 1024*256, BMPNumberOfColors, BMPAllColorsImportant);
          myFileName_a = "\\SD Card\\s100\\data\\" + Rut_a + "WSQ2BMP.bmp";
          fs = File.Create(myFileName_a);
          bw = new BinaryWriter(fs);
          fs.Write(bmp, 0, bmp.Length);
          bw.Close();
          fs.Close();
*/
          
//          this.demoThread = new Thread(new ThreadStart(this.UploadFinger));
//          this.demoThread.Start();
          NameValueCollection nvc = new NameValueCollection();


          nvc.Add("idtransaccion", idtransaccion_a);
          nvc.Add("rut",Rut_a);
          nvc.Add("latitud", MyGlobal.getLatitud().ToString());
          nvc.Add("longitud", MyGlobal.getLongitud().ToString());
          string idio;
          if (checkBoxES.Checked)
          {
              idio = "0";
          }
          else
          {
              idio = "1";
          }
          nvc.Add("idio", idio);
          nvc.Add("idacceso", "CN3-001");

          long ts;
          ts = MyGlobal.UnixTimeNow();
          nvc.Add("ts", ts.ToString());

          string servidorauth = comboBoxServidor.SelectedItem.ToString();
                        

          nvc.Add("servidorauth", servidorauth);

          int idfinger ;

          idfinger = (comboBoxFinger.SelectedIndex+1);
          nvc.Add("idfinger",idfinger.ToString() );
          byte[] bmp;
          string fingertype;

          if (idtransaccion_a == "enrolar")
          {
              bmp = m_cn3piv.ILV2BMP(imageILV, BMPNumberOfColors);
              fingertype = "image/bmp";
          }
          else if (idtransaccion_a == "verificar")
          {
              bmp = entry.m_wsq;
              fingertype = "image/wsq";
          }
          else if (idtransaccion_a == "identificar")
          {
              bmp = entry.m_wsq;
              fingertype = "image/wsq";
          }
          else
          {
              bmp = entry.m_wsq;
              fingertype = "image/wsq";
          }

          tFiles[] myFiles2Upload = new tFiles[2];

          myFiles2Upload[0].paramName_a = "file";
          myFiles2Upload[0].nombre_a = "file1";
          myFiles2Upload[0].tipo_a = fingertype;
          myFiles2Upload[0].file_a = bmp;

          myFiles2Upload[1].paramName_a = "minucia";
          myFiles2Upload[1].nombre_a = "file2";
          myFiles2Upload[1].tipo_a = "object/pdf417";
          myFiles2Upload[1].file_a = minucia_a;
          string response;

          try
          {
              string urlPost_a = MyGlobal.getUrlPost();
              response = this.HttpUploadFile(urlPost_a, nvc, myFiles2Upload);
          }
          catch (Exception ex)
          {
              response = "Error en red de datos:" + ex.ToString().Substring(0, 20);
          }

          // RSO:  German, aqui se debiera manejar la llamada a los WS de Sinacofi
          labelRespuesta.Text = response;

          MessageBox.Show(response);                        

#endif
                    }
                }
                else
                {
                    DebugLine("No ENROLL Image");
                }
            }
            else
            {
                switch (msg.V[0])
                {
                    case MSUSBMessage.ILV.ILVERR_TIMEOUT:
                        DebugLine("Timed Out");
                        break;
                    case MSUSBMessage.ILV.ILVERR_CMDE_ABORTED:
                        DebugLine( "Cancelled");
                        break;
                    default:
                        DebugLine("Rdr Resp " + msg.V[0].ToString("X2"));
                        DebugLine("Rdr Resp " + msg.V[0].ToString("X2"));
                        break;
                }
            }

            m_cn3piv.HandleILVEnroll -= HandleILVEnrollAddToDatabase;
            Enable_Operaciones();

//            UpdateDBUI();
//            SystemSettings.ScreenOrientation = ScreenOrientation.Angle0;
            DebugLine("HandleILVEnrollAddToDatabase+");
        }
        #endregion

        #region private void HandleILVVerifyMatch(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleILVVerifyMatch
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when a VERIFY MATCH ILV is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing VERIFY MATCH ILV.</param>
        private void HandleILVVerifyMatch(MSUSBMessage msg)
        {


        }
        #endregion

        #region private void HandleMSRMessageDataClear(MDPMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRMessageDataClear
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when an MSR Data Clear message is received.
        /// </summary>
        /// <param name="msg">MDPMessage received by CN3PIV object.</param>
        private void HandleMSRMessageDataClear(MDPMessage msg)
        {
            // MSRTrack1DataTextBox.Text = "";
            // MSRTrack2DataTextBox.Text = "";
            // MSRTrack3DataTextBox.Text = "";
        }
        #endregion

        #region private void HandleMSRMessageTrack1Data(MDPMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRMessageTrack1Data
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when a track one MSR data message is received.
        /// </summary>
        /// <param name="msg">MDPMessage containing track one MSR data.</param>
        private void HandleMSRMessageTrack1Data(MDPMessage msg)
        {
            // string s = System.Text.ASCIIEncoding.ASCII.GetString(msg.Data, 0, msg.DataLength);
            // MSRTrack1DataTextBox.Text = s;
            //if (PIVMSRTrack1DataTextBox.Text.CompareTo(s) != 0)
            //{
            //    PIVMSRTrack1DataTextBox.Text = s;
            //}
        }
        #endregion

        #region private void HandleMSRMessageTrack2Data(MDPMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRMessageTrack2Data
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when a track two MSR data message is received.
        /// </summary>
        /// <param name="msg">MDPMessage containing track two MSR data.</param>
        private void HandleMSRMessageTrack2Data(MDPMessage msg)
        {
            //string s = System.Text.ASCIIEncoding.ASCII.GetString(msg.Data, 0, msg.DataLength);
            //MSRTrack2DataTextBox.Text = s;
            //if (PIVMSRTrack2DataTextBox.Text.CompareTo(s) != 0)
            //{
            //    PIVMSRTrack2DataTextBox.Text = s;
            //}
        }
        #endregion

        #region private void HandleMSRMessageTrack3Data(MDPMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRMessageTrack2Data
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when a track three MSR data message is received.
        /// </summary>
        /// <param name="msg">MDPMessage containing track three MSR data.</param>
        private void HandleMSRMessageTrack3Data(MDPMessage msg)
        {
           // string s = System.Text.ASCIIEncoding.ASCII.GetString(msg.Data, 0, msg.DataLength);
            // MSRTrack3DataTextBox.Text = s;
            //if (PIVMSRTrack3DataTextBox.Text.CompareTo(s) != 0)
            //{
            //    PIVMSRTrack3DataTextBox.Text = s;
            //}
        }
        #endregion

        #region private void HandleMSRMessagePower(MDPMessage msg)
        /// <summary>
        /// Handler for MSR power status message.  Update UI based on current
        /// status of MSR power control.
        /// </summary>
        /// <param name="msg"></param>
        private void HandleMSRMessagePower(MDPMessage msg)
        {
/*
            byte[] data = msg.Data;

            for (int i = 0; i < data.Length; i += 2)
            {
                switch (data[i])
                {
                    case (byte)(CN3PIV.PowerControl.FP):
                        {
                            if (data[i + 1] == 0x00)
                            {
                                PowerFPStatusLabel.Text = "Off";
                                PowerFPCheckBox.Checked = false;
                            }
                            else
                            {
                                PowerFPStatusLabel.Text = "On";
                                PowerFPCheckBox.Checked = true;
                            }
                        }
                        break;
                    case (byte)(CN3PIV.PowerControl.CC):
                        {
                            if (data[i + 1] == 0x00)
                            {
                                PowerCCStatusLabel.Text = "Off";
                                PowerCCCheckBox.Checked = false;
                            }
                            else
                            {
                                PowerCCStatusLabel.Text = "On";
                                PowerCCCheckBox.Checked = true;
                            }
                        }
                        break;
                    case (byte)(CN3PIV.PowerControl._5V):
                        {
                            if (data[i + 1] == 0x00)
                            {
                                Power5VStatusLabel.Text = "Off";
                                Power5VCheckBox.Checked = false;
                            }
                            else
                            {
                                Power5VStatusLabel.Text = "On";
                                Power5VCheckBox.Checked = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
*/
        }
        #endregion


        #region private void HandleMSRReadException(Exception ex)
        /// <summary>
        /// Function registered to CN3PIV object's HandleMSRReadException
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when its MDPSerialPort object's read thread
        /// throws an exception.
        /// </summary>
        /// <param name="ex">Exception thrown by CN3PIV object's MDPSerialPort object.</param>
        private void HandleMSRReadException(Exception ex)
        {
           // DebugLine("HandleMSRReadException: " + ex.Message);
            // MessageBox.Show(ex.Message, "HandleMSRReadException");
        }
        #endregion

        #region private void HandleSagemMessage(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleSagemMessage
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when an any ILV is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing ILV.</param>
        private void HandleSagemMessage(MSUSBMessage msg)
        {
            // ulong ui64L = msg.L;
            // uint ui32L = (uint)ui64L;
            // uint ui32LBytes = (uint)(ui64L >> 32);
            // DebugLine("RX: " + msg.I.ToString("X2") + " " + ui32L.ToString("X8") + " (" + ui32LBytes.ToString() + ")");
        }
        #endregion

        #region private void HandleSagemOpenException(Exception ex)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        private void HandleSagemOpenException(Exception ex)
        {
            // DebugLine("HandleSagemOpenException: " + ex.Message);
            // MessageBox.Show(ex.Message, "HandleSagemOpenException");
        }
        #endregion

        #region private void HandleSagemReadException(Exception ex)
        /// <summary>
        /// Function registered to CN3PIV object's HandleSagemReadException
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when an exception is thrown by the CN3PIV object's
        /// MSUSBSerialPort member's read thread.
        /// </summary>
        /// <param name="ex">Exception thrown by CN3PIV MSUSBSerialPort object.</param>
        private void HandleSagemReadException(Exception ex)
        {
            // DebugLine("HandleSagemReadException: " + ex.Message);
            // MessageBox.Show(ex.Message, "HandleSagemReadException");
        }
        #endregion

        #region private void HandleILVGetDescriptor(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleILVGetDescriptor
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when a GET DESCRIPTOR ILV is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing GET DESCRIPTOR ILV.</param>
        private void HandleILVGetDescriptor(MSUSBMessage msg)
        {
            /*
            DebugLine("HandleILVGetDescriptor+");
            ulong ui64L = msg.L;
            uint ui32L = (uint)ui64L;
            uint ui32LBytes = (uint)(ui64L >> 32);

            if (ui32L == 0x000B)
            {
                DebugLine("FORMAT_BIN_VERSION");
                ArrayList ilvs = msg.GetILVList(1);
                for (int i = 0; i < ilvs.Count; i++)
                {
                    MSUSBMessage ilv = (MSUSBMessage)ilvs[i];
                    if (ilv.I == MSUSBMessage.ILV.ID_FORMAT_BIN_VERSION)
                    {
                        m_msusbVersionString = System.Text.Encoding.ASCII.GetString(ilv.V, 0, ilv.V.Length);
                        SagemFWLabel.Text = m_msusbVersionString;
                        PIVFPRFWVersionLabel.Text = m_msusbVersionString;
                        DebugLine("Vers: " + m_msusbVersionString);
                    }
                }
            }
            else
            {
                DebugLine("Format Unknown");
            }
            DebugLine("HandleILVGetDescriptor-");
            */
        }
        #endregion

        #region private void HandleILVMessageCommandCMD(MSUSBMessage msg)
        /// <summary>
        /// Helper function called when a MESSAGE_COMMAND_CMD is found within an
        /// Asynchronous Message ILV recevied by the CN3PIV object.  Adjusts UI
        /// to tell user what to do with his finger to complete the fingerprint
        /// grab.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing MESSAGE_COMMAND_CMD ILV.</param>
        private void HandleILVMessageCommandCMD(MSUSBMessage msg)
        {
            DebugLine("HandleILVMessageCommandCMD+");
            byte[] pui8V = msg.V;

            uint ui32Command = pui8V[3];
            ui32Command <<= 8;
            ui32Command += pui8V[2];
            ui32Command <<= 8;
            ui32Command += pui8V[1];
            ui32Command <<= 8;
            ui32Command += pui8V[0];
            switch (ui32Command)
            {
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_MOVE_NO_FINGER:
                    DebugLine("No Finger");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_MOVE_FINGER_UP:
                    DebugLine("Move Up");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_MOVE_FINGER_DOWN:
                    DebugLine("Move Down");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_MOVE_FINGER_LEFT:
                    DebugLine("Move Left");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_MOVE_FINGER_RIGHT:
                    DebugLine("Move Right");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_PRESS_FINGER_HARDER:
                    DebugLine("Press Harder");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_LATENT:
                    DebugLine("Latent");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_REMOVE_FINGER:
                    DebugLine("Remove Finger");
                    break;
                case MSUSBMessage.ILV.MessageCommandCmd.MORPHO_FINGER_OK:
                    DebugLine("Finger OK");
                    break;
                default:
                    DebugLine("Command " + ui32Command.ToString() + " unknown");
                    break;
            }
            DebugLine("HandleILVMessageCommandCMD-");
        }
        #endregion


        #region private void HandleILVMessageImageCMD(MSUSBMessage msg)
        /// <summary>
        /// Helper function called when a MESSAGE_IMAGE_CMD is found within an
        /// Asynchronous Message ILV recevied by the CN3PIV object.  Adjusts UI
        /// to show fingerprint preview image received in message.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing MESSAGE_IMAGE_CMD ILV.</param>
        private void HandleILVMessageImageCMD(MSUSBMessage msg)
        {
            DebugLine("HandleILVMessageImageCMD+");

            //
            // create .bmp image in memory
            //
            byte[] bmp = m_cn3piv.ILV2BMP(msg, 0);

            //
            // now create a memory stream from the image file in memory and
            // read the bitmap file from it.
            //
            MemoryStream bmpStream = new MemoryStream(bmp);
//            Size size = new Size(120, 120);
            pictureBoxScan.Image = new Bitmap(bmpStream);
//            pictureBoxScan.Size = size;

            DebugLine("HandleILVMessageImageCMD-");
        }
        #endregion


        #region private void HandleILVAsynchronousMessage(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleILVAsynchronousMessage
        /// delegate.  This function is invoked on the application UI thread by
        /// the CN3PIV object when an Asynchronous Message ILV is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage containing Asynchronous Message ILV.</param>
        private void HandleILVAsynchronousMessage(MSUSBMessage msg)
        {
            DebugLine("HandleILVAsynchronousMessage+");
            ulong ui64L = msg.L;
            uint ui32L = (uint)ui64L;
            uint ui32LBytes = (uint)(ui64L >> 32);

            if (msg.V[0] == MSUSBMessage.ILV.ILV_OK)
            {
                ArrayList ilvs = msg.GetILVList(1);
                DebugLine("ILV_OK (" + ilvs.Count.ToString() + " ILVs)");
                for (int i = 0; i < ilvs.Count; i++)
                {
                    MSUSBMessage m = (MSUSBMessage)ilvs[i];
                    switch (m.I)
                    {
                        case MSUSBMessage.ILV.MESSAGE_COMMAND_CMD:
                            HandleILVMessageCommandCMD(m);
                            break;
                        case MSUSBMessage.ILV.MESSAGE_IMAGE_CMD:
                            HandleILVMessageImageCMD(m);
                            break;
                        default:
                            DebugLine("MESSAGE_?_CMD " + m.I.ToString("X2"));
                            break;
                    }
                }
            }
            else
            {
                DebugLine("ILV_ERROR");
            }
            DebugLine("HandleILVAsynchronousMessage-");
        }
        #endregion

        #region private void HandleILVOther(MSUSBMessage msg)
        /// <summary>
        /// Function registered to CN3PIV object's HandleILVOther delegate.  This
        /// function is invoked on the application UI thread by the CN3PIV object
        /// when a Sagem message other than those defined by their own delegate
        /// is received.
        /// </summary>
        /// <param name="msg">MSUSBMessage received by CN3PIV object.</param>
        private void HandleILVOther(MSUSBMessage msg)
        {
            // ulong ui64L = msg.L;
            //uint ui32L = (uint)ui64L;
            // uint ui32LBytes = (uint)(ui64L >> 32);
           // DebugLine("Other: " + msg.I.ToString("X2") + " " + ui32L.ToString("X8") + " (" + ui32LBytes.ToString() + ")");
        }
        #endregion

        #region private void HandleResume(PowerState state)
        /// <summary>
        /// "Resume" power control event handler, called when the \ref
        /// ResumeNotifier object detects a resume event.
        /// </summary>
        /// <param name="state">\ref PowerState variable as sent from \ref
        /// ResumeNotifier object.</param>
        private void HandleResume(PowerState state)
        {/*
            DebugLine("Resume");
            DebugLine(" PowerState " + ((uint)(state)).ToString("X8"));
            if ((state & PowerState.POWER_STATE_ON) == PowerState.POWER_STATE_ON)
            {
                DebugLine("  On");
            }
            if ((state & PowerState.POWER_STATE_OFF) == PowerState.POWER_STATE_OFF)
            {
                DebugLine("  Off");
            }
            if ((state & PowerState.POWER_STATE_CRITICAL) == PowerState.POWER_STATE_CRITICAL)
            {
                DebugLine("  Crit");
            }
            if ((state & PowerState.POWER_STATE_BOOT) == PowerState.POWER_STATE_BOOT)
            {
                DebugLine("  Boot");
            }
            if ((state & PowerState.POWER_STATE_IDLE) == PowerState.POWER_STATE_IDLE)
            {
                DebugLine("  Idle");
            }
            if ((state & PowerState.POWER_STATE_SUSPEND) == PowerState.POWER_STATE_SUSPEND)
            {
                DebugLine("  Suspend");
            }
            if ((state & PowerState.POWER_STATE_RESET) == PowerState.POWER_STATE_RESET)
            {
                DebugLine("  Reset");
            }
            DebugLine("");

            UpdateSagemPortList();
            UpdateMSRPortList();
            UpdateDBUI();
            UpdateMSRUI();
            PIVMSRCheckBox.Checked = false;
            PIVFPRCheckBox.Checked = false;
            PIVSCRCheckBox.Checked = false;
            UpdatePIVUI();
          */
        }
        #endregion

        #region private void DoVerify()
        /// <summary>
        /// Helper function which checks UI elements and begins an 'ENROLL'
        /// cycle, which grabs a fingerprint from the Sagem device.  Registers
        /// 'handle enroll message by searching database' handler with the
        /// CN3PIV 'HandleILVEnroll' delegate to handle fingerprint response,
        /// so that fingerprint minutiae data is searched for in database.
        /// </summary>
        private CN3PIV.Error DoVerify(ushort ui16Timeout)
        {
            //DisableDBUI();
            //DBNameTextBox.Text = "";
            m_cn3piv.HandleILVEnroll += HandleILVEnrollSearchDatabase;
            //ushort ui16Timeout = 0;
            //if(DBTimeoutCheckbox.Checked)
            //{
            //  ui16Timeout = (ushort)(DBTimeoutUpDown.Value);
            //}
            CN3PIV.Error err = m_cn3piv.SendILVEnroll(ui16Timeout, 1, 1,
              MSUSBMessage.ILV.MESSAGE_COMMAND_CMD | MSUSBMessage.ILV.MESSAGE_IMAGE_CMD,
              (byte)MSUSBMessage.ILV.BiometricAlgorithmParameter.PK_COMP, true);
            if (err != CN3PIV.Error.None)
            {
                MessageBox.Show("Error sending FPR command", err.ToString());
                m_cn3piv.HandleILVEnroll -= HandleILVEnrollSearchDatabase;
                //UpdateDBUI();
            }
            return err;
        }
        #endregion

        #region private void DoEnroll()
        /// <summary>
        /// Helper function which checks UI elements and begins an 'ENROLL'
        /// cycle, which grabs a fingerprint from the Sagem device.  Registers
        /// 'handle enroll message by adding to database' handler with the
        /// CN3PIV 'HandleILVEnroll' delegate to handle fingerprint response,
        /// so that fingerprint data is added to database.
        /// </summary>
        private CN3PIV.Error DoEnroll(ushort ui16Timeout)
        {

            m_cn3piv.HandleILVEnroll += HandleILVEnrollAddToDatabase;
            CN3PIV.Error err = m_cn3piv.SendILVEnroll(ui16Timeout, 1, 1,
              MSUSBMessage.ILV.MESSAGE_COMMAND_CMD | MSUSBMessage.ILV.MESSAGE_IMAGE_CMD,
              (byte)MSUSBMessage.ILV.BiometricAlgorithmParameter.PK_COMP, true);
            if (err != CN3PIV.Error.None)
            {
                // MessageBox.Show("Error sending FPR command", err.ToString());
                m_cn3piv.HandleILVEnroll -= HandleILVEnrollAddToDatabase;
                //UpdateDBUI();
            }
            return err;
        }
        #endregion

   

        #endregion // Methods



        #region Members
        /// <summary>
        /// The one and only CN3 PIV object encapsulates all the hardware.
        /// </summary>
        CN3PIV m_cn3piv;

        /// <summary>
        /// String which holds the MS unit firmware version
        /// </summary>
        string m_msusbVersionString;

        /// <summary>
        /// Array list of 'database' entries.
        /// </summary>
        ArrayList m_entries;

        /// <summary>
        /// MSUSB message containing ILV with minutiae we're tyring to match.
        /// </summary>
        MSUSBMessage m_searchTemplate;

        /// <summary>
        /// Index into database of match we're currently trying.
        /// </summary>
        int m_verifyMatchIndex;

        String MyPDF_a,Rut_a,ApellidoPaterno_a;
        byte[] minucia_a;
        Stream fingerPDF_a;
        int finger_a;
        String myFileName_a;


        int contador_a;
        int wsqVersion_a;
        SQLiteConnection sqlConn_a;
        FormDebug myformdebug_a;
        FormAcerca myformacerca_a;
        FormPDF myformpdf_a;
        FormEstado myformEstado_a ;
        FormEnroll myformEnroll_a ;

#endregion


        
        public FormInicio()
        {
            InitializeComponent();

            minucia_a = new byte[342];
            m_cn3piv = new CN3PIV(this);
            myformdebug_a = new FormDebug();
            myformacerca_a = new FormAcerca();
            myformpdf_a = new FormPDF();
            myformEstado_a = new FormEstado();
            myformEnroll_a = new FormEnroll();


            string labelAcerca;

            labelAcerca = "INGENIERIA SOLEM S.A.\r\n";
            labelAcerca = "S100-TDM version "+version_a+"\r\n";
            labelAcerca = "WSQ Version " + wsqVersion_a + "\r\n";
            labelAcerca = "http://www.solem.cl" + "\r\n";
            labelAcerca = "Contacto info@solem.cl" + "\r\n";
            labelAcerca = "Contacto Técnico rsotomayor@savtec.cl" + "\r\n";


            myformacerca_a.setLabelAcerca(labelAcerca);
            m_cn3piv.HandleMSRMessage += HandleMSRMessage;
            m_cn3piv.HandleMSRMessagePing += HandleMSRMessagePing;
            m_cn3piv.HandleMSRMessageDataClear += HandleMSRMessageDataClear;
            m_cn3piv.HandleMSRMessagePower += HandleMSRMessagePower;
            m_cn3piv.HandleMSRReadException += HandleMSRReadException;

            m_cn3piv.HandleILVVerifyMatch += HandleILVVerifyMatch;

            m_cn3piv.HandleILVGetDescriptor += HandleILVGetDescriptor;
            m_cn3piv.HandleILVAsynchronousMessage += HandleILVAsynchronousMessage;
            m_cn3piv.HandleILVOther += HandleILVOther;
      
            m_cn3piv.HandleMSRMessageTrack1Data += HandleMSRMessageTrack1Data;
            m_cn3piv.HandleMSRMessageTrack2Data += HandleMSRMessageTrack2Data;
            m_cn3piv.HandleMSRMessageTrack3Data += HandleMSRMessageTrack3Data;
            m_cn3piv.HandleSagemMessage += HandleSagemMessage;
            m_cn3piv.HandleSagemReadException += HandleSagemReadException;
            m_cn3piv.HandleResume += HandleResume;

            wsqVersion_a = 0;
            try
            {
                wsqVersion_a = m_cn3piv.GetWSQDLLVersion();
            }
            catch
            {
            }
            if (wsqVersion_a != 0)
            {
                string s = "";
                byte b = (byte)((wsqVersion_a >> 24) & 0x000000FF);
                if (b != 0)
                {
                    s += b.ToString();
                }
                b = (byte)((wsqVersion_a >> 16) & 0x000000FF);
                s += b.ToString() + ".";
                b = (byte)((wsqVersion_a >> 8) & 0x000000FF);
                s += b.ToString();
                b = (byte)((wsqVersion_a) & 0x000000FF);
                s += b.ToString();
                labelRespuesta.Text = "wsq.dll version " + s + " sw-ver: " + version_a;
                myformdebug_a.ingresaItem(labelRespuesta.Text);
            }
            else
            {
                labelRespuesta.Text = "wsq.dll no encontrada" + " sw-ver: " + version_a; ;
                myformdebug_a.ingresaItem(labelRespuesta.Text);
            }
            sqlConn_a = new SQLiteConnection();
            sqlConn_a.ConnectionString = "Data Source=s100.db";
            sqlConn_a.Open();


        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            sqlConn_a.Close();
            m_cn3piv.CloseAndStopAll();
            System.Windows.Forms.Application.Exit();
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            m_cn3piv.OpenMSR();

            if (!m_cn3piv.MSRIsOpen)
            {
                MessageBox.Show("Error opening MSR " + m_cn3piv.MSRPortName, "Error");
                menuItemEdgeLineConectar.Enabled = true; 
            }
            else
            {
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPing();

#warning <Why Are These Pings Necessary?>
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPing();
                m_cn3piv.SendMSRPowerSet(true, false, true);
                int iCount = 0;
                do
                {
                    System.Threading.Thread.Sleep(250);
                    iCount++;
                    DebugLine(" fpr port " + m_cn3piv.SagemPortName);
                    m_cn3piv.OpenSagem();
                    DebugLine(" fpr port " + m_cn3piv.SagemPortName);
                } while ((iCount < 20) && (!m_cn3piv.SagemIsOpen));
                DebugLine(" iCount " + iCount.ToString());
                if (m_cn3piv.SagemIsOpen)
                {
                    DebugLine(" FPR open");
                    m_cn3piv.SendILVGetDescriptor(MSUSBMessage.ILV.ID_FORMAT_BIN_VERSION);
                    menuItemEdgeLineConectar.Enabled = false;
                    menuItemEdgeLineDesconectar.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Error opening FPR " + m_cn3piv.SagemPortName, "Error");
                }




                /*
                CN3PIV.Error err = m_cn3piv.SendILVGetDescriptor(MSUSBMessage.ILV.ID_FORMAT_BIN_VERSION);
                if (err != CN3PIV.Error.None)
                {
                    MessageBox.Show("Error pinging FPR.", err.ToString());
                    // UpdateDBUI();
                }

                */

            }

        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            menuItemEdgeLineConectar.Enabled = true;
            menuItemEdgeLineDesconectar.Enabled = false;
            KeyPreview = true;
            MyPDF_a = "";
            contador_a = 0;
            labelRespuesta.Focus();
            comboBoxServidor.SelectedIndex = 1;
            comboBoxFinger.SelectedIndex = 1 ;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            Enable_Operaciones();
        }

        private void Enable_Operaciones()
        {

            string myFileName;
            myFileName = "\\SD Card\\s100\\images\\enrolar.bmp";

            Bitmap bitmapenrolar = new Bitmap(myFileName);
            pictureBoxEnrolar.Image = bitmapenrolar;
            pictureBoxEnrolar.Enabled = true;

            myFileName = "\\SD Card\\s100\\images\\verificar.bmp";

            Bitmap bitmapverificar = new Bitmap(myFileName);
            pictureBoxVerificar.Image = bitmapverificar;
            pictureBoxVerificar.Enabled = true;

            myFileName = "\\SD Card\\s100\\images\\identificar.bmp";

            Bitmap bitmapidentificar = new Bitmap(myFileName);
            pictureBoxIdentificar.Image = bitmapidentificar;
            pictureBoxIdentificar.Enabled = true;


        }

        private void Disable_Operaciones()
        {

            string myFileName;
            myFileName = "\\SD Card\\s100\\images\\enrolar-gris.bmp";

            Bitmap bitmapenrolar = new Bitmap(myFileName);
            pictureBoxEnrolar.Image = bitmapenrolar;
            pictureBoxEnrolar.Enabled = false;

            myFileName = "\\SD Card\\s100\\images\\verificar-gris.bmp";

            Bitmap bitmapverificar = new Bitmap(myFileName);
            pictureBoxVerificar.Image = bitmapverificar;
            pictureBoxVerificar.Enabled = false;

            myFileName = "\\SD Card\\s100\\images\\identificar-gris.bmp";

            Bitmap bitmapidentificar = new Bitmap(myFileName);
            pictureBoxIdentificar.Image = bitmapidentificar;
            pictureBoxIdentificar.Enabled = false;


        }


        private void pictureBoxVerificar_Click(object sender, EventArgs e)
        {
            idtransaccion_a = "verificar";
            Disable_Operaciones();
            ushort ui16Timeout = 0;

            CN3PIV.Error err = DoEnroll(ui16Timeout);
            if (err != CN3PIV.Error.None)
            {
                MessageBox.Show("Error sending FPR command", err.ToString());
                Enable_Operaciones();
            }

            

            /*
            m_verifyMatchIndex++;
            DBEntry entry = (DBEntry)(m_entries[m_verifyMatchIndex]);
            MSUSBMessage referenceTemplate = new MSUSBMessage(entry.m_minutiae, MSUSBMessageParser.Error.MSUSB_ERROR_NONE);

            ArrayList referenceTemplates = new ArrayList();
            referenceTemplates.Add(referenceTemplate);

            m_cn3piv.SendILVVerifyMatch(0x0005, m_searchTemplate, referenceTemplates, true);
            */
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            m_cn3piv.CloseSagem();
            m_cn3piv.CloseMSR();
            menuItemEdgeLineConectar.Enabled = true;

        }

        private void pictureBoxIdentificar_Click(object sender, EventArgs e)
        {
            idtransaccion_a = "identificar";
            Disable_Operaciones();
            ushort ui16Timeout = 0;

            CN3PIV.Error err = DoEnroll(ui16Timeout);
            if (err != CN3PIV.Error.None)
            {
                MessageBox.Show("Error sending FPR command", err.ToString());
                Enable_Operaciones();
            }


        }

        private void FormInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRespuesta.Focus();
            contador_a = contador_a + 1;

            if (contador_a < 420)
            {
                MyPDF_a = MyPDF_a + e.KeyChar;
            }
            else
            {
                MyPDF_a = MyPDF_a + e.KeyChar;

                String minucia;
                Rut_a = MyPDF_a.Substring(0, 9);

                Rut_a = Rut_a.Trim();
                Rut_a = Rut_a.Substring(0, Rut_a.Length - 1) + "-" + Rut_a.Substring(Rut_a.Length - 1, 1);
                ApellidoPaterno_a = MyPDF_a.Substring(19, 30);
                // labelRut.Text = "RUT: " + Rut_a;
                // labelNombre.Text = "Nombre: " + ApellidoPaterno_a;
                textBoxNombre.Text = ApellidoPaterno_a;
                textBoxRut.Text = Rut_a;
                minucia =  MyPDF_a.Substring(78, 342);
                minucia_a = System.Text.Encoding.UTF8.GetBytes(minucia);
                Usuario usuario;
                usuario.rut_a = usuario.idusuario_a = Rut_a;
                usuario.apellidos_a = ApellidoPaterno_a;
                usuario.email_a = usuario.nombres_a = "";
                usuario.fechanacimiento_a = "01-01-1980";

                myformEnroll_a.setUsuario(usuario);
                contador_a = 0;
                myformpdf_a.setValoresFromString(MyPDF_a);
                MyPDF_a = "";


                labelRespuesta.Focus();
            }

        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            MyPDF_a = "";
            contador_a = 0;
            labelRespuesta.Focus();
            textBoxNombre.Text = "";
            textBoxRut.Text = "";
            labelRespuesta.Text = "";
            comboBoxServidor.SelectedIndex = 1;
            progressBar1.Value = 0;

        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            myformdebug_a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int idio = 0;

            if (checkBoxES.Checked)
            {
                idio = 0;
            }
            else
            {
                idio = 1;
            }
            String idalternativacasino = "NULL";
            try
            {
                labelRespuesta.Text = Sync.sendCAAC(Rut_a, idio, idalternativacasino);
                myformdebug_a.ingresaItem(labelRespuesta.Text);

            }
            catch
            {
                labelRespuesta.Text = "Error en servidor " + MyGlobal.UnixTimeNow();
                myformdebug_a.ingresaItem(labelRespuesta.Text);

            }

        }

        private void menuItem7_Click_1(object sender, EventArgs e)
        {
            myformacerca_a.Show();
        }

        public string HttpUploadFile(string url, NameValueCollection nvc, tFiles[] myFiles2Upload)
        {
            string retval = "CAAC-KO";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            
            Stream postDataStream = Sync.GetPostStream(nvc, boundary, myFiles2Upload);
            wr.ContentLength = postDataStream.Length;
            this.SetProgress(10);


            Stream rs = wr.GetRequestStream();
            postDataStream.Position = 0;

            byte[] buffer = new byte[1024];
            int bytesRead = 0;

            this.SetProgress(25);
            while ((bytesRead = postDataStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            postDataStream.Close();
            rs.Close();
            this.SetProgress(75);

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                retval = string.Format("Sube OK: {0}", reader2.ReadToEnd());
                wresp.Close();
            }
            catch (Exception ex)
            {
                retval = "Error uploading file" + ex.ToString();
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }


            this.SetProgress(100);
            return retval;
        }

        public void SetProgress(int progress_p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            
            if (this.progressBar1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetProgress);
                this.Invoke(d, new object[] { progress_p });
            }
            else
            {
                progressBar1.Value = progress_p;

            }
        }

        
        private void pictureBoxEnrolar_Click(object sender, EventArgs e)
        {
            idtransaccion_a = "enrolar";
            Disable_Operaciones();
            ushort ui16Timeout = 0;

            CN3PIV.Error err = DoEnroll(ui16Timeout);
            if (err != CN3PIV.Error.None)
            {
                MessageBox.Show("Error sending FPR command", err.ToString());
                Enable_Operaciones();
            }

        }

        private void UploadFinger()
        {

        }

        private void menuItem8_Click_1(object sender, EventArgs e)
        {
            myformpdf_a.Show();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            myformEstado_a.Show();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            myformEnroll_a.Show();
        }




    }
}