using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Util;
using Util.Clases;
using EvaluacionProvMPFarma;
using Eval_Proveedores.Listados.EvaSemActProve;
using Logica_Negocio;

namespace Eval_Proveedores.Novedades
{
    public partial class ActualizacionSemestralProvMPFarma : Form
    {
        readonly EvalSemestralBOL ESBOL = new EvalSemestralBOL();
        DataTable dtEvaluacion = new DataTable();
        DataTable dtInformeMuestra = new DataTable();
        DataTable dtInformeDetalle = new DataTable();
        string[] _Empresas = { "SurfactanSA", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII", "Pelitall_II", "Pellital_III", "Pellital_V" };
        IniEvaSemActProve frm = new IniEvaSemActProve();
        private int WTipoImpresion = 1;
        bool WImprimiendo;
        private string WEvaluador = "";

        public ActualizacionSemestralProvMPFarma()
        {
            InitializeComponent();

            DGV_EvalSemProve.InhabilitarOrdenamientoColumnas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Desde = Helper.OrdenarFecha(TB_Desde.Text); //TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2);
                string Hasta = Helper.OrdenarFecha(TB_Hasta.Text); //TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2);


                if (Desde == "0") return; //throw new Exception("Se debe ingresar la fecha Desde donde desea listar");
                if (Hasta == "0") return; //throw new Exception("Se debe ingresar la fecha Hasta donde desea listar");

                dtEvaluacion.Clear();
                dtInformeMuestra.Clear();
                DGV_EvalSemProve.Rows.Clear();

                DataTable WProveedores = _ProcesarEvaluacionProveedoresFarma();

                DataRow[] WProveedoresFinales = WProveedores.Select("Pasa = 'S'");

                lblTipoListado.Text = "(Sólo Proveedores con Movimientos)";

                if (ckIncluirSinMovimientos.Checked)
                {
                    WProveedoresFinales = WProveedores.Select();
                    lblTipoListado.Text = "(Proveedores con y sin Movimientos)";
                }

                foreach (DataRow WProveedor in WProveedoresFinales)
                {
                    var ZMovimientos = double.Parse(WProveedor["Movimientos"].ToString());
                    var ZCertificadosOk = double.Parse(WProveedor["CertificadosOk"].ToString());
                    if (ZCertificadosOk > ZMovimientos) ZCertificadosOk = ZMovimientos;
                    
                    var ZEnvasesOk = double.Parse(WProveedor["EnvasesOk"].ToString());
                    if (ZEnvasesOk > ZMovimientos) ZEnvasesOk = ZMovimientos;

                    var WRenglon = DGV_EvalSemProve.Rows.Add();

                    DGV_EvalSemProve.Rows[WRenglon].Cells["MarcaPerformance"].Value = "0";
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Proveedor"].Value = WProveedor["Proveedor"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Articulo"].Value = WProveedor["Articulo"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Razon"].Value = WProveedor["Razon"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Movimientos"].Value = WProveedor["Movimientos"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Aprobados"].Value = WProveedor["Aprobados"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Retrasos"].Value = WProveedor["Retrasos"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Desvios"].Value = WProveedor["Desvios"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Rechazados"].Value = WProveedor["Rechazados"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["EnvasesOk"].Value = ZEnvasesOk.ToString();
                    DGV_EvalSemProve.Rows[WRenglon].Cells["CertificadosOk"].Value = ZCertificadosOk.ToString(); 
                    DGV_EvalSemProve.Rows[WRenglon].Cells["PorCert"].Value = Helper._DeterminarPorcentajeRelacion(ZMovimientos, ZCertificadosOk);
                    DGV_EvalSemProve.Rows[WRenglon].Cells["PorEnv"].Value = Helper._DeterminarPorcentajeRelacion(ZMovimientos, ZEnvasesOk);
                    DGV_EvalSemProve.Rows[WRenglon].Cells["PorcTotal"].Value = Helper._DeterminarPorcentajeTotal(ZMovimientos, ZCertificadosOk, ZEnvasesOk);

                    DataRow WDatoEvalua =
                        Query.GetSingle("SELECT EstadoMP, FechaEvaluaVto, FechaEntrego FROM EvaluacionProvMP WHERE Proveedor = '" +
                                        WProveedor["Proveedor"] + "' And Articulo = '" + WProveedor["Articulo"] + "' And Renglon = 1");

                    DGV_EvalSemProve.Rows[WRenglon].Cells["EvaCal"].Value = _TraerDescEvaluacion(0);

                    DGV_EvalSemProve.Rows[WRenglon].Cells["FechaEvaluaProvMPFarmaII"].Value = "";

                    if (WDatoEvalua != null)
                    {
                        DGV_EvalSemProve.Rows[WRenglon].Cells["EvaCal"].Value =
                            _TraerDescEvaluacion(WDatoEvalua["EstadoMP"]);

                        DGV_EvalSemProve.Rows[WRenglon].Cells["FechaEvaluaProvMPFarmaII"].Value =
                            Helper.OrDefault(WDatoEvalua["FechaEntrego"], "");

                        DGV_EvalSemProve.Rows[WRenglon].Cells["VencEvaluacion"].Value =
                            Helper.OrDefault(WDatoEvalua["FechaEvaluaVto"], "");
                    }
                }

                progressBar1.Value = 0;
                progressBar1.Visible = false;

                if (DGV_EvalSemProve.Columns["Razon"] != null)
                    DGV_EvalSemProve.Sort(DGV_EvalSemProve.Columns["Razon"], ListSortDirection.Ascending);

            }


            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private DataTable _ProcesarEvaluacionProveedoresFarma()
        {
            return Helper._ProcesarEvaluacionProveedoresFarma(comboBox1.SelectedIndex.ToString(), TB_Desde.Text, TB_Hasta.Text, ref progressBar1, EmpresasAConsultar());
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

        private void CargardtInformeMuestra()
        {
            dtInformeMuestra.Columns.Add("CodProve", typeof(string));
            dtInformeMuestra.Columns.Add("DescProve", typeof(string));
            dtInformeMuestra.Columns.Add("Items", typeof(string));
            dtInformeMuestra.Columns.Add("Aprobado", typeof(int));
            dtInformeMuestra.Columns.Add("Desviado", typeof(int));
            dtInformeMuestra.Columns.Add("Rechazado", typeof(int));
            dtInformeMuestra.Columns.Add("Certificado", typeof(int));
            dtInformeMuestra.Columns.Add("Enviado", typeof(int));
            dtInformeMuestra.Columns.Add("PorcCert", typeof(double));
            dtInformeMuestra.Columns.Add("PorcEnv", typeof(double));
            dtInformeMuestra.Columns.Add("PorcTotal", typeof(double));
            dtInformeMuestra.Columns.Add("Atraso", typeof(int));
            dtInformeMuestra.Columns.Add("Fecha", typeof(string));
            dtInformeMuestra.Columns.Add("Categoria1", typeof(string));
            dtInformeMuestra.Columns.Add("Categoria2", typeof(string));
            dtInformeMuestra.Columns.Add("CatI", typeof(int));
            dtInformeMuestra.Columns.Add("CatII", typeof(int));
        }

        private void CargarDtEvaluacion()
        {
            dtEvaluacion.Columns.Add("CodProve", typeof(string));
           dtEvaluacion.Columns.Add("Aprobado", typeof(string));
            
            dtEvaluacion.Columns.Add("Certificado", typeof(string));
            dtEvaluacion.Columns.Add("Enviado", typeof(string));
            dtEvaluacion.Columns.Add("Desviado", typeof(int));
            dtEvaluacion.Columns.Add("Rechazado", typeof(int));
            dtEvaluacion.Columns.Add("Atraso", typeof(int));
            dtEvaluacion.Columns.Add("Fecha", typeof(string));
            dtEvaluacion.Columns.Add("Liberada", typeof(int));
            dtEvaluacion.Columns.Add("Partida", typeof(int));
            dtEvaluacion.Columns.Add("Clave", typeof(string));
            dtEvaluacion.Columns.Add("Categoria1", typeof(string));
            dtEvaluacion.Columns.Add("Categoria2", typeof(string));
            
        }

        private void ActSemProv_Load(object sender, EventArgs e)
        {
            pnlClave.Visible = false;
            comboBox1.SelectedIndex = 0;

            ckTodos.Checked = true;
            WTipoImpresion = 1;
            WImprimiendo = false;

            CargarDtEvaluacion();
            CargardtInformeMuestra();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (WEvaluador.Trim() == "") WEvaluador = "0";

                List<string> ZSqls = new List<string>();

                foreach (DataGridViewRow row in DGV_EvalSemProve.Rows)
                {
                    var WProveedor = Helper.OrDefault(row.Cells["Proveedor"].Value, "").ToString();
                    var WEstadoMP = _TraerIDEvaluacion(Helper.OrDefault(row.Cells["EvaCal"].Value, 0)).ToString();
                    var WFechaEvaluaVto = Helper.OrDefault(row.Cells["FechaEvaluaProvMPFarmaII"].Value, "").ToString();
                    var WFechaEvaluaVtoOrd = Helper.OrdenarFecha(WFechaEvaluaVto);
                    var WCodMP = Helper.OrDefault(row.Cells["Articulo"].Value, "").ToString();
                    var WFecha = DateTime.Now.ToString("dd/MM/yyyy");
                    var WFechaOrd = Helper.OrdenarFecha(WFecha);

                    DataRow WEvaluacion =
                        Query.GetSingle("SELECT Clave FROM EvaluacionProvMP WHERE Proveedor = '" + WProveedor +
                                        "' And Articulo = '" + WCodMP + "'");

                    if (WEvaluacion != null)
                    {
                        ZSqls.Add("UPDATE EvaluacionProvMP SET Fecha = '" + WFecha + "', FechaOrd = '" + WFechaOrd + "', EstadoMP = '" + WEstadoMP + "', FechaEvaluaVto = '" + WFechaEvaluaVto + "', FechaEvaluaVtoOrd = '" + WFechaEvaluaVtoOrd + "', Operador = '" + WEvaluador + "' WHERE Proveedor = '" + WProveedor + "' And Articulo = '" + WCodMP + "'");
                    }
                    else
                    {
                        string WClave = WProveedor.PadLeft(11, '0') + WCodMP + "01";

                        ZSqls.Add(string.Format("INSERT INTO EvaluacionProvMP (Clave, Proveedor, Articulo, Renglon, Fecha, FechaOrd, FechaEvaluaVto, FechaEvaluaVtoOrd, Operador, EstadoMP) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", WClave, WProveedor, WCodMP, 1, WFecha, WFechaOrd, WFechaEvaluaVto, WFechaEvaluaVtoOrd, WEvaluador, WEstadoMP));
                    }
                }

                Query.ExecuteNonQueries(ZSqls.ToArray());

                MessageBox.Show("Las Evaluaciones se actualizaron con éxito", "Actualizar Evaluación",
                MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al querer actualizar las Calificaciones de los Proveedores. Motivo: " + ex.Message);
            }
        }

        private int _TraerIDEvaluacion(object valor)
        {
            switch (valor.ToString())
            {
                case "APROBADO FARMA":
                    {
                        return 1;
                    }
                case "RECHAZADO FARMA":
                    {
                        return 2;
                    }
                case "EVENTUAL FARMA":
                    {
                        return 3;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private void _MostrarDetalles(string _Prove, string descProve, string CodigoMP)
        {
            dtInformeDetalle = new DataTable();

            dtInformeDetalle.Columns.Add("Articulo", typeof (string));
            dtInformeDetalle.Columns.Add("Orden", typeof (int));
            dtInformeDetalle.Columns.Add("Desviad", typeof (string));
            dtInformeDetalle.Columns.Add("DesArticulo", typeof (string));
            dtInformeDetalle.Columns.Add("Atraso", typeof (string));
            dtInformeDetalle.Columns.Add("Desvio", typeof (string));
            dtInformeDetalle.Columns.Add("Informe", typeof (int));
            dtInformeDetalle.Columns.Add("Cantidad", typeof (double));
            dtInformeDetalle.Columns.Add("FechaEntrega", typeof (string));
            dtInformeDetalle.Columns.Add("FechaPosibleEntrega", typeof (string));
            dtInformeDetalle.Columns.Add("Liberada", typeof (string));
            dtInformeDetalle.Columns.Add("Laudo", typeof (int));
            dtInformeDetalle.Columns.Add("Devuelta", typeof (string));
            dtInformeDetalle.Columns.Add("Rechazado", typeof (string));
            dtInformeDetalle.Columns.Add("Clave", typeof (string));
            dtInformeDetalle.Columns.Add("FechaOrd", typeof (string));
            dtInformeDetalle.Columns.Add("OrdFecha2", typeof (string));
            dtInformeDetalle.Columns.Add("Fecha", typeof(string));
            dtInformeDetalle.Columns.Add("Fecha2", typeof(string));
            dtInformeDetalle.Columns.Add("Certificado1", typeof(string));
            dtInformeDetalle.Columns.Add("Estado1", typeof(string));

            foreach (string _Empresa in EmpresasAConsultar())
            {
                DataTable dtInformeProve = ESBOL.ListaInformeProve(Helper.OrdenarFecha(TB_Desde.Text), Helper.OrdenarFecha(TB_Hasta.Text), _Empresa, 1, _Prove);
                CargarInformeProve(dtInformeProve);
            }

            descProve += "     " + GenerarTextoPlantas();

            DetalleItems Detalle = new DetalleItems(dtInformeDetalle, _Prove, descProve, TB_Desde.Text + " al " + TB_Hasta.Text, GenerarTextoPlantas(), CodigoMP);
            Detalle.Show();
        }

        private string GenerarTextoPlantas()
        {
            string WEmpresas = "( Plantas: ";

            if (ckTodos.Checked)
            {
                WEmpresas += "1, 2, 3, 4, 5, 6, 7 y Pellital";
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

            WEmpresas += " )";

            return WEmpresas;
        }

        private void CargarInformeProve(DataTable dtInformeProve)
        {
            foreach (DataRow fila in dtInformeProve.Rows)
            {
                dtInformeDetalle.ImportRow(fila);
            }
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Hasta.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Desde.Clear();
            }
        }

        private void DGV_EvalSemProve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewColumn column = DGV_EvalSemProve.Columns["Actualiza"];
            if (column != null)
                if (column.Index == DGV_EvalSemProve.CurrentCell.ColumnIndex) return;

            string _Prove = DGV_EvalSemProve.Rows[e.RowIndex].Cells["Proveedor"].Value.ToString();
            string _DescProve = DGV_EvalSemProve.Rows[e.RowIndex].Cells["Razon"].Value.ToString();
            string _CodMP = DGV_EvalSemProve.Rows[e.RowIndex].Cells["Articulo"].Value.ToString();
            _MostrarDetalles(_Prove, _DescProve, _CodMP);
        }

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (TB_Hasta.Text.Replace('/', ' ').Trim() == "") return;

                DGV_EvalSemProve.Rows.Clear();

                button1_Click(null, null);

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_Hasta.Clear();
            }
	        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlClave.Visible = true;
            txtClave.Text = "";
            txtClave.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlClave.Visible = false;
            txtClave.Text = "";
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            
	        if (e.KeyData == Keys.Enter){
	        	if (txtClave.Text.Trim() == "") return;

	            if (!_Clave_Valida(txtClave.Text))
	            {
	                MessageBox.Show("Contraseña incorrecta o no tiene los permisos necesarios para poder actualizar las Evaluaciones.", "Evaluación Proveedores de MP Farma", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                txtClave.Focus();
	                return;
	            }

	            button3.PerformClick();

	            BT_Guardar_Click(null, null);

	        }else if (e.KeyData == Keys.Escape){
	        	txtClave.Text = "";
	        }
	        
        }

        private bool _Clave_Valida(string WClave)
        {
            bool WClaveCalida = false;
            WEvaluador = "";

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Operador, EvaluaProvMPFarma FROM Operador WHERE UPPER(Clave) = '" + WClave.Trim().ToUpper() + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WClaveCalida = Helper.OrDefault(dr["EvaluaProvMPFarma"], "N").ToString().ToUpper() == "S";
                                WEvaluador = dr["Operador"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al corroborar la clave indicada en la Base de Datos. Motivo: " + ex.Message);
            }

            return WClaveCalida;

        }

        private void ckIncluirSinMovimientos_CheckedChanged(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodos.Checked)
            {
                foreach (CheckBox ck in new[] { ckPlantaI, ckPlantaII, ckPlantaIII, ckPlantaIV, ckPlantaV, ckPlantaVI, ckPlantaVII, ckPellital })
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
                foreach (CheckBox ck in new[] { ckPlantaI, ckPlantaII, ckPlantaIII, ckPlantaIV, ckPlantaV, ckPlantaVI, ckPlantaVII, ckPellital })
                {
                    ck.Checked = false;
                }
            }
        }

        private void btnPantalla_Click(object sender, EventArgs e)
        {
            WTipoImpresion = 1;

            WImprimiendo = true;

            frm.Show();

            timer1.Start();
        }

        private string[] GenerarArregloPlantas()
        {
            string WEmpresas = "";

            if (ckTodos.Checked)
            {
                WEmpresas += "1, 2, 3, 4, 5, 6, 7, Pellital";
            }
            else
            {
                if (ckPlantaI.Checked) WEmpresas += "1,";
                if (ckPlantaII.Checked) WEmpresas += "2,";
                if (ckPlantaIII.Checked) WEmpresas += "3,";
                if (ckPlantaVI.Checked) WEmpresas += "4,";
                if (ckPlantaV.Checked) WEmpresas += "5,";
                if (ckPlantaVI.Checked) WEmpresas += "6,";
                if (ckPlantaVII.Checked) WEmpresas += "7,";
                if (ckPellital.Checked)
                {
                    WEmpresas += "Pellital";
                }
            }

            // Elimino ultima coma al final en caso de existir.
            WEmpresas = WEmpresas.TrimEnd(',');
            
            return WEmpresas.Split(',');
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (WImprimiendo)
            {

                WImprimiendo = false;

                string[] WEmpresas = GenerarArregloPlantas();

                frm.GenerarReporteDesdeFuera(WEmpresas, TB_Desde.Text, TB_Hasta.Text, WTipoImpresion);

                frm.Close();

                frm = new IniEvaSemActProve();

                timer1.Stop();

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            WTipoImpresion = 2;

            WImprimiendo = true;

            frm.Show();

            timer1.Start();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Evitamos que se copien las cabeceras.
            DGV_EvalSemProve.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            // Copiamos el contenido de las celdas seleccionadas en el ClipBoard.
            _CopiarSeleccion();
        }

        private void _CopiarSeleccion()
        {
            if (DGV_EvalSemProve.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                // Evitamos que los 'Rows Headers' ocupen espacio.
                DGV_EvalSemProve.RowHeadersVisible = false;

                object data = DGV_EvalSemProve.GetClipboardContent();
                if (data != null)
                    Clipboard.SetDataObject(data);

                // Volvemos a mostrar los 'Rows Headers'
                DGV_EvalSemProve.RowHeadersVisible = true;
            }
        }

        private void copiarConCabecerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Activamos que se copien las cabeceras.
            DGV_EvalSemProve.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            // Copiamos el contenido de las celdas seleccionadas en el ClipBoard.
            _CopiarSeleccion();

        }

        private void DGV_EvalSemProve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (DGV_EvalSemProve.Columns[e.ColumnIndex].Name == "Actualiza")
            //{
            //    var WValor = DGV_EvalSemProve.CurrentCell.Value ?? "";

            //    DGV_EvalSemProve.CurrentCell.Value = (WValor.ToString().Trim() == "") ? "X" : "";
            //}

            if (DGV_EvalSemProve.Columns[e.ColumnIndex].Name == "VerEvalua")
            {
                if (DGV_EvalSemProve.CurrentRow != null)
                {
                    string WProveedor = DGV_EvalSemProve.CurrentRow.Cells["Proveedor"].Value.ToString();
                    string WCodMP = DGV_EvalSemProve.CurrentRow.Cells["Articulo"].Value.ToString();

                    EvaluacionProveedorMateriaPrima _frm = new EvaluacionProveedorMateriaPrima(WProveedor, false, WCodMP);
                    _frm.Show(this);
                }
            }
        }

        private void DGV_EvalSemProve_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn FechaFarmaCol = DGV_EvalSemProve.Columns["FechaEvaluaProvMPFarma"];

            if (FechaFarmaCol != null && e.ColumnIndex == FechaFarmaCol.Index)
            {
                DGV_EvalSemProve.CurrentCell.Selected = false;
            }
        }
    }
}
