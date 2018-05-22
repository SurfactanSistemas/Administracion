using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Eval_Proveedores.Listados.CalculoEvaluacionSemestralProveedorEnvases;

namespace Eval_Proveedores.Listados.EvaSemProveEnv
{
    public partial class Inicio : Form
    {
        private string[] _Empresas =
        {
            "SurfactanSA", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V",
            "Surfactan_VI", "Surfactan_VII", "Pelitall_II", "Pellital_III", "Pellital_V"
        };

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            ckTodos.Checked = true;
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

                        cmd.CommandText = "UPDATE Proveedor SET "
                                              + " Impre1 = " + "0" + ", "
                                              + " Impre2 = " + "0" + ", "
                                              + " Impre3 = " + "0" + ", "
                                              + " Impre4 = " + "0" + ", "
                                              + " Impre5 = " + "0" + ", "
                                              + " Impre6 = " + "0" + ", "
                                              + " Impre7 = '" + "" + "', "
                                              + " Impre8 = '" + "" + "', "
                                              + " Impre9 = '" + "" + "', "
                                              + " Impre10 = " + "0" + ", "
                                              + " Impre11 = '" + "" + "', "
                                              + " Impre12 = '" + "" + "', "
                                              + " Periodo = '" + "" + "'";

                        cmd.ExecuteNonQuery();

                        foreach (DataRow WProveedor in WProveedoresFinales)
                        {
                            //WRenglon = DGV_EvalSemProve.Rows.Add();

                            ZMovimientos = double.Parse(WProveedor["Movimientos"].ToString());
                            ZCertificadosOk = double.Parse(WProveedor["CertificadosOk"].ToString());
                            ZEnvasesOk = double.Parse(WProveedor["EnvasesOk"].ToString());
                            ZRetrasos = int.Parse(WProveedor["Retrasos"].ToString());

                            ZImpre1 = WProveedor["Movimientos"].ToString();
                            ZImpre2 = WProveedor["Aprobados"].ToString();
                            ZImpre3 = WProveedor["Desvios"].ToString();
                            ZImpre4 = WProveedor["Rechazados"].ToString();
                            ZImpre5 = WProveedor["CertificadosOk"].ToString();
                            ZImpre6 = WProveedor["EnvasesOk"].ToString();

                            ZImpre7 = ZMovimientos != 0
                                ? Helper.FormatoNumerico((ZCertificadosOk/ZMovimientos)*100)
                                : "";
                            ZImpre8 = ZMovimientos != 0 ? Helper.FormatoNumerico((ZEnvasesOk/ZMovimientos)*100) : "";
                            ZImpre9 = ZMovimientos != 0
                                ? Helper.FormatoNumerico(((ZCertificadosOk + ZEnvasesOk)/(ZMovimientos*2))*100)
                                : "";

                            ZImpre10 = ZRetrasos.ToString();

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

                        cmd.CommandText = "UPDATE Proveedor SET "
                                          + " Periodo = '" + "Del " + TB_Desde.Text + " al " + TB_Hasta.Text + "     " +
                                          GenerarTextoPlantas() + "'";

                        cmd.ExecuteNonQuery();

                        trans.Commit();
                    }
                }

                string WFiltro = " AND {Proveedor.Impre1} > 0";

                if (rbTodos.Checked) WFiltro = "";

                VistaPrevia frm = new VistaPrevia();
                frm.CargarReporte(new wcalificaenvase(), "{Proveedor.TipoProv}=2" + WFiltro);
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

        private string GenerarTextoPlantas()
        {
            string WEmpresas = "(Plantas: ";

            if (ckTodos.Checked)
            {
                WEmpresas += "1, 2, 3, 4, 5, 6, 7 y Pellital)";
            }
            else
            {
                if (ckPlantaI.Checked) WEmpresas += "1, ";
                if (ckPlantaII.Checked) WEmpresas += "2, ";
                if (ckPlantaIII.Checked) WEmpresas += "3, ";
                if (ckPlantaVI.Checked) WEmpresas += "4, ";
                if (ckPlantaV.Checked) WEmpresas += "5, ";
                if (ckPlantaVI.Checked) WEmpresas += "6, ";
                if (ckPlantaVII.Checked) WEmpresas += "7, ";
                if (ckPellital.Checked)
                {
                    WEmpresas += "Pellital";
                }
            }

            // Elimino espacios en blanco al final.
            WEmpresas = WEmpresas.Trim();
            // Elimino ultima coma al final en caso de existir.
            WEmpresas = WEmpresas.TrimEnd(',');
            // Reemplazo la ultima ',' por un 'y'.
            int indice = WEmpresas.LastIndexOf(',');

            if (indice > -1 && !ckTodos.Checked)
                WEmpresas = WEmpresas.Substring(0, indice) + " y" +
                            WEmpresas.Substring(indice + 1, WEmpresas.Length - 1 - indice);

            WEmpresas += ")";

            return WEmpresas;
        }

