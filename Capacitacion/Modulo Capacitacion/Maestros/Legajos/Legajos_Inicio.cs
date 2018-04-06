using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Modulo_Capacitacion.Listados;
using Modulo_Capacitacion.Listados.Perfiles;
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
        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTAgregarLegajo_Click(object sender, EventArgs e)
        {
            AgModLegajo agrModLegajo = new AgModLegajo();
            agrModLegajo.StartPosition = FormStartPosition.CenterScreen;
            agrModLegajo.ShowDialog();

            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            TBFiltro.Text = "";

            dtLegajos = L.ListarTodos();
            ArmardtMuestra();
            DGV_Legajos.DataSource = dtMuestraInicio;

            if (ckSoloActivos.Checked)
            {
                DataTable dataTable = DGV_Legajos.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = "CONVERT(Egreso, System.String) = '00/00/0000' OR CONVERT(Egreso, System.String) = '  /  /    '";
            }

            DGV_Legajos.Columns["Egreso"].Visible = false;

            TBFiltro.Focus();
        }

        private void ArmardtMuestra()
        {
            dtMuestraInicio = new DataTable();
            CargarDt();

            foreach (DataRow fila in dtLegajos.Rows)
            {
                DataRow dr;
                dr = dtMuestraInicio.NewRow();

                dr["Clave"] = fila[0].ToString();
                dr["Codigo"] = fila[1].ToString();
                dr["Descripcion"] = fila[3].ToString();
                dr["Vigencia"] = fila[30].ToString();
                dr["Perfil"] = fila[32].ToString();
                dr["Sector"] = fila[55].ToString();
                dr["Dni"] = fila["Dni"].ToString();
                dr["Egreso"] = fila["FEgreso"].ToString();

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
            try
            {
                if (DGV_Legajos.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = DGV_Legajos.SelectedRows[0].Cells[1].Value.ToString();
                Legajo LegajoAModificar = new Legajo();
                LegajoAModificar = L.BuscarUno(IdAModificar);

                AgModLegajo AgMod = new AgModLegajo(LegajoAModificar);
                AgMod.StartPosition = FormStartPosition.CenterScreen;
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
                    dataTable.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) like '%{0}%' "
                                                    + " OR CONVERT(Descripcion, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Vigencia, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Sector, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Dni, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Perfil, System.String) like '%{0}%'", TBFiltro.Text);
            }
            else
            {
                ActualizarGrilla();
            }
        }

        private void DGV_Perfiles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifLegajo.PerformClick();
        }

        private void Legajos_Inicio_Shown(object sender, EventArgs e)
        {
            TBFiltro.Focus();
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
            Listados.Legajos.Inicio frm = new Listados.Legajos.Inicio();
            frm.ShowDialog();

            ActualizarGrilla();
        }

        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
