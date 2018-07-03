using System;
using System.Data;
using System.Windows.Forms;

namespace HojaRuta.Maestros.IngCamiones
{
    public partial class ImpreCamion : Form
    {
        private DataTable dt;

        public ImpreCamion()
        {
            InitializeComponent();
        }

        public ImpreCamion(DataTable dt)
        {
            // TODO: Complete member initialization
            this.dt = dt;
            InitializeComponent();
        }

        private void ImpreCamion_Load(object sender, EventArgs e)
        {
            DSCamion DS = new DSCamion();

            int filas = dt.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dt.Rows[i];
                DS.Tables[0].Rows.Add
                (dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), dr[15].ToString());
            }

            CRV_Camion.Visible = true;

            ReportCamion RImpre = new ReportCamion();

            RImpre.SetDataSource(DS);

            CRV_Camion.ReportSource = RImpre;

        }
    }
}
