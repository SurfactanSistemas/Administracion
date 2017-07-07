Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class Pagos

    Dim queryController As QueryController
    Dim pagos As New List(Of DetalleCompraCuentaCorriente)
    Dim cheques As New List(Of Cheque)
    Dim chequeRow As Integer = -1
    Dim bancoOrden As Banco
    Dim proveedorOrden As Proveedor
    Dim commonEventHandler As New CommonEventsHandler
    Dim _ClavesCheques As New List(Of Object)
    Dim _Carpetas As New List(Of Object)
    Dim _Claves As New List(Of Object)
    Dim _TipoConsulta As Integer = Nothing

    Private Sub Pagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim gridPagosBuilder As New GridBuilder(gridPagos)
        gridPagosBuilder.addTextColumn(0, "Tipo")
        gridPagosBuilder.addTextColumn(1, "Letra")
        gridPagosBuilder.addTextColumn(2, "Punto")
        gridPagosBuilder.addTextColumn(3, "Número")
        gridPagosBuilder.addTextColumn(4, "Importe")
        gridPagosBuilder.addTextColumn(5, "Descripción")

        Dim gridFormasBuilder As New GridBuilder(gridFormaPagos)
        gridFormasBuilder.addTextColumn(0, "Tipo", False)
        gridFormasBuilder.addTextColumn(1, "Número")
        gridFormasBuilder.addTextColumn(2, "Fecha")
        gridFormasBuilder.addTextColumn(3, "Banco")
        gridFormasBuilder.addTextColumn(4, "Nombre")
        gridFormasBuilder.addTextColumn(5, "Importe")

        commonEventHandler.setIndexTab(Me)
        btnLimpiar.PerformClick()
    End Sub

    Private Sub _AlinearColumnas()
        With gridPagos
            _AlinearDerecha(.Columns(0))
            _AlinearDerecha(.Columns(2))
            _AlinearDerecha(.Columns(3))
            _AlinearDerecha(.Columns(4))
        End With

        With gridFormaPagos
            _AlinearDerecha(.Columns(0))
            _AlinearDerecha(.Columns(2))
            _AlinearDerecha(.Columns(1))
            _AlinearDerecha(.Columns(5))
        End With
    End Sub

    Private Sub _AlinearDerecha(ByRef columna As DataGridViewColumn)
        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Function validarDatos() As Boolean
        Dim validador As New Validator

        validador.validate(Me)
        validador.alsoValidate(consistenciaEntreProveedorYGrillas(), "Algunos campos de las grillas no coinciden con el proveedor que se desea grabar")
        validador.alsoValidate(bancosValidos(), "Algunos campos de la grilla de forma de pagos no tienen un banco válido asignado")
        validador.alsoValidate(noHayDiferencia(), "Hay una diferencia de " & lblDiferencia.Text)
        validador.alsoValidate(hayMovimientos(), "No se registró ningún pago")
        validador.alsoValidate(CustomConvert.toIntOrZero(txtOrdenPago.Text) = 0, "No se puede hacer el alta, el registro ya existe")

        Return validador.flush
    End Function

    Private Function hayMovimientos()
        Return CustomConvert.toDoubleOrZero(lblPagos.Text) <> 0
    End Function

    Private Function noHayDiferencia()
        Return CustomConvert.toDoubleOrZero(lblDiferencia.Text) = 0
    End Function

    Private Function bancosValidos()
        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow And row.Cells(0).Value = "02" Then
                Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(row.Cells(3).Value)
                If IsNothing(banco) Then : Return False : End If
            End If
        Next
        Return True
    End Function

    Private Function consistenciaEntreProveedorYGrillas()
        Return pagos.All(Function(cuenta) cuenta.proveedor.id = txtProveedor.Text)
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtObservaciones_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If gridPagos.Rows.Count = 0 Then
            lstSeleccion.SelectedIndex = 1
            lstSeleccion_Click(Nothing, Nothing)
        Else
            gridPagos.CurrentCell = gridPagos.Rows(0).Cells(4)
            gridPagos.Select()
            gridPagos.Focus()
        End If
    End Sub

    Private Function cuentasCorrientesDelProveedorActual()
        Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
        If IsNothing(proveedor) Then
            Return New List(Of CtaCteProveedor)
        Else
            Return DAOCtaCteProveedor.cuentasSinSaldar(proveedor)
        End If
    End Function

    Private Sub mostrarCuentaCorriente(ByVal cuenta As DetalleCompraCuentaCorriente)
        If (LTrim(txtParidad.Text) = "") Then
            MessageBox.Show("No hay paridad informada")
        Else
            If pagos.Any(Function(pagoExistente) cuenta.igualA(pagoExistente)) Then
                Exit Sub
            End If
            pagos.Add(cuenta)
            gridPagos.Rows.Add(cuenta.tipo, cuenta.letra, cuenta.punto, cuenta.numero, CustomConvert.toStringWithTwoDecimalPlaces(cuenta.saldo), "Pago Factura Nro " & CustomConvert.toIntOrZero(cuenta.numero))

            If cuenta.esClausulaDolar Then
                generarNota(cuenta)
            End If
        End If
    End Sub

    Private Sub generarNota(ByVal cuenta As DetalleCompraCuentaCorriente)
        Dim resto As Double

        resto = (cuenta.montoDolar() * CustomConvert.toStringWithTwoDecimalPlaces(txtParidad.Text)) - CustomConvert.toStringWithTwoDecimalPlaces(cuenta.saldo)



        Select Case resto
            Case Is < 0
                gridPagos.Rows.Add("03", cuenta.letra, cuenta.punto, "99999999", CustomConvert.toStringWithTwoDecimalPlaces(resto), "N/C por Diferencia de Cambio")
            Case Is > 0
                gridPagos.Rows.Add("02", cuenta.letra, cuenta.punto, "99999999", CustomConvert.toStringWithTwoDecimalPlaces(resto), "N/D por Diferencia de Cambio")
            Case Else
                'ENTRA ACA SI ES IGUAL A CERO Y NO SE DEBE HACER NADA'
        End Select

    End Sub

    Private Sub mostrarOrdenDePago(ByVal orden As OrdenPago)
        If IsNothing(orden) Then : Exit Sub : End If
        'btnLimpiar.PerformClick()
        txtOrdenPago.Text = orden.nroOrden
        txtFecha.Text = orden.fecha
        txtObservaciones.Text = orden.observaciones
        txtFechaParidad.Text = orden.fechaParidad
        mostrarProveedor(orden.proveedor)
        mostrarBanco(orden.banco)
        txtGanancias.Text = CustomConvert.toStringWithTwoDecimalPlaces(orden.retGanancias)
        txtIBCiudad.Text = CustomConvert.toStringWithTwoDecimalPlaces(orden.retIBCiudad)
        txtIngresosBrutos.Text = CustomConvert.toStringWithTwoDecimalPlaces(orden.retIB)
        txtIVA.Text = CustomConvert.toStringWithTwoDecimalPlaces(orden.retIVA)
        mostrarPagos(orden.pagos)
        mostrarFormaPagos(orden.formaPagos)
        mostrarTipo(orden.tipo)
        txtParidad.Text = orden.paridad
    End Sub

    Private Sub mostrarTipo(ByVal tipo As Integer)
        Select Case tipo
            Case 1
                optCtaCte.Checked = True
            Case 3
                optChequeRechazado.Checked = True
            Case 4
                optAnticipos.Checked = True
            Case 5
                optTransferencias.Checked = True
            Case Else
                optVarios.Checked = True
        End Select
    End Sub

    Private Sub mostrarPagos(ByVal pagos As List(Of Pago))
        gridPagos.Rows.Clear()
        For Each pago As Pago In pagos
            gridPagos.Rows.Add(pago.tipo, pago.letra, pago.punto, pago.numero, pago.importe, pago.descripcion)
        Next
        sumarImportes()
    End Sub

    Private Sub mostrarFormaPagos(ByVal formaPagos As List(Of FormaPago))
        gridFormaPagos.Rows.Clear()
        For Each formaPago As FormaPago In formaPagos
            gridFormaPagos.Rows.Add(formaPago.tipo, formaPago.numero, formaPago.fecha, formaPago.banco, formaPago.nombre, formaPago.importe)
        Next
        sumarImportes()
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        If IsNothing(proveedor) Then : Exit Sub : End If
        txtProveedor.Text = proveedor.id
        txtRazonSocial.Text = proveedor.razonSocial
    End Sub

    Private Sub mostrarBanco(ByVal banco As Banco)
        If IsNothing(banco) Then : Exit Sub : End If
        txtBanco.Text = banco.id
        txtNombreBanco.Text = banco.nombre
    End Sub

    Private Sub mostrarCuentaContable(ByVal cuenta As CuentaContable)
        'TODO
    End Sub

    Private Sub mostrarCheque(ByVal cheque As Cheque)
        If cheques.Any(Function(chequeExistente) cheque.igualA(chequeExistente)) Then
            chequeRow = -1
            gridFormaPagos.Select()
            Exit Sub
        End If
        cheques.Add(cheque)
        If chequeRow <> -1 Then
            gridFormaPagos.Rows(chequeRow).Cells(0).Value = "03"
            gridFormaPagos.Rows(chequeRow).Cells(1).Value = cheque.numero
            gridFormaPagos.Rows(chequeRow).Cells(2).Value = cheque.fecha
            gridFormaPagos.Rows(chequeRow).Cells(3).Value = ""
            gridFormaPagos.Rows(chequeRow).Cells(4).Value = cheque.banco
            gridFormaPagos.Rows(chequeRow).Cells(5).Value = CustomConvert.toStringWithTwoDecimalPlaces(cheque.importe)
            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(chequeRow + 1).Cells(0)
            gridFormaPagos.Select()
            chequeRow = -1
        Else
            gridFormaPagos.Rows.Add("03", cheque.numero, cheque.fecha, "", cheque.banco, CustomConvert.toStringWithTwoDecimalPlaces(cheque.importe))
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Trim(txtProveedor.Text) = "" Then
                _TipoConsulta = 0
                _ListarProveedores()
                Exit Sub
            End If

            txtProveedor.Text = txtProveedor.Text

            Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)

            If Not IsNothing(proveedor) Then
                mostrarProveedor(proveedor)
                txtObservaciones.Focus()
            Else
                txtRazonSocial.Text = ""
                MessageBox.Show("El proveedor ingresado es inexistente")
                txtProveedor.Focus()
            End If

        End If
    End Sub

    Private Sub txtBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBanco.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Trim(txtBanco.Text) = "" Then
                _TipoConsulta = 1
                _ListarCuentasContables()
                Exit Sub
            End If

            Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)
            If Not IsNothing(banco) Then
                mostrarBanco(banco)
                txtFechaParidad.Focus()
            Else
                MsgBox("Código de Banco incorrecto.", MsgBoxStyle.Information)
                txtBanco.Focus()
            End If
        End If
    End Sub

    Private Sub _InhabilitarConsulta()
        txtConsulta.Text = ""
        txtConsulta.Visible = False
        lstSeleccion.Visible = True
        lstConsulta.Visible = False
        CLBFiltrado.Visible = False
    End Sub

    Private Sub _HabilitarConsulta()
        txtConsulta.Visible = True
        lstSeleccion.Visible = False
        lstConsulta.Visible = True
        CLBFiltrado.Visible = False
        txtConsulta.Text = ""
        txtConsulta.Focus()
    End Sub

    Private Function _TraerCambioDivisa(ByVal fecha As String) As String
        Dim _CambioDivisa As String = "0"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT CambioDivisa FROM Cambios WHERE Fecha = '" & fecha & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr

                If .HasRows Then
                    .Read()

                    If Not IsDBNull(.Item("CambioDivisa")) Then
                        _CambioDivisa = .Item("CambioDivisa").ToString()
                    End If

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _CambioDivisa
    End Function

    Private Sub _ListarCtasCtes()
        Dim XClaves As New List(Of Object)
        Dim _Item As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT cp.NroInterno, cp.Total, cp.Saldo, cp.Impre, cp.Letra, cp.Punto, " _
                                              & "cp.Numero, cp.Fecha, cp.Clave, ivc.Paridad, ivc.Pago FROM CtaCtePrv as cp, IvaComp as ivc WHERE cp.Proveedor = '" _
                                              & Trim(txtProveedor.Text) & "' and cp.Saldo <> 0 AND cp.NroInterno = ivc.NroInterno ORDER BY cp.OrdFecha ASC")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            lstConsulta.Items.Clear()

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    XClaves.Clear()

                    Do While .Read()
                        Dim XNroInterno, XTotal, XSaldo, XSaldoUS, XImpre, XLetra, XPunto, XNumero, XFecha, XClave, XParidad, XPago, XParidadTotal As String

                        XNroInterno = .Item("NroInterno").ToString()
                        XTotal = _NormalizarNumero(.Item("Total").ToString())
                        XSaldo = _NormalizarNumero(.Item("Saldo").ToString())
                        XSaldoUS = 0
                        XParidadTotal = 0
                        XImpre = .Item("Impre").ToString()
                        XLetra = .Item("Letra").ToString()
                        XPunto = .Item("Punto").ToString()
                        XNumero = .Item("Numero").ToString()
                        XFecha = .Item("Fecha").ToString()
                        XClave = .Item("Clave").ToString()
                        XParidad = _NormalizarNumero(.Item("Paridad").ToString())
                        XPago = .Item("Pago").ToString()

                        If Val(XPago) <> 2 Then


                            If Val(XParidad) <> 0 Then
                                XParidadTotal = _TraerCambioDivisa(txtFechaParidad.Text)

                                XSaldoUS = (Val(XSaldo) / Val(XParidad)) * Val(XParidadTotal)
                            End If

                        End If


                        If Val(XSaldoUS) = 0 Then
                            XSaldoUS = ""
                        End If
                        _Item = XImpre & "    " & XLetra & "    " & XPunto & "    " & XNumero & "    " & XFecha & "    " & XSaldo & "    " & XSaldoUS

                        lstConsulta.Items.Add(_Item)

                        XClaves.Add({_Item, .Item("Clave").ToString()})
                    Loop

                    _Claves = XClaves

                    _HabilitarConsulta()
                Else
                    _InhabilitarConsulta()
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _ListarProveedores()
        Dim XClaves As New List(Of Object)
        Dim _Item As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Proveedor, Nombre FROM Proveedor ORDER BY Nombre")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            lstConsulta.Items.Clear()

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()
                        _Item = ceros(.Item("Proveedor"), 11) & "    " & .Item("Nombre")
                        lstConsulta.Items.Add(_Item)
                        XClaves.Add({_Item, ceros(.Item("Proveedor"), 11)})
                    Loop

                    _Claves = XClaves

                    _HabilitarConsulta()
                Else
                    _InhabilitarConsulta()
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Function _TraerChequesEnRecibos() As List(Of Object)
        Dim _ChequesRecibos As New List(Of Object)
        Dim itemTemplate As String = "#NUMERO#  #FECHA#  #IMPORTE#  #BANCO#"
        Dim item As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tiporeg, TipoReg, Estado2, Tipo2, Importe2, Numero2, " _
                                              & "Fecha2, Banco2, Clave, FechaOrd2 FROM Recibos WHERE " _
                                              & "TipoReg = '2' AND Estado2 <> 'X' AND Tipo2 = '02' " _
                                              & "ORDER BY FechaOrd2, Numero2")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero2"), 6)) _
                                            .Replace("#FECHA#", .Item("Fecha2")) _
                                            .Replace("#IMPORTE#", _NormalizarNumero(.Item("Importe2"))) _
                                            .Replace("#BANCO#", .Item("Banco2"))

                        _ChequesRecibos.Add({item, _
                                             "1" & .Item("Clave"), _
                                             IIf(Not IsDBNull(.Item("FechaOrd2")), .Item("FechaOrd2"), "") _
                                            })

                    Loop
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _ChequesRecibos
    End Function

    Private Function _TraerChequesEnRecibosProvisorios() As List(Of Object)
        Dim _ChequesRecibos As New List(Of Object)
        Dim itemTemplate As String = "#NUMERO#  #FECHA#  #IMPORTE#  #BANCO#"
        Dim item As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Tiporeg, TipoReg, Estado2, Tipo2, Importe2, Numero2, " _
                                              & "Fecha2, Banco2, Clave, FechaOrd2 FROM RecibosProvi WHERE " _
                                              & "TipoReg = '2' AND Estado2 = 'P' AND ReciboDefinitivo = '0' AND FechaOrd2 > '20080430'" _
                                              & "ORDER BY FechaOrd2, Numero2")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero2"), 6)) _
                                            .Replace("#FECHA#", .Item("Fecha2")) _
                                            .Replace("#IMPORTE#", _NormalizarNumero(.Item("Importe2"))) _
                                            .Replace("#BANCO#", .Item("Banco2"))

                        _ChequesRecibos.Add({item, _
                                             "2" & .Item("Clave"), _
                                             IIf(Not IsDBNull(.Item("FechaOrd2")), .Item("FechaOrd2"), ""), _
                                             ceros(.Item("Numero2"), 6), _
                                             .Item("Fecha2")
                                            })

                    Loop
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _ChequesRecibos
    End Function

    Private Sub _ListarChequesTerceros()
        Dim XClaves As New List(Of Object)
        Dim _ChequesRecibos As New List(Of Object)
        Dim _ChequesRecibosProvisorios As New List(Of Object)
        Dim _ChequesTotales As New List(Of Object)

        lstConsulta.Items.Clear()

        ' Traemos los cheques que se encuentran aun disponibles.
        _ChequesRecibos = _TraerChequesEnRecibos()
        _ChequesRecibosProvisorios = _TraerChequesEnRecibosProvisorios()

        ' Agrupamos todos los cheques
        _ChequesTotales.AddRange(_ChequesRecibos)
        _ChequesTotales.AddRange(_ChequesRecibosProvisorios)

        ' Los oredenamos de manera ASC
        _ChequesTotales.Sort(Function(a As Object, b As Object)
                                 Return Val(a(2)) < Val(b(2))
                             End Function)

        ' Lo colocamos en la lista.
        For Each _cheque As Object In _ChequesTotales
            lstConsulta.Items.Add(_cheque(0))
            XClaves.Add({_cheque(0), _cheque(1)})
        Next

        ' Guardamos las referencias.
        _Claves = XClaves

        If lstConsulta.Items.Count > 0 Then
            _HabilitarConsulta()
        Else
            _InhabilitarConsulta()
        End If

    End Sub

    Private Sub _ListarDocumentos()
        Dim itemTemplate As String = "#NUMERO#  #VENCIMIENTO#  #SALDO#  #CLIENTE#"
        Dim item As String = ""
        Dim XClaves As New List(Of Object)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave, Numero, Vencimiento1, Saldo, Cliente FROM CtaCte " _
                                              & "WHERE Tipo = '50' AND Saldo <> 0 AND Cliente <> '' ORDER BY Numero")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            lstConsulta.Items.Clear()

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero"), 6)) _
                                            .Replace("#VENCIMIENTO#", .Item("Vencimiento1")) _
                                            .Replace("#SALDO#", _NormalizarNumero(.Item("Saldo"))) _
                                            .Replace("#CLIENTE#", .Item("Cliente"))

                        lstConsulta.Items.Add(item)

                        XClaves.Add({item, .Item("Clave")})

                    Loop

                    _Claves = XClaves

                    _HabilitarConsulta()
                Else
                    MsgBox("No hay documentos disponibles para listar", MsgBoxStyle.Information)
                    _InhabilitarConsulta()
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _ListarCuentasContables()
        Dim XClaves As New List(Of Object)
        Dim _Item As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cuenta, Descripcion FROM Cuenta ORDER BY Cuenta")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            lstConsulta.Items.Clear()

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()
                        _Item = LSet(Trim(.Item("Cuenta")), 6) & "    " & Trim(.Item("Descripcion"))

                        lstConsulta.Items.Add(_Item)

                        XClaves.Add({_Item, .Item("Cuenta")})

                    Loop

                    _Claves = XClaves

                    _HabilitarConsulta()
                Else
                    _InhabilitarConsulta()
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub lstSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSeleccion.Click

        If Trim(lstSeleccion.SelectedItem) <> "" Then

            With lstSeleccion

                _TipoConsulta = .SelectedIndex

                Select Case .SelectedIndex
                    Case 0
                        _ListarProveedores()
                    Case 1
                        _ListarCtasCtes()
                    Case 2
                        _ListarChequesTerceros()
                    Case 3
                        _ListarDocumentos()
                    Case 4
                        _ListarCuentasContables()
                    Case Else
                End Select

            End With

            txtConsulta.Focus()

        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        lstConsulta.Visible = False
        txtConsulta.Visible = False
        lstSeleccion.Visible = True
    End Sub



    Private Function _ObtenerClaveConsulta(ByVal _Item As String) As String
        Dim clave As String = ""

        Try
            clave = _Claves.FindLast(Function(i) i(0) = _Item)(1)
        Catch ex As Exception

        End Try

        Return clave
    End Function

    Private Sub mostrarProveedor(ByVal _Item As String)
        Dim clave As String = ""
        Dim proveedor As Proveedor

        If Not IsNothing(_Claves) Then

            If _Claves.Count > 0 Then
                clave = _ObtenerClaveConsulta(_Item)
            End If

        End If

        If clave = "" Then
            Exit Sub
        End If

        proveedor = DAOProveedor.buscarProveedorPorCodigo(clave)

        If IsNothing(proveedor) Then
            Exit Sub
        End If

        mostrarProveedor(proveedor)

        _InhabilitarConsulta()
        lstSeleccion.Visible = False
        txtObservaciones.Focus()
    End Sub

    Private Sub _TraerCtaCte(ByVal _Item As String, Optional ByVal indice As Integer = Nothing)
        Dim XClave As String = ""

        If IsNothing(_Claves) Then
            Exit Sub
        End If

        If _Claves.Count = 0 Then
            Exit Sub
        End If

        XClave = _ObtenerClaveConsulta(_Item)

        ' Comprobamos que no se haya utilizado antes.
        If _CtaCteYaUtilizada(XClave) Then
            MsgBox("La Cta Cte indicada ya se encuentra en utilización.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Comprobamos que aun haya lugar para seguir cancelando Facturas.
        If gridPagos.Rows.Count > 15 Then
            MsgBox("La cantidad de facturas a cancelar supera las 15", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Procesamos la Cta Cte seleccionada.
        _ProcesarCtaCte(XClave)


        If Not IsNothing(indice) Then
            lstConsulta.Items(indice) = ""
        End If


    End Sub

    Private Function _CtaCteYaUtilizada(ByVal XClave As String) As Boolean
        Dim utilizada As Boolean = False

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                Dim RClave As String = ceros(txtProveedor.Text, 11) & .Cells(1).Value _
                                       & .Cells(0).Value & .Cells(2).Value & .Cells(3).Value

                If XClave = RClave Then

                    utilizada = True

                    Exit For

                End If


            End With
        Next

        Return utilizada
    End Function

    Private Sub _ProcesarCtaCte(ByVal clave As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT cp.Tipo, cp.NroInterno, cp.Total, cp.Saldo, cp.Impre, cp.Letra, cp.Punto, " _
                                              & "cp.Numero, cp.Fecha, cp.Clave, ivc.Paridad, ivc.Pago FROM CtaCtePrv as cp, IvaComp as ivc WHERE cp.Proveedor = '" _
                                              & Trim(txtProveedor.Text) & "' and cp.Clave = '" & clave & "' and cp.Saldo <> 0 AND cp.NroInterno = ivc.NroInterno ORDER BY cp.OrdFecha DESC")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    Dim XTipo, XNroInterno, XTotal, XSaldo, XSaldoUS, XImpre, XLetra, XPunto, XNumero, XFecha, XClave, XParidad, XPago, XParidadTotal As String
                    Dim XRow As Integer = gridPagos.Rows.Add()

                    XTipo = .Item("Tipo").ToString()
                    XNroInterno = .Item("NroInterno").ToString()
                    XTotal = _NormalizarNumero(.Item("Total").ToString())
                    XSaldo = _NormalizarNumero(.Item("Saldo").ToString())
                    
                    XImpre = .Item("Impre").ToString()
                    XLetra = .Item("Letra").ToString()
                    XPunto = .Item("Punto").ToString()
                    XNumero = .Item("Numero").ToString()

                    XSaldoUS = 0
                    XParidadTotal = 0
                    XParidad = _NormalizarNumero(.Item("Paridad").ToString())
                    XPago = .Item("Pago").ToString()

                    With gridPagos.Rows(XRow)
                        .Cells(0).Value = XTipo
                        .Cells(1).Value = XLetra
                        .Cells(2).Value = XPunto
                        .Cells(3).Value = XNumero
                        .Cells(4).Value = XSaldo

                        Select Case Val(XTipo)
                            Case 1
                                .Cells(5).Value = "Pago Factura nro. " & XNumero
                            Case 2
                                .Cells(5).Value = "Pago Nota de Debito nro. " & XNumero
                            Case 3
                                .Cells(5).Value = "Pago Nota de Credito nro. " & XNumero
                            Case 5
                                .Cells(5).Value = "Anticipo nro. " & XNumero
                            Case Else
                                .Cells(5).Value = ""
                        End Select

                    End With

                    If Val(XPago) = 2 Then

                        If Val(XParidad) <> 0 Then
                            XParidadTotal = _TraerCambioDivisa(txtFechaParidad.Text)

                            XSaldoUS = (Val(XSaldo) / Val(XParidad)) * Val(XParidadTotal)

                            Dim diferencia As String = XSaldoUS - XSaldo

                            ' Si hay diferencia se agrega una ND.
                            If Val(diferencia) <> 0 Then

                                XRow = gridPagos.Rows.Add()

                                With gridPagos.Rows(XRow)

                                    .Cells(0).Value = IIf(Val(diferencia) > 0, "02", "03")
                                    .Cells(1).Value = XLetra
                                    .Cells(2).Value = XPunto
                                    .Cells(3).Value = "99999999"
                                    .Cells(4).Value = _NormalizarNumero(diferencia)
                                    .Cells(5).Value = "N/D por Diferencia de Cambio "

                                End With

                            End If
                            
                        End If

                    End If

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub _TraerChequeDeTercero(ByVal _Item As String, Optional ByVal indice As Integer = Nothing)
        Dim XClave As String = ""

        ' Comprobamos que aun haya lugar para seguir cancelando Facturas.
        If gridFormaPagos.Rows.Count > 15 Then
            MsgBox("La cantidad de facturas a cancelar supera las 15", MsgBoxStyle.Information)
            Exit Sub
        End If

        If _Claves.Count = 0 Then
            Exit Sub
        End If

        XClave = _ObtenerClaveConsulta(_Item)

        If XClave = "" Then
            Exit Sub
        End If

        If _ChequeYaUtilizado(XClave) Then
            Exit Sub
        End If

        _ProcesarChequeTercero(XClave, indice)

    End Sub

    Private Function _ChequeYaUtilizado(ByVal XClave As String) As Boolean
        Dim utilizada As Boolean = False

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            With row
                Dim RClave As String = .Cells(6).Value

                If XClave = RClave Then

                    utilizada = True

                    Exit For

                End If

            End With
        Next

        Return utilizada
    End Function

    Private Sub _ProcesarChequeTercero(ByVal clave As String, Optional ByVal indice As Integer = Nothing)
        Dim ZSql As String = "SELECT Numero2, Fecha2, Banco2, Importe2, Cuit FROM #TABLA# WHERE Clave = '" & Mid(clave, 2, 8) & "'"
        Dim Tabla As String = "Recibos"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        If Mid(clave, 1, 1) = "2" Then
            Tabla = "RecibosProvi"
        End If

        cm.CommandText = ZSql.Replace("#TABLA#", Tabla)

        SQLConnector.conexionSql(cn, cm)

        Try
            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    Dim XTipo, XNumero, XFecha, XBanco, XImporte, XCuit, XClave As String
                    Dim XRow As Integer = gridFormaPagos.Rows.Add()

                    XClave = clave
                    XTipo = "3"
                    XNumero = .Item("Numero2").ToString()
                    XFecha = .Item("Fecha2").ToString()
                    XBanco = .Item("Banco2").ToString()
                    XImporte = .Item("Importe2").ToString()
                    XCuit = IIf(Not IsDBNull(.Item("Cuit")), .Item("Cuit"), "")

                    With gridFormaPagos.Rows(XRow)

                        .Cells(0).Value = XTipo
                        .Cells(1).Value = XNumero
                        .Cells(2).Value = XFecha
                        .Cells(3).Value = ""
                        .Cells(4).Value = XBanco
                        .Cells(5).Value = _NormalizarNumero(XImporte)
                        .Cells(6).Value = XClave
                        .Cells(7).Value = XCuit

                    End With


                    If Not IsNothing(indice) Then
                        lstConsulta.Items(indice) = ""
                    End If


                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Function _DocumentoYaUtilizado(ByVal XClave As String) As Boolean
        Dim utilizada As Boolean = False

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            With row
                Dim RClave As String = .Cells(6).Value

                If XClave = RClave Then

                    utilizada = True

                    Exit For

                End If

            End With
        Next

        Return utilizada
    End Function

    Private Sub _TraerDocumento(ByVal _Item As String, ByVal indice As Integer)
        Dim XClave As String = ""

        ' Comprobamos que aun haya lugar para seguir cancelando Facturas.
        If gridFormaPagos.Rows.Count > 15 Then
            MsgBox("La cantidad de facturas a cancelar supera las 15", MsgBoxStyle.Information)
            Exit Sub
        End If

        If _Claves.Count = 0 Then
            Exit Sub
        End If

        XClave = _ObtenerClaveConsulta(_Item)

        If XClave = "" Then
            Exit Sub
        End If

        If _DocumentoYaUtilizado(XClave) Then
            Exit Sub
        End If

        _ProcesarDocumento(XClave, indice)

    End Sub

    Private Sub _ProcesarDocumento(ByVal clave As String, Optional ByVal indice As Integer = Nothing)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Numero, Vencimiento1, Saldo FROM CtaCte WHERE Clave = '" & clave & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    Dim XTipo, XNumero, XFecha, XImporte, XCuit, XClave As String
                    Dim XRow As Integer = gridFormaPagos.Rows.Add()

                    XClave = clave
                    XTipo = "4"
                    XNumero = .Item("Numero").ToString()
                    XFecha = .Item("Vencimiento1").ToString()
                    XImporte = _NormalizarNumero(.Item("Saldo").ToString())
                    XCuit = IIf(Not IsDBNull(.Item("Cuit")), .Item("Cuit"), "")

                    With gridFormaPagos.Rows(XRow)

                        .Cells(0).Value = XTipo
                        .Cells(1).Value = XNumero
                        .Cells(2).Value = XFecha
                        .Cells(3).Value = ""
                        .Cells(4).Value = ""
                        .Cells(5).Value = XImporte
                        .Cells(6).Value = XClave
                        .Cells(7).Value = XCuit

                    End With


                    If Not IsNothing(indice) Then
                        lstConsulta.Items(indice) = ""
                    End If


                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub CLBFiltrado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLBFiltrado.Click

        If Not IsNothing(_TipoConsulta) Then
            Dim indice As Integer = Nothing
            Try
                indice = lstConsulta.FindStringExact(CLBFiltrado.SelectedItem.ToString)
            Catch ex As Exception

            End Try

            Select Case _TipoConsulta
                Case 0
                    mostrarProveedor(CLBFiltrado.SelectedItem.ToString)
                Case 1
                    ' Ctas Ctes
                    If Trim(CLBFiltrado.SelectedItem) = "" Then
                        Exit Sub
                    End If

                    _TraerCtaCte(CLBFiltrado.SelectedItem, indice)

                Case 2
                    If Trim(CLBFiltrado.SelectedItem) = "" Then
                        Exit Sub
                    End If

                    _TraerChequeDeTercero(CLBFiltrado.SelectedItem, indice)

                Case Else
                    Exit Sub
            End Select

            CLBFiltrado.Visible = False
            txtConsulta.Text = ""
            txtConsulta.Focus()
        End If

    End Sub

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        If Not IsNothing(_TipoConsulta) Then

            Select Case _TipoConsulta
                Case 0
                    mostrarProveedor(lstConsulta.SelectedItem.ToString)
                Case 1
                    ' Ctas Ctes
                    If Trim(lstConsulta.SelectedItem) = "" Then
                        Exit Sub
                    End If

                    _TraerCtaCte(lstConsulta.SelectedItem, lstConsulta.SelectedIndex)

                Case 2
                    If Trim(lstConsulta.SelectedItem) = "" Then
                        Exit Sub
                    End If

                    _TraerChequeDeTercero(lstConsulta.SelectedItem, lstConsulta.SelectedIndex)
                Case Else
                    Exit Sub
            End Select

        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'Cleanner.clean(Me)

        For Each _c As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            _c.Text = ""
        Next

        For Each _c As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)()
            _c.Clear()
        Next

        cmbTipo.SelectedIndex = 0

        txtIBCiudad.Text = "0,00"
        txtIngresosBrutos.Text = "0,00"
        txtGanancias.Text = "0,00"
        txtIVA.Text = "0,00"
        txtFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        txtFechaParidad.Text = txtFecha.Text

        gridPagos.Rows.Clear()
        pagos.Clear()
        gridFormaPagos.Rows.Clear()
        _ClavesCheques.Clear()
        cheques.Clear()

        'Array.Clear(_Claves, 0, _Claves.Length)

        lstSeleccion.Visible = False
        lstConsulta.Visible = False
        lstConsulta.Items.Clear()
        CLBFiltrado.Visible = False
        CLBFiltrado.Items.Clear()
        txtConsulta.Visible = False

        txtParidad.Text = traerParidad()

    End Sub

    Private Function traerParidad() As String
        Return traerParidad(txtFechaParidad.Text)
    End Function

    Private Function traerParidad(ByVal fecha As String) As String
        fecha = _Normalizarfecha(fecha)
        Dim _Paridad As String = "0"
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand("SELECT TOP 1 Cambio FROM Cambios WHERE Fecha = '" & Trim(fecha) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            If fecha <> "" Then
                dr = cm.ExecuteReader()
                With dr
                    If .HasRows Then
                        .Read()

                        If Not IsDBNull(.Item("Cambio")) Then
                            _Paridad = _NormalizarNumero(.Item("Cambio").ToString())
                        End If

                    End If
                End With
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la paridad en la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _Paridad
    End Function

    Private Function _NormalizarNumero(ByVal numero As String)
        Return _NormalizarNumero(numero, 2)
    End Function

    Private Function _NormalizarNumero(ByVal numero As String, ByVal decimales As Integer)
        Return CustomConvert.asStringWithDecimalPlaces(numero, decimales)
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If validarDatos() Then
            Dim siguienteNumero As Integer = DAOPagos.siguienteNumeroDeOrden()
            bancoOrden = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)
            proveedorOrden = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
            txtOrdenPago.Text = siguienteNumero
            Dim pago As OrdenPago = New OrdenPago(siguienteNumero, tipoOrden, CustomConvert.toDoubleOrZero(txtParidad.Text),
                                                  CustomConvert.toDoubleOrZero(txtTotal.Text), CustomConvert.toDoubleOrZero(txtIVA.Text),
                                                  CustomConvert.toDoubleOrZero(txtIngresosBrutos.Text), CustomConvert.toDoubleOrZero(txtIBCiudad.Text),
                                                  CustomConvert.toDoubleOrZero(txtGanancias.Text), txtFecha.Text, txtFechaParidad.Text, txtObservaciones.Text,
                                                  bancoOrden, proveedorOrden)
            crearNotasCreditoDebito()
            pago.pagos = crearPagos()
            pago.formaPagos = crearFormaPagos()
            DAOPagos.agregarPago(pago)
            MsgBox("El número de orden asignado es: " & siguienteNumero)
            btnLimpiar.PerformClick()
        End If
    End Sub

    Private Sub crearNotasCreditoDebito()
        Dim pagos As New List(Of Pago)
        Dim ultimoNumero As String = 0
        Dim tipoDoc As String = ""
        Dim neto As Double

        For Each row As DataGridViewRow In gridPagos.Rows
            If (Not row.IsNewRow And (Convert.ToString(row.Cells(3).Value) = "99999999")) Then

                If Convert.ToString(row.Cells(0).Value) = "02" Then
                    tipoDoc = "ND"
                Else
                    tipoDoc = "NC"
                End If

                neto = CustomConvert.toStringWithTwoDecimalPlaces(row.Cells(4).Value) / 1.21

                Dim interno As Integer = DAOCompras.siguienteNumeroDeInterno()
                Dim compra As New Compra(
                                         interno,
                                         DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text),
                                         Convert.ToString(row.Cells(0).Value),
                                         tipoDoc,
                                         "1",
                                         "2",
                                         Convert.ToString(row.Cells(1).Value),
                                         Convert.ToString(row.Cells(2).Value),
                                         ultimoNumero,
                                         txtFecha.Text,
                                         txtFecha.Text,
                                         txtFecha.Text,
                                         txtFecha.Text,
                                         CustomConvert.toStringWithTwoDecimalPlaces(txtParidad.Text),
                                         neto,
                                         CustomConvert.toStringWithTwoDecimalPlaces(row.Cells(4).Value) - neto,
                                         0,
                                         0,
                                         0,
                                         0,
                                         0,
                                         CustomConvert.toStringWithTwoDecimalPlaces(row.Cells(4).Value),
                                         0,
                                         "",
                                         "")
                crearImputaciones(compra)
                DAOCompras.agregarCompra(compra)
                DAOCompras.agregarDatosCuentaCorriente(compra)

            End If
            ultimoNumero = Convert.ToString(row.Cells(3).Value)
        Next
    End Sub

    Private Sub crearImputaciones(ByVal compra As Compra)
        Dim imputaciones As New List(Of Imputac)
        Dim debitoProv, debitoIva, debitoCuenta, creditoProv, creditoIva, creditoCuenta As Double
        Dim cuenta As Integer = 0
        debitoProv = 0
        debitoIva = debitoCuenta = creditoProv = creditoIva = creditoCuenta = debitoProv
        If compra.tipoDocumentoDescripcion = "ND" Then
            debitoCuenta = compra.neto
            debitoIva = compra.iva21
            creditoProv = compra.total
            cuenta = 6107
        Else
            creditoCuenta = compra.neto
            creditoIva = compra.iva21
            debitoProv = compra.total
            cuenta = 7308
        End If
        'For Each row As DataGridViewRow In gridAsientos.Rows
        'If Not row.IsNewRow Then

        imputaciones.Add(New Imputac(compra.fechaEmision, debitoProv, creditoProv, compra.proveedor.id.ToString, 2001, compra.nroInterno,
                                     compra.punto, compra.numero, compra.despacho, compra.letra, compra.tipoDocumento, "01"))
        imputaciones.Add(New Imputac(compra.fechaEmision, debitoIva, creditoIva, compra.proveedor.id.ToString, 151, compra.nroInterno,
                                     compra.punto, compra.numero, compra.despacho, compra.letra, compra.tipoDocumento, "02"))
        imputaciones.Add(New Imputac(compra.fechaEmision, debitoCuenta, creditoCuenta, compra.proveedor.id.ToString, cuenta, compra.nroInterno,
                             compra.punto, compra.numero, compra.despacho, compra.letra, compra.tipoDocumento, "03"))
        'End If
        'Next

        compra.agregarImputaciones(imputaciones)
    End Sub

    Private Function crearPagos()
        Dim pagos As New List(Of Pago)
        Dim ultimoNumero As String = ""

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow Then
                If (Convert.ToString(row.Cells(3).Value) = "99999999") Then
                    pagos.Add(New Pago(Convert.ToString(row.Cells(0).Value), Convert.ToString(row.Cells(1).Value), Convert.ToString(row.Cells(2).Value), ultimoNumero,
                    Convert.ToString(row.Cells(5).Value), CustomConvert.toDoubleOrZero(row.Cells(4).Value)))
                Else
                    pagos.Add(New Pago(Convert.ToString(row.Cells(0).Value), Convert.ToString(row.Cells(1).Value), Convert.ToString(row.Cells(2).Value), Convert.ToString(row.Cells(3).Value),
                    Convert.ToString(row.Cells(5).Value), CustomConvert.toDoubleOrZero(row.Cells(4).Value)))
                End If

            End If
            ultimoNumero = Convert.ToString(row.Cells(3).Value)
        Next
        Return pagos
    End Function

    Private Function crearFormaPagos()
        Dim formaPagos As New List(Of FormaPago)
        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow Then
                formaPagos.Add(New FormaPago(Convert.ToString(row.Cells(0).Value), CustomConvert.toIntOrZero(Convert.ToString(row.Cells(3).Value)), Convert.ToString(row.Cells(1).Value),
                                             Convert.ToString(row.Cells(2).Value), Convert.ToString(row.Cells(4).Value), CustomConvert.toDoubleOrZero(row.Cells(5).Value)))
            End If
        Next
        Return formaPagos
    End Function

    Private Function tipoOrden()
        If optCtaCte.Checked Then : Return 1 : End If
        If optVarios.Checked Then : Return 2 : End If
        If optChequeRechazado.Checked Then : Return 3 : End If
        If optAnticipos.Checked Then : Return 4 : End If
        If optTransferencias.Checked Then : Return 5 : End If
        Return Nothing
    End Function

    Private Sub txtFecha_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtFechaParidad.Text = txtFecha.Text
    End Sub

    Private Sub eventoSegunTipoEnFormaDePagoPara(ByVal val As Integer, ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Dim nombre As String = ""
        Dim column As Integer = columnIndex
        Select Case val
            Case 1
                nombre = "Efectivo"
                column = 4
            Case 2
                column = 1
            Case 3
                chequeRow = rowIndex
                lstSeleccion.SelectedIndex = 2
                lstSeleccion_Click(Nothing, Nothing)
                Exit Sub
            Case 5
                nombre = "US$"
                column = 4
            Case 6
                nombre = "Varios"
                column = 4
            Case Else
                Exit Sub
        End Select
        gridFormaPagos.CurrentCell.Value = ceros(val.ToString, 2)

        gridFormaPagos.Rows(rowIndex).Cells(4).Value = nombre
        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(rowIndex).Cells(column)
    End Sub

    Private Sub gridFormaPagos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFormaPagos.CellValueChanged
        sumarImportes()
        llenarConCerosNumero()
    End Sub

    Private Sub llenarConCerosNumero()
        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If row.Cells(1).Value <> "" Then
                If row.Cells(1).Value.ToString.Length > 8 Then
                    row.Cells(1).Value = ""
                Else
                    row.Cells(1).Value = ceros(row.Cells(1).Value, 8)
                End If
            End If
        Next
    End Sub

    Private Sub gridFormaPagos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridFormaPagos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim iCol = gridFormaPagos.CurrentCell.ColumnIndex
            Dim iRow = gridFormaPagos.CurrentCell.RowIndex
            If iCol = 0 And iRow > -1 Then
                Dim val = gridFormaPagos.Rows(iRow).Cells(iCol).Value
                eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(val), iRow, iCol)
            End If
        End If
    End Sub

    Private Sub gridPagos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPagos.CellValueChanged
        sumarImportes()
    End Sub

    Private Sub sumarImportes()
        Dim pagos As Double = 0
        Dim formaPagos As Double = 0
        Dim total As Double = 0

        total = CustomConvert.toDoubleOrZero(txtIVA.Text) + CustomConvert.toDoubleOrZero(txtGanancias.Text) + CustomConvert.toDoubleOrZero(txtIBCiudad.Text) +
            CustomConvert.toDoubleOrZero(txtIngresosBrutos.Text)

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow Then
                pagos += CustomConvert.toDoubleOrZero(row.Cells(4).Value)
            End If
        Next

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow Then
                formaPagos += CustomConvert.toDoubleOrZero(row.Cells(5).Value)
            End If
        Next
        txtTotal.Text = CustomConvert.toStringWithTwoDecimalPlaces(total)
        lblPagos.Text = CustomConvert.toStringWithTwoDecimalPlaces(pagos)
        lblFormaPagos.Text = CustomConvert.toStringWithTwoDecimalPlaces(formaPagos + total)
        lblDiferencia.Text = CustomConvert.toStringWithTwoDecimalPlaces(pagos - formaPagos - total)
    End Sub

    Private Sub gridPagos_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles gridPagos.RowsAdded
        sumarImportes()
    End Sub

    Private Sub gridFormaPagos_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles gridFormaPagos.RowsAdded
        sumarImportes()
    End Sub

    Private Sub gridPagos_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles gridPagos.UserDeletedRow
        If e.Row.Cells(0).Value <> "" Then
            Dim detalle As DetalleCompraCuentaCorriente = pagos.Find(Function(pago) pago.tipo = e.Row.Cells(0).Value And pago.letra = e.Row.Cells(1).Value And
                                                                         pago.punto = e.Row.Cells(2).Value And pago.numero = e.Row.Cells(3).Value And
                                                                         pago.saldo = CustomConvert.toDoubleOrZero(e.Row.Cells(4).Value))
            If Not IsNothing(detalle) Then
                pagos.Remove(detalle)
            End If
        End If
        sumarImportes()
    End Sub

    Private Sub gridFormaPagos_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles gridFormaPagos.UserDeletedRow
        If e.Row.Cells(0).Value = "03" Then
            Dim chequeABorrar As Cheque = cheques.Find(Function(cheque) cheque.numero = e.Row.Cells(1).Value And cheque.fecha = e.Row.Cells(2).Value And cheque.banco = e.Row.Cells(4).Value And cheque.importe = e.Row.Cells(5).Value)
            If Not IsNothing(chequeABorrar) Then
                cheques.Remove(chequeABorrar)
            End If
            _EliminarSeguimientoClaveCheque(e.Row.Cells(1).Value)
        End If
        sumarImportes()
    End Sub

    Private Sub optTransferencias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTransferencias.CheckedChanged
        If optTransferencias.Checked Then
            txtBanco.Enabled = True
            txtBanco.Empty = False
            txtNombreBanco.Empty = False
            txtBanco.Text = ""
            txtBanco.Focus()
            gridPagos.Rows.Clear()
            gridPagos.Rows.Add("", "", "", "", "", "")
            gridPagos.Columns(5).ReadOnly = False
        End If
    End Sub

    Private Sub optAnticipos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAnticipos.CheckedChanged
        If optAnticipos.Checked Then
            gridPagos.Rows.Clear()
            gridPagos.Rows.Add("", "", "", "", "0,00", txtRazonSocial.Text)
            gridPagos.Columns(5).ReadOnly = True
        End If
    End Sub

    Private Sub optVarios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optVarios.CheckedChanged
        If optVarios.Checked Then
            gridPagos.Rows.Clear()
            gridPagos.Rows.Add("", "", "", "", "", txtRazonSocial.Text)
            gridPagos.Columns(5).ReadOnly = True
        End If
    End Sub

    Private Sub optChequeRechazado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optChequeRechazado.CheckedChanged
        If optChequeRechazado.Checked Then
            gridPagos.Rows.Clear()
            gridPagos.Rows.Add("", "", "", "", "", "")
            gridPagos.Columns(5).ReadOnly = False
        End If
    End Sub

    Private Sub optCtaCte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCtaCte.CheckedChanged
        If optCtaCte.Checked Then
            gridPagos.Rows.Clear()
            Try
                gridPagos.Columns(5).ReadOnly = True
            Catch ex As ArgumentOutOfRangeException
            End Try
        End If
    End Sub

    Private Sub txtFechaParidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        traerParidad(txtFechaParidad.Text())
    End Sub

    Private Sub txtOrdenPago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrdenPago.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtOrdenPago.Text) <> "" Then
                txtOrdenPago.Text = ceros(txtOrdenPago.Text, 6)
                mostrarOrdenDePago(DAOPagos.buscarOrdenPorNumero(txtOrdenPago.Text))


                If txtProveedor.Text <> "" Then
                    txtProveedor.Focus()
                Else
                    txtFecha.Focus()
                End If


            End If
        End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If gridFormaPagos.Focused Or gridFormaPagos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            gridFormaPagos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = gridFormaPagos.CurrentCell.ColumnIndex
            Dim iRow = gridFormaPagos.CurrentCell.RowIndex

            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = gridFormaPagos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then
                        If Trim(valor.ToString.Length) = 31 Then
                            If _ProcesarCheque(iRow, valor) Then
                                gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol + 2) ' Nos desplazamos para que coloque la fecha del cheque.
                            End If
                        Else
                            valor = valor.ToString().Substring(valor.ToString.Length - 1, 1)
                            If valor = "1" Or valor = "2" Or valor = "3" Or valor = "4" Then
                                eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(valor), iRow, iCol)
                            Else ' Sólo se aceptan los valores 1 (Efectivo) , 2 (Cheque), 3 (Doc) y 4 (Varios) ?
                                gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol)
                            End If
                        End If

                        Return True
                    End If

                End If


                If iCol = 3 Then
                    If gridFormaPagos.Rows(iRow).Cells(0).Value = "02" Then
                        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(valor)
                        If Not IsNothing(banco) Then
                            gridFormaPagos.Rows(iRow).Cells(iCol + 1).Value = banco.nombre
                            iCol = 4 ' Desplazamos a ultima fila.
                        Else
                            MsgBox("Codigo de Banco Incorrecto.", MsgBoxStyle.Information)
                            Return True ' Nos quedamos en la celda.
                        End If
                    End If
                End If

                If iCol = 2 And valor <> "" Then
                    valor = _Normalizarfecha(valor)
                    gridFormaPagos.Rows(iRow).Cells(iCol).Value = valor
                End If

                If iCol = 1 Or iCol = 2 Or iCol = 3 Or iCol = 4 Then
                    gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol + 1)
                End If

                If iCol = 5 Then

                    If valor <> "" Then
                        gridFormaPagos.Rows(iRow).Cells(iCol).Value = _NormalizarNumero(valor)
                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(gridFormaPagos.Rows.Add()).Cells(0)
                    End If

                End If

                Return True
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

        With gridFormaPagos.Rows(row)
            .Cells(0).Value = "03"
            .Cells(1).Value = _NumCheque
            .Cells(2).Value = ""
            .Cells(4).Value = _Banco '_GenerarCodigoBanco(_Banco)
        End With
        ' Buscamos si existe el cuit.
        _Cuit = _TraerNumeroCuit(_ClaveBanco & _Sucursal & _NumCta)

        ' Guardamos el nuevo Cheque.
        _GuardarNuevoCheque(row, ClaveCheque, _Banco, _Sucursal, _NumCheque, _NumCta, _Cuit)

        Return _LecturaCorrecta
    End Function

    'Private Function _GenerarCodigoBanco(ByVal _Banco As String) As String
    '    _Banco = _Banco.ToString.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

    '    Return _Banco & "/" & Mid(txtCliente.Text, 1, 1) & Val(Mid(txtCliente.Text, 2, 6)).ToString()
    'End Function

    Private Function _ChequeYaCargado(ByVal ClaveCheque) As Boolean
        Dim _cargado As Boolean = False

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

    Private Sub _PedirInformacion(ByVal msg As String, ByRef control As TextBox, ByRef VariableDestino As String)

        With InformacionRetenciones
            .TipoInformacion = msg

            .Valor = VariableDestino

            .ShowDialog(Me)

            VariableDestino = .Valor

            .Dispose()

        End With

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

    Private Sub _EliminarSeguimientoClaveCheque(ByVal numCheque As String)

        If Trim(numCheque) <> "" Then
            _ClavesCheques.RemoveAll(Function(c) c(4) = numCheque)
        End If

    End Sub

    Private Sub btnCarpetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarpetas.Click
        With CarpetasPagos

            .Carpetas(_Carpetas) ' Asignamos las carpetas en caso de que la orden de pago tenga.

            .ShowDialog()

            _Carpetas = .Carpetas ' Traemos las carpetas que se hayan asignado.

            .Dispose()

        End With


        If _Carpetas.Count > 0 Then

            ' Validamos que todas las carpetas, ademas de validas, correspondan al proveedor en cuestión.
            If Not _CarpetasCorrespondenAProveedor(txtProveedor.Text) Then
                MsgBox("El Proveedor de la Carpeta no coincide con el de la orden de pago.", MsgBoxStyle.Critical)
                btnCarpetas.PerformClick()
            End If

        End If

    End Sub

    Private Function _CarpetasCorrespondenAProveedor(ByVal _Proveedor As String)
        Dim corresponden As Boolean = True
        _Proveedor = Trim(_Proveedor)

        For Each _C As Object In _Carpetas
            If _Proveedor <> "10167878480" And _Proveedor <> "10000000100" And _Proveedor <> "10071081483" And _Proveedor <> "10069345023" And _Proveedor <> "10066352912" Then
                If _Proveedor <> Trim(_C(1)) Then
                    ' Indicamos que hay algunas de las carpetas que no se corresponde con el proveedor y salimos.
                    corresponden = False
                    Exit For
                End If
            End If
        Next

        Return corresponden
    End Function

    Private Sub Pagos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        _AlinearColumnas()
        txtOrdenPago.Focus()
        cmbTipo.SelectedIndex = 0
        lstSeleccion.SelectedIndex = 0

        txtFecha.ValidatingType = GetType(System.DateTime)
        txtFechaParidad.ValidatingType = GetType(System.DateTime)

    End Sub

    Private Sub lblDiferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDiferencia.TextChanged
        lblDiferencia.Text = _NormalizarNumero(lblDiferencia.Text)
    End Sub

    Private Sub lblFormaPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFormaPagos.TextChanged
        lblFormaPagos.Text = _NormalizarNumero(lblFormaPagos.Text)
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) <> "" Then

                If Not _FormatoValidoFecha(txtFecha.Text) Then
                    Exit Sub
                End If

                txtProveedor.Focus()
            End If
        End If

    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then
            txtBanco.Focus()
        End If

    End Sub

    Private Sub txtFechaParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaParidad.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtFechaParidad.Text.Replace("/", "")) <> "" Then

                If Not _FormatoValidoFecha(txtFecha.Text) Then
                    Exit Sub
                End If

                txtParidad.Text = traerParidad()

                If Val(txtParidad.Text) <> 0 Then
                    txtParidad.Focus()
                ElseIf Val(txtParidad.Text) = 0 Then
                    MsgBox("No hay paridad cargada para esta fecha.", MsgBoxStyle.Information)
                End If

            Else
                txtFechaParidad.Focus()
            End If

        End If

    End Sub

    Private Sub txtParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtParidad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtParidad.Text) <> 0 Then
                txtGanancias.Focus()
            End If
        End If

    End Sub

    Private Sub txtGanancias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGanancias.KeyDown
        If e.KeyData = Keys.Enter Then
            txtIngresosBrutos.Focus()
        End If
    End Sub

    Private Sub txtIngresosBrutos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIngresosBrutos.KeyDown
        If e.KeyData = Keys.Enter Then
            cmbTipo.Focus()
        End If
    End Sub

    Private Sub cmbTipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo.KeyDown
        If e.KeyData = Keys.Enter Then
            txtIBCiudad.Focus()
        End If
    End Sub

    Private Sub cmbTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.TextChanged
        txtIBCiudad.Focus()
    End Sub

    Private Sub txtIBCiudad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIBCiudad.KeyDown
        If e.KeyData = Keys.Enter Then
            txtIVA.Focus()
        End If
    End Sub

    Private Sub txtIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTotal.Focus()
        End If
    End Sub

    Private Sub txtParidad_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParidad.Leave, txtGanancias.Leave, txtIBCiudad.Leave, txtIngresosBrutos.Leave, txtIVA.Leave, txtTotal.Leave, lblDiferencia.Leave, lblFormaPagos.Leave, lblPagos.Leave
        Dim _controles As New List(Of Control) From {txtParidad, txtGanancias, txtIBCiudad, txtIngresosBrutos, txtIVA, txtTotal, lblDiferencia, lblFormaPagos, lblPagos}
        For Each _c As Control In _controles
            _c.Text = _NormalizarNumero(_c.Text)
        Next
    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick

        If Trim(txtProveedor.Text) = "" Then

            _TipoConsulta = 0
            _ListarProveedores()

        End If

    End Sub

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

    Private Sub txtFecha_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFecha.TypeValidationCompleted

        e.Cancel = _ValidarFecha(txtFecha.Text, e.IsValidInput)

    End Sub

    Private Sub txtFechaParidad_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtFechaParidad.TypeValidationCompleted
        e.Cancel = _ValidarFecha(txtFechaParidad.Text, e.IsValidInput)
    End Sub

    Private Sub txtBanco_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBanco.MouseDoubleClick

        If Trim(txtBanco.Text) = "" Then
            _TipoConsulta = 1
            _ListarCuentasContables()
            Exit Sub
        End If

    End Sub

    Private Sub txtConsulta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsulta.KeyPress

    End Sub

    Private Sub txtConsulta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsulta.TextChanged

        CLBFiltrado.Items.Clear()

        If UCase(Trim(txtConsulta.Text)) <> "" Then

            For Each item In lstConsulta.Items

                If UCase(item.ToString()).Contains(UCase(Trim(txtConsulta.Text))) Then

                    CLBFiltrado.Items.Add(item.ToString())

                End If

            Next

            CLBFiltrado.Visible = True

        Else

            CLBFiltrado.Visible = False

        End If

    End Sub

    Private Sub btnChequesTerceros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChequesTerceros.Click
        lstSeleccion.SelectedIndex = 2
        lstSeleccion_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaCte.Click
        lstSeleccion.SelectedIndex = 1
        lstSeleccion_Click(Nothing, Nothing)
    End Sub
End Class