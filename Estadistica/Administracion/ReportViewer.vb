﻿Imports CrystalDecisions.CrystalReports.Engine
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

        _ReconectarBaseDatos()

        reporte.SetParameterValue(0, ClasesCompartidas.Globals.NombreEmpresa)
    End Sub

    Private Sub _ReconectarBaseDatos()


        ' CONECTAMOS CON LA BASE DE DATOS QUE CORRESPONDA.
        Dim cs = ""

        Try
            ' Buscamos el string de conexion.
            cs = ClasesCompartidas.Globals.getConnectionString()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        ' Extraemos los datos de conexion del string de conexion.
        Dim cnsb As New SqlClient.SqlConnectionStringBuilder(cs)

        ' Asignamos los datos al reporte.
        reporte.SetDatabaseLogon(cnsb.UserID, cnsb.Password, cnsb.DataSource, cnsb.InitialCatalog)

        Dim conexion As New ConnectionInfo
        conexion.DatabaseName = cnsb.InitialCatalog
        conexion.ServerName = cnsb.DataSource
        conexion.UserID = cnsb.UserID
        conexion.Password = cnsb.Password
        'conexion.IntegratedSecurity = True

        Dim tli As New TableLogOnInfo()
        tli.ConnectionInfo = conexion

        ' Volvemos a asignar los datos de conexion pero ahora a cada una de las tablas que tenga el reporte.
        For Each tabla As Table In reporte.Database.Tables

            Dim _logInfo As TableLogOnInfo = tabla.LogOnInfo

            _logInfo.ConnectionInfo = conexion

            tabla.ApplyLogOnInfo(_logInfo)

        Next
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = nombre
        CrystalReportViewer1.SelectionFormula = formula

        _ReconectarBaseDatos()

        CrystalReportViewer1.ReportSource = reporte

        CrystalReportViewer1.Refresh()
    End Sub

    Public Sub imprimirReporte()
        reporte.Refresh()
        reporte.RecordSelectionFormula = formula
        reporte.PrintToPrinter(1, False, 0, 0)
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
        reporte.RecordSelectionFormula = formula
        reporte.Export()
    End Sub

End Class