        private string[] EmpresasAConsultar()
        {
            List<string> WEmpresas = new List<string>();

            if (ckTodos.Checked)
            {
                WEmpresas.AddRange(_Empresas);
            }
            else
            {
                if (ckPlantaI.Checked) WEmpresas.Add(_Empresas[0]);
                if (ckPlantaII.Checked) WEmpresas.Add(_Empresas[1]);
                if (ckPlantaIII.Checked) WEmpresas.Add(_Empresas[2]);
                if (ckPlantaVI.Checked) WEmpresas.Add(_Empresas[3]);
                if (ckPlantaV.Checked) WEmpresas.Add(_Empresas[4]);
                if (ckPlantaVI.Checked) WEmpresas.Add(_Empresas[5]);
                if (ckPlantaVII.Checked) WEmpresas.Add(_Empresas[6]);
                if (ckPellital.Checked)
                {
                    WEmpresas.Add(_Empresas[7]);
                    WEmpresas.Add(_Empresas[8]);
                    WEmpresas.Add(_Empresas[9]);
                }
            }

            return WEmpresas.ToArray();
        }

        private DataTable _ProcesarEvaluacionProveedores()
        {
            return Helper._ProcesarEvaluacionProveedores("2", TB_Desde.Text, TB_Hasta.Text, ref progressBar1, EmpresasAConsultar());
        }


        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void BT_Imprimir_Click_1(object sender, EventArgs e)
        {
            _MostrarReporte("Imprimir");
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

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (TB_Hasta.Text.Replace('/', ' ').Trim() == "") return;

                TB_Desde.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_Hasta.Clear();
            }
        }


        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodos.Checked)
            {
                foreach (
                    CheckBox ck in
                        new[]
                        {ckPlantaI, ckPlantaII, ckPlantaIII, ckPlantaIV, ckPlantaV, ckPlantaVI, ckPlantaVII, ckPellital}
                    )
                {
                    ck.Checked = true;
                }
            }
        }

        private void Plantas_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox) sender).Checked)
            {
                ckTodos.Checked = false;
            }
        }

        private void ckTodos_Click(object sender, EventArgs e)
        {
            if (!ckTodos.Checked)
            {
                foreach (
                    CheckBox ck in
                        new[]
                        {ckPlantaI, ckPlantaII, ckPlantaIII, ckPlantaIV, ckPlantaV, ckPlantaVI, ckPlantaVII, ckPellital}
                    )
                {
                    ck.Checked = false;
                }
            }
        }

        public void GenerarReporteDesdeFuera(string[] WEmpresas, string WDesde, string WHasta, int Tipo)
        {
            ckTodos.Checked = false;
            ckTodos_Click(null, null);

            foreach (string wEmpresa in WEmpresas)
            {
                switch (wEmpresa.Trim())
                {
                    case "1":
                    {
                        ckPlantaI.Checked = true;
                        break;
                    }
                    case "2":
                    {
                        ckPlantaII.Checked = true;
                        break;
                    }
                    case "3":
                    {
                        ckPlantaIII.Checked = true;
                        break;
                    }
                    case "4":
                    {
                        ckPlantaIV.Checked = true;
                        break;
                    }
                    case "5":
                    {
                        ckPlantaV.Checked = true;
                        break;
                    }
                    case "6":
                    {
                        ckPlantaVI.Checked = true;
                        break;
                    }
                    case "7":
                    {
                        ckPlantaVII.Checked = true;
                        break;
                    }
                    case "Pellital":
                    {
                        ckPellital.Checked = true;
                        break;
                    }
                }
            }

            TB_Desde.Text = WDesde;
            TB_Hasta.Text = WHasta;

            Enabled = false;
            BT_Imprimir.Visible = false;
            BT_Pantalla.Visible = false;
            BT_Salir.Visible = false;

            switch (Tipo)
            {
                case 1:
                {
                    _MostrarReporte("Pantalla");
                    break;
                }
                case 2:
                {
                    _MostrarReporte("Imprimir");
                    break;
                }
                default:
                {
                    return;
                }
            }

            Enabled = true;
        }
    }
}
