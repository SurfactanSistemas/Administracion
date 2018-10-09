using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClassConexion;
using Negocio;

namespace Vista
{
    

    public partial class Muestra : Form
    {
        Conexion CS = new Conexion();
        Terminado Ter = new Terminado();
        Negocio.Muestra M = new Negocio.Muestra();
        DataTable dt;
        string columna = "";
        bool OrdFecha;


        public Muestra()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TB_Desde.Text = DateTime.Now.Year.ToString();
            TB_Hasta.Text = TB_Desde.Text;

            ConfigurationManager.AppSettings["Fecha_Desde"] = TB_Desde.Text;
            ConfigurationManager.AppSettings["Fecha_Hasta"] = TB_Hasta.Text;

            dt = new DataTable();
            dt.Clear();
            dt = M.TraerLista(TB_Desde.Text, TB_Hasta.Text);

            //Se utiliza esta columna para ordenar las fechas.
            dt.Columns.Add("OrdenFecha", typeof(string));

            foreach (DataRow Fila in dt.Rows)
            {
               Fila["OrdenFecha"] = Fila[2].ToString().Substring(6,4) + Fila[2].ToString().Substring(2, 4) + Fila[2].ToString().Substring(0, 2);
            }

            DGV_Muestra.DataSource = dt;

            //LimpiarFechas();

            //Limpio cualquier filtro existente
            ((DataTable) DGV_Muestra.DataSource).DefaultView.RowFilter = string.Empty;

            //DGV_Muestra.SortedColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void BT_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarAños();

                ConfigurationManager.AppSettings["Fecha_Desde"] = TB_Desde.Text;
                ConfigurationManager.AppSettings["Fecha_Hasta"] = TB_Hasta.Text;

                dt = new DataTable();
                dt.Clear();
                dt = M.TraerLista(TB_Desde.Text, TB_Hasta.Text);

               

                foreach (DataRow Fila in dt.Rows)
                {
                    Fila["OrdenFecha"] = Fila[2].ToString().Substring(6, 4) + Fila[2].ToString().Substring(2, 4) + Fila[2].ToString().Substring(0, 2);
                }

                DGV_Muestra.DataSource = dt;

