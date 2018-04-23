using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
                    cmd.CommandText = "UPDATE Legajo SET Horas = 0, HorasTotal = 0, Puntaje = 0";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText =
                        "SELECT c.Curso, c.Legajo, c.Horas, c.Fecha, c.Clave, c.Tema, l.Descripcion, l.Puntaje, l.FEgreso, Activo = case l.Fegreso WHEN '00/00/0000' THEN 'S' WHEN '  /  /    ' THEN 'S' ELSE 'N' END FROM Cursadas c, Legajo l WHERE c.Legajo = l.Codigo AND l.Renglon = 1 AND SUBSTRING(c.Fecha, 7, 4) = '" +
                        TB_AñoDesde.Text + "' ORDER BY c.Clave";

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
                        if (CB_Tipo.SelectedIndex == 1)
                        {
                            WLegajo["Puntaje"] = "9";
                        }

                        cmd.CommandText = "UPDATE Legajo SET Horas = Horas +'" + WLegajo["Horas"].ToString().Replace(',', '.') +
                                          "' WHERE Codigo = '" + WLegajo["Legajo"] + "'";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "UPDATE Legajo SET HorasTotal = HorasTotal + '" +
                                          WLegajo["Horas"].ToString().Replace(',', '.') + "' WHERE Descripcion = '" +
                                          WLegajo["Descripcion"] + "'";
                        cmd.ExecuteNonQuery();

                        progressBar1.Increment(1);
                    }

                    if (CB_Tipo.SelectedIndex == 0)
                    {
                        cmd.CommandText =
                            "UPDATE Legajo SET Puntaje = '9' WHERE FEgreso > '00/00/0000' AND SUBSTRING(FEgreso, 7, 4) < '" +
                            TB_AñoDesde.Text + "'";
                        cmd.ExecuteNonQuery();
                        progressBar1.Increment(9);
                    }

                    if (CB_Tipo.SelectedIndex == 1)
                    {
                        cmd.CommandText = "UPDATE Legajo SET Puntaje = '9' WHERE FEgreso NOT IN ('00/00/0000', '  /  /    ')";
                        cmd.ExecuteNonQuery();
                        progressBar1.Increment(9);
                    }
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
