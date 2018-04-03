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

        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                 if (TB_AñoDesde.Text == "") throw new Exception("Debe ingresar el año inicial");

                 if (TB_AñoHasta.Text == "") throw new Exception("Debe ingresar el año final");

                 if (CB_Tipo.Text == "") throw new Exception("Debe elegir el tipo de listado");

                int Desde = int.Parse(TB_AñoDesde.Text);
                int Hasta = int.Parse(TB_AñoHasta.Text);
                dtCursadas = Cur.ListarCursadaCons(Desde, Hasta);

                foreach (DataRow fila in dtCursadas.Rows)
                {
                    int Año = int.Parse(fila[6].ToString());
                    int Legajo = int.Parse(fila[1].ToString());
                    int Curso = int.Parse(fila[0].ToString());
                    string Clave = fila[4].ToString();

                    dtCronograma = Cr.BuscarUnoCursada(Año, Legajo, Curso);

                    if (dtCronograma.Rows.Count > 0 )
                    {
                        int Valor = 0;
                        Cur.ModificarCursadaConsol(Valor, Clave);
                    }
                    else
                    {
                        int Valor = 1;
                        Cur.ModificarCursadaConsol(Valor, Clave);
                    }

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

                TipoImpre = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, TipoImpre);
                Impre.ShowDialog();
                    


            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error");
            }
        }
    }
}
