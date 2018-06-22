using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HojaRuta.Novedades
{
    public partial class HojaRuta : Form
    {
        public HojaRuta()
        {
            InitializeComponent();
        }

        private void SoloNumerosEnteros(object sender, KeyPressEventArgs e)
        {
            Helper.SoloNumerosEnteros(sender, ref e);
        }

        private void SoloNumerosDecimales(object sender, KeyPressEventArgs e)
        {
            Helper.SoloDecimales(sender, ref e);
        }

        private void txtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtFecha.Text.Replace("/", "").Trim() == "") return;

                if (Helper._ValidarFecha(txtFecha.Text)) cmbTipoPedido.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtFecha.Text = "";
            }
	        
        }

        private void HojaRuta_Shown(object sender, EventArgs e)
        {
            txtNroHoja.Focus();
        }

        private void txtNroHoja_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtNroHoja.Text.Trim() == "") txtNroHoja.Text = "0";

                // En caso de ser != 0, cargar la Hoja de Ruta.

                if (txtNroHoja.Text.Trim() != "0")
                {
                    _TraerHojaRuta(txtNroHoja.Text);
                }

                txtFecha.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtNroHoja.Text = "";
            }
	        
        }

        private void _TraerHojaRuta(string WHojaRuta)
        {
            try
            {
                btnLimpiar.PerformClick();
                dgvPedidos.Rows.Clear();
                double WKilosTotales = 0;

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM HojaRuta WHERE Hoja = '" + WHojaRuta + "' ORDER BY Renglon";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.HasRows) return;

                            while (dr.Read())
                            {
                                txtNroHoja.Text = WHojaRuta;
                                txtFecha.Text = dr["Fecha"].ToString();
                                txtKilos.Text = dr["Kilos"].ToString();
                                txtChofer.Text = dr["Chofer"].ToString();
                                txtCamion.Text = dr["Camion"].ToString();
                                txtNroViaje.Text = dr["NroViaje"].ToString();
                                txtRetiraProv.Text = dr["RetiraProv"].ToString();
                                cmbEstado.SelectedIndex = int.Parse(dr["TipoEstado"].ToString());
                                int WIndice = dgvPedidos.Rows.Add();

                                DataGridViewRow r = dgvPedidos.Rows[WIndice];
                                r.Cells["Pedido"].Value = dr["Pedido"].ToString();
                                r.Cells["Cliente"].Value = dr["Cliente"].ToString();
                                r.Cells["Razon"].Value = _TraerRazonSocial(r.Cells["Cliente"].Value);
                                r.Cells["Remito"].Value = dr["Remito"].ToString();
                                r.Cells["Segur"].Value = dr["Seguridad"].ToString();
                                r.Cells["Kilos"].Value = dr["Kilos"].ToString();
                            }

                            foreach (DataGridViewRow row in dgvPedidos.Rows)
                            {
                                var WValor = row.Cells["Kilos"].Value ?? "0";
                                WKilosTotales += double.Parse(WValor.ToString());
                                row.Cells["Kilos"].Value = Helper.FormatoNumerico(WValor.ToString());
                            }

                            txtDesCamion.Text = _TraerCamion(txtCamion.Text);
                            txtDesChofer.Text = _TraerChofer(txtChofer.Text);
                            txtKilos.Text = Helper.FormatoNumerico(WKilosTotales.ToString());
                            dgvPedidos.Rows.Add();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private string _TraerRazonSocial(object WCliente)
        {
            string WDesc = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(Razon, '') Razon FROM Cliente WHERE CLiente = '" + WCliente + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WDesc = dr["Razon"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return WDesc.Trim();
        }

        private void txtKilos_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtKilos.Text.Trim() == "") return;

                txtKilos.Text = Helper.FormatoNumerico(txtKilos.Text);

                txtChofer.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtKilos.Text = "";
            }
	        
        }

        private void txtChofer_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtChofer.Text.Trim() == "") return;

                try
                {
                    txtDesChofer.Text = _TraerChofer(txtChofer.Text);

                    txtCamion.Focus();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtChofer.Text = "";
                txtDesChofer.Text = "";
            }
	        
        }

        private string _TraerChofer(string WChofer)
        {
            try
            {
                string WDesc = "";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(Descripcion, '') Descripcion FROM Chofer WHERE Codigo = '" + WChofer + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WDesc = dr["Descripcion"].ToString();
                            }
                        }
                    }

                }

                return WDesc.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el Chofer desde la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void txtCamion_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCamion.Text.Trim() == "") return;

                try
                {
                    txtDesCamion.Text = _TraerCamion(txtCamion.Text);

                    txtNroViaje.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCamion.Text = "";
                txtDesCamion.Text = "";
            }
	        
        }

        private string _TraerCamion(string WCamion)
        {
            string WDesc = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(Descripcion, '') Descripcion FROM Camion WHERE COdigo = '" + WCamion + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WDesc = dr["Descripcion"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el Camión desde la Base de Datos. Motivo: " + ex.Message);
            }

            return WDesc.Trim();

        }

        private void txtHoraViaje_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtHoraViaje.Text.Trim() == "") return;

                txtHoraViaje.Text = Helper.FormatoNumerico(txtHoraViaje.Text);

                if (dgvPedidos.Rows.Count == 0) dgvPedidos.Rows.Add();

                dgvPedidos.CurrentCell = dgvPedidos.Rows[0].Cells["Pedido"];
                dgvPedidos.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtHoraViaje.Text = "";
            }
	        
        }

        private void cmbTipoPedido_Enter(object sender, EventArgs e)
        {
            if (cmbTipoPedido.SelectedIndex < 0) cmbTipoPedido.SelectedIndex = 0;
        }

        private void cmbTipoPedido_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (cmbTipoPedido.SelectedIndex < 0) return;

                cmbEstado.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                cmbTipoPedido.SelectedIndex = 0;
            }
	        
        }

        private void cmbEstado_Enter(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedIndex < 0) cmbEstado.SelectedIndex = 0;
        }

        private void cmbEstado_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                if (cmbEstado.SelectedIndex < 0) return;

                txtKilos.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                cmbEstado.SelectedIndex = 0;
            }

        }

        private void txtNroViaje_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtNroViaje.Text.Trim() == "") return;

                txtRetiraProv.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtNroViaje.Text = "";
            }
	        
        }

        private void txtRetiraProv_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                txtHoraViaje.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                txtRetiraProv.Text = "";
            }
	        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in new []{txtNroHoja, txtCamion, txtChofer, txtDesCamion, txtDesChofer, txtKilos, txtNroViaje, txtRetiraProv})
            {
                txt.Text = "";
            }

            foreach (ComboBox cmb in new[] { cmbEstado, cmbTipoPedido })
            {
                cmb.SelectedIndex = 0;
            }

            txtFecha.Clear();

            dgvPedidos.Rows.Clear();

            dgvPedidos.Rows.Add();

            txtNroHoja.Focus();
        }

        private void HojaRuta_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
        }

        private void cmbTipoPedido_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbTipoPedido.SelectedIndex >= 0) cmbEstado.Focus();
        }

        private void cmbEstado_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedIndex >= 0) txtKilos.Focus();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            _ListarPedidosSegunTipo(cmbTipoPedido.SelectedIndex);
        }

        private void _ListarPedidosSegunTipo(int WTipoPedido)
        {
            Auxiliares.ListaPedidos frm = new Auxiliares.ListaPedidos(WTipoPedido);
            frm.Show(this);
        }

        internal void Prueba(object WPedido)
        {
            int I = -1;
            foreach (DataGridViewRow row in dgvPedidos.Rows)
            {
                var r = row.Cells["Pedido"].Value ?? "";
                if (string.IsNullOrEmpty(r.ToString()) && I == -1)
                {
                    I = row.Index;
                }
            }

            if (I == -1) I = dgvPedidos.Rows.Add();

            dgvPedidos.Rows[I].Cells["Pedido"].Value = WPedido;
        }
    }
}
