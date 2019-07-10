using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Modulo_Capacitacion.Listados.InformedeCompetencias
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            cmbSectores.DataSource = _TraerSectores();
            cmbSectores.DisplayMember = "Descripcion";
            cmbSectores.ValueMember = "Codigo";
            cmbSectores.SelectedIndex = 0;

            cmbPerfiles.DataSource = _TraerPerfiles();
            cmbPerfiles.DisplayMember = "Descripcion";
            cmbPerfiles.ValueMember = "Codigo";
            cmbPerfiles.SelectedIndex = 0;

            rbPorLegajo.Checked = true;
            cmbSectores.Enabled = false;
            cmbPerfiles.Enabled = false;
        }

        private DataTable _TraerSectores()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Codigo", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            tabla.Rows.Add(0, "Todos");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Codigo, Descripcion FROM Sector";

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

        private DataTable _TraerPerfiles()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Codigo", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            tabla.Rows.Add(0, "Todos");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Codigo, Descripcion FROM Tarea WHERE Renglon = 1 and Descripcion <> '' Order by Descripcion";

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

        private VistaPrevia _PrepararReporteII()
        {

            ReportDocument reporte = new imprelegajo();

            if (rbSi.Checked)
            {
                reporte = new imprelegajoii();
            }

            string WFiltroSectores = "{Legajo.Sector} = " + cmbSectores.SelectedValue;

            if (cmbSectores.SelectedIndex == 0)
                WFiltroSectores = "{Legajo.Sector} in 0 to 9999";

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(reporte,
                "{Legajo.Codigo} in 0 to 9999 AND {Legajo.FEgreso} in '' to '00/00/0000' AND " + WFiltroSectores);
            return frm;
        }

        private VistaPrevia _PrepararReporteIII()
        {

            ReportDocument reporte = new imprelegajo();

            if (rbSi.Checked)
            {
                reporte = new imprelegajoii();
            }

            string WFiltro = "{Legajo.Perfil} = " + cmbPerfiles.SelectedValue;

            if (cmbPerfiles.SelectedIndex == 0)
                WFiltro = "{Legajo.Perfil} in 0 to 9999";

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(reporte,
                "{Legajo.Codigo} in 0 to 9999 AND {Legajo.FEgreso} in '' to '00/00/0000' AND " + WFiltro);
            return frm;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                 VistaPrevia frmII;

                if (rbPorLegajo.Checked)
                {
                    frmII = _PrepararReporte();

                }else if (rbPorSector.Checked)
                {
                    frmII = _PrepararReporteII();
                }
                else
                {
                    frmII = _PrepararReporteIII();
                }

                frmII.Show();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private VistaPrevia _PrepararReporte()
        {
            if (TB_Desde.Text == "") TB_Desde.Text = "1";
            if (TB_Hasta.Text == "") TB_Hasta.Text = "9999";

            int Desd;
            int.TryParse(TB_Desde.Text, out Desd);
            int Hast;
            int.TryParse(TB_Hasta.Text, out Hast);

            ReportDocument reporte = new imprelegajo();

            if (rbSi.Checked)
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
            rbSi.Checked = true;
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

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerLegajos();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerLegajos()
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
                        cmd.CommandText = "SELECT Legajo.Codigo, Legajo.Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON Legajo.Descripcion = l2.Descripcion WHERE Legajo.FEgreso IN ('  /  /    ', '00/00/0000') AND Legajo.Renglon = 1 AND Legajo.Descripcion <> '' AND Legajo.Codigo = l2.Actual ORDER BY Legajo.Codigo";

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

        private void rbPorLegajo_Click(object sender, EventArgs e)
        { 
            TB_Desde.Enabled = rbPorLegajo.Checked && !rbPorSector.Checked && !rbPorPerfil.Checked;
            TB_Hasta.Enabled = TB_Desde.Enabled;

            cmbSectores.Enabled = rbPorSector.Enabled;
            cmbPerfiles.Enabled = rbPorPerfil.Enabled;

            if (rbPorLegajo.Checked)
            {
                TB_Desde.Focus();
            }
            else if (rbPorSector.Checked)
            {
                cmbSectores.Focus();
                cmbSectores.DroppedDown = true;
            }
            else
            {
                cmbPerfiles.Focus();
                cmbPerfiles.DroppedDown = true;
            }
        }
    }
}
