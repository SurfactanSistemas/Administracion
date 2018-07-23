using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanCapacitacionAnualTentativo
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            var frm = _PrepararReporte();
            progressBar1.Value = 0;
            frm.Show();
        }

        private VistaPrevia _PrepararReporte()
        {
            SqlTransaction trans = null;
            try
            {
                DataTable tabla = new DataTable();
                
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "";
                        cmd.Transaction = trans;

                        // Busco los datos de los legajos que tengan algun tema que en el estado no sea 1, 2 u 8.

                        cmd.CommandText = "SELECT l2.Actual Legajo, Curso FROM Legajo l " +
                                          "INNER JOIN (SELECT MIN(Codigo) Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 " +
                                          "ON l.Descripcion = l2.Descripcion AND l.Codigo = l2.Actual WHERE EstaCurso NOT IN (1, 2, 6, 7, 8) " +
                                          "AND l.Fegreso IN ('  /  /    ', '00/00/0000') Order by Legajo, Renglon";
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                        // Borro Tabla Temporal.

                        progressBar1.Maximum = tabla.Rows.Count + 10;

                        cmd.CommandText = "DELETE FROM CronogramaTentativo";
                        cmd.ExecuteNonQuery();

                        // Grabo los datos.

                        foreach (DataRow row in tabla.Rows)
                        {
                            var WLegajo = row["Legajo"] ?? "";
                            var WCurso = row["Curso"] ?? "";
                            var WClave = txtAno.Text.PadLeft(4, '0') + WLegajo.ToString().PadLeft(4, '0') + WCurso.ToString().PadLeft(4, '0');

                            if (WLegajo.ToString().Trim() == "" || WCurso.ToString().Trim() == "") continue;

                            cmd.CommandText = string.Format("INSERT INTO CronogramaTentativo (Clave, Ano, Curso, Legajo) VALUES ('{0}', '{1}', '{2}', '{3}')", WClave, txtAno.Text, WCurso, WLegajo);
                            cmd.ExecuteNonQuery();

                            progressBar1.Increment(1);
                        }

                        trans.Commit();

                        // Actualizamos los datos de Personas y horas realizadas en tabla Temporal.
                        Helper.ActualizarCantidadPersonasHorasCalendarioTentativo(txtAno.Text);

                        progressBar1.Increment(5);

                        VistaPrevia frm = new VistaPrevia();

                        frm.CargarReporte(new PlanCapacitacionAnualTentativo(), "{CronogramaII.Ano} = " + txtAno.Text + " AND {CronogramaII.Curso} = {Curso.Codigo} AND {Curso.Codigo} > 0");

                        progressBar1.Increment(4);

                        return frm;

                    }

                }

            }
            catch (Exception ex)
            {
                if (trans != null && trans.Connection != null) trans.Rollback();

                throw new Exception("Error al procesar el Calendario Tentativo. Motivo: " + ex.Message);
            }
        
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            var frm = _PrepararReporte();
            progressBar1.Value = 0;
            frm.Imprimir();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) txtAno.Text = "";
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
        }

    }
}
