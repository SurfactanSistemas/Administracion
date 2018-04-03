using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            P_Filtrado.Visible = false;

        }

        private void ActualizarGrilla()
        {
            dtMuestraInicio.Rows.Clear();
            dtLegajos = L.ListarTodos();
            ArmardtMuestra();
            DGV_Legajos.DataSource = dtMuestraInicio;
        }

        private void ArmardtMuestra()
        {
            


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

                dtMuestraInicio.Rows.Add(dr);

            }
        }

        private void BT_MenuFiltros_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Legajo.Show(ptLowerLeft);

            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltro.Text = "";
        }

        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Codigo");
        }

        private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Descripcion");
        }

        private void fechaIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("FIngreso");
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Perfil");
        }

        private void PrepararFiltrado(string opcion)
        {
            P_Filtrado.Visible = true;
            TBFiltro.Text = "";
            LBFiltro.Text = opcion;
            TBFiltro.Focus();
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (BT_Filtrar.Text == "Filtrar")
                {
                    //DGV_Legajos.Rows.Clear();
                    (DGV_Legajos.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + LBFiltro.Text + ", System.String) like '%{0}%'", TBFiltro.Text);
                    BT_Filtrar.Text = "Limp. Filtro";
                }
                else
                {
                    LimpiarFiltro();
                    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void LimpiarFiltro()
        {
            (DGV_Legajos.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            P_Filtrado.Visible = false;
            TBFiltro.Text = "";
            BT_Filtrar.Visible = true;
        }

        private void TBFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Filtrar.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Legajos.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");                
                L.Eliminar(DGV_Legajos.SelectedRows[0].Cells[0].Value.ToString());
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
                LimpiarFiltro();
                P_Filtrado.Visible = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void TBFiltro_TextChanged(object sender, EventArgs e)
        {
            BT_Filtrar.Text = "Filtrar";
        }

        private void Legajos_Inicio_Load(object sender, EventArgs e)
        {

        }

        private void CMS_Legajo_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
