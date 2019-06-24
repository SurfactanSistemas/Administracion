using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.TemasPorLegajoConsolidado
{
    public partial class Inicio : Form
    {
        DataTable dtCursadas;
        Cursada Cur = new Cursada();
        Cronograma Cr = new Cronograma();
        DataTable dtInforme;
        string TipoImpre;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CB_Tipo.SelectedIndex = 0;


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

            foreach (TextBox t in new []{txtCurso, txtDescCurso, txtLegajo, txtDescLegajo})
            {
                t.Text = "";
            }
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                ImpreInforme Impre = _GenerarReporte("Pantalla");
                Impre.Show(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private ImpreInforme _GenerarReporte(string _TipoImpre)
        {
            progressBar1.Visible = false;
            progressBar1.Value = 0;

            if (TB_AñoDesde.Text == "") throw new Exception("Debe ingresar el año inicial");

            if (TB_AñoHasta.Text == "") TB_AñoHasta.Text = TB_AñoDesde.Text;

            //if (CB_Tipo.Text == "") throw new Exception("Debe elegir el tipo de listado");

            int Desde = int.Parse(TB_AñoDesde.Text.Substring(6, 4));
            int Hasta = int.Parse(TB_AñoHasta.Text.Substring(6, 4));

            string WDesde = Helper.OrdenarFecha(TB_AñoDesde.Text);
            string WHasta = Helper.OrdenarFecha(TB_AñoHasta.Text);

            dtCursadas = txtCurso.Text != "" ? Cur.ListarCursadaCons3(WDesde, WHasta, int.Parse(txtCurso.Text)) : Cur.ListarCursadaCons2(WDesde, WHasta);

            progressBar1.Maximum = dtCursadas.Rows.Count;

            progressBar1.Visible = true;
            progressBar1.Step = 1;

            int Año = Desde;

            if (Año > Hasta) Año = Hasta;

            foreach (DataRow fila in dtCursadas.Rows)
            {
                int Legajo = int.Parse(fila["Legajo"].ToString());
                int Curso = int.Parse(fila["Curso"].ToString());
                string Clave = fila["Clave"].ToString();

                //dtCronograma = Cr.BuscarUnoCursada(Año, Legajo, Curso);

                int Valor = 0;

                //if (dtCronograma.Rows.Count > 0 )
                if (!Cr.ExisteEnCronograma(Año, Legajo, Curso)) Valor = 1;

                Cur.ModificarCursadaConsol(Valor, Clave);

                progressBar1.Increment(1);
            }

            string FechaDesde = Helper.OrdenarFecha(TB_AñoDesde.Text); // + "0101";
            string FechaHasta = Helper.OrdenarFecha(TB_AñoHasta.Text); // + "1231";

            int Tipo = CB_Tipo.SelectedIndex;

            /*
             * Preparamos las condiciones extras en caso de ser necesario.
             */
            string WCondicionesExtras = "";

            if (txtCurso.Text.Trim() != "") WCondicionesExtras += " AND C.Curso = '" + txtCurso.Text + "'";

            if (txtLegajo.Text.Trim() != "") WCondicionesExtras += " AND C.Legajo = '" + txtLegajo.Text + "'";

            if (cmbSector.SelectedIndex > 0)
            {
                DataRowView r = (DataRowView) cmbSector.SelectedItem;

                if (r != null) WCondicionesExtras += " AND L.Sector = '" + r["Codigo"] + "'";
            }

            switch (Tipo)
            {
                case 1:

                    dtInforme = Cur.ListarInformeCons(FechaDesde, FechaHasta, 0, 0, WCondicionesExtras);
                    break;

                case 2:

                    dtInforme = Cur.ListarInformeCons(FechaDesde, FechaHasta, 1, 1, WCondicionesExtras);
                    break;

                case 0:

                    dtInforme = Cur.ListarInformeCons(FechaDesde, FechaHasta, 0, 9999, WCondicionesExtras);
                    break;
            }

            progressBar1.Visible = false;

            ImpreInforme Impre = new ImpreInforme(dtInforme, _TipoImpre);
            return Impre;
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ImpreInforme Impre = _GenerarReporte("Imprimir");
                Impre.Show(this);
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error");
            }
        }

        private void TB_AñoDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_AñoDesde.Text.Replace(" ", "").Length == 10)
                {
                    TB_AñoHasta.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_AñoDesde.Text = "";
            }
        }

        private void TB_AñoHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_AñoHasta.Text.Replace(" ", "").Length == 10)
                {
                    txtCurso.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_AñoHasta.Text = "";
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_AñoDesde.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         *
         * */

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

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), "[0-9]") && !char.IsControl(e.KeyChar);
        }

    }
}
