using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.TemasRealizadosPorSector
{
    public partial class Inicio : Form
    {
        Cursada C = new Cursada();
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
            CB_Tipo.SelectedIndex = 0;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                Tipo = "Pantalla";

                _PresentarReporte();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PresentarReporte()
        {
            if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el sector desde el que desea comenzar la busqueda");

            if (TB_Hasta.Text == "") TB_Hasta.Text = TB_Desde.Text;

            if (TB_Año.Text == "") throw new Exception("Se debe ingresar el Año");

            int Desd;
            int.TryParse(TB_Desde.Text, out Desd);
            int Hast;
            int.TryParse(TB_Hasta.Text, out Hast);
            int Año;
            int.TryParse(TB_Año.Text, out Año);
            int AñoDesde = int.Parse(Año.ToString() + "0101");
            int AñoHasta = int.Parse(Año.ToString() + "1231");

            progressBar1.Value = 0;

            Helper.PurgarOrdFechaCursadas();
            Helper.ActualizarTipoCursada(ref progressBar1);

            string WTipoCursada = "";

            if (CB_Tipo.SelectedIndex == 1)
            {
                WTipoCursada = "0";
            }
            else if (CB_Tipo.SelectedIndex == 2)
            {
                WTipoCursada = "1";
            }

            dtInforme = C.ListarCursoporSector(Desd, Hast, AñoDesde, AñoHasta, WTipoCursada);

            progressBar1.Visible = false;

            ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
            Impre.ShowDialog();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
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
                TB_Año.Focus();
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Tipo = "Impresion";

                _PresentarReporte();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }

    }
}
