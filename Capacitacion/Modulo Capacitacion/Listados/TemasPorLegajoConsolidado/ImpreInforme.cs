using System;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.TemasPorLegajoConsolidado
{
    public partial class ImpreInforme : Form
    {
        private DataTable dtInforme;
        private string Tipo;

        public ImpreInforme()
        {
            InitializeComponent();
        }

        public ImpreInforme(DataTable dtInforme, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtInforme = dtInforme;
            this.Tipo = Tipo;
            InitializeComponent();
        }

        private void ImpreInforme_Load(object sender, EventArgs e)
        {
            DSInforme Ds = new DSInforme();

            int filas = dtInforme.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtInforme.Rows[i];
                Ds.Tables[0].Rows.Add
                (
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[4], 
                    dr[5].ToString(), 
                    dr[6].ToString(), 
                    dr[7].ToString(), 
                    dr[8].ToString(), 
                    dr[9].ToString(), 
                    dr[10].ToString(), 
                    dr[11].ToString()
                );
            }

            if (Tipo == "Pantalla")
            {
                //Hago visible el report viewer
                CRVInforme.Visible = true;

                //Instancio el ReportImpre creado
                Reporte RImpre = new Reporte();
                //ReporteConsolidado RImpre = new ReporteConsolidado();
                //RepoteCons RImpre = new RepoteCons();

                //Cargo el reportImpre con el dataset DS
                RImpre.SetDataSource(Ds);

                //Cargo el report viewer con el ReportImp
                CRVInforme.ReportSource = RImpre;
            }
            else
            {
                //Instancio el ReportImpre creado
                Reporte RImpre = new Reporte();

                //Cargo el reportImpre con el dataset DS
                RImpre.SetDataSource(Ds);

                RImpre.PrintToPrinter(1, true, 0, 0);
                Close();
            }
            
        }
    }
}
