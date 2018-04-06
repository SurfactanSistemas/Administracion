using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Modulo_Capacitacion.Reportes;

namespace Modulo_Capacitacion.Novedades
{
    public partial class IngreDeCursosRealizados : Form
    {
        Cronograma Cr = new Cronograma();
        CronogramaII Cr2 = new CronogramaII();
        bool Modificar = true;
        List<CronogramaII> CronogramasII;

        public IngreDeCursosRealizados()
        {
            InitializeComponent();
            CronogramasII = new List<CronogramaII>();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_Año.Text = "";
            //DGV_Cronograma.DataSource = null;

            //DGV_Cronograma.Rows.Clear();

            if (DGV_Cronograma.DataSource != null)
                ((DataTable)DGV_Cronograma.DataSource).Rows.Clear();
            TB_Año.Focus();
        }

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Buscar cronograma?
                if (TB_Año.Text == "") throw new Exception("Se deben cargar los datos del año");

                DGV_Cronograma.DataSource = Cr2.BuscarUnoPorAño(TB_Año.Text);

                if (DGV_Cronograma.Rows.Count == 0)
                {
                    //Busco los cursos asociados al legajo!!
                    Modificar = false;
                    DGV_Cronograma.DataSource = Cr.BuscarPorAño(TB_Año.Text);
                }
            }
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valido que est todo bien y armo el objeto
                ValidarDatosABM();
                CargarCronogramaII();
                //lo guarod si no s modificar

                if (Modificar)
                {
                    Cr2.Eliminar(TB_Año.Text);
                }
                //sino elimino el viejo  y cargo el nuevo

                foreach (var item in CronogramasII)
                {
                    item.Agregar();
                }

                BT_Limpiar.PerformClick();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void CargarCronogramaII()
        {
            

            foreach (DataGridViewRow item in DGV_Cronograma.Rows)
            {
                Cr2 = new CronogramaII();
                Cr2.Año = TB_Año.Text;
                Cr2.Curso = int.Parse(item.Cells[0].Value.ToString());
                Cr2.Descripcion = item.Cells[1].Value.ToString();
                Cr2.Personas = int.Parse(item.Cells[2].Value.ToString());
                Cr2.Horas = float.Parse(item.Cells[3].Value.ToString());
                Cr2.HorasRealizadas = float.Parse(item.Cells[4].Value.ToString());
                //Cr2.Resta = int.Parse(item.Cells[2].Value.ToString());
                Cr2.Mes1 = item.Cells[6].Value.ToString();
                Cr2.Mes2= item.Cells[7].Value.ToString();
                Cr2.Mes3 = item.Cells[8].Value.ToString();
                Cr2.Mes4 = item.Cells[9].Value.ToString();
                Cr2.Mes5 = item.Cells[10].Value.ToString();
                Cr2.Mes6 = item.Cells[11].Value.ToString();
                Cr2.Mes7 = item.Cells[12].Value.ToString();
                Cr2.Mes8 = item.Cells[13].Value.ToString();
                Cr2.Mes9 = item.Cells[14].Value.ToString();
                Cr2.Mes10 = item.Cells[15].Value.ToString();
                Cr2.Mes11= item.Cells[16].Value.ToString();
                Cr2.Mes12 = item.Cells[17].Value.ToString();
                CronogramasII.Add(Cr2);
            }
        }

        private void ValidarDatosABM()
        {
            if (TB_Año.Text == "") throw new Exception("Error falta dato de año");
            if (DGV_Cronograma.Rows.Count == 0) throw new Exception("No hay datos de cronogorama");
        }

        private void DGV_Cronograma_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            int curso = 0;
            if (indexRow >= 0)
            {
                DataGridViewRow row = DGV_Cronograma.Rows[indexRow];

                curso = int.Parse(row.Cells[0].Value.ToString());
            }

            Listados.VistaPrevia frm = new Listados.VistaPrevia();
            frm.CargarReporte(new wlistacursoplani(), "{Cronograma.Curso}=" + curso + " AND {Cronograma.Ano}=" + TB_Año.Text);

            frm.Show();

            ////aca llamo al form y le paso los paremetros
            //ListadoDeCursosRealizadosPorLegajo rpt = new ListadoDeCursosRealizadosPorLegajo(int.Parse(TB_Año.Text), curso);
            //rpt.StartPosition = FormStartPosition.CenterScreen;
            //rpt.WindowState = FormWindowState.Maximized;
            ////rpt.FormBorderStyle = FormBorderStyle.None;
            ////rpt.TopMost = true;
            //rpt.Show();
        }

        private void IngreDeCursosRealizados_Load(object sender, EventArgs e)
        {

        }
    }
}
