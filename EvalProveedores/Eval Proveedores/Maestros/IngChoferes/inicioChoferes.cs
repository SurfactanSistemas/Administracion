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

namespace Eval_Proveedores.IngChoferes
{
    public partial class inicioChoferes : Form
    {
        ChoferBOL CBOL = new ChoferBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        Proveedor P = new Proveedor();
        List<Chofer> Choferes = new List<Chofer>();
        Chofer C = new Chofer();
        string columna = "";


        public inicioChoferes()
        {
            InitializeComponent();
            
           
        }

        private void inicioChoferes_Load(object sender, EventArgs e)
        {
            P_Filtrado.Visible = false;
            TraerLista();
            //DGV_Choferes.Focus();
            txtCodigo.Focus();
        }

        private void TraerLista()
        {
            DataTable dtChofer = CBOL.Lista();
            DataTable dtProve = PBOL.Lista();
            dtChofer.Columns.Add("NombProve", typeof(string));
            dtChofer.Columns.Add("DescAplica", typeof(string));
            foreach (DataRow fila in dtChofer.Rows)
            {
                foreach (DataRow filaPro in dtProve.Rows)
                {
                    if (fila[19].ToString() == filaPro[0].ToString())
                    {
                        fila["NombProve"] = filaPro[1].ToString();
                    }
                }

                if (fila[3].ToString() == "1")
                {
                    fila["DescAplica"] = "SI";
                }
                else
                {
                    fila["DescAplica"] = "NO";
                }

                
                
            }


            DGV_Choferes.DataSource = dtChofer;
        }

        private void BTAgregarChofer_Click(object sender, EventArgs e)
        {
            AgModifChofer AgregarChofer = new AgModifChofer();
            AgregarChofer.ShowDialog();
            TraerLista();
        }

        private void BTModifChofer_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Choferes.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ningun chofer");

