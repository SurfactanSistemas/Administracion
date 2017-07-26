Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class RecibosProvisorios

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
        commonEventsHandler.setIndexTab(Me)
        lstSeleccion.Items.Add(New QueryController("Clientes", AddressOf DAOCliente.buscarClientePorNombre, AddressOf mostrarCliente))
        lstSeleccion.SelectedIndex = 0

        btnLimpiar.PerformClick()
    End Sub

    Private Sub lstSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSeleccion.Click
        queryController = lstSeleccion.SelectedItem
        lstSeleccion.Visible = False
        lstConsulta.Visible = True
        txtConsulta.Visible = queryController.usesQueryText
        If txtConsulta.Visible Then
            lstConsulta.Height = 108
            lstConsulta.Top = 38
        Else
            lstConsulta.Height = lstSeleccion.Height
            lstConsulta.Top = lstSeleccion.Top
        End If
        lstConsulta.DataSource = queryController.query.Invoke("")
        txtConsulta.Focus()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        lstConsulta.Visible = False
        txtConsulta.Visible = False
        lstSeleccion.Visible = True
    End Sub

    Private Sub txtConsulta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsulta.KeyDown
        If e.KeyValue = Keys.Enter Then
            lstConsulta.DataSource = queryController.query.Invoke(txtConsulta.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click
        queryController.showMethod.Invoke(lstConsulta.SelectedValue)
        lstConsulta.Visible = False
        txtConsulta.Visible = False
        txtConsulta.Text = ""
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Cleanner.clean(Me)
        setDefaults()
    End Sub

    Private Sub setDefaults()
        For Each control As Control In Panel2.Controls

            If TypeOf (control) Is TextBox Then
                control.Text = ""
            End If

        Next
        gridRecibos.Rows.Clear()
        _ClavesCheques.Clear()
        _CuentasContables.Clear()
        txtConsulta.Visible = False
        lstConsulta.Visible = False
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtFecha.Focus()
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

        If numero.Contains(",") Then
            numero = String.Format("{0:F2}", CDbl(numero)).Replace(",", ".")
        ElseIf Not numero.Contains(".") Then
            numero &= ".00"
        End If

        Return numero
    End Function

    Private Function sumarValores() As Boolean
        Dim _Error As Boolean = False

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

    Private Sub txtRecibo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecibo.Leave

        If Trim(txtRecibo.Text) <> "" Then
            txtRecibo.Text = ceros(txtRecibo.Text, 6)
            mostrarRecibo(Trim(txtRecibo.Text))
        End If

    End Sub

    Private Sub mostrarRecibo(ByVal recibo As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM RecibosProvi WHERE Recibo = '" + recibo + "'")
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
                        txtRecibo.Text = dr.Item("Recibo")
                        txtFecha.Text = dr.Item("Fecha")
                        txtCliente.Text = dr.Item("Cliente")
                        Dim cliente As Cliente = DAOCliente.buscarClientePorCodigo(txtCliente.Text)
                        txtNombre.Text = cliente.razon
                        cliente = Nothing
                        txtRetGanancias.Text = _NormalizarNumero(dr.Item("RetGanancias"))
                        _ComprobanteRetGanancias = dr.Item("ComproGanan")
                        txtRetIva.Text = _NormalizarNumero(dr.Item("RetIva"))
                        _ComprobanteRetIva = dr.Item("ComproIva")
                        txtRetSuss.Text = _NormalizarNumero(dr.Item("RetSuss"))
                        _ComprobanteRetSuss = dr.Item("ComproSuss")
                        txtRetIB.Text = _NormalizarNumero(dr.Item("RetOtra"))
                        _RetIB1 = _NormalizarNumero(dr.Item("RetIb1"))
                        _CompIB1 = dr.Item("NroRetIb1")
                        _RetIB2 = _NormalizarNumero(dr.Item("RetIb2"))
                        _CompIB2 = dr.Item("NroRetIb2")
                        _RetIB3 = _NormalizarNumero(dr.Item("RetIb3"))
                        _CompIB3 = dr.Item("NroRetIb3")
                        _RetIB4 = _NormalizarNumero(dr.Item("RetIb4"))
                        _CompIB4 = dr.Item("NroRetIb4")
                        _RetIB5 = _NormalizarNumero(dr.Item("RetIb5"))
                        _CompIB5 = dr.Item("NroRetIb5")
                        _RetIB6 = _NormalizarNumero(dr.Item("RetIb6"))
                        _CompIB6 = dr.Item("NroRetIb6")
                        _RetIB7 = _NormalizarNumero(dr.Item("RetIb7"))
                        _CompIB7 = dr.Item("NroRetIb7")
                        _RetIB8 = _NormalizarNumero(dr.Item("RetIb8"))
                        _CompIB8 = dr.Item("NroRetIb8")
                        txtTotal.Text = _NormalizarNumero(dr.Item("Importe"))
                    End If

                    Dim _FormaPagoActual As Integer = gridRecibos.Rows.Add()

                    With gridRecibos.Rows(_FormaPagoActual)
                        .Cells(0).Value = dr.Item("Tipo2")
                        .Cells(1).Value = dr.Item("Numero2")
                        .Cells(2).Value = dr.Item("Fecha2")
                        .Cells(3).Value = dr.Item("banco2")
                        .Cells(4).Value = _NormalizarNumero(dr.Item("Importe2"))
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
                            _CuentasContables.Add({Val(.Item("Renglon")), .Item("Cuenta")})
                        End With
                    End If

                Loop

                sumarValores()
            Else
                txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
                txtFecha.Focus()
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
        Dim proximo As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Recibo FROM RecibosProvi ORDER BY Recibo DESC")
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
        Dim _tipoRec As Integer = 0

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
        validador.alsoValidate(DAORecibo.permiteActualizacionProvisorio(txtRecibo.Text), "Ya existe un recibo provisorio con ese número y no se puede modificar")
        validador.alsoValidate(DAORecibo.existeRecibo(txtRecibo.Text), "Ya existe un recibo definitivo con ese número")

        If validador.flush Then

            If optCtaCte.Checked Then
                _tipoRec = 1
            ElseIf optAnticipos.Checked Then
                _tipoRec = 2
            Else
                _tipoRec = 3
            End If

            DAORecibo.eliminarReciboProvisorio(txtRecibo.Text)

            DAORecibo.agregarReciboProvisorio(txtRecibo.Text, txtFecha.Text, DAOCliente.buscarClientePorCodigo(txtCliente.Text), _
                _tipoRec, Val(_NormalizarNumero(txtRetGanancias.Text)), Val(_NormalizarNumero(txtRetIB.Text)), _
                Val(_NormalizarNumero(txtRetIva.Text)), Val(_NormalizarNumero(txtRetSuss.Text)), _
                0, Val(_NormalizarNumero(txtTotal.Text)), crearFormasPago(), _ComprobanteRetGanancias, _
                _ComprobanteRetIva, _ComprobanteRetSuss, Val(_NormalizarNumero(_RetIB1)), Val(_NormalizarNumero(_CompIB1)), _
                Val(_NormalizarNumero(_RetIB2)), Val(_NormalizarNumero(_CompIB2)), Val(_NormalizarNumero(_RetIB3)), _
                Val(_NormalizarNumero(_CompIB3)), Val(_NormalizarNumero(_RetIB4)), Val(_NormalizarNumero(_CompIB4)), _
                Val(_NormalizarNumero(_RetIB5)), Val(_NormalizarNumero(_CompIB5)), Val(_NormalizarNumero(_RetIB6)), _
                Val(_NormalizarNumero(_CompIB6)), Val(_NormalizarNumero(_RetIB7)), Val(_NormalizarNumero(_CompIB7)), Val(_NormalizarNumero(_RetIB8)), Val(_NormalizarNumero(_CompIB8)), _ClavesCheques)

            btnLimpiar.PerformClick()
        End If
    End Sub

    Private Function crearFormasPago() As List(Of FormaPago)
        Dim formasPago As New List(Of FormaPago)
        For Each row As DataGridViewRow In gridRecibos.Rows
            If Not row.IsNewRow Then
                formasPago.Add(New FormaPago(row.Cells(0).Value, 0, asString(row.Cells(1).Value), asString(row.Cells(2).Value), asString(row.Cells(3).Value), CustomConvert.toDoubleOrZero(row.Cells(4).Value)))
            End If
        Next
        Return formasPago
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

            With gridRecibos
                .Rows(0).Selected = True
                .CurrentCell = .Rows(0).Cells(0)
                .Focus()
            End With
        ElseIf e.KeyData = Keys.Escape Then
            txtTotal.Text = 0
        End If
    End Sub

    Private Sub txtRetIva_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIva.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIva.Text) > 0 Then
                _PedirInformacion("Ingrese el Número de Comprobante de Retención de IVA", txtRetIva, _ComprobanteRetIva)
            End If

            _SaltarA(txtRetSuss)
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
            txtRetGanancias.Text = 0
        End If
    End Sub

    Private Sub txtRetIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB.KeyDown
        If e.KeyData = Keys.Enter Then

            'Aca Mostrar en realidad la ventana con las opciones de IB

            _SaltarA(txtRetIva)
        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB.Text = 0
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

            _SaltarA(txtParidad)
        ElseIf e.KeyData = Keys.Escape Then
            txtRetSuss.Text = 0
        End If
    End Sub

    Private Sub txtParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtParidad.KeyDown
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtTotal)

        ElseIf e.KeyData = Keys.Escape Then
            txtParidad.Text = 0
        End If
    End Sub

    Private Sub txtRecibo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecibo.KeyDown
        If e.KeyData = Keys.Enter Then

            txtRecibo.Text = ceros(txtRecibo.Text, 6)
            mostrarRecibo(Trim(txtRecibo.Text))
            _SaltarA(txtFecha)

        ElseIf e.KeyData = Keys.Escape Then
            txtRecibo.Text = ""
        End If
    End Sub

    Private Sub _SaltarA(ByRef control As Control)
        control.Focus()
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim _f As String = txtFecha.Text

            _Normalizarfecha(_f)

            txtFecha.Text = _f

            If Trim(txtFecha.Text) <> "" Then
                _DeterminarParidad()
            End If

            _SaltarA(txtCliente)

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub _DeterminarParidad(Optional ByVal fecha As String = "")
        Dim _Fecha As String = IIf(fecha = "", txtFecha.Text, fecha)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cambio FROM Cambios WHERE Fecha = '" & _Fecha & "'")
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

            .txtRetIB1.Text = _RetIB1
            .txtCompIB1.Text = _CompIB1
            .txtRetIB2.Text = _RetIB2
            .txtCompIB2.Text = _CompIB2
            .txtRetIB3.Text = _RetIB3
            .txtCompIB3.Text = _CompIB3
            .txtRetIB4.Text = _RetIB4
            .txtCompIB4.Text = _CompIB4
            .txtRetIB5.Text = _RetIB5
            .txtCompIB5.Text = _CompIB5
            .txtRetIB6.Text = _RetIB6
            .txtCompIB6.Text = _CompIB6
            .txtRetIB7.Text = _RetIB7
            .txtCompIB7.Text = _CompIB7
            .txtRetIB8.Text = _RetIB8
            .txtCompIB8.Text = _CompIB8

            .ShowDialog(Me)

            _RetIB1 = .txtRetIB1.Text
            _CompIB1 = .txtCompIB1.Text
            _RetIB2 = .txtRetIB2.Text
            _CompIB2 = .txtCompIB2.Text
            _RetIB3 = .txtRetIB3.Text
            _CompIB3 = .txtCompIB3.Text
            _RetIB4 = .txtRetIB4.Text
            _CompIB4 = .txtCompIB4.Text
            _RetIB5 = .txtRetIB5.Text
            _CompIB5 = .txtCompIB5.Text
            _RetIB6 = .txtRetIB6.Text
            _CompIB6 = .txtCompIB6.Text
            _RetIB7 = .txtRetIB7.Text
            _CompIB7 = .txtCompIB7.Text
            _RetIB8 = .txtRetIB8.Text
            _CompIB8 = .txtCompIB8.Text

            .Dispose()

        End With

        _RecalcularRetIB()

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

        txtRetIB.Text = totalIB
    End Sub

    Private Sub txtRetGanancias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetGanancias.Leave

        If txtRetGanancias.Text = "" Then
            txtRetGanancias.Text = 0
        End If

        sumarValores()
    End Sub

    Private Sub txtRetIB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIB.Leave
        If txtRetIB.Text = "" Then
            txtRetIB.Text = 0
        End If

        sumarValores()
    End Sub

    Private Sub txtRetIva_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIva.Leave
        If txtRetIva.Text = "" Then
            txtRetIva.Text = 0
        End If

        sumarValores()
    End Sub

    Private Sub txtRetSuss_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetSuss.Leave
        If txtRetSuss.Text = "" Then
            txtRetSuss.Text = 0
        End If

        sumarValores()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If gridRecibos.Focused Or gridRecibos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            gridRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = gridRecibos.CurrentCell.ColumnIndex
            Dim iRow = gridRecibos.CurrentCell.RowIndex

            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = gridRecibos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then


                        If Trim(valor.ToString.Length) = 31 Then
                            If _ProcesarCheque(iRow, valor) Then
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 2) ' Nos desplazamos para que coloque la fecha del cheque.
                            End If
                        Else
                            valor = valor.ToString().Substring(valor.ToString.Length - 1, 1)
                            If valor = "1" Or valor = "2" Or valor = "3" Or valor = "4" Then
                                eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(valor), iRow, iCol)
                            Else ' Sólo se aceptan los valores 1 (Efectivo) , 2 (Cheque), 3 (Doc) y 4 (Varios) ?
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol)
                            End If
                        End If

                    Else

                        'Modificar el valor de la columna de ser fecha DD/MM --> DD/MM/YYYY (año actual)
                        If iCol = 2 Then

                            If _Normalizarfecha(valor) Then
                                gridRecibos.Rows(iRow).Cells(2).Value = valor
                                gridRecibos.EndEdit()
                            End If

                        End If

                        If iCol = 1 Or iCol = 2 Or iCol = 3 Then ' Avanzamos a la siguiente celda continua.

                            If iCol = 2 Then
                                If _ChequeVencido(valor) Then
                                    MsgBox("La fecha del cheque introducida es inválida", MsgBoxStyle.Critical)
                                    gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol)
                                Else
                                    gridRecibos.Rows(iRow).Cells(iCol).Value = valor
                                    gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)
                                End If
                            ElseIf iCol = 3 Then
                                gridRecibos.Rows(iRow).Cells(iCol).Value = _GenerarCodigoBanco(valor)
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)
                            Else
                                gridRecibos.CurrentCell = gridRecibos.Rows(iRow).Cells(iCol + 1)
                            End If

                        End If

                        If iCol = 4 Then ' Avanzamos a la fila siguiente.
                            If Val(gridRecibos.Rows(iRow).Cells(0).Value) = 4 Then
                                _PedirCuentaContable(iRow)
                            ElseIf Val(gridRecibos.Rows(iRow).Cells(0).Value) = 2 Then
                                _PedirClaveCheque(iRow)
                            End If

                            gridRecibos.CurrentCell = gridRecibos.Rows(iRow + 1).Cells(0)
                            sumarValores()
                        End If
                    End If

                    Return True

                End If
            ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                gridRecibos.Rows.Remove(gridRecibos.Rows(iRow))
                _CuentasContables.RemoveAll(Function(c) c(0) = iRow)
                _ClavesCheques.RemoveAll(Function(c) c(0) = iRow)
                sumarValores()
            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function _ObtenerNombreBanco(ByVal claveBanco As String) As String
        Dim _NombreBanco As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Nombre FROM BCRA WHERE Banco = '" & Val(claveBanco) & "'")
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
        Dim _LecturaCorrecta As Boolean = True

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

        With gridRecibos.Rows(row)
            .Cells(0).Value = "02"
            .Cells(1).Value = _NumCheque
            .Cells(2).Value = ""
            .Cells(3).Value = _GenerarCodigoBanco(_Banco)
        End With
        ' Buscamos si existe el cuit.
        _Cuit = _TraerNumeroCuit(_ClaveBanco & _Sucursal & _NumCta)

        ' Guardamos el nuevo Cheque.
        _GuardarNuevoCheque(row, ClaveCheque, _Banco, _Sucursal, _NumCheque, _NumCta, _Cuit)

        Return _LecturaCorrecta
    End Function

    Private Function _GenerarCodigoBanco(ByVal _Banco As String) As String
        _Banco = _Banco.ToString.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

        Return _Banco & "/" & Mid(txtCliente.Text, 1, 1) & Val(Mid(txtCliente.Text, 2, 6)).ToString()
    End Function

    Private Function _ChequeYaCargado(ByVal ClaveCheque) As Boolean
        Dim _cargado As Boolean = False

        If _ChequeUtilizadoEnRecibo(ClaveCheque) Then

            _cargado = True

        ElseIf Not _ChequeUtilizadoEnReciboProvisorio(ClaveCheque) Then

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
        Dim utilizado As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 ClaveCheque FROM Recibos WHERE ClaveCheque = '" & ClaveCheque & "'")
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
        Dim utilizado As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 ClaveCheque FROM RecibosProvi WHERE ClaveCheque = '" & ClaveCheque & "'")
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
        Dim _cuit As String = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cuit FROM Cuit WHERE Clave = '" & Trim(clave) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                _cuit = dr.Item("Cuit")

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

        _ClavesCheques.Add({row, Clave, banco, sucursal, numCheque, numCta, _Cuit, "", ""})

    End Sub

    Private Function _Normalizarfecha(ByRef fecha As String) As Boolean
        Dim _FechaValida As Boolean = True
        Dim _Fecha As String() = fecha.Split("/")

        Try
            _Fecha(0) = Val(_Fecha(0)).ToString()
            _Fecha(1) = Val(_Fecha(1)).ToString()
            _Fecha(2) = Val(_Fecha(2)).ToString()

            fecha = String.Join("/", _Fecha)

            fecha = Date.ParseExact(fecha, "d/M/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("dd/MM/yyyy")
        Catch ex As Exception
            _FechaValida = False
            MsgBox("El formato de la fecha ingresada no es válido.", MsgBoxStyle.Information)
        End Try

        Return _FechaValida
    End Function

    Private Sub _PedirCuentaContable(ByVal row As Integer)
        Dim cuenta As String
        Dim buscar As Object

        cuenta = ""
        buscar = _CuentasContables.FindLast(Function(c) c(0) = row)

        If Not IsNothing(buscar) Then
            cuenta = buscar(1)
            _PedirInformacion("Ingrese Cuenta Contable", New TextBox(), cuenta)
            If cuenta = "" Then : Exit Sub : End If
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
            If _cuit.Length = 11 Then : Exit Sub : End If
        End If

        Do While Not _cuit.Length = 11

            _PedirInformacion("Ingrese Cuit del Firmante", New TextBox(), _cuit)

        Loop

        _clave = ""
        _banco = ""
        _sucursal = ""
        _cheque = ""
        _cuenta = ""
        _estado = ""
        _destino = ""

        _ClavesCheques.Add({row, _clave, _banco, _sucursal, _cheque, _cuenta, _cuit, _estado, _destino})

    End Sub

    Private Function _CuentaContableValida(ByRef cuenta As String)
        Dim _CuentaValida As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cuenta FROM Cuenta WHERE Cuenta= '" & Trim(cuenta) & "'")
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
        e.Cancel = Proceso._ValidarFecha(txtFecha.Text, e.IsValidInput)
    End Sub
End Class