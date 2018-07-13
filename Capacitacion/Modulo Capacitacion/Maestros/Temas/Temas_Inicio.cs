using System;
using System.Data;
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
            DGV_Temas.DataSource = temas.ListarTodosPrincipal();
        }


        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Temas.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Temas.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageBox.Show("¿Está seguro de querer ELIMINAR el Tema seleccionado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    temas.Eliminar(IdAEliminar);
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
            TBFiltro.Text = "";
            DGV_Temas.DataSource = temas.ListarTodos();
        }

        private void BTAgregarTema_Click(object sender, EventArgs e)
        {
            int UltimoId = temas.ObtenerUltimoId();
            AgModTema agregarTema = new AgModTema(UltimoId)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
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

                AgModTema modificarTema = new AgModTema(TemaAModificar)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                modificarTema.ShowDialog();

                ActualizarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void TBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dataTable = DGV_Temas.DataSource as DataTable;
            if (dataTable != null)
                dataTable.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) like '%{0}%' "
                                                + " OR CONVERT(Descripcion, System.String) like '%{0}%'"
                                                + " OR CONVERT(TemaI, System.String) like '%{0}%'"
                                                + " OR CONVERT(Responsable, System.String) like '%{0}%'", TBFiltro.Text);
            
        }

        private void DGV_Temas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifTema.PerformClick();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Listados.Temas.Inicio frm = new Listados.Temas.Inicio();
            frm.ShowDialog();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                foreach (DataGridViewRow row in DGV_Temas.Rows)
                {
                    var WCodigo = row.Cells["Codigo"].Value ?? "";

                    if (WCodigo.ToString().Trim() != "")
                    {
                        if (txtCodigo.Text.Trim() == WCodigo.ToString().Trim())
                        {
                            row.Selected = true;
                            DGV_Temas_RowHeaderMouseDoubleClick(null, null);
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

        private void Temas_Inicio_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void Temas_Inicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBFiltro.Text = "";
            TBFiltro.Focus();
            TBFiltro_KeyUp(null, null);
        }

    }
}
