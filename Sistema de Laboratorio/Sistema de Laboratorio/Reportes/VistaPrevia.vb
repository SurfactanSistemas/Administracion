Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text.RegularExpressions

Public Class VistaPrevia
    Public Property Reporte As ReportDocument

    Public Property Formula As String

    Private Sub Reporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.CrystalReportViewer1
            .ReportSource = Me.Reporte
            .Refresh()
        End With

    End Sub

    Public Sub EstablecerConexion(ByVal Servidor As String, ByVal BaseDatos As String)
        With Me.Reporte
            .DataSourceConnections.Item(0).SetConnection(Trim(Servidor), Trim(BaseDatos), False)
            .Refresh()
        End With
    End Sub

    Public Sub _ReconectarBaseDatos()

        ' MANDAMOS EL PARÁMETRO DE LA EMPRESA.

        'If Reporte.ParameterFields.Count > 0 Then

        '    Dim WMostrarHumedad = OrDefault(Reporte.ParameterFields("MostrarHumedad"), 0)
        '    Reporte.SetParameterValue("MostrarHumedad", WMostrarHumedad)

        '    '    For i = 0 To Reporte.ParameterFields.Count - 1

        '    '        If Reporte.ParameterFields(i).CurrentValues.Count = 0 Then
        '    '            Reporte.SetParameterValue(i, "")
        '    '        Else
        '    '            If Reporte.ParameterFields(i).ParameterValueT Then
        '    '                Reporte.SetParameterValue(i, Reporte.ParameterFields(i).CurrentValues(0))
        '    '            End If

        '    '    Next
        'End If

        ' CONECTAMOS CON LA BASE DE DATOS QUE CORRESPONDA.
        Dim cs = ""

        Try
            ' Buscamos el string de conexion.
            cs = Helper._ConectarA("Surfactan_III") 'ClasesCompartidas.Globals.getConnectionString()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        ' Extraemos los datos de conexion del string de conexion.
        Dim cnsb As New SqlClient.SqlConnectionStringBuilder(cs)

        ' Asignamos los datos al reporte.
        Reporte.SetDatabaseLogon(cnsb.UserID, cnsb.Password, cnsb.DataSource, cnsb.InitialCatalog)

        For i = 0 To Reporte.Subreports.Count - 1
            Reporte.Subreports(i).SetDatabaseLogon(cnsb.UserID, cnsb.Password, cnsb.DataSource, cnsb.InitialCatalog)
        Next

        Dim conexion As New ConnectionInfo
        conexion.DatabaseName = cnsb.InitialCatalog
        conexion.ServerName = cnsb.DataSource
        conexion.UserID = cnsb.UserID
        conexion.Password = cnsb.Password
        ' conexion.IntegratedSecurity = True

        Dim tli As New TableLogOnInfo()
        tli.ConnectionInfo = conexion

        ' Volvemos a asignar los datos de conexion pero ahora a cada una de las tablas que tenga el reporte.
        For Each tabla As Table In Reporte.Database.Tables

            Dim _logInfo As TableLogOnInfo = tabla.LogOnInfo

            _logInfo.ConnectionInfo = conexion

            tabla.ApplyLogOnInfo(_logInfo)

        Next

        For i As Integer = 0 To Reporte.Subreports.Count - 1

            For Each tabla As Table In Reporte.Subreports(i).Database.Tables

                Dim _logInfo As TableLogOnInfo = tabla.LogOnInfo

                _logInfo.ConnectionInfo = conexion

                tabla.ApplyLogOnInfo(_logInfo)

            Next

        Next

    End Sub

    Public Sub Mostrar()

        _ReconectarBaseDatos()

        With Me.CrystalReportViewer1

            'For Each o As ReportDocument In Reporte.Subreports
            '    o.RecordSelectionFormula = OrDefault(Me.Formula, "")
            'Next

            .ReportSource = Me.Reporte

            If Not String.IsNullOrEmpty(Me.Formula) Then

                .SelectionFormula = Me.Formula

            End If

            '.RefreshReport()

        End With

        Me.Show()

    End Sub

    Public Sub Imprimir(Optional ByVal cant As Integer = 1)
        'Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)

        _ReconectarBaseDatos()

        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        ' Me.Reporte.Refresh()
        Me.Reporte.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Public Sub GuardarPDF(ByVal NombreArchivo As String, Optional ByVal ruta As String = "")
        ruta = IIf(ruta = "", Application.StartupPath & "/", ruta)

        NombreArchivo = IIf(Regex.IsMatch(NombreArchivo, "(\.pdf)$"), NombreArchivo, NombreArchivo & ".pdf")

        'Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)

        _ReconectarBaseDatos()

        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        Me.Reporte.Refresh()
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

                If .ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then Exit Sub

                If .FileName <> "" Then
                    ruta = .FileName
                    NombreArchivo = ""
                End If

            End With
        End If

        _ReconectarBaseDatos()

        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        'Me.Reporte.Refresh()
        Me.Reporte.ExportToDisk(Formato, ruta & NombreArchivo)

    End Sub

    'Public Sub EnviarPorEmail(ByVal NombreArchivo As String, Optional ByVal WEnvioAutomatico As Boolean = False)

    '    EnviarEmail(NombreArchivo, WEnvioAutomatico)

    'End Sub

    'Private Sub EnviarEmail(ByVal Archivo As String, ByVal EnvioAutomatico As Boolean)
    '    Dim oApp As Outlook._Application
    '    Dim oMsg As Outlook._MailItem

    '    Try
    '        oApp = New Outlook.Application()

    '        oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
    '        oMsg.Subject = "SAC"
    '        oMsg.Body = "Envio de SAC"

    '        oMsg.Attachments.Add(Archivo)

    '        ' Modificar por los E-Mails que correspondan.
    '        'oMsg.To = "gferreyra@surfactan.com.ar"

    '        If EnvioAutomatico Then
    '            oMsg.Send()
    '        Else
    '            oMsg.Display()
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
    '    End Try

    'End Sub

    'Public Sub MergePDFs(ByVal WRuta As String, ByVal WNombreArchivo As String)

    '    Dim Archivos As String() = System.IO.Directory.GetFiles(WRuta, "*.pdf")
    '    Dim outPdf As PdfDocument = New PdfDocument()

    '    For Each file As String In Archivos
    '        Using one As PdfDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import)

    '            CopyPages(one, outPdf)

    '        End Using
    '    Next

    '    outPdf.Save(WRuta & WNombreArchivo)

    'End Sub

    'Private Sub CopyPages(ByVal _from As PdfDocument, ByRef _to As PdfDocument)
    '    For i = 0 To _from.PageCount - 1
    '        _to.AddPage(_from.Pages(i))
    '    Next

    'End Sub
    Public Sub DesdeArchivo(ByVal s As String)
        Reporte = New ReportDocument
        Reporte.Load(s)
    End Sub
End Class