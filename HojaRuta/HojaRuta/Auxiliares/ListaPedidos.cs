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

namespace HojaRuta.Auxiliares
{
    public partial class ListaPedidos : Form
    {
        public ListaPedidos(int WTipoPedido)
        {
            InitializeComponent();

            _TraerPedidosSegunTipo(WTipoPedido);
        }

        private void _TraerPedidosSegunTipo(int wTipoPedido)
        {
            try
            {
                DataTable tabla = new DataTable();
                string WTipos = "";
                switch (wTipoPedido)
                {
                    case 1:
                    {
                        WTipos = "2,3";
                        break;
                    }
                    case 2:
                    {
                        WTipos = "1";
                        break;
                    }
                    case 3:
                    {
                        WTipos = "4";
                        break;
                    }
                    case 4:
                    {
                        WTipos = "5";
                        break;
                    }
                    default:
                    {
                        WTipos = "1,2,3,4,5";
                        break;
                    }
                }

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = " SELECT DISTINCT p.Pedido, c.Razon, Tipo = CASE p.TipoPed WHEN 5 THEN 'Muestra' ELSE 'Pedido' END, "
                                        + " Dire = CASE p.DirEntrega WHEN 1 THEN c.DirEntrega WHEN 2 THEN c.DirEntregaII WHEN 3 THEN c.DirEntregaIII WHEN 4 THEN c.DirEntregaIV ELSE c.DirEntregaV END, "
                                        + " CantidadKilos = (SELECT SUM(CantiLote1+CantiLote2+CantiLote3+CantiLote4+CantiLote5+UltimoCantiLote1+UltimoCantiLote2+UltimoCantiLote3+UltimoCantiLote4+UltimoCantiLote5) from Pedido WHERE Pedido = p.Pedido), p.CantidadFac "
                                        + " FROM pedido p, cliente c WHERE p.Cliente = c.Cliente AND p.TipoPedido IN (" + WTipos + ") AND p.Tipoped <> 4 AND p.pedido > 326800 AND p.HojaRuta = 0 AND (p.CantidadFac <> 0 OR p.Cantidad > p.Facturado) AND p.Autorizo = 'X' AND p.Cliente <> 'P00005' ORDER BY p.Pedido";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                    }

                }

                tabla.Columns.Add("Kilos");
                tabla.Columns.Add("Direccion");

                foreach (DataRow row in tabla.Rows)
                {
                    row["Kilos"] = row["CantidadKilos"];
                    row["Direccion"] = row["Dire"];

                    if (row["Kilos"].ToString() == "0")
                    {
                        row["Kilos"] = row["CantidadFac"];
                    }
                }

                dataGridView1.DataSource = tabla;

                foreach (string c in new[] { "CantidadKilos", "UltimoCantidadKilos", "CantidadFac", "Dire" })
                {
                    DataGridViewColumn column = dataGridView1.Columns[c];
                    if (column != null)
                        column.Visible = false;
                }

                foreach (DataGridViewColumn WCol in dataGridView1.Columns)
                {
                    WCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                var viewColumn = dataGridView1.Columns["Razon"];
                if (viewColumn != null)
                    viewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                ((Novedades.HojaRuta) Owner).Prueba(dataGridView1.CurrentRow.Cells["Pedido"].Value);
        }

        private void ListaPedidos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Width/2, 15);
        }
    }
}
