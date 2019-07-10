using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    public partial class AsignacionTemasPorSectorPerfilYPlanta : Form
    {
        private int WTipoConsulta;
        private DataTable WDatosAsignados = new DataTable();

        //bool Modificar = true;
        public AsignacionTemasPorSectorPerfilYPlanta()
        {
            InitializeComponent();
        }

        private void IngresoDeCursosRealizados_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();

            foreach (string col in new[] {"Legajo", "Descripcion"})
            {
                WDatosAsignados.Columns.Add(col);
            }

            dgvAsignados.DataSource = WDatosAsignados;
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
            DataTable tabla2 = new DataTable();
            cmbVerPorII.Enabled = true;

            tabla = _CargarTodosLosLegajos();

            switch (cmbVerPorI.SelectedIndex)
            {
                case 0: // Todos
                {
                    cmbVerPorII.Enabled = false;
                    break;
                }
                case 1: // Perfil
                {
                    tabla2 = _CargarTodosLosPerfiles();
                    break;
                }
                case 2: // Sector
                {
                    tabla2 = _CargarTodosLosSectores();
                    break;
                }
                case 3: // Plantas
                {
                    tabla2 = _CargarTodosLasPlantas();
                    break;
                }
            }

            if (cmbVerPorII.Enabled)
            {
                cmbVerPorII.DataSource = tabla2;
                if (tabla2.Rows.Count > 0)
                {
                    cmbVerPorII.DisplayMember = "Descripcion";
                    cmbVerPorII.ValueMember = "Codigo";
                    cmbVerPorII.SelectedIndex = 0;
                }
            }

            dgvCandidatos.DataSource = tabla;

            DataGridViewColumn columna = dgvCandidatos.Columns["Descripcion"];
            if (columna != null) columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Desplegamos el segundo combo para mostrar los distintos valores. Por defecto, se muestran todos.
        }

        private DataTable _CargarTodosLasPlantas()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo");
            tabla.Columns.Add("Descripcion");

            tabla.Rows.Add(0, "Todos");
            tabla.Rows.Add(1, "Planta I");
            tabla.Rows.Add(2, "Planta II");
            tabla.Rows.Add(3, "Planta III");
            tabla.Rows.Add(4, "Planta IV");
            tabla.Rows.Add(5, "Planta V");
            tabla.Rows.Add(6, "Planta VI");
            tabla.Rows.Add(7, "Planta VII");

            return tabla;
        }

        private DataTable _CargarTodosLosSectores()
        {

            try
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Codigo");
                tabla.Columns.Add("Descripcion");
                tabla.Rows.Add("0", "Todos");
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Sector ORDER BY Descripcion";

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

        private DataTable _CargarTodosLosPerfiles()
        {

            try
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Codigo");
                tabla.Columns.Add("Descripcion");
                tabla.Rows.Add("0", "Todos");
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Tarea WHERE Descripcion <> '' AND Renglon = 1 ORDER BY Codigo";

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

                btnCerrarAyuda.PerformClick();

                button6.PerformClick();
            }
        }

        private void _CargarLegajosAsignadosAlTema(string WTema, string WAno)
        {
            try
            {
                WDatosAsignados.Rows.Clear();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Distinct Cr.Legajo, L.Descripcion FROM Cronograma Cr INNER JOIN Legajo L ON Cr.Legajo = L.Codigo AND L.Renglon = 1 WHERE L.FEgreso IN ('  /  /    ', '00/00/0000') AND Cr.Ano = '" + WAno + "' AND Cr.Curso = '" + WTema + "' ORDER BY Cr.Legajo";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                WDatosAsignados.Load(dr);
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

        private void txtFiltrarI_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvCandidatos.DataSource as DataTable;
            if (tabla != null) tabla.DefaultView.RowFilter = string.Format("CONVERT(Legajo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrarI.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Helper.Limpiar(new[] {txtFiltrarI, txtAyuda, txtTema, txtDesTema, txtAno});
            Helper.Limpiar(new[] { cmbVerPorI, cmbVerPorII, cmbTipoLegajos });
            Helper.Limpiar(new[] { dgvCandidatos, dgvAyuda, dgvAsignados });

            WDatosAsignados.Rows.Clear();

            txtAno.Text = DateTime.Now.ToString("yyyy");

            txtAno.Focus();
        }

        private void dgvCandidatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCandidatos.CurrentRow == null) return;

            var WLegajo = dgvCandidatos.CurrentRow.Cells["Legajo"].Value ?? "";
            var WDescripcion = dgvCandidatos.CurrentRow.Cells["Descripcion"].Value ?? "";

            if (WLegajo.ToString() == "") return;

            if (WDatosAsignados.Select("Legajo = '" + WLegajo + "'").Length == 0)
                WDatosAsignados.Rows.Add(WLegajo.ToString(), WDescripcion.ToString());

            dgvCandidatos.CurrentCell = null;
            dgvCandidatos.Rows[e.RowIndex].Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            _CargarLegajosAsignadosAlTema(txtTema.Text, txtAno.Text);
            txtFiltrarI.Text = "";
            cmbVerPorI.SelectedIndex = -1;
            cmbVerPorI.SelectedIndex = 0;
            txtFiltrarI.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        cmd.CommandText = "";

                        foreach (DataGridViewRow WAsignado in dgvAsignados.Rows)
                        {
                            var WLegajo = WAsignado.Cells["Legajo"].Value ?? "";
                            var WDescripcion = WAsignado.Cells["Nombre"].Value ?? "";

                            cmd.CommandText = "SELECT Legajo FROM Cronograma WHERE Legajo = '" + WLegajo + "' AND Ano = '" + txtAno.Text + "' AND Curso = '" + txtTema.Text + "'";
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    continue;
                                }
                            }

                            int WRenglon = 1;

                            cmd.CommandText = "SELECT (Max(Renglon) + 1) as Siguiente FROM Cronograma WHERE Legajo = '" + WLegajo + "' AND Ano = '" + txtAno.Text + "'";

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();
                                    WRenglon = int.Parse(dr["Siguiente"].ToString());
                                }
                            }

                            string WClave = Helper.Ceros(WLegajo, 6) + Helper.Ceros(txtAno.Text, 4) +
                                            Helper.Ceros(WRenglon, 2);

                            cmd.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, Curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
                                            + " VALUES ('" + WClave + "', '" + WLegajo + "', '" + txtAno.Text + "', '" + WRenglon + "', '" + txtTema.Text + "', '', '', '', '','','','', '" + WDescripcion + "')";

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();

                        MessageBox.Show("Datos agregados correctamente!");
                    }

                }

            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }        
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtAno.Text.Trim() == "") return;

                btnAyudaTema.PerformClick();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtAno.Text = "";
            }
	        
        }

        private void AsignacionTemasPorSectorPerfilYPlanta_Shown(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void cmbVerPorII_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            if (cmbVerPorII.SelectedValue.ToString() == "0")
            {
               tabla = _CargarTodosLosLegajos();
            }
            else
            {
                switch (cmbVerPorI.SelectedIndex)
                {
                    case 1:
                    {
                        tabla = _CargarLegajosSegunPerfil(cmbVerPorII.SelectedValue);
                        break;
                    }
                    case 2:
                    {
                        tabla = _CargarLegajosSegunSector(cmbVerPorII.SelectedValue);
                        break;
                    }
                    case 3:
                    {
                        tabla = _CargarLegajosSegunPlanta(cmbVerPorII.SelectedValue);
                        break;
                    }
                }
            }

            dgvCandidatos.DataSource = tabla;

            DataGridViewColumn columna = dgvCandidatos.Columns["Descripcion"];
            if (columna != null) columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private DataTable _CargarLegajosSegunPlanta(object WPlanta)
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
                        cmd.CommandText = "SELECT Legajo.Codigo as Legajo, RTRIM(LTRIM(Legajo.Descripcion)) as Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) as l2 ON Legajo.Descripcion = l2.Descripcion INNER JOIN Personal p ON Legajo.Dni = p.Dni WHERE Legajo.Codigo = l2.Actual AND Legajo.Descripcion <> '' AND Legajo.Renglon = 1 AND FEgreso IN ('  /  /    ', '00/00/0000') AND p.Ubicacion = '" + WPlanta + "' ORDER BY Legajo.Descripcion";

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

        private DataTable _CargarLegajosSegunSector(object WSector)
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
                        cmd.CommandText = "SELECT Legajo.Codigo as Legajo, RTRIM(LTRIM(Legajo.Descripcion)) as Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) as l2 ON Legajo.Descripcion = l2.Descripcion WHERE Legajo.Codigo = l2.Actual AND Legajo.Descripcion <> '' AND Legajo.Renglon = 1 AND FEgreso IN ('  /  /    ', '00/00/0000') AND Sector = '" + WSector + "' ORDER BY Legajo.Descripcion";

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

        private DataTable _CargarLegajosSegunPerfil(object WPerfil)
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
                        cmd.CommandText = "SELECT Legajo.Codigo as Legajo, RTRIM(LTRIM(Legajo.Descripcion)) as Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) as l2 ON Legajo.Descripcion = l2.Descripcion WHERE Legajo.Codigo = l2.Actual AND Legajo.Descripcion <> '' AND Legajo.Renglon = 1 AND FEgreso IN ('  /  /    ', '00/00/0000') AND Perfil = '" + WPerfil + "' ORDER BY Legajo.Descripcion";

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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
