using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Data.SQLite;
using MyLibrary;




namespace s100_retail
{
    public partial class FormRecogida : Form
    {
        Producto myproducto_a;
        double cantidadRecogida_a;
//        [DllImport("aygshell.sll")]
//        private static extern int SndPlaySync(string path,uint flags);


        public FormRecogida()
        {
            InitializeComponent();
            myproducto_a = new Producto();
        }

        private void FillForm(Producto producto_p)
        {
            labelEAN.Text = producto_p.EAN;
            labelSKU.Text = "SKU: " + producto_p.SKU;
            labelSKU.ForeColor = Color.Red;
            labelDepartamento.Text = "DPTO: " + producto_p.DPTO;
            labelLinea.Text = "LIN: " + producto_p.LINEA;
            labelNombreProducto.Text = producto_p.PROD;
            labelPrecio.Text = "$ " + String.Format("{0:0,0}", producto_p.PRECIO);
            labelStock.Text = "Stock: " + producto_p.stock;
            labelSemanaAntiguedad.Text = "SA : " + producto_p.SemanaAntiguedad;


        }

        private void FillFormClean() 
        {
            labelEAN.Text = "EAN: ";
            labelSKU.Text = "SKU: ";
            labelNombreProducto.Text = "PROD: ";
            labelPrecio.Text = "PRECIO: ";
            labelStock.Text = "Stock: ";
            labelDepartamento.Text = "DPTO: ";
            labelLinea.Text = "LIN: ";
            labelSemanaAntiguedad.Text = "SA : ";
            LabelREAlarma.Text = "";
            LabelREAlarma.ForeColor = Color.Black;
            LabelREAlarma.BackColor = Color.White;
        }


        private void FormRecogida_Load(object sender, EventArgs e)
        {
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }

        private void menuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void setLabelRecogida(Producto producto_p)
        {
            if ( producto_p.flagRecogida == 1)
            {
                String szTipo;

                szTipo = producto_p.tipoRecogida == "P" ? "PARCIAL" : "TOTAL";

                if (producto_p.tipoRecogida== "P")
                {
                    LabelREAlarma.Text = "Recoger " + szTipo + "\n " + cantidadRecogida_a + " / " + producto_p.cantidadRecoger ;
                    if (cantidadRecogida_a < producto_p.cantidadRecoger)
                    {
                        LabelREAlarma.ForeColor = Color.Green;
                        LabelREAlarma.BackColor = Color.White;
                        MyGlobal.MessageBeep(MyGlobal.BeepTypes.Ok);

                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            MyGlobal.MessageBeep(MyGlobal.BeepTypes.IconExclamation);
                        }
                        LabelREAlarma.ForeColor = Color.White;
                        LabelREAlarma.BackColor = Color.Red;
                    }
                }
                else
                {
                    LabelREAlarma.ForeColor = Color.Green;
                    LabelREAlarma.BackColor = Color.White;
                    LabelREAlarma.Text = "Recoger " + szTipo + "\n " + cantidadRecogida_a + " / todas ";
                    MyGlobal.MessageBeep(MyGlobal.BeepTypes.Ok);
                }

            }
            else
            {
                LabelREAlarma.ForeColor = Color.Red;
                LabelREAlarma.BackColor = Color.White;
                LabelREAlarma.Text = "NO RECOGER ";
            }

        }
        private void ButtonConsultar_Click(object sender, EventArgs e)
        {
            LabelREAlarma.ForeColor = Color.Black;
            LabelREAlarma.BackColor = Color.White;

            consultarProducto();
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            FillFormClean();
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();
        }

        private void consultarProducto()
        {
            String szRetval;
            int retval;
            String ean = textBoxBarCode.Text;
            try
            {
                retval = myproducto_a.getRegistroByEan(textBoxBarCode.Text, out szRetval);
            }
            catch
            {
                StatusBar1.Text = "Error en consulta de producto";
                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: NO ENCONTRADO";
                return;
            }


            if ( retval == 0)
            {
                FillForm(myproducto_a);
            }
            else
            {

                FillFormClean();
                labelEAN.Text = ean;
                labelSKU.Text = "SKU: NO ENCONTRADO";
            }
            int cuentaRecogida = 0;
            if (myproducto_a.flagRecogida == 1)
            {

                if (checkBoxMasMenos.Checked == true)
                {
                    cuentaRecogida = 1;
                }
                else
                {
                    cuentaRecogida = -1;
                }
            }

//            MessageBox.Show("Cuenta Recogida " + cuentaRecogida);


            String place;
            if (textBoxUbicacion.Text.Length == 0)
            {
                place = null;
            }
            else
            {
                place = textBoxUbicacion.Text;
            }

            try
            {
                if (checkBoxDiarioTotal.Checked)
                {
                    cantidadRecogida_a = Transacciones.getNumeroEventosDiariosByEAN(myproducto_a.EAN, Constants.RECOGIDA, out szRetval);
                }
                else
                {
                    cantidadRecogida_a = Transacciones.getNumeroEventosByEAN(myproducto_a.EAN, Constants.RECOGIDA, out szRetval);
                }
            }
            catch
            {
                StatusBar1.Text = "Error en consulta de coantidad recogida";
                return;
            }
            // MessageBox.Show("Cantidad Recogida " + cantidadRecogida_a + " : " + szRetval);
            if ( cantidadRecogida_a < myproducto_a.cantidadRecoger  || myproducto_a.tipoRecogida == "T" ||  cuentaRecogida < 0)
            {
                try
                {
                    Etiqueta.registraTransaccion(myproducto_a, Constants.RECOGIDA, place, cuentaRecogida, out szRetval);
                }
                catch
                {
                    StatusBar1.Text = "Error en registrar transaccion";
                    return;
                }
                // MessageBox.Show("Registra Transacción: " + szRetval);

                cantidadRecogida_a += cuentaRecogida ;
            }
            setLabelRecogida(myproducto_a);
            textBoxBarCode.Text = "";
            textBoxBarCode.Focus();


        }

        private void textBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarCode.Text.Length >= Configuracion.EANSIZE)
            {
                LabelREAlarma.ForeColor = Color.Black;
                LabelREAlarma.BackColor = Color.White;
                consultarProducto();
            }
        }

   
    }
}