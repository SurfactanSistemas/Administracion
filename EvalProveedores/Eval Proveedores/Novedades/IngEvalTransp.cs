using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Logica_Negocio;
using Negocio;

namespace Eval_Proveedores.Novedades
{
    public partial class IngEvalTransp : Form
    {
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtProveedores = new DataTable();
        DataTable dtChoferes = new DataTable();
        DataTable dtChoferes2 = new DataTable();
        DataTable dtChoferes3 = new DataTable();
        DataTable dtCamion = new DataTable();
        DataTable dtCamion2 = new DataTable();
        DataTable dtCamion3 = new DataTable();
        ChoferBOL CBOL = new ChoferBOL();
        CamionBOL CABOL = new CamionBOL();
        EvaluaTransp EVATRA = new EvaluaTransp();
        EvaTransBOL EVATRABOL = new EvaTransBOL();
        Proveedor P = new Proveedor();
        Camion CA = new Camion();

        int NDom;
        double PromedioTot;
        double Promedio11;
        double Promedio22;
        double Promedio33;
        double Promedio1;
        double Promedio2;
        double Promedio3;
        double Promedio4;
        double Promedio5;
        Dictionary<int, string> Lista1 = new Dictionary<int, string>();
        bool Modificar;
        bool Cargado;
        bool CargadoD;
        int IdCamion1;
        int IdCamion2;
        int IdCamion3;



        private int Tipo;
        private EvaluaTransp EvaTrans;
        private string Estado;
        private string NombProve;

        public IngEvalTransp()
        {
            InitializeComponent();
        }

        public IngEvalTransp(int Tipo)
        {
            // TODO: Complete member initialization
            this.Tipo = Tipo;
            InitializeComponent();
        }

        

        

