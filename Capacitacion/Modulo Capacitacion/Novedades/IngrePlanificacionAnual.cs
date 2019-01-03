using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Modulo_Capacitacion.Interfaces;
using Negocio;

namespace Modulo_Capacitacion.Novedades
{
    public partial class IngrePlanificacionAnual : Form, IAyudaLegajos
    {
        Tema T = new Tema();
        Curso C = new Curso();
        Cronograma Cr = new Cronograma();
        Legajo L = new Legajo();
        DataTable dtLegajos;
        DataTable dtLegajosSinFechaEgreso;
        bool Cargado;
        DataTable dtTemas;
        DataTable dtCursos;
        DataTable dtCronograma = new DataTable();

        public IngrePlanificacionAnual()
        {
            InitializeComponent();
            CargardtCronograma();

            CargarLegajos();
            CargarTemas();
            Cargado = true;
        }

        private void CargardtCronograma()
        {

            dtCronograma.Columns.Add("Tema", typeof(string));
            dtCronograma.Columns.Add("DescTema", typeof(string));
            dtCronograma.Columns.Add("Curso", typeof(string));
            dtCronograma.Columns.Add("DesCurso", typeof(string));
            dtCronograma.Columns.Add("Horas", typeof(string));
            dtCronograma.Columns.Add("Realizado", typeof(string));
        }

        private void CargarTemas()
        {
            dtTemas = T.ListarTemasPlani();

            DataRow fila;
            fila = dtTemas.NewRow();
            dtTemas.Rows.InsertAt(fila, 0);

            CargarDescTemas();
            CargarCodigosTemas();
        }

