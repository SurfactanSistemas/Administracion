using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClassConexion;

namespace Vista
{
    public partial class Remito : Form
    {
        Conexion Cs = new Conexion();
        bool reimprimir;

        DataTable DT = new DataTable();
        string Datos;
        string DirEnt;
        private string datos;
        private DataTable dt;
        private string DirEntrega;
        private string CodClient;
        private string DirClient;
        private string LocalidadClient;
        private string Cuit;
        private string cliente;

        // Variables para Número de Remito por Estación de Trabajo.
        private int WEmpresaRemito = -1;
        private int WCodigoRemito = -1;
        private string[] WDatosRemito = new string[5];

        //  Ultimo nro de mov de laboratorio
        private string MovLabNumero;
        private string MovlabRenglon;
        private string txtTrabajo;
        private string[,] HojasDeSeguridad;
        private const string ORIGEN_HOJA_SEGURIDAD = "W:\\impresion pdf\\fds\\fds#NOMBREPDF#.pdf";
        private const string DESTINO_HOJA_SEGURIDAD = "C:\\pdfprint\\fds#NOMBREPDF#.pdf";



             
        public Remito(string datos, DataTable dt, List<string> erroresLote, List<string> sinEnsayo, string DirEntrega, string CodClient, string DirClient, string LocalidadClient, string Cuit, string cliente, string[,] FDSs)
        {
            InitializeComponent();

            //reimprimir
            this.datos = datos;
            this.dt = dt;
            this.DirEntrega = DirEntrega;
            this.CodClient = CodClient;
            this.DirClient = DirClient;
            this.LocalidadClient = LocalidadClient;
            this.Cuit = Cuit;
            this.cliente = cliente;
            HojasDeSeguridad = FDSs;

            // Determinamos la Empresa en la Cual Trabajaremos.
            _DeterminarEmpresaRemito(dt);

            AsignarDatos(datos);

            DGV_Remito.DataSource = dt;

            TBNumRemito.Text = _TraerProximoNumeroRemitoPorEstacionDeTrabajo().ToString();

            TBNumRemito.Enabled = false;

            cmbTipoRemito.SelectedIndex = 0;

            if (erroresLote.Count > 0 || sinEnsayo.Count > 0)
            {
                BTAceptar.Enabled = false;
                string errores = "Se han producido los siguientes errores:  \n";
                foreach (string s in erroresLote)
                {
                    errores += "La muestra " + s + " no posee numero de Lote en la tabla Pedido \n";
                }

                foreach (string s in sinEnsayo)
                {
                    errores += "La muestra " + s + " no posee ensayo \n";
                }
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }


        }