        public IngEvalTransp(EvaluaTransp EvaTrans, string Estado, string NombProve)
        {
            // TODO: Complete member initialization
            this.EvaTrans = EvaTrans;
            this.Estado = Estado;
            this.NombProve = NombProve;
            Modificar = true;
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void IngEvalTransp_Load(object sender, EventArgs e)
        {
            CargarCombos();
            OcultarTextCalif();
            if (Modificar)
            {
                LB_TitEva.Text = "MODIFICAR EVALUACION DE TRANSPORTISTA";
                TB_CodProveedor.Text = EvaTrans.Proveedor;
                TB_NombProveedor.Text = NombProve;
                TB_CodProveedor.Enabled = false;
                TB_NombProveedor.Enabled = false;
                
                if (Estado == "Inhabilitado") TB_Estado.Visible = true;
                if (EvaTrans.Mes < 10)
                {
                    TB_Mes.Text = "0" + EvaTrans.Mes;
                }
                else
                {
                    TB_Mes.Text = EvaTrans.Mes.ToString();
                }
               
                TB_Año.Text = EvaTrans.Año.ToString();
                TB_Evaluador.Text = EvaTrans.Evaluador;
                TB_Fecha.Text = EvaTrans.Fecha;
                TB_Venc.Text = EvaTrans.FechaVenc;
                if ((EvaTrans.Chofer1 != 0) && (EvaTrans.Camion1 != 0))
                {
                    TB_CodChof1.Text = EvaTrans.Chofer1.ToString();
                    TB_DescChof1.Text = EvaTrans.DescChofer1;
                    int Chapa1 = int.Parse(EvaTrans.Camion1.ToString());
                    CA = CABOL.Find(Chapa1);
                    TB_Dom1.Text = CA.Patente;
                    TB_DescDom1.Text = EvaTrans.Dominio1;
                    CB_Punt11.Text = EvaTrans.Puntaje11.ToString();
                    CB_Punt12.Text = EvaTrans.Puntaje12.ToString();
                    CB_Punt13.Text = EvaTrans.Puntaje13.ToString();
                    CB_Punt14.Text = EvaTrans.Puntaje14.ToString();
                    CB_Punt15.Text = EvaTrans.Puntaje15.ToString();
                    TB_Promedio1.Text = EvaTrans.Promedio1.ToString();
                    TB_Promedio2.Text = EvaTrans.Promedio2.ToString();
                    TB_Promedio3.Text = EvaTrans.Promedio3.ToString();
                    TB_Promedio4.Text = EvaTrans.Promedio4.ToString();
                    TB_Promedio5.Text = EvaTrans.Promedio5.ToString();
                    TB_Promedio11.Text = EvaTrans.Promedio11.ToString();
                    HabilitarCalif1();
                }


                if ((EvaTrans.Chofer2 != 0) && (EvaTrans.Camion2 != 0))
                {
                    TB_CodChof2.Text = EvaTrans.Chofer2.ToString();
                    TB_DescChof2.Text = EvaTrans.DescChofer2;
                    TB_Dom2.Text = EvaTrans.Camion2.ToString();
                    TB_DescDom2.Text = EvaTrans.Dominio2;
                    CB_Punt21.Text = EvaTrans.Puntaje21.ToString();
                    CB_Punt22.Text = EvaTrans.Puntaje22.ToString();
                    CB_Punt23.Text = EvaTrans.Puntaje23.ToString();
                    CB_Punt24.Text = EvaTrans.Puntaje24.ToString();
                    CB_Punt25.Text = EvaTrans.Puntaje25.ToString();
                    TB_Promedio22.Text = EvaTrans.Promedio22.ToString();
                    HabilitarCalif2();
                }
                else
                {
                    CargarChof2();
                    CargarDom2();
                }


                if ((EvaTrans.Chofer2 != 0) && (EvaTrans.Camion2 != 0))
                {
                    TB_CodChof3.Text = EvaTrans.Chofer3.ToString();
                    TB_DescChof3.Text = EvaTrans.DescChofer3;
                    TB_Dom3.Text = EvaTrans.Camion3.ToString();
                    TB_DescDom3.Text = EvaTrans.Dominio3;
                    CB_Punt31.Text = EvaTrans.Puntaje31.ToString();
                    CB_Punt32.Text = EvaTrans.Puntaje32.ToString();
                    CB_Punt33.Text = EvaTrans.Puntaje33.ToString();
                    CB_Punt34.Text = EvaTrans.Puntaje34.ToString();
                    CB_Punt35.Text = EvaTrans.Puntaje35.ToString();
                    TB_Promedio33.Text = EvaTrans.Promedio33.ToString();
                    HabilitarCalif3();
                }
                else
                {
                    CargarChof3();
                    CargarDom3();
                }
                
                TB_PromedioTot.Text = EvaTrans.PromedioTot.ToString();
                TB_ObservEva.Text = EvaTrans.Observ;

                Modificar = true;

                BuscarEstadoProveevor();

                //CargarCombos();
            }
            else
            {
                CargarProveedores();
                LB_TitEva.Text = "INGRESO EVALUACION DE TRANSPORTISTA";
                OcultarTextCalif();
                DateTime Hoy = DateTime.Today;
                TB_Fecha.Text = Hoy.ToString("d");
                
            }
            
        }

        private void CargarProveedores()
        {
            dtProveedores.Clear();
            //dtProveedores = PBOL.ListaTipo(15);
            dtProveedores = PBOL.ListaSinTipo();

            var fila = dtProveedores.NewRow();
            dtProveedores.Rows.InsertAt(fila, 0);


            CargarNombres();
            CargarCodigos();
        }

        private void CargarNombres()
        {
            TB_NombProveedor.DataSource = dtProveedores;
            CargadoD = false;
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

        

        private void CargarCombos()
        {
            Lista1.Add(0, "");
            Lista1.Add(1, "1");
            Lista1.Add(2, "2");
            Lista1.Add(3, "3");
            Lista1.Add(4, "4");
            Lista1.Add(5, "5");
            Lista1.Add(6, "6");
            Lista1.Add(7, "7");
            Lista1.Add(8, "8");
            Lista1.Add(9, "9");
            Lista1.Add(10, "10");

            CB_Punt11.DisplayMember = "Value";
            CB_Punt11.ValueMember = "Key";
            CB_Punt11.DataSource = Lista1.ToArray();

            CB_Punt12.DisplayMember = "Value";
            CB_Punt12.ValueMember = "Key";
            CB_Punt12.DataSource = Lista1.ToArray();

            CB_Punt13.DisplayMember = "Value";
            CB_Punt13.ValueMember = "Key";
            CB_Punt13.DataSource = Lista1.ToArray();

            CB_Punt14.DisplayMember = "Value";
            CB_Punt14.ValueMember = "Key";
            CB_Punt14.DataSource = Lista1.ToArray();

            CB_Punt15.DisplayMember = "Value";
            CB_Punt15.ValueMember = "Key";
            CB_Punt15.DataSource = Lista1.ToArray();

            CB_Punt21.DisplayMember = "Value";
            CB_Punt21.ValueMember = "Key";
            CB_Punt21.DataSource = Lista1.ToArray();

            CB_Punt22.DisplayMember = "Value";
            CB_Punt22.ValueMember = "Key";
            CB_Punt22.DataSource = Lista1.ToArray();

            CB_Punt23.DisplayMember = "Value";
            CB_Punt23.ValueMember = "Key";
            CB_Punt23.DataSource = Lista1.ToArray();

            CB_Punt24.DisplayMember = "Value";
            CB_Punt24.ValueMember = "Key";
            CB_Punt24.DataSource = Lista1.ToArray();

            CB_Punt25.DisplayMember = "Value";
            CB_Punt25.ValueMember = "Key";
            CB_Punt25.DataSource = Lista1.ToArray();

            CB_Punt31.DisplayMember = "Value";
            CB_Punt31.ValueMember = "Key";
            CB_Punt31.DataSource = Lista1.ToArray();

            CB_Punt32.DisplayMember = "Value";
            CB_Punt32.ValueMember = "Key";
            CB_Punt32.DataSource = Lista1.ToArray();

            CB_Punt33.DisplayMember = "Value";
            CB_Punt33.ValueMember = "Key";
            CB_Punt33.DataSource = Lista1.ToArray();

            CB_Punt34.DisplayMember = "Value";
            CB_Punt34.ValueMember = "Key";
            CB_Punt34.DataSource = Lista1.ToArray();

            CB_Punt35.DisplayMember = "Value";
            CB_Punt35.ValueMember = "Key";
            CB_Punt35.DataSource = Lista1.ToArray();
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
            if (ValidarClave() == 1)
            {
                GuardarEva();
            }
        }

        private void CargarEva()
        {
            SacarPromedioTot();
            EVATRA.Clave = TB_CodProveedor.Text + TB_Mes.Text + TB_Año.Text;
            EVATRA.Proveedor = TB_CodProveedor.Text;
            EVATRA.Mes = int.Parse(TB_Mes.Text);
            EVATRA.Año = int.Parse(TB_Año.Text);
            EVATRA.Evaluador = TB_Evaluador.Text;

            if ((TB_Dom1.Text != "") && (IdCamion1 == 0))
            {
                dtCamion.Clear();
                //dtCamion = CABOL.Lista();
                dtCamion = CABOL.ListaProve(TB_CodProveedor.Text);

                foreach (DataRow Des in dtCamion.Rows)
                {

                    if (Des[2].ToString() == TB_Dom1.Text)
                    {
                       
                        IdCamion1 = int.Parse(Des[0].ToString());

                        


                    }


                }
            }
            EVATRA.Camion1 = IdCamion1;
            EVATRA.Camion2 = TB_Dom2.Text == "" ? 0 : IdCamion2;

            EVATRA.Camion3 = TB_Dom3.Text == "" ? 0 : IdCamion3;

            EVATRA.Chofer1 = TB_CodChof1.Text == "" ? 0 : int.Parse(TB_CodChof1.Text);

            EVATRA.Chofer2 = TB_CodChof2.Text == "" ? 0 : int.Parse(TB_CodChof2.Text);


            EVATRA.Chofer3 = TB_CodChof3.Text == "" ? 0 : int.Parse(TB_CodChof3.Text);

            if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
            {
                SacarPromedio11();

                EVATRA.Puntaje11 = double.Parse(CB_Punt11.Text);
                EVATRA.Puntaje12 = double.Parse(CB_Punt12.Text);
                EVATRA.Puntaje13 = double.Parse(CB_Punt13.Text);
                EVATRA.Puntaje14 = double.Parse(CB_Punt14.Text);
                EVATRA.Puntaje15 = double.Parse(CB_Punt15.Text);
                EVATRA.Promedio11 = Promedio11;
            }
            else
            {
                EVATRA.Puntaje11 = 0;
                EVATRA.Puntaje12 = 0;
                EVATRA.Puntaje13 = 0;
                EVATRA.Puntaje14 = 0;
                EVATRA.Puntaje15 = 0;
                EVATRA.Promedio11 = 0;
            }

            if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
            {
                SacarPromedio22();
                EVATRA.Puntaje21 = double.Parse(CB_Punt21.Text);
                EVATRA.Puntaje22 = double.Parse(CB_Punt22.Text);
                EVATRA.Puntaje23 = double.Parse(CB_Punt23.Text);
                EVATRA.Puntaje24 = double.Parse(CB_Punt24.Text);
                EVATRA.Puntaje25 = double.Parse(CB_Punt25.Text);
                EVATRA.Promedio22 = Promedio22;
            }
            else
            {
                EVATRA.Puntaje21 = 0;
                EVATRA.Puntaje22 = 0;
                EVATRA.Puntaje23 = 0;
                EVATRA.Puntaje24 = 0;
                EVATRA.Puntaje25 = 0;
                EVATRA.Promedio22 = 0;
            }

            if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
            {
                SacarPromedio33();
                EVATRA.Puntaje31 = double.Parse(CB_Punt31.Text);
                EVATRA.Puntaje32 = double.Parse(CB_Punt32.Text);
                EVATRA.Puntaje33 = double.Parse(CB_Punt33.Text);
                EVATRA.Puntaje34 = double.Parse(CB_Punt34.Text);
                EVATRA.Puntaje35 = double.Parse(CB_Punt35.Text);
                EVATRA.Promedio33 = Promedio33;
            }
            else
            {
                EVATRA.Puntaje31 = 0;
                EVATRA.Puntaje32 = 0;
                EVATRA.Puntaje33 = 0;
                EVATRA.Puntaje34 = 0;
                EVATRA.Puntaje35 = 0;
                EVATRA.Promedio33 = 0;
            }

            EVATRA.PromedioTot = PromedioTot;

            EVATRA.Promedio1 = Promedio1;
            EVATRA.Promedio2 = Promedio2;
            EVATRA.Promedio3 = Promedio3;
            EVATRA.Promedio4 = Promedio4;
            EVATRA.Promedio5 = Promedio5;

            
            
            

            EVATRA.Observ = TB_ObservEva.Text;

            EVATRA.DescChofer1 = TB_DescChof1.Text;
            EVATRA.DescChofer2 = TB_DescChof2.Text;
            EVATRA.DescChofer3 = TB_DescChof3.Text;

            EVATRA.Dominio1 = TB_DescDom1.Text;
            EVATRA.Dominio2 = TB_DescDom2.Text;
            EVATRA.Dominio3 = TB_DescDom3.Text;

            EVATRA.Fecha = TB_Fecha.Text;
            EVATRA.FechaVenc = TB_Venc.Text;
            EVATRA.Periodo = TB_Año.Text + TB_Mes.Text;
            EVATRA.Tipo = Tipo;

            if (Modificar == false)
            {
                EVATRABOL.Insertar(EVATRA);
                MessageBox.Show("La evaluación se agregó con éxito", "Agregar Evaluación",
                MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                EVATRA.Clave = EvaTrans.Clave;
                EVATRA.Tipo = 1;
                EVATRABOL.Modificar(EVATRA);
                MessageBox.Show("La evaluación se modifico con éxito", "Modificar Evaluación",
                MessageBoxButtons.OK, MessageBoxIcon.None);

            }

            Close();

        }

        #region Ayuda Chofer

       

        private void TB_CodChof1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_CodChof2_MouseClick(object sender, MouseEventArgs e)
        {
           
            
        }

        private void TB_CodChof3_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        #endregion

        #region Ocultar Paneles

        private void TB_Evaluador_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio11_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio22_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio33_MouseClick(object sender, MouseEventArgs e)
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

        private void TB_Promedio4_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Promedio5_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_PromedioTot_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_ObservEva_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        #endregion

        #region Ocultar TexBox de Calificación

        private void OcultarTextCalif()
        {
            CB_Punt11.Visible = false;
            CB_Punt12.Visible = false;
            CB_Punt13.Visible = false;
            CB_Punt14.Visible = false;
            CB_Punt15.Visible = false;

            CB_Punt21.Visible = false;
            CB_Punt22.Visible = false;
            CB_Punt23.Visible = false;
            CB_Punt24.Visible = false;
            CB_Punt25.Visible = false;

            CB_Punt31.Visible = false;
            CB_Punt32.Visible = false;
            CB_Punt33.Visible = false;
            CB_Punt34.Visible = false;
            CB_Punt35.Visible = false;

            TB_Promedio11.Visible = false;
            TB_Promedio22.Visible = false;
            TB_Promedio33.Visible = false;

            TB_Promedio1.Visible = false;
            TB_Promedio2.Visible = false;
            TB_Promedio3.Visible = false;
            TB_Promedio4.Visible = false;
            TB_Promedio5.Visible = false;
            
        }

        private void HabilitarCalif1()
        {
            CB_Punt11.Visible = true;
            CB_Punt12.Visible = true;
            CB_Punt13.Visible = true;
            CB_Punt14.Visible = true;
            CB_Punt15.Visible = true;

            TB_Promedio1.Visible = true;
            TB_Promedio2.Visible = true;
            TB_Promedio3.Visible = true;
            TB_Promedio4.Visible = true;
            TB_Promedio5.Visible = true;

            TB_Promedio11.Visible = true;
        }

        private void HabilitarCalif2()
        {
            CB_Punt21.Visible = true;
            CB_Punt22.Visible = true;
            CB_Punt23.Visible = true;
            CB_Punt24.Visible = true;
            CB_Punt25.Visible = true;

            TB_Promedio22.Visible = true;
        }

        private void HabilitarCalif3()
        {
            CB_Punt31.Visible = true;
            CB_Punt32.Visible = true;
            CB_Punt33.Visible = true;
            CB_Punt34.Visible = true;
            CB_Punt35.Visible = true;

            TB_Promedio33.Visible = true;
        }

        #endregion

        #region Sacar Promedio 1

        private void CB_Punt11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt12.Text != "") && (CB_Punt13.Text != "") && (CB_Punt14.Text != "") && (CB_Punt15.Text != ""))
            {
                SacarPromedio11();
                
                TB_Promedio11.Text = Promedio11.ToString();
                
            }
        }

       

