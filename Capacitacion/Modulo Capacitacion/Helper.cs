using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Modulo_Capacitacion
{
    class Helper
    {

        public static string[] _Empresas = { "SurfactanSA", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII", "Pelitall_II", "Pellital_III", "Pellital_V" };

        private static int WRenglon;

        public static Point _CentrarH(int containerWidth, Control control)
        {
            return new Point(containerWidth / 2 - control.Width / 2, control.Location.Y);
        }

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

        public static string OrdenarFecha(string WFecha)
        {
            string WFechaOrd = "0";

            if (WFecha.Trim().Length == 10)
            {
                string[] items = WFecha.Split('/');

                Array.Reverse(items);

                WFechaOrd = string.Join("", items);
            }

            return WFechaOrd;
        }

        public static string Left(string WTexto, int WLongitud)
        {
            if (WTexto.Length <= WLongitud) return WTexto;

            return WTexto.Substring(0, WLongitud);
        }

        public static string Right(string WTexto, int WLongitud)
        {
            if (WTexto.Length <= WLongitud) return WTexto;

            return WTexto.Substring(WTexto.Length - WLongitud, WLongitud);
        }

        public static string Mid(string WTexto, int WInicio, int WFinal)
        {
            //if (WInicio >= WFinal) return WTexto;

            try
            {
                return WTexto.Substring(WInicio, WFinal);
            }
            catch (Exception)
            {
                return WTexto;
            }
        }

        public static string Ceros(string WTexto, int WLargo)
        {
            return WTexto.PadLeft(WLargo, '0');
        }

        public static string Ceros(int WTexto, int WLargo)
        {
            return Ceros(WTexto.ToString(), WLargo);
        }

        public static string Ceros(object WTexto, int WLargo)
        {
            return Ceros(WTexto.ToString(), WLargo);
        }

        public static string FormatoNumerico(string WValor, int WCantDigitos = 2, string WSeparadorDecimales = ".")
        {
            string WValorArmado = "";

            if (WValor.Trim() == "") WValor = "0";

            // Normalizamos el numero, porque hay casos en que vienen del estilo '.5' o '5.'
            if (WValor.Trim().EndsWith(".")) WValor += "0";
            if (WValor.Trim().EndsWith(".")) WValor += "0";
            if (WValor.Trim().StartsWith(",")) WValor = "0" + WValor;
            if (WValor.Trim().StartsWith(".")) WValor = "0" + WValor;

            WValor = WValor.Replace('.', ',');

            WValor = Math.Round(double.Parse(WValor), WCantDigitos).ToString();

            if (WValor.IndexOf(',') > -1)
            {
                int i = WValor.IndexOf(',');

                WValorArmado = WValor.Substring(0, i);

                WValorArmado += WSeparadorDecimales;

                string WDecimales = WValor.Substring(i + 1, WValor.Length - i - 1);

                return WValorArmado + WDecimales.PadRight(WCantDigitos, '0');
            }

            return (WValor.Trim() + ".") + "".PadRight(WCantDigitos, '0');
        }

        public static string FormatoNumerico(double wValor, int WCantDigitos = 2)
        {
            return FormatoNumerico(wValor.ToString(), WCantDigitos);
        }

        public static object FormatoNumerico(object wValor)
        {
            if (wValor == null) wValor = "0";
            return FormatoNumerico(wValor.ToString());
        }
    }
}
