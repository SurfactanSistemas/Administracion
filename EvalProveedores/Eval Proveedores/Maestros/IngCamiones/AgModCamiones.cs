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

namespace Eval_Proveedores.IngCamiones
{
    public partial class AgModCamiones : Form
    {
        Camion Ca = new Camion();
        Chofer C = new Chofer();
        Proveedor P = new Proveedor();
        CamionBOL CABOL = new CamionBOL();
        ChoferBOL CBOL = new ChoferBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtProveedores = new DataTable();
        DataTable dtChoferes = new DataTable();
        bool Modificar = false;
        private string Codigo;
        private string Desc;
        private string Patent;
        private string NomProve;
        private string NomChof;
        private string Estado;
        private string CodEmp;
        private string Aplica;
        private string CodChof;
        private string CodProveedor;
        private string FechaVenc1;
        private string FechaVenc2;
        private string FechaVenc3;
        private string FechaVenc4;
        private string FechaVenc5;
        private string OrdFecVenc1;
        private string OrdFecVenc2;
        private string OrdFecVenc3;
        private string OrdFecVenc4;
        private string OrdFecVenc5;
        private string FechaEnt1;
        private string FechaEnt2;
        private string FechaEnt3;
        private string FechaEnt4;
        private string FechaEnt5;
        private string OrdFecEnt1;
        private string OrdFecEnt2;
        private string OrdFecEnt3;
        private string OrdFecEnt4;
        private string OrdFecEnt5;
        private string Coment1;
        private string Coment2;
        private string Coment3;
        private string Coment4;
        private string Coment5;
        private string Titulo;
        


        public AgModCamiones()
        {
            InitializeComponent();
        }

        public AgModCamiones(string Codigo, string Desc, string Patent, string NomProve, string NomChof, string Estado, string CodEmp, string Aplica, string CodChof, string CodProveedor, string FechaVenc1, string FechaVenc2, string FechaVenc3, string FechaVenc4, string FechaVenc5, string OrdFecVenc1, string OrdFecVenc2, string OrdFecVenc3, string OrdFecVenc4, string OrdFecVenc5, string FechaEnt1, string FechaEnt2, string FechaEnt3, string FechaEnt4, string FechaEnt5, string OrdFecEnt1, string OrdFecEnt2, string OrdFecEnt3, string OrdFecEnt4, string OrdFecEnt5, string Coment1, string Coment2, string Coment3, string Coment4, string Coment5, string Titulo)
        {
            // TODO: Complete member initialization
            this.Codigo = Codigo;
            this.Desc = Desc;
            this.Patent = Patent;
            this.NomProve = NomProve;
            this.NomChof = NomChof;
            this.Estado = Estado;
            this.CodEmp = CodEmp;
            this.Aplica = Aplica;
            this.CodChof = CodChof;
            this.CodProveedor = CodProveedor;
            this.FechaVenc1 = FechaVenc1;
            this.FechaVenc2 = FechaVenc2;
            this.FechaVenc3 = FechaVenc3;
            this.FechaVenc4 = FechaVenc4;
            this.FechaVenc5 = FechaVenc5;
            this.OrdFecVenc1 = OrdFecVenc1;
            this.OrdFecVenc2 = OrdFecVenc2;
            this.OrdFecVenc3 = OrdFecVenc3;
            this.OrdFecVenc4 = OrdFecVenc4;
            this.OrdFecVenc5 = OrdFecVenc5;
            this.FechaEnt1 = FechaEnt1;
            this.FechaEnt2 = FechaEnt2;
            this.FechaEnt3 = FechaEnt3;
            this.FechaEnt4 = FechaEnt4;
            this.FechaEnt5 = FechaEnt5;
            this.OrdFecEnt1 = OrdFecEnt1;
            this.OrdFecEnt2 = OrdFecEnt2;
            this.OrdFecEnt3 = OrdFecEnt3;
            this.OrdFecEnt4 = OrdFecEnt4;
            this.OrdFecEnt5 = OrdFecEnt5;
            this.Coment1 = Coment1;
            this.Coment2 = Coment2;
            this.Coment3 = Coment3;
            this.Coment4 = Coment4;
            this.Coment5 = Coment5;
            this.Titulo = Titulo;
            InitializeComponent();
        }

        

