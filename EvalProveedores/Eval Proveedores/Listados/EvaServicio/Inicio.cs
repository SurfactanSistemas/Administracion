using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Logica_Negocio;

namespace Eval_Proveedores.Listados.EvaServicio
{
    public partial class Inicio : Form
    {

        EvaTransBOL ETBOL = new EvaTransBOL();
        EvaVariosBOL EVBOL = new EvaVariosBOL();
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtProveedores;
        DataTable dtEva;
        string Tipo = "";
        int Tipo1;
        int Tipo2;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            dtProveedores = PBOL.Lista();
            dtProveedores.Rows.InsertAt(dtProveedores.NewRow(), 0);
            CargarCodProveedor();
            CargarDescProveedor();


        }

        private void CargarDescProveedor()
        {
            TB_DescProve.DataSource = dtProveedores;
            TB_DescProve.DisplayMember = "Nombre";
            TB_DescProve.ValueMember = "Proveedor";

            AutoCompleteStringCollection stringDescProve = new AutoCompleteStringCollection();
            foreach (DataRow row in dtProveedores.Rows)
            {
                stringDescProve.Add(Convert.ToString(row["Nombre"]));

            }

            TB_DescProve.AutoCompleteCustomSource = stringDescProve;
            TB_DescProve.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_DescProve.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodProveedor()
        {
            TB_Prove.DataSource = dtProveedores;
            TB_Prove.DisplayMember = "Proveedor";
            TB_Prove.ValueMember = "Proveedor";

            AutoCompleteStringCollection stringCodProve = new AutoCompleteStringCollection();
            foreach (DataRow row in dtProveedores.Rows)
            {
                stringCodProve.Add(Convert.ToString(row["Proveedor"]));

            }

            TB_Prove.AutoCompleteCustomSource = stringCodProve;
            TB_Prove.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Prove.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            Tipo = "Pantalla";
            Imprimir();
        }

        private void Bt_Imprimir_Click(object sender, EventArgs e)
        {
            Tipo = "Imprimir";
            Imprimir();
        }

        private void Imprimir()
        {
            try
            {
                if (TB_Prove.Text == "") throw new Exception("Se debe ingresar el proveedor");

                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                if (CB_Tipo.Text == "") throw new Exception("Se debe elegir un tipo");

                string PeriodoDesde = TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2);

                string PeriodoHasta = TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2);

                Int64 Prove = Int64.Parse(TB_Prove.Text);

                BuscarTipo();

                

                dtEva = EVBOL.EvaServ( Prove, PeriodoDesde, PeriodoHasta, Tipo1, Tipo2 );

                CompletarLista();

                string TipoServ = CB_Tipo.Text;

                ImpreEvaServ Impre = new ImpreEvaServ(dtEva, TipoServ, Tipo);
                
                Impre.ShowDialog();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
                
        }



