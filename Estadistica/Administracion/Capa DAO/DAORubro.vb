Imports ClasesCompartidas

Public Class DAORubro

    Public Shared Function buscarRubroPorNombre(ByVal nombre As String)

        Dim rubros As New List(Of Rubro)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_Rubro_por_nombre", nombre)
        For Each ListaRubro As DataRow In tabla.Rows
            rubros.Add(New Rubro(ListaRubro("rubro"), ListaRubro("nombre")))
        Next
        Return rubros

    End Function

End Class
