Public Class ProcesoReteIvaRecibos

    Public fechaord As String
    Public retiva As Double
    Public renglon As String
    Public cliente As String
    Public fecha As String
    Public comproiva As String
    Public cuit As String

    Public Sub New(ByVal fechaord2 As String, ByVal retiva2 As Double, ByVal renglon2 As String, ByVal cliente2 As String,
                   ByVal fecha2 As String, ByVal comproiva2 As String, ByVal cuit2 As String)

        fechaord = fechaord2
        retiva = retiva2
        renglon = renglon2
        cliente = cliente2
        fecha = fecha2
        comproiva = comproiva2
        cuit = cuit2

    End Sub

End Class
