using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HojaRuta.Auxiliares;
using HojaRuta.Reportes;

namespace HojaRuta.Novedades
{
    public partial class HojaRuta : Form
    {
        private ConsultaAyuda frmAyuda;
        private string WHojaCot = "";

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
                                txtFecha.Text = dr["Fecha"] != null ? dr["Fecha"].ToString() : "";
                                txtKilos.Text = dr["Kilos"] != null ? dr["Kilos"].ToString() : "";
                                txtChofer.Text = dr["Chofer"] != null ? dr["Chofer"].ToString() : "";
                                txtCamion.Text = dr["Camion"] != null ? dr["Camion"].ToString() : "";
                                txtNroViaje.Text = dr["NroViaje"] != null ? dr["NroViaje"].ToString() : "";
                                txtRetiraProv.Text = dr["RetiraProv"] != null ? dr["RetiraProv"].ToString() : "";
                                cmbEstado.SelectedIndex = int.Parse(dr["TipoEstado"] != null ? dr["TipoEstado"].ToString().PadLeft(1, '0') : "0");
                                int WIndice = dgvPedidos.Rows.Add();

                                DataGridViewRow r = dgvPedidos.Rows[WIndice];
                                r.Cells["Pedido"].Value = dr["Pedido"] != null ? dr["Pedido"].ToString() : "";
                                r.Cells["Cliente"].Value = dr["Cliente"] != null ? dr["Cliente"].ToString() : "";
                                r.Cells["Razon"].Value = _TraerRazonSocial(r.Cells["Cliente"].Value);
                                r.Cells["Remito"].Value = dr["Remito"] != null ? dr["Remito"].ToString() : "";
                                r.Cells["Segur"].Value = dr["Seguridad"] != null ? dr["Seguridad"].ToString() : "";
                                r.Cells["Kilos"].Value = dr["Kilos"] != null ? dr["Kilos"].ToString() : "";
                                r.Cells["Bultos"].Value = dr["Bultos"] != null ? dr["Bultos"].ToString() : "";
                                r.Cells["Envases"].Value = dr["ObservaI"] != null ? dr["ObservaI"].ToString() : "";
                                r.Cells["Observacion"].Value = dr["ObservaII"] != null ? dr["ObservaII"].ToString() : "";
                                r.Cells["Cot"].Value = dr["Comprobante"] != null ? dr["Comprobante"].ToString() : "";
                                r.Cells["Integridad"].Value = dr["Integridad"] != null ? dr["Integridad"].ToString() : "";
                                r.Cells["Archivo"].Value = dr["Archivo"] != null ? dr["Archivo"].ToString() : "";
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
            foreach (TextBox txt in groupBox2.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }

            foreach (ComboBox cmb in groupBox2.Controls.OfType<ComboBox>())
            {
                if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
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
            if (_EsExterior())
            {
                _ListarPedidosSegunTipo(cmbTipoPedido.SelectedIndex);
            }
        }

        private void _ListarPedidosSegunTipo(int WTipoPedido)
        {
            _PurgarRemitosYNroRemitosPedidos();
            ListaPedidos frm = new ListaPedidos(WTipoPedido);
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
            CheckListExportacion frm = new CheckListExportacion(txtNroHoja.Text, txtFecha.Text, WPeligroso);
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

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (frmAyuda != null) frmAyuda.Dispose();

            frmAyuda = new ConsultaAyuda();
            frmAyuda.Show(this);
        }

        internal void _RecibirDatosAyuda(string WId, short WtipoConsulta)
        {
            switch (WtipoConsulta)
            {
                case 1:
                {
                    txtCamion.Text = WId;
                    txtCamion_KeyDown(null, new KeyEventArgs(Keys.Enter));
                    break;
                }
                case 2:
                {
                    txtChofer.Text = WId;
                    txtChofer_KeyDown(null, new KeyEventArgs(Keys.Enter));
                    break;
                }
            }

            if (frmAyuda != null) frmAyuda.Dispose();
        }

        private void txtChofer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (frmAyuda != null) frmAyuda.Dispose();

            frmAyuda = new ConsultaAyuda("2");
            frmAyuda.Show(this);
        }

        private void txtCamion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (frmAyuda != null) frmAyuda.Dispose();

