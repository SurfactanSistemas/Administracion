﻿Public Class LeeRecibosValcar

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
        fechaord = IIf(IsDBNull(xfechaord), "", xfechaord)
        recibo = IIf(IsDBNull(xrecibo), "", xrecibo)
        tiporeg = IIf(IsDBNull(xtiporeg), "", xtiporeg)
        tiporec = IIf(IsDBNull(xtiporec), "", xtiporec)
        cuenta = IIf(IsDBNull(xcuenta), "", xcuenta)
        cliente = IIf(IsDBNull(xcliente), "", xcliente)
        tipo1 = IIf(IsDBNull(xtipo1), "", xtipo1)
        letra1 = IIf(IsDBNull(xletra1), "", xletra1)
        punto1 = IIf(IsDBNull(xpunto1), "", xpunto1)
        numero1 = IIf(IsDBNull(xnumero1), "", xnumero1)
        fecha = IIf(IsDBNull(xfecha), "", xfecha)
        tipo2 = IIf(IsDBNull(xtipo2), "", xtipo2)
        numero2 = IIf(IsDBNull(xnumero2), "", xnumero2)
        importe1 = IIf(IsDBNull(ximporte1), 0, ximporte1)
        paridad = IIf(IsDBNull(xparidad), 0, xparidad)
        importe2 = IIf(IsDBNull(ximporte2), 0, ximporte2)
        retiva = IIf(IsDBNull(xretiva), 0, xretiva)
        retotra = IIf(IsDBNull(xretotra), 0, xretotra)
        retsuss = IIf(IsDBNull(xretsuss), 0, xretsuss)
        retganancias = IIf(IsDBNull(xretganancias), 0, xretganancias)
        renglon = IIf(IsDBNull(xrenglon), 0, xrenglon)
        Banco2 = IIf(IsDBNull(xBanco2), "", xBanco2)
        Fecha2 = IIf(IsDBNull(xfecha2), "", xfecha2)
        FechaOrd2 = IIf(IsDBNull(xfechaord2), "", xfechaord2)
        destino = IIf(IsDBNull(xdestino), "", xdestino)
    End Sub

End Class
