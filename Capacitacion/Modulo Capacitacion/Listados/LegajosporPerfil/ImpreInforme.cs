using System;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.LegajosporPerfil
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
                (dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), dr[15].ToString(), dr[16].ToString(), dr[17].ToString(), dr[18].ToString(), dr[19].ToString(), dr[20].ToString(), dr[21].ToString(), dr[22].ToString(), dr[23].ToString(), dr[24].ToString(), dr[25].ToString(), dr[26].ToString(), dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), dr[30].ToString(), dr[31].ToString(), dr[32].ToString(), dr[33].ToString(), dr[34].ToString(), dr[35].ToString(), dr[36].ToString(), dr[37].ToString(), dr[38].ToString(), dr[39].ToString(), dr[40].ToString(), dr[41].ToString(), dr[42].ToString());
            }

            if (Tipo == "Pantalla")
            {
                //Hago visible el report viewer
                CRVInforme.Visible = true;


                //Instancio el ReportImpre creado
                Reporte RImpre = new Reporte();


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

                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();
            }

        }
    }
}