        private void AgModCamiones_Load(object sender, EventArgs e)
        {
            if (Codigo != null)
            {
                LBCamion.Text = "MODIFICAR CAMION";
                TB_CodCamion.Text = Codigo;
                if (int.Parse(Estado) == 0)
                {
                    CB_Estado.Text = "";
                }
                else
                {
                    CB_Estado.Text = "Inhabilitado";
                }
                TB_Descripcion.Text = Desc;
                TB_Patente.Text = Patent;
                TB_CodProveedor.Text = CodProveedor;
                TB_NombProveedor.Text = NomProve;
                TB_CodChofer.Text = CodChof ;
                TB_NombChofer.Text = NomChof;

                TB_VencRuta.Text = FechaVenc1;
                TB_EntRuta.Text = FechaEnt1;
                TB_ObservacRuta.Text = Coment1;

                TB_VencRTO.Text = FechaVenc2;
                TB_EntRTO.Text = FechaEnt2;
                TB_ObservRTO.Text = Coment2;

                TB_VencHabDominio.Text = FechaVenc3;
                TB_EntHabDominio.Text = FechaEnt3;
                TB_ObservHabDominio.Text = Coment3;

                TB_VencSeguro.Text = FechaVenc4;
                TB_EntSeguro.Text = FechaEnt4;
                TB_ObservSeguro.Text = Coment4;

                if (int.Parse(Aplica) == 1) CB_CargasPeligrosas.Checked = true;
                TB_VencCargasPelig.Text = FechaVenc5;
                TB_EntCargasPelig.Text = FechaEnt5;
                TB_ObservCargasPelig.Text = Coment5;

                _CargarDatosRENPRE(Codigo);

                Modificar = true;


            }
            else
            {
                LBCamion.Text = "INGRESO DE CAMION";
                int Ultimo = CABOL.Ultimo();
                TB_CodCamion.Text = (Ultimo + 1).ToString();
                CargarProveedores();
                TB_NombChofer.Text = "";
            }

            
        }

