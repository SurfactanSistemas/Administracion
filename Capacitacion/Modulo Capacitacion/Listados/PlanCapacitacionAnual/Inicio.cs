using System;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnual
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            var frm = _PrepararReporte();
            frm.Show();
        }

        private VistaPrevia _PrepararReporte()
        {
            // Actualizamos los datos de Personas y horas realizadas.
            Helper.ActualizarCantidadPersonasHoras(txtAno.Text);

            VistaPrevia frm = new VistaPrevia();

            frm.CargarReporte(new PlanCapacitacionAnual(), "{CronogramaII.Ano} = " + txtAno.Text);
            return frm;
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            var frm = _PrepararReporte();
            frm.Imprimir();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) txtAno.Text = "";
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
