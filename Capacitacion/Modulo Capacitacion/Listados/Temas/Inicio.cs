using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Modulo_Capacitacion.Listados.Temas
{
    
    public partial class Inicio : Form
    {

        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") TB_Desde.Text = "1";

                if (TB_Hasta.Text == "") TB_Hasta.Text = "9999";

                ReportDocument reporte = new ListadoTemas();

                VistaPrevia rp = new VistaPrevia();
                rp.CargarReporte(reporte, "{Curso.Codigo}>=" + TB_Desde.Text.Trim() + " AND {Curso.Codigo}<=" + TB_Hasta.Text.Trim() + " AND {Curso.Codigo}>0");
                rp.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") TB_Desde.Text = "1";

                if (TB_Hasta.Text == "") TB_Hasta.Text = "9999";

                ReportDocument reporte = new ListadoTemas();

                VistaPrevia rp = new VistaPrevia();
                rp.CargarReporte(reporte, "{Curso.Codigo}>=" + TB_Desde.Text.Trim() + " AND {Curso.Codigo}<=" + TB_Hasta.Text.Trim() + " AND {Curso.Codigo}>0");
                rp.Imprimir();

                TB_Desde.Text = "";
                TB_Hasta.Text = "";

                TB_Desde.Focus();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_Hasta.Text.Trim() == "")
                    TB_Hasta.Text = TB_Desde.Text;

                TB_Hasta.Focus();

            }else if (e.KeyCode == Keys.Escape)
            {
                TB_Desde.Text = "";
            }
        }

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TB_Hasta.Text = "";
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