        private void _CargarDatosRENPRE(string  WCodigo)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT isnull(VencimientoRENPRE, '') VencimientoRENPRE, isnull(FechaEntregaRENPRE, '') FechaEntregaRENPRE, isnull(ObsRENPRE, '') ObsRENPRE FROM Camion WHERE Codigo = '" + WCodigo + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            txtFechaEntregaRENPRE.Text = dr["FechaEntregaRENPRE"].ToString();
                            txtVencimientoRENPRE.Text = dr["VencimientoRENPRE"].ToString();
                            txtObsRENPRE.Text = dr["ObsRENPRE"].ToString();
                        }
                    }
                }

            }

        
        }


        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Descripcion.Text == "") throw new Exception("Se debe ingresar la descripcion del camión");

                if (TB_Patente.Text == "") throw new Exception("Se debe ingresar la patente del camión");

                if (TB_CodProveedor.Text == "") throw new Exception("Se debe ingresar el código del  proveedor");

                if (TB_CodChofer.Text == "") throw new Exception("Se debe ingresar el código del  chofer");

                if (TB_VencRuta.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la ruta");

                if (TB_VencRTO.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la revisión técnica obligatoria");

                if (TB_VencHabDominio.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la habilitación de dominio");

                if (TB_VencSeguro.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento del seguro");


                if (TB_EntRuta.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la ruta");

                if (TB_EntRTO.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la revisión técnica obligatoria");

                if (TB_EntHabDominio.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la habilitación de dominio");

                if (TB_EntSeguro.Text == "") throw new Exception("Se debe ingresar la fecha de entrega del seguro");


                if (CB_CargasPeligrosas.Checked == true)
                {
                    if (TB_VencCargasPelig.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento del certificado de transporte de cargas peligrosas");


                    if (TB_EntCargasPelig.Text == "") throw new Exception("Se debe ingresar la fecha de entrega del certificado de cargas peligrosas");

                }

                Ca.Aplica = 0;

                Ca.Descripcion = TB_Descripcion.Text;

                //Si Habilitado es numero 0. Preguntar si es asi??????????????

                if (CB_Estado.Text == "")
                { 
                    Ca.Estado = 0; 
                }
                else
                {
                    Ca.Estado = -1;
                }

                Ca.Patente = TB_Patente.Text;
                Ca.Proveedor = TB_CodProveedor.Text;
                Ca.Chofer = int.Parse(TB_CodChofer.Text);


                Ca.FechaVto1 = TB_VencRuta.Text;
                Ca.OrdFechaVto1 = TB_VencRuta.Text.Substring(6, 4) + TB_VencRuta.Text.Substring(3, 2) + TB_VencRuta.Text.Substring(0, 2);
                Ca.FechaEnt1 = TB_EntRuta.Text;
                Ca.OrdFechaEnt1 = TB_EntRuta.Text.Substring(6, 4) + TB_EntRuta.Text.Substring(3, 2) + TB_EntRuta.Text.Substring(0, 2);
                Ca.Comentario1 = TB_ObservacRuta.Text;


                Ca.FechaVto2 = TB_VencRTO.Text;
                Ca.OrdFechaVto2 = TB_VencRTO.Text.Substring(6, 4) + TB_VencRTO.Text.Substring(3, 2) + TB_VencRTO.Text.Substring(0, 2);
                Ca.FechaEnt2 = TB_EntRTO.Text;
                Ca.OrdFechaEnt2 = TB_EntRTO.Text.Substring(6, 4) + TB_EntRTO.Text.Substring(3, 2) + TB_EntRTO.Text.Substring(0, 2);
                Ca.Comentario2 = TB_ObservRTO.Text;


                Ca.FechaVto3 = TB_VencHabDominio.Text;
                Ca.OrdFechaVto3 = TB_VencHabDominio.Text.Substring(6, 4) + TB_VencHabDominio.Text.Substring(3, 2) + TB_VencHabDominio.Text.Substring(0, 2);
                Ca.FechaEnt3 = TB_EntHabDominio.Text;
                Ca.OrdFechaEnt3 = TB_EntHabDominio.Text.Substring(6, 4) + TB_EntHabDominio.Text.Substring(3, 2) + TB_EntHabDominio.Text.Substring(0, 2);
                Ca.Comentario3 = TB_ObservHabDominio.Text;

                Ca.FechaVto4 = TB_VencSeguro.Text;
                Ca.OrdFechaVto4 = TB_VencSeguro.Text.Substring(6, 4) + TB_VencSeguro.Text.Substring(3, 2) + TB_VencSeguro.Text.Substring(0, 2);
                Ca.FechaEnt4 = TB_EntSeguro.Text;
                Ca.OrdFechaEnt4 = TB_EntSeguro.Text.Substring(6, 4) + TB_EntSeguro.Text.Substring(3, 2) + TB_EntSeguro.Text.Substring(0, 2);
                Ca.Comentario4 = TB_ObservSeguro.Text;

                if (CB_CargasPeligrosas.Checked == true)
                {
                    Ca.Aplica = 1;
                    Ca.FechaVto5 = TB_VencCargasPelig.Text;
                    Ca.OrdFechaVto5 = TB_VencCargasPelig.Text.Substring(6, 4) + TB_VencCargasPelig.Text.Substring(3, 2) + TB_VencCargasPelig.Text.Substring(0, 2);
                    Ca.FechaEnt5 = TB_EntCargasPelig.Text;
                    Ca.OrdFechaEnt5 = TB_EntCargasPelig.Text.Substring(6, 4) + TB_EntCargasPelig.Text.Substring(3, 2) + TB_EntCargasPelig.Text.Substring(0, 2);
                    Ca.Comentario5 = TB_ObservCargasPelig.Text;
                }
                else
                {
                    Ca.FechaVto5 = TB_VencCargasPelig.Text;
                    Ca.OrdFechaVto5 = "";
                    Ca.FechaEnt5 = TB_EntCargasPelig.Text;
                    Ca.OrdFechaEnt5 = "";
                    Ca.Comentario5 = TB_ObservCargasPelig.Text; 
                }

                Ca.Titulo = "";

                Ca.CodigoEmpresa = 1;

                if (Modificar == false)
                {
                    CABOL.Insertar(Ca);
                    MessageBox.Show("El Camión se agregó con éxito", "Agregar Camión",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    Ca.Codigo = int.Parse(TB_CodCamion.Text);
                    CABOL.Modificar(Ca);
                    MessageBox.Show("El Camión se modifico con éxito", "Modificar Camión",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                _ActualizarDatosRENPRE();

                Close();
                          
               }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ActualizarDatosRENPRE()
        {
            string WCodigo = "", WVencimiento = "", WFechaEntrega = "", WVencimientoOrd = "", WFechaEntregaOrd = "", WObs = "";

            WCodigo = TB_CodCamion.Text.Trim();
            WVencimiento = txtVencimientoRENPRE.Text;
            WVencimientoOrd = Helper.OrdenarFecha(WVencimiento);
            WFechaEntrega = txtFechaEntregaRENPRE.Text;
            WFechaEntregaOrd = Helper.OrdenarFecha(WFechaEntrega);
            WObs = Helper.Left(txtObsRENPRE.Text, 50);

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Camion SET " 
                                    + " ObsRENPRE = '" + WObs + "', "
                                    + " VencimientoRENPRE = '" + WVencimiento + "', "
                                    + " VencimientoRENPREOrd = '" + WVencimientoOrd + "', "
                                    + " FechaEntregaRENPRE = '" + WFechaEntrega + "', "
                                    + " FechaEntregaRENPREOrd = '" + WFechaEntregaOrd + "'"
                                    + " WHERE Codigo = '" + WCodigo + "'";
                    cmd.ExecuteNonQuery();
                }

            }

        
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {

            //SOLO SE PERMITE LIMPIAR A PANTALLA CUANDO NO SE MODIFICA
            if (Modificar == false)
            {
                CB_Estado.Text = "";
                TB_Descripcion.Text = "";
                TB_Patente.Text = "";
                TB_CodProveedor.Text = "";
                TB_NombProveedor.Text = "";
                TB_CodChofer.Text = "";
                TB_NombChofer.Text = "";

                TB_VencRuta.Text = "";
                TB_EntRuta.Text = "";
                TB_ObservacRuta.Text = "";

                TB_VencRTO.Text = "";
                TB_EntRTO.Text = "";
                TB_ObservRTO.Text = "";

                TB_VencHabDominio.Text = "";
                TB_EntHabDominio.Text = "";
                TB_ObservHabDominio.Text = "";

                TB_VencSeguro.Text = "";
                TB_EntSeguro.Text = "";
                TB_ObservSeguro.Text = "";

                CB_CargasPeligrosas.Checked = false;
                TB_VencCargasPelig.Text = "";
                TB_EntCargasPelig.Text = "";
                TB_ObservCargasPelig.Text = "";

                txtFechaEntregaRENPRE.Clear();
                txtObsRENPRE.Text = "";
                txtVencimientoRENPRE.Clear();

            }
            
            
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region Ayuda Proveedor

        private void CargarProveedores()
        {
            dtProveedores.Clear();
            dtProveedores = PBOL.Lista();

            DataRow fila;
            fila = dtProveedores.NewRow();
            dtProveedores.Rows.InsertAt(fila, 0);


            CargarNombres();
            CargarCodigos();
            

            
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
                        CargarChoferes();

                    }
                }
            }
        }


        private void TB_NombProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow Des in dtProveedores.Rows)
            {
                if (Des[1].ToString() == TB_NombProveedor.Text)
                {
                    TB_CodProveedor.Text = Des[0].ToString();
                    TB_NombProveedor.Text = Des[1].ToString();
                    CargarChoferes();

                }
            }
        }

        private void CargarChoferes()
        {
            if (TB_CodProveedor.Text != "")
            {
                dtChoferes.Clear();
                dtChoferes = CBOL.ListaProve(TB_CodProveedor.Text);
                DataRow fila;
                fila = dtChoferes.NewRow();
                dtChoferes.Rows.InsertAt(fila, 0);

                TB_NombChofer.DataSource = dtChoferes;
                TB_NombChofer.DisplayMember = "Descripcion";
                TB_NombChofer.ValueMember = "Codigo";
                TB_NombChofer.Text = "";

                AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
                foreach (DataRow row in dtChoferes.Rows)
                {
                    stringCodArti.Add(Convert.ToString(row["Descripcion"]));

                }

                TB_NombChofer.AutoCompleteCustomSource = stringCodArti;
                TB_NombChofer.AutoCompleteMode = AutoCompleteMode.Suggest;
                TB_NombChofer.AutoCompleteSource = AutoCompleteSource.CustomSource;

                TB_NombChofer.Focus();
            }
            

        }

        private void TB_NombChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TB_CodProveedor.Text != "")  && (TB_NombChofer.Text != ""))
            {
                for (int i = 1; i < dtChoferes.Rows.Count; i++)
                {
                    DataRow Des = dtChoferes.Rows[i];
                    if (Des[1].ToString() == TB_NombChofer.Text)
                    {
                        TB_CodChofer.Text = Des[0].ToString();
                        TB_NombChofer.Text = Des[1].ToString();
                        TB_VencRuta.Focus();
                        

                    }
                }
                
            }
            
        }

        private void TB_CodProveedor_MouseClick(object sender, MouseEventArgs e)
        {
            /*PanelChofer.Visible = false;
            
                
                PanelProveedor.Visible = true;
                LBProveedor.IntegralHeight = true;*/
            
        }

        private void RBDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            /*dtProveedores.Clear();
            dtProveedores = PBOL.Lista();
            LBProveedor.DataSource = dtProveedores;
            LBProveedor.DisplayMember = "Nombre";*/
        }

        private void RBCodigo_CheckedChanged(object sender, EventArgs e)
        {
            /*dtProveedores.Clear();
            dtProveedores = PBOL.Lista();
            LBProveedor.DataSource = dtProveedores;
            LBProveedor.DisplayMember = "Proveedor";*/
        }

        private void TBFiltro_TextChanged(object sender, EventArgs e)
        {
           /* DataView dvProveedores = dtProveedores.DefaultView;
            if (RBCodigo.Checked)
            {
                dvProveedores.RowFilter = "Convert(Proveedor, System.String) LIKE '%" + TBFiltro.Text + "%'";
            }
            else
            {
                dvProveedores.RowFilter = "Nombre LIKE '%" + TBFiltro.Text + "%'";
            }*/
        }

        private void LBProveedor_MouseCaptureChanged(object sender, EventArgs e)
        {
            /*
            string elegido = LBProveedor.Text;


            if (RBCodigo.Checked)
            {

                foreach (DataRow Des in dtProveedores.Rows)
                {
                    if (Des[0].ToString() == elegido)
                    {
                        TB_NombProveedor.Text = Des[1].ToString();
                        TB_CodProveedor.Text = elegido;
                    }
                }

            }
            else
            {
                foreach (DataRow Des in dtProveedores.Rows)
                {
                    if (Des[1].ToString() == elegido)
                    {
                        TB_CodProveedor.Text = Des[0].ToString();
                        TB_NombProveedor.Text = elegido;
                    }
                }
            }
            TBFiltro.Text = "";
            PanelProveedor.Visible = false;*/
        }
            
        private void CB_Estado_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        private void TB_Descripcion_MarginChanged(object sender, EventArgs e)
        {
            
        }

        private void TB_Patente_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

     

        private void TB_ObservacRuta_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_VencRTO_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void TB_EntRTO_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void TB_ObservRTO_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_VencHabDominio_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void TB_EntHabDominio_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void TB_ObservHabDominio_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_VencSeguro_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void TB_EntSeguro_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_ObservSeguro_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_VencCargasPelig_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_EntCargasPelig_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_ObservCargasPelig_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void CB_CargasPeligrosas_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        #endregion

        #region Ayuda Chofer

        private void TB_CodChofer_MouseClick(object sender, MouseEventArgs e)
        {
            
            //COMPRUEBO QUE  YA SE HAYA AGREGADO EL PROVEEDOR
            if (TB_CodProveedor.Text != "") 
            {
                
                
                
            }

        }

        private void RB_NombreChof_CheckedChanged(object sender, EventArgs e)
        {
            //LOS CHOFERES QUE SE LISTAN SON LOS QUE ESTAN ASOCIADOS AL PROVEEDOR ELEGIDO
            //SINO SE DESEA ASI SE PUEDEN LISTAR TODOS LOS CHOFERES, LO MALO QUE SE PODRA ELEGIR CUALQUIERA.
            
        }

        private void RB_CodChofer_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void TB_FiltroChof_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LB_Chofer_MouseCaptureChanged(object sender, EventArgs e)
        {
            
            
        }

        #endregion

        private void TB_Patente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_NombProveedor.Focus();
            }
        }

        private void TB_Descripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Patente.Focus();
            }
        }

        private void TB_VencRuta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_EntRuta.Focus();
            }
        }

        private void TB_EntRuta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_ObservacRuta.Focus();
                
            }
        }

        private void TB_ObservacRuta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_VencRTO.Focus();

            }
        }

        private void TB_VencRTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_EntRTO.Focus();

            }
        }

        private void TB_EntRTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_ObservRTO.Focus();

            }
        }

        private void TB_ObservRTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_VencHabDominio.Focus();

            }
        }

        private void TB_VencHabDominio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_EntHabDominio.Focus();

            }
        }

        private void TB_EntHabDominio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_ObservHabDominio.Focus();

            }
        }

        private void TB_ObservHabDominio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_VencSeguro.Focus();

            }
        }

        private void TB_VencSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_EntSeguro.Focus();

            }
        }

        private void TB_EntSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_ObservSeguro.Focus();

            }
        }

        private void TB_ObservSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_VencCargasPelig.Focus();

            }
        }

        private void TB_VencCargasPelig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_EntCargasPelig.Focus();

            }
        }

        private void TB_EntCargasPelig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TB_ObservCargasPelig.Focus();

            }
        }

        private void TB_ObservCargasPelig_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtVencimientoRENPRE_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtVencimientoRENPRE.Text.Trim() == "") return;

                txtFechaEntregaRENPRE.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtVencimientoRENPRE.Text = "";
            }
	        
        }

        private void txtFechaEntregaRENPRE_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtFechaEntregaRENPRE.Text.Trim() == "") return;

                txtObsRENPRE.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtFechaEntregaRENPRE.Text = "";
            }
	        
        }

       

        

       
    }
}
