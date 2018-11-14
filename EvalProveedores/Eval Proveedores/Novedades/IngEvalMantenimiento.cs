using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica_Negocio;
using Negocio;

namespace Eval_Proveedores.Novedades
{
    public partial class IngEvalMantenimiento : Form
    {
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtProveedores = new DataTable();
        DataTable dtAyuda = new DataTable();
        EvaVariosBOL EVABOL = new EvaVariosBOL();
        EvaluaVarios EVAR = new EvaluaVarios();
        Proveedor P = new Proveedor();
        bool Modificar = false;
        int Index1;
        int Index2;
        Dictionary<int, string> Lista1 = new Dictionary<int, string>();
        Dictionary<int, string> Lista2 = new Dictionary<int, string>();
        Dictionary<int, string> Lista3 = new Dictionary<int, string>();
        int PromedioTot = 0;
        int Promedio1 = 0;
        int Promedio2 = 0;
        int Promedio3 = 0;


        private int Tipo;
        private EvaluaVarios Eva;
        private string Estado;
        private string NombProve;
        

        public IngEvalMantenimiento()
        {
            InitializeComponent();
        }

        public IngEvalMantenimiento(int Tipo)
        {
            // TODO: Complete member initialization
            this.Tipo = Tipo;
            InitializeComponent();
        }

        public IngEvalMantenimiento(EvaluaVarios Eva, string Estado, string NombProve, int Tipo)
        {
            // TODO: Complete member initialization
            this.Eva = Eva;
            this.Estado = Estado;
            this.NombProve = NombProve;
            this.Tipo = Tipo;
            Modificar = true;
            InitializeComponent();
        }

        

        private void IngEvalTransportista_Load(object sender, EventArgs e)
        {
            
            CargarCBprimeraFila();
            CargarCBSegFila();
            CargarCBRestoFila();

            lblCalificacion1.Text = "";
            lblCalificacion2.Text = "";
            lblCalificacion3.Text = "";

            TB_Promedio1.Visible = false;
            TB_Promedio2.Visible = false;
            TB_Promedio3.Visible = false;

            if (Modificar == true)
            {
                BuscarTitulo();
                TB_CodProveedor.Text = Eva.Proveedor;
                TB_NombProveedor.Text = NombProve;
                P = PBOL.Find(TB_CodProveedor.Text);
                TB_ObservProve.Text = P.ObservacionesII;
                //TB_CodProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
                TB_CodProveedor.Enabled = false;
                TB_NombProveedor.Enabled = false;
                if (Estado == "Inhabilitado") TB_Estado.Visible = true;
                if (Eva.Mes < 10)
                {
                    TB_Mes.Text = "0" + Eva.Mes.ToString();
                }
                else
                {
                    TB_Mes.Text = Eva.Mes.ToString();
                }

                TB_Año.Text = Eva.Año.ToString();

                if (Eva.Sector1 != 0)
                {
                    CB_Sec1.SelectedIndex = Eva.Sector1;
                    CB_Calif11.SelectedIndex = int.Parse(Eva.Calif11.ToString());
                    CB_Calif12.SelectedIndex = int.Parse(Eva.Calif12.ToString());
                    CB_Calif13.SelectedIndex = int.Parse(Eva.Calif13.ToString());
                    CB_Calif14.SelectedIndex = int.Parse(Eva.Calif14.ToString());


                    
                    HabilitarCB1();
                    TB_Promedio1.Text = Eva.Promedio11.ToString();
                }

                if (Eva.Sector2 != 0)
                {
                    CB_Sec2.SelectedIndex = Eva.Sector2;
                    CB_Calif21.SelectedIndex = int.Parse(Eva.Calif21.ToString());
                    CB_Calif22.SelectedIndex = int.Parse(Eva.Calif22.ToString());
                    CB_Calif23.SelectedIndex = int.Parse(Eva.Calif23.ToString());
                    CB_Calif24.SelectedIndex = int.Parse(Eva.Calif24.ToString());
                    
                    HabilitarCB1();
                    TB_Promedio2.Text = Eva.Promedio22.ToString();
                }

                if (Eva.Sector3 != 0)
                {
                    CB_Sec3.SelectedIndex = Eva.Sector3;
                    CB_Calif31.SelectedIndex = int.Parse(Eva.Calif31.ToString());
                    CB_Calif32.SelectedIndex = int.Parse(Eva.Calif32.ToString());
                    CB_Calif33.SelectedIndex = int.Parse(Eva.Calif33.ToString());
                    CB_Calif34.SelectedIndex = int.Parse(Eva.Calif34.ToString());
                    
                    HabilitarCB1();
                    TB_Promedio3.Text = Eva.Promedio33.ToString();
                }

                SacarPromedio1();
                TB_Promedio1.Text = Promedio1.ToString(); 

                TB_PromedioTot.Text = Eva.PromedioTot.ToString();
                TB_ObservEva.Text = Eva.Observ;
                
            }
            else
            {
                CargarProveedores();
                ListarTitulo();
                groupBox1.Focus();
               // TB_NombProveedor.Focus();
            }
        }

