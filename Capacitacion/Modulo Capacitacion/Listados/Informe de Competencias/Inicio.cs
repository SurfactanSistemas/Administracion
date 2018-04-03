using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.Informe_de_Competencias
{
    public partial class Inicio : Form
    {
        Negocio.Legajo L = new Negocio.Legajo();
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
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el perfil desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el perfil hasta el que desea realizar la busqueda");

                int Desd;
                int.TryParse(TB_Desde.Text, out Desd);
                int Hast;
                int.TryParse(TB_Hasta.Text, out Hast);
                dtInforme = L.ListarLegajosdeCompetencias(Desd, Hast);





                Tipo = "Pantalla";

                //ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                //Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
