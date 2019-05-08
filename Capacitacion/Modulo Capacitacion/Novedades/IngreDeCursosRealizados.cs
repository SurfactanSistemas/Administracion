using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Modulo_Capacitacion.Listados;
using Modulo_Capacitacion.Listados.AvisoCronograma;
using Modulo_Capacitacion.Listados.CronogramaCursos;
using Negocio;

namespace Modulo_Capacitacion.Novedades
{
    public partial class IngreDeCursosRealizados : Form
    {
        Cronograma Cr = new Cronograma();
        CronogramaII Cr2 = new CronogramaII();
        bool Modificar = true;
        List<CronogramaII> CronogramasII;
        private string WDirecciones = "";

        public IngreDeCursosRealizados()
        {
            InitializeComponent();
            CronogramasII = new List<CronogramaII>();
            WDirecciones = "";
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_Año.Text = "";
            cmbMes.SelectedIndex = 0;
            pnlAviso.Visible = false;
            pnlTipoListado.Visible = false;
            //DGV_Cronograma.DataSource = null;

            //DGV_Cronograma.Rows.Clear();

            if (DGV_Cronograma.DataSource != null)
                ((DataTable)DGV_Cronograma.DataSource).Rows.Clear();
            TB_Año.Focus();
        }

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Buscar cronograma?
                //if (TB_Año.Text == "") throw new Exception("Se deben cargar los datos del año");
                if (TB_Año.Text == "") return;

                //DGV_Cronograma.DataSource = Cr2.BuscarUnoPorAño(TB_Año.Text);

                //Busco los cursos asociados al legajo!!
                Modificar = false;
                DGV_Cronograma.DataSource = Cr.BuscarPorAño(TB_Año.Text);

            }
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valido que est todo bien y armo el objeto
                ValidarDatosABM();
                //CargarCronogramaII();
                ////lo guarod si no s modificar

                //Cr2.Eliminar(TB_Año.Text);
                ////sino elimino el viejo  y cargo el nuevo

                //foreach (var item in CronogramasII)
                //{
                //    item.Agregar();
                //}
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
                            cmd.CommandText = "";
                            cmd.Transaction = trans;

                            cmd.CommandText = "DELETE FROM CronogramaII WHERE Ano = '" + TB_Año.Text + "'";
                            cmd.ExecuteNonQuery();

                            foreach (DataGridViewRow row in DGV_Cronograma.Rows)
                            {
                                var WCurso = row.Cells["Curso"].Value ?? "";
                                var WMes1 = row.Cells["Mes1"].Value ?? "";
                                var WMes2 = row.Cells["Mes2"].Value ?? "";
                                var WMes3 = row.Cells["Mes3"].Value ?? "";
                                var WMes4 = row.Cells["Mes4"].Value ?? "";
                                var WMes5 = row.Cells["Mes5"].Value ?? "";
                                var WMes6 = row.Cells["Mes6"].Value ?? "";
                                var WMes7 = row.Cells["Mes7"].Value ?? "";
                                var WMes8 = row.Cells["Mes8"].Value ?? "";
                                var WMes9 = row.Cells["Mes9"].Value ?? "";
                                var WMes10 = row.Cells["Mes10"].Value ?? "";
                                var WMes11 = row.Cells["Mes11"].Value ?? "";
                                var WMes12 = row.Cells["Mes12"].Value ?? "";

                                if (WCurso.ToString().Trim() == "") continue;

                                var WClave = TB_Año.Text.PadLeft(4, '0') + WCurso.ToString().PadLeft(4, '0');

                                string ZSql = string.Format("INSERT INTO CronogramaII (Clave, Ano, Curso, Mes1, Mes2, Mes3, Mes4, Mes5, Mes6, Mes7, Mes8, Mes9, Mes10, Mes11, Mes12) " +
                                                            " VALUES ('{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')", 
                                    WClave, TB_Año.Text ,WCurso,WMes1, WMes2, WMes3, WMes4, WMes5, WMes6, WMes7, WMes8, WMes9, WMes10, WMes11, WMes12);

                                cmd.CommandText = ZSql;
                                cmd.ExecuteNonQuery();
                            }
                            
