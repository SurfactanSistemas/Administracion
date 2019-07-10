using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            DataTable WSectores = _TraerSectores();

            WSectores.Rows.Add(0, " TODOS");

            WSectores.DefaultView.Sort = "Descripcion";

            cmbSectores.DataSource = WSectores;
            cmbSectores.DisplayMember = "Descripcion";
            cmbSectores.ValueMember = "Codigo";

            txtAno.Text = DateTime.Now.ToString("yyyy");
        }

        private void _ActualizarDefectoLegajos()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                cn.Open();
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;
                    cm.CommandText = "UPDATE Legajo SET Legajo.Sector = Tarea.Sector FROM Legajo, Tarea WHERE Legajo.Perfil = Tarea.Codigo";
                    cm.ExecuteNonQuery();
                }
            }
        }

        private DataTable _TraerSectores()
        {
            DataTable datos = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT Codigo, RTRIM(Descripcion) Descripcion FROM Sector Order by Descripcion";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            datos.Load(dr);
                        }
                    }
                }

            }

            return datos;
        }

        private DataTable _CargarDatosPorAnio(string Año)
        {
            DataTable WDatos = new DataTable();

            try
            {
                _ActualizarDefectoLegajos();

                string WSector = "";

                DataRowView r = (DataRowView) cmbSectores.SelectedItem;

                if (r != null && cmbSectores.SelectedIndex > 0) WSector = "And l.Sector = '" + r["Codigo"] + "'";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT l2.Actual Legajo, l.Descripcion DescLegajo, l.Curso, c.Descripcion DescCurso, cr.Tema, t.Descripcion DescTema, t.Horas, l.Sector, s.Descripcion DescSector FROM Legajo l " +
                                            "INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion AND l.Codigo = l2.Actual " +
                                            "LEFT OUTER JOIN Sector s ON s.Codigo = L.Sector " +
                                            "LEFT OUTER JOIN Curso c on c.Codigo = l.Curso LEFT OUTER JOIN Cronograma cr ON cr.Ano = '" + Año + "' and cr.Curso = l.Curso AND cr.Legajo = l2.Actual " +
                                            "LEFT OUTER JOIN Tema t ON t.Curso = cr.Curso AND t.Tema = cr.Tema WHERE EstaCurso NOT IN (1, 2, 6, 7) AND l.Fegreso IN ('  /  /    ', '00/00/0000') " + WSector + " And l.Sector NOT IN (1000) Order by Legajo, l.Renglon";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                WDatos.Load(dr);
                            }
                        }

                        cmd.CommandText = "SELECT l2.Actual Legajo, l.Descripcion DescLegajo, l.Curso, c.Descripcion DescCurso, cr.Tema2 As Tema, t.Descripcion DescTema, t.Horas, l.Sector, s.Descripcion DescSector FROM Legajo l " +
                                            "INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion AND l.Codigo = l2.Actual " +
                                            "LEFT OUTER JOIN Sector s ON s.Codigo = L.Sector " +
                                            "LEFT OUTER JOIN Curso c on c.Codigo = l.Curso LEFT OUTER JOIN Cronograma cr ON cr.Ano = '" + Año + "' and cr.Curso = l.Curso AND cr.Legajo = l2.Actual " +
                                            "LEFT OUTER JOIN Tema t ON t.Curso = cr.Curso AND t.Tema = cr.Tema2 WHERE EstaCurso NOT IN (1, 2, 6, 7) AND l.Fegreso IN ('  /  /    ', '00/00/0000') And ISNULL(cr.Tema2, 0) <> 0 " + WSector + " And l.Sector NOT IN (1000) Order by Legajo, l.Renglon";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                WDatos.Load(dr);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return WDatos;
        }

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Regex.IsMatch(txtAno.Text, "[^0-9]") && char.IsControl(e.KeyChar);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (txtAno.Text.Trim().Length < 4) return;

            DataTable WDatos = _CargarDatosPorAnio(txtAno.Text);

            ReportDocument rpt = null;

            progressBar1.Value = 0;

            if (rbPlanilla.Checked)
            {
                DataTable WDatosII = new DataTable();

                WDatosII.Columns.Add("Curso", typeof(int));
                WDatosII.Columns.Add("DescCurso");
                WDatosII.Columns.Add("Personas", typeof(int));

                if (WDatos.Rows.Count > 0)
                {
                    progressBar1.Maximum = WDatos.Rows.Count;

                    var WCursos = WDatos.DefaultView.ToTable(true, "Curso", "DescCurso");

                    foreach (DataRow WCurso in WCursos.Select("", "Curso ASC"))
                    {
                        if (int.Parse(WCurso["Curso"].ToString()) > 0)
                        {
                            DataRow r = WDatosII.NewRow();

                            var WPersonas = WDatos.Select("Curso = '" + WCurso["Curso"] + "'").ToArray().Count();

                            r["Curso"] = WCurso["Curso"];
                            r["DescCurso"] = WCurso["DescCurso"];
                            r["Personas"] = WPersonas;

                            WDatosII.Rows.Add(r);
                        }

                        progressBar1.Increment(1);
                    }

                }

                rpt = new PlanCapacitacionAnualTentativo();
                rpt.SetDataSource(WDatosII);
            }
            else
            {
                DataTable WDatosII = new DBAuxi.ListadoTentativoDataTable();
                int i = 0;

                progressBar1.Maximum = WDatos.Rows.Count;

                foreach (DataRow row in WDatos.Rows)
                {
                    DataRow r = WDatosII.NewRow();

                    i++;
                    r["ID"] = i;
                    r["Legajo"] = row["Legajo"];
                    r["DescLegajo"] = row["DescLegajo"];
                    r["Curso"] = row["Curso"];
                    r["DescCurso"] = row["DescCurso"];
                    r["Tema"] = row["Tema"];
                    r["DescTema"] = row["DescTema"];
                    r["Horas"] = row["Horas"];
                    r["Sector"] = row["Sector"];
                    r["DescSector"] = row["DescSector"];
                    r["Año"] = txtAno.Text;

                    WDatosII.Rows.Add(r);

                    progressBar1.Increment(1);
                }

                rpt = new ListadoPersonalCapacitacionAnualTentativo();
                rpt.SetDataSource(WDatosII);
            }

            progressBar1.Value = 0;

            if (rpt != null)
            {
                VistaPrevia frm = new VistaPrevia();
                frm.CargarReporte(rpt);

                frm.Show(this);
            }
        }

        private void Listado_Shown(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
