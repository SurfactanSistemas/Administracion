using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Modulo_Capacitacion.Listados;
using Negocio;

namespace Modulo_Capacitacion.Novedades
{
    public partial class IngresoDeCursosRealizados : Form
    {
        Curso C = new Curso();

        Tema T = new Tema();

        private int WTipoConsulta = 0;

        //bool Modificar = true;
        public IngresoDeCursosRealizados()
        {
            InitializeComponent();
        }

        private void IngresoDeCursosRealizados_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
        }

        private string _TraerProximoCodigo()
        {
            int proximo = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT MAX(Codigo) as CodigoMayor FROM Cursadas";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            proximo = int.Parse(dr["CodigoMayor"].ToString());
                        }
                    }
                }

            }

            return (proximo + 1).ToString();
        }

        private void TB_CodTema_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Tema tema = new Tema();

                if (e.KeyCode == Keys.Enter)
                {
                    BuscarDescripcionTema();

                    //TB_Codigo.Text = tema.ObtenerUltimo(TB_CodTema.Text).ToString();
                };
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void TB_CodCurso_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (txtDesTema.Text == "") throw new Exception("Se debe cargar el tema primero");
                if (e.KeyCode == Keys.Enter)
                {
                    BuscarDescripcionCurso();

                    //TB_Codigo.Text = tema.ObtenerUltimo(TB_CodTema.Text).ToString();
                };
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BuscarDescripcionCurso()
        {
            int valor = 0;

            int.TryParse(txtCurso.Text, out valor);

            if (txtCurso.Text == "" || valor == 0) throw new Exception("Por favor ingrese un codigo valido");
            //Tema tema = new Tema();
            C = C.BuscarUnoPorTema(txtTema.Text,txtCurso.Text);

            if (C.Descripcion != null) txtDesCurso.Text = C.Descripcion;
            else throw new Exception("No se encontro ningun Tema con el numero de codigo ingresado");
        }

        private void BuscarDescripcionTema()
        {
            int valor = 0;

            int.TryParse(txtTema.Text, out valor);

            if (txtTema.Text == "" || valor == 0) throw new Exception("Por favor ingrese un codigo valido");
            //Tema tema = new Tema();
            T = T.BuscarUno(txtTema.Text);

            if (T.Descripcion != null) txtDesTema.Text = T.Descripcion;
            else throw new Exception("No se encontro ningun Tema con el numero de codigo ingresado");

        }

        private void IngresoDeCursosRealizados_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                // Buscamos, si existe lo cargamos
                try
                {
                    string WCodigo = txtCodigo.Text;
                    btnLimpiar.PerformClick();

                    if (_ExisteCursada(WCodigo))
                    {
                        _CargarCursada(WCodigo);
                    }
                    else
                    {
                        btnAyudaTema.PerformClick();
                    }

                    txtCodigo.Text = WCodigo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }

        private void _CargarCursada(string WCodigo)
        {
            try
            {
                DataTable WDatos = new DataTable();
                dgvGrilla.Rows.Clear();
                int WRenglon = 0;

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "select cu.Codigo, cu.Curso, c.Descripcion as DesCurso, cu.Tema, t.Descripcion as DesTema, cu.Fecha, cu.Horas, cu.TipoI, cu.TipoII, cu.Instructor, cu.Actividad, cu.Temas, cu.Legajo, l.Descripcion as DesLegajo, cu.Observaciones from Cursadas cu LEFT OUTER JOIN Legajo l ON cu.Legajo = l.Codigo and l.Renglon = 1 LEFT OUTER JOIN Curso c ON cu.Curso = c.Codigo LEFT OUTER JOIN Tema t ON cu.Tema = t.Tema AND c.Codigo = t.Curso where cu.Codigo = '" + WCodigo + "' order by cu.Renglon";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                WDatos.Load(dr);
                            }
                        }

                        foreach (DataRow row in WDatos.Rows)
                        {
                            txtCodigo.Text = WCodigo;
                            txtTema.Text = row["Curso"].ToString().Trim();
                            txtDesTema.Text = row["DesCurso"].ToString().Trim();
                            txtCurso.Text = row["Tema"].ToString().Trim();
                            txtDesCurso.Text = row["DesTema"].ToString().Trim();
                            txtFecha.Text = row["Fecha"].ToString();
                            txtHoras.Text = Helper.FormatoNumerico(row["Horas"]);
                            cmbTipo.SelectedIndex = int.Parse(row["TipoI"].ToString());
                            cmbTipoProgramacion.SelectedIndex = int.Parse(row["TipoII"].ToString());
                            txtInstructor.Text = row["Instructor"].ToString().Trim();
                            txtActividad.Text = row["Actividad"].ToString().Trim();
                            txtTemas.Text = row["Temas"].ToString().Trim();

                            WRenglon = dgvGrilla.Rows.Add();
                            dgvGrilla.Rows[WRenglon].Cells["Legajo"].Value = row["Legajo"].ToString().Trim();
                            dgvGrilla.Rows[WRenglon].Cells["Nombre"].Value = row["DesLegajo"].ToString().Trim();
                            dgvGrilla.Rows[WRenglon].Cells["Observaciones"].Value = row["Observaciones"].ToString().Trim();

                        }

                        //dgvGrilla.Rows.Add();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private bool _ExisteCursada(string WCodigo)
        {
            try
            {
                bool existe = false;

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo FROM Cursadas WHERE Codigo = '" + WCodigo + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            existe = dr.HasRows;
                        }
                    }

                }

                return existe;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
                throw;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in new []{txtCodigo, txtTema, txtCurso, txtDesCurso, txtDesTema, txtActividad, txtInstructor, txtHoras, txtTemas, txtAyuda})
            {
                txt.Text = "";
            }

            foreach (MaskedTextBox msk in new[] { txtFecha })
            {
                msk.Clear();
            }

            foreach (DataGridView dgv in new[] { dgvGrilla, dgvAyuda })
            {
                if (dgv.DataSource == null) dgv.Rows.Clear();
                dgv.DataSource = null;
            }

            foreach (ComboBox cmb in new[] { cmbTipo, cmbTipoProgramacion, cmbTipoLegajos })
            {
                cmb.SelectedIndex = 0;
            }

            pnlAyuda.Visible = false;
            WTipoConsulta = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCodigo.Text = _TraerProximoCodigo();
            txtCodigo.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!DatosValidos()) return;
            
            // Obtenemos los datos de la Cursada en caso de actualizar.
            DataTable WDatosAnteriores = new DataTable();
            SqlTransaction trans = null;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();
                trans = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Cursadas WHERE Codigo = '" + txtCodigo.Text + "'";
                    cmd.Transaction = trans;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WDatosAnteriores.Load(dr);
                        }
                    }

                    // Recorremos y restauramos los valores de 'Realizado' para cada legajo en el cronograma (Realizado - Horas).
                    foreach (DataRow WAnt in WDatosAnteriores.Rows)
                    {
                        cmd.CommandText = "UPDATE Cronograma SET Realizado = Realizado - " + Helper.FormatoNumerico(WAnt["Horas"]) + " WHERE Legajo = '" + WAnt["Legajo"] + "' AND Curso = '" + WAnt["Curso"] + "' AND Ano = '" + Helper.Right(WAnt["Fecha"].ToString(), 4) + "'" ;
                        cmd.ExecuteNonQuery();
                    }

                    // Borramos la cursada
                    cmd.CommandText = "DELETE FROM Cursadas WHERE Codigo = '" + txtCodigo.Text + "'";
                    cmd.ExecuteNonQuery();

                    // Grabamos con una hora en caso de que no se haya especificado algun valor.
                    if (txtHoras.Text.Trim() == "") txtHoras.Text = "0";
                    if (double.Parse(txtHoras.Text) <= 0) txtHoras.Text = "1";

                    // Regrabamos y actualizamos los datos de 'Realizado' en Cronograma.
                    int WRenglon = 0;
                    string WCodigo = txtCodigo.Text;
                    string WHoras = Helper.FormatoNumerico(txtHoras.Text);
                    string WTemas = Helper.Left(txtTemas.Text, 100);
                    string WInstructor = Helper.Left(txtInstructor.Text, 50);
                    string WActividad = Helper.Left(txtActividad.Text, 50);
                    int WTipoI = cmbTipo.SelectedIndex;
                    int WTipoII = cmbTipoProgramacion.SelectedIndex;
                    string WTema = txtTema.Text;
                    string WCurso = txtCurso.Text;
                    string WFecha = txtFecha.Text;
                    string WFechaOrd = Helper.OrdenarFecha(WFecha);

                    foreach (DataGridViewRow row in dgvGrilla.Rows)
                    {
                        WRenglon++;

                        string WClave = Helper.Ceros(WCodigo, 6) + Helper.Ceros(WRenglon, 2);
                        var WLegajo = row.Cells["Legajo"].Value ?? "";
                        var WObservaciones = row.Cells["Observaciones"].Value ?? "";

                        if (WLegajo.ToString() == "") continue;

                        cmd.CommandText = "INSERT INTO Cursadas "
                                        + " (Clave, Codigo, Renglon, Curso, Tema, Fecha, OrdFecha, Horas, " 
                                        + " TipoI, TipoII, Instructor, Actividad, Temas, Legajo, DesLegajo,"
                                        + " DesSector, DesCurso, DesTema, Observaciones) "
                                        + " VALUES "
                                        + " ('" + WClave + "', " + WCodigo + "," + WRenglon + ", " + WTema + ", " + WCurso + ", '" + WFecha + "', '" + WFechaOrd + "', "
                                        + " " + WHoras + ", " + WTipoI + ", " + WTipoII + ", '" + WInstructor + "', '" + WActividad + "', '" + WTemas + "', "
                                        + " " + WLegajo + ", '', '', '', '', '" + WObservaciones + "' )";
                        cmd.ExecuteNonQuery();

                    }

                    trans.Commit();

                    if (
                        MessageBox.Show(
                            "Actualizado Correctamente!" + Environment.NewLine + "¿Desea Imprimir la Planilla?", "",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Imprimimos la planilla con las personas indicadas.
                        VistaPrevia frm = new VistaPrevia();
                        frm.CargarReporte(new Reportes.Cursada.planillacursada(), "{Cursadas.Curso} = {Curso.Codigo} AND {Cursadas.Legajo} = {Legajo.Codigo} AND {Legajo.Renglon} = 1 AND {Cursadas.Codigo} = " + WCodigo);
                        frm.Imprimir();
                    }

                    btnLimpiar.PerformClick();
                }

            }
        }

        private bool DatosValidos()
        {
            // Verificamos que hayan legajos cargados.
            if (dgvGrilla.Rows.Count == 0) return false;

            // Validamos que se haya cargado un tema.
            if (txtTema.Text.Trim() == "")
            {
                MessageBox.Show("No se ha cargado un Tema");
                return false;
            }

            // Validamos que sea un tema valido.
            if (!_TemaValido(txtTema.Text))
            {
                MessageBox.Show("El Tema ingresado no es válido.");
                return false;
            }

            // Validamos que se haya cargado un Curso.
            if (txtCurso.Text.Trim() == "")
            {
                MessageBox.Show("No se ha cargado un Curso");
                return false;
            }

            // Validamos que sea un curso valido.
            if (!_CursoValido(txtTema.Text, txtCurso.Text))
            {
                MessageBox.Show("El Curso ingresado no es válido.");
                return false;
            }

            // Verificamos que todos los ingresados no se encuentren dados de baja.
            foreach (DataGridViewRow row in dgvGrilla.Rows)
            {
                var WLegajo = row.Cells["Legajo"].Value ?? "";

                if (WLegajo.ToString() == "") continue;

                if (_LegajoDatoDeBaja(WLegajo.ToString()))
                {
                    MessageBox.Show("El Legajo " + row.Cells["Legajo"].Value + " se encuentra dado de baja.");
                    return false;
                }
            }

            return true;
        }

        private bool _CursoValido(string WTema, string WCurso)
        {
            try
            {
                bool WValido = false;

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Curso FROM Tema WHERE Tema  = '" + WCurso + "' AND Curso = '" + WTema + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            WValido = dr.HasRows;
                        }
                    }

                }

                return WValido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private bool _TemaValido(string WTema)
        {
            bool WValido;

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo FROM Curso WHERE Codigo = '" + WTema + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            WValido = dr.HasRows;
                        }
                    }

                }

                return WValido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private bool _LegajoDatoDeBaja(string WLegajo)
        {
            bool enbaja = false;

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT BAJA = CASE FEgreso WHEN '  /  /    ' THEN 'N' WHEN '00/00/0000' THEN 'N' ELSE 'S' END FROM Legajo WHERE Codigo = '" + WLegajo + "' AND Renglon = 1";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                if (dr["Baja"].ToString() == "S") enbaja = true;
                            }
                        }
                    }

                }

                return enbaja;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            WTipoConsulta = 4;

            tabla = _TraerLegajos();

            DataTable tabla2 = tabla.Clone();

            if (dgvGrilla.Rows.Count > 0)
            {
                bool WEncontrado;
                // Eliminamos los legajos que ya se encuentren en la grilla.
                foreach (DataRow row in tabla.Rows)
                {
                    var WLegajo = row["Codigo"] ?? "";

                    if (WLegajo.ToString() == "") continue;

                    WEncontrado = false;
                    foreach (DataGridViewRow row2 in dgvGrilla.Rows)
                    {
                        if (WLegajo.ToString() == row2.Cells["Legajo"].Value.ToString())
                        {
                            WEncontrado = true;
                        }
                    }

                    if (!WEncontrado) tabla2.ImportRow(row);
                }
            }

            dgvAyuda.DataSource = dgvGrilla.Rows.Count == 0 ? tabla : tabla2;

            WTipoConsulta = 0;

            DataGridViewColumn _columna = dgvAyuda.Columns["Descripcion"];
            if (_columna != null) _columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            pnlAyuda.Visible = true;
            txtAyuda.Text = "";
            txtAyuda.Focus();
        }

        private DataTable _TraerLegajos()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "select l.Codigo, RTRIM(LTRIM(l.Descripcion)) as Descripcion FROM Legajo l INNER JOIN (SELECT Descripcion, MIN(Codigo) as actual FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion WHERE l.Codigo = l2.actual and l.renglon = 1 and l.Fegreso in ('  /  /    ', '00/00/0000') ORDER BY l.Descripcion";

                        gbLegajos.Visible = false;

                        if (txtTema.Text.Trim() != "")
                        {
                            if (WTipoConsulta == 4 && cmbTipoProgramacion.SelectedIndex == 0)
                            {
                                if (txtTema.Text.Trim() != "" && cmbTipoLegajos.SelectedIndex == 0)
                                    cmd.CommandText = "SELECT DISTINCT cr.Legajo AS Codigo, RTRIM(LTRIM(l.Descripcion)) Descripcion FROM Cronograma cr INNER JOIN Legajo l ON cr.Legajo = l.Codigo AND l.Renglon = 1 AND l.FEgreso IN ('  /  /     ', '00/00/0000') INNER JOIN (SELECT Descripcion, MIN(Codigo) as actual FROM Legajo GROUP BY Descripcion) l2 ON l.Descripcion = l2.Descripcion WHERE cr.Curso = '" + txtTema.Text + "' AND l.Codigo = l2.actual ORDER BY Descripcion, cr.Legajo";
                            }

                            gbLegajos.Visible = cmbTipoProgramacion.SelectedIndex == 0;
                        }

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
        }

        private void txtAyuda_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvAyuda.DataSource as DataTable;
            if (tabla != null)
            {
                tabla.DefaultView.RowFilter = string.Format("Descripcion LIKE '%{0}%'", txtAyuda.Text);
            }
        }

        private void dgvAyuda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var WCodigo = dgvAyuda.Rows[e.RowIndex].Cells["Codigo"].Value ?? "";

            if (WCodigo.ToString() == "") return;

            switch (WTipoConsulta)
            {
                case 4:
                case 0:
                {
                    _CargarLegajo(WCodigo);
                    dgvAyuda.CurrentCell = null;
                    dgvAyuda.Rows[e.RowIndex].Visible = false;
                    break;
                }
                case 1:
                {
                    _CargarTema(WCodigo);
                    btnCerrarAyuda.PerformClick();
                    break;
                }
                case 2:
                {
                    _CargarCurso(WCodigo);
                    btnCerrarAyuda.PerformClick();
                    txtFecha.Focus();
                    break;
                }
                case 3:
                {
                    _CargarTema(WCodigo);
                    btnAyudaCursos.PerformClick();
                    break;
                }
                default:
                {
                    return;
                }
            }
        }

        private void _CargarCurso(object wCodigo)
        {
            txtCurso.Text = wCodigo.ToString();
            txtDesCurso.Text = _TraerDescripcionCurso(txtTema.Text, wCodigo);
        }

        private string _TraerDescripcionCurso(string WTema, object WCurso)
        {
            string WDesc = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT RTRIM(LTRIM(Descripcion)) Descripcion FROM Tema WHERE Curso = '" + WTema + "' AND Tema = '" + WCurso + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WDesc = dr["Descripcion"].ToString();
                            }
                        }
                    }

                }

                return WDesc;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void _CargarTema(object wCodigo)
        {
            txtTema.Text = wCodigo.ToString();
            txtDesTema.Text = _TraerDecripcionTema(wCodigo.ToString());
        }

        private string _TraerDecripcionTema(string wCodigo)
        {
            string WDesc = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT RTRIM(LTRIM(Descripcion)) Descripcion FROM Curso WHERE Codigo = '" + wCodigo + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WDesc = dr["Descripcion"].ToString();
                            }
                        }
                    }

                }

                return WDesc;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void _CargarLegajo(object wCodigo)
        {
            int WRenglon = dgvGrilla.Rows.Add();
            dgvGrilla.Rows[WRenglon].Cells["Legajo"].Value = wCodigo;
            dgvGrilla.Rows[WRenglon].Cells["Nombre"].Value = _TraerDescripcionLegajo(wCodigo.ToString());
        }

        private string _TraerDescripcionLegajo(string wCodigo)
        {
            string Wdesc = "";

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT RTRIM(LTRIM(Descripcion)) Descripcion FROM Legajo WHERE Codigo = '" + wCodigo + "' AND Renglon = 1"; 

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                Wdesc = dr["Descripcion"].ToString();
                            }
                        }
                    }

                }

                return Wdesc;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
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

        private void btnAyudaCursos_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            if (txtTema.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar primero un Tema.");
                WTipoConsulta = 3;
                tabla = _TraerTemas();
            }
            else
            {
                WTipoConsulta = 2;
                tabla = _TraerCursos(); 
            }
            
            dgvAyuda.DataSource = tabla;
            
            DataGridViewColumn _columna = dgvAyuda.Columns["Descripcion"];
            if (_columna != null) _columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            gbLegajos.Visible = false;
            pnlAyuda.Visible = true;
            txtAyuda.Text = "";
            txtAyuda.Focus();
        }

        private DataTable _TraerCursos()
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
                        cmd.CommandText = "SELECT Tema as Codigo, RTRIM(LTRIM(Descripcion)) Descripcion FROM Tema WHERE Curso = '" + txtTema.Text + "' ORDER BY Tema";

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

        private void txtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtFecha.Text.Replace('/', ' ').Trim() == "") return;

                txtHoras.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtFecha.Clear();
            }
	        
        }

        private void txtHoras_Leave(object sender, EventArgs e)
        {
            txtHoras.Text = Helper.FormatoNumerico(txtHoras.Text);
        }

        private void txtHoras_KeyDown(object sender, KeyEventArgs e)
        {
            
	        if (e.KeyData == Keys.Enter){
	        	if (txtHoras.Text.Trim() == "") return;

                cmbTipo.Focus();

	        }else if (e.KeyData == Keys.Escape){
	        	txtHoras.Text = "";
	        }
	        
        }

        private void cmbTipo_DropDownClosed(object sender, EventArgs e)
        {
            cmbTipoProgramacion.Focus();
        }

        private void cmbTipo_KeyDown(object sender, KeyEventArgs e)
        {
            
	        if (e.KeyData == Keys.Enter){
	        	if (cmbTipo.Text.Trim() == "") return;

	            cmbTipoProgramacion.Focus();

	        }else if (e.KeyData == Keys.Escape){
	        	cmbTipo.SelectedIndex = 0;
	        }
	        
        }

        private void cmbTipoProgramacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter){
	        	if (cmbTipoProgramacion.Text.Trim() == "") return;

                txtInstructor.Focus();

            }else if (e.KeyData == Keys.Escape){
	        	cmbTipoProgramacion.SelectedIndex = 0;
	        }
        }

        private void cmbTipoProgramacion_DropDownClosed(object sender, EventArgs e)
        {
            txtInstructor.Focus();
        }

        private void txtInstructor_KeyDown(object sender, KeyEventArgs e)
        {
            
	        if (e.KeyData == Keys.Enter){
	        	if (txtInstructor.Text.Trim() == "") return;

	            txtActividad.Focus();

	        }else if (e.KeyData == Keys.Escape){
	        	txtInstructor.Text = "";
	        }
	        
        }

        private void txtActividad_KeyDown(object sender, KeyEventArgs e)
        {
            
	        if (e.KeyData == Keys.Enter){
	        	if (txtActividad.Text.Trim() == "") return;

	            txtTemas.Focus();

	        }else if (e.KeyData == Keys.Escape){
	        	txtActividad.Text = "";
	        }
	        
        }

        private void txtTemas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape){
	        	txtTemas.Text = "";
	        }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            WTipoConsulta = 4;
            btnAyuda.PerformClick();
            txtAyuda.Focus();
        }

        private void dgvGrilla_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvGrilla.Rows[e.RowIndex];

                if (
                    MessageBox.Show("¿Está seguro de querer eliminar la fila?", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvGrilla.Rows.Remove(row);
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
                if (dgvGrilla.SelectedCells.Count > 1) return;

                DataGridView.HitTestInfo WHit = dgvGrilla.HitTest(e.X, e.Y);

                if (WHit.Type == DataGridViewHitTestType.Cell)
                {
                    dgvGrilla.CurrentCell = dgvGrilla.Rows[WHit.RowIndex].Cells[WHit.ColumnIndex];
                }

                if (WHit.Type == DataGridViewHitTestType.RowHeader)
                {
                    dgvGrilla.ClearSelection();
                }
            }
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

        private void eliminarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedCells.Count > 0)
            {
                try
                {
                    if (
                    MessageBox.Show("¿Está seguro de querer eliminar la(s) fila(s)?", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        foreach (DataGridViewCell celdas in dgvGrilla.SelectedCells)
                        {
                            if (celdas.RowIndex < 0) continue;
                            DataGridViewRow row = dgvGrilla.Rows[celdas.RowIndex];

                            row.Selected = true;
                        }

                        foreach (DataGridViewRow row in dgvGrilla.SelectedRows)
                        {
                            dgvGrilla.Rows.Remove(row);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void asignarNuevoLegajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAyuda.PerformClick();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            eliminarFilaToolStripMenuItem.Enabled = dgvGrilla.SelectedCells.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAyuda.PerformClick();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (!_ExisteCursada(txtCodigo.Text))
            {
                MessageBox.Show("No existe ninguna cursada con el codigo indicado");
                return;
            }

            if (
                        MessageBox.Show(
                            "¿Desea Imprimir la Planilla?", "",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Imprimimos la planilla con las personas indicadas.
                VistaPrevia frm = new VistaPrevia();
                frm.CargarReporte(new Reportes.Cursada.planillacursada(), "{Cursadas.Curso} = {Curso.Codigo} AND {Cursadas.Legajo} = {Legajo.Codigo} AND {Legajo.Renglon} = 1 AND {Cursadas.Codigo} = " + txtCodigo.Text);
                frm.Imprimir();
            }

            btnLimpiar.PerformClick();
        }
    }
}
