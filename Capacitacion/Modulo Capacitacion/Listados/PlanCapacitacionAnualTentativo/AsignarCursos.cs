using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    public partial class AsignarCursos : Form
    {
        private int WCurso;
        private string WAnio;

        public AsignarCursos(DataTable _Datos, object _Curso, string _Anio)
        {
            InitializeComponent();

            WCurso = int.Parse(_Curso.ToString());
            WAnio = _Anio;

            var WLegajos = _Datos.Select("Curso = '" + _Curso + "'", "Legajo ASC");

            foreach (DataRow wLegajo in WLegajos)
            {
                int i = dgvLegajos.Rows.Add();

                lblDescCurso.Text = wLegajo["DescCurso"].ToString().Trim();

                dgvLegajos.Rows[i].Cells["Legajo"].Value = wLegajo["Legajo"] ?? "";
                dgvLegajos.Rows[i].Cells["DescLegajo"].Value = wLegajo["DescLegajo"] ?? "";
                dgvLegajos.Rows[i].Cells["Tema"].Value = wLegajo["Tema"] ?? "";
                dgvLegajos.Rows[i].Cells["DescTema"].Value = wLegajo["DescTema"] ?? "";
                dgvLegajos.Rows[i].Cells["Horas"].Value = wLegajo["Horas"] ?? "";

                foreach (DataGridViewCell celda in dgvLegajos.Rows[i].Cells)
                {
                    celda.Value = celda.Value.ToString().Trim();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*
             * Elimino la fila y la reingreso con los datos actualizados.
             */
            SqlTransaction trans = null;

            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    cn.Open();
                    trans = cn.BeginTransaction();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.Connection = cn;
                        cm.Transaction = trans;

                        cm.CommandText = "";

                        foreach (DataGridViewRow row in dgvLegajos.Rows)
                        {
                            var WLegajo = row.Cells["Legajo"].Value ?? "";
                            var WTema = row.Cells["Tema"].Value ?? "";
                            var WHoras = row.Cells["Horas"].Value ?? "0";

                            WHoras = Helper.FormatoNumerico(WHoras);

                            if (WLegajo.ToString().Trim() == "") continue;

                            cm.CommandText = "DELETE FROM Cronograma WHERE Ano = '" + WAnio + "' AND Legajo = '" + WLegajo + "' AND Curso = '" + WCurso + "'";
                            cm.ExecuteNonQuery();

                            /*
                             * Chequeamos si era el unico legajo que quedaba en ese curso. En caso de que si, se da de baja el Curso en la Tabla CronogramaII.
                             */
                            cm.CommandText = "SELECT COUNT(DISTINCT Legajo) Legajos FROM Cronograma WHERE Ano = '" + WAnio +
                                                  "' AND Curso = '" + WCurso + "'";
                            using (SqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();

                                    var WCantidadLegajos = int.Parse(dr["Legajos"].ToString());

                                    if (!dr.IsClosed) dr.Close();

                                    if (WCantidadLegajos == 0)
                                    {
                                        cm.CommandText = string.Format("DELETE FROM CronogramaII WHERE Ano = '{0}' AND Curso = '{1}'", WAnio, WCurso);
                                        cm.ExecuteNonQuery();
                                    }
                                }
                            }

                            /*
                             * Grabamos la nueva fila, con renglon = 99.
                             */

                            int WRenglon = 99;

                            if (WTema.ToString().Trim() != "" && WTema.ToString().Trim() != "0")
                            {
                                string XClave = Helper.Ceros(WLegajo, 6) + Helper.Ceros(WAnio, 4) +
                                         Helper.Ceros(WRenglon, 2);

                                cm.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
                                                + " VALUES ("
                                                + " '" + XClave + "', '" + WLegajo + "', '" + WAnio + "', '" + WRenglon + "', '" + WCurso + "', " + WHoras + ", '0', '" + WTema + "', '', '','', '', '' "
                                                + " )";

                                cm.ExecuteNonQuery();
                            }

                            /*
                             * Recupero y regrabo todas las filas del legajo para conservar la correlatividad de los renglones.
                             */

                            WRenglon = 0;
                            cm.CommandText = "SELECT Legajo, Ano, Curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo FROM Cronograma WHERE Legajo = '" + WLegajo + "' AND Ano = '" + WAnio + "'";

                            DataTable WRegrabar = new DataTable();
                            using (SqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    WRegrabar.Load(dr);
                                }
                            }

                            if (WRegrabar.Rows.Count > 0)
                            {
                                cm.CommandText = "DELETE FROM Cronograma WHERE Legajo = '" + WLegajo + "' AND Ano = '" + WAnio + "'";
                                cm.ExecuteNonQuery();

                                foreach (DataRow WRow in WRegrabar.Rows)
                                {
                                    WRenglon++;

                                    var XClave = Helper.Ceros(WRow["Legajo"], 6) + Helper.Ceros(WAnio, 4) +
                                             Helper.Ceros(WRenglon, 2);

                                    cm.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
                                                    + " VALUES ("
                                                    + " '" + XClave + "', '" + WRow["Legajo"] + "', '" + WAnio + "', '" + WRenglon + "', '" + WRow["Curso"] + "', " + Helper.FormatoNumerico(WRow["Horas"]) + ", " + Helper.FormatoNumerico(WRow["Realizado"]) + ", '" + WRow["Tema"] + "', '" + WRow["DesTema"] + "', '" + WRow["Observaciones"] + "','" + WRow["ObservacionesII"] + "', '" + WRow["DesSector"] + "', '" + WRow["DesLegajo"] + "' "
                                                    + " )";

                                    cm.ExecuteNonQuery();
                                }
                            }
                        }

                        trans.Commit();

                        DialogResult = DialogResult.None;
                        Close();

                    }

                }

            }
            catch (Exception ex)
            {
                if (trans != null && trans.Connection != null) trans.Rollback();

                MessageBox.Show(ex.Message);
            }

            //// Obtengo y regrabo los cursos correspondientes al Legajo y Año para mantener la correlatividad en la numeracion de Renglones.
            
            // int WRenglon = 0;
            //cmd.CommandText = "SELECT Legajo, Ano, Curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo FROM Cronograma WHERE Legajo = '" + WAnt + "' AND Ano = '" + txtAno.Text + "'";

            //DataTable WRegrabar = new DataTable();
            //using (SqlDataReader dr = cmd.ExecuteReader())
            //{
            //    if (dr.HasRows)
            //    {
            //        WRegrabar.Load(dr);
            //    }
            //}

            //if (WRegrabar.Rows.Count > 0)
            //{
            //    cmd.CommandText = "DELETE FROM Cronograma WHERE Legajo = '" + WAnt + "' AND Ano = '" + txtAno.Text + "'";
            //    cmd.ExecuteNonQuery();

            //    foreach (DataRow WRow in WRegrabar.Rows)
            //    {
            //        WRenglon++;

            //        XClave = Helper.Ceros(WRow["Legajo"], 6) + Helper.Ceros(txtAno.Text, 4) +
            //                 Helper.Ceros(WRenglon, 2);

            //        cmd.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
            //                        + " VALUES ("
            //                        + " '" + XClave + "', '" + WRow["Legajo"] + "', '" + txtAno.Text + "', '" + WRenglon + "', '" + WRow["Curso"] + "', " + Helper.FormatoNumerico(WRow["Horas"]) + ", " + Helper.FormatoNumerico(WRow["Realizado"]) + ", '" + WRow["Tema"] + "', '" + WRow["DesTema"] + "', '" + WRow["Observaciones"] + "','" + WRow["ObservacionesII"] + "', '" + WRow["DesSector"] + "', '" + WRow["DesLegajo"] + "' "
            //                        + " )";

            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvLegajos.CurrentRow != null)
            {

                List<int> WIndices = new List<int>();

                foreach (DataGridViewCell celda in dgvLegajos.SelectedCells)
                {
                    if (!WIndices.Contains(celda.RowIndex)) WIndices.Add(celda.RowIndex);
                }

                AsignaTema frm = new AsignaTema(WCurso, WIndices);
                frm.ShowDialog(this);
            }
        }

        private void dgvLegajos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvLegajos.SelectedCells.Count > 1) return;

                DataGridView.HitTestInfo WHit = dgvLegajos.HitTest(e.X, e.Y);

                if (WHit.Type == DataGridViewHitTestType.Cell)
                {
                    dgvLegajos.CurrentCell = dgvLegajos.Rows[WHit.RowIndex].Cells[WHit.ColumnIndex];
                }
            }
        }

        internal void ProcesarAsignacionTema(int wRowIndex, object wTema, object wDescTema, object wHoras)
        {
            dgvLegajos.Rows[wRowIndex].Cells["Tema"].Value = wTema;
            dgvLegajos.Rows[wRowIndex].Cells["DescTema"].Value = wDescTema;
            dgvLegajos.Rows[wRowIndex].Cells["Horas"].Value = wHoras;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<int> WIndices = new List<int>();


            foreach (DataGridViewCell celda in dgvLegajos.SelectedCells)
            {
                if(!WIndices.Contains(celda.RowIndex)) WIndices.Add(celda.RowIndex);
            }

            foreach (var i in WIndices)
            {
                dgvLegajos.Rows[i].Cells["Tema"].Value = "";
                dgvLegajos.Rows[i].Cells["DescTema"].Value = "";
                dgvLegajos.Rows[i].Cells["Horas"].Value = "";
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            List<int> WIndices = new List<int>();


            foreach (DataGridViewCell celda in dgvLegajos.SelectedCells)
            {
                if (!WIndices.Contains(celda.RowIndex)) WIndices.Add(celda.RowIndex);
            }

            foreach (var i in WIndices)
            {
                dgvLegajos.Rows[i].Cells["Tema"].Value = "99";
                dgvLegajos.Rows[i].Cells["DescTema"].Value = "Vario";
                dgvLegajos.Rows[i].Cells["Horas"].Value = "1";
            }
        }

        private void AsignarCursos_Load(object sender, EventArgs e)
        {

        }
    }
}
