using System;
using System.Data;
using System.Windows.Forms;
using ConsultasVarias.Clases;
using Eval_Proveedores.Interfaces;

namespace Eval_Proveedores.Ayudas
{
    public partial class AyudaProveedores : Form
    {
        public AyudaProveedores()
        {
            InitializeComponent();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = (DataTable) dgvDatos.DataSource;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("Proveedor LIKE '%{0}%' Or Descripcion LIKE '%{0}%'",
                    txtFiltrar.Text);
        }

        private void dgvDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string WProveedor = Helper.OrDefault(dgvDatos.Rows[e.RowIndex].Cells["Proveedor"].Value, "").ToString();
            string WDescripcion = Helper.OrDefault(dgvDatos.Rows[e.RowIndex].Cells["Descripcion"].Value, "").ToString();

            IAyudaProveedores frm = (IAyudaProveedores) Owner;
            if (frm != null) frm.ProcesarAyudaProveedores(WProveedor, WDescripcion);

            Close();
        }

        private void AyudaProveedores_Load(object sender, EventArgs e)
        {
            DataTable proveedores =
                Query.GetAll("SELECT Proveedor, rtrim(Nombre) As Descripcion FROM Proveedor Order by Nombre");
            dgvDatos.DataSource = proveedores;
        }

        private void AyudaProveedores_Shown(object sender, EventArgs e)
        {
            txtFiltrar.Focus();
        }
    }
}
