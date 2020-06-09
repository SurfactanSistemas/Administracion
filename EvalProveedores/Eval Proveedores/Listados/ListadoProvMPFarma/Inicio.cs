using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Util.Clases;
using CrystalDecisions.CrystalReports.Engine;
using Eval_Proveedores.Listados.CalculoEvaluacionSemestralProveedorEnvases;

namespace Eval_Proveedores.Listados.ListadoProvMPFarma
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
            cmbTipo.SelectedIndex = 0;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            _MostrarReporte("Pantalla");
        }

        private void _MostrarReporte(string WTipoImpre)
        {
            try
            {
                string Desde = Helper.OrdenarFecha(TB_Desde.Text); //TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2);
                string Hasta = Helper.OrdenarFecha(TB_Hasta.Text); //TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2);


                if (Desde == "0") return; //throw new Exception("Se debe ingresar la fecha Desde donde desea listar");
                if (Hasta == "0") return; //throw new Exception("Se debe ingresar la fecha Hasta donde desea listar");

                DataTable EvalSemProve = _GenerarTablaEvalSemProve();

                DataTable WProveedores = _ProcesarEvaluacionProveedoresFarma();

                DataRow[] WProveedoresFinales = WProveedores.Select("Pasa = 'S'");

                if (rbTodos.Checked)
                {
                    WProveedoresFinales = WProveedores.Select();
                }

                foreach (DataRow WProveedor in WProveedoresFinales)
                {
                    var ZMovimientos = double.Parse(WProveedor["Movimientos"].ToString());
                    var ZCertificadosOk = double.Parse(WProveedor["CertificadosOk"].ToString());
                    if (ZCertificadosOk > ZMovimientos) ZCertificadosOk = ZMovimientos;

                    var ZEnvasesOk = double.Parse(WProveedor["EnvasesOk"].ToString());
                    if (ZEnvasesOk > ZMovimientos) ZEnvasesOk = ZMovimientos;

                    DataRow row = EvalSemProve.NewRow();

                    //row["MarcaPerformance"] = "0";
                    row["Proveedor"] = WProveedor["Proveedor"];
                    row["Articulo"] = WProveedor["Articulo"];
                    row["Razon"] = WProveedor["Razon"];
                    row["Movimientos"] = WProveedor["Movimientos"];
                    row["Aprobados"] = WProveedor["Aprobados"];
                    row["Retrasos"] = WProveedor["Retrasos"];
                    row["Desvios"] = WProveedor["Desvios"];
                    row["Rechazados"] = WProveedor["Rechazados"];
                    row["EnvasesOk"] = ZEnvasesOk.ToString();
                    row["CertificadosOk"] = ZCertificadosOk.ToString();
                    row["PorCert"] = Helper._DeterminarPorcentajeRelacion(ZMovimientos, ZCertificadosOk);
                    row["PorEnv"] = Helper._DeterminarPorcentajeRelacion(ZMovimientos, ZEnvasesOk);
                    row["PorcTotal"] = Helper._DeterminarPorcentajeTotal(ZMovimientos, ZCertificadosOk, ZEnvasesOk);

                    DataRow WDatoEvalua =
                        Query.GetSingle("SELECT EstadoMP, FechaEvaluaVto, FechaEntrego FROM EvaluacionProvMP WHERE Proveedor = '" +
                                        WProveedor["Proveedor"] + "' And Articulo = '" + WProveedor["Articulo"] + "' And Renglon = 1");

                    row["EvalCal"] = _TraerDescEvaluacion(0);

                    row["FechaEvaluaProvMPFarmaII"] = "";

                    if (WDatoEvalua != null)
                    {
                        row["EvalCal"] =
                            _TraerDescEvaluacion(WDatoEvalua["EstadoMP"]);

                        row["FechaEvaluaProvMPFarmaII"] =
                            Helper.OrDefault(WDatoEvalua["FechaEntrego"], "");

                        row["FechaEvaluaVto"] =
                            Helper.OrDefault(WDatoEvalua["FechaEvaluaVto"], "");
                    }

                    EvalSemProve.Rows.Add(row);
                }

                EvalSemProve.DefaultView.Sort = "Razon ASC, Articulo ASC";

                VistaPrevia frm = new VistaPrevia();
                ReportDocument rpt = new ReportEvaProveMPFarma();
                rpt.SetDataSource(EvalSemProve);
                frm.CargarReporte(rpt);

                frm.Show();

            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
                MessageBox.Show(
                    "Ocurrió un problema al querer procesar la información de las Evaluaciones Semestrales de los Proveedores de Materia Prima. Motivo: " +
                    ex.Message);
            }
        }

        private string _TraerDescEvaluacion(object valor)
        {
            switch (int.Parse(Helper.OrDefault(valor, "0").ToString()))
            {
                case 1:
                    {
                        return "APROBADO FARMA";
                    }
                case 2:
                    {
                        return "RECHAZADO FARMA";
                    }
                case 3:
                    {
                        return "EVENTUAL FARMA";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        private DataTable _GenerarTablaEvalSemProve()
        {
            DataTable t = new DataTable();

            t.Columns.Add("Proveedor");
            t.Columns.Add("Articulo");
            t.Columns.Add("Razon");
            t.Columns.Add("Movimientos");
            t.Columns.Add("Aprobados");
            t.Columns.Add("Retrasos");
            t.Columns.Add("Desvios");
            t.Columns.Add("Rechazados");
            t.Columns.Add("EnvasesOk");
            t.Columns.Add("CertificadosOK");
            t.Columns.Add("PorCert");
            t.Columns.Add("PorEnv");
            t.Columns.Add("PorcTotal");
            t.Columns.Add("EvalCal");
            t.Columns.Add("FechaEvaluaProvMPFarmaII");
            t.Columns.Add("EstadoMP");
            t.Columns.Add("FechaEvaluaVto");
            t.Columns.Add("VencEvaluacion");

            return t;
        }

        private DataTable _ProcesarEvaluacionProveedoresFarma()
        {
            return Helper._ProcesarEvaluacionProveedoresFarma(cmbTipo.SelectedIndex.ToString(), TB_Desde.Text, TB_Hasta.Text, ref progressBar1, EmpresasAConsultar());
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
            //return Helper._ProcesarEvaluacionProveedores("2", TB_Desde.Text, TB_Hasta.Text, ref progressBar1, EmpresasAConsultar());
            return Helper._ProcesarEvaluacionProveedoresFarma("1", TB_Desde.Text, TB_Hasta.Text, ref progressBar1,
                EmpresasAConsultar());
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
