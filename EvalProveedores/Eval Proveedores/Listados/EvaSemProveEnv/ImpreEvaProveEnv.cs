using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.EvaSemProveEnv
{
    public partial class ImpreEvaProveEnv : Form
    {
        private DataTable dtInformeMuestra;
        private string FDesde;
        private string FHasta;
        private string TipoImpre;

        public ImpreEvaProveEnv()
        {
            InitializeComponent();
        }

        public ImpreEvaProveEnv(DataTable dtInformeMuestra, string FDesde, string FHasta, string TipoImpre)
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
                    (new object[]
                    {
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[8].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        FDesde,
                        FHasta,
                        
                         });


            }

            if (TipoImpre == "Pantalla")
            {
                CRVEvaSemProveEnv.Visible = true;

                ReportEvaProveEnv RImpre = new ReportEvaProveEnv();
                





                RImpre.SetDataSource(Ds);
                CRVEvaSemProveEnv.ReportSource = RImpre;
                

            }
            else
            {
                ReportEvaProveEnv RImpre = new ReportEvaProveEnv();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }

            
        }
    }
}
