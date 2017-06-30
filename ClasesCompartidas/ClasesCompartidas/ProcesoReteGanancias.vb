Public Class ProcesoReteGanancias

    Public fechaord As String
    Public orden As String
    Public renglon As String
    Public Importe As Double
    Public fecha As String
    Public retencion As Double
    Public proveedor As String
    Public certificadogan As String
    Public cuit As String
    Public tipo As String

    Public Sub New(ByVal fechaord2 As String, ByVal orden2 As String, ByVal renglon2 As String, ByVal importe2 As Double,
                   ByVal fecha2 As String, ByVal retencion2 As Double, ByVal proveedor2 As String,
                   ByVal certificadogan2 As String, ByVal cuit2 As String, ByVal tipo2 As String)

        fechaord = fechaord2
        orden = orden2
        renglon = renglon2
        Importe = importe2
        fecha = fecha2
        retencion = retencion2
        proveedor = proveedor2
        certificadogan = certificadogan2
        cuit = cuit2
        tipo = tipo2

    End Sub

End Class
