using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Exception = System.Exception;

namespace Modulo_Capacitacion.Listados
{
    public partial class VistaPrevia : Form
    {
        public VistaPrevia()
        {
            InitializeComponent();
        }

        public void CargarReporte(ReportDocument reporte)
        {
            CRVInforme.ReportSource = reporte;
            CRVInforme.Refresh();
        }

        public void CargarReporte(ReportDocument reporte, string formula)
        {
            CRVInforme.ReportSource = reporte;
            CRVInforme.SelectionFormula = formula;
            CRVInforme.Refresh();
        }

        public void Imprimir()
        {
            string formula = CRVInforme.SelectionFormula;
            ReportDocument reporte = CRVInforme.ReportSource as ReportDocument;

            if (reporte == null) return;

            ParameterFields parameters = reporte.ParameterFields;

            reporte.Refresh();

            foreach (ParameterField p in parameters)
            {
                reporte.SetParameterValue(p.Name, p.CurrentValues[0]);
            }

            if (formula != null && formula.Trim() != "")
            {
                reporte.RecordSelectionFormula = formula;
            }

            //reporte.Refresh();

            reporte.PrintToPrinter(1, true, 0, 0);
        }

        public void GuardarComoPDF(string WNombreArchivo = "", string WRutaArchivo = "")
        {
            string formula = CRVInforme.SelectionFormula;
            ReportDocument reporte = CRVInforme.ReportSource as ReportDocument;
            
            if (reporte == null) return;

            ParameterFields parameters = reporte.ParameterFields;

            reporte.Refresh();

            foreach (ParameterField p in parameters)
            {
                reporte.SetParameterValue(p.Name, p.CurrentValues[0]);
            }

            if (formula.Trim() != "")
            {
                reporte.RecordSelectionFormula = formula;
            }

            // Determinamos en caso de no tener una ruta definida por el usuario, lo guardamos en el escritorio del mismo.
            if (WRutaArchivo.Trim() == "")
            {
                WRutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }

            if (WNombreArchivo.Trim() == "") WNombreArchivo = "Reporte-" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";

            if (!WNombreArchivo.EndsWith(".pdf")) WNombreArchivo = WNombreArchivo + ".pdf";

            reporte.ExportToDisk(ExportFormatType.PortableDocFormat, WRutaArchivo + "\\" + WNombreArchivo);
            //reporte.SaveAs(WRutaArchivo + "\\" + WNombreArchivo);
        }

        private void BorrarPDF(string WRutaArchivo)
        {
            try
            {
                if (!WRutaArchivo.EndsWith(".pdf")) WRutaArchivo = WRutaArchivo + ".pdf";

                if (File.Exists(WRutaArchivo))
                {
                    File.Delete(WRutaArchivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EnviarPorEmail(string WDirecciones = "", string WNombreArchivo = "", string WAsunto = "", string WCuerpo = "", string cc = "", string cco = "")
        {
            try
            {
                var oApp = new Application();

                Thread.Sleep(1000);

                GuardarComoPDF(WNombreArchivo); //Guardamos el archivo pdf en el escritorio de manera temporal.
                
                var mailItem = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                string WRutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + WNombreArchivo + ".pdf";

                mailItem.Subject = WAsunto;
                mailItem.HTMLBody = WCuerpo;
                mailItem.To = WDirecciones;
                mailItem.Attachments.Add(WRutaArchivo);

                // Si se pasaron las direcciones, se envia directamente el email, sino se abre en una ventana para que el usuario lo termine de completar.
                if (WDirecciones == "")
                {
                    mailItem.Display();
                }
                else
                {
                    mailItem.Send();   
                }
                
                // Borramos el archivo temporal de el escritorio.
                BorrarPDF(WRutaArchivo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
