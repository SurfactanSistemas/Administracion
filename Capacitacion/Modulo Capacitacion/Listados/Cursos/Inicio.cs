using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.Cursos
{
    public partial class Inicio : Form
    {
        Curso C = new Curso();
        DataTable dtInforme = new DataTable();
        string Tipo;

        
        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            ListarCursos();
            Tipo = "Pantalla";

            ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
            Impre.ShowDialog();
        }

        private void ListarCursos()
        {
            dtInforme.Clear();
            dtInforme = C.ListarTodosListado();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            ListarCursos();
            Tipo = "";

            ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
            Impre.ShowDialog();
        }
    }
}
