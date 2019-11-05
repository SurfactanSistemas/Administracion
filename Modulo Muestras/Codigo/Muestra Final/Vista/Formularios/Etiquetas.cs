﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassConexion;

namespace Vista
{
    
    public partial class Etiquetas : Form
    {
        
        DataTable DT = new DataTable();

        DataTable DTOriginal = new DataTable();

        Conexion CS = new Conexion();

        Boolean Traducibles = false;
        
        public Etiquetas(DataTable tabla)
        {
            InitializeComponent();
            DT = tabla;

            DTOriginal = DT.Copy();

            cmbIdiomaEtiquetas.SelectedIndex = 0;
            //GrupoIdiomaEtiquetas.Visible = false;

            PoblarGrilla();

            //DeterminarCantidadPosibleDeCorrimientos();

            CBTamañoEtiquetas.SelectedIndex = 0;
        }

      
        private void PoblarGrilla()
        {
            DataTable tabla = DT;

            DGV_Etiquetas.Rows.Clear();

            foreach (DataRow dr in tabla.Rows)
            {
                DGV_Etiquetas.Rows.Add(dr["Codigo"].ToString(), dr["DescriCliente"].ToString(), 1);

                //if (!Traducibles && dr["Codigo"].ToString().Trim().StartsWith("PT"))
                //{
                //    Traducibles = true;
                //}
            }

            //GrupoIdiomaEtiquetas.Visible = Traducibles;
        }

        private void PoblarGrilla(DataTable tabla)
        {
            DGV_Etiquetas.Rows.Clear();

            foreach (DataRow dr in tabla.Rows)
            {
                DGV_Etiquetas.Rows.Add(dr["Codigo"].ToString(), dr["DescriCliente"].ToString(), 1);
            }

            DT = tabla.Copy();

        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Forzamos la actualizacion de todas las cantidades.
                DGV_Etiquetas.EndEdit(DataGridViewDataErrorContexts.Commit);

                string TipoEtiqueta = DeterminarTipoEtiqueta();

                for (int RowIndex = 0; RowIndex < DGV_Etiquetas.RowCount; RowIndex++)
                {
                    if (CantidadInvalidaDeEtiquetas(RowIndex))
                    {
                        throw new Exception("Debe estar definidas todas las cantidades de Cada etiqueta.");
                    }
                }

                int[] CantidadesDeEtiquetas = DeterminarCantidadDeEtiquetas();
                int posicion = CBPosicion.SelectedIndex;

                Boolean trad = cmbIdiomaEtiquetas.SelectedIndex == 1;

                ImpreEtiquetChic impre = new ImpreEtiquetChic(DT, CantidadesDeEtiquetas, TipoEtiqueta, posicion, trad);

                impre.ShowDialog();

                Close();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }    
        }

        private string DeterminarTipoEtiqueta()
        {
            switch (CBTamañoEtiquetas.SelectedIndex)
            {

                case 0: // Etiqueta Chica (8.5 x 4)

                    return "Chica";

                case 1: // Etiqueta Autoadhesiva (14 x 12.5)

                    return "Grande";

                //case 2: // Etiqueta Mediana

                //    return "Mediana";

                case 2: // Etiqueta P/Frascos

                    return "Frasco";

                default:

                    throw new Exception("Tipo de Etiqueta Inválida.");

            }
        }

        private void DeterminarCantidadPosibleDeCorrimientos()
        {
            // Limpiamos todos los items anteriores.
            CBPosicion.Items.Clear();

            int posiciones = 0;

            switch (DeterminarTipoEtiqueta())
            {
                case "Chica": // Etiqueta Chica (8.5 x 4)

                    posiciones = 4;
                    break;

                case "Grande": // Etiqueta Autoadhesiva (14 x 12.5)

                    posiciones = 1;
                    break;

                case "Mediana": // Etiqueta Mediana

                    posiciones = 4;
                    break;

                case "Frasco": // Etiqueta P/Frascos

                    posiciones = 7;
                    break;

                default:

                    throw new Exception("Tipo de Etiqueta Inválida.");
            }

            for (int i = 1; i < posiciones; i++)
            {
                CBPosicion.Items.Add(i);
            }

            CBPosicion.SelectedIndex = 0;
        }

        private int[] DeterminarCantidadDeEtiquetas()
        {
            int[] Cantidades = new int[DGV_Etiquetas.Rows.Count];

            for (int i = 0; i < DGV_Etiquetas.Rows.Count; i++)
            {
                Cantidades[i] = int.Parse(DGV_Etiquetas.Rows[i].Cells[2].Value.ToString());
            }

            return Cantidades;
        }

        private bool CantidadInvalidaDeEtiquetas(int Index)
        {
            return DeterminarCantidadDeEtiquetas().Length < 0;
        }

