using System.Windows.Forms;

namespace Modulo_Capacitacion.Reportes
{
    public partial class ListadoDeCursosRealizadosPorLegajo : Form
    {
        public ListadoDeCursosRealizadosPorLegajo(int ano, int curso)
        {
            InitializeComponent();
            CargarReporte(ano,curso);
        }

        private void CargarReporte(int ano, int curso)
        {
            

            ////aca debo tener los parametros
            //ReportDocument cryRpt = new ReportDocument();

            ////cryRpt.Load(ConfigurationManager.AppSettings["REPORTES"] + @"\Rpt_ListadoDeCursosRealizadosPorLegajo.rpt");
            //cryRpt.Load(ConfigurationManager.AppSettings["REPORTES"] + @"\WListaCursoPlani.rpt");

            //crystalReportViewer1.ReportSource = cryRpt;

            //crystalReportViewer1.SelectionFormula = "{Cronograma.Curso}=" + curso + " AND {Cronograma.Ano}=" + ano + "";

            //crystalReportViewer1.Refresh();
        }

        //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
        //ParameterFieldDefinitions crParameterFieldDefinitions;
        //ParameterFieldDefinition crParameterFieldDefinition;
        //ParameterValues crParameterValues = new ParameterValues();

        //crParameterDiscreteValue.Value = ano;
        //crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
        //crParameterFieldDefinition = crParameterFieldDefinitions["Año"];
        //crParameterValues = crParameterFieldDefinition.CurrentValues;
        //crParameterValues.Clear();
        //crParameterValues.Add(crParameterDiscreteValue);
        //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

        ////
        //ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
        //ParameterFieldDefinitions crParameterFieldDefinitions2;
        //ParameterFieldDefinition crParameterFieldDefinition2;
        //ParameterValues crParameterValues2 = new ParameterValues();

        //crParameterDiscreteValue2.Value = curso;
        //crParameterFieldDefinitions2 = cryRpt.DataDefinition.ParameterFields;
        //crParameterFieldDefinition2 = crParameterFieldDefinitions2["Curso"];
        //crParameterValues2 = crParameterFieldDefinition2.CurrentValues;
        //crParameterValues2.Clear();
        //crParameterValues2.Add(crParameterDiscreteValue2);
        //crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2);
        ////
        //ParameterDiscreteValue crParameterDiscreteValue3 = new ParameterDiscreteValue();
        //ParameterFieldDefinitions crParameterFieldDefinitions3;
        //ParameterFieldDefinition crParameterFieldDefinition3;
        //ParameterValues crParameterValues3 = new ParameterValues();

        //crParameterDiscreteValue3.Value = 0.0;
        //crParameterFieldDefinitions3 = cryRpt.DataDefinition.ParameterFields;
        //crParameterFieldDefinition3 = crParameterFieldDefinitions3["Realizado"];
        //crParameterValues3 = crParameterFieldDefinition3.CurrentValues;
        //crParameterValues3.Clear();
        //crParameterValues3.Add(crParameterDiscreteValue3);
        //crParameterFieldDefinition3.ApplyCurrentValues(crParameterValues3);

    }
}
