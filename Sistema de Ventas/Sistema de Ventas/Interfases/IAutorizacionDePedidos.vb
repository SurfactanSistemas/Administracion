Public Interface IAutorizacionDePedidos

    Sub CambiaAutorizado(ByVal ClavePedido As String, Optional ByVal FechaVto As String = "")

    Sub CambiaAutorizadoChecks(ByVal ClavePedido As String, ByVal Inicial As String)
End Interface
