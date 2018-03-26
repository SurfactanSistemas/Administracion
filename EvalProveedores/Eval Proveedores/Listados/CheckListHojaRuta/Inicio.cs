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
using System.Text.RegularExpressions;

namespace Eval_Proveedores.Listados.CheckListHojaRuta
{
    public partial class Inicio : Form
    {

        string Tipo = "";
        string PeriodoDesde;
        string PeriodoHasta;
        CheckListBOL HBOL = new CheckListBOL();
        DataTable dtExpreso1 = new DataTable();
        DataTable dtExpreso3 = new DataTable();
        int CantItem1Exp1 = 0;
        int CantItem2Exp1 = 0;
        int CantItem3Exp1 = 0;
        int CantItem4Exp1 = 0;
        int CantItem5Exp1 = 0;
        int CantItem6Exp1 = 0;
        int CantItem7Exp1 = 0;
        int CantItem8Exp1 = 0;
        int CantItem1Exp2 = 0;
        int CantItem2Exp2 = 0;
        int CantItem3Exp2 = 0;
        int CantItem4Exp2 = 0;
        int CantItem5Exp2 = 0;
        int CantItem6Exp2 = 0;
        int CantItem7Exp2 = 0;
        int CantItem8Exp2 = 0;
        int CantItem1Tot = 0;
        int CantItem2Tot = 0;
        int CantItem3Tot = 0;
        int CantItem4Tot = 0;
        int CantItem5Tot = 0;
        int CantItem6Tot = 0;
        int CantItem7Tot = 0;
        int CantItem8Tot = 0;


        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarDatatable1();
            CargarDatatable2();
        }

        private void CargarDatatable1()
        {
            dtExpreso1.Columns.Add("Hoja", typeof(string));
            dtExpreso1.Columns.Add("Fecha", typeof(string));
            dtExpreso1.Columns.Add("Expreso", typeof(string));
            dtExpreso1.Columns.Add("Chapa", typeof(string));
            dtExpreso1.Columns.Add("Chofer", typeof(string));
            dtExpreso1.Columns.Add("Item1", typeof(string));
            dtExpreso1.Columns.Add("Item2", typeof(string));
            dtExpreso1.Columns.Add("Item3", typeof(string));
            dtExpreso1.Columns.Add("Item4", typeof(string));
            dtExpreso1.Columns.Add("Item5", typeof(string));
            dtExpreso1.Columns.Add("Item6", typeof(string));
            dtExpreso1.Columns.Add("Item7", typeof(string));
            dtExpreso1.Columns.Add("Item8", typeof(string));
            dtExpreso1.Columns.Add("Placa", typeof(string));
            dtExpreso1.Columns.Add("Rombo", typeof(string));
            dtExpreso1.Columns.Add("Observaciones", typeof(string));
            dtExpreso1.Columns.Add("DescExpreso", typeof(string));
        }

