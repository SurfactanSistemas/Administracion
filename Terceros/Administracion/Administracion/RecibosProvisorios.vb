Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class RecibosProvisorios
    Private WRow, Wcol As Integer
    Private Const YMARGEN = 183
    Private Const XMARGEN = 65
    Private _ComprobanteRetIva As String = ""
    Private _ComprobanteRetGanancias As String = ""
    Private _ComprobanteRetSuss As String = ""
    Private _RetIB1, _CompIB1, _RetIB2, _CompIB2, _RetIB3, _CompIB3, _RetIB4, _CompIB4, _RetIB5, _CompIB5, _
            _RetIB6, _CompIB6, _RetIB7, _CompIB7, _RetIB8, _CompIB8 As String
    Private _CuentasContables As New List(Of Object)
    Private _ClavesCheques As New List(Of Object)

    Dim queryController As QueryController
    Dim commonEventsHandler As New CommonEventsHandler

    Private Sub RecibosProvisorios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WRow = -1
        Wcol = -1

        Label2.Text = Proceso.NombreEmpresa()

        commonEventsHandler.setIndexTab(Me)
        lstSeleccion.Items.Add(New QueryController("Clientes", AddressOf DAOCliente.buscarClientePorNombre, AddressOf mostrarCliente))
        lstSeleccion.SelectedIndex = 0

        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        txtConsulta.Text = ""
        queryController = lstSeleccion.SelectedItem
        lstConsulta.Visible = True
        txtConsulta.Visible = True
        lstConsulta.DataSource = queryController.query.Invoke("")
        txtConsulta.Focus()
    End Sub


    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstConsulta
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtConsulta.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True
            origen.Visible = False

        Else

            origen.Visible = True
            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstConsulta
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtConsulta

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstConsulta_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        'texto.Text = ""
    End Sub

    Private Sub txtConsulta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsulta.TextChanged
        _FiltrarDinamicamente()
    End Sub

    'Private Sub txtConsulta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsulta.KeyDown
    '    'If e.KeyValue = Keys.Enter Then
    '    '    lstConsulta.DataSource = queryController.query.Invoke(txtConsulta.Text)
    '    '    e.Handled = True
    '    'End If
    'End Sub

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click
        queryController.showMethod.Invoke(lstConsulta.SelectedValue)
        lstConsulta.Visible = False
        txtConsulta.Visible = False
        'txtConsulta.Text = ""
        txtRetGanancias.Focus()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Cleanner.clean(Me)
        setDefaults()
    End Sub

    Private Sub setDefaults()
        txtFechaAux.Visible = False

        For Each control As Control In Panel2.Controls

            If TypeOf (control) Is TextBox Then
                control.Text = ""
            End If

        Next

        _ComprobanteRetIva = ""
        _ComprobanteRetGanancias = ""
        _ComprobanteRetSuss = ""

        _RetIB1 = ""
        _CompIB1 = ""
        _RetIB2 = ""
        _CompIB2 = ""
        _RetIB3 = ""
        _CompIB3 = ""
        _RetIB4 = ""
        _CompIB4 = ""
        _RetIB5 = ""
        _CompIB5 = ""
        _RetIB6 = ""
        _CompIB6 = ""
        _RetIB7 = ""
        _CompIB7 = ""
        _RetIB8 = ""
        _CompIB8 = ""

        lblTotal.Text = "0.00"
        lblDiferencia.Text = "0.00"

        gridRecibos.Rows.Clear()
        gridRecibos.Rows.Add()

        _ClavesCheques.Clear()
        _CuentasContables.Clear()
        txtConsulta.Visible = False
        lstConsulta.Visible = False
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtRecibo.Focus()
    End Sub

    Private Sub eventoSegunTipoEnFormaDePagoPara(ByVal val As Integer, ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Dim column As Integer = columnIndex
        Select Case val
            Case 1, 4
                column = 4
                With gridRecibos.Rows(rowIndex)
                    .Cells(1).Value = ""
                    .Cells(2).Value = ""
                    .Cells(3).Value = ""
                End With
            Case 2, 3
                column = 1
            Case Else
                Exit Sub
        End Select
        gridRecibos.CurrentCell.Value = ceros(val.ToString, 2)
        gridRecibos.CurrentCell = gridRecibos.Rows(rowIndex).Cells(column)
    End Sub

    Private Sub gridRecibos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        sumarValores()
        agregarClienteABanco()
    End Sub

    Private Function _NormalizarNumero(ByVal numero As String) As String

        Return Proceso.formatonumerico(numero)

    End Function

    Private Function sumarValores() As Boolean
        Dim _Error = False

        lblTotal.Text = Val(_NormalizarNumero(txtRetGanancias.Text)) _
                        + Val(_NormalizarNumero(txtRetIva.Text)) _
                        + Val(_NormalizarNumero(txtRetIB.Text)) _
                        + Val(_NormalizarNumero(txtRetSuss.Text))

        For Each row As DataGridViewRow In gridRecibos.Rows

            If Val(row.Cells(4).Value) <> 0 Then

                If Val(row.Cells(0).Value) = 2 Then

                    If _ChequeVencido(row.Cells(2).Value) Then
                        _Error = True
                        Exit For
                    End If

                End If

                lblTotal.Text = _NormalizarNumero(Val(_NormalizarNumero(lblTotal.Text)) + Val(_NormalizarNumero(row.Cells(4).Value))) ' Lo vamos acumulando.

            End If

        Next

        lblTotal.Text = _NormalizarNumero(lblTotal.Text)
        lblDiferencia.Text = Val(_NormalizarNumero(lblTotal.Text)) - Val(_NormalizarNumero(txtTotal.Text))
        Return _Error
    End Function

    Private Function _ChequeVencido(ByVal fecha_cheque As String) As Boolean
        Return IsDate(fecha_cheque) And IsDate(txtFecha.Text) And DateDiff(DateInterval.Day, CDate(fecha_cheque), CDate(txtFecha.Text)) > 30
    End Function

    Private Sub agregarClienteABanco()
        For Each row As DataGridViewRow In gridRecibos.Rows
            If row.Cells(3).Value <> "" Then
                If row.Cells(3).Value.ToString.Length > 20 Or row.Cells(3).Value.ToString.Contains("/") Then
                    'row.Cells(3).Value = ""
                Else
                    row.Cells(3).Value = row.Cells(3).Value.ToString & clienteSinCeros()
                End If
            End If
        Next
    End Sub

    Private Function clienteSinCeros()
        Try
            Dim cliente As String = txtCliente.Text
            Dim numero As Integer = CustomConvert.toIntOrZero(cliente.Substring(1, cliente.Count - 1))
            Return "/" & cliente.First & numero
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub mostrarRecibo(ByVal recibo As String)
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT * FROM RecibosProvi WHERE Recibo = '" + recibo + "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()
            gridRecibos.Rows.Clear()
            _ClavesCheques.Clear()
            _CuentasContables.Clear()

            If dr.HasRows Then

                Do While dr.Read()
                    Dim renglon As String = dr.Item("Renglon").ToString()

                    If renglon = "01" Then
                        txtRecibo.Text = IIf(IsDBNull(dr.Item("Recibo")), "", dr.Item("Recibo"))
                        txtFecha.Text = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))
                        txtCliente.Text = IIf(IsDBNull(dr.Item("Cliente")), "", dr.Item("Cliente"))
                        Dim cliente As Cliente = DAOCliente.buscarClientePorCodigo(txtCliente.Text)
                        If Not IsNothing(cliente) Then : txtNombre.Text = cliente.razon : End If
                        cliente = Nothing
                        txtParidad.Text = "0.00"
                        txtRetGanancias.Text = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetGanancias")), "", dr.Item("RetGanancias")))
                        _ComprobanteRetGanancias = IIf(IsDBNull(dr.Item("ComproGanan")), "", dr.Item("ComproGanan"))
                        txtRetIva.Text = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIva")), "", dr.Item("RetIva")))
                        _ComprobanteRetIva = IIf(IsDBNull(dr.Item("ComproIva")), "", dr.Item("ComproIva"))
                        txtRetSuss.Text = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetSuss")), "", dr.Item("RetSuss")))
                        _ComprobanteRetSuss = IIf(IsDBNull(dr.Item("ComproSuss")), "", dr.Item("ComproSuss"))
                        txtRetIB.Text = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetOtra")), "", dr.Item("RetOtra")))
                        _RetIB1 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb1")), "", dr.Item("RetIb1")))
                        _CompIB1 = IIf(IsDBNull(dr.Item("NroRetIb1")), "", dr.Item("NroRetIb1"))
                        _RetIB2 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb2")), "", dr.Item("RetIb2")))
                        _CompIB2 = IIf(IsDBNull(dr.Item("NroRetIb2")), "", dr.Item("NroRetIb2"))
                        _RetIB3 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb3")), "", dr.Item("RetIb3")))
                        _CompIB3 = IIf(IsDBNull(dr.Item("NroRetIb3")), "", dr.Item("NroRetIb3"))
                        _RetIB4 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb4")), "", dr.Item("RetIb4")))
                        _CompIB4 = IIf(IsDBNull(dr.Item("NroRetIb4")), "", dr.Item("NroRetIb4"))
                        _RetIB5 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb5")), "", dr.Item("RetIb5")))
                        _CompIB5 = IIf(IsDBNull(dr.Item("NroRetIb5")), "", dr.Item("NroRetIb5"))
                        _RetIB6 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb6")), "", dr.Item("RetIb6")))
                        _CompIB6 = IIf(IsDBNull(dr.Item("NroRetIb6")), "", dr.Item("NroRetIb6"))
                        _RetIB7 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb7")), "", dr.Item("RetIb7")))
                        _CompIB7 = IIf(IsDBNull(dr.Item("NroRetIb7")), "", dr.Item("NroRetIb7"))
                        _RetIB8 = _NormalizarNumero(IIf(IsDBNull(dr.Item("RetIb8")), "", dr.Item("RetIb8")))
                        _CompIB8 = IIf(IsDBNull(dr.Item("NroRetIb8")), "", dr.Item("NroRetIb8"))
                        txtTotal.Text = _NormalizarNumero(IIf(IsDBNull(dr.Item("Importe")), "", dr.Item("Importe")))
                    End If

                    Dim _FormaPagoActual As Integer = gridRecibos.Rows.Add()

                    With gridRecibos.Rows(_FormaPagoActual)
                        .Cells(0).Value = IIf(IsDBNull(dr.Item("Tipo2")), "", dr.Item("Tipo2"))
                        .Cells(1).Value = IIf(IsDBNull(dr.Item("Numero2")), "", dr.Item("Numero2"))
                        .Cells(2).Value = IIf(IsDBNull(dr.Item("Fecha2")), "", dr.Item("Fecha2"))
                        .Cells(3).Value = IIf(IsDBNull(dr.Item("banco2")), "", dr.Item("banco2"))
                        .Cells(4).Value = _NormalizarNumero(dr.Item("Importe2"))
                        .Cells(5).Value = _FormaPagoActual
                        .Cells("ClaveCheque").Value = IIf(IsDBNull(dr.Item("ClaveCheque")), "", dr.Item("ClaveCheque"))
                        .Cells("ClaveBanco").Value = IIf(IsDBNull(dr.Item("BancoCheque")), "", dr.Item("BancoCheque"))
                        .Cells("ClaveSucursal").Value = IIf(IsDBNull(dr.Item("SucursalCheque")), "", dr.Item("SucursalCheque"))
                        .Cells("NumeroCheque").Value = IIf(IsDBNull(dr.Item("ChequeCheque")), "", dr.Item("ChequeCheque"))
                        .Cells("NroCta").Value = IIf(IsDBNull(dr.Item("CuentaCheque")), "", dr.Item("CuentaCheque"))
                        .Cells("NroCuit").Value = IIf(IsDBNull(dr.Item("Cuit")), "", dr.Item("Cuit"))
                    End With


                    If Val(dr.Item("Tipo2")) = 2 Then
                        With dr
                            _ClavesCheques.Add({CInt(.Item("Renglon")) - 1, .Item("ClaveCheque"), .Item("BancoCheque") _
                                               , .Item("SucursalCheque"), .Item("ChequeCheque"), .Item("CuentaCheque") _
                                               , .Item("Cuit"), "", ""})
                        End With
                    End If

                    If Val(dr.Item("Tipo2")) = 4 Then
                        With dr
                            _CuentasContables.Add({Val(.Item("Renglon")) - 1, .Item("Cuenta")})
                        End With
                    End If

                Loop

                sumarValores()

            Else
                Dim _r As String = txtRecibo.Text
                btnLimpiar.PerformClick()
                txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
                txtRecibo.Text = _r
                txtRecibo.Focus()
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar el recibo provisorio.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cm = Nothing

        End Try
    End Sub

    Private Sub mostrarFormasPago(ByVal formasPago As List(Of FormaPago))
        gridRecibos.Rows.Clear()
        For Each forma As FormaPago In formasPago
            gridRecibos.Rows.Add(forma.tipo, forma.numero, forma.fecha, forma.nombre, forma.importe)
        Next
    End Sub

    Private Sub mostrarCliente(ByVal cliente As Cliente)
        If IsNothing(cliente) Then
            txtNombre.Text = ""
        Else
            txtCliente.Text = cliente.id
            txtNombre.Text = cliente.razon
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Trim(txtCliente.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            Dim cliente = DAOCliente.buscarClientePorCodigo(txtCliente.Text)
            If Not IsNothing(cliente) Then
                mostrarCliente(cliente)
                _SaltarA(txtRetGanancias)
            Else
                txtNombre.Text = ""
                MessageBox.Show("El cliente ingresado es inexistente")
                txtCliente.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
            txtNombre.Text = ""
        End If
    End Sub

    Private Function _TraerProximoNumeroDeReciboProvisorio()
        Dim proximo = ""
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Recibo FROM RecibosProvi ORDER BY Recibo DESC")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                proximo = ceros(Val(dr.Item("Recibo")) + 1, 6)

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return proximo
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim validador As New Validator
        Dim _tipoRec = 0

        If Val(txtRecibo.Text) = 0 Then
            txtRecibo.Text = _TraerProximoNumeroDeReciboProvisorio()
        End If

        For Each control As Control In Panel2.Controls

            If TypeOf (control) Is TextBox Then

                If Trim(control.Text) = "" And control.Name <> "txtConsulta" And control.Name <> "txtParidad" Then ' Validamos que todos los campos tengan valores
                    MsgBox("Hay campos que son obligatorios que no se encuentran completos.", MsgBoxStyle.Information)
                    Exit Sub

                End If

            End If

        Next
        validador.validate(Me)
        validador.alsoValidate(Val(_NormalizarNumero(lblTotal.Text)) = Val(_NormalizarNumero(txtTotal.Text)), "La suma de los importes de la tabla no coincide con lo informado en el total")
        validador.alsoValidate(DAORecibo.permiteActualizacionProvisorio(txtRecibo.Text), "Algunos de los cheques del recibo provisorio ya se encuentra procesado por lo que no se puede actualizar el mismo.")
        'validador.alsoValidate(DAORecibo.existeReciboProvisorio(txtRecibo.Text), "Ya existe un recibo definitivo con ese número")

        If validador.flush Then

            If optCtaCte.Checked Then
                _tipoRec = 1
            ElseIf optAnticipos.Checked Then
                _tipoRec = 2
            Else
                _tipoRec = 3
            End If

            Try

                DAORecibo.agregarReciboProvisorio(txtRecibo.Text, txtFecha.Text, DAOCliente.buscarClientePorCodigo(txtCliente.Text), _
                    _tipoRec, (_NormalizarNumero(txtRetGanancias.Text)), (_NormalizarNumero(txtRetIB.Text)), _
                    (_NormalizarNumero(txtRetIva.Text)), (_NormalizarNumero(txtRetSuss.Text)), _
                    0, (_NormalizarNumero(txtTotal.Text)), gridRecibos.Rows, _Left(_ComprobanteRetGanancias, 10), _
                    _Left(_ComprobanteRetIva, 10), _Left(_ComprobanteRetSuss, 10), (_NormalizarNumero(_RetIB1)), (_NormalizarNumero(_CompIB1)), _
                    (_NormalizarNumero(_RetIB2)), (_NormalizarNumero(_CompIB2)), (_NormalizarNumero(_RetIB3)), _
                    (_NormalizarNumero(_CompIB3)), (_NormalizarNumero(_RetIB4)), (_NormalizarNumero(_CompIB4)), _
                    (_NormalizarNumero(_RetIB5)), (_NormalizarNumero(_CompIB5)), (_NormalizarNumero(_RetIB6)), _
                    (_NormalizarNumero(_CompIB6)), (_NormalizarNumero(_RetIB7)), (_NormalizarNumero(_CompIB7)), (_NormalizarNumero(_RetIB8)), (_NormalizarNumero(_CompIB8)), _ClavesCheques, _CuentasContables)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            MsgBox("Recibo provisorio guardado con exito!", MsgBoxStyle.Information)
            btnLimpiar.PerformClick()

        End If
    End Sub

    Private Function _Left(ByVal texto As String, ByVal largo As Integer) As String
        Return Mid(texto, 1, largo)
    End Function

    Private Function crearFormasPago() As List(Of FormaPago)
        Dim formasPago As New List(Of FormaPago)
        For Each row As DataGridViewRow In gridRecibos.Rows
            If Not row.IsNewRow AndAlso Not IsNothing(row.Cells(0).Value) AndAlso Trim(row.Cells(0).Value) <> "" Then
                formasPago.Add(New FormaPago(_Left(row.Cells(0).Value, 2), 0, _NormalizarNumeroCheque(asString(row.Cells(1).Value)), asString(row.Cells(2).Value), _Left(asString(row.Cells(3).Value), 20), _NormalizarNumero(row.Cells(4).Value)))
            End If
        Next
        Return formasPago
    End Function

    Private Function _NormalizarNumeroCheque(ByVal numero As String) As String

        If Trim(numero) <> "" Then
            numero = ceros(numero, 8)
        End If
        Return numero
    End Function

    Private Function asString(ByVal value)
        If IsNothing(value) Then
            Return ""
        Else
            Return value.ToString
        End If
    End Function

    Private Sub txtRetencion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sumarValores()
    End Sub

    Private Sub txtTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotal.KeyDown
        If e.KeyValue = Keys.Enter Then

            txtTotal.Text = _NormalizarNumero(txtTotal.Text)

            If Val(txtTotal.Text) = 0 Then
                Exit Sub
            End If

            sumarValores()
            With gridRecibos
                '.Rows(0).Selected = True
                .CurrentCell = .Rows(0).Cells(0)
                .Focus()
            End With
        ElseIf e.KeyData = Keys.Escape Then
            txtTotal.Text = ""
        End If
    End Sub

    Private Sub txtRetIva_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIva.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIva.Text) > 0 Then
                _PedirInformacion("Ingrese el Número de Comprobante de Retención de IVA", txtRetIva, _ComprobanteRetIva)
            End If

            _SaltarA(txtRetSuss)
        ElseIf e.KeyData = Keys.Escape Then
            txtRetIva.Text = ""
        End If

    End Sub

    Private Sub _PedirInformacion(ByVal msg As String, ByRef control As TextBox, ByRef VariableDestino As String)

        With InformacionRetenciones
            .TipoInformacion = msg

            .Valor = VariableDestino

            .ShowDialog(Me)

            VariableDestino = .Valor

            .Dispose()

        End With

    End Sub

    Private Sub txtRetGanancias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetGanancias.KeyDown
        If e.KeyData = Keys.Enter Then

            If Val(txtRetGanancias.Text) > 0 Then
                _PedirInformacion("Ingrese el Número de Comprobante de Retención de Ganancias", txtRetGanancias, _ComprobanteRetGanancias)
            End If

            _SaltarA(txtRetIB)
        ElseIf e.KeyData = Keys.Escape Then
            txtRetGanancias.Text = ""
        End If
    End Sub

    Private Sub txtRetIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB.KeyDown
        If e.KeyData = Keys.Enter Then

            'Aca Mostrar en realidad la ventana con las opciones de IB

            _SaltarA(txtRetIva)
        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB.Text = "0.00"
            _RetIB1 = ""
            _CompIB1 = ""
            _RetIB2 = ""
            _CompIB2 = ""
            _RetIB3 = ""
            _CompIB3 = ""
            _RetIB4 = ""
            _CompIB4 = ""
            _RetIB5 = ""
            _CompIB5 = ""
            _RetIB6 = ""
            _CompIB6 = ""
            _RetIB7 = ""
            _CompIB7 = ""
            _RetIB8 = ""
            _CompIB8 = ""
        End If
    End Sub

    Private Sub txtRetSuss_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetSuss.KeyDown
        If e.KeyData = Keys.Enter Then

            If Val(txtRetSuss.Text) > 0 Then
                _PedirInformacion("Ingrese el Número de Comprobante de Retención de SUSS", txtRetSuss, _ComprobanteRetSuss)
            End If

            _SaltarA(txtTotal)
        ElseIf e.KeyData = Keys.Escape Then
            txtRetSuss.Text = ""
        End If
    End Sub

    Private Sub txtParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtParidad.KeyDown
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtTotal)

        ElseIf e.KeyData = Keys.Escape Then
            txtParidad.Text = ""
        End If
    End Sub

    Private Sub txtRecibo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecibo.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtRecibo.Text) <> "" Then
                txtRecibo.Text = ceros(txtRecibo.Text, 6)
                mostrarRecibo(Trim(txtRecibo.Text))
                _SaltarA(txtFecha)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRecibo.Text = ""
        End If
    End Sub

    Private Sub _SaltarA(ByRef control As Control)
        control.Focus()
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyData = Keys.Enter Then

            'txtFecha.Text = _Normalizarfecha(txtFecha.Text)

            If Proceso._ValidarFecha(txtFecha.Text) Then
                txtCliente.Focus()
                Exit Sub
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If
    End Sub

    Private Sub _DeterminarParidad(Optional ByVal fecha As String = "")
        Dim _Fecha As String = IIf(fecha = "", txtFecha.Text, fecha)
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Cambio FROM Cambios WHERE Fecha = '" & _Fecha & "'")
        Dim dr As SqlDataReader

        If Trim(txtFecha.Text) <> "" Then

            SQLConnector.conexionSql(cn, cm)

            Try

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    dr.Read()

                    txtParidad.Text = _NormalizarNumero(dr.Item("Cambio"))

                Else
                    txtParidad.Text = ""
                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()

            End Try
        End If

    End Sub

    Private Sub txtRetIB_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIB.Enter

        With DatosIB

            .txtRetIB1.Text = Proceso.formatonumerico(_RetIB1)
            .txtCompIB1.Text = _CompIB1
            .txtRetIB2.Text = Proceso.formatonumerico(_RetIB2)
            .txtCompIB2.Text = _CompIB2
            .txtRetIB3.Text = Proceso.formatonumerico(_RetIB3)
            .txtCompIB3.Text = _CompIB3
            .txtRetIB4.Text = Proceso.formatonumerico(_RetIB4)
            .txtCompIB4.Text = _CompIB4
            .txtRetIB5.Text = Proceso.formatonumerico(_RetIB5)
            .txtCompIB5.Text = _CompIB5
            .txtRetIB6.Text = Proceso.formatonumerico(_RetIB6)
            .txtCompIB6.Text = _CompIB6
            .txtRetIB7.Text = Proceso.formatonumerico(_RetIB7)
            .txtCompIB7.Text = _CompIB7
            .txtRetIB8.Text = Proceso.formatonumerico(_RetIB8)
            .txtCompIB8.Text = _CompIB8

            .ShowDialog(Me)

            _RetIB1 = Proceso.formatonumerico(.txtRetIB1.Text)
            _CompIB1 = .txtCompIB1.Text
            _RetIB2 = Proceso.formatonumerico(.txtRetIB2.Text)
            _CompIB2 = .txtCompIB2.Text
            _RetIB3 = Proceso.formatonumerico(.txtRetIB3.Text)
            _CompIB3 = .txtCompIB3.Text
            _RetIB4 = Proceso.formatonumerico(.txtRetIB4.Text)
            _CompIB4 = .txtCompIB4.Text
            _RetIB5 = Proceso.formatonumerico(.txtRetIB5.Text)
            _CompIB5 = .txtCompIB5.Text
            _RetIB6 = Proceso.formatonumerico(.txtRetIB6.Text)
            _CompIB6 = .txtCompIB6.Text
            _RetIB7 = Proceso.formatonumerico(.txtRetIB7.Text)
            _CompIB7 = .txtCompIB7.Text
            _RetIB8 = Proceso.formatonumerico(.txtRetIB8.Text)
            _CompIB8 = .txtCompIB8.Text

            .Dispose()

        End With

        _RecalcularRetIB()

    End Sub

    Private Sub _RecalcularRetIB()
        Dim totalIB As Double = 0

        totalIB += (Val(_RetIB1))
        totalIB += (Val(_RetIB2))
        totalIB += (Val(_RetIB3))
        totalIB += (Val(_RetIB4))
        totalIB += (Val(_RetIB5))
        totalIB += (Val(_RetIB6))
        totalIB += (Val(_RetIB7))
        totalIB += (Val(_RetIB8))

        txtRetIB.Text = totalIB

        txtRetIva.Focus()
    End Sub

    Private Sub txtRetGanancias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetGanancias.Leave

        If txtRetGanancias.Text = "" Then
            txtRetGanancias.Text = "0.00"
        End If

        sumarValores()
    End Sub

    Private Sub txtRetIB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIB.Leave
        If txtRetIB.Text = "" Then
            txtRetIB.Text = "0.00"
        End If

        sumarValores()
    End Sub

    Private Sub txtRetIva_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIva.Leave
        If txtRetIva.Text = "" Then
            txtRetIva.Text = "0.00"
        End If

        sumarValores()
    End Sub

    Private Sub txtRetSuss_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetSuss.Leave
        If txtRetSuss.Text = "" Then
            txtRetSuss.Text = "0.00"
        End If

        sumarValores()
    End Sub

    Private Sub NormalizarMontos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetSuss.Leave, txtParidad.Leave, txtRetGanancias.Leave, txtRetIB.Leave, txtRetIva.Leave
        txtRetSuss.Text = Proceso.formatonumerico(txtRetSuss.Text)
        txtParidad.Text = Proceso.formatonumerico(txtParidad.Text)
        txtRetGanancias.Text = Proceso.formatonumerico(txtRetGanancias.Text)
        txtRetIB.Text = Proceso.formatonumerico(txtRetIB.Text)
        txtRetIva.Text = Proceso.formatonumerico(txtRetIva.Text)

        sumarValores()
    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 109)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190 Or keycode = 109)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If gridRecibos.Focused Or gridRecibos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            gridRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = gridRecibos.CurrentCell.ColumnIndex
            Dim iRow = gridRecibos.CurrentCell.RowIndex

            ' Limitamos los caracteres permitidos para cada una de las columnas.
            Select Case iCol
                Case 1
                    If Not _EsNumeroOControl(keyData) Then
                        Return True
                    End If
                Case 4
                    If Not _EsDecimalOControl(keyData) Then
                        Return True
                    End If
                Case Else

            End Select

            'If iCol = 0 Then

            '    ' Por compatibilidad con lectora de Domingo que no envia enter al leer dato de cheque.
            '    If Len(gridRecibos.Rows(iRow).Cells(iCol).Value) = 30 Then
            '        SendKeys.Send("{ENTER}")
            '    End If

            'End If

            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = gridRecibos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then


                        If Trim(valor.ToString.Length) = 31 Then
                            If _ProcesarCheque(iRow, valor) Then

                                Dim _c As Object = _ClavesCheques.FindLast(Function(c) c(0) = iRow)

                                If Not IsNothing(_c) Then
                                    If Proceso.CuitValido(_c(6)) Then

                                        gridRecibos.Rows(iRow).Cells(6).Value = "1"

                                    Else

                                        gridRecibos.Rows(iRow).Cells(6).Value = "0"

                                    End If
                                Else
                                    gridRecibos.Rows(iRow).Cells(6).Value = "0"
                                End If


                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 2) ' Nos desplazamos para que coloque la fecha del cheque.

                            End If
                        Else
                            valor = valor.ToString().Substring(valor.ToString.Length - 1, 1)
                            If valor = "1" Or valor = "2" Or valor = "3" Or valor = "4" Then
                                eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(valor), iRow, iCol)
                            Else ' Sólo se aceptan los valores 1 (Efectivo) , 2 (Cheque), 3 (Doc) y 4 (Varios) ?
                                Return True
                            End If
                        End If

                    Else

                        'Modificar el valor de la columna de ser fecha DD/MM --> DD/MM/YYYY (año actual)
                        If iCol = 2 Then

                            gridRecibos.Rows(iRow).Cells(2).Value = _Normalizarfecha(valor)
                            gridRecibos.EndEdit()

                        End If

                        If iCol = 1 Or iCol = 2 Or iCol = 3 Then ' Avanzamos a la siguiente celda continua.

                            If iCol = 2 Then
                                ' Completamos el año de manera automatica
                                If Len(Trim(valor)) = 6 Then
                                    Dim _mes As String = Mid(valor, 4, 2)

                                    Select Case Val(_mes)
                                        Case Is < 7
                                            valor = Mid(valor, 1, 2) & "/" & _mes & "/" & "2018"
                                        Case Else
                                            valor = Mid(valor, 1, 2) & "/" & _mes & "/" & "2017"
                                    End Select

                                End If
                                If _ChequeVencido(valor) Then
                                    MsgBox("La fecha del cheque introducida es inválida", MsgBoxStyle.Critical)
                                    gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol)
                                Else
                                    gridRecibos.Rows(iRow).Cells(iCol).Value = valor
                                    gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)
                                End If
                            ElseIf iCol = 3 Then

                                If Trim(valor) = "" Or IsNothing(valor) Then : Return True : End If

                                gridRecibos.Rows(iRow).Cells(iCol).Value = _GenerarCodigoBanco(valor)
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)
                            Else
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)

                                Dim _location As Point = gridRecibos.GetCellDisplayRectangle(2, iRow, False).Location

                                gridRecibos.ClearSelection()
                                _location.Y += gridRecibos.Location.Y + (gridRecibos.CurrentCell.Size.Height / 4) - 1.5
                                _location.X += gridRecibos.Location.X + (gridRecibos.CurrentCell.Size.Width - txtFechaAux.Size.Width) - 3
                                txtFechaAux.Location = _location
                                txtFechaAux.Text = gridRecibos.Rows(iRow).Cells(2).Value
                                WRow = iRow
                                Wcol = iCol
                                txtFechaAux.Visible = True
                                txtFechaAux.Focus()
                            End If

                        End If

                        If iCol = 4 Then ' Avanzamos a la fila siguiente.

                            If Trim(valor) = "" Or IsNothing(valor) Then : Return True : End If

                            If Val(gridRecibos.Rows(iRow).Cells(0).Value) = 4 Then

                                _PedirCuentaContable(iRow)

                            ElseIf Val(gridRecibos.Rows(iRow).Cells(0).Value) = 2 Then
                                ' Pedimos unicamente cuit cuando el cheque no fue cargado por lectora y este no es un cuit invalido.
                                If Val(gridRecibos.Rows(iRow).Cells(6).Value) <> 1 Then
                                    _PedirClaveCheque(iRow)
                                Else
                                    gridRecibos.Rows(iRow).Cells(6).Value = "0"
                                End If

                            End If

                            If gridRecibos.Rows.Count <= 40 Then
                                gridRecibos.Rows.Add()
                            Else
                                MsgBox("Se ha alcanzado el Número Máximo de Cheques/Formas de Pago permitidos en un Recibo.", MsgBoxStyle.Information)
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(0)
                                gridRecibos.Focus()
                                Return True
                            End If

                            gridRecibos.CurrentCell = gridRecibos.Rows(iRow + 1).Cells(0)
                            sumarValores()
                        End If
                    End If

                    Return True
                Else

                    With gridRecibos
                        Select Case iCol
                            Case 0
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Case 1, 2, 3
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                            Case Else
                        End Select
                    End With

                    Return True

                End If
            ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                gridRecibos.Rows(iRow).Cells(iCol).Value = ""

                ' Solo para que pierda el foco y se refresque el contenido sino sigue quedando ahi.
                If iCol = 4 Then
                    gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol - 1)
                Else
                    gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)
                End If

                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol)

            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _ObtenerNombreBanco(ByVal claveBanco As String) As String
        Dim _NombreBanco = ""
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Nombre FROM BCRA WHERE Banco = '" & Val(claveBanco) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                _NombreBanco = Trim(UCase(dr.Item("Nombre")))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _NombreBanco
    End Function

    Private Function _FormatoValidoDeCheque(ByVal ClaveCheque As String) As Boolean
        Dim valido = False

        ClaveCheque = UCase(Trim(ClaveCheque))

        If ClaveCheque.Length = 31 And Mid(ClaveCheque, 1, 1) = "C" And Mid(ClaveCheque, ClaveCheque.Length, 1) = "E" Then
            valido = True
        End If

        Return valido
    End Function

    Private Function _ProcesarCheque(ByVal row As Integer, ByVal ClaveCheque As String) As Boolean
        Dim _ClaveBanco, _Banco, _Sucursal, _NumCheque, _NumCta, _Cuit As String
        Dim _LecturaCorrecta = True

        If Not _FormatoValidoDeCheque(ClaveCheque) Then
            MsgBox("El formato del cheque no es valido.", MsgBoxStyle.Exclamation)
            Return False
        End If

        _ClaveBanco = Mid$(ClaveCheque, 2, 3)
        _Banco = _ObtenerNombreBanco(_ClaveBanco)
        _Sucursal = Mid$(ClaveCheque, 5, 3)
        _NumCheque = Mid$(ClaveCheque, 12, 8)
        _NumCta = Mid$(ClaveCheque, 20, 11)

        ' Chequeamos que el cheque no se haya cargado.

        If _ChequeYaCargado(ClaveCheque) Then
            _LecturaCorrecta = False

            MsgBox("Cheque ya Cargado con anterioridad.", MsgBoxStyle.Exclamation)

            Return _LecturaCorrecta
        End If

        ' Extraer Datos del String.
        If _Banco = "" Then
            _LecturaCorrecta = False
            MsgBox("Error en la lectura de los datos del codigo de banco del cheque")
        End If

        ' Buscamos si existe el cuit.
        _Cuit = _TraerNumeroCuit(_ClaveBanco & _Sucursal & _NumCta)

        With gridRecibos.Rows(row)
            .Cells(0).Value = "02"
            .Cells(1).Value = _NumCheque
            .Cells(2).Value = ""
            .Cells(3).Value = _GenerarCodigoBanco(_Banco)
            .Cells("ClaveCheque").Value = ClaveCheque
            .Cells("ClaveBanco").Value = _ClaveBanco
            .Cells("ClaveSucursal").Value = _Sucursal
            .Cells("NumeroCheque").Value = _NumCheque
            .Cells("NroCta").Value = _NumCta
            .Cells("NroCuit").Value = _Cuit
        End With

        ' Guardamos el nuevo Cheque.
        _GuardarNuevoCheque(row, ClaveCheque, _ClaveBanco, _Sucursal, _NumCheque, _NumCta, _Cuit)

        Return _LecturaCorrecta
    End Function

    Private Function _GenerarCodigoBanco(ByVal _Banco As String) As String
        _Banco = _Banco.ToString.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

        Return _Banco & "/" & Mid(txtCliente.Text, 1, 1) & Val(Mid(txtCliente.Text, 2, 6)).ToString()
    End Function

    Private Function _ChequeYaCargado(ByVal ClaveCheque) As Boolean
        Dim _cargado = False

        If _ChequeUtilizadoEnRecibo(ClaveCheque) Then

            _cargado = True

        ElseIf _ChequeUtilizadoEnReciboProvisorio(ClaveCheque) Then

            _cargado = True

        Else

            Dim cheque As Object = _ClavesCheques.FindLast(Function(c) c(1) = ClaveCheque)
            If Not IsNothing(cheque) Then
                _cargado = True
            End If

        End If

        Return _cargado
    End Function

    Private Function _ChequeUtilizadoEnRecibo(ByVal ClaveCheque As String) As Boolean
        Dim utilizado = False
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 ClaveCheque FROM Recibos WHERE ClaveCheque = '" & ClaveCheque & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                utilizado = True
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return utilizado
    End Function

    Private Function _ChequeUtilizadoEnReciboProvisorio(ByVal ClaveCheque As String) As Boolean
        Dim utilizado = False
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 ClaveCheque FROM RecibosProvi WHERE ClaveCheque = '" & ClaveCheque & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                utilizado = True
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return utilizado
    End Function

    Private Function _TraerNumeroCuit(ByVal clave As String) As String
        Dim _cuit = ""
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Cuit FROM Cuit WHERE Clave = '" & Trim(clave) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                _cuit = IIf(IsDBNull(dr.Item("Cuit")), "", dr.Item("Cuit"))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _cuit
    End Function


    Private Sub _GuardarNuevoCheque(ByVal row As Integer, ByVal Clave As String, _
                                    ByVal banco As String, ByVal sucursal As String, _
                                    ByVal numCheque As String, ByVal numCta As String, _
                                    ByVal _Cuit As String)

        Dim buscar As Object = _ClavesCheques.Find(Function(c) c(0) = row)

        If Not IsNothing(buscar) Then
            _ClavesCheques.Remove(buscar)
        End If

        _ClavesCheques.Add({row, Clave, banco, sucursal, numCheque, numCta, _Cuit, "", ""})

    End Sub

    Private Function _Normalizarfecha(ByVal fecha As String) As String
        Return Proceso._Normalizarfecha(fecha)
    End Function

    Private Sub _PedirCuentaContable(ByVal row As Integer)
        Dim cuenta As String
        Dim buscar As Object

        cuenta = ""
        buscar = _CuentasContables.FindLast(Function(c) c(0) = row)

        If Not IsNothing(buscar) Then
            cuenta = buscar(1)
            _PedirInformacion("Ingrese Cuenta Contable", New TextBox(), cuenta)
            'If cuenta = "" Then : Exit Sub : End If
        End If

        Do While Not _CuentaContableValida(cuenta)

            _PedirInformacion("Ingrese Cuenta Contable", New TextBox(), cuenta)

            If cuenta = "" Then
                Exit Do
            End If
        Loop

        _CuentasContables.Add({row, Trim(cuenta)})

    End Sub

    Private Sub _PedirClaveCheque(ByVal row As Integer)
        Dim _clave, _banco, _sucursal, _cheque, _cuenta, _cuit, _estado, _destino As String
        Dim buscar As Object

        _cuit = ""
        buscar = _ClavesCheques.FindLast(Function(c) c(0) = row)

        If Not IsNothing(buscar) Then
            _cuit = Trim(buscar(6))
            'If _cuit.Length = 11 Then : Exit Sub : End If
        End If

        With SolicitarInformacionCuit

            .Valor = _cuit

            .ShowDialog()

            _cuit = .Valor

        End With

        _clave = ""
        _banco = ""
        _sucursal = ""
        _cheque = ""
        _cuenta = ""
        _estado = ""
        _destino = ""

        buscar = Nothing
        buscar = _ClavesCheques.Find(Function(c) c(0) = row)
        If Not IsNothing(buscar) Then

            _clave = buscar(1)
            _banco = buscar(2)
            _sucursal = buscar(3)
            _cheque = buscar(4)
            _cuenta = buscar(5)
            _estado = ""
            _destino = ""

            _ClavesCheques.Remove(buscar)
        End If

        _ClavesCheques.Add({row, _clave, _banco, _sucursal, _cheque, _cuenta, _cuit, _estado, _destino})

        gridRecibos.Rows(row).Cells(5).Value = row
        gridRecibos.Rows(row).Cells("NroCuit").Value = _cuit ' Guardamos el numero de cuit para que lo guarde.

    End Sub

    Private Function _CuentaContableValida(ByRef cuenta As String)
        Dim _CuentaValida = False
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Cuenta FROM Cuenta WHERE Cuenta= '" & Trim(cuenta) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                _CuentaValida = True

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cm.CommandText = ""

        End Try

        Return _CuentaValida
    End Function

    Private Sub txtFecha_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFecha.TypeValidationCompleted
        e.Cancel = Not Proceso._ValidarFecha(txtFecha.Text, e.IsValidInput)
    End Sub

    Private Sub RecibosProvisorios_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtRecibo.Focus()
    End Sub

    Private Sub txtCliente_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCliente.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            ' Completamos el año de manera automatica
            If Len(Trim(txtFechaAux.Text)) = 6 Then
                Dim _mes As String = Mid(txtFechaAux.Text, 4, 2)

                Select Case Val(_mes)
                    Case Is < 7
                        txtFechaAux.Text = Mid(txtFechaAux.Text, 1, 2) & "/" & _mes & "/" & "2018"
                    Case Else
                        txtFechaAux.Text = Mid(txtFechaAux.Text, 1, 2) & "/" & _mes & "/" & "2018"
                End Select

            End If

            'Debug.Print(Proceso._ValidarFecha(Trim(txtFechaAux.Text)))

            If Proceso._ValidarFecha(Trim(txtFechaAux.Text)) And WRow >= 0 And Wcol >= 0 Then

                If _ChequeVencido(Trim(txtFechaAux.Text)) Then
                    MsgBox("La fecha del cheque introducida es inválida", MsgBoxStyle.Critical)
                    'gridRecibos.CurrentCell = gridRecibos.Rows(WRow).Cells(Wcol)
                    Exit Sub
                End If

                gridRecibos.Rows(WRow).Cells(2).Value = txtFechaAux.Text

                If Trim(gridRecibos.Rows(WRow).Cells(3).Value) <> "" Then
                    gridRecibos.CurrentCell = gridRecibos.Rows(WRow).Cells(4)
                Else
                    gridRecibos.CurrentCell = gridRecibos.Rows(WRow).Cells(3)
                End If

                gridRecibos.Focus()

                txtFechaAux.Visible = False
                txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If MsgBox("¿Desea eliminar el siguiente Recibo Provisorio?", MsgBoxStyle.YesNo) = DialogResult.No Then
            txtRecibo.Focus()
            Exit Sub
        End If

        ' Comprobamos que todos los cheques se encuentren en estado pendiente (Estado2 = "P")
        If Not _TodosLosChequesPendientes() Then
            MsgBox("Alguno de los cheques del Recibo Provisorio ya fue procesado.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Verificamos que no se lo haya asignado a algun Recibo Definitivo.
        If _ReciboProvisorioYaAsignado() Then
            MsgBox("El recibo provisorio actual ya se encuentra asociado a un Recibo Definitivo.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Eliminamos el Recibo Provisorio.
        Try
            _EliminarReciboProvisorio(txtRecibo.Text)
            MsgBox("El Recibo Provisorio se ha eliminado correctamente.", MsgBoxStyle.Information)
            btnLimpiar.PerformClick()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
            Exit Sub
        End Try

    End Sub

    Private Sub _EliminarReciboProvisorio(ByVal recibo As String)
        recibo = Trim(recibo)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("DELETE FROM RecibosProvi WHERE Recibo = '" & recibo & "'")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("No se pudo eliminar el Recibo Provisorio solicitado.")
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _ReciboProvisorioYaAsignado() As Boolean
        Dim asignado = False
        Dim definitivo = ""

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT ReciboDefinitivo FROM RecibosProvi WHERE Recibo = '" & Trim(txtRecibo.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                definitivo = IIf(IsDBNull(dr.Item("ReciboDefinitivo")), 0, dr.Item("ReciboDefinitivo"))

                If Val(definitivo) <> 0 Then
                    asignado = True
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

        Return asignado
    End Function

    Private Function _TodosLosChequesPendientes() As Boolean
        Dim _TodosPendientes = True

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT * FROM RecibosProvi WHERE Recibo = '" & Trim(txtRecibo.Text) & "' AND (Tipo2 = '02' OR Tipo2 = '2') AND Estado2 <> 'P'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                _TodosPendientes = False
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _TodosPendientes
    End Function

    Private Sub txtRecibo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar("-")) = e.KeyChar And Not (CChar("/")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetGanancias.KeyPress, txtRetIB.KeyPress, txtRetIva.KeyPress, txtRetSuss.KeyPress, txtParidad.KeyPress, txtTotal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    'Private Sub gridRecibos_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridRecibos.MouseDoubleClick

    '    If gridRecibos.SelectedRows.Count > 0 Then

    '        If MsgBox("¿Desea eliminar la fila seleccionada?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
    '            Dim row As DataGridViewRow = gridRecibos.CurrentRow

    '            _ClavesCheques.RemoveAll(Function(_c) _c(0) = row.Cells(5).Value)

    '            gridRecibos.Rows.Remove(row)

    '            sumarValores()
    '        Else
    '            gridRecibos.ClearSelection()
    '        End If

    '    End If

    'End Sub

    Private Sub gridRecibos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridRecibos.CellClick
        With gridRecibos
            If e.ColumnIndex = 2 Then
                Dim _location As Point = .GetCellDisplayRectangle(2, e.RowIndex, False).Location

                .ClearSelection()
                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - 1.5
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - 3
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells(2).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With

    End Sub

    Private Sub gridRecibos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridRecibos.CellEnter
        With gridRecibos
            If e.ColumnIndex = 2 Then
                Dim _location As Point = .GetCellDisplayRectangle(2, e.RowIndex, False).Location

                .ClearSelection()
                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - 1.5
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - 3
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells(2).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With
    End Sub

    Private Sub _PrepararTablaIntereses(ByRef tabla As DataTable)
        ' Por defecto son de tipo String, asi que solamente defino explicitamente las de tipo Double.
        With tabla
            .Columns.Add("CodigoCliente")
            .Columns.Add("Cliente")
            .Columns.Add("Fecha")
            .Columns.Add("Numero")
            .Columns.Add("Fecha2")
            .Columns.Add("Banco")
            .Columns.Add("Importe").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Dias")
            .Columns.Add("Tasa")
            .Columns.Add("Intereses").DataType = System.Type.GetType("System.Double")
        End With
    End Sub

    Private Sub btnIntereses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntereses.Click
        Dim tabla = New DataTable("Detalles")
        Dim DiasTasa = ""
        Dim XTipo2, XNumero2, XFecha2, XBanco2, XImporte2 As String

        _PedirInformacion("Informe la tasa Mensual", New TextBox, DiasTasa)

        Dim ZZSuma As Double = 0
        Dim ZZCodigo As Double = 0

        Dim FechaBase As String = txtFecha.Text

        Dim row As DataRow
        Dim crdoc As ReportDocument
        crdoc = New InformeIntereses

        ' Creo las Columnas
        _PrepararTablaIntereses(tabla)

        ' Lleno la tabla con la informacion del Recibo.
        For i = 0 To gridRecibos.Rows.Count - 1

            With gridRecibos.Rows(i)

                XTipo2 = .Cells(0).Value
                XNumero2 = ceros(.Cells(1).Value, 8)
                If Val(XNumero2) = 0 Then
                    XNumero2 = ""
                End If
                XFecha2 = .Cells(2).Value
                XBanco2 = .Cells(3).Value
                XImporte2 = .Cells(4).Value

                If Val(XImporte2) <> 0 Then

                    XImporte2 = _NormalizarNumero(XImporte2)
                    DiasTasa = _NormalizarNumero(DiasTasa)

                    If XFecha2 = "" Then
                        XFecha2 = txtFecha.Text
                    End If
                    Dim WFechaCheque As String = String.Join("", XFecha2.Split("/").Reverse())
                    Dim WFechaRecibo As String = String.Join("", txtFecha.Text.Split("/").Reverse())
                    If Val(WFechaCheque) < Val(WFechaRecibo) Then
                        XFecha2 = txtFecha.Text
                    End If
                    Dim XDias2 As Integer = DateDiff("d", FechaBase, XFecha2)
                    Dim ZZInteres As Double = ((Val(XImporte2) * XDias2 * (Val(DiasTasa) / 100)) / 365)
                    ZZInteres = Val(_NormalizarNumero(ZZInteres))
                    ZZSuma = ZZSuma + ZZInteres

                    row = tabla.NewRow()

                    row.Item("CodigoCliente") = txtCliente.Text
                    row.Item("Cliente") = txtNombre.Text
                    row.Item("Fecha") = txtFecha.Text
                    row.Item("Numero") = XNumero2
                    row.Item("Fecha2") = XFecha2
                    row.Item("Banco") = XBanco2
                    row.Item("Importe") = Val(_NormalizarNumero(XImporte2))
                    row.Item("Dias") = XDias2
                    row.Item("Tasa") = _NormalizarNumero(DiasTasa)
                    row.Item("Intereses") = Val(_NormalizarNumero(ZZInteres))

                    tabla.Rows.Add(row)
                End If

            End With

        Next

        crdoc.SetDataSource(tabla)

        MsgBox("El interes a pagar es de " + Str$(ZZSuma), MsgBoxStyle.Information, "Emision de Recibos")

        '_Imprimir(crdoc)
        _VistaPrevia(crdoc)
    End Sub

    Private Sub _Imprimir(ByVal crdoc As ReportDocument, Optional ByVal cant As Integer = 1)
        crdoc.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Private Sub _VistaPrevia(ByVal crdoc As ReportDocument)
        With VistaPrevia
            .Reporte = crdoc
            .Mostrar()
        End With
    End Sub

    Private Sub gridRecibos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridRecibos.RowHeaderMouseDoubleClick
        If gridRecibos.SelectedRows.Count > 0 Then

            If MsgBox("¿Desea eliminar la fila seleccionada?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Dim row As DataGridViewRow = gridRecibos.CurrentRow

                _ClavesCheques.RemoveAll(Function(_c) _c(1) = row.Cells("ClaveCheque").Value)

                gridRecibos.Rows.Remove(row)

                If gridRecibos.RowCount = 0 Then
                    gridRecibos.Rows.Add()
                End If

                sumarValores()
            Else
                gridRecibos.ClearSelection()
            End If

        End If
    End Sub
End Class
