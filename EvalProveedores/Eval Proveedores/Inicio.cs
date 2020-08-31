using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using EvaluacionProvMPFarma;
using Eval_Proveedores.IngCamiones;
using Eval_Proveedores.IngChoferes;
using Eval_Proveedores.Listados.EvaSemActProve;
using Eval_Proveedores.Listados.ListadoEvaluacionProvMPFarma;
using Eval_Proveedores.Novedades;

namespace Eval_Proveedores
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            using (
                SqlConnection cnx =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
            }

            // Determinamos si se lo llama por linea de comandos.
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                VencimientosProximosEvaluaciones frm = new VencimientosProximosEvaluaciones(true);
                frm.ShowDialog(this);
                Close();
            }
        }

        private void ctiDeEvaluaciónSemestralDeProveedoresDeEnvasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActSemProvEnv Env = new ActSemProvEnv();
            Env.Show();
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void ingChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inicioChoferes Choferes = new inicioChoferes();
            Choferes.Show();
        }

        private void ingCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicioCamiones Camiones = new InicioCamiones();
            Camiones.Show();
        }

        private void listaDeEvaluacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicEvaluacion IniEva = new InicEvaluacion();
            IniEva.Show();
        }

        private void listadoDeCheckListDeInformesDeRecepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CheckListRecepcion.Inicio IniInforme = new Listados.CheckListRecepcion.Inicio();
            IniInforme.Show();
        }

        private void listadoDeEvaluaciónDeTransportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.ListaEvaTransp.Inicio IniEvaTransp = new Listados.ListaEvaTransp.Inicio();
            IniEvaTransp.Show();
        }

        private void listadoDeProveedoresPorRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.ProvRubro.Inicio InicioProvRubro = new Listados.ProvRubro.Inicio();
            InicioProvRubro.Show();
        }

        private void listadoDeVencimientoDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.VencCamiones.Inicio InicioVencCamion = new Listados.VencCamiones.Inicio();
            InicioVencCamion.Show();
        }

        private void listadoDeVencimientoDeChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.VencChoferes.Inicio InicioVencChofer = new Listados.VencChoferes.Inicio();
            InicioVencChofer.Show();
        }

        private void listadoDeEvaluaciónDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.EvaServicio.Inicio InicioEvaServ = new Listados.EvaServicio.Inicio();
            InicioEvaServ.Show();
        }

        private void actDeEvaluacionSemetralDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActSemProv ActSem = new ActSemProv();
            ActSem.Show();
        }

        private void consultaDeEvaluaciónSemestralActualDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniEvaSemActProve IniEva = new IniEvaSemActProve();
            IniEva.Show();
        }

        private void consultaDeEvalSemestralActualDeProveedoresDeEnvasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.EvaSemProveEnv.Inicio IniEv = new Listados.EvaSemProveEnv.Inicio();
            IniEv.Show();
        }

        private void listadoDeCheckListDeHojaDeRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.CheckListHojaRuta.Inicio Ini = new Listados.CheckListHojaRuta.Inicio();
            Ini.Show();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void evaluaciónDeProveedoresDeMateriaPrimaDeFarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvaluacionProveedorMateriaPrima frm = new EvaluacionProveedorMateriaPrima("", true);

            frm.Show(this);
        }

        private void actDeEvaluaciónSemestralDeProveedoresDeMateriaPrimaParaFarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizacionSemestralProvMPFarma frm = new ActualizacionSemestralProvMPFarma();
            frm.Show(this);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Util.Clases.Conexion.EmpresaDeTrabajo = "SurfactanSA";
        }

        private void listadoDeEvaluaciónDeProveedoresDeMateriaPrimaParaFarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEvaluacionesProveedoreMPFarma frm = new ListadoEvaluacionesProveedoreMPFarma();

            frm.Show(this);
        }

        private void listadoDeEvaluaciónDeProveedorDeMateriaPrimaParaFarmaEntreFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.ListadoProvMPFarma.Inicio frm = new Listados.ListadoProvMPFarma.Inicio();
            frm.Show(this);
        }

        private void evaluaciónDeProveedoresDeEnsayosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvaluacionesProveedoresEnsayos frm = new EvaluacionesProveedoresEnsayos();
            frm.Show(this);
        }

        private void previsiónDeVencimientosDeEvaluacionesDeProveedoresDeMateriaPrimaParaFarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VencimientosProximosEvaluaciones frm = new VencimientosProximosEvaluaciones();
            frm.Show(this);
        }
    }
}
