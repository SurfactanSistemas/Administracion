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

                //dtInforme = IBOL.Lista();
                
                dtInforme = IBOL.Lista(Helper.OrdenarFecha(TB_Desde.Text), Helper.OrdenarFecha(TB_Hasta.Text));

                FechaDesde = int.Parse(TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2));

                FechaHasta = int.Parse(TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2));

                BuscarFechas();
                Tipo = "Impresora";
                ImpreInforme Impre = new ImpreInforme(dtInfMuestra, Tipo);
                Impre.Show();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Enabled= true;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                dtInforme = IBOL.Lista(Helper.OrdenarFecha(TB_Desde.Text), Helper.OrdenarFecha(TB_Hasta.Text));

                FechaDesde = int.Parse(TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2));

                FechaHasta = int.Parse(TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2));


                BuscarFechas();
                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.Show();

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
