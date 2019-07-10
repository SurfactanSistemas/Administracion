using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Negocio;

namespace Modulo_Capacitacion.Listados.InformedeCompetenciasNecesidadesPorSector
{
    public partial class Inicio : Form
    {
        Legajo L = new Legajo();
        DataTable dtInforme;
        string Tipo;
        bool Observ = false;

        public Inicio()
        {
            InitializeComponent();

            cmbSectores.DataSource = _TraerSectores();
            cmbSectores.DisplayMember = "Descripcion";
            cmbSectores.ValueMember = "Codigo";
            cmbSectores.SelectedIndex = 0;
        }

        private DataTable _TraerSectores()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Codigo", typeof(int));
            tabla.Columns.Add("Descripcion", typeof(string));

            tabla.Rows.Add(0, "Todos");

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

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = _PrepararReporte();

                frm.Show();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private VistaPrevia _PrepararReporte()
        {
            
            ReportDocument reporte = new imprelegajo();

            if (CB_Observ.SelectedIndex == 1)
            {
                reporte = new imprelegajoii();
            }

            string WFiltroSectores = "{Legajo.Sector} = " + cmbSectores.SelectedValue;

            if (cmbSectores.SelectedIndex == 0)
                WFiltroSectores = "{Legajo.Sector} in 0 to 9999";

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(reporte,
                "{Legajo.Codigo} in 0 to 9999 AND {Legajo.FEgreso} in '' to '00/00/0000' AND " + WFiltroSectores);
            return frm;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CB_Observ.SelectedIndex = 0;
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = _PrepararReporte();

                frm.Imprimir();
                
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
