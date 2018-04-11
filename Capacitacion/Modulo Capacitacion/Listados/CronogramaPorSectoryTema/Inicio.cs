﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.CronogramaPorSectoryTema
{
    public partial class Inicio : Form
    {
        Cronograma C = new Cronograma();
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_DesdeSector.Text == "") throw new Exception("Se debe ingresar el Sector desde el cual comenzar la busqueda");

                if (TB_HastaSector.Text == "") TB_HastaSector.Text = TB_DesdeSector.Text;

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el Año");

                int SectorDesde = 0;

                int.TryParse(TB_DesdeSector.Text, out SectorDesde);

                int SectorHasta = 0;

                int.TryParse(TB_HastaSector.Text, out SectorHasta);

                int Año = 0;

                int.TryParse(TB_Año.Text, out Año);

                dtInforme = C.CronogramaSectorTema(Año, SectorDesde, SectorHasta);

                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo, Año);
                Impre.ShowDialog();


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_DesdeSector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_HastaSector.Text == "") TB_HastaSector.Text = TB_DesdeSector.Text;
                TB_HastaSector.Focus();
            }
        }

        private void TB_HastaSector_KeyDown(object sender, KeyEventArgs e)
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
                if (TB_DesdeSector.Text == "") throw new Exception("Se debe ingresar el Sector desde el cual comenzar la busqueda");

                if (TB_HastaSector.Text == "") throw new Exception("Se debe ingresar el Sector hasta el cual terminar la busqueda");

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el Año");

                int SectorDesde = 0;

                int.TryParse(TB_DesdeSector.Text, out SectorDesde);

                int SectorHasta = 0;

                int.TryParse(TB_HastaSector.Text, out SectorHasta);

                int Año = 0;

                int.TryParse(TB_Año.Text, out Año);

                dtInforme = C.CronogramaSectorTema(Año, SectorDesde, SectorHasta);

                Tipo = "Impresion";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo, Año);
                Impre.ShowDialog();


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_DesdeSector.Focus();
        }
    }
}
