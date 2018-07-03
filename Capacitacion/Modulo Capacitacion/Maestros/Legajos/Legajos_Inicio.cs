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
        public Legajos_Inicio()
        {
            InitializeComponent();
            CargarDt();
            ActualizarGrilla();
        }

        private void CargarDt()
        {
            dtMuestraInicio.Columns.Add("Clave", typeof(string));
            dtMuestraInicio.Columns.Add("Codigo", typeof(string));
            dtMuestraInicio.Columns.Add("Descripcion", typeof(string));
            dtMuestraInicio.Columns.Add("Vigencia", typeof(string));
            dtMuestraInicio.Columns.Add("Sector", typeof(string));
            dtMuestraInicio.Columns.Add("Perfil", typeof(string));
            dtMuestraInicio.Columns.Add("Dni", typeof(string));
            dtMuestraInicio.Columns.Add("Egreso", typeof(string));
            dtMuestraInicio.Columns.Add("Actualizado", typeof(string));
            dtMuestraInicio.Columns.Add("VigenciaOrd", typeof(string));
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
                DataTable dataTable = (DataTable) DGV_Legajos.DataSource;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = "(CONVERT(Egreso, System.String) = '00/00/0000' OR CONVERT(Egreso, System.String) = '  /  /    ') AND CONVERT(Mostrar, System.String) <> 'N'";
            }

            if (ckSoloNoActualizados.Checked)
            {
                DataTable dataTable = (DataTable) DGV_Legajos.DataSource;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = "(CONVERT(Actualizado, System.String) = 'N' OR CONVERT(Actualizado, System.String) = 'n') AND CONVERT(Mostrar, System.String) <> 'N'";
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
                }

                WAnterior = WActual.Trim();

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
                    L.Eliminar(DGV_Legajos.SelectedRows[0].Cells[0].Value.ToString());
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
            if (TBFiltro.Text != "")
            {
                DataTable dataTable = DGV_Legajos.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("(CONVERT(Codigo, System.String) like '%{0}%' "
                                                    + " OR CONVERT(Descripcion, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Vigencia, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Sector, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Dni, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Perfil, System.String) like '%{0}%') AND CONVERT(Mostrar, System.String) <> 'N'", TBFiltro.Text);
            }
            else
            {
                ActualizarGrilla();
            }
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

                foreach (DataGridViewRow row in DGV_Legajos.Rows)
                {
                    var WCodigo = row.Cells["Codigo"].Value ?? "";
                    if (WCodigo.ToString().Trim() != "")
                    {
                        if (txtCodigo.Text.Trim() == WCodigo.ToString().Trim())
                        {
                            row.Selected = true;
                            DGV_Perfiles_RowHeaderMouseDoubleClick(null, new DataGridViewCellMouseEventArgs(0, row.Index, 0,0, new MouseEventArgs(MouseButtons.None, 0,0,0,0)));
                            txtCodigo.Text = "";
                            return;
                        }
                    }
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }
    }
}
