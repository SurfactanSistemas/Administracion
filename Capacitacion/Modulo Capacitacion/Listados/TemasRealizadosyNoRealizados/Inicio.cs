using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

                Helper.ActualizarCantidadPersonasHoras(Año.ToString());

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

                Helper.ActualizarCantidadPersonasHoras(Año.ToString());

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

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerTemas();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerTemas()
        {
            try
            {
                DataTable tabla = new DataTable();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Codigo";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                    }

                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        }
    }
}
