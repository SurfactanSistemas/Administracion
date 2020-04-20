﻿Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop.Outlook
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO

Public Class VistaPrevia
    Public Property Reporte As ReportDocument

    Public Property Formula As String

    Private Sub Reporte_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        With CrystalReportViewer1
            .ReportSource = Reporte
        End With

    End Sub

    Public Sub EstablecerConexion(ByVal Servidor As String, ByVal BaseDatos As String)
        With Reporte
            .DataSourceConnections.Item(0).SetConnection(Trim(Servidor), Trim(BaseDatos), False)
        End With
    End Sub

    Public Sub _ReconectarBaseDatos()

        ' CONECTAMOS CON LA BASE DE DATOS QUE CORRESPONDA.
        Dim cs = ""

        Try
            ' Buscamos el string de conexion.
            cs = _ConectarA()
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        ' Extraemos los datos de conexion del string de conexion.
        Dim cnsb As New SqlConnectionStringBuilder(cs)

        ' Asignamos los datos al reporte.
        Reporte.SetDatabaseLogon(cnsb.UserID, cnsb.Password, cnsb.DataSource, cnsb.InitialCatalog)

        Dim conexion As New ConnectionInfo
        conexion.DatabaseName = cnsb.InitialCatalog
        conexion.ServerName = cnsb.DataSource
        conexion.UserID = cnsb.UserID
        conexion.Password = cnsb.Password

        Dim tli As New TableLogOnInfo()
        tli.ConnectionInfo = conexion

        ' Volvemos a asignar los datos de conexion pero ahora a cada una de las tablas que tenga el reporte.
        For Each tabla As CrystalDecisions.CrystalReports.Engine.Table In Reporte.Database.Tables

            Dim _logInfo As TableLogOnInfo = tabla.LogOnInfo

            _logInfo.ConnectionInfo = conexion

            tabla.ApplyLogOnInfo(_logInfo)

        Next
    End Sub

    Public Sub Mostrar()

        _ReconectarBaseDatos()

        With CrystalReportViewer1

            .ReportSource = Reporte

            If Not String.IsNullOrEmpty(Formula) Then

                .SelectionFormula = Formula

            End If

        End With

        Show()

    End Sub

    Public Sub Imprimir(Optional ByVal cant As Integer = 1)
        
        _ReconectarBaseDatos()

        Reporte.RecordSelectionFormula = IIf(IsNothing(Formula), "", Formula)
        Reporte.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Public Sub GuardarPDF(ByVal NombreArchivo As String, Optional ByVal ruta As String = "")
        ruta = IIf(ruta = "", Windows.Forms.Application.StartupPath & "/", ruta)

        NombreArchivo = IIf(Regex.IsMatch(NombreArchivo, "(\.pdf)$"), NombreArchivo, NombreArchivo & ".pdf")

        _ReconectarBaseDatos()

        Reporte.RecordSelectionFormula = IIf(IsNothing(Formula), "", Formula)
        Reporte.ExportToDisk(ExportFormatType.PortableDocFormat, ruta & NombreArchivo)
    End Sub

    Public Sub Exportar(ByVal NombreArchivo As String, ByVal Formato As ExportFormatType, Optional ByVal ruta As String = "")

        If ruta.Trim = "" Then
            With SaveFileDialog1

                .FileName = NombreArchivo

                Select Case Formato
                    Case ExportFormatType.PortableDocFormat
                        .Filter = "PDF|*.pdf"
                    Case ExportFormatType.Excel
                        .Filter = "Excel|*.xls"
                    Case ExportFormatType.WordForWindows
                        .Filter = "Word|*.doc"
                End Select

                If .ShowDialog(Me) <> DialogResult.OK Then Exit Sub

                If .FileName <> "" Then
                    ruta = .FileName
                    NombreArchivo = ""
                End If

            End With
        End If

        _ReconectarBaseDatos()

        Reporte.RecordSelectionFormula = IIf(IsNothing(Formula), "", Formula)
        Reporte.ExportToDisk(Formato, ruta & NombreArchivo)

    End Sub

    Public Sub EnviarPorEmail(ByVal NombreArchivo As String, Optional ByVal WEnvioAutomatico As Boolean = False)

        EnviarEmail(NombreArchivo, WEnvioAutomatico)

    End Sub

    Private Sub EnviarEmail(ByVal Archivo As String, ByVal EnvioAutomatico As Boolean)
        Dim oApp As _Application
        Dim oMsg As _MailItem

        Try
            oApp = New Application()

            oMsg = oApp.CreateItem(OlItemType.olMailItem)
            oMsg.Subject = "SAC"
            oMsg.Body = "Envio de SAC"

            oMsg.Attachments.Add(Archivo)

            ' Modificar por los E-Mails que correspondan.
            'oMsg.To = "gferreyra@surfactan.com.ar"

            If EnvioAutomatico Then
                oMsg.Send()
            Else
                oMsg.Display()
            End If

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        End Try

    End Sub

    Public Sub MergePDFs(ByVal WRuta As String, ByVal WNombreArchivo As String)

        Dim Archivos As String() = Directory.GetFiles(WRuta, "*.pdf")
        Dim outPdf = New PdfDocument()

        For Each file As String In Archivos
            Using one As PdfDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import)

                CopyPages(one, outPdf)

            End Using
        Next

        outPdf.Save(WRuta & WNombreArchivo)

    End Sub

    Private Sub CopyPages(ByVal _from As PdfDocument, ByRef _to As PdfDocument)
        For i = 0 To _from.PageCount - 1
            _to.AddPage(_from.Pages(i))
        Next

    End Sub
    Public Sub DesdeArchivo(ByVal s As String)
        Reporte = New ReportDocument
        Reporte.Load(s)
    End Sub
End Class