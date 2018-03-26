using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.EvaSemActProve
{
    public partial class ImpreEvaSemProve : Form
    {
        private DataTable dtInformeMuestra;
        private string FDesde;
        private string FHasta;
        private string TipoImpre;

        public ImpreEvaSemProve()
        {
            InitializeComponent();
        }

        

        public ImpreEvaSemProve(DataTable dtInformeMuestra, string FDesde, string FHasta, string TipoImpre)
        {
            // TODO: Complete member initialization
            this.dtInformeMuestra = dtInformeMuestra;
            this.FDesde = FDesde;
            this.FHasta = FHasta;
            this.TipoImpre = TipoImpre;
            InitializeComponent();
        }

        private void ImpreEvaSemProve_Load(object sender, EventArgs e)
        {
            DSEvaSemProve Ds = new DSEvaSemProve();

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
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[13].ToString(),
                        dr[14].ToString(),
                        FDesde,
                        FHasta,
                        
                         });


            }

            if (TipoImpre == "Pantalla")
            {
                CRVEvaSemProve.Visible = true;

                ReportEvaSemProve RImpre = new ReportEvaSemProve();
               




                RImpre.SetDataSource(Ds);

                CRVEvaSemProve.ReportSource = RImpre;

            }
            else
            {
                ReportEvaSemProve RImpre = new ReportEvaSemProve();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }
        }
    }
}
