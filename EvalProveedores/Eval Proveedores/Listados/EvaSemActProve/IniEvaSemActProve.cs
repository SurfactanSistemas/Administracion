using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Eval_Proveedores.Listados.CalculoEvaluacionSemestralProvMP;

namespace Eval_Proveedores.Listados.EvaSemActProve
{
    public partial class IniEvaSemActProve : Form
    {
        public IniEvaSemActProve()
        {
            InitializeComponent();
        }

        private void IniEvaSemActProve_Load(object sender, EventArgs e)
        {
            rbSoloConMovimientos.Checked = true;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            _MostrarReporte("Pantalla");
        }

        private void _MostrarReporte(string WTipoImpre)
        {
            DataTable WProveedores = _ProcesarEvaluacionProveedores();

            DataRow[] WProveedoresFinales = WProveedores.Select("Pasa = 'S'");

            double ZMovimientos = 0, ZCertificadosOk = 0, ZEnvasesOk = 0, ZRetrasos = 0;
            string ZImpre1 = "",
                ZImpre2 = "",
                ZImpre3 = "",
                ZImpre4 = "",
                ZImpre5 = "",
                ZImpre6 = "",
                ZImpre7 = "",
                ZImpre8 = "",
                ZImpre9 = "",
                ZImpre10 = "",
                ZImpre11 = "",
                ZImpre12 = "";

            SqlTransaction trans = null;

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "";
                        cmd.Transaction = trans;

                        foreach (DataRow WProveedor in WProveedoresFinales)
                        {
                            //WRenglon = DGV_EvalSemProve.Rows.Add();

                            ZMovimientos = double.Parse(WProveedor["Movimientos"].ToString());
                            ZCertificadosOk = double.Parse(WProveedor["CertificadosOk"].ToString());
                            ZEnvasesOk = double.Parse(WProveedor["EnvasesOk"].ToString());
                            ZRetrasos = double.Parse(WProveedor["Retrasos"].ToString());

                            ZImpre1 = WProveedor["Movimientos"].ToString();
                            ZImpre2 = WProveedor["Aprobados"].ToString();
                            ZImpre3 = WProveedor["Desvios"].ToString();
                            ZImpre4 = WProveedor["Rechazados"].ToString();
                            ZImpre5 = WProveedor["CertificadosOk"].ToString();
                            ZImpre6 = WProveedor["EnvasesOk"].ToString();

                            ZImpre7 = ZMovimientos != 0 ? Helper.FormatoNumerico((ZCertificadosOk/ZMovimientos)*100) : "";
                            ZImpre8 = ZMovimientos != 0 ? Helper.FormatoNumerico((ZEnvasesOk/ZMovimientos)*100) : "";
                            ZImpre9 = ZMovimientos != 0
                                ? Helper.FormatoNumerico(((ZCertificadosOk + ZEnvasesOk)/(ZMovimientos*2))*100)
                                : "";
                            
                            ZImpre10 = ZMovimientos != 0 ? Helper.FormatoNumerico((ZRetrasos/ZMovimientos)) : "0";

                            if (double.Parse(ZImpre10.Replace(".", ",")) <= 1)
                            {
                                ZImpre11 = "Muy Bueno";
                            }
                            else if (double.Parse(ZImpre10.Replace(".", ",")) <= 2)
                            {
                                ZImpre11 = "Bueno";
                            }
                            else if (double.Parse(ZImpre10.Replace(".", ",")) <= 7)
                            {
                                ZImpre11 = "Regular";
                            }
                            else
                            {
                                ZImpre11 = "Malo";
                            }


                            if (int.Parse(ZImpre4) == 0)
                            {
                                ZImpre12 = "A";
                            }
                            else if (int.Parse(ZImpre4) == 0)
                            {
                                ZImpre12 = "B";
                            }
                            else
                            {
                                ZImpre12 = "C";
                            }


                            cmd.CommandText = "UPDATE Proveedor SET "
                                              + " Impre1 = " + ZImpre1 + ", "
                                              + " Impre2 = " + ZImpre2 + ", "
                                              + " Impre3 = " + ZImpre3 + ", "
                                              + " Impre4 = " + ZImpre4 + ", "
                                              + " Impre5 = " + ZImpre5 + ", "
                                              + " Impre6 = " + ZImpre6 + ", "
                                              + " Impre7 = '" + ZImpre7 + "', "
                                              + " Impre8 = '" + ZImpre8 + "', "
                                              + " Impre9 = '" + ZImpre9 + "', "
                                              + " Impre10 = " + ZImpre10 + ", "
                                              + " Impre11 = '" + ZImpre11 + "', "
                                              + " Impre12 = '" + ZImpre12 + "', "
                                              + " Periodo = '" + "Del " + TB_Desde.Text + " al " + TB_Hasta.Text + "'"
                                              + " WHERE Proveedor = '" + WProveedor["Proveedor"] + "'";

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                }

                string WFiltro = " AND {Proveedor.Impre1} > 0";

                if (rbTodos.Checked) WFiltro = "";

                VistaPrevia frm = new VistaPrevia();
                frm.CargarReporte(new wcalifica(), "{Proveedor.TipoProv}=1" + WFiltro);
                if (WTipoImpre == "Pantalla") frm.Show();
                if (WTipoImpre == "Imprimir") frm.Imprimir();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                progressBar1.Visible = false;
                MessageBox.Show(
                    "Ocurrió un problema al querer procesar la información de las Evaluaciones Semestrales de los Proveedores de Materia Prima. Motivo: " +
                    ex.Message);
            }
        }

        private DataTable _ProcesarEvaluacionProveedores()
        {
            return Helper._ProcesarEvaluacionProveedores("1", TB_Desde.Text, TB_Hasta.Text, ref progressBar1);
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            _MostrarReporte("Imprimir");
        }


        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (TB_Desde.Text.Replace('/', ' ').Trim() == "") return;

                TB_Hasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_Desde.Clear();
            }
	        
        }

        private void IniEvaSemActProve_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        
    }
}
