using System;
using System.Data;
using System.Windows.Forms;
using ClassConexion;

namespace Vista
{
    public partial class ActLab : Form
    {
        Conexion CS = new Conexion();

        Negocio.Muestra M = new Negocio.Muestra();

        public ActLab(DataTable table)
        {
            InitializeComponent();
            CargarDatos(table);
        }

        private void CargarDatos(DataTable table)
        {
            DataRow dr = table.Rows[0];

            LB_Id.Text = dr["Id"].ToString();
            TBCodMatPrima.Text = dr["Codigo"].ToString();
            TBCodEnsayo.Text = dr["Ensayo"].ToString();
            TBFechaRealiz.Text = dr["Fecha"].ToString();
            TbCantEntregada.Text = dr["Cantidad"].ToString();
            TBDescMatPrima.Text = dr["Nombre"].ToString();
            TB_Observaciones.Text = dr["Observaciones"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBCodEnsayo.Text = "";
            TbCantEntregada.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBCodEnsayo.Text == "" || TbCantEntregada.Text == "") throw new Exception("Falta completar datos de Ensayo o Cantidad");

                string OrderFecha = TBFechaRealiz.Text.Substring(6, 4) + TBFechaRealiz.Text.Substring(3, 2) + TBFechaRealiz.Text.Substring(0, 2);

                string consulta = "update Muestra set Ensayo2 = '" + TBCodEnsayo.Text +
                    "', Nombre2 = '" + TBDescMatPrima.Text + "', Fecha2 = '" + TBFechaRealiz.Text + "', OrdFecha2 = '" + OrderFecha + "',"
                    + "Cantidad2 = '" + TbCantEntregada.Text + "' ," + "Observaciones2 = '" + TB_Observaciones.Text + "' where Codigo = '" + LB_Id.Text + "'";

                M.ActualizarMuestra(consulta);

                MessageBox.Show("La muestra se actualizo con exito", "Actualizacion Muestra Laboratorio",
                MessageBoxButtons.OK, MessageBoxIcon.None);

                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