        private void _DeterminarEmpresaRemito(DataTable dt)
        {
            WEmpresaRemito = -1;

            string WPedido = "";

            if (dt.Rows.Count > 0)
            {
                WPedido = dt.Rows[0]["Pedido"].ToString();
                WPedido = WPedido.Trim();
            }
            
            TBCliente.Text = datos_separados[1];
            if (datos_separados[0] == "" || datos_separados[0] == "0") TBNumRemito.Text = Cs.TraerRemitoMax();
            else {
                TBNumRemito.Text = datos_separados[0];
                reimprimir = true;
            }

            if (WPedido == "") return;

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(TipoPedido, '') TipoPedido FROM Pedido WHERE Pedido = '" + WPedido + "' AND Renglon = '1'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                string WTipoPedido = dr["TipoPedido"].ToString().Trim();

                                if (WTipoPedido == "") return;

                                switch (WTipoPedido)
                                {
                                    case "1":
                                    case "5":
                                    {
                                        WEmpresaRemito = 11;
                                        break;
                                    }
                                    default:
                                    {
                                        WEmpresaRemito = 12;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el numero próximo de Remito en la Base de Datos. Motivo: " + ex.Message);
            }
        }

        private string _TraerTipoProducto(string WPedido, string WProducto)
        {
            string WTipoProd = "";

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ISNULL(TipoPro, '') TipoPro FROM Pedido WHERE Terminado = '" + WProducto.Trim() + "' AND Pedido = '" + WPedido.Trim() + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WTipoProd = dr["TipoPro"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return WTipoProd;
        }

        private void AsignarDatos(string _datos)
        {
            try
            {
                string[] datos_separados = _datos.Split(';');

                TBCliente.Text = datos_separados[1];
                if (datos_separados[0] == "" || datos_separados[0] == "0")
                {
                    int WProximoNumero = _TraerProximoNumeroRemitoPorEstacionDeTrabajo();

                    if (WProximoNumero < 0) throw new Exception("No existe numeración de Remito disponible para la Empresa Involucrada.");

                    TBNumRemito.Text = WProximoNumero.ToString();
                }
                else {
                    TBNumRemito.Text = datos_separados[0];
                    reimprimir = true;
                }

                TBFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*
         * 1 -> Surfactan I
         * 3 -> Surfactan VII
         * 4 -> Surfactan V
         */
        private int _TraerProximoNumeroRemitoPorEstacionDeTrabajo()
        {
            int WProximoNumero = -1;
            int WCandidato = -1;
            WCodigoRemito = -1;

            try
            {
                if (WEmpresaRemito == -1) throw new Exception("No se determinó la empresa a la cual corresponde el remito.");

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo, Ultimo, Cai, Fecha, Punto FROM NumeroRemito WHERE Punto = '" + WEmpresaRemito + "' ORDER BY Codigo";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read() && WProximoNumero < 0)
                                {
                                    WCandidato = int.Parse(dr["Ultimo"].ToString());

                                    //// Vemos si es Cero -> Le damos el Valor de 'Desde'.

                                    //if (WCandidato == 0)
                                    //{
                                    //    WCandidato = -1;
                                    //    WCandidato += int.Parse(dr["Desde"].ToString());
                                    //}

                                    //// Incrementamos en Uno.

                                    //WCandidato++;

                                    //// Vemos si se encuentra entre los valores 'Desde' y 'Hasta'.

                                    //if (WCandidato < int.Parse(dr["Desde"].ToString()) ||
                                    //    WCandidato > int.Parse(dr["Hasta"].ToString()) || WCandidato < 0 )
                                    //{
                                    //    // Invalidamos el Candidato.
                                    //    WCandidato = -1;

                                    //    // Buscamos en el Siguiente Registro.
                                    //    continue;
                                    //}

                                    // En caso de que este correcto, salimos. Sino buscamos en el siguiente registro.
                                    WProximoNumero = WCandidato + 1;
                                    WCodigoRemito = int.Parse(dr["Codigo"].ToString());

                                    WDatosRemito[0] = dt.Rows[0]["Pedido"].ToString();
                                    WDatosRemito[1] = dr["Cai"].ToString();
                                    WDatosRemito[2] = dr["Fecha"].ToString();
                                    WDatosRemito[3] = WProximoNumero.ToString();
                                    WDatosRemito[4] = dr["Punto"].ToString();
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el Próximo número de remito desde la Base de Datos. Motivo: " + ex.Message);
            }

            return WProximoNumero;
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            string _Clave, _Codigo, _Renglon, _Fecha, _CLiente, _Articulo, _Terminado, _Cantidad, _Fechaord, _Movi, _Tipo, _Tipomov, _Observaciones, _WDate, _Marca, _Lote;

            // Verificamos que el numero de remito no haya sido cargado con anterioridad.
            
            if (Cs.RemitoExistente(TBNumRemito.Text.Trim())) {
                MessageBox.Show("El Número de remito ya fue utilizado con anterioridad y no puede volver a utilizarse. Por favor, avise a Sistemas para que actualice la numeración de los Remitos.", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
                TBNumRemito.Focus();
                return;
            }

            try
            {
                if (TBNumRemito.Text == "") throw new Exception("Se debe ingresar el numero de remito");
                if (reimprimir)
                {
                    ImpreRemito impre = new ImpreRemito(dt, DirEntrega, CodClient, DirClient, LocalidadClient, Cuit, cliente, HojasDeSeguridad, WDatosRemito);
                    impre.ShowDialog();
                }
                else
                {
                    if (WEmpresaRemito < 0 || WCodigoRemito < 0) throw new Exception("No se encuentra bien definido las referencias a la numeraciónn del Remito o el Puesto de Trabajo correspondiente.");

                    for (int i = 0; i < DGV_Remito.Rows.Count; i++)
                    {
                        string codigo = DGV_Remito.Rows[i].Cells[5].Value.ToString();
                        string aux = DGV_Remito.Rows[i].Cells[1].Value.ToString();
                        
                        aux = aux.Trim();

                        aux = aux.StartsWith(".") ? "0" + aux : aux;// Hay casos en lo que se cargo como por ejemplo ".1" en vez de "0.1"

                        double Cantidad = Convert.ToDouble(aux.Replace(".", ","));

                        //if (codigo.StartsWith("PT") || codigo.StartsWith("DY") || codigo.StartsWith("YQ") || codigo.StartsWith("YF"))
                        //{
                        //    Cs.ActualizarPedidoI(DGV_Remito.Rows[i]);
                        //}

                        Cs.ActualizarPedidoI(DGV_Remito.Rows[i]);

                        Cs.ActualizarMuestraRemito(DGV_Remito.Rows[i], TBNumRemito.Text);

                        Cs.BuscarTipoPedido(DGV_Remito.Rows[i]);

                        // buscar ultimo numero de movvlab
                        MovLabNumero = Cs.TraerMovlabMax();

                        //la siguiente linea no hace falta porque ya suma uno en la consulta SQL
                        //int NumMov = int.Parse(MovLabNumero) + 1;
                        //string MovLab = NumMov.ToString();

                        //Reviso que cantidad de caracteres tiene el codigo devuelto
                        int CantCar = MovLabNumero.Length;

                        //Con la variable i del modulo saco el orden del movimiento, como empieza por 0 
                        //le sumo 1
                        string orden = "1"; // (i + 1).ToString();

                        //Consulto si el orden es de un solo digito, si es asi le pongo un 0 adelante
                        if (orden.Length == 1) orden = "0" + orden;

                        //Sumo el string del movimiento mas el orden
                        string Clave = MovLabNumero + orden;
                        int max = Clave.Length;

                        //realizo el for para saber cuantos ceros van a anteceder a la clave obtenida
                        for (int u = 0; u < (8 - max); u++)
                        {
                            Clave = "0" + Clave;
                        }

                        _Clave = Clave;
                        _Codigo = MovLabNumero;
                        _Fecha = TBFecha.Text.Trim();
                        
                        _Cantidad = Cantidad.ToString(); //DGV_Remito.Rows[i].Cells[3].Value.ToString();
                        _Fechaord = String.Join("", TBFecha.Text.Split("/".ToCharArray()).Reverse());
                        _WDate = DateTime.Now.ToString("MM-dd-yyyy");
                        _Lote = DGV_Remito.Rows[i].Cells[3].Value.ToString();

                        // Verificamos para ver si realizar o  no el movimiento.
                        bool _GrabarMovLab = true;

                        if (codigo.StartsWith("YQ")){
                            if (Cantidad < 20){
                            
                                _GrabarMovLab = false;
                            }
                        }

                        if (_GrabarMovLab) {
                            //SE MODIFICA A CONTINUACION PORQUE AL SER ML NO SE ACTUALIZA NADA
                            if (codigo.StartsWith("DY")) //|| codigo.StartsWith("ML"))
                            {
                                Cs.ActualizarArticulo(DGV_Remito.Rows[i]);

                                _Tipo = "M";
                                _Terminado = "  -     -   ";
                                _Articulo = codigo;

                                //No se en que parte se tiene la fecha
                                //Fila["OrdenFecha"] = Fila[2].ToString().Substring(6,4) + Fila[2].ToString().Substring(2, 4) + Fila[2].ToString().Substring(0, 2);

                                // Grabar registro
                                Cs.AltaMovlab(_Clave, _Codigo, _Articulo, _Terminado, _Tipo, orden, _Fecha, _Fechaord, _Lote, TBCliente.Text, Cantidad);

                                if (Cs.BuscarEnLaudo(DGV_Remito.Rows[i])) Cs.RestarSaldoALaudo(DGV_Remito.Rows[i]);
                                else if (Cs.BuscarEnGuia_Art(DGV_Remito.Rows[i])) Cs.RestarSaldoAGuia_Art(DGV_Remito.Rows[i]);
                                else throw new Exception("No se encontro la Muestra en las tablas Laudo ni Guia");
                            }
                            //SE MODIFICO A ELSE IF PARA QUE ENTRE EN CASO QUE NO SEA DY NI ML ENTRE Y SI ES YF O YQ LA CANTIDAD DEBE SER MAYOR A 1
                            //SINO NO SE ACTUALIZA LOTE
                            else if ((codigo.StartsWith("YQ") && Cantidad > 1) || (codigo.StartsWith("YF") && Cantidad > 1) || codigo.StartsWith("PT"))
                            {

                                Cs.ActualizarTerminado(DGV_Remito.Rows[i]);

                                _Tipo = "T";
                                _Terminado = codigo;
                                _Articulo = "  -     -   ";

                                //// Grabar registro
                                Cs.AltaMovlab(_Clave, _Codigo, _Articulo, _Terminado, _Tipo, orden, _Fecha, _Fechaord, _Lote, TBCliente.Text, Cantidad);

                                if (Cs.BuscarEnHoja(DGV_Remito.Rows[i])) Cs.RestarSaldoAHoja(DGV_Remito.Rows[i]);
                                else if (Cs.BuscarEnGuia_Ter(DGV_Remito.Rows[i])) Cs.RestarSaldoAGuia_Ter(DGV_Remito.Rows[i]);
                                else throw new Exception("No se encontro la Muestra en las tablas Hoja ni Guia");
                            }
                        }
                    }
                }

                ImpreRemito impre_1 = new ImpreRemito(dt, DirEntrega, CodClient, DirClient, LocalidadClient, Cuit, cliente, WDatosRemito);
                impre_1.ShowDialog();

                // Verifico que se haya cargado algun articulo para comenzar a imprimir.
                if (HojasDeSeguridad[0, 0].Trim() != "")
                {

                    ImprimirHojasDSeguridad(HojasDeSeguridad);

                }

                if (cmbTipoRemito.SelectedIndex == 0 && WEmpresaRemito != -1) _ActualizarUltimaNumeracionRemito();

                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ActualizarUltimaNumeracionRemito()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE NumeroRemito SET Ultimo = "+ TBNumRemito.Text +" WHERE Codigo = '" + WCodigoRemito + "'";
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la numeración del último remito utilizado en la Base de Datos. Avise a SISTEMAS para que sea actualizado de manera manual antes de continuar. Motivo: " + ex.Message);
            }
        }

        private void ImprimirHojasDSeguridad(string[,] arrHojasDeSeguridad)
        {

            try
            {

                // Avisamos para que puedan sacar las hojas de remitos.
                MessageBox.Show("Se van a imprimir las hojas de seguridad. Por favor, coloque hojas A4 para las misma.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string desc = "";
                string cod = "";

                // Borramos el directorio en caso de que exista.
                if (Directory.Exists(@"C:\pdfprint"))
                {

                    Directory.Delete(@"C:\pdfprint", true);

                }

                // Creamos el directorio donde alojaremos los pdf a imprimir.
                Directory.CreateDirectory(@"C:\pdfprint");

                for (int i = 0; i < arrHojasDeSeguridad.GetLength(0); i++)
                {
                    // Formateamos la descripcion y el codigo segun sea el tipo.
                    desc = arrHojasDeSeguridad[i, 0].Trim();
                    cod = arrHojasDeSeguridad[i, 1].Trim();

                    // Eliminamos los espacios y "/" del nombre del Producto.
                    desc = desc.Replace(" ", "").Replace("/", "");

                    string WRutaFds = "";
                    string nom = "";

                    //if (cod.StartsWith("PT") || cod.StartsWith("CO"))
                    if (!cod.StartsWith("DY"))
                    {
                        // Eliminamos los "-".
                        cod = cod.Replace("-", "");

                        string temp = cod.Replace("PT", "");

                        // Los 25000 (Farma), se guardan con el formato FDS25000100-NOMBREDELPRODUCTO PARTIDA
                        if (temp.StartsWith("25"))
                        {
                            // Buscamos el archivo que coincida con el codigo de producto.
                            foreach (string file in Directory.GetFiles(@"w:\impresion pdf\fds"))
                            {
                                if (file.Contains(temp))
                                {
                                    WRutaFds = file;
                                    break;
                                }
                            }
                        }
                        else // En los demas casos, siguen el formato normal FDSNOMBREPRODUCTO06570100
                        {
                            WRutaFds = ORIGEN_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", desc + cod.Substring(2, cod.Length - 2));
                        }

                    }
                    else // Los DY, siguen el siguiente formato FDSDY-600-101
                    {
                        string[] ZCod = cod.Split('-');

                        // Eliminamos los ceros de mas que pudiesen estar presentes en el codigo intermedio. EJ: DY-00302-100 -> DY-302-100.
                        ZCod[1] = int.Parse(ZCod[1]).ToString();

                        cod = string.Join("-", ZCod);

                        WRutaFds = ORIGEN_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", cod);
                    }

                    if (File.Exists(WRutaFds))
                    {
                        nom = Path.GetFileNameWithoutExtension(WRutaFds);

                        File.Copy(WRutaFds, DESTINO_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", nom));

                    }
                    else
                    {
                        // Notificamos al usuario la NO existencia de alguna Hoja de Seguridad.
                        MessageBox.Show("¡No existe FDS del " + arrHojasDeSeguridad[i, 0].Trim() + " (" + arrHojasDeSeguridad[i, 1].Trim() + ")!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Imprimimos las hojas guardadas.

                // Recorremos e imprimimos los archivos copiados a la carpeta "pdfprint"
                foreach (string file in Directory.GetFiles(@"C:\pdfprint"))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = file //put the correct path here
                    };
                    p.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirHojasDSeguridad(HojasDeSeguridad);
        }

        private void cmbTipoRemito_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBNumRemito.Enabled = cmbTipoRemito.SelectedIndex == 1;

            if (TBNumRemito.Enabled)
            {
                TBNumRemito.Focus();
            }
            else
            {
                _DeterminarEmpresaRemito(dt);
                TBNumRemito.Text = _TraerProximoNumeroRemitoPorEstacionDeTrabajo().ToString();
            }
        }
    }
}