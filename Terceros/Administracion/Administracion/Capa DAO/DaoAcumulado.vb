Imports ClasesCompartidas

Public Class DaoAcumulado

    Public Shared Function buscarAcumulado(ByVal varproveedor As String, ByVal varfecha As String)
        Try
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_acumulado_proveedor", varproveedor, varfecha)
            If tabla.Rows.Count > 0 Then
                Return New LeeAcumulado(tabla(0)("Neto"), tabla(0)("Retenido"), tabla(0)("Anticipo"), tabla(0)("Bruto"), tabla(0)("Iva"))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

End Class
