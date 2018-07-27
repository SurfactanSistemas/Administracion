using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PromediodeCalificacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_DesdeSector.Focus();
        }

        private void TB_DesdeSector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (TB_DesdeSector.Text.Trim() == "") TB_DesdeSector.Text = "0";

                TB_HastaSector.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_DesdeSector.Text = "";
            }
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                VistaPrevia frm = _PrepararReporte();

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private VistaPrevia _PrepararReporte()
        {
            if (TB_DesdeSector.Text.Trim() == "") TB_DesdeSector.Text = "0";
            if (TB_HastaSector.Text.Trim() == "") TB_HastaSector.Text = "9999";

            // Eliminamos posibles nulos, actualizamos descripciones y reseteamos datos.
            _NormalizarDatos();

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new wPromedioCalificacion(), "{Legajo.Renglon} = 1 AND {Legajo.PromedioII} = 1");
            return frm;
        }

        private void _NormalizarDatos()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Legajo SET Legajo.ImprePerfil = Tarea.Descripcion, Legajo.Sector = Tarea.Sector FROM Legajo, Tarea WHERE Legajo.Perfil = Tarea.Codigo";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET Legajo.DesSector = Sector.Descripcion FROM Legajo, Sector WHERE Legajo.Sector = Sector.Codigo";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET Promedio = 0, PromedioII = 0";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET FEgreso = '  /  /    ' WHERE FEgreso IS NULL";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET EstaX = 0 WHERE EstaX IS NULL";
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                VistaPrevia frm = _PrepararReporte();

                frm.Imprimir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerSector();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerSector()
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
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Sector WHERE Descripcion <> '' ORDER BY Codigo";

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
