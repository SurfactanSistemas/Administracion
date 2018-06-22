using System;
using System.Windows.Forms;
using HojaRuta.IngCamiones;
using HojaRuta.IngChoferes;

namespace HojaRuta
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void ingChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inicioChoferes Choferes = new inicioChoferes();
            Choferes.Show();
        }

        private void ingCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicioCamiones Camiones = new InicioCamiones();
            Camiones.Show();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
