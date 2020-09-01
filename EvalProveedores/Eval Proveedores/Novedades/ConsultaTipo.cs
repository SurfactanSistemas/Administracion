using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Novedades
{
    public partial class ConsultaTipo : Form
    {
        int Tipo = 0;


        public ConsultaTipo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultaTipo_Load(object sender, EventArgs e)
        {
            CB_Calibracion.Checked = false;
            CB_Mant.Checked = false;
            CB_Otros.Checked = false;
            CB_Transp.Checked = false;
        }

        private void Bt_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((CB_Calibracion.Checked == false) && (CB_Mant.Checked == false) && (CB_Otros.Checked == false) && (CB_Transp.Checked == false)) throw new Exception("Se debe seleccionar un tipo de proveedor");

                if (CB_Calibracion.Checked == true)
                {
                    Tipo = 2;
                    IngEvalMantenimiento IngCal = new IngEvalMantenimiento(Tipo);
                    IngCal.ShowDialog();
                    Close();
                }
                if (CB_Mant.Checked == true)
                {
                    Tipo = 4;
                    IngEvalMantenimiento IngTrans = new IngEvalMantenimiento(Tipo);
                    IngTrans.ShowDialog();
                    Close();
                }

                if (CB_Otros.Checked == true)
                {

                    Tipo = 5;
                    IngEvalMantenimiento IngCal = new IngEvalMantenimiento(Tipo);
                    IngCal.ShowDialog();
                    Close();

                }
                if (CB_Transp.Checked == true)
                {

                    Tipo = 15;
                    IngEvalTransp IngTra = new IngEvalTransp(Tipo);
                    IngTra.ShowDialog();
                    Close();
                }


            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CB_Transp_CheckedChanged(object sender, EventArgs e)
        {
            CB_Calibracion.Checked = false;
            CB_Mant.Checked = false;
            CB_Otros.Checked = false;

        }

        private void CB_Calibracion_CheckedChanged(object sender, EventArgs e)
        {
            CB_Mant.Checked = false;
            CB_Otros.Checked = false;
            CB_Transp.Checked = false;
        }

        private void CB_Mant_CheckedChanged(object sender, EventArgs e)
        {
            CB_Calibracion.Checked = false;
            CB_Otros.Checked = false;
            CB_Transp.Checked = false;
        }

        private void CB_Otros_CheckedChanged(object sender, EventArgs e)
        {
            CB_Calibracion.Checked = false;
            CB_Transp.Checked = false;
            CB_Mant.Checked = false;
        }
    }
}
