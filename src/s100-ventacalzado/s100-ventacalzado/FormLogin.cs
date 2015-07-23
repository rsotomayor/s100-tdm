using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Specialized;
using Microsoft.Win32;

using MyLibrary;

namespace s100_ventacalzado
{

    public partial class FormLogin : Form
    {
        public static FormInicio myFormInicio_a = new FormInicio();

        public FormLogin()
        {
            InitializeComponent();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

 
        private void FormLogin_Load(object sender, EventArgs e)
        {
            Modelo.setTablePrefix("rpycal_");
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string fileConfig = appPath + "\\rpycal_config.db";
            Configuracion.setCurrentPath(appPath);
            Configuracion.setConfiguracionFile(fileConfig);
            String myResponse;
            if (Modelo.InitDataBaseConfiguracion(out myResponse) < 0)
            {
                MessageBox.Show("Configuración: " + myResponse);
            }
            Configuracion.readConfiguracion();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;

            String iddispositivo;
            String idusuario;
            String local;
            String idlocal;
            String a_passwordsha1;
            String a_passwordmd5;
            String myResponse;

            a_passwordsha1 = MyGlobal.getSHA1Hash(textBoxPassword.Text);
            a_passwordmd5 = MyGlobal.getMD5Hash(textBoxPassword.Text);

            iddispositivo = Configuracion.getIdDispositivo();
            idusuario = textBoxUsuario.Text.ToLower();
            if (idusuario == "admin" && textBoxPassword.Text == "admin")
            {
               Configuracion.setLocation("PRINCIPAL");
               Configuracion.setIdLocation("0");
               Configuracion.setIdUsuario(idusuario);
               Modelo.Log("0", idusuario, "LOGIN", "OK", null, out myResponse);
               myFormInicio_a.ShowDialog();
           } else {
               a_passwordsha1 = "sha1:" + a_passwordsha1.ToUpper();
               a_passwordmd5 = "md5:" + a_passwordmd5.ToLower();
               String szRetval;
               MyData.mypeople_a = new People();

               if (MyData.mypeople_a.getAuthUsuario(idusuario, a_passwordsha1, a_passwordmd5, out szRetval) == 0)
               {
                   idlocal = MyData.mypeople_a.idlocation_a;
                   local = MyData.mypeople_a.location_a;

                   Configuracion.setLocation(local);
                   Configuracion.setIdLocation(idlocal);
                   Configuracion.setIdUsuario(idusuario);
                   Configuracion.setIdRol(MyData.mypeople_a.role_a);

                   Configuracion.readConfiguracion();
                   Modelo.Log(idlocal, idusuario, "LOGIN", "OK", null, out myResponse);
                   myFormInicio_a.ShowDialog();
               }
               else
               {
                   MessageBox.Show(szRetval);
                   Modelo.Log("0", idusuario, "LOGIN", "KO", "Acceso denegado", out myResponse);
                   statusBarLogin.Text = "Acceso denegado: " + szRetval;
               }
            }


            buttonLogin.Enabled = true;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (myFormInicio_a.mygps_a.Opened)
            {
                myFormInicio_a.mygps_a.Close();
            }
            System.Windows.Forms.Application.Exit();
        }

    }
}