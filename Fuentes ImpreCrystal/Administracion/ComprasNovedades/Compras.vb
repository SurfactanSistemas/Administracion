Imports ClasesCompartidas

Public Class Compras

    Dim diasPlazo As Integer = 0
    Dim letrasValidas As New List(Of String) From {"A", "B", "C", "X", "M", "I"}
    Dim pagoPyme As Tuple(Of String, String, String) = Tuple.Create("", "", "")
    Dim proveedor As Proveedor
    Dim apertura As New Apertura

    Private Sub Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gridBuilder As New GridBuilder(gridAsientos)

        gridBuilder.addTextColumn(0, "Cuenta")
        gridBuilder.addTextColumn(1, "Descripción")
        gridBuilder.addPositiveFloatColumn(2, "Débito")
        gridBuilder.addPositiveFloatColumn(3, "Crédito")

        Dim commonEventsHandler As New CommonEventsHandler
        commonEventsHandler.setIndexTab(Me)
    End Sub

    Private Sub txtNumero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.Leave
        txtNumero.Text = ceros(txtNumero.Text, 8)
    End Sub

    Private Sub txtPunto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPunto.Leave
        txtPunto.Text = ceros(txtPunto.Text, 4)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtTipo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipo.Leave
        Dim tipo As Integer = Val(txtTipo.Text)
        If 1 <= tipo And tipo <= 3 Then
            cmbTipo.SelectedIndex = tipo - 1
        Else
            cmbTipo.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If cmbTipo.SelectedIndex <> -1 Then
            txtTipo.Text = "0" & cmbTipo.SelectedIndex + 1
        End If
        gridAsientos.Rows.Clear()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Cleanner.clean(Me)
        gridAsientos.Rows.Clear()
        chkSoloIVA.Checked = False
        optEfectivo.Checked = True
        apertura = New Apertura
    End Sub

    Public Sub mostrarProveedor(ByVal proveedorAMostrar As Proveedor)
        If Not proveedorAMostrar.estaDefinidoCompleto Then
            proveedorAMostrar = DAOProveedor.buscarProveedorPorCodigo(proveedorAMostrar.id)
        End If
        proveedor = proveedorAMostrar
        txtCodigoProveedor.Text = proveedor.id
        txtNombreProveedor.Text = proveedor.razonSocial
        txtCAI.Text = proveedor.cai
        txtVtoCAI.Text = proveedor.vtoCAI
        diasPlazo = CustomConvert.toIntOrZero(proveedor.diasPlazo)
    End Sub

    Public Sub mostrarCuentaContable(ByVal cuenta As CuentaContable)
        If gridAsientos.SelectedCells.Count > 0 Then
            Dim selectedRow As Integer = gridAsientos.SelectedCells(0).RowIndex

            If selectedRow <> -1 Then
                gridAsientos.Rows(selectedRow).Cells(0).Value = cuenta.id
            End If
        End If
    End Sub

    Private Sub txtCodigoProveedor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoProveedor.Leave
        proveedor = DAOProveedor.buscarProveedorPorCodigo(txtCodigoProveedor.Text)
        If Not IsNothing(proveedor) Then
            mostrarProveedor(proveedor)
        Else
            txtNombreProveedor.Text = ""
            txtCAI.Text = ""
            txtVtoCAI.Text = "  /  /    "
            diasPlazo = 0
        End If
    End Sub

    Private Sub cmbFormaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFormaPago.KeyDown
        If e.KeyValue = Keys.Enter Then
            cmbFormaPago_SelectedIndexChanged(sender, Nothing)
        End If
    End Sub

    Private Sub cmbFormaPago_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.Leave
        cmbFormaPago_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        txtParidad.Empty = cmbFormaPago.SelectedIndex <> 2
        If txtParidad.Empty Then
            txtParidad.Enabled = False
            txtParidad.Text = ""
        Else
            txtParidad.Enabled = True
        End If
    End Sub

    Private Sub txtImporte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVARG.Leave, txtPercIB.Leave, txtNoGravado.Leave, txtIVA27.Leave, txtIVA21.Leave, txtIVA10.Leave
        Dim total As Double = asDouble(txtIVA21.Text) + asDouble(txtIVARG.Text) + asDouble(txtIVA27.Text) + asDouble(txtPercIB.Text) + asDouble(txtNoGravado.Text) + asDouble(txtIVA10.Text) + asDouble(txtNeto.Text)
        txtTotal.Text = CustomConvert.toStringWithTwoDecimalPlaces(Math.Round(total, 2))
    End Sub

    Private Sub txtNeto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNeto.Leave
        If txtIVA21.Enabled Then
            txtIVA21.Text = CustomConvert.toStringWithTwoDecimalPlaces(Math.Round(asDouble(txtNeto.Text) * 0.21, 2))
        End If
        txtImporte_Leave(sender, e)
    End Sub

    Private Function asDouble(ByVal text As String)
        Return CustomConvert.toDoubleOrZero(text)
    End Function

    Private Function validarCampos() As Boolean
        Dim validador As New Validator

        validador.validate(Me)
        validador.alsoValidate(CustomConvert.toIntOr(txtPunto.Text, 0) <> 0, "El campo " & CustomLabel6.Text & " no puede ser cero")
        validador.alsoValidate(CustomConvert.toIntOr(txtNumero.Text, 0) <> 0, "El campo " & CustomLabel7.Text & " no puede ser cero")
        validador.alsoValidate(letrasValidas.Contains(txtLetra.Text) Or txtLetra.Text = "", "El valor ingresado (" & txtLetra.Text & ") no es una letra válida")
        validador.alsoValidate(DAOCierreMes.mesAbierto(txtFechaEmision.Text), "El mes de la fecha de emisión: " & txtFechaEmision.Text & " se encuentra cerrado según el sistema")
        validador.alsoValidate(gridAsientos.Rows.Count > 1, "No fue generado el asiento. No se puede confirmar")
        validador.alsoValidate(lblCredito.Text = lblDebito.Text, "El asiento se encuentra desbalanceado. Hay una diferencia de: " & Math.Abs(asDouble(lblCredito.Text) - asDouble(lblDebito.Text)))
        validador.alsoValidate(asientosCorrectos(), "El asiento se encuentra en un estado inválido, puede que falte asignar alguna cuenta")
        validador.alsoValidate(valoresDebeYHaberCorrectos(), "Una entrada del asiento tiene valores inválidos de Débito y/o Crédito")
        validador.alsoValidate(asDouble(lblDebito.Text) = asDouble(txtTotal.Text), "El total del asiento contable tiene que ser igual al importe total")
        validador.alsoValidate(esValidoNacion, "No se cargaron las cuotas de PyME nación correctamente")

        Return validador.flush
    End Function

    Private Function valoresDebeYHaberCorrectos()
        Dim estado As Boolean = True
        For Each row As DataGridViewRow In gridAsientos.Rows
            estado = estado And (asDouble(row.Cells(2).Value) = 0 Xor asDouble(row.Cells(3).Value) = 0) _
                And asDouble(row.Cells(2).Value) >= 0 And asDouble(row.Cells(3).Value) >= 0
        Next
        Return estado
    End Function

    Private Function asientosCorrectos()
        Dim estado As Boolean = True
        For Each row As DataGridViewRow In gridAsientos.Rows
            estado = estado And row.Cells(1).Value <> ""
        Next
        Return estado
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If validarCampos() Then
            actualizarProveedor()
            Dim compra As Compra = crearCompra()
            If DAOCompras.facturaPagada(compra.nroInterno) Then
                MsgBox("No se puede modificar una factura que ya fue pagada", MsgBoxStyle.Exclamation, "No se puede confirmar la operación")
                Exit Sub
            End If
            txtNroInterno.Text = compra.nroInterno
            DAOCompras.agregarCompra(compra)
            If usaCuentas() Then
                If cuotasCargadas() Then
                    compra.agregarPagoPyme(pagoPyme)
                End If
                DAOCompras.agregarDatosCuentaCorriente(compra)
            End If
            MsgBox("El número de interno asignado es: " & compra.nroInterno)
        End If
    End Sub

    Private Function crearCompra() As Compra
        Dim multiplicadorPorNotaDeCredito As Integer = 1
        If esNotaDeCredito() Then
            multiplicadorPorNotaDeCredito = -1
        End If
        Dim interno As Integer = CustomConvert.toIntOrZero(txtNroInterno.Text)
        If interno = 0 Then : interno = DAOCompras.siguienteNumeroDeInterno() : End If
        Dim compra As New Compra(interno, proveedor, txtTipo.Text, cmbTipo.Text, cmbFormaPago.SelectedIndex,
                                 tipoPago(), txtLetra.Text, txtPunto.Text, txtNumero.Text, txtFechaEmision.Text, txtFechaIVA.Text, txtFechaVto1.Text, txtFechaVto2.Text,
                                 asDouble(txtParidad.Text), asDouble(txtNeto.Text) * multiplicadorPorNotaDeCredito, asDouble(txtIVA21.Text) * multiplicadorPorNotaDeCredito,
                                 asDouble(txtIVARG.Text) * multiplicadorPorNotaDeCredito, asDouble(txtIVA27.Text) * multiplicadorPorNotaDeCredito,
                                 asDouble(txtPercIB.Text) * multiplicadorPorNotaDeCredito, asDouble(txtNoGravado.Text) * multiplicadorPorNotaDeCredito,
                                 asDouble(txtIVA10.Text) * multiplicadorPorNotaDeCredito, asDouble(txtTotal.Text) * multiplicadorPorNotaDeCredito, chkSoloIVA.Checked,
                                 txtRemito.Text, txtDespacho.Text)
        crearImputaciones(compra)
        Return compra
    End Function

    Private Sub crearImputaciones(ByVal compra As Compra)
        Dim imputaciones As New List(Of Imputac)
        For Each row As DataGridViewRow In gridAsientos.Rows
            imputaciones.Add(New Imputac(compra.fechaEmision, asDouble(row.Cells(2).Value), asDouble(row.Cells(3).Value), proveedor.id, row.Cells(0).Value, compra.nroInterno,
                                         compra.punto, compra.numero, compra.despacho, compra.letra, compra.tipoDocumento, ceros((row.Index + 1).ToString, 2)))
        Next

        compra.agregarImputaciones(imputaciones)
    End Sub

    Private Function tipoPago() As Integer
        If optEfectivo.Checked Then : Return 1 : End If
        If optCtaCte.Checked Then : Return 2 : End If
        Return 3
    End Function

    Private Sub actualizarProveedor()
        proveedor.cai = txtCAI.Text
        proveedor.vtoCAI = txtVtoCAI.Text
        If IsNothing(proveedor.cuenta) Then
            proveedor.cuenta = DAOProveedor.cuentaDefault
        End If
        DAOProveedor.agregarProveedor(proveedor)
    End Sub

    Private Sub txtFechaEmision_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaEmision.Leave
        Try
            Dim fecha As Date = Convert.ToDateTime(txtFechaEmision.Text)
            txtFechaIVA.Text = fecha.ToShortDateString
            txtFechaVto1.Text = fecha.AddDays(diasPlazo).ToShortDateString()
            txtFechaVto2.Text = txtFechaVto1.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSoloIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloIVA.CheckedChanged
        If chkSoloIVA.Checked Then
            txtNeto.Text = 0
        End If
        txtNeto.Enabled = Not chkSoloIVA.Checked
        txtImporte_Leave(sender, e)
    End Sub

    Private Sub txtLetra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLetra.TextChanged
        txtLetra.Text = txtLetra.Text.ToUpper
        If txtLetra.Text = "C" Then
            txtIVA21.Enabled = False
            txtIVARG.Enabled = False
            txtIVA27.Enabled = False
            txtPercIB.Enabled = False
            txtNoGravado.Enabled = False
            txtIVA10.Enabled = False
            txtIVA21.Text = "0,00"
            txtIVARG.Text = "0,00"
            txtIVA27.Text = "0,00"
            txtPercIB.Text = "0,00"
            txtNoGravado.Text = "0,00"
            txtIVA10.Text = "0,00"
        Else
            txtIVA21.Enabled = True
            txtIVARG.Enabled = True
            txtIVA27.Enabled = True
            txtPercIB.Enabled = True
            txtNoGravado.Enabled = True
            txtIVA10.Enabled = True
        End If
        txtLetra.Select(txtLetra.Text.Count, 1)
        txtImporte_Leave(sender, e)
    End Sub

    Private Sub txtDespacho_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDespacho.Leave
        Dim cuenta As CuentaContable
        If IsNothing(proveedor) Then
            cuenta = DAOProveedor.cuentaDefault
        Else
            If IsNothing(proveedor.cuenta) Then : proveedor.cuenta = DAOProveedor.cuentaDefault : End If
            cuenta = proveedor.cuenta
        End If

        If txtLetra.Text = "I" Then
            cuenta = DAOCuentaContable.proveedoresInternacionales
        End If

        crearAsientoContableUsando(cuenta)
        If gridAsientos.Rows.Count > 0 Then
            gridAsientos.CurrentCell = gridAsientos.Rows(gridAsientos.Rows.Count - 1).Cells(0)
            gridAsientos.Select()
        End If
    End Sub

    Private Function esNotaDeCredito()
        Return txtTipo.Text = "03"
    End Function

    Private Function cuentaIVACredito() As CuentaContable
        Return DAOCuentaContable.IVACredito()
    End Function

    Private Function cuentaIngresosBrutos() As CuentaContable
        Return DAOCuentaContable.ingresosBrutos
    End Function

    Private Function cuentaIVARG3337() As CuentaContable
        Return DAOCuentaContable.IVARG3337
    End Function

    Private Sub crearAsientoContableUsando(ByVal cuenta As CuentaContable)
        gridAsientos.Rows.Clear()
        Dim total As Double = asDouble(txtTotal.Text)
        Dim sumaIvas As Double = asDouble(txtIVA10.Text) + asDouble(txtIVA21.Text) + asDouble(txtIVA27.Text) + asDouble(txtNoGravado.Text)
        Dim ivaRG3337 As Double = asDouble(txtIVARG.Text)
        Dim ingresosBrutos As Double = asDouble(txtPercIB.Text)
        Dim diferencia As Double = total - sumaIvas - ingresosBrutos - ivaRG3337

        If esNotaDeCredito() Then
            If total <> 0 Then : gridAsientos.Rows.Add(cuenta.id, cuenta.descripcion, total, 0) : End If
            If sumaIvas <> 0 Then : gridAsientos.Rows.Add(cuentaIVACredito.id, cuentaIVACredito.descripcion, 0, sumaIvas) : End If
            If ivaRG3337 <> 0 Then : gridAsientos.Rows.Add(cuentaIVARG3337.id, cuentaIVARG3337.descripcion, 0, ivaRG3337) : End If
            If ingresosBrutos <> 0 Then : gridAsientos.Rows.Add(cuentaIngresosBrutos.id, cuentaIngresosBrutos.descripcion, 0, ingresosBrutos) : End If
            If diferencia <> 0 Then : gridAsientos.Rows.Add("", "", 0, diferencia) : End If
        Else
            If total <> 0 Then : gridAsientos.Rows.Add(cuenta.id, cuenta.descripcion, 0, total) : End If
            If sumaIvas <> 0 Then : gridAsientos.Rows.Add(cuentaIVACredito.id, cuentaIVACredito.descripcion, sumaIvas, 0) : End If
            If ivaRG3337 <> 0 Then : gridAsientos.Rows.Add(cuentaIVARG3337.id, cuentaIVARG3337.descripcion, ivaRG3337, 0) : End If
            If ingresosBrutos <> 0 Then : gridAsientos.Rows.Add(cuentaIngresosBrutos.id, cuentaIngresosBrutos.descripcion, ingresosBrutos, 0) : End If
            If diferencia <> 0 Then : gridAsientos.Rows.Add("", "", diferencia, 0) : End If
        End If

        calcularAsiento()
    End Sub

    Private Sub calcularAsiento()
        Dim valorDebe As Double = 0
        Dim valorHaber As Double = 0
        For Each row As DataGridViewRow In gridAsientos.Rows
            valorDebe += asDouble(row.Cells(2).Value)
            valorHaber += asDouble(row.Cells(3).Value)
        Next
        lblDebito.Text = CustomConvert.toStringWithTwoDecimalPlaces(valorDebe)
        lblCredito.Text = CustomConvert.toStringWithTwoDecimalPlaces(valorHaber)
    End Sub

    Private Sub gridAsientos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridAsientos.CellValueChanged
        calcularAsiento()
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
            Exit Sub
        End If
        If e.ColumnIndex = 0 Then
            Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(gridAsientos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            If Not IsNothing(cuenta) Then
                gridAsientos.Rows(e.RowIndex).Cells(1).Value = cuenta.descripcion
            Else
                gridAsientos.Rows(e.RowIndex).Cells(1).Value = ""
            End If
        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        Dim consulta As New ConsultaCompras(Me)
        consulta.ShowDialog()
    End Sub

    Private Sub pulsarOption(ByVal val As Integer)
        Select Case val
            Case 3
                optNacion.Checked = True
            Case 2
                optCtaCte.Checked = True
            Case Else
                optEfectivo.Checked = True
        End Select
    End Sub

    Private Sub mostrarCompra(ByVal compra As Compra)
        txtNroInterno.Text = compra.nroInterno
        mostrarProveedor(compra.proveedor)
        txtTipo.Text = compra.tipoDocumento
        txtLetra.Text = compra.letra
        txtPunto.Text = compra.punto
        txtNumero.Text = compra.numero
        txtFechaEmision.Text = compra.fechaEmision
        txtFechaIVA.Text = compra.fechaIVA
        txtFechaVto1.Text = compra.fechaVto1
        txtFechaVto2.Text = compra.fechaVto2
        txtRemito.Text = compra.remito
        cmbFormaPago.SelectedIndex = compra.formaPago
        txtParidad.Text = compra.paridad
        txtNeto.Text = compra.neto
        txtIVA10.Text = compra.iva105
        txtIVA21.Text = compra.iva21
        txtIVA27.Text = compra.iva27
        txtIVARG.Text = compra.ivaRG
        txtPercIB.Text = compra.percibidoIB
        txtNoGravado.Text = compra.exento
        txtDespacho.Text = compra.despacho
        chkSoloIVA.Checked = compra.soloIVA
        pulsarOption(compra.tipoPago)
        txtImporte_Leave(Nothing, Nothing)
        txtTipo_Leave(Nothing, Nothing)
        mostrarImputaciones(compra.imputaciones)
        calcularAsiento()
    End Sub

    Private Sub mostrarImputaciones(ByVal imputaciones As List(Of Imputac))
        For Each imputacion As Imputac In imputaciones
            gridAsientos.Rows.Add(imputacion.cuenta, DAOCuentaContable.buscarCuentaContablePorCodigo(imputacion.cuenta).descripcion, imputacion.debito, imputacion.credito)
        Next
    End Sub

    Private Sub txtNroInterno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroInterno.Leave
        Dim compra As Compra = DAOCompras.buscarCompraPorCodigo(txtNroInterno.Text)
        If Not IsNothing(compra) Then
            mostrarCompra(compra)
        Else
            'Creo que no hay que hacer nada
        End If

    End Sub

    Private Sub btnConsultaNroFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaNroFactura.Click
    End Sub

    Private Sub btnApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApertura.Click
        apertura.ShowDialog()

        If Not apertura.IsDisposed Then
            txtNeto.Text = apertura.valorNeto
            txtIVA21.Text = apertura.valorIVA21
            txtIVA27.Text = apertura.valorIVA27
            txtIVARG.Text = apertura.valorIVARG
            txtIVA10.Text = apertura.valorIVA105
            txtNoGravado.Text = apertura.valorExento
            txtPercIB.Text = apertura.valorIB
            txtImporte_Leave(sender, Nothing)
            txtDespacho_Leave(sender, Nothing)
        End If
    End Sub

    Private Function usaCuentas()
        Return optNacion.Checked Or optCtaCte.Checked
    End Function

    Private Function esValidoNacion()
        Return (optNacion.Checked And cuotasCargadas()) Or Not optNacion.Checked
    End Function

    Private Function cuotasCargadas()
        Return pagoPyme.Item1 <> "" And pagoPyme.Item2 <> "" And pagoPyme.Item3 <> ""
    End Function

    Private Sub optNacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNacion.CheckedChanged
        If Not optNacion.Checked Then
            pagoPyme = Tuple.Create("", "", "")
        End If
    End Sub

    Private Sub optNacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNacion.Click
        If optNacion.Checked Then
            Dim pymeForm As New CuotasPyMENacion

            pymeForm.txtCantidadCuotas.Text = pagoPyme.Item1
            pymeForm.txtMes.Text = pagoPyme.Item2
            pymeForm.txtAnio.Text = pagoPyme.Item3

            If pymeForm.ShowDialog(Me) = DialogResult.OK Then
                pagoPyme = Tuple.Create(pymeForm.txtCantidadCuotas.Text, pymeForm.txtMes.Text, pymeForm.txtAnio.Text)
            End If
        End If
    End Sub
End Class