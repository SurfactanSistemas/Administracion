Public Class LeeAcumulado

    Public neto, retenido, anticipo, bruto, iva As Double

    Public Sub New(ByVal xneto As Double, ByVal xretenido As Double, ByVal xanticipo As Double, ByVal xbruto As Double,
                   ByVal xiva As Double)
        neto = xneto
        retenido = xretenido
        anticipo = xanticipo
        bruto = xbruto
        iva = xiva
    End Sub
End Class
