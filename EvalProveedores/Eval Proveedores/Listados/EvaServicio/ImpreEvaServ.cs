using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.EvaServicio
{
    public partial class ImpreEvaServ : Form
    {
        private DataTable dtEva;
        private string TipoServ;
        private string Tipo;

        public ImpreEvaServ()
        {
            InitializeComponent();
        }

        

        public ImpreEvaServ(DataTable dtEva, string TipoServ, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtEva = dtEva;
            this.TipoServ = TipoServ;
            this.Tipo = Tipo;
            InitializeComponent();
        }

        private void ImpreEvaServ_Load(object sender, EventArgs e)
        {
            DSEvaServ Ds = new DSEvaServ();

            int filas = dtEva.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtEva.Rows[i];
                int TipoServi = int.Parse(dr[6].ToString());
                switch (TipoServi)
                {
                    case 2:
                        TipoServ = "Calibración";
                        break;

                    case 4:
                        TipoServ = "Mantenimiento";
                        break;

                    case 3:
                        TipoServ = "Ensayos";
                        break;
                }

                Ds.Tables[0].Rows.Add
                    (new object[]
                    {
                        dr[0].ToString(),
                        dr[37].ToString(),
                        dr[1].ToString(),
                        TipoServ,
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString(),
                        dr[10].ToString(),
                        dr[11].ToString(),
                        dr[12].ToString(),
                        dr[13].ToString(),
                        dr[14].ToString(),
                        dr[15].ToString(),
                        dr[11].ToString(),
                        dr[40].ToString(),
                        dr[41].ToString(),
                        dr[42].ToString(),
                        dr[43].ToString(),
                        dr[44].ToString(),
                        dr[45].ToString(),
                        dr[46].ToString(),
                        dr[47].ToString(),
                        dr[48].ToString(),
                        dr[49].ToString(),
                        dr[50].ToString(),
                        dr[51].ToString(),
                        dr[52].ToString(),
                        dr[53].ToString(),
                        dr[54].ToString(),
                        dr[31].ToString(),
                        dr[32].ToString(),
                        dr[33].ToString(),
                        dr[39].ToString(),
                        dr[4].ToString(),
                        dr[2].ToString(),
                        

                        });


            }

            if (Tipo == "Pantalla")
            {

                CRVEvaServ.Visible = true;

                ReportEvaServ RImpre = new ReportEvaServ();
                
                RImpre.SetDataSource(Ds);

                CRVEvaServ.ReportSource = RImpre;

            }
            else
            {
                ReportEvaServ RImpre = new ReportEvaServ();
                
                RImpre.SetDataSource(Ds);
                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();

            }
        }
    }
}
