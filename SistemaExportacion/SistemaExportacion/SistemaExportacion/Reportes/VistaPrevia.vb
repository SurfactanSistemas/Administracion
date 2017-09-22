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

    End Sub

    Public Sub EstablecerConexion(ByVal Servidor As String, ByVal BaseDatos As String)
        With Me.Reporte
            .DataSourceConnections.Item(0).SetConnection(Trim(Servidor), Trim(BaseDatos), False)
            .Refresh()
        End With
    End Sub

    Public Sub Mostrar()
        Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)
        Me.CrystalReportViewer1.SelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        Me.CrystalReportViewer1.Refresh()
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Public Sub Imprimir(Optional ByVal cant As Integer = 1)
        Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)
        Me.Reporte.Refresh()
        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        Me.Reporte.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Public Sub GuardarPDF(ByVal NombreArchivo As String, Optional ByVal ruta As String = "")
        ruta = IIf(ruta = "", Application.StartupPath & "/", ruta)

        NombreArchivo = IIf(Regex.IsMatch(NombreArchivo, "(\.pdf)$"), NombreArchivo, NombreArchivo & ".pdf")

        Me.Reporte.DataSourceConnections.Item(0).SetConnection("EMPRESA01", "SurfactanSA", False)
        Me.Reporte.Refresh()
        Me.Reporte.RecordSelectionFormula = IIf(IsNothing(Me.Formula), "", Me.Formula)
        Me.Reporte.ExportToDisk(ExportFormatType.PortableDocFormat, ruta & NombreArchivo)

    End Sub

End Class