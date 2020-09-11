﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Eval_Proveedores.Listados;
using Eval_Proveedores.Listados.DetalleItemsEnvases;
using Util.Clases;

namespace Eval_Proveedores.Novedades
{
    public partial class DetalleItemsEnvases : Form
    {
        private DataTable dtInformeDetalle;
        private string WCodProv = "";
        private string WPeriodo = "";
        private string WPlantas = "";

        public DetalleItemsEnvases()
        {
            InitializeComponent();
        }

        public DetalleItemsEnvases(DataTable dtInformeDetalle)
        {
            this.dtInformeDetalle = dtInformeDetalle;
            InitializeComponent();
        }

        public DetalleItemsEnvases(DataTable dtInformeDetalle, string _CodProv, string WProveedor, string _Periodo, string _Plantas)
        {
            this.dtInformeDetalle = dtInformeDetalle;
            InitializeComponent();
            lblProveedor.Text = WProveedor;
            WCodProv = _CodProv;
            WPeriodo = _Periodo;
            WPlantas = _Plantas;
        }

        private void DetalleItems_Load(object sender, EventArgs e)
        {
            pnlEstadoEnvases.Visible = false;
            //DGV_EvalSemProve.Columns.Clear();
            ArmarDt();
            //DGV_EvalSemProve.DataSource = dtItems;

            btnImprimir.Location = Helper._CentrarH(Width, btnImprimir);

        }

