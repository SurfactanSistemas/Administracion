Imports ClasesCompartidas

Public Class DAOLinea

    Public Shared Function buscarLineaPorNombre(ByVal nombre As String)

        Dim lineas As New List(Of Linea)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_linea_por_nombre", nombre)
        For Each Listalinea As DataRow In tabla.Rows
            lineas.Add(New Linea(Listalinea("linea"), Listalinea("nombre")))
        Next
        Return lineas

    End Function


    Public Shared Function buscarLinea(ByVal codigo As Integer)

        Dim lineas As New List(Of Linea)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_linea", codigo)
        For Each Listalinea As DataRow In tabla.Rows
            lineas.Add(New Linea(Listalinea("linea"), Listalinea("nombre")))
        Next
        Return lineas

    End Function


End Class

