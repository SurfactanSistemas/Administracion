using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.ProvRubro
{
    public partial class ImpreProve : Form
    {
        private DataTable dtListaprove;
        private string Tipo;

        public ImpreProve()
        {
            InitializeComponent();
        }

        public ImpreProve(DataTable dtListaprove, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtListaprove = dtListaprove;
            this.Tipo = Tipo;
            InitializeComponent();
        }

        private void ImpreProve_Load(object sender, EventArgs e)
        {
            DSProve Ds = new DSProve();
            int filas = dtListaprove.Rows.Count;

             for (int i = filas - 1; i > -1; i--)
             {
                 DataRow dr = dtListaprove.Rows[i];
                 Ds.Tables[0].Rows.Add
                 (new object[]
                {
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    dr[5].ToString(),
                    dr[6].ToString(),
                    dr[7].ToString(),                   
                    

                }

                 );
             }

             if (Tipo == "Pantalla")
             {
                 CRVListProve.Visible = true;

                 ReportProve RImpre = new ReportProve();

                 RImpre.SetDataSource(Ds);

                 CRVListProve.ReportSource = RImpre;
             }
             else
             {
                 ReportProve RImpre = new ReportProve();

                 RImpre.SetDataSource(Ds);
                 RImpre.PrintToPrinter(1, true, 1, 999);
                 Close();

             }
        }
    }
}
