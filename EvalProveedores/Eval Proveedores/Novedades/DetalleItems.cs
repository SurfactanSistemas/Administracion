using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Eval_Proveedores.Novedades
{
    public partial class DetalleItems : Form
    {
        private DataTable dtInformeDetalle;
        DataTable dtItems = new DataTable();

        public DetalleItems()
        {
            InitializeComponent();
        }

        public DetalleItems(DataTable dtInformeDetalle)
        {
            // TODO: Complete member initialization
            this.dtInformeDetalle = dtInformeDetalle;
            InitializeComponent();
        }

        private void DetalleItems_Load(object sender, EventArgs e)
        {

            //DGV_EvalSemProve.Columns.Clear();
            ArmarDt();
            //DGV_EvalSemProve.DataSource = dtItems;
        }

        private string _TraerDescArticulo(string _Articulo)
        {
            using (SqlConnection cnn = new SqlConnection())
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString();

                cnn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Articulo WHERE Codigo = '" + _Articulo +"'";
                    cmd.Connection = cnn;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            rd.Read();

                            return rd["Descripcion"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }

                }

            }
        }
        
        private void ArmarDt()
        {
            //dtItems.Columns.Add("Articulo", typeof(string));
            //dtItems.Columns.Add("Orden", typeof(string));
            //dtItems.Columns.Add("Clave", typeof(string));
            //dtItems.Columns.Add("DescArticulo", typeof(string));
            //dtItems.Columns.Add("Certifica", typeof(string));
            //dtItems.Columns.Add("Envase", typeof(string));
            //dtItems.Columns.Add("Informe", typeof(string));
            //dtItems.Columns.Add("Cantidad", typeof(string));
            //dtItems.Columns.Add("Fecha", typeof(string));
            //dtItems.Columns.Add("Fecha2", typeof(string));
            //dtItems.Columns.Add("Liberada", typeof(string));
            //dtItems.Columns.Add("Laudo", typeof(string));
            //dtItems.Columns.Add("Devuelta", typeof(string));
            int _index = 0;
            DGV_EvalSemProve.Rows.Clear();

            foreach (DataRow fila in dtInformeDetalle.Rows)
            {
                _index = DGV_EvalSemProve.Rows.Add();

                DGV_EvalSemProve.Rows[_index].Cells["Articulo"].Value = fila[0].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Orden"].Value = fila[1].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Desviad"].Value = fila[3].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["DescArticulo"].Value = _TraerDescArticulo(fila[0].ToString());
                DGV_EvalSemProve.Rows[_index].Cells["Atraso"].Value = _CalcularAtraso(fila[2], fila[10]);
                DGV_EvalSemProve.Rows[_index].Cells["Desvio"].Value = _EsPorDesvio(fila[15].ToString()) ? "X" : "";


                if (fila[5].ToString() == "1")
                {
                    DGV_EvalSemProve.Rows[_index].Cells["Certificado"].Value = "SI";
                    DGV_EvalSemProve.Rows[_index].Cells["Aprobado"].Value = "X";
                }
                else
                {
                    DGV_EvalSemProve.Rows[_index].Cells["Certificado"].Value = "NO";
                    DGV_EvalSemProve.Rows[_index].Cells["Aprobado"].Value = "";
                }

                if (fila[6].ToString() == "1")
                {
                    DGV_EvalSemProve.Rows[_index].Cells["Envase"].Value = "SI";
                }
                else
                {
                    DGV_EvalSemProve.Rows[_index].Cells["Envase"].Value = "NO";
                }
                DGV_EvalSemProve.Rows[_index].Cells["Informe"].Value = fila[6].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Cantidad"].Value = fila[7].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["FechaEntrega"].Value = fila[8].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["FechaPosibleEntrega"].Value = fila[9].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Liberada"].Value = fila[13].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Laudo"].Value = fila[15].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Devuelta"].Value = fila[16].ToString();
                DGV_EvalSemProve.Rows[_index].Cells["Rechazado"].Value = _DeterminarRechazado(fila[16].ToString());

                 //dtItems.Rows.Add(filaItems);
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

            _FechaOrd = _FechaOrd.ToString();
            _FechaOrd2 = _FechaOrd2.ToString();

            _FechaOrd = _FechaOrd == "" ? "00000000" : _FechaOrd;
            _FechaOrd2 = _FechaOrd2 == "" ? "00000000" : _FechaOrd2;

            int base1 = (int.Parse(_FechaOrd.ToString().Substring(0, 4)) * 365) + (int.Parse(_FechaOrd.ToString().Substring(4, 2)) * 30) + (int.Parse(_FechaOrd.ToString().Substring(6, 2)) * 1);
            int base2 = (int.Parse(_FechaOrd2.ToString().Substring(0, 4)) * 365) + (int.Parse(_FechaOrd2.ToString().Substring(4, 2)) * 30) + (int.Parse(_FechaOrd2.ToString().Substring(6, 2)) * 1);

            diferencia = base1 - base2;

            if (diferencia < 0 || diferencia > 100)
            {
                diferencia = 0;
            }

            return diferencia;
        }
    }
}
