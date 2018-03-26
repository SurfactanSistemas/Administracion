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
using System.Text.RegularExpressions;

namespace Eval_Proveedores.Listados.VencChoferes
{
    public partial class Inicio : Form
    {
        ChoferBOL CBOL = new ChoferBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        Proveedor P = new Proveedor();
        string Tipo = "";
        Regex reg = new Regex("[0-9]");
        
        string PeriodoDesde;
        string PeriodoHasta;



        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            Tipo = "Pantalla";
            Imprimir();
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            Tipo = "Imprimir";
            Imprimir();
        }


        private void Imprimir()
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                PeriodoDesde = TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2);

                PeriodoHasta = TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2);

                DataTable dtInforme = CBOL.ListaFecha(PeriodoDesde, PeriodoHasta);

                ArmarDT(dtInforme);
                ImpreVencChofer Impre = new ImpreVencChofer(dtInforme, TB_Desde.Text, TB_Hasta.Text, Tipo);

                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArmarDT(DataTable dtInforme)
        {
            int Desde = int.Parse(PeriodoDesde);
            int Hasta = int.Parse(PeriodoHasta);
            dtInforme.Columns.Add("Vto1", typeof(string));
            dtInforme.Columns.Add("Vto2", typeof(string));
            dtInforme.Columns.Add("Vto3", typeof(string));
            dtInforme.Columns.Add("NomProve", typeof(string));

            foreach (DataRow fila in dtInforme.Rows)
            {
                if ((fila[2].ToString() != "  /  /    ") && (int.Parse(fila[5].ToString()) >= Desde) && (int.Parse(fila[5].ToString()) <= Hasta))
                {
                    fila["Vto1"] = fila[2].ToString();
                }

                if ((fila[3].ToString() != "  /  /    ") && (int.Parse(fila[6].ToString()) >= Desde) && (int.Parse(fila[6].ToString()) <= Hasta))
                {
                    fila["Vto2"] = fila[3].ToString();
                }

                
                if ((fila[4].ToString() != "  /  /    ") && (int.Parse(fila[7].ToString()) >= Desde) && (int.Parse(fila[7].ToString()) <= Hasta))
                {
                    fila["Vto3"] = fila[4].ToString();
                }
                bool b = reg.IsMatch(fila[8].ToString());
                if (b == true)
                {
                    P = PBOL.Find(fila[8].ToString());
                    fila["NomProve"] = P.Descripcion;
                }

                
            }
        }

        

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
