using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.ListaEvaTransp
{
    public partial class ImpreEvaTransp : Form
    {
        private DataTable dtEva;
        private string Tipo;
        private string p;
        private string p_2;

        public ImpreEvaTransp()
        {
            InitializeComponent();
        }

        public ImpreEvaTransp(DataTable dtEva, string Tipo, string Prove, string DescProve)
        {
            // TODO: Complete member initialization
            this.dtEva = dtEva;
            this.Tipo = Tipo;
            this.p = Prove;
            this.p_2 = DescProve;
            InitializeComponent();
        }

        private void ImpreEvaTransp_Load(object sender, EventArgs e)
        {
            DSEvaluaTransp Ds = new DSEvaluaTransp();

            int filas = dtEva.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtEva.Rows[i];
                Ds.Tables[0].Rows.Add
                    (new object[]
                    {
                        p,
                         p_2,
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[43].ToString(),
                        dr[44].ToString(),
                        dr[37].ToString(),
                        dr[40].ToString(),
                        dr[38].ToString(),
                        dr[41].ToString(),
                        dr[39].ToString(),
                        dr[42].ToString(),
                        dr[11].ToString(),
                        dr[12].ToString(),
                        dr[13].ToString(),
                        dr[14].ToString(),
                        dr[15].ToString(),
                        dr[16].ToString(),
                        dr[17].ToString(),
                        dr[18].ToString(),
                        dr[19].ToString(),
                        dr[20].ToString(),
                        dr[21].ToString(),
                        dr[22].ToString(),
                        dr[23].ToString(),
                        dr[24].ToString(),
                        dr[25].ToString(),
                        dr[26].ToString(),
                        dr[28].ToString(),
                        dr[29].ToString(),
                        dr[30].ToString(),
                        dr[31].ToString(),
                        dr[32].ToString(),
                        dr[33].ToString(),
                        dr[34].ToString(),
                        dr[35].ToString(),
                        dr[36].ToString(),
                    });
                        
                     
            }

            if (Tipo == "Pantalla")
            {
                CRVEvaTransp.Visible = true;

                ReportEvaluacTransp RImpre = new ReportEvaluacTransp();

                


                RImpre.SetDataSource(Ds);

                CRVEvaTransp.ReportSource = RImpre;

            }
            else
            {
                ReportEvaluacTransp RImpre = new ReportEvaluacTransp();

                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }

            }
        }
    }

