using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Modulo_Capacitacion.Listados;
using Modulo_Capacitacion.Listados.Sectores;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Sectores
{
    public partial class Sectores_Inicio : Form
    {
        Sector sector = new Sector();

        public Sectores_Inicio()
        {
            InitializeComponent();
            DGV_Sectores.DataSource = sector.ListarTodosCodigoDescripcion();
        }

        private void BTAgregarSector_Click(object sender, EventArgs e)
        {
            int UltimoId = sector.ObtenerUltimoId();

            AgModSector agregarSector = new AgModSector(UltimoId)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            agregarSector.ShowDialog();

            ActualizarGrilla();
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Sectores.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Sectores.SelectedRows[0].Cells[0].Value.ToString();

                if (MessageBox.Show("¿Seguro de que quiere eliminar el Sector indicado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sector.Eliminar(IdAEliminar);
                }

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void ActualizarGrilla()
        {
            DGV_Sectores.DataSource = sector.ListarTodosCodigoDescripcion();
        }

        private void BTModifSector_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Sectores.SelectedRows.Count != 1 ) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = DGV_Sectores.SelectedRows[0].Cells[0].Value.ToString();
                Sector SectorAModificar  = new Sector();
                SectorAModificar = sector.BuscarUno(IdAModificar);

                AgModSector modificarSector = new AgModSector(SectorAModificar)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                modificarSector.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DGV_Sectores_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifSector.PerformClick();
        }
        
        private void TBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltro.Text != "")
            {
                DataTable dataTable = DGV_Sectores.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) like '%{0}%' OR CONVERT(Descripcion, System.String) like '%{0}%'", TBFiltro.Text);
            }
            else
            {
                ActualizarGrilla();
            }
        }

        private void Sectores_Inicio_Shown(object sender, EventArgs e)
        {
            //TBFiltro.Focus();
            txtCodigo.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ReportDocument reporte = new ListadoSectores();
            VistaPrevia rp = new VistaPrevia();

            rp.CargarReporte(reporte);

            rp.ShowDialog();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                foreach (DataGridViewRow row in DGV_Sectores.Rows)
                {
                    var WCodigo = row.Cells["Codigo"].Value ?? "";

                    if (WCodigo.ToString().Trim() != "")
                    {
                        if (WCodigo.ToString().Trim() == txtCodigo.Text.Trim())
                        {
                            row.Selected = true;
                            DGV_Sectores_RowHeaderMouseDoubleClick(null, null);
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
