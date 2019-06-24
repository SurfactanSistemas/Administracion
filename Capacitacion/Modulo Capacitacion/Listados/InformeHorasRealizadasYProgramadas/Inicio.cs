using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.InformeHorasRealizadasYProgramadas
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;

            foreach (TextBox C in new []{txtAnio, txtCurso, txtDescCurso, txtDescLegajo, txtLegajo})
            {
                C.Text = "";
            }

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

            if (ckExcluir99.Checked) WFormula += " AND {Cronograma.Tema} <> 99 ";

            if (txtCurso.Text.Trim() != "") WFormula += " AND {Cronograma.Curso} = " + txtCurso.Text + "";
            
            if (txtLegajo.Text.Trim() != "") WFormula += " AND {Legajo.Codigo} = " + txtLegajo.Text + "";

            if (cmbTipo.SelectedIndex == 1) WFormula += " AND {Cronograma.Realizado} >= {Tema.Horas}";

            if (cmbTipo.SelectedIndex == 2) WFormula += " AND {Cronograma.Realizado} < {Tema.Horas}";

            if (cmbSector.SelectedIndex > 0 && txtLegajo.Text.Trim() == "")
            {
                DataRowView r = (DataRowView) cmbSector.SelectedItem;

                if (r != null) WFormula += " And {Legajo.Sector} = " + r["Codigo"];
            }

            VistaPrevia frm = new VistaPrevia();

            frm.CargarReporte(new ReporteInformeHorasRealizadasyProgramadas(), WFormula);

            return frm;
        }

        

        private void btnPantalla_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = _GenerarReporte();

                frm.Show(this);
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
    }
}
