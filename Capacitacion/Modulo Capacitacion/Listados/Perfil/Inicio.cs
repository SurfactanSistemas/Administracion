using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.Perfil
{
    
    public partial class Inicio : Form
    {
        //Negocio.Legajo L = new Negocio.Legajo();
        Negocio.Perfil P = new Negocio.Perfil();
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
                dtInforme =  P.ListarLegajosPorPerfil(Desd, Hast);

                


                
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
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el perfil desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el perfil hasta el que desea realizar la busqueda");

                int Desd;
                int.TryParse(TB_Desde.Text, out Desd);
                int Hast;
                int.TryParse(TB_Hasta.Text, out Hast);
                dtInforme = P.ListarLegajosPorPerfil(Desd, Hast);





                Tipo = "Imprimir";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Hasta.Focus();
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
