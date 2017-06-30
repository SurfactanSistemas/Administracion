Imports ClasesCompartidas

Public Class DaoVendedor

    Public Shared Function buscarVendedorPorNombre(ByVal nombre As String)

        Dim vendedores As New List(Of Vendedor)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_vendedor_por_nombre", nombre)
        For Each vendedor As DataRow In tabla.Rows
            vendedores.Add(New Vendedor(vendedor("vendedor"), vendedor("nombre")))
        Next
        Return vendedores

    End Function

End Class
