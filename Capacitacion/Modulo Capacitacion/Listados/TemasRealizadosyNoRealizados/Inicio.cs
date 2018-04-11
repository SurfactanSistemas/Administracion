using System;
using System.Data;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.TemasRealizadosyNoRealizados
{
    public partial class Inicio : Form
    {
        Cronograma C = new Cronograma();
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_TemaDesde.Text == "") throw new Exception("Se debe ingresar el Tema desde el cual comenzar la busqueda");

                if (TB_TemaHasta.Text == "") TB_TemaHasta.Text = TB_TemaDesde.Text;

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el Año");

                int TemaDesde = 0;

                int.TryParse(TB_TemaDesde.Text, out TemaDesde);

                int TemaHasta = 0;

                int.TryParse(TB_TemaHasta.Text, out TemaHasta);

                int Año = 0;

                int.TryParse(TB_Año.Text, out Año);

                dtInforme = C.CronogramaHoras(Año, TemaDesde, TemaHasta);

                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();


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
                if (TB_TemaDesde.Text == "") throw new Exception("Se debe ingresar el Tema desde el cual comenzar la busqueda");

                if (TB_TemaHasta.Text == "") throw new Exception("Se debe ingresar el Tema hasta el cual terminar la busqueda");

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el Año");

                int TemaDesde = 0;

                int.TryParse(TB_TemaDesde.Text, out TemaDesde);

                int TemaHasta = 0;

                int.TryParse(TB_TemaHasta.Text, out TemaHasta);

                int Año = 0;

                int.TryParse(TB_Año.Text, out Año);

                dtInforme = C.CronogramaHoras(Año, TemaDesde, TemaHasta);

                Tipo = "Impresion";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();


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

        private void TB_TemaDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_TemaHasta.Text == "") TB_TemaHasta.Text = TB_TemaDesde.Text;
                TB_TemaHasta.Focus();
            }
        }

        private void TB_TemaHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Año.Focus();
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_TemaDesde.Focus();
        }
    }
}
