using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Negocio;

namespace Modulo_Capacitacion.Listados.InformedeCompetencias
{
    public partial class Inicio : Form
    {
        Legajo L = new Legajo();
        DataTable dtInforme;
        string Tipo;
        bool Observ = false;

        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = _PrepararReporte();

                frm.Show();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private VistaPrevia _PrepararReporte()
        {
            if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el perfil desde el que desea comenzar la busqueda");

            if (TB_Hasta.Text == "") TB_Hasta.Text = TB_Desde.Text;

            int Desd;
            int.TryParse(TB_Desde.Text, out Desd);
            int Hast;
            int.TryParse(TB_Hasta.Text, out Hast);

            ReportDocument reporte = new imprelegajo();

            if (CB_Observ.SelectedIndex == 1)
            {
                reporte = new imprelegajoii();
            }

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(reporte,
                "{Legajo.Codigo} in " + Desd + " to " + Hast + " AND {Legajo.FEgreso} in '' to '00/00/0000'");
            return frm;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CB_Observ.SelectedIndex = 0;
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = _PrepararReporte();

                frm.Imprimir();
                
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Hasta.Focus();
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }
    }
}