                            trans.Commit();
                        }
                    }

                    BT_Limpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    if (trans != null && trans.Connection != null) trans.Rollback();
                    throw new Exception("Error al Actualizar los datos de la Planificacion Anual en la Base de Datos. Motivo: " + ex.Message);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void CargarCronogramaII()
        {
            

            foreach (DataGridViewRow item in DGV_Cronograma.Rows)
            {
                Cr2 = new CronogramaII
                {
                    Año = TB_Año.Text,
                    Curso = int.Parse(item.Cells[0].Value.ToString()),
                    Descripcion = item.Cells[1].Value.ToString(),
                    Personas = int.Parse(item.Cells[2].Value.ToString()),
                    Horas = float.Parse(item.Cells[3].Value.ToString()),
                    HorasRealizadas = float.Parse(item.Cells[4].Value.ToString()),
                    Mes1 = item.Cells[6].Value.ToString(),
                    Mes2 = item.Cells[7].Value.ToString(),
                    Mes3 = item.Cells[8].Value.ToString(),
                    Mes4 = item.Cells[9].Value.ToString(),
                    Mes5 = item.Cells[10].Value.ToString(),
                    Mes6 = item.Cells[11].Value.ToString(),
                    Mes7 = item.Cells[12].Value.ToString(),
                    Mes8 = item.Cells[13].Value.ToString(),
                    Mes9 = item.Cells[14].Value.ToString(),
                    Mes10 = item.Cells[15].Value.ToString(),
                    Mes11 = item.Cells[16].Value.ToString(),
                    Mes12 = item.Cells[17].Value.ToString()
                };
                //Cr2.Resta = int.Parse(item.Cells[2].Value.ToString());
                CronogramasII.Add(Cr2);
            }
        }

        private void ValidarDatosABM()
        {
            if (TB_Año.Text == "") throw new Exception("Error falta dato de año");
            if (DGV_Cronograma.Rows.Count == 0) throw new Exception("No hay datos de cronogorama");
        }


        private void IngreDeCursosRealizados_Load(object sender, EventArgs e)
        {
            Helper.ActualizarCantidadPersonasHoras(TB_Año.Text);
        }

        private void IngreDeCursosRealizados_Shown(object sender, EventArgs e)
        {
            TB_Año.Focus();
        }

        //private void DGV_Cronograma_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    _ImprimirReporteCronograma(e.RowIndex);
        //}

        private void _ImprimirReporteCronograma(int indexRow, int TipoConsulta)
        {
            int curso = 0;
            if (indexRow >= 0)
            {
                DataGridViewRow row = DGV_Cronograma.Rows[indexRow];

                curso = int.Parse(row.Cells[0].Value.ToString());

            }

            string WFormula = "{Cronograma.Curso}=" + curso + " AND {Cronograma.Ano}=" + TB_Año.Text + " AND {Legajo.Renglon} = 1";

            if (TipoConsulta > 0)
            {
                WFormula += " And {Tema.Horas} <> {Cronograma.Realizado}";
            }

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new wlistacursoplani(), WFormula);

            frm.Show();

            pnlTipoListado.Visible = false;
        }
        
        private void DGV_Cronograma_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdRow.Text = e.RowIndex.ToString();
            pnlTipoListado.Visible = true;
        }

        private void btnImprimirAviso_Click(object sender, EventArgs e)
        {
            pnlAviso.Visible = true;
            checkBox1.Checked = true;
            cmbMes.SelectedIndex = DateTime.Now.Month;
            txtAnoConsulta.Text = TB_Año.Text.Trim().Length < 4 ? DateTime.Now.ToString("dd/MM/yyyy") : TB_Año.Text;
            cmbMes.Focus();
        }

        private void btnMostrarAviso_Click(object sender, EventArgs e)
        {
            if (cmbMes.SelectedIndex == 0) return;

            VistaPrevia frm = _PrepararAviso();

            if (frm != null) frm.Show();

            btnCerrarAviso.PerformClick();
        }

        private VistaPrevia _PrepararAviso()
        {
            // Busco primero los Cursos.

            short[] WColumnaMeses = {-1, 8, 9, 10, 11, 12, 1, 2, 3, 4, 5, 6, 7};

            int WMes = cmbMes.SelectedIndex;
            short WColumna = -1;
            short[] WCursos = new short[1000];
            short WRenglon = 0;

            // Determino la columna segun el mes indicado.
            WColumna = WColumnaMeses[WMes];

            // Controlamos que se haya elegido un mes valido.
            if (WColumna < 1) return null;

            if (txtAnoConsulta.Text.Trim() == "") txtAnoConsulta.Text = TB_Año.Text;

            // Determinamos el año de cronograma a consultar
            short WAno = short.Parse(txtAnoConsulta.Text);

            if (WMes >= 1 && WMes <= 7)
            {
                WAno -= 1;
            }

            string auxi = TB_Año.Text;

            if (txtAnoConsulta.Text.Trim() != TB_Año.Text)
            {
                auxi = TB_Año.Text;

                TB_Año.Text = WAno.ToString();
                TB_Año_KeyDown(null, new KeyEventArgs(Keys.Enter));
            }

            // Extraigo de la grilla, aquellos cursos que tienen informado que se realizan.

            WDirecciones = "";
            List<string> XDirecciones = new List<string>{};

            foreach (DataGridViewRow row in DGV_Cronograma.Rows)
            {
                if (row.Cells["Mes" + WColumna].Value.ToString().ToUpper() == "X")
                {
                    if (row.Cells["Curso"].Value.ToString() != "")
                    {
                        WRenglon++;
                        WCursos[WRenglon] = short.Parse(row.Cells["Curso"].Value.ToString());
                        string WDireccionEmail = _TraerMailResponsable(WCursos[WRenglon]);

                        WDireccionEmail = WDireccionEmail.Trim();

                        if (!XDirecciones.Exists(d => d == WDireccionEmail) && WDireccionEmail != "")
                        {
                            XDirecciones.Add(WDireccionEmail);
                        }
                    }
                }
            }

            foreach (string WD in XDirecciones)
            {
                WDirecciones += WD + ";";
            }

            string WCursosAListar = "[";
            //string WCursosAListar = "";

            for (int i = 1; i <= WRenglon; i++)
            {
                WCursosAListar += WCursos[i] + ",";
            }

            if (WCursosAListar.Length == 1)
            {
                MessageBox.Show("No existen datos para mostrar.");
                TB_Año.Text = auxi;
                TB_Año_KeyDown(null, new KeyEventArgs(Keys.Enter));
                return null;
            }

            //WCursosAListar = WCursosAListar.Substring(0, WCursosAListar.Length - 2);
            WCursosAListar = WCursosAListar.TrimEnd(',');

            WCursosAListar += "]";

            TB_Año.Text = auxi;
            TB_Año_KeyDown(null, new KeyEventArgs(Keys.Enter));

            VistaPrevia frm = new VistaPrevia();
            AvisoCronograma reporte = new AvisoCronograma();

            string WImpreAno = (WMes >= 1 && WMes <= 7) ? (WAno + 1).ToString() : WAno.ToString();

            reporte.SetParameterValue("Mes", WMes);
            reporte.SetParameterValue("ImpreAno", WImpreAno);

            string WFormula = "{Cronograma.Ano} = " + WAno + " AND {Cronograma.Curso} IN " + WCursosAListar +
                              " AND {Legajo.Renglon} = 1 ";

            if (checkBox1.Checked) WFormula += " AND {Cronograma.Tema} <> 99";

            frm.CargarReporte(reporte, WFormula);
            return frm;
        }

        private string _TraerMailResponsable(short wCurso)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT R.Email FROM Curso C, ResponsableSac R WHERE C.ResponsableII = R.Codigo AND C.Codigo = '" + wCurso + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            return dr["Email"].ToString();

                        }
                    }
                }

            }

            return "";
        }

        private void btnCerrarAviso_Click(object sender, EventArgs e)
        {
            pnlAviso.Visible = false;
            cmbMes.SelectedIndex = 0;
        }

        private void btnImprimirAvisoCursos_Click(object sender, EventArgs e)
        {
            if (cmbMes.SelectedIndex == 0) return;

            VistaPrevia frm = _PrepararAviso();

            if (frm != null) frm.Imprimir();

            btnCerrarAviso.PerformClick();
        }

        private void btnEnviarEmailAviso_Click(object sender, EventArgs e)
        {
            if (cmbMes.SelectedIndex == 0) return;

            WDirecciones = "";

            VistaPrevia frm = _PrepararAviso();

            //string WDirecciones = ConfigurationManager.AppSettings["DETINATARIOS_AVISO_CRONOGRAMA"];

            if (frm != null) frm.EnviarPorEmail(WDirecciones, "AvisoCronograma");

            btnCerrarAviso.PerformClick();

            WDirecciones = "";
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnoConsulta.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pnlTipoListado.Visible = false;
            TB_Año.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ImprimirReporteCronograma(int.Parse(lblIdRow.Text), 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ImprimirReporteCronograma(int.Parse(lblIdRow.Text), 1);
        }
    }
}
