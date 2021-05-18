Public Class ProcesoPercepcionTucuman


    Public fechaord As String
    Public impoibtucu As Double
    Public cliente As String
    Public fecha As String
    Public tipo As String
    Public numero As String
    Public neto As Double
    Public cuit As String
    Public ibtucu As String
    Public porceibtucu As String

    Public Sub New(ByVal fechaord2 As String, ByVal impoibtucu2 As Double, ByVal cliente2 As String, ByVal fecha2 As String,
                   ByVal tipo2 As String, ByVal numero2 As String, ByVal neto2 As Double, ByVal cuit2 As String,
                   ByVal ibtucu2 As Integer, ByVal porceibtucu2 As Double)

        fechaord = fechaord2
        impoibtucu = impoibtucu2
        cliente = cliente2
        fecha = fecha2
        tipo = tipo2
        numero = numero2
        neto = neto2
        cuit = cuit2
        ibtucu = ibtucu2.ToString
        porceibtucu = porceibtucu2.ToString

    End Sub

End Class
