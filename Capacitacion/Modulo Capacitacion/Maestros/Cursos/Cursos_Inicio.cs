using System;
using System.Data;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Cursos
{
    public partial class Cursos_Inicio : Form
    {
        public Curso curso = new Curso();

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
            Close();
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Cursos.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Cursos.SelectedRows[0].Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está seguro de querer eliminar el curso indicado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    curso.Eliminar(IdAEliminar); 
                }

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void ActualizarGrilla()
        {
            DGV_Cursos.DataSource = curso.ListarTodos();
        }

        private void BTAgregarCurso_Click(object sender, EventArgs e)
        {
            AgModCurso agregarOMod = new AgModCurso {StartPosition = FormStartPosition.CenterScreen};
            agregarOMod.ShowDialog();

            ActualizarGrilla();
        }

        private void BTModifCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Cursos.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = DGV_Cursos.SelectedRows[0].Cells[0].Value.ToString();
                Curso CursoAModificar = new Curso();
                CursoAModificar = curso.BuscarUno(IdAModificar);

                AgModCurso modificarCurso = new AgModCurso(CursoAModificar)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                modificarCurso.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void TBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltro.Text != "")
            {
                DataTable dataTable = DGV_Cursos.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("CONVERT(Tema, System.String) like '%{0}%' "
                                                    + " OR CONVERT(Descripcion, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Curso, System.String) like '%{0}%'"
                                                    + " OR CONVERT(CursoDesc, System.String) like '%{0}%'", TBFiltro.Text);
            }
            else
            {
                ActualizarGrilla();
            }
        }

        private void DGV_Cursos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifCurso.PerformClick();
        }

        private void Cursos_Inicio_Shown(object sender, EventArgs e)
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
            Listados.Cursos.Inicio frm = new Listados.Cursos.Inicio();
            frm.ShowDialog();
        }

    }
}
