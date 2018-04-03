using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.VersionPerfiles
{
    public partial class IngVersPerfil : Form
    {
        Perfil P = new Perfil();
        Perfil PerfilViejo = new Perfil();
        PerfilVersion PerVer = new PerfilVersion();
        Sector S = new Sector();
        Tema T = new Tema();
        Responsable R = new Responsable();
        Responsable R2 = new Responsable();
        public int indexRow = 0;
        private Perfil PerfilAModificar;
        public bool AModificar = false;
        DataTable dtPerfil;
        bool Cargado = false;
        DataTable dtVersiones;
        
        public IngVersPerfil()
        {
            InitializeComponent();
            CargarPerfiles();
            Cargado = true;
            //BuscarMaxCodigo();
            //TB_Fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void CargarPerfiles()
        {
            dtPerfil = P.ListarTodos();

            DataRow fila;
            fila = dtPerfil.NewRow();
            dtPerfil.Rows.InsertAt(fila, 0);


            CargarDescPerfil();
            CargarCodigosPerfil();
        }

        private void CargarDescPerfil()
        {
            TB_DecPerfil.DataSource = dtPerfil;
            TB_DecPerfil.DisplayMember = "Descripcion";
            TB_DecPerfil.ValueMember = "Codigo";
            TB_DecPerfil.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtPerfil.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DecPerfil.AutoCompleteCustomSource = stringCodArti;
            TB_DecPerfil.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DecPerfil.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosPerfil()
        {
            TB_Codigo.DataSource = dtPerfil;
            TB_Codigo.DisplayMember = "Codigo";
            TB_Codigo.ValueMember = "Codigo";
            TB_Codigo.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtPerfil.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_Codigo.AutoCompleteCustomSource = stringCodArti;
            TB_Codigo.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Codigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void IngVersPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        //public IngVersPerfil(Perfil PerfilAModificar)
        //{
        //    InitializeComponent();
        //    //Guardo el perfil
        //    PerfilViejo = PerfilAModificar;

        //    P = PerfilAModificar;
            
        //    AModificar = true;
        //    CargarTemas();

        //    CargarDatosPerfilABM();

        //}

        private void CargarDatosPerfilABM()
        {
            TB_DecPerfil.Text = PerVer.Descripcion;
            TB_Fecha.Text = PerVer.DesdeVigencia; //?
            DTP_FechaVigenciaII.Text = PerVer.HastaVigencia;

            TB_CodSec.Text = this.PerVer.sector.Codigo.ToString();
            TB_DescSector.Text = this.PerVer.sector.Descripcion;

            //TB_CodResp1.Text = this.PerVer.R.Codigo.ToString();
            //TB_DescResp1.Text = this.PerVer.R.Descripcion;

            //TB_CodResp2.Text = this.PerVer.R2.Codigo.ToString();
            //TB_DescResp2.Text = this.PerVer.R2.Descripcion;

            TB_Tareas1.Text = this.PerVer.TareasI;
            TB_Tareas2.Text = this.PerVer.TareasII;
            TB_Tareas3.Text = this.PerVer.TareasIII;

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

        private void CargarTemas()
        {
            DGV_Temas.Rows.Clear();

            foreach (var item in this.PerVer.Temas)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_Temas);
                row.Cells[0].Value = item.Codigo;
                row.Cells[1].Value = item.Descripcion;
                row.Cells[2].Value = item.Necesaria == 1 ? "X" : "";
                row.Cells[3].Value = item.Deseable == 1 ? "X" : "";

                DGV_Temas.Rows.Add(row);
            }
        }

        private void TB_Codigo_KeyDown(object sender, KeyEventArgs e)
        {
            BuscarVersion();
            
        }

        private void BuscarVersion()
        {
            try
            {
                
                    if (TB_Codigo.Text == "" || TB_Version.Text == "") throw new Exception("Se deben cargar los datos de CODIGO y VERISON");

                    PerVer = PerVer.BuscarUno(TB_Codigo.Text, TB_Version.Text);
                    CargarTemas();

                    CargarDatosPerfilABM();

                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {

        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IngVersPerfil_Load(object sender, EventArgs e)
        {

        }

        private void TB_Version_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarVersion();
            }
        }

        private void TB_DecPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cargado == true)
            {
                LimpiarPantalla();
                CargarCodigo();
                CargarVersion();
                
                TB_Version.Focus();
            }
            
        }

        private void LimpiarPantalla()
        {
            TB_CodSec.Text = "";
            TB_DescSector.Text = "";
            TB_Tareas1.Text = "";
            TB_Tareas2.Text = "";
            TB_Tareas3.Text = "";
            TB_Primaria.Text = "";
            TB_ObservPrimaria.Text = "";
            CB_NecPrim.Checked = false;
            CB_DesPrim.Checked = false;
            TB_Secundaria.Text = "";
            TB_ObservSecundaria.Text = "";
            CB_NecSec.Checked = false;
            CB_DesSec.Checked = false;
            TB_Terciaria.Text = "";
            TB_ObservTerciaria.Text = "";
            CB_NecTerc.Checked = false;
            CB_DesTerc.Checked = false;
            TB_Idioma.Text = "";
            TB_ObservIdioma.Text = "";
            CB_NecIdioma.Checked = false;
            CB_DesIdioma.Checked = false;
            TB_Exp.Text = "";
            TB_ObservExp.Text = "";
            CB_NecExp.Checked = false;
            CB_DesExp.Checked = false;
            TB_CondFisica.Text = "";
            TB_ObservCondFisica.Text = "";
            CB_NecCondFisica.Checked = false;
            CB_DesCondFisica.Checked = false;
            TB_Otros1.Text = "";
            CB_NecOtros1.Checked = false;
            CB_DesOtros1.Checked = false;
            TB_Otros2.Text = "";
            CB_NecOtros2.Checked = false;
            CB_DesOtros2.Checked = false;
            TB_Equiv1.Text = "";
            TB_Equiv2.Text = "";
            DGV_Temas.Rows.Clear();





        }

        private void CargarCodigo()
        {
            foreach (DataRow fila in dtPerfil.Rows)
            {
                if (fila[1].ToString() == TB_DecPerfil.Text)
                {
                    TB_Codigo.Text = fila[0].ToString();
                }
            }
        }

        private void CargarVersion()
        {
            int Codigo = int.Parse(TB_Codigo.Text);
            dtVersiones = PerVer.ListarVersion(Codigo);

            DataRow fila;
            fila = dtVersiones.NewRow();
            dtVersiones.Rows.InsertAt(fila, 0);

            Cargado = false;
            TB_Version.DataSource = dtVersiones;
            TB_Version.DisplayMember = "Version";
            TB_Version.ValueMember = "Version";
            TB_Version.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtVersiones.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Version"]));

            }

            TB_Version.AutoCompleteCustomSource = stringCodArti;
            TB_Version.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Version.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Cargado = true;
        }

        private void TB_DecPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Version.Focus();
            }
        }

        private void TB_Version_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cargado == true)
            {
                BuscarVersion();
            }
            
        }

        

        //private void BuscarMaxCodigo()
        //{
        //    TB_Codigo.Text = PerVer.ObtenerUltimoId().ToString();
        //}

        //private void tabPage2_Click(object sender, EventArgs e)
        //{

        //}

        //private void TB_CodSec_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        try
        //        {
        //            S = S.BuscarUno(TB_CodSec.Text);

        //            if (S.Codigo == 0) throw new Exception("No se encontro elemento con el codigo ingresado");

        //            TB_DescSector.Text = S.Descripcion;
        //            e.SuppressKeyPress = true;
        //            e.Handled = true;
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show(err.Message, "Error");
        //        }
        //    }
        //}

        //private void TB_CodTemas_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        T = T.BuscarUno(TB_CodTemas.Text);
        //        TB_DescTemas.Text = T.Descripcion;                
        //        e.SuppressKeyPress = true;
        //        e.Handled = true;
        //    }
        //}

        //private void BTAgregarTema_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (TB_CodTemas.Text == "" || TB_DescTemas.Text == "") throw new Exception("Se debe ingresar el tema");

        //        AgregarFila();
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message,"Error");
        //    }
        //}

        //private void AgregarFila()
        //{
        //    var index = DGV_Temas.Rows.Add();
        //    DGV_Temas.Rows[index].Cells["Curso"].Value = TB_CodTemas.Text;
        //    DGV_Temas.Rows[index].Cells["Descripcion"].Value = TB_DescTemas.Text;
        //    DGV_Temas.Rows[index].Cells["Necesaria"].Value = CB_Necesario.Checked ? "X" : "";
        //    DGV_Temas.Rows[index].Cells["Deseable"].Value = CB_Deseable.Checked ? "X" : "";

        //    LimpiarCamposTema();
        //}

        //private void LimpiarCamposTema()
        //{
        //    TB_CodTemas.Text = "";
        //    TB_DescTemas.Text = "";
        //    CB_Necesario.Checked = false;
        //    CB_Deseable.Checked = false;
        //}

        //private void TB_CodResp1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        try
        //        {
        //            R = R.BuscarUno(TB_CodResp1.Text);

        //            if (R.Codigo == 0) throw new Exception("No se encontro elemento con el codigo ingresado");

        //            TB_DescResp1.Text = R.Descripcion;
        //            e.SuppressKeyPress = true;
        //            e.Handled = true;
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show(err.Message, "Error");
        //        }
        //    }
        //}

        //private void TB_CodResp2_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        try
        //        {
        //            R2 = R2.BuscarUno(TB_CodResp2.Text);

        //            if (R2.Codigo == 0) throw new Exception("No se encontro elemento con el codigo ingresado");

        //            TB_DescResp2.Text = R2.Descripcion;
        //            e.SuppressKeyPress = true;
        //            e.Handled = true;
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show(err.Message, "Error");
        //        }
        //    }
        //}

        //private void BT_Salir_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void BT_LimpiarPant_Click(object sender, EventArgs e)
        //{
        //    if (!AModificar)
        //    {
        //        TB_DecPerfil.Text = "";
        //        TB_Fecha.Text = DateTime.Now.ToShortDateString();
        //        TB_Version.Text = "1";
        //        TB_CodSec.Text = "";
        //        TB_DescSector.Text = "";
        //        TB_CodResp1.Text = "";
        //        TB_DescResp1.Text = "";
        //        TB_CodResp2.Text = "";
        //        TB_DescResp2.Text = "";
        //        TB_Tareas1.Text = "";
        //        TB_Tareas2.Text = "";
        //        TB_Tareas3.Text = "";
        //        TB_Primaria.Text = "";
        //        TB_Secundaria.Text = "";
        //        TB_Terciaria.Text = "";
        //        TB_Idioma.Text = "";
        //        TB_ExPerVer.Text = "";
        //        TB_CondFisica.Text = "";
        //        TB_Otros1.Text = "";
        //        TB_Otros2.Text = "";
        //        TB_Equiv1.Text = "";
        //        TB_Equiv2.Text = "";
        //        TB_ObservCondFisica.Text = "";
        //        TB_ObservPrimaria.Text = "";
        //        TB_ObservSecundaria.Text = "";
        //        TB_ObservTerciaria.Text = "";
        //        TB_ObservIdioma.Text = "";
        //        TB_ObservExPerVer.Text = "";
        //        CB_DesPrim.Checked = false;
        //        CB_DesSec.Checked = false;
        //        CB_DesTerc.Checked = false;
        //        CB_DesIdioma.Checked = false;
        //        CB_DesExPerVer.Checked = false;
        //        CB_DesCondFisica.Checked = false;
        //        CB_DesOtros1.Checked = false;
        //        CB_DesOtros2.Checked = false;

        //        CB_NecPrim.Checked = false;

        //        CB_NecSec.Checked = false;
        //        CB_NecTerc.Checked = false;
        //        CB_NecIdioma.Checked = false;
        //        CB_NecExPerVer.Checked = false;
        //        CB_NecCondFisica.Checked = false;
        //        CB_NecOtros1.Checked = false;
        //        CB_NecOtros2.Checked = false;

        //        TB_CodTemas.Text = "";
        //        TB_DescTemas.Text = "";
        //        CB_Deseable.Checked = false;
        //        CB_Necesario.Checked = false;

        //        DGV_Temas.DataSource = null;
        //        DGV_Temas.Rows.Clear();
        //    }
        //}

        //private void BTModifTema_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (TB_CodTemas.Text == "" || TB_DescTemas.Text == "") { throw new Exception("No se puede modificar"); };

        //        DataGridViewRow nuevaRow = DGV_Temas.Rows[indexRow];

        //        nuevaRow.Cells[0].Value = TB_CodTemas.Text;
        //        nuevaRow.Cells[1].Value = TB_DescTemas.Text;
        //        nuevaRow.Cells[3].Value = CB_Deseable.Checked ? "X" : "";
        //        nuevaRow.Cells[2].Value = CB_Necesario.Checked ? "X" : "";

        //        LimpiarCamposTema();
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message,"Error");
        //    }
        //}

        //private void DGV_Temas_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //   indexRow = e.RowIndex;

        //   if (indexRow >= 0)
        //   {
        //       DataGridViewRow row = DGV_Temas.Rows[indexRow];

        //       TB_CodTemas.Text = row.Cells[0].Value.ToString();
        //       TB_DescTemas.Text = row.Cells[1].Value.ToString();
        //       CB_Necesario.Checked = row.Cells[2].Value.ToString() == "X" ? true : false;
        //       CB_Deseable.Checked = row.Cells[3].Value.ToString() == "X" ? true : false;
        //   }
            
        //}

        //private void BT_Guardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //VALIDO QUE ESTEN TODOS LOS DATOS
        //        ValidarDatosCargados();

        //        //Creo el objeto Perfil
        //        CargarDatosPerfil();

        //        if (AModificar)
        //        {
        //            CargarDatosPerfilVer();

        //            PerVer.Agregar();

        //            //Agrego el nuevo
        //            PerVer.Eliminar(PerVer.Codigo.ToString());
        //            PerVer.Agregar();
        //        }
        //        else 
        //        {
        //            //INSERTO EN LA BASE DE DATOS
        //            PerVer.Agregar();
        //        }
                

        //        this.Close();

        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "ERROR");
        //    }
        //}

        //private void CargarDatosPerfilVer()
        //{
        //    PerVer.Codigo = PerfilViejo.Codigo;
        //    PerVer.Descripcion = PerfilViejo.Descripcion;
        //    PerVer.DesdeVigencia = PerfilViejo.Vigencia;
        //    PerVer.HastaVigencia = TB_Fecha.Text;
        //    PerVer.Version = PerfilViejo.Version;
        //    PerVer.sector = PerfilViejo.sector;
        //    PerVer.Temas = PerfilViejo.Temas;
        //    PerVer.TareasI = PerfilViejo.TareasI;
        //    PerVer.TareasII = PerfilViejo.TareasII;
        //    PerVer.TareasIII = PerfilViejo.TareasIII;
        //    PerVer.OtrosI = PerfilViejo.OtrosI;
        //    PerVer.OtrosII = PerfilViejo.OtrosII;
        //    PerVer.EquivalenciasI = PerfilViejo.EquivalenciasI;
        //    PerVer.EquivalenciasII = PerfilViejo.EquivalenciasII;
        //    PerVer.DescriI = PerfilViejo.DescriI;
        //    PerVer.DescriII = PerfilViejo.DescriII;
        //    PerVer.DescriIII = PerfilViejo.DescriIII;
        //    PerVer.DescriIV = PerfilViejo.DescriIV;
        //    PerVer.DescriV = PerfilViejo.DescriV;
        //    PerVer.ObservaI = PerfilViejo.ObservaI;
        //    PerVer.ObservaII = PerfilViejo.ObservaII;
        //    PerVer.ObservaIII = PerfilViejo.ObservaIII;
        //    PerVer.ObservaIV = PerfilViejo.ObservaIV;
        //    PerVer.ObservaV = PerfilViejo.ObservaV;
        //    PerVer.DeseableI = PerfilViejo.DeseableI;
        //    PerVer.DeseableII = PerfilViejo.DeseableII;
        //    PerVer.DeseableIII = PerfilViejo.DeseableIII;
        //    PerVer.DeseableIV = PerfilViejo.DeseableIV;
        //    PerVer.DeseableV = PerfilViejo.DeseableV;
        //    PerVer.DeseableVI = PerfilViejo.DeseableVI;
        //    PerVer.DeseableVII = PerfilViejo.DeseableVII;
        //    PerVer.DeseableVIII = PerfilViejo.DeseableVIII;
        //    PerVer.NecesariaI = PerfilViejo.NecesariaI;
        //    PerVer.NecesariaII = PerfilViejo.NecesariaII;
        //    PerVer.NecesariaIII = PerfilViejo.NecesariaIII;
        //    PerVer.NecesariaIV = PerfilViejo.NecesariaIV;
        //    PerVer.NecesariaV = PerfilViejo.NecesariaV;
        //    PerVer.NecesariaVI = PerfilViejo.NecesariaVI;
        //    PerVer.NecesariaVII = PerfilViejo.NecesariaVII;
        //    PerVer.NecesariaVIII = PerfilViejo.NecesariaVIII;
        //    PerVer.Fisica = PerfilViejo.Fisica;
        //}

        //private void CargarDatosPerfil()
        //{
            
        //    P = new Perfil();
        //    PerVer.Codigo = int.Parse(TB_Codigo.Text);
        //    PerVer.Descripcion = TB_DecPerfil.Text;
        //    PerVer.Vigencia = TB_Fecha.Text;
        //    PerVer.Version = int.Parse(TB_Version.Text);

        //    PerVer.sector = S.Codigo == 0 ? CargarSector() : S ;

        //    //if (S.Codigo != 0)
        //    //{
        //    //    PerVer.sector = S;
        //    //}
        //    //else
        //    //{
        //    //    PerVer.sector = CargarSector();
        //    //}

        //    PerVer.R = R.Codigo == 0 ? CargarRes1() : R;
        //    PerVer.R2 = R2.Codigo == 0 ? CargarRes2() : R2;
        //    //PerVer.R = R;
        //    //PerVer.R2 = R2;
        //    PerVer.TareasI = TB_Tareas1.Text;
        //    PerVer.TareasII = TB_Tareas2.Text;
        //    PerVer.TareasIII = TB_Tareas3.Text;

        //    PerVer.DescriI = TB_Primaria.Text;
        //    PerVer.ObservaI = TB_ObservPrimaria.Text;
        //    PerVer.NecesariaI = CB_NecPrim.Checked ? 1 : 0;
        //    PerVer.DeseableI = CB_DesPrim.Checked ? 1 : 0;

        //    PerVer.DescriII = TB_Secundaria.Text;
        //    PerVer.ObservaII = TB_ObservSecundaria.Text;
        //    PerVer.NecesariaII = CB_NecSec.Checked ? 1 : 0;
        //    PerVer.DeseableII = CB_DesSec.Checked ? 1 : 0;

        //    PerVer.DescriIII = TB_Terciaria.Text;
        //    PerVer.ObservaIII = TB_ObservTerciaria.Text;
        //    PerVer.NecesariaIII = CB_NecTerc.Checked ? 1 : 0;
        //    PerVer.DeseableIII = CB_DesTerc.Checked ? 1 : 0;

        //    PerVer.DescriIV = TB_Idioma.Text;
        //    PerVer.ObservaIV = TB_ObservIdioma.Text;
        //    PerVer.NecesariaIV = CB_NecIdioma.Checked ? 1 : 0;
        //    PerVer.DeseableIV = CB_DesIdioma.Checked ? 1 : 0;

        //    PerVer.DescriV = TB_ExPerVer.Text;
        //    PerVer.ObservaV = TB_ObservExPerVer.Text;
        //    PerVer.NecesariaV = CB_NecExPerVer.Checked ? 1 : 0;
        //    PerVer.DeseableV = CB_DesExPerVer.Checked ? 1 : 0;

        //    PerVer.Fisica = TB_CondFisica.Text;
        //    PerVer.NecesariaVI = CB_NecCondFisica.Checked ? 1 : 0;
        //    PerVer.DeseableVI = CB_DesCondFisica.Checked ? 1 : 0;

        //    PerVer.OtrosI = TB_Otros1.Text;
        //    PerVer.DeseableVII = CB_DesOtros1.Checked ? 1 : 0;
        //    PerVer.NecesariaVII = CB_NecOtros1.Checked ? 1 : 0;

        //    PerVer.OtrosII = TB_Otros2.Text;
        //    PerVer.DeseableVIII = CB_DesOtros2.Checked ? 1 : 0;
        //    PerVer.NecesariaVIII = CB_NecOtros2.Checked ? 1 : 0;

        //    PerVer.EquivalenciasI = TB_Equiv1.Text;
        //    PerVer.EquivalenciasII = TB_Equiv2.Text;

        //    List<Tema> Temas = new List<Tema>();
        //    foreach (DataGridViewRow row in DGV_Temas.Rows)
        //    {
        //        Tema T = new Tema();
        //        T.Codigo = int.Parse(row.Cells[0].Value.ToString());
        //        T.Descripcion = row.Cells[1].Value.ToString();
        //        T.Necesaria = row.Cells[2].Value.ToString() == "X" ? 1 : 0;
        //        T.Deseable = row.Cells[3].Value.ToString() == "X" ? 1 : 0;

        //        Temas.Add(T);
        //    }
        //    PerVer.Temas = Temas;
        //}

        //private Responsable CargarRes1()
        //{
        //    Responsable Res = new Responsable();
        //    Res.Codigo = int.Parse(TB_CodResp1.Text);
        //    Res.Descripcion = TB_DescResp1.Text;
        //    return Res;
        //}

        //private Responsable CargarRes2()
        //{
        //    Responsable Res = new Responsable();
        //    Res.Codigo = int.Parse(TB_CodResp2.Text);
        //    Res.Descripcion = TB_DescResp2.Text;
        //    return Res;
        //}

        //private Sector CargarSector()
        //{
        //    Sector Sec= new Sector();
        //    Sec.Codigo = int.Parse(TB_CodSec.Text);
        //    Sec.Descripcion = TB_DescSector.Text;
        //    return Sec;
        //}

        //private void ValidarDatosCargados()
        //{
        //    if (TB_DecPerfil.Text == "") 
        //        throw new Exception("Se debe cargar la descripcion");
        //    if (TB_DescSector.Text == "" || TB_DescResp1.Text == "" || TB_DescResp2.Text == "") 
        //        throw new Exception("Se deben completar los datos de sector, reponsable");
        //    //if (TB_Tareas1.Text == "" || TB_Tareas2.Text == "" || TB_Tareas3.Text == "") 
        //    //    throw new Exception("Se deben completar los datos de tarea");
        //    if (TB_Tareas1.Text == "" ) throw new Exception("Se deben completar los datos de tarea");
        //    //if (TB_Primaria.Text == "" || TB_Secundaria.Text == "" || TB_Terciaria.Text == "" || TB_Idioma.Text == "" || 
        //    //    TB_ExPerVer.Text == "" || TB_CondFisica.Text == "") throw new Exception("Se deben cargar los datos de educacion");
        //    if (DGV_Temas.Rows.Count == 0) 
        //        throw new Exception("Se deben cargar temas");
        //}
    }
}
