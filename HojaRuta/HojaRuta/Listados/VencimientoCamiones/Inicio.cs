using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Logica_Negocio;
using Negocio;

namespace HojaRuta.Listados.VencimientoCamiones
{
    public partial class Inicio : Form
    {
        CamionBOL CBOL = new CamionBOL();
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
                ImpreVencCamion Impre = new ImpreVencCamion(dtInforme, TB_Desde.Text, TB_Hasta.Text, Tipo);
               
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
            dtInforme.Columns.Add("Vto4", typeof(string));
            dtInforme.Columns.Add("Vto5", typeof(string));
            dtInforme.Columns.Add("NomProve", typeof(string));
            
            foreach (DataRow fila in dtInforme.Rows)
            {
                if ((fila[3].ToString() != "  /  /    ") && (int.Parse(fila[8].ToString()) >= Desde) && (int.Parse(fila[8].ToString()) <= Hasta))
                {
                    fila["Vto1"] = fila[3].ToString();
                }

                if ((fila[5].ToString() != "  /  /    ") && (int.Parse(fila[9].ToString()) >= Desde) && (int.Parse(fila[9].ToString()) <= Hasta))
                {
                    fila["Vto2"] = fila[4].ToString();
                }

                if ((fila[5].ToString() != "  /  /    ") && (int.Parse(fila[10].ToString()) >= Desde) && (int.Parse(fila[10].ToString()) <= Hasta))
                {
                    fila["Vto3"] = fila[5].ToString();
                }

                if ((fila[6].ToString() != "  /  /    ") && (int.Parse(fila[11].ToString()) >= Desde) && (int.Parse(fila[11].ToString()) <= Hasta))
                {
                    fila["Vto4"] = fila[6].ToString();
                }

                if ((fila[7].ToString() != "  /  /    ") && (int.Parse(fila[12].ToString()) >= Desde) && (int.Parse(fila[12].ToString()) <= Hasta))
                {
                    fila["Vto5"] = fila[7].ToString();
                }

                bool b = reg.IsMatch(fila[13].ToString());
                if (b)
                {
                    P = PBOL.Find(fila[13].ToString());
                    fila["NomProve"] = P.Descripcion;
                }

                
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            Tipo = "Imprimir";
            Imprimir();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (TB_Desde.Text.Replace("/", "").Trim() == "") return;

                TB_Hasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_Desde.Text = "";
            }
	        
        }

        
    }
}