        private void CB_Punt12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt11.Text != "") && (CB_Punt13.Text != "") && (CB_Punt14.Text != "") && (CB_Punt15.Text != ""))
            {
                SacarPromedio11();
                
                TB_Promedio11.Text = Promedio11.ToString();
                
            }
        }

        

        private void CB_Punt13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt11.Text != "") && (CB_Punt12.Text != "") && (CB_Punt14.Text != "") && (CB_Punt15.Text != ""))
            {
                SacarPromedio11();
                
                TB_Promedio11.Text = Promedio11.ToString();
                
            }
        }

        

        private void CB_Punt14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt11.Text != "") && (CB_Punt12.Text != "") && (CB_Punt13.Text != "") && (CB_Punt15.Text != ""))
            {
                SacarPromedio11();
                
                TB_Promedio11.Text = Promedio11.ToString();
                
            }
        }

       

        private void CB_Punt15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt11.Text != "") && (CB_Punt12.Text != "") && (CB_Punt13.Text != "") && (CB_Punt14.Text != ""))
            {
                SacarPromedio11();
                
                TB_Promedio11.Text = Promedio11.ToString();
                
            }
        }

        

        #endregion

        private void SacarPromedio11()
        {

            Promedio11 = ((double.Parse(CB_Punt11.Text)) * 0.1) + ((double.Parse(CB_Punt12.Text)) * 0.2) + ((double.Parse(CB_Punt13.Text)) * 0.2) + ((double.Parse(CB_Punt14.Text)) * 0.2) + ((double.Parse(CB_Punt15.Text)) * 0.3);
        }

        #region Sacar Promedio 2

        private void CB_Punt21_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt22.Text != "") && (CB_Punt23.Text != "") && (CB_Punt24.Text != "") && (CB_Punt25.Text != ""))
            {
                SacarPromedio22();
                
                TB_Promedio22.Text = Promedio22.ToString();
                
            }
        }

        

        private void CB_Punt22_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt21.Text != "") && (CB_Punt23.Text != "") && (CB_Punt24.Text != "") && (CB_Punt25.Text != ""))
            {
                SacarPromedio22();
                
                TB_Promedio22.Text = Promedio22.ToString();
                
            }
        }

        private void CB_Punt23_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt21.Text != "") && (CB_Punt22.Text != "") && (CB_Punt24.Text != "") && (CB_Punt25.Text != ""))
            {
                SacarPromedio22();
                
                TB_Promedio22.Text = Promedio22.ToString();
                
            }
        }

        private void CB_Punt24_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt21.Text != "") && (CB_Punt22.Text != "") && (CB_Punt23.Text != "") && (CB_Punt25.Text != ""))
            {
                SacarPromedio22();
                
                TB_Promedio22.Text = Promedio22.ToString();
                
            }
        }

        private void CB_Punt25_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt21.Text != "") && (CB_Punt22.Text != "") && (CB_Punt23.Text != "") && (CB_Punt24.Text != ""))
            {
                SacarPromedio22();
                
                TB_Promedio22.Text = Promedio22.ToString();
                
            }
        }

        #endregion

        private void SacarPromedio22()
        {
            Promedio22 = ((double.Parse(CB_Punt21.Text)) * 0.1) + ((double.Parse(CB_Punt22.Text)) * 0.2) + ((double.Parse(CB_Punt23.Text)) * 0.2) + ((double.Parse(CB_Punt24.Text)) * 0.2) + ((double.Parse(CB_Punt25.Text)) * 0.3);
        }


        #region Sacar Promedio 3

        private void CB_Punt31_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt32.Text != "") && (CB_Punt33.Text != "") && (CB_Punt34.Text != "") && (CB_Punt35.Text != ""))
            {
                SacarPromedio33();
                
                TB_Promedio33.Text = Promedio33.ToString();
                
            }
        }

        

        private void CB_Punt32_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt31.Text != "") && (CB_Punt33.Text != "") && (CB_Punt34.Text != "") && (CB_Punt35.Text != ""))
            {
                SacarPromedio33();
                
                TB_Promedio33.Text = Promedio33.ToString();
                
            }
        }

        private void CB_Punt33_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt31.Text != "") && (CB_Punt32.Text != "") && (CB_Punt34.Text != "") && (CB_Punt35.Text != ""))
            {
                SacarPromedio33();
                
                TB_Promedio33.Text = Promedio33.ToString();
                
            }
        }

        private void CB_Punt34_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt31.Text != "") && (CB_Punt32.Text != "") && (CB_Punt33.Text != "") && (CB_Punt35.Text != ""))
            {
                SacarPromedio33();
                
                TB_Promedio33.Text = Promedio33.ToString();
                
            }
        }

        private void CB_Punt35_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CB_Punt31.Text != "") && (CB_Punt32.Text != "") && (CB_Punt33.Text != "") && (CB_Punt34.Text != ""))
            {
                SacarPromedio33();
                
                TB_Promedio33.Text = Promedio33.ToString();
                
            }
        }

        #endregion

        private void SacarPromedio33()
        {
            Promedio33 = ((double.Parse(CB_Punt31.Text)) * 0.1) + ((double.Parse(CB_Punt32.Text)) * 0.2) + ((double.Parse(CB_Punt33.Text)) * 0.2) + ((double.Parse(CB_Punt34.Text)) * 0.2) + ((double.Parse(CB_Punt35.Text)) * 0.3);
        }



        private void BT_CalificProve_Click(object sender, EventArgs e)
        {
            SacarPromedioTot();
            
        }

        private void SacarPromedioTot()
        {
            try
            {
                 if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
                {
                    if ((CB_Punt11.Text == "") || (CB_Punt12.Text == "") || (CB_Punt13.Text == "") || (CB_Punt14.Text == "") || (CB_Punt15.Text == "")) throw new Exception("Se debe calificar todos los parametros del dominio 1");
                }

                if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
                {
                    if ((CB_Punt21.Text == "") || (CB_Punt22.Text == "") || (CB_Punt23.Text == "") || (CB_Punt24.Text == "") || (CB_Punt25.Text == "")) throw new Exception("Se debe calificar todos los parametros del dominio 2");
                }

                if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
                {
                    if ((CB_Punt31.Text == "") || (CB_Punt32.Text == "") || (CB_Punt33.Text == "") || (CB_Punt34.Text == "") || (CB_Punt35.Text == "")) throw new Exception("Se debe calificar todos los parametros del dominio 3");
                }

                SacarPromedio1();
                TB_Promedio1.Text = Promedio1.ToString();
                SacarPromedio2();
                TB_Promedio2.Text = Promedio2.ToString();
                SacarPromedio3();
                TB_Promedio3.Text = Promedio3.ToString();
                SacarPromedio4();
                TB_Promedio4.Text = Promedio4.ToString();
                SacarPromedio5();
                TB_Promedio5.Text = Promedio5.ToString();
                PromedioTot = Promedio1 * 0.1 + Promedio2 * 0.2 + Promedio3 * 0.2 + Promedio4 * 0.2 + Promedio5 * 0.3;
                TB_PromedioTot.Text = PromedioTot.ToString();
            }
            catch (Exception err)
            {
                
                 MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SacarPromedio1()
        {
            
                int Suma = 0;
                int Cantidad = 0;

                if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
                {

                    Cantidad = 1;
                    Suma = int.Parse(CB_Punt11.Text);
                }

                if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
                {
                    if (CB_Punt21.Text == "")  throw new Exception("Se debe calificar el primer parametro del dominio 2");

                    Cantidad = 2;
                    Suma = Suma + int.Parse(CB_Punt21.Text);
                }

                if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
                {
                    
                        if (CB_Punt31.Text == "") throw new Exception("Se debe calificar el primer parametro del dominio 3");

                        Cantidad = 3;
                        Suma = Suma + int.Parse(CB_Punt31.Text);
                    
                        
                         
                        
                    
                  
                }

                Promedio1 = (double) Suma / Cantidad;
            
        }

        private void SacarPromedio2()
        {
            
                int Suma = 0;
                int Cantidad = 0;

                if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
                {

                    Cantidad = 1;
                    Suma = int.Parse(CB_Punt12.Text);
                }

                if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
                {

                    Cantidad = 2;
                    Suma = Suma + int.Parse(CB_Punt22.Text);
                }

                if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
                {

                    Cantidad = 3;
                    Suma = Suma + int.Parse(CB_Punt32.Text);
                }

                Promedio2 = Suma / Cantidad;
            
            
            
        }

        private void SacarPromedio3()
        {
           
                int Suma = 0;
                int Cantidad = 0;

                if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
                {

                        Cantidad = 1;
                        Suma = int.Parse(CB_Punt13.Text);
                    
                    
                }

                if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
                {

                    Cantidad = 2;
                    Suma = Suma + int.Parse(CB_Punt23.Text);
                }

                if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
                {

                    Cantidad = 3;
                    Suma = Suma + int.Parse(CB_Punt33.Text);
                }

                Promedio3 = Suma / Cantidad;
           
            
        }


        private void SacarPromedio4()
        {
            int Suma = 0;
            int Cantidad = 0;

            if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
            {

                Cantidad = 1;
                Suma = int.Parse(CB_Punt14.Text);
            }

            if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
            {

                Cantidad = 2;
                Suma = Suma + int.Parse(CB_Punt24.Text);
            }

            if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
            {

                Cantidad = 3;
                Suma = Suma + int.Parse(CB_Punt34.Text);
            }

            Promedio4 = Suma / Cantidad;
        }

        private void SacarPromedio5()
        {
            int Suma = 0;
            int Cantidad = 0;

            if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
            {

                Cantidad = 1;
                Suma = int.Parse(CB_Punt15.Text);
            }

            if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
            {

                Cantidad = 2;
                Suma = Suma + int.Parse(CB_Punt25.Text);
            }

            if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
            {

                Cantidad = 3;
                Suma = Suma + int.Parse(CB_Punt35.Text);
            }

            Promedio5 = Suma / Cantidad;
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            //SOLO SE PERMITE LIMPIAR A PANTALLA CUANDO NO SE MODIFICA
            if (Modificar == false)
            {
                
                TB_CodProveedor.Text = "";
                TB_NombProveedor.Text = "";
                TB_Estado.Visible = false;
                TB_Mes.Text = "";
                TB_Año.Text = "";
                TB_Evaluador.Text = "";
                TB_Fecha.Text = "";
                TB_Venc.Text = "";

                TB_CodChof1.Text = "";
                TB_DescChof1.Text = "";
                TB_CodChof2.Text = "";
                TB_DescChof2.Text = "";
                TB_CodChof3.Text = "";
                TB_DescChof3.Text = "";

                TB_Dom1.Text = "";
                TB_DescDom1.Text = "";
                TB_Dom2.Text = "";
                TB_DescDom2.Text = "";
                TB_Dom3.Text = "";
                TB_DescDom3.Text = "";

                CB_Punt11.Text = "";
                CB_Punt11.Visible = false;
                CB_Punt12.Text = "";
                CB_Punt12.Visible = false;
                CB_Punt13.Text = "";
                CB_Punt13.Visible = false;
                CB_Punt14.Text = "";
                CB_Punt14.Visible = false;
                CB_Punt15.Text = "";
                CB_Punt15.Visible = false;

                CB_Punt21.Text = "";
                CB_Punt21.Visible = false;
                CB_Punt22.Text = "";
                CB_Punt22.Visible = false;
                CB_Punt23.Text = "";
                CB_Punt23.Visible = false;
                CB_Punt24.Text = "";
                CB_Punt24.Visible = false;
                CB_Punt25.Text = "";
                CB_Punt25.Visible = false;

                CB_Punt31.Text = "";
                CB_Punt31.Visible = false;
                CB_Punt32.Text = "";
                CB_Punt32.Visible = false;
                CB_Punt33.Text = "";
                CB_Punt33.Visible = false;
                CB_Punt34.Text = "";
                CB_Punt34.Visible = false;
                CB_Punt35.Text = "";
                CB_Punt35.Visible = false;

                TB_Promedio1.Text = "";
                TB_Promedio2.Text = "";
                TB_Promedio3.Text = "";
                TB_Promedio4.Text = "";
                TB_Promedio5.Text = "";

                TB_Promedio11.Text = "";
                TB_Promedio22.Text = "";
                TB_Promedio33.Text = "";
                TB_PromedioTot.Text = "";

                TB_ObservEva.Text = "";
            }
        }

        private void TB_NombProveedor_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void TB_NombProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataRow Des in dtProveedores.Rows)
                {
                    
                        if (Des[1].ToString() == TB_NombProveedor.Text)
                        {
                            TB_CodProveedor.Text = Des[0].ToString();
                            TB_NombProveedor.Text = Des[1].ToString();
                            TB_NombProveedor.Focus();
                            Cargado = false;
                            CargadoD = false;
                            CargarChof1();
                            CargarDom1();
                            TB_Mes.Focus();
                        }
                    
                    
                }
            }
            
        }


        private void TB_NombProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TB_NombProveedor.Text != "")
            {
                foreach (DataRow Des in dtProveedores.Rows)
                {

                    if (Des[1].ToString() == TB_NombProveedor.Text)
                    {
                        TB_CodProveedor.Text = Des[0].ToString();
                        TB_NombProveedor.Text = Des[1].ToString();
                        TB_NombProveedor.Focus();
                        Cargado = false;
                        CargadoD = false;
                        CargarChof1();
                        CargarDom1();
                        TB_Mes.Focus();
                        BuscarEstadoProveevor();
                    }


                }
            }
            
        }


        private void TB_CodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BuscarEstadoProveevor()
        {
            P = PBOL.Find(TB_CodProveedor.Text);

            if (P.Estado == 2)
            {
                TB_Estado.Visible = true;
            }
        }

        

        private void CargarChoferes()
        {

            CargarChof1();
            CargarChof2();
            CargarChof3();
        }

        

        

        private void CargarChof1()
        {
            if (TB_CodProveedor.Text != "")
            {
                dtChoferes.Clear();
                //dtCamion = CABOL.Lista();
                dtChoferes = CBOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtChoferes.NewRow();
                dtChoferes.Rows.InsertAt(fila, 0);
                //Cargado = false;
                TB_DescChof1.DataSource = dtChoferes;
                Cargado = false;
                TB_DescChof1.DisplayMember = "Descripcion";
                //Cargado = false;
                TB_DescChof1.ValueMember = "Codigo";
                TB_DescChof1.Text = "";

                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtChoferes.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Descripcion"]));

                }

                TB_DescChof1.AutoCompleteCustomSource = stringCodArti;
                TB_DescChof1.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_DescChof1.AutoCompleteSource = AutoCompleteSource.CustomSource;


                TB_Dom1.Focus();
            }
            

        }
        private void CargarChof2()
        {
            if (TB_CodChof1.Text != "")
            {
                dtChoferes2.Clear();
                //dtCamion = CABOL.Lista();
                dtChoferes2 = CBOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtChoferes2.NewRow();
                dtChoferes2.Rows.InsertAt(fila, 0);


                if (TB_CodChof1.Text != "")
                {
                    foreach (DataRow filan in dtChoferes2.Rows)
                    {
                        if (filan[0].ToString() == TB_CodChof1.Text)
                        {
                            filan[1] = "";
                            filan[0] = 0;
                        }


                    }
                }
                TB_DescChof2.DataSource = dtChoferes2;
                TB_DescChof2.DisplayMember = "Descripcion";
                TB_DescChof2.ValueMember = "Codigo";
                TB_DescChof2.Text = "";
                TB_CodChof2.Text = "";

                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtChoferes2.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Descripcion"]));

                }

                TB_DescChof2.AutoCompleteCustomSource = stringCodArti;
                TB_DescChof2.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_DescChof2.AutoCompleteSource = AutoCompleteSource.CustomSource;


                TB_Dom2.Focus();
            }
        }
        private void CargarChof3()
        {
            if (TB_CodChof2.Text != "")
            {
                dtChoferes3.Clear();
                //dtCamion = CABOL.Lista();
                dtChoferes3 = CBOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtChoferes3.NewRow();
                dtChoferes3.Rows.InsertAt(fila, 0);


                if (TB_CodChof1.Text != "")
                {
                    foreach (DataRow filan in dtChoferes3.Rows)
                    {
                        if (filan[0].ToString() == TB_CodChof1.Text)
                        {
                            filan[1] = "";
                            filan[0] = 0;
                        }
                        if (filan[0].ToString() == TB_CodChof2.Text)
                        {
                            filan[1] = "";
                            filan[0] = 0;
                        }

                    }
                }
                TB_DescChof3.DataSource = dtChoferes3;
                TB_DescChof3.DisplayMember = "Descripcion";
                TB_DescChof3.ValueMember = "Codigo";
                TB_DescChof3.Text = "";

                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtChoferes3.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Descripcion"]));

                }

                TB_DescChof3.AutoCompleteCustomSource = stringCodArti;
                TB_DescChof3.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_DescChof3.AutoCompleteSource = AutoCompleteSource.CustomSource;


                TB_Dom3.Focus();
            }
        }
        private void CargarDominios()
        {
            CargarDom1();
            CargarDom2();
            CargarDom3();
        }

        private void CargarDom1()
        {
            if (TB_CodProveedor.Text != "")
            {
                dtCamion.Clear();
                //dtCamion = CABOL.Lista();
                dtCamion = CABOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtCamion.NewRow();
                dtCamion.Rows.InsertAt(fila, 0);

               
                TB_Dom1.DataSource = dtCamion;
                CargadoD = false;
                TB_Dom1.DisplayMember = "Patente";

                TB_Dom1.ValueMember = "Codigo";
                TB_Dom1.Text = "";

                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtCamion.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Patente"]));

                }

                TB_Dom1.AutoCompleteCustomSource = stringCodArti;
                TB_Dom1.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_Dom1.AutoCompleteSource = AutoCompleteSource.CustomSource;


                CB_Punt11.Focus();
            }
            
        }

        private void CargarDom2()
        {
            if (TB_Dom1.Text != "")
            {
                dtCamion2.Clear();
                //dtCamion = CABOL.Lista();
                dtCamion2 = CABOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtCamion2.NewRow();
                dtCamion2.Rows.InsertAt(fila, 0);

                if (TB_Dom1.Text != "")
                {
                    foreach (DataRow filan in dtCamion2.Rows)
                    {
                        if (filan[2].ToString() == TB_Dom1.Text) filan[2] = "";



                    }
                }

                TB_Dom2.DataSource = dtCamion2;
                TB_Dom2.DisplayMember = "Patente";
                TB_Dom2.ValueMember = "Codigo";
                TB_Dom2.Text = "";
                TB_DescDom2.Text = "";

                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtCamion2.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Patente"]));

                }

                TB_Dom2.AutoCompleteCustomSource = stringCodArti;
                TB_Dom2.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_Dom2.AutoCompleteSource = AutoCompleteSource.CustomSource;


                CB_Punt21.Focus();
            }
        }

        private void CargarDom3()
        {
            if (TB_Dom2.Text != "")
            {
                dtCamion3.Clear();
                //dtCamion = CABOL.Lista();
                dtCamion3 = CABOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtCamion3.NewRow();
                dtCamion3.Rows.InsertAt(fila, 0);

                if (TB_Dom1.Text != "")
                {
                    foreach (DataRow filan in dtCamion3.Rows)
                    {
                        if (filan[2].ToString() == TB_Dom1.Text) filan[2] = "";
                        if (filan[2].ToString() == TB_Dom2.Text) filan[2] = "";


                    }
                }

                TB_Dom3.DataSource = dtCamion3;
                TB_Dom3.DisplayMember = "Patente";
                TB_Dom3.ValueMember = "Codigo";
                TB_Dom3.Text = "";
                TB_DescDom3.Text = "";
                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtCamion3.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Patente"]));

                }

                TB_Dom3.AutoCompleteCustomSource = stringCodArti;
                TB_Dom3.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_Dom3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }


        private void LlenarListaChoferes()
        {
            dtChoferes.Clear();
            //dtCamion = CABOL.Lista();
            dtChoferes = CBOL.ListaProve(TB_CodProveedor.Text);
            
            if (TB_CodChof2.Text != "")
            {
                foreach (DataRow fila in dtChoferes.Rows)
                {
                    if (fila[0].ToString() == TB_CodChof2.Text) dtChoferes.Rows.Remove(fila);



                }
            }

            if (TB_CodChof3.Text != "")
            {
                foreach (DataRow fila in dtChoferes.Rows)
                {
                    if (fila[0].ToString() == TB_CodChof3.Text) dtChoferes.Rows.Remove(fila);



                }
            }
        }

        private void LlenarListaDominio()
        {
            dtCamion.Clear();
            //dtCamion = CABOL.Lista();
            dtCamion = CABOL.ListaProve(TB_CodProveedor.Text);
            if (TB_Dom1.Text != "")
            {
                foreach (DataRow fila in dtCamion.Rows)
                {
                    if (fila[0].ToString() == TB_Dom1.Text) dtCamion.Rows.Remove(fila);



                }
            }
            if (TB_Dom2.Text != "")
            {
                foreach (DataRow fila in dtCamion.Rows)
                {
                    if (fila[0].ToString() == TB_Dom2.Text) dtCamion.Rows.Remove(fila);



                }
            }

            if (TB_Dom3.Text != "")
            {
                foreach (DataRow fila in dtCamion.Rows)
                {
                    if (fila[0].ToString() == TB_Dom3.Text) dtCamion.Rows.Remove(fila);



                }
            }
        }

        private void TB_DescChof1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TB_DescChof1.Text != "System.Data.DataRowView") && (TB_DescChof1.Text != ""))
            {
                foreach (DataRow Des in dtChoferes.Rows)
                {
                    
                        if (Des[1].ToString() == TB_DescChof1.Text)
                        {
                            TB_CodChof1.Text = Des[0].ToString();
                            TB_DescChof1.Text = Des[1].ToString();

                            CargarChof2();
                            TB_Dom1.Focus();

                        }
                    }

                

                
            }
            
            
        }

        private void TB_DescChof1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataRow Des in dtChoferes.Rows)
                {
                    if (Des[1].ToString() == TB_DescChof1.Text)
                    {
                        TB_CodChof1.Text = Des[0].ToString();
                        TB_DescChof1.Text = Des[1].ToString();
                        TB_Dom1.Focus();
                        CargarChof2();
                        

                    }
                }
            }
        }

        private void TB_Dom1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((TB_Dom1.Text != "System.Data.DataRowView") && (TB_Dom1.Text != ""))
            {
                foreach (DataRow Des in dtCamion.Rows)
                {
                    
                        if (Des[2].ToString() == TB_Dom1.Text)
                        {
                            TB_DescDom1.Text = Des[1].ToString();
                            IdCamion1 = int.Parse(Des[0].ToString());

                            CargarDom2();


                        }
                    

                }
            }
            
            if ((TB_Dom1.Text != "") && CargadoD)
            {
                HabilitarCalif1();
            }
            CargadoD = true;
            CB_Punt11.Focus();


            
        }

        private void TB_Dom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TB_Dom2.Text != "System.Data.DataRowView") && (TB_Dom2.Text != ""))
            {
                foreach (DataRow Des in dtCamion2.Rows)
                {
                    if (CargadoD)
                    {
                        if (Des[2].ToString() == TB_Dom2.Text)
                        {
                            TB_DescDom2.Text = Des[1].ToString();
                            IdCamion2 = int.Parse(Des[0].ToString());

                            CargarDom3();


                        }
                    }

                }
            }
            
            if ((TB_Dom2.Text != "") && CargadoD)
            {
                HabilitarCalif2();
            }
            CargadoD = true;
            CB_Punt21.Focus();
        }


        private void TB_Dom3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TB_Dom3.Text != "System.Data.DataRowView") && (TB_Dom3.Text != ""))
            {
                foreach (DataRow Des in dtCamion3.Rows)
                {
                    if (CargadoD)
                    {
                        if (Des[2].ToString() == TB_Dom3.Text)
                        {
                            TB_DescDom3.Text = Des[1].ToString();
                            IdCamion3 = int.Parse(Des[0].ToString());

                            //CargarDom3();


                        }
                    }

                }
            }
            if (TB_Dom3.Text != "System.Data.DataRowView")
            {
                if ((TB_Dom3.Text != "") && CargadoD)
                {
                    HabilitarCalif3();
                }
            }
            
            CargadoD = true;
            CB_Punt31.Focus();
        }

        private void TB_Dom1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataRow Des in dtCamion.Rows)
                {
                    if (CargadoD)
                    {
                        if (Des[2].ToString() == TB_Dom1.Text)
                        {
                            TB_DescDom1.Text = Des[1].ToString();


                            CargarDom2();


                        }
                    }
                        
                
                    
                }
                CargadoD = true;
            }
        }

        private void TB_DescChof2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TB_DescChof2.Text != "System.Data.DataRowView") && (TB_DescChof2.Text != ""))
            {
                foreach (DataRow Des in dtChoferes2.Rows)
                {
                    if (Cargado)
                    {
                        if (Des[1].ToString() == TB_DescChof2.Text)
                        {
                            TB_CodChof2.Text = Des[0].ToString();
                            TB_DescChof2.Text = Des[1].ToString();

                            CargarChof3();
                            TB_Dom2.Focus();

                        }
                    }

                }
            }
            
            Cargado = true;
        }


        private void TB_DescChof3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TB_DescChof3.Text != "System.Data.DataRowView") && (TB_DescChof3.Text != ""))
            {
                foreach (DataRow Des in dtChoferes3.Rows)
                {
                    if (Cargado)
                    {
                        if (Des[1].ToString() == TB_DescChof3.Text)
                        {
                            TB_CodChof3.Text = Des[0].ToString();
                            TB_DescChof3.Text = Des[1].ToString();

                            
                            TB_Dom3.Focus();

                        }
                    }

                }
            }

            Cargado = true;
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




        #region Tab con Enter

        private void TB_Mes_KeyDown(object sender, KeyEventArgs e)
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


                TB_Evaluador.Focus();
            }
        }

        private void TB_Evaluador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Venc.Focus();
            }
        }

        private void TB_Venc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_DescChof1.Focus();
            }
        }
        #endregion

        private void BTEvaluacionAnt_Click(object sender, EventArgs e)
        {
                    }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TB_PromedioTot.Text != "")
            {
                IhabilitarProveedor();

            }
            else
            {
                MessageBox.Show("No se puede inhabilitar al proveedor sino fue evaluado", "Inhabilitar Proveedor",
               MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void IhabilitarProveedor()
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

        private void GuardarEva()
        {
            try
            {
                if (TB_CodProveedor.Text == "") throw new Exception("Se debe ingresar el proveedor que desea evaluar");

                if (TB_Mes.Text == "") throw new Exception("Se debe ingresar el mes de la evaluación");

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el año de la evaluación");

                if (TB_Evaluador.Text == "") throw new Exception("Se debe ingresar el evaluador de la evaluación");

                if (TB_Fecha.Text == "") throw new Exception("Se debe ingresar la fecha de la evaluación");

                if (TB_Venc.Text == "") throw new Exception("Se debe ingresar el vencimiento de la evaluación");

                if (TB_CodChof1.Text == "") throw new Exception("Se debe ingresar el Chofer de la evaluación");

                if (TB_Dom1.Text == "") throw new Exception("Se debe ingresar el Dominio de la evaluación");

                if ((TB_Dom1.Text != "") && (TB_CodChof1.Text != ""))
                {
                    if ((CB_Punt11.Text == "") || (CB_Punt12.Text == "") || (CB_Punt13.Text == "") || (CB_Punt14.Text == "") || (CB_Punt15.Text == "")) throw new Exception("Se debe calificar todos los parametros del dominio 1");
                }

                if ((TB_Dom2.Text != "") && (TB_CodChof2.Text != ""))
                {
                    if ((CB_Punt21.Text == "") || (CB_Punt22.Text == "") || (CB_Punt23.Text == "") || (CB_Punt24.Text == "") || (CB_Punt25.Text == "")) throw new Exception("Se debe calificar todos los parametros del dominio 2");
                }

                if ((TB_Dom3.Text != "") && (TB_CodChof3.Text != ""))
                {
                    if ((CB_Punt31.Text == "") || (CB_Punt32.Text == "") || (CB_Punt33.Text == "") || (CB_Punt34.Text == "") || (CB_Punt35.Text == "")) throw new Exception("Se debe calificar todos los parametros del dominio 3");
                }
                CargarEva();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IngEvalTransp_Shown(object sender, EventArgs e)
        {
            if (TB_Mes.Text.Trim() != "") TB_Mes.Focus();
        }
    }


}
