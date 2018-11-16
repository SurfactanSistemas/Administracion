using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Maestros.IngChoferes
{
    public partial class ImpreChofer : Form
    {
        private DataTable dt;

        public ImpreChofer()
        {
            InitializeComponent();
        }

        public ImpreChofer(DataTable dt)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.dt = dt;
        }

        private void ImpreChofer_Load(object sender, EventArgs e)
        {
            DSChofer DS = new DSChofer();

            //int filas = dt.Rows.Count;

            //for (int i = filas - 1; i > -1; i--)
            //{
            //    DataRow dr = dt.Rows[i];
            //    DS.Tables[0].Rows.Add
            //    (new object[]
            //    {
            //        dr[0].ToString(),
            //        dr[1].ToString(),
            //        dr[2].ToString(),
            //        dr[3].ToString(),
            //        dr[5].ToString(),
            //        dr[6].ToString(),
            //        dr[7].ToString(),
            //        dr[20].ToString(),
                    
                    
                    

            //    }

            //    );
            //}

            CRV_Chofer.Visible = true;

            ReportChofer RImpre = new ReportChofer();

            RImpre.SetDataSource(dt);

            CRV_Chofer.ReportSource = RImpre;
        }
    }
}
