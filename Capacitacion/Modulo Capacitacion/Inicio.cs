using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modulo_Capacitacion.Maestros.Sectores;
using Modulo_Capacitacion.Maestros.Temas;
using Modulo_Capacitacion.Maestros.Cursos;
using Modulo_Capacitacion.Maestros.Perfiles;
using Modulo_Capacitacion.Maestros.Legajos;
using Modulo_Capacitacion.Maestros.VersionLegajo;
using Modulo_Capacitacion.Maestros.VersionPerfiles;
using Modulo_Capacitacion.Novedades;

namespace Modulo_Capacitacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngrePlanificacionAnual form = new IngrePlanificacionAnual();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void ingresoDeSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sectores_Inicio form = new Sectores_Inicio();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro que quieres salir?", "Confirmacion salir",
                                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ingresoDeTemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Temas_Inicio temasForm = new Temas_Inicio();
            temasForm.StartPosition = FormStartPosition.CenterScreen;
            temasForm.ShowDialog();
        }

        private void ingresoDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos_Inicio cursosForm = new Cursos_Inicio();
            cursosForm.StartPosition = FormStartPosition.CenterScreen;
            cursosForm.ShowDialog();
        }

        private void ingresoDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfiles_Inicio perfilesform = new Perfiles_Inicio();
            perfilesform.StartPosition = FormStartPosition.CenterScreen;
            perfilesform.ShowDialog();
        }

        private void ingresoDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legajos_Inicio form = new Legajos_Inicio();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void consultaDeVersionDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngVersLegajo form = new IngVersLegajo();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void consultaDeVersionDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngVersPerfil form = new IngVersPerfil();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void ingresoDeCornogramaDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngreDeCursosRealizados form = new IngreDeCursosRealizados();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void ingresoDeCursosRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoDeCursosRealizados form = new IngresoDeCursosRealizados();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            
        }

        private void listadoDeLegajosPorPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.Perfil.Inicio Ini = new Listados.Perfil.Inicio();
            
            Ini.StartPosition = FormStartPosition.CenterScreen;
            Ini.ShowDialog();
        }

        private void listadoDeTemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.Cursos.Inicio Ini = new Listados.Cursos.Inicio();
            Ini.ShowDialog();
        }

        private void listadosDeTemasRealizadosPorLegajosConsolidadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.TemasPorLegajoConsolidado.Inicio Ini = new Listados.TemasPorLegajoConsolidado.Inicio();
            Ini.ShowDialog();
        }

        private void listadoDeTemasRealizadosPorLegajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.TemasPorLegajo.Inicio Ini = new Listados.TemasPorLegajo.Inicio();
            Ini.ShowDialog();
        }

        private void perfilDelPuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.LegajosporPerfil.Inicio Ini = new Listados.LegajosporPerfil.Inicio();
            Ini.ShowDialog();
            
            
        }

        private void listadoDeCursosRealizadosPorTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CursosRealizadosporTemas.Inicio Ini = new Listados.CursosRealizadosporTemas.Inicio();
            Ini.ShowDialog();
        }

        private void listadoTemasRealizadosPorSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.TemasRealizadosPorSector.Inicio Ini = new Listados.TemasRealizadosPorSector.Inicio();
            Ini.ShowDialog();
        }

        private void listadoDeLegajosConNecesidadesPendientesPorICYNCVigenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.LegajosConNecesidadesPendientes.Inicio Ini = new Listados.LegajosConNecesidadesPendientes.Inicio();
            Ini.ShowDialog();
        }
    }
}
