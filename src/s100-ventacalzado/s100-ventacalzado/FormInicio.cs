using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Net;
using System.Globalization;
using System.Collections.Specialized;
using MyLibrary;
using Microsoft.WindowsMobile.Samples.Location;
using Microsoft.Win32;

namespace s100_ventacalzado
{
    public partial class FormInicio : Form
    {
        public String version_g = "v 1.1.0-rc3";

        delegate void SetGPSPositionCallback(String message_p);
        private EventHandler updateDataHandler;

        GpsDeviceState device = null;
        GpsPosition position = null;
        public Gps mygps_a = new Gps();
        DateTime tStartMuestreo_a;

        public FormInicio()
        {
            InitializeComponent();
        }

        void UpdateData(object sender, System.EventArgs args)
        {
       
            if (mygps_a.Opened)
            {
                string str = "";
                if (device != null)
                {
                    str = device.FriendlyName + " " + device.ServiceState + ", " + device.DeviceState + "\n";
                }


                if (position != null)
                {
                      if (position.LatitudeValid)
                    {
                        str += "Lat (DD):" + position.Latitude + "\n";
                        // str += "Latitude (D,M,S):\n   " + position.LatitudeInDegreesMinutesSeconds + "\n";
                        MyGlobal.latitud_a = position.Latitude;
                    }

                    if (position.LongitudeValid)
                    {
                        str += "Long(DD):" + position.Longitude + "\n";
                        // str += "Longitude (D,M,S):\n   " + position.LongitudeInDegreesMinutesSeconds + "\n";
                        MyGlobal.longitud_a = position.Longitude;
                    }

                    if (position.SpeedValid)
                    {
                        str += "Speed:" + position.Speed + "\n";
                        MyGlobal.velocidad_a = position.Speed;

                    }
                    if (position.SeaLevelAltitudeValid)
                    {
                        str += "SeaLevelAltitude (M):" + position.SeaLevelAltitude + "\n";
                        MyGlobal.altura_a = position.SeaLevelAltitude;

                    }

                    if (position.SatellitesInSolutionValid &&
                        position.SatellitesInViewValid &&
                        position.SatelliteCountValid)
                    {
                        // str += "Satellite Count:\n   " + position.GetSatellitesInSolution().Length + "/" +
                        //    position.GetSatellitesInView().Length + " (" +
                        //    position.SatelliteCount + ")\n";
                    }

                    if (position.TimeValid)
                    {
                        str += "Time: " + position.Time.ToString() + "\n";
                        MyGlobal.tsgps_a = (long) MyGlobal.DateTimeToUnixTime(position.Time);
                    }
                }

                labelStatus.Text = str;

            }
          
        }

        protected void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            position = args.Position;

            // call the UpdateData method via the updateDataHandler so that we
            // update the UI on the UI thread
            Invoke(updateDataHandler);

        }

        void gps_DeviceStateChanged(object sender, DeviceStateChangedEventArgs args)
        {
            device = args.DeviceState;

            // call the UpdateData method via the updateDataHandler so that we
            // update the UI on the UI thread
            Invoke(updateDataHandler);
        }

        public void setInicioOperacion()
        {


        }

        private void llenaComboBoxBodegas(string idlocal_p)
        {
            SQLiteConnection sqlConn;
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
                return;
            }

            String table = Modelo.getTablePrefix() + "bodegas";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT idbodega,descripcion ";
            mycommand.CommandText += "FROM " + table + " ";
            mycommand.CommandText += "WHERE idlocal = '" + idlocal_p +"' ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                comboBoxBodega.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    comboBoxBodega.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                comboBoxBodega.Items.Clear();
                // comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

