Public Class CtaCteProveedoresDeuda

    Public Tipo, letra, punto, numero, fecha, vencimiento As String
    Public total, saldo As Double


    Public Sub New(ByVal tipo2 As String,
            ByVal letra2 As String,
            ByVal punto2 As String,
            ByVal numero2 As String,
            ByVal total2 As Double,
            ByVal saldo2 As Double,
            ByVal fecha2 As String,
            ByVal Vencimiento2 As String)
        Tipo = tipo2
        letra = letra2
        punto = punto2
        numero = numero2
        total = total2
        saldo = saldo2
        fecha = fecha2
        vencimiento = Vencimiento2
    End Sub


End Class
