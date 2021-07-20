using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

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
            txtDesde.Text = "01/06/" + (DateTime.Now.Year - 1);
            txtHasta.Text = "31/05/" + (DateTime.Now.Year);
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            if (txtHasta.Text.Replace(" ", "").Length < 10 || txtDesde.Text.Replace(" ", "").Length < 10) return;

            var frm = _PrepararReporte();
            frm.Show();
        }

        private VistaPrevia _PrepararReporte()
        {
            string hastaFecha = txtHasta.Text; //"31/05/" + (int.Parse(TB_AñoDesde.Text) + 1);
            string desdeFecha = txtDesde.Text; //"01/06/" + TB_AñoDesde.Text;

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

                    cmd.CommandText = "UPDATE Legajo SET FEgresoOrd = RIGHT(FEgreso, 4) + SUBSTRING(FEgreso, 4,2) + left(FEgreso, 2)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET FIngresoOrd = RIGHT(FIngreso, 4) + SUBSTRING(FIngreso, 4,2) + left(FIngreso, 2)";
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
                }
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            VistaPrevia frm = new VistaPrevia();
            ReportDocument rpt = new wHorasCursadasPorLegajo();
            rpt.SetParameterValue("Desde", txtDesde.Text);
            rpt.SetParameterValue("Hasta", txtHasta.Text);

            frm.CargarReporte(rpt,
                "{Legajo.Renglon} = 1 AND {Legajo.Descripcion} <> '' AND {Legajo.HorasTotal} IN 0 TO 9999 " + (rbTodos.Checked ? "AND ({Legajo.Codigo} < 900 OR {Legajo.Codigo} >= 1000) AND ({Legajo.FEgresoOrd} >= '" + WDesdeOrd + "' OR {Legajo.FEgreso} = '  /  /    ' OR {Legajo.FEgreso} = '00/00/0000') AND {Legajo.FIngresoOrd} <= '" + WHastaOrd + "'" : "AND {Legajo.Puntaje} = 0"));
            return frm;
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            txtDesde.Focus();
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            if (txtHasta.Text.Replace(" ", "").Length < 10 || txtDesde.Text.Replace(" ", "").Length < 10) return;

            var frm = _PrepararReporte();
            frm.Imprimir();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtDesde.Text.Replace(" ", "").Length < 10) return;

                txtHasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtDesde.Text = "";
            }
	        
        }
    }
}
