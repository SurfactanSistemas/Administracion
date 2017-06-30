Public Class ProcesoReteIb

    Public fechaord As String
    Public retotra As Double
    Public renglon As String
    Public proveedor As String
    Public fecha As String
    Public orden As String
    Public cuit As String

    Public Sub New(ByVal fechaord2 As String, ByVal retotra2 As Double, ByVal renglon2 As String, ByVal proveedor2 As String,
                   ByVal fecha2 As String, ByVal orden2 As String, ByVal cuit2 As String)

        fechaord = fechaord2
        retotra = retotra2
        renglon = renglon2
        proveedor = proveedor2
        fecha = fecha2
        orden = orden2
        cuit = cuit2

    End Sub

End Class
