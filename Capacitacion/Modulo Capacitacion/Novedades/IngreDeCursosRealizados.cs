﻿using System;
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

                DGV_Cronograma.DataSource = Cr2.BuscarUnoPorAño(TB_Año.Text);

                if (DGV_Cronograma.Rows.Count == 0)
                {
                    //Busco los cursos asociados al legajo!!
                    Modificar = false;
                    DGV_Cronograma.DataSource = Cr.BuscarPorAño(TB_Año.Text);
                }
            }
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valido que est todo bien y armo el objeto
                ValidarDatosABM();
                CargarCronogramaII();
                //lo guarod si no s modificar

                if (Modificar)
                {
                    Cr2.Eliminar(TB_Año.Text);
                }
                //sino elimino el viejo  y cargo el nuevo

                foreach (var item in CronogramasII)
                {
                    item.Agregar();
                }

                BT_Limpiar.PerformClick();

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

        }

        private void IngreDeCursosRealizados_Shown(object sender, EventArgs e)
        {
            TB_Año.Focus();
        }

        //private void DGV_Cronograma_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    _ImprimirReporteCronograma(e.RowIndex);
        //}

        private void _ImprimirReporteCronograma(int indexRow)
        {
            int curso = 0;
            if (indexRow >= 0)
            {
                DataGridViewRow row = DGV_Cronograma.Rows[indexRow];

                curso = int.Parse(row.Cells[0].Value.ToString());
            }

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new wlistacursoplani(), "{Cronograma.Curso}=" + curso + " AND {Cronograma.Ano}=" + TB_Año.Text);

            frm.Show();
        }
        
        private void DGV_Cronograma_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ImprimirReporteCronograma(e.RowIndex);
        }

        private void btnImprimirAviso_Click(object sender, EventArgs e)
        {
            pnlAviso.Visible = true;
            cmbMes.SelectedIndex = 1;
            txtAnoConsulta.Text = "";
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

            WCursosAListar = WCursosAListar.Substring(0, WCursosAListar.Length - 2);

            WCursosAListar += "]";

            TB_Año.Text = auxi;
            TB_Año_KeyDown(null, new KeyEventArgs(Keys.Enter));

            VistaPrevia frm = new VistaPrevia();
            AvisoCronograma reporte = new AvisoCronograma();

            string WImpreAno = (WMes >= 1 && WMes <= 7) ? (WAno + 1).ToString() : WAno.ToString();

            reporte.SetParameterValue("Mes", WMes);
            reporte.SetParameterValue("ImpreAno", WImpreAno);

            frm.CargarReporte(reporte,
                "{Cronograma.Ano}=" + WAno + " AND {Cronograma.Curso}IN" + WCursosAListar +
                " AND {Cronograma.Curso}={Curso.Codigo} AND {Cronograma.Legajo}={Legajo.Codigo} AND {Cronograma.Sector}={Sector.Codigo} AND {Cronograma.Tema}={Tema.Tema} AND {Legajo.Sector}={Sector.Codigo} AND {Legajo.Curso}={Curso.Codigo} AND {Tema.Curso}={Curso.Codigo}");
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

            if (frm != null) frm.EnviarPorEmail(WDirecciones, "AvisoCronograma2017");

            btnCerrarAviso.PerformClick();

            WDirecciones = "";
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnoConsulta.Focus();
        }
    }
}