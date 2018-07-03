Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared

Public Class ReportViewer

    Dim nombre As String
    Dim ruta As String
    Dim formula As String
    Dim reporte As New ReportDocument

    Public Sub New(ByVal nombreReporte As String, ByVal rutaReporte As String, ByVal formulaReporte As String)
        InitializeComponent()
        nombre = nombreReporte
        ruta = rutaReporte
        formula = formulaReporte
        reporte.Load(ruta)
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = nombre
        CrystalReportViewer3.SelectionFormula = formula

        CrystalReportViewer3.ReportSource = reporte

        CrystalReportViewer3.Refresh()
    End Sub

    Public Sub ExportarExcel(ByVal WNombre As String, ByVal WDestino As String)

        'Dim exportOptions As ExportOptions
        'Dim diskFileDestinationOptions As New DiskFileDestinationOptions()
        ''Dim formatTypeOptions As New PdfRtfWordFormatOptions()
        'Dim formatTypeOptions As New ExcelFormatOptions()

        'Dim folderPath As String = Trim(WDestino)
        'If Not Directory.Exists(folderPath) Then
        '    Directory.CreateDirectory(folderPath)
        'End If
        'diskFileDestinationOptions.DiskFileName = folderPath & WNombre

        'If Not diskFileDestinationOptions.DiskFileName.EndsWith(".xls") Then
        '    diskFileDestinationOptions.DiskFileName &= ".xls"
        'End If

        'exportOptions = reporte.ExportOptions
        'With exportOptions
        '    .ExportDestinationType = ExportDestinationType.DiskFile
        '    .ExportFormatType = ExportFormatType.PortableDocFormat
        '    .DestinationOptions = diskFileDestinationOptions
        '    .FormatOptions = formatTypeOptions
        'End With

        ''Exporta y crea el XLS.
        reporte.RecordSelectionFormula = formula
        'reporte.Export()

        reporte.ExportToDisk(ExportFormatType.Excel, WDestino.TrimEnd(".xls"))

    End Sub

    Public Sub imprimirReporte()
        reporte.Refresh()
        reporte.RecordSelectionFormula = formula
        reporte.PrintToPrinter(1, False, 0, 0)
    End Sub

    Public Sub descargarComoPDF(ByVal _nombre As String, ByVal destino As String)
        Dim exportOptions As ExportOptions
        Dim diskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim formatTypeOptions As New PdfRtfWordFormatOptions()

        Dim folderPath As String = Trim(destino)
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        diskFileDestinationOptions.DiskFileName = folderPath & _nombre & ".pdf"

        exportOptions = reporte.ExportOptions
        With exportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = diskFileDestinationOptions
            .FormatOptions = formatTypeOptions
        End With

        'Exporta y crea el pdf.
        reporte.RecordSelectionFormula = formula
        reporte.Export()
    End Sub

End Class