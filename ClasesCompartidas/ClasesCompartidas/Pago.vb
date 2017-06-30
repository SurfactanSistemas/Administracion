Public Class Pago
    Public tipo, letra, punto, numero, descripcion As String
    Public importe As Double

    Public Sub New(ByVal tipoPago As String, ByVal letraDoc As String, ByVal puntoDoc As String, ByVal nro As String,
                   ByVal obs As String, ByVal valor As Double)
        tipo = tipoPago
        letra = letraDoc
        punto = puntoDoc
        numero = nro
        descripcion = obs
        importe = valor
    End Sub
End Class
