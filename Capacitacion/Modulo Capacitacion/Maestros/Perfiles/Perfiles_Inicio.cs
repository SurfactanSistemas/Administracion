using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Perfiles
{
    public partial class Perfiles_Inicio : Form
    {
        Perfil P = new Perfil();            
        public Perfiles_Inicio()
        {
            InitializeComponent();
            
            CargarPerfiles();
        }

        private void CargarPerfiles()
        {
            DGV_Perfiles.DataSource = P.ListarTodosInicio();
        }

        private void BTAgregarPerfil_Click(object sender, EventArgs e)
        {
            AgModPerfil agregarModPerfil = new AgModPerfil();
            agregarModPerfil.StartPosition = FormStartPosition.CenterScreen;
            agregarModPerfil.ShowDialog();

            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {

            DGV_Perfiles.DataSource = P.ListarTodosInicio();
        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_MenuFiltros_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Perfil.Show(ptLowerLeft);


            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltro.Text = "";
        }

        private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Descripcion");
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Version");
        }

        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Codigo");
        }

        private void sectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Sector");
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
                    (DGV_Perfiles.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + LBFiltro.Text + ", System.String) like '%{0}%'", TBFiltro.Text);
                    BT_Filtrar.Text = "Limp. Filtro";
                }
                else
                {
                    (DGV_Perfiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    P_Filtrado.Visible = false;
                    TBFiltro.Text = "";
                    BT_Filtrar.Visible = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void TBFiltro_TextChanged(object sender, EventArgs e)
        {
            BT_Filtrar.Text = "Filtrar";
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
                if (DGV_Perfiles.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Perfiles.SelectedRows[0].Cells[0].Value.ToString();
                P.Eliminar(IdAEliminar);
                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BTModifSector_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Perfiles.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = DGV_Perfiles.SelectedRows[0].Cells[0].Value.ToString();
                Perfil PerfilAModificar = new Perfil();
                PerfilAModificar = P.BuscarUno(IdAModificar);

                AgModPerfil modificarPerfil = new AgModPerfil(PerfilAModificar);
                modificarPerfil.StartPosition = FormStartPosition.CenterScreen;
                modificarPerfil.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void Perfiles_Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
