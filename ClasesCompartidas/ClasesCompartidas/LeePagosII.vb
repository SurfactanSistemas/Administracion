Public Class LeePagosII


    Public fechaord, orden, tipoOrd, cuenta, proveedor, letra1, tipo1, punto1, numero1, fecha, tiporeg As String
    Public importe1 As Double
    Public banco2 As Integer
    Public observaciones As String
    Public retotra, retencion, retiva, retibciudad As Double
    Public tipo2, numero2 As String
    Public importe2 As Double
    Public renglon As Integer



    Public Sub New(ByVal fechaord2 As String, ByVal orden2 As String, ByVal tipoord2 As String, ByVal banco22 As Integer,
                   ByVal cuenta2 As String, ByVal proveedor2 As String, ByVal letra12 As String, ByVal tipo12 As String,
                   ByVal punto12 As String, ByVal numero12 As String, ByVal importe12 As Double, ByVal fecha2 As String,
                   ByVal tiporeg2 As String, ByVal observaciones2 As String, ByVal retotra2 As Double, ByVal retencion2 As Double,
                   ByVal retibciudad2 As Double, ByVal importe22 As Double, ByVal tipo22 As String, ByVal numero22 As String,
                   ByVal renglon2 As Integer)
        fechaord = fechaord2
        orden = orden2
        tipoOrd = tipoord2
        banco2 = banco22
        cuenta = cuenta2
        proveedor = proveedor2
        letra1 = letra12
        tipo1 = tipo12
        punto1 = punto12
        numero1 = numero12
        importe1 = importe12
        fecha = fecha2
        tiporeg = tiporeg2
        observaciones = observaciones2
        retotra = retotra2
        retencion = retencion2
        retibciudad = retibciudad2
        importe2 = importe22
        tipo2 = tipo22
        numero2 = numero22
        renglon = renglon2
    End Sub



End Class
