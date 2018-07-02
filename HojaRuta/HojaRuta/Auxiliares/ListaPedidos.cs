using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                                        + " CantidadKilos = (SELECT SUM(CantiLote1+CantiLote2+CantiLote3+CantiLote4+CantiLote5+UltimoCantiLote1+UltimoCantiLote2+UltimoCantiLote3+UltimoCantiLote4+UltimoCantiLote5) from Pedido WHERE Pedido = p.Pedido), CantidadFac = (SELECT SUM(CantidadFac) from Pedido WHERE Pedido = p.Pedido) "
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
            _EnviarPedido(e.RowIndex);
        }

        private void _EnviarPedido(int index)
        {
            if (index < 0) return;

            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    ((Novedades.HojaRuta)Owner)._TraerPedidoDeLista(dataGridView1.CurrentRow.Cells["Pedido"].Value);

                    dataGridView1.CurrentCell = null;
                    dataGridView1.Rows[index].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListaPedidos_Load(object sender, EventArgs e)
        {
            Location = new Point(Width/2, 15);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _EnviarPedido(e.RowIndex);
        }

        private void ListaPedidos_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dataGridView1.DataSource as DataTable;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("CONVERT(Pedido, System.String) LIKE '%{0}%' OR Razon LIKE '%{0}%' OR Tipo LIKE '%{0}%' OR Direccion LIKE '%{0}%'", textBox1.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tabla = dataGridView1.DataSource as DataTable;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Empty;

            textBox1.Text = "";
            textBox1.Focus();
        }
    }
}