                //Limpio cualquier filtro existente
                ((DataTable) DGV_Muestra.DataSource).DefaultView.RowFilter = string.Empty;
                ((DataTable) DGV_Muestra.DataSource).DefaultView.Sort = string.Empty;
                P_Filtrado.Visible = false;
            }
            catch (Exception Err)
            {                
                MessageBox.Show(Err.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);  
            }            
        }

        private void ValidarAños()
        {
            if (TB_Desde.Text == "") throw new Exception("No se ha ingresado la fecha Inicial");
            if (TB_Hasta.Text == "") throw new Exception("No se ha ingresado la fecha Final");

            if (!Regex.IsMatch(TB_Desde.Text, "^(19|20)[0-9][0-9]") || !Regex.IsMatch(TB_Hasta.Text, "^(19|20)[0-9][0-9]")) throw new Exception("Unos de los valores ingresados no corresponde a un año valido");
            if (int.Parse(TB_Hasta.Text) < int.Parse(TB_Desde.Text)) throw new Exception("La fecha desde no puede ser mayor a la fecha hasta");

        }


        private void button7_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Filtros.Show(ptLowerLeft);

            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltro.Text = "";
            
            
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            if (BT_Filtrar.Text == "Filtrar")
            {
                DataTable dataTable = DGV_Muestra.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("CONVERT(" + columna + ", System.String) like '%{0}%'", TBFiltro.Text);
                BT_Filtrar.Text = "Limp. Filtro";
            }
            else
            {
                DataTable dataTable = DGV_Muestra.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Empty;

                P_Filtrado.Visible = false;
                TBFiltro.Text = "";
                BT_Filtrar.Visible = true;
            }
           
                
        }

        #region Menu
        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Pedido";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;

        }

        private void fechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Fecha";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Codigo";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Nombre";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void cantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Cantidad";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void nombreParaElClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "DescriCliente";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void óbservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Observaciones";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Razon";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void remitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Remito";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void hojaDeRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "HojaRuta";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void sinRemitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Muestra s/Remito";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = false;
            DataTable dataTable = DGV_Muestra.DataSource as DataTable;
            if (dataTable != null)
                dataTable.DefaultView.RowFilter = "CONVERT(Isnull(Remito,''), System.String) = ''";
        }

        private void sinRemitoConLote1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Muestra s/Remito c/Partida";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = false;
            DataTable dataTable = DGV_Muestra.DataSource as DataTable;
            if (dataTable != null)
                dataTable.DefaultView.RowFilter = "CONVERT(Isnull(Remito,''), System.String) = '' AND Lote1 <> 0";
        }

        private void codClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "Cliente";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columna = "NombreVend";
            HabilitarPanelFiltrado();
            LBFiltro.Text = columna;
            TBFiltro.Visible = true;
        }

        #endregion

        private void HabilitarPanelFiltrado()
        {
            P_Filtrado.Visible = true;
            TBFiltro.Focus();
        }

        
       private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            //PresionarBotonBuscar(e);
        if(e.KeyCode == Keys.Enter)
            TB_Hasta.Focus();
            
        }

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            PresionarBotonBuscar(e);
            if (e.KeyCode == Keys.Enter)
                BT_Buscar.Focus();
            
        }

        private void TBFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Filtrar.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void PresionarBotonBuscar( KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Buscar.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Armo el datatable
                if (DGV_Muestra.SelectedRows.Count == 0) throw new Exception("No hay filas seleccionadas");

                DataTable _dt = new DataTable();
                foreach (DataGridViewColumn column in DGV_Muestra.Columns)
                    _dt.Columns.Add(column.Name, typeof(string));
                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    _dt.Rows.Add();
                    for (int j = 0; j < DGV_Muestra.Columns.Count; j++)
                    {
                        _dt.Rows[i][j] = DGV_Muestra.SelectedRows[i].Cells[j].Value;
                    }
                }

                Exportar exportar = new Exportar(_dt);
                exportar.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro que quieres salir?", "Confirmacion salir",
                                MessageBoxButtons.YesNo);  
            if (dialogResult == DialogResult.Yes){
                Close();
            }
        }

        private void BtEtiquetas_Click(object sender, EventArgs e)
        {

            try
            {
                // En caso de que no se hayan seleccionado las filas completas y solo una celda o fila de manera parcial.
                if (DGV_Muestra.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell celda in DGV_Muestra.SelectedCells)
                    {
                        DGV_Muestra.Rows[celda.RowIndex].Selected = true;
                    }
                }

               //Valido que se hayan seleccionado registros
                if (DGV_Muestra.SelectedRows.Count == 0) throw new Exception("No hay filas seleccionadas");

                //creo el datatable
                DataTable _dt = new DataTable();

                AgregarColumnas(_dt);
                               
                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    DataRow newRow = _dt.NewRow();
                    newRow["NombreEmpresa"] = "SURFACTAN S.A.";
                    newRow["Nombre"] = DGV_Muestra.SelectedRows[i].Cells["Nombre"].Value.ToString();
                    newRow["Codigo"] = DGV_Muestra.SelectedRows[i].Cells["Codigo"].Value.ToString();
                    newRow["DescriCliente"] = DGV_Muestra.SelectedRows[i].Cells["DescriCliente"].Value.ToString();
                    newRow["Razon"] = DGV_Muestra.SelectedRows[i].Cells["Razon"].Value.ToString();
                    newRow["Fecha"] = "Fecha: "+DateTime.Now.ToShortDateString();
                    newRow["Direccion_1"] = "MALVINAS ARGENTINAS 4589 (1644) VICTORIA";
                    newRow["Direccion_2"] = "BS.AS. 4714-4097/4085 surfac@surfactan.com";


                    string lote = DGV_Muestra.SelectedRows[i].Cells["Lote2"].Value.ToString();

                    try
                    {
                        lote = _DetarminarLote(i, newRow, lote);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    newRow["Lote"] = lote;

                    string codigoOri = DGV_Muestra.SelectedRows[i].Cells["Codigo"].Value.ToString();
                    //string codigo = codigoOri.Substring(0, 12);

                    //Me fijo si empieza con PT de Producto Terminado y sino dejo vacio
                    if (codigoOri.Substring(0, 2) == "PT")
                    {
                        string codigo = codigoOri.Substring(0, 12);
                        DataRow datarow = Ter.ListarPeligroso(codigo);

                        if (datarow[0].ToString() != "                              ")
                        {
                            newRow["Clase"] = "Clase: " + datarow[0];
                        }
                        else
                        {
                            newRow["Clase"] = "";
                        }

                        if (datarow[1].ToString() != "          ")
                        {
                            newRow["Intervencion"] = "Guia: " + datarow[1];
                        }
                        else
                        {
                            newRow["Intervencion"] = "";
                        }

                        if (datarow[2].ToString() != "          ")
                        {
                            newRow["Naciones"] = "O.N.U: " + datarow[2];
                        }
                        else
                        {
                            newRow["Naciones"] = "";
                        }

                    }

                    else

                    {
                        newRow["Clase"] = "";
                        newRow["Intervencion"] = "";
                        newRow["Naciones"] = "";
                    }

                    _dt.Rows.Add(newRow);

                }

                Etiquetas etiquetas = new Etiquetas(_dt);
                etiquetas.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private string _DetarminarLote(int i, DataRow newRow, string lote)
        {
            if (lote.Trim() == "" || int.Parse(lote) == 0)
            {
                lote = DGV_Muestra.SelectedRows[i].Cells["Lote1"].Value.ToString();
            }

            // En caso de los DY, deben salir con el lote Alfanumérico no con el número de Laudo.
            if (newRow["Codigo"].ToString().StartsWith("DY"))
            {
                try
                {
                    lote = CS.BuscarAlfanumericoDY(newRow["Codigo"].ToString(), lote)["PartiOri"].ToString();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            lote = lote.Trim();

            if (lote.Trim() == "" || (!newRow["Codigo"].ToString().StartsWith("DY") && int.Parse(lote) == 0))
            {
                // EB - 20/12/2017 - Autoriza a destrabar.
                //if (newRow["Codigo"].ToString().StartsWith("YF"))
                //    throw new Exception("Los YF deben tener lote asignado antes de poder imprimir sus respectivas etiquetas.");

                lote = "Pedido: " + DGV_Muestra.SelectedRows[i].Cells["Pedido"].Value.ToString().Trim();
            }
            else
            {
                lote = "Lote: " + lote.Trim();
            }

            return lote;
        }

        private void BtRemito_Click(object sender, EventArgs e)
        {
            

            try
            {
                // En caso de que no se hayan seleccionado las filas completas y solo una celda o fila de manera parcial.
                if (DGV_Muestra.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell celda in DGV_Muestra.SelectedCells)
                    {
                        DGV_Muestra.Rows[celda.RowIndex].Selected = true;
                    }
                }

                DataTable _dt = new DataTable();
                List<string> sinEnsayo = new List<string>();
                List<string> errorLote = new List<string>();

                int cantidad = (DGV_Muestra.SelectedRows.Count - 1);
                string cliente = DGV_Muestra.SelectedRows[cantidad].Cells[7].Value.ToString(); //Cliente
                string _CodCliente = DGV_Muestra.SelectedRows[cantidad].Cells[8].Value.ToString();

                //Filtro para clientes identicos
                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    if (DGV_Muestra.SelectedRows[i].Cells[7].Value.ToString() != cliente) {
                        throw new Exception("Los clientes son distintos");
                    }
                }

                //Verifico que se ML y valor medio mayor a 100 (Verifico que se haya hecho actualizar laboratiori)
                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    int valor = int.Parse(DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().Substring(3, 3));

                    if (DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().StartsWith("ML") &&
                        valor >= 100) {
                            string _id = DGV_Muestra.SelectedRows[i].Cells[0].Value.ToString();
                            if (!CS.VerificarEnsayo2(_id)) throw new Exception("La muestra " + DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().Trim() + " no posee ensayo");
                            //sinEnsayo.Add(DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString());
                    }
                }

                //Verifico que no tengan número de remito
                string numero_remito = DGV_Muestra.SelectedRows[0].Cells[12].Value.ToString();
                string[,] HojasDeSeguridad = new string[DGV_Muestra.SelectedRows.Count, 2];

                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    if (DGV_Muestra.SelectedRows[i].Cells[12].Value.ToString() != numero_remito) {
                            throw new Exception("El numero de remito es diferente");
                        }
                    HojasDeSeguridad[i, 0] = DGV_Muestra.SelectedRows[i].Cells["DescriCliente"].Value.ToString().Trim();

                    HojasDeSeguridad[i, 1] = DGV_Muestra.SelectedRows[i].Cells["Codigo"].Value.ToString().Trim();
                }

                if (numero_remito != "" && numero_remito != "0")
                {
                    _dt = CS.BuscarListaRemito(numero_remito, _CodCliente);

                    DataRow datacliente1 = CS.BuscarCliente(cliente);

                    string WPedido = DGV_Muestra.SelectedRows[0].Cells["Pedido"].Value.ToString();

                    string WDirEntrega = _TraerDireccionEntregaPorPedido(WPedido, _CodCliente);

                    if (WDirEntrega.Trim() == "") throw new Exception("No se encuentra dirección de Entrega de Cliente");

                    string CodClient1 = datacliente1[0].ToString();
                    string DirClient1 = datacliente1[1].ToString();
                    string LocalidadClient1 = datacliente1[2].ToString();
                    string Cuit1 = datacliente1[3].ToString();
                    string DirEntrega1 = WDirEntrega; //datacliente1[4].ToString();
                    string[] WDatosRemito = _BuscarDatosRemito(WPedido, numero_remito);

                    ImpreRemito impre_1 = new ImpreRemito(_dt, DirEntrega1, CodClient1, DirClient1, LocalidadClient1, Cuit1, cliente, HojasDeSeguridad, WDatosRemito);
                    impre_1.ShowDialog();
                    goto finalizado;
                    //goto Error;


                }

                //Se valido la totalidad de las variables, ahora se va a modificar la/s base/s                
                int[] Lotes = new int[DGV_Muestra.SelectedRows.Count];

                string[,] Peligroso = new string[DGV_Muestra.SelectedRows.Count, 2];

                string[] Codigos = new string[DGV_Muestra.SelectedRows.Count];

                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    string cod = DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString();

                    if(DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().Length < 12)
                    {
                        string codigo = cod.Substring(0, 2) + "-00" + cod.Substring(3, 7);
                        cod = codigo;
                    }
                    Codigos[i] = cod;
                    int _id = int.Parse(DGV_Muestra.SelectedRows[i].Cells[0].Value.ToString());
                    string pedido = DGV_Muestra.SelectedRows[i].Cells[1].Value.ToString();
                    
                    // Se busca lote para el Codigo solicitado en caso de que no sea un ML.
                    // Falta definir el

                    if (cod.StartsWith("DY"))
                    {
                        cod = Conexion._FormatearCodigoProducto(cod);
                    }
                    

                    string cant = DGV_Muestra.SelectedRows[i].Cells[5].Value.ToString().Trim();

                    cant = cant.Replace(",", ".");

                    cant = cant.StartsWith(".") ? "0" + cant : cant;

                    if (DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().StartsWith("YQ") || DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().StartsWith("YF"))
                    {
                        if (Double.Parse(cant.Replace(".", ",")) >= 20)
                        {
                            int _lote1 = int.Parse(CS.BuscarLote1(cod, pedido));

                            if (_lote1 == 0)
                            {
                                throw new Exception("La Muestra para " + DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().Trim() + " no posee lote");
                            }

                            Lotes[i] = _lote1;
                        }
                        
                    }
                    else {

                        if (!DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().StartsWith("ML") && !DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().StartsWith("YP"))
                        {

                            int _lote1 = int.Parse(CS.BuscarLote1(cod, pedido));

                            if (_lote1 == 0) throw new Exception("La Muestra para " + DGV_Muestra.SelectedRows[i].Cells[3].Value.ToString().Trim() + " no posee lote");

                            Lotes[i] = _lote1;
                        }
                    }
                    
                    

                    DataRow datarow = CS.ListarPeligroso(_id);

                    Peligroso[i, 0] = datarow[0].ToString();
                    Peligroso[i, 1] = datarow[1].ToString()
                    
                }
                
                
                //cargo el nombre cliente
                DataRow datacliente = CS.BuscarCliente(cliente);

                string _Pedido = DGV_Muestra.SelectedRows[0].Cells["Pedido"].Value.ToString();

                string _DirEntrega = _TraerDireccionEntregaPorPedido(_Pedido, _CodCliente);

                if (_DirEntrega.Trim() == "") throw new Exception("No se encuentra dirección de Entrega de Cliente");

                string CodClient = datacliente[0].ToString();
                string DirClient = datacliente[1].ToString();
                string LocalidadClient = datacliente[2].ToString();
                string Cuit = datacliente[3].ToString();
                string DirEntrega = _DirEntrega; //datacliente[4].ToString();

                string datos = numero_remito + ";" + cliente;
                AgregarColumnasRemito(_dt);

                

                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    if (Lotes[i] == 0)
                    {
                        Lotes[i] = int.Parse(DGV_Muestra.SelectedRows[i].Cells["Lote2"].Value.ToString());

                        if (Lotes[i] == 0)
                        {
                            Lotes[i] = int.Parse(DGV_Muestra.SelectedRows[i].Cells["Lote1"].Value.ToString());
                        }
                    }

                    DataRow newRow = _dt.NewRow();
                    newRow["Descripcion"] = DGV_Muestra.SelectedRows[i].Cells["DescriCliente"].Value.ToString();
                    newRow["Cantidad"] = DGV_Muestra.SelectedRows[i].Cells["Cantidad"].Value.ToString();
                    newRow["Muestra"] = DGV_Muestra.SelectedRows[i].Cells["Id"].Value.ToString();
                    newRow["Partida"] = Lotes[i];
                    newRow["Pedido"] = DGV_Muestra.SelectedRows[i].Cells["Pedido"].Value.ToString();
                    newRow["Codigo"] = Codigos[i];
                    newRow["Codigo_Original"] = DGV_Muestra.SelectedRows[i].Cells["Codigo"].Value.ToString();
                    newRow["Peligroso"] = Peligroso[i, 0];
                    newRow["PeligrosoII"] = Peligroso[i, 1];

                    HojasDeSeguridad[i, 0] = DGV_Muestra.SelectedRows[i].Cells["DescriCliente"].Value.ToString().Trim();

                    HojasDeSeguridad[i, 1] = DGV_Muestra.SelectedRows[i].Cells["Codigo"].Value.ToString().Trim();

                    _dt.Rows.Add(newRow);
                }

                
                Remito remito = new Remito(datos, _dt, errorLote, sinEnsayo, DirEntrega, CodClient, DirClient, LocalidadClient, Cuit, cliente, HojasDeSeguridad);
                remito.ShowDialog();

            }
                            
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        finalizado: ;
           
        }

        private string[] _BuscarDatosRemito(string WPedido, string WRemito)
        {
            string[] WDatos = new string[5];
            int WEmpresaRemito = -1;

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

                                if (WTipoPedido == "") return new string[5];

                                switch (WTipoPedido)
                                {
                                    case "1":
                                    case "5":
                                        {
                                            WEmpresaRemito = 1;
                                            break;
                                        }
                                    case "4":
                                        {
                                            WEmpresaRemito = 3;
                                            break;
                                        }
                                    default:
                                        {
                                            WEmpresaRemito = 4;
                                            break;
                                        }
                                }
                            }

                        }

                        cmd.CommandText = "SELECT * FROM NumeroRemito WHERE Punto = '" + WEmpresaRemito + "' AND Desde <= '" + WRemito + "' AND Hasta >= '" + WRemito + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                WDatos[0] = WPedido;
                                WDatos[1] = dr["Cai"].ToString();
                                WDatos[2] = dr["Fecha"].ToString();
                                WDatos[3] = WRemito.PadLeft(8, '0');
                                WDatos[4] = dr["Punto"].ToString().PadLeft(4, '0');
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return WDatos;

        }

        private string _TraerDireccionEntregaPorPedido(string wPedido, string codCliente)
        {
            string WDireccion = "";
            
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Direccion = CASE m.DirEntrega WHEN 1 THEN ISNULL(c.DirEntrega, '') WHEN 2 THEN ISNULL(c.DirEntregaII, '') WHEN 3 THEN ISNULL(c.DirEntregaIII, '') WHEN 4 THEN ISNULL(c.DirEntregaIV, '') WHEN 5 THEN ISNULL(c.DirEntregaV, '') ELSE '' END FROM Muestra m INNER JOIN Cliente c ON m.Cliente = c.Cliente WHERE m.Pedido = '" + wPedido + "' and m.Cliente = '" + codCliente + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                WDireccion = dr["Direccion"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }

            return WDireccion.Trim();
        }

        private void AgregarColumnasRemito(DataTable _dt)
        {
            _dt.Columns.Add("Descripcion", typeof(string));
            _dt.Columns.Add("Cantidad", typeof(string));
            _dt.Columns.Add("Muestra", typeof(string));
            _dt.Columns.Add("Partida", typeof(string));
            _dt.Columns.Add("Pedido", typeof(string));
            _dt.Columns.Add("Codigo", typeof(string));
            _dt.Columns.Add("Codigo_Original", typeof(string));
            _dt.Columns.Add("Peligroso", typeof(string));
            _dt.Columns.Add("PeligrosoII", typeof(string));
        }

        

        private void AgregarColumnas(DataTable _dt)
        {
            _dt.Columns.Add("NombreEmpresa", typeof(string));
            _dt.Columns.Add("Nombre", typeof(string));
            _dt.Columns.Add("Codigo", typeof(string));
            _dt.Columns.Add("DescriCliente", typeof(string));
            _dt.Columns.Add("Razon", typeof(string));
            _dt.Columns.Add("Fecha", typeof(string));
            _dt.Columns.Add("Direccion_1", typeof(string));
            _dt.Columns.Add("Direccion_2", typeof(string));
            _dt.Columns.Add("Clase", typeof(string));
            _dt.Columns.Add("Intervencion", typeof(string));
            _dt.Columns.Add("Naciones", typeof(string));
            _dt.Columns.Add("Lote", typeof(string));
        }

        private void BtImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                //Armo el datatable
                if (DGV_Muestra.SelectedRows.Count == 0) throw new Exception("No hay filas seleccionadas");

                DataTable _dt = new DataTable();
                foreach (DataGridViewColumn column in DGV_Muestra.Columns)
                    _dt.Columns.Add(column.Name, typeof(string));
                for (int i = 0; i < DGV_Muestra.SelectedRows.Count; i++)
                {
                    _dt.Rows.Add();
                    for (int j = 0; j < DGV_Muestra.Columns.Count; j++)
                    {
                        _dt.Rows[i][j] = DGV_Muestra.SelectedRows[i].Cells[j].Value;
                    }
                }

                Impresion impresion = new Impresion(_dt);
                impresion.ShowDialog();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void BtActLaborat_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Muestra.SelectedRows.Count == 0)
                    throw new Exception("No hay filas seleccionadas");
                if (DGV_Muestra.SelectedRows.Count > 1)
                    throw new Exception("Se seleccionaron mas de una fila");
                if (!DGV_Muestra.SelectedRows[0].Cells["Codigo"].Value.ToString().StartsWith("ML"))
                    throw new Exception("La muestra seleccionada no es una Muestra de Laboratorio");

                //creo el datatable
                DataTable _dt = new DataTable();

                _dt.Columns.Add("Id", typeof(string));
                _dt.Columns.Add("Codigo", typeof(string));
                _dt.Columns.Add("Ensayo", typeof(string));
                _dt.Columns.Add("Nombre", typeof(string));
                _dt.Columns.Add("Fecha", typeof(string));
                _dt.Columns.Add("Cantidad", typeof(string));
                _dt.Columns.Add("Observaciones", typeof(string));

                DataRow row = _dt.NewRow();
                //Estos datos que tomo estan bien o me tengo que fijar en ensayo2 y cantidad2? 
                row["Id"] = DGV_Muestra.SelectedRows[0].Cells["Id"].Value.ToString();
                row["Codigo"] = DGV_Muestra.SelectedRows[0].Cells["Codigo"].Value.ToString();
                row["Ensayo"] = DGV_Muestra.SelectedRows[0].Cells["CodigoConf"].Value.ToString();
                row["Nombre"] = DGV_Muestra.SelectedRows[0].Cells["Nombre"].Value.ToString();
                row["Fecha"] = DateTime.Now.ToShortDateString();
                row["Cantidad"] = DGV_Muestra.SelectedRows[0].Cells["Cantidad2"].Value.ToString();
                row["Observaciones"] = DGV_Muestra.SelectedRows[0].Cells["Observaciones2"].Value.ToString();

                _dt.Rows.Add(row);

                ActLab actlab = new ActLab(_dt);
                actlab.ShowDialog();
                
                ActualizarGridView();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void ActualizarGridView()
        {
            int index = DGV_Muestra.SelectedRows[0].Index; 
            TB_Desde.Text = ConfigurationManager.AppSettings["Fecha_Desde"];
            TB_Hasta.Text = ConfigurationManager.AppSettings["Fecha_Hasta"];
            BT_Buscar.PerformClick();
            DGV_Muestra.CurrentCell = DGV_Muestra.Rows[index].Cells[1];
            DGV_Muestra.Rows[index].Selected= true;
        }

        private void DGV_Muestra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    BtActLaborat.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.F5:
                    BtExportar.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.F6:
                    BtEtiquetas.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.F8:
                    BtRemito.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.F9:
                    BtImpresion.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.F10:
                    BtFin.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }
        }

        

        private void DGV_Muestra_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;

            if (index == 2)
            {
                if (OrdFecha == false)
                {
                    DGV_Muestra.Sort(DGV_Muestra.Columns[19], ListSortDirection.Ascending);
                    OrdFecha = true;
                }
                else
                {
                    DGV_Muestra.Sort(DGV_Muestra.Columns[19], ListSortDirection.Descending);
                    OrdFecha = false;
                }
            }
        }

       

        private void TBFiltro_TextChanged(object sender, EventArgs e)
        {
            BT_Filtrar.Text = "Filtrar";
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Muestra.SelectedRows.Count == 0)
                    throw new Exception("No hay filas seleccionadas");
                if (DGV_Muestra.SelectedRows.Count > 1)
                    throw new Exception("Se seleccionaron mas de una fila");
                if (DGV_Muestra.SelectedRows[0].Cells[12].Value.ToString() != "")
                    throw new Exception("La muestra no se puede eliminar porque tiene remito");

                DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar la muestra?", "Confirmacion eliminar",
                                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string _id = DGV_Muestra.SelectedRows[0].Cells["Id"].Value.ToString();
                string Producto = DGV_Muestra.SelectedRows[0].Cells["Codigo"].Value.ToString();

                int _pedido = CS.BuscarPedido(_id);
                CS.ModificCantidad(_pedido, Producto);
                CS.EliminarMuestra(_id);


                ActualizarGridView();

                MessageBox.Show("La muestra se elimino con exito", "Actualizacion Muestra Laboratorio",
                MessageBoxButtons.OK, MessageBoxIcon.None);
            }

                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemitosVarios_Click(object sender, EventArgs e)
        {
            Process.Start(@"\\193.168.0.2\g$\vb\Net\RemitosVarios\Ejecutable\RemitosVarios.exe", "1");
        }

    }
}
