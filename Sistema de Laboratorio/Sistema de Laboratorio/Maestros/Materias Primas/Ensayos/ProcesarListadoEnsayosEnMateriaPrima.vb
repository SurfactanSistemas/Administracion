Imports ConsultasVarias

Public Class ProcesarListadoEnsayosEnMateriaPrima : Implements IListarReporteDesdeHastaBasico

    Private frm As New ListarReporteDesdeHastaBasico

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler frm.WOnKeyDown, AddressOf _OnKeyDownEnsayos

        frm.Show(Owner)

        Hide()

    End Sub

    Public Sub _ProcesarListarReporteDesdeHastaBasico(ByVal Desde As String, ByVal Hasta As String, ByVal TipoVisualizacion As ConsultasVarias.Clases.Enumeraciones.TipoVisualizacionReporte) Implements IListarReporteDesdeHastaBasico._ProcesarListarReporteDesdeHastaBasico
        Dim WParam As New Dictionary(Of String, Object)

        WParam.Add("@Ensayo1", Desde)
        WParam.Add("@Ensayo2", Hasta)

        Dim Base = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

        Dim WDatos As DataTable = New DBAuxi.VerificaEnsayosDataTable

        WDatos = _ProcesarDatos(Desde, Hasta, Base) 'CallProcedureWithReturns("VerificaEnsayoMP", WParam, Base)

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

    Private Function _ProcesarDatos(ByVal Desde As String, ByVal Hasta As String, ByVal Base As String) As DataTable
        Dim WDatos As DataTable = New DBAuxi.VerificaEnsayosDataTable
        Dim WDatosI As DataTable
        Dim WDatosII As DataTable

        Dim WColumnasI, WColumnasII, WFiltroI, WFiltroII As String

        For i = 1 To 20
            WFiltroI &= String.Format("e.Ensayo{0} BETWEEN '{1}' And '{2}' OR ", i, Desde, Hasta)
            WColumnasI &= String.Format("e.Ensayo{0}, e.Valor{0},", i)
        Next

        For i = 21 To 30
            WFiltroII &= String.Format("e.Ensayo{0} BETWEEN '{1}' And '{2}' OR ", i, Desde, Hasta)
            WColumnasII &= String.Format("e.Ensayo{0}, e.Valor{0},", i)
        Next

        WFiltroI = WFiltroI.Trim.Substring(0, WFiltroI.Trim.LastIndexOf("OR"))
        WFiltroII = WFiltroII.Trim.Substring(0, WFiltroII.Trim.LastIndexOf("OR"))
        WColumnasI = WColumnasI.Trim.TrimEnd(",")
        WColumnasII = WColumnasII.Trim.TrimEnd(",")


        WDatosI = GetAll("SELECT e.Producto, a.Descripcion, " & WColumnasI & " FROM EspecificacionesUnifica e INNER JOIN Articulo a ON a.Codigo = e.Producto WHERE " & WFiltroI, Base)
        WDatosII = GetAll("SELECT e.Producto, a.Descripcion, " & WColumnasII & " FROM EspecificacionesUnificaIII e INNER JOIN Articulo a ON a.Codigo = e.Producto WHERE " & WFiltroII, Base)

        For Each row As Datarow In WDatosI.rows
            With row
                
                For i = 1 To 20
                    If OrDefault(.Item("Ensayo" & i), 0) >= Val(Desde) And OrDefault(.Item("Ensayo" & i), 0) <= Val(Hasta) Then
                        Dim r As DataRow = WDatos.NewRow

                        r.Item("Ensayo") = Trim(OrDefault(.Item("Ensayo" & i), 0))
                        r.Item("DescEnsayo") = Trim(OrDefault(.Item("Valor" & i), ""))
                        r.Item("Producto") = Trim(OrDefault(.Item("Producto"), ""))
                        r.Item("Descripcion") = Trim(OrDefault(.Item("Descripcion"), ""))
                        r.Item("Resultado") = Trim(OrDefault(.Item("Valor" & i), ""))

                        WDatos.Rows.Add(r)
                    End If
                Next

            End With
        Next

        For Each row As DataRow In WDatosII.Rows
            With row

                For i = 21 To 30
                    If OrDefault(.Item("Ensayo" & i), 0) >= Val(Desde) Or OrDefault(.Item("Ensayo" & i), 0) <= Val(Hasta) Then
                        Dim r As DataRow = WDatos.NewRow

                        r.Item("Ensayo") = Trim(OrDefault(.Item("Ensayo" & i), 0))
                        r.Item("DescEnsayo") = Trim(OrDefault(.Item("Valor" & i), ""))
                        r.Item("Producto") = Trim(OrDefault(.Item("Producto"), ""))
                        r.Item("Descripcion") = Trim(OrDefault(.Item("Descripcion"), ""))
                        r.Item("Resultado") = Trim(OrDefault(.Item("Valor" & i), ""))

                        WDatos.Rows.Add(r)
                    End If
                Next

            End With
        Next

        Dim WEnsayos As DataTable = (New DataView(WDatos)).ToTable(True, "Ensayo")

        For Each row As Datarow In WEnsayos.Rows
            Dim WDescripcion As String = ""
            Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & row.Item("Ensayo") & "'", Base)

            If WEnsayo IsNot Nothing Then
                WDescripcion = Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))

                For Each r As DataRow In WDatos.Select("Ensayo = " & row.Item("Ensayo"))
                    r.Item("DescEnsayo") = WDescripcion.ToUpper
                Next
            End If
        Next

        Return WDatos

    End Function

    Private Sub _OnKeyDownEnsayos(ByVal sender As Object, ByVal e As ListadoReporteEventArgs)

        Dim WControl As TextBox = TryCast(sender, TextBox)
        Dim Base = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
        Dim WEns As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WControl.Text.Trim & "'", Base)

        If WEns IsNot Nothing Then e.Control.Text = Trim(OrDefault(WEns.Item("Descripcion"), ""))

    End Sub

    Private Sub ProcesarListadoEnsayosEnMateriaPrima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Close()
    End Sub
End Class