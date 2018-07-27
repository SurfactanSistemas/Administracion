using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PlanilladeTemasnoProgramados
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Mes.Focus();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            if (TB_Año.Text.Trim() != "" && TB_Mes.Text.Trim() != "")
            {
                var frm = _PrepararReporte();
                frm.Show();
            }
        }

        private VistaPrevia _PrepararReporte()
        {
            Helper.ActualizarTipoCursada(ref progressBar1);

            TB_Mes.Text = TB_Mes.Text.PadLeft(2, '0');
            _ActualizarHorasCursadasNoProgramadas(TB_Año.Text, TB_Mes.Text);


            string WDesde = TB_Año.Text + "0131";
            string WHasta = TB_Año.Text + TB_Mes.Text.PadLeft(2, '0') + "31";

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new PlanillaTemasNoProgramados(),
                "{Cursadas.Curso} = {Curso.Codigo} AND {Cursadas.TipoCursada} = 1 AND {Cursadas.OrdFecha} in '" + WDesde +
                "' to '" + WHasta + "'");
            return frm;
        }

        private void _ActualizarHorasCursadasNoProgramadas(string WAno, string WMes)
        {
            string WDesde = "", WHasta = "";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Cursadas SET Horas1 = 0,Horas2 = 0,Horas3 = 0,Horas4 = 0,Horas5 = 0,Horas6 = 0,Horas7 = 0,Horas8 = 0,Horas9 = 0,Horas10 = 0,Horas11 = 0, Horas12 = 0, Ano = '" + WAno + "'";
                    cmd.ExecuteNonQuery();

                    for (int i = 1; i <= int.Parse(WMes); i++)
                    {
                        WDesde = WAno + i.ToString().PadLeft(2, '0') + "01";
                        WHasta = WAno + i.ToString().PadLeft(2, '0') + "31";

                        cmd.CommandText = "UPDATE Cursadas SET Horas" + i + "=Horas WHERE TipoCursada = 1 AND OrdFecha >= '" + WDesde + "' AND  OrdFecha <= '" + WHasta + "'";
                        cmd.ExecuteNonQuery();
                    }
                }

            }

            progressBar1.Visible = false;
            
        }

        private void TB_Mes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Año.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Mes.Text = "";
            }
        }

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TB_Año.Text = "";
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            if (TB_Año.Text.Trim() != "" && TB_Mes.Text.Trim() != "")
            {
                var frm = _PrepararReporte();
                frm.Imprimir();
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
