Public Class Efectivo
    Implements ItemDeposito

    Public moneda As Integer
    Public valorImporte As Double

    Public Sub New(ByVal tipo As Integer, ByVal importe As Double)
        moneda = tipo
        valorImporte = importe
    End Sub

    Public Function tipo() As Integer Implements ItemDeposito.tipo
        Return moneda
    End Function

    Public Function importe() As Double Implements ItemDeposito.importe
        Return valorImporte
    End Function

    Public Function numero() As String Implements ItemDeposito.numero
        Return ""
    End Function

    Public Function nombre() As String Implements ItemDeposito.nombre
        Return ""
    End Function

    Public Function fecha() As String Implements ItemDeposito.fecha
        Return ""
    End Function
End Class
