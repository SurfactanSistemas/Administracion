using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Logica_Negocio;

namespace Eval_Proveedores.IngCamiones
{
    public partial class InicioCamiones : Form
    {
        CamionBOL CABOL = new CamionBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        ChoferBOL CBOL = new ChoferBOL();
        Proveedor P = new Proveedor();
        List<Camion> Camiones = new List<Camion>();
        Camion Ca = new Camion();
        Chofer C = new Chofer();
        string columna = "";


        public InicioCamiones()
        {
            InitializeComponent();
        }

        

        private void InicioCamiones_Load(object sender, EventArgs e)
        {
            P_Filtrado.Visible = false;
            TraerLista();
            DGV_Camiones.Focus();
        }

        private void TraerLista()
        {
            DataTable dtCamion = CABOL.Lista();
            DataTable dtProve = PBOL.Lista();
            DataTable dtChofer = CBOL.Lista();
            dtCamion.Columns.Add("NombProve", typeof(string));
            dtCamion.Columns.Add("NombChof", typeof(string));
            dtCamion.Columns.Add("DescEstado", typeof(string));


            foreach (DataRow filaCa in dtCamion.Rows)
            {
                foreach (DataRow filaPro in dtProve.Rows)
                {
                    if (filaCa[30].ToString() == filaPro[0].ToString())
                    {
                        filaCa["NombProve"] = filaPro[1].ToString();
                    }
                }

                if (int.Parse(filaCa[34].ToString()) != 0)
                {
                    foreach (DataRow filaCho in dtChofer.Rows)
                    {
                        if (filaCa[34].ToString() == filaCho[0].ToString())
                        {
                            filaCa["NombChof"] = filaCho[1].ToString();
                        }
                    }
                }
                
               
                
                if (int.Parse(filaCa[31].ToString()) == 0)
                {
                    filaCa["DescEstado"] = "Habilitado";
                }
                else
                {
                    filaCa["DescEstado"] = "Inhabilitado";
                }
                
                
            }

            DGV_Camiones.DataSource = dtCamion;
        }

        private void BTAgregarCamion_Click(object sender, EventArgs e)
        {
            AgModCamiones AgregarCamion = new AgModCamiones();
            AgregarCamion.ShowDialog();
            TraerLista();
        }

        private void BTModifChofer_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Camiones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ningún Camión");

