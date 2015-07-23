using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyLibrary;

namespace s100_ventacalzado
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            Configuracion.readConfiguracion();
            textBoxUrlPost.Text = Configuracion.getUrlPost();
            textBoxUrlMaestrosPrefix.Text = Configuracion.getUrlMaestroPrefix();
            textBoxIdDevice.Text = Configuracion.getIdDispositivo();
            textBoxDBPath.Text = Configuracion.getDBPath();
            if (Configuracion.getFlagLogGPS())
            {
                checkBoxGpsLog.Checked = true;
            }
            else
            {
                checkBoxGpsLog.Checked = false;
            }

            textBoxTimeoutLogGps.Text = Configuracion.getTimeOutLogGPS().ToString();
            textBoxPacketSize.Text = Configuracion.getPacketSize().ToString();

        }

        private void buttonGrabar_Click(object sender, EventArgs e)
        {
            buttonGrabar.Enabled = false;
            String resultado;

            if (tabControlConfiguracion.SelectedIndex == 0)
            {
                if (Configuracion.guardarParametro("urlpost", textBoxUrlPost.Text, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }
                if (Configuracion.guardarParametro("urlmaestrosprefix", textBoxUrlMaestrosPrefix.Text, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }
                if (Configuracion.guardarParametro("iddispositivo", textBoxIdDevice.Text, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }

                if (Configuracion.guardarParametro("dbpath", textBoxDBPath.Text, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }

                if (Configuracion.guardarParametro("packetsize", textBoxPacketSize.Text, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }

                Configuracion.readConfiguracion();
                statusBar1.Text = "Configuracion Parametros OK " + MyGlobal.UnixTimeNow();
            }
            else if ( tabControlConfiguracion.SelectedIndex == 1 )
            {   
                String flagLogGps;
                if ( checkBoxGpsLog.Checked == true ) {
                    flagLogGps = "true";
                } else {
                    flagLogGps = "false";
                }
                if (Configuracion.guardarParametro("flagloggps", flagLogGps, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }
                if (Configuracion.guardarParametro("timeoutloggps", textBoxTimeoutLogGps.Text, out resultado) < 0)
                {
                    MessageBox.Show(resultado);
                }
                Configuracion.readConfiguracion();
                statusBar1.Text = "Configuracion GPS OK " + MyGlobal.UnixTimeNow();

            }
            buttonGrabar.Enabled = true;
        }


   
    }
}