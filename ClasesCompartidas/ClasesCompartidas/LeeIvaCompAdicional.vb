
Public Class LeeIvaCompAdicional


    Public tipo, letra, punto, numero, fecha, razon, cuit As String
    Public neto, iva21, perceiva, iva27, iva105, perceib, exento As Double
    Public NroInterno As Integer


    Public Sub New(ByVal nrointerno2 As Integer, ByVal tipo2 As String, ByVal letra2 As String, ByVal punto2 As String,
                   ByVal numero2 As String, ByVal fecha2 As String, ByVal neto2 As Double, ByVal iva212 As Double,
                   ByVal perceiva2 As Double, ByVal iva272 As Double, ByVal perceib2 As Double, ByVal exento2 As Double, ByVal iva1052 As Double,
                   ByVal cuit2 As String, ByVal razon2 As String)

        NroInterno = nrointerno2
        tipo = tipo2
        letra = letra2
        punto = punto2
        numero = numero2
        fecha = fecha2
        neto = neto2
        iva21 = iva212
        perceiva = perceiva2
        iva27 = iva272
        iva105 = iva1052
        perceib = perceib2
        exento = exento2
        razon = razon2
        cuit = cuit2
    End Sub

End Class