        private void CargarDescTemas()
        {
            TB_DescTemas.DataSource = dtTemas;
            TB_DescTemas.DisplayMember = "Descripcion";
            TB_DescTemas.ValueMember = "Codigo";
            TB_DescTemas.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTemas.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescTemas.AutoCompleteCustomSource = stringCodArti;
            TB_DescTemas.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescTemas.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosTemas()
        {
            TB_CodTemas.DataSource = dtTemas;
            TB_CodTemas.DisplayMember = "Codigo";
            TB_CodTemas.ValueMember = "Codigo";
            TB_CodTemas.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTemas.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodTemas.AutoCompleteCustomSource = stringCodArti;
            TB_CodTemas.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodTemas.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarLegajos()
        {
            dtLegajos = L.ListarTodos();

            

            dtLegajosSinFechaEgreso = dtLegajos.Copy();

            dtLegajosSinFechaEgreso.Clear();

            DataRow fila;
            fila = dtLegajosSinFechaEgreso.NewRow();
            dtLegajosSinFechaEgreso.Rows.InsertAt(fila, 0);

            //CARGO LOS LEGAJOS QUE NO TENGAN FECHA DE EGRESO PARA QUE SE LES PERMITA HACER LA 
            // PLANIFICACION
            foreach (DataRow filaLeg in dtLegajos.Rows)
            {
               
                if (filaLeg[33].ToString() == "00/00/0000")
                {
                    
                    dtLegajosSinFechaEgreso.ImportRow(filaLeg);
                }
                
            }

            //CargarDescLegajos();
            //CargarCodigosLegajos();
            
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
        }

        private void CargarDescLegajos()
        {
            TB_DesLegajob.DataSource = dtLegajosSinFechaEgreso;
            TB_DesLegajob.DisplayMember = "Descripcion";
            TB_DesLegajob.ValueMember = "Codigo";
            TB_DesLegajob.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtLegajosSinFechaEgreso.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DesLegajob.AutoCompleteCustomSource = stringCodArti;
            TB_DesLegajob.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DesLegajob.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        //private void CargarCodigosLegajos()
        //{
        //    TB_CodLegajo.DataSource = dtLegajosSinFechaEgreso;
        //    TB_CodLegajo.DisplayMember = "Codigo";
        //    TB_CodLegajo.ValueMember = "Codigo";
        //    TB_CodLegajo.Text = "";

        //    AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
        //    foreach (DataRow row in dtLegajosSinFechaEgreso.Rows)
        //    {
        //        stringCodArti.Add(Convert.ToString(row["Codigo"]));

        //    }

        //    TB_CodLegajo.AutoCompleteCustomSource = stringCodArti;
        //    TB_CodLegajo.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    TB_CodLegajo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //}

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_CodLegajo.Text = "";
            TB_DesLegajob.Text = "";
            TB_Año.Text = "";
            LimpiarCamposTema();
            //DGV_Cronograma.Rows.Clear();
            DGV_Crono.DataSource = null;

            TB_CodLegajo.Focus();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            
            SqlTransaction trans = null;

            try
            {
                ValidarDatosIngresados();

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "";
                        cmd.Transaction = trans;

                        cmd.CommandText = "DELETE FROM Cronograma WHERE Legajo = '" + TB_CodLegajo.Text + "' And Ano = '" + TB_Año.Text + "'";
                        cmd.ExecuteNonQuery();

                        int WRenglon = 0;

                        foreach (DataGridViewRow row in DGV_Crono.Rows)
                        {
                            string consulta;

                            var WCurso = row.Cells["Tema"].Value ?? "";
                            var WTema = row.Cells["Curso"].Value ?? "";
                            var WHoras = row.Cells["Horas"].Value ?? "";
                            var WRealizado = row.Cells["Realizado"].Value ?? "";

                            WHoras = Helper.FormatoNumerico(WHoras);
                            WRealizado = Helper.FormatoNumerico(WRealizado);

                            cmd.CommandText = "SELECT Clave FROM Cronograma WHERE Legajo = '" + TB_CodLegajo.Text + "' AND Ano = '" + TB_Año.Text + "' And Curso = '" + WCurso + "'";

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    // Actualizo el segundo curso.
                                    dr.Read();
                                    string WClave = dr["Clave"].ToString();

                                    consulta = "UPDATE Cronograma SET Tema2 = '" + WTema + "' WHERE Clave = '" + WClave + "'";
                                }
                                else
                                {
                                    WRenglon++;
                                    // Inserto el Renglon.

                                    var clave1 = TB_CodLegajo.Text.Trim().PadLeft(6, '0');
                                    var clave2 = TB_Año.Text.Trim().PadLeft(4, '0');
                                    var clave3 = WRenglon.ToString().PadLeft(2, '0');

                                    consulta = "insert into cronograma (Clave,Legajo,Ano,Renglon,Curso,Horas,Realizado, DesLegajo, Tema,DesTema, Tema2, DesTema2) " +
                                    " values ('"+ clave1 + clave2 + clave3 +"', "+ TB_CodLegajo.Text +", "+ TB_Año.Text +"," + WRenglon + ", " + WCurso + ", "
                                    + WHoras + ", " + WRealizado + ", '" + TB_DesLegajob.Text.Trim() + "', " + WTema + ", '', 0, '')";
                                }
                            }

                            cmd.CommandText = consulta;
                            cmd.ExecuteNonQuery();
                        }

                    }

                    trans.Commit();
                }

                Close();
            }
            catch (Exception ex)
            {
                if (trans != null && trans.Connection != null) trans.Rollback();
                MessageBox.Show("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        }

        private void ValidarDatosIngresados()
        {
            if (TB_CodLegajo.Text == "") throw new Exception("Debe estar cargado el campo Legajo");

            Legajo leg = (new Legajo()).BuscarUno(TB_CodLegajo.Text);

            if (leg.Codigo == 0) throw new Exception("Debe cargar un legajo válido.");

            if (TB_Año.Text == "") throw new Exception("Debe estar cargado el campo año");
            if (DGV_Crono.Rows.Count == 0) throw new Exception("No hay datos en la grilla");
        }

        private void IngrePlanificacionAnual_Load(object sender, EventArgs e)
        {

        }

        private void TB_DesLegajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cargado)
            {
                TB_Año.Focus();
            }
        }

