using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Logica_Negocio;

namespace Eval_Proveedores.Novedades
{
    public partial class ActSemProv : Form
    {
        EvalSemestralBOL ESBOL = new EvalSemestralBOL();
        DataTable dtEvaluacion = new DataTable();
        DataTable dtInformeMuestra = new DataTable();
        DataTable dtInformeDetalle = new DataTable();
        string[] _Empresas = { "SurfactanSA", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII", "Pelitall_II", "Pellital_III", "Pellital_V" };
        Listados.EvaSemActProve.IniEvaSemActProve frm = new Listados.EvaSemActProve.IniEvaSemActProve();
        private int WTipoImpresion = 1;
        bool WImprimiendo = false;

        public ActSemProv()
        {
            InitializeComponent();
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

                DataTable WProveedores = _ProcesarEvaluacionProveedores();

                DataRow[] WProveedoresFinales = WProveedores.Select("Pasa = 'S'");

                lblTipoListado.Text = "(Sólo Proveedores con Movimientos)";

                if (ckIncluirSinMovimientos.Checked)
                {
                    WProveedoresFinales = WProveedores.Select();
                    lblTipoListado.Text = "(Proveedores con y sin Movimientos)";
                }

                int WRenglon = 0;
                double ZMovimientos = 0, ZCertificadosOk = 0, ZEnvasesOk = 0;

                foreach (DataRow WProveedor in WProveedoresFinales)
                {
                    WRenglon = DGV_EvalSemProve.Rows.Add();

                    ZMovimientos = double.Parse(WProveedor["Movimientos"].ToString());
                    ZCertificadosOk = double.Parse(WProveedor["CertificadosOk"].ToString());
                    ZEnvasesOk = double.Parse(WProveedor["EnvasesOk"].ToString());

                    DGV_EvalSemProve.Rows[WRenglon].Cells["Proveedor"].Value = WProveedor["Proveedor"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Razon"].Value = WProveedor["Razon"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Movimientos"].Value = WProveedor["Movimientos"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Aprobados"].Value = WProveedor["Aprobados"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Retrasos"].Value = WProveedor["Retrasos"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Desvios"].Value = WProveedor["Desvios"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Rechazados"].Value = WProveedor["Rechazados"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["EnvasesOk"].Value = WProveedor["EnvasesOk"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["CertificadosOk"].Value = WProveedor["CertificadosOk"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Categoria1"].Value = WProveedor["CategoriaI"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Categoria2"].Value = WProveedor["CategoriaII"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["PorCert"].Value = Helper._DeterminarPorcentajeRelacion(ZMovimientos, ZCertificadosOk);
                    DGV_EvalSemProve.Rows[WRenglon].Cells["PorEnv"].Value = Helper._DeterminarPorcentajeRelacion(ZMovimientos, ZEnvasesOk);
                    DGV_EvalSemProve.Rows[WRenglon].Cells["PorcTotal"].Value = Helper._DeterminarPorcentajeTotal(ZMovimientos, ZCertificadosOk, ZEnvasesOk);
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Categoria1"].Value = WProveedor["CategoriaI"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Categoria2"].Value = WProveedor["CategoriaII"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Fechas"].Value = WProveedor["Fechacategoria"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["EvaCal"].Value = Helper._DeterminarCalidad(WProveedor["CategoriaI"].ToString());
                    DGV_EvalSemProve.Rows[WRenglon].Cells["EvaEnt"].Value = Helper._DeterminarCalidadEntrega(WProveedor["CategoriaII"].ToString());

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

        private DataTable _ProcesarEvaluacionProveedores()
        {
            return Helper._ProcesarEvaluacionProveedores("1", TB_Desde.Text, TB_Hasta.Text, ref progressBar1, EmpresasAConsultar());
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
            SqlTransaction trans = null;

            try
            {
                string WProveedor = "", WFechaCategoria = "", WFechaCategoriaOrd = "", WCategoriaI ="", WCategoriaII = "", WTemp ="";

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

                        foreach (DataGridViewRow WRow in DGV_EvalSemProve.Rows)
                        {
                            WProveedor = WRow.Cells["Proveedor"].Value.ToString();
                            WTemp = WRow.Cells["EvaCal"].Value.ToString();
                            WCategoriaI = _TraerCalidad(WTemp);
                            WTemp = WRow.Cells["EvaEnt"].Value.ToString();
                            WCategoriaII = _TraerEnt(WTemp);

                            if (_DatosActualizados(WRow, WCategoriaI, WCategoriaII))
                            {
                                WFechaCategoria = DateTime.Now.ToString("dd/MM/yyyy");
                                WFechaCategoriaOrd = Helper.OrdenarFecha(WFechaCategoria);

                                cmd.CommandText = "UPDATE Proveedor SET FechaCategoria = '" + WFechaCategoria + "', "
                                                + " OrdFechaCategoria = '" + WFechaCategoriaOrd + "', "
                                                + " CategoriaI = '" + WCategoriaI + "', "
                                                + " CategoriaII = '" + WCategoriaII + "' "
                                                + " WHERE Proveedor  = '" + WProveedor + "'";

                                cmd.ExecuteNonQuery();
                            }    

                        }

                        trans.Commit();

                        MessageBox.Show("La evaluación se agregó con éxito", "Agregar Evaluación",
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                }
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();

                MessageBox.Show("Hubo un problema al querer actualizar las Calificaciones de los Proveedores. Motivo: " + ex.Message);
            }
        }

        private bool _DatosActualizados(DataGridViewRow WRow, string WCategoriaI, string WCategoriaII)
        {
            return WRow.Cells["Categoria1"].Value.ToString().Trim() != WCategoriaI || WRow.Cells["Categoria2"].Value.ToString().Trim() != WCategoriaII;
        }

        private string _TraerEnt(string wTemp)
        {
            switch (wTemp.ToUpper())
            {
                case "MUY BUENO":
                {
                    return "1";
                }
                case "BUENO":
                {
                    return "2";
                }
                case "REGULAR":
                {
                    return "3";
                }
                case "MALO":
                {
                    return "4";
                }
                default:
                {
                    return "0";
                }
            }
        }

        private string _TraerCalidad(string wTemp)
        {
            switch (wTemp.ToUpper())
            {
                case "A":
                {
                    return "1";
                }
                case "B":
                {
                    return "2";
                }
                case "C":
                {
                    return "3";
                }
                case "E":
                {
                    return "4";
                }
                default:
                {
                    return "0";
                }

            }
        }

        private void _MostrarDetalles(string _Prove, string descProve)
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

            DetalleItems Detalle = new DetalleItems(dtInformeDetalle, _Prove, descProve, TB_Desde.Text + " al " + TB_Hasta.Text, GenerarTextoPlantas());
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

            string _Prove = DGV_EvalSemProve.Rows[e.RowIndex].Cells["Proveedor"].Value.ToString();
            string _DescProve = DGV_EvalSemProve.Rows[e.RowIndex].Cells["Razon"].Value.ToString();
            _MostrarDetalles(_Prove, _DescProve);
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

	            if (txtClave.Text.ToUpper() != "EVALUA") return;

	            button3.PerformClick();

	            BT_Guardar.PerformClick();

	        }else if (e.KeyData == Keys.Escape){
	        	txtClave.Text = "";
	        }
	        
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

                frm = new Listados.EvaSemActProve.IniEvaSemActProve();

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

    }
}
