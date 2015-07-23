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
    public partial class FormTransacciones : Form
    {
        public FormTransacciones()
        {
            InitializeComponent();
        }

        private void buttonBorraTransacciones_Click(object sender, EventArgs e)
        {

            string message = "Esta Seguro ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result != DialogResult.Yes)
            {
                return;
            }
            buttonBorraTransacciones.Enabled = false;

            String dummyText,szResult1, szResult2;
            Modelo.BorraDataBaseTransaccionesCalzado(out szResult1);
            dummyText = "Borrado : " + szResult1 + "\n";
            Modelo.InitDataBaseTransaccionesCalzado(out szResult2);
            dummyText += "Creando DB : " + szResult2 ;
            consultaNumeroRegistros();
            buttonBorraTransacciones.Enabled = true;

        }

        private void consultaNumeroRegistros()
        {
            int nregistros;
            String szRetval;
            String tableName;

            tableName = Modelo.getTablePrefix() + "TRANSACCIONES";
            Modelo.getNumeroRegistros(tableName, out nregistros, out szRetval);
            labelNImpresiones.Text = "Transacciones: " + nregistros;

            tableName = Modelo.getTablePrefix() + "STOCKDIARY";
            Modelo.getNumeroRegistros(tableName, out nregistros, out szRetval);
            labelNCuentasInventario.Text = "Cuentas Inventario: " + nregistros;

            tableName = Modelo.getTablePrefix() + "POSICION";
            Modelo.getNumeroRegistros(tableName, out nregistros, out szRetval);
            labelNCuentasPosicion.Text = "Cuentas Posicion: " + nregistros;
        }

        private void FormTransacciones_Load(object sender, EventArgs e)
        {
            consultaNumeroRegistros();

        }

        private void buttonIniciaInventario_Click(object sender, EventArgs e)
        {



            string message = "Esta Seguro ?";
            string caption = "Confirmar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result != DialogResult.Yes)
            {
                return;
            }
            buttonIniciaInventario.Enabled = false;

            String szRetval;
            Modelo.InitStockCurrent(out szRetval);
            MessageBox.Show("Init: " + szRetval);

            buttonIniciaInventario.Enabled = true;

        }


    }
}