using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.VencChoferes
{
    public partial class ImpreVencChofer : Form
    {
        private DataTable dtInforme;
        private string p;
        private string p_2;
        private string Tipo;

        public ImpreVencChofer()
        {
            InitializeComponent();
        }

        public ImpreVencChofer(DataTable dtInforme, string p, string p_2, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtInforme = dtInforme;
            this.p = p;
            this.p_2 = p_2;
            this.Tipo = Tipo;
            InitializeComponent();
        }

        private void ImpreVencChofer_Load(object sender, EventArgs e)
        {
            DSChoferVenc Ds = new DSChoferVenc();

            int filas = dtInforme.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtInforme.Rows[i];
                Ds.Tables[0].Rows.Add
                    (new object[]
                    {
                        p,
                        p_2,
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[8].ToString(),
                        dr[12].ToString(),
                        
                    });
            }

            if (Tipo == "Pantalla")
            {
                CRVVencChofer.Visible = true;

                ReportVencChofer RImpre = new ReportVencChofer();
                


                RImpre.SetDataSource(Ds);

                CRVVencChofer.ReportSource = RImpre;

            }
            else
            {
                ReportVencChofer RImpre = new ReportVencChofer();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }

        }
    }
}
