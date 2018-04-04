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
            Close();
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Perfiles.SelectedRows.Count != 1) throw new Exception("No hay filas seleccionadas o se selecciono mas de una");
                string IdAEliminar = DGV_Perfiles.SelectedRows[0].Cells[0].Value.ToString();

                if (MessageBox.Show("¿Está seguro de querer eliminar el perfil seleccionado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    P.Eliminar(IdAEliminar);
                }

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


        private void TBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltro.Text != "")
            {
                DataTable dataTable = DGV_Perfiles.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) like '%{0}%' "
                                                    + " OR CONVERT(Perfil, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Sector, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Vigencia, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Version, System.String) like '%{0}%'"
                                                    + " OR CONVERT(Descripcion, System.String) like '%{0}%'", TBFiltro.Text);
            }
            else
            {
                ActualizarGrilla();
            }
        }

        private void DGV_Perfiles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifSector.PerformClick();
        }

        private void Periles_Inicio_Shown(object sender, EventArgs e)
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
            ReportDocument reporte = new ListadoPerfiles();

            VistaPrevia rp = new VistaPrevia();
            rp.CargarReporte(reporte);
            rp.ShowDialog();
        }
        
    }
}
