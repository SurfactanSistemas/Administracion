Imports ClasesCompartidas

Public Class DAOTrabajo

    Public Shared Function buscarTrabajoPorCodigo(ByVal codigoInt As Integer)
        Try
            Dim codigo As Integer = codigoInt
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("lee_trabajo", codigo)
            If tabla.Rows.Count > 0 Then
                Return New Trabajo(tabla(0)("codigo"), tabla(0)("proceso"), tabla(0)("destino"), tabla(0)("planta"), tabla(0)("orden"), tabla(0)("nombre").ToString)
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function

End Class
