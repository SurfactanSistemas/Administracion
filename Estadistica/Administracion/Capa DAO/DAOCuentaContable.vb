Imports ClasesCompartidas

Public Class DAOCuentaContable

    Public Shared Function crearCuenta(ByVal row As DataRow)
        Return New CuentaContable(row("cuenta"), row("descripcion"))
    End Function

    Public Shared Sub agregarCuentaContable(ByVal cuenta As CuentaContable)
        SQLConnector.executeProcedure("alta_cuenta", cuenta.id, cuenta.descripcion, 1, 1)
    End Sub

    Public Shared Sub eliminarCuentaContable(ByVal codigo As String)
        SQLConnector.executeProcedure("baja_cuenta", codigo)
    End Sub

    Public Shared Function buscarCuentaContablePorDescripcion(ByVal descripcion As String)
        Dim cuentas As New List(Of CuentaContable)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_por_descripcion", descripcion)
        For Each cuenta As DataRow In tabla.Rows
            cuentas.Add(New CuentaContable(cuenta("cuenta"), cuenta("descripcion")))
        Next
        Return cuentas
    End Function

    Public Shared Function buscarCuentaContablePorCodigo(ByVal codigo As String) As CuentaContable
        If Trim(codigo) = "" Then : Return Nothing : End If
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_por_codigo", codigo)
        If tabla.Rows.Count > 0 Then
            Return New CuentaContable(tabla(0)("cuenta"), tabla(0)("descripcion"))
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function IVACredito()
        Return buscarCuentaContablePorCodigo("151")
    End Function

    Public Shared Function IVADebito()
        Return buscarCuentaContablePorCodigo("155")
    End Function

    Public Shared Function IVARG3337()
        Return buscarCuentaContablePorCodigo("152")
    End Function

    Public Shared Function ingresosBrutos()
        Return buscarCuentaContablePorCodigo("164")
    End Function

    Public Shared Function proveedoresInternacionales()
        Return buscarCuentaContablePorCodigo("2010")
    End Function
End Class
