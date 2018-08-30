using System;
using System.Windows.Forms;
using Modulo_Capacitacion.Listados.Perfil;
using Modulo_Capacitacion.Maestros.Cursos;
using Modulo_Capacitacion.Maestros.Legajos;
using Modulo_Capacitacion.Maestros.Perfiles;
using Modulo_Capacitacion.Maestros.Sectores;
using Modulo_Capacitacion.Maestros.Temas;
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
            IngrePlanificacionAnual form = new IngrePlanificacionAnual {StartPosition = FormStartPosition.CenterScreen};
            form.ShowDialog();
        }

        private void ingresoDeSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sectores_Inicio form = new Sectores_Inicio {StartPosition = FormStartPosition.CenterScreen};
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
            Temas_Inicio temasForm = new Temas_Inicio {StartPosition = FormStartPosition.CenterScreen};
            temasForm.ShowDialog();
        }

        private void ingresoDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos_Inicio cursosForm = new Cursos_Inicio {StartPosition = FormStartPosition.CenterScreen};
            cursosForm.ShowDialog();
        }

        private void ingresoDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfiles_Inicio perfilesform = new Perfiles_Inicio {StartPosition = FormStartPosition.CenterScreen};
            perfilesform.ShowDialog();
        }

        private void ingresoDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legajos_Inicio form = new Legajos_Inicio {StartPosition = FormStartPosition.CenterScreen};
            form.ShowDialog();
        }

        private void consultaDeVersionDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngVersLegajo form = new IngVersLegajo {StartPosition = FormStartPosition.CenterScreen};
            form.ShowDialog();
        }

        private void consultaDeVersionDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngVersPerfil form = new IngVersPerfil {StartPosition = FormStartPosition.CenterScreen};
            form.ShowDialog();
        }

        private void ingresoDeCornogramaDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngreDeCursosRealizados form = new IngreDeCursosRealizados {StartPosition = FormStartPosition.CenterScreen};
            form.Show();
        }

        private void ingresoDeCursosRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoDeCursosRealizados form = new IngresoDeCursosRealizados
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            form.ShowDialog();
            
        }

        private void listadoDeLegajosPorPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio Ini = new Inicio {StartPosition = FormStartPosition.CenterScreen};

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

        private void listadoDeCursosPendientesPorSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CursosPendientesPorSector.Inicio frm = new Listados.CursosPendientesPorSector.Inicio();
            frm.Show();
        }

        private void listadoDeCursosPorResponsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CursosPorResponsable.Inicio frm = new Listados.CursosPorResponsable.Inicio();
            frm.Show();
        }

        private void listadoDeTemasRealizadosYNoRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.TemasRealizadosyNoRealizados.Inicio frm = new Listados.TemasRealizadosyNoRealizados.Inicio();
            frm.Show();
        }

        private void listadoDeCronogramaPorSectorYTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CronogramaPorTemaySector.Inicio frm = new Listados.CronogramaPorTemaySector.Inicio();
            frm.Show();
        }

        private void informeDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.InformedeCompetencias.Inicio frm = new Listados.InformedeCompetencias.Inicio();
            frm.Show();
        }

        private void planDeCapacitaciónAnualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.PlanCapacitacionAnual.Inicio frm = new Listados.PlanCapacitacionAnual.Inicio();
            frm.Show();
        }

        private void planillasDeTemasNoProgramadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.PlanilladeTemasnoProgramados.Inicio frm =
                new Listados.PlanilladeTemasnoProgramados.Inicio();
            frm.Show();
        }

        private void listadoDeEvaluaciónDeTemasProgramadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.EvoluciondeTemasProgramados.Inicio frm = new Listados.EvoluciondeTemasProgramados.Inicio();
            frm.Show();
        }

        private void listadoDeHorasCursadasPorLegajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.HorasCursadasPorLegajo.Inicio frm = new Listados.HorasCursadasPorLegajo.Inicio();
            frm.Show();
        }

        private void listadoDePromedioDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.PromediodeCalificacion.Inicio frm = new Listados.PromediodeCalificacion.Inicio();
            frm.Show();
        }

        private void toolStripMenuNecesidadesCompetenciasPorSector_Click(object sender, EventArgs e)
        {
            Listados.InformedeCompetenciasNecesidadesPorSector.Inicio frm =
                new Listados.InformedeCompetenciasNecesidadesPorSector.Inicio();
            frm.Show();
        }

        private void actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizacionDeCompetenciasYNecesidadesDeCapacitacion frm =
                new ActualizacionDeCompetenciasYNecesidadesDeCapacitacion();
            frm.Show();
        }

        private void asignaciónDeCursosPorPerfilOSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarCursosPorPerfilYSector frm = new AsignarCursosPorPerfilYSector();
            frm.Show();
        }

        private void asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignacionTemasPorSectorPerfilYPlanta frm = new AsignacionTemasPorSectorPerfilYPlanta();
            frm.Show();
        }

        private void planDeCapacitaciónTentativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.PlanCapacitacionAnualTentativo.Inicio frm = new Listados.PlanCapacitacionAnualTentativo.Inicio();
            frm.Show();
        }

        private void listadoDeCronogramaPorSectorYTemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listados.CronogramaPorSectorYTema.Inicio frm = new Listados.CronogramaPorSectorYTema.Inicio();
            frm.Show();
        }
    }
}
