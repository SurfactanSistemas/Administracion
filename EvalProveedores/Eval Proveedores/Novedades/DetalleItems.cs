using System;
using System.Data;
using System.Windows.Forms;
using Util;
using Eval_Proveedores.Listados.DetalleItemsMP;
using VistaPrevia = Eval_Proveedores.Listados.VistaPrevia;

namespace Eval_Proveedores.Novedades
{
    public partial class DetalleItems : Form
    {
        private readonly DataTable dtInformeDetalle;
        private readonly string WCodProv = "";
        private readonly string WPeriodo = "";
        private readonly string WPlantas = "";
        private readonly string WCodMp = "";

        public DetalleItems()
        {
            InitializeComponent();
        }

        public DetalleItems(DataTable dtInformeDetalle)
        {
            this.dtInformeDetalle = dtInformeDetalle;
            InitializeComponent();
        }

        public DetalleItems(DataTable dtInformeDetalle, string _CodProv, string WProveedor, string _Periodo, string _Plantas, string CodMP = "")
        {
            WCodMp = CodMP;
            this.dtInformeDetalle = dtInformeDetalle;
            InitializeComponent();
            lblProveedor.Text = WProveedor;
            WCodProv = _CodProv;
            WPeriodo = _Periodo;
            WPlantas = _Plantas;
        }

        private void DetalleItems_Load(object sender, EventArgs e)
        {
            ArmarDt();
        }

