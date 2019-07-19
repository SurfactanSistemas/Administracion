using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Modulo_Capacitacion
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeSectoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeTemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDePerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeLegajosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeVersionDeLegajosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeVersionDePerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeCursosRealizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planDeCapacitaciónAnualTentativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listados2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maestrosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDePerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosLosPerfilesExistenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilDelPuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeTemasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeLegajosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.competenciasYNecesidadesDeCapacitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoPorLegajosPendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosPorLegajoConsolidadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosPorSectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumidoPorCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abiertoPorPlanillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.análisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temasNoRçealizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenDeCursosRealizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cronogramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planillaDeCapacitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cronogramaPorSectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cronogramaPorTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeCronogramaTentativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maestrosToolStripMenuItem,
            this.novedadesToolStripMenuItem,
            this.listados2ToolStripMenuItem,
            this.procesosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoDeSectoresToolStripMenuItem,
            this.ingresoDeTemasToolStripMenuItem,
            this.ingresoDeCursosToolStripMenuItem,
            this.ingresoDePerfilesToolStripMenuItem,
            this.ingresoDeLegajosToolStripMenuItem,
            this.consultaDeVersionDeLegajosToolStripMenuItem,
            this.consultaDeVersionDePerfilesToolStripMenuItem});
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.maestrosToolStripMenuItem.Text = "Maestros";
            // 
            // ingresoDeSectoresToolStripMenuItem
            // 
            this.ingresoDeSectoresToolStripMenuItem.Name = "ingresoDeSectoresToolStripMenuItem";
            this.ingresoDeSectoresToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ingresoDeSectoresToolStripMenuItem.Text = "Ingreso de Sectores";
            this.ingresoDeSectoresToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeSectoresToolStripMenuItem_Click);
            // 
            // ingresoDeTemasToolStripMenuItem
            // 
            this.ingresoDeTemasToolStripMenuItem.Name = "ingresoDeTemasToolStripMenuItem";
            this.ingresoDeTemasToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ingresoDeTemasToolStripMenuItem.Text = "Ingreso de Temas";
            this.ingresoDeTemasToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeTemasToolStripMenuItem_Click);
            // 
            // ingresoDeCursosToolStripMenuItem
            // 
            this.ingresoDeCursosToolStripMenuItem.Name = "ingresoDeCursosToolStripMenuItem";
            this.ingresoDeCursosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ingresoDeCursosToolStripMenuItem.Text = "Ingreso de Cursos";
            this.ingresoDeCursosToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeCursosToolStripMenuItem_Click);
            // 
            // ingresoDePerfilesToolStripMenuItem
            // 
            this.ingresoDePerfilesToolStripMenuItem.Name = "ingresoDePerfilesToolStripMenuItem";
            this.ingresoDePerfilesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ingresoDePerfilesToolStripMenuItem.Text = "Ingreso de Perfiles";
            this.ingresoDePerfilesToolStripMenuItem.Click += new System.EventHandler(this.ingresoDePerfilesToolStripMenuItem_Click);
            // 
            // ingresoDeLegajosToolStripMenuItem
            // 
            this.ingresoDeLegajosToolStripMenuItem.Name = "ingresoDeLegajosToolStripMenuItem";
            this.ingresoDeLegajosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ingresoDeLegajosToolStripMenuItem.Text = "Ingreso de Legajos";
            this.ingresoDeLegajosToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeLegajosToolStripMenuItem_Click);
            // 
            // consultaDeVersionDeLegajosToolStripMenuItem
            // 
            this.consultaDeVersionDeLegajosToolStripMenuItem.Name = "consultaDeVersionDeLegajosToolStripMenuItem";
            this.consultaDeVersionDeLegajosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.consultaDeVersionDeLegajosToolStripMenuItem.Text = "Consulta de Version de Legajos";
            this.consultaDeVersionDeLegajosToolStripMenuItem.Click += new System.EventHandler(this.consultaDeVersionDeLegajosToolStripMenuItem_Click);
            // 
            // consultaDeVersionDePerfilesToolStripMenuItem
            // 
            this.consultaDeVersionDePerfilesToolStripMenuItem.Name = "consultaDeVersionDePerfilesToolStripMenuItem";
            this.consultaDeVersionDePerfilesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.consultaDeVersionDePerfilesToolStripMenuItem.Text = "Consulta de Version de Perfiles";
            this.consultaDeVersionDePerfilesToolStripMenuItem.Click += new System.EventHandler(this.consultaDeVersionDePerfilesToolStripMenuItem_Click);
            // 
            // novedadesToolStripMenuItem
            // 
            this.novedadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem,
            this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem,
            this.ingresoDeCursosRealizadosToolStripMenuItem,
            this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem,
            this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem,
            this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem,
            this.planDeCapacitaciónAnualTentativoToolStripMenuItem});
            this.novedadesToolStripMenuItem.Name = "novedadesToolStripMenuItem";
            this.novedadesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.novedadesToolStripMenuItem.Text = "Novedades";
            // 
            // ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem
            // 
            this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem.Name = "ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem";
            this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem.Text = "Ingreso de Planificacion Anual de Capacitación por Legajo";
            this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem.Click += new System.EventHandler(this.ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem_Click);
            // 
            // ingresoDeCornogramaDeCapacitaciónToolStripMenuItem
            // 
            this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem.Name = "ingresoDeCornogramaDeCapacitaciónToolStripMenuItem";
            this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem.Text = "Ingreso de Cronograma de Capacitación";
            this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeCornogramaDeCapacitaciónToolStripMenuItem_Click);
            // 
            // ingresoDeCursosRealizadosToolStripMenuItem
            // 
            this.ingresoDeCursosRealizadosToolStripMenuItem.Name = "ingresoDeCursosRealizadosToolStripMenuItem";
            this.ingresoDeCursosRealizadosToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.ingresoDeCursosRealizadosToolStripMenuItem.Text = "Ingreso de Cursos Realizados";
            this.ingresoDeCursosRealizadosToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeCursosRealizadosToolStripMenuItem_Click);
            // 
            // actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem
            // 
            this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Name = "actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem";
            this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Text = "Actualizacion de Competencias y Necesidades de Capacitación";
            this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Click += new System.EventHandler(this.actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem_Click);
            // 
            // asignaciónDeCursosPorPerfilOSectorToolStripMenuItem
            // 
            this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem.Name = "asignaciónDeCursosPorPerfilOSectorToolStripMenuItem";
            this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem.Text = "Asignación de Cursos por Perfil, Sector o Tema";
            this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem.Click += new System.EventHandler(this.asignaciónDeCursosPorPerfilOSectorToolStripMenuItem_Click);
            // 
            // asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem
            // 
            this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem.Name = "asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem";
            this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem.Text = "Asignacion de Temas por Perfil, Sector y Planta";
            this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem.Click += new System.EventHandler(this.asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem_Click);
            // 
            // planDeCapacitaciónAnualTentativoToolStripMenuItem
            // 
            this.planDeCapacitaciónAnualTentativoToolStripMenuItem.Name = "planDeCapacitaciónAnualTentativoToolStripMenuItem";
            this.planDeCapacitaciónAnualTentativoToolStripMenuItem.Size = new System.Drawing.Size(406, 22);
            this.planDeCapacitaciónAnualTentativoToolStripMenuItem.Text = "Plan de Capacitación Anual (Tentativo)";
            this.planDeCapacitaciónAnualTentativoToolStripMenuItem.Click += new System.EventHandler(this.planDeCapacitaciónAnualTentativoToolStripMenuItem_Click);
            // 
            // listados2ToolStripMenuItem
            // 
            this.listados2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maestrosToolStripMenuItem1,
            this.competenciasYNecesidadesDeCapacitaciónToolStripMenuItem,
            this.cursosToolStripMenuItem,
            this.análisisToolStripMenuItem,
            this.cronogramaToolStripMenuItem});
            this.listados2ToolStripMenuItem.Name = "listados2ToolStripMenuItem";
            this.listados2ToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.listados2ToolStripMenuItem.Text = "Listados";
            // 
            // maestrosToolStripMenuItem1
            // 
            this.maestrosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDePerfilesToolStripMenuItem,
            this.listadoDeTemasToolStripMenuItem1,
            this.listadoDeLegajosToolStripMenuItem});
            this.maestrosToolStripMenuItem1.Name = "maestrosToolStripMenuItem1";
            this.maestrosToolStripMenuItem1.Size = new System.Drawing.Size(316, 22);
            this.maestrosToolStripMenuItem1.Text = "Maestros";
            // 
            // listadoDePerfilesToolStripMenuItem
            // 
            this.listadoDePerfilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todosLosPerfilesExistenteToolStripMenuItem,
            this.perfilDelPuestoToolStripMenuItem});
            this.listadoDePerfilesToolStripMenuItem.Name = "listadoDePerfilesToolStripMenuItem";
            this.listadoDePerfilesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.listadoDePerfilesToolStripMenuItem.Text = "Listado de Perfiles";
            // 
            // todosLosPerfilesExistenteToolStripMenuItem
            // 
            this.todosLosPerfilesExistenteToolStripMenuItem.Name = "todosLosPerfilesExistenteToolStripMenuItem";
            this.todosLosPerfilesExistenteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.todosLosPerfilesExistenteToolStripMenuItem.Text = "Perfiles Disponibles por Sector";
            this.todosLosPerfilesExistenteToolStripMenuItem.Click += new System.EventHandler(this.todosLosPerfilesExistenteToolStripMenuItem_Click);
            // 
            // perfilDelPuestoToolStripMenuItem
            // 
            this.perfilDelPuestoToolStripMenuItem.Name = "perfilDelPuestoToolStripMenuItem";
            this.perfilDelPuestoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.perfilDelPuestoToolStripMenuItem.Text = "Perfil del Puesto";
            this.perfilDelPuestoToolStripMenuItem.Click += new System.EventHandler(this.perfilDelPuestoToolStripMenuItem_Click);
            // 
            // listadoDeTemasToolStripMenuItem1
            // 
            this.listadoDeTemasToolStripMenuItem1.Name = "listadoDeTemasToolStripMenuItem1";
            this.listadoDeTemasToolStripMenuItem1.Size = new System.Drawing.Size(222, 22);
            this.listadoDeTemasToolStripMenuItem1.Text = "Listado de Temas";
            this.listadoDeTemasToolStripMenuItem1.Click += new System.EventHandler(this.listadoDeTemasToolStripMenuItem1_Click);
            // 
            // listadoDeLegajosToolStripMenuItem
            // 
            this.listadoDeLegajosToolStripMenuItem.Name = "listadoDeLegajosToolStripMenuItem";
            this.listadoDeLegajosToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.listadoDeLegajosToolStripMenuItem.Text = "Listado de Legajos por Perfil";
            this.listadoDeLegajosToolStripMenuItem.Click += new System.EventHandler(this.listadoDeLegajosToolStripMenuItem_Click);
            // 
            // competenciasYNecesidadesDeCapacitaciónToolStripMenuItem
            // 
            this.competenciasYNecesidadesDeCapacitaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem,
            this.listadoPorLegajosPendientesToolStripMenuItem});
            this.competenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Name = "competenciasYNecesidadesDeCapacitaciónToolStripMenuItem";
            this.competenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.competenciasYNecesidadesDeCapacitaciónToolStripMenuItem.Text = "Competencias y Necesidades de Capacitación";
            // 
            // informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem
            // 
            this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem.Name = "informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem";
            this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem.Text = "Informe de Competencia y Necesidad de Capacitación";
            this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem.Click += new System.EventHandler(this.informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem_Click);
            // 
            // listadoPorLegajosPendientesToolStripMenuItem
            // 
            this.listadoPorLegajosPendientesToolStripMenuItem.Name = "listadoPorLegajosPendientesToolStripMenuItem";
            this.listadoPorLegajosPendientesToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.listadoPorLegajosPendientesToolStripMenuItem.Text = "Listado Legajos con Necesidades Pendientes";
            this.listadoPorLegajosPendientesToolStripMenuItem.Click += new System.EventHandler(this.listadoPorLegajosPendientesToolStripMenuItem_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursosPorLegajoConsolidadosToolStripMenuItem,
            this.cursosPorSectorToolStripMenuItem});
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.cursosToolStripMenuItem.Text = "Cursos";
            // 
            // cursosPorLegajoConsolidadosToolStripMenuItem
            // 
            this.cursosPorLegajoConsolidadosToolStripMenuItem.Name = "cursosPorLegajoConsolidadosToolStripMenuItem";
            this.cursosPorLegajoConsolidadosToolStripMenuItem.Size = new System.Drawing.Size(374, 22);
            this.cursosPorLegajoConsolidadosToolStripMenuItem.Text = "Total de Horas Cursadas por Legajo ordenadas por Sector";
            this.cursosPorLegajoConsolidadosToolStripMenuItem.Click += new System.EventHandler(this.cursosPorLegajoConsolidadosToolStripMenuItem_Click);
            // 
            // cursosPorSectorToolStripMenuItem
            // 
            this.cursosPorSectorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resumidoPorCursoToolStripMenuItem,
            this.abiertoPorPlanillaToolStripMenuItem});
            this.cursosPorSectorToolStripMenuItem.Name = "cursosPorSectorToolStripMenuItem";
            this.cursosPorSectorToolStripMenuItem.Size = new System.Drawing.Size(374, 22);
            this.cursosPorSectorToolStripMenuItem.Text = "Detalle de Cursos Realizados (Por Legajo, Sector o Tema)";
            // 
            // resumidoPorCursoToolStripMenuItem
            // 
            this.resumidoPorCursoToolStripMenuItem.Name = "resumidoPorCursoToolStripMenuItem";
            this.resumidoPorCursoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.resumidoPorCursoToolStripMenuItem.Text = "Resumido por Curso";
            this.resumidoPorCursoToolStripMenuItem.Click += new System.EventHandler(this.resumidoPorCursoToolStripMenuItem_Click);
            // 
            // abiertoPorPlanillaToolStripMenuItem
            // 
            this.abiertoPorPlanillaToolStripMenuItem.Name = "abiertoPorPlanillaToolStripMenuItem";
            this.abiertoPorPlanillaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.abiertoPorPlanillaToolStripMenuItem.Text = "Abierto por Planilla";
            this.abiertoPorPlanillaToolStripMenuItem.Click += new System.EventHandler(this.abiertoPorPlanillaToolStripMenuItem_Click);
            // 
            // análisisToolStripMenuItem
            // 
            this.análisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temasNoRçealizadosToolStripMenuItem,
            this.resumenDeCursosRealizadosToolStripMenuItem,
            this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem,
            this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem});
            this.análisisToolStripMenuItem.Name = "análisisToolStripMenuItem";
            this.análisisToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.análisisToolStripMenuItem.Text = "Análisis";
            // 
            // temasNoRçealizadosToolStripMenuItem
            // 
            this.temasNoRçealizadosToolStripMenuItem.Name = "temasNoRçealizadosToolStripMenuItem";
            this.temasNoRçealizadosToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.temasNoRçealizadosToolStripMenuItem.Text = "Resumen Anual de Cursos No Programados";
            this.temasNoRçealizadosToolStripMenuItem.Click += new System.EventHandler(this.temasNoRçealizadosToolStripMenuItem_Click);
            // 
            // resumenDeCursosRealizadosToolStripMenuItem
            // 
            this.resumenDeCursosRealizadosToolStripMenuItem.Name = "resumenDeCursosRealizadosToolStripMenuItem";
            this.resumenDeCursosRealizadosToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.resumenDeCursosRealizadosToolStripMenuItem.Text = "Resúmen de Horas Realizadas y Programadas";
            this.resumenDeCursosRealizadosToolStripMenuItem.Click += new System.EventHandler(this.resumenDeCursosRealizadosToolStripMenuItem_Click);
            // 
            // promedioDeCalificaciónDeCapacitaciónToolStripMenuItem
            // 
            this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem.Name = "promedioDeCalificaciónDeCapacitaciónToolStripMenuItem";
            this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem.Text = "Promedio de Calificación de Capacitación";
            this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem.Click += new System.EventHandler(this.promedioDeCalificaciónDeCapacitaciónToolStripMenuItem_Click);
            // 
            // cronogramaToolStripMenuItem
            // 
            this.cronogramaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planillaDeCapacitaciónToolStripMenuItem,
            this.cronogramaPorSectorToolStripMenuItem,
            this.cronogramaPorTemaToolStripMenuItem,
            this.listadoDeCronogramaTentativoToolStripMenuItem});
            this.cronogramaToolStripMenuItem.Name = "cronogramaToolStripMenuItem";
            this.cronogramaToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.cronogramaToolStripMenuItem.Text = "Cronograma";
            // 
            // planillaDeCapacitaciónToolStripMenuItem
            // 
            this.planillaDeCapacitaciónToolStripMenuItem.Name = "planillaDeCapacitaciónToolStripMenuItem";
            this.planillaDeCapacitaciónToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.planillaDeCapacitaciónToolStripMenuItem.Text = "Planilla de Capacitación";
            this.planillaDeCapacitaciónToolStripMenuItem.Click += new System.EventHandler(this.planillaDeCapacitaciónToolStripMenuItem_Click);
            // 
            // cronogramaPorSectorToolStripMenuItem
            // 
            this.cronogramaPorSectorToolStripMenuItem.Name = "cronogramaPorSectorToolStripMenuItem";
            this.cronogramaPorSectorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.cronogramaPorSectorToolStripMenuItem.Text = "Cronograma por Sector";
            this.cronogramaPorSectorToolStripMenuItem.Click += new System.EventHandler(this.cronogramaPorSectorToolStripMenuItem_Click);
            // 
            // cronogramaPorTemaToolStripMenuItem
            // 
            this.cronogramaPorTemaToolStripMenuItem.Name = "cronogramaPorTemaToolStripMenuItem";
            this.cronogramaPorTemaToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.cronogramaPorTemaToolStripMenuItem.Text = "Cronograma por Tema";
            this.cronogramaPorTemaToolStripMenuItem.Click += new System.EventHandler(this.cronogramaPorTemaToolStripMenuItem_Click);
            // 
            // listadoDeCronogramaTentativoToolStripMenuItem
            // 
            this.listadoDeCronogramaTentativoToolStripMenuItem.Name = "listadoDeCronogramaTentativoToolStripMenuItem";
            this.listadoDeCronogramaTentativoToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.listadoDeCronogramaTentativoToolStripMenuItem.Text = "Listado de Cronograma Tentativo";
            this.listadoDeCronogramaTentativoToolStripMenuItem.Click += new System.EventHandler(this.listadoDeCronogramaTentativoToolStripMenuItem_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 40);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE CAPACITACIÓN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 538);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // listadoDeLegajosSinActualizarAFechaToolStripMenuItem
            // 
            this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem.Name = "listadoDeLegajosSinActualizarAFechaToolStripMenuItem";
            this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem.Text = "Listado de Legajos sin Actualizar a Fecha";
            this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem.Click += new System.EventHandler(this.listadoDeLegajosSinActualizarAFechaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem maestrosToolStripMenuItem;
        private ToolStripMenuItem ingresoDeSectoresToolStripMenuItem;
        private ToolStripMenuItem ingresoDeTemasToolStripMenuItem;
        private ToolStripMenuItem ingresoDeCursosToolStripMenuItem;
        private ToolStripMenuItem ingresoDePerfilesToolStripMenuItem;
        private ToolStripMenuItem ingresoDeLegajosToolStripMenuItem;
        private ToolStripMenuItem consultaDeVersionDeLegajosToolStripMenuItem;
        private ToolStripMenuItem consultaDeVersionDePerfilesToolStripMenuItem;
        private ToolStripMenuItem novedadesToolStripMenuItem;
        private ToolStripMenuItem ingresoDePlanificacionAnualDeCapacitacionPorLegajoToolStripMenuItem;
        private ToolStripMenuItem ingresoDeCornogramaDeCapacitaciónToolStripMenuItem;
        private ToolStripMenuItem ingresoDeCursosRealizadosToolStripMenuItem;
        private ToolStripMenuItem procesosToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Panel panel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripMenuItem actualizacionDeCompetenciasYNecesidadesDeCapacitaciónToolStripMenuItem;
        private ToolStripMenuItem asignaciónDeCursosPorPerfilOSectorToolStripMenuItem;
        private ToolStripMenuItem asignacionDeTemasPorPerfilSectorPlantaToolStripMenuItem;
        private ToolStripMenuItem listados2ToolStripMenuItem;
        private ToolStripMenuItem maestrosToolStripMenuItem1;
        private ToolStripMenuItem listadoDePerfilesToolStripMenuItem;
        private ToolStripMenuItem listadoDeTemasToolStripMenuItem1;
        private ToolStripMenuItem listadoDeLegajosToolStripMenuItem;
        private ToolStripMenuItem competenciasYNecesidadesDeCapacitaciónToolStripMenuItem;
        private ToolStripMenuItem listadoPorLegajosPendientesToolStripMenuItem;
        private ToolStripMenuItem cursosToolStripMenuItem;
        private ToolStripMenuItem análisisToolStripMenuItem;
        private ToolStripMenuItem cronogramaToolStripMenuItem;
        private ToolStripMenuItem cursosPorLegajoConsolidadosToolStripMenuItem;
        private ToolStripMenuItem cursosPorSectorToolStripMenuItem;
        private ToolStripMenuItem resumenDeCursosRealizadosToolStripMenuItem;
        private ToolStripMenuItem planillaDeCapacitaciónToolStripMenuItem;
        private ToolStripMenuItem cronogramaPorSectorToolStripMenuItem;
        private ToolStripMenuItem cronogramaPorTemaToolStripMenuItem;
        private ToolStripMenuItem planDeCapacitaciónAnualTentativoToolStripMenuItem;
        private ToolStripMenuItem informeDeCompetenciaYNecesidadDeCapacitaciónToolStripMenuItem;
        private ToolStripMenuItem todosLosPerfilesExistenteToolStripMenuItem;
        private ToolStripMenuItem perfilDelPuestoToolStripMenuItem;
        private ToolStripMenuItem resumidoPorCursoToolStripMenuItem;
        private ToolStripMenuItem abiertoPorPlanillaToolStripMenuItem;
        private ToolStripMenuItem temasNoRçealizadosToolStripMenuItem;
        private ToolStripMenuItem promedioDeCalificaciónDeCapacitaciónToolStripMenuItem;
        private ToolStripMenuItem listadoDeCronogramaTentativoToolStripMenuItem;
        private ToolStripMenuItem listadoDeLegajosSinActualizarAFechaToolStripMenuItem;
    }
}

