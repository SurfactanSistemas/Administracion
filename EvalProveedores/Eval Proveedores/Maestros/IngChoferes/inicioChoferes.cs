using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            DataTable dtChoferes = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT Codigo, Descripcion As Nombre, CargasPeligrosas = CASE WHEN c.AplicaIII = '1' THEN 'Si' ELSE 'No' END, p.Nombre As DescProveedor, " +
                                        " FechaVtoI As FechaVtoLicConducir, FechaEntregaI As FechaEntLicConducir, LTRIM(RTRIM(ComentarioI)) ComentarioI," +
                                        " FechaVtoII As FechaVtoArt, FechaEntregaII As FechaEntArt, LTRIM(RTRIM(ComentarioII)) ComentarioII," +
                                        " FechaVtoIII As FechaVtoCargasPeligrosas, FechaEntregaIII As FechaEntCargasPeligrosas, LTRIM(RTRIM(ComentarioIII)) ComentarioIII," +
                                        " c.Proveedor" +
                                        " FROM chofer c LEFT OUTER JOIN Proveedor p ON p.Proveedor = c.Proveedor ORDER BY c.Codigo ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtChoferes.Load(dataReader);

                }
            }

            DGV_Choferes.DataSource = dtChoferes;
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
                
                AgModifChofer ModifChofer = new AgModifChofer(Codigo);
                //AgModifChofer ModifChofer = new AgModifChofer(Codigo, Desc, Aplica, Proveedor, CodEmp, FechaVenc1, FechaVenc2, FechaVenc3, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, FechaEnt1, FechaEnt2, FechaEnt3, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, Coment1, Coment2, Coment3, NomProve);
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

                if (MessageBox.Show("¿Está Seguro de querer eliminar el Chofer seleccionado?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                CBOL.Eliminar(int.Parse(DGV_Choferes.SelectedRows[0].Cells["Codigo"].Value.ToString()));

                MessageBox.Show("El chofer se eliminó con exito", "Eliminacion chofer",
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
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Aplica");
                dt.Columns.Add("Proveedor");
                dt.Columns.Add("FechaVtoLic");
                dt.Columns.Add("FechaVtoArt");
                dt.Columns.Add("FechaVtoCargaPel");
                dt.Columns.Add("NombProve");

                foreach (DataGridViewRow row in DGV_Choferes.SelectedRows)
                {
                    DataRow r = dt.NewRow();

                    r["Codigo"] = row.Cells["Codigo"].Value ?? "";
                    r["Descripcion"] = row.Cells["DescChofer"].Value ?? "";
                    r["Aplica"] = row.Cells["CargasPeligrosas"].Value ?? "";
                    r["Proveedor"] = row.Cells["Proveedor"].Value ?? "";
                    r["FechaVtoLic"] = row.Cells["FechaVtoLicConducir"].Value ?? "";
                    r["FechaVtoArt"] = row.Cells["FechaVtoArt"].Value ?? "";
                    r["FechaVtoCargaPel"] = row.Cells["FechaVtoCargasPeligrosas"].Value ?? "";
                    r["NombProve"] = row.Cells["DescProveedor"].Value ?? "";

                    dt.Rows.Add(r);
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

                string Codigo = DGV_Choferes.SelectedRows[0].Cells["Codigo"].Value.ToString();
                
                //AgModifChofer ModifChofer = new AgModifChofer(Codigo, Desc, Aplica, Proveedor, CodEmp, FechaVenc1, FechaVenc2, FechaVenc3, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, FechaEnt1, FechaEnt2, FechaEnt3, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, Coment1, Coment2, Coment3, NomProve);
                AgModifChofer ModifChofer = new AgModifChofer(Codigo);
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
