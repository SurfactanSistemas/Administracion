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

    Private Sub Reporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.CrystalReportViewer1
            .ReportSource = Me.Reporte
        End With
    End Sub

    Public Sub EstablecerConexion(ByVal Servidor As String, ByVal BaseDatos As String)
        With Me.Reporte
            .DataSourceConnections.Item(0).SetConnection(Trim(Servidor), Trim(BaseDatos), False)
            .Refresh()
        End With
    End Sub

    Private Sub _ReconectarBaseDatos()

        ' MANDAMOS EL PARÁMETRO DE LA EMPRESA.

        If Reporte.ParameterFields.Count > 0 Then

            Dim WParams As ParameterFields = Reporte.ParameterFields

            For Each p As ParameterField In Reporte.ParameterFields
                If Not p.Name.StartsWith("Pm-") Then p.CurrentValues = WParams.Item(p.Name).CurrentValues
            Next

            For Each p As ParameterField In Reporte.ParameterFields
                If p.Name = "Empresa" Then
                    Reporte.SetParameterValue("Empresa", ClasesCompartidas.Globals.NombreEmpresa)
                End If
            Next

            'If Reporte.ParameterFields(0).ReportName.Length = 0 Then
            '    Reporte.SetParameterValue(0, ClasesCompartidas.Globals.NombreEmpresa)
            'End If

        End If

        ' CONECTAMOS CON LA BASE DE DATOS QUE CORRESPONDA.
        Dim cs = ""

        Try
            ' Buscamos el string de conexion.
            cs = ClasesCompartidas.Globals.getConnectionString()
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        ' Extraemos los datos de conexion del string de conexion.
        Dim cnsb As New SqlClient.SqlConnectionStringBuilder(cs)

        ' Asignamos los datos al reporte.
        Reporte.SetDatabaseLogon(cnsb.UserID, cnsb.Password, cnsb.DataSource, cnsb.InitialCatalog)

        Dim conexion As New ConnectionInfo
        conexion.DatabaseName = cnsb.InitialCatalog
        conexion.ServerName = cnsb.DataSource
        conexion.UserID = cnsb.UserID
        conexion.Password = cnsb.Password
        conexion.IntegratedSecurity = False

        Dim tli As New TableLogOnInfo()
        tli.ConnectionInfo = conexion

        ' Volvemos a asignar los datos de conexion pero ahora a cada una de las tablas que tenga el reporte.
        For Each tabla As CrystalDecisions.CrystalReports.Engine.Table In Reporte.Database.Tables

            Dim _logInfo As TableLogOnInfo = tabla.LogOnInfo

            _logInfo.ConnectionInfo = conexion

            tabla.ApplyLogOnInfo(_logInfo)

        Next

        For Each rpt As ReportDocument In Reporte.Subreports

            For Each s As Object In rpt.Database.Tables
                Dim _logInfo As TableLogOnInfo = s.LogOnInfo

                _logInfo.ConnectionInfo = conexion

                s.ApplyLogOnInfo(_logInfo)
            Next

        Next
    End Sub

    Public Sub Mostrar()

        _ReconectarBaseDatos()

        Me.CrystalReportViewer1.SelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        'Me.CrystalReportViewer1.Refresh()
        Me.Show()
        'Me.Dispose()
    End Sub

    Public Sub Imprimir(Optional ByVal cant As Integer = 1)
        'Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)

        _ReconectarBaseDatos()

        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        'Me.Reporte.Refresh()
        Me.Reporte.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Public Sub GuardarPDF(ByVal NombreArchivo As String, Optional ByVal ruta As String = "")
        ruta = IIf(ruta = "", System.Windows.Forms.Application.StartupPath & "/", ruta)

        NombreArchivo = IIf(Regex.IsMatch(NombreArchivo, "(\.pdf)$"), NombreArchivo, NombreArchivo & ".pdf")

        'Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)

        _ReconectarBaseDatos()

        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        'Me.Reporte.Refresh()
        Me.Reporte.ExportToDisk(ExportFormatType.PortableDocFormat, ruta & NombreArchivo)
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
        Else

            If Not ruta.EndsWith("/") Then ruta &= "/"

            Directory.CreateDirectory(ruta)

        End If

        If Formato = ExportFormatType.PortableDocFormat AndAlso Not NombreArchivo.EndsWith(".pdf") Then NombreArchivo &= ".pdf"

        _ReconectarBaseDatos()

        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        'Me.Reporte.Refresh()
        Me.Reporte.ExportToDisk(Formato, ruta & NombreArchivo)

    End Sub

    Public Sub EnviarPorEmail(ByVal NombreArchivo As String, Optional ByVal WEnvioAutomatico As Boolean = False, Optional ByVal Subject As String = "", Optional ByVal Body As String = "", Optional ByVal Direcciones As String = "")

        EnviarEmail(NombreArchivo, WEnvioAutomatico, Subject, Body, Direcciones)

    End Sub

    Private Sub EnviarEmail(ByVal Archivo As String, ByVal EnvioAutomatico As Boolean, Optional ByVal Subject As String = "", Optional ByVal Body As String = "", Optional ByVal Direcciones As String = "")
        Dim oApp As _Application
        Dim oMsg As _MailItem

        Try
            oApp = New Application()

            oMsg = oApp.CreateItem(OlItemType.olMailItem)

            Dim el = oMsg.GetInspector

            oMsg.Subject = Subject
            oMsg.HTMLBody = "<p>" & Body.Replace(vbCrLf, "<br/>") & "<p>" & oMsg.HTMLBody

            oMsg.Attachments.Add(Archivo)

            ' Modificar por los E-Mails que correspondan.
            'oMsg.To = "gferreyra@surfactan.com.ar"
            oMsg.To = Direcciones

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