using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.TemasPorLegajo
{
    public partial class Inicio : Form
    {
        Cursada Cu = new Cursada();
        DataTable dtCursadas;
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
            
            
        }

        

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el legajo desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el legajo hasta el que desea realizar la busqueda");
                
                if (TB_AñoDesde.Text == "") throw new Exception("Se debe ingresar el año desde el que desea comenzar la busqueda");

                if (TB_AñoHasta.Text == "") throw new Exception("Se debe ingresar el año hasta el que desea realizar la busqueda");

                if (CB_Tipo.Text == "") throw new Exception("Se debe elegir el tipo de informe");

                int LegDesd;
                int.TryParse(TB_Desde.Text, out LegDesd);
                int LegHast;
                int.TryParse(TB_Hasta.Text, out LegHast);
                int AñoDesd;
                int.TryParse(TB_AñoDesde.Text, out AñoDesd);
                AñoDesd = int.Parse(AñoDesd.ToString() + "0101");
                int AñoHast;
                int.TryParse(TB_AñoHasta.Text, out AñoHast);
                AñoHast = int.Parse(AñoHast.ToString() + "1231");

                dtCursadas = Cu.ListarPorLegajo(LegDesd, LegHast);

                dtCursadas.Columns.Add("NHoras", typeof(float));

                dtInforme = dtCursadas.Copy();

                dtInforme.Clear();

                


                foreach (DataRow fila in dtCursadas.Rows)
                {
                    DataRow filaHoras;
                    filaHoras = dtCursadas.NewRow();

                    //CONSULTO POR SI LA ORDEN FECHA TIENE ALGO
                    if (fila[8].ToString() != "  /  /    ")

                    {
                        int Fecha;
                        int.TryParse(fila[11].ToString(), out Fecha);
                        

                        //SI SE CUMPLE QUE LA FECHA ESTA EN ENTRE LA INGRESADA LO AÑADO A LA DTINFORME
                        if ((Fecha >= AñoDesd) && (Fecha <= AñoHast) )
                        {
                            fila["NHoras"] = float.Parse(fila[6].ToString());
                            dtInforme.ImportRow(fila);
                        }
                    }
                   
                }

                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();
            
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el legajo desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el legajo hasta el que desea realizar la busqueda");

                if (TB_AñoDesde.Text == "") throw new Exception("Se debe ingresar el año desde el que desea comenzar la busqueda");

                if (TB_AñoHasta.Text == "") throw new Exception("Se debe ingresar el año hasta el que desea realizar la busqueda");

                if (CB_Tipo.Text == "") throw new Exception("Se debe elegir el tipo de informe");

                int LegDesd;
                int.TryParse(TB_Desde.Text, out LegDesd);
                int LegHast;
                int.TryParse(TB_Hasta.Text, out LegHast);
                int AñoDesd;
                int.TryParse(TB_AñoDesde.Text, out AñoDesd);
                AñoDesd = int.Parse(AñoDesd.ToString() + "0101");
                int AñoHast;
                int.TryParse(TB_AñoHasta.Text, out AñoHast);
                AñoHast = int.Parse(AñoHast.ToString() + "1231");

                dtCursadas = Cu.ListarPorLegajo(LegDesd, LegHast);

                dtCursadas.Columns.Add("NHoras", typeof(float));

                dtInforme = dtCursadas.Copy();

                dtInforme.Clear();




                foreach (DataRow fila in dtCursadas.Rows)
                {
                    DataRow filaHoras;
                    filaHoras = dtCursadas.NewRow();

                    //CONSULTO POR SI LA ORDEN FECHA TIENE ALGO
                    if (fila[8].ToString() != "  /  /    ")
                    {
                        int Fecha;
                        int.TryParse(fila[11].ToString(), out Fecha);


                        //SI SE CUMPLE QUE LA FECHA ESTA EN ENTRE LA INGRESADA LO AÑADO A LA DTINFORME
                        if ((Fecha >= AñoDesd) && (Fecha <= AñoHast))
                        {
                            fila["NHoras"] = float.Parse(fila[6].ToString());
                            dtInforme.ImportRow(fila);
                        }
                    }

                }

                Tipo = "Impresion";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Hasta.Focus();
            }
        }

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_AñoDesde.Focus();
            }
        }

        private void TB_AñoDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_AñoHasta.Focus();
            }
        }

        private void TB_AñoHasta_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
