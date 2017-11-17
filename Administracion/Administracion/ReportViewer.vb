Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class ReportViewer

    Dim nombre As String
    Dim ruta As String
    Dim formula As String
    Public reporte As New ReportDocument

    Public Sub New(ByVal nombreReporte As String, ByVal rutaReporte As String, ByVal formulaReporte As String)
        InitializeComponent()
        nombre = nombreReporte
        ruta = rutaReporte
        formula = formulaReporte
        reporte.Load(ruta)

        CrystalReportViewer1.ReportSource = reporte

    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = nombre

        CrystalReportViewer1.SelectionFormula = formula

        CrystalReportViewer1.ReportSource = reporte

        CrystalReportViewer1.Refresh()
    End Sub

    Public Sub imprimirReporte()
        reporte.RecordSelectionFormula = formula
        reporte.PrintToPrinter(1, True, 0, 0)
    End Sub

    Public Sub descargarComoPDF()
        Dim exportOptions As ExportOptions
        Dim diskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim formatTypeOptions As New PdfRtfWordFormatOptions()

        Dim folderPath As String = Application.StartupPath & "\Reportes\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        diskFileDestinationOptions.DiskFileName = folderPath & nombre & ".pdf"

        exportOptions = reporte.ExportOptions
        With exportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = diskFileDestinationOptions
            .FormatOptions = formatTypeOptions
        End With

        'Exporta y crea el pdf.
        reporte.Export()
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

End Class