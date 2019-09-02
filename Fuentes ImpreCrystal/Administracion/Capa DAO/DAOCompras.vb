Imports ClasesCompartidas

Public Class DAOCompras

    Public Shared Sub agregarDatosCuentaCorriente(ByVal compra As Compra)
        Dim datosCuotas As New List(Of Tuple(Of String, String, String, Double, Double)) '1: Numero 2: Fecha vto 3: Fecha vto 2 4: Total 5: Saldo
        datosCuotas.Add(Tuple.Create(compra.numero, compra.fechaVto1, compra.fechaVto2, compra.total, compra.total))
        If compra.usaCuotas() Then
            datosCuotas(0) = Tuple.Create(datosCuotas(0).Item1, datosCuotas(0).Item2, datosCuotas(0).Item3, datosCuotas(0).Item4, 0.0)
            crarCuotasPara(compra, datosCuotas)
        End If
        For Each datoCuotas In datosCuotas
            SQLConnector.executeProcedure("alta_cuenta_corriente", compra.tipoPago, compra.codigoProveedor, compra.letra, ceros(compra.tipoDocumento, 2), compra.punto,
                                      datoCuotas.Item1, compra.fechaEmision, datoCuotas.Item2, datoCuotas.Item3, datoCuotas.Item4, datoCuotas.Item5,
                                      compra.tipoDocumentoDescripcion, compra.nroInterno, compra.paridad, compra.formaPago)
        Next
    End Sub

    Private Shared Sub crarCuotasPara(ByVal compra As Compra, ByRef datosCuotas As List(Of Tuple(Of String, String, String, Double, Double)))
        Dim cantidadCuotas, mes, anio As Integer
        cantidadCuotas = CustomConvert.toIntOrZero(compra.pagoPyme.Item1)
        mes = CustomConvert.toIntOrZero(compra.pagoPyme.Item2)
        anio = CustomConvert.toIntOrZero(compra.pagoPyme.Item3)

        For x As Integer = 1 To cantidadCuotas
            datosCuotas.Add(Tuple.Create(truncarUltimosDosCon(compra.numero, x), fechaSegun(mes + x, anio),
                                         fechaSegun(mes + x, anio), compra.total / cantidadCuotas,
                                         compra.total / cantidadCuotas))
        Next
    End Sub

    Private Shared Function fechaSegun(ByVal mes As Integer, ByVal anio As Integer) As String
        If mes > 12 Then
            mes = mes - 12
            anio = anio + 1
            fechaSegun(mes, anio)
        End If
        Dim fecha As String = "01" & "/" & ceros(mes, 2) & "/" & anio
        Return CustomConvert.asTextDate(fecha).ToString
    End Function

    Private Shared Function truncarUltimosDosCon(ByVal text As String, ByVal valor As String) As String
        Return text.Remove(6, 2).Insert(6, ceros(valor, 2))
    End Function

    Private Shared Function crearCompra(ByVal row As DataRow)
        Dim compra As Compra
        compra = New Compra(asInt(row("NroInterno")), DAOProveedor.buscarProveedorPorCodigo(row("Proveedor").ToString), asInt(row("Tipo")), "", asInt(row("Pago")), asInt(row("Contado")), row("Letra").ToString,
                                row("Punto").ToString, row("Numero").ToString, asDate(row("Fecha")), asDate(row("Periodo")), asDate(row("Vencimiento")), asDate(row("Vencimiento1")), asDouble(row("Paridad")),
                                asDouble(row("Neto")), asDouble(row("Iva21")), asDouble(row("Iva5")), asDouble(row("Iva27")), asDouble(row("Ib")), asDouble(row("Exento")), asDouble(row("Iva105")),
                                0, asBool(row("SoloIva")), row("Remito").ToString, row("Despacho").ToString)

        compra.agregarImputaciones(buscarImputacionesPorInterno(compra.nroInterno))
        compra.valoresAbsolutos()
        Return compra
    End Function

    Private Shared Function asDate(ByVal value)
        Return CustomConvert.asTextDate(value.ToString)
    End Function

    Private Shared Function asInt(ByVal value)
        Return CustomConvert.toIntOrZero(value.ToString)
    End Function

    Private Shared Function asDouble(ByVal value)
        Return CustomConvert.toDoubleOrZero(value.ToString)
    End Function

    Private Shared Function asBool(ByVal value)
        Return CustomConvert.toBoolOrFalse(value)
    End Function

    Public Shared Function facturaPagada(ByVal nroInterno As Integer) As Boolean
        Return SQLConnector.executeProcedureWithReturnValue("factura_pagada", nroInterno)
    End Function

    Public Shared Function buscarCompraPorCodigo(ByVal codigo As String)
        Dim row As DataRow
        Try
            row = SQLConnector.retrieveDataTable("get_compra_por_codigo", CustomConvert.toIntOrZero(codigo)).Rows(0)
        Catch ex As Exception
            Return Nothing
        End Try
        Return crearCompra(row)
    End Function

    Public Shared Function buscarImputacionesPorInterno(ByVal interno As Integer)
        Dim imputaciones As New List(Of Imputac)
        'Try

        Dim table As DataTable = SQLConnector.retrieveDataTable("get_imputaciones_por_nro_interno", interno)
        For Each row As DataRow In table.Rows
            imputaciones.Add(New Imputac(asDate(row("Fecha")), asDouble(row("Debito")), asDouble(row("Credito")), row("Proveedor").ToString,
                                         row("Cuenta").ToString, interno.ToString, row("PuntoComp").ToString, row("NroComp").ToString,
                                         "", "", row("LetraComp").ToString))
        Next
        'Catch ex As Exception
        '   imputaciones.Clear()
        'End Try
        Return imputaciones
    End Function


    Public Shared Sub agregarCompra(ByVal compra As Compra)
        SQLConnector.executeProcedure("alta_iva_compra", compra.nroInterno, compra.codigoProveedor, compra.tipoDocumento, compra.letra, compra.punto, compra.numero, compra.fechaEmision,
                                      compra.fechaVto1, compra.fechaVto2, compra.fechaIVA, compra.neto, compra.iva21, compra.ivaRG, compra.iva27,
                                      compra.percibidoIB, compra.exento, compra.tipoPago, compra.tipoDocumentoDescripcion, compra.paridad,
                                      compra.formaPago, compra.proveedor.cai, compra.proveedor.vtoCAI, compra.iva105, compra.despacho, compra.remito, compra.soloIVA)
        agregarImputaciones(compra.imputaciones)
    End Sub

    Private Shared Sub agregarImputaciones(ByVal imputaciones As List(Of Imputac))
        imputaciones.ForEach(Sub(imputacion) SQLConnector.executeProcedure("alta_imputacion", imputacion.clave, imputacion.tipoMovimiento, imputacion.proveedor, imputacion.tipoComprobante,
                                                                           imputacion.letra, imputacion.punto, imputacion.numero, imputacion.renglon,
                                                                           imputacion.fechaord, "", imputacion.cuenta, imputacion.debito, imputacion.credito, imputacion.nrointerno))
    End Sub

    Public Shared Function siguienteNumeroDeInterno() As Long
        Return SQLConnector.retrieveDataTable("get_siguiente_numero_interno").Rows(0)(0)
    End Function
End Class
