using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eval_Proveedores
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void evaluacionDeOtrosProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ctiDeEvaluaciónSemestralDeProveedoresDeEnvasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novedades.ActSemProvEnv Env = new Novedades.ActSemProvEnv();
            Env.ShowDialog();
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ingChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngChoferes.inicioChoferes Choferes = new IngChoferes.inicioChoferes();
            Choferes.ShowDialog();
        }

        private void ingCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngCamiones.InicioCamiones Camiones = new IngCamiones.InicioCamiones();
            Camiones.ShowDialog();
        }

        private void listaDeEvaluacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novedades.InicEvaluacion IniEva = new Novedades.InicEvaluacion();
            IniEva.ShowDialog();
        }

        private void listadoDeCheckListDeInformesDeRecepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CheckListRecepcion.Inicio IniInforme = new Listados.CheckListRecepcion.Inicio();
            IniInforme.ShowDialog();
        }

        private void listadoDeEvaluaciónDeTransportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.ListaEvaTransp.Inicio IniEvaTransp = new Listados.ListaEvaTransp.Inicio();
            IniEvaTransp.ShowDialog();
        }

        private void listadoDeProveedoresPorRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.ProvRubro.Inicio InicioProvRubro = new Listados.ProvRubro.Inicio();
            InicioProvRubro.ShowDialog();
        }

        private void listadoDeVencimientoDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.VencCamiones.Inicio InicioVencCamion = new Listados.VencCamiones.Inicio();
            InicioVencCamion.ShowDialog();
        }

        private void listadoDeVencimientoDeChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.VencChoferes.Inicio InicioVencChofer = new Listados.VencChoferes.Inicio();
            InicioVencChofer.ShowDialog();
        }

        private void listadoDeEvaluaciónDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.EvaServicio.Inicio InicioEvaServ = new Listados.EvaServicio.Inicio();
            InicioEvaServ.ShowDialog();
        }

        private void actDeEvaluacionSemetralDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novedades.ActSemProv ActSem = new Novedades.ActSemProv();
            ActSem.ShowDialog();
        }

        private void consultaDeEvaluaciónSemestralActualDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.EvaSemActProve.IniEvaSemActProve IniEva = new Listados.EvaSemActProve.IniEvaSemActProve();
            IniEva.ShowDialog();
        }

        private void consultaDeEvalSemestralActualDeProveedoresDeEnvasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.EvaSemProveEnv.Inicio IniEv = new Listados.EvaSemProveEnv.Inicio();
            IniEv.ShowDialog();
        }

        private void listadoDeCheckListDeHojaDeRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CheckListHojaRuta.Inicio Ini = new Listados.CheckListHojaRuta.Inicio();
            Ini.ShowDialog();
        }
    }
}
