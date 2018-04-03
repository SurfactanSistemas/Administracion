using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Cursos
{
    public partial class Cursos_Inicio : Form
    {
        public Curso curso = new Curso();
        DataTable dtCursos;

        public Cursos_Inicio()
        {
            InitializeComponent();
        }

        private void Cursos_Inicio_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Cursos.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Cursos.SelectedRows[0].Cells[0].Value.ToString();
                curso.Eliminar(IdAEliminar);
                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void ActualizarGrilla()
        {
            //DGV_Cursos.DataSource = null;
            dtCursos = curso.ListarTodos();
            DGV_Cursos.DataSource = curso.ListarTodos();
        }

        private void claveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Clave");
        }

        private void temaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Tema");
        }

        private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Descripcion");
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Curso");
        }

        private void horaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepararFiltrado("Horas");
        }
        private void PrepararFiltrado(string opcion)
        {
            P_Filtrado.Visible = true;
            TBFiltro.Text = "";
            LBFiltro.Text = opcion;
            TBFiltro.Focus();
        }

        private void BT_MenuFiltros_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Curso.Show(ptLowerLeft);


            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltro.Text = "";
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (BT_Filtrar.Text == "Filtrar")
                {
                    (DGV_Cursos.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + LBFiltro.Text + ", System.String) like '%{0}%'", TBFiltro.Text);
                    BT_Filtrar.Text = "Limp. Filtro";
                }
                else
                {
                    (DGV_Cursos.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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

        private void BTAgregarCurso_Click(object sender, EventArgs e)
        {
            AgModCurso agregarOMod = new AgModCurso();
            agregarOMod.StartPosition = FormStartPosition.CenterScreen;
            agregarOMod.ShowDialog();

            ActualizarGrilla();
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

        private void BTModifCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Cursos.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = DGV_Cursos.SelectedRows[0].Cells[0].Value.ToString();
                Curso CursoAModificar = new Curso();
                CursoAModificar = curso.BuscarUno(IdAModificar);

                AgModCurso modificarCurso = new AgModCurso(CursoAModificar);
                modificarCurso.StartPosition = FormStartPosition.CenterScreen;
                modificarCurso.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }
    }
}
