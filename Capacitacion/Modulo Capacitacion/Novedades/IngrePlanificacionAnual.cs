using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Novedades
{
    public partial class IngrePlanificacionAnual : Form
    {
        Tema T = new Tema();
        Curso C = new Curso();
        Cronograma Cr = new Cronograma();
        Legajo L = new Legajo();
        bool Modificar = true;
        DataTable dtLegajos;
        DataTable dtLegajosSinFechaEgreso;
        bool Cargado = false;
        DataTable dtTemas;
        DataTable dtCursos;
        DataTable dtCronograma = new DataTable();

        public IngrePlanificacionAnual()
        {
            InitializeComponent();
            CargardtCronograma();

            CargarLegajos();
            CargarTemas();
            Cargado = true;
        }

        private void CargardtCronograma()
        {

            dtCronograma.Columns.Add("Tema", typeof(string));
            dtCronograma.Columns.Add("DescTema", typeof(string));
            dtCronograma.Columns.Add("Curso", typeof(string));
            dtCronograma.Columns.Add("DesCurso", typeof(string));
            dtCronograma.Columns.Add("Horas", typeof(string));
            dtCronograma.Columns.Add("Realizado", typeof(string));
        }

        private void CargarTemas()
        {
            dtTemas = T.ListarTemasPlani();

            DataRow fila;
            fila = dtTemas.NewRow();
            dtTemas.Rows.InsertAt(fila, 0);

            CargarDescTemas();
            CargarCodigosTemas();
        }

        private void CargarDescTemas()
        {
            TB_DescTemas.DataSource = dtTemas;
            TB_DescTemas.DisplayMember = "Descripcion";
            TB_DescTemas.ValueMember = "Codigo";
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
            TB_CodTemas.DisplayMember = "Codigo";
            TB_CodTemas.ValueMember = "Codigo";
            TB_CodTemas.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTemas.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodTemas.AutoCompleteCustomSource = stringCodArti;
            TB_CodTemas.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodTemas.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarLegajos()
        {
            dtLegajos = L.ListarTodos();

            

            dtLegajosSinFechaEgreso = dtLegajos.Copy();

            dtLegajosSinFechaEgreso.Clear();

            DataRow fila;
            fila = dtLegajosSinFechaEgreso.NewRow();
            dtLegajosSinFechaEgreso.Rows.InsertAt(fila, 0);

            //CARGO LOS LEGAJOS QUE NO TENGAN FECHA DE EGRESO PARA QUE SE LES PERMITA HACER LA 
            // PLANIFICACION
            foreach (DataRow filaLeg in dtLegajos.Rows)
            {
               
                if (filaLeg[33].ToString() == "00/00/0000")
                {
                    
                    dtLegajosSinFechaEgreso.ImportRow(filaLeg);
                }
                
            }

            CargarDescLegajos();
            CargarCodigosLegajos();
            
        }

        private void CargarDescLegajos()
        {
            TB_DesLegajo.DataSource = dtLegajosSinFechaEgreso;
            TB_DesLegajo.DisplayMember = "Descripcion";
            TB_DesLegajo.ValueMember = "Codigo";
            TB_DesLegajo.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtLegajosSinFechaEgreso.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_DesLegajo.AutoCompleteCustomSource = stringCodArti;
            TB_DesLegajo.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DesLegajo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosLegajos()
        {
            TB_CodLegajo.DataSource = dtLegajosSinFechaEgreso;
            TB_CodLegajo.DisplayMember = "Codigo";
            TB_CodLegajo.ValueMember = "Codigo";
            TB_CodLegajo.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtLegajosSinFechaEgreso.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodLegajo.AutoCompleteCustomSource = stringCodArti;
            TB_CodLegajo.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodLegajo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void TB_CodPer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (TB_CodLegajo.Text == "" || TB_Año.Text == "") throw new Exception("Se deben cargar los datos de legajo y año");

                    DGV_Crono.DataSource = Cr.BuscarUno(TB_CodLegajo.Text, TB_Año.Text);

                    Legajo L = new Legajo();
                    L = L.BuscarUno(TB_CodLegajo.Text);
                    TB_DesLegajo.Text = L.Descripcion;

                    if (DGV_Crono.Rows.Count == 0)
                    {
                        //Busco los cursos asociados al legajo!!
                        Modificar = false;
                        DGV_Crono.DataSource = L.BuscarCursos(TB_CodLegajo.Text);
                    }

                    //Perfil P = new Perfil();
                    //P = P.BuscarUno(TB_CodPer.Text);

                    //TB_DecPerfil.Text = P.Descripcion;
                    //Busco datos en cronograma


                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_CodLegajo.Text = "";
            TB_DesLegajo.Text = "";
            TB_Año.Text = "";
            LimpiarCamposTema();
            //DGV_Cronograma.Rows.Clear();
            DGV_Crono.DataSource = null;

            TB_CodLegajo.Focus();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            //
            ValidarDatosIngresados();
            CargarDatosCronograma();

            if (Modificar) { 
                //Modifico existente
                Cr.Eliminar(Cr.Legajo.Codigo, Cr.Año);
            }

            InsertarCronograma();
            this.Close();
        }

        private void InsertarCronograma()
        {
            Cr.Agregar();
        }

        private void CargarDatosCronograma()
        {
            Cr.Legajo = new Legajo();
            Cr.Legajo.Codigo = int.Parse(TB_CodLegajo.Text);
            Cr.Legajo.Descripcion = TB_DesLegajo.Text;
            Cr.Año = TB_Año.Text;
            //Cr.Tema = new Tema();


            List<Curso> Cursos = new List<Curso>();
            foreach (DataGridViewRow row in DGV_Crono.Rows)
            {
                Curso C = new Curso();
                C.Curso_Id = int.Parse(row.Cells[0].Value.ToString());
                C.Descripcion = row.Cells[1].Value.ToString();
                C.Horas = float.Parse(row.Cells[4].Value.ToString());
                C.Realizado = float.Parse(row.Cells[5].Value.ToString());
                int result = 0;
                int.TryParse(row.Cells[2].Value.ToString(), out result);
                C.Tema = result;
                Cursos.Add(C);
            }
            Cr.Cursos = Cursos;
        }

        private void ValidarDatosIngresados()
        {
            if (TB_CodLegajo.Text == "") throw new Exception("Debe estar cargado el campo Legajo");
            if (TB_DesLegajo.Text == "") throw new Exception("Debe estar cargado el campo descripcion");
            if (TB_Año.Text == "") throw new Exception("Debe estar cargado el campo año");
            if (DGV_Crono.Rows.Count == 0) throw new Exception("No hay datos en la grilla");
        }

        private void IngrePlanificacionAnual_Load(object sender, EventArgs e)
        {

        }

        private void TB_DesLegajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cargado == true)
            {
                TB_Año.Focus();
            }
        }

        private void BT_Guardar_Click_1(object sender, EventArgs e)
        {
            //
            ValidarDatosIngresados();
            CargarDatosCronograma();

            if (Modificar)
            {
                //Modifico existente
                Cr.Eliminar(Cr.Legajo.Codigo, Cr.Año);
            }

            InsertarCronograma();
            this.Close();
        }

        private void TB_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                

                    if (TB_CodLegajo.Text == "" || TB_Año.Text == "") throw new Exception("Se deben cargar los datos de legajo y año");


                    dtCronograma = Cr.BuscarUno(TB_CodLegajo.Text, TB_Año.Text);
                    DGV_Crono.DataSource = Cr.BuscarUno(TB_CodLegajo.Text, TB_Año.Text);

                    Legajo L = new Legajo();
                    L = L.BuscarUno(TB_CodLegajo.Text);
                    TB_DesLegajo.Text = L.Descripcion;
                    lblAtencion.Visible = false;

                    if (dtCronograma.Rows.Count == 0)
                    {
                        //Busco los cursos asociados al legajo!!
                        Modificar = false;
                        dtCronograma = L.BuscarCursosPlanificacion(TB_CodLegajo.Text);
                        // Mostramos la ventana de Atencion.
                        lblAtencion.Visible = true;
                    }

                    DGV_Crono.DataSource = dtCronograma;

                

                    //Perfil P = new Perfil();
                    //P = P.BuscarUno(TB_CodPer.Text);

                    //TB_DecPerfil.Text = P.Descripcion;
                    //Busco datos en cronograma


                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

        }

        private void TB_DescTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarCodigoTema();
            CargarCursos();
            CB_Curso.Focus();
        }

        private void BuscarCodigoTema()
        {
            foreach (DataRow fila in dtTemas.Rows)
            {
                if (fila[1].ToString() == TB_DescTemas.Text)
                {
                    TB_CodTemas.Text = fila[0].ToString();
                }
            }
        }

        private void CargarCursos()
        {
            if (TB_CodTemas.Text != "")
            {
                dtCursos = C.ListaPorTema(int.Parse(TB_CodTemas.Text));

                DataRow fila;
                fila = dtCursos.NewRow();
                dtCursos.Rows.InsertAt(fila, 0);

                CargarDescCursos();

                LB_Curso.Visible = true;
                CB_Curso.Visible = true;
            }
            
            
        }

        private void CargarDescCursos()
        {
            CB_Curso.DataSource = dtCursos;
            CB_Curso.DisplayMember = "Descripcion";
            CB_Curso.ValueMember = "Tema";
            CB_Curso.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtCursos.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]).Trim());
            }

            CB_Curso.AutoCompleteCustomSource = stringCodArti;
            CB_Curso.AutoCompleteMode = AutoCompleteMode.Suggest;
            CB_Curso.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BT_AgregarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_CodTemas.Text == "" || TB_DescTemas.Text == "") throw new Exception("Se debe ingresar el tema");

                AgregarFila();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            TB_CodTemas.Focus();
        }

        private void AgregarFila()
        {
            DataRow filaCronograma;
            filaCronograma = dtCronograma.NewRow();

            filaCronograma[0] = TB_CodTemas.Text;
            filaCronograma[1] = TB_DescTemas.Text;
            if (CB_Curso.Text != "")
            {
                foreach (DataRow filaCurso in dtCursos.Rows)
                {
                    if (filaCurso[2].ToString() == CB_Curso.Text)
                    {
                        filaCronograma[2] = filaCurso[1].ToString();
                        filaCronograma[3] = CB_Curso.Text;
                        filaCronograma[4] = filaCurso[4].ToString();
                        filaCronograma[5] = 0;

                        
                    }
                }
            }
            else
            {
                filaCronograma[2] = 0;
                filaCronograma[3] = "";
                filaCronograma[4] = 0;
                filaCronograma[5] = 0;

                
            }


            dtCronograma.Rows.Add(filaCronograma);

            DGV_Crono.DataSource = dtCronograma;
            

            LimpiarCamposTema();
        }

        private void LimpiarCamposTema()
        {
            TB_CodTemas.Text = "";
            TB_DescTemas.Text = "";
            CB_Curso.Text = "";
            CB_Curso.Visible = false;
        }

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TB_Buscar.PerformClick();
            if (e.KeyCode == Keys.Escape) TB_Año.Text = "";
        }

        private void IngrePlanificacionAnual_Shown(object sender, EventArgs e)
        {
            TB_CodLegajo.Focus();
        }

        private void TB_CodLegajo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) TB_CodLegajo.Text = "";
        }
    }
}
