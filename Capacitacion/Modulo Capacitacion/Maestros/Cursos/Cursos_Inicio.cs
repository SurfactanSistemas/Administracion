using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Modulo_Capacitacion.Listados.Cursos;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Cursos
{
    public partial class Cursos_Inicio : Form
    {
        public Curso curso = new Curso();

        private int POSICION_FINAL = 0;
        private int POSICION_INICIAL = 0;

        public Cursos_Inicio()
        {
            InitializeComponent();
        }

        private void Cursos_Inicio_Load(object sender, EventArgs e)
        {
            pnlCursos.Visible = false;
            lblTema.Text = "0";
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
                if (dgvTemas.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = dgvTemas.SelectedRows[0].Cells[0].Value.ToString();

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
            dgvTemas.DataSource = curso.ListarTodos();
        }

        private void BTAgregarCurso_Click(object sender, EventArgs e)
        {
            var WTema = "";

            if (pnlCursos.Visible)
            {
                WTema = lblTema.Text;
            }

            if (dgvTemas.SelectedRows.Count > 0)
            {
                var t = dgvTemas.SelectedRows[0].Cells["Tema"].Value ?? "";
                WTema = t.ToString();
            }

            AgModCurso agregarOMod = new AgModCurso(WTema) {StartPosition = FormStartPosition.CenterScreen};
            agregarOMod.ShowDialog();

            //ActualizarGrilla();
        }

        private void BTModifCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCursos.SelectedRows.Count != 1) throw new Exception("Se debe seleccionar una fila a modificar");

                string IdAModificar = dgvCursos.SelectedRows[0].Cells["Clave"].Value.ToString();
                Curso CursoAModificar = new Curso();
                CursoAModificar = curso.BuscarUno(IdAModificar);

                AgModCurso modificarCurso = new AgModCurso(CursoAModificar)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                modificarCurso.ShowDialog();

                dgvCursos.DataSource = _TraerCursos(CursoAModificar.Curso_Id.ToString());

                //ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void TBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
                DataTable dataTable = dgvTemas.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("CONVERT(Tema, System.String) like '%{0}%' "
                                                    //+ " OR CONVERT(Descripcion, System.String) like '%{0}%'"
                                                    //+ " OR CONVERT(Curso, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Descripcion, System.String) like '%{0}%'", TBFiltro.Text);
        }

        private void DGV_Cursos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string WTema = dgvTemas.Rows[e.RowIndex].Cells["Tema"].Value.ToString();
            string WDescripcion = dgvTemas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            
            _CargarCursosDisponibles(WTema, WDescripcion);

            //BTModifCurso.PerformClick();
        }

        private void _CargarCursosDisponibles(string WTema, string wDescripcion)
        {
            dgvCursos.DataSource = _TraerCursos(WTema);

            lblTema.Text = WTema;

            groupBox1.Text = "Tema: " + wDescripcion.ToUpper().Trim();

            DataGridViewColumn dataGridViewColumn = dgvCursos.Columns["Descripcion"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (string columna in new[] {"Clave"})
            {
                DataGridViewColumn column = dgvCursos.Columns[columna];
                if (column != null) column.Visible = false;
            }

            pnlCursos.Location = new Point((Width/2) - pnlCursos.Width / 2 , pnlCursos.Location.Y);
            pnlCursos.Visible = true;
        }

        private DataTable _TraerCursos(string wTema)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Clave as Clave, Tema as Curso, Descripcion FROM Tema WHERE Curso = '" + wTema + "' ORDER BY Tema";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            tabla.Load(dr);
                        }
                    }
                }

            }

            return tabla;
        }

        private void Cursos_Inicio_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
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
            Inicio frm = new Inicio();
            frm.ShowDialog();
        }

        private void btnCerrarCursos_Click(object sender, EventArgs e)
        {
            dgvCursos.DataSource = null;
            pnlCursos.Visible = false;
        }

        private void dgvCursos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            BTModifCurso_Click(null, null);
        }

        private void dgvCursos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            dgvCursos.Rows[e.RowIndex].Selected = true;

            BTModifCurso_Click(null, null);
        }

        private void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            if (dgvTemas.SelectedCells.Count < 0) return;

            //dgvTemas.Rows[dgvTemas.SelectedCells[0].RowIndex].Selected = true;

            string WTema = dgvTemas.Rows[dgvTemas.SelectedCells[0].RowIndex].Cells["Tema"].Value.ToString();
            string WDescripcion = dgvTemas.Rows[dgvTemas.SelectedCells[0].RowIndex].Cells["Descripcion"].Value.ToString();

            _CargarCursosDisponibles(WTema, WDescripcion);
   
        }

        private void dgvTemas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            string WTema = dgvTemas.Rows[e.RowIndex].Cells["Tema"].Value.ToString();
            string WDescripcion = dgvTemas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

            _CargarCursosDisponibles(WTema, WDescripcion);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                foreach (DataGridViewRow row in dgvTemas.Rows)
                {
                    var WCodigo = row.Cells["Tema"].Value ?? "";

                    if (WCodigo.ToString().Trim() != "")
                    {
                        if (txtCodigo.Text.Trim() == WCodigo.ToString().Trim())
                        {
                            dgvTemas_CellMouseDoubleClick(null, new DataGridViewCellMouseEventArgs(0, row.Index, 0,0, new MouseEventArgs(MouseButtons.None, 0, 0 ,0,0)));
                            txtCodigo.Text = "";
                            return;
                        }
                    }
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBFiltro.Text = "";
            TBFiltro.Focus();
            TBFiltro_KeyUp(null, null);
        }

    }
}
