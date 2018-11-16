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
            //DGV_Camiones.Focus();
            txtCodigo.Focus();
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

                string _Codigo = DGV_Camiones.SelectedRows[0].Cells[0].Value.ToString();

                //AgModCamiones ModifCamion = new AgModCamiones(Codigo, Desc, Patent, NomProve, NomChof, Estado, CodEmp, Aplica, CodChof, CodProveedor, FechaVenc1, FechaVenc2, FechaVenc3, FechaVenc4, FechaVenc5, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, OrdFecVenc4, OrdFecVenc5, FechaEnt1, FechaEnt2, FechaEnt3, FechaEnt4, FechaEnt5, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, OrdFecEnt4, OrdFecEnt5, Coment1, Coment2, Coment3, Coment4, Coment5, Titulo);
                AgModCamiones ModifCamion = new AgModCamiones(_Codigo);
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

                if (
                    MessageBox.Show("¿Está seguro de querer eliminar el camión seleccionado?", "",
                        MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                CABOL.Eliminar(int.Parse(DGV_Camiones.SelectedRows[0].Cells["Codigo"].Value.ToString()));

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

                dt.Columns.Add("Codigo");
                dt.Columns.Add("Desc");
                dt.Columns.Add("Patente");
                dt.Columns.Add("Estado");
                dt.Columns.Add("Nomb Prove");
                dt.Columns.Add("Nomb Chofer");
                dt.Columns.Add("Vto Ruta");
                dt.Columns.Add("Vto RTO");
                dt.Columns.Add("Vto Hab Dom");
                dt.Columns.Add("Vto Seguro");
                dt.Columns.Add("Vto. Cert. Carg. Pel");

                foreach (DataGridViewRow row in DGV_Camiones.SelectedRows)
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            var WCodigo = row.Cells["Codigo"].Value ?? "";

                            if (WCodigo.ToString() == "") continue;

                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT Ca.*, P.Nombre As DescProveedor, Ch.Descripcion As DescChofer FROM Camion Ca LEFT OUTER JOIN Proveedor P ON P.Proveedor = Ca.Proveedor LEFT OUTER JOIN Chofer Ch ON Ch.Codigo = Ca.Chofer WHERE Ca.Codigo = '" + WCodigo + "'";

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();

                                    DataRow r = dt.NewRow();

                                    r["Codigo"] = dr["Codigo"] == null ? "" : dr["Codigo"].ToString();
                                    r["Desc"] = dr["Descripcion"] == null ? "" : dr["Descripcion"].ToString();
                                    r["Patente"] = dr["Patente"] == null ? "" : dr["Patente"].ToString();
                                    r["Estado"] = dr["Estado"] == null ? "0" : dr["Estado"].ToString();
                                    r["Nomb Prove"] = dr["DescProveedor"] == null ? "" : dr["DescProveedor"].ToString();
                                    r["Nomb Chofer"] = dr["DescChofer"] == null ? "" : dr["DescChofer"].ToString();
                                    r["Vto Ruta"] = dr["FechaVtoI"] == null ? "" : dr["FechaVtoI"].ToString();
                                    r["Vto RTO"] = dr["FechaVtoII"] == null ? "" : dr["FechaVtoII"].ToString();
                                    r["Vto Hab Dom"] = dr["FechaVtoIII"] == null ? "" : dr["FechaVtoIII"].ToString();
                                    r["Vto Seguro"] = dr["FechaVtoIV"] == null ? "" : dr["FechaVtoIV"].ToString();
                                    r["Vto. Cert. Carg. Pel"] = dr["FechaVtoV"] == null ? "" : dr["FechaVtoV"].ToString();

                                    dt.Rows.Add(r);
                                }
                            }
                        }

                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    row["Estado"] = int.Parse(row["Estado"].ToString()) == 0 ? "Habilitado" : "Inhabilitado";
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

                string _Codigo = DGV_Camiones.SelectedRows[0].Cells[0].Value.ToString();
                
                //AgModCamiones ModifCamion = new AgModCamiones(Codigo, Desc, Patent, NomProve, NomChof, Estado, CodEmp, Aplica, CodChof, CodProveedor, FechaVenc1, FechaVenc2, FechaVenc3, FechaVenc4, FechaVenc5, OrdFecVenc1, OrdFecVenc2, OrdFecVenc3, OrdFecVenc4, OrdFecVenc5, FechaEnt1, FechaEnt2, FechaEnt3, FechaEnt4, FechaEnt5, OrdFecEnt1, OrdFecEnt2, OrdFecEnt3, OrdFecEnt4, OrdFecEnt5, Coment1, Coment2, Coment3, Coment4, Coment5, Titulo);
                AgModCamiones ModifCamion = new AgModCamiones(_Codigo);
                ModifCamion.ShowDialog();
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

                foreach (DataGridViewRow row in DGV_Camiones.Rows)
                {
                    var WCodigo = row.Cells["Codigo"].Value ?? "";

                    if (WCodigo.ToString() != "")
                    {
                        if (txtCodigo.Text.Trim() == WCodigo.ToString().Trim())
                        {
                            row.Selected = true;
                            DGV_Camiones_RowHeaderMouseDoubleClick(null,
                                new DataGridViewCellMouseEventArgs(0, 0, 0, 0, new MouseEventArgs( MouseButtons.Left, 0, 0, 0, 0))
                            );
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
