using System;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            TentativoListaCursos frm = new TentativoListaCursos(txtAno.Text);

            frm.Show(this);
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
            if (e.KeyCode == Keys.Escape) txtAno.Text = "";
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            txtAno.Text = DateTime.Now.Year.ToString();
        }

    }
}
