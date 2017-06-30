Imports ClasesCompartidas

Public Class DAORubroProveedor

    Public Shared Function crearRubroProveedor(ByVal row As DataRow)
        Return New RubroProveedor(row("codigo"), row("descripcion"))
    End Function

    Public Shared Sub agregarRubroProveedor(ByVal rubro As RubroProveedor)
        SQLConnector.executeProcedure("alta_rubro_proveedor", rubro.codigo, rubro.descripcion)
    End Sub

    Public Shared Sub eliminarRubroProveedor(ByVal rubro As RubroProveedor)
        SQLConnector.executeProcedure("baja_rubro_proveedor", rubro.codigo)
    End Sub

    Public Shared Function buscarRubroProveedorPorDescripcion(ByVal descripcion As String)
        Dim rubros As New List(Of RubroProveedor)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_rubro_proveedor_por_descripcion", descripcion)
        For Each rubro As DataRow In tabla.Rows
            rubros.Add(New RubroProveedor(rubro("codigo"), rubro("descripcion")))
        Next
        Return rubros
    End Function

    Public Shared Function buscarRubroProveedorPorCodigo(ByVal codigoString As String)
        Try
            Dim codigo As Integer = codigoString
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_rubro_proveedor_por_codigo", codigo)
            If tabla.Rows.Count > 0 Then
                Return New RubroProveedor(tabla(0)("codigo"), tabla(0)("descripcion"))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function siguienteCodigo() As Integer
        Try
            Return SQLConnector.retrieveDataTable("get_rubro", "ultimo", 0).Rows(0)(0) + 1
        Catch ex As Exception
            Return 1
        End Try
    End Function

End Class
