using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.EvoluciondeTemasProgramados
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            var frm = _PrepararReporte();
            frm.Show();
        }

        private VistaPrevia _PrepararReporte()
        {
            string WMes = TB_Mes.Text.PadLeft(2, '0');
            string WAno = TB_Año.Text;

            string WDesdeFecha = WAno + "0131";
            string WHastaFecha = WAno + WMes + "31";

            string ZCurso = "";
            int ZPersonas = 0, ZPersonasRealizado = 0, ZPersonasRealizadoII = 0, ZMesesI = 0, ZMesesII = 0, ZPaso = 0;
            double ZHoras = 0, ZHorasRealizado = 0, ZHorasRealizadoII = 0, ZHorasII = 0, ZHorasRealizadosIII = 0;
            string ZCorte = "";

            DataTable WCronogramaII = new DataTable();

            DataTable WCronograma = new DataTable();
            WCronograma.Columns.Add("Legajo", typeof (string));
            WCronograma.Columns.Add("Curso", typeof (string));
            WCronograma.Columns.Add("Horas", typeof (double));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    WCronogramaII.Rows.Clear();

                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT Curso, Mes1, Mes2, Mes3, Mes4, Mes5, Mes6, Mes7, Mes8, Mes9, Mes10, Mes11, Mes12 FROM CronogramaII WHERE Ano = '" +
                        WAno + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WCronogramaII.Load(dr);
                        }
                    }

                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = WCronogramaII.Rows.Count;

                    Helper.ActualizarTipoCursada(ref progressBar1);

                    foreach (DataRow WCurso in WCronogramaII.Rows)
                    {
                        ZPersonas = 0;
                        ZHoras = 0;
                        ZPersonasRealizado = 0;
                        ZHorasRealizado = 0;
                        ZHorasII = 0;
                        ZPersonasRealizadoII = 0;
                        ZHorasRealizadoII = 0;
                        ZMesesI = 0;
                        ZMesesII = 0;
                        ZCorte = "";

                        ZCurso = WCurso["Curso"].ToString();
                        //string ZAno = WCurso["Ano"].ToString();

                        cmd.CommandText = "SELECT Legajo, Curso, Horas, Realizado FROM Cronograma WHERE Curso = '" + ZCurso +
                                          "' AND Ano = '" + WAno + "' ORDER BY Legajo, Curso";

                        WCronograma.Rows.Clear();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string TempRealizado = dr["Realizado"] == null ? "0" : dr["Realizado"].ToString();
                                    string TempHoras = dr["Horas"] == null ? "0" : dr["Horas"].ToString();

                                    if (ZCorte != dr["Legajo"].ToString())
                                    {
                                        ZPersonas++;
                                        if (double.Parse(TempRealizado) > double.Parse(TempHoras)) ZPersonasRealizado++;
                                        ZCorte = dr["Legajo"].ToString();
                                    }

                                    ZHoras += double.Parse(TempHoras);
                                    ZHorasRealizado += double.Parse(TempRealizado);

                                    DataRow ZRow = WCronograma.NewRow();

                                    ZRow["Legajo"] = dr["Legajo"] == null ? "0" : dr["Legajo"].ToString();
                                    ZRow["Curso"] = dr["Curso"] == null ? "0" : dr["Curso"].ToString();
                                    ZRow["Horas"] = dr["Horas"] == null ? "0" : dr["Horas"].ToString();

                                    WCronograma.Rows.Add(ZRow);
                                }
                            }
                        }

                        for (int i = 1; i < 12; i++)
                        {
                            string XMes = WCurso["Mes" + i].ToString();

                            if (XMes.ToUpper() == "X")
                            {
                                ZMesesI++;

                                if (int.Parse(i.ToString()) <= int.Parse(WMes)) ZMesesII++;
                            }
                        }

                        ZCorte = "";
                        ZPersonasRealizadoII = 0;

                        foreach (DataRow XCurso in WCronograma.Rows)
                        {
                            ZHorasRealizadosIII = 0;
                            ZCurso = XCurso["Curso"].ToString();

                            cmd.CommandText =
                                "SELECT isnull(Horas, 0) as Horas FROM Cursadas WHERE TIpoCursada = 0 AND Legajo = '" +
                                XCurso["Legajo"] + "' AND Curso = '" + ZCurso + "' AND OrdFecha BETWEEN " + WDesdeFecha +
                                " AND " + WHastaFecha + " ORDER BY Legajo";

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        ZHorasRealizadoII += double.Parse(dr["Horas"].ToString());
                                        ZHorasRealizadosIII += double.Parse(dr["Horas"].ToString());
                                    }
                                }
                            }

                            if (ZCorte != XCurso["Legajo"].ToString())
                            {
                                ZCorte = XCurso["Legajo"].ToString();
                                if (ZHorasRealizadosIII >= double.Parse(XCurso["Horas"].ToString()))
                                {
                                    ZPersonasRealizadoII++;
                                }
                            }
                        }

                        ZHorasII = 0;

                        if (ZMesesI != 0)
                        {
                            ZHorasII = Math.Round((ZHoras/ZMesesI)*ZMesesII, 0);
                        }

                        double ZPorce = 0, ZPorceII = 0;

                        if (ZHorasII != 0)
                        {
                            ZPorce = ZHorasRealizadoII/(ZHorasII/100);
                        }

                        cmd.CommandText = "UPDATE CronogramaII SET "
                                          + " Personas = '" + ZPersonas + "',"
                                          + " PersonasRealizado = '" + ZPersonasRealizado + "',"
                                          + " PersonasRealizadoII = '" + ZPersonasRealizadoII + "',"
                                          + " Horas = '" + ZHoras.ToString().Replace(',', '.') + "',"
                                          + " HorasII = '" + ZHorasII.ToString().Replace(',', '.') + "',"
                                          + " HorasRealizado = '" + ZHorasRealizado.ToString().Replace(',', '.') + "',"
                                          + " HorasRealizadoII = '" + ZHorasRealizadoII.ToString().Replace(',', '.') + "',"
                                          + " Mes = '" + TB_Mes.Text + "',"
                                          + " Porce = '" + ZPorce.ToString().Replace(',', '.') + "',"
                                          + " PorceII = '" + ZPorceII.ToString().Replace(',', '.') + "'"
                                          + " WHERE Ano = '" + WAno + "'"
                                          + " AND "
                                          + " Curso = '" + ZCurso + "'";

                        cmd.ExecuteNonQuery();

                        progressBar1.Increment(1);
                    }
                }
            }

            progressBar1.Visible = false;

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new wlistaevolucionTemasProgramados(),
                "{CronogramaII.Curso} = {Curso.Codigo} AND {CronogramaII.Ano} In " + WAno + " To " + WAno);
            return frm;
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Mes.Focus();
        }

        private void TB_Mes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TB_Año.Focus();
            if (e.KeyCode == Keys.Escape) TB_Mes.Text = "";
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            var frm = _PrepararReporte();
            frm.Imprimir();
        }
    }
}
