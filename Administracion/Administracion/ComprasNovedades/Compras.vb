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
    Private ImpoIb(14, 2) As String
    Dim _PyMENacion() As Integer = {0, 0, 0} ' Cuotas, Mes, Año.

    Private _PreguntarPorRecalculo As Boolean = True

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

        cmbTipo.SelectedItem = "FC"
        CBLetra.SelectedItem = "A"

        gridAsientos.Rows.Clear()
        chkSoloIVA.Checked = False
        ckChequeRechazado.Checked = False
        optCtaCte.Checked = True
        apertura = New Apertura
        esModificacion = False
        diasPlazo = 0

        _RetIB1 = ""
        _RetIB2 = ""
        _RetIB3 = ""
        _RetIB4 = ""
        _RetIB5 = ""
        _RetIB6 = ""
        _RetIB7 = ""
        _RetIB8 = ""
        _RetIB9 = ""
        _RetIB10 = ""
        _RetIB11 = ""
        _RetIB12 = ""
        _RetIB13 = ""
        _RetIB14 = ""

        Array.Clear(_PyMENacion, 0, _PyMENacion.Length)
        Array.Clear(ImpoIb, 0, ImpoIb.Length)

        txtCodigoProveedor.Focus()
    End Sub

    Public Sub mostrarProveedor(ByVal proveedorAMostrar As Proveedor)
        If Not proveedorAMostrar.estaDefinidoCompleto Then
            Try
                proveedorAMostrar = DAOProveedor.buscarProveedorPorCodigo(proveedorAMostrar.id)
            Catch ex As Exception
                'MsgBox("")
                Exit Sub
            End Try
        End If
        If Not optNacion.Checked Then
            proveedor = proveedorAMostrar
        End If
        txtCodigoProveedor.Text = proveedorAMostrar.id
        txtNombreProveedor.Text = proveedorAMostrar.razonSocial

        CBLetra.SelectedItem = "A"
        cmbFormaPago.SelectedIndex = 0

        If Val(proveedorAMostrar.codIva) = 5 Then
            cmbTipo.SelectedItem = "FC"
            CBLetra.SelectedItem = "C"
            _HabilitarDeshabilitarControlesSegunLetra()
        End If

        _MostrarCAI(proveedor)
        diasPlazo = _ExtraerSoloNumeros(proveedorAMostrar.diasPlazo)
    End Sub

    Private Sub _MostrarCAI(ByVal proveedor As Proveedor)

        txtCAI.Text = proveedor.cai
        txtVtoCAI.Text = Proceso._Normalizarfecha(proveedor.vtoCAI)

        If CBLetra.SelectedItem = "C" Then
            _HabilitarCAI()
        End If

    End Sub

    Private Sub _HabilitarCAI()
        lblCai.Visible = True
        lblVtoCai.Visible = True
        txtCAI.Visible = True
        txtVtoCAI.Visible = True
    End Sub

    Private Sub _DeshabilitarCAI()
        lblCai.Visible = False
        lblVtoCai.Visible = False
        txtCAI.Visible = False
        txtVtoCAI.Visible = False
    End Sub

    Private Function _CAIVencido() As Boolean
        Dim vencido As Boolean = False
        Dim vto As String = String.Join("", txtVtoCAI.Text.Split("/").Reverse())
        Dim actual As String = Date.Now.ToString("yyyyMMdd")

        vto = IIf(Trim(vto) = "", "0", vto)

        If Val(vto) < actual Then
            vencido = True
        End If

        Return vencido
    End Function

    Public Sub mostrarProveedor(ByVal _proveedorAMostrar As String)
        Dim proveedorAMostrar As Proveedor = DAOProveedor.buscarProveedorPorNombre(_proveedorAMostrar)(0)

        mostrarProveedor(proveedorAMostrar)

    End Sub

    Private Function _ExtraerSoloNumeros(ByVal Plazo As String) As String
        Dim regex As New System.Text.RegularExpressions.Regex("[^0-9]+")

        Dim dias As String = regex.Replace(Plazo, "")
        Return IIf(dias = "", 0, Mid(dias, 1, 2))
    End Function

    Public Sub mostrarProveedorConsulta(ByVal proveedorAMostrar As Proveedor)

        If Not IsNothing(proveedorAMostrar) Then
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
        If esModificacion Then : Exit Sub : End If
        Dim total As Double = calculoTotal()
        txtTotal.Text = _FormatearNumero(total)
    End Sub

    Private Function _FormatearNumero(ByVal numero As String, Optional ByVal decimales As Integer = 2) As String

        If Trim(numero) = "" Then : numero = "0" : End If

        Return Proceso.formatonumerico(numero, decimales)

    End Function

    Private Sub _FormatearNumeros()

        Dim numeros As New List(Of TextBox) From {txtNeto, txtIVA10, txtIVA21, txtIVA27, txtIVARG, txtNoGravado, txtPercIB, txtTotal}

        For Each _n As TextBox In numeros
            _n.Text = _FormatearNumero(_n.Text)
        Next

        txtParidad.Text = Proceso.formatonumerico(txtParidad.Text, 4)

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

    Private Function asDouble(ByVal text As String, Optional ByVal decimales As Integer = 2)

        If IsNothing(text) Then : Return text : End If

        'Return CustomConvert.toDoubleOrZero(text.Replace(".", ","))
        Return Val(Proceso.formatonumerico(text, decimales))
    End Function

    Private Function validarCampos() As Boolean
        Dim validador As New Validator

        validador.validate(Me)
        validador.alsoValidate(CustomConvert.toIntOr(txtPunto.Text, 0) > 0, "El campo " & CustomLabel6.Text & " no puede ser cero")
        validador.alsoValidate(CustomConvert.toIntOr(txtNumero.Text, 0) > 0, "El campo " & CustomLabel7.Text & " no puede ser cero")
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
        validador.alsoValidate(cmbFormaPago.SelectedIndex > 0, "Debe indicarse el tipo de Moneda.")

        If Val(cmbFormaPago.SelectedIndex) = 2 And Val(txtParidad.Text) = 0 Then

            MsgBox("Debe cargarse la paridad", MsgBoxStyle.Information)
            txtParidad.Focus()
            Return False

        End If

        If txtFechaEmision.Text.Replace(" ", "").Length < 10 Then
            MsgBox("Debe cargarse una fecha de emisión válida", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtFechaIVA.Text.Replace(" ", "").Length < 10 Then
            MsgBox("Debe cargarse una fecha de IVA válida", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtFechaVto1.Text.Replace(" ", "").Length < 10 Then
            MsgBox("Debe cargarse una fecha de Vencimiento válida", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtFechaVto2.Text.Replace(" ", "").Length < 10 Then
            MsgBox("Debe cargarse una fecha de Vencimiento válida", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return validador.flush
    End Function

    Private Function laParidadEsValida()
        'If cmbTipo.SelectedItem = "NC" Then
        'Return CustomConvert.toDoubleOrZero(txtParidad.Text)
        'End If
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
                If IsNothing(.Cells(0).Value) And IsNothing(.Cells(1).Value) And (IsNothing(.Cells(2).Value) And IsNothing(.Cells(3).Value)) Then
                    If Not .IsNewRow Then
                        gridAsientos.Rows().Remove(row)
                    End If
                ElseIf Trim(.Cells(0).Value) = "" And Trim(.Cells(1).Value) = "" And Val(.Cells(2).Value) = 0 And Val(.Cells(3).Value) = 0 Then
                    If Not .IsNewRow Then
                        gridAsientos.Rows().Remove(row)
                        _EliminarFilasEnBlanco()
                    End If
                End If

            End With

        Next

        For Each row As DataGridViewRow In apertura.gridApertura.Rows

            With row
                apertura.gridApertura.CommitEdit(DataGridViewDataErrorContexts.Commit)
                If IsNothing(.Cells(0).Value) And IsNothing(.Cells(1).Value) And IsNothing(.Cells(2).Value) And IsNothing(.Cells(3).Value) Then
                    If Not .IsNewRow Then
                        apertura.gridApertura.Rows().Remove(row)
                    End If
                End If

            End With

        Next
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim validoComoPymenacion As Boolean = False

        _EliminarFilasEnBlanco()

        validoComoPymenacion = _ComprobarPyme()

        ' Verificamos que laforma de pago segun orden de compra y la informada sean correctas.
        If optNacion.Checked And Not validoComoPymenacion Then

            Dim res As DialogResult = MsgBox("La Orden de Comrpa indica que se paga con Pyme Banco Nacion" & vbCrLf & _
             "y difiere de la forma de pago informado en la carga del comprobante" & vbCrLf & _
             "Desea continuar con la grabacion", MsgBoxStyle.YesNo)

            If res = DialogResult.No Then
                Exit Sub
            End If

        End If

        If validoComoPymenacion Then
            If Val(_PyMENacion(0)) = 0 Then
                MsgBox("No se informo la cantidad de cuotas para la financiacion de la compra", MsgBoxStyle.Information)
                Exit Sub
            ElseIf Val(_PyMENacion(1)) = 0 Or Val(_PyMENacion(2)) = 0 Then
                MsgBox("No se informó la fecha de inicio para la financiación de la compra", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

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

            Try
                DAOCompras.agregarCompra(compra)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            Try
                _ActualizarChequeRechazado(compra.nroInterno)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            If usaCuentas() Then
                If cuotasCargadas() Then
                    compra.agregarPagoPyme(_PyMENacion)
                End If

                Try
                    DAOCompras.agregarDatosCuentaCorriente(compra)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Exit Sub
                End Try

            End If
            If Not IsNothing(apertura) Then

                Try
                    DAOCompras.agregarTablaIvaComprasAdicional(compra, apertura.gridApertura.Rows)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Exit Sub
                End Try

            End If
            MsgBox("El número de Factura asignado es: " & compra.nroInterno, MsgBoxStyle.Information)
            btnLimpiar.PerformClick()
        End If
    End Sub

    Private Sub _ActualizarChequeRechazado(ByVal NroInterno As Integer)
        Dim WRechazado = 0

        If ckChequeRechazado.Checked Then
            WRechazado = 1
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("UPDATE IvaComp SET Rechazado = " & WRechazado & " WHERE NroInterno = '" & NroInterno & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function crearCompra() As Compra
        Dim multiplicadorPorNotaDeCredito As Integer = 1
        If esNotaDeCredito() Then
            multiplicadorPorNotaDeCredito = -1
        End If
        Dim interno As Integer = CustomConvert.toIntOrZero(txtNroInterno.Text)
        If interno = 0 Then : interno = DAOCompras.siguienteNumeroDeInterno() : End If
        Dim compra As New Compra(interno, proveedor, ceros(cmbTipo.SelectedIndex, 2), cmbTipo.Text, cmbFormaPago.SelectedIndex,
                                 tipoPago(), CBLetra.SelectedItem, txtPunto.Text, txtNumero.Text, txtFechaEmision.Text, txtFechaIVA.Text, txtFechaVto1.Text, txtFechaVto2.Text,
                                 asDouble(txtParidad.Text, 4), asDouble(txtNeto.Text) * multiplicadorPorNotaDeCredito, asDouble(txtIVA21.Text) * multiplicadorPorNotaDeCredito,
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

        If Not txtCAI.Visible Then
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
        Return Proceso._Normalizarfecha(fecha)
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
        Return cmbTipo.SelectedItem = "NC" 'txtTipo.Text = "03"
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

    Private Function _UtilizaApertura() As Boolean
        Return apertura.gridApertura.Rows.Count > 0 And Not IsNothing(apertura.gridApertura.Rows(0).Cells(0).Value) And CBLetra.Text <> "C"
    End Function

    Private Sub crearAsientoContableUsando(ByVal cuenta As CuentaContable)
        Dim _Cta As CuentaContable
        If Not esModificacion Then

            Dim total, sumaIvas, ivaRG3337, ingresosBrutos, diferencia As Double

            total = 0
            sumaIvas = 0
            ivaRG3337 = 0
            ingresosBrutos = 0
            diferencia = 0

            gridAsientos.Rows.Clear()

            If _UtilizaApertura Then

                With apertura
                    total = asDouble(txtTotal.Text)
                    sumaIvas = .valorIVA105 + .valorIVA21 + .valorIVA27
                    ivaRG3337 = .valorIVARG
                    ingresosBrutos = .valorIB
                    diferencia = .valorNeto
                End With

            Else
                txtTotal.Text = calculoTotal()
                total = asDouble(txtTotal.Text)
                sumaIvas = asDouble(txtIVA10.Text) + asDouble(txtIVA21.Text) + asDouble(txtIVA27.Text)
                ivaRG3337 = asDouble(txtIVARG.Text)
                ingresosBrutos = asDouble(txtPercIB.Text)
                diferencia = total - sumaIvas - ingresosBrutos - ivaRG3337

            End If

            If esNotaDeCredito() Then
                If total <> 0 Then : gridAsientos.Rows.Add(cuenta.id, cuenta.descripcion, total, "") : End If
                If sumaIvas <> 0 Then : gridAsientos.Rows.Add(cuentaIVACredito.id, cuentaIVACredito.descripcion, "", sumaIvas) : End If
                If ivaRG3337 <> 0 Then : gridAsientos.Rows.Add(cuentaIVARG3337.id, cuentaIVARG3337.descripcion, "", ivaRG3337) : End If


                If _UtilizaApertura() Then
                    _Cta = DAOCuentaContable.buscarCuentaContablePorCodigo("164")

                    If Val(ingresosBrutos) <> 0 Then
                        gridAsientos.Rows.Add("164", _Cta.descripcion, "", formatonumerico(ingresosBrutos))
                    End If

                Else
                    For i = 0 To 14

                        If Val(ImpoIb(i, 1)) <> 0 Then
                            _Cta = DAOCuentaContable.buscarCuentaContablePorCodigo(Trim(ImpoIb(i, 2)))

                            gridAsientos.Rows.Add(ImpoIb(i, 2), _Cta.descripcion, "", formatonumerico(ImpoIb(i, 1)))

                        End If

                    Next
                End If


                If diferencia <> 0 Then : gridAsientos.Rows.Add("", "", "", diferencia) : End If
            Else
                If total <> 0 Then : gridAsientos.Rows.Add(cuenta.id, cuenta.descripcion, "", total) : End If
                If sumaIvas <> 0 Then : gridAsientos.Rows.Add(cuentaIVACredito.id, cuentaIVACredito.descripcion, sumaIvas, "") : End If
                If ivaRG3337 <> 0 Then : gridAsientos.Rows.Add(cuentaIVARG3337.id, cuentaIVARG3337.descripcion, ivaRG3337, "") : End If


                If _UtilizaApertura() Then
                    _Cta = DAOCuentaContable.buscarCuentaContablePorCodigo("164")

                    If Val(ingresosBrutos) <> 0 Then
                        gridAsientos.Rows.Add("164", _Cta.descripcion, formatonumerico(ingresosBrutos), "")
                    End If

                Else
                    For i = 0 To 14

                        If Val(ImpoIb(i, 1)) <> 0 Then

                            _Cta = DAOCuentaContable.buscarCuentaContablePorCodigo(Trim(ImpoIb(i, 2)))

                            gridAsientos.Rows.Add(ImpoIb(i, 2), _Cta.descripcion, formatonumerico(ImpoIb(i, 1)), "")

                        End If

                    Next
                End If

                If diferencia <> 0 Then : gridAsientos.Rows.Add("", "", diferencia, 0) : End If
            End If

            _DarFormatoValoresGrilla()

            calcularAsiento()

        End If
    End Sub

    Private Sub _DarFormatoValoresGrilla()
        For Each row As DataGridViewRow In gridAsientos.Rows
            With row
                .Cells(2).Value = _FormatearNumero(.Cells(2).Value)
                .Cells(3).Value = _FormatearNumero(.Cells(3).Value)
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
        lblDebito.Text = _FormatearNumero(valorDebe)
        lblCredito.Text = _FormatearNumero(valorHaber)
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
        esModificacion = True
        txtTipo.Text = compra.tipoDocumento

        If compra.tipoDocumento >= 0 Then
            cmbTipo.SelectedIndex = compra.tipoDocumento
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
        txtParidad.Text = _FormatearNumero(compra.paridad, 4)
        txtNeto.Text = _FormatearNumero(compra.neto)
        txtIVA10.Text = _FormatearNumero(compra.iva105)
        txtIVA21.Text = _FormatearNumero(compra.iva21)
        txtIVA27.Text = _FormatearNumero(compra.iva27)
        txtIVARG.Text = _FormatearNumero(compra.ivaRG)
        txtPercIB.Text = _FormatearNumero(compra.percibidoIB)
        txtNoGravado.Text = _FormatearNumero(compra.exento)
        txtDespacho.Text = compra.despacho
        chkSoloIVA.Checked = compra.soloIVA
        pulsarOption(compra.tipoPago)
        traerValoresIb(compra.nroInterno)
        txtImporte_Leave(Nothing, Nothing)
        mostrarImputaciones(compra.imputaciones)
        calcularAsiento()
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
            _RecalcularTotal()
        Else
            esModificacion = False
            btnLimpiar.PerformClick()
            txtNroInterno.Text = interno
            txtCodigoProveedor.Focus()
        End If
    End Sub

    Private Sub btnConsultaNroFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaNroFactura.Click
        ' Deshabilitado ?
        'Dim consulta As New ConsultaNumeroFactura
        'consulta.ShowDialog(Me)

        'If consulta.numero <> 0 Then
        '    txtNroInterno.Text = consulta.numero
        '    _BuscarCompraPorNumeroInterno()
        'End If

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
            'If total > 0 Then
            '    txtNeto.Text = apertura.valorNeto
            '    txtIVA21.Text = apertura.valorIVA21
            '    txtIVA27.Text = apertura.valorIVA27
            '    txtIVARG.Text = apertura.valorIVARG
            '    txtIVA10.Text = apertura.valorIVA105
            '    txtNoGravado.Text = apertura.valorExento
            '    txtPercIB.Text = apertura.valorIB
            '    txtImporte_Leave(sender, Nothing)
            'End If
        End If

        txtDespacho_KeyDown(Nothing, New System.Windows.Forms.KeyEventArgs(Keys.Enter))
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
        If optNacion.Checked Then
            If esModificacion Then

                If Trim(txtNroInterno.Text) <> "" Then
                    Dim num As Integer = Val(txtNroInterno.Text)

                    _PyMENacion = DAOCompras.datosNacion(num)
                Else
                    _PyMENacion = {0, 0, 0}
                End If

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
    
    Private Sub txtCodigoProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigoProveedor.MouseDoubleClick

        Dim consulta As New ConsultaCompras(Me, True)
        consulta.ShowDialog()
        If Trim(txtNombreProveedor.Text) <> "" And Trim(txtCodigoProveedor.Text) <> "" Then
            If Trim(txtCAI.Text) <> "" Then
                txtPunto.Focus()
            Else
                txtCAI.Focus()
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


            If Trim(txtCAI.Text) <> "" And Trim(txtVtoCAI.Text.Replace("/", "")) <> "" Then
                _HabilitarCAI()
            End If

        Else
            For Each _c In _controles
                _c.Enabled = True
            Next

            If Val(txtIVA21.Text) = 0 Or Trim(txtIVA21.Text) = "" Then
                txtIVA21.Text = _FormatearNumero(Val(txtNeto.Text) * 0.21)
                _RecalcularTotal()
            End If

            txtTotal.Enabled = False

            _DeshabilitarCAI()
        End If
    End Sub

    Private Sub txtPunto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPunto.KeyDown

        If e.KeyData = Keys.Enter Then

            ' Comprobamos que se haya colocado un punto correcto. Es decir, mayor a Cero.
            If Val(txtPunto.Text) > 0 Then
                txtPunto.Text = ceros(txtPunto.Text, 4)
                _SaltarA(txtNumero)
            Else
                txtPunto.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtPunto.Text = ""
        End If

    End Sub

    Private Function _ExisteFacturaPorNumero() As String
        Dim existe As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT NroInterno FROM CtaCtePrv WHERE Numero = '" & Trim(txtNumero.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                existe = dr.Item("NroInterno").ToString()
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return existe
    End Function

    Private Sub txtNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown

        If e.KeyData = Keys.Enter Then

            txtNumero.Text = ceros(txtNumero.Text, 8)

            ' Comprobamos que se haya colocado un numero correcto. Es decir, mayor a Cero.
            If Val(txtNumero.Text) = 0 Then
                txtNumero.Focus()
                Exit Sub
            End If

            Dim _NumeroInterno As String = ""

            If Trim(txtCodigoProveedor.Text) <> "" And cmbTipo.SelectedIndex >= 0 And CBLetra.SelectedIndex >= 0 And Trim(txtPunto.Text) <> "" And Trim(txtNumero.Text) <> "" Then
                _NumeroInterno = Trim(DAOCompras.buscarNumeroIntero(txtCodigoProveedor.Text, ceros(cmbTipo.SelectedIndex, 2), CBLetra.SelectedItem, ceros(txtPunto.Text, 4), ceros(txtNumero.Text, 8)))

                If Trim(_NumeroInterno) <> 0 Then

                    If MsgBox("Ya existe una factura con el Numero indicado. ¿Desea traer la misma?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

                        txtNroInterno.Text = _NumeroInterno

                        _BuscarCompraPorNumeroInterno()

                    End If

                    Exit Sub
                End If
            End If

            If txtCAI.Visible And _CAIVencido() Then
                txtCAI.Focus()
            Else
                txtFechaEmision.Focus()
            End If


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
                If esModificacion Then : Exit Try : End If

                ' Validamos que se cargue una fecha de emisión.
                If Trim(txtFechaEmision.Text.Replace("/", "")) = "" Or Trim(txtFechaEmision.Text).Length < 10 Then
                    txtFechaEmision.Focus()
                    Exit Sub
                Else
                    If Not Proceso._ValidarFecha(txtFechaEmision.Text) Then
                        txtFechaEmision.Focus()
                        Exit Sub
                    End If
                End If

                txtFechaIVA.Text = Date.Now.ToString("dd/MM/yyyy")
                Dim fecha As Date = Convert.ToDateTime(txtFechaIVA.Text)
                Dim fecha2 As Date = Convert.ToDateTime(txtFechaEmision.Text)
                txtFechaVto1.Text = fecha2.AddDays(Val(diasPlazo)).ToString("dd/MM/yyyy")
                txtFechaVto2.Text = fecha.AddDays(Val(diasPlazo)).ToString("dd/MM/yyyy")

            Catch ex As Exception

            End Try

            _SaltarA(txtRemito)
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEmision.Clear()
        End If

    End Sub

    Private Sub txtFechaVto1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaVto1.KeyDown

        If e.KeyData = Keys.Enter Then

            If Proceso._ValidarFecha(txtFechaVto1.Text) Then
                _SaltarA(txtFechaVto2)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaVto1.Clear()
        End If

    End Sub

    Private Sub txtFechaVto2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaVto2.KeyDown

        If e.KeyData = Keys.Enter Then

            If Proceso._ValidarFecha(txtFechaVto2.Text) Then
                _SaltarA(cmbFormaPago)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaVto2.Clear()
        End If

    End Sub

    Private Sub txtFechaIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaIVA.KeyDown

        If e.KeyData = Keys.Enter Then

            If Proceso._ValidarFecha(txtFechaIVA.Text) Then
                _SaltarA(txtRemito)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaIVA.Clear()
        End If

    End Sub

    Private Function _ComprobarExistenciaRemito(ByVal _remitos As String) As Boolean
        Dim _existe As Boolean = False
        Dim remito As String = _remitos.Split(",")(0)
        Dim csEmpresa As String = _DeterminarEmpresaDeTrabajo(remito)

        ' Lo determinamos como valido si se encuentra en alguna de las empresas.
        If Trim(csEmpresa) <> "" Then
            _existe = True

            ' Consultamos la orden de compra relacionada y si los dias son distintos, preguntamos si se recalcula o no.


            If _PreguntarPorRecalculo Then

                Dim dias As String = ""

                dias = _BuscarDiasOCRelacionada(remito)

                If dias <> "" Then
                    If Val(dias) <> diasPlazo Then

                        If MsgBox("¿Se detectó que el plazo indicado en la Orden de Compra (" & dias & ") difiere con el indicado en la informacioón del Proveedor (" & diasPlazo & ")" & vbCrLf & vbCrLf & "¿Desea recalcular la fecha de Vencimiento a partir de la información de la Orden de Compra?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                            _RecalcularFechaDeVencimiento(dias)
                        End If

                    End If
                End If

            End If



        End If

        Return _existe
    End Function

    Private Sub _RecalcularFechaDeVencimiento(ByVal dias As String)
        Dim fecha As Date = Convert.ToDateTime(txtFechaIVA.Text)
        'Dim fecha2 As Date = Convert.ToDateTime(txtFechaEmision.Text)
        'txtFechaVto1.Text = fecha2.AddDays(Val(diasPlazo)).ToString("dd/MM/yyyy")
        txtFechaVto2.Text = fecha.AddDays(Val(dias)).ToString("dd/MM/yyyy")
    End Sub

    Private Function _BuscarDiasOCRelacionada(ByVal remito As String) As String
        Dim dias As String = ""
        Dim cn As New SqlConnection()
        ' ACA  FALTA AGREGAR LA COLUMNA DE DONDE SE EXTRAERÁ EL DATO DE LOS DIAS.
        Dim cm As New SqlCommand("SELECT i.Orden FROM Informe as i, Orden as o WHERE i.Remito = '" & Trim(remito) & "' AND i.Orden = o.Orden ")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                ' ACA UNA VEZ DEFINIDO EL CAMPO DEL CUAL SACAR SE ASIGNA Y SE RETORNA.
                'dias = dr.item("Campo")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return dias

    End Function

    Private Sub txtRemito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemito.KeyDown
        Dim _ValidoComoPymeNacion As Boolean = False

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbFormaPago)

            If Trim(txtRemito.Text) <> "" Then

                If _ComprobarExistenciaRemito(Trim(txtRemito.Text)) Then

                    _ValidoComoPymeNacion = _ComprobarPyme()
                    If _ValidoComoPymeNacion Then
                        _PedirDatosPymeNacion()
                        optNacion.Checked = True
                    Else

                        If optNacion.Checked And Not _ValidoComoPymeNacion Then
                            MsgBox("Hay remitos cargados que no corresponden a Pyme Nación.")
                            txtRemito.Focus()

                        End If

                    End If

                Else
                    MsgBox("Remito Inexistente.", MsgBoxStyle.Information)
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

        If Trim(txtRemito.Text) = "" Then : Return _EsPymeNacion : End If

        ' Extraemos los remitos a consultar.
        Dim remitos() As String = Trim(txtRemito.Text).Split(",")
        Dim renglon As Integer = 0

        If remitos.Length = 0 Then
            MsgBox("No hay remitos cargados.", MsgBoxStyle.Information)
            Return _EsPymeNacion
        End If

        ' Determinar el ConnectionString de la empresa.
        Dim csEmpresa As String = _DeterminarEmpresaDeTrabajo(remitos(0))

        ' Salimos en caso de no encontrar alguna empresa.
        If Trim(csEmpresa) = "" Then
            If optNacion.Checked Then

                MsgBox("Remito Inexistente", MsgBoxStyle.Information)
                txtRemito.Focus()

            End If
            
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
            'txtParidad.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtParidad.Text))
            _SaltarA(txtNeto)
        ElseIf e.KeyData = Keys.Escape Then
            txtParidad.Text = ""
        End If

    End Sub

    Private Sub txtNeto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNeto.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtIVA21.Enabled Then
                txtIVA21.Text = Proceso.formatonumerico(asDouble(txtNeto.Text) * 0.21)
            End If

            txtNeto.Text = _FormatearNumero(asDouble(txtNeto.Text.Replace(".", ",")))
            _RecalcularTotal()

            If txtIVA21.Enabled Then
                _SaltarA(txtIVA21)
            Else
                _SaltarA(txtDespacho)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtNeto.Text = ""
        End If

    End Sub

    Private Sub _RecalcularTotal()
        txtTotal.Text = _FormatearNumero(calculoTotal())
    End Sub

    Private Sub txtIVA21_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA21.KeyDown

        If e.KeyData = Keys.Enter Then
            'txtIVA21.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVA21.Text))
            _RecalcularTotal()
            _SaltarA(txtIVARG)
        ElseIf e.KeyData = Keys.Escape Then
            txtIVA21.Text = ""
        End If

    End Sub

    Private Sub txtIVARG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVARG.KeyDown

        If e.KeyData = Keys.Enter Then
            'txtIVARG.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVARG.Text))
            _RecalcularTotal()
            _SaltarA(txtIVA27)
        ElseIf e.KeyData = Keys.Escape Then
            txtIVARG.Text = ""
        End If

    End Sub

    Private Sub txtIVA27_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA27.KeyDown

        If e.KeyData = Keys.Enter Then
            'txtIVA27.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVA27.Text))
            _RecalcularTotal()
            _SaltarA(txtIVA10)
        ElseIf e.KeyData = Keys.Escape Then
            txtIVA27.Text = ""
        End If

    End Sub

    Private Sub txtIVA10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA10.KeyDown

        If e.KeyData = Keys.Enter Then
            'txtIVA10.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtIVA10.Text))
            _RecalcularTotal()
            _SaltarA(txtPercIB)
            _SolicitarInfoIB()
        ElseIf e.KeyData = Keys.Escape Then
            txtIVA10.Text = ""
        End If

    End Sub

    Private Sub txtNoGravado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoGravado.KeyDown

        If e.KeyData = Keys.Enter Then
            'txtNoGravado.Text = CustomConvert.toStringWithTwoDecimalPlaces(Val(txtNoGravado.Text))
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
                MsgBox("No se encontró una cuenta asociada para poder calcular el Asiento correspondiente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            crearAsientoContableUsando(cuenta)

            If gridAsientos.Rows.Count > 0 And Val(txtTotal.Text) <> 0 Then
                Dim celda As Integer = gridAsientos.Rows.Count - 2
                gridAsientos.CurrentCell = gridAsientos.Rows(celda).Cells(0) ' REM REVISAR LA RESTA, VON 2 DA INDICE NEGATIVO
                '_TraerSugerenciaDeCuenta(gridAsientos.CurrentCell)
                gridAsientos.Select()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtDespacho.Text = ""
        End If

    End Sub

    Private Sub _TraerSugerenciaDeCuenta(ByVal celda As DataGridViewCell)
        Dim sugerencia As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 i.Cuenta, c.Descripcion FROM Imputac as i, Cuenta as c WHERE i.Proveedor = '" & Trim(txtCodigoProveedor.Text) & "' AND i.Cuenta = c.Cuenta " _
                                              & "ORDER BY i.Renglon DESC, i.NroInterno DESC")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With gridAsientos.Rows(celda.RowIndex)
                    .Cells(0).Value = dr.Item("Cuenta")
                    .Cells(1).Value = dr.Item("Descripcion")
                End With

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

            Array.Clear(ImpoIb, 0, ImpoIb.Length)

            ' Guardamos datos para detalles de asientos.
            ImpoIb(1, 1) = _RetIB1
            ImpoIb(1, 2) = "163"
            ImpoIb(2, 1) = _RetIB2
            ImpoIb(2, 2) = "164"
            ImpoIb(3, 1) = _RetIB3
            ImpoIb(3, 2) = "177"
            ImpoIb(4, 1) = _RetIB4
            ImpoIb(4, 2) = "173"
            ImpoIb(5, 1) = _RetIB5
            ImpoIb(5, 2) = "176"
            ImpoIb(6, 1) = _RetIB6
            ImpoIb(6, 2) = "170"
            ImpoIb(7, 1) = _RetIB7
            ImpoIb(7, 2) = "171"
            ImpoIb(8, 1) = _RetIB8
            ImpoIb(8, 2) = "167"
            ImpoIb(9, 1) = _RetIB9
            ImpoIb(9, 2) = "172"
            ImpoIb(10, 1) = _RetIB10
            ImpoIb(10, 2) = "165"
            ImpoIb(11, 1) = _RetIB11
            ImpoIb(11, 2) = "166"
            ImpoIb(12, 1) = _RetIB12
            ImpoIb(12, 2) = "179"
            ImpoIb(13, 1) = _RetIB13
            ImpoIb(13, 2) = "169"
            ImpoIb(14, 1) = _RetIB14
            ImpoIb(14, 2) = "168"

            .Dispose()

        End With

        _RecalcularRetIB()

        _RecalcularTotal()

        _SaltarA(txtNoGravado)

    End Sub


    Private Sub _RecalcularRetIB()
        Dim totalIB As Double = 0

        totalIB += Val(_FormatearNumero(_RetIB1))
        totalIB += Val(_FormatearNumero(_RetIB2))
        totalIB += Val(_FormatearNumero(_RetIB3))
        totalIB += Val(_FormatearNumero(_RetIB4))
        totalIB += Val(_FormatearNumero(_RetIB5))
        totalIB += Val(_FormatearNumero(_RetIB6))
        totalIB += Val(_FormatearNumero(_RetIB7))
        totalIB += Val(_FormatearNumero(_RetIB8))
        totalIB += Val(_FormatearNumero(_RetIB9))
        totalIB += Val(_FormatearNumero(_RetIB10))
        totalIB += Val(_FormatearNumero(_RetIB11))
        totalIB += Val(_FormatearNumero(_RetIB12))
        totalIB += Val(_FormatearNumero(_RetIB13))
        totalIB += Val(_FormatearNumero(_RetIB14))

        txtPercIB.Text = _FormatearNumero(totalIB)

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
                        valor = _FormatearNumero(valor)
                        gridAsientos.Rows(iRow).Cells(iCol).Value = valor
                    End If


                    If iCol = 1 Or iCol = 2 Then
                        gridAsientos.CurrentCell = gridAsientos.Rows(iRow).Cells(iCol + 1)
                    End If

                    If iCol = 3 Then
                        Try
                            gridAsientos.CurrentCell = gridAsientos.Rows(iRow + 1).Cells(0)
                        Catch ex As Exception
                            gridAsientos.CurrentCell = gridAsientos.Rows(gridAsientos.Rows.Add).Cells(0) ' Agregamos una fila y nos posicionamos en la primer celda.
                        End Try
                    End If

                Else

                    If iCol = 0 Or iCol = 1 Or iCol = 2 Then ' Avanzamos a la siguiente celda continua.

                        gridAsientos.CurrentCell = gridAsientos.Rows(iRow).Cells(iCol + 1)

                    Else

                        If iCol = 3 And gridAsientos.Rows(iRow).Cells(iCol - 1).Value <> "" Then
                            Try
                                gridAsientos.CurrentCell = gridAsientos.Rows(iRow + 1).Cells(0)
                            Catch ex As Exception
                                gridAsientos.CurrentCell = gridAsientos.Rows(gridAsientos.Rows.Add).Cells(0) ' Agregamos una fila y nos posicionamos en la primer celda.
                            End Try
                        End If

                    End If

                End If

                Return True

            ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                gridAsientos.Rows(iRow).Cells(iCol).Value = ""
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
            CBLetra.SelectedItem = "A"
        End If

    End Sub

    Private Sub CBLetra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBLetra.TextChanged
        _SaltarA(txtPunto)
        _HabilitarDeshabilitarControlesSegunLetra()
    End Sub

    Private Sub _FormatearNumero(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParidad.Leave
        _FormatearNumeros()
    End Sub



    Private Sub txtNeto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNeto.Leave
        txtNeto.Text = _FormatearNumero(txtNeto.Text)
    End Sub

    Private Sub txtIVA21_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA21.Leave
        txtIVA21.Text = _FormatearNumero(txtIVA21.Text)
    End Sub

    Private Sub txtIVARG_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVARG.Leave
        txtIVARG.Text = _FormatearNumero(txtIVARG.Text)
    End Sub

    Private Sub txtIVA27_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA27.Leave
        txtIVA27.Text = _FormatearNumero(txtIVA27.Text)
    End Sub

    Private Sub txtPercIB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercIB.Leave
        txtPercIB.Text = _FormatearNumero(txtPercIB.Text)
    End Sub

    Private Sub txtIVA10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIVA10.Leave
        txtIVA10.Text = _FormatearNumero(txtIVA10.Text)
    End Sub

    Private Sub txtNoGravado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoGravado.Leave
        txtNoGravado.Text = _FormatearNumero(txtNoGravado.Text)
    End Sub

    Private Sub txtTotal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.Leave
        txtTotal.Text = _FormatearNumero(txtTotal.Text)
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
        Dim _Disponible As Boolean = True

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
                    _Disponible = false
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

    Private Sub _BorrarIvaCompAdicional()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM IvaCompAdicional WHERE NroInterno = '" & Trim(txtNroInterno.Text) & "'")
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

        ' Borramos los registros de Iva Comp Adicionales.
        Try
            _BorrarIvaCompAdicional()
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

    Private Sub txtRemito_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRemito.MouseDoubleClick
        Dim WConsulta As String = Trim(txtCodigoProveedor.Text) & "$" & Trim(txtNombreProveedor.Text) & "$" & Trim(txtRemito.Text)

        ' Verificamos que hayan remitos que consultar.
        If Trim(txtRemito.Text) = "" Then
            txtRemito.Focus()
            Exit Sub
        End If

        ' Abrimos la ventana con los detalles de los remitos indicados.
        With New DetallesRemitosProveedor(WConsulta)

            .ShowDialog()

        End With

    End Sub

    Private Sub CustomButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomButton1.Click
        txtRemito_MouseDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtNumericWithComma_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNeto.KeyPress, txtIVA10.KeyPress, txtIVA21.KeyPress, txtIVA27.KeyPress, txtIVARG.KeyPress, txtNoGravado.KeyPress, txtParidad.KeyPress, txtPercIB.KeyPress, txtTotal.KeyPress
        If _EsNumero(e) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Or e.KeyChar = CChar(","c) Or e.KeyChar = CChar("."c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeric_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroInterno.KeyPress, txtCodigoProveedor.KeyPress, txtPunto.KeyPress, txtNumero.KeyPress
        If _EsNumero(e) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Right) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Function _EsNumero(ByVal e As KeyPressEventArgs) As Boolean
        Return (e.KeyChar >= CChar("0"c) And e.KeyChar <= CChar("9"c))
    End Function

    Private Sub cmbFormaPago_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.Enter
        cmbFormaPago.DroppedDown = True
    End Sub

    Private Sub gridAsientos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridAsientos.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = gridAsientos.Rows(e.RowIndex)

        If row.IsNewRow Then : Exit Sub : End If

        If MsgBox("¿Seguro que quiere eliminar la fila seleccionada?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then : Exit Sub : End If

        gridAsientos.Rows.Remove(row)

    End Sub
End Class