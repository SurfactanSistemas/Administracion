using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Negocio;

namespace Modulo_Capacitacion.Listados.InformedeCompetencias
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
            if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el perfil desde el que desea comenzar la busqueda");

            if (TB_Hasta.Text == "") TB_Hasta.Text = TB_Desde.Text;

            int Desd;
            int.TryParse(TB_Desde.Text, out Desd);
            int Hast;
            int.TryParse(TB_Hasta.Text, out Hast);

            ReportDocument reporte = new imprelegajo();

            if (CB_Observ.SelectedIndex == 1)
            {
                reporte = new imprelegajoii();
            }

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(reporte,
                "{Legajo.Codigo} in " + Desd + " to " + Hast + " AND {Legajo.FEgreso} in '' to '00/00/0000'");
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

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Hasta.Focus();
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerLegajos();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerLegajos()
        {

            try
            {
                DataTable tabla = new DataTable();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Legajo.Codigo, Legajo.Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON Legajo.Descripcion = l2.Descripcion WHERE Legajo.FEgreso IN ('  /  /    ', '00/00/0000') AND Legajo.Renglon = 1 AND Legajo.Descripcion <> '' AND Legajo.Codigo = l2.Actual ORDER BY Legajo.Codigo";

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
    }
}
