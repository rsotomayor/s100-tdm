using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace s100_tdm
{
    public partial class FormPDF : Form
    {
        public FormPDF()
        {
            InitializeComponent();
        }

        private void FormPDF_Load(object sender, EventArgs e)
        {
            labelPDFRut.Text = "Rut :";
            labelPDFNumeroSolicitud.Text = "Numero Solicitud: ";
            labelPDFApellidoPaterno.Text = "Apellido Apaterno: ";
            labelPDFCodigoPais.Text = "C�digo Pais: ";
            labelPDFFechaVencimientoCedula.Text = "Fecha Venc C�dula: ";
            labelPDFNumeroSerieCedula.Text = "N�mero Serie C�dula: ";
            labelRegistroDiscapacidad.Text = "Registro Discapacidad: ";
            labelTipoDocumento.Text = "Tipo Documento: ";
            labelLargoMinucia.Text = "Largo Minucia: ";
            labelNumeroDedo.Text = "Numero Dedo: ";
        }

        public void setValoresFromString(String strPDF_p)
        {
            /*
	Inicio	Termino	Largo
Run	0	8	9
Numero Solicitud C�dula	9	19	10
Apellido Paterno	19	49	30
C�digo Pa�s C�dula	49	52	3
Fecha Vencimiento C�dula	52	58	6
N�mero Serie C�dula	58	68	10
Registro Discapacidad	68	69	1
Tipo Documento	69	70	1
Largo Minucia	70	74	4
N�mero dedo	74	78	4
Minucia PC1	78	420	342
            */
            labelPDFRut.Text = "Rut :" + strPDF_p.Substring(0, 9);
            labelPDFNumeroSolicitud.Text = "Numero Sol: " + strPDF_p.Substring(9, 10);
            labelPDFApellidoPaterno.Text = "Apellido Apaterno: " + strPDF_p.Substring(19, 30);
            labelPDFCodigoPais.Text = "C�digo Pais: " + strPDF_p.Substring(49, 3) ;
            labelPDFFechaVencimientoCedula.Text = "Fecha Venc C�dula: " + strPDF_p.Substring(52, 6);
            labelPDFNumeroSerieCedula.Text = "N�mero Serie C�dula: " + strPDF_p.Substring(58, 10);
            labelRegistroDiscapacidad.Text = "Registro Discapacidad: " + strPDF_p.Substring(68, 1);
            labelTipoDocumento.Text = "Tipo Documento: " + strPDF_p.Substring(69, 1);
            labelLargoMinucia.Text = "Largo Minucia: " + strPDF_p.Substring(70, 4);
            labelNumeroDedo.Text = "Numero Dedo: " + strPDF_p.Substring(74, 4); 
            
        }
    }
}