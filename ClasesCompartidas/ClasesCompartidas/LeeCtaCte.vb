Public Class LeeCtaCte


    Public clave, tipo, cliente, fecha, vencimiento, impre As String
    Public total, saldo, totalus, saldous, neto, iva1, iva2, paridad As Double
    Public numero As Integer


    Public Sub New(ByVal xclave As String, ByVal xtipo As String, ByVal xnumero As Integer, ByVal xcliente As String, ByVal xfecha As String,
                   ByVal xvencimiento As String,
                   ByVal xtotal As Double, ByVal xsaldo As Double, ByVal xtotalus As Double, ByVal xsaldous As Double,
                   ByVal ximpre As String, ByVal xneto As Double, ByVal xiva1 As Double, ByVal xiva2 As Double, ByVal xparidad As Double)
        tipo = xtipo
        cliente = xcliente
        fecha = xfecha
        vencimiento = xvencimiento
        impre = ximpre
        total = xtotal
        saldo = xsaldo
        totalus = xtotalus
        saldous = xsaldous
        neto = xneto
        iva1 = xiva1
        iva2 = xiva2
        paridad = xparidad
        numero = xnumero
    End Sub



End Class
