using System;
using System.Windows.Forms;
using Modulo_Capacitacion.Listados.Perfiles;
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
            form.Show(this);
        }

        private void ingresoDeSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sectores_Inicio form = new Sectores_Inicio {StartPosition = FormStartPosition.CenterScreen};
            form.Show(this);
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
            temasForm.Show(this);
        }

        private void ingresoDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos_Inicio cursosForm = new Cursos_Inicio {StartPosition = FormStartPosition.CenterScreen};
            cursosForm.Show();
        }

        private void ingresoDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfiles_Inicio perfilesform = new Perfiles_Inicio {StartPosition = FormStartPosition.CenterScreen};
            perfilesform.Show();
        }

        private void ingresoDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legajos_Inicio form = new Legajos_Inicio {StartPosition = FormStartPosition.CenterScreen};
            form.Show();
        }

        private void consultaDeVersionDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngVersLegajo form = new IngVersLegajo {StartPosition = FormStartPosition.CenterScreen};
            form.Show();
        }

        private void consultaDeVersionDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngVersPerfil form = new IngVersPerfil {StartPosition = FormStartPosition.CenterScreen};
            form.Show();
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
            form.Show();
            
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

        protected void _Abrir(Form Ini)
        {
            Ini.Show();
        }

        private void listadoDeTemasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.Cursos.Inicio());
        }

        private void listadoDeLegajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.Perfil.Inicio());
        }

        private void listadoPorLegajosPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.LegajosConNecesidadesPendientes.Inicio());
        }

        private void cursosPorLegajoConsolidadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.HorasCursadasPorLegajo.Inicio());
        }
        
        private void resumenDeCursosRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.InformeHorasRealizadasYProgramadas.Inicio());
        }

        private void planillaDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.PlanCapacitacionAnual.Inicio());
        }

        private void cronogramaPorSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.CronogramaPorSectorYTema.Inicio());
        }

        private void cronogramaPorTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.CronogramaPorTemaySector.Inicio());
        }

        private void planDeCapacitaciónAnualTentativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.PlanCapacitacionAnualTentativo.Inicio());
        }

        private void informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.InformedeCompetencias.Inicio());
        }

        private void todosLosPerfilesExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Inicio());
        }

        private void perfilDelPuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.LegajosporPerfil.Inicio());
        }

        private void resumidoPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.TemasRealizadosPorSector.Inicio());
        }

        private void abiertoPorPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.TemasPorLegajoConsolidado.Inicio());
        }

        private void temasNoRçealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.PlanilladeTemasnoProgramados.Inicio());
        }

        private void promedioDeCalificaciónDeCapacitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.PromediodeCalificacion.Inicio());
        }

        private void listadoDeCronogramaTentativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.PlanCapacitacionAnualTentativo.Listado());
        }

        private void listadoDeLegajosSinActualizarAFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Abrir(new Listados.ListadoLegajosAActualizarAFecha.ListadoLegajosActualizarAFecha());
        }
    }
}
