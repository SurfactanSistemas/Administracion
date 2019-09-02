Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class ReportViewer

    Dim nombre As String
    Dim nombrePdf As String
    Dim ruta As String
    Dim formula As String
    Dim Direccion As String
    Dim reporte As New ReportDocument

    Public Sub New(ByVal nombreReporte As String, ByVal rutaReporte As String, ByVal formulaReporte As String, ByVal nombreExporta As String, ByVal DireccionEntrega As String)
        InitializeComponent()
        nombre = nombreReporte
        nombrePdf = nombreExporta
        ruta = rutaReporte
        formula = formulaReporte
        Direccion = DireccionEntrega

        'MsgBox(ruta)

        reporte.Load(ruta)
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = nombre
        CrystalReportViewer1.SelectionFormula = formula
        CrystalReportViewer1.ReportSource = reporte
        CrystalReportViewer1.Refresh()
    End Sub

    Public Sub imprimirReporte()
        reporte.PrintToPrinter(1, False, 1, 1)
    End Sub

    Public Sub descargarComoPDF()
        Dim exportOptions As ExportOptions
        Dim diskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim formatTypeOptions As New PdfRtfWordFormatOptions()

        Dim folderPath As String

        If ImpreCrystal.pasanombre.Text = "" Then
            folderPath = "c:\orden\"
        Else
            folderPath = ImpreCrystal.pasanombre.Text
        End If

        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        diskFileDestinationOptions.DiskFileName = folderPath & nombrePdf & ".pdf"

        exportOptions = reporte.ExportOptions
        With exportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = diskFileDestinationOptions
            .FormatOptions = formatTypeOptions
        End With

        reporte.RecordSelectionFormula = formula
        If LTrim(RTrim(Direccion)) <> "" Then
            reporte.SetParameterValue("DireccionI", Direccion)
        End If

        'Exporta y crea el pdf.
        reporte.Export()
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Text = nombre
        CrystalReportViewer1.SelectionFormula = formula
        CrystalReportViewer1.ReportSource = reporte
        CrystalReportViewer1.Refresh()
    End Sub

End Class