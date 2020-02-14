using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Novedades
{
    public partial class EvaluacionesProveedoresEnsayos : Form
    {
        public EvaluacionesProveedoresEnsayos()
        {
            InitializeComponent();
        }

        private void EvaluacionesProveedoresEnsayos_Load(object sender, EventArgs e)
        {
            _CargarDatos();
        }

        private void _CargarDatos()
        {
            DataTable datos =
                ConsultasVarias.Clases.Query.GetAll(
                    "SELECT ee.Proveedor, p.Nombre, ee.Periodo, ee.Mes, ee.Ano, ee.Fecha, ee.Vencimiento, ee.Evaluador, ee.Calificacion FROM EvaluaEnsayos ee INNER JOIN Proveedor p ON p.Proveedor= ee.Proveedor order by p.Nombre, ee.Ano DESC, ee.Mes DESC");

            dgvEvaluaciones.DataSource = datos;
        }

        private void EvaluacionesProveedoresEnsayos_Shown(object sender, EventArgs e)
        {
            txtFiltrar.Focus();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvEvaluaciones.DataSource as DataTable;

            if (tabla != null) tabla.DefaultView.RowFilter = "Nombre LIKE '%" + txtFiltrar.Text + "%'";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            EvaluacionProveedorEnsayos frm = new EvaluacionProveedorEnsayos();

            frm.Show(this);
        }

        private void dgvEvaluaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvEvaluaciones.CurrentRow != null)
            {
                string Proveedor = dgvEvaluaciones.CurrentRow.Cells["Proveedor"].Value.ToString();
                string Mes = dgvEvaluaciones.CurrentRow.Cells["Mes"].Value.ToString();
                string Ano = dgvEvaluaciones.CurrentRow.Cells["Ano"].Value.ToString();

                EvaluacionProveedorEnsayos frm = new EvaluacionProveedorEnsayos(Proveedor, Mes, Ano);

                frm.ShowDialog(this);

                _CargarDatos();
            }

        }

    }
}
