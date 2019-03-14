using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Perfiles
{
    public partial class AgModPerfil : Form
    {
        Legajo L = new Legajo();
        Perfil P = new Perfil();
        Perfil PerfilViejo = new Perfil();
        PerfilVersion PerVer = new PerfilVersion();
        Sector S = new Sector();
        Tema T = new Tema();
        Responsable R = new Responsable();
        Responsable R2 = new Responsable();
        public int indexRow;
        public bool AModificar;
        DataTable dtSectores;
        DataTable dtTemas;
        DataTable dtResponsable;
        DataTable dtResponsable2;
        DataTable dtTemasInicio;
        DataTable dtTemaEliminado = new DataTable();

        public AgModPerfil()
        {
            InitializeComponent();
            CargarSectores();
            CargarTemasIni();
            CargarREsponsables();
            BuscarMaxCodigo();
            TB_Fecha.Text = DateTime.Now.ToShortDateString();
        }

        public AgModPerfil(Perfil PerfilAModificar)
        {
            InitializeComponent();
            //Guardo el perfil
            PerfilViejo = PerfilAModificar;
            CargarSectores();
            CargarTemasIni();
            CargarREsponsables();
            P = PerfilAModificar;
            
            AModificar = true;
            CargarTemas();

            CargarDatosPerfilABM();

        }

        private void CargarDatosPerfilABM()
        {
            TB_Codigo.Text = P.Codigo.ToString();
            TB_DecPerfil.Text = P.Descripcion.Trim();
            TB_Fecha.Text = P.Vigencia;
            TB_Version.Text = (P.Version).ToString().Trim();

            TB_CodSec.Text = P.sector.Codigo.ToString().Trim();
            TB_DescSector.Text = P.sector.Descripcion.Trim();

            TB_CodResp1.Text = P.R.Codigo.ToString().Trim();
            TB_DescResp1.Text = P.R.Descripcion.Trim();

            TB_CodResp2.Text = P.R2.Codigo.ToString().Trim();
            TB_DescResp2.Text = P.R2.Descripcion.Trim();

            TB_Tareas1.Text = P.TareasI.Trim();
            TB_Tareas2.Text = P.TareasII.Trim();
            TB_Tareas3.Text = P.TareasIII.Trim();

            TB_Primaria.Text = P.DescriI.Trim();
            TB_ObservPrimaria.Text = P.ObservaI.Trim();
            CB_NecPrim.Checked = P.NecesariaI == 1;
            CB_DesPrim.Checked = P.DeseableI == 1;

            TB_Secundaria.Text = P.DescriII.Trim();
            TB_ObservSecundaria.Text = P.ObservaII.Trim();
            CB_NecSec.Checked = P.NecesariaII == 1;
            CB_DesSec.Checked = P.DeseableII == 1;

            TB_Terciaria.Text = P.DescriIII.Trim();
            TB_ObservTerciaria.Text = P.ObservaIII.Trim();
            CB_NecTerc.Checked = P.NecesariaIII == 1;
            CB_DesTerc.Checked = P.DeseableIII == 1;

            TB_Idioma.Text = P.DescriIV.Trim();
            TB_ObservIdioma.Text = P.ObservaIV.Trim();
            CB_NecIdioma.Checked = P.NecesariaIV == 1;
            CB_DesIdioma.Checked = P.DeseableIV == 1;

            TB_Exp.Text = P.DescriV.Trim();
            TB_ObservExp.Text = P.ObservaV.Trim();
            CB_NecExp.Checked = P.NecesariaV == 1;
            CB_DesExp.Checked = P.DeseableV == 1;

            TB_CondFisica.Text = P.Fisica.Trim();
            CB_NecCondFisica.Checked = P.NecesariaVI == 1;
            CB_DesCondFisica.Checked = P.DeseableVI == 1;

            TB_Otros1.Text = P.OtrosI.Trim();
            CB_DesOtros1.Checked = P.DeseableVII == 1;
            CB_NecOtros1.Checked = P.NecesariaVII == 1;

            TB_Otros2.Text = P.OtrosII.Trim();
            CB_DesOtros2.Checked = P.DeseableVIII == 1;
            CB_NecOtros2.Checked = P.NecesariaVIII == 1;

            TB_Equiv1.Text = P.EquivalenciasI.Trim();
            TB_Equiv2.Text = P.EquivalenciasII.Trim();
        }

        private void CargarTemas()
        {
            int Codigo = P.Codigo;

            P.ListarCursos(Codigo);

            dtTemasInicio = P.ListarCursos(Codigo);

            foreach (DataRow fila in dtTemasInicio.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_Temas);
                row.Cells[0].Value = fila[0].ToString();
                row.Cells[1].Value = fila[1].ToString();
                row.Cells[2].Value = fila[2].ToString();
                row.Cells[3].Value = fila[3].ToString();

                DGV_Temas.Rows.Add(row);
            }
            /*

            foreach (var item in this.P.Temas)
            {
                
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_Temas);
                row.Cells[0].Value = item.Codigo;
                row.Cells[1].Value = item.Descripcion;
                row.Cells[2].Value = item.Necesaria == 1 ? "X" : "";
                row.Cells[3].Value = item.Deseable == 1 ? "X" : "";

                DGV_Temas.Rows.Add(row);
            }*/
        }

        private void BuscarMaxCodigo()
        {
            TB_Codigo.Text = P.ObtenerUltimoId().ToString();
        }

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

        private void BTAgregarTema_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_CodTemas.Text == "" || TB_DescTemas.Text == "") throw new Exception("Se debe ingresar el tema");

                AgregarFila();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }

            TB_CodTemas.Focus();
        }

        private void AgregarFila()
        {
            var index = DGV_Temas.Rows.Add();
            DGV_Temas.Rows[index].Cells["Curso"].Value = TB_CodTemas.Text;
            DGV_Temas.Rows[index].Cells["Descripcion"].Value = TB_DescTemas.Text;
            DGV_Temas.Rows[index].Cells["Necesaria"].Value = CB_Necesario.Checked ? "X" : "";
            DGV_Temas.Rows[index].Cells["Deseable"].Value = CB_Deseable.Checked ? "X" : "";

            LimpiarCamposTema();
        }

        private void LimpiarCamposTema()
        {
            TB_CodTemas.Text = "";
            TB_DescTemas.Text = "";
            CB_Necesario.Checked = false;
            CB_Deseable.Checked = false;
        }

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

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            if (!AModificar)
            {
                TB_DecPerfil.Text = "";
                TB_Fecha.Text = DateTime.Now.ToShortDateString();
                TB_Version.Text = "1";
                TB_CodSec.Text = "";
                TB_DescSector.Text = "";
                TB_CodResp1.Text = "";
                TB_DescResp1.Text = "";
                TB_CodResp2.Text = "";
                TB_DescResp2.Text = "";
                TB_Tareas1.Text = "";
                TB_Tareas2.Text = "";
                TB_Tareas3.Text = "";
                TB_Primaria.Text = "";
                TB_Secundaria.Text = "";
                TB_Terciaria.Text = "";
                TB_Idioma.Text = "";
                TB_Exp.Text = "";
                TB_CondFisica.Text = "";
                TB_Otros1.Text = "";
                TB_Otros2.Text = "";
                TB_Equiv1.Text = "";
                TB_Equiv2.Text = "";
                TB_ObservCondFisica.Text = "";
                TB_ObservPrimaria.Text = "";
                TB_ObservSecundaria.Text = "";
                TB_ObservTerciaria.Text = "";
                TB_ObservIdioma.Text = "";
                TB_ObservExp.Text = "";
                CB_DesPrim.Checked = false;
                CB_DesSec.Checked = false;
                CB_DesTerc.Checked = false;
                CB_DesIdioma.Checked = false;
                CB_DesExp.Checked = false;
                CB_DesCondFisica.Checked = false;
                CB_DesOtros1.Checked = false;
                CB_DesOtros2.Checked = false;

                CB_NecPrim.Checked = false;

                CB_NecSec.Checked = false;
                CB_NecTerc.Checked = false;
                CB_NecIdioma.Checked = false;
                CB_NecExp.Checked = false;
                CB_NecCondFisica.Checked = false;
                CB_NecOtros1.Checked = false;
                CB_NecOtros2.Checked = false;

                TB_CodTemas.Text = "";
                TB_DescTemas.Text = "";
                CB_Deseable.Checked = false;
                CB_Necesario.Checked = false;

                DGV_Temas.DataSource = null;
                DGV_Temas.Rows.Clear();
            }
        }

        private void BTModifTema_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_CodTemas.Text == "" || TB_DescTemas.Text == "") { throw new Exception("No se puede modificar"); }

                DataGridViewRow nuevaRow = DGV_Temas.Rows[indexRow];

                nuevaRow.Cells[0].Value = TB_CodTemas.Text;
                nuevaRow.Cells[1].Value = TB_DescTemas.Text;
                nuevaRow.Cells[3].Value = CB_Deseable.Checked ? "X" : "";
                nuevaRow.Cells[2].Value = CB_Necesario.Checked ? "X" : "";

                LimpiarCamposTema();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }

            BTAgregarTema.Visible = true;
            BT_Eliminar.Visible = false;
            BTModifTema.Visible = false;
        }


        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            dtTemaEliminado.Clear();
            dtTemaEliminado.Columns.Add("Curso", typeof(string));
            foreach (DataGridViewRow fila in DGV_Temas.Rows)
            {
                if (fila.Cells[0].Value.ToString() == TB_CodTemas.Text)
                {
                    DataRow dr = dtTemaEliminado.NewRow();
                    dr[0] = fila.Cells[0].Value.ToString();
                    dtTemaEliminado.Rows.Add(dr);
                    DGV_Temas.Rows.Remove(fila);
                    LimpiarCamposTema();
                }
            }
            BTAgregarTema.Visible = true;
            BT_Eliminar.Visible = false;
            BTModifTema.Visible = false;
        }

        private void DGV_Temas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //VALIDO QUE ESTEN TODOS LOS DATOS
                ValidarDatosCargados();

                //Creo el objeto Perfil
                CargarDatosPerfil();

                if (AModificar)
                {
                    DialogResult Result = MessageBox.Show("¿Desea modificar la versión?", "Modificar Versión", MessageBoxButtons.YesNo);

                    if (Result == DialogResult.Yes)
                    {
                        CargarDatosPerfilVer();

                        PerVer.Agregar();

                        //Elimino el legajo
                        P.Eliminar(P.Codigo.ToString());

                        //COLOCO LA FECHA DEL DIA 
                        DateTime Hoy = DateTime.Today;
                        P.Vigencia = Hoy.ToString("d");

                        //SUMO UNO A VERSION
                        
                        P.Version = int.Parse(TB_Version.Text) + 1;

                        P.Agregar();


                        //OJO ACA SE MOFDIFICAN TODOS LOS LEGAJOS QUE TENGAN EL PERFIL Y LA VERSION 
                        // MODIFICADA. SE TOMA EL Nº DE PERFIL Y LA VERSION.

                        L.ActualizarPerfil(PerfilViejo.Codigo, PerfilViejo.Version);

                        

                        MessageBox.Show("Se ha modificado el perfil", "Modificar Perfil",
                        MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    else if (Result == DialogResult.No)
                    {
                        DataTable dtTemasModif = new DataTable();
                        dtTemasModif.Columns.Add("NumCurso", typeof(string));
                        dtTemasModif.Columns.Add("DescCurso", typeof(string));
                        dtTemasModif.Columns.Add("Necesario", typeof(string));
                        dtTemasModif.Columns.Add("Deseable", typeof(string));
                        dtTemasModif.Columns.Add("Agregar", typeof(string));

                        foreach (DataGridViewRow Row in DGV_Temas.Rows)
                        {
                            DataRow fila = dtTemasModif.NewRow();
                            fila["NumCurso"] = Row.Cells[0].Value.ToString();
                            fila["DescCurso"] = Row.Cells[1].Value.ToString();
                            fila["Necesario"] = Row.Cells[2].Value.ToString();
                            fila["Deseable"] = Row.Cells[3].Value.ToString();
                            fila["Agregar"] = 1;

                            dtTemasModif.Rows.Add(fila);
                        }
                        //int contador = 0;
                        foreach (DataRow filaini in dtTemasInicio.Rows)
                        {
                            
                            

                            foreach (DataRow filamod in dtTemasModif.Rows)
                            {
                                if (filaini[1].ToString() == filamod[1].ToString())
                                {
                                    filamod["Agregar"] = 0;
                                    break;
                                } 
                                
                                
                            }
                            
                        }

                        P.ModificarN(dtTemasModif, dtTemaEliminado);

                        MessageBox.Show("Se ha modificado el perfil sin cambiar la versión", "Modificar Perfil",
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                    
                    
                }
                else 
                {
                    //INSERTO EN LA BASE DE DATOS
                    P.Agregar();

                    MessageBox.Show("Se ha agragado el perfil", "Agregar Perfil",
                      MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                

                Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR");
            }
        }

        

        private void CargarDatosPerfilVer()
        {
            PerVer.Codigo = PerfilViejo.Codigo;
            PerVer.Descripcion = PerfilViejo.Descripcion;
            PerVer.DesdeVigencia = PerfilViejo.Vigencia;
            //COLOCO LA FECHA DEL DIA QUE SE ESTA MODIFICANDO EL NUEVO PERFIL
            DateTime Hoy = DateTime.Today;
            PerVer.HastaVigencia = Hoy.ToString("d");

            PerVer.Version = PerfilViejo.Version;
            PerVer.sector = PerfilViejo.sector;
            PerVer.Temas = PerfilViejo.Temas;
            PerVer.TareasI = PerfilViejo.TareasI;
            PerVer.TareasII = PerfilViejo.TareasII;
            PerVer.TareasIII = PerfilViejo.TareasIII;
            PerVer.OtrosI = PerfilViejo.OtrosI;
            PerVer.OtrosII = PerfilViejo.OtrosII;
            PerVer.EquivalenciasI = PerfilViejo.EquivalenciasI;
            PerVer.EquivalenciasII = PerfilViejo.EquivalenciasII;
            PerVer.DescriI = PerfilViejo.DescriI;
            PerVer.DescriII = PerfilViejo.DescriII;
            PerVer.DescriIII = PerfilViejo.DescriIII;
            PerVer.DescriIV = PerfilViejo.DescriIV;
            PerVer.DescriV = PerfilViejo.DescriV;
            PerVer.ObservaI = PerfilViejo.ObservaI;
            PerVer.ObservaII = PerfilViejo.ObservaII;
            PerVer.ObservaIII = PerfilViejo.ObservaIII;
            PerVer.ObservaIV = PerfilViejo.ObservaIV;
            PerVer.ObservaV = PerfilViejo.ObservaV;
            PerVer.DeseableI = PerfilViejo.DeseableI;
            PerVer.DeseableII = PerfilViejo.DeseableII;
            PerVer.DeseableIII = PerfilViejo.DeseableIII;
            PerVer.DeseableIV = PerfilViejo.DeseableIV;
            PerVer.DeseableV = PerfilViejo.DeseableV;
            PerVer.DeseableVI = PerfilViejo.DeseableVI;
            PerVer.DeseableVII = PerfilViejo.DeseableVII;
            PerVer.DeseableVIII = PerfilViejo.DeseableVIII;
            PerVer.NecesariaI = PerfilViejo.NecesariaI;
            PerVer.NecesariaII = PerfilViejo.NecesariaII;
            PerVer.NecesariaIII = PerfilViejo.NecesariaIII;
            PerVer.NecesariaIV = PerfilViejo.NecesariaIV;
            PerVer.NecesariaV = PerfilViejo.NecesariaV;
            PerVer.NecesariaVI = PerfilViejo.NecesariaVI;
            PerVer.NecesariaVII = PerfilViejo.NecesariaVII;
            PerVer.NecesariaVIII = PerfilViejo.NecesariaVIII;
            PerVer.Fisica = PerfilViejo.Fisica;
        }

        private void CargarDatosPerfil()
        {

            P = new Perfil
            {
                Codigo = int.Parse(TB_Codigo.Text),
                Descripcion = TB_DecPerfil.Text.Trim(),
                Vigencia = TB_Fecha.Text,
                Version = int.Parse(TB_Version.Text),
                sector = S.Codigo == 0 ? CargarSector() : S,
                R = R.Codigo == 0 ? CargarRes1() : R,
                R2 = R2.Codigo == 0 ? CargarRes2() : R2,
                TareasI = TB_Tareas1.Text.Trim(),
                TareasII = TB_Tareas2.Text.Trim(),
                TareasIII = TB_Tareas3.Text.Trim(),
                DescriI = TB_Primaria.Text.Trim(),
                ObservaI = TB_ObservPrimaria.Text.Trim(),
                NecesariaI = CB_NecPrim.Checked ? 1 : 0,
                DeseableI = CB_DesPrim.Checked ? 1 : 0,
                DescriII = TB_Secundaria.Text.Trim(),
                ObservaII = TB_ObservSecundaria.Text.Trim(),
                NecesariaII = CB_NecSec.Checked ? 1 : 0,
                DeseableII = CB_DesSec.Checked ? 1 : 0,
                DescriIII = TB_Terciaria.Text.Trim(),
                ObservaIII = TB_ObservTerciaria.Text.Trim(),
                NecesariaIII = CB_NecTerc.Checked ? 1 : 0,
                DeseableIII = CB_DesTerc.Checked ? 1 : 0,
                DescriIV = TB_Idioma.Text.Trim(),
                ObservaIV = TB_ObservIdioma.Text.Trim(),
                NecesariaIV = CB_NecIdioma.Checked ? 1 : 0,
                DeseableIV = CB_DesIdioma.Checked ? 1 : 0,
                DescriV = TB_Exp.Text.Trim(),
                ObservaV = TB_ObservExp.Text.Trim(),
                NecesariaV = CB_NecExp.Checked ? 1 : 0,
                DeseableV = CB_DesExp.Checked ? 1 : 0,
                Fisica = TB_CondFisica.Text.Trim(),
                NecesariaVI = CB_NecCondFisica.Checked ? 1 : 0,
                DeseableVI = CB_DesCondFisica.Checked ? 1 : 0,
                OtrosI = TB_Otros1.Text.Trim(),
                DeseableVII = CB_DesOtros1.Checked ? 1 : 0,
                NecesariaVII = CB_NecOtros1.Checked ? 1 : 0,
                OtrosII = TB_Otros2.Text.Trim(),
                DeseableVIII = CB_DesOtros2.Checked ? 1 : 0,
                NecesariaVIII = CB_NecOtros2.Checked ? 1 : 0,
                EquivalenciasI = TB_Equiv1.Text.Trim(),
                EquivalenciasII = TB_Equiv2.Text.Trim()
            };


            //if (S.Codigo != 0)
            //{
            //    P.sector = S;
            //}
            //else
            //{
            //    P.sector = CargarSector();
            //}

            //P.R = R;
            //P.R2 = R2;










            List<Tema> Temas = new List<Tema>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (DataGridViewRow row in DGV_Temas.Rows)
            {
                Tema _Tema = new Tema
                {
                    Codigo = int.Parse(row.Cells[0].Value.ToString()),
                    Descripcion = row.Cells[1].Value.ToString(),
                    Necesaria = row.Cells[2].Value.ToString() == "X" ? 1 : 0,
                    Deseable = row.Cells[3].Value.ToString() == "X" ? 1 : 0
                };

                Temas.Add(_Tema);
            }
            P.Temas = Temas;
        }

        private Responsable CargarRes1()
        {
            Responsable Res = new Responsable
            {
                Codigo = int.Parse(TB_CodResp1.Text),
                Descripcion = TB_DescResp1.Text
            };
            return Res;
        }

        private Responsable CargarRes2()
        {
            Responsable Res = new Responsable
            {
                Codigo = int.Parse(TB_CodResp2.Text),
                Descripcion = TB_DescResp2.Text
            };
            return Res;
        }

        private Sector CargarSector()
        {
            Sector Sec = new Sector
            {
                Codigo = int.Parse(TB_CodSec.Text),
                Descripcion = TB_DescSector.Text
            };
            return Sec;
        }

        private void ValidarDatosCargados()
        {
            if (TB_DecPerfil.Text == "") 
                throw new Exception("Se debe cargar la descripcion");
            if (TB_DescSector.Text == "" || TB_DescResp1.Text == "" || TB_DescResp2.Text == "") 
                throw new Exception("Se deben completar los datos de sector, reponsable");
            //if (TB_Tareas1.Text == "" || TB_Tareas2.Text == "" || TB_Tareas3.Text == "") 
            //    throw new Exception("Se deben completar los datos de tarea");
            if (TB_Tareas1.Text == "" ) throw new Exception("Se deben completar los datos de tarea");
            //if (TB_Primaria.Text == "" || TB_Secundaria.Text == "" || TB_Terciaria.Text == "" || TB_Idioma.Text == "" || 
            //    TB_Exp.Text == "" || TB_CondFisica.Text == "") throw new Exception("Se deben cargar los datos de educacion");
            if (DGV_Temas.Rows.Count == 0) 
                throw new Exception("Se deben cargar temas");
        }

        private void AgModPerfil_Load(object sender, EventArgs e)
        {
            
            TB_DecPerfil.Focus();
        }

        private void CargarTemasIni()
        {
            dtTemas = T.ListarTemas();

            var fila = dtTemas.NewRow();
            dtTemas.Rows.InsertAt(fila, 0);


            CargarDescTemas();
            CargarCodigosTemas();
        }

        private void CargarDescTemas()
        {
            TB_DescTemas.DataSource = dtTemas;
            TB_DescTemas.DisplayMember = "Descripcion";
            TB_DescTemas.ValueMember = "Curso";
            TB_DescTemas.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTemas.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescTemas.AutoCompleteCustomSource = stringCodArti;
            TB_DescTemas.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescTemas.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosTemas()
        {
            TB_CodTemas.DataSource = dtTemas;
            TB_CodTemas.DisplayMember = "Curso";
            TB_CodTemas.ValueMember = "Curso";
            TB_CodTemas.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTemas.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Curso"]));

            }

            TB_CodTemas.AutoCompleteCustomSource = stringCodArti;
            TB_CodTemas.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodTemas.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarSectores()
        {
            dtSectores = S.ListarTodos();

            var fila = dtSectores.NewRow();
            dtSectores.Rows.InsertAt(fila, 0);


            CargarDescSector();
            CargarCodigosSec();
        }

        private void CargarDescSector()
        {
            TB_DescSector.DataSource = dtSectores;
            TB_DescSector.DisplayMember = "Descripcion";
            TB_DescSector.ValueMember = "Codigo";
            TB_DescSector.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtSectores.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescSector.AutoCompleteCustomSource = stringCodArti;
            TB_DescSector.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescSector.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosSec()
        {
            TB_CodSec.DataSource = dtSectores;
            TB_CodSec.DisplayMember = "Codigo";
            TB_CodSec.ValueMember = "Codigo";
            TB_CodSec.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtSectores.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodSec.AutoCompleteCustomSource = stringCodArti;
            TB_CodSec.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodSec.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarREsponsables()
        {
            dtResponsable = R.ListarTodos();


            var fila = dtResponsable.NewRow();
            dtResponsable.Rows.InsertAt(fila, 0);

            dtResponsable2 = dtResponsable.Copy();

            CargarDescResp();
            CargarCodigosResp();
            CargarDescResp2();
            CargarCodigosResp2();
        }

        

        private void CargarDescResp()
        {
            TB_DescResp1.DataSource = dtResponsable;
            TB_DescResp1.DisplayMember = "Descripcion";
            TB_DescResp1.ValueMember = "Codigo";
            TB_DescResp1.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescResp1.AutoCompleteCustomSource = stringCodArti;
            TB_DescResp1.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescResp1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosResp()
        {
            TB_CodResp1.DataSource = dtResponsable;
            TB_CodResp1.DisplayMember = "Codigo";
            TB_CodResp1.ValueMember = "Codigo";
            TB_CodResp1.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodResp1.AutoCompleteCustomSource = stringCodArti;
            TB_CodResp1.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodResp1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarDescResp2()
        {
            TB_DescResp2.DataSource = dtResponsable2;
            TB_DescResp2.DisplayMember = "Descripcion";
            TB_DescResp2.ValueMember = "Codigo";
            TB_DescResp2.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable2.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescResp2.AutoCompleteCustomSource = stringCodArti;
            TB_DescResp2.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescResp2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosResp2()
        {
            TB_CodResp2.DataSource = dtResponsable2;
            TB_CodResp2.DisplayMember = "Codigo";
            TB_CodResp2.ValueMember = "Codigo";
            TB_CodResp2.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable2.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodResp2.AutoCompleteCustomSource = stringCodArti;
            TB_CodResp2.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodResp2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void TB_DecPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_CodSec.Focus();
            }
            
        }

        private void TB_CodSec_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_DescSector.Text == "")
                {
                    TB_DescSector.Focus();
                }
                else
                {
                    TB_CodResp1.Focus();
                }
            }
            
        }

        private void TB_DescSector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_CodResp1.Focus();
            }
        }

        private void TB_CodResp1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_DescResp1.Text == "")
                {
                    TB_DescResp1.Focus();
                }
                else
                {
                    TB_CodResp2.Focus();
                }
            }
        }

        private void TB_DescResp1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_CodResp2.Focus();
            }
        }

        private void TB_CodResp2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_DescResp2.Text == "")
                {
                    TB_DescResp2.Focus();
                }
                else
                {
                    TB_Tareas1.Focus();
                }
            }
        }

        private void TB_DescResp2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Tareas1.Focus();
            }
        }


        private void TB_Tareas1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Tareas2.Focus();
            }
        }

        private void TB_Tareas2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Tareas3.Focus();
            }
        }

        private void TB_Tareas3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Primaria.Focus();
            }
        }

        private void TB_Primaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_ObservPrimaria.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Primaria.Text = "";
            }
        }

        private void TB_ObservPrimaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Secundaria.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_ObservPrimaria.Text = "";
            }
        }

        private void CB_NecPrim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecPrim.Checked)
                {
                    TB_Secundaria.Focus();
                }
                else
                {
                    CB_DesPrim.Focus();
                    CB_DesPrim.Select();
                    CB_DesPrim.BackColor = Color.DarkSlateGray;
                }

                CB_NecPrim.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesPrim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Secundaria.Focus();
                CB_DesPrim.BackColor = SystemColors.Control;
            }
            
        }

        private void TB_Secundaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_ObservSecundaria.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Secundaria.Text = "";
            }
        }

        private void TB_ObservSecundaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Terciaria.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_ObservSecundaria.Text = "";
            }
        }

        private void CB_NecSec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecSec.Checked)
                {
                    TB_Terciaria.Focus();
                }
                else
                {
                    CB_DesSec.Focus();
                    CB_DesSec.Select();
                    CB_DesSec.BackColor = Color.DarkSlateGray;
                }

                CB_NecSec.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesSec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Terciaria.Focus();
                CB_DesSec.BackColor = SystemColors.Control;
            }
        }

        private void TB_Terciaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_ObservTerciaria.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Terciaria.Text = "";
            }
        }

        private void TB_ObservTerciaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Idioma.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_ObservTerciaria.Text = "";
            }
        }

        private void CB_NecTerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecTerc.Checked)
                {
                    TB_Idioma.Focus();
                }
                else
                {
                    CB_DesTerc.Focus();
                    CB_DesTerc.Select();
                    CB_DesTerc.BackColor = Color.DarkSlateGray;
                }

                CB_NecTerc.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesTerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Idioma.Focus();
                CB_DesTerc.BackColor = SystemColors.Control;
            }
        }

        private void TB_Idioma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_ObservIdioma.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Idioma.Text = "";
            }
        }

        private void TB_ObservIdioma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Exp.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_ObservIdioma.Text = "";
            }
        }

        private void CB_NecIdioma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecIdioma.Checked)
                {
                    TB_Exp.Focus();
                }
                else
                {
                    CB_DesIdioma.Focus();
                    CB_DesIdioma.Select();
                    CB_DesIdioma.BackColor = Color.DarkSlateGray;
                }

                CB_NecIdioma.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesIdioma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Exp.Focus();
                CB_DesIdioma.BackColor = SystemColors.Control;
            } 
        }

        private void TB_Exp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_ObservExp.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Exp.Text = "";
            }
        }

        private void TB_ObservExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_CondFisica.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_ObservExp.Text = "";
            }
        }

        private void CB_NecExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecExp.Checked)
                {
                    TB_CondFisica.Focus();
                }
                else
                {
                    CB_DesExp.Focus();
                    CB_DesExp.Select();
                    CB_DesExp.BackColor = Color.DarkSlateGray;
                }

                CB_NecExp.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_CondFisica.Focus();
                CB_DesExp.BackColor = SystemColors.Control;
            } 
        }

        private void TB_CondFisica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_ObservCondFisica.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_CondFisica.Text = "";
            }
        }

        private void TB_ObservCondFisica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Otros1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_ObservCondFisica.Text = "";
            }
        }

        private void CB_NecCondFisica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecCondFisica.Checked)
                {
                    TB_Otros1.Focus();
                }
                else
                {
                    CB_DesCondFisica.Focus();
                    CB_DesCondFisica.Select();
                    CB_DesCondFisica.BackColor = Color.DarkSlateGray;
                }

                CB_NecCondFisica.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesCondFisica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Otros1.Focus();
                CB_DesCondFisica.BackColor = SystemColors.Control;
            } 
        }

        private void TB_Otros1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Otros2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Otros1.Text = "";
            }
        }

        private void CB_NecOtros1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecOtros1.Checked)
                {
                    TB_Otros2.Focus();
                }
                else
                {
                    CB_DesOtros1.Focus();
                    CB_DesOtros1.Select();
                    CB_DesOtros1.BackColor = Color.DarkSlateGray;
                }

                CB_NecOtros1.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesOtros1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Otros2.Focus();
                CB_DesOtros1.BackColor = SystemColors.Control;
            }
        }

        private void TB_Otros2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Equiv1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Otros2.Text = "";
            }
        }

        private void CB_NecOtros2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_NecOtros2.Checked)
                {
                    TB_Equiv1.Focus();
                }
                else
                {
                    CB_DesOtros2.Focus();
                    CB_DesOtros2.Select();
                    CB_DesOtros2.BackColor = Color.DarkSlateGray;
                }

                CB_NecOtros2.BackColor = SystemColors.Control;
            }
        }

        private void CB_DesOtros2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Equiv1.Focus();
                CB_DesOtros2.BackColor = SystemColors.Control;
            }
        }

        private void TB_Equiv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Equiv2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TB_Equiv1.Text = "";
            }
        }

        private void TB_Equiv2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TB_Equiv2.Text = "";
            }
        }

        private void TB_CodTemas_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_DescTemas.Text == "")
                {
                    TB_DescTemas.Focus();
                }
                else
                {
                    CB_Necesario.Focus();
                    CB_DesOtros2.BackColor = Color.DarkSlateGray;
                }
            }
        }

        private void TB_DescTemas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CB_Necesario.Focus();
                CB_Necesario.BackColor = Color.DarkSlateGray;
            }
        }

        private void CB_Necesario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CB_Necesario.Checked)
                {
                    BT_Guardar.Focus();
                     
                }
                else
                {
                    CB_Deseable.Focus();
                    CB_Deseable.Select();
                    CB_Deseable.BackColor = Color.DarkSlateGray;
                }

                CB_Necesario.BackColor = SystemColors.Control;
            }
        }

        private void CB_Deseable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Guardar.Focus();
                CB_Deseable.BackColor = SystemColors.Control;
            }
        }

        private void DGV_Temas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexRow = e.RowIndex;

            if (indexRow >= 0)
            {
                DataGridViewRow row = DGV_Temas.Rows[indexRow];

                TB_CodTemas.Text = row.Cells[0].Value.ToString();
                TB_DescTemas.Text = row.Cells[1].Value.ToString();
                CB_Necesario.Checked = row.Cells[2].Value.ToString() == "X";
                CB_Deseable.Checked = row.Cells[3].Value.ToString() == "X";
            }

            BT_Eliminar.Visible = true;
            BTModifTema.Visible = true;

            BTAgregarTema.Visible = false;
        }

        private void AgModPerfil_Shown(object sender, EventArgs e)
        {
            TB_DecPerfil.Focus();
        }

        

        

        

       

        
    }
}
