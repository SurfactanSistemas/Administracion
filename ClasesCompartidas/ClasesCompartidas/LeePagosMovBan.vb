Public Class LeePagosMovBan

    Public fechaord, orden, tipoOrd, cuenta, proveedor, fecha, tiporeg, fecha2, fechaord2 As String
    Public importe2, importe1 As Double
    Public banco2 As Integer
    Public observaciones As String
    Public tipo2, numero2 As String
    Public renglon As Integer



    Public Sub New(ByVal xfechaord As String, ByVal xorden As String, ByVal xtipoord As String, ByVal xbanco2 As Integer,
                   ByVal xcuenta As String, ByVal xproveedor As String, ByVal xfecha As String, ByVal xfecha2 As String, ByVal xfechaOrd2 As String,
                   ByVal xtiporeg As String, ByVal xobservaciones As String,
                   ByVal ximporte2 As Double, ByVal xtipo2 As String, ByVal xnumero2 As String,
                   ByVal xrenglon As Integer, ByVal ximporte1 As Double)

        fechaord = xfechaord
        orden = xorden
        tipoOrd = xtipoord
        banco2 = xbanco2
        cuenta = xcuenta
        proveedor = xproveedor
        fecha = xfecha
        fecha2 = xfecha2
        fechaord2 = xfechaOrd2
        tiporeg = xtiporeg
        observaciones = xobservaciones
        importe2 = ximporte2
        importe1 = ximporte1
        tipo2 = xtipo2
        numero2 = xnumero2
        renglon = xrenglon
    End Sub

End Class
