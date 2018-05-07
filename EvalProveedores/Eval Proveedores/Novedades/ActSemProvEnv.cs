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
    public partial class ActSemProvEnv : Form
    {
        DataTable dtEvaluacion = new DataTable();
        DataTable dtInformeMuestra = new DataTable();
        EvalSemestralBOL ESBOL = new EvalSemestralBOL();
        DataTable dtInformeDetalle;


        public ActSemProvEnv()
        {
            InitializeComponent();
        }

        private void ActSemProvEnv_Load(object sender, EventArgs e)
        {
            CargarDtEvaluacion();
            CargardtInformeMuestra();

            ckTodos.Checked = true;
            //DGV_EvalSemProve.Visible = false;

            //LB_Titulo.Visible = false;
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
            //dtEvaluacion.Columns.Add("Fecha", typeof(string));
            //dtEvaluacion.Columns.Add("Liberada", typeof(int));
            //dtEvaluacion.Columns.Add("Partida", typeof(int));
            dtEvaluacion.Columns.Add("Clave", typeof(string));
            
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
            //dtInformeMuestra.Columns.Add("PorcCert", typeof(double));
            //dtInformeMuestra.Columns.Add("PorcEnv", typeof(double));
            //dtInformeMuestra.Columns.Add("PorcTotal", typeof(double));
            dtInformeMuestra.Columns.Add("Atraso", typeof(int));
            dtInformeMuestra.Columns.Add("Fecha", typeof(string));
            dtInformeMuestra.Columns.Add("Categoria1", typeof(string));
            dtInformeMuestra.Columns.Add("Categoria2", typeof(string));
            dtInformeMuestra.Columns.Add("CatI", typeof(int));
            dtInformeMuestra.Columns.Add("CatII", typeof(int));
        }

        private void BT_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string Desde = Helper.OrdenarFecha(TB_Desde.Text); //TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2);
                string Hasta = Helper.OrdenarFecha(TB_Hasta.Text); //TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2);


                if (Desde == "0") return;
                if (Hasta == "0") return;

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

                foreach (DataRow WProveedor in WProveedoresFinales)
                {
                    WRenglon = DGV_EvalSemProve.Rows.Add();

                    DGV_EvalSemProve.Rows[WRenglon].Cells["Proveedor"].Value = WProveedor["Proveedor"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Razon"].Value = WProveedor["Razon"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Movimientos"].Value = WProveedor["Movimientos"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Aprobados"].Value = WProveedor["Aprobados"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Retrasos"].Value = WProveedor["Retrasos"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["Desvios"].Value = WProveedor["Desvios"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["EnvasesOk"].Value = WProveedor["EnvasesOk"];
                    DGV_EvalSemProve.Rows[WRenglon].Cells["CertificadosOk"].Value = WProveedor["CertificadosOk"];
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



                LB_Titulo.Visible = true;

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable _ProcesarEvaluacionProveedores()
        {
            return Helper._ProcesarEvaluacionProveedores("2", TB_Desde.Text, TB_Hasta.Text, ref progressBar1, EmpresasAConsultar());
        }

        private string[] EmpresasAConsultar()
        {
            List<string> WEmpresas = new List<string>();

            if (ckTodos.Checked)
            {
                WEmpresas.AddRange(Helper._Empresas);
            }
            else
            {
                if (ckPlantaI.Checked) WEmpresas.Add(Helper._Empresas[0]);
                if (ckPlantaII.Checked) WEmpresas.Add(Helper._Empresas[1]);
                if (ckPlantaIII.Checked) WEmpresas.Add(Helper._Empresas[2]);
                if (ckPlantaVI.Checked) WEmpresas.Add(Helper._Empresas[3]);
                if (ckPlantaV.Checked) WEmpresas.Add(Helper._Empresas[4]);
                if (ckPlantaVI.Checked) WEmpresas.Add(Helper._Empresas[5]);
                if (ckPlantaVII.Checked) WEmpresas.Add(Helper._Empresas[6]);
                if (ckPellital.Checked)
                {
                    WEmpresas.Add(Helper._Empresas[7]);
                    WEmpresas.Add(Helper._Empresas[8]);
                    WEmpresas.Add(Helper._Empresas[9]);
                }
            }

            return WEmpresas.ToArray();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {

            pnlClave.Visible = true;
            txtClave.Text = "";
            txtClave.Focus();

        }

        private void _MostrarDetalles(int WRowIndex)
        {
            string _Prove = DGV_EvalSemProve.Rows[WRowIndex].Cells["Proveedor"].Value.ToString();

            dtInformeDetalle = new DataTable();

            dtInformeDetalle.Columns.Add("Articulo", typeof(string));
            dtInformeDetalle.Columns.Add("Orden", typeof(int));
            dtInformeDetalle.Columns.Add("Desviad", typeof(string));
            dtInformeDetalle.Columns.Add("DesArticulo", typeof(string));
            dtInformeDetalle.Columns.Add("Atraso", typeof(string));
            dtInformeDetalle.Columns.Add("Desvio", typeof(string));
            dtInformeDetalle.Columns.Add("Informe", typeof(int));
            dtInformeDetalle.Columns.Add("Cantidad", typeof(double));
            dtInformeDetalle.Columns.Add("FechaEntrega", typeof(string));
            dtInformeDetalle.Columns.Add("FechaPosibleEntrega", typeof(string));
            dtInformeDetalle.Columns.Add("Liberada", typeof(string));
            dtInformeDetalle.Columns.Add("Laudo", typeof(int));
            dtInformeDetalle.Columns.Add("Devuelta", typeof(string));
            dtInformeDetalle.Columns.Add("Rechazado", typeof(string));
            dtInformeDetalle.Columns.Add("Clave", typeof(string));
            dtInformeDetalle.Columns.Add("FechaOrd", typeof(string));
            dtInformeDetalle.Columns.Add("OrdFecha2", typeof(string));
            dtInformeDetalle.Columns.Add("Fecha", typeof(string));
            dtInformeDetalle.Columns.Add("Fecha2", typeof(string));
            dtInformeDetalle.Columns.Add("Certificado1", typeof(string));
            dtInformeDetalle.Columns.Add("Estado1", typeof(string));
            dtInformeDetalle.Columns.Add("SaldoOC", typeof(double));
            dtInformeDetalle.Columns.Add("DesconOC", typeof(double));
            dtInformeDetalle.Columns.Add("EnvaseOC", typeof(string));
            dtInformeDetalle.Columns.Add("DescEnvaseOC", typeof(string));
            dtInformeDetalle.Columns.Add("CSEmpresa", typeof(string));

            DataRow WDatosOC;

            foreach (string _Empresa in Helper._Empresas)
            {
                DataTable dtInformeProve = ESBOL.ListaInformeProve(Helper.OrdenarFecha(TB_Desde.Text), Helper.OrdenarFecha(TB_Hasta.Text), _Empresa, 1, _Prove);

                dtInformeProve.Columns.Add("DesArticulo", typeof(string));
                dtInformeProve.Columns.Add("SaldoOC", typeof(double));
                dtInformeProve.Columns.Add("DesconOC", typeof(double));
                dtInformeProve.Columns.Add("EnvaseOC", typeof(string));
                dtInformeProve.Columns.Add("DescEnvaseOC", typeof(string));
                dtInformeProve.Columns.Add("CSEmpresa", typeof(string));

                foreach (DataRow row in dtInformeProve.Rows)
                {
                    if (row["DesArticulo"].ToString() == "")
                    {
                        row["DesArticulo"] = _TraerDescripcionArticulo(row["Articulo"].ToString(), _Empresa);
                    }

                    row["SaldoOC"] = 0;
                    row["Cantidad"] = 0;
                    row["DesconOC"] = 0;
                    row["EnvaseOC"] = "0";
                    row["DescEnvaseOC"] = "";

                    WDatosOC = _TraerInformacionOC(row["Orden"], row["Articulo"], _Empresa);

                    if (WDatosOC != null)
                    {

                        row["SaldoOC"] = WDatosOC["Saldo"];
                        row["Cantidad"] = WDatosOC["Cantidad"];
                        row["DesconOC"] = WDatosOC["Recibida"];
                        row["EnvaseOC"] = WDatosOC["Envase"];
                        row["DescEnvaseOC"] = WDatosOC["DescEnvase"];

                    }

                    row["CSEmpresa"] = _Empresa;
                }

                CargarInformeProve(dtInformeProve);
            }

            DetalleItemsEnvases Detalle = new DetalleItemsEnvases(dtInformeDetalle);
            Detalle.Show();
        }

        private DataRow _TraerInformacionOC(object _Orden, object _Articulo, string WEmpresa)
        {
            DataTable tabla = new DataTable();
            string WOrden = _Orden.ToString();
            string WArticulo = _Articulo.ToString();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[WEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT o.Saldo, o.Recibida, o.Cantidad, i.Envase, isnull(e.Descripcion, '') as DescEnvase FROM Orden o, Informe i FULL OUTER JOIN Envases e ON i.Envase = e.Envases WHERE o.Orden = i.Orden AND o.Articulo = i.Articulo AND o.Orden = '" + WOrden + "' AND o.Articulo = '" + WArticulo + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            tabla.Load(dr);
                        }
                    }
                }

            }

            if (tabla.Rows.Count > 0) return tabla.Rows[0];

            return null;
        }

        private string _TraerDescripcionArticulo(string WArticulo, string _Empresa)
        {
            string Descripcion = "";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[_Empresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Descripcion FROM Articulo WHERE Codigo = '" + WArticulo + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            Descripcion = dr["Descripcion"].ToString();
                            Descripcion = Descripcion.Trim();
                        }
                    }
                }

            }

            return Descripcion;
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
        }

        private void ckIncluirSinMovimientos_CheckedChanged(object sender, EventArgs e)
        {
            BT_Buscar.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlClave.Visible = false;
            txtClave.Text = "";
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtClave.Text.Trim() == "") return;

                if (txtClave.Text.ToUpper() != "EVALUA") return;

                button3.PerformClick();

                BT_Guardar.PerformClick();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtClave.Text = "";
            }
        }

        private void BT_Guardar_Click_1(object sender, EventArgs e)
        {
            SqlTransaction trans = null;

            try
            {
                string WProveedor = "", WFechaCategoria = "", WFechaCategoriaOrd = "", WCategoriaI = "", WCategoriaII = "", WTemp = "";

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

        private void DGV_EvalSemProve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex > -1)
                if (DGV_EvalSemProve.Columns[e.ColumnIndex].Name == "EvaCal" || DGV_EvalSemProve.Columns[e.ColumnIndex].Name == "EvaEnt") return;

            _MostrarDetalles(e.RowIndex);
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
            if (!((CheckBox)sender).Checked)
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
    }
}
