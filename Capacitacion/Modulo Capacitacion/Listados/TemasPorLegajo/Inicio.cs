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

namespace Modulo_Capacitacion.Listados.TemasPorLegajo
{
    public partial class Inicio : Form
    {
        Cursada Cu = new Cursada();
        DataTable dtCursadas;
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
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el legajo desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el legajo hasta el que desea realizar la busqueda");
                
                if (TB_AñoDesde.Text == "") throw new Exception("Se debe ingresar el año desde el que desea comenzar la busqueda");

                if (TB_AñoHasta.Text == "") throw new Exception("Se debe ingresar el año hasta el que desea realizar la busqueda");

                if (CB_Tipo.Text == "") throw new Exception("Se debe elegir el tipo de informe");

                int LegDesd;
                int.TryParse(TB_Desde.Text, out LegDesd);
                int LegHast;
                int.TryParse(TB_Hasta.Text, out LegHast);
                int AñoDesd;
                int.TryParse(TB_AñoDesde.Text, out AñoDesd);
                AñoDesd = int.Parse(AñoDesd.ToString() + "0101");
                int AñoHast;
                int.TryParse(TB_AñoHasta.Text, out AñoHast);
                AñoHast = int.Parse(AñoHast.ToString() + "1231");

                dtCursadas = Cu.ListarPorLegajo(LegDesd, LegHast);

                dtCursadas.Columns.Add("NHoras", typeof(float));

                dtInforme = dtCursadas.Copy();

                dtInforme.Clear();

                


                foreach (DataRow fila in dtCursadas.Rows)
                {
                    DataRow filaHoras;
                    filaHoras = dtCursadas.NewRow();

                    //CONSULTO POR SI LA ORDEN FECHA TIENE ALGO
                    if (fila[8].ToString() != "  /  /    ")

                    {
                        int Fecha;
                        int.TryParse(fila[11].ToString(), out Fecha);
                        

                        //SI SE CUMPLE QUE LA FECHA ESTA EN ENTRE LA INGRESADA LO AÑADO A LA DTINFORME
                        if ((Fecha >= AñoDesd) && (Fecha <= AñoHast) )
                        {
                            fila["NHoras"] = float.Parse(fila[6].ToString());
                            dtInforme.ImportRow(fila);
                        }
                    }
                   
                }

                Tipo = "Pantalla";

                ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
                Impre.ShowDialog();
            
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar el legajo desde el que desea comenzar la busqueda");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar el legajo hasta el que desea realizar la busqueda");

                if (TB_AñoDesde.Text == "") throw new Exception("Se debe ingresar el año desde el que desea comenzar la busqueda");

                if (TB_AñoHasta.Text == "") throw new Exception("Se debe ingresar el año hasta el que desea realizar la busqueda");

                if (CB_Tipo.Text == "") throw new Exception("Se debe elegir el tipo de informe");

                int LegDesd;
                int.TryParse(TB_Desde.Text, out LegDesd);
                int LegHast;
                int.TryParse(TB_Hasta.Text, out LegHast);
                int AñoDesd;
                int.TryParse(TB_AñoDesde.Text, out AñoDesd);
                AñoDesd = int.Parse(AñoDesd.ToString() + "0101");
                int AñoHast;
                int.TryParse(TB_AñoHasta.Text, out AñoHast);
                AñoHast = int.Parse(AñoHast.ToString() + "1231");

                dtCursadas = Cu.ListarPorLegajo(LegDesd, LegHast);

                dtCursadas.Columns.Add("NHoras", typeof(float));

                dtInforme = dtCursadas.Copy();

                dtInforme.Clear();




                foreach (DataRow fila in dtCursadas.Rows)
                {
                    DataRow filaHoras;
                    filaHoras = dtCursadas.NewRow();

                    //CONSULTO POR SI LA ORDEN FECHA TIENE ALGO
                    if (fila[8].ToString() != "  /  /    ")
                    {
                        int Fecha;
                        int.TryParse(fila[11].ToString(), out Fecha);


                        //SI SE CUMPLE QUE LA FECHA ESTA EN ENTRE LA INGRESADA LO AÑADO A LA DTINFORME
                        if ((Fecha >= AñoDesd) && (Fecha <= AñoHast))
                        {
                            fila["NHoras"] = float.Parse(fila[6].ToString());
                            dtInforme.ImportRow(fila);
                        }
                    }

                }

                Tipo = "Impresion";

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
                TB_AñoDesde.Focus();
            }
        }

        private void TB_AñoDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_AñoHasta.Focus();
            }
        }

        private void TB_AñoHasta_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ayuda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable tabla = _TraerLegajos();
            Ayuda frm = new Ayuda(tabla, ((TextBox)sender).Text);

            frm.ShowDialog();
            ((TextBox)sender).Text = frm.Valor == null ? "" : frm.Valor.ToString();
            frm.Dispose();
        }


        private DataTable _TraerLegajos()
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
                        cmd.CommandText = "SELECT Legajo.Codigo, Legajo.Descripcion FROM Legajo INNER JOIN (SELECT MIN(Codigo) as Actual, Descripcion FROM Legajo GROUP BY Descripcion) l2 ON Legajo.Descripcion = l2.Descripcion WHERE Legajo.FEgreso IN ('  /  /    ', '00/00/0000') AND Legajo.Renglon = 1 AND Legajo.Descripcion <> '' AND Legajo.Codigo = l2.Actual ORDER BY Legajo.Codigo";

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
    }
}
