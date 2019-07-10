using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.HorasCursadasPorLegajo
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CB_Tipo.SelectedIndex = 0;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            var frm = _PrepararReporte();
            frm.Show();
        }

        private VistaPrevia _PrepararReporte()
        {
            string hastaFecha = "31/05/" + (int.Parse(TB_AñoDesde.Text) + 1);
            string desdeFecha = "01/06/" + TB_AñoDesde.Text;

            Helper.PurgarOrdFechaCursadas();
            Helper._ReprocesoCursosProgramadosYNoProgramados(desdeFecha, hastaFecha, 1);

            string WDesdeOrd = Helper.OrdenarFecha(desdeFecha);
            string WHastaOrd = Helper.OrdenarFecha(hastaFecha);

            DataTable WCursadas = new DataTable();

            progressBar1.Value = 0;
            progressBar1.Visible = true;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Legajo SET Horas = 0, HorasTotal = 0, Puntaje = 9";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText =
                        "SELECT c.Curso, c.Legajo, c.Horas, c.Fecha, c.Clave, c.Tema, l.Descripcion, l.Puntaje, l.FEgreso, Activo = case l.Fegreso WHEN '00/00/0000' THEN 'S' WHEN '  /  /    ' THEN 'S' ELSE 'N' END FROM Cursadas c LEFT OUTER JOIN Legajo l ON L.Codigo = C.Legajo AND L.Renglon = 1 WHERE c.Ordfecha BETWEEN '" + WDesdeOrd + "' And '" + WHastaOrd + "' ORDER BY c.Clave";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WCursadas.Load(dr);
                        }
                    }

                    progressBar1.Maximum = WCursadas.Rows.Count + 10;

                    foreach (DataRow WLegajo in WCursadas.Rows)
                    {
                        string WFEgreso = Helper.OrDefault(WLegajo["FEgreso"].ToString(), "00/00/0000").ToString();

                        WLegajo["Puntaje"] = "0";

                        if (CB_Tipo.SelectedIndex == 1)
                        {
                            if (WFEgreso != "  /  /    " && WFEgreso != "00/00/0000")
                            {
                                WLegajo["Puntaje"] = "9";
                            }
                        }

                        cmd.CommandText = "UPDATE Legajo SET Puntaje = '" + WLegajo["Puntaje"] + "', Horas = Horas +'" + WLegajo["Horas"].ToString().Replace(',', '.') +
                                          "' WHERE Codigo = '" + WLegajo["Legajo"] + "'";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "UPDATE Legajo SET HorasTotal = HorasTotal + '" +
                                          WLegajo["Horas"].ToString().Replace(',', '.') + "' WHERE Descripcion = '" +
                                          WLegajo["Descripcion"] + "'";
                        cmd.ExecuteNonQuery();

                        progressBar1.Increment(1);
                    }

                    //if (CB_Tipo.SelectedIndex == 0)
                    //{
                    //    cmd.CommandText =
                    //        "UPDATE Legajo SET Puntaje = '0' WHERE RIGHT(ISNULL(FEgreso, '00/00/0000'), 4)*1 = 0 Or RIGHT(FEgreso, 4)*1 < " +
                    //       Helper.Right(TB_AñoDesde.Text, 4) + "";
                    //    cmd.ExecuteNonQuery();
                    //    progressBar1.Increment(9);
                    //}

                    //if (CB_Tipo.SelectedIndex == 1)
                    //{
                    //    cmd.CommandText = "UPDATE Legajo SET Puntaje = '9' WHERE ISNULL(FEgreso, '  /  /    ') NOT IN ('00/00/0000', '  /  /    ')";
                    //    cmd.ExecuteNonQuery();
                    //    progressBar1.Increment(9);
                    //}
                }
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new wHorasCursadasPorLegajo(),
                "{Legajo.Renglon} = 1 AND {Legajo.Descripcion} <> '' AND {Legajo.HorasTotal} IN 0 TO 9999 AND {Legajo.Puntaje} = 0");
            return frm;
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_AñoDesde.Focus();
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            var frm = _PrepararReporte();
            frm.Imprimir();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
