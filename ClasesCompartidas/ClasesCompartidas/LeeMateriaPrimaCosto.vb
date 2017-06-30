Public Class LeeMateriaPrimaCosto

    Public Articulo, Descripcion As String
    Public Costo As Double


    Public Sub New(ByVal XArticulo As String, ByVal XCosto As Double, ByVal XDescripcion As String)
        Articulo = XArticulo
        Costo = XCosto
        Descripcion = XDescripcion
    End Sub

End Class
