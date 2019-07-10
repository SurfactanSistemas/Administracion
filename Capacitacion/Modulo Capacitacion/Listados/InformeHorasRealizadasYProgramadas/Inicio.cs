using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Negocio;

namespace Modulo_Capacitacion.Listados.InformeHorasRealizadasYProgramadas
{
    public partial class Inicio : Form
    {
        public Inicio(string Año = "", int Curso = 0, bool Pendientes = false)
        {
            InitializeComponent();

            if (Curso != 0 && Año != "")
            {
                txtAnio.Text = Año;
                txtCurso.Text = Curso.ToString();
                rbPorCurso.Checked = true;
                rbPorCurso_Click(null, null);

                if (Pendientes) cmbTipo.SelectedIndex = 2;

                txtLegajo.Text = "";

                btnPantalla_Click(null, null);
                Close();
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;

            foreach (TextBox C in new []{txtAnio, txtCurso, txtDescCurso, txtDescLegajo, txtLegajo})
            {
                C.Text = "";
            }

            txtCurso.Enabled = rbPorCurso.Checked;

            /*
             * Cargamos los datos de los Sectores. Únicamente aquellos que se encuentren asignados aunque sea a un legajo.
             */
            DataTable WSectores = _TraerSectores();

            DataRow r = WSectores.NewRow();

            r["Codigo"] = 0;
            r["Descripcion"] = " TODOS";

            WSectores.Rows.InsertAt(r, 0);
            WSectores.DefaultView.Sort = "Descripcion ASC";
            cmbSector.DataSource = WSectores;
            cmbSector.DisplayMember = "Descripcion";
            cmbSector.ValueMember = "Codigo";



        }

        private DataTable _TraerSectores()
        {
            DataTable datos = new DataTable();

            try
            {                
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.Connection = cn;
                        cm.CommandText = "select Codigo, UPPER(Descripcion) Descripcion from Sector where codigo in (select Sector from legajo) order by Descripcion";

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                datos.Load(dr);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return datos;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var frm = _GenerarReporte();

            frm.Imprimir();
        }

        private VistaPrevia _GenerarReporte()
        {
            if (txtAnio.Text.Trim() == "" || txtAnio.Text.Trim().Length < 4)
                throw new Exception("No se ha cargado un Año válido de consulta.");

            if (txtCurso.Text.Trim() != "")
            {
                DataRow WCurso = (new Curso())._BuscarCurso(txtCurso.Text, "Codigo");

                if (WCurso == null) throw new Exception("No se ha cargado un Curso válido de consulta.");
            }

            if (txtLegajo.Text.Trim() != "")
            {
                DataTable WLegajo = (new Legajo())._BuscarLegajo(txtLegajo.Text, "Codigo");

                if (WLegajo.Rows.Count == 0) throw new Exception("No se ha cargado un Legajo válido de consulta.");
            }

            /*
             * Recalculamos los datos a imprimir.
             */
            Helper.ActualizarCantidadPersonasHoras("01/06/" + txtAnio.Text, "31/05/" + (int.Parse(txtAnio.Text) + 1));
            Helper.ActualizarHorasRealizadas(txtAnio.Text);

            string WFormula = "{Cronograma.Ano}=" + txtAnio.Text +
                              " AND {Legajo.Renglon} = 1 ";

            if (txtCurso.Text.Trim() != "" && rbPorCurso.Checked) WFormula += " AND {Cronograma.Curso} = " + txtCurso.Text + "";
            
            if (txtLegajo.Text.Trim() != "") WFormula += " AND {Legajo.Codigo} = " + txtLegajo.Text + "";

            if (cmbTipo.SelectedIndex == 1 && rbPorCurso.Checked) WFormula += " AND {Cronograma.Realizado} >= {Tema.Horas}";

            if (cmbTipo.SelectedIndex == 2 && rbPorCurso.Checked) WFormula += " AND {Cronograma.Realizado} < {Tema.Horas}";

            if (cmbSector.SelectedIndex > 0 && txtLegajo.Text.Trim() == "")
            {
                DataRowView r = (DataRowView) cmbSector.SelectedItem;

                if (r != null) WFormula += " And {Legajo.Sector} = " + r["Codigo"];
            }

            VistaPrevia frm = new VistaPrevia();

            ReportDocument rpt = rbPorCurso.Checked ? (ReportDocument) new ReporteInformeHorasRealizadasyProgramadasPorCurso() : new ReporteInformeHorasRealizadasyProgramadasPorLegajo();

            if (rbPorLegajo.Checked)
            {
                double[] Totales = _TraerTotalPersonas();

                rpt.SetParameterValue("TotalPersonas", Totales[0]);
                rpt.SetParameterValue("HorasTotales", Totales[1]);
                rpt.SetParameterValue("RealizadosTotales", Totales[2]);
                rpt.SetParameterValue("Todos", cmbTipo.SelectedIndex == 0);
                rpt.SetParameterValue("SoloCumplidos", cmbTipo.SelectedIndex == 1);
                rpt.SetParameterValue("SoloPendientes", cmbTipo.SelectedIndex == 2);
            }

            frm.CargarReporte(rpt, WFormula);

            return frm;
        }

        private double[] _TraerTotalPersonas()
        {
            double Total = 0;
            double HorasTotales = 0;
            double RealizadosTotales = 0;

            string wFiltroLegajo = "";
            string wFiltroSector = "";

            if (txtLegajo.Text.Trim() != "") wFiltroLegajo = " AND Cr.Legajo = " + txtLegajo.Text + "";

            if (cmbSector.SelectedIndex > 0 && txtLegajo.Text.Trim() == "")
            {
                DataRowView r = (DataRowView)cmbSector.SelectedItem;

                if (r != null) wFiltroSector += " And L.Sector = " + r["Codigo"];
            }

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Surfactan"].ToString()))
            {
                cn.Open();
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;
                    cm.CommandText = "";
                    
                    switch (cmbTipo.SelectedIndex)
                    {
                        case 1:
                        {
                            cm.CommandText = "select Cr.Legajo, sum(Cr.horas) Horas, sum(Cr.realizado) Realizados  from Cronograma cr INNER JOIN Legajo L ON L.Codigo = cr.Legajo and L.Renglon = 1 LEFT OUTER JOIN Tema T1 ON T1.Tema = Cr.Tema And T1.Curso = cr.Curso LEFT OUTER JOIN Tema T2 ON T2.Curso = cr.Curso AND T2.Tema = cr.Tema2 WHERE Cr.Curso BETWEEN 0 And 9999 AND cr.Ano = 2018 " + wFiltroLegajo + " " + wFiltroSector + " GROUP By Cr.Legajo HAVING Sum(Cr.Horas) <= sum(Cr.Realizado)";
                            break;
                        }
                        case 2:
                        {
                            cm.CommandText = "select Cr.Legajo, sum(Cr.horas) Horas, sum(Cr.realizado) Realizados  from Cronograma cr INNER JOIN Legajo L ON L.Codigo = cr.Legajo and L.Renglon = 1 LEFT OUTER JOIN Tema T1 ON T1.Tema = Cr.Tema And T1.Curso = cr.Curso LEFT OUTER JOIN Tema T2 ON T2.Curso = cr.Curso AND T2.Tema = cr.Tema2 WHERE Cr.Curso BETWEEN 0 And 9999 AND cr.Ano = 2018 " + wFiltroLegajo + " " + wFiltroSector + " GROUP By Cr.Legajo HAVING Sum(Cr.Horas) > sum(Cr.Realizado)";
                            break;
                        }
                        default:
                        {
                            cm.CommandText = "select Cr.Legajo, sum(Cr.horas) Horas, sum(Cr.realizado) Realizados  from Cronograma cr INNER JOIN Legajo L ON L.Codigo = cr.Legajo and L.Renglon = 1 LEFT OUTER JOIN Tema T1 ON T1.Tema = Cr.Tema And T1.Curso = cr.Curso LEFT OUTER JOIN Tema T2 ON T2.Curso = cr.Curso AND T2.Tema = cr.Tema2 WHERE Cr.Curso BETWEEN 0 And 9999 AND cr.Ano = 2018 " + wFiltroLegajo + " " + wFiltroSector + " GROUP By Cr.Legajo";
                            break;
                        }
                    }

                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Total++;
                                HorasTotales += double.Parse(Helper.OrDefault(dr["Horas"].ToString(), "0").ToString());
                                RealizadosTotales += double.Parse(Helper.OrDefault(dr["Realizados"].ToString(), "0").ToString());
                            }
                        }
                    }
                }
            }

