using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.LegajosConNecesidadesPendientes
{
    public partial class Inicio : Form
    {
        Legajo L = new Legajo();
        
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                TB_Desde.Text = Regex.Replace(TB_Desde.Text, "[^0-9]", "");
                TB_Hasta.Text = Regex.Replace(TB_Hasta.Text, "[^0-9]", "");

                if (TB_Desde.Text == "") TB_Desde.Text = "1";

                if (TB_Hasta.Text == "") TB_Hasta.Text = "9999";

                int Desd;
                int.TryParse(TB_Desde.Text, out Desd);
                int Hast;
                int.TryParse(TB_Hasta.Text, out Hast);
                
                dtInforme = L.LegajoConNecesidades(Desd, Hast);

                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_Hasta.Text == "") TB_Hasta.Text = TB_Desde.Text;
                TB_Hasta.Focus();
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerTemas();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerTemas()
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
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Codigo";

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

        private void TB_Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), "[0-9]") && !char.IsControl(e.KeyChar) && char.IsPunctuation(e.KeyChar);
        }
    }
}
