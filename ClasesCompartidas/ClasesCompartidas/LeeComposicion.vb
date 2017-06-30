Public Class LeeComposicion

    Public Clave, Terminado, Tipo, Articulo1, Articulo2 As String
    Public Cantidad As Double

    Public Sub New(ByVal XClave As String, ByVal XTerminado As String, ByVal XTipo As String, ByVal XArticulo1 As String, ByVal XArticulo2 As String, ByVal XCantidad As Double)

        Clave = XClave
        Terminado = XTerminado
        Tipo = XTipo
        Articulo1 = XArticulo1
        Articulo2 = XArticulo2
        Cantidad = XCantidad

    End Sub


End Class
