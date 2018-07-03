using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HojaRuta.Novedades
{
    public partial class ConsultaHojaRutaCliente : Form
    {
        public ConsultaHojaRutaCliente()
        {
            InitializeComponent();
        }

        private void ConsultaHojaRutaCliente_Shown(object sender, EventArgs e)
        {
            txtFecha.Focus();
        }

        private void txtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtFecha.Text.Replace("/", "").Trim() == "") return;

                dvgHojas.Rows.Clear();

                DataTable WHojas = _TraerHojasPorFecha(txtFecha.Text);

                foreach (DataRow row in WHojas.Rows)
                {
                    var WHoja = row["Hoja"] ?? "";
                    var WPedido = row["Pedido"] ?? "";
                    var WCliente = row["Cliente"] ?? "";
                    var WRazon = row["Razon"] ?? "";
                    var WRemito = row["Remito"] ?? "";
                    var WFactura = row["Factura"] ?? "0";
                    var WCantidad = "";

                    DataTable WDatos = int.Parse(WFactura.ToString()) > 0 ? _TraerCantidadDesdeEstadisticas(WFactura, WCliente) : _TraerCantidadDesdePedido(WPedido);

                    foreach (DataRow _r in WDatos.Rows)
                    {
                        int i = dvgHojas.Rows.Add();

                        DataGridViewRow r = dvgHojas.Rows[i];

                        r.Cells["Hoja"].Value = WHoja;
                        r.Cells["Factura"].Value = WFactura;
                        r.Cells["Remito"].Value = WRemito;
                        r.Cells["Pedido"].Value = WPedido;
                        r.Cells["Razon"].Value = WRazon;
                        r.Cells["Producto"].Value = _r["Codigo"] ?? "";
                        r.Cells["Cliente"].Value = _r["Cliente"] ?? "";
                        r.Cells["Descripcion"].Value = "";

                        if (int.Parse(WFactura.ToString()) > 0)
                        {
                            WCantidad = _r["Cantidad"].ToString();
                        }
                        else
                        {
                            WCantidad = _r["CantiLote"].ToString();

                            if (int.Parse(WCantidad) == 0)
                            {
                                WCantidad = _r["CantidadFac"].ToString();
                            }

                            if (int.Parse(WCantidad) == 0)
                            {
                                WCantidad = _r["Cantidad"].ToString();
                            }
                        }

                        r.Cells["Kilos"].Value = Helper.FormatoNumerico(WCantidad);
                    }

                }

                foreach (DataGridViewRow row in dvgHojas.Rows)
                {
                    var WCodigo = row.Cells["Producto"].Value ?? "";

                    if (WCodigo.ToString().Trim() == "") continue;

                    if (Helper.Left(WCodigo.ToString(), 2) != "PT")
                    {
                        row.Cells["Descripcion"].Value = _TraerDescripcionMP(WCodigo);
                    }
                    else
                    {
                        var WCliente = row.Cells["Cliente"].Value ?? "";
                        row.Cells["Descripcion"].Value = _TraerDescripcionPT(WCodigo, WCliente);
                    }
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                txtFecha.Text = "";
            }
	        
        }

        private string _TraerDescripcionPT(object wCodigo, object wCliente)
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
                        cmd.CommandText = "SELECT RTRIM(LTRIM(ISNULL(Descripcion, ''))) Descripcion FROM Precios WHERE Terminado = '" + wCodigo + "' AND Cliente = '" + wCliente + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                return dr["Descripcion"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return "";
        }

        private string _TraerDescripcionMP(object wCodigo)
        {
            var ZCodigo = Helper.Left(wCodigo.ToString(), 3);
            ZCodigo += Helper.Right(wCodigo.ToString(), 7);

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT RTRIM(LTRIM(ISNULL(Descripcion, ''))) Descripcion FROM Articulo WHERE Codigo = '" + ZCodigo + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                return dr["Descripcion"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return "";
        }

        private DataTable _TraerCantidadDesdePedido(object wPedido)
        {
            try
            {
                DataTable tabla = new DataTable();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Cliente, Terminado Codigo, CantiLote = (CantiLote1 + CantiLote2 + CantiLote3 + CantiLote4 + CantiLote5), ISNULL(CantidadFac, 0) CantidadFac, ISNULL(Cantidad, 0) Cantidad " +
                                          " FROM Pedido WHERE Pedido = '" + wPedido + "'";

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
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private DataTable _TraerCantidadDesdeEstadisticas(object wFactura, object wCliente)
        {

            try
            {
                DataTable tabla = new DataTable();

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Articulo as Codigo, ISNULL(Cantidad, 0) Cantidad, Cliente FROM Estadistica WHERE Numero = '" + wFactura + "' and Estadistica.Cliente = '" + wCliente + "'";

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
            catch (Exception ex)
            {
                throw new Exception("Error al traer las cantidades desde la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private DataTable _TraerHojasPorFecha(string WFecha)
        {
            try
            {
                DataTable tabla = new DataTable();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT hr.Hoja, hr.Pedido, hr.Cliente, hr.Razon, p.Remito, p.TipoPedido, ISNULL(cc.Numero, 0) Factura FROM HojaRuta hr LEFT OUTER JOIN Pedido p ON hr.Pedido = p.Pedido LEFT OUTER JOIN CtaCte cc ON hr.Pedido = cc.Pedido WHERE hr.Fecha = '" + WFecha + "'";

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
            catch (Exception ex)
            {
                throw new Exception("Error al intentar traer las Hojas de Ruta desde la Base de Datos, para la Fecha indicada. Motivo: " + ex.Message);
            }
        
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
