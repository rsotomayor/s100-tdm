using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MyLibrary;

namespace s100_ventacalzado
{
    public partial class FormMaestros : Form
    {
        public bool cancelarOperacion_a = false;
        delegate void SetAvanceCallback(int value_p, String message_p);
        public FormMaestros()
        {
            InitializeComponent();
        }

        private void SetAvance(int avance_p, String message_p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelSincronizacion.InvokeRequired)
            {
                SetAvanceCallback d = new SetAvanceCallback(SetAvance);
                this.Invoke(d, new object[] { avance_p, message_p });
            }
            else
            {
                this.ProgressBar1.Value = avance_p;
                labelSincronizacion.Text += message_p;
            }
        }
        private void labelSincronizacion_ParentChanged(object sender, EventArgs e)
        {

        }

        private void consultandoBaseDatos()
        {
            String myResponse;
            String dummyText ;
            SetAvance(0, "");
            tOperacion operacion;
            Modelo.getRegistroUltimaOperacion(Configuracion.getIdLocation(), "DOWNLOAD", "OK", out operacion, out myResponse);
            dummyText = "Ultima Sincronizacion:" + "\n";
            DateTime myDateTime = MyGlobal.UnixTimeStampToDateTime(operacion.ts_a);
            dummyText += "Fecha Hora:" + myDateTime.ToShortDateString() + " " + myDateTime.ToShortTimeString() + "\n";
            dummyText += "IdUsuario: " + operacion.idUsuario_a + "\n";
            dummyText += "Nota: " + operacion.nota_a + "\n"; 


            if (cancelarOperacion_a == true)
            {
                cancelarOperacion_a = false;
                return;
            }
            SetAvance(10, dummyText);
            dummyText = "Numero Productos: " + Producto.getNumeroProductos(out myResponse) + "\n";
            if (cancelarOperacion_a == true)
            {
                cancelarOperacion_a = false;
                return;
            }

            
            SetAvance(30, dummyText);
            dummyText = "Numero EAN: " + Producto.getNumeroProductosEan(out myResponse) + "\n";
            if (cancelarOperacion_a == true)
            {
                cancelarOperacion_a = false;
                return;
            }

            SetAvance(50, dummyText);
            dummyText = "FlagEtiquetar: " + Producto.getNumeroProductosByWhere("WHERE flagetiqueta=1", out myResponse) + "\n";
            if (cancelarOperacion_a == true)
            {
                cancelarOperacion_a = false;
                return;
            }

            SetAvance(65, dummyText);
            dummyText = "FlagRevenue: " + Producto.getNumeroProductosByWhere("WHERE flagrevenue=1", out myResponse) + "\n";
            if (cancelarOperacion_a == true)
            {
                cancelarOperacion_a = false;
                return;
            }

            SetAvance(80, dummyText);
            dummyText = "FlagRecogida: " + Producto.getNumeroProductosByWhere("WHERE flagrecogida=1", out myResponse);
            if (cancelarOperacion_a == true)
            {
                cancelarOperacion_a = false;
                return;
            }

            SetAvance(100, dummyText);
            cancelarOperacion_a = false;

        }

        private void FormMaestros_Load(object sender, EventArgs e)
        {
   
            ThreadStart threadDelegate = new ThreadStart(consultandoBaseDatos);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();
            labelSincronizacion.Text = "";

        }

        private void ProgressBar1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            cancelarOperacion_a = true;
        }
    }
}