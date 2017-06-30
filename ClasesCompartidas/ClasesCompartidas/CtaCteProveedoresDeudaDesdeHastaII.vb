Public Class CtaCteProveedoresDeudaDesdeHastaII

    Public Proveedor, Tipo, letra, punto, numero, fecha, vencimiento, VencimientoII, Impre, Clave As String
    Public total, saldo, paridad As Double
    Public nroInterno, pago As Integer

    Public Sub New(ByVal tipo2 As String,
            ByVal letra2 As String,
            ByVal punto2 As String,
            ByVal numero2 As String,
            ByVal total2 As Double,
            ByVal saldo2 As Double,
            ByVal fecha2 As String,
            ByVal Vencimiento2 As String,
            ByVal VencimientoII2 As String,
            ByVal Impre2 As String,
            ByVal nroInterno2 As Integer,
            ByVal clave2 As String,
            ByVal proveedor2 As String,
            ByVal pago2 As String,
            ByVal paridad2 As String)
        Tipo = tipo2
        letra = letra2
        punto = punto2
        numero = numero2
        total = total2
        saldo = saldo2
        fecha = fecha2
        vencimiento = Vencimiento2
        VencimientoII = VencimientoII2
        Impre = Impre2
        nroInterno = nroInterno2
        Clave = clave2
        Proveedor = proveedor2
        pago = pago2
        paridad = paridad2
    End Sub

End Class
