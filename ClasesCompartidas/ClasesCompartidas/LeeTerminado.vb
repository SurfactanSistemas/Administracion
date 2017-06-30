Public Class LeeTerminado

    Public Articulo, Descripcion As String

    Public Sub New(ByVal XArticulo As String, ByVal XDescripcion As String)
        Articulo = XArticulo
        Descripcion = XDescripcion
    End Sub

    Public Overrides Function ToString() As String
        Return Descripcion
    End Function
End Class
