using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Modulo_Capacitacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 Inicio = new Form1();
            Inicio.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(Inicio);
        }
    }
}
