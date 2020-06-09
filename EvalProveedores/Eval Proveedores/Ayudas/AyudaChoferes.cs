using System;
using System.Data;
using System.Windows.Forms;
using Util.Clases;
using Eval_Proveedores.Interfaces;

namespace Eval_Proveedores.Ayudas
{
    public partial class AyudaChoferes : Form
    {
        private string WProveedor;

        public AyudaChoferes(string Proveedor)
        {
            WProveedor = Proveedor;
            InitializeComponent();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = (DataTable) dgvDatos.DataSource;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("Chofer LIKE '%{0}%' Or Descripcion LIKE '%{0}%'",
                    txtFiltrar.Text);
        }

        private void dgvDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string WChofer = Helper.OrDefault(dgvDatos.Rows[e.RowIndex].Cells["Chofer"].Value, "").ToString();
            string WDescripcion = Helper.OrDefault(dgvDatos.Rows[e.RowIndex].Cells["Descripcion"].Value, "").ToString();

            IAyudaChoferes frm = (IAyudaChoferes)Owner;
            if (frm != null) frm.ProcesarAyudaChoferes(WChofer, WDescripcion);

            Close();
        }

        private void AyudaChoferes_Load(object sender, EventArgs e)
        {
            DataTable proveedores =
                Query.GetAll("SELECT Codigo As Chofer, rtrim(Descripcion) As Descripcion FROM Chofer WHERE Proveedor = '" + WProveedor + "' Order by Descripcion");
            dgvDatos.DataSource = proveedores;
        }

        private void AyudaProveedores_Shown(object sender, EventArgs e)
        {
            txtFiltrar.Focus();
        }
    }
}
