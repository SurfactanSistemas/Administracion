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
        fechaord = IIf(IsDBNull(xfechaord), "", xfechaord).ToString
        recibo = IIf(IsDBNull(xrecibo), "", xrecibo).ToString
        tiporeg = IIf(IsDBNull(xtiporeg), "", xtiporeg).ToString
        tiporec = IIf(IsDBNull(xtiporec), "", xtiporec).ToString
        cuenta = IIf(IsDBNull(xcuenta), "", xcuenta).ToString
        cliente = IIf(IsDBNull(xcliente), "", xcliente).ToString
        tipo1 = IIf(IsDBNull(xtipo1), "", xtipo1).ToString
        letra1 = IIf(IsDBNull(xletra1), "", xletra1).ToString
        punto1 = IIf(IsDBNull(xpunto1), "", xpunto1).ToString
        numero1 = IIf(IsDBNull(xnumero1), "", xnumero1).ToString
        fecha = IIf(IsDBNull(xfecha), "", xfecha).ToString
        tipo2 = IIf(IsDBNull(xtipo2), "", xtipo2).ToString
        numero2 = IIf(IsDBNull(xnumero2), "", xnumero2).ToString
        importe1 = CDbl(IIf(IsDBNull(ximporte1), 0, ximporte1))
        paridad = CDbl(IIf(IsDBNull(xparidad), 0, xparidad))
        importe2 = CDbl(IIf(IsDBNull(ximporte2), 0, ximporte2))
        retiva = CDbl(IIf(IsDBNull(xretiva), 0, xretiva))
        retotra = CDbl(IIf(IsDBNull(xretotra), 0, xretotra))
        retsuss = CDbl(IIf(IsDBNull(xretsuss), 0, xretsuss))
        retganancias = CDbl(IIf(IsDBNull(xretganancias), 0, xretganancias))
        renglon = CInt(IIf(IsDBNull(xrenglon), 0, xrenglon))
        Banco2 = IIf(IsDBNull(xBanco2), "", xBanco2).ToString
        Fecha2 = IIf(IsDBNull(xfecha2), "", xfecha2).ToString
        FechaOrd2 = IIf(IsDBNull(xfechaord2), "", xfechaord2).ToString
        destino = IIf(IsDBNull(xdestino), "", xdestino).ToString
    End Sub

End Class
