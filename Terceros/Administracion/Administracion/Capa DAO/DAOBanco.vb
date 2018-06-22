Imports ClasesCompartidas

Public Class DAOBanco

    Public Shared Function crearBanco(ByVal row As DataRow)
        Return New Banco(row("banco"), row("nombre"), DAOCuentaContable.buscarCuentaContablePorCodigo(row("cuenta")))
    End Function

    Public Shared Sub agregarBanco(ByVal banco As Banco)
        SQLConnector.executeProcedure("alta_banco", banco.id, banco.nombre, banco.cuenta.id)
    End Sub

    Public Shared Sub eliminarBanco(ByVal banco As Banco)
        SQLConnector.executeProcedure("baja_banco", banco.id)
    End Sub

    Public Shared Function buscarBancoPorNombre(ByVal nombre As String)
        Dim bancos As New List(Of Banco)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_banco_por_nombre", nombre)
        For Each banco As DataRow In tabla.Rows
            bancos.Add(New Banco(banco("banco"), banco("nombre"), DAOCuentaContable.buscarCuentaContablePorCodigo(banco("cuenta"))))
        Next
        Return bancos
    End Function

    Public Shared Function buscarBancoPorCodigo(ByVal codigoString As String)
        Try
            Dim codigo As Short = codigoString
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_banco_por_codigo", codigo)
            If tabla.Rows.Count > 0 Then
                Return New Banco(tabla(0)("banco"), tabla(0)("nombre"), DAOCuentaContable.buscarCuentaContablePorCodigo(tabla(0)("cuenta")))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function


    Public Shared Function buscarBancoPorCodigoII(ByVal codigoString As String)
        Try
            Dim codigo As Short = codigoString
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_banco_por_codigo", codigo)
            If tabla.Rows.Count > 0 Then
                Return New Banco(tabla(0)("banco"), tabla(0)("nombre"), tabla(0)("cuenta"))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function siguienteCodigo() As Integer

        Try
            Return SQLConnector.retrieveDataTable("get_banco", "ultimo", 0).Rows(0)(0) + 1
        Catch ex As Exception
            Return 1
        End Try

    End Function
End Class
