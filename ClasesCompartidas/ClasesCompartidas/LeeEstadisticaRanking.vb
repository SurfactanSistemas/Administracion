Public Class LeeEstadisticaRanking

    Public Articulo, Tipo, Cliente, DescriTerminado, Fecha As String
    Public Linea As Integer
    Public Cantidad, ImporteUs, Importe, Costo2 As Double

    Public Sub New(ByVal XArticulo As String, ByVal XCliente As String, ByVal XLinea As Integer, ByVal XCantidad As Double, ByVal XImporteuS As Double, ByVal XImporte As Double, ByVal XTipo As String, ByVal XCosto2 As Double, ByVal XDescriTerminado As String, ByVal XFecha As String)

        Articulo = XArticulo
        Tipo = XTipo
        Cliente = XCliente
        Linea = XLinea
        Cantidad = XCantidad
        Importe = XImporte
        ImporteUs = XImporteuS
        Costo2 = XCosto2
        DescriTerminado = XDescriTerminado
        Fecha = XFecha

    End Sub

End Class
