using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Maestros.IngCamiones
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
            CRV_Camion.Visible = true;

            ReportCamion RImpre = new ReportCamion();

            RImpre.SetDataSource(dt);

            CRV_Camion.ReportSource = RImpre;

        }
    }
}
