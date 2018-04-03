using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Temas
{
    public partial class Temas_Inicio : Form
    {
        public Tema temas = new Tema();
        public Temas_Inicio()
        {
            InitializeComponent();
            DGV_Temas.DataSource = temas.ListarTodos();
        }

        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Codigo");
        }

        private void PrepararFiltrado(string opcion)
        {
            P_Filtrado.Visible = true;
            TBFiltro.Text = "";
            LBFiltro.Text = opcion;
            TBFiltro.Focus();
        }

        private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Descripcion");
        }

        private void responableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Responsable");
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Tipo");
        }

        private void BT_MenuFiltros_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Temas.Show(ptLowerLeft);


            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltro.Text = "";
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (BT_Filtrar.Text == "Filtrar")
                {
                    (DGV_Temas.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + LBFiltro.Text + ", System.String) like '%{0}%'", TBFiltro.Text);
                    BT_Filtrar.Text = "Limp. Filtro";
                }
                else
                {
                    (DGV_Temas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Temas.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Temas.SelectedRows[0].Cells[0].Value.ToString();
                temas.Eliminar(IdAEliminar);
                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void ActualizarGrilla()
        {
            //DGV_Temas.DataSource = null;
            DGV_Temas.DataSource = temas.ListarTodos(); ;
        }

        private void BTAgregarTema_Click(object sender, EventArgs e)
        {
            int UltimoId = temas.ObtenerUltimoId();
            AgModTema agregarTema = new AgModTema(UltimoId);
            agregarTema.StartPosition = FormStartPosition.CenterScreen;
            agregarTema.ShowDialog();

            ActualizarGrilla();
        }

        private void BTModifTema_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Temas.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = DGV_Temas.SelectedRows[0].Cells[0].Value.ToString();
                Tema TemaAModificar = new Tema();
                TemaAModificar = temas.BuscarUno(IdAModificar);

                AgModTema modificarTema = new AgModTema(TemaAModificar);
                modificarTema.StartPosition = FormStartPosition.CenterScreen;
                modificarTema.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void Temas_Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