            frmAyuda = new ConsultaAyuda("1");
            frmAyuda.Show(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                var WCamion = txtCamion.Text.Trim();
                var WChofer = txtChofer.Text.Trim();
                var WNroViaje = txtNroViaje.Text.Trim();

                // Controlo Fecha.
                if (txtFecha.Text.Replace("/", "").Trim() == "")
                {
                    throw new Exception("Fecha No Informada");
                }

                // Controlo Camión.
                if (WCamion == "")
                {
                    throw new Exception("Camión no informado.");
                }

                // Controlo Chofer.
                if (WChofer== "")
                {
                    throw new Exception("Chofer no informado.");
                }

                // Controlo Nro Viaje.
                if (WNroViaje == "" || WNroViaje == "0")
                {
                    throw new Exception("Nro de Viaje no informado.");
                }

                var WFecha = txtFecha.Text;
                var WOrdFecha = int.Parse(Helper.OrdenarFecha(WFecha));
                var WFechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
                var WOrdFechaInicio = int.Parse(Helper.OrdenarFecha(WFechaInicio));
                var WNuevaFecha = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy");
                var WOrdNuevaFecha = int.Parse(Helper.OrdenarFecha(WNuevaFecha));

                var ZCodigoPeligroso = "";
                var ZCantiPeligroso = 0;
                var ZCodigoPeligrosoII = "";
                var ZCantiPeligrosoII = 0;

                List<object[]> WAtrasos = new List<object[]>();

                // Controlo Validez de la Fecha ingresada.
                if (!Helper._ValidarFecha(txtFecha.Text))
                {
                    throw new Exception("Fecha Inválida.");
                }

                var WDiferencia = (Convert.ToDateTime(WFecha) - Convert.ToDateTime(WFechaInicio)).Days;
                // Controlo que se encuentre dentro de los cuatros dias.
                if (WDiferencia > 4 || WDiferencia < 0)
                {
                    throw new Exception("La fecha de la hoja de ruta exede los 4 dias desde la fecha actual o no es anterior");
                }

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        cmd.CommandText = "SELECT FechaVtoI, FechaVtoII, FechaVtoIII, FechaVtoIV, FechaVtoV, AplicaV FROM Camion WHERE Codigo = '" + WCamion + "'";

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dr.Read();

                            var WCamionFechaVtoI = dr["FechaVtoI"] != null ? dr["FechaVtoI"].ToString() : "";
                            var WCamionFechaVtoII = dr["FechaVtoII"] != null ? dr["FechaVtoII"].ToString() : "";
                            var WCamionFechaVtoIII = dr["FechaVtoIII"] != null ? dr["FechaVtoIII"].ToString() : "";
                            var WCamionFechaVtoIV = dr["FechaVtoIV"] != null ? dr["FechaVtoIV"].ToString() : "";
                            var WCamionFechaVtoV = dr["FechaVtoV"] != null ? dr["FechaVtoV"].ToString() : "";
                            var WAplicaV = dr["AplicaV"] != null ? dr["AplicaV"].ToString() : "0";

                            var WOrdCamionFechaVtoI = int.Parse(Helper.OrdenarFecha(WCamionFechaVtoI));
                            var WOrdCamionFechaVtoII = int.Parse(Helper.OrdenarFecha(WCamionFechaVtoII));
                            var WOrdCamionFechaVtoIII = int.Parse(Helper.OrdenarFecha(WCamionFechaVtoIII));
                            var WOrdCamionFechaVtoIV = int.Parse(Helper.OrdenarFecha(WCamionFechaVtoIV));
                            var WOrdCamionFechaVtoV = int.Parse(Helper.OrdenarFecha(WCamionFechaVtoV));

                            if (WOrdCamionFechaVtoI < WOrdFecha && WOrdCamionFechaVtoI > 0)
                            {
                                throw new Exception("La fecha de vigencia de Ruta esta vencida: " + WCamionFechaVtoI);
                            }

                            if (WOrdCamionFechaVtoII < WOrdFecha && WOrdCamionFechaVtoII > 0)
                            {
                                throw new Exception(
                                    "La fecha de vigencia de Revision Tecnica Obligatoria esta vencida: " +
                                    WCamionFechaVtoII);
                            }

                            if (WOrdCamionFechaVtoIII < WOrdFecha && WOrdCamionFechaVtoIII > 0)
                            {
                                throw new Exception("La fecha de vigencia de Habilitacion de Dominio esta vencida: " +
                                                    WCamionFechaVtoIII);
                            }

                            if (WOrdCamionFechaVtoIV < WOrdFecha && WOrdCamionFechaVtoIV > 0)
                            {
                                throw new Exception("La fecha de vigencia de Seguro esta vencida: " + WCamionFechaVtoIV);
                            }

                            if (int.Parse(WAplicaV) == 1 && WOrdCamionFechaVtoI < WOrdFecha)
                            {
                                throw new Exception(
                                    "La fecha de vigencia de Cert. para transporte de cargas peligrosas esta vencida: " +
                                    WCamionFechaVtoV);
                            }

                            // Verifico proximidad de Vencimiento.
                            if (WOrdCamionFechaVtoI < WOrdNuevaFecha && WOrdCamionFechaVtoI > 0)
                            {
                                throw new Exception("La fecha de vigencia de Ruta esta próxima a: " + WCamionFechaVtoI);
                            }

                            if (WOrdCamionFechaVtoII < WOrdNuevaFecha && WOrdCamionFechaVtoII > 0)
                            {
                                throw new Exception(
                                    "La fecha de vigencia de Revision Tecnica Obligatoria esta próxima a: " +
                                    WCamionFechaVtoII);
                            }

                            if (WOrdCamionFechaVtoIII < WOrdNuevaFecha && WOrdCamionFechaVtoIII > 0)
                            {
                                throw new Exception("La fecha de vigencia de Habilitacion de Dominio esta próxima a: " +
                                                    WCamionFechaVtoIII);
                            }

                            if (WOrdCamionFechaVtoIV < WOrdNuevaFecha && WOrdCamionFechaVtoIV > 0)
                            {
                                throw new Exception("La fecha de vigencia de Seguro esta próxima a: " + WCamionFechaVtoIV);
                            }

                            if (WOrdCamionFechaVtoV < WOrdNuevaFecha && WOrdCamionFechaVtoV > 0 && WAplicaV == "1")
                            {
                                throw new Exception(
                                    "La fecha de vigencia de Cert. para transporte de cargas peligrosas esta próxima a: " +
                                    WCamionFechaVtoV);
                            }
                        }
                        else
                        {
                            throw new Exception("Camion Inexistente");
                        }

                        if (!dr.IsClosed) dr.Close();

                        cmd.CommandText = "SELECT * FROM Chofer WHERE Codigo = '" + WChofer + "'";

                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dr.Read();

                            var WChoferFechaVtoI = dr["FechaVtoI"] != null ? dr["FechaVtoI"].ToString() : "";
                            var WChoferFechaVtoII = dr["FechaVtoII"] != null ? dr["FechaVtoII"].ToString() : "";
                            var WChoferFechaVtoIII = dr["FechaVtoIII"] != null ? dr["FechaVtoIII"].ToString() : "";

                            var WOrdChoferFechaVtoI = int.Parse(Helper.OrdenarFecha(WChoferFechaVtoI));
                            var WOrdChoferFechaVtoII = int.Parse(Helper.OrdenarFecha(WChoferFechaVtoII));
                            var WOrdChoferFechaVtoIII = int.Parse(Helper.OrdenarFecha(WChoferFechaVtoIII));

                            var WAplicaIII = dr["FechaVtoIII"] != null ? dr["FechaVtoIII"].ToString() : "0";

                            if (WOrdChoferFechaVtoI < WOrdFecha && WOrdChoferFechaVtoI > 0)
                            {
                                throw new Exception("La fecha de vigencia de Licencia de Conducir esta vencida: " + WChoferFechaVtoI);
                            }

                            if (WOrdChoferFechaVtoII < WOrdFecha && WOrdChoferFechaVtoII > 0)
                            {
                                throw new Exception(
                                    "La fecha de vigencia de ART esta vencida: " +
                                    WChoferFechaVtoII);
                            }

