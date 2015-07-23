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

namespace s100_retail
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

        private void llenaComBoxBox()
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

            String tableLocales = Modelo.getTablePrefix() + "locales";

            mycommand = new SQLiteCommand(sqlConn);
            mycommand.CommandText = "SELECT id,descripcion ";
            mycommand.CommandText = mycommand.CommandText + "FROM " + tableLocales + " ";

            SQLiteDataReader reader;

            try
            {
                reader = mycommand.ExecuteReader();
                reader.Read();
                //                comboBoxLocales.Items.Clear();
                while (reader.HasRows)
                {
                    String id, descripcion;
                    id = reader.GetString(0);
                    descripcion = reader.GetString(1);
                    //                    comboBoxLocales.Items.Add(new Item(id, descripcion));
                    reader.Read();
                }
            }
            catch (SQLiteException myException)
            {
                //                comboBoxLocales.Items.Clear();
                //                comboBoxLocales.Items.Add(new Item("0", "PRINCIPAL"));
                MessageBox.Show("Message: " + myException.Message + "\n");
            }
            sqlConn.Close();

            // Para Seleccionar ComboxBox Item
            //            if (comboBoxLocales.SelectedItem != null)
            //            {
            //                local = comboBoxLocales.SelectedItem.ToString();
            //                Item selectedItem = (Item)comboBoxLocales.SelectedItem;
            //                idlocal = selectedItem.Value();
            //            }
            ////                        idlocal = selectedItem.Value();
            // local = comboBoxLocales.SelectedItem.ToString();

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string fileConfig = appPath + "\\tpm_config.db";
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
            idusuario = textBoxUsuario.Text;
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
                People mypeople = new People();

                if (mypeople.getAuthUsuario(idusuario, a_passwordsha1,a_passwordmd5, out szRetval) == 0)
                {
                    idlocal = mypeople.idlocation_a;
                    local = mypeople.location_a;
                    Configuracion.setLocation(local);
                    Configuracion.setIdLocation(idlocal);
                    Configuracion.setIdUsuario(idusuario);
                    Configuracion.readConfiguracion();
                    Modelo.Log(idlocal, idusuario, "LOGIN", "OK", null, out myResponse);
                    myFormInicio_a.ShowDialog();
                }
                else
                {
                    Modelo.Log("0", idusuario, "LOGIN", "KO", "Acceso denegado", out myResponse);
                    statusBarLogin.Text = "Acceso denegado: " + szRetval;
                    MessageBox.Show(statusBarLogin.Text);
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