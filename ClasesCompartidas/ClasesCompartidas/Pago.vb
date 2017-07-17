Public Class Pago
    Public tipo, letra, punto, numero, descripcion, impoNeto As String
    Public importe As Double

    Public Sub New(ByVal tipoPago As String, ByVal letraDoc As String, ByVal puntoDoc As String, ByVal nro As String,
                   ByVal obs As String, ByVal valor As Double, Optional ByVal _ImpoNeto As String = "0")
        tipo = tipoPago
        letra = letraDoc
        punto = puntoDoc
        numero = nro
        descripcion = obs
        importe = valor
        impoNeto = _ImpoNeto
    End Sub
End Class
