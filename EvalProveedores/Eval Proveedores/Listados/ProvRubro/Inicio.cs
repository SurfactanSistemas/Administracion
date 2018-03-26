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

namespace Eval_Proveedores.Listados.ProvRubro
{
    public partial class Inicio : Form
    {
        TipoProveedorBOL TPBOL = new TipoProveedorBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        string Tipo = "";
        string TipoProve;
        DataTable dtTipo = new DataTable();

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarCombo();
            Focus();
        }

        private void CargarCombo()
        {
            dtTipo = TPBOL.Lista();

            DataRow Row = dtTipo.NewRow();

            Row["Codigo"] = 0;
            Row["Descripcion"] = "";
            dtTipo.Rows.InsertAt(Row, 0);

            CB_Rubro.DataSource = dtTipo;
            CB_Rubro.DisplayMember = "Descripcion";
            CB_Rubro.ValueMember = "Codigo";
            
        }

        private void CB_Rubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoProve = CB_Rubro.SelectedValue.ToString();
            BT_Salir.Focus();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            Tipo = "Pantalla";
            Imprimir();
            
            
        }

        private void Imprimir()
        {
            try
            {
                if (CB_Rubro.Text == "") throw new Exception("Se debe seleccionar un tipo de proveedor");

                DataTable dtListaprove = PBOL.ListaRubro(TipoProve);


                ImpreProve Impre = new ImpreProve(dtListaprove, Tipo);
                Impre.ShowDialog();
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

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            Tipo = "Imprimir";
            Imprimir();
        }
    }
}
