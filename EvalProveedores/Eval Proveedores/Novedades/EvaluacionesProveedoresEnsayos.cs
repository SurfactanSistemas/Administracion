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
            DataTable datos = ConsultasVarias.Clases.Query.GetAll("SELECT e.Proveedor, p.Nombre, Periodo = (dbo.LPAD(e.Mes, 2) + '/' + cast(e.Ano as varchar(4))), e.Mes, e.Ano, CASE WHEN ISNULL(e.Evaluador, '') = '' THEN 'NO INFORMADO' ELSE e.Evaluador END , e.Promedio FROM EvaluaI e INNER JOIN Proveedor p ON p.Proveedor= e.Proveedor order by p.Nombre, e.Ano DESC, e.Mes DESC");

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

    }
}
