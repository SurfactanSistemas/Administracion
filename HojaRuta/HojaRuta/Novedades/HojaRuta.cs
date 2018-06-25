using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
                        cmd.CommandText = "SELECT ISNULL(Razon, '') Razon FROM Cliente WHERE CLiente = '" + WCliente +
                                          "'";

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
                        cmd.CommandText = "SELECT ISNULL(Descripcion, '') Descripcion FROM Chofer WHERE Codigo = '" +
                                          WChofer + "'";

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
                        cmd.CommandText = "SELECT ISNULL(Descripcion, '') Descripcion FROM Camion WHERE COdigo = '" +
                                          WCamion + "'";

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
            foreach (
                TextBox txt in
                    new[]
                    {txtNroHoja, txtCamion, txtChofer, txtDesCamion, txtDesChofer, txtKilos, txtNroViaje, txtRetiraProv}
                )
            {
                txt.Text = "";
            }

            foreach (ComboBox cmb in new[] {cmbEstado, cmbTipoPedido})
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
            if (cmbTipoPedido.SelectedIndex >= 0) btnPedidos.PerformClick();
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
            _PurgarRemitosYNroRemitosPedidos();
            Auxiliares.ListaPedidos frm = new Auxiliares.ListaPedidos(WTipoPedido);
            frm.Show(this);
        }

        private void _PurgarRemitosYNroRemitosPedidos()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE Pedido SET Remito = 0 WHERE Remito is null or Remito = ''";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "UPDATE Pedido SET NroRemito = 0 WHERE NroRemito is null or NroRemito = ''";
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

        }

        internal void _TraerPedidoDeLista(object WPedido)
        {

            try
            {
                int I = -1;

                if (_PedidoYaCargado(WPedido))
                {
                    return;
                }

                foreach (DataGridViewRow row in dgvPedidos.Rows)
                {
                    var r = row.Cells["Pedido"].Value ?? "";

                    if (string.IsNullOrEmpty(r.ToString()) && I == -1)
                    {
                        I = row.Index;
                    }
                }

                if (I == -1) I = dgvPedidos.Rows.Add();

                _TraerInformacionPedido(WPedido, I);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        }

        private bool _PedidoYaCargado(object WPedido)
        {
            return
                (from DataGridViewRow row in dgvPedidos.Rows select row.Cells["Pedido"].Value ?? "").Count(
                    r => r.ToString() == WPedido.ToString()) > 1;
        }

        private void _TraerInformacionPedido(object WPedido, int I)
        {
            DataGridViewRow WRow = dgvPedidos.Rows[I];

            WRow.Cells["Pedido"].Value = WPedido;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT p.Pedido, p.Cliente, p.Terminado, ST = (SELECT COALESCE(LTRIM(RTRIM(ISNULL(Clase, ''))) + ';', '') FROM Terminado WHERE Codigo = p.Terminado), c.Razon, Tipo = CASE p.TipoPed WHEN 5 THEN 'Muestra' ELSE 'Pedido' END, NroRemitoPedido = ISNULL(p.NroRemito, 0), RemitoPedido = ISNULL(p.Remito, 0), RemitoMuestra = ISNULL(m.Remito, 0), CantidadKilos = (SELECT SUM(CantiLote1+CantiLote2+CantiLote3+CantiLote4+CantiLote5+UltimoCantiLote1+UltimoCantiLote2+UltimoCantiLote3+UltimoCantiLote4+UltimoCantiLote5) from Pedido WHERE Pedido = p.Pedido), CantidadFac = (SELECT SUM(CantidadFac) from Pedido WHERE Pedido = p.Pedido) FROM Pedido p INNER JOIN Cliente c ON p.Cliente = c.Cliente LEFT OUTER JOIN Muestra m ON p.Pedido = m.Pedido WHERE p.Cliente = c.Cliente AND p.Pedido = '" +
                        WPedido + "' order BY p.Pedido";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            WRow.Cells["Cliente"].Value = dr["Cliente"].ToString();
                            WRow.Cells["Razon"].Value = dr["Razon"].ToString();
                            WRow.Cells["Remito"].Value = dr["RemitoPedido"].ToString();

                            if (WRow.Cells["Remito"].Value.ToString() == "0")
                            {
                                WRow.Cells["Remito"].Value = dr["NroRemitoPedido"].ToString();
                            }

                            if (dr["NroRemitoPedido"].ToString() == "Muestra")
                            {
                                WRow.Cells["Remito"].Value = dr["RemitoMuestra"].ToString();
                            }

                            WRow.Cells["Segur"].Value = dr["ST"];

                            WRow.Cells["Segur"].Value = WRow.Cells["Segur"].Value.ToString().TrimEnd(';');

                            WRow.Cells["Kilos"].Value = dr["CantidadKilos"];

                            if (WRow.Cells["Kilos"].Value.ToString() == "0")
                            {
                                WRow.Cells["Kilos"].Value = dr["CantidadFac"].ToString();
                            }

                            WRow.Cells["Kilos"].Value = Helper.FormatoNumerico(WRow.Cells["Kilos"].Value.ToString());

                            if (dgvPedidos.Rows.Count > 0)
                            {
                                int _I = -1;

                                foreach (DataGridViewRow row in dgvPedidos.Rows)
                                {
                                    var r = row.Cells["Pedido"].Value ?? "";

                                    if (string.IsNullOrEmpty(r.ToString()) && _I == -1)
                                    {
                                        _I = row.Index;
                                    }
                                }

                                if (_I == -1) _I = dgvPedidos.Rows.Add();

                                dgvPedidos.CurrentCell = dgvPedidos.Rows[_I].Cells["Pedido"];
                            }
                        }
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (dgvPedidos.Focused || dgvPedidos.IsCurrentCellInEditMode)
            {
                dgvPedidos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (keyData == Keys.Enter)
                {
                    var WValor = dgvPedidos.CurrentCell.Value ?? "";
                    int iCol = dgvPedidos.CurrentCell.ColumnIndex;
                    int iRow = dgvPedidos.CurrentCell.RowIndex;

                    switch (iCol)
                    {
                        case 0:
                        {
                            if (_PedidoYaCargado(WValor) || WValor.ToString().Trim() == "") return true;

                            _TraerInformacionPedido(WValor, iRow);
                            dgvPedidos.CurrentCell = dgvPedidos.Rows[iRow].Cells["Bultos"];

                            break;
                        }
                        default:
                        {
                            dgvPedidos.CurrentCell = iCol == dgvPedidos.Columns.Count - 1
                                ? (dgvPedidos.Rows.Count - 1 == iRow
                                    ? dgvPedidos.Rows[dgvPedidos.Rows.Add()].Cells["Pedido"]
                                    : dgvPedidos.Rows[iRow + 1].Cells["Pedido"])
                                : dgvPedidos.Rows[iRow].Cells[iCol + 1];
                            break;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        private void btnCheckList_Click(object sender, EventArgs e)
        {
            bool WPeligroso = _EsPeligroso();
            Auxiliares.CheckListExportacion frm = new Auxiliares.CheckListExportacion(txtNroHoja.Text, txtFecha.Text, WPeligroso);
            frm.Show(this);
        }

        private bool _EsPeligroso()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    string WClase = "";

                    foreach (DataGridViewRow row in dgvPedidos.Rows)
                    {
                        var WPedido = row.Cells["Pedido"].Value ?? "";

                        if (WPedido.ToString().Trim() == "") continue;

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT ISNULL(Terminado.Clase, '') Clase FROM Pedido INNER JOIN Terminado ON Pedido.Terminado = Terminado.Codigo WHERE Pedido.Pedido = '" + WPedido + "'";

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        WClase += dr["Clase"] == null ? "" : dr["Clase"].ToString();
                                    }
                                }
                            }
                        }
                    }
                    
                    // Determinamos si hay algun numero cargado en la Clase referida a alguno del Terminados de los Pedidos.
                    return (new Regex(@"[0-9]+")).IsMatch(WClase);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al determinar la peligrosidad del los Productos Terminados desde la Base de Datos. Motivo: " + ex.Message);
            }
        }
    }
}