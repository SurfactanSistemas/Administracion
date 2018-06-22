Imports ClasesCompartidas

Public Class DAOTipoCambio

    Public Shared Function crearTipoCambio(ByVal row As DataRow)
        Return New TipoDeCambio(row("fecha"), row("cambio"))
    End Function

    Public Shared Sub agregarTipoCambio(ByVal cambio As TipoDeCambio)
        SQLConnector.executeProcedure("alta_tipo_cambio", cambio.fecha.ToString, cambio.paridad)
    End Sub

    Public Shared Sub eliminarTipoCambio(ByVal fecha As String)
        SQLConnector.executeProcedure("baja_tipo_cambio", fecha)
    End Sub

    Public Shared Function listarTiposCambio() As List(Of TipoDeCambio)
        Dim cambios As New List(Of TipoDeCambio)
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("get_tipos_cambio")
        For Each cambio As DataRow In tabla.Rows
            cambios.Add(New TipoDeCambio(Date.Parse(cambio("Fecha")), cambio("Cambio")))
        Next
        Return cambios
    End Function


    Public Shared Function buscarTipoCambioPorFecha(ByVal fecha As String)
        Try
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_tipo_cambio_por_fecha", fecha)
            If tabla.Rows.Count > 0 Then
                Return New TipoDeCambio(tabla(0)("fecha"), tabla(0)("Cambio"))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function


    Public Shared Function buscarTipoCambioPorFechaPago(ByVal fecha As String)
        Try
            Dim tabla As DataTable
            tabla = SQLConnector.retrieveDataTable("buscar_tipo_cambio_por_fecha_Pago", fecha)
            If tabla.Rows.Count > 0 Then
                Return New TipoDeCambio(tabla(0)("fecha"), tabla(0)("Cambiodivisa"))
            Else
                Return Nothing
            End If
        Catch e As Exception
            Return Nothing
        End Try
    End Function


End Class
