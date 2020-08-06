Public Class ComposicionProducto : Implements IComposicionDatosAdicionales

    Private WDatosAdicionales As DatosAdicionales

    Private Sub ComposicionProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub _ProcesarComposicionDatosAdicionales(DatosAdicionales As DatosAdicionales) Implements IComposicionDatosAdicionales._ProcesarComposicionDatosAdicionales
        WDatosAdicionales = DatosAdicionales
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If WDatosAdicionales Is Nothing Then WDatosAdicionales = New DatosAdicionales

        With New ComposicionDatosAdicionales(WDatosAdicionales)
            .Show(Me)
        End With
    End Sub
End Class

Public Class DatosAdicionales
    Property Producto As String
    Property Version As String
    Property NUnidas As String
    Property Embalaje As String
    Property Clase As String
    Property RSec As String
    Property Riesgo As String
    Property Caracteristicas As String
    Property FIntervencion As String
    Property Carga As Short
    Property Estado As Short
    Property VidaUtil As Short
    Property Restriccion As Boolean

End Class