            labelVersion.Text = version_g;
            String myResponse;
            if ( Configuracion.getIdUsuario() == "admin" ) {
                menuItemSolicitudes.Enabled = false;
                menuItemConsultas.Enabled = false;
                menuItemMovimientos.Enabled = false;
                menuItemInventario.Enabled = false;
                menuItemSincronizacion.Enabled = true;
            } else {
                Configuracion.readConfiguracion();

                if (Modelo.initCarroCompras(out myResponse) < 0)
                {
                    MessageBox.Show("CarroCompras: " + myResponse);
                }

                if (Modelo.InitDataBaseTransaccionesCalzado(out myResponse) < 0)
                {
                    MessageBox.Show("Transacciones: " + myResponse);
                }

                llenaComboBoxBodegas(Configuracion.getIdLocation());

                if ( Configuracion.getIdRol() == "ORDEN" ) {
                    menuItemSolicitudes.Enabled = false;
                    menuItemConsultas.Enabled = false;
                }

            }

            // Inicio en operaci�n normal
            updateDataHandler = new EventHandler(UpdateData);
            mygps_a.DeviceStateChanged += new DeviceStateChangedEventHandler(gps_DeviceStateChanged);
            mygps_a.LocationChanged += new LocationChangedEventHandler(gps_LocationChanged);
            labelTienda.Text = "Tienda: " + Configuracion.getLocation();
            labelUsuario.Text = "Usuario: " + Configuracion.getIdUsuario();
            // String szRetval;
            // MyLibrary.Impresora.iniciarImpresora(out szRetval);
            // StatusBarInicio.Text = szRetval;
            setInicioOperacion();

        }

        private void menuItemGpsEnabled_Click(object sender, EventArgs e)
        {
            try
            {
                mygps_a.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (mygps_a.Opened)
            {
                //---disable the Connect GPS menu item---
                menuItemGpsEnabled.Enabled = false;
                //---enable the Disconnect menu item---
                menuItemGpsDisabled.Enabled = true;
                tStartMuestreo_a = DateTime.Now;
              }
            else
            {
                MessageBox.Show("Failed to Open");
            }
        }

        private void menuItemGpsDisabled_Click(object sender, EventArgs e)
        {
            try
            {
                mygps_a.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            //---disable the Connect GPS menu item---
            menuItemGpsEnabled.Enabled = true;
            //---enable the Disconnect menu item---
            menuItemGpsDisabled.Enabled = false;
        }

        public void getInfoDispositivo()
        {
            float aTotalMem;
            float anUsedMem;
            float aFreeMem;

            MemoryStatus.GetAvailableMemory(out aTotalMem, out anUsedMem, out aFreeMem);

            String dummyText;
            dummyText  = "Memoria \n";
            dummyText += "Total :" + aTotalMem.ToString("F4",CultureInfo.CreateSpecificCulture("es-MX")) + "\n";
            dummyText += "Usada :" + anUsedMem.ToString("F2", CultureInfo.CreateSpecificCulture("es-MX"))+ " " ;
            dummyText += "Libre :" + aFreeMem.ToString("F2", CultureInfo.CreateSpecificCulture("es-MX")) + "\n";
            String IMEI;

            IMEI = PhoneInfo.GetIMEI();
 
            dummyText += "IMEI: " + IMEI + "\n";

            labelRecursos.Text = dummyText;
            String latitud, longitud, velocidad, altura;
            latitud   = MyGlobal.latitud_a.ToString("F4", CultureInfo.CreateSpecificCulture("es-MX"));
            longitud  = MyGlobal.longitud_a.ToString("F4", CultureInfo.CreateSpecificCulture("es-MX"));
            velocidad = MyGlobal.velocidad_a.ToString("F1", CultureInfo.CreateSpecificCulture("es-MX"));
            altura    = MyGlobal.altura_a.ToString("F1", CultureInfo.CreateSpecificCulture("es-MX"));

            labelGeo.Text = "Geo: ( " + latitud + "," + longitud + ")\n";
            labelGeo.Text += "Speed,Alt: ( " + velocidad + "," + altura + ")";
        }

        private void buttonActivacion_Click(object sender, EventArgs e)
        {
            buttonActivacion.Enabled = false;


            string message = "Esta Seguro ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result != DialogResult.Yes) {
                  return;
            }

            String IMEI;

            IMEI = PhoneInfo.GetIMEI();

            String idSoftware = "s100-retail";
            String resultado;
            // Lo que esta comentado es para auth remota
            NameValueCollection nvc = new NameValueCollection();
            if (buttonActivacion.Text == "Solicitar Activaci�n" )
            {
                nvc.Add("wsname", "getActivacion");
            }
            else
            {
                nvc.Add("wsname", "getDesActivacion");
            }

            nvc.Add("iddispositivo", IMEI);
            nvc.Add("idsoftware", idSoftware);
            nvc.Add("nombre", textBoxNombre.Text);
            nvc.Add("organizacion", textBoxOrganizacion.Text);
            nvc.Add("email", textBoxEmail.Text);

            long ts;
            ts = MyGlobal.UnixTimeNow();
            nvc.Add("ts", ts.ToString());

            string response="KO";
            string urlPost = "http://savtec.rso.cl/apps/src/ws/wsgateway.php";


            try
            {
                response = Sync.HttpPost(urlPost, nvc);
            }
            catch
            {
                labelActivacion.Text = "Problemas en la conexi�n \n";
                labelActivacion.Text += response;
                buttonActivacion.Enabled = true;
                return;
            }
   

            labelActivacion.Text = response;
            if (response.IndexOf("OK", 0) > 0)
            {
                if (buttonActivacion.Text == "Solicitar Activaci�n")
                {
                    String feed = IMEI + idSoftware;
                    String clave;
                    clave = MyGlobal.getMD5Hash(feed); // no es muy buena la clave, pero sirve

                    if (Configuracion.guardarParametro("keyactivacion", clave, out resultado) < 0)
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        Configuracion.guardarParametro("keynombre", textBoxNombre.Text, out resultado);
                        Configuracion.guardarParametro("keyemail", textBoxEmail.Text, out resultado);
                        Configuracion.guardarParametro("keyorganizacion", textBoxOrganizacion.Text, out resultado);
                        labelActivacion.Text += "Clave guardada localmente, salga del programa e ingrese nuevamente";
                        buttonActivacion.Text = "Desactivar producto";
                        textBoxNombre.ReadOnly =true;
                        textBoxOrganizacion.ReadOnly = true;
                        textBoxEmail.ReadOnly = true;
                    }
    
                }
                else
                {
                    if (Configuracion.guardarParametro("keyactivacion", "NO ACTIVADO", out resultado) < 0)
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        labelActivacion.Text += "Clave desactivada";
                        buttonActivacion.Text = "Solicitar Activaci�n";
                        textBoxNombre.ReadOnly = false;
                        textBoxOrganizacion.ReadOnly = false;
                        textBoxEmail.ReadOnly = false;
                    }

                }
            }
            buttonActivacion.Enabled = true;
        }



        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            if (mygps_a.Opened)
            {
                mygps_a.Close();
            }
            System.Windows.Forms.Application.Exit();
        }


        private void menuItemInventario_Click(object sender, EventArgs e)
        {
            FormInventario myformInventario_a = new FormInventario();
            myformInventario_a.ShowDialog();
        }

        private void menuItemSincronizacion_Click(object sender, EventArgs e)
        {
            FormSincronizacion myformSincronizacion_a = new FormSincronizacion(this);
            myformSincronizacion_a.ShowDialog();
        }

        private void tabControlInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlInicio.SelectedIndex == 2)
            {
                if (Configuracion.getEstadoActivacion("s100-retail") == false)
                {

                    textBoxNombre.ReadOnly = false;
                    textBoxOrganizacion.ReadOnly = false;
                    textBoxEmail.ReadOnly = false;

                    textBoxNombre.Text = null;
                    textBoxOrganizacion.Text = null;
                    textBoxEmail.Text = null;

                    labelActivacion.Text = "Producto no esta activado, \n";
                    labelActivacion.Text += "conectarse a Internet y \n";
                    labelActivacion.Text += "solicitar activaci�n\n";
                }
                else
                {
                    String keynombre, keyemail, keyorganizacion;
                    Configuracion.getRegistroConfiguracion("keynombre", out keynombre);
                    Configuracion.getRegistroConfiguracion("keyemail", out keyemail);
                    Configuracion.getRegistroConfiguracion("keyorganizacion", out keyorganizacion);
                    buttonActivacion.Text = "Desactivar producto";
                    textBoxNombre.Text = keynombre;
                    textBoxOrganizacion.Text = keyorganizacion;
                    textBoxEmail.Text = keyemail;

                    textBoxNombre.ReadOnly = true;
                    textBoxOrganizacion.ReadOnly = true;
                    textBoxEmail.ReadOnly = true;

                }
            }
            else if (tabControlInicio.SelectedIndex == 1)
            {
                try
                {
                    getInfoDispositivo();
                }
                catch
                {
                    StatusBarInicio.Text = "Error en info dispositivo";
                }
            }
        }
        /*
        private void timerInicio_Tick(object sender, EventArgs e)
        {
            try
            {
                getInfoDispositivo();
            }
            catch
            {
                StatusBarInicio.Text = "Error en info dispositivo";
            }

            try
            {
                if (mygps_a.Opened && Configuracion.getFlagLogGPS())
                {
                    String szRetval;
                    long TS;
                    String iddispositivo = Configuracion.getIdDispositivo();
                    String idusuario = Configuracion.getIdUsuario();

                    DateTime tNow = DateTime.Now;
                    TimeSpan diffTime = tNow - tStartMuestreo_a;
                    if (diffTime.Seconds >= Configuracion.getTimeOutLogGPS())
                    {
                        TS = MyGlobal.UnixTimeNow();
                        String ID = "TPOS" + "-" + TS + "-" + iddispositivo + "-" + idusuario;
                        ID = MyGlobal.getMD5Hash(ID);
                        Modelo.registraEvento(ID, TS, "TPOS", out szRetval);
                        tStartMuestreo_a = tNow;
                        string dummy;
                        dummy = String.Format("{0:hh:mm:ss}", tNow) + ": TPOS" + szRetval;
                        // listBoxRegistro.Items.Insert(0, dummy);
                    }

                }
            }
            catch
            {
                StatusBarInicio.Text = "Error en info GPS";
            }
        }
        */

        private void FormInicio_Closed(object sender, EventArgs e)
        {
            if (mygps_a.Opened)
            {
                mygps_a.Close();
            }
            System.Windows.Forms.Application.Exit();
        }


        private void menuItemSolicitudes_Click(object sender, EventArgs e)
        {
            FormSolicitud myFormSolicitud = new FormSolicitud();
            myFormSolicitud.ShowDialog();
        }

        private void menuItemMovimientosEntradaSalida_Click(object sender, EventArgs e)
        {
            if (Configuracion.getIdBodega() == null)
            {
                MessageBox.Show("Debe seleccionar bodega");
                return;
            }
            FormEntradaSalida myFormEntradaSalida = new FormEntradaSalida();
            myFormEntradaSalida.ShowDialog();
        }

        private void menuItemMovimientosBodega_Click(object sender, EventArgs e)
        {
            if (Configuracion.getIdBodega() == null)
            {
                MessageBox.Show("Debe seleccionar bodega");
                return;
            }
            FormMovimiento myFormMovimiento = new FormMovimiento();
            myFormMovimiento.ShowDialog();
        }

        private void menuItemConsultas_Click(object sender, EventArgs e)
        {
            FormConsulta myFormConsulta = new FormConsulta();
            myFormConsulta.ShowDialog();
        }

        private void comboBoxBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            String idbodega = null, bodega;
            if (comboBoxBodega.SelectedItem != null)
            {
                bodega = comboBoxBodega.SelectedItem.ToString();
                Item selectedItem = (Item)comboBoxBodega.SelectedItem;
                idbodega = selectedItem.Value();
                Configuracion.setIdBodega(idbodega);
            }
        }

        private void menuItemInventario_Click_1(object sender, EventArgs e)
        {
            if (Configuracion.getIdBodega() == null)
            {
                MessageBox.Show("Debe seleccionar bodega");
                return;
            }
            FormInventario myFormInventario = new FormInventario();
            myFormInventario.ShowDialog();   
        }


    }
}