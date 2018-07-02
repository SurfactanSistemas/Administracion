using System;
using System.Data;
using System.Windows.Forms;

namespace HojaRuta.Listados.VencimientoCamiones
{
    public partial class ImpreVencCamion : Form
    {
        private DataTable dtInforme;
        private string p;
        private string p_2;
        private string Tipo;

        public ImpreVencCamion()
        {
            InitializeComponent();
        }

        

        public ImpreVencCamion(DataTable dtInforme, string p, string p_2, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtInforme = dtInforme;
            this.p = p;
            this.p_2 = p_2;
            this.Tipo = Tipo;
            InitializeComponent();
        }

        private void ImpreVencCamion_Load(object sender, EventArgs e)
        {
            DSCamionVenc Ds = new DSCamionVenc();

            int filas = dtInforme.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtInforme.Rows[i];
                Ds.Tables[0].Rows.Add
                    (p, p_2, dr[0].ToString(), dr[1].ToString(), dr[14].ToString(), dr[15].ToString(), dr[16].ToString(), dr[17].ToString(), dr[18].ToString(), dr[13].ToString(), dr[19].ToString(), dr[2].ToString());
            }

            if (Tipo == "Pantalla")
            {
                CRV_Camion.Visible = true;

                ReportVencCamion RImpre = new ReportVencCamion();
                

                RImpre.SetDataSource(Ds);

                CRV_Camion.ReportSource = RImpre;
                
            }
            else
            {
                ReportVencCamion RImpre = new ReportVencCamion();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }
        }
    }
}
