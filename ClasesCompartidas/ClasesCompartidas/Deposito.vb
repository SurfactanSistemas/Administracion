Public Class Deposito

    Public numero As String
    Public fecha, fechaAcreditacion As String
    Public importeTotal As Double
    Public banco As Banco
    Public items As New List(Of ItemDeposito)

    Public Sub New(ByVal nro As String, ByVal unBanco As Banco, ByVal unaFecha As String, ByVal fechaAcred As String, ByVal importe As Double)
        numero = nro
        banco = unBanco
        fecha = unaFecha
        fechaAcreditacion = fechaAcred
        importeTotal = importe
    End Sub

    Public Sub agregarItems(ByVal itemsNuevos As List(Of ItemDeposito))
        items.AddRange(itemsNuevos)
    End Sub

End Class
