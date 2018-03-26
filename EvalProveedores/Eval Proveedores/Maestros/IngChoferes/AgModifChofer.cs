using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica_Negocio;
using Negocio;

namespace Eval_Proveedores.IngChoferes
{
    public partial class AgModifChofer : Form
    {
        Chofer C = new Chofer();
        ChoferBOL CBOL = new ChoferBOL();
        Proveedor P = new Proveedor();
        List<Proveedor> Proveedores = new List<Proveedor>();
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtProveedores = new DataTable();
        int IdPas;
        bool Modificar = false;
        private string Codigo;
        private string Desc;
        private string Aplica;
        private string Proveedor;
        private string CodEmp;
        private string FechaVenc1;
        private string FechaVenc2;
        private string FechaVenc3;
        private string OrdFecVenc1;
        private string OrdFecVenc2;
        private string OrdFecVenc3;
        private string FechaEnt1;
        private string FechaEnt2;
        private string FechaEnt3;
        private string OrdFecEnt1;
        private string OrdFecEnt2;
        private string OrdFecEnt3;
        private string Coment1;
        private string Coment2;
        private string Coment3;
        private string NomProve;

        public AgModifChofer()
        {

            InitializeComponent();
            /*textBox1.Text = "37";
            textBox2.Text = "PRUEBA INSERT";
            maskedTextBox1.Text = "12/08/2017";*/

        }

        

        public AgModifChofer(string Codigo, string Desc, string Aplica, string Proveedor, string CodEmp, string FechaVenc1, string FechaVenc2, string FechaVenc3, string OrdFecVenc1, string OrdFecVenc2, string OrdFecVenc3, string FechaEnt1, string FechaEnt2, string FechaEnt3, string OrdFecEnt1, string OrdFecEnt2, string OrdFecEnt3, string Coment1, string Coment2, string Coment3, string NomProve)
        {
            // TODO: Complete member initialization
            this.Codigo = Codigo;
            this.Desc = Desc;
            this.Aplica = Aplica;
            this.Proveedor = Proveedor;
            this.CodEmp = CodEmp;
            this.FechaVenc1 = FechaVenc1;
            this.FechaVenc2 = FechaVenc2;
            this.FechaVenc3 = FechaVenc3;
            this.OrdFecVenc1 = OrdFecVenc1;
            this.OrdFecVenc2 = OrdFecVenc2;
            this.OrdFecVenc3 = OrdFecVenc3;
            this.FechaEnt1 = FechaEnt1;
            this.FechaEnt2 = FechaEnt2;
            this.FechaEnt3 = FechaEnt3;
            this.OrdFecEnt1 = OrdFecEnt1;
            this.OrdFecEnt2 = OrdFecEnt2;
            this.OrdFecEnt3 = OrdFecEnt3;
            this.Coment1 = Coment1;
            this.Coment2 = Coment2;
            this.Coment3 = Coment3;
            this.NomProve = NomProve;
            InitializeComponent();
        }

        private void AgModifChofer_Load(object sender, EventArgs e)
        {
            if (Codigo != null)
            {
                LBChofer.Text = "MODIFICAR CHOFER";
                TB_Codigo.Text = Codigo;
                TB_Nombre.Text = Desc;
                TB_CodProveedor.Text = Proveedor;
                TB_NombProveedor.Text = NomProve;
                FecVencLic.Text = FechaVenc1;
                FecVencART.Text = FechaVenc2;
                FecVencCargPel.Text = FechaVenc3;
                FecEntLic.Text = FechaEnt1;
                FecEntART.Text = FechaEnt2;
                FecEntCargPel.Text = FechaEnt3;
                ObservLicCon.Text = Coment1;
                ObservART.Text = Coment2;
                ObservCargPel.Text = Coment3;
                if (int.Parse(Aplica) == 1) CB_CertPel.Checked = true;
                
                TB_Nombre.ReadOnly = true;
                Modificar = true;

                TB_Codigo.Focus();



            }
            else
            {
                LBChofer.Text = "INGRESO DE CHOFER";
                int Ultimo = CBOL.Ultimo();
                TB_Codigo.Text = (Ultimo + 1).ToString();
                CargarProveedores();
                TB_Nombre.Focus();
            }
            
            
        }

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

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ( TB_Nombre.Text == "") throw new Exception("Se debe ingresar el nombre del chofer");

                if (TB_NombProveedor.Text == "") throw new Exception("Se debe ingresar el proveedor al que pertenece el chofer");

