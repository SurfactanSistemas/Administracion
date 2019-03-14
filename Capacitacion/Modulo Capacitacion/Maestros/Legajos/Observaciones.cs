using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Maestros.Legajos
{
    public partial class Observaciones : Form
    {
        public string ObservExt1;
        public string ObservExt2;
        public string ObservExt3;
        public string ObservExt4;
        public string ObservExt5;
        private string p;
        private string p_2;
        private string p_3;
        private string p_4;
        private string p_5;
        private string p_6;

        public Observaciones()
        {
            InitializeComponent();
        }

        public Observaciones(string p, string p_2, string p_3, string p_4, string p_5, string p_6)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
            this.p_6 = p_6;
            InitializeComponent();
        }

        private void Observaciones_Load(object sender, EventArgs e)
        {
            TB_ObservExt1.Text = p.Trim();
            TB_ObservExt2.Text = p_2.Trim();
            TB_ObservExt3.Text = p_3.Trim();
            TB_ObservExt4.Text = p_4.Trim();
            TB_ObservExt5.Text = p_5.Trim();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            ObservExt1 = TB_ObservExt1.Text;
            ObservExt2 = TB_ObservExt2.Text;
            ObservExt3 = TB_ObservExt3.Text;
            ObservExt4 = TB_ObservExt4.Text;
            ObservExt5 = TB_ObservExt5.Text;
            //MessageBox.Show("Se han guardado las observaciones correctamente", "Guardar Observaciones",
            //MessageBoxButtons.OK, MessageBoxIcon.None);
            Close();

        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_ObservExt1.Text = "";
            TB_ObservExt2.Text = "";
            TB_ObservExt3.Text = "";
            TB_ObservExt4.Text = "";
            TB_ObservExt5.Text = "";
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Observaciones_Shown(object sender, EventArgs e)
        {
            TB_ObservExt1.Focus();
        }
    }
}
