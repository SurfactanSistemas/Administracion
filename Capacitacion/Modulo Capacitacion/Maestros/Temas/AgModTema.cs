using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Temas
{
    public partial class AgModTema : Form
    {
        private Responsable R = new Responsable();
        bool EsModificar;
        private Tema TemaAModificar;
        Tema nuevoTema = new Tema();
        DataTable dtResponsable;
        DataTable dtResponsable2;

        public AgModTema()
        {
            InitializeComponent();
        }

        public AgModTema(int _UltimoId)
        {
            EsModificar = false;
            
            InitializeComponent();
            TB_Codigo.Text = _UltimoId.ToString();
            CargarCombo();
            CargarREsponsables();
            TB_Descripcion.Focus();
        }

        public AgModTema(Tema TemaAModificar)
        {
            this.TemaAModificar = TemaAModificar;
            EsModificar = true;

            InitializeComponent();
            CargarCombo();
            CargarCampos(this.TemaAModificar);
            TB_Descripcion.Focus();
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

        public void CargarCombo()
        {
            Dictionary<int, string> comboLugar = new Dictionary<int, string>
            {
                {0, ""},
                {1, "En la Empresa"},
                {2, "Otros Conocimientos"}
            };
            CB_Donde.DataSource = new BindingSource(comboLugar, null);
            CB_Donde.DisplayMember = "Value";
            CB_Donde.ValueMember = "Key";
        }

        private void CargarCampos(Tema tema)
        {
            TB_Codigo.Text = tema.Codigo.ToString();
            TB_Responsable.Text = tema.Responsable.Trim();
            TB_Descripcion.Text = tema.Descripcion.Trim();
            TB_Detalle_1.Text = tema.TemaI.Trim();
            TB_Detalle_2.Text = tema.TemaII.Trim();
            TB_Detalle_3.Text = tema.TemaIII.Trim();
            TB_CodResponsable2.Text = tema.ResponsableII.Codigo.ToString().Trim();
            TB_Responsable2.Text = tema.ResponsableII.Descripcion.Trim();
            TB_CodResponsable3.Text = tema.ResponsableIII.Codigo.ToString().Trim();
            TB_Responsable3.Text = tema.ResponsableIII.Descripcion.Trim();
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
                    Close();
                }
            }
            else { Close(); }
            
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
                if (TB_Descripcion.Text.Trim() == "") throw new Exception("La tarea debe tener una descripción.");

                if (!EsModificar)
                {

                    nuevoTema.Codigo = int.Parse(TB_Codigo.Text);
                    nuevoTema.Descripcion = TB_Descripcion.Text.Trim();
                    nuevoTema.TemaI = TB_Detalle_1.Text.Trim();
                    nuevoTema.TemaII = TB_Detalle_2.Text.Trim();
                    nuevoTema.TemaIII = TB_Detalle_3.Text.Trim();
                    nuevoTema.Responsable = TB_Responsable.Text.Trim();
                    nuevoTema.ResponsableII = new Responsable
                    {
                        Codigo = TB_CodResponsable2.Text.Trim() == "" ? 0 : int.Parse(TB_CodResponsable2.Text)
                    };
                    nuevoTema.ResponsableIII = new Responsable
                    {
                        Codigo = TB_CodResponsable3.Text.Trim() == "" ? 0 : int.Parse(TB_CodResponsable3.Text)
                    };

                    nuevoTema.Tipo = CB_Donde.SelectedValue.ToString().Trim() == "" ? 0 : int.Parse(CB_Donde.SelectedValue.ToString());

                    nuevoTema.Agregar();
                }
                else
                {

                    TemaAModificar.Codigo = int.Parse(TB_Codigo.Text);
                    TemaAModificar.Descripcion = TB_Descripcion.Text.Trim();
                    TemaAModificar.TemaI = TB_Detalle_1.Text.Trim();
                    TemaAModificar.TemaII = TB_Detalle_2.Text.Trim();
                    TemaAModificar.TemaIII = TB_Detalle_3.Text.Trim();
                    TemaAModificar.Responsable = TB_Responsable.Text.Trim();
                    TemaAModificar.ResponsableII = new Responsable
                    {
                        Codigo = TB_CodResponsable2.Text.Trim() == "" ? 0 : int.Parse(TB_CodResponsable2.Text)
                    };
                    TemaAModificar.ResponsableIII = new Responsable
                    {
                        Codigo = TB_CodResponsable3.Text.Trim() == "" ? 0 : int.Parse(TB_CodResponsable3.Text)
                    };

                    TemaAModificar.Tipo = CB_Donde.SelectedValue.ToString().Trim() == "" ? 0 : int.Parse(CB_Donde.SelectedValue.ToString());

                    nuevoTema.Modificar(TemaAModificar);

                }

                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }

        private void TB_CodResponsable2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    if (TB_CodResponsable2.Text.Trim() == "")
                    {
                        return;
                    }

                    R = R.BuscarUno(TB_CodResponsable2.Text);

                    if (R.Codigo == 0) throw new Exception("No se encontro elemento con el codigo ingresado");

                    TB_Responsable2.Text = R.Descripcion;
                    e.SuppressKeyPress = true;
                    e.Handled = true;

                    TB_CodResponsable3.Focus();
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

                    if (TB_CodResponsable3.Text.Trim() == "")
                    {
                        return;
                    }

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
            if (e.KeyCode == Keys.Enter)
            {
                TB_Detalle_1.Focus();
            }
        }

        private void TB_Detalle_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TB_Detalle_2.Focus();
        }

        private void TB_Detalle_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TB_Detalle_3.Focus();
        }

        private void TB_Detalle_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                TB_CodResponsable2.Focus();
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

        private void AgModTema_Shown(object sender, EventArgs e)
        {
            TB_Descripcion.Focus();
        }
    }
}
