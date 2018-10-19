using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Vista
{
    public partial class ImpreEtiquetChic : Form
    {
        private DataTable dt;
        int[] CantidadesDeEtiquetas;
        string tipo;
        int posicion;
        Boolean _Traducir;
        const Boolean _EnProduccion = true; // Dejar en TRUE cuando se está en producción
                                            // Cambiar a FALSE cuando se trabaje en desarrollo.

        public ImpreEtiquetChic(DataTable ds, int[] CantidadesDeEtiquetas, string Tipo, int Posicion = 0, Boolean traducir = false)
        {
            InitializeComponent();
            dt = ds;
            this.CantidadesDeEtiquetas = CantidadesDeEtiquetas;
            tipo = Tipo;
            posicion = Posicion;
            _Traducir = traducir;
        }

        private void CRVEtiquetas_Load(object sender, EventArgs e)
        {
            int NumEtiquetaActual = 0;
            int HojaActual = 0;

            DSEtiq1[] Dss = new DSEtiq1[CalcularCantidadDeHojas()];

            Dss[HojaActual] = new DSEtiq1();

            if (tipo != "Grande")
            {
                // Dejamos en blanco las primeras etiquetas en caso de seleccionar una posicion que no se la de por defecto.
                int WPosicion = (tipo == "Chica") ? posicion * 2 : posicion;

                for (int j = 0; j < WPosicion; j++)
                {
                    DataRow dr = dt.Rows[0];
                    Dss[0].Tables[NumEtiquetaActual].Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                    NumEtiquetaActual++;
                }
            }

            for (int row = 0; row < dt.Rows.Count; row++)
            {
                for (int i = 0; i < CantidadesDeEtiquetas[row]; i++)
                {
                    DataRow dr = dt.Rows[row];

                    // Quitamos espacios en blanco.

                    for (int x = 0; x < dr.ItemArray.Count(); x++) {

                        dr[x] = dr[x].ToString().Trim();
                    
                    }
                    
                    string[] SGA = _ObtenerDatosSGA(dr[2].ToString());

                    if (tipo == "Chica") {
                        Dss[HojaActual].Tables[NumEtiquetaActual].Rows.Add(
                            dr[4], dr[3], dr[9],
                            dr[6], dr[7], dr[0],
                            dr[10], dr[8], dr[5],
                            SGA[0], SGA[1], SGA[2],
                            SGA[3], SGA[4], SGA[5],
                            SGA[6], SGA[7], SGA[8],
                            SGA[9], SGA[10], SGA[11], SGA[14],
                            SGA[15], SGA[16], SGA[17],
                            SGA[18], SGA[19], SGA[20],
                            SGA[21], SGA[22], SGA[23],
                            SGA[24], SGA[25], SGA[26],
                            SGA[27], SGA[28], "", "", SGA[12], dr[11]
                        );

                        NumEtiquetaActual++;

                        Dss[HojaActual].Tables[NumEtiquetaActual].Rows.Add(
                            dr[4], dr[3], dr[9],
                            dr[6], dr[7], dr[0],
                            dr[10], dr[8], dr[5],
                            SGA[0], SGA[1], SGA[2],
                            SGA[3], SGA[4], SGA[5],
                            SGA[6], SGA[7], SGA[8],
                            SGA[9], SGA[10], SGA[11], SGA[14],
                            SGA[15], SGA[16], SGA[17],
                            SGA[18], SGA[19], SGA[20],
                            SGA[21], SGA[22], SGA[23],
                            SGA[24], SGA[25], SGA[26],
                            SGA[27], SGA[28], "", "", SGA[12], dr[11]
                        );

                        NumEtiquetaActual++;
                    } 
                    else{

                        Dss[HojaActual].Tables[NumEtiquetaActual].Rows.Add(
                            dr[4], dr[3], dr[9],
                            dr[6], dr[7], dr[0],
                            dr[10], dr[8], dr[5],
                            SGA[0], SGA[1], SGA[2],
                            SGA[3], SGA[4], SGA[5],
                            SGA[6], SGA[7], SGA[8],
                            SGA[9], SGA[10], SGA[11], SGA[14],
                            SGA[15], SGA[16], SGA[17],
                            SGA[18], SGA[19], SGA[20],
                            SGA[21], SGA[22], SGA[23],
                            SGA[24], SGA[25], SGA[26],
                            SGA[27], SGA[28], "", "", SGA[12], dr[11]
                        );

                        NumEtiquetaActual++;
                    }

                    if (EsFinalDeHoja(NumEtiquetaActual))
                    {
                        NumEtiquetaActual = 0;

                        HojaActual++;

                        if (HojaActual < CalcularCantidadDeHojas())
                        {
                            Dss[HojaActual] = new DSEtiq1();
                        }
                    }
                }
            }
            
            
            foreach (DSEtiq1 ds in Dss)
            {
                DSEtiq1 _ds = ds;
                ReportClass ECImp = ObtenerRptSegunTipo();

                ECImp.SetDataSource(_ds);

                if (_EnProduccion)
                {

                    //CRVEtiquetas.Visible = true;
                    //CRVEtiquetas.ReportSource = ECImp;
                    ECImp.PrintToPrinter(1, true, 0, 0);

                    Close();
                }
                else
                {
                    CRVEtiquetas.Visible = true;
                    CRVEtiquetas.ReportSource = ECImp;
                }

            }
        }

        private string _DeterminarTabla(string codigo)
        {
            switch (codigo.Substring(0, 2))
            {
                case "PT": case "YQ": case "YF": case "YP":
                    // Porque los datos para la etiquetas de frasco se encuentran en otra tabla.
                    return (tipo == "Frasco" || tipo == "Chica") && !_Traducir ? "DatosEtiqueta" : "DatosEtiquetaImpre";
                    break;
                default:
                    return !_Traducir ? "DatosEtiquetaMP" : "DatosEtiquetaImpre";
                    break;
            }
        }

        private string _DeterminarColumna(string codigo)
        {
            switch (codigo.Substring(0, 2))
            {
                case "PT": case "YQ": case "YF": case "YP":
                    return "Terminado";
                    break;
                default:
                    return "Articulo";
                    break;
            }
        }

        private string[] _ObtenerDatosSGA(string _Codigo)
        {
            string[] datos = new string[31];

            string sufix = _Traducir ? "Ingles" : "";

            bool _ViejoTraducir = _Traducir;

            if (_Codigo.Substring(0, 2).ToUpper() == "DY")
            {
                sufix = "";
                _Traducir = false;
            }

            for (int i = 0; i < 31; i++) {

                datos[i] = "";
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
                {
                    cn.Open();

                    string Tabla = _DeterminarTabla(_Codigo);
                    string Columna = _DeterminarColumna(_Codigo);

                    SqlCommand cmd = new SqlCommand("Select * From " + Tabla + " WHERE " + Columna + " = '" + _Codigo.Trim() + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        int renglon = 8;
                        int pictograma = 1;

                        int _tipo = (tipo == "Chica" || tipo == "Frasco" || Tabla == "DatosEtiquetaMP") ? 0 : 1;

                        switch (_tipo)
                        {
                            case 0:
                                datos[0] = dr["Frase1" + sufix].ToString();
                                datos[1] = dr["Frase2" + sufix].ToString();
                                datos[2] = dr["Frase3" + sufix].ToString();
                                datos[3] = dr["Frase4" + sufix].ToString();
                                datos[4] = dr["Frase5" + sufix].ToString();
                                datos[5] = dr["Frase6" + sufix].ToString();
                                datos[6] = dr["Frase7" + sufix].ToString();
                                break;
                            default:
                                // Arranca del 14 porque se agregaron cantidades de frases despues.
                                datos[14] = dr["Frase9" + sufix].ToString();
                                datos[15] = dr["Frase10" + sufix].ToString();
                                datos[16] = dr["Frase11" + sufix].ToString();
                                datos[17] = dr["Frase12" + sufix].ToString();
                                datos[18] = dr["Frase13" + sufix].ToString();
                                datos[19] = dr["Frase14" + sufix].ToString();
                                datos[20] = dr["Frase15" + sufix].ToString();
                                datos[21] = dr["Frase16" + sufix].ToString();
                                datos[22] = dr["Frase17" + sufix].ToString();
                                datos[23] = dr["Frase18" + sufix].ToString();
                                datos[24] = dr["Frase19" + sufix].ToString();
                                datos[25] = dr["Frase20" + sufix].ToString();
                                datos[26] = dr["Frase21" + sufix].ToString();
                                datos[27] = dr["Frase22" + sufix].ToString();
                                datos[28] = dr["Frase23" + sufix].ToString(); // Aca va la frase de peligro cuando no es etiqueta Frasco.
                                break;
                        }

                        datos[7] = (_tipo == 0) ? dr["Frase8" + sufix].ToString() : datos[28]; // Guardamos la "palabra"


                        if (_Codigo.StartsWith("DY")) { // Porque se lo trata como una MP.

                            for (int i = 0; i < 7; i++) {

                                datos[i + 14] = datos[i];
                            }
                        
                        }

                        if (datos[7] == "") {

                            var exists = Enumerable.Range(0, dr.FieldCount).Any(i => string.Equals(dr.GetName(i), "Palabra", StringComparison.OrdinalIgnoreCase));

                            string pal = exists ? dr["Palabra"].ToString().Trim() : "";

                            switch (pal)
                            {
                                case "1":
                                    pal = (_Traducir) ? "Danger" : "Peligro";
                                    break;

                                case "2":
                                    pal = (_Traducir) ? "Warning" : "Atención";
                                    break;

                                default:
                                    pal = "";
                                    break;
                            }

                            datos[7] = pal;

                        }
                        else
                        {
                            if (_Traducir)
                            {
                                datos[7] = datos[7].Replace("Peligro", "DANGER");
                                datos[7] = datos[7].Replace("PELIGRO", "DANGER");
                                datos[7] = datos[7].Replace("Atención", "WARNING");
                                datos[7] = datos[7].Replace("Atencion", "WARNING");
                                datos[7] = datos[7].Replace("ATENCIÓN", "WARNING");
                                datos[7] = datos[7].Replace("ATENCION", "WARNING");
                            }
                        }


                        while (pictograma <= 9 && renglon < 13)
                        {
                            if (Int32.Parse(dr["Pictograma" + pictograma].ToString()) != 0)
                            {
                                datos[renglon] = _ObtenerRutaImagenSGA(pictograma.ToString());
                                renglon++;
                            }

                            pictograma++;
                        }

                        while (renglon < 13)
                        {
                            datos[renglon] = _ObtenerRutaImagenSGA("0"); // Llenamos los campos de pictogramas faltantes con el rombo tachado.
                            renglon++;
                        }

                    }
                    else
                    {
                        if (Tabla != "DatosEtiquetaImpre")
                        {
                            int i = 0;

                            while (i <= 13)
                            {
                                datos[i] = i >= 8 ? _ObtenerRutaImagenSGA("0") : ""; // Llenamos con rombos tachados los pictogramas.

                                i++;
                            }
                        }
                        else {
                            // Hay casos en los que se encuentran cargados datos en esta otra tabla. Se hacen compatibles los datos.
                            dr.Close();

                            cmd = new SqlCommand("Select * From DatosEtiqueta WHERE " + Columna + " = '" + _Codigo.Trim() + "'", cn);
                            dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();

                                datos[14] = dr["Frase1" + sufix].ToString();
                                datos[15] = dr["Frase2" + sufix].ToString();
                                datos[16] = dr["Frase3" + sufix].ToString();
                                datos[17] = dr["Frase4" + sufix].ToString();
                                datos[18] = dr["Frase5" + sufix].ToString();
                                datos[19] = dr["Frase6" + sufix].ToString();
                                datos[20] = dr["Frase7" + sufix].ToString();
                                datos[7] = dr["Frase8" + sufix].ToString();


                                int renglon = 8;
                                int pictograma = 1;

                                while (pictograma <= 9 && renglon < 13)
                                {
                                    if (Int32.Parse(dr["Pictograma" + pictograma].ToString()) != 0)
                                    {
                                        datos[renglon] = _ObtenerRutaImagenSGA(pictograma.ToString());
                                        renglon++;
                                    }

                                    pictograma++;
                                }

                                while (renglon < 13)
                                {
                                    datos[renglon] = _ObtenerRutaImagenSGA("0"); // Llenamos los campos de pictogramas faltantes con el rombo tachado.
                                    renglon++;
                                }

                                if (datos[7] == "")
                                {

                                    string pal = dr["Palabra"].ToString().Trim();

                                    switch (pal)
                                    {
                                        case "1":
                                            pal = (_Traducir) ? "Danger" : "Peligro";
                                            break;

                                        case "2":
                                            pal = (_Traducir) ? "Warning" : "Atención";
                                            break;

                                        default:
                                            pal = "";
                                            break;
                                    }

                                    datos[7] = pal;

                                }
                                else
                                {
                                    if (_Traducir)
                                    {
                                        datos[7] = datos[7].Replace("Peligro", "DANGER");
                                        datos[7] = datos[7].Replace("PELIGRO", "DANGER");
                                        datos[7] = datos[7].Replace("Atención", "WARNING");
                                        datos[7] = datos[7].Replace("Atencion", "WARNING");
                                        datos[7] = datos[7].Replace("ATENCIÓN", "WARNING");
                                        datos[7] = datos[7].Replace("ATENCION", "WARNING");
                                    }
                                }

                            }
                            else {

                                int i = 0;

                                while (i < 13)
                                {
                                    datos[i] = i >= 8 ? _ObtenerRutaImagenSGA("0") : ""; // Llenamos con rombos tachados los pictogramas.

                                    i++;
                                }
                            }
                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al querer consultar las especificaciones SGA del siguiente producto: " + _Codigo);
            }

            // En caso de que sea un DY y se haya modificado.
            _Traducir = _ViejoTraducir;

            return datos;
        }

        private string _ObtenerRutaImagenSGA(string numero) 
        {
            switch (tipo)
            {
                case "Grande":

                    if (numero == "0")
                    {
                        return _EnProduccion ? Path.GetFullPath(@".\SGA\SB_SGA0.JPG") : Path.GetFullPath(@"..\..\Resources\SB_SGA0.JPG");
                    }
                    // Envio la ruta dependiendo si se encuentra en produccion o no, debido a que mientras se desarrolla la raiz del ejecutable se resetea cada vez que se ejecuta.
                    return _EnProduccion ? Path.GetFullPath(@".\SGA\SB_SGA" + numero + ".png") : Path.GetFullPath(@"..\..\Resources\SB_SGA" + numero + ".png");

                    break;

                default:

                    if (numero == "0")
                    {
                        return _EnProduccion ? Path.GetFullPath(@".\SGA\SGA0.JPG") : Path.GetFullPath(@"..\..\Resources\SGA0.JPG");
                    }
                    // Envio la ruta dependiendo si se encuentra en produccion o no, debido a que mientras se desarrolla la raiz del ejecutable se resetea cada vez que se ejecuta.
                    return _EnProduccion ? Path.GetFullPath(@".\SGA\SGA" + numero + ".png") : Path.GetFullPath(@"..\..\Resources\SGA" + numero + ".png");
                    break;
            }

        }
        
        private bool EsFinalDeHoja(int NumeroDeEtiquetaActual)
        {
            return NumeroDeEtiquetaActual == CantidadDeEtiquetasPorHojaSegunTipo();
        }

        private int CalcularCantidadDeHojas()
        {
            int corrimiento = 0;

            if (tipo != "Grande")
            {
                corrimiento += (tipo == "Chica") ? posicion*2 : posicion;
            }

            return Convert.ToInt32( // Paso a número entero
                        Math.Ceiling( // Redondeo al entero más alto y próximo.
                            (CantidadDeEtiquetasTotales() + corrimiento) / CantidadDeEtiquetasPorHojaSegunTipo() // Sumo la posición por un tema de corrimiento.
                        )
                   );
        }

        private double CantidadDeEtiquetasTotales()
        {
            double total = 0;

            foreach (int cant in CantidadesDeEtiquetas)
            {
                total += (tipo == "Chica") ? cant*2 : cant;
            }

            return total;
        }

        public int CantidadDeEtiquetasPorHojaSegunTipo()
        {
            switch (tipo)
            {

                case "Chica": // Etiqueta Chica (8.5 x 4)

                    return 8;

                case "Grande": // Etiqueta Autoadhesiva (14 x 12.5)

                    return 1;

                case "Mediana": // Etiqueta Mediana

                    return 4;

                case "Frasco": // Etiqueta P/Frascos

                    return 7;

                default:

                    throw new Exception("Tipo de Etiqueta Inválido.");

            }
        }

        private ReportClass ObtenerRptSegunTipo()
        {
            switch (tipo)
            {

                case "Chica": // Etiqueta Chica (8.5 x 4)

                    return new EtiquetC();

                case "Grande": // Etiqueta Autoadhesiva (14 x 12.5)

                    return new EtiquetaGrandSGA();

                case "Mediana": // Etiqueta Mediana

                    return new EtiquetaMediana();

                case "Frasco": // Etiqueta P/Frascos

                    // Por temas de diferencias en impresoras entre Tomasek y el resto.
                    //return new EtiquetaFrasco();  // Se reemplaza el formato de hoja A4 a Ejecutivo para que
                                                    // en las impresoras no lance advertencias de que la hoja es mas
                                                    // chica que la prederterminada entre impresion e impresion.
                    
                    return new EtiquetaFrascoDaniel();

                default:

                    throw new Exception("Tipo de Etiqueta Inválido.");

            }
        }
    }
}
