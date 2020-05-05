using System;
using System.Data;
using System.Windows.Forms;
using Util.Clases;
using Eval_Proveedores.Interfaces;

namespace Eval_Proveedores.Ayudas
{
    public partial class AyudaOperadores : Form
    {
        public AyudaOperadores()
        {
            InitializeComponent();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = (DataTable) dgvDatos.DataSource;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("CONVERT(Operador, System.String) LIKE '%{0}%' Or Descripcion LIKE '%{0}%'",
                    txtFiltrar.Text);
        }

        private void dgvDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string WProveedor = Helper.OrDefault(dgvDatos.Rows[e.RowIndex].Cells["Operador"].Value, "").ToString();
            string WDescripcion = Helper.OrDefault(dgvDatos.Rows[e.RowIndex].Cells["Descripcion"].Value, "").ToString();

            IAyudaOperadores frm = (IAyudaOperadores) Owner;
            if (frm != null) frm.ProcesarAyudaOperadores(WProveedor, WDescripcion);

            Close();
        }

        private void AyudaOperadores_Load(object sender, EventArgs e)
        {
            DataTable proveedores =
                Query.GetAll("SELECT Operador, rtrim(Descripcion) As Descripcion FROM Operador Order by Descripcion");
            dgvDatos.DataSource = proveedores;
        }

        private void AyudaOperadores_Shown(object sender, EventArgs e)
        {
            txtFiltrar.Focus();
        }
    }
}
