Public Class ProcesoPercecion

    Public fechaord As String
    Public impoib As Double
    Public fecha As String
    Public Clave As String
    Public tipo As String
    Public numero As String
    Public cliente As String
    Public neto As Double
    Public cuit As String

    Public Sub New(ByVal fechaord2 As String, ByVal impoib2 As Double, ByVal fecha2 As String, ByVal clave2 As String,
                   ByVal tipo2 As String, ByVal numero2 As String, ByVal cliente2 As String, ByVal neto2 As Double,
                   ByVal cuit2 As String)

        fechaord = fechaord2
        impoib = impoib2
        fecha = fecha2
        Clave = clave2
        tipo = tipo2
        numero = numero2
        cliente = cliente2
        neto = neto2
        cuit = cuit2

    End Sub

End Class
