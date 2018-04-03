using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.Cursos_Por_Personal
{
    public partial class Inicio : Form
    {
        DataTable dtResponsable;
        Responsable R = new Responsable();
        
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarResponsables();
        }

        private void CargarResponsables()
        {
            dtResponsable = R.ListarTodos();


            DataRow fila;
            fila = dtResponsable.NewRow();
            dtResponsable.Rows.InsertAt(fila, 0);

           

            CargarDescResp();
            CargarCodigosResp();
        }

        private void CargarDescResp()
        {
            TB_Responsable2.DataSource = dtResponsable;
            TB_Responsable2.DisplayMember = "Descripcion";
            TB_Responsable2.ValueMember = "Codigo";
            TB_Responsable2.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_Responsable2.AutoCompleteCustomSource = stringCodArti;
            TB_Responsable2.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Responsable2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosResp()
        {
            TB_CodResponsable2.DataSource = dtResponsable;
            TB_CodResponsable2.DisplayMember = "Codigo";
            TB_CodResponsable2.ValueMember = "Codigo";
            TB_CodResponsable2.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodResponsable2.AutoCompleteCustomSource = stringCodArti;
            TB_CodResponsable2.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodResponsable2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if ( TB_CodResponsable2.Text == "") throw new Exception("Se debe elegir el responsable");

                if (TB_Mes.Text == "") throw new Exception("Se debe ingresar el mes");

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el año");

                if (CB_Ordenamiento.Text == "") throw new Exception("Se debe elegir un ordenamiento");


            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
