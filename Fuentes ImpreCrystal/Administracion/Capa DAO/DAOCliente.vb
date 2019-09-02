Imports ClasesCompartidas

Public Class DAOCliente

    Public Shared Function buscarClientePorNombre(ByVal nombre As String)
        Dim clientes As New List(Of Cliente)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cliente_por_nombre", nombre)
        For Each cliente As DataRow In tabla.Rows
            clientes.Add(New Cliente(cliente("cliente"), cliente("razon")))
        Next
        Return clientes
    End Function

    Public Shared Function buscarClientePorCodigo(ByVal codigoString As String)
        Try
            Dim codigo As String = codigoString
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_Cliente_por_codigo", codigo)
            If tabla.Rows.Count > 0 Then
                Return New Cliente(tabla(0)("cliente").ToString, tabla(0)("razon").ToString)
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

End Class
