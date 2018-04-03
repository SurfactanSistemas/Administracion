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
    public partial class IngresoDeCursosRealizados : Form
    {
        Cronograma Cr = new Cronograma();
        Curso C = new Curso();

        Tema T = new Tema();
        //bool Modificar = true;
        public IngresoDeCursosRealizados()
        {
            InitializeComponent();
        }

        private void TB_CodTema_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Tema tema = new Tema();

                if (e.KeyCode == Keys.Enter)
                {
                    BuscarDescripcionTema();

                    //TB_Codigo.Text = tema.ObtenerUltimo(TB_CodTema.Text).ToString();
                };
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void TB_CodCurso_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (TB_DescTema.Text == "") throw new Exception("Se debe cargar el tema primero");
                if (e.KeyCode == Keys.Enter)
                {
                    BuscarDescripcionCurso();

                    //TB_Codigo.Text = tema.ObtenerUltimo(TB_CodTema.Text).ToString();
                };
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void BuscarDescripcionCurso()
        {
            int valor = 0;

            int.TryParse(TB_CodCurso.Text, out valor);

            if (TB_CodCurso.Text == "" || valor == 0) throw new Exception("Por favor ingrese un codigo valido");
            //Tema tema = new Tema();
            C = C.BuscarUnoPorTema(TB_CodTema.Text,TB_CodCurso.Text);

            if (C.Descripcion != null) TB_DesCurso.Text = C.Descripcion;
            else throw new Exception("No se encontro ningun Tema con el numero de codigo ingresado");
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


    }
}
