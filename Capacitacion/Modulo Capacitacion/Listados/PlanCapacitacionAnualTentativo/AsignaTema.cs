using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    public partial class AsignaTema : Form
    {

        private List<int> WRowIndex;

        public AsignaTema(object wCurso, List<int> _RowIndexs)
        {
            InitializeComponent();

            _CargarTemasPara(wCurso);

            WRowIndex = _RowIndexs;
        }

        private void _CargarTemasPara(object wCurso)
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
                        cmd.CommandText = "SELECT Tema, Descripcion, Horas FROM Tema WHERE Curso = '" + wCurso + "' ORDER BY Tema";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                    }

                }

                dgvLegajos.DataSource = tabla;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dgvLegajos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (dgvLegajos.CurrentRow != null)
                {
                    var WTema = dgvLegajos.CurrentRow.Cells["Tema"].Value ?? "";
                    var WDescTema = dgvLegajos.CurrentRow.Cells["DescTema"].Value ?? "";
                    var WHoras = dgvLegajos.CurrentRow.Cells["Horas"].Value ?? "";

                    var WOwner = (AsignarCursos) Owner;

                    foreach (var i in WRowIndex)
                    {
                        WOwner.ProcesarAsignacionTema(i, WTema, WDescTema, WHoras);
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
