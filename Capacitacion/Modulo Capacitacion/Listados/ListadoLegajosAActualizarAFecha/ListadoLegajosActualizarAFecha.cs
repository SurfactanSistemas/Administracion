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
using CrystalDecisions.CrystalReports.Engine;

namespace Modulo_Capacitacion.Listados.ListadoLegajosAActualizarAFecha
{
    public partial class ListadoLegajosActualizarAFecha : Form
    {
        public ListadoLegajosActualizarAFecha()
        {
            InitializeComponent();
        }

        private void ListadoLegajosActualizarAFecha_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFecha.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtFecha.Text.Replace(" ", "").Length < 10) return;

            DataTable legajos = _TraerLegajos();

            VistaPrevia frm = new VistaPrevia();

            ReportDocument rpt = new ReporteListadoLegajosAActualizarAFecha();
            rpt.SetDataSource(legajos);
            rpt.SetParameterValue("Fecha", txtFecha.Text);

            frm.CargarReporte(rpt);
            frm.Show(this);
        }

        private DataTable _TraerLegajos()
        {
            DataTable tabla = new DBAuxi().ListadoTentativo;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                cn.Open();

                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;

                    //string WDate = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                    string WDate = txtFecha.Text.Substring(6, 4) + "-" +
                                   txtFecha.Text.Substring(3, 2) + "-" +
                                   txtFecha.Text.Substring(0, 2);

                    cm.CommandText = "SELECT l.Codigo Legajo, l.Descripcion DescLegajo, l.Sector, s.Descripcion DescSector FROM Legajo l LEFT OUTER JOIN Sector s ON s.Codigo = l.Sector WHERE l.Renglon = 1 And ISNULL(l.FEgreso, '  /  /    ') IN ('00/00/0000', '  /  /    ') And ISNULL(WDate, '0000-00-00') < '" + WDate + "' Order by l.Descripcion";

                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.HasRows) tabla.Load(dr);
                    }
                }
            }

            return tabla;
        }

        private void ListadoLegajosActualizarAFecha_Shown(object sender, EventArgs e)
        {
            txtFecha.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
