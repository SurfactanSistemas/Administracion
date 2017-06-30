Imports ClasesCompartidas

Public Class DAOCompras

    Public Shared Function datosNacion(ByVal nroInterno As Integer)
        Try
            Dim row As DataRow = SQLConnector.retrieveDataTable("get_datos_nacion", nroInterno).Rows(0)
            Dim fecha As DateTime = Convert.ToDateTime(row("Fecha").ToString)
            Dim mes As String = fecha.AddDays(-1).Month
            Dim anio As String = fecha.AddDays(-1).Year
            Return Tuple.Create(row("Cantidad").ToString, mes, anio)
        Catch ex As Exception
            Return Tuple.Create("", "", "")
        End Try
    End Function

    Public Shared Function buscarNumeroIntero(ByVal codigoProveedor As String, ByVal tipo As String, ByVal letra As String, ByVal punto As String, ByVal numero As String)
        Return SQLConnector.executeProcedureWithReturnValue("get_interno_segun", codigoProveedor, tipo, letra, punto, numero)
    End Function

    Public Shared Sub agregarDatosCuentaCorriente(ByVal compra As Compra)
        Dim saldo As Double = compra.total
        If Not (compra.tipoDocumentoDescripcion = "FC") Then ' Porque notas de credito o debito llevan un saldo de 0
            saldo = 0
        End If
        Dim datosCuotas As New List(Of Tuple(Of String, String, String, Double, Double)) '1: Numero 2: Fecha vto 3: Fecha vto 2 4: Total 5: Saldo
        datosCuotas.Add(Tuple.Create(compra.numero, compra.fechaVto1, compra.fechaVto2, compra.total, saldo))
        If compra.usaCuotas() Then
            datosCuotas(0) = Tuple.Create(datosCuotas(0).Item1, datosCuotas(0).Item2, datosCuotas(0).Item3, datosCuotas(0).Item4, 0.0)
            crarCuotasPara(compra, datosCuotas)
        End If
        Dim aumentoInterno As Integer = 0
        For Each datoCuotas In datosCuotas
            SQLConnector.executeProcedure("alta_cuenta_corriente", compra.tipoPago, compra.codigoProveedor, compra.letra, ceros(compra.tipoDocumento, 2), compra.punto,
                                      datoCuotas.Item1, compra.fechaEmision, datoCuotas.Item2, datoCuotas.Item3, datoCuotas.Item4, datoCuotas.Item5,
                                      compra.tipoDocumentoDescripcion, compra.nroInterno, compra.paridad, compra.formaPago)
            If compra.tipoPago = 3 And aumentoInterno > 0 Then
                SQLConnector.executeProcedure("alta_iva_compra_nacion", compra.nroInterno + aumentoInterno, DAOProveedor.bancoNacion.id, compra.tipoDocumento, compra.letra,
                                              compra.punto, compra.numero, compra.fechaEmision, datoCuotas.Item2, datoCuotas.Item3, compra.fechaIVA, 0, 0, 0, 0,
                                              0, 0, compra.tipoPago, compra.tipoDocumentoDescripcion, compra.paridad,
                                              compra.formaPago, compra.proveedor.cai, compra.proveedor.vtoCAI, 0, compra.despacho, compra.remito, compra.soloIVA, compra.nroInterno)
            End If
            aumentoInterno += 1
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


    Public Shared Sub agregarNota(ByVal compra As Compra)
        SQLConnector.executeProcedure("alta_iva_compra", compra.nroInterno, compra.codigoProveedor, compra.tipoDocumento, compra.letra, compra.punto, compra.numero, compra.fechaEmision,
                                      compra.fechaVto1, compra.fechaVto2, compra.fechaIVA, compra.neto, compra.iva21, compra.ivaRG, compra.iva27,
                                      compra.percibidoIB, compra.exento, compra.tipoPago, compra.tipoDocumentoDescripcion, compra.paridad,
                                      compra.formaPago, compra.proveedor.cai, compra.proveedor.vtoCAI, compra.iva105, compra.despacho, compra.remito, compra.soloIVA)
    End Sub

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

    Public Shared Sub agregarTablaIvaComprasAdicional(ByVal compra As Compra, ByVal rows As DataGridViewRowCollection)
        For Each row As DataGridViewRow In rows
            If Not row.IsNewRow Then
                Dim renglon As Int16 = row.Index + 1
                Dim clave As String = ceros(compra.nroInterno, 8) & ceros(renglon, 2)
                SQLConnector.executeProcedure("alta_iva_compras_adicional", clave, compra.nroInterno, renglon, row.Cells(0).Value,
                                              row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value,
                                              row.Cells(5).Value, row.Cells(6).Value, asDouble(row.Cells(7).Value), asDouble(row.Cells(8).Value),
                                              asDouble(row.Cells(9).Value), asDouble(row.Cells(10).Value), asDouble(row.Cells(11).Value),
                                              asDouble(row.Cells(12).Value), asDouble(row.Cells(13).Value))
            End If
        Next
    End Sub

    Public Shared Function siguienteNumeroDeInterno() As Long
        Return SQLConnector.retrieveDataTable("get_siguiente_numero_interno").Rows(0)(0)
    End Function

    Public Shared Function camposApertura(ByVal nroIntero As Integer)
        Return SQLConnector.retrieveDataTable("get_iva_compras_adicional", nroIntero)
    End Function
End Class
