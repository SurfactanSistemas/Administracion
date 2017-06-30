Public Class ProcesoReteGenanciasRecibo

    Public fechaord As String
    Public retganancias As Double
    Public renglon As String
    Public cliente As String
    Public fecha As String
    Public comproganan As String
    Public cuit As String

    Public Sub New(ByVal fechaord2 As String, ByVal retganancias2 As Double, ByVal renglon2 As String, ByVal cliente2 As String,
                   ByVal comproganan2 As String, ByVal cuit2 As String)

        fechaord = fechaord2
        retganancias = retganancias2
        renglon = renglon2
        cliente = cliente2
        REM fecha = fecha2
        comproganan = comproganan2
        cuit = cuit2

    End Sub


End Class
