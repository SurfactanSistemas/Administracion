using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    public partial class AsignarCursosPorPerfilYSector : Form
    {
        public AsignarCursosPorPerfilYSector()
        {
            InitializeComponent();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            dgvGrilla.Rows.Clear();
            dgvAyuda.DataSource = null;
            txtFiltrar.Text = "";
            txtCodigo.Text = "";
            cmbAuxi.Visible = false;
            rbPerfil.Checked = true;
            _CargarPerfiles();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {

            if (rbTema.Checked)
            {
                _GrabarActualizacionPorTema();
                return;
            }

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

                        string WAnt = "";
                        int WRenglon = 0;

                        foreach (DataGridViewRow row in dgvGrilla.Rows)
                        {
                            var WLegajo = row.Cells["Legajo"].Value ?? "";
                            var WTipo = row.Cells["Tipo"].Value ?? "";
                            var WRealizar = row.Cells["Realizar"].Value ?? "";
                            var WCurso = row.Cells["Curso"].Value ?? "";
                            var WHoras = row.Cells["Horas"].Value ?? "";
                            var WTema = row.Cells["Tema"].Value ?? "";
                            string XClave = "";

                            if (WTipo.ToString() == "") continue;

                            if (WAnt != WLegajo.ToString() && WLegajo.ToString() != "")
                            {
                                WRenglon = 0;
                                WAnt = WLegajo.ToString();

                                cmd.CommandText = "DELETE FROM Cronograma WHERE Legajo = '" + WLegajo + "' AND Ano = '" + txtAno.Text + "'";

                                cmd.ExecuteNonQuery();
                            }

                            cmd.CommandText = "SELECT COUNT(DISTINCT Legajo) Legajos FROM Cronograma WHERE Ano = '" + txtAno.Text +
                                              "' AND Curso = '" + WCurso + "'";
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();

                                    var WCantidadLegajos = int.Parse(dr["Legajos"].ToString());

                                    if (!dr.IsClosed) dr.Close();

                                    if (WCantidadLegajos == 0)
                                    {
                                        cmd.CommandText = string.Format("DELETE FROM CronogramaII WHERE Ano = '{0}' AND Curso = '{1}'", txtAno.Text, WCurso);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (WRealizar.ToString() == "X")
                            {
                                WRenglon++;
                                
                                XClave = Helper.Ceros(WAnt, 6) + Helper.Ceros(txtAno.Text, 4) +
                                         Helper.Ceros(WRenglon, 2);

                                cmd.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
                                                + " VALUES ("
                                                + " '" + XClave + "', '" + WAnt + "', '" + txtAno.Text + "', '" + WRenglon + "', '" + WCurso + "', " + WHoras + ", '0', '" + WTema + "', '', '','', '', '' "
                                                + " )";

                                cmd.ExecuteNonQuery();
                                
                                cmd.CommandText = "SELECT Clave FROM CronogramaII WHERE Ano = '" + txtAno.Text +
                                              "' AND Curso = '" + WCurso + "'";
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    if (!dr.HasRows)
                                    {
                                        if (!dr.IsClosed) dr.Close();

                                        cmd.CommandText = string.Format("INSERT INTO CronogramaII (Clave, Ano, Curso) VALUES ('{0}', '{1}', '{2}')", txtAno.Text + WCurso.ToString().PadLeft(4, '0'), txtAno.Text, WCurso);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        trans.Commit();
                    }
                }

                MessageBox.Show("Datos Actualizados correctamente");
                btnBuscar.PerformClick();

            }
            catch (Exception err)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Ocurrio un problema al querer actualizar los datos. " + Environment.NewLine + " Motivo" + err.Message, "Error");
            }
        }

        private void _GrabarActualizacionPorTema()
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

                        string WAnt = "";
                        int WRenglon = 0;

                        foreach (DataGridViewRow row in dgvGrilla.Rows)
                        {
                            var WLegajo = row.Cells["Legajo"].Value ?? "";
                            var WTipo = row.Cells["Tipo"].Value ?? "";
                            var WRealizar = row.Cells["Realizar"].Value ?? "";
                            var WCurso = row.Cells["Curso"].Value ?? "";
                            var WHoras = row.Cells["Horas"].Value ?? "";
                            var WTema = row.Cells["Tema"].Value ?? "";
                            string XClave = "";

                            if (WTipo.ToString() == "") continue;

                            WRenglon = 0;

                            WAnt = WLegajo.ToString();

                            cmd.CommandText = "DELETE FROM Cronograma WHERE Legajo = '" + WLegajo + "' AND Ano = '" + txtAno.Text + "' AND Curso = '" + cmbOrganizar.SelectedValue + "'";

                            cmd.ExecuteNonQuery();

                            // Si está marcado para que se realizar, lo vuelvo a grabar.
                            if (WRealizar.ToString() == "X")
                            {
                                WRenglon++;

                                XClave = Helper.Ceros(WAnt, 6) + Helper.Ceros(txtAno.Text, 4) +
                                         Helper.Ceros(WRenglon, 2);

                                cmd.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
                                                + " VALUES ("
                                                + " '" + XClave + "', '" + WAnt + "', '" + txtAno.Text + "', '" + WRenglon + "', '" + WCurso + "', " + WHoras + ", '0', '" + WTema + "', '', '','', '', '' "
                                                + " )";

                                cmd.ExecuteNonQuery();
                            }

                            // Obtengo y regrabo los cursos correspondientes al Legajo y Año para mantener la correlatividad en la numeracion de Renglones.
                            WRenglon = 0;
                            cmd.CommandText = "SELECT Legajo, Ano, Curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo FROM Cronograma WHERE Legajo = '" + WAnt + "' AND Ano = '" + txtAno.Text + "'";

                            DataTable WRegrabar = new DataTable();
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    WRegrabar.Load(dr);
                                }
                            }

                            if (WRegrabar.Rows.Count > 0)
                            {
                                cmd.CommandText = "DELETE FROM Cronograma WHERE Legajo = '" + WAnt + "' AND Ano = '" + txtAno.Text + "'";
                                cmd.ExecuteNonQuery();

                                foreach (DataRow WRow in WRegrabar.Rows)
                                {
                                    WRenglon++;
                                    
                                    XClave = Helper.Ceros(WRow["Legajo"], 6) + Helper.Ceros(txtAno.Text, 4) +
                                             Helper.Ceros(WRenglon, 2);

                                    cmd.CommandText = "INSERT INTO Cronograma (Clave, Legajo, Ano, Renglon, curso, Horas, Realizado, Tema, DesTema, Observaciones, ObservacionesII, DesSector, DesLegajo) "
                                                    + " VALUES ("
                                                    + " '" + XClave + "', '" + WRow["Legajo"] + "', '" + txtAno.Text + "', '" + WRenglon + "', '" + WRow["Curso"] + "', " + Helper.FormatoNumerico(WRow["Horas"]) + ", " + Helper.FormatoNumerico(WRow["Realizado"]) + ", '" + WRow["Tema"] + "', '" + WRow["DesTema"] + "', '" + WRow["Observaciones"] + "','" + WRow["ObservacionesII"] + "', '" + WRow["DesSector"] + "', '" + WRow["DesLegajo"] + "' "
                                                    + " )";

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        trans.Commit();
                    }
                }

                MessageBox.Show("Datos Actualizados correctamente");
                btnBuscar.PerformClick();

            }
            catch (Exception err)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Ocurrio un problema al querer actualizar los datos. " + Environment.NewLine + " Motivo" + err.Message, "Error");
            }
        }


        private void IngreDeCursosRealizados_Load(object sender, EventArgs e)
        {
            cmbAuxi.Visible = false;
            pnlAyuda.Visible = false;

            rbPerfil.Checked = true;
            pnlProgreso.Visible = false;

            _CargarPerfiles();

            txtAno.Text = _TraerAnoPorDefault();
            txtAno.Focus();
        }

        private string _TraerAnoPorDefault()
        {
            string WAno = "";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Max(Ano) as Ano FROM Cronograma";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            WAno = dr["Ano"].ToString();
                        }
                    }
                }

            }

            return WAno;
        }

        private void _CargarPerfiles()
        {
            DataTable perfiles = _TraerPerfiles();

            cmbOrganizar.DataSource = perfiles;
            cmbOrganizar.ValueMember = "Codigo";
            cmbOrganizar.DisplayMember = "Descripcion";
        }

        private DataTable _TraerPerfiles()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    string WFiltrarPorTema = txtTema.Text.Trim() != "" ?  " AND Curso = '" + txtTema.Text + "'" : "";

                    cmd.CommandText = "SELECT DISTINCT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Tarea WHERE Descripcion <> '' " + WFiltrarPorTema + " ORDER BY Descripcion";

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

        private void IngreDeCursosRealizados_Shown(object sender, EventArgs e)
        {
            //txtTema.Focus();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = false;
        }
        
        private void _ActualizarDatosDeOrganizacion()
        {
            if (rbPerfil.Checked)
            {
                _CargarPerfiles();

            }else if (rbSector.Checked)
            {
                _CargarSectores();
            }
            else if (rbTema.Checked)
            {
                _CargarTemas();
            }
        }

        private void _CargarTemas()
        {
            DataTable sectores = _TraerTemas();

            cmbOrganizar.DataSource = sectores;
            cmbOrganizar.ValueMember = "Codigo";
            cmbOrganizar.DisplayMember = "Descripcion";
        }

        private DataTable _TraerTemas()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT DISTINCT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Descripcion";

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

        private void _CargarSectores()
        {
            DataTable sectores = _TraerSectores();

            cmbOrganizar.DataSource = sectores;
            cmbOrganizar.ValueMember = "Codigo";
            cmbOrganizar.DisplayMember = "Descripcion";
        }

        private DataTable _TraerSectores()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT DISTINCT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Sector WHERE Descripcion <> '' ORDER BY Descripcion";

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

        private void rbPerfil_Click(object sender, EventArgs e)
        {
            _ActualizarDatosDeOrganizacion();
        }

        private void rbSector_Click(object sender, EventArgs e)
        {
            _ActualizarDatosDeOrganizacion();
        }

        private void txtTema_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //_AbrirAyuda();
        }

        private void _AbrirAyuda(string WTema)
        {
            DataTable cursos = _TraerCursos(WTema);
            dgvAyuda.DataSource = cursos;

            DataGridViewColumn column = dgvAyuda.Columns["Descripcion"];
            if (column != null)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            pnlAyuda.Size = new Size(725, 375);
            pnlAyuda.Location = Helper._CentrarH(Width, pnlAyuda);
            pnlAyuda.Visible = true;
            txtFiltrar.Text = "";
            txtFiltrar.Focus();
        }

        private DataTable _TraerCursos(string wTema)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Tema as Curso, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Tema WHERE Descripcion <> '' and Curso = '" + wTema + "' ORDER BY Curso";

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

        private void txtTema_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtTema.Text.Trim() == "") return;

                _CargarTema();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtTema.Text = "";
            }
	        
        }

        private void _CargarTema()
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT UPPER(RTRIM(LTRIM(Descripcion))) Descripcion FROM Curso WHERE Codigo = '" + txtTema.Text + "'";
                    
                    txtDescTema.Text = "";
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            txtDescTema.Text = dr["Descripcion"].ToString();
                        }
                    }
                }

                _ActualizarDatosDeOrganizacion();

                btnCerrarAyuda.PerformClick();
            }

        
        }

        private void dgvAyuda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            string tema = dgvAyuda.Rows[e.RowIndex].Cells["Curso"].Value.ToString();

            //txtTema.Text = tema;

            int wRowIndex = dgvGrilla.CurrentCell.RowIndex;

            if (wRowIndex < 0) return;

            if (!rbTema.Checked)
            {
                dgvGrilla.Rows[wRowIndex].Cells["Tema"].Value = tema;

                string WCurso = dgvGrilla.Rows[wRowIndex].Cells["Curso"].Value.ToString();
                DataTable WInfoCurso = _TraerDescripcionCurso(WCurso, tema);

                dgvGrilla.Rows[wRowIndex].Cells["DescTema"].Value = "";
                dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value = "0";

                if (WInfoCurso.Rows.Count > 0)
                {
                    dgvGrilla.Rows[wRowIndex].Cells["DescTema"].Value = WInfoCurso.Rows[0]["Descripcion"];
                    dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value = WInfoCurso.Rows[0]["Horas"];
                }

                dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value =
                    Helper.FormatoNumerico(dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value);

                dgvGrilla.Rows[wRowIndex].Cells["Realizar"].Value = "X";
            }
            else
            {

                foreach (DataGridViewCell cells in dgvGrilla.SelectedCells)
                {
                    wRowIndex = cells.RowIndex;
                    var WTipo = dgvGrilla.Rows[wRowIndex].Cells["Tema"].Value ?? "";

                    if (WTipo.ToString() == "") continue;

                    dgvGrilla.Rows[wRowIndex].Cells["Tema"].Value = tema;

                    string WCurso = dgvGrilla.Rows[wRowIndex].Cells["Curso"].Value.ToString();
                    DataTable WInfoCurso = _TraerDescripcionCurso(WCurso, tema);

                    dgvGrilla.Rows[wRowIndex].Cells["DescTema"].Value = "";
                    dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value = "0";

                    if (WInfoCurso.Rows.Count > 0)
                    {
                        dgvGrilla.Rows[wRowIndex].Cells["DescTema"].Value = WInfoCurso.Rows[0]["Descripcion"];
                        dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value = WInfoCurso.Rows[0]["Horas"];
                    }

                    dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value =
                        Helper.FormatoNumerico(dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value);

                    dgvGrilla.Rows[wRowIndex].Cells["Realizar"].Value = "X";
                }
            }

            btnCerrarAyuda.PerformClick();

            //_CargarTema();

        }

        private DataTable _TraerDescripcionCurso(string wCurso, string tema)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT UPPER(LTRIM(RTRIM(Descripcion))) as Descripcion, Horas FROM Tema WHERE Curso = '" + wCurso + "' AND Tema = '" + tema + "'";
                     
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

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            //_AbrirAyuda();
        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvAyuda.DataSource as DataTable;

            if (tabla != null)
            {
                tabla.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) like '%{0}%' OR CONVERT(Descripcion, System.String) like '%{0}%'", txtFiltrar.Text);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int WRowindex = 0;

            dgvGrilla.Rows.Clear();
            pnlProgreso.Visible = false;

            if (txtAno.Text.Trim() == "") return;

            DataTable tabla = new DataTable();

            if (rbPerfil.Checked)
                tabla = _TraerDatosPorPerfiles();

            if (rbSector.Checked)
                tabla = _TraerDatosPorSector();

            if (rbTema.Checked)
                tabla = _TraerDatosPorTema();

            string WAnt = "";

            if (tabla.Rows.Count == 0) return;

            string WFiltro = "";

            if (ckSoloSugeridos.Checked) WFiltro = "Tipo <> 1";

            foreach (DataRow dr in rbPerfil.Checked ? tabla.Select(WFiltro, "DesSector, Legajo, Nombre ASC, Curso ASC") : tabla.Select(WFiltro, "Legajo, Nombre ASC, Curso ASC"))
            {
                WRowindex = dgvGrilla.Rows.Add();

                //if (dr["Legajo"].ToString() == "366") MessageBox.Show("Test");

                if (dr["Legajo"].ToString() != WAnt)
                {
                    if (WRowindex != 0) WRowindex = dgvGrilla.Rows.Add();

                    WAnt = dr["Legajo"].ToString();

                    if (!rbSector.Checked)
                    {
                        dgvGrilla.Rows[WRowindex].Cells["Sector"].Value = dr["Sector"];
                        dgvGrilla.Rows[WRowindex].Cells["DesSector"].Value = dr["DesSector"]; 
                    }

                    dgvGrilla.Rows[WRowindex].Cells["Perfil"].Value = dr["Perfil"];
                    dgvGrilla.Rows[WRowindex].Cells["DescPerfil"].Value = dr["DescPerfil"];
                    dgvGrilla.Rows[WRowindex].Cells["Legajo"].Value = dr["Legajo"];
                    dgvGrilla.Rows[WRowindex].Cells["Nombre"].Value = dr["Nombre"];
                }

                dgvGrilla.Rows[WRowindex].Cells["Clave"].Value = dr["Clave"];
                dgvGrilla.Rows[WRowindex].Cells["Tipo"].Value = dr["Tipo"];
                dgvGrilla.Rows[WRowindex].Cells["Calificacion"].Value = _TraerDescripcionCalificacion(dr["EstaCurso"].ToString());
                dgvGrilla.Rows[WRowindex].Cells["Curso"].Value = dr["Curso"];
                dgvGrilla.Rows[WRowindex].Cells["DescCurso"].Value = dr["DescCurso"].ToString().Trim().PadRight(5, ' ');
                dgvGrilla.Rows[WRowindex].Cells["Horas"].Value = Helper.FormatoNumerico(dr["Horas"]);
                dgvGrilla.Rows[WRowindex].Cells["Realizado"].Value = Helper.FormatoNumerico(dr["Realizado"]);
                dgvGrilla.Rows[WRowindex].Cells["Tema"].Value = dr["Tema"];
                dgvGrilla.Rows[WRowindex].Cells["DescTema"].Value = dr["DescTema"];
                dgvGrilla.Rows[WRowindex].Cells["Realizar"].Value = dr["Realizar"];
            }

            var WColNombre = dgvGrilla.Columns["Nombre"];
            var WColCurso = dgvGrilla.Columns["DescCurso"];
            var WColPerfil = dgvGrilla.Columns["DescPerfil"];
            var WColDescTema = dgvGrilla.Columns["DescTema"];
            var WColTipo = dgvGrilla.Columns["Tipo"];
            var WColTema = dgvGrilla.Columns["Curso"];

            if (WColTipo != null) WColTipo.Visible = false;

            if (rbPerfil.Checked)
            {
                //if (WColCurso != null) WColCurso.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //if (WColNombre != null) WColNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                //if (WColDescTema != null) WColDescTema.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                foreach (string Columna in new[] { "Perfil", "DescPerfil", "Sector" })
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = false;
                }

                foreach (string Columna in new[] { "Curso", "DescCurso" })
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = true;
                }
            }

            if (rbSector.Checked)
            {
                if (WColCurso != null) WColCurso.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (WColNombre != null) WColNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (WColPerfil != null) WColPerfil.Width = 175;
                if (WColDescTema != null) WColDescTema.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                foreach (string Columna in new[] { "Perfil", "DescPerfil", "Curso", "DescCurso" })
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = true;
                }

                foreach (string Columna in new[] { "Sector", "DesSector" })
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = false;
                }
            }

            if (rbTema.Checked)
            {
                if (WColCurso != null) WColCurso.Visible = false;
                if (WColNombre != null) WColNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (WColPerfil != null) WColPerfil.Width = 175;
                if (WColDescTema != null) WColDescTema.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                if (WColTema != null) WColTema.Visible = false;

                foreach (string Columna in new[] { "Perfil", "DescPerfil" })
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = true;
                }
            }
        }

        private string _TraerDescripcionCalificacion(string WIDCalificacion)
        {
            if (WIDCalificacion.Trim() == "") WIDCalificacion = "0";
            switch (int.Parse(WIDCalificacion))
            {
                case 1:
                    {
                        return "Exede";
                    }
                case 2:
                    {
                        return "Cumple";
                    }
                case 3:
                    {
                        return "Reforzar";
                    }
                case 4:
                    {
                        return "En Entrenamiento";
                    }
                case 5:
                    {
                        return "No Cumple";
                    }
                case 6:
                    {
                        return "No Aplica";
                    }
                case 7:
                    {
                        return "No Evalúa";
                    }
                case 8:
                    {
                        return "Cumple Act.";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        private DataTable _TraerDatosPorTema()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT Clave = '', Tipo = CASE WHEN l.EstaCurso IN (3,4,5,7,8) THEN '2' ELSE '1' END, l.EstaCurso, l.Codigo as Legajo, l.Renglon, l.Descripcion as Nombre, l.Sector, Sector.Descripcion as DesSector, l.Perfil, p.Descripcion as DescPerfil, l.Curso, c.Descripcion as DescCurso, ISNULL(p.Tema, '') as Tema, RTRIM(LTRIM(ISNULL(t.Descripcion, ''))) as DescTema, Horas = 0, Realizado = 0, Realizar = '' FROM Legajo l INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM LEgajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion INNER JOIN Tarea p ON l.Perfil = p.Codigo INNER JOIN Curso c ON l.Curso = c.Codigo FULL OUTER JOIN Tema t ON p.Tema = t.Tema LEFT OUTER JOIN Sector ON l.Sector = Sector.Codigo WHERE l.Perfil = p.Codigo and l.renglon = p.Renglon AND l.FEgreso IN ('  /  /    ', '00/00/0000') AND l.Codigo = l2.Actual AND p.Curso = '" +
                        cmbOrganizar.SelectedValue + "' ORDER BY l.Codigo, l.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) tabla.Load(dr);
                    }

                    DataTable WProgramados = tabla.Copy();

                    WProgramados.Rows.Clear();
                    WProgramados.Columns.Clear();

                    cmd.CommandText =
                        "SELECT Clave = '', Tipo = '0', cr.Legajo, cr.Renglon, RTRIM(l.Descripcion) as Nombre, l.EstaCurso, l.Sector, Sector.Descripcion as DesSector, l.Perfil, RTRIM(ISNULL(p.Descripcion, '')) as DescPerfil, cr.Curso, RTRIM(ISNULL(c.Descripcion, '')) as DescCurso, cr.Horas, cr.Realizado, ISNULL(cr.Tema, '') as Tema, RTRIM(ISNULL(t.Descripcion, '')) as DescTema, Realizar = 'X' FROM Cronograma cr FULL OUTER JOIN Legajo l ON cr.Legajo = l.Codigo INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM LEgajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion FULL OUTER JOIN Tarea p ON l.Perfil = p.Codigo FULL OUTER JOIN Curso c ON cr.Curso = c.Codigo FULL OUTER JOIN Tema t ON cr.Curso = t.Curso and cr.Tema = t.Tema LEFT OUTER JOIN Sector ON l.Sector = Sector.Codigo WHERE cr.Ano = '" +
                        txtAno.Text + "' AND p.Renglon = 1 and cr.Curso = '" + cmbOrganizar.SelectedValue +
                        "' and cr.Curso = l.Curso AND l.Codigo = l2.Actual ORDER BY cr.Legajo, Cr.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) WProgramados.Load(dr);
                    }

                    foreach (DataColumn col in tabla.Columns)
                        col.ReadOnly = false;

                    foreach (DataColumn col in WProgramados.Columns)
                        col.ReadOnly = false;

                    if (tabla.Rows.Count > 0)
                    {
                        if (WProgramados.Rows.Count > 0)
                        {
                            foreach (DataRow row in tabla.Rows)
                            {
                                DataRow[] wRow =
                                    WProgramados.Select("Legajo = '" + row["Legajo"] + "' AND Curso = '" + row["Curso"] + "'");

                                if (wRow.Length > 0)
                                {
                                    row["Realizar"] = "X";
                                }
                            }
                        }

                        foreach (DataRow r in tabla.Select("Realizar = 'X'"))
                        {
                            tabla.Rows.Remove(r);
                        }
                    }

                    foreach (DataRow row in WProgramados.Rows)
                    {
                        tabla.ImportRow(row);
                    }
                }
            }

            return tabla;
        }

        private DataTable _TraerDatosPorPerfiles()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    // AND l.EstaCurso IN (3,4,5,7,8)
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT Clave = '', Tipo = CASE WHEN l.EstaCurso IN (3,4,5,7,8) THEN '2' ELSE '1' END, l.EstaCurso, l.Codigo as Legajo, l.Renglon, l.Sector, Sector.Descripcion as DesSector, l.Descripcion as Nombre, l.Perfil, p.Descripcion as DescPerfil, l.Curso, c.Descripcion as DescCurso, ISNULL(p.Tema, '') as Tema, RTRIM(LTRIM(ISNULL(t.Descripcion, ''))) as DescTema, Horas = 0, Realizado = 0, Realizar = '' FROM Legajo l INNER JOIN (SELECT MIN(Codigo) actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion INNER JOIN Tarea p ON l.Perfil = p.Codigo INNER JOIN Curso c ON p.Curso = c.Codigo FULL OUTER JOIN Tema t ON p.Tema = t.Tema LEFT OUTER JOIN Sector ON l.Sector = Sector.Codigo WHERE l.Perfil = p.Codigo and l.renglon = p.Renglon AND l.FEgreso IN ('  /  /    ', '00/00/0000')  AND l.Perfil = '" +
                        cmbOrganizar.SelectedValue + "' AND l.Codigo = l2.actual ORDER BY l.Codigo, l.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) tabla.Load(dr);
                    }

                    DataTable WProgramados = tabla.Copy();

                    WProgramados.Rows.Clear();
                    WProgramados.Columns.Clear();

                    cmd.CommandText =
                        "SELECT Clave = '', Tipo = '0', cr.Legajo, cr.Renglon, RTRIM(l.Descripcion) as Nombre, l.Perfil, l.EstaCurso, RTRIM(ISNULL(p.Descripcion, '')) as DescPerfil, l.Sector, Sector.Descripcion as DesSector, cr.Curso, RTRIM(ISNULL(c.Descripcion, '')) as DescCurso, cr.Horas, cr.Realizado, ISNULL(cr.Tema, '') as Tema, RTRIM(ISNULL(t.Descripcion, '')) as DescTema, Realizar = 'X' FROM Cronograma cr FULL OUTER JOIN Legajo l ON cr.Legajo = l.Codigo FULL OUTER JOIN Tarea p ON l.Perfil = p.Codigo FULL OUTER JOIN Curso c ON cr.Curso = c.Codigo FULL OUTER JOIN Tema t ON cr.Curso = t.Curso and cr.Tema = t.Tema LEFT OUTER JOIN Sector ON l.Sector = Sector.Codigo WHERE cr.Ano = '" +
                        txtAno.Text + "' AND p.Renglon = 1 and l.Perfil = '" + cmbOrganizar.SelectedValue +
                        "' and cr.Curso = l.Curso ORDER BY cr.Legajo, Cr.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) WProgramados.Load(dr);
                    }

                    foreach (DataColumn col in tabla.Columns)
                        col.ReadOnly = false;

                    foreach (DataColumn col in WProgramados.Columns)
                        col.ReadOnly = false;

                    if (tabla.Rows.Count > 0)
                    {
                        if (WProgramados.Rows.Count > 0)
                        {
                            foreach (DataRow row in tabla.Rows)
                            {
                                DataRow[] wRow =
                                    WProgramados.Select("Legajo = '" + row["Legajo"] + "' AND Curso = '" + row["Curso"] + "'");

                                if (wRow.Length > 0)
                                {
                                    row["Realizar"] = "X";
                                }
                            }
                        }

                        foreach (DataRow r in tabla.Select("Realizar = 'X'"))
                        {
                            tabla.Rows.Remove(r);
                        }
                    }

                    foreach (DataRow row in WProgramados.Rows)
                    {
                        tabla.ImportRow(row);
                    }

                    if (tabla.Rows.Count > 0) tabla.DefaultView.Sort = "Legajo ASC";
                }
            }

            return tabla;
        }

        private DataTable _TraerDatosPorSector()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT Clave = '', Tipo = CASE WHEN l.EstaCurso IN (3,4,5,7,8) THEN '2' ELSE '1' END, l.EstaCurso, l.Codigo as Legajo, l.Renglon, l.Descripcion as Nombre, l.Perfil, p.Descripcion as DescPerfil, l.Curso, c.Descripcion as DescCurso, ISNULL(p.Tema, '') as Tema, RTRIM(LTRIM(ISNULL(t.Descripcion, ''))) as DescTema, Horas = 0, Realizado = 0, Realizar = '' FROM Legajo l INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM LEgajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion INNER JOIN Tarea p ON l.Perfil = p.Codigo INNER JOIN Curso c ON l.Curso = c.Codigo FULL OUTER JOIN Tema t ON p.Tema = t.Tema WHERE l.Perfil = p.Codigo AND l.Codigo = l2.Actual and l.renglon = p.Renglon AND l.FEgreso IN ('  /  /    ', '00/00/0000') AND l.Sector = '" +
                        cmbOrganizar.SelectedValue + "' ORDER BY l.Codigo, l.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) tabla.Load(dr);
                    }

                    DataTable WProgramados = tabla.Copy();

                    WProgramados.Rows.Clear();
                    WProgramados.Columns.Clear();



                    cmd.CommandText = "SELECT DISTINCT Clave = '', Tipo = '0', cr.Legajo, cr.Renglon, " +
                                      "RTRIM(l.Descripcion) as Nombre, l.EstaCurso, l.Perfil, RTRIM(ISNULL(p.Descripcion, '')) " +
                                      "as DescPerfil, cr.Curso, RTRIM(ISNULL(c.Descripcion, '')) as DescCurso, cr.Horas, cr.Realizado, " +
                                      "ISNULL(cr.Tema, '') as Tema, RTRIM(ISNULL(t.Descripcion, '')) as DescTema, Realizar = 'X' " +
                                      "FROM Cronograma cr FULL OUTER JOIN Legajo l ON cr.Legajo = l.Codigo " +
                                      "INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM LEgajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion " +
                                      "FULL OUTER JOIN Tarea p ON l.Perfil = p.Codigo FULL OUTER JOIN Curso c ON l.Curso = c.Codigo FULL OUTER JOIN Tema t ON cr.Curso = t.Curso and cr.Tema = t.Tema " +
                                      "WHERE cr.Ano = '" + txtAno.Text + "' and l.Sector = '" + cmbOrganizar.SelectedValue +"' and cr.Curso = l.Curso AND l.Codigo = l2.Actual ORDER BY cr.Legajo, Cr.Renglon";
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) WProgramados.Load(dr);
                    }

                    foreach (DataColumn col in tabla.Columns)
                        col.ReadOnly = false;

                    foreach (DataColumn col in WProgramados.Columns)
                        col.ReadOnly = false;

                    if (tabla.Rows.Count > 0)
                    {
                        if (WProgramados.Rows.Count > 0)
                        {
                            foreach (DataRow row in tabla.Rows)
                            {
                                DataRow[] wRow =
                                    WProgramados.Select("Legajo = '" + row["Legajo"] + "' AND Curso = '" + row["Curso"] + "'");

                                if (wRow.Length > 0)
                                {
                                    row["Realizar"] = "X";
                                }
                            }
                        }

                        foreach (DataRow r in tabla.Select("Realizar = 'X'"))
                        {
                            tabla.Rows.Remove(r);
                        }
                    }

                    foreach (DataRow row in WProgramados.Rows)
                    {
                        tabla.ImportRow(row);
                    }
                }
            }

            return tabla;
        }

        private void cmbAuxi_DropDownClosed(object sender, EventArgs e)
        {
            cmbAuxi.Visible = false;
            dgvGrilla.Focus();
        }

        private void cmbAuxi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGrilla.CurrentCell.Value = cmbAuxi.SelectedItem;
            dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells["IdCalificacion"].Value = cmbAuxi.SelectedIndex;
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Evitamos que se copien las cabeceras.
            dgvGrilla.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            // Copiamos el contenido de las celdas seleccionadas en el ClipBoard.
            _CopiarSeleccion();
        }

        private void _CopiarSeleccion()
        {
            if (dgvGrilla.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                // Evitamos que los 'Rows Headers' ocupen espacio.
                dgvGrilla.RowHeadersVisible = false;

                object data = dgvGrilla.GetClipboardContent();
                if (data != null)
                    Clipboard.SetDataObject(data);

                // Volvemos a mostrar los 'Rows Headers'
                dgvGrilla.RowHeadersVisible = true;
            }
        }

        private void copiarConCabecerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Activamos que se copien las cabeceras.
            dgvGrilla.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            // Copiamos el contenido de las celdas seleccionadas en el ClipBoard.
            _CopiarSeleccion();

        }

        private void dgvGrilla_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridView WGrilla = dgvGrilla;

            DataGridViewColumn column = WGrilla.Columns["Realizar"];
            if (column != null && column.Index == e.ColumnIndex)
            {
                var WValor = WGrilla.Rows[e.RowIndex].Cells["Realizar"].Value ?? "";
                var WTipo = WGrilla.Rows[e.RowIndex].Cells["Tipo"].Value ?? "";

                if (WTipo.ToString() != "")
                    WGrilla.Rows[e.RowIndex].Cells["Realizar"].Value = WValor.ToString() == "" ? "X" : "";
            }
        }

        private void marcarParaRealizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedCells.Count > 0)
            {
                foreach (DataGridViewTextBoxCell celda in dgvGrilla.SelectedCells)
                {
                    var WTipo = dgvGrilla.Rows[celda.RowIndex].Cells["Tipo"].Value ?? "";

                    if (WTipo.ToString() != "")
                        dgvGrilla.Rows[celda.RowIndex].Cells["Realizar"].Value = "X";
                }
            }
        }

        private void desmarcarParaRealizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedCells.Count > 0)
            {
                foreach (DataGridViewTextBoxCell celda in dgvGrilla.SelectedCells)
                {
                    var WTipo = dgvGrilla.Rows[celda.RowIndex].Cells["Tipo"].Value ?? "";

                    if (WTipo.ToString() != "")
                        dgvGrilla.Rows[celda.RowIndex].Cells["Realizar"].Value = "";
                }
            }
        }

        private void dgvGrilla_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvGrilla.SelectedCells.Count > 1) return;

                DataGridView.HitTestInfo WHit = dgvGrilla.HitTest(e.X, e.Y);

                if (WHit.Type == DataGridViewHitTestType.Cell)
                {
                    dgvGrilla.CurrentCell = dgvGrilla.Rows[WHit.RowIndex].Cells[WHit.ColumnIndex];
                }
            }
        }

        private void asignarModificarCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count == 0) return;
            if (dgvGrilla.SelectedCells.Count == 0) return;

            int wRowIndex = dgvGrilla.CurrentCell.RowIndex;

            var WTema = dgvGrilla.Rows[wRowIndex].Cells["Curso"].Value ?? "";

            if (rbTema.Checked)
            {
                WTema = cmbOrganizar.SelectedValue.ToString();
            }

            if (WTema.ToString() == "") return;

            _AbrirAyuda(WTema.ToString());

        }

        private void quitarCursoAsignadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedCells.Count == 0) return;

            int wRowIndex = dgvGrilla.CurrentCell.RowIndex;

            dgvGrilla.Rows[wRowIndex].Cells["Tema"].Value = "0";
            dgvGrilla.Rows[wRowIndex].Cells["DescTema"].Value = "";
            dgvGrilla.Rows[wRowIndex].Cells["Horas"].Value = "0";
        }

        private void cmbOrganizar_DropDownClosed(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void dgvGrilla_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            dgvGrilla.ClearSelection();

            for (int i = 0; i < dgvGrilla.Rows.Count; i++)
            {
                dgvGrilla.Rows[i].Cells[e.ColumnIndex].Selected = true;
            }
        }

        private void ckSoloSugeridos_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                cmbOrganizar.SelectedValue = txtCodigo.Text;

                if (cmbOrganizar.SelectedIndex > 0)
                {
                    txtAno.Focus();
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }
    }
}
