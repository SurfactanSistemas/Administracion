Public Class LeeAplicaProve

    Public clave, fecha, ordfecha, proveedor, tipo, letra, punto, numero As String
    Public importe As Double
    Public codigo, renglon As Integer


    Public Sub New(ByVal xclave As String, ByVal xcodigo As Integer, ByVal xrenglon As Integer,
                   ByVal xfecha As String, ByVal xordfecha As String, ByVal xproveedor As String, ByVal xtipo As String,
                   ByVal xletra As String, ByVal xpunto As String, ByVal xnumero As String, ByVal ximporte As Double)

        clave = xclave
        codigo = xcodigo
        renglon = xrenglon
        fecha = xfecha
        ordfecha = xordfecha
        proveedor = xproveedor
        tipo = xtipo
        letra = xletra
        punto = xpunto
        numero = xnumero
        importe = ximporte

    End Sub




End Class
