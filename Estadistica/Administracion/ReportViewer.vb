Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class ReportViewer

    Dim nombre As String
    Dim ruta As String
    Dim formula As String
    Dim reporte As New ReportDocument
    Dim RpDatos As New CrystalDecisions.Shared.ParameterValues()
    Dim DsNombre As New CrystalDecisions.Shared.ParameterDiscreteValue()



    Public Sub New(ByVal nombreReporte As String, ByVal rutaReporte As String, ByVal formulaReporte As String)
        InitializeComponent()
        nombre = nombreReporte
        ruta = rutaReporte
        formula = formulaReporte
        reporte.Load(ruta)

        'DsNombre.Value = "Surfactan"
        'RpDatos.Add(DsNombre)
        'reporte.DataDefinition.ParameterFields("txtEmpresa").ApplyCurrentValues(RpDatos)
        'RpDatos.Clear()

    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = nombre
        CrystalReportViewer1.SelectionFormula = formula



        'reporte.SetDatabaseLogon("usuarioadmin", "usuarioadmin", "(LOCAL)\SQLEXPRESS", "Surfactan_II")
        'For Each tabla As Table In reporte.Database.Tables
        '    Dim conexion As New ConnectionInfo
        '    conexion.DatabaseName = "Surfactan_II"
        '    conexion.ServerName = "(LOCAL)\SQLEXPRESS"
        '    conexion.UserID = "usuarioadmin"
        '    conexion.Password = "usuarioadmin"
        '    tabla.LogOnInfo.ConnectionInfo = conexion

        '    'tabla.ConnectionProperties.Add("DSN", )
        '    'tabla.ConnectionProperties.Add("Server", "(LOCAL)\SQLEXPRESS")
        '    'tabla.ConnectionProperties.Add("Database", "surfactan_ii")
        '    'tabla.ConnectionProperties.Add("User ID", "usuarioadmin")
        '    'tabla.ConnectionProperties.Add("Password", "usuarioadmin")
        '    'tabla.ConnectionProperties.Add("UseDSNProperties", False)
        'Next

        CrystalReportViewer1.ReportSource = reporte
        'Dim conexion As New ConnectionInfo
        'conexion.DatabaseName = "Surfactan_II"
        'conexion.ServerName = "(LOCAL)\SQLEXPRESS"
        'conexion.UserID = "usuarioadmin"
        'conexion.Password = "usuarioadmin"
        'For Each logInfo In CrystalReportViewer1.LogOnInfo
        '    logInfo.ConnectionInfo = conexion
        'Next


        CrystalReportViewer1.Refresh()
    End Sub

    Public Sub imprimirReporte()
        reporte.Refresh()
        reporte.PrintToPrinter(1, False, 1, 1)
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