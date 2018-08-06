using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    public partial class ActualizacionDeCompetenciasYNecesidadesDeCapacitacion : Form
    {

        private Color WAnteriorBackColor;
        private Color WAnteriorForeColor;
        private Color WBackColorOriginal;

        public ActualizacionDeCompetenciasYNecesidadesDeCapacitacion()
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
            dgvAyuda.Rows.Clear();
            txtFiltrar.Text = "";
            txtCodigo.Text = "";
            cmbAuxi.Visible = false;
            _CargarPerfiles();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
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

                        bool WActualizaVersion = MessageBox.Show(
                            "¿Desea Actualizar Version? Recuerde que esto afecta a todos los Legajos aqui listados.",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                        List<string> WAProcesar = new List<string>();

                        if (WActualizaVersion)
                        {
                            // Guardamos la version actual de cada uno de los legajos antes de actualizar los datos de las Necesidades y Competencias de cada uno.
                            foreach (DataGridViewRow _row in dgvGrilla.Rows)
                            {
                                var WLegajo = _row.Cells["Legajo"].Value ?? "";

                                if (WLegajo.ToString() == "") continue;
                                if (WAProcesar.Exists(l => l == WLegajo.ToString())) continue;

                                WAProcesar.Add(WLegajo.ToString());
                            }

                            // Traemos los datos del legajo.
                            DataTable WDatos = _TraerDatosLegajo(WAProcesar);

                            if (WDatos.Rows.Count > 0)
                            {
                                string WLegajo = "";
                                // Guardamos la version del Legajo.
                                foreach (DataRow Row in WDatos.Rows)
                                {
                                    WLegajo = Row["Codigo"].ToString();

                                    cmd.CommandText = "INSERT INTO LegajoVersion (Clave ,Codigo ,Version ,Renglon ,Descripcion ,FIngreso ,Perfil ,EstadoI ,EstadoII ,EstadoIII ,EstadoIV ,EstadoV ,EstadoVI ,EstadoVII ,EstadoVIII ,EstadoIX ,Curso ,EstadoCurso ,EstaI ,EstaII ,EstaIII ,EstaIV ,EstaV ,EstaVI ,EstaVII ,EstaVIII ,EstaIX ,EstaCurso ,ClavePerfil ,NecesariaCurso ,DeseableCurso ,FechaVersionI ,FechaVersionII ,Fegreso ,Tema ,PerfilVersion ,EstaX ,EstadoX) VALUES ("
                                                    + "'" + Helper.Ceros(Row["Codigo"].ToString(), 6) + Helper.Ceros(Row["Version"].ToString(), 4) + Helper.Ceros(Row["Renglon"].ToString(), 2) + "',"
                                                    + "'" + Row["Codigo"] + "',"
                                                    + "'" + Row["Version"] + "',"
                                                    + "'" + Row["Renglon"] + "',"
                                                    + "'" + Row["Descripcion"] + "',"
                                                    + "'" + Row["FIngreso"] + "',"
                                                    + "" + Row["Perfil"] + ","
                                                    + "'" + Row["EstadoI"] + "',"
                                                    + "'" + Row["EstadoII"] + "',"
                                                    + "'" + Row["EstadoIII"] + "',"
                                                    + "'" + Row["EstadoIV"] + "',"
                                                    + "'" + Row["EstadoV"] + "',"
                                                    + "'" + Row["EstadoVI"] + "',"
                                                    + "'" + Row["EstadoVII"] + "',"
                                                    + "'" + Row["EstadoVIII"] + "',"
                                                    + "'" + Row["EstadoIX"] + "',"
                                                    + "" + Row["Curso"] + ","
                                                    + "'" + Row["EstadoCurso"] + "',"
                                                    + "" + Row["EstaI"] + ","
                                                    + "" + Row["EstaII"] + ","
                                                    + "" + Row["EstaIII"] + ","
                                                    + "" + Row["EstaIV"] + ","
                                                    + "" + Row["EstaV"] + ","
                                                    + "" + Row["EstaVI"] + ","
                                                    + "" + Row["EstaVII"] + ","
                                                    + "" + Row["EstaVIII"] + ","
                                                    + "" + Row["EstaIX"] + ","
                                                    + "" + Row["EstaCurso"] + ","
                                                    + "'" + Row["ClavePerfil"] + "',"
                                                    + "'" + Row["NecesariaCurso"] + "',"
                                                    + "'" + Row["DeseableCurso"] + "',"
                                                    + "'" + Row["FechaVersion"] + "',"
                                                    + "'" + DateTime.Now.ToString("dd/MM/yyyy") + "',"
                                                    + "'" + Row["FEgreso"] + "',"
                                                    + "'" + Row["Tema"] + "',"
                                                    + "" + Row["PerfilVersion"] + ","
                                                    + "'" + Row["EstaX"] + "',"
                                                    + "'" + Row["EstadoX"] + "'"
                                                    + ")";


                                    cmd.ExecuteNonQuery();
                                }

                                // Incrementamos la numeracion de la Version en el Legajo.
                                cmd.CommandText = "UPDATE Legajo SET Version = Version + 1 WHERE Codigo = '" + WLegajo + "'";
                                cmd.ExecuteNonQuery();
                            }


                        }

                        // Actualizamos cada uno de los renglones
                        foreach (DataGridViewRow row in dgvGrilla.Rows)
                        {
                            var WClave = row.Cells["Clave"].Value;
                            var WCalificacion = row.Cells["idCalificacion"].Value;
                            var WObservaciones = row.Cells["Observaciones"].Value;
                            var WMarca = row.Cells["Marca"].Value;
                            var WMarcar = row.Cells["MarcarActualizacion"].Value;
                            
                            if (WClave == null) continue;

                            string WLegajo = int.Parse(Helper.Left(WClave.ToString(), 6)).ToString();

                            cmd.CommandText = "UPDATE Legajo SET EstaCurso = '" + WCalificacion + "', EstadoCurso = '" + WObservaciones + "' WHERE Clave = '" + WClave + "'";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DELETE LegajoMarcaModificacion WHERE Clave = '" + WClave + "'";
                            cmd.ExecuteNonQuery();

                            if (WMarca.ToString() == "X" || WMarcar.ToString() == "X")
                            {
                                cmd.CommandText = "INSERT INTO LegajoMarcaModificacion (Clave, Legajo, Fecha, FechaOrd, Actualizado) VALUES ('" + WClave + "', '" + WLegajo + "', '" + DateTime.Now.ToString("dd/MM/yyyy") + "', '" + Helper.OrdenarFecha(DateTime.Now.ToString("dd/MM/yyyy")) + "', 'X')";
                                cmd.ExecuteNonQuery();
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

        private DataTable _TraerDatosLegajo(List<string> wLegajo)
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

                        string WLegajos = "";

                        foreach (string l in wLegajo)
                        {
                            WLegajos += l + ",";
                        }

                        WLegajos = WLegajos.TrimEnd(',');

                        cmd.CommandText = "SELECT * FROM Legajo WHERE Codigo IN (" + WLegajos + ") ORDER BY Codigo, Renglon";

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


        private void IngreDeCursosRealizados_Load(object sender, EventArgs e)
        {
            cmbAuxi.Visible = false;
            pnlAyuda.Visible = false;

            rbPerfil.Checked = true;
            pnlProgreso.Visible = false;

            WBackColorOriginal = dgvGrilla.DefaultCellStyle.BackColor;
            _CargarPerfiles();
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
            _AbrirAyuda();
        }

        private void _AbrirAyuda()
        {
            DataTable temas = _TraerTemas();
            dgvAyuda.DataSource = temas;

            DataGridViewColumn column = dgvAyuda.Columns["Descripcion"];
            if (column != null)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            pnlAyuda.Location = Helper._CentrarH(Width, pnlAyuda);
            pnlAyuda.Visible = true;
            txtFiltrar.Text = "";
            txtFiltrar.Focus();
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
                    cmd.CommandText = "SELECT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Descripcion";

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

            string tema = dgvAyuda.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();

            txtTema.Text = tema;

            btnCerrarAyuda.PerformClick();

            //_CargarTema();

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            _AbrirAyuda();
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

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    
                    if (rbPerfil.Checked)
                        cmd.CommandText = "SELECT Legajo.Clave, Legajo.Perfil, Tarea.Descripcion as DescPerfil, Legajo.Renglon, Legajo.Codigo as Legajo, Legajo.Descripcion as Nombre, Legajo.Curso, ISNULL(Curso.Descripcion, '') as DescCurso, ISNULL(Tarea.NecesariaCurso, '') as Necesario, ISNULL(Tarea.DeseableCurso, '') as Deseable, ISNULL(Legajo.Estacurso, '') as Calificacion, ISNULL(Legajo.EstadoCurso, '') as Observaciones, Marca = ISNULL(LMM.Actualizado, '') FROM Legajo FULL OUTER JOIN Curso ON Legajo.Curso = Curso.Codigo FULL OUTER JOIN Tarea ON Legajo.Perfil = Tarea.Codigo FULL OUTER JOIN LegajoMarcaModificacion LMM ON Legajo.Clave = LMM.Clave WHERE Tarea.Renglon = 1 AND Legajo.Perfil = '" + cmbOrganizar.SelectedValue + "' AND Legajo.Clave IS NOT NULL AND Legajo.FEgreso IN ('  /  /    ', '00/00/0000') ORDER BY Legajo.Descripcion, Legajo.Codigo, Legajo.Renglon";

                    if (rbSector.Checked)
                        cmd.CommandText = "SELECT Legajo.Clave, Legajo.Perfil, Tarea.Descripcion as DescPerfil, Legajo.Renglon, Legajo.Codigo as Legajo, Legajo.Descripcion as Nombre, Legajo.Curso, ISNULL(Curso.Descripcion, '') as DescCurso, ISNULL(Tarea.NecesariaCurso, '') as Necesario, ISNULL(Tarea.DeseableCurso, '') as Deseable, ISNULL(Legajo.Estacurso, '') as Calificacion, ISNULL(Legajo.EstadoCurso, '') as Observaciones, Marca = ISNULL(LMM.Actualizado, '') FROM Legajo FULL OUTER JOIN Curso ON Legajo.Curso = Curso.Codigo FULL OUTER JOIN Tarea ON Legajo.Perfil = Tarea.Codigo FULL OUTER JOIN LegajoMarcaModificacion LMM ON Legajo.Clave = LMM.Clave WHERE Tarea.Renglon = 1 AND Legajo.Clave IS NOT NULL AND Legajo.FEgreso IN ('  /  /    ', '00/00/0000') AND Legajo.Sector = '" + cmbOrganizar.SelectedValue + "' ORDER BY Legajo.Perfil, Legajo.Descripcion, Legajo.Codigo, Legajo.Renglon";
                    
                    //pnlProgreso.Location = Helper._CentrarH(Width, pnlProgreso);
                    //pnlProgreso.Visible = true;
                    //progressBar1.Maximum = 100;
                    //progressBar1.Value = 0;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                WRowindex = dgvGrilla.Rows.Add();

                                if (dr["Renglon"].ToString() == "1")
                                {
                                    if (WRowindex != 0) WRowindex = dgvGrilla.Rows.Add();

                                    dgvGrilla.Rows[WRowindex].Cells["Perfil"].Value = dr["Perfil"];
                                    dgvGrilla.Rows[WRowindex].Cells["DescPerfil"].Value = dr["DescPerfil"];
                                    dgvGrilla.Rows[WRowindex].Cells["Legajo"].Value = dr["Legajo"];
                                    dgvGrilla.Rows[WRowindex].Cells["Nombre"].Value = dr["Nombre"];
                                }

                                dgvGrilla.Rows[WRowindex].Cells["Clave"].Value = dr["Clave"];
                                dgvGrilla.Rows[WRowindex].Cells["Curso"].Value = dr["Curso"];
                                dgvGrilla.Rows[WRowindex].Cells["DescCurso"].Value = dr["DescCurso"].ToString().Trim().PadRight(5, ' ');
                                dgvGrilla.Rows[WRowindex].Cells["Necesario"].Value = dr["Necesario"];
                                dgvGrilla.Rows[WRowindex].Cells["Deseable"].Value = dr["Deseable"];
                                dgvGrilla.Rows[WRowindex].Cells["idCalificacion"].Value = dr["Calificacion"];
                                dgvGrilla.Rows[WRowindex].Cells["idCalificacionAnterior"].Value = dr["Calificacion"];
                                dgvGrilla.Rows[WRowindex].Cells["Calificacion"].Value = _TraerDescripcionCalificacion(dr["Calificacion"].ToString());
                                dgvGrilla.Rows[WRowindex].Cells["Observaciones"].Value = dr["Observaciones"].ToString().Trim();
                                dgvGrilla.Rows[WRowindex].Cells["Marca"].Value = dr["Marca"].ToString().Trim();
                                dgvGrilla.Rows[WRowindex].Cells["MarcarActualizacion"].Value = dr["Marca"].ToString().Trim();


                                if (progressBar1.Value < progressBar1.Maximum) progressBar1.Increment(1);
                            }
                        }
                    }
                    pnlProgreso.Visible = false;
                }

            }

            var WColNombre = dgvGrilla.Columns["Nombre"];
            var WColCurso = dgvGrilla.Columns["DescCurso"];
            var WColPerfil = dgvGrilla.Columns["DescPerfil"];

            if (rbPerfil.Checked)
            {
                if (WColCurso != null) WColCurso.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (WColNombre != null) WColNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

                foreach (string Columna in new []{"Perfil", "DescPerfil"})
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = false;
                }
            }

            if (rbSector.Checked)
            {
                if (WColCurso != null) WColCurso.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (WColNombre != null) WColNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (WColPerfil != null) WColPerfil.Width = 175;

                foreach (string Columna in new[] { "Perfil", "DescPerfil" })
                {
                    DataGridViewColumn c = dgvGrilla.Columns[Columna];
                    if (c != null) c.Visible = true;
                }
            }

            ProcesarColoracionActualizacion();

            if (dgvGrilla.Rows.Count == 0) MessageBox.Show("No hay datos que listar.");
        }

        private void ProcesarColoracionActualizacion()
        {
            foreach (DataGridViewRow row in dgvGrilla.Rows)
            {
                var WMarca = row.Cells["Marca"].Value ?? "";

                if (WMarca.ToString() == "X")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
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

        private string _TraerCalificacionPorDescripcion(string WCalificacion)
        {
            switch (WCalificacion)
            {
                case "Exede":
                    {
                        return "1";
                    }
                case "Cumple":
                    {
                        return "2";
                    }
                case "Reforzar":
                    {
                        return "3";
                    }
                case "En Entrenamiento":
                    {
                        return "4";
                    }
                case "No Cumple":
                    {
                        return "5";
                    }
                case "No Aplica":
                    {
                        return "6";
                    }
                case "No Evalúa":
                    {
                        return "7";
                    }
                case "Cumple Act.":
                    {
                        return "8";
                    }
                default:
                    {
                        return "0";
                    }
            }
        }

        private void dgvGrilla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var WGrilla = dgvGrilla;

            DataGridViewColumn column = WGrilla.Columns["Calificacion"];
            if (column != null && column.Index != e.ColumnIndex) return;

            var WClave = WGrilla.Rows[e.RowIndex].Cells["Clave"].Value;
            if (WClave == null || WClave.ToString() == "") return;

            var WCellRectangule = WGrilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            WAnteriorBackColor = WGrilla.DefaultCellStyle.SelectionBackColor;
            WAnteriorForeColor = WGrilla.DefaultCellStyle.SelectionForeColor;

            WGrilla.DefaultCellStyle.SelectionBackColor = WGrilla.DefaultCellStyle.BackColor;
            WGrilla.DefaultCellStyle.SelectionForeColor = WGrilla.DefaultCellStyle.ForeColor;

            cmbAuxi.Location = new Point(WCellRectangule.Location.X + WGrilla.Margin.Left, WCellRectangule.Location.Y + WGrilla.Location.Y + WCellRectangule.Height * 2 - WGrilla.Margin.Top * 2);
            cmbAuxi.Width = WCellRectangule.Width;
            cmbAuxi.Height = WCellRectangule.Height + WGrilla.Margin.Top + WGrilla.ColumnHeadersHeight;

            cmbAuxi.Visible = true;
            cmbAuxi.SelectedIndex = int.Parse(_TraerCalificacionPorDescripcion(WGrilla.CurrentCell.Value.ToString()));
            cmbAuxi.DroppedDown = true;
        }

        private void cmbAuxi_DropDownClosed(object sender, EventArgs e)
        {
            cmbAuxi.Visible = false;
            dgvGrilla.DefaultCellStyle.SelectionBackColor = WAnteriorBackColor;
            dgvGrilla.DefaultCellStyle.SelectionForeColor = WAnteriorForeColor;
            dgvGrilla.Focus();
        }

        private void cmbAuxi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGrilla.CurrentCell.Value = cmbAuxi.SelectedItem;
            dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].DefaultCellStyle.BackColor = WBackColorOriginal;
            dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells["MarcarActualizacion"].Value = "";


            var WMarca = dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells["Marca"].Value ?? "";

            if (WMarca.ToString() == "X")
            {
                dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }

            if (dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells["IdCalificacionAnterior"].Value.ToString() !=
                cmbAuxi.SelectedIndex.ToString())
            {
                dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells["MarcarActualizacion"].Value = "X";
            }

            dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells["IdCalificacion"].Value = cmbAuxi.SelectedIndex;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                cmbOrganizar.SelectedValue = txtCodigo.Text;

                if (cmbOrganizar.SelectedIndex > 0)
                {
                    btnBuscar.PerformClick();
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }
    }
}
