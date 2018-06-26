using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HojaRuta.Auxiliares
{
    public partial class ConsultaAyuda : Form
    {
        private short WTipoConsulta;

        public ConsultaAyuda(string WTipo = "0")
        {
            InitializeComponent();

            _InicializarAyuda();

            switch (WTipo)
            {
                case "1":
                    {
                        WTipoConsulta = 1;
                        _TraerInformacionConsulta("Camion");
                        break;
                    }
                case "2":
                    {
                        WTipoConsulta = 2;
                        _TraerInformacionConsulta("Chofer");
                        break;
                    }
            }
        }

        private void _InicializarAyuda()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Codigo");
            dt.Columns.Add("Descripcion");

            dt.Rows.Add("1", "CAMIONES");
            dt.Rows.Add("2", "CHOFERES");

            dataGridView1.DataSource = dt;

            DataGridViewColumn column = dataGridView1.Columns["Codigo"];
            if (column != null) column.Visible = false;

            column = dataGridView1.Columns["Descripcion"];
            if (column != null) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            WTipoConsulta = 0;
        }

        private void _TraerInformacionConsulta(string WTabla)
        {
            try
            {
                DataTable tabla = new DataTable();
                dataGridView1.DataSource = null;
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo, LTRIM(RTRIM(UPPER(ISNULL(Descripcion, '')))) Descripcion FROM " + WTabla + " WHERE Descripcion <> '' ORDER BY Descripcion";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                    }
                }

                dataGridView1.DataSource = tabla;

                var column = dataGridView1.Columns["Codigo"];
                if (column != null) column.Visible = true;

                column = dataGridView1.Columns["Descripcion"];
                if (column != null) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void _EnviarConsulta(int index)
        {
            if (index < 0) return;

            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    ((Novedades.HojaRuta)Owner)._RecibirDatosAyuda(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString(), WTipoConsulta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConsultaAyuda_Load(object sender, EventArgs e)
        {
            Location = new Point(Width/2, 15);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _EnviarConsulta(e.RowIndex);
        }

        private void ConsultaAyuda_Shown(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            if (WTipoConsulta > 0) _EnviarConsulta(e.RowIndex);

            if (dataGridView1.CurrentRow != null)
                switch (dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString())
                {
                    case "1":
                    {
                        WTipoConsulta = 1;
                            _TraerInformacionConsulta("Camion");
                            break;
                        }
                    case "2":
                        {
                            WTipoConsulta = 2;
                            _TraerInformacionConsulta("Chofer");
                            break;
                        }
                }
        }
    }
}
