Imports ClasesCompartidas

Public Class DAOCierreMes

    Public Shared Sub agregarCierremes(ByVal cuenta As CuentaContable)
        SQLConnector.executeProcedure("alta_cierre", cuenta.id, cuenta.descripcion, 1, 1)
    End Sub

    Public Shared Function mesAbierto(ByVal fecha As String)
        Try
            Dim fechaDate As DateTime = Convert.ToDateTime(fecha)
            Dim mes As Integer = fechaDate.Month
            Dim anio As Integer = fechaDate.Year
            Return SQLConnector.retrieveDataTable("get_mes_esta_cerrado", mes, anio).Rows(0)(0) = 0
        Catch ex As FormatException
            Return True
        End Try
    End Function

End Class
