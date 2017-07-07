Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class Compras

    Dim diasPlazo As Integer = 0
    Dim letrasValidas As New List(Of String) From {"A", "B", "C", "X", "M", "I"}
    Dim proveedor As Proveedor
    Dim apertura As New Apertura
    Dim esModificacion As Boolean = False
    Private _RetIB1, _RetIB2, _RetIB3, _RetIB4, _RetIB5, _RetIB6, _RetIB7, _
            _RetIB8, _RetIB9, _RetIB10, _RetIB11, _RetIB12, _RetIB13, _RetIB14 As String
    Dim _PyMENacion() As Integer = {0, 0, 0} ' Cuotas, Mes, Año.

    Dim commonEventsHandler As New CommonEventsHandler

    Private Sub Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gridBuilder As New GridBuilder(gridAsientos)

        gridBuilder.addTextColumn(0, "Cuenta")
        gridBuilder.addTextColumn(1, "Descripción")
        gridBuilder.addTextColumn(2, "Débito")
        gridBuilder.addTextColumn(3, "Crédito")

        btnLimpiar.PerformClick()

    End Sub

    Private Sub _AlinearDerecha(ByRef columna As DataGridViewColumn)
        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'Cleanner.clean(Me)
        For Each _txt As TextBox In Me.Panel2.Controls.OfType(Of TextBox)() ' Limpiamos todos los textbox del Formulario.
            _txt.Text = ""
        Next

        For Each _msk As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)() ' Limpiamos todos los campos fecha.
            _msk.Clear()
        Next

        For Each _cmb As ComboBox In Me.Panel2.Controls.OfType(Of ComboBox)() ' Limpiamos todos los campos combo.
            _cmb.SelectedIndex = 0
        Next

        gridAsientos.Rows.Clear()
        chkSoloIVA.Checked = False
        optCtaCte.Checked = True
        apertura = New Apertura
        esModificacion = False
        diasPlazo = 0

        Dim ibs As New List(Of String) From {_RetIB1, _RetIB2, _RetIB3, _RetIB4, _RetIB5, _RetIB6, _RetIB7, _RetIB8, _RetIB9, _RetIB10, _RetIB11, _RetIB12, _RetIB13, _RetIB14}

        For Each ib In ibs
            ib = ""
        Next

        ibs = Nothing

        Array.Clear(_PyMENacion, 0, _PyMENacion.Length)

        txtCodigoProveedor.Focus()
    End Sub

    Public Sub mostrarProveedor(ByVal proveedorAMostrar As Proveedor)
        If Not proveedorAMostrar.estaDefinidoCompleto Then
            Try
                proveedorAMostrar = DAOProveedor.buscarProveedorPorCodigo(proveedorAMostrar.id)
            Catch ex As Exception
                MsgBox("")
            End Try
        End If
        If Not optNacion.Checked Then
            proveedor = proveedorAMostrar
        End If
        txtCodigoProveedor.Text = proveedorAMostrar.id
        txtNombreProveedor.Text = proveedorAMostrar.razonSocial
        txtCAI.Text = proveedorAMostrar.cai
        txtVtoCAI.Text = proveedorAMostrar.vtoCAI
        CBLetra.SelectedIndex = 0
        cmbFormaPago.SelectedIndex = 0

        If Val(proveedorAMostrar.codIva) = 5 Then
            cmbTipo.SelectedIndex = 0
            CBLetra.SelectedIndex = 2
            _HabilitarDeshabilitarControlesSegunLetra()
        End If

        diasPlazo = _ExtraerSoloNumeros(proveedorAMostrar.diasPlazo)
    End Sub

    Public Sub mostrarProveedor(ByVal _proveedorAMostrar As String)
        Dim proveedorAMostrar As Proveedor = DAOProveedor.buscarProveedorPorNombre(_proveedorAMostrar)(0)

        mostrarProveedor(proveedorAMostrar)

    End Sub

    Private Function _ExtraerSoloNumeros(ByVal Plazo As String) As String
        Dim regex As New System.Text.RegularExpressions.Regex("[^0-9]+")

        Dim dias As String = regex.Replace(Plazo, "")
        Return IIf(dias = "", 0, Mid(dias, 1, 2))
    End Function

    Public Sub mostrarProveedorConsulta(ByVal proveedorAMostrar As String)

        If proveedorAMostrar <> "" Then
            btnLimpiar.PerformClick()
            mostrarProveedor(proveedorAMostrar)
        End If

    End Sub

    Public Sub mostrarCuentaContable(ByVal cuenta As CuentaContable)
        If gridAsientos.SelectedCells.Count > 0 Then
            Dim selectedRow As Integer = gridAsientos.SelectedCells(0).RowIndex

            If selectedRow <> -1 Then
                gridAsientos.Rows(selectedRow).Cells(0).Value = cuenta.id
            End If
        End If
    End Sub

    Private Sub txtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown
        If e.KeyValue = Keys.Enter Then

            ' Abrimos la consulta en caso de que no haya proveedor cargado.
            If Trim(txtCodigoProveedor.Text) = "" Then
                Dim consulta As New ConsultaCompras(Me, True)
                consulta.ShowDialog()
                If Trim(txtNombreProveedor.Text) <> "" And Trim(txtCodigoProveedor.Text) <> "" Then
                    txtPunto.Focus()
                End If
            Else
                Dim prov As String = txtCodigoProveedor.Text
                ' Buscamos el proveedor.
                proveedor = DAOProveedor.buscarProveedorPorCodigo(prov)
                If Not IsNothing(proveedor) Then
                    mostrarProveedor(proveedor)

                    txtPunto.Focus()

                Else
                    ' En caso de no existir, se notifica al usuario.
                    btnLimpiar.PerformClick()
                    txtCodigoProveedor.Text = prov
                    MessageBox.Show("El proveedor ingresado es inexistente")
                    txtCodigoProveedor.Focus()
                End If
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoProveedor.Text = ""
        End If
    End Sub

    Private Sub txtImporte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVARG.Leave, txtPercIB.Leave, txtNoGravado.Leave, txtIVA27.Leave, txtIVA21.Leave, txtIVA10.Leave
        Dim total As Double = calculoTotal()
        txtTotal.Text = CustomConvert.toStringWithTwoDecimalPlaces(Math.Round(total, 2))
    End Sub

    Private Sub _FormatearNumero(Optional ByRef numero As String = "")

        numero = IIf(IsNothing(numero) Or numero = "", "0", numero)

        If _NecesarioFormatear(numero) Then
            numero = CustomConvert.toStringWithTwoDecimalPlaces(numero)
        End If

    End Sub

    Private Sub _FormatearNumeros()

        Dim numeros As New List(Of TextBox) From {txtNeto, txtIVA10, txtIVA21, txtIVA27, txtIVARG, txtNoGravado, txtParidad, txtPercIB, txtTotal}

        For Each _n As TextBox In numeros
            If _NecesarioFormatear(_n.Text) Then
                _FormatearNumero(_n.Text)
            End If
        Next

    End Sub

    Private Function _NecesarioFormatear(ByVal numero As String) As Boolean
        Dim formatear As Boolean = True
        Dim regex As New System.Text.RegularExpressions.Regex("([\,|\.]00)$")

        If regex.IsMatch(numero) Or numero = "" Then
            formatear = False
        End If

        Return formatear
    End Function

    Private Function calculoTotal() As Double

        If UCase(CBLetra.SelectedItem) = "C" Then
            Return asDouble(txtNeto.Text)
        End If

        Return asDouble(txtIVA21.Text) + asDouble(txtIVARG.Text) + asDouble(txtIVA27.Text) + asDouble(txtPercIB.Text) + asDouble(txtNoGravado.Text) + asDouble(txtIVA10.Text) + asDouble(txtNeto.Text)
    End Function

    Private Function asDouble(ByVal text As String)
        Return CustomConvert.toDoubleOrZero(text)
    End Function

    Private Function validarCampos() As Boolean
        Dim validador As New Validator

        validador.validate(Me)
        validador.alsoValidate(CustomConvert.toIntOr(txtPunto.Text, 0) <> 0, "El campo " & CustomLabel6.Text & " no puede ser cero")
        validador.alsoValidate(CustomConvert.toIntOr(txtNumero.Text, 0) <> 0, "El campo " & CustomLabel7.Text & " no puede ser cero")
        Dim letra As String = letrasValidas.Find(Function(l) l = CBLetra.SelectedItem)
        validador.alsoValidate(Not IsNothing(letra) And letra <> "", "El valor ingresado (" & CBLetra.SelectedItem & ") no es una letra válida")
        validador.alsoValidate(DAOCierreMes.mesAbierto(txtFechaIVA.Text), "El mes de la fecha de emisión: " & txtFechaIVA.Text & " se encuentra cerrado según el sistema")
        validador.alsoValidate(gridAsientos.Rows.Count > 1, "No fue generado el asiento. No se puede confirmar")
        validador.alsoValidate(lblCredito.Text = lblDebito.Text, "El asiento se encuentra desbalanceado. Hay una diferencia de: " & Math.Abs(asDouble(lblCredito.Text) - asDouble(lblDebito.Text)))
        validador.alsoValidate(asientosCorrectos(), "El asiento se encuentra en un estado inválido, puede que falte asignar alguna cuenta")
        validador.alsoValidate(valoresDebeYHaberCorrectos(), "Una entrada del asiento tiene valores inválidos de Débito y/o Crédito")
        validador.alsoValidate(asDouble(lblDebito.Text) = asDouble(txtTotal.Text), "El total del asiento contable tiene que ser igual al importe total")
        validador.alsoValidate(esValidoNacion, "No se cargaron las cuotas de PyME nación correctamente")
        validador.alsoValidate(laParidadEsValida, "La paridad con el dólar tiene que ser un valor positivo")

        Return validador.flush
    End Function

    Private Function laParidadEsValida()
        If cmbTipo.SelectedIndex = 2 Then
            Return CustomConvert.toDoubleOrZero(txtParidad.Text)
        End If
        Return True
    End Function

    Private Function valoresDebeYHaberCorrectos()
        Dim estado As Boolean = True
        For Each row As DataGridViewRow In gridAsientos.Rows

            If Not row.IsNewRow Then
                estado = estado And (asDouble(row.Cells(2).Value) = 0 Xor asDouble(row.Cells(3).Value) = 0) _
                    And asDouble(row.Cells(2).Value) >= 0 And asDouble(row.Cells(3).Value) >= 0
            End If

        Next
        Return estado
    End Function

    Private Function asientosCorrectos()
        Dim estado As Boolean = True
        For Each row As DataGridViewRow In gridAsientos.Rows
            If Not row.IsNewRow Then
                If Not IsNothing(row.Cells(0).Value) And Not IsNothing(row.Cells(1).Value) Then
                    estado = estado And row.Cells(1).Value <> ""
                End If
            End If
        Next
        Return estado
    End Function

    Private Sub _EliminarFilasEnBlanco()
        For Each row As DataGridViewRow In gridAsientos.Rows

            With row
                gridAsientos.CommitEdit(DataGridViewDataErrorContexts.Commit)
                If IsNothing(.Cells(0).Value) And IsNothing(.Cells(1).Value) And IsNothing(.Cells(2).Value) And IsNothing(.Cells(3).Value) Then
                    If Not .IsNewRow Then
                        gridAsientos.Rows().Remove(row)
                    End If
                End If

            End With

        Next
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        _EliminarFilasEnBlanco()

        If validarCampos() Then
            Try
                actualizarProveedor()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            Dim compra As Compra = crearCompra()
            If DAOCompras.facturaPagada(compra.nroInterno) Then
                MsgBox("No se puede modificar una factura que ya se encuentra paga", MsgBoxStyle.Exclamation, "No se puede confirmar la operación")
                Exit Sub
            End If
            txtNroInterno.Text = compra.nroInterno
            DAOCompras.agregarCompra(compra)
            If usaCuentas() Then
                If cuotasCargadas() Then
                    compra.agregarPagoPyme(_PyMENacion)
                End If
                DAOCompras.agregarDatosCuentaCorriente(compra)
            End If
            If Not IsNothing(apertura) Then
                DAOCompras.agregarTablaIvaComprasAdicional(compra, apertura.gridApertura.Rows)
            End If
            MsgBox("El número de Factura asignado es: " & compra.nroInterno, MsgBoxStyle.Information)
            btnLimpiar.PerformClick()
        End If
    End Sub

    Private Function crearCompra() As Compra
        Dim multiplicadorPorNotaDeCredito As Integer = 1
        If esNotaDeCredito() Then
            multiplicadorPorNotaDeCredito = -1
        End If
        Dim interno As Integer = CustomConvert.toIntOrZero(txtNroInterno.Text)
        If interno = 0 Then : interno = DAOCompras.siguienteNumeroDeInterno() : End If
        Dim compra As New Compra(interno, proveedor, cmbTipo.SelectedIndex, cmbTipo.Text, cmbFormaPago.SelectedIndex,
                                 tipoPago(), CBLetra.SelectedItem, txtPunto.Text, txtNumero.Text, txtFechaEmision.Text, txtFechaIVA.Text, txtFechaVto1.Text, txtFechaVto2.Text,
                                 asDouble(txtParidad.Text), asDouble(txtNeto.Text) * multiplicadorPorNotaDeCredito, asDouble(txtIVA21.Text) * multiplicadorPorNotaDeCredito,
                                 asDouble(txtIVARG.Text) * multiplicadorPorNotaDeCredito, asDouble(txtIVA27.Text) * multiplicadorPorNotaDeCredito,
                                 asDouble(txtPercIB.Text) * multiplicadorPorNotaDeCredito, asDouble(txtNoGravado.Text) * multiplicadorPorNotaDeCredito,
                                 asDouble(txtIVA10.Text) * multiplicadorPorNotaDeCredito, asDouble(txtTotal.Text) * multiplicadorPorNotaDeCredito, chkSoloIVA.Checked,
                                 txtRemito.Text, txtDespacho.Text, asDouble(_RetIB1), asDouble(_RetIB2), asDouble(_RetIB3), asDouble(_RetIB4), asDouble(_RetIB5), asDouble(_RetIB6), asDouble(_RetIB7), asDouble(_RetIB8), asDouble(_RetIB9), asDouble(_RetIB10), asDouble(_RetIB11), asDouble(_RetIB12), asDouble(_RetIB13), asDouble(_RetIB14))
        crearImputaciones(compra)
        Return compra
    End Function

    Private Sub crearImputaciones(ByVal compra As Compra)
        Dim imputaciones As New List(Of Imputac)
        For Each row As DataGridViewRow In gridAsientos.Rows

            If Not row.IsNewRow Then
                imputaciones.Add(New Imputac(compra.fechaEmision, asDouble(row.Cells(2).Value), asDouble(row.Cells(3).Value), proveedor.id, row.Cells(0).Value, compra.nroInterno,
                                             compra.punto, compra.numero, compra.despacho, compra.letra, compra.tipoDocumento, ceros((row.Index + 1).ToString, 2)))
            End If
        Next

        compra.agregarImputaciones(imputaciones)
    End Sub

    Private Function tipoPago() As Integer
        If optEfectivo.Checked Then : Return 1 : End If
        If optCtaCte.Checked Then : Return 2 : End If
        Return 3
    End Function

    Private Sub actualizarProveedor()
        'proveedor.cai = txtCAI.Text
        'proveedor.vtoCAI = txtVtoCAI.Text
        'If IsNothing(proveedor.cuenta) Then
        '    proveedor.cuenta = DAOProveedor.cuentaDefault
        'End If
        'DAOProveedor.agregarProveedor(proveedor)

        If Trim(txtCAI.Text) = "" Or Trim(txtVtoCAI.Text.Replace("/", "")) = "" Then
            Exit Sub
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("UPDATE Proveedor SET Cai = '" & Trim(txtCAI.Text) & "', VtoCai = '" & Trim(txtVtoCAI.Text) & "' WHERE Proveedor = '" & Trim(txtCodigoProveedor.Text) & "'")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer Actualizar los datos del CAI del proveedor en la Base de Datos.")
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _Normalizarfecha(ByVal fecha As String) As String
        Dim xfecha As String = ""
        Dim _temp As String = fecha
        Dim _Fecha As String() = fecha.Split("/")

        Try
            _Fecha(0) = Val(_Fecha(0)).ToString()
            _Fecha(1) = Val(_Fecha(1)).ToString()
            _Fecha(2) = Val(_Fecha(2)).ToString()

            xfecha = String.Join("/", _Fecha)

            xfecha = Date.ParseExact(fecha, "d/M/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("dd/MM/yyyy")
        Catch ex As Exception
            xfecha = _temp
        End Try

        Return xfecha
    End Function

    Private Function _FormatoValidoFecha(ByVal fecha As String) As Boolean
        Return Trim(_Normalizarfecha(fecha)).Replace("/", "").Length = 8
    End Function

    Private Function _ValidarFecha(ByVal fecha As String, ByVal valido As Boolean) As Boolean
        Dim invalida As Boolean = False

        If Trim(fecha.Replace("/", "")) <> "" Then

            If _FormatoValidoFecha(fecha) Then
                If Not valido Then
                    invalida = True
                End If
            End If

        End If

        Return invalida
    End Function

    Private Sub chkSoloIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloIVA.CheckedChanged
        If chkSoloIVA.Checked Then
            txtNeto.Text = 0
        End If
        txtNeto.Enabled = Not chkSoloIVA.Checked
        txtImporte_Leave(sender, e)
    End Sub

    Private Sub txtLetra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim letra As String = UCase(CBLetra.SelectedItem)
        If letra = "C" Then
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
        txtImporte_Leave(sender, e)
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
        'If Not esModificacion Then
        gridAsientos.Rows.Clear()
        txtTotal.Text = calculoTotal()
        Dim total As Double = asDouble(txtTotal.Text)
        Dim sumaIvas As Double = asDouble(txtIVA10.Text) + asDouble(txtIVA21.Text) + asDouble(txtIVA27.Text)
        Dim ivaRG3337 As Double = asDouble(txtIVARG.Text)
        Dim ingresosBrutos As Double = asDouble(txtPercIB.Text)
        Dim diferencia As Double = total - sumaIvas - ingresosBrutos - ivaRG3337

        If esNotaDeCredito() Then
            If total <> 0 Then : gridAsientos.Rows.Add(cuenta.id, cuenta.descripcion, total, "") : End If
            If sumaIvas <> 0 Then : gridAsientos.Rows.Add(cuentaIVACredito.id, cuentaIVACredito.descripcion, "", sumaIvas) : End If
            If ivaRG3337 <> 0 Then : gridAsientos.Rows.Add(cuentaIVARG3337.id, cuentaIVARG3337.descripcion, "", ivaRG3337) : End If
            If ingresosBrutos <> 0 Then : gridAsientos.Rows.Add(cuentaIngresosBrutos.id, cuentaIngresosBrutos.descripcion, "", ingresosBrutos) : End If
            If diferencia <> 0 Then : gridAsientos.Rows.Add("", "", "", diferencia) : End If
        Else
            If total <> 0 Then : gridAsientos.Rows.Add(cuenta.id, cuenta.descripcion, "", total) : End If
            If sumaIvas <> 0 Then : gridAsientos.Rows.Add(cuentaIVACredito.id, cuentaIVACredito.descripcion, sumaIvas, "") : End If
            If ivaRG3337 <> 0 Then : gridAsientos.Rows.Add(cuentaIVARG3337.id, cuentaIVARG3337.descripcion, ivaRG3337, "") : End If
            If ingresosBrutos <> 0 Then : gridAsientos.Rows.Add(cuentaIngresosBrutos.id, cuentaIngresosBrutos.descripcion, ingresosBrutos, "") : End If
            If diferencia <> 0 Then : gridAsientos.Rows.Add("", "", diferencia, 0) : End If
        End If

        _DarFormatoValoresGrilla()

        calcularAsiento()
        'End If
    End Sub

    Private Sub _DarFormatoValoresGrilla()
        For Each row As DataGridViewRow In gridAsientos.Rows
            With row
                _FormatearNumero(.Cells(2).Value)
                _FormatearNumero(.Cells(3).Value)
            End With
        Next
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

        If compra.tipoDocumento > 0 Then
            cmbTipo.SelectedIndex = compra.tipoDocumento - 1
        Else
            cmbTipo.SelectedIndex = 0
        End If

        CBLetra.SelectedItem = compra.letra
        txtPunto.Text = compra.punto
        txtNumero.Text = compra.numero
        txtFechaEmision.Text = compra.fechaEmision
        txtFechaIVA.Text = compra.fechaIVA
        txtFechaVto1.Text = compra.fechaVto1
        txtFechaVto2.Text = compra.fechaVto2
        txtRemito.Text = compra.remito
        cmbFormaPago.SelectedIndex = compra.formaPago
        txtParidad.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.paridad)
        txtNeto.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.neto)
        txtIVA10.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.iva105)
        txtIVA21.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.iva21)
        txtIVA27.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.iva27)
        txtIVARG.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.ivaRG)
        txtPercIB.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.percibidoIB)
        txtNoGravado.Text = CustomConvert.toStringWithTwoDecimalPlaces(compra.exento)
        txtDespacho.Text = compra.despacho
        chkSoloIVA.Checked = compra.soloIVA
        pulsarOption(compra.tipoPago)
        traerValoresIb(compra.nroInterno)
        txtImporte_Leave(Nothing, Nothing)
        txtTipo_Leave(Nothing, Nothing)
        mostrarImputaciones(compra.imputaciones)
        calcularAsiento()
        esModificacion = True
    End Sub

    Private Sub traerValoresIb(ByVal nroInterno As String)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 RetIB1, RetIB2, RetIB3, RetIB4, RetIB5, RetIB6, RetIB7, RetIB8, RetIB9, RetIB10, RetIB11, RetIB12, RetIB13, RetIB14 FROM IvaComp WHERE NroInterno = '" & Trim(nroInterno) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                _RetIB1 = IIf(Not IsDBNull(dr.Item("RetIB1")), dr.Item("RetIB1"), "")
                _RetIB2 = IIf(Not IsDBNull(dr.Item("RetIB2")), dr.Item("RetIB2"), "")
                _RetIB3 = IIf(Not IsDBNull(dr.Item("RetIB3")), dr.Item("RetIB3"), "")
                _RetIB4 = IIf(Not IsDBNull(dr.Item("RetIB4")), dr.Item("RetIB4"), "")
                _RetIB5 = IIf(Not IsDBNull(dr.Item("RetIB5")), dr.Item("RetIB5"), "")
                _RetIB6 = IIf(Not IsDBNull(dr.Item("RetIB6")), dr.Item("RetIB6"), "")
                _RetIB7 = IIf(Not IsDBNull(dr.Item("RetIB7")), dr.Item("RetIB7"), "")
                _RetIB8 = IIf(Not IsDBNull(dr.Item("RetIB8")), dr.Item("RetIB8"), "")
                _RetIB9 = IIf(Not IsDBNull(dr.Item("RetIB9")), dr.Item("RetIB9"), "")
                _RetIB10 = IIf(Not IsDBNull(dr.Item("RetIB10")), dr.Item("RetIB10"), "")
                _RetIB11 = IIf(Not IsDBNull(dr.Item("RetIB11")), dr.Item("RetIB11"), "")
                _RetIB12 = IIf(Not IsDBNull(dr.Item("RetIB12")), dr.Item("RetIB12"), "")
                _RetIB13 = IIf(Not IsDBNull(dr.Item("RetIB13")), dr.Item("RetIB13"), "")
                _RetIB14 = IIf(Not IsDBNull(dr.Item("RetIB14")), dr.Item("RetIB14"), "")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub mostrarImputaciones(ByVal imputaciones As List(Of Imputac))
        gridAsientos.Rows.Clear()
        For Each imputacion As Imputac In imputaciones
            gridAsientos.Rows.Add(imputacion.cuenta, DAOCuentaContable.buscarCuentaContablePorCodigo(imputacion.cuenta).descripcion, imputacion.debito, imputacion.credito)
        Next
    End Sub

    Private Sub txtNroInterno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroInterno.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Trim(txtNroInterno.Text) = "" Then
                _SaltarA(txtCodigoProveedor)
            End If

            _BuscarCompraPorNumeroInterno()
        ElseIf e.KeyData = Keys.Escape Then
            txtNroInterno.Text = ""
        End If
    End Sub

    Private Sub _BuscarCompraPorNumeroInterno()
        Dim interno As String = txtNroInterno.Text
        Dim compra As Compra = DAOCompras.buscarCompraPorCodigo(interno)
        If Not IsNothing(compra) Then
            apertura = New Apertura
            mostrarCompra(compra)
        Else
            esModificacion = False
            btnLimpiar.PerformClick()
            txtNroInterno.Text = interno
            txtCodigoProveedor.Focus()
        End If
    End Sub

    Private Sub btnConsultaNroFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaNroFactura.Click
        Dim consulta As New ConsultaNumeroFactura
        consulta.ShowDialog(Me)

        If consulta.numero <> 0 Then
            txtNroInterno.Text = consulta.numero
            _BuscarCompraPorNumeroInterno()
        End If

    End Sub

    Private Sub btnApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApertura.Click
        If esModificacion And apertura.noSeAbrio Then
            apertura.cargarTablaSegun(DAOCompras.camposApertura(CustomConvert.toIntOrZero(txtNroInterno.Text)))
        End If
        apertura.ShowDialog()

        If Not apertura.IsDisposed Then 'calculoTotal() > 0
            Dim total As Double = asDouble(apertura.valorNeto) +
                asDouble(apertura.valorIVA21) +
                asDouble(apertura.valorIVA27) +
                asDouble(apertura.valorIVARG) +
                asDouble(apertura.valorIVA105) +
                asDouble(apertura.valorExento) +
                asDouble(apertura.valorIB)
            If total > 0 Then
                txtNeto.Text = apertura.valorNeto
                txtIVA21.Text = apertura.valorIVA21
                txtIVA27.Text = apertura.valorIVA27
                txtIVARG.Text = apertura.valorIVARG
                txtIVA10.Text = apertura.valorIVA105
                txtNoGravado.Text = apertura.valorExento
                txtPercIB.Text = apertura.valorIB
                txtImporte_Leave(sender, Nothing)
            End If
        End If
    End Sub

    Private Function usaCuentas()
        Return optNacion.Checked Or optCtaCte.Checked
    End Function

    Private Function esValidoNacion()
        Return (optNacion.Checked And cuotasCargadas()) Or Not optNacion.Checked
    End Function

    Private Function cuotasCargadas()
        Return _PyMENacion(0) <> 0 And _PyMENacion(1) <> 0 And _PyMENacion(2) <> 0
    End Function

    Private Sub optNacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNacion.CheckedChanged
        If Not optNacion.Checked Then
            If esModificacion Then
                _PyMENacion = DAOCompras.datosNacion(CustomConvert.toIntOrZero(txtNroInterno.Text))
            Else
                _PyMENacion = {0, 0, 0}
            End If
        End If
    End Sub

    Private Sub optNacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNacion.Click
        If optNacion.Checked Then
            _PedirDatosPymeNacion()
        End If
    End Sub

    Private Sub optEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEfectivo.CheckedChanged
        'If Not esModificacion Then
        'gridAsientos.Rows.Clear()
        'End If
    End Sub

    Private Sub optCtaCte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCtaCte.CheckedChanged
        'If Not esModificacion Then
        '    gridAsientos.Rows.Clear()
        'End If
    End Sub

    Private Sub txtCodigoProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigoProveedor.MouseDoubleClick
        If Trim(txtCodigoProveedor.Text) = "" Then
            Dim consulta As New ConsultaCompras(Me, True)
            consulta.ShowDialog()
            If Trim(txtNombreProveedor.Text) <> "" And Trim(txtCodigoProveedor.Text) <> "" Then
                If Trim(txtCAI.Text) <> "" Then
                    txtPunto.Focus()
                Else
                    txtCAI.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub _HabilitarDeshabilitarControlesSegunLetra()
        Dim _controles As New List(Of TextBox) From {txtIVA21, txtIVA10, txtIVARG, txtIVA27, txtPercIB, txtNoGravado}
        If UCase(CBLetra.SelectedItem) = "C" Then
            For Each _c In _controles
                _c.Enabled = False
            Next
            txtTotal.Enabled = True
        Else
            For Each _c In _controles
                _c.Enabled = True
            Next

            If Val(txtIVA21.Text) = 0 Or Trim(txtIVA21.Text) = "" Then
                txtIVA21.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtNeto.Text) * 0.21)
                _RecalcularTotal()
            End If

            txtTotal.Enabled = False
        End If
    End Sub

    Private Sub txtPunto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPunto.KeyDown

        If e.KeyData = Keys.Enter Then
            txtPunto.Text = ceros(txtPunto.Text, 4)
            _SaltarA(txtNumero)
        ElseIf e.KeyData = Keys.Escape Then
            txtPunto.Text = ""
        End If

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown

        If e.KeyData = Keys.Enter Then
            txtNumero.Text = ceros(txtNumero.Text, 8)

            txtCAI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNumero.Text = ""
        End If

    End Sub

    Private Sub txtCAI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCAI.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtVtoCAI)
        ElseIf e.KeyData = Keys.Escape Then
            txtCAI.Text = ""
        End If

    End Sub

    Private Sub txtVtoCAI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVtoCAI.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtCAI.Text) <> "" And Trim(txtVtoCAI.Text.Replace("/", "")) = "" Then
                txtVtoCAI.Focus()
            Else
                _SaltarA(txtFechaEmision)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtVtoCAI.Clear()
        End If

    End Sub

    Private Sub txtFechaEmision_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaEmision.KeyDown

        If e.KeyData = Keys.Enter Then
            Try
                ' Validamos que se cargue una fecha de emisión.
                If Trim(txtFechaEmision.Text.Replace("/", "")) = "" Or Trim(txtFechaEmision.Text).Length < 10 Then
                    txtFechaEmision.Focus()
                    Exit Sub
                End If

                Dim fecha As Date = Convert.ToDateTime(txtFechaEmision.Text)
                txtFechaIVA.Text = Date.Now.ToString("dd/MM/yyyy")
                txtFechaVto1.Text = fecha.AddDays(Val(diasPlazo)).ToString("dd/MM/yyyy")
                txtFechaVto2.Text = txtFechaVto1.Text

            Catch ex As Exception

            End Try

            _SaltarA(txtFechaIVA)
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEmision.Clear()
        End If

    End Sub

    Private Sub txtFechaVto1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaVto1.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtFechaVto2)
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaVto1.Clear()
        End If

    End Sub

    Private Sub txtFechaVto2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaVto2.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbFormaPago)
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaVto2.Clear()
        End If

    End Sub

    Private Sub txtFechaIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaIVA.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRemito)
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaIVA.Clear()
        End If

    End Sub

    Private Sub txtRemito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemito.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtFechaVto1)

            If Trim(txtRemito.Text) <> "" Then

                If _ComprobarPyme() Then
                    _PedirDatosPymeNacion()
                End If

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRemito.Text = ""
        End If

    End Sub

    Private Sub _PedirDatosPymeNacion()
        With PymeNacion

            .Cuotas = _PyMENacion(0)
            .Mes = _PyMENacion(1)
            .Ano = _PyMENacion(2)

            .ShowDialog(Me)

            _PyMENacion(0) = .Cuotas
            _PyMENacion(1) = .Mes
            _PyMENacion(2) = .Ano

            .Dispose()

        End With
    End Sub

    Private Function _ComprobarPyme() As Boolean

        ' Reiniciamos la variable de control.
        Dim _EsPymeNacion As Boolean = False

        ' Extraemos los remitos a consultar.
        Dim remitos() As String = Trim(txtRemito.Text).Split(",")
        Dim renglon As Integer = 0

        If remitos.Length = 0 Then
            MsgBox("No hay remitos cargados.", MsgBoxStyle.Critical)
            Return _EsPymeNacion
        End If

        ' Determinar el ConnectionString de la empresa.
        Dim csEmpresa As String = _DeterminarEmpresaDeTrabajo(remitos(0))

        ' Salimos en caso de no encontrar alguna empresa.
        If Trim(csEmpresa) = "" Then
            MsgBox("Remito Inexistente", MsgBoxStyle.Information)

            txtRemito.Focus()

            Return _EsPymeNacion
        End If

        ' Conectamos con la empresa y extraemos los datos de Pyme Nacion.
        Dim cn As New SqlConnection(csEmpresa)
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cn.Open()
            cm.CommandText = _PrepararSQLRemitosPymeNacion(remitos)

            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                With dr

                    Do While .Read()

                        Dim _Tarjeta As Integer = Val(IIf(IsDBNull(.Item("Tarjeta")), "0", .Item("Tarjeta")))

                        If _Tarjeta = 1 Then

                            _EsPymeNacion = True ' Controla que todos los remitos correspondan a Pyme Nación.

                            If Trim(_PyMENacion(0)) = 0 Then ' Guardamos unicamente la primera ya que es la mas actual.
                                _PyMENacion(0) = IIf(IsDBNull(.Item("Cuotas")), "0", .Item("Cuotas"))
                                _PyMENacion(1) = IIf(IsDBNull(.Item("MesCuota")), "0", .Item("MesCuota"))
                                _PyMENacion(2) = IIf(IsDBNull(.Item("AnoCuota")), "0", .Item("AnoCuota"))
                            End If
                        Else
                            _EsPymeNacion = False ' Controla si alguna de los remitos no corresponde a PyME Nación
                            Exit Do
                        End If

                    Loop

                End With

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing
            dr = Nothing

        End Try

        Return _EsPymeNacion
    End Function

    Private Function _PrepararSQLRemitosPymeNacion(ByVal remitos() As String) As String
        Dim sqlRemitos As String = ""
        Dim _CantRemitos As Integer = 0

        For Each remito As String In remitos
            If Trim(remito) <> "" Then
                sqlRemitos &= "'" & remito & "',"
            End If
        Next

        sqlRemitos = sqlRemitos.Substring(0, sqlRemitos.Length - 1) ' Sacamos la ultima ","
        _CantRemitos = sqlRemitos.Split(",").Count ' Limitamos la consulta a la cantidad de remitos que tengamos para consultar.

        Return "SELECT TOP " & _CantRemitos & " o.Tarjeta, o.Cuotas, o.MesCuota, o.AnoCuota " _
                          & " FROM Informe as i, Orden as o " _
                          & " WHERE i.Remito in (" & sqlRemitos & ") AND i.orden = o.orden AND i.Articulo = o.Articulo AND i.Cantidad <> 0" _
                          & " ORDER BY o.AnoCuota DESC"

    End Function

    Private Function _DeterminarEmpresaDeTrabajo(ByVal remitoPrueba As String) As String
        Dim Empresas As New List(Of String) From {"SurfactanSA", "surfactan_II", _
                                                  "Surfactan_III", "Surfactan_VI", _
                                                  "Surfactan_V", "Surfactan_VI", _
                                                  "Surfactan_VII"}
        Dim csTemplate As String = "Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"
        Dim cs As String = ""

        For Each Empresa As String In Empresas

            Dim cn As New SqlConnection(csTemplate.Replace("#EMPRESA#", Empresa))
            Dim cm As New SqlCommand("SELECT TOP 1 Informe FROM Informe WHERE Remito = '" & remitoPrueba & "' and Proveedor = '" & Trim(txtCodigoProveedor.Text) & "'")
            Dim dr As SqlDataReader

            Try

                cm.Connection = cn
                cn.Open()
                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    cs = csTemplate.Replace("#EMPRESA#", Empresa)

                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()


            End Try


            If Trim(cs) <> "" Then

                dr = Nothing
                cn = Nothing
                cm = Nothing

                Exit For
            End If

        Next

        Return cs
    End Function

    Private Sub txtParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtParidad.KeyDown

        If e.KeyData = Keys.Enter Then
            txtParidad.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtParidad.Text))
            _SaltarA(txtNeto)
        ElseIf e.KeyData = Keys.Escape Then
            txtParidad.Text = ""
        End If

    End Sub

    Private Sub txtNeto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNeto.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtIVA21.Enabled Then
                txtIVA21.Text = CustomConvert.toStringWithTwoDecimalPlaces(Math.Round(asDouble(txtNeto.Text.Replace(".", ",")) * 0.21, 2))
            End If

            txtNeto.Text = CustomConvert.toStringWithTwoDecimalPlaces(asDouble(txtNeto.Text.Replace(".", ",")))
            _RecalcularTotal()

            If txtIVA21.Enabled Then
                _SaltarA(txtIVA21)
            Else
                _SaltarA(txtTotal)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtNeto.Text = ""
        End If

    End Sub

    Private Sub _RecalcularTotal()
        txtTotal.Text = CustomConvert.toStringWithTwoDecimalPlaces(calculoTotal())
    End Sub

    Private Sub txtIVA21_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA21.KeyDown

        If e.KeyData = Keys.Enter Then
            txtIVA21.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVA21.Text))
            _RecalcularTotal()
            _SaltarA(txtIVARG)
        ElseIf e.KeyData = Keys.Escape Then
            txtIVA21.Text = ""
        End If

    End Sub

    Private Sub txtIVARG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVARG.KeyDown

        If e.KeyData = Keys.Enter Then
            txtIVARG.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVARG.Text))
            _RecalcularTotal()
            _SaltarA(txtIVA27)
        ElseIf e.KeyData = Keys.Escape Then
            txtIVARG.Text = ""
        End If

    End Sub

    Private Sub txtIVA27_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA27.KeyDown

        If e.KeyData = Keys.Enter Then
            txtIVA27.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVA27.Text))
            _RecalcularTotal()
            _SaltarA(txtIVA10)
        ElseIf e.KeyData = Keys.Escape Then
            txtIVA27.Text = ""
        End If

    End Sub

    Private Sub txtIVA10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA10.KeyDown

        If e.KeyData = Keys.Enter Then
            txtIVA10.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVA10.Text))
            _RecalcularTotal()
            _SaltarA(txtPercIB)
            _SolicitarInfoIB()
        ElseIf e.KeyData = Keys.Escape Then
            txtIVA10.Text = ""
        End If

    End Sub

    Private Sub txtNoGravado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoGravado.KeyDown

        If e.KeyData = Keys.Enter Then
            txtNoGravado.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtNoGravado.Text))
            _RecalcularTotal()
            _SaltarA(txtDespacho)
        ElseIf e.KeyData = Keys.Escape Then
            txtNoGravado.Text = ""
        End If

    End Sub

    Private Sub txtDespacho_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDespacho.KeyDown

        If e.KeyData = Keys.Enter Then

            Dim cuenta As CuentaContable
            If IsNothing(proveedor) Then
                cuenta = DAOProveedor.cuentaDefault
            Else
                If IsNothing(proveedor.cuenta) Then : proveedor.cuenta = DAOProveedor.cuentaDefault : End If
                cuenta = proveedor.cuenta
            End If

            If CBLetra.SelectedItem = "I" Then
                cuenta = DAOCuentaContable.proveedoresInternacionales
            End If

            If IsNothing(cuenta) Then
                Exit Sub
            End If

            crearAsientoContableUsando(cuenta)

            If gridAsientos.Rows.Count > 0 And Val(txtTotal.Text) <> 0 Then
                gridAsientos.CurrentCell = gridAsientos.Rows(gridAsientos.Rows.Count - 2).Cells(0) ' REM REVISAR LA RESTA, VON 2 DA INDICE NEGATIVO
                gridAsientos.Select()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtDespacho.Text = ""
        End If

    End Sub

    Private Sub _SaltarA(ByRef control As Control)
        control.Focus()
    End Sub

    Private Sub txtPercIB_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercIB.Enter

        If Trim(txtPercIB.Text) = "" Then
            txtPercIB.Text = "0,00"
        End If

    End Sub

    Private Sub _SolicitarInfoIB()

        With PercIB

            .txtRetIB1.Text = _RetIB1
            .txtRetIB2.Text = _RetIB2
            .txtRetIB3.Text = _RetIB3
            .txtRetIB4.Text = _RetIB4
            .txtRetIB5.Text = _RetIB5
            .txtRetIB6.Text = _RetIB6
            .txtRetIB7.Text = _RetIB7
            .txtRetIB8.Text = _RetIB8
            .txtRetIB9.Text = _RetIB9
            .txtRetIB10.Text = _RetIB10
            .txtRetIB11.Text = _RetIB11
            .txtRetIB12.Text = _RetIB12
            .txtRetIB13.Text = _RetIB13
            .txtRetIB14.Text = _RetIB14

            .ShowDialog(Me)

            _RetIB1 = asDouble(.txtRetIB1.Text)
            _RetIB2 = asDouble(.txtRetIB2.Text)
            _RetIB3 = asDouble(.txtRetIB3.Text)
            _RetIB4 = asDouble(.txtRetIB4.Text)
            _RetIB5 = asDouble(.txtRetIB5.Text)
            _RetIB6 = asDouble(.txtRetIB6.Text)
            _RetIB7 = asDouble(.txtRetIB7.Text)
            _RetIB8 = asDouble(.txtRetIB8.Text)
            _RetIB9 = asDouble(.txtRetIB9.Text)
            _RetIB10 = asDouble(.txtRetIB10.Text)
            _RetIB11 = asDouble(.txtRetIB11.Text)
            _RetIB12 = asDouble(.txtRetIB12.Text)
            _RetIB13 = asDouble(.txtRetIB13.Text)
            _RetIB14 = asDouble(.txtRetIB14.Text)

            .Dispose()

        End With

        _RecalcularRetIB()

        _RecalcularTotal()

        _SaltarA(txtNoGravado)

    End Sub


    Private Sub _RecalcularRetIB()
        Dim totalIB As Double = 0

        totalIB += Val(_RetIB1)
        totalIB += Val(_RetIB2)
        totalIB += Val(_RetIB3)
        totalIB += Val(_RetIB4)
        totalIB += Val(_RetIB5)
        totalIB += Val(_RetIB6)
        totalIB += Val(_RetIB7)
        totalIB += Val(_RetIB8)
        totalIB += Val(_RetIB9)
        totalIB += Val(_RetIB10)
        totalIB += Val(_RetIB11)
        totalIB += Val(_RetIB12)
        totalIB += Val(_RetIB13)
        totalIB += Val(_RetIB14)

        txtPercIB.Text = CustomConvert.toStringWithTwoDecimalPlaces(asDouble(totalIB))

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If gridAsientos.Focused Or gridAsientos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            gridAsientos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = gridAsientos.CurrentCell.ColumnIndex
            Dim iRow = gridAsientos.CurrentCell.RowIndex

            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = gridAsientos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then
                        Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(valor)
                        If Not IsNothing(cuenta) Then
                            gridAsientos.Rows(iRow).Cells(1).Value = cuenta.descripcion

                            gridAsientos.CurrentCell = gridAsientos.Rows(iRow).Cells(2) ' Nos movemos a debitos.

                        Else
                            gridAsientos.Rows(iRow).Cells(1).Value = ""
                            gridAsientos.CurrentCell = gridAsientos.Rows(iRow).Cells(iCol) ' Nos quedamos en la celda.
                        End If

                    End If


                    If iCol = 2 Or iCol = 3 Then
                        _FormatearNumero(valor)
                        gridAsientos.Rows(iRow).Cells(iCol).Value = valor
                    End If


                    If iCol = 1 Or iCol = 2 Then
                        gridAsientos.CurrentCell = gridAsientos.Rows(iRow).Cells(iCol + 1)
                    End If

                    If iCol = 3 Then
                        gridAsientos.CurrentCell = gridAsientos.Rows(gridAsientos.Rows.Add()).Cells(0)
                    End If

                Else

                    If iCol = 0 Or iCol = 1 Or iCol = 2 Then ' Avanzamos a la siguiente celda continua.

                        gridAsientos.CurrentCell = gridAsientos.Rows(iRow).Cells(iCol + 1)

                    Else

                        If iCol = 3 And gridAsientos.Rows(iRow).Cells(iCol - 1).Value <> "" Then
                            gridAsientos.CurrentCell = gridAsientos.Rows(gridAsientos.Rows.Add()).Cells(0)
                        End If

                    End If

                End If

                Return True

            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Compras_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        With gridAsientos
            _AlinearDerecha(.Columns("Cuenta"))
            _AlinearDerecha(.Columns("Debito"))
            _AlinearDerecha(.Columns("Credito"))
        End With

        CBLetra.SelectedItem = "A"
        cmbTipo.SelectedItem = "FC"
        txtCodigoProveedor.Focus()
    End Sub

    Private Sub txtTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotal.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtDespacho)
        ElseIf e.KeyData = Keys.Escape Then
            txtTotal.Text = ""
        End If

    End Sub

    Private Sub txtPercIB_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercIB.DoubleClick
        _SolicitarInfoIB()
    End Sub

    Private Sub txtPercIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPercIB.KeyDown

        If e.KeyData = Keys.Enter Then
            _SolicitarInfoIB()
        ElseIf e.KeyData = Keys.Escape Then
            txtPercIB.Text = ""
        End If

    End Sub

    Private Sub cmbFormaPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.TextChanged
        _DeterminarParidad()
    End Sub

    Private Sub cmbFormaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFormaPago.KeyDown
        If e.KeyValue = Keys.Enter Then
            _DeterminarParidad()
        ElseIf e.KeyData = Keys.Escape Then
            cmbFormaPago.SelectedIndex = 0
        End If
    End Sub

    Private Sub _DeterminarParidad()
        txtParidad.Empty = cmbFormaPago.SelectedIndex <> 2
        If txtParidad.Empty Then
            txtParidad.Enabled = False
            txtParidad.Text = ""
            _SaltarA(txtNeto)
        Else
            txtParidad.Enabled = True
            txtParidad.Text = "0.00"
            _SaltarA(txtParidad)
        End If
    End Sub

    Private Sub cmbTipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo.KeyDown

        If e.KeyData = Keys.Enter Then
            If cmbTipo.SelectedIndex <> -1 Then
                txtTipo.Text = "0" & cmbTipo.SelectedIndex + 1
            End If
            gridAsientos.Rows.Clear()
            _SaltarA(CBLetra)
        ElseIf e.KeyData = Keys.Escape Then
            cmbTipo.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.TextChanged
        If cmbTipo.SelectedIndex <> -1 Then
            txtTipo.Text = "0" & cmbTipo.SelectedIndex + 1
        End If
        gridAsientos.Rows.Clear()
        _SaltarA(CBLetra)
    End Sub

    Private Sub CBLetra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CBLetra.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPunto)
            _HabilitarDeshabilitarControlesSegunLetra()
        ElseIf e.KeyData = Keys.Escape Then
            CBLetra.SelectedIndex = 0
        End If

    End Sub

    Private Sub CBLetra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBLetra.TextChanged
        _SaltarA(txtPunto)
        _HabilitarDeshabilitarControlesSegunLetra()
    End Sub

    Private Sub _FormatearNumero(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParidad.Leave
        _FormatearNumero()
    End Sub

    Private Sub txtNeto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNeto.Leave
        _FormatearNumero(txtNeto.Text)
    End Sub

    Private Sub txtIVA21_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA21.Leave
        _FormatearNumero(txtIVA21.Text)
    End Sub

    Private Sub txtIVARG_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVARG.Leave
        _FormatearNumero(txtIVARG.Text)
    End Sub

    Private Sub txtIVA27_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA27.Leave
        _FormatearNumero(txtIVA27.Text)
    End Sub

    Private Sub txtPercIB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercIB.Leave
        _FormatearNumero(txtPercIB.Text)
    End Sub

    Private Sub txtIVA10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA10.Leave
        _FormatearNumero(txtIVA10.Text)
    End Sub

    Private Sub txtNoGravado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoGravado.Leave
        _FormatearNumero(txtNoGravado.Text)
    End Sub

    Private Sub txtTotal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.Leave
        _FormatearNumero(txtTotal.Text)
    End Sub

    Private Sub txtFechaEmision_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFechaEmision.TypeValidationCompleted
        e.Cancel = _ValidarFecha(txtFechaEmision.Text, e.IsValidInput)
    End Sub

    Private Sub txtFechaIVA_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFechaIVA.TypeValidationCompleted
        e.Cancel = _ValidarFecha(txtFechaIVA.Text, e.IsValidInput)
    End Sub

    Private Sub txtFechaVto1_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFechaVto1.TypeValidationCompleted
        e.Cancel = _ValidarFecha(txtFechaVto1.Text, e.IsValidInput)
    End Sub

    Private Sub txtFechaVto2_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFechaVto2.TypeValidationCompleted
        e.Cancel = _ValidarFecha(txtFechaVto2.Text, e.IsValidInput)
    End Sub

    Private Sub txtVtoCAI_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtVtoCAI.TypeValidationCompleted

        If txtCAI.Text <> "" Then
            e.Cancel = _ValidarFecha(txtVtoCAI.Text, e.IsValidInput)
        Else
            e.Cancel = False
        End If

    End Sub

    Private Function _DisponibleParaDarDeBaja() As Boolean
        Dim _Disponible As Boolean = False

        Dim XClave As String = Trim(txtCodigoProveedor.Text) & CBLetra.SelectedItem & ceros(cmbTipo.SelectedIndex + 1, 2) & ceros(Trim(txtPunto.Text), 4) & ceros(Trim(txtNumero.Text), 8)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Saldo, Total FROM CtaCtePrv WHERE Clave = '" & XClave & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                If Val(dr.Item("Saldo")) <> Val(dr.Item("Total")) Then
                    _Disponible = True
                End If

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _Disponible
    End Function

    Private Function _ExisteRegistrosParaBorrar() As Boolean
        Dim _Existe As Boolean = False

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT NroInterno FROM IvaComp WHERE NroInterno = '" & Trim(txtNroInterno.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                _Existe = True

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _Existe
    End Function

    Private Sub _BorrarIvaComp()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM IvaComp WHERE NroInterno = '" & Trim(txtNroInterno.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un error al querer borrar el registro.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _BorrarCtaCtePrv()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM CtaCtePrv WHERE NroInterno = '" & Trim(txtNroInterno.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un error al querer borrar el registro.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _BorrarImputaciones()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM Imputac WHERE NroInterno = '" & Trim(txtNroInterno.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un error al querer borrar el registro.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _BorrarIvaCompPyMENacion()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM IvaComp WHERE NroInternoAsociado = '" & Trim(txtNroInterno.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un error al querer borrar el registro.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _BorrarCtaCtePrvPyMENacion()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM CtaCtePrv WHERE NroInternoAsociado = '" & Trim(txtNroInterno.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

            _BorrarIvaCompPyMENacion()

        Catch ex As Exception
            Throw New Exception("Hubo un error al querer borrar el registro.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtNroInterno.Text) = "" Then
            Exit Sub
        End If

        ' Validar que se pueda borrar => Sólo si los saldos son distintos?
        If Not _DisponibleParaDarDeBaja() Then
            MsgBox("El Comprobante se encuentra total o parcialmente cancelado", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Existe para poder borrarlo?
        If Not _ExisteRegistrosParaBorrar() Then
            Exit Sub
        End If

        ' Preguntamos si esta seguro de borrar.
        If MsgBox("¿Está seguro de borrar el registro?", MsgBoxStyle.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        ' Borramos el IvaComp
        Try
            _BorrarIvaComp()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' Si el Nro de Interno no es cero, borramos la ctacteprv
        Try
            _BorrarCtaCtePrv()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' Borramos las imputaciones
        Try
            _BorrarImputaciones()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' En caso de PyME Nacion, borramos los datos de grabaciones anteriores.
        Try
            _BorrarCtaCtePrvPyMENacion()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' En caso de exito, mandamos mensaje a usuario y limpiamos pantalla.
        btnLimpiar.PerformClick()
        MsgBox("El Registro ha sido eliminado con exito.", MsgBoxStyle.Information)

    End Sub
End Class