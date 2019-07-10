using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.TemasRealizadosPorSector
{
    public partial class Inicio : Form
    {
        Cursada C = new Cursada();
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
            rbTodos.Checked = true;
            rbSector.Checked = true;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                Tipo = "Pantalla";

                if (TB_Desde.Text.Trim() == "") TB_Desde.Text = "1";
                if (TB_Hasta.Text.Trim() == "") TB_Hasta.Text = "9999";

                if (txtAnioDesde.Text.Replace("/", "").Trim() == "") txtAnioDesde.Text = "01/06" + DateTime.Now.Year;
                if (txtAnioHasta.Text.Replace("/", "").Trim() == "") txtAnioHasta.Text = "31/05" + (DateTime.Now.Year + 1);

                /*
                 * Actualizamos los datos de Programados/No Programados.
                 */
                Helper._ReprocesoCursosProgramadosYNoProgramadosII(txtAnioDesde.Text, txtAnioHasta.Text, int.Parse(TB_Desde.Text), int.Parse(TB_Hasta.Text));

                if (rbSector.Checked)
                {
                    _PresentarReporte(Tipo);

                }else if (rbLegajo.Checked)
                {
                    _PresentarReportePorLegajo(Tipo);
                }
                else
                {
                    _PresentarReportePorTema(Tipo);
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PresentarReportePorTema(string _Tipo)
        {
            try
            {
                int Desd;
                int.TryParse(TB_Desde.Text, out Desd);
                int Hast;
                int.TryParse(TB_Hasta.Text, out Hast);
                
                Helper.PurgarOrdFechaCursadas();

                int AñoDesde = int.Parse(Helper.OrdenarFecha(txtAnioDesde.Text));
                int AñoHasta = int.Parse(Helper.OrdenarFecha(txtAnioHasta.Text));

                Helper.ActualizarCantidadPersonasHoras(txtAnioDesde.Text.Substring(6, 4));

                string WTipoCursada = "";

                if (rbProgramados.Checked)
                {
                    WTipoCursada = "0";

                }
                else if (rbNoProgramados.Checked)
                {
                    WTipoCursada = "1";
                }

                dtInforme = C.ListarCursoporTema(Desd, Hast, AñoDesde, AñoHasta, WTipoCursada);

                CursosRealizadosporTemas.ImpreInforme Impre = new CursosRealizadosporTemas.ImpreInforme(dtInforme, _Tipo);
                Impre.WindowState = FormWindowState.Maximized;
                Impre.Show();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PresentarReportePorLegajo(string _Tipo)
        {
            try
            {
                int LegDesd;
                int.TryParse(TB_Desde.Text, out LegDesd);
                int LegHast;
                int.TryParse(TB_Hasta.Text, out LegHast);

                Helper.PurgarOrdFechaCursadas();

                int AñoDesd = int.Parse(Helper.OrdenarFecha(txtAnioDesde.Text));
                
                int AñoHast = int.Parse(Helper.OrdenarFecha(txtAnioHasta.Text));

                string WTipoCursada = "";

                if (rbProgramados.Checked)
                {
                    WTipoCursada = "0";

                }
                else if (rbNoProgramados.Checked)
                {
                    WTipoCursada = "1";
                }

                DataTable dtCursadas = (new Cursada()).ListarPorLegajo(LegDesd, LegHast, AñoDesd, AñoHast, WTipoCursada);

                dtCursadas.Columns.Add("NHoras", typeof(float));

                dtInforme = dtCursadas.Copy();

                dtInforme.Clear();

                foreach (DataRow fila in dtCursadas.Rows)
                {
                    //CONSULTO POR SI LA ORDEN FECHA TIENE ALGO
                    if (fila[8].ToString() != "  /  /    ")
                    {
                        int Fecha;
                        int.TryParse(fila[11].ToString(), out Fecha);

                        fila["NHoras"] = float.Parse(fila[6].ToString());
                        dtInforme.ImportRow(fila);
                    }
                }

                TemasPorLegajo.ImpreInforme Impre = new TemasPorLegajo.ImpreInforme(dtInforme, _Tipo);
                Impre.WindowState = FormWindowState.Maximized;
                Impre.Show();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PresentarReporte(string _Tipo)
        {
            int Desd;
            int.TryParse(TB_Desde.Text, out Desd);
            int Hast;
            int.TryParse(TB_Hasta.Text, out Hast);
            
            int AñoDesde = int.Parse(Helper.OrdenarFecha(txtAnioDesde.Text));
            int AñoHasta = int.Parse(Helper.OrdenarFecha(txtAnioHasta.Text));

            progressBar1.Value = 0;

            Helper.PurgarOrdFechaCursadas();
            //Helper.ActualizarTipoCursada(ref progressBar1);

            string WTipoCursada = "";

            if (rbProgramados.Checked)
            {
                WTipoCursada = "0";

            }else if (rbNoProgramados.Checked)
            {
                WTipoCursada = "1";
            }
        
            dtInforme = C.ListarCursoporSector(Desd, Hast, AñoDesde, AñoHasta, WTipoCursada);

            progressBar1.Visible = false;

            ImpreInforme Impre = new ImpreInforme(dtInforme, _Tipo);
            Impre.WindowState = FormWindowState.Maximized;
            Impre.Show();
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

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAnioDesde.Focus();
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Tipo = "Impresion";

                _PresentarReporte(Tipo);

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerSectores();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerSectores()
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
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Sector WHERE Descripcion <> '' ORDER BY Codigo";

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

        private void txtAnioDesde_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtAnioDesde.Text.Replace(" ", "").Length < 10) return;
                if (!Helper._FechaValida(txtAnioDesde.Text)) return;

                txtAnioHasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtAnioDesde.Text = "";
            }
	        
        }
    }
}
