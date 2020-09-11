using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Logica_Negocio;

namespace Eval_Proveedores.Listados.CheckListRecepcion
{
    public partial class Inicio : Form
    {
        InformeConsolBOL IBOL = new InformeConsolBOL();
        DataTable dtInforme;
        DataTable dtInfMuestra;
        string Tipo = "";
        int FechaDesde;
        int FechaHasta;



        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Enabled= false;

                if(TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                FechaDesde = int.Parse(Helper.OrdenarFecha(TB_Desde.Text));

                FechaHasta = int.Parse(Helper.OrdenarFecha(TB_Hasta.Text));

                //dtInforme = IBOL.Lista();

                if (cmbTipo.SelectedIndex == 0)
                {
                    dtInforme = IBOL.Lista(Helper.OrdenarFecha(TB_Desde.Text), Helper.OrdenarFecha(TB_Hasta.Text), cmbTipo.SelectedIndex);

                    BuscarFechas();
                    Tipo = "Impresora";
                    ImpreInforme Impre = new ImpreInforme(dtInfMuestra, Tipo);
                    Impre.Show();
                }
                else
                {
                    this._Procesar(sender);
                }


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Enabled= true;
        }

        private void _Procesar(object sender)
        {
            DataTable datos = new DSInforme.DSInformeMPDataTable();
                    
            Util.Clases.Conexion._EmpresaTrabajo = "SurfactanSa";

            Dictionary<string, string> emp =
            new Dictionary<string,string>{
                {"Surfactan I", "SurfactanSa"},
                {"Surfactan II", "Surfactan_II"},
                {"Surfactan III", "Surfactan_III"},
                {"Surfactan IV", "Surfactan_IV"},
                {"Surfactan V", "Surfactan_V"},
                {"Surfactan VI", "Surfactan_VI"},
                {"Surfactan VII", "Surfactan_VII"}
            };

            DataTable tabla = new DataTable();

            foreach (KeyValuePair<string, string> pair in emp)
            {
                tabla.Rows.Clear();

                tabla = Util.Clases.Query.GetAll(
                "select distinct i.Informe, i.Fecha, i.Proveedor, p.Nombre, i.Articulo, a.Descripcion As DescArticulo, i.Cantidad, i.CantidadEnv, i.EstadoEnvI, i.EstadoEnvII, i.EstadoEnvIII, i.EstadoEnvIV, i.EstadoEnvV, i.EstadoEnvVI, i.EstadoEnvVII, i.EstadoEnvVIII, i.EstadoEnvIX, i.EstadoEnvX, i.ObservaI, i.ObservaII, i.ObservaIII, i.ObservaIV, eu.Ensayo1, eu.Ensayo2, eu.Ensayo3, eu.Ensayo4, eu.Ensayo5 from informe i inner join Proveedor p ON p.proveedor = i.Proveedor inner join orden o on o.orden = i.orden left outer join surfactan_II.dbo.EspecificacionesUnifica eu ON eu.Producto  collate Modern_Spanish_CI_AS = i.Articulo collate Modern_Spanish_CI_AS inner join Articulo a ON a.codigo = i.Articulo where o.Tipo in (3,4) and i.FechaOrd BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "' order by i.Proveedor, i.informe", pair.Value);

                foreach (DataRow row in tabla.Rows)
                {
                    for (var index = 1; index <= 5; index++)
                    {
                        string s = new[] {"", "I", "III", "V", "VII", "IX"}[index];
                        string s2 = new[] {"", "II", "IV", "VI", "VIII", "X"}[index];

                        DataRow r = datos.NewRow();

                        r["Informe"] = row["Informe"];
                        r["Proveedor"] = row["Proveedor"];
                        r["DescProveedor"] = row["Nombre"];
                        r["Articulo"] = row["Articulo"];
                        r["DescArticulo"] = row["DescArticulo"];
                        r["Cant"] = row["Cantidad"];
                        r["Cantidad"] = row["CantidadEnv"];
                        r["Valor1"] = Int32.Parse(row["EstadoEnv" + s].ToString()) == 1
                            ? Char.Parse("X")
                            : Char.Parse(" ");
                        r["Valor2"] = Int32.Parse(row["EstadoEnv" + s2].ToString()) == 1
                            ? Char.Parse("X")
                            : Char.Parse(" ");

                        r["Item"] = this._obtenerDescripcionEnsayo(row["Ensayo" + index]);
                        r["Planta"] = pair.Key;

                        datos.Rows.Add(r);
                    }
                }
            }

            Util.VistaPrevia frm = new Util.VistaPrevia {Reporte = new ReporteInformeMP()};

            frm.Reporte.SetDataSource(datos);

            if (((Button) sender).Name == BT_Imprimir.Name)
            {
                frm.Imprimir();
            }
            else
            {
                frm.Mostrar();
            }

        }

        private string _obtenerDescripcionEnsayo(object o)
        {
            DataRow ensayo =
                Util.Clases.Query.GetSingle("SELECT Descripcion FROM Surfactan_II.dbo.Ensayos WHERE Codigo = '" + o +
                                            "'");
            if (ensayo == null) return "";

            return Helper.OrDefault(ensayo["Descripcion"], "").ToString().ToUpper().Trim();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                FechaDesde = int.Parse(TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2));

                FechaHasta = int.Parse(TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2));

                if (cmbTipo.SelectedIndex == 0)
                {
                    dtInforme = IBOL.Lista(Helper.OrdenarFecha(TB_Desde.Text), Helper.OrdenarFecha(TB_Hasta.Text), cmbTipo.SelectedIndex);

                    BuscarFechas();
                    Tipo = "Pantalla";

                    ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                    Impre.Show();

                }else
                {
                    this._Procesar(sender);
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Enabled = true;

        }

        private void BuscarFechas()
        {
            dtInfMuestra = dtInforme.Clone();
            dtInfMuestra.Clear();

            foreach (DataRow fila in dtInforme.Rows)
            {
                dtInfMuestra.ImportRow(fila);
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (TB_Desde.Text.Replace('/', ' ').Trim() == "") return;

                TB_Hasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_Desde.Text = "";
            }
	        
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