                if (DGV_Choferes.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de un chofer");

                string Codigo = DGV_Choferes.SelectedRows[0].Cells[0].Value.ToString();
                string Desc = DGV_Choferes.SelectedRows[0].Cells[1].Value.ToString();
                string Aplica = DGV_Choferes.SelectedRows[0].Cells[2].Value.ToString();
                string Proveedor = DGV_Choferes.SelectedRows[0].Cells[4].Value.ToString();
                string NomProve = DGV_Choferes.SelectedRows[0].Cells[5].Value.ToString();
                string CodEmp = DGV_Choferes.SelectedRows[0].Cells[6].Value.ToString();
                string FechaVenc1 = DGV_Choferes.SelectedRows[0].Cells[7].Value.ToString();
                string Coment1 = DGV_Choferes.SelectedRows[0].Cells[8].Value.ToString();
                string FechaVenc2 = DGV_Choferes.SelectedRows[0].Cells[9].Value.ToString();
                string Coment2 = DGV_Choferes.SelectedRows[0].Cells[10].Value.ToString();
                string FechaVenc3 = DGV_Choferes.SelectedRows[0].Cells[11].Value.ToString();
                string OrdFecVenc1 = DGV_Choferes.SelectedRows[0].Cells[12].Value.ToString();
                string OrdFecVenc2 = DGV_Choferes.SelectedRows[0].Cells[13].Value.ToString();
                string OrdFecVenc3 = DGV_Choferes.SelectedRows[0].Cells[14].Value.ToString();
                string FechaEnt1 = DGV_Choferes.SelectedRows[0].Cells[15].Value.ToString();
                string FechaEnt2 = DGV_Choferes.SelectedRows[0].Cells[16].Value.ToString();
                string FechaEnt3 = DGV_Choferes.SelectedRows[0].Cells[17].Value.ToString();
                string OrdFecEnt1 = DGV_Choferes.SelectedRows[0].Cells[18].Value.ToString();
                string OrdFecEnt2 = DGV_Choferes.SelectedRows[0].Cells[19].Value.ToString();
                string OrdFecEnt3 = DGV_Choferes.SelectedRows[0].Cells[20].Value.ToString();
                string Coment3 = DGV_Choferes.SelectedRows[0].Cells[21].Value.ToString();
                
                
                

                AgModifChofer ModifChofer = new AgModifChofer(Codigo, Desc, Aplica, Proveedor, CodEmp, FechaVenc1, FechaVenc2, FechaVenc3, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, FechaEnt1, FechaEnt2, FechaEnt3, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, Coment1, Coment2, Coment3, NomProve);
                ModifChofer.ShowDialog();
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
                if (DGV_Choferes.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ningun chofer");

                if (DGV_Choferes.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de un chofer");

                CBOL.Eliminar(int.Parse(DGV_Choferes.SelectedRows[0].Cells[0].Value.ToString()));

                MessageBox.Show("El chofer se elimino con exito", "Eliminacion chofer",
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
                 if (DGV_Choferes.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ninguna linea");

                 DataTable dt = new DataTable();
                 foreach (DataGridViewColumn column in DGV_Choferes.Columns)
                     dt.Columns.Add(column.Name, typeof(string));
                 for (int i = 0; i < DGV_Choferes.SelectedRows.Count; i++)
                 {
                     dt.Rows.Add();
                     for (int j = 0; j < DGV_Choferes.Columns.Count; j++)
                     {
                         dt.Rows[i][j] = DGV_Choferes.SelectedRows[i].Cells[j].Value;
                     }
                 }

                 Maestros.IngChoferes.ImpreChofer Impresion = new Maestros.IngChoferes.ImpreChofer(dt);
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
            LBFiltro.Text = "Codigo Chofer";
            TBFiltro.Visible = true;
        }

        

        private void nombreProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "NombProve";
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Nombre Proveedor";
            TBFiltro.Visible = true;
        }

        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Descripcion";
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Nombre";
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
                (DGV_Choferes.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + columna + ", System.String) like '%{0}%'", TBFiltro.Text);
                BT_Filtrar.Text = "Limp. Filtro";
            }
            else
            {
                (DGV_Choferes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

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

        private void DGV_Choferes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DGV_Choferes.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ningun chofer");

                if (DGV_Choferes.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de un chofer");

                string Codigo = DGV_Choferes.SelectedRows[0].Cells[0].Value.ToString();
                string Desc = DGV_Choferes.SelectedRows[0].Cells[1].Value.ToString();
                string Aplica = DGV_Choferes.SelectedRows[0].Cells[2].Value.ToString();
                string Proveedor = DGV_Choferes.SelectedRows[0].Cells[4].Value.ToString();
                string NomProve = DGV_Choferes.SelectedRows[0].Cells[5].Value.ToString();
                string CodEmp = DGV_Choferes.SelectedRows[0].Cells[6].Value.ToString();
                string FechaVenc1 = DGV_Choferes.SelectedRows[0].Cells[7].Value.ToString();
                string Coment1 = DGV_Choferes.SelectedRows[0].Cells[8].Value.ToString();
                string FechaVenc2 = DGV_Choferes.SelectedRows[0].Cells[9].Value.ToString();
                string Coment2 = DGV_Choferes.SelectedRows[0].Cells[10].Value.ToString();
                string FechaVenc3 = DGV_Choferes.SelectedRows[0].Cells[11].Value.ToString();
                string OrdFecVenc1 = DGV_Choferes.SelectedRows[0].Cells[12].Value.ToString();
                string OrdFecVenc2 = DGV_Choferes.SelectedRows[0].Cells[13].Value.ToString();
                string OrdFecVenc3 = DGV_Choferes.SelectedRows[0].Cells[14].Value.ToString();
                string FechaEnt1 = DGV_Choferes.SelectedRows[0].Cells[15].Value.ToString();
                string FechaEnt2 = DGV_Choferes.SelectedRows[0].Cells[16].Value.ToString();
                string FechaEnt3 = DGV_Choferes.SelectedRows[0].Cells[17].Value.ToString();
                string OrdFecEnt1 = DGV_Choferes.SelectedRows[0].Cells[18].Value.ToString();
                string OrdFecEnt2 = DGV_Choferes.SelectedRows[0].Cells[19].Value.ToString();
                string OrdFecEnt3 = DGV_Choferes.SelectedRows[0].Cells[20].Value.ToString();
                string Coment3 = DGV_Choferes.SelectedRows[0].Cells[21].Value.ToString();
                

                AgModifChofer ModifChofer = new AgModifChofer(Codigo, Desc, Aplica, Proveedor, CodEmp, FechaVenc1, FechaVenc2, FechaVenc3, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, FechaEnt1, FechaEnt2, FechaEnt3, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, Coment1, Coment2, Coment3, NomProve);
                ModifChofer.ShowDialog();
                TraerLista();
                P_Filtrado.Visible = false;

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                foreach (DataGridViewRow row in DGV_Choferes.Rows)
                {
                    var WCodigo = row.Cells["Codigo"].Value ?? "";

                    if (WCodigo.ToString().Trim() != "")
                    {
                        if (txtCodigo.Text.Trim() == WCodigo.ToString().Trim())
                        {
                            row.Selected = true;
                            DGV_Choferes_RowHeaderMouseDoubleClick(null, null);
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

    }
}