        private void CargarProveedores()
        {
           /* switch (Tipo)
            {
                case 2:
                    dtProveedores.Clear();
                    dtProveedores = PBOL.ListaTipo(8);
                    break;

                case 4:
                    dtProveedores.Clear();
                    dtProveedores = PBOL.ListaSinTipo();
                    break;

                case 5:
                    dtProveedores.Clear();
                    dtProveedores = PBOL.ListaSinTipo();
                    break;
            }
            * */
            dtProveedores.Clear();
            dtProveedores = PBOL.ListaSinTipo();
            

            DataRow fila;
            fila = dtProveedores.NewRow();
            dtProveedores.Rows.InsertAt(fila, 0);


            CargarNombres();
            CargarCodigos();
            CargarObservac();
        }

        private void CargarObservac()
        {
            CB_ObservProve.DataSource = dtProveedores;
            CB_ObservProve.DisplayMember = "Observaciones";
            CB_ObservProve.ValueMember = "Proveedor";
            CB_ObservProve.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtProveedores.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Observaciones"]));

            }

            CB_ObservProve.AutoCompleteCustomSource = stringCodArti;
            CB_ObservProve.AutoCompleteMode = AutoCompleteMode.Suggest;
            CB_ObservProve.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarNombres()
        {
            TB_NombProveedor.DataSource = dtProveedores;
            TB_NombProveedor.DisplayMember = "Nombre";
            TB_NombProveedor.ValueMember = "Proveedor";
            TB_NombProveedor.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtProveedores.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Nombre"]));

            }

            TB_NombProveedor.AutoCompleteCustomSource = stringCodArti;
            TB_NombProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_NombProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigos()
        {
            TB_CodProveedor.DataSource = dtProveedores;
            TB_CodProveedor.DisplayMember = "Proveedor";
            TB_CodProveedor.ValueMember = "Proveedor";
            TB_CodProveedor.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtProveedores.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Proveedor"]));

            }

            TB_CodProveedor.AutoCompleteCustomSource = stringCodArti;
            TB_CodProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BuscarTitulo()
        {
            

            if (this.Eva.Tipo == 2) LB_TitEva.Text = "MODIFICAR EVALUACION DE PROVEEDOR DE CALIBRACION";

            if (this.Eva.Tipo == 4) LB_TitEva.Text = "MODIFICAR EVALUACION DE PROVEEDOR DE MANTENIMIENTO";

            if (this.Eva.Tipo == 5) LB_TitEva.Text = "MODIFICAR EVALUACION DE OTROS PROVEEDORES";

            if (this.Eva.Tipo == 1) LB_TitEva.Text = "MODIFICAR EVALUACION DE PROVEEDOR DE TRANSPORTE";
        }