        private void ArmarDt()
        {
            int _index = 0;
            DGV_EvalSemProve.Rows.Clear();
            string WOrden = "", WArticulo = "";

            foreach (DataRow fila in dtInformeDetalle.Rows)
            {
                _index = DGV_EvalSemProve.Rows.Add();

                WOrden = fila["Orden"].ToString();
                WArticulo = fila["Articulo"].ToString();

                DGV_EvalSemProve.Rows[_index].Cells["Renglon"].Value = _index;
                DGV_EvalSemProve.Rows[_index].Cells["Articulo"].Value = WArticulo;
                DGV_EvalSemProve.Rows[_index].Cells["Orden"].Value = WOrden;
                DGV_EvalSemProve.Rows[_index].Cells["Desviad"].Value = fila["Clave"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["DescArticulo"].Value = fila["DesArticulo"].ToString(); //_TraerDescArticulo(fila["Articulo"].ToString());
                DGV_EvalSemProve.Rows[_index].Cells["Atraso"].Value = _CalcularAtraso(Helper.OrdenarFecha(fila["Fecha"].ToString()), Helper.OrdenarFecha(fila["Fecha2"].ToString()));
                DGV_EvalSemProve.Rows[_index].Cells["Desvio"].Value = _EsPorDesvio(fila["Laudo"].ToString()) ? "X" : "";
                DGV_EvalSemProve.Rows[_index].Cells["Aprobado"].Value = (_EsPorDesvio(fila["Laudo"].ToString()) || _DeterminarRechazado(fila["Devuelta"].ToString()) == "") ? "X" : "";

                DGV_EvalSemProve.Rows[_index].Cells["Informe"].Value = fila["Informe"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Cantidad"].Value = Helper.FormatoNumerico(fila["Cantidad"].ToString());
                DGV_EvalSemProve.Rows[_index].Cells["FechaEntrega"].Value = fila["fecha"].ToString();

                DGV_EvalSemProve.Rows[_index].Cells["Liberada"].Value = fila["Liberada"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Laudo"].Value = fila["Laudo"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Devuelta"].Value = fila["Devuelta"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Rechazado"].Value = _DeterminarRechazado(fila["Devuelta"].ToString());

                DGV_EvalSemProve.Rows[_index].Cells["Cantidad"].Value = Helper.FormatoNumerico(fila["Liberada"].ToString());

                DGV_EvalSemProve.Rows[_index].Cells["SaldoOC"].Value = Helper.FormatoNumerico(fila["SaldoOC"].ToString());
                DGV_EvalSemProve.Rows[_index].Cells["DesconOC"].Value = Helper.FormatoNumerico(fila["DesconOC"].ToString());
                DGV_EvalSemProve.Rows[_index].Cells["EnvaseOC"].Value = fila["EnvaseOC"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["DescEnvaseOC"].Value = fila["DescEnvaseOC"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["CSEmpresa"].Value = fila["CSEmpresa"].ToString();

            }

            foreach (string WColumna in new[] { "FechaPosibleEntrega", "CSEmpresa" })
            {
                DataGridViewColumn column = DGV_EvalSemProve.Columns[WColumna];
                if (column != null) column.Visible = false;
            }

        }

        private string _DeterminarRechazado(string _Rechazado)
        {
            _Rechazado = _Rechazado == "" ? "0" : _Rechazado;

            return int.Parse(_Rechazado) > 0 ? "X" : "";
        }

        private bool _EsPorDesvio(string WPartida1)
        {
            WPartida1 = WPartida1 == "" ? "0" : WPartida1;

            return ((((int.Parse(WPartida1) >= 190000)
                  && (int.Parse(WPartida1) <= 194999))
                 || (((int.Parse(WPartida1) >= 990000)
                      && (int.Parse(WPartida1) <= 994999))
                     || (((int.Parse(WPartida1) >= 290000)
                          && (int.Parse(WPartida1) <= 294999))
                         || (((int.Parse(WPartida1) >= 390000)
                              && (int.Parse(WPartida1) <= 394999))
                             || (((int.Parse(WPartida1) >= 490000)
                                  && (int.Parse(WPartida1) <= 494999))
                                 || (((int.Parse(WPartida1) >= 590000)
                                      && (int.Parse(WPartida1) <= 594999))
                                     || (((int.Parse(WPartida1) >= 690000)
                                          && (int.Parse(WPartida1) <= 694999))
                                         || (((int.Parse(WPartida1) >= 790000)
                                              && (int.Parse(WPartida1) <= 794999))
                                             || ((int.Parse(WPartida1) >= 890000)
                                                 && (int.Parse(WPartida1) <= 894999))))))))))) ;
        }

        private int _CalcularAtraso(string _FechaOrd, string _FechaOrd2)
        {
            int diferencia = 0;
            
            _FechaOrd = _FechaOrd == "" ? "00000000" : _FechaOrd;
            _FechaOrd2 = _FechaOrd2 == "" ? "00000000" : _FechaOrd2;

            int base1 = (int.Parse(_FechaOrd.Substring(0, 4)) * 365) + (int.Parse(_FechaOrd.Substring(4, 2)) * 30) + (int.Parse(_FechaOrd.Substring(6, 2)) * 1);
            int base2 = (int.Parse(_FechaOrd2.Substring(0, 4)) * 365) + (int.Parse(_FechaOrd2.Substring(4, 2)) * 30) + (int.Parse(_FechaOrd2.Substring(6, 2)) * 1);

            diferencia = base1 - base2;

            if (diferencia < 0 || diferencia > 100)
            {
                diferencia = 0;
            }

            return diferencia;
        }

        private void DGV_EvalSemProve_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _MostrarDetalles(e.RowIndex);
        }

        private void _MostrarDetalles(int RowIndex)
        {
            if (RowIndex < 0) return;
            // Obtengo el numero de Informe.
            string WInforme = DGV_EvalSemProve.Rows[RowIndex].Cells["Informe"].Value.ToString();

            // Obtengo el articulo.
            string WArticulo = DGV_EvalSemProve.Rows[RowIndex].Cells["Articulo"].Value.ToString();

            // Obtengo la Empresa.
            string WEmpresa = DGV_EvalSemProve.Rows[RowIndex].Cells["CSEmpresa"].Value.ToString();

            // Obtengo los datos del Informe para ese Articulo.
            DataRow WDatos = _TraerInformacionEstadoEnvases(WInforme, WArticulo, WEmpresa);

            foreach (
                CheckBox ck in
                    new object[]
                    {
                        ckCumple1, ckCumple2, ckCumple3, ckCumple4, ckCumple5, ckNoCumple1, ckNoCumple2, ckNoCumple3, ckNoCumple4,
                        ckNoCumple5
                    })
            {
                ck.Checked = false;
            }

            ckCumple1.Checked = int.Parse(WDatos["EstadoEnvI"].ToString()) == 1;
            ckCumple2.Checked = int.Parse(WDatos["EstadoEnvIII"].ToString()) == 1;
            ckCumple3.Checked = int.Parse(WDatos["EstadoEnvV"].ToString()) == 1;
            ckCumple4.Checked = int.Parse(WDatos["EstadoEnvVII"].ToString()) == 1;
            ckCumple5.Checked = int.Parse(WDatos["EstadoEnvIX"].ToString()) == 1;
            ckNoCumple1.Checked = int.Parse(WDatos["EstadoEnvII"].ToString()) == 1;
            ckNoCumple2.Checked = int.Parse(WDatos["EstadoEnvIV"].ToString()) == 1;
            ckNoCumple3.Checked = int.Parse(WDatos["EstadoEnvVI"].ToString()) == 1;
            ckNoCumple4.Checked = int.Parse(WDatos["EstadoEnvVIII"].ToString()) == 1;
            ckNoCumple5.Checked = int.Parse(WDatos["EstadoEnvX"].ToString()) == 1;

            txtObs2.Text = WDatos["ObservaI"].ToString();
            txtObs3.Text = WDatos["ObservaII"].ToString();
            txtObs4.Text = WDatos["ObservaIII"].ToString();
            txtObs5.Text = WDatos["ObservaIV"].ToString();

            txtCantRechazada.Text = Helper.FormatoNumerico(WDatos["CantidadEnv"].ToString());

            lblDescEns1.Text = "";
            lblDescEns2.Text = "";
            lblDescEns3.Text = "";
            lblDescEns4.Text = "";
            lblDescEns5.Text = "";

            DataRowCollection WEnsayos = _TraerInformacionEnsayos(WArticulo);

            if (WEnsayos != null)
            {
                lblDescEns1.Text = WEnsayos[0]["Descripcion"].ToString();
                lblDescEns2.Text = WEnsayos[1]["Descripcion"].ToString();
                lblDescEns3.Text = WEnsayos[2]["Descripcion"].ToString();
                lblDescEns4.Text = WEnsayos[3]["Descripcion"].ToString();
                lblDescEns5.Text = WEnsayos[4]["Descripcion"].ToString();
            }

            pnlEstadoEnvases.Location = new Point((Width/2) - (pnlEstadoEnvases.Width/2),
                pnlEstadoEnvases.Location.Y);
            pnlEstadoEnvases.Visible = true;
        }

        private DataRowCollection _TraerInformacionEnsayos(string wArticulo, string wEmpresa = "surfactan_II")
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Ensayo");
            tabla.Columns.Add("Descripcion");

            for (int i = 1; i <= 5; i++)
            {
                tabla.Rows.Add(i, "");
            }

            string[] WEnsayo = new string[6];

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[wEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT isnull(Ensayo1, '0') Ensayo1, isnull(Ensayo2, '0') Ensayo2, isnull(Ensayo3, '0') Ensayo3, isnull(Ensayo4, '0') Ensayo4, isnull(Ensayo5, '0') Ensayo5 FROM EspecificacionesUnifica WHERE Producto = '" + wArticulo + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            for (int i = 1; i <= 5; i++)
                            {
                                WEnsayo[i] = dr["Ensayo" + i].ToString();
                            }
                        }
                    }

                    for (int i = 1; i <= 5; i++)
                    {
                        cmd.CommandText = "SELECT isnull(Descripcion, '') as Descripcion FROM Ensayos WHERE Codigo = '" + WEnsayo[i] + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                tabla.Rows[i - 1]["Descripcion"] = dr["Descripcion"].ToString();
                            }
                        }
                    }

                }

            }
            return tabla.Rows.Count > 0 ? tabla.Rows : null;
        }

        private DataRow _TraerInformacionEstadoEnvases(string wInforme, string wArticulo, string wEmpresa)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[wEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT EstadoEnvI, EstadoEnvII, EstadoEnvIII, EstadoEnvIV, EstadoEnvV,"
                                    + " EstadoEnvVI,EstadoEnvVII,EstadoEnvVIII,EstadoEnvIX,EstadoEnvX, "
                                    + " ObservaI, ObservaII, ObservaIII, ObservaIV, Cantidadenv "
                                    + " FROM Informe WHERE Informe = '"+ wInforme +"' AND Articulo = '" + wArticulo + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            tabla.Load(dr);
                        }
                    }
                }

            }
            return tabla.Rows.Count > 0 ? tabla.Rows[0] : null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlEstadoEnvases.Visible = false;
        }

        private void DGV_EvalSemProve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _MostrarDetalles(e.RowIndex);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            VistaPrevia frm = new VistaPrevia();

            Reporte rpt = new Reporte();

            Detalles tabla = new Detalles();

            foreach (DataRow row in dtInformeDetalle.Rows)
            {
                DataRow _r = tabla.Tables[0].NewRow();

                _r["Clave"] = row["Clave"];
                _r["Informe"] = row["Informe"];
                _r["Orden"] = row["Orden"];
                _r["Articulo"] = row["Articulo"];
                _r["Aprobado"] = (_EsPorDesvio(row["Laudo"].ToString()) || _DeterminarRechazado(row["Devuelta"].ToString()) == "") ? 1 : 0;
                _r["Desvio"] = _EsPorDesvio(row["Laudo"].ToString()) ? 1 : 0;
                _r["Rechazado"] = _DeterminarRechazado(row["Devuelta"].ToString()) == "X" ? 1 : 0;
                _r["Atraso"] = _CalcularAtraso(Helper.OrdenarFecha(row["Fecha"].ToString()), Helper.OrdenarFecha(row["Fecha2"].ToString())); ;
                _r["Cantidad"] =  double.Parse(row["Cantidad"].ToString());
                _r["SaldoOC"] = double.Parse(row["SaldoOC"].ToString());
                _r["DesconOC"] = double.Parse(row["DesconOC"].ToString());
                _r["EnvaseOC"] = row["EnvaseOC"];
                _r["DescEnvaseOC"] = row["DescEnvaseOC"];
                _r["FechaEntrega"] = row["Fecha"];
                _r["FechaPosibleEntrega"] = "";
                _r["Proveedor"] = WCodProv;
                _r["Plantas"] = WPlantas;
                _r["Periodo"] = WPeriodo;

                tabla.Tables[0].Rows.Add(_r);
            }

            rpt.SetDataSource(tabla);

            frm.CargarReporte(rpt);

            frm.Show();
        }

        private void DetalleItemsEnvases_ResizeEnd(object sender, EventArgs e)
        {
            btnImprimir.Location = Helper._CentrarH(Width, btnImprimir);
        }

        private void DetalleItemsEnvases_Paint(object sender, PaintEventArgs e)
        {
            btnImprimir.Location = Helper._CentrarH(Width, btnImprimir);
        }
    }
}
