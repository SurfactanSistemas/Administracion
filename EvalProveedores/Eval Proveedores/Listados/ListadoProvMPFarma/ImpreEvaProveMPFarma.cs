using System;
using System.Data;
using System.Windows.Forms;
using Eval_Proveedores.Listados.ListadoProvMPFarma;

namespace Eval_Proveedores.Listados.ListadoProvMPFarma
{
    public partial class ImpreEvaProveMPFarma : Form
    {
        private readonly DataTable dtInformeMuestra;
        private readonly string FDesde;
        private readonly string FHasta;
        private readonly string TipoImpre;

        public ImpreEvaProveMPFarma()
        {
            InitializeComponent();
        }

        public ImpreEvaProveMPFarma(DataTable dtInformeMuestra, string FDesde, string FHasta, string TipoImpre)
        {
            // TODO: Complete member initialization
            this.dtInformeMuestra = dtInformeMuestra;
            this.FDesde = FDesde;
            this.FHasta = FHasta;
            this.TipoImpre = TipoImpre;
            InitializeComponent();
        }

        private void ImpreEvaProveEnv_Load(object sender, EventArgs e)
        {
            EvaProveEnv Ds = new EvaProveEnv();

            int filas = dtInformeMuestra.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtInformeMuestra.Rows[i];
                Ds.Tables[0].Rows.Add
                    (dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[8].ToString(), dr[10].ToString(), dr[11].ToString(), FDesde, FHasta);
            }

            if (TipoImpre == "Pantalla")
            {
                CRVEvaSemProveEnv.Visible = true;

                ReportEvaProveMPFarma RImpre = new ReportEvaProveMPFarma();
                
                RImpre.SetDataSource(Ds);
                CRVEvaSemProveEnv.ReportSource = RImpre;
            }
            else
            {
                ReportEvaProveMPFarma RImpre = new ReportEvaProveMPFarma();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();
            }
        }
    }
}
