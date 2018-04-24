using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Novedades
{
    public partial class ActualizacionDeCompetenciasYNecesidadesDeCapacitacion : Form
    {
        
        public ActualizacionDeCompetenciasYNecesidadesDeCapacitacion()
        {
            InitializeComponent();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }


        private void IngreDeCursosRealizados_Load(object sender, EventArgs e)
        {
            pnlAyuda.Visible = false;

            rbPerfil.Checked = true;
            _CargarPerfiles();
        }

        private void _CargarPerfiles()
        {
            DataTable perfiles = _TraerPerfiles();

            cmbOrganizar.DataSource = perfiles;
            cmbOrganizar.ValueMember = "Codigo";
            cmbOrganizar.DisplayMember = "Descripcion";
        }

        private DataTable _TraerPerfiles()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    string WFiltrarPorTema = txtTema.Text.Trim() != "" ?  " AND Curso = '" + txtTema.Text + "'" : "";

                    cmd.CommandText = "SELECT DISTINCT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Tarea WHERE Descripcion <> '' " + WFiltrarPorTema + " ORDER BY Descripcion";

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

        private void IngreDeCursosRealizados_Shown(object sender, EventArgs e)
        {
            //txtTema.Focus();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = false;
        }
        
        private void _ActualizarDatosDeOrganizacion()
        {
            if (rbPerfil.Checked)
            {
                _CargarPerfiles();

            }else if (rbSector.Checked)
            {
                _CargarSectores();
            }
        }

        private void _CargarSectores()
        {
            DataTable sectores = _TraerSectores();

            cmbOrganizar.DataSource = sectores;
            cmbOrganizar.ValueMember = "Codigo";
            cmbOrganizar.DisplayMember = "Descripcion";
        }

        private DataTable _TraerSectores()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT DISTINCT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Sector WHERE Descripcion <> '' ORDER BY Descripcion";

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

        private void rbPerfil_Click(object sender, EventArgs e)
        {
            _ActualizarDatosDeOrganizacion();
        }

        private void rbSector_Click(object sender, EventArgs e)
        {
            _ActualizarDatosDeOrganizacion();
        }

        private void txtTema_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _AbrirAyuda();
        }

        private void _AbrirAyuda()
        {
            DataTable temas = _TraerTemas();
            dgvAyuda.DataSource = temas;

            DataGridViewColumn column = dgvAyuda.Columns["Descripcion"];
            if (column != null)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            pnlAyuda.Location = Helper._CentrarH(Width, pnlAyuda);
            pnlAyuda.Visible = true;
            txtFiltrar.Text = "";
            txtFiltrar.Focus();
        }

        private DataTable _TraerTemas()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Codigo, UPPER(LTRIM(RTRIM(Descripcion))) Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Descripcion";

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

        private void txtTema_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtTema.Text.Trim() == "") return;

                _CargarTema();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtTema.Text = "";
            }
	        
        }

        private void _CargarTema()
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT UPPER(RTRIM(LTRIM(Descripcion))) Descripcion FROM Curso WHERE Codigo = '" + txtTema.Text + "'";
                    
                    txtDescTema.Text = "";
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            txtDescTema.Text = dr["Descripcion"].ToString();
                        }
                    }
                }

                _ActualizarDatosDeOrganizacion();

                btnCerrarAyuda.PerformClick();
            }

        
        }

        private void dgvAyuda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            string tema = dgvAyuda.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();

            txtTema.Text = tema;

            btnCerrarAyuda.PerformClick();

            //_CargarTema();

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            _AbrirAyuda();
        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvAyuda.DataSource as DataTable;

            if (tabla != null)
            {
                tabla.DefaultView.RowFilter = string.Format("CONVERT(Codigo, System.String) like '%{0}%' OR CONVERT(Descripcion, System.String) like '%{0}%'", txtFiltrar.Text);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    
                    if (rbPerfil.Checked)
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Legajo WHERE ";

                    if (rbPerfil.Checked)
                        cmd.CommandText = "SELECT ";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                            }
                        }
                    }
                }

            }

        
        }
    }
}
