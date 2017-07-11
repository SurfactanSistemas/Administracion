Imports ClasesCompartidas

Public Class DAOPagos

    Public Shared Function siguienteNumeroDeOrden()
        Return SQLConnector.executeProcedureWithReturnValue("get_siguiente_orden_pago")
    End Function

    Public Shared Function buscarOrdenPorNumero(ByVal numero As String)
        Dim tabla As DataTable = SQLConnector.retrieveDataTable("get_pago_por_orden", numero)
        If tabla.Rows.Count < 1 Then : Return Nothing : End If
        Dim pagos As New List(Of Pago)
        Dim formaPagos As New List(Of FormaPago)
        Dim orden As OrdenPago = crearOrdenPago(tabla.Rows(0))
        For Each row As DataRow In tabla.Rows
            If row("TipoReg").ToString = "1" Then
                pagos.Add(crearPago(row))
            Else
                formaPagos.Add(crearFormaPago(row))
            End If
        Next
        orden.formaPagos = formaPagos
        orden.pagos = pagos
        Return orden
    End Function

    Private Shared Function crearOrdenPago(ByVal row As DataRow)
        Return New OrdenPago(ceros(row("Orden").ToString, 6), asInteger(row("TipoOrd")), asDouble(row("Paridad")), asDouble(row("Importe")),
                             asDouble(row("RetIva")), asDouble(row("RetencionIB")), asDouble(row("RetIbCiudad")), asDouble(row("Retencion")),
                             asDateString(row("Fecha")), asDateString(row("fechaParidad")), row("Observaciones").ToString,
                             DAOBanco.buscarBancoPorCodigo(row("Banco").ToString), DAOProveedor.buscarProveedorPorCodigo(row("Proveedor").ToString))
    End Function

    Private Shared Function asDouble(ByVal val)
        Return CustomConvert.toDoubleOrZero(val.ToString)
    End Function

    Private Shared Function asInteger(ByVal val)
        Return CustomConvert.toIntOrZero(val.ToString)
    End Function

    Private Shared Function asDateString(ByVal val)
        Return CustomConvert.asTextDate(val.ToString)
    End Function

    Private Shared Function crearPago(ByVal row As DataRow)
        Return New Pago(row("Tipo1").ToString, row("Letra1").ToString, row("Punto1").ToString, row("Numero1").ToString,
                        row("Observaciones2").ToString, asDouble(row("Importe1")))
    End Function

    Private Shared Function crearFormaPago(ByVal row As DataRow)
        Return New FormaPago(ceros(row("Tipo2").ToString, 2), asInteger(row("Banco2")), row("Numero2").ToString, row("FechaCheque").ToString,
                            row("NombreCheque").ToString, asDouble(row("Importe2")), row("Cuit").ToString)
    End Function

    Public Shared Sub agregarPago(ByVal orden As OrdenPago)
        For Each pago As Pago In orden.pagos
            Dim renglon As Integer = 1
            SQLConnector.executeProcedure("alta_pago_pago", orden.nroOrden, ceros(renglon, 2), orden.tipo, orden.fecha, orden.codigoProveedor,
            orden.observaciones, orden.codigoBanco, orden.fechaParidad, orden.paridad, orden.retGanancias, orden.retIB, orden.retIBCiudad, orden.retIVA, orden.importe,
            pago.tipo, pago.letra, pago.punto, pago.numero, pago.importe, 0, pago.descripcion)
            renglon += 1
        Next

        For Each formaPago As FormaPago In orden.formaPagos
            Dim renglon As Integer = 1
            SQLConnector.executeProcedure("alta_pago_forma_de_pago", orden.nroOrden, ceros(renglon, 2), orden.tipo, orden.fecha, orden.codigoProveedor,
            orden.observaciones, formaPago.banco, orden.fechaParidad, orden.paridad, orden.retGanancias, orden.retIB, orden.retIBCiudad, orden.retIVA, orden.importe,
            formaPago.tipo, formaPago.numero, formaPago.fecha, formaPago.nombre, formaPago.importe, 0, formaPago.nombre)
            renglon += 1
        Next
    End Sub
End Class
