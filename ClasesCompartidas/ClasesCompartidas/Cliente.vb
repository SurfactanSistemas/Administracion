Public Class Cliente
    Public id As String
    Public razon As String

    Public Sub New(Optional ByVal cliente2 As String = "", Optional ByVal razon2 As String = "")
        id = cliente2
        razon = razon2
    End Sub

    Public Overrides Function ToString() As String
        Return razon
    End Function
End Class
