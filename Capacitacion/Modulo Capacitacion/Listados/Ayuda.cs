using System;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados
{
    public partial class Ayuda : Form
    {

        public Object Valor { get; set; }

        public Ayuda(DataTable WDatos, object actual = null)
        {
            InitializeComponent();
            Valor = actual ?? "";
            dgvAyuda.DataSource = WDatos;

            DataGridViewColumn col = dgvAyuda.Columns["Descripcion"];
            if (col != null) col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Ayuda_Shown(object sender, EventArgs e)
        {
            txtAyuda.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAyuda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAyuda.CurrentRow != null) Valor = dgvAyuda.CurrentRow.Cells["Codigo"].Value;
            Close();
        }

        private void txtAyuda_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataTable tabla = dgvAyuda.DataSource as DataTable;
            if (tabla != null) tabla.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtAyuda.Text);
        }
    }
}