                            if (WOrdChoferFechaVtoIII < WOrdFecha && WAplicaIII == "1")
                            {
                                throw new Exception("La fecha de vigencia de Cert. para transporte de cargas peligrosas esta vencida: " +
                                                    WChoferFechaVtoIII);
                            }


                            // Verifico proximidad de Vencimiento.
                            if (WOrdChoferFechaVtoI < WOrdNuevaFecha && WOrdChoferFechaVtoI > 0)
                            {
                                throw new Exception("La fecha de vigencia de Licencia de Conducir esta proxima a: " + WChoferFechaVtoI);
                            }

                            if (WOrdChoferFechaVtoII < WOrdNuevaFecha && WOrdChoferFechaVtoII > 0)
                            {
                                throw new Exception(
                                    "La fecha de vigencia de ART esta proxima a: " +
                                    WChoferFechaVtoII);
                            }

                            if (WOrdChoferFechaVtoIII < WOrdNuevaFecha && WOrdChoferFechaVtoIII > 0 && WAplicaIII == "1")
                            {
                                throw new Exception("La fecha de vigencia de Cert. para transporte de cargas peligrosas esta proxima a: " +
                                                    WChoferFechaVtoIII);
                            }

                        }
                        else
                        {
                            throw new Exception("Chofer Inexistente");
                        }

                        // Verificamos la existencia de la numeración de la Hoja.

                        if (!dr.IsClosed) dr.Close();

                        cmd.CommandText = "SELECT Hoja FROM HojaRuta WHERE Hoja = '" + txtNroHoja.Text + "'";

                        dr = cmd.ExecuteReader();

                        // Si no existe, se busca la maxima numeracion de hoja hasta el momento y se le asigna el siguiente. En caso contrario, se le asigna la primera numeracion.
                        if (!dr.HasRows)
                        {
                            if (!dr.IsClosed) dr.Close();

                            cmd.CommandText = "SELECT MAX(Hoja) Maximo FROM HojaRuta";
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();

                                txtNroHoja.Text = (int.Parse(dr["Maximo"].ToString()) + 1).ToString();
                            }
                            else
                            {
                                txtNroHoja.Text = "1";
                            }
                        }

                        // Corroboramos que, si es de exterior, tenga CheckList cargado.
                        if (_EsExterior())
                        {
                            if (!dr.IsClosed) dr.Close();

                            cmd.CommandText = "SELECT Hoja FROM CheckListExpo WHERE Hoja = '" + txtNroHoja.Text + "'";
                            dr = cmd.ExecuteReader();

                            if (!dr.HasRows) throw new Exception("Debe cargar el Check List de Exportación correspondiente.");
                        }

                        // Reseteamos las numeraciones de las hojas cargadas en los registros de los pedidos.
                        foreach (DataGridViewRow row in dgvPedidos.Rows)
                        {
                            var WPed = row.Cells["Pedido"].Value ?? "";

                            if (WPed.ToString().Trim() == "") continue;

                            if (!dr.IsClosed) dr.Close();

                            cmd.CommandText = "UPDATE Pedido SET HojaRuta = 0 WHERE Pedido = '" + WPed + "'";
                            cmd.ExecuteNonQuery();
                        }

                        // Eliminamos cualquier registro previo de la Hoja de Ruta.

                        if (!dr.IsClosed) dr.Close();
                        cmd.CommandText = "DELETE FROM HojaRuta WHERE Hoja = '" + txtNroHoja.Text + "'";
                        cmd.ExecuteNonQuery();


                        // Vamos guardando los pedidos de esta Hoja de Ruta y actualizando la numeracion en los registros de los Pedidos y Muestras.
                        int WRenglon = 0;

                        foreach (DataGridViewRow row in dgvPedidos.Rows)
                        {
                            if (!dr.IsClosed) dr.Close();

                            var XHoja = txtNroHoja.Text;
                            var XFecha = txtFecha.Text;
                            var XOrdFecha = Helper.OrdenarFecha(XFecha);
                            var XChofer = txtChofer.Text;
                            var XCamion = txtCamion.Text;
                            var XPedido = row.Cells["Pedido"].Value ?? "";
                            var XCliente = row.Cells["Cliente"].Value ?? "";
                            var XRemito = row.Cells["Remito"].Value ?? "";
                            var XSeguridad = row.Cells["Segur"].Value ?? "";
                            var XKilos = row.Cells["Kilos"].Value ?? "";
                            var XPesos = "0";
                            var XBultos = row.Cells["Bultos"].Value ?? "";
                            var XRazon = row.Cells["Razon"].Value ?? "";
                            var XObservaI = row.Cells["Envases"].Value ?? "";
                            var XObservaII = row.Cells["Observacion"].Value ?? "";
                            var XNroViaje = txtNroViaje.Text;
                            var XRetiraProv = txtRetiraProv.Text;
                            var XTipoEstado = cmbEstado.SelectedIndex.ToString();
                            var XComprobante = row.Cells["Cot"].Value ?? "";
                            var XIntegridad = row.Cells["Integridad"].Value ?? "";
                            var XArchivo = row.Cells["Archivo"].Value ?? "";

                            if (XPedido.ToString().Trim() == "") continue;

                            WRenglon++;

                            var XClave = XHoja.PadLeft(6, '0') + WRenglon.ToString().PadLeft(2, '0');

                            var ZSql = string.Format("INSERT INTO HojaRuta (Clave, Hoja, Renglon, Fecha, OrdFecha, Chofer, Camion, Pedido, Cliente, Remito, Seguridad, Kilos, Pesos, Bultos, Razon, ObservaI, ObservaII, Comprobante, Integridad, Archivo, NroViaje, TipoEstado, RetiraProv) " +
                                                     " Values ('{0}', {1}, {2}, '{3}', '{4}', {5}, {6}, {7}, '{8}', {9}, '{10}', {11}, {12}, {13}, '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', {20}, {21}, '{22}')",
                                                     XClave, XHoja, WRenglon, XFecha, XOrdFecha, XChofer, XCamion, XPedido, XCliente, XRemito, XSeguridad, XKilos, XPesos, XBultos, XRazon, XObservaI, XObservaII, XComprobante, XIntegridad, XArchivo, XNroViaje, XTipoEstado, XRetiraProv);

                            cmd.CommandText = ZSql;
                            cmd.ExecuteNonQuery();

                            /*
                             * Asociamos el numero de Hoja al Registro del Pedido.
                             */
                            cmd.CommandText = string.Format("UPDATE Pedido SET HojaRuta = '{0}' WHERE Pedido = '{1}'", XHoja, XPedido);
                            cmd.ExecuteNonQuery();

                            /*
                             * Asociamos el numero de Hoja al Registro de la Muestra, en caso que corresponda.
                             */
                            cmd.CommandText = string.Format("UPDATE Muestra SET HojaRuta = '{0}' WHERE Pedido = '{1}'", XHoja, XPedido);
                            cmd.ExecuteNonQuery();

                            if (!dr.IsClosed) dr.Close();

                            /*
                             * Verificamos y calculamos la cantidad de Productos Peligrosos se van a transportar.
                             */

                            cmd.CommandText = "SELECT * FROM Pedido INNER JOIN Terminado ON Pedido.Terminado = Terminado.Codigo WHERE Pedido.Pedido = '" + XPedido + "'";
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var ZMarca = dr["Marca"] != null ? dr["Marca"].ToString() : "";
                                    var ZNaciones = dr["Naciones"] != null ? dr["Naciones"].ToString() : "";

                                    ZMarca = ZMarca.Trim();
                                    ZNaciones = ZNaciones.Trim();

                                    if (ZMarca == "") continue;

                                    if (ZMarca != ZCodigoPeligroso)
                                    {
                                        ZCantiPeligroso++;
                                        ZCodigoPeligroso = ZMarca;
                                    }

                                    if (ZNaciones == ZCodigoPeligrosoII) continue;

                                    ZCantiPeligrosoII++;
                                    ZCodigoPeligrosoII = ZNaciones;
                                }
                            }


                            /*
                             * Verificamos si hay atraso en el envío de los pedidos.
                             */
                            var ZFechaEntrega = "00/00/0000";
                            var ZOrdFechaEntrega = "00000000";

                            if (!dr.IsClosed) dr.Close();

                            cmd.CommandText = "SELECT FecEntrega, OrdFecEntrega FROM Pedido WHERE Pedido = '" + XPedido +"'";
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();

                                ZFechaEntrega = dr["FecEntrega"] != null ? dr["FecEntrega"].ToString() : "";
                                ZOrdFechaEntrega = dr["OrdFecEntrega"] != null ? dr["OrdFecEntrega"].ToString() : "";
                            }

                            if (int.Parse(XOrdFecha) > int.Parse(ZOrdFechaEntrega))
                            {
                                var ZAtraso = true;

                                if (!dr.IsClosed) dr.Close();

                                cmd.CommandText = "SELECT Origen FROM Atraso WHERE Pedido = '" + XPedido + "'";
                                dr = cmd.ExecuteReader();

                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        var ZOrigen = dr["Origen"] != null ? dr["Origen"].ToString() : "";

                                        if (int.Parse(ZOrigen) == 3) ZAtraso = false;

                                    }
                                }

                                if (ZAtraso) WAtrasos.Add(new[]{XPedido, XCliente, XRazon, ZFechaEntrega});
                            }
                        }

                        /*
                         * Actualizamos las cantidades y datos de los Productos Peligrosos.
                         */
                        if (!dr.IsClosed) dr.Close();

                        cmd.CommandText = string.Format("UPDATE HojaRuta SET CodigoPeligroso = '{0}', CantiPeligroso = '{1}', CodigoPeligrosoII = '{2}', CantiPeligrosoII = '{3}' WHERE Hoja = '{4}'", 
                                                        ZCantiPeligroso, ZCantiPeligroso, ZCodigoPeligrosoII, ZCantiPeligrosoII, txtNroHoja.Text);
                        cmd.ExecuteNonQuery();
                     
                        // Confirmamos los cambios.
                        trans.Commit();
                    }
                }

                MessageBox.Show("El número de Hoja Asignado es: " + txtNroHoja.Text);

                /*
                 * Si hay atrasos los voy llamando de a uno para que los actualicen.
                 */

                foreach (object[] ZPed in WAtrasos)
                {
                    AtrasoExpedicion frm = new AtrasoExpedicion(ZPed[0], ZPed[1], ZPed[2], ZPed[3]);
                    frm.ShowDialog(this);
                }

                /*
                 * Consultamos por si quiere realizar el COT al momento de guardar la hoja de Ruta, en caso de que alguno de los pedidos no tenga un comprobante asignado.
                 */

                bool WConsultar = false;
                foreach (DataGridViewRow row in dgvPedidos.Rows)
                {
                    var WPed = row.Cells["Pedido"].Value ?? "";
                    if (WPed.ToString().Trim() == "") continue;

                    var WComp = row.Cells["Cot"].Value ?? "";
                    if (WComp.ToString().Trim() == "") WConsultar = true;
                }

                if (WConsultar)
                {
                    if (MessageBox.Show("¿Desea Generar el COT para los pedidos indicados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                    {
                        btnCot.PerformClick();
                    }
                }

                /*
                 * Consulto si quier imprimir el remito.
                 */
                if (MessageBox.Show("¿Desea Imprimir la Hoja de Ruta?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    _ImprimirHojaRuta();
                }

                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                if (trans != null && trans.Connection != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }

        }

        private void _ImprimirHojaRuta()
        {
            if (txtNroHoja.Text.Trim() == "") return;
            if (!_ExisteHojaRuta(txtNroHoja.Text)) return;

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new hojarutanuevo(), "{HojaRuta.Hoja} = " + txtNroHoja.Text + " AND {HojaRuta.Chofer} = {Chofer.Codigo} AND {HojaRuta.Camion} = {Camion.Codigo}");
            //frm.Show();
            frm.Imprimir();
        }

        private bool _ExisteHojaRuta(string WHojaRuta)
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
                        cmd.CommandText = "SELECT Hoja FROM HojaRuta WHERE Hoja = '" + WHojaRuta + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            return dr.HasRows;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la existencia de la Hoja de Ruta en la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private bool _EsExterior()
        {
            try
            {
                bool WExterior = false;

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        foreach (DataGridViewRow row in dgvPedidos.Rows)
                        {
                            var WPedido = row.Cells["Pedido"].Value ?? "";

                            if (WPedido.ToString() == "") continue;

                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT ISNULL(Cliente.Provincia, 0) Prov FROM Pedido, Cliente WHERE Pedido.Cliente = Cliente.Cliente AND Pedido.Pedido = '" + WPedido + "'";

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();

                                    if (dr["Prov"].ToString() == "24")
                                    {
                                        WExterior = true;
                                    }
                                }
                            }
                        }
                    }

                }

                return WExterior;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar si es una hoja para el exterior en la Base de Datos. Motivo: " + ex.Message);
            }
        }

        private void btnCot_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            SqlDataReader dr = null;
            try
            {
                if (!Directory.Exists(@"C:\cot")) Directory.CreateDirectory(@"C:\cot");

                foreach (string WPath in Directory.GetFiles(@"C:\cot"))
                {
                    File.Delete(WPath);
                }

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "";
                        cmd.Transaction = trans;

                        var WDolar = _TraerCambioDolarHoy();
                        var WPlanta = "000";
                        var WPuerta = "000";
                        var WCuit = "30549165083";
                        var WNroOrden = txtNroViaje.Text.PadLeft(6, '0');
                        var WPatente = _TraerPatenteCamion();
                        var WProveedor = _TraerProveedorChofer();
                        var WCuitChofer = _TraerCuitProveedor(WProveedor);

                        foreach (DataGridViewRow row in dgvPedidos.Rows)
                        {
                            var WFecha = txtFecha.Text;
                            var WFechaOrd = Helper.OrdenarFecha(WFecha);
                            var WChofer = txtChofer.Text;
                            var WCamion = txtCamion.Text;
                            var WPedido = row.Cells["Pedido"].Value ?? "";
                            var WCliente = row.Cells["Cliente"].Value ?? "";
                            var WRazon = row.Cells["Razon"].Value ?? "";
                            var WRemito = row.Cells["Remito"].Value ?? "";
                            WRemito = WRemito.ToString().PadLeft(8, '0');
                            var WCot = row.Cells["Cot"].Value ?? "";

                            if (WCot.ToString().Trim() != "") continue;

                            if (WPedido.ToString() == "") continue;

                            var WTipoPed = _TraerTipoPed(WPedido.ToString());

                            if (WTipoPed == "")
                                throw new Exception("No se pudo determinar el Tipo de Pedido de el Pedido '" + WPedido + "'");

                            if (WTipoPed == "5" || WTipoPed == "6") continue;

                            var WHora = txtHoraViaje.Text;

                            WHora = WHora.PadLeft(4, WHora.Trim() != "" ? '0' : ' ');

                            var WSeguridad = row.Cells["Segur"].Value ?? "";
                            var WKilos = row.Cells["Kilos"].Value ?? "";
                            var WPesos = "0";
                            var WBultos = row.Cells["Bultos"].Value ?? "";
                            var WObservaI = row.Cells["Envases"].Value ?? "";
                            var WObservaII = row.Cells["Observacion"].Value ?? "";
                            var WNroViaje = txtNroViaje.Text;
                            var WRetiraProv = txtRetiraProv.Text;
                            var WTipoEstado = cmbEstado.SelectedIndex;

                            var WCuitCliente = "";
                            var WDireccionCliente = "";
                            var WLocalidadCliente = "";
                            var WPostalCliente = "";

                            if (dr != null && !dr.IsClosed) dr.Close();

                            cmd.CommandText = "SELECT Cuit, Direccion, Localidad, Postal FROM Cliente WHERE Cliente = '" + WCliente + "'";
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();
                                WCuitCliente = dr["Cuit"] != null ? dr["Cuit"].ToString() : "";
                                WDireccionCliente = dr["Direccion"] != null ? dr["Direccion"].ToString() : "";
                                WLocalidadCliente = dr["Localidad"] != null ? dr["Localidad"].ToString() : "";
                                WPostalCliente = dr["Postal"] != null ? dr["Postal"].ToString() : "";
                            }

                            if (!dr.IsClosed) dr.Close();

                            var WTipoPedido = "";
                            var WLugarDirEntrega = "";

                            cmd.CommandText = "SELECT TipoPedido, DirEntrega, Remito, NroRemito FROM Pedido WHERE Pedido = '" + WPedido + "'";
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();
                                WTipoPedido = dr["TipoPedido"] != null ? dr["TipoPedido"].ToString() : "";
                                WLugarDirEntrega = dr["DirEntrega"] != null ? dr["DirEntrega"].ToString() : "";
                                WRemito = dr["Remito"] != null ? dr["Remito"].ToString() : "";

                                if (WRemito.ToString().Trim() == "")
                                {
                                    WRemito = dr["NroRemito"] != null ? dr["NroRemito"].ToString() : "";
                                }
                            }

                            if (!dr.IsClosed) dr.Close();

                            var WPunto = "";

                            switch (WTipoPedido)
                            {
                                case "1":
                                case "5":
                                {
                                    WPunto = "0001";
                                    break;
                                }
                                case "4":
                                {
                                    WPunto = "0003";
                                    break;
                                }
                                default:
                                {
                                    WPunto = "0004";
                                    break;
                                }
                            }

                            var WDireccionEntrega = "";
                            var WNumeroEntrega = "";
                            var WLocalidadEntrega = "";
                            var WPostalEntrega = "";
                            var WComplementoEntrega = "";
                            var WProvinciaEntrega = "";
                            var WDir = "";

                            WDir = _TraerReferenciaDireccion(WLugarDirEntrega);

                            cmd.CommandText = string.Format("SELECT Direccion{0} Direccion, Numero{0} Numero, Localidad{0} Localidad, Postal{0} Postal, Complemento{0} Complemento, Provincia{0} Provincia FROM ClienteDirEntrega WHERE Cliente = '{1}'", WDir, WCliente);
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();
                                WDireccionEntrega = dr["Direccion"] != null ? dr["Direccion"].ToString() : "";
                                WNumeroEntrega = dr["Numero"] != null ? dr["Numero"].ToString() : "";
                                WPostalEntrega = dr["Postal"] != null ? dr["Postal"].ToString() : "";
                                WLocalidadEntrega = dr["Localidad"] != null ? dr["Localidad"].ToString() : "";
                                WComplementoEntrega = dr["Complemento"] != null ? dr["Complemento"].ToString() : "";
                                WProvinciaEntrega = dr["Provincia"] != null ? dr["Provincia"].ToString() : "";
                            }
                            else
                            {
                                continue;
                            }

                            if (!dr.IsClosed) dr.Close();

                            var WProvinciaEntregaCodigo = _TraerCodigoEntregaProvincia(WProvinciaEntrega);

                            var WSecuencia = _TraerProximaSecuencia();

                            WSecuencia = WSecuencia.PadLeft(6, '0');

                            var WNombreArchivo = string.Format(@"C:\cot\TB_{0}_{1}{2}_{3}_{4}.txt", WCuit, WPlanta, WPuerta, WFechaOrd, WSecuencia);

                            var WLineasTexto = new List<string>();

                            var WImporte = 0.0;

                            var WPedidosRenglon = new List<object[]>();
                            var ZKilos = 0.0;

                            if (!dr.IsClosed) dr.Close();

                            cmd.CommandText = "SELECT * FROM Pedido WHERE Pedido = '" + WPedido + "'";
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var WSumaCantidad = 0.0;
                                    for (int i = 1; i < 5; i++)
                                    {
                                        var WA = dr["CantiLote" + i] != null ? dr["CantiLote" + i].ToString() : "0";

                                        if (WA.Trim() == "") WA = "0";

                                        WSumaCantidad += double.Parse(WA);
                                    }

                                    if (WSumaCantidad == 0)
                                    {
                                        for (int i = 1; i < 5; i++)
                                        {
                                            var WA = dr["UltimoCantiLote" + i] != null
                                                ? dr["UltimoCantiLote" + i].ToString()
                                                : "0";
                                            if (WA.Trim() == "") WA = "0";

                                            WSumaCantidad += double.Parse(WA);
                                        }    
                                    }

                                    if (WSumaCantidad == 0) WSumaCantidad = dr["CantidadFac"] != null ? double.Parse(dr["CantidadFac"].ToString()) : 0;

                                    if (WSumaCantidad != 0)
                                    {
                                        ZKilos += WSumaCantidad;
                                    }
                                    else
                                    {
                                        ZKilos += dr["Cantidad"] != null ? double.Parse(dr["Cantidad"].ToString()) : 0;
                                    }

                                    if (ZKilos != 0)
                                    {
                                        var WTerminado = dr["Terminado"] != null ? dr["Terminado"].ToString() : "";
                                        var ZTipoPed = dr["TipoPed"] != null ? dr["TipoPed"].ToString() : "";
                                        var ZTipoPedido = dr["TipoPedido"] != null ? dr["TipoPedido"].ToString() : "";
                                        var ZCliente = dr["Cliente"] != null ? dr["Cliente"].ToString() : "";
                                        var ZPrecio = dr["Precio"] != null ? dr["Precio"].ToString() : "0";

                                        var ZCod = ZTipoPedido == "1" ? "320411" : ZTipoPedido == "4" ? "291815" : "340391";

                                        WPedidosRenglon.Add(new object[]{WTerminado, ZKilos, ZCod, ZTipoPed, ZCliente});

                                        if (ZPrecio.Trim() == "") ZPrecio = "0";

                                        WImporte += (ZKilos + double.Parse(ZPrecio) + WDolar);
                                    }

                                }
                            }


                            if (File.Exists(WNombreArchivo)) File.Delete(WNombreArchivo);

                            WLineasTexto.Add("01|" + WCuit);

                            var WCampo1 = "02";
                            var WCampo2 = WFechaOrd;
                            WRemito = WRemito.ToString().Trim().PadLeft(8, '0');
                            var WCampo3 = "91 R" + WPunto + WRemito;
                            var WCampo4 = WFechaOrd;
                            var WCampo5 = " ";
                            var WCampo6 = "E";
                            var WCampo7 = "0";
                            var WCampo8 = "  ";
                            var WCampo9 = "  ";
                            var WCampo10 = WCuitCliente.Replace("-", "").Trim() + " ";
                            var WCampo11 = Helper.Left(WRazon.ToString(), 50).Trim() + " ";
                            var WCampo12 = "0";
                            var WCampo13 = Helper.Left(WDireccionEntrega, 40).Trim() + " ";
                            var WCampo14 = WNumeroEntrega.Trim() + " ";
                            var WCampo15 = WComplementoEntrega.Trim() + " ";
                            var WCampo16 = " ";
                            var WCampo17 = " ";
                            var WCampo18 = " ";
                            var WCampo19 = WPostalEntrega.Trim() + " ";
                            var WCampo20 = Helper.Left(WLocalidadEntrega, 50).Trim() + " ";
                            var WCampo21 = WProvinciaEntregaCodigo;
                            var WCampo22 = " ";
                            var WCampo23 = "NO";
                            var WCampo24 = "30549165083";
                            var WCampo25 = "SURFACTAN S.A.";
                            var WCampo26 = "0";
                            var WCampo27 = "";
                            var WCampo28 = "";
                            switch (WPunto)
                            {
                                case "0001":
                                {
                                    WCampo27 = "Malvinas Argentinas";
                                    WCampo28 = "4495";
                                    break;
                                }
                                case "0003":
                                {
                                    WCampo27 = "J.F.Kennedy";
                                    WCampo28 = "2689";
                                    break;
                                }
                                default:
                                {
                                    WCampo27 = "Tucuman";
                                    WCampo28 = "3475";
                                    break;
                                }
                            }

                            var WCampo29 = " ";
                            var WCampo30 = " ";
                            var WCampo31 = " ";
                            var WCampo32 = " ";
                            var WCampo33 = "1644";
                            var WCampo34 = "Victoria";
                            var WCampo35 = "B";
                            var WCampo36 = WCuitChofer;
                            var WCampo37 = "U";
                            var WCampo38 = " ";
                            var WCampo39 = " ";
                            var WCampo40 = " ";
                            var WCampo41 = WPatente;
                            var WCampo42 = " ";
                            var WCampo43 = "0";
                            var WCampo44 = Math.Truncate(WImporte * 100).ToString();

                            var WTemp = "";
                            WTemp += WCampo1 + "|" + WCampo2 + "|" + WCampo3 + "|" + WCampo4 + "|" + WCampo5 + "|" + WCampo6 + "|" + WCampo7 + "|" + WCampo8 + "|" + WCampo9 + "|" + WCampo10 + "|";
                            WTemp += WCampo11 + "|" + WCampo12 + "|" + WCampo13 + "|" + WCampo14 + "|" + WCampo15 + "|" + WCampo16 + "|" + WCampo17 + "|" + WCampo18 + "|" + WCampo19 + "|" + WCampo20 + "|";
                            WTemp += WCampo21 + "|" + WCampo22 + "|" + WCampo23 + "|" + WCampo24 + "|" + WCampo25 + "|" + WCampo26 + "|" + WCampo27 + "|" + WCampo28 + "|" + WCampo29 + "|" + WCampo30 + "|";
                            WTemp += WCampo31 + "|" + WCampo32 + "|" + WCampo33 + "|" + WCampo34 + "|" + WCampo35 + "|" + WCampo36 + "|" + WCampo37 + "|" + WCampo38 + "|" + WCampo39 + "|" + WCampo40 + "|";
                            WTemp += WCampo41 + "|" + WCampo42 + "|" + WCampo43 + "|" + WCampo44;

                            WLineasTexto.Add(WTemp);

                            foreach (object[] _Renglon in WPedidosRenglon)
                            {
                                var XArticulo = _Renglon[0];
                                var XArti = Helper.Left(XArticulo.ToString(), 3) + Helper.Right(XArticulo.ToString(), 7);
                                var XKilos = _Renglon[1];
                                var XCodAfip = _Renglon[2];
                                var XTipoPed = _Renglon[3];
                                var XCliente = _Renglon[4];
                                var XAuxi = "";
                                var XTipoPro = "";
                                var XDescripcion = "";

                                XAuxi = Helper.Left(XArticulo.ToString(), 2);

                                XAuxi = "T";

                                if (XAuxi != "PT" && XAuxi != "YQ" && XAuxi != "YF" && XAuxi != "YP" && XAuxi != "YH")
                                {
                                    XAuxi = "M";
                                }

                                if (!dr.IsClosed) dr.Close();

                                switch (XTipoPro)
                                {
                                    case "M":
                                    {
                                        cmd.CommandText = "SELECT Descripcion FROM ARticulo WHERE Codigo = '" + XArticulo + "'";
                                        break;
                                    }
                                    default:
                                    {
                                        if (XTipoPed.ToString() == "5" || XTipoPed.ToString() == "6")
                                        {
                                            cmd.CommandText = "SELECT Descripcion FROM Terminado WHERE Codigo = '" + XArticulo + "'";
                                        }
                                        else
                                        {
                                            cmd.CommandText = "SELECT Descripcion FROM Precios WHERE Cliente = '" + XCliente + "' AND Terminado = '" + XArticulo + "'";
                                        }
                                        break;
                                    }
                                }

                                dr = cmd.ExecuteReader();

                                if (dr.HasRows)
                                {
                                    dr.Read();
                                    XDescripcion = dr["Descripcion"] != null ? dr["Descripcion"].ToString() : "";
                                }

                                if (!dr.IsClosed) dr.Close();

                                XDescripcion = XDescripcion.Replace('-', ' ').Replace('/', ' ').Trim();

                                WCampo1 = "03";
                                WCampo2 = XCodAfip.ToString();
                                WCampo3 = "1";

                                if (XKilos.ToString().Trim() == "") XKilos = "0";

                                WCampo4 = Math.Truncate(double.Parse(XKilos.ToString())*100).ToString();
                                WCampo5 = XArticulo.ToString();
                                WCampo6 = Helper.Left(XDescripcion, 4);
                                WCampo7 = "Kilos";
                                WCampo8 = WCampo4;

                                WTemp = "";
                                WTemp = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", WCampo1, WCampo2, WCampo3, WCampo4, WCampo5, WCampo6, WCampo7, WCampo8);

                                WLineasTexto.Add(WTemp);
                            }

                            WTemp = "";
                            WTemp = "04| 1";

                            WLineasTexto.Add(WTemp);

                            File.WriteAllLines(WNombreArchivo, WLineasTexto.ToArray());

                            /*
                             * Actualizamos los datos para generar el COT.
                             */
                            if (!dr.IsClosed) dr.Close();

                            cmd.CommandText = "DELETE FROM GenerarCot WHERE Hoja = '" + txtNroHoja.Text + "' AND Pedido = '" + WPedido + "'";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = string.Format("INSERT INTO GenerarCot (Clave, Hoja, Pedido, RutaArchivo, Comprobante, Integridad) " +
                                                            " VALUES " +
                                                            " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", txtNroHoja.Text.PadLeft(6, '0') + WPedido.ToString().PadLeft(6,'0'), txtNroHoja.Text.Trim(), WPedido, WNombreArchivo, "","");
                            cmd.ExecuteNonQuery();
                        }
                        if (!dr.IsClosed) dr.Close();
                        trans.Commit();

                        /*
                         * Llamamos al Generador de Cot, pasandole el numero de hoja para que procese los comprobantes de todos los pedidos que asi lo necesiten.
                         */

                        _GenerarCot();
                    }

                }
            }
            catch (Exception ex)
            {
                if (trans != null && trans.Connection != null) trans.Rollback();
                throw new Exception(ex.Message);
            }
        
        }

        private void _GenerarCot()
        {
            var WRutaGenerador = ConfigurationManager.AppSettings["GENERADOR_COT"];

            Process.Start(WRutaGenerador, txtNroHoja.Text);

            timer1.Start();
        }

        private string _TraerProximaSecuencia()
        {
            try
            {
                var WSecuencia = "0";

                var WArchivos = Directory.GetFiles(@"C:\cot\", "TB_30549165083_000000_" + Helper.OrdenarFecha(txtFecha.Text) + "_*.txt");

                int WMayor = 0;

                foreach (string WArchivo in WArchivos)
                {
                    var WTemp = WArchivo.Replace(@"C:\cot\TB_30549165083_000000_" + Helper.OrdenarFecha(txtFecha.Text) + "_", "");
                    WTemp = WTemp.Replace(".txt", "");
                    var WNro = int.Parse(WTemp);

                    if (WNro > WMayor)
                    {
                        WMayor = WNro;
                    }
                }

                WSecuencia = WMayor.ToString();

                return (int.Parse(WSecuencia) + 1).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string _TraerReferenciaDireccion(string WTipoPedido)
        {
            string WDir = "";
            switch (WTipoPedido)
            {
                case "1":
                {
                    WDir = "I";
                    break;
                }
                case "2":
                {
                    WDir = "II";
                    break;
                }
                case "3":
                {
                    WDir = "III";
                    break;
                }
                case "4":
                {
                    WDir = "IV";
                    break;
                }
                case "5":
                {
                    WDir = "V";
                    break;
                }
            }
            return WDir;
        }

        private string _TraerCodigoEntregaProvincia(string wProvinciaEntrega)
        {
            var ZZProvinciaEntregaCodigo = "";

            switch (wProvinciaEntrega)
            {
                 case "0":
                {
                    ZZProvinciaEntregaCodigo = "C";
                    break;
                }
                    case "1":
                {
                    ZZProvinciaEntregaCodigo = "B";
                    break;
                }
                    case "2":
                {
                    ZZProvinciaEntregaCodigo = "K";
                    break;
                }
                    case "3":
                {
                    ZZProvinciaEntregaCodigo = "X";
                    break;
                }
                    case "4":
                {
                    ZZProvinciaEntregaCodigo = "W";
                    break;
                }
                    case "5":
                {
                    ZZProvinciaEntregaCodigo = "H";
                    break;
                }
                    case "6":
                {
                    ZZProvinciaEntregaCodigo = "U";
                    break;
                }
                    case "7":
                {
                    ZZProvinciaEntregaCodigo = "E";
                    break;
                }
                    case "8":
                {
                    ZZProvinciaEntregaCodigo = "P";
                    break;
                }
                    case
                    "9":
                {
                    ZZProvinciaEntregaCodigo = "Y";
                    break;
                }
                    case "10":
                {
                    ZZProvinciaEntregaCodigo = "L";
                    break;
                }
                    case "11":
                {
                    ZZProvinciaEntregaCodigo = "F";
                    break;
                }
                    case "12":
                {
                    ZZProvinciaEntregaCodigo = "M";
                    break;
                }
                    case "13":
                {
                    ZZProvinciaEntregaCodigo = "N";
                    break;
                }
                    case "14":
                {
                    ZZProvinciaEntregaCodigo = "Q";
                    break;
                }
                    case "15":
                {
                    ZZProvinciaEntregaCodigo = "R";
                    break;
                }
                    case "16":
                {
                    ZZProvinciaEntregaCodigo = "A";
                    break;
                }
                    case "17":
                {
                    ZZProvinciaEntregaCodigo = "J";
                    break;
                }
                    case "18":
                {
                    ZZProvinciaEntregaCodigo = "D";
                    break;
                }
                    case "19":
                {
                    ZZProvinciaEntregaCodigo = "Z";
                    break;
                }
                    case "20":
                {
                    ZZProvinciaEntregaCodigo = "S";
                    break;
                }
                    case "21":
                {
                    ZZProvinciaEntregaCodigo = "G";
                    break;
                }
                    case "22":
                {
                    ZZProvinciaEntregaCodigo = "T";
                    break;
                }
                    case "23":
                {
                    ZZProvinciaEntregaCodigo = "V";
                    break;
                }
            }

            return ZZProvinciaEntregaCodigo.Trim();
        }

        private string _TraerTipoPed(string WPedido)
        {
            string WTipoPed = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(TipoPed, '') TipoPed FROM Pedido WHERE Pedido = '" + WPedido.Trim() + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WTipoPed = dr["TipoPed"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar el Tipo de Pedido desde la Base de Datos del Pedido '" + WPedido + "'. Motivo: " + ex.Message);
            }

            return WTipoPed.Trim();
        }

        private string _TraerProveedorChofer()
        {
            string WProveedor = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(Proveedor, '') Proveedor FROM Chofer WHERE Codigo = '" + txtChofer.Text + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WProveedor = dr["Proveedor"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el Cuit del Chofer desde la Base de Datos. Motivo: " + ex.Message);
            }

            return WProveedor.Trim();
        }

        private string _TraerCuitProveedor(string WProveedor)
        {
            string WCuitProveedor = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(Cuit, '') Cuit FROM Proveedor WHERE Proveedor = '" + WProveedor + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WCuitProveedor = dr["Cuit"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el Cuit del Chofer desde la Base de Datos. Motivo: " + ex.Message);
            }

            return WCuitProveedor.Replace("-", "").Replace(" ", "").Trim();
        }

        private string _TraerPatenteCamion()
        {
            string WPatente = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(Patente, '') Patente FROM Camion WHERE Codigo = '" + txtCamion.Text + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WPatente = dr["Patente"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la patente del Camión desde la Base de Datos. Motivo: " + ex.Message);
            }

            return WPatente.Replace(" ", "").Replace("/", "").Trim();
        }

        private double _TraerCambioDolarHoy()
        {
            double WDolar = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Cambio FROM Cambios WHERE Fecha = '" + txtFecha.Text + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WDolar = double.Parse(dr["Cambio"].ToString());
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el Cambio para la fecha '" + txtFecha.Text + "' a la Base de Datos. Motivo: " + ex.Message);
            }

            return WDolar;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var WProcess = Process.GetProcessesByName("GenerarCot");

            if (WProcess.Length == 0)
            {
                timer1.Stop();
                txtNroHoja_KeyDown(null, new KeyEventArgs(Keys.Enter));
            }
        }
    }
}