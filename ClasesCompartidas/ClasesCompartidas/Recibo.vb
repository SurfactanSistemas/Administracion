Public Class Recibo

    Public codigo, fecha, observaciones, cuenta As String
    Public cliente As Cliente
    'Public cuenta As CuentaContable
    Public retGanancias, retIB, retIVA, retSuss, paridad, total As Double
    Public formasPago As New List(Of FormaPago)
    Public pagos As New List(Of Pago)
    Public tipo As Integer

    Public Sub New(ByVal id As String, ByVal fecha2 As String, ByVal cli As Cliente, ByVal ganancias As Double, ByVal IB As Double, ByVal IVA As Double,
                   ByVal suss As Double, ByVal valorParidad As Double, ByVal valorTotal As Double, ByVal cuentaContable As String,
                   ByVal obs As String, ByVal tipoRec As Integer)
        codigo = id
        fecha = fecha2
        cliente = cli
        retGanancias = ganancias
        retIB = IB
        retIVA = IVA
        retSuss = suss
        paridad = valorParidad
        total = valorTotal
        cuenta = cuentaContable
        observaciones = obs
        tipo = tipoRec
    End Sub

    Public Function codigoCliente() As String
        If IsNothing(cliente) Then
            Return ""
        End If
        Return cliente.id
    End Function

    'Public Function codigoCuenta()
    '    If IsNothing(cuenta) Then
    '        Return ""
    '    End If
    '    Return cuenta.id
    'End Function

End Class
