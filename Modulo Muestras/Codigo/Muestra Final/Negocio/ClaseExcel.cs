using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;

namespace Negocio
{
    public class ClaseExcel
    {
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel._Workbook oWB;
        Microsoft.Office.Interop.Excel._Worksheet oSheet;

        public void CrearExcel(System.Data.DataTable dt, string path)
        {              
            object misvalue = System.Reflection.Missing.Value;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();

                bool codescreenUpdateState = oXL.ScreenUpdating;
                bool statusBarState = oXL.DisplayStatusBar;
                bool eventsState = oXL.EnableEvents;

                string pathDefinitivo = path + ".xlsx";

                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));

                oWB.SaveCopyAs(pathDefinitivo);

                //oWB.SaveAs(pathDefinitivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                  //  false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                   // Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


                oWB = oXL.Workbooks.Open(pathDefinitivo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                oXL.Calculation = XlCalculation.xlCalculationManual; 

                oXL.ScreenUpdating = false;
                oXL.DisplayStatusBar = false;
                oXL.Calculation = XlCalculation.xlCalculationManual;
                oXL.EnableEvents = false;

                oXL.Visible = false;

                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Cargar header
                oSheet.Cells[1, 1] = "Empresa: ";
                oSheet.Cells[1, 2] = "SURFACTAN S.A.";
                oSheet.Cells[1, 11] = "Fecha: ";
                oSheet.Cells[1, 12] = DateTime.Now.ToShortDateString();
                oSheet.Cells[2, 7] = "Listado de Muestras";

                oSheet.get_Range("L1", "L1").EntireColumn.NumberFormat = "mm/dd/yyyy";              
                oSheet.get_Range("A1", "L2").Font.Bold = true;
                oSheet.get_Range("A1", "L1").Cells.Font.Size = 10;
                oSheet.get_Range("A1", "L2").Cells.Font.Name = "Times New Roman";
                oSheet.get_Range("G2", "G2").Cells.Font.Size = 16;
                oSheet.get_Range("G2", "G2").HorizontalAlignment =
                    Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range("G2", "G2").Cells.Font.Size = 16;
                oSheet.get_Range("A1", "L2").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                oSheet.get_Range("G2", "G2").Borders.LineStyle =
                    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //Agrego los headers
                oSheet.Cells[4, 1] = "Fecha";
                oSheet.Cells[4, 2] = "Codigo";
                oSheet.Cells[4, 3] = "Cantidad";
                oSheet.Cells[4, 4] = "Nombre para el Cliente";
                oSheet.Cells[4, 6] = "Cliente";
                oSheet.Cells[4, 8] = "Observaciones";
                oSheet.Cells[4, 10] = "Lote";
                oSheet.Cells[4, 11] = "Cantidad";
                oSheet.Cells[4, 12] = "Observaciones";

                oSheet.get_Range("A4", "L4").Cells.Font.Size = 8;
                oSheet.get_Range("A4", "L4").Cells.Font.Name = "Times New Roman";
                oSheet.get_Range("A4", "L4").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A4", "L4").HorizontalAlignment =
                    Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                int rango = 6;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[,] valores = new string[dt.Rows.Count, 12];

                    DataRow dr = dt.Rows[i];

                        valores[0,0]  =  dr["Fecha"].ToString();
                        valores[0,1] = dr["Codigo"].ToString();
                        valores[0,2] = dr["Cantidad"].ToString();
                        valores[0, 3] = dr["DescriCliente"].ToString();
                        valores[0, 4] = "";
                        valores[0,5] = dr["Razon"].ToString();
                        valores[0,6] = "";
                        valores[0,7] = dr["Observaciones"].ToString();
                        valores[0,8] = "";
                        valores[0,9] = dr["Lote2"].ToString();
                        valores[0,10] = dr["Cantidad2"].ToString();
                        valores[0,11] = dr["Observaciones2"].ToString();

                    oSheet.get_Range("A" + rango.ToString(), "L" + rango.ToString()).Value2 = valores;
                    oSheet.get_Range("A" + rango.ToString(), "L" + rango.ToString()).Cells.Font.Size = 8;
                    oSheet.get_Range("A" + rango.ToString(), "L" + rango.ToString()).Cells.Font.Name = "Times New Roman";

                    rango += 1;
                }
               

                oXL.Visible = false;
                oXL.UserControl = false;   

                oWB.Save();
                oWB.Close();

                oXL.ScreenUpdating = codescreenUpdateState;
                oXL.DisplayStatusBar = statusBarState;
                oXL.EnableEvents = eventsState;

                MessageBox.Show("El archivo se genero con exito", "Generacion de Excel",
                MessageBoxButtons.OK, MessageBoxIcon.None);              

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error al generar archivo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
