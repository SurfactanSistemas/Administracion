using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

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

            if (formula.Trim() != "")
            {
                reporte.RecordSelectionFormula = formula;
            }

            reporte.Refresh();

            reporte.PrintToPrinter(1, true, 0, 0);
        }
    }
}
