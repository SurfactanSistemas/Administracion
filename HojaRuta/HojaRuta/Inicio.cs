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

        private void hojaDeRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novedades.HojaRuta frm = new Novedades.HojaRuta();
            frm.Show();
        }

        private void listadoVencimientosDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.VencimientoCamiones.Inicio frm = new Listados.VencimientoCamiones.Inicio();
            frm.Show();
        }

        private void listadoDeVencimientosDeChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.VencimientoChoferes.Inicio frm = new Listados.VencimientoChoferes.Inicio();
            frm.Show();
        }

        private void consultaHojaDeRutaCOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novedades.ConsultaHojaRutaCot frm = new Novedades.ConsultaHojaRutaCot();
            frm.Show();
        }

        private void consultaHojaDeRutaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novedades.ConsultaHojaRutaCliente frm = new Novedades.ConsultaHojaRutaCliente();
            frm.Show();
        }
    }
}