            return new[]{Total, HorasTotales, RealizadosTotales};
        }


        private void btnPantalla_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = _GenerarReporte();

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCurso_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                txtDescCurso.Text = "";

                if (txtCurso.Text.Trim() != "")
                {
                    DataRow WCurso = (new Curso())._BuscarCurso(txtCurso.Text, "Descripcion");

                    if (WCurso == null) return;
                        
                    txtDescCurso.Text = WCurso["Descripcion"].ToString().Trim().ToUpper();
                }

                txtLegajo.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCurso.Text = "";
            }
	        
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            txtAnio.Focus();
        }

        private void txtAnio_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtAnio.Text.Trim() == "") return;

                txtCurso.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtAnio.Text = "";
            }
	        
        }

        private void txtLegajo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                txtDescLegajo.Text = "";

                if (txtLegajo.Text.Trim() != "")
                {
                    DataTable WLeg = (new Legajo())._BuscarLegajo(txtLegajo.Text, "Descripcion");

                    if (WLeg.Rows.Count == 0) return;

                    txtDescLegajo.Text = WLeg.Rows[0]["Descripcion"].ToString().Trim().ToUpper();
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                txtLegajo.Text = "";
            }
	        
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), "[0-9]") && !char.IsControl(e.KeyChar);
        }

        private void rbPorCurso_Click(object sender, EventArgs e)
        {
            txtCurso.Enabled = rbPorCurso.Checked;
        }
    }
}