        private void ArmarDt()
        {
            DGV_EvalSemProve.Rows.Clear();

            DataRow[] WDatos = WCodMp == "" ? dtInformeDetalle.Select() : dtInformeDetalle.Select("Articulo = '" + WCodMp + "'") ;

            foreach (DataRow fila in dtInformeDetalle.Rows)
            {
                var _index = DGV_EvalSemProve.Rows.Add();

                DGV_EvalSemProve.Rows[_index].Cells["Articulo"].Value = fila["Articulo"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Orden"].Value = fila["Orden"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Desviad"].Value = fila["Clave"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["DescArticulo"].Value = fila["DesArticulo"].ToString(); //_TraerDescArticulo(fila["Articulo"].ToString());
                DGV_EvalSemProve.Rows[_index].Cells["Atraso"].Value = _CalcularAtraso(Helper.OrdenarFecha(fila["Fecha"].ToString()), Helper.OrdenarFecha(fila["Fecha2"].ToString()));
                DGV_EvalSemProve.Rows[_index].Cells["Desvio"].Value = _EsPorDesvio(fila["Laudo"].ToString()) ? "X" : "";
                DGV_EvalSemProve.Rows[_index].Cells["Aprobado"].Value = (_EsPorDesvio(fila["Laudo"].ToString()) || _DeterminarRechazado(fila["Devuelta"].ToString()) == "") ? "X" : "";

                DGV_EvalSemProve.Rows[_index].Cells["Certificado"].Value = fila["Certificado1"].ToString() == "1" ? "SI" : "NO";

                DGV_EvalSemProve.Rows[_index].Cells["Envase"].Value = fila["Estado1"].ToString() == "1" ? "SI" : "NO";

                DGV_EvalSemProve.Rows[_index].Cells["Informe"].Value = fila["Informe"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Cantidad"].Value = fila["Cantidad"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["FechaEntrega"].Value = fila["fecha"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["FechaPosibleEntrega"].Value = fila["Fecha2"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Liberada"].Value = fila["Liberada"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Laudo"].Value = fila["Laudo"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Devuelta"].Value = fila["Devuelta"].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Rechazado"].Value = _DeterminarRechazado(fila["Devuelta"].ToString());

                 //dtItems.Rows.Add(filaItems);
            }

            foreach (string WColumna in new [] { "Cantidad", "FechaPosibleEntrega" })
            {
                DataGridViewColumn column = DGV_EvalSemProve.Columns[WColumna];
                if (column != null) column.Visible = false;
            }

            //foreach (DataGridViewRow row in DGV_EvalSemProve.Rows)
            //{

            //    row.Cells["DescArticulo"].Value = _TraerDescArticulo(row.Cells["Articulo"].ToString());

            //}
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

        private int _CalcularAtraso(object _FechaOrd, object _FechaOrd2)
        {
            int diferencia = 0;

            _FechaOrd = _FechaOrd.ToString() == "" ? "00000000" : _FechaOrd;
            _FechaOrd2 = _FechaOrd2.ToString() == "" ? "00000000" : _FechaOrd2;

            _FechaOrd = _FechaOrd.ToString().PadLeft(8, '0');
            _FechaOrd2 = _FechaOrd2.ToString().PadLeft(8, '0');

            int base1 = (int.Parse(_FechaOrd.ToString().Substring(0, 4)) * 365) + (int.Parse(_FechaOrd.ToString().Substring(4, 2)) * 30) + (int.Parse(_FechaOrd.ToString().Substring(6, 2)) * 1);
            int base2 = (int.Parse(_FechaOrd2.ToString().Substring(0, 4)) * 365) + (int.Parse(_FechaOrd2.ToString().Substring(4, 2)) * 30) + (int.Parse(_FechaOrd2.ToString().Substring(6, 2)) * 1);

            diferencia = base1 - base2;

            if (diferencia < 0 || diferencia > 100)
            {
                diferencia = 0;
            }

            return diferencia;
        }

        private void DetalleItemsEnvases_ResizeEnd(object sender, EventArgs e)
        {
            btnImprimir.Location = Helper._CentrarH(Width, btnImprimir);
        }

        private void DetalleItemsEnvases_Paint(object sender, PaintEventArgs e)
        {
            btnImprimir.Location = Helper._CentrarH(Width, btnImprimir);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            VistaPrevia frm = new VistaPrevia();

            Reporte rpt = new Reporte();

            Detalles tabla = new Detalles();

            foreach (DataRow row in dtInformeDetalle.Rows)
            {
                DataRow _r = tabla.Tables[0].NewRow();

                _r["Clave"] = row["Desviad"];
                _r["Informe"] = row["Informe"];
                _r["Orden"] = row["Orden"];
                _r["Articulo"] = row["Articulo"];
                _r["Aprobado"] = (_EsPorDesvio(row["Laudo"].ToString()) || _DeterminarRechazado(row["Devuelta"].ToString()) == "") ? 1 : 0;
                _r["Desvio"] = _EsPorDesvio(row["Laudo"].ToString()) ? 1 : 0;
                _r["Rechazado"] = _DeterminarRechazado(row["Devuelta"].ToString()) == "X" ? 1 : 0;
                _r["Atraso"] = _CalcularAtraso(Helper.OrdenarFecha(row["Fecha"].ToString()), Helper.OrdenarFecha(row["Fecha2"].ToString()));
                _r["Cantidad"] = double.Parse(row["Liberada"].ToString());
                _r["Laudo"] = row["Laudo"];
                _r["Devuelta"] = double.Parse(row["Devuelta"].ToString());
                //_r["DesconOC"] = double.Parse(row["DesconOC"].ToString());
                _r["Certificado"] = row["Certificado1"].ToString() == "1" ? "SI" : "NO";
                _r["Envase"] = row["Estado1"].ToString() == "1" ? "SI" : "NO";
                //_r["DescEnvaseOC"] = row["DescEnvaseOC"];
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

        private void DGV_EvalSemProve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn ColLaudo = DGV_EvalSemProve.Columns["Laudo"];

            if (ColLaudo != null && e.ColumnIndex == ColLaudo.Index)
            {
                DetallesEnsayosMP frm = new DetallesEnsayosMP(DGV_EvalSemProve.CurrentCell.Value);
                frm.Show(this);
            }
        }
    }
}
