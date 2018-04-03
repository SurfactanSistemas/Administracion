using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.VersionLegajo
{
    public partial class IngVersLegajo : Form
    {
        LegajoVersion LV = new LegajoVersion();
        Perfil Per = new Perfil();
        PerfilVersion PerVer = new PerfilVersion();
        Legajo L = new Legajo();
        DataTable dtLegajos;
        bool Cargado = false;
        bool Limpiando = false;
        string Perfil;

        public IngVersLegajo()
        {
            InitializeComponent();
            CargarLegajos();
            Cargado = true;

        }

        private void CargarLegajos()
        {
            dtLegajos = L.ListarTodos();

            DataRow fila;
            fila = dtLegajos.NewRow();
            dtLegajos.Rows.InsertAt(fila, 0);


            CargarDescLegajos();
            CargarCodigosLegajos();
            CargarFechaIngreso();
        }

        private void CargarFechaIngreso()
        {
            TB_FechaIngAyuda.DataSource = dtLegajos;
            TB_FechaIngAyuda.DisplayMember = "FIngreso";
            TB_FechaIngAyuda.ValueMember = "Codigo";
            TB_FechaIngAyuda.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtLegajos.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["FIngreso"]));

            }

            TB_FechaIngAyuda.AutoCompleteCustomSource = stringCodArti;
            TB_FechaIngAyuda.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_FechaIngAyuda.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarDescLegajos()
        {
            TB_DescLegajo.DataSource = dtLegajos;
            TB_DescLegajo.DisplayMember = "Descripcion";
            TB_DescLegajo.ValueMember = "Codigo";
            TB_DescLegajo.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtLegajos.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescLegajo.AutoCompleteCustomSource = stringCodArti;
            TB_DescLegajo.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescLegajo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosLegajos()
        {
            TB_Codigo.DataSource = dtLegajos;
            TB_Codigo.DisplayMember = "Codigo";
            TB_Codigo.ValueMember = "Codigo";
            TB_Codigo.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtLegajos.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_Codigo.AutoCompleteCustomSource = stringCodArti;
            TB_Codigo.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Codigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void TB_Codigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Buscardatosdelegajo
                    if (TB_Codigo.Text == "" || TB_VersionLegajo.Text == "" || TB_FechaIng.Text == "") throw new Exception("No se puede asi macho");

                    LV = LV.BuscarUnaVersion(TB_Codigo.Text, TB_VersionLegajo.Text, TB_FechaIng.Text);

                    if (LV.Codigo == 0) throw new Exception("No se encontro registro con los datos ingresados.");

                    //Cargo los datos
                    CargarDatosABM();
                    CargarDatosPefil();
                    CargarTemas(LV.Temas);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void CargarTemas(List<Tema> list)
        {

            //DGV_Temas.DataSource = null;
            DGV_Temas.Rows.Clear();

            foreach (var item in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_Temas);
                row.Cells[0].Value = item.Codigo;
                row.Cells[1].Value = item.Descripcion;
                //necesario
                row.Cells[2].Value = item.Necesaria == 1 ? "X" : "";
                //deseable
                row.Cells[3].Value = item.Deseable == 1 ? "X" : "";
                //combo
                row.Cells[4].Value = ObtenerValor(item.EstaCurso);
                //observacion
                //row.Cells[5].Value = item.Observacion;
                row.Cells[5].Value = item.EstadoCurso;
                //row.Cells[5].Value = item.Estado;

                DGV_Temas.Rows.Add(row);
            }
        }

        private object ObtenerValor(int Esta)
        {
            //estados d ela primera pantalla
            switch (Esta)
            {
                case 0:
                    return "Cumple";
                case 1:
                    return "Cumple Act.";
                case 2:
                    return "Reforzar";
                case 3:
                    return "No Cumple";
                default:
                    return "";
            }
        }

        private void CargarDatosPefil()
        {
            //tnego el codigo de perfil y la version
            //Per = Per.BuscarUno(TB_CodPer.Text, TB_VerPer.Text);

            PerVer = PerVer.BuscarUno(Perfil, TB_VerPer.Text);

            TB_DescPer.Text = PerVer.Descripcion;
            TB_CodSec.Text = PerVer.sector.Codigo.ToString();
            TB_DescSector.Text = PerVer.sector.Descripcion;
            TB_Tareas1.Text = PerVer.TareasI;
            TB_Tareas2.Text = PerVer.TareasII;
            TB_Tareas3.Text = PerVer.TareasIII;
            TB_Primaria.Text = PerVer.DescriI;
            TB_ObservPrimaria.Text = PerVer.ObservaI;
            CB_NecPrim.Checked = PerVer.NecesariaI == 1 ? true : false;
            CB_DesPrim.Checked = PerVer.DeseableI == 1 ? true : false;

            TB_Secundaria.Text = PerVer.DescriII;
            TB_ObservSecundaria.Text = PerVer.ObservaII;
            CB_NecSec.Checked = PerVer.NecesariaII == 1 ? true : false;
            CB_DesSec.Checked = PerVer.DeseableII == 1 ? true : false;

            TB_Terciaria.Text = PerVer.DescriIII;
            TB_ObservTerciaria.Text = PerVer.ObservaIII;
            CB_NecTerc.Checked = PerVer.NecesariaIII == 1 ? true : false;
            CB_DesTerc.Checked = PerVer.DeseableIII == 1 ? true : false;

            TB_Idioma.Text = PerVer.DescriIV;
            TB_ObservIdioma.Text = PerVer.ObservaIV;
            CB_NecIdioma.Checked = PerVer.NecesariaIV == 1 ? true : false;
            CB_DesIdioma.Checked = PerVer.DeseableIV == 1 ? true : false;

            TB_Exp.Text = PerVer.DescriV;
            TB_ObservExp.Text = PerVer.ObservaV;
            CB_NecExp.Checked = PerVer.NecesariaV == 1 ? true : false;
            CB_DesExp.Checked = PerVer.DeseableV == 1 ? true : false;

            TB_CondFisica.Text = PerVer.Fisica;
            CB_NecCondFisica.Checked = PerVer.NecesariaVI == 1 ? true : false;
            CB_DesCondFisica.Checked = PerVer.DeseableVI == 1 ? true : false;

            TB_Otros1.Text = PerVer.OtrosI;
            CB_DesOtros1.Checked = PerVer.DeseableVII == 1 ? true : false;
            CB_NecOtros1.Checked = PerVer.NecesariaVII == 1 ? true : false;

            TB_Otros2.Text = PerVer.OtrosII;
            CB_DesOtros2.Checked = PerVer.DeseableVIII == 1 ? true : false;
            CB_NecOtros2.Checked = PerVer.NecesariaVIII == 1 ? true : false;

            TB_Equiv1.Text = PerVer.EquivalenciasI;
            TB_Equiv2.Text = PerVer.EquivalenciasII;
        }

        private void CargarDatosABM()
        {
            TB_Codigo.Text = LV.Codigo.ToString();
            //TB_DescLegajo.Text = LV.Descripcion;
            TB_FechaIng.Text = LV.FIngreso;
            //TB_FechaEgreso.Text = LV.FEgreso;
            int valorVersion = int.Parse(LV.Version);
            TB_VersionLegajo.Text = valorVersion.ToString();
            TB_FechaVersionI.Text = LV.FechaVersionI;
            DTP_FechaVersionII.Text = LV.FechaVersionII;
            TB_CodPer.Text = LV.Perfil.Codigo.ToString();
            TB_VerPer.Text = LV.Perfil.Version.ToString();

            //Falta los combos y observaciones
            TB_ObservPrimariaLeg.Text = LV.EstadoI;
            TB_ObservSecundariaLeg.Text = LV.EstadoII;
            TB_ObservTerciariaLeg.Text = LV.EstadoIII;
            TB_ObservIdiomaLeg.Text = LV.EstadoIV;
            TB_ObservExpLeg.Text = LV.EstadoV;
            TB_ObservCondFisicaLeg.Text = LV.EstadoVI;
            TB_Otros1Leg.Text = LV.EstadoVII;
            TB_Otros2Leg.Text = LV.EstadoVIII;
            TB_Equiv1Leg.Text = LV.EstadoIX;
            TB_Equiv2Leg.Text = LV.EstadoX;



            CB_EstPrim.SelectedItem = ObtenerValorCombo(LV.EstaI);
            CB_EstSec.SelectedItem = ObtenerValorCombo(LV.EstaII);
            CB_EstTerc.SelectedItem = ObtenerValorCombo(LV.EstaIII);
            CB_EstIdioma.SelectedItem = ObtenerValorCombo(LV.EstaIV);
            CB_EstExp.SelectedItem = ObtenerValorCombo(LV.EstaV);
            CB_EstCondFisic.SelectedItem = ObtenerValorCombo(LV.EstaVI);
            CB_EstOtros1.SelectedItem = ObtenerValorCombo(LV.EstaVII);
            CB_EstOtros2.SelectedItem = ObtenerValorCombo(LV.EstaVIII);
            CB_EstEquiv1.SelectedItem = ObtenerValorCombo(LV.EstaIX);
            CB_Estequiv2.SelectedItem = ObtenerValorCombo(LV.EstaX);
        }

        private object ObtenerValorCombo(string p)
        {
            switch (p)
            {
                case "0":
                    return "Cumple";
                case "1":
                    return "No Cumple";
                case "2":
                    return "No Aplica";
                default:
                    return "";
            }
        }

        private void TB_Codigo_TextChanged(object sender, EventArgs e)
        {
            string maxVersiones = LV.MaxVersiones(TB_Codigo.Text);
            TB_CantidadVersiones.Text = maxVersiones;
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TB_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cargado == true)
            {
                //TB_FechaIng.Text = TB_FechaIngAyuda.Text;
                //BuscarVersiones();
            }
            
        }

        private void BuscarVersiones()
        {
            try
            {
                
                    //Buscardatosdelegajo
                    if (TB_Codigo.Text == "" || TB_VersionLegajo.Text == "" || TB_FechaIng.Text == "") throw new Exception("No se puede asi macho");

                    LV = LV.BuscarUnaVersion(TB_Codigo.Text, TB_VersionLegajo.Text, TB_FechaIng.Text);

                    if (LV.Codigo == 0) throw new Exception("No se encontro registro con los datos ingresados.");

                    //Cargo los datos
                    CargarDatosABM();
                    CargarDatosPefil();
                    CargarTemas(LV.Temas);
                    BuscarCantVersiones();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BuscarCantVersiones()
        {
            //int Codigo = int.Parse(TB_Codigo.Text);
            TB_CantidadVersiones.Text = LV.MaxVersiones(TB_Codigo.Text);
            TB_CantidadVersiones.ReadOnly = true;

        }

        private void TB_Codigo_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void TB_DescLegajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cargado == true) && (Limpiando == false))
            {
                if (TB_Codigo.Text != "")
                {
                    LimpiarPantalla();
                }
                
                CompletarFechaIng();
                TB_VersionLegajo.Focus();
                string FechaEgreso = TB_Codigo.Text;
                
            }
            
        }

        private void LimpiarPantalla()
        {
            Limpiando = true;
            TB_VersionLegajo.Text = "";
            TB_CodPer.Text = "";
            TB_VerPer.Text = "";
            TB_DescPer.Text = "";
            TB_CodSec.Text = "";
            TB_DescSector.Text = "";
            TB_Tareas1.Text = "";
            TB_Tareas2.Text = "";
            TB_Tareas3.Text = "";
            TB_Primaria.Text = "";
            TB_ObservPrimaria.Text = "";
            CB_NecPrim.Checked = false;
            CB_DesPrim.Checked = false;
            CB_EstPrim.Text = "";
            TB_ObservPrimariaLeg.Text = "";
            TB_Secundaria.Text = "";
            TB_ObservSecundaria.Text = "";
            CB_NecSec.Checked = false;
            CB_DesSec.Checked = false;
            CB_EstSec.Text = "";
            TB_ObservSecundariaLeg.Text = "";
            TB_Terciaria.Text = "";
            TB_ObservTerciaria.Text = "";
            CB_NecTerc.Checked = false;
            CB_DesTerc.Checked = false;
            CB_EstTerc.Text = "";
            TB_ObservTerciariaLeg.Text = "";
            TB_Idioma.Text = "";
            TB_ObservIdioma.Text = "";
            CB_NecIdioma.Checked = false;
            CB_DesIdioma.Checked = false;
            CB_EstIdioma.Text = "";
            TB_ObservIdiomaLeg.Text = "";
            TB_Exp.Text = "";
            TB_ObservExp.Text = "";
            CB_NecExp.Checked = false;
            CB_DesExp.Checked = false;
            CB_EstExp.Text = "";
            TB_ObservExpLeg.Text = "";
            TB_CondFisica.Text = "";
            TB_ObservCondFisica.Text = "";
            CB_NecCondFisica.Checked = false;
            CB_DesCondFisica.Checked = false;
            CB_EstCondFisic.Text = "";
            TB_ObservCondFisicaLeg.Text = "";
            TB_Otros1.Text = "";
            CB_NecOtros1.Checked = false;
            CB_DesOtros1.Checked = false;
            CB_EstOtros1.Text = "";
            TB_Otros1Leg.Text = "";

            TB_Otros2.Text = "";
            CB_NecOtros2.Checked = false;
            CB_DesOtros2.Checked = false;
            CB_EstOtros2.Text = "";
            TB_Otros2Leg.Text = "";
            TB_Equiv1.Text = "";
            CB_EstEquiv1.Text = "";
            TB_Equiv1Leg.Text = "";
            TB_Equiv2.Text = "";
            CB_Estequiv2.Text = "";
            TB_Equiv2Leg.Text = "";
            DGV_Temas.Rows.Clear();
            Limpiando = false;
            TB_VersionLegajo.Focus();
        }

        private void CompletarFechaIng()
        {
            foreach (DataRow fila in dtLegajos.Rows)
            {
                if (fila[3].ToString() == TB_DescLegajo.Text)
                {
                    TB_FechaIng.Text = fila[4].ToString();
                    Perfil = fila[5].ToString();
                    TB_CantidadVersiones.Text = LV.MaxVersiones(fila[1].ToString());
                    TB_CantidadVersiones.ReadOnly = true;
                }
            }
            
        }

        private void TB_DescLegajo_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void TB_VersionLegajo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                
                if (TB_VersionLegajo.Text != "")
                {
                    Cargado = false;
                    BuscarVersiones();
                    Cargado = true;
                }
            }
            
        }

        private void IngVersLegajo_Load(object sender, EventArgs e)
        {

        }
    }
}
