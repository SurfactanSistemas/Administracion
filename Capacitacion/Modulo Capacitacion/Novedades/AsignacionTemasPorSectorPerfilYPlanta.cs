using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    public partial class AsignacionTemasPorSectorPerfilYPlanta : Form
    {
        private int WTipoConsulta = 0;

        //bool Modificar = true;
        public AsignacionTemasPorSectorPerfilYPlanta()
        {
            InitializeComponent();
        }

        private void IngresoDeCursosRealizados_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
        }

        private void dgvGrilla_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvAsignados.Rows[e.RowIndex];

                if (
                    MessageBox.Show("¿Está seguro de querer eliminar la fila?", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvAsignados.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvGrilla_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvAsignados.SelectedCells.Count > 1) return;

                DataGridView.HitTestInfo WHit = dgvAsignados.HitTest(e.X, e.Y);

                if (WHit.Type == DataGridViewHitTestType.Cell)
                {
                    dgvAsignados.CurrentCell = dgvAsignados.Rows[WHit.RowIndex].Cells[WHit.ColumnIndex];
                }

                if (WHit.Type == DataGridViewHitTestType.RowHeader)
                {
                    dgvAsignados.ClearSelection();
                }
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Evitamos que se copien las cabeceras.
            dgvAsignados.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            // Copiamos el contenido de las celdas seleccionadas en el ClipBoard.
            _CopiarSeleccion();
        }

        private void _CopiarSeleccion()
        {
            if (dgvAsignados.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                // Evitamos que los 'Rows Headers' ocupen espacio.
                dgvAsignados.RowHeadersVisible = false;

                object data = dgvAsignados.GetClipboardContent();
                if (data != null)
                    Clipboard.SetDataObject(data);

                // Volvemos a mostrar los 'Rows Headers'
                dgvAsignados.RowHeadersVisible = true;
            }
        }

        private void copiarConCabecerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Activamos que se copien las cabeceras.
            dgvAsignados.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            // Copiamos el contenido de las celdas seleccionadas en el ClipBoard.
            _CopiarSeleccion();

        }

        private void txtAyuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                txtAyuda.Text = "";
            }
        }

        private void btnAyudaTema_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            tabla = _TraerTemas();

            dgvAyuda.DataSource = tabla;

            WTipoConsulta = 1;

            DataGridViewColumn _columna = dgvAyuda.Columns["Descripcion"];
            if (_columna != null) _columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            gbLegajos.Visible = false;
            pnlAyuda.Visible = true;
            txtAyuda.Text = "";
            txtAyuda.Focus();
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
                        cmd.CommandText = "SELECT Codigo, LTRIM(RTRIM(Descripcion)) as Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Codigo";

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

        private void txtDesTema_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAyudaTema.PerformClick();
        }

        private void cmbVerPorI_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cargamos el segundo combo segun el tipo del primer filtro.
            DataTable tabla = new DataTable();
            cmbVerPorII.Enabled = true;

            switch (cmbVerPorI.SelectedIndex)
            {
                case 0: // Todos
                {
                    tabla = _CargarTodosLosLegajos();
                    cmbVerPorII.Enabled = false;
                    break;
                }
            }

            if (cmbVerPorII.Enabled)
            {
                cmbVerPorII.DataSource = null;
            }

            dgvCandidatos.DataSource = tabla;

            DataGridViewColumn columna = dgvCandidatos.Columns["Descripcion"];
            if (columna != null) columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Desplegamos el segundo combo para mostrar los distintos valores. Por defecto, se muestran todos.
        }

        private DataTable _CargarTodosLosLegajos()
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
                        cmd.CommandText = "SELECT Legajo.Codigo as Legajo, RTRIM(LTRIM(Legajo.Descripcion)) as Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) as l2 ON Legajo.Descripcion = l2.Descripcion WHERE Legajo.Codigo = l2.Actual AND Legajo.Descripcion <> '' AND Legajo.Renglon = 1 AND FEgreso IN ('  /  /    ', '00/00/0000') ORDER BY Legajo.Descripcion";

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

        private void btnCerrarAyuda_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = false;
            txtFiltrarI.Focus();
        }

        private void txtAyuda_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvAyuda.DataSource as DataTable;
            if (tabla != null) tabla.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtAyuda.Text);
        }

        private void dgvAyuda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAyuda.CurrentRow != null)
            {
                txtTema.Text = dgvAyuda.CurrentRow.Cells["Codigo"].Value.ToString();
                
                txtDesTema.Text = dgvAyuda.CurrentRow.Cells["Descripcion"].Value.ToString();

                cmbVerPorI.SelectedIndex = -1;
                cmbVerPorI.SelectedIndex = 0;

                btnCerrarAyuda.PerformClick();
            }
        }

        private void txtFiltrarI_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvCandidatos.DataSource as DataTable;
            if (tabla != null) tabla.DefaultView.RowFilter = string.Format("CONVERT(Legajo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrarI.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Helper.Limpiar(new[] {txtFiltrarI, txtAyuda, txtTema, txtDesTema});
            Helper.Limpiar(new[] { cmbVerPorI, cmbVerPorII, cmbTipoLegajos });
            Helper.Limpiar(new[] { dgvCandidatos, dgvAyuda, dgvAsignados });
        }

    }
}
