using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Cursos
{
    public partial class AgModCurso : Form
    {
        Curso C = new Curso();
        Tema T = new Tema();
        private Curso CursoAModificar;
        bool EsModificar = false;

        DataTable dtTema;


        public AgModCurso()
        {
            InitializeComponent();
            CargarCombos();
        }

        public AgModCurso(Curso CursoAModificar)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.CursoAModificar = CursoAModificar;
            EsModificar = true;
            CargarCombos();
            CargoDatos();

            
        }

        private void CargoDatos()
        {
            TB_Codigo.Text = this.CursoAModificar.Tema.ToString();
            TB_DescCurso.Text = this.CursoAModificar.Descripcion;
            TB_CodTema.Text = this.CursoAModificar.Curso_Id.ToString();
            TB_DescTema.Text = this.CursoAModificar.DescripcionCurso;
           
            TB_Horas.Text = this.CursoAModificar.Horas.ToString();

            //BuscarDescripcionTema();
        }

        private void AgModCurso_Load(object sender, EventArgs e)
        {
            if (EsModificar)
            {
                TB_CodTema.Enabled = false;
                TB_DescTema.Enabled = false;
                TB_DescTema.Text = this.CursoAModificar.DescripcionCurso;
            } 
            

        }

        private void CargarCombos()
        {
            //dtTema.Clear();
            dtTema = T.ListarTemas();

            DataRow fila;
            fila = dtTema.NewRow();
            dtTema.Rows.InsertAt(fila, 0);


            CargarDesc();
            CargarCodigos();

        }

        private void CargarDesc()
        {
            TB_DescTema.DataSource = dtTema;
            TB_DescTema.DisplayMember = "Descripcion";
            TB_DescTema.ValueMember = "Tema";
            TB_DescTema.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTema.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DescTema.AutoCompleteCustomSource = stringCodArti;
            TB_DescTema.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescTema.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigos()
        {
            TB_CodTema.DataSource = dtTema;
            TB_CodTema.DisplayMember = "Tema";
            TB_CodTema.ValueMember = "Tema";
            TB_CodTema.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTema.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Tema"]));

            }

            TB_CodTema.AutoCompleteCustomSource = stringCodArti;
            TB_CodTema.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodTema.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void TB_CodTema_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void BuscarDescripcionTema()
        {
            int valor = 0;

            int.TryParse(TB_CodTema.Text, out valor);

            if (TB_CodTema.Text == "" || valor == 0) throw new Exception("Por favor ingrese un codigo valido");
            //Tema tema = new Tema();
            T = T.BuscarUno(TB_CodTema.Text);

            if (T.Descripcion != null) TB_DescTema.Text = T.Descripcion;
            else throw new Exception("No se encontro ningun Tema con el numero de codigo ingresado");
            
        }

        private void TB_CodTema_TextChanged(object sender, EventArgs e)
        {
            if (!EsModificar) { 
                TB_DescTema.Text = "";
                TB_Codigo.Text = "";
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            if (EsModificar)
            {
                TB_DescCurso.Text = "";
                TB_Horas.Text = "";
            }
            else { 
                TB_Codigo.Text = "";
                TB_CodTema.Text = "";
                TB_DescCurso.Text = "";
                TB_DescTema.Text = "";
                TB_Horas.Text = "";
            }
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Codigo.Text == "" || TB_CodTema.Text == "" || TB_DescCurso.Text == "" || TB_DescTema.Text == "" || TB_Horas.Text == "") throw new Exception("Hay que cargar todos los datos");

                C.Curso_Id = int.Parse(TB_Codigo.Text);
                C.Tema = int.Parse(TB_CodTema.Text);
                C.Descripcion = TB_DescCurso.Text;
                C.Horas = float.Parse(TB_Horas.Text);

                if (!EsModificar) { 
                C.Agregar();
                }
                else
                {
                    C.Modificar(C);
                }
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
            finally
            {
                
            }
        }

        private void TB_CodTema_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                

                if (e.KeyCode == Keys.Enter)
                {
                    BuscarDescripcionTema();

                    BuscarUltimoCurso();

                    

                    TB_DescCurso.Focus();
                }

                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BuscarUltimoCurso()
        {
            Tema tema = new Tema();
            TB_Codigo.Text = tema.ObtenerUltimo(TB_CodTema.Text).ToString();
        }

        private void TB_DescTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EsModificar == false)
            {
                if (TB_CodTema.Text != "")
                {
                    TB_DescCurso.Focus();
                    BuscarUltimoCurso();
                }
            }
            
            
        }

        private void TB_CodTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (TB_CodTema.Text != "" && TB_CodTema.Text != "System.Data.DataRowView")
                {
                    TB_DescCurso.Focus();
                    if (EsModificar == false)
                    {
                        BuscarUltimoCurso();
                    }
                    
                }
            
            
        }

        private void TB_DescCurso_KeyDown(object sender, KeyEventArgs e)
        {
            TB_Horas.Focus();
        }
    }
}
