using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

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

        public static void Limpiar(TextBox[] controles)
        {
            foreach (TextBox txt in controles)
            {
                txt.Text = "";
            }
        }

        public static void Limpiar(ComboBox[] controles)
        {
            foreach (ComboBox cmb in controles)
            {
                if (cmb.Items.Count == 0) continue;

                cmb.SelectedIndex = 0;
            }
        }

        public static void Limpiar(MaskedTextBox[] controles)
        {
            foreach (MaskedTextBox msk in controles)
            {
                msk.Clear();
            }
        }

        public static void Limpiar(DataGridView[] controles)
        {
            foreach (DataGridView dgv in controles)
            {
                dgv.DataSource = null;
                dgv.Rows.Clear();
            }
        }

        public static void _ReprocesoCursosProgramadosYNoProgramados(string DesdeFecha, string HastaFecha,
            string DesdeCurso = "1", string HastaCurso = "9999")
        {
            _ReprocesoCursosProgramadosYNoProgramados(DesdeFecha, HastaFecha, int.Parse(DesdeCurso), int.Parse(HastaCurso));
        }

        public static void _ReprocesoCursosProgramadosYNoProgramadosII(string DesdeFecha, string HastaFecha, int DesdeCurso = 1, int HastaCurso = 9999)
        {
            string WDesde = OrdenarFecha(DesdeFecha);
            string WHasta = OrdenarFecha(HastaFecha);

            Cursada Cur = new Cursada();

            DataTable dtCursadas = Cur.ListarCursadaCons3(WDesde, WHasta, DesdeCurso, HastaCurso);

            int Desde = int.Parse(WDesde.Substring(0, 4));
            int Hasta = int.Parse(WHasta.Substring(0, 4));

            int Año = Desde;

            if (Año > Hasta) Año = Hasta;

            DataTable WLegajos = (new DataView(dtCursadas)).ToTable(true, "Legajo");
            DataTable WCursos = (new DataView(dtCursadas)).ToTable(true, "Curso");

            Cronograma Cr = new Cronograma();

            foreach (DataRow WLegajo in WLegajos.Rows)
            {
                foreach (DataRow WCurso in WCursos.Rows)
                {
                    DataRow[] WCursosPorLegajo = dtCursadas.Select("Legajo = '" + WLegajo["Legajo"] + "' And Curso = '" + WCurso["Curso"] + "'");

                    foreach (DataRow WCursoLegajo in WCursosPorLegajo)
                    {
                        int Valor = 0;

                        if (!Cr.ExisteEnCronograma(Año.ToString(), WLegajo["Legajo"].ToString(), WCurso["Curso"].ToString())) Valor = 1;

                        Cur.ModificarCursadaConsolII(Valor, WCursoLegajo["Curso"].ToString(), WLegajo["Legajo"].ToString(), Año);
                    }
                }

            }
        }

        public static void _ReprocesoCursosProgramadosYNoProgramados(string DesdeFecha, string HastaFecha, int DesdeCurso = 1, int HastaCurso = 9999)
        {
            string WDesde = OrdenarFecha(DesdeFecha);
            string WHasta = OrdenarFecha(HastaFecha);

            Cursada Cur = new Cursada();

            DataTable dtCursadas = Cur.ListarCursadaCons3(WDesde, WHasta, DesdeCurso, HastaCurso);

            int Desde = int.Parse(WDesde.Substring(0, 4));
            int Hasta = int.Parse(WHasta.Substring(0, 4));

            int Año = Desde;

            if (Año > Hasta) Año = Hasta;

            Cronograma Cr = new Cronograma();

            foreach (DataRow fila in dtCursadas.Rows)
            {
                int Legajo = int.Parse(fila["Legajo"].ToString());
                int Curso = int.Parse(fila["Curso"].ToString());
                string Clave = fila["Clave"].ToString();

                int Valor = 0;

                if (!Cr.ExisteEnCronograma(Año, Legajo, Curso)) Valor = 1;

                Cur.ModificarCursadaConsol(Valor, Clave);
            }
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
                    cmd.CommandText = "UPDATE Cursadas SET Ordfecha = Right(Fecha, 4) + '' + SUBSTRING(Fecha, 4, 2) + '' + LEFT(Fecha, 2) WHERE Clave IN (select Clave from Cursadas group by Clave, OrdFecha, Fecha having (len(Replace(OrdFecha, ' ', '')) < 8 Or ISNULL(OrdFecha, '') = '') and len(Replace(Fecha, ' ', '')) = 10)";
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

        public static void ActualizarHorasRealizadas(string WAnioCalendario)
        {
            string WDesde = OrdenarFecha("01/06/" + WAnioCalendario);
            string WHasta = OrdenarFecha("31/05/" + (int.Parse(WAnioCalendario) + 1));

            DataTable WPersonas = new DataTable();

            _ReprocesoCursosProgramadosYNoProgramadosII("01/06/" + WAnioCalendario, "31/05/" + (int.Parse(WAnioCalendario) + 1));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Cronograma SET Realizado = 0 WHERE Ano = '" + WAnioCalendario +"'";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT Clave, Legajo, Curso, Tema, Tema2, Realizado FROM Cronograma WHERE Ano = '" + WAnioCalendario + "' Order by Legajo, Curso";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WPersonas.Load(dr);
                        }
                    }

                    foreach (DataRow WPersona in WPersonas.Rows)
                    {
                        double WRealizado = 0;
                        int WTema = (int) OrDefault(WPersona["Tema"], 0);
                        int WTemaII = (int) OrDefault(WPersona["Tema2"], 0);
                        int WCurso = (int) OrDefault(WPersona["Curso"], 0);

                        /*
                         * En caso de que se encuentre cargado solo un tema generico, buscamos todas las horas cursadas para el curso en general.
                         */

                        if ((WTema == 99 && WTemaII == 0) || (WTemaII == 99 && WTema == 0))
                        {
                            cmd.CommandText = "SELECT SUM(Horas) Realizadas FROM Cursadas WHERE Curso = '" + WCurso + "' And Legajo = '" +
                                              OrDefault(WPersona["Legajo"], "") + "' And OrdFecha BETWEEN '" + WDesde +
                                              "' And '" + WHasta + "'";
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();
                                    WRealizado = double.Parse(OrDefault(dr["Realizadas"], 0).ToString());
                                }
                            }
                        }
                        else
                        {
                            /*
                             * En caso de que se hayan cargado algun valor para los temas busco el acumulado de cada una y lo sumarizo bajo la misma variable.
                             */
                            if (WTema != 0)
                            {
                                cmd.CommandText = "SELECT SUM(Horas) Realizadas FROM Cursadas WHERE Curso = '" + WCurso + "' And Legajo = '" +
                                              OrDefault(WPersona["Legajo"], "") + "' And OrdFecha BETWEEN '" + WDesde +
                                              "' And '" + WHasta + "' And Tema = '" + WTema + "'";
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    if (dr.HasRows)
                                    {
                                        dr.Read();
                                        WRealizado += double.Parse(OrDefault(dr["Realizadas"], 0).ToString());
                                    }
                                }
                            }

                            if (WTemaII != 0)
                            {
                                cmd.CommandText = "SELECT SUM(Horas) Realizadas FROM Cursadas WHERE Curso = '" + WCurso + "' And  Legajo = '" +
                                              OrDefault(WPersona["Legajo"], "") + "' And OrdFecha BETWEEN '" + WDesde +
                                              "' And '" + WHasta + "' And Tema = '" + WTemaII + "'";
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    if (dr.HasRows)
                                    {
                                        dr.Read();
                                        WRealizado += double.Parse(OrDefault(dr["Realizadas"], 0).ToString());
                                    }
                                }
                            }
                        }

                        cmd.CommandText = "UPDATE Cronograma SET Realizado = " + WRealizado.ToString().Replace(',', '.') + " WHERE Clave = '" + WPersona["Clave"] + "'";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        public static void ActualizarCantidadPersonasHoras(string WDesdeFecha, string WHastaFecha)
        {
            string WAnioI = ""; //;
            string WAnioII = "";

            WAnioI = !WDesdeFecha.Contains("/") ? WDesdeFecha.Substring(0, 4) : WDesdeFecha.Substring(6, 4);
            WAnioII = !WHastaFecha.Contains("/") ? WHastaFecha.Substring(0, 4) : WHastaFecha.Substring(6, 4);

            DataTable WPersonas = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE CronogramaII SET Personas = 0, Horas = 0 WHERE Ano BETWEEN '" + WAnioI + "' AND '" + WAnioII + "'";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT Curso, COUNT(distinct legajo) as Cantidad, SUM(horas) as Horas "
                                    + " FROM cronograma WHERE Ano BETWEEN '" + WAnioI + "' AND '" + WAnioII + "' AND Curso IN "
                                    + " (SELECT Curso FROM CronogramaII WHERE Ano BETWEEN '" + WAnioI + "' AND '" + WAnioII + "') "
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
                        cmd.CommandText = "UPDATE CronogramaII SET Personas = " + WPersona["Cantidad"].ToString().Replace(',', '.') + ", Horas = " + WPersona["Horas"].ToString().Replace(',', '.') + " WHERE Ano BETWEEN '" + WAnioI + "' AND '" + WAnioII + "' AND Curso = '" + WPersona["Curso"] + "'";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        public static void ActualizaMarcaImpreListado1(string Año)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Cronograma SET ImpreListado1 = '0'";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT cr.Curso, cr.Ano, cr2.* FROM Cronograma cr INNER JOIN CronogramaII cr2 ON cr2.Ano = cr.Ano WHERE cr.Ano = '" + int.Parse(Año) + "' OR cr.Ano = '" + (int.Parse(Año) + 1) + "'";
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

        public static object OrDefault(object valor, object _default)
        {
            if (valor == null || string.IsNullOrEmpty(valor.ToString())) return _default;
            
            return valor;
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

        public static string FormatoNumerico(object wValor)
        {
            if (wValor == null) wValor = "0";
            return FormatoNumerico(wValor.ToString());
        }

        public static void ActualizarCantidadPersonasHorasCalendarioTentativo(string txtAno)
        {
            DataTable WPersonas = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE CronogramaTentativo SET Personas = 0, Horas = 0 WHERE Ano = '" + txtAno + "'";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT Curso, COUNT(distinct legajo) as Cantidad, SUM(horas) as Horas "
                                    + " FROM cronograma WHERE Ano = '" + txtAno + "' AND Curso IN "
                                    + " (SELECT Curso FROM CronogramaTentativo WHERE Ano = '" + txtAno + "') "
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
                        cmd.CommandText = "UPDATE CronogramaTentativo SET Personas = " + WPersona["Cantidad"].ToString().Replace(',', '.') + ", Horas = " + WPersona["Horas"].ToString().Replace(',', '.') + " WHERE Ano = '" + txtAno + "' AND Curso = '" + WPersona["Curso"] + "'";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        /*
         * Comprobacion muy básica.
         */
        public static bool _FechaValida(string WFecha)
        {
            if (WFecha.Replace("/", "").Trim() == "") return false;
            if (WFecha.Replace(" ", "").Length < 10) return false;

            string WDia = WFecha.Substring(0, 2);
            string WMes = WFecha.Substring(3, 2);
            string WAnio = WFecha.Substring(6, 4);

            if (int.Parse(WDia) < 1 || int.Parse(WDia) > 31) return false;
            if (int.Parse(WMes) < 1 || int.Parse(WMes) > 12) return false;
            if (int.Parse(WAnio) < 1900) return false;

            return true;
        }
    }
}
