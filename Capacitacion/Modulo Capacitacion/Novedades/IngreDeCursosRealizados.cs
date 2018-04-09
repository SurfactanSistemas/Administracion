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

        public IngreDeCursosRealizados()
        {
            InitializeComponent();
            CronogramasII = new List<CronogramaII>();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_Año.Text = "";
            txtMes.Text = "";
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
                Cr2 = new CronogramaII();
                Cr2.Año = TB_Año.Text;
                Cr2.Curso = int.Parse(item.Cells[0].Value.ToString());
                Cr2.Descripcion = item.Cells[1].Value.ToString();
                Cr2.Personas = int.Parse(item.Cells[2].Value.ToString());
                Cr2.Horas = float.Parse(item.Cells[3].Value.ToString());
                Cr2.HorasRealizadas = float.Parse(item.Cells[4].Value.ToString());
                //Cr2.Resta = int.Parse(item.Cells[2].Value.ToString());
                Cr2.Mes1 = item.Cells[6].Value.ToString();
                Cr2.Mes2= item.Cells[7].Value.ToString();
                Cr2.Mes3 = item.Cells[8].Value.ToString();
                Cr2.Mes4 = item.Cells[9].Value.ToString();
                Cr2.Mes5 = item.Cells[10].Value.ToString();
                Cr2.Mes6 = item.Cells[11].Value.ToString();
                Cr2.Mes7 = item.Cells[12].Value.ToString();
                Cr2.Mes8 = item.Cells[13].Value.ToString();
                Cr2.Mes9 = item.Cells[14].Value.ToString();
                Cr2.Mes10 = item.Cells[15].Value.ToString();
                Cr2.Mes11= item.Cells[16].Value.ToString();
                Cr2.Mes12 = item.Cells[17].Value.ToString();
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
            txtMes.Text = "";
            txtMes.Focus();
        }

        private void txtMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Select)
            {
                txtMes.Text = "";
            }
        }

        private void btnMostrarAviso_Click(object sender, EventArgs e)
        {
            if (txtMes.Text.Trim() == "") return;

            VistaPrevia frm = _PrepararAviso();

            if (frm != null) frm.Show();

            btnCerrarAviso.PerformClick();
        }

        private VistaPrevia _PrepararAviso()
        {
            // Busco primero los Cursos.

            short[] WColumnaMeses = {-1, 8, 9, 10, 11, 12, 1, 2, 3, 4, 5, 6, 7};

            short WMes = short.Parse(txtMes.Text);
            short WColumna = -1;
            short[] WCursos = new short[1000];
            short WRenglon = 0;

            // Determino la columna segun el mes indicado.
            WColumna = WColumnaMeses[WMes];

            // Controlamos que se haya elegido un mes valido.
            if (WColumna < 1) return null;

            // Extraigo de la grilla, aquellos cursos que tienen informado que se realizan.

            foreach (DataGridViewRow row in DGV_Cronograma.Rows)
            {
                if (row.Cells["Mes" + WColumna].Value.ToString().ToUpper() == "X")
                {
                    if (row.Cells["Curso"].Value.ToString() != "")
                    {
                        WRenglon++;
                        WCursos[WRenglon] = short.Parse(row.Cells["Curso"].Value.ToString());
                    }
                }
            }

            string WCursosAListar = "[";
            //string WCursosAListar = "";

            for (int i = 1; i <= WRenglon; i++)
            {
                WCursosAListar += WCursos[i] + ",";
            }

            if (WCursosAListar.Length == 1) return null;

            WCursosAListar = WCursosAListar.Substring(0, WCursosAListar.Length - 2);

            WCursosAListar += "]";

            Listados.VistaPrevia frm = new VistaPrevia();
            Listados.AvisoCronograma.AvisoCronograma reporte = new Listados.AvisoCronograma.AvisoCronograma();

            reporte.SetParameterValue("Mes", txtMes.Text);

            frm.CargarReporte(reporte,
                "{Cronograma.Ano}=" + TB_Año.Text + " AND {Cronograma.Curso}IN" + WCursosAListar +
                " AND {Cronograma.Curso}={Curso.Codigo} AND {Cronograma.Legajo}={Legajo.Codigo} AND {Cronograma.Sector}={Sector.Codigo} AND {Cronograma.Tema}={Tema.Tema} AND {Legajo.Sector}={Sector.Codigo} AND {Legajo.Curso}={Curso.Codigo} AND {Tema.Curso}={Curso.Codigo}");
            return frm;
        }

        private void btnCerrarAviso_Click(object sender, EventArgs e)
        {
            pnlAviso.Visible = false;
            txtMes.Text = "";
        }

        private void btnImprimirAvisoCursos_Click(object sender, EventArgs e)
        {
            if (txtMes.Text.Trim() == "") return;

            VistaPrevia frm = _PrepararAviso();

            if (frm != null) frm.Imprimir();

            btnCerrarAviso.PerformClick();
        }

        private void btnEnviarEmailAviso_Click(object sender, EventArgs e)
        {
            if (txtMes.Text.Trim() == "") return;

            VistaPrevia frm = _PrepararAviso();

            string WDirecciones = ConfigurationManager.AppSettings["DETINATARIOS_AVISO_CRONOGRAMA"];

            if (frm != null) frm.EnviarPorEmail(WDirecciones, "AvisoCronograma2017");

            btnCerrarAviso.PerformClick();
        }
    }
}
