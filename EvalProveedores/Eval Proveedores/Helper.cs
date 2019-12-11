﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Eval_Proveedores
{
    class Helper
    {
        public static string[] _Empresas = { "SurfactanSA", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII", "Pelitall_II", "Pellital_III", "Pellital_V" };

        public static Point _CentrarH(int containerWidth, Control control)
        {
            return new Point(containerWidth / 2 - control.Width / 2, control.Location.Y);
        }

        public static string OrdenarFecha(string WFecha)
        {
            string WFechaOrd = "0";

            if (WFecha.Trim().Length == 10)
            {
                string[] items = WFecha.Split('/');

                Array.Reverse(items);

                WFechaOrd = string.Join("", items);
            }

            return WFechaOrd;
        }

        public static string Left(string WTexto, int WLongitud)
        {
            if (WTexto.Length <= WLongitud) return WTexto;

            return WTexto.Substring(0, WLongitud);
        }

        public static string Right(string WTexto, int WLongitud)
        {
            if (WTexto.Length <= WLongitud) return WTexto;

            return WTexto.Substring(WTexto.Length - WLongitud, WLongitud);
        }

        public static string Mid(string WTexto, int WInicio, int WFinal)
        {
            //if (WInicio >= WFinal) return WTexto;

            try
            {
                return WTexto.Substring(WInicio, WFinal);
            }
            catch (Exception)
            {
                return WTexto;
            }
        }

        public static DataTable _ProcesarEvaluacionProveedores(string WTipoProv, string WDesde, string WHasta, ref ProgressBar progressBar, string[] WEmpresasAConsultar = null)
        {
            DataTable WProveedores = new DataTable();

            progressBar.Value = 0;
            progressBar.Visible = true;
            WProveedores = _TraerInformacionBasicaDeProveedores(WTipoProv);

            WProveedores.Columns.Add("Movimientos", typeof(int));
            WProveedores.Columns.Add("Aprobados", typeof(int));
            WProveedores.Columns.Add("Desvios", typeof(int));
            WProveedores.Columns.Add("Rechazados", typeof(int));
            WProveedores.Columns.Add("CertificadosOk", typeof(int));
            WProveedores.Columns.Add("EnvasesOk", typeof(int));
            WProveedores.Columns.Add("Retrasos", typeof(int));
            WProveedores.Columns.Add("Pasa", typeof(char));

            if (WProveedores.Rows.Count == 0) return WProveedores;

            // Hago los calculos pertinentes recorriendo cada una de las empresas.
            progressBar.Maximum = WProveedores.Rows.Count;

            // Determinamos las empresas a consultar.
            string[] XEmpresas = WEmpresasAConsultar ?? _Empresas;

            foreach (DataRow WProveedor in WProveedores.Rows)
            {
                int WMovimientos = 0, WCertificadosOk = 0, WEnvasesOk = 0, WDiasRetrasos = 0;
                int WAprobados = 0, WRechazados = 0, WDesvio = 0, WDevuelta = 0;

                WProveedor["Pasa"] = " ";
                
                foreach (string WEmpresa in XEmpresas)
                {
                    DataTable WInformes = _TraerInformesPorProveedorEmpresa(WProveedor["Proveedor"].ToString(), WDesde, WHasta, WEmpresa);

                    if (WInformes.Rows.Count > 0)
                    {
                        // Marco el Proveedor
                        WProveedor["Pasa"] = "S";
                    }

                    foreach (DataRow WInforme in WInformes.Rows)
                    {
                        int WDiferenciaDias = _CalcularDiferenciaDiasEntreInformeYOrden(WInforme["Articulo"].ToString(),
                            WInforme["Orden"].ToString(),
                            WInforme["Fecha"].ToString(),
                            WEmpresa);

                        int WCertificado = WInforme["Certificado1"] == null ? 0 : int.Parse(WInforme["Certificado1"].ToString());
                        if (WCertificado == 1) WCertificadosOk++;

                        int WEstado = WInforme["Estado1"] == null ? 0 : int.Parse(WInforme["Estado1"].ToString());
                        if (WEstado == 1) WEnvasesOk++;

                        WDiasRetrasos += WDiferenciaDias;

                        DataTable WLaudos = _TraerArticulosPorInforme(WInforme["Informe"].ToString(), WInforme["Articulo"].ToString(), WEmpresa);

                        string WNumLaudo = "";

                        //if (WLaudos.Rows.Count == 0) continue;

                        WMovimientos++;

                        foreach (DataRow WLaudo in WLaudos.Rows)
                        {
                            string WMarca = WLaudo["Marca"] == null ? "" : WLaudo["Marca"].ToString();
                            int WDevueltaAnt = 0;

                            WNumLaudo = WLaudo["Laudo"].ToString();

                            if (WMarca.ToUpper() == "X")
                            {
                                WDevueltaAnt = WLaudo["DevueltaAnt"] == null
                                    ? 0
                                    : int.Parse(WLaudo["DevueltaAnt"].ToString());

                                if (WDevueltaAnt != 0)
                                {
                                    WDevuelta++;
                                }
                            }
                            else
                            {
                                WDevueltaAnt = WLaudo["Devuelta"] == null ? 0 : int.Parse(WLaudo["Devuelta"].ToString());

                                if (WDevueltaAnt != 0)
                                {
                                    WDevuelta++;
                                }
                            }

                            if (WDevueltaAnt != 0)
                            {
                                WRechazados++;
                            }
                            else
                            {
                                if (WNumLaudo == "") continue;
                                
                                int XLaudo = int.Parse(WNumLaudo);

                                if (_EsDevio(XLaudo))
                                {
                                    WDesvio++;
                                }
                                else
                                {
                                    WAprobados++;
                                }
                            }
                        }
                    }
                }

                WProveedor["Movimientos"] = WMovimientos;
                WProveedor["CertificadosOk"] = WCertificadosOk;
                WProveedor["EnvasesOk"] = WEnvasesOk;
                WProveedor["Retrasos"] = WMovimientos != 0 ? Math.Truncate((double)WDiasRetrasos / WMovimientos) : WDiasRetrasos;
                WProveedor["Aprobados"] = WMovimientos - WRechazados; //WAprobados;
                WProveedor["Desvios"] = WDesvio;
                WProveedor["Rechazados"] = WRechazados;

                progressBar.Increment(1);
            }

            return WProveedores;
        }

        public static DataTable _ProcesarEvaluacionProveedoresFarma(string WTipoMP, string WDesde, string WHasta, ref ProgressBar progressBar, string[] WEmpresasAConsultar = null)
        {
            DataTable WProveedores = new DataTable();

            //DataTable WListaProveedoresFarma = _TraerProveedoresFarma();

            progressBar.Value = 0;
            progressBar.Visible = true;
            WProveedores = _TraerProveedoresFarma(WTipoMP); //_TraerInformacionBasicaDeProveedores(WTipoMP);

            //WProveedores.Columns.Add("Articulo", typeof(string));
            WProveedores.Columns.Add("Movimientos", typeof(int));
            WProveedores.Columns.Add("Aprobados", typeof(int));
            WProveedores.Columns.Add("Desvios", typeof(int));
            WProveedores.Columns.Add("Rechazados", typeof(int));
            WProveedores.Columns.Add("CertificadosOk", typeof(int));
            WProveedores.Columns.Add("EnvasesOk", typeof(int));
            WProveedores.Columns.Add("Retrasos", typeof(int));
            WProveedores.Columns.Add("Pasa", typeof(char));

            DataTable WDatosFinales = WProveedores.Clone();

            if (WProveedores.Rows.Count == 0) return WProveedores;

            // Hago los calculos pertinentes recorriendo cada una de las empresas.
            progressBar.Maximum = WProveedores.Rows.Count;

            // Determinamos las empresas a consultar.
            string[] XEmpresas = WEmpresasAConsultar ?? _Empresas;

            foreach (DataRow WProveedor in WProveedores.Rows)
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Articulo", typeof(string));
                tabla.Columns.Add("Movimientos", typeof(int));
                tabla.Columns.Add("Aprobados", typeof(int));
                tabla.Columns.Add("Desvios", typeof(int));
                tabla.Columns.Add("Rechazados", typeof(int));
                tabla.Columns.Add("CertificadosOk", typeof(int));
                tabla.Columns.Add("EnvasesOk", typeof(int));
                tabla.Columns.Add("Retrasos", typeof(int));
                tabla.Columns.Add("Pasa", typeof(char));

                WProveedor["Pasa"] = " ";

                foreach (string WEmpresa in XEmpresas)
                {
                    DataTable WInformes = _TraerInformesPorProveedorFarmaEmpresa(WProveedor["Proveedor"].ToString(), WProveedor["Articulo"].ToString(), WDesde, WHasta, WEmpresa);

                    if (WInformes.Rows.Count > 0)
                    {
                        // Marco el Proveedor
                        WProveedor["Pasa"] = "S";
                    }
                    else
                    {
                        DataRow fila = tabla.NewRow();

                        fila["Articulo"] = WProveedor["Articulo"];
                        //fila["Pasa"] = WProveedor["Pasa"];
                        //fila["Proveedor"] = WProveedor["Proveedor"];
                        //fila["Razon"] = WProveedor["Razon"];
                        fila["Movimientos"] = 0;
                        fila["CertificadosOk"] = 0;
                        fila["EnvasesOk"] = 0;
                        fila["Retrasos"] = 0;
                        fila["Aprobados"] = 0;
                        fila["Desvios"] = 0;
                        fila["Rechazados"] = 0;

                        tabla.Rows.Add(fila);
                    }

                    foreach (DataRow WInforme in WInformes.Rows)
                    {
                        int WMovimientos = 0, WCertificadosOk = 0, WEnvasesOk = 0, WDiasRetrasos = 0;
                        int WAprobados = 0, WRechazados = 0, WDesvio = 0, WDevuelta = 0;

                        DataRow fila = tabla.NewRow();

                        int WDiferenciaDias = _CalcularDiferenciaDiasEntreInformeYOrden(WInforme["Articulo"].ToString(),
                            WInforme["Orden"].ToString(),
                            WInforme["Fecha"].ToString(),
                            WEmpresa);

                        int WCertificado = WInforme["Certificado1"] == null ? 0 : int.Parse(WInforme["Certificado1"].ToString());
                        if (WCertificado == 1) WCertificadosOk++;

                        int WEstado = WInforme["Estado1"] == null ? 0 : int.Parse(WInforme["Estado1"].ToString());
                        if (WEstado == 1) WEnvasesOk++;

                        WDiasRetrasos += WDiferenciaDias;

                        DataTable WLaudos = _TraerArticulosPorInforme(WInforme["Informe"].ToString(), WInforme["Articulo"].ToString(), WEmpresa);

                        string WNumLaudo = "";

                        WMovimientos++;

                        fila["Articulo"] = WInforme["Articulo"];

                        foreach (DataRow WLaudo in WLaudos.Rows)
                        {
                            string WMarca = WLaudo["Marca"] == null ? "" : WLaudo["Marca"].ToString();
                            int WDevueltaAnt = 0;

                            WNumLaudo = WLaudo["Laudo"].ToString();

                            if (WMarca.ToUpper() == "X")
                            {
                                WDevueltaAnt = WLaudo["DevueltaAnt"] == null
                                    ? 0
                                    : int.Parse(WLaudo["DevueltaAnt"].ToString());

                                if (WDevueltaAnt != 0)
                                {
                                    WDevuelta++;
                                }
                            }
                            else
                            {
                                WDevueltaAnt = WLaudo["Devuelta"] == null ? 0 : int.Parse(WLaudo["Devuelta"].ToString());

                                if (WDevueltaAnt != 0)
                                {
                                    WDevuelta++;
                                }
                            }

                            if (WDevueltaAnt != 0)
                            {
                                WRechazados++;
                            }
                            else
                            {
                                if (WNumLaudo == "") continue;

                                int XLaudo = int.Parse(WNumLaudo);

                                if (_EsDevio(XLaudo))
                                {
                                    WDesvio++;
                                }
                                else
                                {
                                    WAprobados++;
                                }
                            }
                        }

                        fila["Movimientos"] = WMovimientos;
                        fila["CertificadosOk"] = WCertificadosOk;
                        fila["EnvasesOk"] = WEnvasesOk;
                        fila["Retrasos"] = WMovimientos != 0 ? Math.Truncate((double)WDiasRetrasos / WMovimientos) : WDiasRetrasos;
                        fila["Aprobados"] = WMovimientos - WRechazados; //WAprobados;
                        fila["Desvios"] = WDesvio;
                        fila["Rechazados"] = WRechazados;

                        tabla.Rows.Add(fila);
                    }
                }

                DataTable codigos = (new DataView(tabla)).ToTable(true, "Articulo");

                foreach (DataRow codigo in codigos.Rows)
                {
                    DataRow filaProv = WDatosFinales.NewRow();

                    filaProv["Proveedor"] = WProveedor["Proveedor"];
                    filaProv["Razon"] = WProveedor["Razon"];
                    filaProv["Pasa"] = WProveedor["Pasa"];

                    filaProv["Movimientos"] = 0;
                    filaProv["CertificadosOk"] = 0;
                    filaProv["EnvasesOk"] = 0;
                    filaProv["Retrasos"] = 0;
                    filaProv["Aprobados"] = 0;
                    filaProv["Desvios"] = 0;
                    filaProv["Rechazados"] = 0;

                    DataRow[] datos = tabla.Select("Articulo = '" + codigo["Articulo"] + "'");

                    foreach (DataRow fila in datos)
                    {
                        filaProv["Articulo"] = fila["Articulo"];
                        filaProv["Movimientos"] = int.Parse(filaProv["Movimientos"].ToString()) + int.Parse(fila["Movimientos"].ToString()); //WMovimientos;
                        filaProv["CertificadosOk"] = int.Parse(filaProv["CertificadosOk"].ToString()) + int.Parse(fila["CertificadosOk"].ToString()); //WCertificadosOk;
                        filaProv["EnvasesOk"] = int.Parse(filaProv["EnvasesOk"].ToString()) + int.Parse(fila["EnvasesOk"].ToString()); //WEnvasesOk;
                        filaProv["Retrasos"] = int.Parse(filaProv["Retrasos"].ToString()) + int.Parse(fila["Retrasos"].ToString()); ; //WMovimientos != 0 ? Math.Truncate((double)WDiasRetrasos / WMovimientos) : WDiasRetrasos;
                        filaProv["Aprobados"] = int.Parse(filaProv["Aprobados"].ToString()) + int.Parse(fila["Aprobados"].ToString()); ; //WMovimientos - WRechazados; //WAprobados;
                        filaProv["Desvios"] = int.Parse(filaProv["Desvios"].ToString()) + int.Parse(fila["Desvios"].ToString()); ; // WDesvio;
                        filaProv["Rechazados"] = int.Parse(filaProv["Rechazados"].ToString()) + int.Parse(fila["Rechazados"].ToString()); ; // WRechazados;
                    }

                    WDatosFinales.Rows.Add(filaProv);

                }

                progressBar.Increment(1);
            }

            return WDatosFinales;
        }

        private static DataTable _TraerProveedoresFarma(string WTipoMP = "")
        {
            // Armamos el filtro para tipo de MP.
            string WFiltro = _GenerarFiltroPorTipo(WTipoMP);

            DataTable tabla = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT distinct p.Proveedor, p.Nombre Razon, ct.Articulo FROM Proveedor p INNER JOIN Cotiza ct ON ct.Proveedor = p.Proveedor INNER JOIN Articulo a ON a.Codigo = ct.Articulo AND (" + WFiltro + ") ORDER BY p.nombre, ct.Articulo";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            tabla.Load(dr);
                        }
                    }
                }

            }

            return tabla;
        }

        private static string _GenerarFiltroPorTipo(string wTipoMp)
        {
            switch (wTipoMp)
            {
                case "0":
                {
                    return "ISNULL(a.ClasificacionFarma,0) = 1 Or (ISNULL(a.ClasificacionFarma,0) = 0 And a.ReqEvalEspecial = '1') Or (ISNULL(a.ClasificacionFarma,0) > 1 And a.ReqEvalEspecial = '1') ";
                }
                case "1":
                {
                    return "ISNULL(a.ClasificacionFarma,0) = 1";
                }
                default:
                {
                    return string.Format("ISNULL(a.ClasificacionFarma,0) = ${0} And a.ReqEvalEspecial = '1'", wTipoMp);
//                    return "ISNULL(a.ClasificacionFarma, 0) = 0 And a.ReqEvalEspecial = '1'";
                }
            }
        }

        public static string _DeterminarCalidad(string ZCategoriaI)
        {
            string Calidad = "";

            switch (ZCategoriaI)
            {
                case "1":
                    {
                        Calidad = "A";
                        break;
                    }
                case "2":
                    {
                        Calidad = "B";
                        break;
                    }
                case "3":
                    {
                        Calidad = "C";
                        break;
                    }
                case "4":
                    {
                        Calidad = "E";
                        break;
                    }
                default:
                    {
                        Calidad = "";
                        break;
                    }
            }

            return Calidad;
        }

        public static string _DeterminarPorcentajeTotal(double ZMovimientos, double ZCertificadosOk, double ZEnvasesOk)
        {
            return ZMovimientos != 0 ? Math.Round(((ZCertificadosOk + ZEnvasesOk) / (ZMovimientos * 2)) * 100, 2).ToString() : "";
        }

        public static string _DeterminarPorcentajeRelacion(double ZMovimientos, double ZCantidadOk)
        {
            return ZMovimientos != 0 ? Math.Round(((ZCantidadOk * 100) / ZMovimientos), 2).ToString() : "";
        }

        public static string _DeterminarCalidadEntrega(string ZCategoriaII)
        {
            string Calidad = "";

            switch (ZCategoriaII)
            {
                case "1":
                    {
                        Calidad = "Muy Bueno";
                        break;
                    }
                case "2":
                    {
                        Calidad = "Bueno";
                        break;
                    }
                case "3":
                    {
                        Calidad = "Regular";
                        break;
                    }
                case "4":
                    {
                        Calidad = "Malo";
                        break;
                    }
                default:
                    {
                        Calidad = "Sin Calificar";
                        break;
                    }
            }

            return Calidad;
        }

        public static bool _EsDevio(int XLaudo)
        {
            return (((XLaudo >= 190000)
                     && (XLaudo <= 194999))
                    || (((XLaudo >= 990000)
                         && (XLaudo <= 994999))
                        || (((XLaudo >= 290000)
                             && (XLaudo <= 294999))
                            || ((XLaudo >= 390000)
                                && (XLaudo <= 394999))
                            || (((XLaudo >= 490000)
                                 && (XLaudo <= 494999))
                                || (((XLaudo >= 590000)
                                     && (XLaudo <= 594999))
                                    || (((XLaudo >= 690000)
                                         && (XLaudo <= 694999))
                                        || (((XLaudo >= 790000)
                                             && (XLaudo <= 794999))
                                            || ((XLaudo >= 890000)
                                                && (XLaudo <= 894999)))))))));
        }

        public static DataTable _TraerArticulosPorInforme(string WInforme, string WArticulo, string WEmpresa)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[WEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Laudo, Marca, DevueltaAnt, Devuelta FROM Laudo WHERE Informe = '" + WInforme + "' AND Articulo = '" + WArticulo + "' AND (Liberada <> 0 OR Devuelta <> 0) ORDER BY Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            tabla.Load(dr);
                        }
                    }
                }

            }

            return tabla;
        }

        public static int _CalcularDiferenciaDiasEntreInformeYOrden(string WArticulo, string WOrden, string WFechaInforme, string WEmpresa)
        {
            int WDiferencia = 0;
            string XFecha = "00/00/0000", XFechaOrd = "0";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[WEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Fecha2 FROM Orden WHERE Articulo = '" + WArticulo + "' AND Orden = '" + WOrden + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            XFecha = dr["Fecha2"].ToString();
                        }
                    }
                }

            }

            XFechaOrd = OrdenarFecha(XFecha);
            string WFechaOrd = OrdenarFecha(WFechaInforme);

            int WAno = int.Parse(Left(XFechaOrd, 4));
            int WMes = int.Parse(Mid(XFechaOrd, 4, 2));
            int WDia = int.Parse(Right(XFechaOrd, 2));

            var Base1 = (WAno * 365) + (WMes * 30) + (WDia);

            WAno = int.Parse(Left(WFechaOrd, 4));
            WMes = int.Parse(Mid(WFechaOrd, 4, 2));
            WDia = int.Parse(Right(WFechaOrd, 2));

            var Base2 = (WAno * 365) + (WMes * 30) + (WDia);

            WDiferencia = Base2 - Base1;

            if (WDiferencia < 0 || WDiferencia > 100) WDiferencia = 0;

            return WDiferencia;
        }

        public static DataTable _TraerInformesPorProveedorEmpresa(string WProveedor, string WFechaDesde, string WFechaHasta, string wEmpresa)
        {
            DataTable WInformes = new DataTable();
            string WDesde = OrdenarFecha(WFechaDesde);
            string WHasta = OrdenarFecha(WFechaHasta);

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[wEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT i.Clave, i.Informe, i.Fecha, i.FechaOrd, i.Orden, i.Articulo, i.Cantidad, i.Certificado1, i.Estado1 FROM Informe i INNER JOIN Articulo a ON a.Codigo = i.Articulo WHERE i.Proveedor = '" + WProveedor + "' AND i.FechaOrd BETWEEN " + WDesde + " AND " + WHasta + " ORDER BY i.Informe, i.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WInformes.Load(dr);
                        }
                    }
                }

            }

            return WInformes;
        }

        public static DataTable _TraerInformesPorProveedorFarmaEmpresa(string WProveedor, string WArticulo, string WFechaDesde, string WFechaHasta, string wEmpresa)
        {
            DataTable WInformes = new DataTable();
            string WDesde = OrdenarFecha(WFechaDesde);
            string WHasta = OrdenarFecha(WFechaHasta);

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[wEmpresa].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT i.Clave, i.Informe, i.Fecha, i.FechaOrd, i.Orden, i.Articulo, i.Cantidad, i.Certificado1, i.Estado1 FROM Informe i WHERE i.Articulo = '" + WArticulo + "' And i.Proveedor = '" + WProveedor + "' AND i.FechaOrd BETWEEN " + WDesde + " AND " + WHasta + " ORDER BY i.Informe, i.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WInformes.Load(dr);
                        }
                    }
                }

            }

            return WInformes;
        }

        public static DataTable _TraerInformacionBasicaDeProveedores(string WTipoProv)
        {
            DataTable WProveedores = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    
                    cmd.CommandText = "update Proveedor SET FechaCategoria = '' WHERE len(replace(FechaCategoria, ' ','')) < 8 or FechaCategoria is null";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update Proveedor SET FechaCalCalidad = '' WHERE len(replace(FechaCalCalidad, ' ','')) < 8 or FechaCalCalidad is null";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update Proveedor SET FechaCalEnvases = '' WHERE len(replace(FechaCalEnvases, ' ','')) < 8 or FechaCalEnvases is null";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update Proveedor SET FechaCalEntrega = '' WHERE len(replace(FechaCalEntrega, ' ','')) < 8 or FechaCalEntrega is null";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT Proveedor, Nombre as Razon, CategoriaI, CategoriaII, FechaCategoria, FechaCalCalidad, FechaCalEnvases, FechaCalEntrega FROM Proveedor WHERE TipoProv = '" + WTipoProv + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WProveedores.Load(dr);
                        }
                    }
                }

            }

            return WProveedores;

        }

        public static string FormatoNumerico(string WValor, int WCantDigitos = 2, string WSeparadorDecimales = ".")
        {
            string WValorArmado = "";

            if (WValor.Trim() == "") WValor = "0";
            
            // Normalizamos el numero, porque hay casos en que vienen del estilo '.5' o '5.'
            if (WValor.Trim().EndsWith(".")) WValor += "0";
            if (WValor.Trim().EndsWith(".")) WValor += "0";
            if (WValor.Trim().StartsWith(",")) WValor = "0" + WValor;
            if (WValor.Trim().StartsWith(".")) WValor = "0" + WValor;

            WValor = WValor.Replace('.', ',');

            WValor =  Math.Round(double.Parse(WValor), WCantDigitos).ToString();

            if (WValor.IndexOf(',') > -1)
            {
                int i = WValor.IndexOf(',');

                WValorArmado = WValor.Substring(0, i);

                WValorArmado += WSeparadorDecimales;

                string WDecimales = WValor.Substring(i + 1, WValor.Length - i - 1);

                return WValorArmado + WDecimales.PadRight(WCantDigitos, '0');
            }
            
            return (WValor.Trim() + ".") + "".PadRight(WCantDigitos, '0');
        }

        public static string FormatoNumerico(double wValor, int WCantDigitos = 2)
        {
            return FormatoNumerico(wValor.ToString(), WCantDigitos);
        }

        public static object _CalcularAtraso(string _FechaOrd, string _FechaOrd2)
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

        public static object OrDefault(object value, object DefaulValue)
        {
            if (value == null || value.GetType() == Type.GetType("System.DBNull")) return DefaulValue;

            return value;
        }
    }
}
