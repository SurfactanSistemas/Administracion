Public Class LeeRecibos

    Public fechaord, recibo, tiporeg, tiporec, cuenta, cliente, tipo1, letra1, punto1, numero1, fecha, tipo2, numero2, provincia As String
    Public importe1, importe2, retiva, retotra, retsuss, retganancias As Double
    Public renglon As Integer


    Public Sub New(ByVal fechaord2 As String, ByVal recibo2 As String, ByVal tiporeg2 As String, ByVal tiporec2 As String,
                   ByVal cuenta2 As String, ByVal cliente2 As String, ByVal tipo12 As String, ByVal letra12 As String,
                   ByVal punto12 As String, ByVal numero12 As String, ByVal fecha2 As String, ByVal tipo22 As String,
                   ByVal numero22 As String, ByVal importe12 As Double, ByVal importe22 As Double,
                   ByVal retiva2 As Double, ByVal retotra2 As Double, ByVal retsuss2 As Double, ByVal retganancias2 As Double,
                   ByVal renglon2 As Integer, ByVal provincia2 As String)
        fechaord = fechaord2
        recibo = recibo2
        tiporeg = tiporeg2
        tiporec = tiporec2
        cuenta = cuenta2
        cliente = cliente2
        tipo1 = tipo12
        letra1 = letra12
        punto1 = punto12
        numero1 = numero12
        fecha = fecha2
        tipo2 = tipo22
        numero2 = numero22
        importe1 = importe12
        REM paridad = paridad2
        importe2 = importe22
        retiva = retiva2
        retotra = retotra2
        retsuss = retsuss2
        retganancias = retganancias2
        renglon = renglon2
        provincia = provincia2
    End Sub

End Class
