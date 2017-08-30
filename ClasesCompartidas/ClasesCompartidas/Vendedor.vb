Public Class Vendedor

    Public id As Short
    Public nombre As String
    Public Shared permisos As Integer = 0

    Public Sub New(ByVal codigo As Short, ByVal descripcion As String)
        id = codigo
        nombre = descripcion
    End Sub

    Public Overrides Function ToString() As String
        Return nombre
    End Function

End Class
