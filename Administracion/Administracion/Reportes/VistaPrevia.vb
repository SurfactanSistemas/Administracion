Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text.RegularExpressions

Public Class VistaPrevia

    Private _Reporte As ReportDocument
    Public Property Reporte() As ReportDocument
        Get
            Return _Reporte
        End Get
        Set(ByVal value As ReportDocument)
            _Reporte = value
        End Set
    End Property

    Private _Formula As String
    Public Property Formula() As String
        Get
            Return _Formula
        End Get
        Set(ByVal value As String)
            _Formula = value
        End Set
    End Property


    Private Sub Reporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.CrystalReportViewer1
            .ReportSource = Me.Reporte
        End With

        'Me.Reporte.DataSourceConnections.Item(0).SetLogon("usuarioadmin", "usuarioadmin")

    End Sub

    Public Sub EstablecerConexion(ByVal Servidor As String, ByVal BaseDatos As String)
        'crdoc.DataSourceConnections.Item(0).SetConnection("(LOCAL)\LOCALSQLSERVER", "SurfactanSA", True)
        With Me.Reporte
            .DataSourceConnections.Item(0).SetConnection(Trim(Servidor), Trim(BaseDatos), False)
            .Refresh()
        End With
        'crdoc.DataSourceConnections.Item(0).SetLogon("usuarioadmin", "usuarioadmin")
    End Sub

    Public Sub Mostrar()
        'Me.Reporte.DataSourceConnections.Item(0).SetConnection("193.168.0.7", "SurfactanSA", "usuarioadmin", "usuarioadmin")
        'Me.Reporte.Refresh()
        'Me.Reporte.DataSourceConnections.Item(0).SetLogon("usuarioadmin", "usuarioadmin")
        Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)
        Me.CrystalReportViewer1.SelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        Me.CrystalReportViewer1.Refresh()
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Public Sub Imprimir(Optional ByVal cant As Integer = 1)
        'Me.Reporte.DataSourceConnections.Item(0).SetConnection("193.168.0.7", "SurfactanSA", "usuarioadmin", "usuarioadmin")
        'Me.Reporte.Refresh()
        'Me.Reporte.DataSourceConnections.Item(0).SetLogon("usuarioadmin", "usuarioadmin")
        Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)
        Me.CrystalReportViewer1.SelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        Me.CrystalReportViewer1.Refresh()
        Me.Reporte.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Public Sub GuardarPDF(ByVal NombreArchivo As String, Optional ByVal ruta As String = "")
        ruta = IIf(ruta = "", Application.StartupPath & "/", ruta)

        NombreArchivo = IIf(Regex.IsMatch(NombreArchivo, "(\.pdf)$"), NombreArchivo, NombreArchivo & ".pdf")

        Me.Reporte.ExportToDisk(ExportFormatType.PortableDocFormat, ruta & NombreArchivo)

    End Sub

End Class