        #region Cargar Combos
        private void CargarCBRestoFila()
        {
            Lista2.Add(0, "");
            Lista2.Add(1, "Cumple");
            Lista2.Add(2, "Parcial");
            Lista2.Add(3, "No Cumple");
            Lista2.Add(4, "No Aplica");
            CB_Calif12.DisplayMember = "Value";
            CB_Calif12.ValueMember = "Key";
            CB_Calif12.DataSource = Lista2.ToArray();
            CB_Calif13.DisplayMember = "Value";
            CB_Calif13.ValueMember = "Key";
            CB_Calif13.DataSource = Lista2.ToArray();
            CB_Calif14.DisplayMember = "Value";
            CB_Calif14.ValueMember = "Key";
            CB_Calif14.DataSource = Lista2.ToArray();
            CB_Calif22.DisplayMember = "Value";
            CB_Calif22.ValueMember = "Key";
            CB_Calif22.DataSource = Lista2.ToArray();
            CB_Calif23.DisplayMember = "Value";
            CB_Calif23.ValueMember = "Key";
            CB_Calif23.DataSource = Lista2.ToArray();
            CB_Calif24.DisplayMember = "Value";
            CB_Calif24.ValueMember = "Key";
            CB_Calif24.DataSource = Lista2.ToArray();
            CB_Calif32.DisplayMember = "Value";
            CB_Calif32.ValueMember = "Key";
            CB_Calif32.DataSource = Lista2.ToArray();
            CB_Calif33.DisplayMember = "Value";
            CB_Calif33.ValueMember = "Key";
            CB_Calif33.DataSource = Lista2.ToArray();
            CB_Calif34.DisplayMember = "Value";
            CB_Calif34.ValueMember = "Key";
            CB_Calif34.DataSource = Lista2.ToArray();
        }

        private void CargarCBSegFila()
        {
            Lista1.Add(0, "");
            Lista1.Add(1, "Cumple");
            Lista1.Add(2, "No Cumple");
            CB_Calif11.DisplayMember = "Value";
            CB_Calif11.ValueMember = "Key";
            CB_Calif11.DataSource = Lista1.ToArray();
            CB_Calif21.DisplayMember = "Value";
            CB_Calif21.ValueMember = "Key";
            CB_Calif21.DataSource = Lista1.ToArray();
            CB_Calif31.DisplayMember = "Value";
            CB_Calif31.ValueMember = "Key";
            CB_Calif31.DataSource = Lista1.ToArray();
        }

        private void CargarCBprimeraFila()
        {
            Lista3.Add(0, "");
            Lista3.Add(1, "C.CALIDAD");
            Lista3.Add(2, "DESARROLLO");
            Lista3.Add(3, "PIGMENTOS");
            Lista3.Add(4, "TEXTIL");
            Lista3.Add(5, "MANTENIMIENTO");
            CB_Sec1.DisplayMember = "Value";
            CB_Sec1.ValueMember = "Key";
            CB_Sec1.DataSource = Lista3.ToArray();
            CB_Sec2.DisplayMember = "Value";
            CB_Sec2.ValueMember = "Key";
            CB_Sec2.DataSource = Lista3.ToArray();
            CB_Sec3.DisplayMember = "Value";
            CB_Sec3.ValueMember = "Key";
            CB_Sec3.DataSource = Lista3.ToArray();
        }

        #endregion

        private void ListarTitulo()
        {
            switch (Tipo)
            {
                
                case 8:
                    LB_TitEva.Text = "INGRESO DE EVALUACION DE PROVEEDORES DE CALIBRACION";
                    break;

                case 4:
                    LB_TitEva.Text = "INGRESO DE EVALUACION DE PROVEEDORES DE MANTENIMIENTO";
                    break;

                case 5:
                    LB_TitEva.Text = "INGRESO DE EVALUACION DE PROVEEDORES VARIOS";
                    break;

                case 15:
                    LB_TitEva.Text = "INGRESO DE EVALUACION DE PROVEEDORES DE TRANSPORTE";
                    break;
            };
        }

        #region Habilitar ComboBox
        private void CB_Sec1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CB_Sec1.Text != "")
                {
                    if ((CB_Sec1.Text == CB_Sec2.Text) || (CB_Sec1.Text == CB_Sec3.Text)) throw new Exception("Ya ha elegido ese sector. Por favor elija otro sector para evaluar a el proveedor.");

                    HabilitarCB1();
                    
                }
                else
                {
                    CB_Calif11.Visible = false;
                    CB_Calif11.Text = "";
                    CB_Calif12.Visible = false;
                    CB_Calif12.Text = "";
                    CB_Calif13.Visible = false;
                    CB_Calif13.Text = "";
                    CB_Calif14.Visible = false;
                    CB_Calif14.Text = "";
                }
                

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void HabilitarCB1()
        {
            CB_Calif11.Visible = true;
            CB_Calif12.Visible = true;
            CB_Calif13.Visible = true;
            CB_Calif14.Visible = true;
        }

