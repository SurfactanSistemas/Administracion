Imports ClasesCompartidas

Public Class DAOTerminado

    Public Shared Function buscarTerminadoPorNombre(ByVal nombre As String)

        Dim terminados As New List(Of LeeTerminado)
        Dim tabla As DataTable

        tabla = SQLConnector.retrieveDataTable("buscar_terminado_por_nombre", nombre)
        For Each ListaTerminado As DataRow In tabla.Rows
            terminados.Add(New LeeTerminado(ListaTerminado("codigo"), ListaTerminado("descricpion")))
        Next
        Return terminados

    End Function


End Class