                if (FecVencLic.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la Licencia de Conducir");

                if (FecEntLic.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la Licencia de Conducir");

                if (FecVencART.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la ART");

                if (FecEntART.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la ART");

                if (CB_CertPel.Checked == true)
                {
                    

                    if (FecVencCargPel.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento del certificado de cargas peligrosas");

                    if (FecEntCargPel.Text == "") throw new Exception("Se debe ingresar la fecha de entrega del certificado de cargas peligrosas");
                }

                C.Aplica = 0;
                
                C.Descripcion = TB_Nombre.Text;
                C.Proveedor = TB_CodProveedor.Text;
                C.FechaVto1 = FecVencLic.Text;
                C.OrdFechaVto1 = FecVencLic.Text.Substring(6, 4) + FecVencLic.Text.Substring(3, 2) + FecVencLic.Text.Substring(0, 2);
                C.FechaEnt1 = FecEntLic.Text;
                C.OrdFechaEnt1 = FecEntLic.Text.Substring(6, 4) + FecEntLic.Text.Substring(3, 2) + FecEntLic.Text.Substring(0, 2);
                C.Comentario1 = ObservLicCon.Text;

                C.FechaVto2 = FecVencART.Text;
                C.OrdFechaVto2 = FecVencART.Text.Substring(6, 4) + FecVencART.Text.Substring(3, 2) + FecVencART.Text.Substring(0, 2);
                C.FechaEnt2 = FecEntART.Text;
                C.OrdFechaEnt2 = FecEntART.Text.Substring(6, 4) + FecEntART.Text.Substring(3, 2) + FecEntART.Text.Substring(0, 2);
                C.Comentario2 = ObservART.Text;

                if (CB_CertPel.Checked == true)
                {
                    C.Aplica = 1;
                    C.FechaVto3 = FecVencCargPel.Text;
                    C.OrdFechaVto3 = FecVencCargPel.Text.Substring(6, 4) + FecVencCargPel.Text.Substring(3, 2) + FecVencCargPel.Text.Substring(0, 2);
                    C.FechaEnt3 = FecEntCargPel.Text;
                    C.OrdFechaEnt3 = FecEntCargPel.Text.Substring(6, 4) + FecEntCargPel.Text.Substring(3, 2) + FecEntCargPel.Text.Substring(0, 2);
                    C.Comentario3 = ObservCargPel.Text;
                }
                else
                {
                    C.FechaVto3 = FecVencCargPel.Text;
                    C.OrdFechaVto3 = "";
                    C.FechaEnt3 = FecEntCargPel.Text;
                    C.OrdFechaEnt3 = "";
                    C.Comentario3 = ObservCargPel.Text;
                }
                
                //DONDE SE PONE ESTE DATO
                C.Titulo = "";

                C.CodigoEmpresa = 1;

                if (Modificar == false)
                {
                    CBOL.Insertar(C);
                    MessageBox.Show("El conductor se agrego con exito", "Agregar Conductor",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    C.Codigo = int.Parse(TB_Codigo.Text);
                    CBOL.Modificar(C);
                    MessageBox.Show("El conductor se modifico con exito", "Modificar Conductor",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                

                

                Close();

             }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        


        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                TB_Nombre.Text = "";

                TB_CodProveedor.Text = "";

                TB_NombProveedor.Text = "";
            }

            CB_CertPel.Checked = false;

            FecVencLic.Text = "";

            FecEntLic.Text = "";

            FecVencART.Text = "";

            FecEntART.Text = "";

            FecVencCargPel.Text = "";

            FecEntCargPel.Text = "";

            ObservLicCon.Text = "";

            ObservART.Text = "";

            ObservCargPel.Text = "";

        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Ayuda Proveedor

        private void TB_CodProveedor_MouseClick(object sender, MouseEventArgs e)
        {
            if (Modificar == false)
            {
               
            }
            
        }

        private void RBDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            dtProveedores.Clear();
            dtProveedores = PBOL.Lista();
            //Proveedores = PBOL.Todos();
            
        }

        private void RBCodigo_CheckedChanged(object sender, EventArgs e)
        {
            dtProveedores.Clear();
            dtProveedores = PBOL.Lista();
            
        }


        private void TB_Nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                TB_CodProveedor.Focus();

            }
        }

        private void TB_CodProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_NombProveedor.Focus();
                

            }
        }

        private void TB_NombProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                FecVencLic.Focus();

            }
        }

