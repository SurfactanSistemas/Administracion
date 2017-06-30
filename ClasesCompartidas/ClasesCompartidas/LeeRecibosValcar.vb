Public Class LeeRecibosValcar

    Public fechaord, recibo, tiporeg, tiporec, cuenta, cliente, tipo1, letra1, punto1, numero1, fecha, tipo2, numero2, Banco2, Fecha2, FechaOrd2 As String
    Public importe1, paridad, importe2, retiva, retotra, retsuss, retganancias As Double
    Public renglon As Integer
    Public destino As String


    Public Sub New(ByVal xfechaord As String, ByVal xrecibo As String, ByVal xtiporeg As String, ByVal xtiporec As String,
                   ByVal xcuenta As String, ByVal xcliente As String, ByVal xtipo1 As String, ByVal xletra1 As String,
                   ByVal xpunto1 As String, ByVal xnumero1 As String, ByVal xfecha As String, ByVal xtipo2 As String,
                   ByVal xnumero2 As String, ByVal ximporte1 As Double, ByVal xparidad As Double, ByVal ximporte2 As Double,
                   ByVal xretiva As Double, ByVal xretotra As Double, ByVal xretsuss As Double, ByVal xretganancias As Double,
                   ByVal xrenglon As Integer, ByVal xBanco2 As String, ByVal xfecha2 As String, ByVal xfechaord2 As String,
                   ByVal xdestino As String)
        fechaord = xfechaord
        recibo = xrecibo
        tiporeg = xtiporeg
        tiporec = xtiporec
        cuenta = xcuenta
        cliente = xcliente
        tipo1 = xtipo1
        letra1 = xletra1
        punto1 = xpunto1
        numero1 = xnumero1
        fecha = xfecha
        tipo2 = xtipo2
        numero2 = xnumero2
        importe1 = ximporte1
        paridad = xparidad
        importe2 = ximporte2
        retiva = xretiva
        retotra = xretotra
        retsuss = xretsuss
        retganancias = xretganancias
        renglon = xrenglon
        Banco2 = xBanco2
        Fecha2 = xfecha2
        FechaOrd2 = xfechaord2
        destino = xdestino
    End Sub

End Class
