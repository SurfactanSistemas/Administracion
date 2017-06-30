Public Class LeeIvaComp


    Public proveedor, tipo, letra, punto, numero, fecha, periodo, nombre, cuit As String
    Public neto, iva21, iva5, iva27, iva105, ib, exento As Double
    Public NroInterno, soloiva As Integer


    Public Sub New(ByVal nrointerno2 As Integer, ByVal proveedor2 As String, ByVal tipo2 As String, ByVal letra2 As String, ByVal punto2 As String,
                   ByVal numero2 As String, ByVal fecha2 As String, ByVal periodo2 As String, ByVal neto2 As Double, ByVal iva212 As Double,
                   ByVal iva52 As Double, ByVal iva272 As Double, ByVal ib2 As Double, ByVal exento2 As Double, ByVal iva1052 As Double,
                   ByVal nombre2 As String, ByVal cuit2 As String, ByVal soloiva2 As Integer)
        NroInterno = nrointerno2
        proveedor = proveedor2
        tipo = tipo2
        letra = letra2
        punto = punto2
        numero = numero2
        fecha = fecha2
        periodo = periodo2
        neto = neto2
        iva21 = iva212
        iva5 = iva52
        iva27 = iva272
        iva105 = iva1052
        ib = ib2
        exento = exento2
        nombre = nombre2
        cuit = cuit2
        soloiva = soloiva2
    End Sub

End Class
