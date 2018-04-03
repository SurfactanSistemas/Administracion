using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Sectores
{
    public partial class Sectores_Inicio : Form
    {
        Sector sector = new Sector();
        private DataTable WOriginal;

        public Sectores_Inicio()
        {
            InitializeComponent();
            DGV_Sectores.DataSource = sector.ListarTodosCodigoDescripcion();
            WOriginal = (DataTable) DGV_Sectores.DataSource;
        }

        //private void BT_Filtrar_Click(object sender, EventArgs e)
        //{
        //    if (BT_Filtrar.Text == "Filtrar")
        //    {
        //        try
        //        {
        //            DataTable dataTable = DGV_Sectores.DataSource as DataTable;
        //            if (dataTable != null)
        //                dataTable.DefaultView.RowFilter = string.Format("CONVERT(" + LBFiltro.Text + ", System.String) like '%{0}%'", TBFiltro.Text);
        //            BT_Filtrar.Text = "Limp. Filtro";
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show(err.Message,"Error");
        //        }                
        //    }
        //    else
        //    {
        //        DataTable dataTable = DGV_Sectores.DataSource as DataTable;
        //        if (dataTable != null)
        //            dataTable.DefaultView.RowFilter = string.Empty;
        //        P_Filtrado.Visible = false;
        //        TBFiltro.Text = "";
        //        BT_Filtrar.Visible = true;
        //    }
        //}

        //private void BT_MenuFiltros_Click(object sender, EventArgs e)
        //{
        //    Button btnSender = (Button)sender;
        //    Point ptLowerLeft = new Point(0, btnSender.Height);
        //    ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);            
        //    CMS_Sectores.Show(ptLowerLeft);


        //    BT_Filtrar.Text = "Limp. Filtro";
        //    TBFiltro.Text = "";
        //}

        //private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    P_Filtrado.Visible = true;
        //    TBFiltro.Text = "";
        //    LBFiltro.Text = "Codigo";
        //    TBFiltro.Focus();
        //}

        //private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    P_Filtrado.Visible = true;
        //    TBFiltro.Text = "";
        //    LBFiltro.Text = "Descripcion";
        //    TBFiltro.Focus();
        //}

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

        //private void TBFiltro_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        BT_Filtrar.PerformClick();
        //        e.SuppressKeyPress = true;
        //        e.Handled = true;
        //    }
        //}

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

        //private void TBFiltro_TextChanged(object sender, EventArgs e)
        //{
        //    BT_Filtrar.Text = "Filtrar";
        //}

        private void DGV_Sectores_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifSector.PerformClick();
        }

        private void DGV_Sectores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGV_Sectores.Rows[e.RowIndex].Selected = true;
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
            TBFiltro.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new Listados.Sectores.ListadoSectores();
            Listados.VistaPrevia rp = new Listados.VistaPrevia();

            rp.CargarReporte(reporte);

            rp.ShowDialog();
        }
    }
}
