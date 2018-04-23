using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion
{
    class Helper
    {
        private static int WRenglon;

        public static void PurgarOrdFechaCursadas()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Cursadas SET Ordfecha = '0' WHERE Clave IN (select Clave from Cursadas group by Clave, OrdFecha having len(Replace(OrdFecha, ' ', '')) < 8)";
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static void ActualizarTipoCursada()
        {
            WRenglon = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(Clave) as Total FROM Cursadas";

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        //Array.Resize(ref WValores, int.Parse(dr["Total"].ToString()));
                        int WTotal = int.Parse(dr["Total"].ToString());

                        string[,] WValores = new string[WTotal, 4];

                        if (!dr.IsClosed) dr.Close();

                        cmd.CommandText = "UPDATE Cursadas SET TipoCursada = 0";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT Curso, Legajo, Clave, Ano FROM Cursadas";

                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                WValores[WRenglon, 0] = dr["Clave"].ToString();
                                WValores[WRenglon, 1] = dr["Legajo"].ToString();
                                WValores[WRenglon, 2] = dr["Curso"].ToString();
                                WValores[WRenglon, 3] = dr["Ano"].ToString();

                                WRenglon++;
                            }

                        }

                        if (!dr.IsClosed) dr.Close();

                        for (int i = 0; i < WRenglon - 1; i++)
                        {
                            cmd.CommandText = "SELECT Legajo FROM Cronograma WHERE Legajo = '" + WValores[i, 1] + "' AND Curso = '" + WValores[i, 2] + "' AND Ano = '" + WValores[i, 3] + "'";

                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                if (!dr.IsClosed) dr.Close();

                                cmd.CommandText = "UPDATE Cursadas SET TipoCursada = '1' WHERE Clave = '" + WValores[i, 0] + "'";
                                cmd.ExecuteNonQuery();
                            }

                            if (!dr.IsClosed) dr.Close();

                        }

                    }
                }

            }
        }

        public static void ActualizarTipoCursada(ref ProgressBar pgb, bool WResetearBarra = false)
        {
            WRenglon = 0;
            pgb.Value = WResetearBarra ? 0 : pgb.Value;
            pgb.Visible = true;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(Clave) as Total FROM Cursadas";

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        //Array.Resize(ref WValores, int.Parse(dr["Total"].ToString()));
                        int WTotal = int.Parse(dr["Total"].ToString());

                        pgb.Maximum = WResetearBarra ? WTotal : pgb.Maximum + WTotal;

                        string[,] WValores = new string[WTotal, 4];

                        if (!dr.IsClosed) dr.Close();

                        cmd.CommandText = "UPDATE Cursadas SET TipoCursada = 0";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT Curso, Legajo, Clave, Ano FROM Cursadas";

                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                WValores[WRenglon, 0] = dr["Clave"].ToString();
                                WValores[WRenglon, 1] = dr["Legajo"].ToString();
                                WValores[WRenglon, 2] = dr["Curso"].ToString();
                                WValores[WRenglon, 3] = dr["Ano"].ToString();

                                WRenglon++;
                            }

                        }

                        if (!dr.IsClosed) dr.Close();

                        string WClaves = "";

                        for (int i = 0; i < WRenglon - 1; i++)
                        {
                            cmd.CommandText = "SELECT Legajo FROM Cronograma WHERE Legajo = '" + WValores[i, 1] + "' AND Curso = '" + WValores[i, 2] + "' AND Ano = '" + WValores[i, 3] + "'";

                            dr = cmd.ExecuteReader();

                            if (!dr.HasRows)
                            {
                                WClaves += "'" + WValores[i,0] + "',";
                            }

                            if (!dr.IsClosed) dr.Close();

                            pgb.Increment(1);

                        }

                        if (WClaves.EndsWith(",")) WClaves = WClaves.Substring(0, WClaves.Length - 1);

                        WClaves = "(" + WClaves + ")";

                        cmd.CommandText = "UPDATE Cursadas SET TipoCursada = '1' WHERE Clave IN " + WClaves + "";
                        cmd.ExecuteNonQuery();

                    }
                }

            }

        }

        public static void ActualizarCantidadPersonasHoras(string txtAno)
        {
            DataTable WPersonas = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE CronogramaII SET Personas = 0, Horas = 0 WHERE Ano = '" + txtAno + "'";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT Curso, COUNT(distinct legajo) as Cantidad, SUM(horas) as Horas "
                                    + " FROM cronograma WHERE Ano = '" + txtAno + "' AND Curso IN "
                                    + " (SELECT Curso FROM CronogramaII WHERE Ano = '" + txtAno + "') "
                                    + " GROUP BY Curso";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WPersonas.Load(dr);
                        }
                    }

                    foreach (DataRow WPersona in WPersonas.Rows)
                    {
                        cmd.CommandText = "UPDATE CronogramaII SET Personas = " + WPersona["Cantidad"].ToString().Replace(',', '.') + ", Horas = " + WPersona["Horas"].ToString().Replace(',', '.') + " WHERE Ano = '" + txtAno + "' AND Curso = '" + WPersona["Curso"] + "'";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }
    }
}
