using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.TemasPorLegajoConsolidado
{
    public partial class Inicio : Form
    {
        DataTable dtCursadas;
        Cursada Cur = new Cursada();
        Cronograma Cr = new Cronograma();
        DataTable dtInforme;
        string TipoImpre;

        DataTable dtCronograma;
        int DesdeTipo;
        int HastaTipo;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CB_Tipo.SelectedIndex = 0;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;

                 if (TB_AñoDesde.Text == "") throw new Exception("Debe ingresar el año inicial");

                if (TB_AñoHasta.Text == "") TB_AñoHasta.Text = TB_AñoDesde.Text;

                //if (CB_Tipo.Text == "") throw new Exception("Debe elegir el tipo de listado");

                int Desde = int.Parse(TB_AñoDesde.Text);
                int Hasta = int.Parse(TB_AñoHasta.Text);

                dtCursadas = Cur.ListarCursadaCons2(Desde, Hasta);

                progressBar1.Maximum = dtCursadas.Rows.Count;

                progressBar1.Visible = true;
                progressBar1.Step = 1;

                foreach (DataRow fila in dtCursadas.Rows)
                {
                    int Año = int.Parse(fila["Ano"].ToString());
                    int Legajo = int.Parse(fila["Legajo"].ToString());
                    int Curso = int.Parse(fila["Curso"].ToString());
                    string Clave = fila["Clave"].ToString();

                    //dtCronograma = Cr.BuscarUnoCursada(Año, Legajo, Curso);

                    int Valor = 0;

                    //if (dtCronograma.Rows.Count > 0 )
                    if (!Cr.ExisteEnCronograma(Año, Legajo, Curso)) Valor = 1;
                    
                    Cur.ModificarCursadaConsol(Valor, Clave);

                    progressBar1.Increment(1);
                }

                string FechaDesde = TB_AñoDesde.Text + "0101";
                string FechaHasta = TB_AñoHasta.Text + "1231";

                int Tipo = CB_Tipo.SelectedIndex;
                

                switch (Tipo)
                {
                        
                    case 1:
                        
                        dtInforme = Cur.ListarInformeCons(FechaDesde, FechaHasta, 0, 0);
                        break;

                    case 2:
                        
                        dtInforme = Cur.ListarInformeCons(FechaDesde, FechaHasta, 1, 1);
                        break;

                    case 0:

                        dtInforme = Cur.ListarInformeCons(FechaDesde, FechaHasta, 0, 9999);
                        break;
                }

                progressBar1.Visible = false;

                TipoImpre = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, TipoImpre);
                Impre.ShowDialog();
                
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void TB_AñoDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_AñoDesde.Text.Trim() != "")
                {
                    TB_AñoHasta.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_AñoDesde.Text = "";
            }
        }

        private void TB_AñoHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_AñoHasta.Text.Trim() != "")
                {
                    CB_Tipo.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_AñoHasta.Text = "";
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_AñoDesde.Focus();
        }
    }
}
