Imports ConsultasVarias

Public Class ProcesarListadoEnsayosEnMateriaPrima : Implements IListarReporteDesdeHastaBasico

    Private frm As New ListarReporteDesdeHastaBasico

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler frm.WOnKeyDown, AddressOf _OnKeyDownEnsayos

        Hide()

        frm.ShowDialog(Me)

    End Sub

    Public Sub _ProcesarListarReporteDesdeHastaBasico(ByVal Desde As String, ByVal Hasta As String, ByVal TipoVisualizacion As ConsultasVarias.Clases.Enumeraciones.TipoVisualizacionReporte) Implements IListarReporteDesdeHastaBasico._ProcesarListarReporteDesdeHastaBasico
        Dim WParam As New Dictionary(Of String, Object)

        WParam.Add("@Ensayo1", Desde)
        WParam.Add("@Ensayo2", Hasta)

        Dim Base = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

        Dim WDatos As DataTable = New DBAuxi.VerificaEnsayosDataTable

        WDatos = CallProcedureWithReturns("VerificaEnsayoMP", WParam, Base)

        Dim rpt As New ReporteListadoEnsayosEnMP
        rpt.SetDataSource(WDatos)

        With New VistaPrevia
            .Reporte = rpt

            If TipoVisualizacion = ConsultasVarias.Clases.Enumeraciones.TipoVisualizacionReporte.Pantalla Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With

    End Sub

    Private Sub _OnKeyDownEnsayos(ByVal sender As Object, ByVal e As ListadoReporteEventArgs)

        Dim WControl As TextBox = TryCast(sender, TextBox)
        Dim Base = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
        Dim WEns As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WControl.Text.Trim & "'", Base)

        If WEns IsNot Nothing Then e.Control.Text = Trim(OrDefault(WEns.Item("Descripcion"), ""))

    End Sub

    Private Sub ProcesarListadoEnsayosEnMateriaPrima_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Close()
    End Sub
End Class