                if (DGV_Camiones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de un Camión");

                string Codigo = DGV_Camiones.SelectedRows[0].Cells[0].Value.ToString();
                string Desc = DGV_Camiones.SelectedRows[0].Cells[1].Value.ToString();
                string Patent = DGV_Camiones.SelectedRows[0].Cells[2].Value.ToString();
                string NomProve = DGV_Camiones.SelectedRows[0].Cells[4].Value.ToString();
                string NomChof = DGV_Camiones.SelectedRows[0].Cells[5].Value.ToString();
                string Estado = DGV_Camiones.SelectedRows[0].Cells[6].Value.ToString();
                string CodEmp = DGV_Camiones.SelectedRows[0].Cells[7].Value.ToString();
                string Aplica = DGV_Camiones.SelectedRows[0].Cells[8].Value.ToString();
                string CodChof = DGV_Camiones.SelectedRows[0].Cells[9].Value.ToString();
                string CodProveedor = DGV_Camiones.SelectedRows[0].Cells[10].Value.ToString();
                string FechaVenc1 = DGV_Camiones.SelectedRows[0].Cells[11].Value.ToString();
                string Coment1 = DGV_Camiones.SelectedRows[0].Cells[12].Value.ToString();
                string FechaVenc2 = DGV_Camiones.SelectedRows[0].Cells[13].Value.ToString();
                string Coment2 = DGV_Camiones.SelectedRows[0].Cells[14].Value.ToString();

                string FechaVenc3 = DGV_Camiones.SelectedRows[0].Cells[15].Value.ToString();
                string Coment3 = DGV_Camiones.SelectedRows[0].Cells[16].Value.ToString();
                string FechaVenc4 = DGV_Camiones.SelectedRows[0].Cells[17].Value.ToString();
                string Coment4 = DGV_Camiones.SelectedRows[0].Cells[18].Value.ToString();

                string FechaVenc5 = DGV_Camiones.SelectedRows[0].Cells[19].Value.ToString();
                string Coment5 = DGV_Camiones.SelectedRows[0].Cells[20].Value.ToString();

                string OrdFecVenc1 = DGV_Camiones.SelectedRows[0].Cells[21].Value.ToString();
                string OrdFecVenc2 = DGV_Camiones.SelectedRows[0].Cells[22].Value.ToString();
                string OrdFecVenc3 = DGV_Camiones.SelectedRows[0].Cells[23].Value.ToString();
                string OrdFecVenc4 = DGV_Camiones.SelectedRows[0].Cells[24].Value.ToString();
                string OrdFecVenc5 = DGV_Camiones.SelectedRows[0].Cells[25].Value.ToString();
                string FechaEnt1 = DGV_Camiones.SelectedRows[0].Cells[26].Value.ToString();
                string FechaEnt2 = DGV_Camiones.SelectedRows[0].Cells[27].Value.ToString();
                string FechaEnt3 = DGV_Camiones.SelectedRows[0].Cells[28].Value.ToString();
                string FechaEnt4 = DGV_Camiones.SelectedRows[0].Cells[29].Value.ToString();
                string FechaEnt5 = DGV_Camiones.SelectedRows[0].Cells[30].Value.ToString();
                string OrdFecEnt1 = DGV_Camiones.SelectedRows[0].Cells[31].Value.ToString();
                string OrdFecEnt2 = DGV_Camiones.SelectedRows[0].Cells[32].Value.ToString();
                string OrdFecEnt3 = DGV_Camiones.SelectedRows[0].Cells[33].Value.ToString();
                string OrdFecEnt4 = DGV_Camiones.SelectedRows[0].Cells[34].Value.ToString();
                string OrdFecEnt5 = DGV_Camiones.SelectedRows[0].Cells[35].Value.ToString();
                
                
                
                
                
                string Titulo = DGV_Camiones.SelectedRows[0].Cells[36].Value.ToString();

                AgModCamiones ModifCamion = new AgModCamiones(Codigo, Desc, Patent, NomProve, NomChof, Estado, CodEmp, Aplica, CodChof, CodProveedor, FechaVenc1, FechaVenc2, FechaVenc3, FechaVenc4, FechaVenc5, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, OrdFecVenc4, OrdFecVenc5, FechaEnt1, FechaEnt2, FechaEnt3, FechaEnt4, FechaEnt5, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, OrdFecEnt4, OrdFecEnt5, Coment1, Coment2, Coment3, Coment4, Coment5, Titulo);
                ModifCamion.ShowDialog();
                TraerLista();
                P_Filtrado.Visible = false;




            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Camiones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ningún Camión");

                if (DGV_Camiones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de un Camión");


                CABOL.Eliminar(int.Parse(DGV_Camiones.SelectedRows[0].Cells[0].Value.ToString()));

                MessageBox.Show("El camión se eliminó con éxito", "Eliminación camión",
                MessageBoxButtons.OK, MessageBoxIcon.None);

                TraerLista();
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Camiones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ninguna linea");
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in DGV_Camiones.Columns)
                    dt.Columns.Add(column.Name, typeof(string));
                for (int i = 0; i < DGV_Camiones.SelectedRows.Count; i++)
                {
                    dt.Rows.Add();
                    for (int j = 0; j < DGV_Camiones.Columns.Count; j++)
                    {
                        dt.Rows[i][j] = DGV_Camiones.SelectedRows[i].Cells[j].Value;
                    }
                }

                Maestros.IngCamiones.ImpreCamion Impresion = new Maestros.IngCamiones.ImpreCamion(dt);
                Impresion.ShowDialog();

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Filtrado
        private void BT_MenuFiltros_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Filtros.Show(ptLowerLeft);

            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltro.Text = "";
        }

        private void codigoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Codigo";
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Codigo Camion";
            TBFiltro.Visible = true;
        }

        

