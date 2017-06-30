Public Class TipoDeCambio
    Public fecha As Date
    Public paridad As Double

    Public Sub New(ByVal dia As Date, ByVal precio As Double)
        fecha = dia
        paridad = precio
    End Sub

    Public Overrides Function ToString() As String
        Return fecha & " " & paridad
    End Function

End Class
