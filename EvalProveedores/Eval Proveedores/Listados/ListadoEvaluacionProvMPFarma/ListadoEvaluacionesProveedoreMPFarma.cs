using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ConsultasVarias;
using ConsultasVarias.Clases;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Eval_Proveedores.Listados.ListadoEvaluacionProvMPFarma
{
    public partial class ListadoEvaluacionesProveedoreMPFarma : Form, IExportar
    {
        public ListadoEvaluacionesProveedoreMPFarma()
        {
            InitializeComponent();
            dgvProveedores.InhabilitarOrdenamientoColumnas();
        }

        private void ListadoEvaluacionesProveedoreMPFarma_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable WProveedores =
                Query.GetAll(
                    "SELECT distinct p.Proveedor, Nombre = UPPER(p.Nombre) FROM Proveedor p INNER JOIN Cotiza ct ON ct.Proveedor = p.Proveedor INNER JOIN Articulo a ON a.Codigo = ct.Articulo And ISNULL(a.ClasificacionFarma,0) > 0");

            WProveedores.Columns.Add("Listar", typeof (bool));

            WProveedores.Rows.Add("", " TODOS", true);

            foreach (DataRow row in WProveedores.Rows)
            {
                row["Listar"] = true;
            }

            backgroundWorker1.ReportProgress(1, WProveedores);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dgvProveedores.Rows.Clear();

            DataTable WProveedores = e.UserState as DataTable;

            if (WProveedores != null)
            {
                WProveedores.DefaultView.Sort = "Nombre ASC";
                dgvProveedores.DataSource = WProveedores;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) backgroundWorker1.CancelAsync();

            Close();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvProveedores.DataSource as DataTable;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("Proveedor LIKE '%{0}%' OR Nombre LIKE '%{0}%'",
                    txtFiltrar.Text);
        }

        private void dgvProveedores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewColumn column = dgvProveedores.Columns["Listar"];

            if (column != null && e.ColumnIndex == column.Index)
            {
                if (dgvProveedores.CurrentRow != null)
                {
                    dgvProveedores.CurrentRow.Cells["Listar"].Value = !(bool)dgvProveedores.CurrentRow.Cells["Listar"].Value;

                    if (dgvProveedores.CurrentRow.Cells["Nombre"].Value.ToString() == " TODOS")
                    {
                        foreach (DataGridViewRow row in dgvProveedores.Rows)
                        {
                            row.Cells["Listar"].Value = dgvProveedores.CurrentRow.Cells["Listar"].Value;
                        }
                    }
                    else
                    {
                        dgvProveedores.Rows[0].Cells["Listar"].Value = false;
                    }
                }
            }
        }

        private void btnPantalla_Click(object sender, EventArgs e)
        {
            ConsultasVarias.VistaPrevia frm = _GenerarReporte();

            frm.Mostrar();
        }

        private ConsultasVarias.VistaPrevia _GenerarReporte()
        {
            string WFiltroProv = "";

            ConsultasVarias.VistaPrevia frm = new ConsultasVarias.VistaPrevia();
            ReportDocument rpt = null;

            if (rbListadoCompleto.Checked || rbEvalVencida.Checked)
            {
                List<string> WProveedores = new List<string>();

                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {
                    if ((bool)row.Cells["Listar"].Value) WProveedores.Add(row.Cells["Proveedor"].Value.ToString());
                }

                if (WProveedores.Count == 0)
                {
                    MessageBox.Show("No se ha seleccionado ningún Proveedor para listar.");
                    return null;
                }

                foreach (string WProveedor in WProveedores)
                {
                    WFiltroProv += "'" + WProveedor + "',";
                }

                WFiltroProv = WFiltroProv.Trim(',');
                WFiltroProv = "[" + WFiltroProv + "]";

                rpt = rbResumido.Checked
                    ? (ReportDocument)new ListadoResumidoEvaluacionProveedoresMPFarmaNuevo()
                    : new ListadoCompletoEvaluacionProveedoresMPFarma();

                string WFiltroVencidos = rbEvalVencida.Checked ? " AND {EvaluacionProvMP.FechaEvaluaVtoOrd} < '" + DateTime.Now.ToString("yyyyMMdd") + "' And {EvaluacionProvMP.FechaEvaluaVtoOrd} > '0' " : "";

                frm.Formula = "{EvaluacionProvMP.Renglon} = 1 And {EvaluacionProvMP.Proveedor} IN " + WFiltroProv + " " + WFiltroVencidos;
                frm.Reporte = rpt;
            }
            else if (rbSinEvaluar.Checked)
            {
                rpt = new ProveedoresFaltantesEvaluacion();
                DataTable tabla = new DBAuxi.ProveedoresFaltantesDataTable();

                tabla = Query.GetAll(
                        "select distinct p.Proveedor, p.Nombre, ct.Articulo, a.Descripcion from proveedor p inner join cotiza ct on ct.Proveedor = p.Proveedor inner join Articulo a on a.Codigo = ct.Articulo and isnull(a.ClasificacionFarma, '0') = '1' left outer join EvaluacionProvMP e on e.Proveedor = p.Proveedor and e.Articulo = a.Codigo where ISNULL(e.Articulo, '') = '' order by p.nombre, a.Descripcion");

                rpt.SetDataSource(tabla);
                frm.Reporte = rpt;
            }

            return frm;
        }

        private void rbListadoCompleto_Click(object sender, EventArgs e)
        {
            rbResumido.Enabled = rbListadoCompleto.Checked || rbEvalVencida.Checked;
            rbFichaCompleta.Enabled = rbListadoCompleto.Checked || rbEvalVencida.Checked;
            txtFiltrar.Enabled = rbListadoCompleto.Checked;
            dgvProveedores.Enabled = rbListadoCompleto.Checked;

            txtFiltrar.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ConsultasVarias.VistaPrevia frm = _GenerarReporte();

            frm.Mostrar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar frm = new Exportar();
            frm.ShowDialog(this);
        }

        public void _ProcesarExportar(Enum TipoSalida)
        {
            ConsultasVarias.VistaPrevia frm = _GenerarReporte();

            switch ((Enumeraciones.FormatoExportacion) TipoSalida)
            {
                case Enumeraciones.FormatoExportacion.PorMailComoAdjunto:
                {
                    frm.EnviarPorEmail("Evaluación de Proveedores Farma.pdf");
                    break;
                }
                case Enumeraciones.FormatoExportacion.Excel:
                {
                    frm.Exportar("Evaluación de Proveedores Farma", ExportFormatType.Excel);
                    break;
                }
                case Enumeraciones.FormatoExportacion.Word:
                {
                    frm.Exportar("Evaluación de Proveedores Farma", ExportFormatType.WordForWindows);
                    break;
                }
                case Enumeraciones.FormatoExportacion.PDF:
                {
                    frm.Exportar("Evaluación de Proveedores Farma", ExportFormatType.PortableDocFormat);
                    break;
                }
                case Enumeraciones.FormatoExportacion.Impresion:
                {
                    btnImprimir_Click(null, null);
                    break;
                }
                case Enumeraciones.FormatoExportacion.PorPantalla:
                {
                    btnPantalla_Click(null, null);
                    break;
                }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rbListadoCompleto.Checked = true;
            rbListadoCompleto_Click(null, null);
        }
    }
}
