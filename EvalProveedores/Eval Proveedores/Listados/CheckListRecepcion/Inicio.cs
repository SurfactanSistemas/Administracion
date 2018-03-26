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
                if(TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                dtInforme = IBOL.Lista();
                FechaDesde = int.Parse(TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2));

                FechaHasta = int.Parse(TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2));

                BuscarFechas();
                Tipo = "Impresora";
                ImpreInforme Impre = new ImpreInforme(dtInfMuestra, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                dtInforme = IBOL.Lista();

                FechaDesde = int.Parse(TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2));

                FechaHasta = int.Parse(TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2));

                
                BuscarFechas();
                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInfMuestra, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarFechas()
        {
            dtInfMuestra = dtInforme.Clone();
            dtInfMuestra.Clear();


            foreach (DataRow fila in dtInforme.Rows)
            {
                string Fecha = fila[1].ToString();
                int FechaOrd = int.Parse(Fecha.Substring(6, 4) + Fecha.Substring(3, 2) + Fecha.Substring(0, 2));

                if ((FechaOrd >= FechaDesde) && (FechaOrd <= FechaHasta))
                {
                    dtInfMuestra.ImportRow(fila);
                }


            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
