using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Logica_Negocio;

namespace Eval_Proveedores.Listados.ListaEvaTransp
{
   
    public partial class Inicio : Form
    {
        EvaTransBOL ETBOL = new EvaTransBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtProveedores;
        string Tipo = "";


        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            
        }

        private void CargarProveedores()
        {
            dtProveedores = PBOL.Lista();
            dtProveedores.Rows.InsertAt(dtProveedores.NewRow(),0);
            CargarCodProveedor();
            CargarDescProveedor();
            

        }

        private void CargarDescProveedor()
        {
            TB_DescProve.DataSource = dtProveedores;
            TB_DescProve.DisplayMember = "Nombre";
            TB_DescProve.ValueMember = "Proveedor";

            //AutoCompleteStringCollection stringDescProve = new AutoCompleteStringCollection()
            
            //foreach (DataRow row in dtProveedores.Rows)
            //{
            //    stringDescProve.Add(Convert.ToString(row["Nombre"]));

            //}

            //TB_DescProve.AutoCompleteCustomSource = stringDescProve;
            //TB_DescProve.AutoCompleteMode = AutoCompleteMode.Suggest;
            //TB_DescProve.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodProveedor()
        {
            TB_Prove.DataSource = dtProveedores;
            TB_Prove.DisplayMember = "Proveedor";
            TB_Prove.ValueMember = "Proveedor";

            //AutoCompleteStringCollection stringCodProve = new AutoCompleteStringCollection();
            //foreach (DataRow row in dtProveedores.Rows)
            //{
            //    stringCodProve.Add(Convert.ToString(row["Proveedor"]));

            //}

            //TB_Prove.AutoCompleteCustomSource = stringCodProve;
            //TB_Prove.AutoCompleteMode = AutoCompleteMode.Suggest;
            //TB_Prove.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            Tipo = "Pantalla";
            Imprimir();
        }

        private void Bt_Imprimir_Click(object sender, EventArgs e)
        {
            Tipo = "Imprimir";
            Imprimir();
        }

        private void Imprimir()
        {
            try
            {
                if (TB_Prove.Text == "") throw new Exception("Se debe ingresar el proveedor");

                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                string PeriodoDesde = TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2);

                string PeriodoHasta = TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2);

                VistaPrevia frm = new VistaPrevia();
                frm.CargarReporte(new listaevaluatransportista(), "{EvaluaI.Periodo} IN '" + PeriodoDesde + "' to '" + PeriodoHasta + "' AND {EvaluaI.Proveedor} = '" + TB_Prove.Text + "' AND {EvaluaI.Proveedor} = {Proveedor.Proveedor}");
                if (Tipo == "Pantalla") frm.Show();
                if (Tipo == "Imprimir") frm.Imprimir();
                //DataTable dtEva = ETBOL.ListaListaProveFecha(PeriodoDesde, PeriodoHasta, TB_Prove.Text);

                //ImpreEvaTransp Impre = new ImpreEvaTransp(dtEva, Tipo, TB_Prove.Text, TB_DescProve.Text);
                //Impre.ShowDialog();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_DescProve.Focus();
        }

        private void TB_DescProve_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void TB_Prove_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (TB_Desde.Text.Trim() == "") return;

                TB_Hasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_Desde.Text = "";
            }
	        
        }

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                TB_Hasta.Clear();
            }
        }

    }
}
