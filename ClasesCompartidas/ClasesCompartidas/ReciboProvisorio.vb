Public Class ReciboProvisorio

    Public codigo, fecha As String
    Public cliente As Cliente
    Public retGanancias, retIB, retIVA, retSuss, paridad, total As Double
    Public formasPago As New List(Of FormaPago)

    Public Sub New(ByVal id As String, ByVal fecha2 As String, ByVal cli As Cliente, ByVal ganancias As Double, ByVal IB As Double, ByVal IVA As Double,
                   ByVal Suss As Double, ByVal valorParidad As Double, ByVal valorTotal As Double)
        codigo = id
        fecha = fecha2
        cliente = cli
        retGanancias = ganancias
        retIB = IB
        retIVA = IVA
        retSuss = Suss
        paridad = valorParidad
        total = valorTotal
    End Sub

    Public Function codigoCliente()
        If IsNothing(cliente) Then
            Return ""
        End If
        Return cliente.id
    End Function

End Class