using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.CheckListHojaRuta
{
    public partial class ImpreHojaRuta : Form
    {
        private DataTable dtExpreso1;
        private DataTable dtExpreso3;
        private int CantItem1Exp1;
        private int CantItem2Exp1;
        private int CantItem3Exp1;
        private int CantItem4Exp1;
        private int CantItem5Exp1;
        private int CantItem6Exp1;
        private int CantItem7Exp1;
        private int CantItem8Exp1;
        private int CantItem1Exp2;
        private int CantItem2Exp2;
        private int CantItem3Exp2;
        private int CantItem4Exp2;
        private int CantItem5Exp2;
        private int CantItem6Exp2;
        private int CantItem7Exp2;
        private int CantItem8Exp2;
        private int CantItem1Tot;
        private int CantItem2Tot;
        private int CantItem3Tot;
        private int CantItem4Tot;
        private int CantItem5Tot;
        private int CantItem6Tot;
        private int CantItem7Tot;
        private int CantItem8Tot;
        private string Tipo;

        public ImpreHojaRuta()
        {
            InitializeComponent();
        }

        

        public ImpreHojaRuta(DataTable dtExpreso1, DataTable dtExpreso3, int CantItem1Exp1, int CantItem2Exp1, int CantItem3Exp1, int CantItem4Exp1, int CantItem5Exp1, int CantItem6Exp1, int CantItem7Exp1, int CantItem8Exp1, int CantItem1Exp2, int CantItem2Exp2, int CantItem3Exp2, int CantItem4Exp2, int CantItem5Exp2, int CantItem6Exp2, int CantItem7Exp2, int CantItem8Exp2, int CantItem1Tot, int CantItem2Tot, int CantItem3Tot, int CantItem4Tot, int CantItem5Tot, int CantItem6Tot, int CantItem7Tot, int CantItem8Tot, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtExpreso1 = dtExpreso1;
            this.dtExpreso3 = dtExpreso3;
            this.CantItem1Exp1 = CantItem1Exp1;
            this.CantItem2Exp1 = CantItem2Exp1;
            this.CantItem3Exp1 = CantItem3Exp1;
            this.CantItem4Exp1 = CantItem4Exp1;
            this.CantItem5Exp1 = CantItem5Exp1;
            this.CantItem6Exp1 = CantItem6Exp1;
            this.CantItem7Exp1 = CantItem7Exp1;
            this.CantItem8Exp1 = CantItem8Exp1;
            this.CantItem1Exp2 = CantItem1Exp2;
            this.CantItem2Exp2 = CantItem2Exp2;
            this.CantItem3Exp2 = CantItem3Exp2;
            this.CantItem4Exp2 = CantItem4Exp2;
            this.CantItem5Exp2 = CantItem5Exp2;
            this.CantItem6Exp2 = CantItem6Exp2;
            this.CantItem7Exp2 = CantItem7Exp2;
            this.CantItem8Exp2 = CantItem8Exp2;
            this.CantItem1Tot = CantItem1Tot;
            this.CantItem2Tot = CantItem2Tot;
            this.CantItem3Tot = CantItem3Tot;
            this.CantItem4Tot = CantItem4Tot;
            this.CantItem5Tot = CantItem5Tot;
            this.CantItem6Tot = CantItem6Tot;
            this.CantItem7Tot = CantItem7Tot;
            this.CantItem8Tot = CantItem8Tot;
            this.Tipo = Tipo;
            InitializeComponent();
        }

        private void ImpreHojaRuta_Load(object sender, EventArgs e)
        {
            DSHojaRuta Ds = new DSHojaRuta();
/*
            int filasExp1 = dtExpreso1.Rows.Count;
            string Total = dtExpreso1.Rows.Count.ToString();

            for (int i = filasExp1 - 1; i > -1; i--)
            {
                DataRow dr = dtExpreso1.Rows[i];
                Ds.Tables[0].Rows.Add
                    (new object[]
                    {
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[5].ToString(),
                        dr[4].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[12].ToString(),
                        dr[13].ToString(),
                        dr[14].ToString(),
                        dr[15].ToString(),
                        dr[16].ToString(),
                        dr[17].ToString(),
                        Total,
                        CantItem1Exp1,
                        CantItem2Exp1,
                        CantItem3Exp1,
                        CantItem4Exp1,
                        CantItem5Exp1,
                        CantItem6Exp1,
                        CantItem7Exp1,
                        CantItem8Exp1,

                    });
            }
            */
            int filasExp3 = dtExpreso3.Rows.Count;
            string TotalExp2 = dtExpreso3.Rows.Count.ToString();

            for (int i = filasExp3 - 1; i > -1; i--)
            {
                DataRow dr = dtExpreso3.Rows[i];
                Ds.Tables["DsHojaRuta"].Rows.Add
                //Ds.Tables[0].Rows.Add
                    (new object[]
                    {
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[4].ToString(),
                        dr[3].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[12].ToString(),
                        dr[13].ToString(),
                        dr[14].ToString(),
                        dr[15].ToString(),
                        dr[16].ToString(),
                       
                        CantItem1Exp2,
                        CantItem2Exp2,
                        CantItem3Exp2,
                        CantItem4Exp2,
                        CantItem5Exp2,
                        CantItem6Exp2,
                        CantItem7Exp2,
                        CantItem8Exp2,
                         //Total,

                    });
            }
            
            int ItemTot = dtExpreso1.Rows.Count + dtExpreso3.Rows.Count;

            string Itemtotal = ItemTot.ToString();

            Ds.Tables[2].Rows.Add
                    (new object[]
                    {
                        CantItem1Tot,
                        CantItem2Tot,
                        CantItem3Tot,
                        CantItem4Tot,
                        CantItem5Tot,
                        CantItem6Tot,
                        CantItem7Tot,
                        CantItem8Tot,
                        Itemtotal,


                    });

            
            if (Tipo == "Pantalla")
            {
                
                CRVHojaRuta.Visible = true;

                ReportHojaRuta RImpre = new ReportHojaRuta();
                





                RImpre.SetDataSource(Ds);

                CRVHojaRuta.ReportSource = RImpre;

            }
            else
            {
                ReportHojaRuta RImpre = new ReportHojaRuta();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }


        }

        
    }
}
