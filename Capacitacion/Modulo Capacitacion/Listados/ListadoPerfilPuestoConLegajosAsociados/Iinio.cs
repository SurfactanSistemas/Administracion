using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.ListadoPerfilPuestoConLegajosAsociados
{
    public partial class Linio : Form
    {
        public Linio()
        {
            InitializeComponent();

            cmbSectores.DataSource = _TraerSectores();
            cmbSectores.DisplayMember = "Descripcion";
            cmbSectores.ValueMember = "Codigo";
            cmbSectores.SelectedIndex = 0;

            cmbPerfiles.DataSource = _TraerPerfiles();
            cmbPerfiles.DisplayMember = "Descripcion";
            cmbPerfiles.ValueMember = "Codigo";
            cmbPerfiles.SelectedIndex = 0;
        }

        private DataTable _TraerSectores()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Codigo", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Codigo, Descripcion FROM Sector";

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

        private DataTable _TraerPerfiles()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Codigo", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Codigo, Descripcion FROM Tarea WHERE Renglon = 1 and Descripcion <> '' Order by Descripcion";

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

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPorSector.Checked)
                {
                    DataTable perfiles = Util.Clases.Query.GetAll("SELECT DISTINCT Perfil FROM Legajo WHERE Sector = '" + cmbSectores.SelectedValue + "' AND ISNULL(FEgreso, '') in ('', '00/00/0000')", "SurfactanSa");

                    foreach (DataRow perfil in perfiles.Rows)
                    {
                        _ReportarPerfil(int.Parse(perfil[0].ToString()));
                    }
                }
                else
                {
                    _ReportarPerfil(int.Parse(cmbPerfiles.SelectedValue.ToString()));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void _ReportarPerfil(int perfil)
        {
            Negocio.Perfil P = new Negocio.Perfil();

            var Desd = perfil;
            ;
            var Hast = Desd;

            DataTable dtInforme = P.ListarPerfilEsp(Desd, Hast);

            DSInforme Ds = new DSInforme();

            int filas = dtInforme.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtInforme.Rows[i];
                Ds.Tables[0].Rows.Add
                    (dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),
                        dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(),
                        dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), dr[15].ToString(),
                        dr[16].ToString(), dr[17].ToString(), dr[18].ToString(), dr[19].ToString(), dr[20].ToString(),
                        dr[21].ToString(), dr[22].ToString(), dr[23].ToString(), dr[24].ToString(), dr[25].ToString(),
                        dr[26].ToString(), dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), dr[30].ToString(),
                        dr[31].ToString(), dr[32].ToString(), dr[33].ToString(), dr[34].ToString(), dr[35].ToString(),
                        dr[36].ToString(), dr[37].ToString(), dr[38].ToString(), dr[39].ToString(), dr[40].ToString(),
                        dr[41].ToString(), dr[42].ToString(), dr[43].ToString());
            }

            //Instancio el ReportImpre creado
            Reporte RImpre = new Reporte();

            //Cargo el reportImpre con el dataset DS
            RImpre.SetDataSource(Ds);

            VistaPrevia frmII = new VistaPrevia();

            frmII.CargarReporte(RImpre);

            frmII.Show();
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //var frm = _PrepararReporte();

                //frm.Imprimir();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            cmbSectores.Focus();
        }
    }
}
