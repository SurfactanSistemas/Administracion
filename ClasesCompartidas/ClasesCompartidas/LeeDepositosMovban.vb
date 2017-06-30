Public Class LeeDepositosMovban

    Public fechaord, deposito, tipo2, numero2, Fecha, acredita, acreditaord As String
    Public importe2, importe As Double
    Public Banco As Integer


    Public Sub New(ByVal xfechaord As String, ByVal xdeposito As String, ByVal xtipo2 As String, ByVal xnumero2 As String,
                   ByVal xFecha As String, ByVal ximporte2 As Double, ByVal xBanco As Integer, ByVal ximporte As Double,
                   ByVal xacredita As String, ByVal xacreditaord As String)
        fechaord = xfechaord
        deposito = xdeposito
        tipo2 = xtipo2
        numero2 = xnumero2
        Fecha = xFecha
        importe2 = ximporte2
        Banco = xBanco
        importe = ximporte
        acredita = xacredita
        acreditaord = xacreditaord
    End Sub
End Class
