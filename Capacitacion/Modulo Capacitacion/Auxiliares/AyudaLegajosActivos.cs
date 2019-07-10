using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Modulo_Capacitacion.Interfaces;
using Negocio;

namespace Modulo_Capacitacion.Auxiliares
{
    public partial class AyudaLegajosActivos : Form
    {
        private int WRowIndex = -1;
        private string ZTema;

        public AyudaLegajosActivos()
        {
            InitializeComponent();
        }

        private void CursosDisponibles_Load(object sender, EventArgs e)
        {
            CargarLegajosActivos();
            txtFiltrar.Focus();
        }

        private void CargarLegajosActivos()
        {
            try
            {
                DataTable tabla = new DataTable();

                tabla = (new Legajo()).ListarTodosParaGrilla();

                dgvCursos.DataSource = tabla;

                DataTable dataTable = (DataTable) dgvCursos.DataSource;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = "(CONVERT(FEgreso, System.String) = '00/00/0000' OR CONVERT(FEgreso, System.String) = '  /  /    ')";

                foreach (DataGridViewColumn col in dgvCursos.Columns)
                {
                    if (!(new[] {"Codigo", "Descripcion"}).Contains(col.Name))
                    {
                        col.Visible = false;
                    }
                }

                DataGridViewColumn column = dgvCursos.Columns["Descripcion"];
                if (column != null)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void dgvCursos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IAyudaLegajos WOwner = (IAyudaLegajos)Owner;

            if (WOwner == null) return;

            if (dgvCursos.CurrentRow != null)
            {
                var WCodigo = dgvCursos.CurrentRow.Cells["Codigo"].Value ?? "0";
                var WDescripcion = dgvCursos.CurrentRow.Cells["Descripcion"].Value ?? "";

                WOwner._ProcesarAyudaLegajos(WCodigo, WDescripcion);

                Close();
            }

        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvCursos.DataSource as DataTable;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("Descripcion LIKE '%{0}%'", txtFiltrar.Text);
        }

        private void AyudaLegajosActivos_Shown(object sender, EventArgs e)
        {
            txtFiltrar.Focus();
        }
    }
}
