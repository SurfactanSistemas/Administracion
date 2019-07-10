using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    public partial class TentativoListaCursos : Form
    {
        private DataTable WDatos = new DataTable();

        public TentativoListaCursos(string WAnio)
        {
            InitializeComponent();

            txtAnio.Text = WAnio;

            if (txtAnio.Text.Trim() != "")
            {
                _CargarDatosPorAnio();
            }
        }

        private void _CargarDatosPorAnio()
        {
            try
            {
                WDatos.Rows.Clear();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT l2.Actual Legajo, l.Descripcion DescLegajo, l.Curso, c.Descripcion DescCurso, cr.Tema, t.Descripcion DescTema, t.Horas FROM Legajo l " +
                                            "INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion AND l.Codigo = l2.Actual "+
                                            "LEFT OUTER JOIN Curso c on c.Codigo = l.Curso LEFT OUTER JOIN Cronograma cr ON cr.Ano = '" + txtAnio.Text + "' and cr.Curso = l.Curso AND cr.Legajo = l2.Actual "+
                                            "LEFT OUTER JOIN Tema t ON t.Curso = cr.Curso AND t.Tema = cr.Tema WHERE EstaCurso NOT IN (1, 2, 6, 7) AND l.Fegreso IN ('  /  /    ', '00/00/0000') Order by Legajo, l.Renglon";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                WDatos.Load(dr);
                            }
                        }

                        cmd.CommandText = "SELECT l2.Actual Legajo, l.Descripcion DescLegajo, l.Curso, c.Descripcion DescCurso, cr.Tema2 As Tema, t.Descripcion DescTema, t.Horas FROM Legajo l " +
                                            "INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion AND l.Codigo = l2.Actual " +
                                            "LEFT OUTER JOIN Curso c on c.Codigo = l.Curso LEFT OUTER JOIN Cronograma cr ON cr.Ano = '" + txtAnio.Text + "' and cr.Curso = l.Curso AND cr.Legajo = l2.Actual " +
                                            "LEFT OUTER JOIN Tema t ON t.Curso = cr.Curso AND t.Tema = cr.Tema2 WHERE EstaCurso NOT IN (1, 2, 6, 7) AND l.Fegreso IN ('  /  /    ', '00/00/0000') And ISNULL(cr.Tema2, 0) <> 0 Order by Legajo, l.Renglon";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                WDatos.Load(dr);
                            }
                        }

                        if (WDatos.Rows.Count > 0)
                        {
                            var WCursos = WDatos.DefaultView.ToTable(true, "Curso", "DescCurso");

                            foreach (DataRow WCurso in WCursos.Select("", "Curso ASC"))
                            {
                                if (int.Parse(WCurso["Curso"].ToString()) > 0)
                                {
                                    int i = dgvGrilla.Rows.Add();

                                    var WPersonas = WDatos.Select("Curso = '" + WCurso["Curso"] + "'").ToArray().Count();

                                    dgvGrilla.Rows[i].Cells["Curso"].Value = WCurso["Curso"];
                                    dgvGrilla.Rows[i].Cells["Descripcion"].Value = WCurso["DescCurso"];
                                    dgvGrilla.Rows[i].Cells["Personas"].Value = WPersonas;
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvGrilla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (dgvGrilla.CurrentRow != null)
                {
                    var WCurso = dgvGrilla.CurrentRow.Cells["Curso"].Value ?? "";

                    AsignarCursos frm = new AsignarCursos(WDatos, WCurso, txtAnio.Text);
                    frm.ShowDialog(this);

                    _CargarDatosPorAnio();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TentativoListaCursos_Load(object sender, EventArgs e)
        {

        }


    }
}