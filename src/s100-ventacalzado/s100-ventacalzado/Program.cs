using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace s100_ventacalzado
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new FormLogin());
        }
    }
}