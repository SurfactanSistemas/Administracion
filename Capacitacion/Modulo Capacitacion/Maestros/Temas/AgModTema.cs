using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Temas
{
    public partial class AgModTema : Form
    {
        private Responsable R = new Responsable();
        private int UltimoId;
        bool EsModificar = false;
        private Tema TemaAModificar;
        Tema nuevoTema = new Tema();
        DataTable dtResponsable;
        DataTable dtResponsable2;

        public AgModTema()
        {
            InitializeComponent();
        }

        public AgModTema(int UltimoId)
        {
            // TODO: Complete member initialization
            this.UltimoId = UltimoId;
            EsModificar = false;
            
            InitializeComponent();
            TB_Codigo.Text = this.UltimoId.ToString();
            CargarCombo();
            CargarREsponsables();
        }

        private void CargarREsponsables()
        {
            dtResponsable = R.ListarTodos();


            DataRow fila;
            fila = dtResponsable.NewRow();
            dtResponsable.Rows.InsertAt(fila, 0);

            dtResponsable2 = dtResponsable.Copy();

            CargarDescResp();
            CargarCodigosResp();
            CargarDescResp2();
            CargarCodigosResp2();
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

        private void CargarDescResp2()
        {
            TB_Responsable3.DataSource = dtResponsable2;
            TB_Responsable3.DisplayMember = "Descripcion";
            TB_Responsable3.ValueMember = "Codigo";
            TB_Responsable3.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable2.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_Responsable3.AutoCompleteCustomSource = stringCodArti;
            TB_Responsable3.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Responsable3.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosResp2()
        {
            TB_CodResponsable3.DataSource = dtResponsable2;
            TB_CodResponsable3.DisplayMember = "Codigo";
            TB_CodResponsable3.ValueMember = "Codigo";
            TB_CodResponsable3.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable2.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodResponsable3.AutoCompleteCustomSource = stringCodArti;
            TB_CodResponsable3.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodResponsable3.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public AgModTema(Tema TemaAModificar)
        {
            // TODO: Complete member initialization
            this.TemaAModificar = TemaAModificar;
            EsModificar = true;
            
            InitializeComponent();
            CargarCombo();
            CargarCampos(this.TemaAModificar);
            
        }

        public void CargarCombo()
        {
            Dictionary<int, string> comboLugar = new Dictionary<int, string>();
            comboLugar.Add(0, "");
            comboLugar.Add(1, "En la Empresa");
            comboLugar.Add(2, "Otros Conocimientos");
            CB_Donde.DataSource = new BindingSource(comboLugar, null);
            CB_Donde.DisplayMember = "Value";
            CB_Donde.ValueMember = "Key";
        }

        private void CargarCampos(Tema tema)
        {
            TB_Codigo.Text = tema.Codigo.ToString();
            TB_Responsable.Text = tema.Responsable;
            TB_Descripcion.Text = tema.Descripcion;
            TB_Detalle_1.Text = tema.TemaI;
            TB_Detalle_2.Text = tema.TemaII;
            TB_Detalle_3.Text = tema.TemaIII;
            TB_CodResponsable2.Text = tema.ResponsableII.Codigo.ToString();
            TB_Responsable2.Text = tema.ResponsableII.Descripcion;
            TB_CodResponsable3.Text = tema.ResponsableIII.Codigo.ToString();
            TB_Responsable3.Text = tema.ResponsableIII.Descripcion;
            CB_Donde.SelectedValue = tema.Tipo;
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            if (TB_Descripcion.Text != "" || TB_Detalle_1.Text != "" || TB_Detalle_2.Text != "" || TB_Responsable.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("¿Estas seguro que quieres salir? Se perderan todos los datos ingresados", "Confirmacion de salida",
                                MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else { this.Close(); }
            
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            TB_Responsable.Text = "";
            TB_Responsable2.Text = "";
            TB_Responsable3.Text = "";
            TB_Descripcion.Text = "";
            TB_Detalle_1.Text = "";
            TB_Detalle_2.Text = "";
            TB_Detalle_3.Text = "";
            TB_CodResponsable2.Text = "";
            TB_CodResponsable3.Text = "";           
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Descripcion.Text == "" || TB_Detalle_1.Text == "" || TB_Detalle_2.Text == "" ||
                    TB_Responsable.Text == "" || TB_CodResponsable2.Text == "" || TB_CodResponsable3.Text == "" ||
                    CB_Donde.SelectedValue.ToString() == "") 
                    throw new Exception("Se deben completar todos los campos");

                if (!EsModificar)
                {
                    
                    nuevoTema.Codigo = int.Parse(TB_Codigo.Text);
                    nuevoTema.Descripcion = TB_Descripcion.Text;
                    nuevoTema.TemaI = TB_Detalle_1.Text;
                    nuevoTema.TemaII = TB_Detalle_2.Text;
                    nuevoTema.TemaIII = TB_Detalle_3.Text;
                    nuevoTema.Responsable = TB_Responsable.Text;
                    nuevoTema.ResponsableII = new Responsable();
                    nuevoTema.ResponsableII.Codigo = int.Parse(TB_CodResponsable2.Text);
                    nuevoTema.ResponsableIII = new Responsable();
                    nuevoTema.ResponsableIII.Codigo = int.Parse(TB_CodResponsable3.Text);

                    nuevoTema.Tipo = int.Parse(CB_Donde.SelectedValue.ToString());

                    nuevoTema.Agregar();
                }
                else
                {

                    this.TemaAModificar.Codigo = int.Parse(TB_Codigo.Text);
                    this.TemaAModificar.Descripcion = TB_Descripcion.Text;
                    this.TemaAModificar.TemaI = TB_Detalle_1.Text;
                    this.TemaAModificar.TemaII = TB_Detalle_2.Text;
                    this.TemaAModificar.TemaIII = TB_Detalle_3.Text;
                    this.TemaAModificar.Responsable = TB_Responsable.Text;
                    this.TemaAModificar.ResponsableII = new Responsable();
                    this.TemaAModificar.ResponsableII.Codigo = int.Parse(TB_CodResponsable2.Text);
                    this.TemaAModificar.ResponsableIII = new Responsable();
                    this.TemaAModificar.ResponsableIII.Codigo = int.Parse(TB_CodResponsable3.Text);
                    this.TemaAModificar.Tipo = int.Parse(CB_Donde.SelectedValue.ToString());

                    nuevoTema.Modificar(this.TemaAModificar);

                    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }

            finally
            {
                this.Close();
            }
        }

        private void AgModTema_Load(object sender, EventArgs e)
        {
        }

        private void TB_CodResponsable2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    R = R.BuscarUno(TB_CodResponsable2.Text);

                    if (R.Codigo == 0) throw new Exception("No se encontro elemento con el codigo ingresado");

                    TB_Responsable2.Text = R.Descripcion;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error");
                }
            }
        }

        private void TB_CodResponsable3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    R = R.BuscarUno(TB_CodResponsable3.Text);

                    if (R.Codigo == 0) throw new Exception("No existe Responsable con el codigo ingresado");

                    TB_Responsable3.Text = R.Descripcion;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error");
                }
            }
        }

        private void TB_Descripcion_KeyDown(object sender, KeyEventArgs e)
        {
            TB_Detalle_1.Focus();
        }

        private void TB_Detalle_1_KeyDown(object sender, KeyEventArgs e)
        {
            TB_Detalle_2.Focus();
        }

        private void TB_Detalle_2_KeyDown(object sender, KeyEventArgs e)
        {
            TB_Detalle_3.Focus();
        }

        private void TB_Detalle_3_KeyDown(object sender, KeyEventArgs e)
        {
            TB_CodResponsable2.Focus();
        }

        private void TB_Responsable_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TB_Responsable2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_CodResponsable3.Focus();
                TB_Responsable.Text = TB_Responsable2.Text;
            }
        }

        private void TB_Responsable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_CodResponsable3.Focus();
            TB_Responsable.Text = TB_Responsable2.Text;
        }

        private void TB_CodResponsable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_CodResponsable3.Focus();
            TB_Responsable.Text = TB_Responsable2.Text;
        }

        private void TB_CodResponsable2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_Responsable2.Text == "")
                {
                    TB_Responsable2.Focus();
                }
                else
                {
                    TB_CodResponsable3.Focus();
                    TB_Responsable.Text = TB_Responsable2.Text;
                }
            }
        }

        private void TB_CodResponsable3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TB_CodResponsable3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_Responsable3.Text == "")
                {
                    TB_Responsable3.Focus();
                }
               
            }
        }

        private void TB_Responsable3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TB_Responsable3_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