        private void nombreProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "NombProve";
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Nombre Proveedor";
            TBFiltro.Visible = true;
        }

        private void patenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Patente";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void HabilitarPanelFiltrado()
        {
            P_Filtrado.Visible = true;
            TBFiltro.Focus();
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            if (BT_Filtrar.Text == "Filtrar")
            {
                (DGV_Camiones.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + columna + ", System.String) like '%{0}%'", TBFiltro.Text);
                BT_Filtrar.Text = "Limp. Filtro";
            }
            else
            {
                (DGV_Camiones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

                P_Filtrado.Visible = false;
                TBFiltro.Text = "";
                BT_Filtrar.Visible = true;
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
        #endregion

        private void DGV_Camiones_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DGV_Camiones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ningún Camión");

                if (DGV_Camiones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de un Camión");

                string Codigo = DGV_Camiones.SelectedRows[0].Cells[0].Value.ToString();
                string Desc = DGV_Camiones.SelectedRows[0].Cells[1].Value.ToString();
                string Patent = DGV_Camiones.SelectedRows[0].Cells[2].Value.ToString();
                string NomProve = DGV_Camiones.SelectedRows[0].Cells[4].Value.ToString();
                string NomChof = DGV_Camiones.SelectedRows[0].Cells[5].Value.ToString();
                string Estado = DGV_Camiones.SelectedRows[0].Cells[6].Value.ToString();
                string CodEmp = DGV_Camiones.SelectedRows[0].Cells[7].Value.ToString();
                string Aplica = DGV_Camiones.SelectedRows[0].Cells[8].Value.ToString();
                string CodChof = DGV_Camiones.SelectedRows[0].Cells[9].Value.ToString();
                string CodProveedor = DGV_Camiones.SelectedRows[0].Cells[10].Value.ToString();
                string FechaVenc1 = DGV_Camiones.SelectedRows[0].Cells[11].Value.ToString();
                string Coment1 = DGV_Camiones.SelectedRows[0].Cells[12].Value.ToString();
                string FechaVenc2 = DGV_Camiones.SelectedRows[0].Cells[13].Value.ToString();
                string Coment2 = DGV_Camiones.SelectedRows[0].Cells[14].Value.ToString();

                string FechaVenc3 = DGV_Camiones.SelectedRows[0].Cells[15].Value.ToString();
                string Coment3 = DGV_Camiones.SelectedRows[0].Cells[16].Value.ToString();
                string FechaVenc4 = DGV_Camiones.SelectedRows[0].Cells[17].Value.ToString();
                string Coment4 = DGV_Camiones.SelectedRows[0].Cells[18].Value.ToString();

                string FechaVenc5 = DGV_Camiones.SelectedRows[0].Cells[19].Value.ToString();
                string Coment5 = DGV_Camiones.SelectedRows[0].Cells[20].Value.ToString();

                string OrdFecVenc1 = DGV_Camiones.SelectedRows[0].Cells[21].Value.ToString();
                string OrdFecVenc2 = DGV_Camiones.SelectedRows[0].Cells[22].Value.ToString();
                string OrdFecVenc3 = DGV_Camiones.SelectedRows[0].Cells[23].Value.ToString();
                string OrdFecVenc4 = DGV_Camiones.SelectedRows[0].Cells[24].Value.ToString();
                string OrdFecVenc5 = DGV_Camiones.SelectedRows[0].Cells[25].Value.ToString();
                string FechaEnt1 = DGV_Camiones.SelectedRows[0].Cells[26].Value.ToString();
                string FechaEnt2 = DGV_Camiones.SelectedRows[0].Cells[27].Value.ToString();
                string FechaEnt3 = DGV_Camiones.SelectedRows[0].Cells[28].Value.ToString();
                string FechaEnt4 = DGV_Camiones.SelectedRows[0].Cells[29].Value.ToString();
                string FechaEnt5 = DGV_Camiones.SelectedRows[0].Cells[30].Value.ToString();
                string OrdFecEnt1 = DGV_Camiones.SelectedRows[0].Cells[31].Value.ToString();
                string OrdFecEnt2 = DGV_Camiones.SelectedRows[0].Cells[32].Value.ToString();
                string OrdFecEnt3 = DGV_Camiones.SelectedRows[0].Cells[33].Value.ToString();
                string OrdFecEnt4 = DGV_Camiones.SelectedRows[0].Cells[34].Value.ToString();
                string OrdFecEnt5 = DGV_Camiones.SelectedRows[0].Cells[35].Value.ToString();





                string Titulo = DGV_Camiones.SelectedRows[0].Cells[36].Value.ToString();

                AgModCamiones ModifCamion = new AgModCamiones(Codigo, Desc, Patent, NomProve, NomChof, Estado, CodEmp, Aplica, CodChof, CodProveedor, FechaVenc1, FechaVenc2, FechaVenc3, FechaVenc4, FechaVenc5, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, OrdFecVenc4, OrdFecVenc5, FechaEnt1, FechaEnt2, FechaEnt3, FechaEnt4, FechaEnt5, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, OrdFecEnt4, OrdFecEnt5, Coment1, Coment2, Coment3, Coment4, Coment5, Titulo);
                ModifCamion.ShowDialog();
                TraerLista();
                P_Filtrado.Visible = false;




            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