        private void CargarDatatable2()
        {
            dtExpreso3.Columns.Add("Hoja", typeof(string));
            dtExpreso3.Columns.Add("Fecha", typeof(string));
            dtExpreso3.Columns.Add("Expreso", typeof(string));
            dtExpreso3.Columns.Add("Chapa", typeof(string));
            dtExpreso3.Columns.Add("Chofer", typeof(string));
            dtExpreso3.Columns.Add("Item1", typeof(string));
            dtExpreso3.Columns.Add("Item2", typeof(string));
            dtExpreso3.Columns.Add("Item3", typeof(string));
            dtExpreso3.Columns.Add("Item4", typeof(string));
            dtExpreso3.Columns.Add("Item5", typeof(string));
            dtExpreso3.Columns.Add("Item6", typeof(string));
            dtExpreso3.Columns.Add("Item7", typeof(string));
            dtExpreso3.Columns.Add("Item8", typeof(string));
            dtExpreso3.Columns.Add("Placa", typeof(string));
            dtExpreso3.Columns.Add("Rombo", typeof(string));
            dtExpreso3.Columns.Add("Observaciones", typeof(string));
            dtExpreso3.Columns.Add("DescExpreso", typeof(string));
        }
        

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            Tipo = "Pantalla";
            Imprimir();
        }

        private void Imprimir()
        {
            try
            {
                if (TB_Desde.Text == "") throw new Exception("Se debe ingresar la fecha desde donde se desea filtrar");

                if (TB_Hasta.Text == "") throw new Exception("Se debe ingresar la fecha hasta donde se desea filtrar");

                PeriodoDesde = TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2);

                PeriodoHasta = TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2);

                DataTable dtInforme = HBOL.ListaFecha(PeriodoDesde, PeriodoHasta);

                ArmarDT(dtInforme);

                ImpreHojaRuta Impre = new ImpreHojaRuta(dtExpreso1, dtExpreso3, CantItem1Exp1, CantItem2Exp1, CantItem3Exp1, CantItem4Exp1, CantItem5Exp1,  CantItem6Exp1,  CantItem7Exp1,  CantItem8Exp1, CantItem1Exp2, CantItem2Exp2, CantItem3Exp2, CantItem4Exp2, CantItem5Exp2,  CantItem6Exp2,  CantItem7Exp2,  CantItem8Exp2, CantItem1Tot,  CantItem2Tot, CantItem3Tot,  CantItem4Tot,  CantItem5Tot,  CantItem6Tot,  CantItem7Tot,  CantItem8Tot, Tipo);
                    
                Impre.ShowDialog();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //ARMAR DOS DATATABLE PARA EXPRESO1 Y EXPRESO3
        private void ArmarDT(DataTable dtInforme)
        {
            DataRow filaEncontrada;
            foreach(DataRow fila in dtInforme.Rows)
            {
                filaEncontrada = fila;
                //SI EXPRESO ES 1 SE CARGA EN EL DATATABLE EXPRESO1
                if (fila[3].ToString() == "1")
                {

                    dtExpreso1.ImportRow(fila);

                    //CONSULTO SI ITEM 1 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[6].ToString() != "")
                    {
                        CantItem1Exp1 = CantItem1Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 2 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[7].ToString() != "")
                    {
                        CantItem2Exp1 = CantItem2Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 3 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[8].ToString() != "")
                    {
                        CantItem3Exp1 = CantItem3Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 4 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[9].ToString() != "")
                    {
                        CantItem4Exp1 = CantItem4Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 5 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[10].ToString() != "")
                    {
                        CantItem5Exp1 = CantItem5Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 6 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[11].ToString() != "")
                    {
                        CantItem6Exp1 = CantItem6Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 7 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[12].ToString() != "")
                    {
                        CantItem7Exp1 = CantItem7Exp1 + 1;
                    }

                    //CONSULTO SI ITEM 8 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[13].ToString() != "")
                    {
                        CantItem8Exp1 = CantItem8Exp1 + 1;
                    }
                }

                //SI EXPRESO ES 3 SE CARGA EN EL DATATABLE EXPRESO3
                if (fila[3].ToString() == "3")
                {
                    

                    
                    dtExpreso3.ImportRow(fila);
                    

                    //CONSULTO SI ITEM 1 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[6].ToString() != "")
                    {
                        CantItem1Exp2 = CantItem1Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 2 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[7].ToString() != "")
                    {
                        CantItem2Exp2 = CantItem2Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 3 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[8].ToString() != "")
                    {
                        CantItem3Exp2 = CantItem3Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 4 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[9].ToString() != "")
                    {
                        CantItem4Exp2 = CantItem4Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 5 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[10].ToString() != "")
                    {
                        CantItem5Exp2 = CantItem5Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 6 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[11].ToString() != "")
                    {
                        CantItem6Exp2 = CantItem6Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 7 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[12].ToString() != "")
                    {
                        CantItem7Exp2 = CantItem7Exp2 + 1;
                    }

                    //CONSULTO SI ITEM 8 ES MAYOR QUE CERO PARA SUMARLE 1 A LA CANTIDAD
                    if (fila[13].ToString() != "")
                    {
                        CantItem8Exp2 = CantItem8Exp2 + 1;
                    }
                }

                


            }

            CantItem1Tot = CantItem1Exp1 + CantItem1Exp2;
            CantItem2Tot = CantItem2Exp1 + CantItem2Exp2;
            CantItem3Tot = CantItem3Exp1 + CantItem3Exp2;
            CantItem4Tot = CantItem4Exp1 + CantItem4Exp2;
            CantItem5Tot = CantItem5Exp1 + CantItem5Exp2;
            CantItem6Tot = CantItem6Exp1 + CantItem6Exp2;
            CantItem7Tot = CantItem7Exp1 + CantItem7Exp2;
            CantItem8Tot = CantItem8Exp1 + CantItem8Exp2;

        }
    }
}