        private void CompletarLista()
        {
            
            
            dtEva.Columns.Add("DescEstado", typeof(string));
            dtEva.Columns.Add("DescCalif11", typeof(string));
            dtEva.Columns.Add("DescCalif12", typeof(string));
            dtEva.Columns.Add("DescCalif13", typeof(string));
            dtEva.Columns.Add("DescCalif14", typeof(string));
            dtEva.Columns.Add("DescCalif15", typeof(string));
            dtEva.Columns.Add("DescCalif21", typeof(string));
            dtEva.Columns.Add("DescCalif22", typeof(string));
            dtEva.Columns.Add("DescCalif23", typeof(string));
            dtEva.Columns.Add("DescCalif24", typeof(string));
            dtEva.Columns.Add("DescCalif25", typeof(string));
            dtEva.Columns.Add("DescCalif31", typeof(string));
            dtEva.Columns.Add("DescCalif32", typeof(string));
            dtEva.Columns.Add("DescCalif33", typeof(string));
            dtEva.Columns.Add("DescCalif34", typeof(string));
            dtEva.Columns.Add("DescCalif35", typeof(string));

            
            foreach (DataRow fila in dtEva.Rows)
            {
               
                   
                        
                        if (fila["Estado"].ToString() == "")
                        {
                            fila[39] = "Sin Evaluar";

                        }
                        else
                        {
                            if (int.Parse(fila["Estado"].ToString()) == -1)
                            {
                                fila[39] = "Inhabilitado";

                            }
                            else
                            {
                                fila[39] = "Habilitado";
                            }
                        }

                        if (fila[34].ToString()  != "0")
                        {
                            for (int i = 16; i < 21; i++)
                            {
                                if ((fila[i].ToString() == "") || (int.Parse(fila[i].ToString()) == 0))
                                {
                                    fila[i + 24] = "";
                                }

                                else if (i == 16)
                                {
                                    switch (int.Parse(fila[i].ToString()))
                                    {
                                        case 1:
                                            fila[i + 24] = "Cumple";
                                            break;

                                        case 2:
                                            fila[i + 24] = "No Cumple";
                                            break;

                                    }
                                }

                                else
                                {
                                    switch (int.Parse(fila[i].ToString()))
                                    {
                                        case 1:
                                            fila[i + 24] = "Cumple";
                                            break;

                                        case 2:
                                            fila[i + 24] = "Parcial";
                                            break;

                                        case 3:
                                            fila[i + 24] = "No Cumple";
                                            break;

                                        case 4:
                                            fila[i + 24] = "No Aplica";
                                            break;
                                    }
                                }



                            }
                        }

                        if (fila[35].ToString() != "0")
                        {
                            for (int i = 21; i < 26; i++)
                            {
                                if ((fila[i].ToString() == "") || (int.Parse(fila[i].ToString()) == 0))
                                {
                                    fila[i + 24] = "";
                                }

                                else if (i == 21)
                                {
                                    switch (int.Parse(fila[i].ToString()))
                                    {
                                        case 1:
                                            fila[i + 24] = "Cumple";
                                            break;

                                        case 2:
                                            fila[i + 24] = "No Cumple";
                                            break;

                                    }
                                }

                                else
                                {
                                    switch (int.Parse(fila[i].ToString()))
                                    {
                                        case 1:
                                            fila[i + 24] = "Cumple";
                                            break;

                                        case 2:
                                            fila[i + 24] = "Parcial";
                                            break;

                                        case 3:
                                            fila[i + 24] = "No Cumple";
                                            break;

                                        case 4:
                                            fila[i + 24] = "No Aplica";
                                            break;
                                    }
                                }



                            }
                        }



                        if (fila[36].ToString() != "0")
                        {
                            for (int i = 26; i < 31; i++)
                            {
                                if ((fila[i].ToString() == "") || (int.Parse(fila[i].ToString()) == 0))
                                {
                                    fila[i + 24] = "";
                                }

                                else if (i == 21)
                                {
                                    switch (int.Parse(fila[i].ToString()))
                                    {
                                        case 1:
                                            fila[i + 24] = "Cumple";
                                            break;

                                        case 2:
                                            fila[i + 24] = "No Cumple";
                                            break;

                                    }
                                }

                                else
                                {
                                    switch (int.Parse(fila[i].ToString()))
                                    {
                                        case 1:
                                            fila[i + 24] = "Cumple";
                                            break;

                                        case 2:
                                            fila[i + 24] = "Parcial";
                                            break;

                                        case 3:
                                            fila[i + 24] = "No Cumple";
                                            break;

                                        case 4:
                                            fila[i + 24] = "No Aplica";
                                            break;
                                    }
                                }



                            }
                        }


                        
                    
                

            }

            
        }
        private void BuscarTipo()
        {
            switch (CB_Tipo.SelectedIndex)
            {
                case 1:
                    Tipo1 = 2;
                    Tipo2 = 4;
                    break;

                case 2:
                    Tipo1 = 2;
                    Tipo2 = 2;
                    break;

                case 3:
                    Tipo1 = 3;
                    Tipo2 = 3;
                    break;

                case 4:
                    Tipo1 = 4;
                    Tipo2 = 4;
                    break;
            }
        }
        

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