        private void CBTamañoEtiquetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBTamañoEtiquetas.SelectedIndex == 1) // Solo la desactivamos en el Caso de las Etiquetas Grandes.
            {
                CBPosicion.Enabled = false;
            }
            else
            {
                DeterminarCantidadPosibleDeCorrimientos();
                CBPosicion.Enabled = true;
                CBPosicion.Focus();
            }
        }

        private string BuscarDescripcionIngles(string codigo)
        {
            string descripcion = "";

            descripcion = CS.BuscarDescripcionIngles(codigo);

            return descripcion;
        }
        
        private void cmbIdiomaEtiquetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aca verificamos cada uno de los Productos y para los PT buscamos y reemplazamos las descripciones al idioma inglés.
            // Para los que no se encuentre o no sean PT's, se dejan como están y se avisa por pantalla que no poseen descripción en dicho idioma.

            // Se utiliza una tabla auxiliar para no perder los datos originales.

            DataTable tabla = new DataTable();
            tabla = DTOriginal.Copy();
            string WDescripcionIngles = "";
            string WNoTraducidos = "";

            if (cmbIdiomaEtiquetas.SelectedIndex == 1)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    WDescripcionIngles = "";

                    //if (row["Codigo"].ToString().Trim().StartsWith("PT"))
                    //{
                    //    // Buscamos la traducción del nombre del Producto.
                        WDescripcionIngles = BuscarDescripcionIngles(row["Codigo"].ToString());

                        // Traducimos Fecha.
                        row["Fecha"] = row["Fecha"].ToString().Replace("Fecha:", "Sample Date:");

                        // Traducimos Pedido/Lote.
                        row["Lote"] = row["Lote"].ToString().Replace("Lote:", "Batch:");
                        row["Lote"] = row["Lote"].ToString().Replace("Pedido:", "Order:");

                        // Traducimos Guía.
                        row["Intervencion"] = row["Intervencion"].ToString().Replace("Guia:", "Guide:");

                        // Traducimos Clase.
                        row["Clase"] = row["Clase"].ToString().Replace("Clase:", "Class:");
                        
                    //}

                    if (WDescripcionIngles.Trim() != "")
                    {
                        row["DescriCliente"] = WDescripcionIngles.Trim();
                    }
                    else
                    {
                        WNoTraducidos += row["Codigo"] + Environment.NewLine;
                    }

                }

            }

            if (WNoTraducidos.Trim() != "")
            {
                MessageBox.Show("Lo siguientes Códigos, no poseen descripción en Inglés disponible: " + Environment.NewLine + WNoTraducidos, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            PoblarGrilla(tabla);
        }

     

        private void DGV_Etiquetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_Etiquetas.SelectedCells.Count > 0)
            {
                if (DGV_Etiquetas.CurrentCell.ColumnIndex == 1)
                {
                    
                    txtDescripcionCambiar.Text = DGV_Etiquetas.Rows[DGV_Etiquetas.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim();
                    panel4.Visible = true;
                    txtDescripcionCambiar.Focus();
                }
            }
        }

        private void Etiquetas_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            String Codigo = DGV_Etiquetas.Rows[DGV_Etiquetas.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
            
            if (DGV_Etiquetas.Rows[DGV_Etiquetas.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim() ==
                txtDescripcionCambiar.Text.Trim())
            {
                MessageBox.Show("El nombre es el mismo");
                
            }
                else
                    {
                       try
                      {
                          using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
                          {
                          cn.Open();

                          string Columna = _DeterminarColumna(Codigo);
                          
                          string consulta = " UPDATE Muestra SET DescriCliente = '" + txtDescripcionCambiar.Text.Trim() +
                                               "' WHERE " + Columna + " = '" + Codigo + "'";
                          SqlCommand cmd = new SqlCommand(consulta, cn);
                          int dr = cmd.ExecuteNonQuery();
                          DGV_Etiquetas.Rows[DGV_Etiquetas.CurrentCell.RowIndex].Cells[1].Value = txtDescripcionCambiar.Text;
                          panel4.Visible = false;
                          ((Vista.Muestra)Owner).PresionarBotonBuscar(new KeyEventArgs(Keys.Enter));
                              foreach (DataRow fila in DT.Rows)
                              {
                                  if(fila["Codigo"].ToString().Trim() == Codigo.Trim())
                                  {
                                      fila["DescriCliente"] = txtDescripcionCambiar.Text;
                                  
                                  }
                              }
                          }
                    }
                     catch (Exception ex)
                    {
                        throw new Exception("Ocurrio un error al querer modificar la descripcion del siguiente producto: " + Codigo);
          
                    }
                }
    }
        
        
        private string _DeterminarColumna(string codigo)
        {
            switch (codigo.Substring(0, 2))
            {
                case "PT":
                case "YQ":
                case "YF":
                case "YP":
                    return "Producto";
                    break;
                default:
                    return "Articulo";
                    break;
            }
        }

        private void txtDescripcionCambiar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                {
                    button2_Click(null,null);
                }
                    break;  
                case Keys.Escape:
                {
                    txtDescripcionCambiar.Text = "";
                }
            break;
            }
        }
}
}