        private void TB_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                    if (TB_CodLegajo.Text == "" || TB_Año.Text == "") throw new Exception("Se deben cargar los datos de legajo y año");

                    dtCronograma = Cr.BuscarUno(TB_CodLegajo.Text, TB_Año.Text);
                
                    Legajo _L = new Legajo();
                    _L = _L.BuscarUno(TB_CodLegajo.Text);
                    TB_DesLegajo.Text = _L.Descripcion;
                    lblAtencion.Visible = false;

                    if (dtCronograma.Rows.Count == 0)
                    {
                        dtCronograma = L.BuscarCursosPlanificacion(TB_CodLegajo.Text);
                        // Mostramos la ventana de Atencion.
                        lblAtencion.Visible = true;
                    }

                    DGV_Crono.DataSource = dtCronograma;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

        }

        private void TB_DescTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarCodigoTema();
            CargarCursos();
            CB_Curso.Focus();
        }

        private void BuscarCodigoTema()
        {
            foreach (DataRow fila in dtTemas.Rows)
            {
                if (fila[1].ToString() == TB_DescTemas.Text)
                {
                    TB_CodTemas.Text = fila[0].ToString();
                }
            }
        }

        private void CargarCursos()
        {
            if (TB_CodTemas.Text != "")
            {
                dtCursos = C.ListaPorTema(int.Parse(TB_CodTemas.Text));

                DataRow fila;
                fila = dtCursos.NewRow();
                dtCursos.Rows.InsertAt(fila, 0);

                CargarDescCursos();

                LB_Curso.Visible = true;
                CB_Curso.Visible = true;
            }
            
            
        }

        private void CargarDescCursos()
        {
            CB_Curso.DataSource = dtCursos;
            CB_Curso.DisplayMember = "Descripcion";
            CB_Curso.ValueMember = "Tema";
            CB_Curso.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtCursos.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]).Trim());
            }

            CB_Curso.AutoCompleteCustomSource = stringCodArti;
            CB_Curso.AutoCompleteMode = AutoCompleteMode.Suggest;
            CB_Curso.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BT_AgregarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_CodTemas.Text == "" || TB_DescTemas.Text == "") throw new Exception("Se debe ingresar el tema");

                AgregarFila();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            TB_CodTemas.Focus();
        }

        private void AgregarFila()
        {
            DataRow filaCronograma = null;
            bool WAgregar = false;

            DataRow[] rows = dtCronograma.Select("Tema = '" + TB_CodTemas.Text + "'");

            if (rows.Length == 2)
            {
                MessageBox.Show("Se pueden agregar unicamente hasta un máximo de 2 Cursos por Tema.");
                return;
            }

            foreach (DataRow row in dtCronograma.Rows)
            {
                if (row["Tema"].ToString() == TB_CodTemas.Text && row["DesCurso"].ToString().ToUpper() == CB_Curso.Text.ToUpper())
                {
                    filaCronograma = row;
                }
            }

            if (filaCronograma == null)
            {
                filaCronograma = dtCronograma.NewRow();
                WAgregar = true;
            }

            filaCronograma[0] = TB_CodTemas.Text;
            filaCronograma[1] = TB_DescTemas.Text;
            if (CB_Curso.Text != "")
            {
                foreach (DataRow filaCurso in dtCursos.Rows)
                {
                    if (filaCurso[2].ToString() == CB_Curso.Text)
                    {
                        filaCronograma[2] = filaCurso[1].ToString();
                        filaCronograma[3] = CB_Curso.Text;
                        filaCronograma[4] = filaCurso[4].ToString();
                        filaCronograma[5] = 0;
                    }
                }
            }
            else
            {
                filaCronograma[2] = 0;
                filaCronograma[3] = "";
                filaCronograma[4] = 0;
                filaCronograma[5] = 0;
            }


            
            if (WAgregar) dtCronograma.Rows.Add(filaCronograma);

            DGV_Crono.DataSource = dtCronograma;
            

            LimpiarCamposTema();
        }

        private void LimpiarCamposTema()
        {
            TB_CodTemas.Text = "";
            TB_DescTemas.Text = "";
            CB_Curso.Text = "";
            CB_Curso.Visible = false;
        }

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TB_Buscar.PerformClick();
            if (e.KeyCode == Keys.Escape) TB_Año.Text = "";
        }

        private void IngrePlanificacionAnual_Shown(object sender, EventArgs e)
        {
            TB_CodLegajo.Focus();
        }

        private void TB_CodLegajo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TB_CodLegajo.Text = "";
                TB_DesLegajo.Text = "";
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (TB_CodLegajo.Text.Trim() != "")
                {
                    Legajo _Leg = (new Legajo()).BuscarUno(TB_CodLegajo.Text);

                    if (_Leg.Codigo != 0)
                    {
                        TB_DesLegajo.Text = _Leg.Descripcion.Trim();
                        TB_Año.Focus();
                    }
                    else
                    {
                        TB_DesLegajo.Text = "";
                    }
                }
            }
        }

        internal bool AsignarCurso(string zTema, object wCurso, object wDesCurso, object WHoras, int wRowIndex)
        {

            foreach (DataGridViewRow row in DGV_Crono.Rows)
            {
                var WTema = row.Cells["Tema"].Value ?? "";
                var _Curso = row.Cells["Curso"].Value ?? "";

                if (int.Parse(zTema) == int.Parse(WTema.ToString()) && int.Parse(wCurso.ToString()) == int.Parse(_Curso.ToString())) return false;

            }

            DGV_Crono.Rows[wRowIndex].Cells["Curso"].Value = wCurso;
            DGV_Crono.Rows[wRowIndex].Cells["DesCurso"].Value = wDesCurso;
            DGV_Crono.Rows[wRowIndex].Cells["Horas"].Value = WHoras;

            return true;
        }

        private void DGV_Crono_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            if (DGV_Crono.CurrentRow != null)
            {
                Auxiliares.CursosDisponibles frm =
                    new Auxiliares.CursosDisponibles(DGV_Crono.CurrentRow.Cells["Tema"].Value.ToString(),
                        DGV_Crono.CurrentRow.Index);

                frm.Show(this);
            }
        }

        private void DGV_Crono_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex < 0) return;

            DataRow BorrarFila = null;

            foreach (DataRow row in dtCronograma.Rows)
            {
                if (DGV_Crono.CurrentRow != null && row["Tema"].ToString() == DGV_Crono.CurrentRow.Cells["Tema"].Value.ToString() && row["Curso"].ToString() == DGV_Crono.CurrentRow.Cells["Curso"].Value.ToString())
                {
                    BorrarFila = row;
                }
            }

            if (BorrarFila != null)
            {
                DataRow temp = dtCronograma.NewRow();

                temp["Tema"] = BorrarFila["Tema"];
                temp["DesTema"] = BorrarFila["DesTema"];
                temp["Horas"] = "0";
                temp["Realizado"] = "0";
                temp["Curso"] = "0";
                temp["DesCurso"] = "";

                dtCronograma.Rows.Remove(BorrarFila);
                dtCronograma.Rows.Add(temp);
            }

            DGV_Crono.DataSource = dtCronograma;
            if (DGV_Crono.Columns["Tema"] != null) DGV_Crono.Sort(DGV_Crono.Columns["Tema"], ListSortDirection.Ascending);
        }

        private void TB_DesLegajo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Auxiliares.AyudaLegajosActivos frm = new Auxiliares.AyudaLegajosActivos();

            frm.Show(this);
        }

        public void _ProcesarAyudaLegajos(object WCodigo, object WLegajo)
        {
            TB_CodLegajo.Text = WCodigo.ToString();
            TB_CodLegajo_KeyDown(null, new KeyEventArgs(Keys.Enter));
        }

        private void TB_CodLegajo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Auxiliares.AyudaLegajosActivos frm = new Auxiliares.AyudaLegajosActivos();

            frm.Show(this);
        }
    }
}
