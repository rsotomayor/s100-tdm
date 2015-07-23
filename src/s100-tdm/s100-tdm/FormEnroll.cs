using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public struct Usuario
{
    public string nombres_a, apellidos_a;
    public string fechanacimiento_a;
    public string idusuario_a,rut_a;
    public string email_a;
}

namespace s100_tdm
{
    public partial class FormEnroll : Form
    {
        public FormEnroll()
        {
            InitializeComponent();
        }

        private void pictureBoxEnrolar_Click(object sender, EventArgs e)
        {

        }

        private void FormEnroll_Load(object sender, EventArgs e)
        {
            string myFileName;
            myFileName = "\\SD Card\\s100\\images\\enrolar.bmp";

            Bitmap bitmapenrolar = new Bitmap(myFileName);
            pictureBoxEnrolar.Image = bitmapenrolar;
            pictureBoxEnrolar.Enabled = true;
            dateTimePickerFecNacimiento.CustomFormat = "dddd-MMMM-YYYY";



        }


        private void pictureBoxEnrolar_Click_1(object sender, EventArgs e)
        {
            Usuario myUsuario;

            myUsuario.apellidos_a = textBoxApellidos.Text;
            myUsuario.nombres_a = textBoxNombres.Text;
            myUsuario.email_a = textBoxEmail.Text;
            myUsuario.idusuario_a = textBoxCodigo.Text ;
            myUsuario.rut_a = textBoxRut.Text ;
            myUsuario.fechanacimiento_a = dateTimePickerFecNacimiento.Text;

            string myFileName;
            myFileName = "\\SD Card\\s100\\images\\enrolar-gris.bmp";

            Bitmap bitmapenrolar = new Bitmap(myFileName);
            pictureBoxEnrolar.Image = bitmapenrolar;
            pictureBoxEnrolar.Enabled = false;
            labelRespuesta.Text = "Enviando Datos ....";

            string response;
            try
            {
                response = Sync.sendEnroll(myUsuario);
            }
            catch (Exception ex)
            {
                response = "Error en red de datos:" + ex.ToString().Substring(0, 20);
            }

            MessageBox.Show(response);
            myFileName = "\\SD Card\\s100\\images\\enrolar.bmp";

            bitmapenrolar = new Bitmap(myFileName);
            pictureBoxEnrolar.Image = bitmapenrolar;
            pictureBoxEnrolar.Enabled = true;
            labelRespuesta.Text = response;

        }

        public void setUsuario(Usuario usuario_p)
        {
            textBoxApellidos.Text = usuario_p.apellidos_a;
            textBoxNombres.Text = usuario_p.nombres_a;
            textBoxEmail.Text = usuario_p.email_a;
            textBoxRut.Text = usuario_p.rut_a;
            textBoxCodigo.Text = usuario_p.idusuario_a;
            dateTimePickerFecNacimiento.Text = usuario_p.fechanacimiento_a;

        }

    }
}