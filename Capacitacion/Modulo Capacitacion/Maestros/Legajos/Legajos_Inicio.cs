using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modulo_Capacitacion.Listados.Legajos;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Legajos
{
    public partial class Legajos_Inicio : Form
    {

        Legajo L = new Legajo();
        DataTable dtLegajos;
        DataTable dtMuestraInicio = new DataTable();
        private Boolean sortAsc = false;

        public Legajos_Inicio()
        {
            InitializeComponent();
            CargarDt();
            ActualizarGrilla();
        }

        private void CargarDt()
        {
            dtMuestraInicio.Columns.Add("Clave", typeof(string));
            dtMuestraInicio.Columns.Add("Codigo", typeof(int));
            dtMuestraInicio.Columns.Add("Descripcion", typeof(string));
            dtMuestraInicio.Columns.Add("Vigencia", typeof(string));
            dtMuestraInicio.Columns.Add("Sector", typeof(int));
            dtMuestraInicio.Columns.Add("Perfil", typeof(int));
            dtMuestraInicio.Columns.Add("Dni", typeof(string));
            dtMuestraInicio.Columns.Add("Egreso", typeof(string));
            dtMuestraInicio.Columns.Add("Actualizado", typeof(string));
            dtMuestraInicio.Columns.Add("VigenciaOrd", typeof(int));
            dtMuestraInicio.Columns.Add("Mostrar", typeof(string));
        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTAgregarLegajo_Click(object sender, EventArgs e)
        {
            AgModLegajo agrModLegajo = new AgModLegajo {StartPosition = FormStartPosition.CenterScreen};
            agrModLegajo.ShowDialog();

            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            TBFiltro.Text = "";

            L.ActualizarFechasIngresoOrden();
            //dtLegajos = L.ListarTodos();
            dtLegajos = L.ListarTodosParaGrilla();
            ArmardtMuestra();
            DGV_Legajos.DataSource = dtMuestraInicio;

            _ProcesarPersonalConMasDeUnPerfil();

            if (!ckSoloActivos.Checked)
            {
                /*
                 * Filtramos aquellos que se encuentren activos y estén para mostrar.
                 */
                DataTable dataTable = (DataTable) DGV_Legajos.DataSource;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = "(CONVERT(Egreso, System.String) = '00/00/0000' OR CONVERT(Egreso, System.String) = '  /  /    ') AND CONVERT(Mostrar, System.String) <> 'N'";
            }

            if (ckSoloNoActualizados.Checked)
            {
                /*
                 * Filtro aquellos que esten activos y que no se encuentren actualizados.
                 */
                DataTable dataTable = (DataTable) DGV_Legajos.DataSource;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = "(CONVERT(Actualizado, System.String) = 'N' OR CONVERT(Actualizado, System.String) = 'n') AND CONVERT(Mostrar, System.String) <> 'N' AND (CONVERT(Egreso, System.String) = '00/00/0000' OR CONVERT(Egreso, System.String) = '  /  /    ')";
            }

            _OcultarColumnasAuxiliares();

            TBFiltro.Focus();
        }

        private void _ProcesarPersonalConMasDeUnPerfil()
        {
            string WAnterior = "";

            DataTable table = DGV_Legajos.DataSource as DataTable;

            if (table == null) return;

            foreach (DataRow _row in table.Rows)
            {
                string WActual  = _row["Descripcion"].ToString();

                if (WActual.Trim() == WAnterior.Trim())
                {
                    _row["Mostrar"] = "N";
                    WAnterior = WActual.Trim();
                }

            }

            DataRow[] row = table.Select("Mostrar='N'");

            foreach (DataRow r in row)
            {
                DataRow[] r2 = table.Select("Descripcion='" + r["Descripcion"] + "'");

                foreach (DataRow r3 in r2)
                {
                    r3["Vigencia"] = "";
                    r3["Sector"] = "";
                    r3["Perfil"] = "";
                }

            }

        }

        private void _OcultarColumnasAuxiliares()
        {
            foreach (string columna in new[] {"Egreso", "Actualizado", "Grisar", "Mostrar", "VigenciaOrd"})
            {
                using (var column = DGV_Legajos.Columns[columna])
                {
                    if (column != null) column.Visible = false;
                }
            }
        }

        private void ArmardtMuestra()
        {
            dtMuestraInicio = new DataTable();
            CargarDt();

            foreach (DataRow fila in dtLegajos.Rows)
            {
                var dr = dtMuestraInicio.NewRow();

                dr["Clave"] = fila["Clave"].ToString();
                dr["Codigo"] = fila["Codigo"].ToString();
                dr["Descripcion"] = fila["Descripcion"].ToString();
                dr["Vigencia"] = fila["FechaVersion"].ToString();
                dr["Perfil"] = fila["Perfil"].ToString();
                dr["Sector"] = fila["Sector"].ToString();
                dr["Dni"] = fila["Dni"].ToString();
                dr["Egreso"] = fila["FEgreso"].ToString();
                dr["Actualizado"] = fila["Actualizado"].ToString();
                dr["VigenciaOrd"] = fila["VigenciaOrd"].ToString();
                dr["Mostrar"] = "";

                dtMuestraInicio.Rows.Add(dr);

            }
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Legajos.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");

                if (MessageBox.Show("¿Está seguro de querer eliminar el Legajo indicado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    L.Eliminar(DGV_Legajos.SelectedRows[0].Cells[1].Value.ToString());
                }

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BTModifLegajo_Click(object sender, EventArgs e)
        {
            _AbrirModificarLegajo(DGV_Legajos);
        }

        private void _AbrirModificarLegajo(DataGridView grid)
        {
            try
            {
                if (grid.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = grid.SelectedRows[0].Cells["Codigo"].Value.ToString();
                Legajo LegajoAModificar = new Legajo();
                LegajoAModificar = L.BuscarUno(IdAModificar);

                AgModLegajo AgMod = new AgModLegajo(LegajoAModificar) {StartPosition = FormStartPosition.CenterScreen};
                AgMod.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void TBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            var WFiltro = "";

            if (!ckSoloActivos.Checked)
            {
                WFiltro = " AND (CONVERT(Egreso, System.String) = '00/00/0000' OR CONVERT(Egreso, System.String) = '  /  /    ')";
            }

            DataTable dataTable = DGV_Legajos.DataSource as DataTable;
            if (dataTable != null)
                dataTable.DefaultView.RowFilter = string.Format("((CONVERT(Codigo, System.String) like '%{0}%' "
                                                + " OR CONVERT(Descripcion, System.String) like '%{0}%'"
                                                + " OR CONVERT(Vigencia, System.String) like '%{0}%'"
                                                + " OR CONVERT(Sector, System.String) like '%{0}%'"
                                                + " OR CONVERT(Dni, System.String) like '%{0}%'"
                                                + " OR CONVERT(Perfil, System.String) like '%{0}%') AND CONVERT(Mostrar, System.String) <> 'N')"
                                                + " {1}", TBFiltro.Text, WFiltro);
            
        }

        private void DGV_Perfiles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = DGV_Legajos.Rows[e.RowIndex];
            if (row.Cells["Vigencia"].Value.ToString() == "" && row.Cells["Sector"].Value.ToString() == "" && row.Cells["Perfil"].Value.ToString() == "")
            {
                DataTable WLegajos = L.ListarLegajosDiscriminado(row.Cells["Descripcion"].Value.ToString());

                dgvDiscriminarLegajos.DataSource = WLegajos;
                DataGridViewColumn column = dgvDiscriminarLegajos.Columns["Descripcion"];
                if (column != null)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                foreach (var WColumna in new[]{"Grisar", "Mostrar", "VigenciaOrd"})
                {
                    column = dgvDiscriminarLegajos.Columns[WColumna];
                    if (column != null)
                        column.Visible = false;
                }

                column = dgvDiscriminarLegajos.Columns["Codigo"];
                if (column != null)
                    column.Width = 50;

                int WWidth = pnlDiscriminarLegajos.Width;

                pnlDiscriminarLegajos.Location = new Point((Width/2) - WWidth/2, pnlDiscriminarLegajos.Location.Y);
                pnlDiscriminarLegajos.Visible = true;

                foreach (DataGridViewRow _row in dgvDiscriminarLegajos.Rows)
                {
                    if (_row.Cells["Grisar"].Value.ToString() == "S")
                    {
                        _row.DefaultCellStyle.BackColor = Color.DarkGray;
                        _row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                BTModifLegajo.PerformClick();
            }

        }

        private void Legajos_Inicio_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void TBFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TBFiltro.Text = "";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Inicio frm = new Inicio();
            frm.ShowDialog();

            ActualizarGrilla();
        }

        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDiscriminarLegajos.Visible = false;
            TBFiltro.Focus();
        }

        private void dgvDiscriminarLegajos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pnlDiscriminarLegajos.Visible = false;
            _AbrirModificarLegajo(dgvDiscriminarLegajos);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                string IdAModificar = txtCodigo.Text.Trim();
                Legajo LegajoAModificar = new Legajo();
                LegajoAModificar = L.BuscarUno(IdAModificar);

                if (LegajoAModificar.Codigo == 0) return;

                AgModLegajo AgMod = new AgModLegajo(LegajoAModificar) { StartPosition = FormStartPosition.CenterScreen };
                AgMod.ShowDialog();

                txtCodigo.Text = "";

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBFiltro.Text = "";
            TBFiltro.Focus();
            TBFiltro_KeyUp(null, null);
        }

        private void DGV_Legajos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Legajos_Inicio_Load(object sender, EventArgs e)
        {

        }

        private void DGV_Legajos_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            DGV_Legajos.ClearSelection();

            Double num1, num2;

            switch (e.Column.Index)
            {
                case 0:
                {
                    num1 = double.Parse(e.CellValue1.ToString());
                    num2 = double.Parse(e.CellValue2.ToString());
                    break;
                }
                case 3:
                {
                    num1 = double.Parse(Helper.OrdenarFecha(e.CellValue1.ToString()));
                    num2 = double.Parse(Helper.OrdenarFecha(e.CellValue2.ToString()));
                    break;
                }
                default:
                {
                    return;
                }
            }

            if (num1 < num2)
            {
                e.SortResult = -1;
            }else if (num1 == num2)
            {
                e.SortResult = 0;
            }
            else
            {
                e.SortResult = 1;
            }

            e.Handled = true;
        }

        private void DGV_Legajos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable tabla = (DataTable) DGV_Legajos.DataSource;
            string ordenamiento = "";

            switch (e.ColumnIndex)
            {
                case 3:
                {
                    ordenamiento = "VigenciaOrd " + ((this.sortAsc) ? "DESC" : "ASC");
                    break;
                }
                case 2:
                {
                    ordenamiento = "Descripcion " + ((this.sortAsc) ? "DESC" : "ASC");
                    break;
                }
                case 1:
                case 4:
                case 5:
                {
                    string columna = DGV_Legajos.Columns[e.ColumnIndex].Name;

                    ordenamiento = columna + " " + ((this.sortAsc) ? "DESC" : "ASC");

                    break;
                }
            }

            if (tabla !=null) tabla.DefaultView.Sort = ordenamiento;

            this.sortAsc = !this.sortAsc;
        }
    }
}
