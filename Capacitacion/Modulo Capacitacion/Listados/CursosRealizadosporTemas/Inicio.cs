using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.CursosRealizadosporTemas
{
    public partial class Inicio : Form
    {
        Cursada C = new Cursada();
        DataTable dtInforme;
        string Tipo;

        public Inicio()
        {
            InitializeComponent();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el tema desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el tema hasta el que desea realizar la busqueda");

                int Desd;
                int.TryParse(TB_Desde.Text, out Desd);
                int Hast;
                int.TryParse(TB_Hasta.Text, out Hast);
                //int Año;
                //int.TryParse(TB_AñoDesde.Text, out Año);
                int AñoDesde = int.Parse(Helper.OrdenarFecha(txtAnioDesde.Text));
                int AñoHasta = int.Parse(Helper.OrdenarFecha(txtAnioHasta.Text));

                Helper.ActualizarCantidadPersonasHoras(txtAnioDesde.Text.Substring(6, 4));
                Helper.ActualizarCantidadPersonasHoras(txtAnioHasta.Text.Substring(6, 4));

                dtInforme = C.ListarCursoporTema(Desd, Hast, AñoDesde, AñoHasta);
                
                Tipo = "Pantalla";
                
                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Hasta.Focus();
            }
        }

        private void TB_Hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAnioDesde.Focus();
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el tema desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el tema hasta el que desea realizar la busqueda");

                if (CB_Tipo.Text == "") throw new Exception("Se debe elegir un tipo");

                int Desd;
                int.TryParse(TB_Desde.Text, out Desd);
                int Hast;
                int.TryParse(TB_Hasta.Text, out Hast);
                int Año;
                //int.TryParse(TB_AñoDesde.Text, out Año);
                int AñoDesde = int.Parse(Helper.OrdenarFecha(txtAnioDesde.Text));
                int AñoHasta = int.Parse(Helper.OrdenarFecha(txtAnioHasta.Text));

                Helper.ActualizarCantidadPersonasHoras(txtAnioDesde.Text.Substring(6,4));
                Helper.ActualizarCantidadPersonasHoras(txtAnioHasta.Text.Substring(6,4));

                dtInforme = C.ListarCursoporTema(Desd, Hast, AñoDesde, AñoHasta);

                Tipo = "Imprimir";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerTemas();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }

        private DataTable _TraerTemas()
        {
            try
            {
                DataTable tabla = new DataTable();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Codigo, Descripcion FROM Curso WHERE Descripcion <> '' ORDER BY Codigo";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                    }

                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_Desde.Focus();
        }


        private void txtAnioDesde_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtAnioDesde.Text.Replace(" ", "").Length < 10) return;

                txtAnioHasta.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtAnioDesde.Text = "";
            }
	        
        }

        private void txtAnioHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtAnioHasta.Text.Replace(" ", "").Length < 10) return;

                CB_Tipo.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtAnioHasta.Text = "";
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            txtAnioDesde.Clear();
            txtAnioHasta.Clear();
        }
    }
}