        private void CB_Sec2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CB_Sec2.Text != "")
                {
                    if ((CB_Sec2.Text == CB_Sec1.Text) || (CB_Sec2.Text == CB_Sec3.Text)) throw new Exception("Ya ha elegido ese sector. Por favor elija otro sector para evaluar a el proveedor.");

                    HabilitarCB2();
        
                    
                }
                else
                {
                    CB_Calif21.Visible = false;
                    CB_Calif21.Text = "";
                    CB_Calif22.Visible = false;
                    CB_Calif22.Text = "";
                    CB_Calif23.Visible = false;
                    CB_Calif23.Text = "";
                    CB_Calif24.Visible = false;
                    CB_Calif24.Text = "";
                }

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void HabilitarCB2()
        {
            CB_Calif21.Visible = true;
            CB_Calif22.Visible = true;
            CB_Calif23.Visible = true;
            CB_Calif24.Visible = true;
        }

        private void CB_Sec3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CB_Sec3.Text != "")
                {
                    if ((CB_Sec3.Text == CB_Sec1.Text) || (CB_Sec3.Text == CB_Sec2.Text)) throw new Exception("Ya ha elegido ese sector. Por favor elija otro sector para evaluar a el proveedor.");

                    HabilitarCB3();
                    
                }
                else
                {
                    CB_Calif31.Visible = false;
                    CB_Calif31.Text = "";
                    CB_Calif32.Visible = false;
                    CB_Calif32.Text = "";
                    CB_Calif33.Visible = false;
                    CB_Calif33.Text = "";
                    CB_Calif34.Visible = false;
                    CB_Calif34.Text = "";
                }

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void HabilitarCB3()
        {
            CB_Calif31.Visible = true;
            CB_Calif32.Visible = true;
            CB_Calif33.Visible = true;
            CB_Calif34.Visible = true;
        }

        #endregion

        #region Sacar Promedio 1


        private void CB_Calif11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif12.Text != "") && (CB_Calif13.Text != "") && (CB_Calif14.Text != ""))
            {
                SacarPromedio1();
                TB_Promedio1.Text = Promedio1.ToString(); 
            }
        }



        private void CB_Calif12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif11.Text != "") && (CB_Calif13.Text != "") && (CB_Calif14.Text != ""))
            {
                SacarPromedio1();
                TB_Promedio1.Text = Promedio1.ToString(); 
            }
        }

        private void CB_Calif13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif11.Text != "") && (CB_Calif12.Text != "") && (CB_Calif14.Text != ""))
            {
                SacarPromedio1();
                TB_Promedio1.Text = Promedio1.ToString(); 
            }
        }

        private void CB_Calif14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif11.Text != "") && (CB_Calif12.Text != "") && (CB_Calif13.Text != ""))
            {
                SacarPromedio1();
                TB_Promedio1.Text = Promedio1.ToString(); 
            }
        }

        private void SacarPromedio1()
        {
            Promedio1 = 0;
            var WCal1 = CB_Calif11.SelectedIndex;
            var WCal2 = CB_Calif12.SelectedIndex;
            var WCal3 = CB_Calif13.SelectedIndex;
            var WCal4 = CB_Calif14.SelectedIndex;

            if (WCal1 == 4) WCal1 = 1;
            if (WCal2 == 4) WCal2 = 1;
            if (WCal3 == 4) WCal3 = 1;
            if (WCal4 == 4) WCal4 = 1;

            if (WCal1 == 2)
            {
                Promedio1 = 1;
            }
            else if (WCal2 == 1 && WCal3 == 1 && WCal4 == 1)
            {
                Promedio1 = 10;
            }
            else
            {
                Promedio1 = 5;
            }
        }

        #endregion

        #region Sacar Promedio 2


        private void CB_Calif21_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif22.Text != "") && (CB_Calif23.Text != "") && (CB_Calif24.Text != ""))
            {
                SacarPromedio2();
                TB_Promedio2.Text = Promedio2.ToString();
            }
        }

        

        private void CB_Calif22_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif21.Text != "") && (CB_Calif23.Text != "") && (CB_Calif24.Text != ""))
            {
                SacarPromedio2();
                TB_Promedio2.Text = Promedio2.ToString();
            }
        }

        private void CB_Calif23_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif21.Text != "") && (CB_Calif22.Text != "") && (CB_Calif24.Text != ""))
            {
                SacarPromedio2();
                TB_Promedio2.Text = Promedio2.ToString();
            }
        }

        private void CB_Calif24_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif21.Text != "") && (CB_Calif22.Text != "") && (CB_Calif24.Text != ""))
            {
                SacarPromedio2();
                TB_Promedio2.Text = Promedio2.ToString();
            }
        }

        private void SacarPromedio2()
        {
            Promedio2 = 0;
            var WCal1 = CB_Calif21.SelectedIndex;
            var WCal2 = CB_Calif22.SelectedIndex;
            var WCal3 = CB_Calif23.SelectedIndex;
            var WCal4 = CB_Calif24.SelectedIndex;

            if (WCal1 == 4) WCal1 = 1;
            if (WCal2 == 4) WCal2 = 1;
            if (WCal3 == 4) WCal3 = 1;
            if (WCal4 == 4) WCal4 = 1;

            if (WCal1 == 2)
            {
                Promedio2 = 1;
            }
            else if (WCal2 == 1 && WCal3 == 1 && WCal4 == 1)
            {
                Promedio2 = 10;
            }
            else
            {
                Promedio2 = 5;
            }

        }

        #endregion

        #region Sacar Promedio 3

        private void CB_Calif31_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif32.Text != "") && (CB_Calif33.Text != "") && (CB_Calif34.Text != ""))
            {
                SacarPromedio3();
                TB_Promedio3.Text = Promedio3.ToString();
            }
        }

        private void CB_Calif32_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif31.Text != "") && (CB_Calif33.Text != "") && (CB_Calif34.Text != ""))
            {
                SacarPromedio3();
                TB_Promedio3.Text = Promedio3.ToString();
            }
        }

        private void CB_Calif33_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif31.Text != "") && (CB_Calif32.Text != "") && (CB_Calif34.Text != ""))
            {
                SacarPromedio3();
                TB_Promedio3.Text = Promedio3.ToString();
            }
        }

        private void CB_Calif34_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Calif31.Text != "") && (CB_Calif32.Text != "") && (CB_Calif33.Text != ""))
            {
                SacarPromedio3();
                TB_Promedio3.Text = Promedio3.ToString();
            }
        }

        private void SacarPromedio3()
        {
            Promedio3 = 0;
            var WCal1 = CB_Calif31.SelectedIndex;
            var WCal2 = CB_Calif32.SelectedIndex;
            var WCal3 = CB_Calif33.SelectedIndex;
            var WCal4 = CB_Calif34.SelectedIndex;

            if (WCal1 == 4) WCal1 = 1;
            if (WCal2 == 4) WCal2 = 1;
            if (WCal3 == 4) WCal3 = 1;
            if (WCal4 == 4) WCal4 = 1;

            if (WCal1 == 2)
            {
                Promedio3 = 1;
            }
            else if (WCal2 == 1 && WCal3 == 1 && WCal4 == 1)
            {
                Promedio3 = 10;
            }
            else
            {
                Promedio3 = 5;
            }
        }

        #endregion


        private void BTEvaluacionAnt_Click(object sender, EventArgs e)
        {
           // GB_Prove.Visible = false;
        }

        private int ValidarClave()
        {
            int WResp = 0;

            LoginAdmin Log = new LoginAdmin(WResp);
            Log.ShowDialog();
            WResp = Log.ValidClave;

            return WResp;
        }


        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            //GB_Prove.Visible = false;
            try
            {

                if (ValidarClave() != 1) return;

                if (TB_CodProveedor.Text == "") throw new Exception("Se debe ingresar el proveedor que desea evaluar");

                if (TB_Mes.Text == "") throw new Exception("Se debe ingresar el mes de la evaluación");

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el año de la evaluación");

                if (CB_Sec1.Text != "")
                {
                    if ((CB_Calif11.Text == "") || (CB_Calif12.Text == "") || (CB_Calif13.Text == "") || (CB_Calif14.Text == "")) throw new Exception("Se debe calificar todos los parametros del sector");
                }

                if (CB_Sec2.Text != "")
                {
                    if ((CB_Calif21.Text == "") || (CB_Calif22.Text == "") || (CB_Calif23.Text == "") || (CB_Calif24.Text == "")) throw new Exception("Se debe calificar todos los parametros del sector");
                }

                if (CB_Sec3.Text != "")
                {
                    if ((CB_Calif31.Text == "") || (CB_Calif32.Text == "") || (CB_Calif33.Text == "") || (CB_Calif34.Text == "")) throw new Exception("Se debe calificar todos los parametros del sector");
                }

                if ((TB_Promedio1.Text != "0") || (TB_Promedio2.Text != "0") || (TB_Promedio3.Text != "0"))
                {
                    
                        CargarEva();
                        _ActualizarObservacionesProveedor();
    
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("No se ha calificado al proveedor en ningún sector. ¿Desea guardar la evaluación igualmente?", "Guardar evaluación",
                                  MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            CargarEva();

                            _ActualizarObservacionesProveedor();
                        }
                }

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ActualizarObservacionesProveedor()
        {
            foreach (
                string empre in
                    new string[]
                    {
                        "SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI",
                        "Surfactan_VII"
                    })
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[empre].ToString()))
                {
                    cnx.Open();
                    string sqlQuery = "update Proveedor set ObservacionesII = '" + TB_ObservProve.Text.Trim() +
                                      "' WHERE proveedor = '" + TB_CodProveedor.Text + "'";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void CargarEva()
        {
            
                


                CalificarProve();
                EVAR.Clave = TB_CodProveedor.Text + TB_Mes.Text + TB_Año.Text;
                EVAR.Proveedor = TB_CodProveedor.Text;
                EVAR.Mes = int.Parse(TB_Mes.Text);
                EVAR.Año = int.Parse(TB_Año.Text);
                EVAR.PromedioTot = double.Parse(TB_PromedioTot.Text);

                
                EVAR.Promedio11 = double.Parse(TB_Promedio1.Text);

                EVAR.Promedio22 = double.Parse(TB_Promedio2.Text);
                EVAR.Promedio33 = double.Parse(TB_Promedio3.Text);
                EVAR.Observ = TB_ObservEva.Text;
                EVAR.Periodo = TB_Año.Text + TB_Mes.Text;
                EVAR.Tipo = Tipo;
                EVAR.Param1 = LB_Param1.Text;
                EVAR.Param2 = LB_Param2.Text;
                EVAR.Param3 = LB_Param3.Text;
                EVAR.Param4 = LB_Param41.Text + " " + LB_Param42.Text.Substring(0, 7);
                EVAR.Criterio1 = LB_Crit11.Text + " " + LB_Crit12.Text.Substring(0, 13);
                EVAR.Criterio2 = LB_Crit21.Text + " " + LB_Crit22.Text.Substring(0, 13);
                EVAR.Criterio3 = LB_Crit31.Text + " " + LB_Crit32.Text;
                EVAR.Criterio4 = LB_Crit41.Text + " " + LB_Crit42.Text.Substring(0, 12);


                EVAR.Calif11 = CB_Calif11.SelectedIndex;
                EVAR.Calif12 = CB_Calif12.SelectedIndex;
                EVAR.Calif13 = CB_Calif13.SelectedIndex;
                EVAR.Calif14 = CB_Calif14.SelectedIndex;

                EVAR.Calif21 = CB_Calif21.SelectedIndex;
                EVAR.Calif22 = CB_Calif22.SelectedIndex;
                EVAR.Calif23 = CB_Calif23.SelectedIndex;
                EVAR.Calif24 = CB_Calif24.SelectedIndex;

                EVAR.Calif31 = CB_Calif31.SelectedIndex;
                EVAR.Calif32 = CB_Calif32.SelectedIndex;
                EVAR.Calif33 = CB_Calif33.SelectedIndex;
                EVAR.Calif34 = CB_Calif34.SelectedIndex;

                EVAR.Sector1 = CB_Sec1.SelectedIndex;
                EVAR.Sector2 = CB_Sec2.SelectedIndex;
                EVAR.Sector3 = CB_Sec3.SelectedIndex;

                EVAR.DesSector1 = CB_Sec1.Text;
                EVAR.DesSector2 = CB_Sec2.Text;
                EVAR.DesSector3 = CB_Sec3.Text;

                if (Modificar == false)
                {
                    EVABOL.Insertar(EVAR);

                    MessageBox.Show("La evaluación se agregó con éxito", "Agregar Evaluación",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    EVABOL.Modificar(EVAR);
                    MessageBox.Show("La evaluación se modifico con éxito", "Modificar Evaluación",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                Close();

            
            
            
           
            
            

            
        }

        

        

        
        private void CalificarProve()
        {
            try
            {
               
                if (TB_CodProveedor.Text == "") throw new Exception("Se debe ingresar el proveedor que desea evaluar");

                PromedioTot = 10;
                if ((TB_Promedio1.Text == "") && (TB_Promedio2.Text == "") && (TB_Promedio3.Text == "") || (TB_Promedio1.Text == "0") && (TB_Promedio2.Text == "0") && (TB_Promedio3.Text == "0"))
                 {
                     PromedioTot = 0;

                 }
                 
                if ((TB_Promedio1.Text == "5") || (TB_Promedio2.Text == "5") || (TB_Promedio3.Text == "5"))
                {
                    PromedioTot = 5;
                }

                if ((TB_Promedio1.Text == "1") || (TB_Promedio2.Text == "1") || (TB_Promedio3.Text == "1"))
                {
                    PromedioTot = 1;
                }
                if (TB_Promedio1.Text == "") TB_Promedio1.Text = "0";
                if (TB_Promedio2.Text == "") TB_Promedio2.Text = "0";
                if (TB_Promedio3.Text == "") TB_Promedio3.Text = "0";
                TB_PromedioTot.Text = PromedioTot.ToString();
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            //SOLO SE PERMITE LIMPIAR A PANTALLA CUANDO NO SE MODIFICA
            if (Modificar == false)
            {
                //GB_Prove.Visible = false;
                TB_CodProveedor.Text = "";
                TB_NombProveedor.Text = "";
                TB_Estado.Visible = false;

                TB_Mes.Text = "";
                TB_Año.Text = "";

                CB_Sec1.Text = "";
                CB_Sec2.Text = "";
                CB_Sec3.Text = "";

                CB_Calif11.Text = "";
                CB_Calif12.Text = "";
                CB_Calif13.Text = "";
                CB_Calif14.Text = "";

                CB_Calif21.Text = "";
                CB_Calif22.Text = "";
                CB_Calif23.Text = "";
                CB_Calif24.Text = "";

                CB_Calif31.Text = "";
                CB_Calif32.Text = "";
                CB_Calif33.Text = "";
                CB_Calif34.Text = "";

                TB_Promedio1.Text = "";
                TB_Promedio2.Text = "";
                TB_Promedio3.Text = "";

                TB_PromedioTot.Text = "";

                TB_ObservProve.Text = "";
                TB_ObservEva.Text = "";

            }
            
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_CalificProve_Click(object sender, EventArgs e)
        {
            CalificarProve();
        }




        #region Ayuda Proveedor

        private void TB_CodProve_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void RBDescripcion_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void RBCodigo_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void TBFiltro_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void LBProveedor_MouseCaptureChanged_1(object sender, EventArgs e)
        {
            

        }

        private void TB_NombProve_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Sec1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Sec2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Sec3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif11_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif21_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif31_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif12_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif22_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif32_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif13_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif23_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif33_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void CB_Calif14_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif24_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_Calif34_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_PromedioTot_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void LB_ObservProve_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void LB_ObservEva_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        #endregion

        private void TB_NombProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Mes.Focus();
                TB_ObservProve.Text = CB_ObservProve.Text;
            }
        }

        private void TB_CodProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Mes.Focus();
            }
        }

        private void TB_Mes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Año.Focus();
            }
        }

        private void TB_Mes_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Año.Focus();
            }
        }

        

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Sec1.Focus();
            }
        }

        private void TB_Año_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Sec1.Focus();
            }
        }

        private void CB_Sec1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif11.Focus();
            }
        }

        private void CB_Calif11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif12.Focus();
            }
        }

        private void CB_Calif12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif13.Focus();
            }
        }

        private void CB_Calif13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif14.Focus();
            }
        }

        private void CB_Calif14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                CalificarProve();
                CB_Sec2.Focus();
            }
        }

        private void CB_Sec2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif21.Focus();
            }
        }

        private void CB_Calif21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif22.Focus();
            }
        }

        private void CB_Calif22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif23.Focus();
            }
        }

        private void CB_Calif23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif24.Focus();
            }
        }

        private void CB_Calif24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                CalificarProve();
                CB_Sec3.Focus();
            }
        }

        private void CB_Sec3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif31.Focus();
            }
        }

        private void CB_Calif31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif32.Focus();
            }
        }

        private void CB_Calif32_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif33.Focus();
            }
        }

        private void CB_Calif33_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CB_Calif34.Focus();
            }
        }

        private void CB_Calif34_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CalificarProve();
            }
        }

        private void TB_Mes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
                
        }

        private void TB_Mes_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        

        private void TB_Año_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        private void BT_Inhabilitar_Click(object sender, EventArgs e)
        {
            if (TB_PromedioTot.Text != "")
            {
                InhabilitarProveedor();

            }
            else
            {
                MessageBox.Show("No se puede inhabilitar al proveedor sino fue evaluado", "Inhabilitar Proveedor",
               MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void InhabilitarProveedor()
        {
            P.Codigo = TB_CodProveedor.Text;
            PBOL.Inhabilitar(P, "SurfactanSA");
            PBOL.Inhabilitar(P, "Surfactan_V");
            PBOL.Inhabilitar(P, "Surfactan_II");
            PBOL.Inhabilitar(P, "Surfactan_III");
            PBOL.Inhabilitar(P, "Surfactan_VI");



            //GuardarEva();

            MessageBox.Show("Se ha inhabilitado el proveedor", "Inhabilitar Proveedor",
               MessageBoxButtons.OK, MessageBoxIcon.None);

            TB_Estado.Visible = true;
        }

        private void _ActualizarCalificacion(object sender, EventArgs e)
        {
            short WCalif1, WCalif2, WCalif3;

            TB_Promedio1.Visible = false;
            TB_Promedio2.Visible = false;
            TB_Promedio3.Visible = false;

            WCalif1 = TB_Promedio1.Text == "" ? short.Parse("0") :short.Parse(TB_Promedio1.Text);
            WCalif2 = TB_Promedio2.Text == "" ? short.Parse("0") :short.Parse(TB_Promedio2.Text);
            WCalif3 = TB_Promedio3.Text == "" ? short.Parse("0") :short.Parse(TB_Promedio3.Text);

            lblCalificacion1.Text = _ObtenerDescripcionCalificacion(WCalif1);
            lblCalificacion2.Text = _ObtenerDescripcionCalificacion(WCalif2);
            lblCalificacion3.Text = _ObtenerDescripcionCalificacion(WCalif3);

            lblCalificacion1.BackColor = _DeterminarColorPorCalificacion(WCalif1);
            lblCalificacion2.BackColor = _DeterminarColorPorCalificacion(WCalif2);
            lblCalificacion3.BackColor = _DeterminarColorPorCalificacion(WCalif3);

        }

        private Color _DeterminarColorPorCalificacion(short WCalif1)
        {
            switch (WCalif1)
            {
                case 1:
                    {
                        return Color.OrangeRed;
                    }
                case 5:
                    {
                        return Color.Orange;
                    }
                case 10:
                    {
                        return Color.ForestGreen;
                    }
                default:
                    {
                        return Color.LightGray;
                    }
            }
        }

        private string _ObtenerDescripcionCalificacion(short WCalif1)
        {
            switch (WCalif1)
            {
                case 1:
                {
                    return "NO APTO";
                }
                case 5:
                {
                    return "CONDICIONAL";
                }
                case 10:
                {
                    return "APTO";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}