        private void FecVencLic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                FecEntLic.Focus();

            }
        }

        private void FecEntLic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ObservLicCon.Focus();

            }
        }

        private void ObservLicCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                FecVencART.Focus();

            }
        }

        private void FecVencART_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                FecEntART.Focus();

            }
        }

        private void FecEntART_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ObservART.Focus();

            }
        }

        private void ObservART_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                FecVencCargPel.Focus();

            }
        }

        private void FecVencCargPel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                FecEntCargPel.Focus();

            }
        }

        private void FecEntCargPel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ObservCargPel.Focus();

            }
        }

        private void ObservCargPel_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TBFiltro_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LBProveedor_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Nombre_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_DescProveedor_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TB_Codigo_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void maskedTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void maskedTextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FecVencART_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FecEntART_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ObservART_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FecVencCargPel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FecEntCargPel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ObservCargPel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        #endregion

        private void BT_Guardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TB_Nombre.Text == "") throw new Exception("Se debe ingresar el nombre del chofer");

                if (TB_NombProveedor.Text == "") throw new Exception("Se debe ingresar el proveedor al que pertenece el chofer");

                if (FecVencLic.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la Licencia de Conducir");

                if (FecEntLic.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la Licencia de Conducir");

                if (FecVencART.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento de la ART");

                if (FecEntART.Text == "") throw new Exception("Se debe ingresar la fecha de entrega de la ART");

                if (CB_CertPel.Checked == true)
                {


                    if (FecVencCargPel.Text == "") throw new Exception("Se debe ingresar la fecha de vencimiento del certificado de cargas peligrosas");

                    if (FecEntCargPel.Text == "") throw new Exception("Se debe ingresar la fecha de entrega del certificado de cargas peligrosas");
                }

                C.Aplica = 0;

                C.Descripcion = TB_Nombre.Text;
                C.Proveedor = TB_CodProveedor.Text;
                C.FechaVto1 = FecVencLic.Text;
                C.OrdFechaVto1 = FecVencLic.Text.Substring(6, 4) + FecVencLic.Text.Substring(3, 2) + FecVencLic.Text.Substring(0, 2);
                C.FechaEnt1 = FecEntLic.Text;
                C.OrdFechaEnt1 = FecEntLic.Text.Substring(6, 4) + FecEntLic.Text.Substring(3, 2) + FecEntLic.Text.Substring(0, 2);
                C.Comentario1 = ObservLicCon.Text;

                C.FechaVto2 = FecVencART.Text;
                C.OrdFechaVto2 = FecVencART.Text.Substring(6, 4) + FecVencART.Text.Substring(3, 2) + FecVencART.Text.Substring(0, 2);
                C.FechaEnt2 = FecEntART.Text;
                C.OrdFechaEnt2 = FecEntART.Text.Substring(6, 4) + FecEntART.Text.Substring(3, 2) + FecEntART.Text.Substring(0, 2);
                C.Comentario2 = ObservART.Text;

                if (CB_CertPel.Checked == true)
                {
                    C.Aplica = 1;
                    C.FechaVto3 = FecVencCargPel.Text;
                    C.OrdFechaVto3 = FecVencCargPel.Text.Substring(6, 4) + FecVencCargPel.Text.Substring(3, 2) + FecVencCargPel.Text.Substring(0, 2);
                    C.FechaEnt3 = FecEntCargPel.Text;
                    C.OrdFechaEnt3 = FecEntCargPel.Text.Substring(6, 4) + FecEntCargPel.Text.Substring(3, 2) + FecEntCargPel.Text.Substring(0, 2);
                    C.Comentario3 = ObservCargPel.Text;
                }
                else
                {
                    C.FechaVto3 = FecVencCargPel.Text;
                    C.OrdFechaVto3 = "";
                    C.FechaEnt3 = FecEntCargPel.Text;
                    C.OrdFechaEnt3 = "";
                    C.Comentario3 = ObservCargPel.Text;
                }

                //DONDE SE PONE ESTE DATO
                C.Titulo = "";

                C.CodigoEmpresa = 1;

                if (Modificar == false)
                {
                    CBOL.Insertar(C);
                    MessageBox.Show("El conductor se agrego con exito", "Agregar Conductor",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    C.Codigo = int.Parse(TB_Codigo.Text);
                    CBOL.Modificar(C);
                    MessageBox.Show("El conductor se modifico con exito", "Modificar Conductor",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                }




                Close();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Salir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        

    }
}
