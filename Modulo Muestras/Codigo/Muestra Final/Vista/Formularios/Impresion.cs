using System;
using System.Data;
using System.Windows.Forms;

namespace Vista
{
    public partial class Impresion : Form
    {
        private DataTable dt;

        public Impresion()
        {
            InitializeComponent();
        }

        public Impresion(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DsImp Ds = new DsImp();
            int filas = dt.Rows.Count;

            for (int i = filas - 1 ; i > -1; i--)
            {
                DataRow dr = dt.Rows[i];
                Ds.Tables[0].Rows.Add
                (dr[2].ToString(), dr[3].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[10].ToString(), dr[16].ToString(), dr[1].ToString());
            }
            //Hago visible el report viewer
            crystalReportViewer1.Visible = true;

            //Instancio el ReportImpre creado
            ReportImpre RImp = new ReportImpre();

            //Cargo el reportImpre con el dataset Ds
            RImp.SetDataSource(Ds);

            //Cargo el report viewer con el ReportImp
            crystalReportViewer1.ReportSource = RImp;

        }

        private void Impresion_Load(object sender, EventArgs e)
        {

        }
    }
}
