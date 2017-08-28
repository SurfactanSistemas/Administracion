Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Pagos

    Dim queryController As QueryController
    Dim pagos As New List(Of DetalleCompraCuentaCorriente)
    Dim cheques As New List(Of Cheque)
    Dim chequeRow As Integer = -1
    Dim bancoOrden As Banco
    Dim proveedorOrden As Proveedor
    Private XParidadTotal As String = "0"
    Dim commonEventHandler As New CommonEventsHandler
    Dim _ClavesCheques As New List(Of Object)
    Dim _Carpetas As New List(Of Object)
    Dim _Claves As New List(Of Object)
    Dim _TipoConsulta As Integer = Nothing
    Private WCertificadoIb, WCertificadoIbCiudad, WCertificadoIVA As String

    Private Const YMARGEN = 250
    Private Const XMARGEN = 426
    Private WRow, Wcol As Integer

    Private WTipoProv, WTipoIva, WTipoIb, WTipoIbCaba, WPorceIb, WPorceIbCaba As String

    ' Utilizado para poder ser usado con consulta de cta cte prv por pantalla.
    Private _SoloLectura As String = False

    Dim XRenglon, XRecibo, XCliente, XFecha, XFechaOrd, XTipoRec, XRetganancias, XRetIva, XRetotra, _
            XRetencion, XTiporeg, XTipo, XNumero, ClaveCtaCte, XTipo1, XLetra1, XPunto1, XNumero1, XImporte1, XTipo2, _
            XNumero2, XFecha2, XFechaOrd2, XBanco2, XImporte2, XEstado2, XObservaciones, XEmpresa, _
            XImporte, XImporteBaja, XCuenta, XMarca, XFechaDepo, XFechaDepoOrd, XImpolist, XImpo1list, XDestino, XEstado, _
            XVencimiento, XVencimiento1, XTotal, XTotalUs, XSaldo, XSaldoUs, XOrdFecha, XOrdVencimiento, _
            XOrdVencimiento1, XImpre, XNeto, XIva1, XIva2, XImpoIb, XSeguro, XFlete, XPedido, XRemito, XOrden, _
            XParidad, XProvincia, XVendedor, XRubro, XComprobante, XAceptada, XCosto, XImporte3, XImporte4, _
            XImporte5, XImporte6, XImporte7, XDate, XParam, XSql, XClaveCheque, XBancoCheque, XSucursalCheque, _
            XChequeCheque, XCuentaCheque, XCuit, XClaveCuit, XNet As String

    Public Property SoloLectura() As Boolean
        Get
            Return _SoloLectura
        End Get
        Set(ByVal value As Boolean)
            _SoloLectura = value
        End Set
    End Property

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

        If Me.SoloLectura Then
            Dim botones As New List(Of Button) From {btnAgregar, btnCalcular, btnCarpetas, btnChequesTerceros, btnConsulta, btnCtaCte, btnImprimir, btnLimpiar}

            For Each btn As Button In botones
                btn.Visible = False
            Next

            btnCerrar.Location = New Point(387, btnCerrar.Location.Y)

        Else
            btnLimpiar.PerformClick()
        End If

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
            lstSeleccion_MouseClick(Nothing, Nothing)
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
        txtFecha.Text = Proceso._Normalizarfecha(orden.fecha)
        txtObservaciones.Text = orden.observaciones
        txtFechaParidad.Text = Proceso._Normalizarfecha(orden.fechaParidad)
        mostrarProveedor(orden.proveedor)
        mostrarBanco(orden.banco)

        txtGanancias.Text = _NormalizarNumero(orden.retGanancias)
        txtIBCiudad.Text = _NormalizarNumero(orden.retIBCiudad)
        txtIngresosBrutos.Text = _NormalizarNumero(orden.retIB)
        txtIVA.Text = _NormalizarNumero(orden.retIVA)
        mostrarPagos(orden.pagos)
        mostrarFormaPagos(orden.formaPagos)
        mostrarTipo(orden.tipo)
        txtParidad.Text = _NormalizarNumero(orden.paridad)
        WCertificadoIb = orden.certIb
        WCertificadoIbCiudad = orden.certIbCABA
        WCertificadoIVA = orden.certIVA
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
            gridPagos.Rows.Add(pago.tipo, pago.letra, pago.punto, pago.numero, _NormalizarNumero(pago.importe), pago.descripcion, _NormalizarNumero(pago.impoNeto))
        Next
        sumarImportes()
    End Sub

    Private Sub mostrarFormaPagos(ByVal formaPagos As List(Of FormaPago))
        gridFormaPagos.Rows.Clear()
        For Each formaPago As FormaPago In formaPagos
            gridFormaPagos.Rows.Add(formaPago.tipo, formaPago.numero, formaPago.fecha, formaPago.banco, formaPago.nombre, _NormalizarNumero(formaPago.importe), "", formaPago.cuit)
        Next
        sumarImportes()
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        If IsNothing(proveedor) Then : Exit Sub : End If

        txtProveedor.Text = proveedor.id
        txtRazonSocial.Text = proveedor.razonSocial
        WTipoProv = proveedor.tipo + 1
        WTipoIva = proveedor.codIva
        WTipoIb = proveedor.condicionIB1
        WTipoIbCaba = proveedor.condicionIB2
        WPorceIb = proveedor.porceIBProvincia
        WPorceIbCaba = proveedor.porceIBCABA


        btnCtaCte.PerformClick()

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
                'txtObservaciones.Focus()
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
                        Dim XNroInterno, XTotal, XSaldo, XSaldoUS, XImpre, XLetra, XPunto, XNumero, XFecha, XClave, XParidad, XPago As String

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

                    If Trim(txtProveedor.Text) = "" Then
                        MsgBox("Debe informarse primero un proveedor para poder realizar la consulta de Cuentas Corrientes.", MsgBoxStyle.Information)
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

    Private Sub _ListarProveedores()
        Dim XClaves As New List(Of Object)
        Dim _Item As String = ""
        Dim proveedores As List(Of Proveedor) = DAOProveedor.buscarProveedoresActivoPorNombre("")

        If proveedores.Count > 0 Then
            lstConsulta.Items.Clear()

            For Each _Prv As Proveedor In proveedores
                _Item = ceros(_Prv.id, 11) & "    " & _Prv.razonSocial
                lstConsulta.Items.Add(_Item)
                XClaves.Add({_Item, ceros(_Prv.id, 11)})
            Next

            _Claves = XClaves

            _HabilitarConsulta()
        Else
            _InhabilitarConsulta()
        End If

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
                                            .Replace("#IMPORTE#", _NormalizarNumero(.Item("Importe2")).ToString.PadLeft(10, "_")) _
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
                                            .Replace("#IMPORTE#", _NormalizarNumero(.Item("Importe2")).ToString.PadLeft(10, "_")) _
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



    Private Sub lstSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs)

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

        '_InhabilitarConsulta()
        'lstSeleccion.Visible = False
        'txtObservaciones.Focus()
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
                    XParidad = .Item("Paridad")
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

                            XSaldoUS = (Val(_NormalizarNumero(XSaldo)) / Val(XParidad.Replace(",", "."))) * Val(_NormalizarNumero(XParidadTotal))

                            Dim diferencia As String = Val(_NormalizarNumero(XSaldoUS)) - Val(_NormalizarNumero(XSaldo))

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
                    XNumero = IIf(Not IsDBNull(.Item("Numero")), .Item("Numero"), "")
                    XFecha = IIf(Not IsDBNull(.Item("Vencimiento1")), .Item("Vencimiento1"), "")
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

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'Cleanner.clean(Me)

        For Each _c As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            _c.Text = ""
        Next

        For Each _c As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)()
            _c.Clear()
        Next

        WRow = -1
        Wcol = -1

        cmbTipo.SelectedIndex = 0

        txtIBCiudad.Text = "0.00"
        txtIngresosBrutos.Text = "0.00"
        txtGanancias.Text = "0.00"
        txtIVA.Text = "0.00"
        txtFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        txtFechaParidad.Text = txtFecha.Text

        gridPagos.Rows.Clear()
        pagos.Clear()
        gridFormaPagos.Rows.Clear()
        _ClavesCheques.Clear()
        cheques.Clear()

        'Array.Clear(_Claves, 0, _Claves.Length)

        WCertificadoIb = ""
        WCertificadoIbCiudad = ""
        WCertificadoIVA = ""

        lstSeleccion.Visible = False
        lstConsulta.Visible = False
        lstConsulta.Items.Clear()
        CLBFiltrado.Visible = False
        CLBFiltrado.Items.Clear()
        txtConsulta.Visible = False

        txtParidad.Text = traerParidad()

        txtProveedor.Focus()
        WTipoProv = ""
        WTipoIva = ""
        WTipoIb = ""
        WTipoIbCaba = ""
        WPorceIb = ""
        WPorceIbCaba = ""

    End Sub

    Private Function traerParidad() As String
        Return traerParidad(txtFechaParidad.Text)
    End Function

    Private Function traerParidad(ByVal fecha As String) As String
        fecha = _Normalizarfecha(fecha)
        Dim _Paridad As String = "0"
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand("SELECT TOP 1 CambioDivisa FROM Cambios WHERE Fecha = '" & Trim(fecha) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            If fecha <> "" Then
                dr = cm.ExecuteReader()
                With dr
                    If .HasRows Then
                        .Read()

                        If Not IsDBNull(.Item("CambioDivisa")) Then
                            _Paridad = _NormalizarNumero(.Item("CambioDivisa").ToString())
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

    Private Function _NormalizarNumero(ByVal numero As String, ByVal decimales As Integer)
        Return CustomConvert.asStringWithDecimalPlaces(numero, decimales)
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If validarDatos() Then
            Dim siguienteNumero As Integer = DAOPagos.siguienteNumeroDeOrden()
            bancoOrden = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)
            proveedorOrden = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
            txtOrdenPago.Text = siguienteNumero
            Dim pago As OrdenPago = New OrdenPago(siguienteNumero, tipoOrden, _NormalizarNumero(txtParidad.Text),
                                                  _NormalizarNumero(txtTotal.Text), _NormalizarNumero(txtIVA.Text),
                                                  _NormalizarNumero(txtIngresosBrutos.Text), _NormalizarNumero(txtIBCiudad.Text),
                                                  _NormalizarNumero(txtGanancias.Text), txtFecha.Text, txtFechaParidad.Text, txtObservaciones.Text,
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

                neto = _NormalizarNumero(row.Cells(4).Value) / 1.21

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
                                         _NormalizarNumero(txtParidad.Text),
                                         neto,
                                         _NormalizarNumero(row.Cells(4).Value) - neto,
                                         0,
                                         0,
                                         0,
                                         0,
                                         0,
                                         _NormalizarNumero(row.Cells(4).Value),
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
                    Convert.ToString(row.Cells(5).Value), _NormalizarNumero(row.Cells(4).Value)))
                Else
                    pagos.Add(New Pago(Convert.ToString(row.Cells(0).Value), Convert.ToString(row.Cells(1).Value), Convert.ToString(row.Cells(2).Value), Convert.ToString(row.Cells(3).Value),
                    Convert.ToString(row.Cells(5).Value), _NormalizarNumero(row.Cells(4).Value)))
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
                                             Convert.ToString(row.Cells(2).Value), Convert.ToString(row.Cells(4).Value), _NormalizarNumero(row.Cells(5).Value)))
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
                lstSeleccion_MouseClick(Nothing, Nothing)
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

        total = Val(_NormalizarNumero(txtIVA.Text)) + Val(_NormalizarNumero(txtGanancias.Text)) + Val(_NormalizarNumero(txtIBCiudad.Text)) +
            Val(_NormalizarNumero(txtIngresosBrutos.Text))

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow Then
                pagos += Val(_NormalizarNumero(row.Cells(4).Value))
            End If
        Next

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow Then
                formaPagos += Val(_NormalizarNumero(row.Cells(5).Value))
            End If
        Next
        txtTotal.Text = _NormalizarNumero(total)
        lblPagos.Text = _NormalizarNumero(pagos)
        lblFormaPagos.Text = _NormalizarNumero(formaPagos + total)
        lblDiferencia.Text = _NormalizarNumero(pagos - formaPagos - total)
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
            gridPagos.Rows.Add("", "", "", "", "0.00", txtRazonSocial.Text)
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
        traerParidad(txtFechaParidad.Text)
    End Sub

    Public Sub txtOrdenPago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrdenPago.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtOrdenPago.Text) <> "" Then
                txtOrdenPago.Text = ceros(txtOrdenPago.Text, 6)
                mostrarOrdenDePago(DAOPagos.buscarOrdenPorNumero(txtOrdenPago.Text))

                If txtProveedor.Text <> "" Then
                    txtProveedor.Focus()
                Else
                    txtFecha.Focus()
                End If
            Else
                txtOrdenPago.Text = "0"
                txtFecha.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtOrdenPago.Text = ""
        End If

    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If gridFormaPagos.Focused Or gridFormaPagos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            gridFormaPagos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = gridFormaPagos.CurrentCell.ColumnIndex
            Dim iRow = gridFormaPagos.CurrentCell.RowIndex


            Select Case iCol
                Case 1

                    If Not _EsNumeroOControl(keyData) Then
                        Return True
                    End If
                Case 5
                    If Not _EsDecimalOControl(keyData) Then
                        Return True
                    End If
                Case Else

            End Select


            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = gridFormaPagos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then
                        If Trim(valor.ToString.Length) = 31 Then
                            If _ProcesarCheque(iRow, valor) Then
                                Try
                                    gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow + 1).Cells(0)
                                Catch ex As Exception
                                    gridFormaPagos.CurrentCell = gridFormaPagos.Rows(gridFormaPagos.Rows.Add).Cells(0)
                                End Try
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

                    If Not _ValidarFecha(valor, True) Then
                        Return True
                    End If

                    gridFormaPagos.Rows(iRow).Cells(iCol).Value = valor
                End If

                If iCol = 1 Or iCol = 2 Or iCol = 3 Or iCol = 4 Then
                    gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol + 1)
                End If


                If iCol = 1 Then

                    With gridFormaPagos
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                        Dim _location As Point = .GetCellDisplayRectangle(2, iRow, False).Location

                        .ClearSelection()
                        _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - 1.5
                        _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - 3
                        txtFechaAux.Location = _location
                        txtFechaAux.Text = .Rows(iRow).Cells(2).Value
                        WRow = iRow
                        Wcol = iCol
                        txtFechaAux.Visible = True
                        txtFechaAux.Focus()
                    End With

                End If


                If iCol = 5 Then

                    If valor <> "" Then
                        gridFormaPagos.Rows(iRow).Cells(iCol).Value = _NormalizarNumero(valor)
                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(gridFormaPagos.Rows.Add()).Cells(0)
                    End If

                End If

                Return True
            ElseIf msg.WParam.ToInt32() = Keys.Escape Then

                With gridFormaPagos
                    .Rows(iRow).Cells(iCol).Value = ""
                    If iCol = 5 Then
                        .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                    Else
                        .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End If

                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End With

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

    Private Function _BuscarClaveRecibo(ByVal Clavecheque) As String
        Dim clave As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave FROM Recibos WHERE ClaveCheque = '" & Clavecheque & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr
                    clave = IIf(Not IsDBNull(.Item("Clave")), "1" & .Item("Clave"), "")
                End With

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try


        If clave = "" Then
            Try
                cn.Open()
                cm.CommandText = "SELECT Clave FROM RecibosProvi WHERE ClaveCheque = '" & Clavecheque & "'"
                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    dr.Read()

                    With dr
                        clave = IIf(Not IsDBNull(.Item("Clave")), "2" & .Item("Clave"), "")
                    End With

                End If

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()

            End Try
        End If

        cn = Nothing
        cm = Nothing
        dr = Nothing

        Return clave
    End Function

    Private Function _ProcesarCheque(ByVal row As Integer, ByVal ClaveCheque As String) As Boolean
        Dim WNumero, WFecha, WBanco, WImporte, WClave As String
        Dim _LecturaCorrecta As Boolean = True
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader


        If Not _FormatoValidoDeCheque(ClaveCheque) Then
            MsgBox("El formato del cheque no es valido.", MsgBoxStyle.Exclamation)
            Return False
        End If

        WClave = _BuscarClaveRecibo(ClaveCheque)

        ' Chequeamos que el cheque no se haya cargado.

        If _ChequeYaCargado(WClave) Then
            _LecturaCorrecta = False

            MsgBox("Cheque ya Cargado con anterioridad.", MsgBoxStyle.Exclamation)

            Return _LecturaCorrecta
        End If

        SQLConnector.conexionSql(cn, cm)
        Dim _Tabla As String = "Recibos"


        If Mid(WClave, 1, 1) = "2" Then
            _Tabla = "RecibosProvi"
        End If

        Try
            cm.CommandText = "SELECT Numero2, Fecha2, Importe2, Banco2 FROM " & _Tabla & " WHERE ClaveCheque = '" & ClaveCheque & "' AND Estado2 = 'P'"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr
                    WNumero = .Item("Numero2")
                    WFecha = .Item("Fecha2")
                    WImporte = .Item("Importe2")
                    WBanco = .Item("Banco2")
                End With
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Return False
        Finally

            cn.Close()

        End Try

        If _LecturaCorrecta Then
            With gridFormaPagos.Rows(row)
                .Cells(0).Value = "03"
                .Cells(1).Value = WNumero
                .Cells(2).Value = WFecha
                .Cells(4).Value = WBanco
                .Cells(5).Value = WImporte
                .Cells(6).Value = WClave
            End With
        End If

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
        Return Proceso._Normalizarfecha(fecha)
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
        txtProveedor.Focus()
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
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Not _ValidarFecha(txtFecha.Text) Then
                Exit Sub
            End If

            txtProveedor.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If

    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then
            txtBanco.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If

    End Sub

    Private Sub txtFechaParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaParidad.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtFechaParidad.Text.Replace("/", "")) <> "" Then

                If Not _ValidarFecha(txtFechaParidad.Text) Then
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
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaParidad.Clear()
        End If

    End Sub

    Private Sub txtParidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtParidad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtParidad.Text) <> 0 Then
                txtGanancias.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtParidad.Text = ""
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

            _TipoConsulta = 0
            _ListarProveedores()

    End Sub

    Private Function _FormatoValidoFecha(ByVal fecha As String) As Boolean
        Return Proceso._FormatoValidoFecha(fecha)
    End Function

    Private Function _ValidarFecha(ByVal fecha As String, Optional ByVal valido As Boolean = True) As Boolean
        Return Proceso._ValidarFecha(fecha, valido)
    End Function

    Private Sub txtFecha_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)

        e.Cancel = Not _ValidarFecha(txtFecha.Text, e.IsValidInput)

    End Sub

    Private Sub txtFechaParidad_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)
        e.Cancel = Not _ValidarFecha(txtFechaParidad.Text, e.IsValidInput)
    End Sub

    Private Sub txtBanco_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBanco.MouseDoubleClick

            _TipoConsulta = 1
            _ListarCuentasContables()

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
        lstSeleccion_MouseClick(Nothing, Nothing)
    End Sub

    Private Sub btnCtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaCte.Click
        lstSeleccion.SelectedIndex = 1
        lstSeleccion_MouseClick(Nothing, Nothing)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim XOrdenPago As String = IIf(Trim(txtOrdenPago.Text) = "", "0", Trim(txtOrdenPago.Text))
        Dim XEmpCuit As String = "30-54916508-3"
        Dim XRazon, XCuitProveedor, WTipo, WLetra, WPunto, WNumero, ClaveCtaprv, WCtaProveedor, WCtaEfectivo, WCtaCheques, ClaveBanco As String
        Dim WRenglon, XTotal, XSubtotal, XCantidad, XLugarResumen As Double
        Dim WImpresion(15, 10) As String
        Dim WImpre2(15, 10) As String
        Dim WDebito(15, 2) As String
        Dim WCredito(15, 4) As String
        Dim WCuenta(15, 2) As String
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        ' Verificamos de que haya codigo de orden de pago valido para traer.
        If Val(XOrdenPago) <= 0 Then
            Exit Sub
        End If

        XRazon = ""
        XCuitProveedor = ""
        WRenglon = 0
        XTotal = 0
        XSubtotal = 0
        XCantidad = 0
        XLugarResumen = 0

        SQLConnector.conexionSql(cn, cm)

        ' Sacamos el resto de informacion del proveedor.
        Try
            cm.CommandText = "SELECT Cuit, Nombre FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()
                XRazon = dr.Item("Nombre")
                XCuitProveedor = dr.Item("Cuit")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        ' Recorremos los primeros 15 pagos.
        For iRow = 0 To gridPagos.Rows.Count - 1

            With gridPagos.Rows(iRow)

                If Val(.Cells(4).Value) = 0 Then
                    Exit For
                End If

                Select Case Val(.Cells(0).Value)
                    Case 1
                        WImpresion(XCantidad, 2) = "Factura"
                    Case 2
                        WImpresion(XCantidad, 2) = "N.Debito"
                    Case 3
                        WImpresion(XCantidad, 2) = "N.Credito"
                    Case 99
                        WImpresion(XCantidad, 2) = "Varios"
                    Case Else
                        WImpresion(XCantidad, 2) = ""
                End Select

                WImpresion(XCantidad, 3) = Mid(.Cells(3).Value, 1, 8)
                WImpresion(XCantidad, 4) = .Cells(5).Value
                WImpresion(XCantidad, 5) = .Cells(4).Value
                If Val(WImpresion(XCantidad, 2)) = 3 Or Val(WImpresion(XCantidad, 2)) = 5 Then
                    XTotal -= CDbl(WImpresion(XCantidad, 5))
                Else
                    XTotal += CDbl(WImpresion(XCantidad, 5))
                End If

                WTipo = .Cells(0).Value
                WLetra = .Cells(1).Value
                WPunto = .Cells(2).Value
                WNumero = .Cells(3).Value

                ClaveCtaprv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

                ' Sacamos el resto de informacion del proveedor.
                Try
                    cn.Open()
                    cm.CommandText = "SELECT Fecha FROM CtaCtePrv WHERE Clave = '" & ClaveCtaprv & "'"
                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        dr.Read()
                        WImpresion(XCantidad, 1) = dr.Item("Fecha")

                    Else
                        WImpresion(XCantidad, 1) = ""
                    End If

                Catch ex As Exception
                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                    Exit Sub
                Finally
                    cn.Close()
                End Try

                XCantidad += 1

            End With

        Next

        WCtaProveedor = "21101"
        WCtaEfectivo = "1110103"
        WCtaCheques = "1110103"


        If optCtaCte.Checked Or optAnticipos.Checked Then
            WDebito(1, 1) = WCtaProveedor
            WDebito(1, 2) = XTotal
        Else

            For irow = 0 To gridPagos.Rows.Count - 1
                With gridPagos.Rows(irow)
                    If Val(.Cells(4).Value) <> 0 Then
                        WDebito(irow + 1, 1) = WCuenta(irow, 1)
                        WDebito(irow + 1, 2) = CDbl(.Cells(4).Value)
                    End If
                End With
            Next

        End If

        Dim Retenido = "" ' Consultar con DAVID mañana.

        WCredito(1, 1) = WCtaProveedor
        If Val(Retenido) <> 0 Then
            WCredito(1, 2) = Retenido
        End If

        Dim Lugar = 0
        Dim Impre2 = 0
        Dim SumaTercero = 0

        For iRow = 0 To gridFormaPagos.Rows.Count - 1
            With gridFormaPagos.Rows(iRow)
                If Val(.Cells(5).Value) <> 0 Then

                    WCredito(Lugar, 4) = .Cells(5).Value
                    Select Case Val(.Cells(0).Value)
                        Case 2
                            WCredito(Lugar, 1) = "999999"
                            ClaveBanco = .Cells(3).Value
                            WCredito(Lugar, 1) = _TraerCuentaBanco(ClaveBanco)
                        Case 3, 4
                            WCredito(Lugar, 1) = WCtaCheques
                        Case Else
                            WCredito(Lugar, 1) = WCtaEfectivo
                    End Select

                    If Val(.Cells(0).Value) <> 3 Or Val(txtProveedor.Text) = 0 Then

                        WImpre2(Impre2, 1) = .Cells(1).Value
                        WImpre2(Impre2, 2) = .Cells(4).Value
                        WImpre2(Impre2, 3) = .Cells(5).Value
                        WImpre2(Impre2, 4) = .Cells(2).Value

                        WCredito(Lugar, 2) = .Cells(4).Value
                        WCredito(Lugar, 3) = .Cells(1).Value
                        WCredito(Lugar, 4) = .Cells(5).Value

                        Impre2 = Impre2 + 1
                    ElseIf Val(.Cells(0).Value) = 3 Then
                        SumaTercero = SumaTercero + CDbl(.Cells(5).Value)
                    End If

                    Lugar = Lugar + 1
                End If
            End With
        Next iRow

        If SumaTercero <> 0 Then
            For WCiclo = 1 To 15
                If Val(WImpre2(WCiclo, 3)) = 0 Then
                    WImpre2(WCiclo, 1) = ""
                    WImpre2(WCiclo, 2) = "Valores S/Detalle"
                    WImpre2(WCiclo, 3) = Str$(SumaTercero)
                    WImpre2(WCiclo, 4) = ""
                    Exit For
                End If
            Next WCiclo
        End If

        ' ACA IMPRIMIR ORDEN DE PAGO.
        Dim WFecha1, WNumero1, WComprobante1, WDescripcion1, WNumero2, WBanco2, WFecha2 As String
        Dim WImporte1, WImporte2 As Double
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New InformeOrdenPago

        ' Creo las Columnas
        _PrepararTablaOrdenPago(Tabla)

        For WCiclo = 0 To 11

            WFecha1 = ""
            WNumero1 = ""
            WComprobante1 = ""
            WDescripcion1 = ""
            WImporte1 = 0
            WNumero2 = ""
            WBanco2 = ""
            WImporte2 = 0
            WFecha2 = ""

            WRenglon += 1

            If Val(WImpresion(WCiclo, 5)) <> 0 Then
                WFecha1 = WImpresion(WCiclo, 1)
                WNumero1 = WImpresion(WCiclo, 3)
                WComprobante1 = WImpresion(WCiclo, 2)
                WDescripcion1 = WImpresion(WCiclo, 4)
                WImporte1 = CDbl(WImpresion(WCiclo, 5))
            End If

            If Val(WImpre2(WCiclo, 3)) <> 0 Then
                WNumero2 = WImpre2(WCiclo, 1)
                WBanco2 = WImpre2(WCiclo, 2)
                WImporte2 = CDbl(WImpre2(WCiclo, 3))
                WFecha2 = WImpre2(WCiclo, 4)
            End If

            row = Tabla.NewRow

            With row

                .Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                .Item("Tipo") = 1
                .Item("Orden") = Val(txtOrdenPago.Text)
                .Item("Renglon") = WRenglon
                .Item("Fecha") = txtFecha.Text
                .Item("Proveedor") = Trim(txtProveedor.Text)
                .Item("Nombre") = txtRazonSocial.Text
                .Item("Fecha1") = WFecha1
                .Item("Numero1") = WNumero1
                .Item("Comprobante1") = WComprobante1
                .Item("Descripcion1") = WDescripcion1
                .Item("Importe1") = WImporte1
                .Item("Numero2") = WNumero2
                .Item("Banco2") = WBanco2
                .Item("Importe2") = WImporte2
                .Item("Fecha2") = WFecha2
                .Item("Neto") = XTotal
                .Item("Rete1") = CDbl(txtGanancias.Text)
                .Item("Rete2") = CDbl(txtIngresosBrutos.Text) + CDbl(txtIBCiudad.Text)
                .Item("Total") = CDbl(txtIVA.Text)
                .Item("Observaciones") = txtObservaciones.Text
                .Item("Empresa") = "Surfactan S.A."
                .Item("Cuit") = XEmpCuit
                .Item("Paridad") = CDbl(XParidadTotal)

            End With

            Tabla.Rows.Add(row)

            row = Tabla.NewRow()

            With row
                .Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                .Item("Tipo") = 2
                .Item("Orden") = Val(txtOrdenPago.Text)
                .Item("Renglon") = WRenglon
                .Item("Fecha") = txtFecha.Text
                .Item("Proveedor") = Trim(txtProveedor.Text)
                .Item("Nombre") = txtRazonSocial.Text
                .Item("Fecha1") = WFecha1
                .Item("Numero1") = WNumero1
                .Item("Comprobante1") = WComprobante1
                .Item("Descripcion1") = WDescripcion1
                .Item("Importe1") = WImporte1
                .Item("Numero2") = WNumero2
                .Item("Banco2") = WBanco2
                .Item("Importe2") = WImporte2
                .Item("Fecha2") = WFecha2
                .Item("Neto") = XTotal
                .Item("Rete1") = CDbl(txtGanancias.Text)
                .Item("Rete2") = CDbl(txtIngresosBrutos.Text) + CDbl(txtIBCiudad.Text)
                .Item("Total") = CDbl(txtIVA.Text)
                .Item("Observaciones") = txtObservaciones.Text
                .Item("Empresa") = "Surfactan S.A."
                .Item("Cuit") = XEmpCuit
                .Item("Paridad") = CDbl(XParidadTotal)
            End With

            Tabla.Rows.Add(row)

        Next

        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With


        ' Imprimimos Discrimianción de Valores de Terceros Entregados si el Tipo2 es = 3
        If _DiscriminarValoreDeTerceros(txtOrdenPago.Text) Then
            _ImprimirDiscriminacionDeValoresDeTerceros(XRazon, XCuitProveedor)
        End If

        ' Imprimimos Comprobante de Retención de Ganancias si la hubiese

        If Val(txtGanancias.Text) <> 0 Then
            _ImprimirComprobanteRetencionGanancias(XTotal, txtGanancias.Text)
        End If

        ' Imprimimos Comprobante de Retención de Ingresos Brutos si la hubiese.

        If Val(txtIngresosBrutos.Text) <> 0 Then
            _ImprimirComprobanteRetencionIB()
        End If

        ' Imprimimos Comprobante de Retención de Ingresos Brutos CABA si la hubiese.

        If Val(txtIBCiudad.Text) <> 0 Then
            _ImprimirComprobanteRetencionIBCiudad()
        End If

        ' Imprimimos Comprobante de Retención de Iva si la hubiese.

        If Val(txtIVA.Text) <> 0 Then
            _ImprimirComprobanteRetencionIva()
        End If

    End Sub

    Private Sub _ImprimirComprobanteRetencionIva()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteRetIva
        Dim WTipoIb, WTipoIbCaba, WTipoiva, WTipoprv, WPorceIb, WPorceIbCaba As String
        Dim WEmpNombre As String = "SURFACTAN S.A."
        Dim WEmpDireccion As String = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad As String = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit As String = "30-54916508-3"
        Dim WNroIb As String = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, ZNroInterno, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, ZZTotal, ZZSaldo, ZZSuma, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim WCategoria, WPorce1 As String
        Dim ZRechazado, WImpoRetenido As Double
        Dim ZFechaCompa = String.Join("", Trim(txtFecha.Text).Split("/").Reverse())
        Dim WRete As Double = 0
        Dim WRenglon As Integer = 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WPrvDireccion = .Item("Direccion")
                    WPrvCuit = .Item("Cuit")
                    WPrvIb = .Item("NroIb")
                    WTipoIb = .Item("CodIb")
                    WTipoIbCaba = .Item("CodIbCaba")
                    WTipoiva = Val(.Item("Iva"))
                    WTipoprv = Val(.Item("Tipo")) + 1
                    WPorceIb = IIf(IsDBNull(.Item("PorceIb")), "0", .Item("PorceIb"))
                    WPorceIbCaba = IIf(IsDBNull(.Item("PorceIbCaba")), "0", .Item("PorceIbCaba"))

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        ImpreCopia(1) = "Original"
        ImpreCopia(2) = "Duplicado"

        WImpoRetenido = 0
        ZRechazado = 0
        ZNroInterno = "0"

        ' Preparamos las columnas.
        With Tabla
            .Columns.Add("Clave")
            .Columns.Add("Tipo")
            .Columns.Add("Orden")
            .Columns.Add("Renglon")
            .Columns.Add("Empresa")
            .Columns.Add("Direccion")
            .Columns.Add("Titulo")
            .Columns.Add("Localidad")
            .Columns.Add("Fecha")
            .Columns.Add("Cuit")
            .Columns.Add("Copia")
            .Columns.Add("NroIb")
            .Columns.Add("NroAgente")
            .Columns.Add("NombrePrv")
            .Columns.Add("DireccionPrv")
            .Columns.Add("CuitPrv")
            .Columns.Add("NroIbPrv")
            .Columns.Add("Tipo1")
            .Columns.Add("Numero1")
            .Columns.Add("Fecha1")
            .Columns.Add("Categoria1")
            .Columns.Add("Importe1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Porce1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Retencion1").DataType = System.Type.GetType("System.Double")
        End With


        For iRow = 0 To gridPagos.Rows.Count - 1

            With gridPagos.Rows(iRow)
                WLetra = .Cells(1).Value
                WTipo = .Cells(0).Value
                WPunto = .Cells(2).Value
                WNumero = .Cells(3).Value

                ZRechazado = 0
                ZNroInterno = "0"

                ZZClaveCtaCtePrv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

                XImpre1 = ""

                Select Case Val(.Cells(0).Value)
                    Case 1
                        XImpre1 = "Factura"
                    Case 2
                        XImpre1 = "N.Debito"
                    Case 3
                        XImpre1 = "N.Credito"
                    Case 5
                        XImpre1 = "Anticipo"
                    Case 99
                        XImpre1 = "Varios"
                    Case Else
                        XImpre1 = ""
                End Select

                XImpre2 = Mid(.Cells(3).Value, 1, 8)
                XImpre3 = ""
                ZZTotal = ""
                ZZSaldo = ""
                ZZSuma = ""

                WImpre4 = Val(.Cells(4).Value) / 1.21

                XImpre4 = WImpre4


                If Val(XImpre4) >= 1000 And Val(WNumero) <> 0 Then

                    Try
                        cn.Open()
                        cm.CommandText = "SELECT ccp.Fecha, i.Iva21 FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                        dr = cm.ExecuteReader()

                        If dr.HasRows Then
                            dr.Read()

                            XImpre3 = dr.Item("Fecha")
                            WPorce1 = dr.Item("Iva21")
                        Else
                            XImpre3 = ""
                            WPorce1 = "0"
                        End If

                    Catch ex As Exception
                        MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                    Finally

                        cn.Close()

                    End Try

                End If

                WCategoria = "SUJETO A RETENCION 0.75%"
                WRete = WPorce1

                WRenglon = WRenglon + 1

                row = Tabla.NewRow

                row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 1
                row.Item("Orden") = Val(txtOrdenPago.Text)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = txtFecha.Text
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = txtRazonSocial.Text
                row.Item("DireccionPrv") = WPrvDireccion
                row.Item("CuitPrv") = WPrvCuit
                row.Item("NroIbPrv") = WPrvIb
                row.Item("Tipo1") = XImpre1
                row.Item("Numero1") = XImpre2
                row.Item("Fecha1") = XImpre3
                row.Item("Categoria1") = WCategoria
                row.Item("Importe1") = CDbl(XImpre4)
                row.Item("Porce1") = CDbl(WPorce1)
                row.Item("Retencion1") = CDbl(WRete)

                Tabla.Rows.Add(row)

                row = Tabla.NewRow

                row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 2
                row.Item("Orden") = Val(txtOrdenPago.Text)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = txtFecha.Text
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = txtRazonSocial.Text
                row.Item("DireccionPrv") = WPrvDireccion
                row.Item("CuitPrv") = WPrvCuit
                row.Item("NroIbPrv") = WPrvIb
                row.Item("Tipo1") = XImpre1
                row.Item("Numero1") = XImpre2
                row.Item("Fecha1") = XImpre3
                row.Item("Categoria1") = WCategoria
                row.Item("Importe1") = CDbl(XImpre4)
                row.Item("Porce1") = CDbl(WPorce1)
                row.Item("Retencion1") = CDbl(WRete)

                Tabla.Rows.Add(row)

            End With

        Next

        ' Completamos los renglones faltantes.


        For WRenglon = 1 To 15

            row = Tabla.NewRow

            row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 1
            row.Item("Orden") = Val(txtOrdenPago.Text)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = txtFecha.Text
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = txtRazonSocial.Text
            row.Item("DireccionPrv") = WPrvDireccion
            row.Item("CuitPrv") = WPrvCuit
            row.Item("NroIbPrv") = WPrvIb
            row.Item("Tipo1") = ""
            row.Item("Numero1") = ""
            row.Item("Fecha1") = ""
            row.Item("Categoria1") = ""
            row.Item("Importe1") = 0
            row.Item("Porce1") = 0
            row.Item("Retencion1") = 0

            Tabla.Rows.Add(row)

            row = Tabla.NewRow

            row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 2
            row.Item("Orden") = Val(txtOrdenPago.Text)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = txtFecha.Text
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = txtRazonSocial.Text
            row.Item("DireccionPrv") = WPrvDireccion
            row.Item("CuitPrv") = WPrvCuit
            row.Item("NroIbPrv") = WPrvIb
            row.Item("Tipo1") = ""
            row.Item("Numero1") = ""
            row.Item("Fecha1") = ""
            row.Item("Categoria1") = ""
            row.Item("Importe1") = 0
            row.Item("Porce1") = 0
            row.Item("Retencion1") = 0

            Tabla.Rows.Add(row)
        Next


        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub _ImprimirComprobanteRetencionIBCiudad()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteIBCABA
        Dim WTipoIb, WTipoIbCaba, WTipoiva, WTipoprv, WPorceIb, WPorceIbCaba As String
        Dim WEmpNombre As String = "SURFACTAN S.A."
        Dim WEmpDireccion As String = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad As String = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit As String = "30-54916508-3"
        Dim WNroIb As String = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, ZNroInterno, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, ZZTotal, ZZSaldo, ZZSuma, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim WCategoria, WPorce1 As String
        Dim ZRechazado, WImpoRetenido As Double
        Dim ZFechaCompa = String.Join("", Trim(txtFecha.Text).Split("/").Reverse())
        Dim WRete As Double = 0
        Dim WRenglon As Integer = 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WPrvDireccion = .Item("Direccion")
                    WPrvCuit = .Item("Cuit")
                    WPrvIb = .Item("NroIb")
                    WTipoIb = .Item("CodIb")
                    WTipoIbCaba = .Item("CodIbCaba")
                    WTipoiva = Val(.Item("Iva"))
                    WTipoprv = Val(.Item("Tipo")) + 1
                    WPorceIb = IIf(IsDBNull(.Item("PorceIb")), "0", .Item("PorceIb"))
                    WPorceIbCaba = IIf(IsDBNull(.Item("PorceIbCaba")), "0", .Item("PorceIbCaba"))

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        ImpreCopia(1) = "Original"
        ImpreCopia(2) = "Duplicado"

        WImpoRetenido = 0
        ZRechazado = 0
        ZNroInterno = "0"

        ' Preparamos las columnas.
        With Tabla
            .Columns.Add("Clave")
            .Columns.Add("Tipo")
            .Columns.Add("Orden")
            .Columns.Add("Renglon")
            .Columns.Add("Empresa")
            .Columns.Add("Direccion")
            .Columns.Add("Titulo")
            .Columns.Add("Localidad")
            .Columns.Add("Fecha")
            .Columns.Add("Cuit")
            .Columns.Add("Copia")
            .Columns.Add("NroIb")
            .Columns.Add("NroAgente")
            .Columns.Add("NombrePrv")
            .Columns.Add("DireccionPrv")
            .Columns.Add("CuitPrv")
            .Columns.Add("NroIbPrv")
            .Columns.Add("Tipo1")
            .Columns.Add("Numero1")
            .Columns.Add("Fecha1")
            .Columns.Add("Categoria1")
            .Columns.Add("Importe1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Porce1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Retencion1").DataType = System.Type.GetType("System.Double")
        End With


        For iRow = 0 To gridPagos.Rows.Count - 1

            With gridPagos.Rows(iRow)
                WLetra = .Cells(1).Value
                WTipo = .Cells(0).Value
                WPunto = .Cells(2).Value
                WNumero = .Cells(3).Value

                ZRechazado = 0
                ZNroInterno = "0"

                ZZClaveCtaCtePrv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

                XImpre1 = ""

                Select Case Val(.Cells(0).Value)
                    Case 1
                        XImpre1 = "Factura"
                    Case 2
                        XImpre1 = "N.Debito"
                    Case 3
                        XImpre1 = "N.Credito"
                    Case 5
                        XImpre1 = "Anticipo"
                    Case 99
                        XImpre1 = "Varios"
                    Case Else
                        XImpre1 = ""
                End Select

                XImpre2 = Mid(.Cells(3).Value, 1, 8)
                XImpre3 = ""
                ZZTotal = ""
                ZZSaldo = ""
                ZZSuma = ""

                Try
                    cn.Open()
                    cm.CommandText = "SELECT ccp.NroInterno, ccp.Fecha, ccp.Total, ccp.Saldo, i.Rechazado, i.Neto FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        ZNroInterno = dr.Item("NroInterno")
                        ZRechazado = IIf(IsDBNull(dr.Item("Rechazado")), "0", dr.Item("Rechazado"))
                        XImpre3 = dr.Item("Fecha")

                    Else
                        ZZSuma = Val(.Cells(5).Value) / 1.21
                    End If

                Catch ex As Exception
                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Finally

                    cn.Close()

                End Try

                WImpre4 = Val(.Cells(4).Value)

                If WTipoiva = 2 Then
                    WImpre4 = WImpre4 / 1.21
                End If

                XImpre4 = WImpre4

                If Val(WPorceIbCaba) <> 0 Then
                    WRete = CDbl(XImpre4) * (CDbl(WPorceIbCaba) / 100)
                Else
                    If WTipoIbCaba = 3 Then
                        WRete = CDbl(XImpre4) * (6 / 100)
                    Else
                        WRete = CDbl(XImpre4) * (6 / 100)
                    End If
                End If

                WImpoRetenido = WImpoRetenido + WRete

                If WPorceIbCaba <> 0 Then
                    WCategoria = "SUJETO A RETENCION " & WPorceIbCaba & "%"
                Else
                    If WTipoIbCaba = 3 Then
                        WCategoria = "SUJETO A RETENCION 6%"
                    Else
                        WCategoria = "SUJETO A RETENCION 6%"
                    End If
                End If

                If Val(WPorceIbCaba) <> 0 Then
                    WPorce1 = WPorceIbCaba
                Else
                    WPorce1 = 6
                End If

                WRenglon = WRenglon + 1

                row = Tabla.NewRow

                row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 1
                row.Item("Orden") = Val(txtOrdenPago.Text)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIbCiudad
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = txtFecha.Text
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = txtRazonSocial.Text
                row.Item("DireccionPrv") = WPrvDireccion
                row.Item("CuitPrv") = WPrvCuit
                row.Item("NroIbPrv") = WPrvIb
                row.Item("Tipo1") = XImpre1
                row.Item("Numero1") = XImpre2
                row.Item("Fecha1") = XImpre3
                row.Item("Categoria1") = WCategoria
                row.Item("Importe1") = CDbl(XImpre4)
                row.Item("Porce1") = CDbl(WPorce1)
                row.Item("Retencion1") = WRete

                Tabla.Rows.Add(row)

                row = Tabla.NewRow

                row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 2
                row.Item("Orden") = Val(txtOrdenPago.Text)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIbCiudad
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = txtFecha.Text
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = txtRazonSocial.Text
                row.Item("DireccionPrv") = WPrvDireccion
                row.Item("CuitPrv") = WPrvCuit
                row.Item("NroIbPrv") = WPrvIb
                row.Item("Tipo1") = XImpre1
                row.Item("Numero1") = XImpre2
                row.Item("Fecha1") = XImpre3
                row.Item("Categoria1") = WCategoria
                row.Item("Importe1") = CDbl(XImpre4)
                row.Item("Porce1") = CDbl(WPorce1)
                row.Item("Retencion1") = WRete

                Tabla.Rows.Add(row)

            End With

        Next

        ' Completamos los renglones faltantes.


        For WRenglon = 1 To 15

            row = Tabla.NewRow

            row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 1
            row.Item("Orden") = Val(txtOrdenPago.Text)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = txtFecha.Text
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = txtRazonSocial.Text
            row.Item("DireccionPrv") = WPrvDireccion
            row.Item("CuitPrv") = WPrvCuit
            row.Item("NroIbPrv") = WPrvIb
            row.Item("Tipo1") = ""
            row.Item("Numero1") = ""
            row.Item("Fecha1") = ""
            row.Item("Categoria1") = ""
            row.Item("Importe1") = 0
            row.Item("Porce1") = 0
            row.Item("Retencion1") = 0

            Tabla.Rows.Add(row)

            row = Tabla.NewRow

            row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 2
            row.Item("Orden") = Val(txtOrdenPago.Text)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = txtFecha.Text
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = txtRazonSocial.Text
            row.Item("DireccionPrv") = WPrvDireccion
            row.Item("CuitPrv") = WPrvCuit
            row.Item("NroIbPrv") = WPrvIb
            row.Item("Tipo1") = ""
            row.Item("Numero1") = ""
            row.Item("Fecha1") = ""
            row.Item("Categoria1") = ""
            row.Item("Importe1") = 0
            row.Item("Porce1") = 0
            row.Item("Retencion1") = 0

            Tabla.Rows.Add(row)
        Next


        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub _ImprimirComprobanteRetencionIB()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteIB
        Dim WTipoIb, WTipoIbCaba, WTipoiva, WTipoprv, WPorceIb, WPorceIbCaba As String
        Dim WEmpNombre As String = "SURFACTAN S.A."
        Dim WEmpDireccion As String = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad As String = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit As String = "30-54916508-3"
        Dim WNroIb As String = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, ZNroInterno, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, ZZTotal, ZZSaldo, ZZSuma, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim ZRechazado, WImpoRetenido As Double
        Dim ZFechaCompa = String.Join("", Trim(txtFecha.Text).Split("/").Reverse())
        Dim WRete As Double = 0
        Dim WRenglon As Integer = 0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WPrvDireccion = .Item("Direccion")
                    WPrvCuit = .Item("Cuit")
                    WPrvIb = .Item("NroIb")
                    WTipoIb = .Item("CodIb")
                    WTipoIbCaba = .Item("CodIbCaba")
                    WTipoiva = Val(.Item("Iva"))
                    WTipoprv = Val(.Item("Tipo")) + 1
                    WPorceIb = IIf(IsDBNull(.Item("PorceIb")), "0", .Item("PorceIb"))
                    WPorceIbCaba = IIf(IsDBNull(.Item("PorceIbCaba")), "0", .Item("PorceIbCaba"))

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        ImpreCopia(1) = "Original"
        ImpreCopia(2) = "Duplicado"

        WImpoRetenido = 0
        ZRechazado = 0
        ZNroInterno = "0"

        ' Preparamos las columnas.
        With Tabla
            .Columns.Add("Clave")
            .Columns.Add("Tipo")
            .Columns.Add("Orden")
            .Columns.Add("Renglon")
            .Columns.Add("Empresa")
            .Columns.Add("Direccion")
            .Columns.Add("Titulo")
            .Columns.Add("Localidad")
            .Columns.Add("Fecha")
            .Columns.Add("Cuit")
            .Columns.Add("Copia")
            .Columns.Add("NroIb")
            .Columns.Add("NroAgente")
            .Columns.Add("NombrePrv")
            .Columns.Add("DireccionPrv")
            .Columns.Add("CuitPrv")
            .Columns.Add("NroIbPrv")
            .Columns.Add("Tipo1")
            .Columns.Add("Numero1")
            .Columns.Add("Fecha1")
            .Columns.Add("Categoria1")
            .Columns.Add("Importe1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Porce1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Retencion1").DataType = System.Type.GetType("System.Double")
        End With


        For iRow = 0 To gridPagos.Rows.Count - 1

            With gridPagos.Rows(iRow)
                WLetra = .Cells(1).Value
                WTipo = .Cells(0).Value
                WPunto = .Cells(2).Value
                WNumero = .Cells(3).Value

                ZRechazado = 0
                ZNroInterno = "0"

                ZZClaveCtaCtePrv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

                XImpre1 = ""

                Select Case Val(.Cells(0).Value)
                    Case 1
                        XImpre1 = "Factura"
                    Case 2
                        XImpre1 = "N.Debito"
                    Case 3
                        XImpre1 = "N.Credito"
                    Case 5
                        XImpre1 = "Anticipo"
                    Case 99
                        XImpre1 = "Varios"
                    Case Else
                        XImpre1 = ""
                End Select

                XImpre2 = Mid(.Cells(3).Value, 1, 8)
                XImpre3 = ""
                ZZTotal = ""
                ZZSaldo = ""
                ZZSuma = ""

                Try
                    cn.Open()
                    cm.CommandText = "SELECT ccp.NroInterno, ccp.Fecha, ccp.Total, ccp.Saldo, i.Rechazado, i.Neto FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        ZNroInterno = dr.Item("NroInterno")
                        ZRechazado = IIf(IsDBNull(dr.Item("Rechazado")), "0", dr.Item("Rechazado"))
                        XImpre3 = dr.Item("Fecha")
                        ZZTotal = dr.Item("Total")
                        ZZSaldo = dr.Item("Saldo")

                        ZZSuma = dr.Item("Neto")

                    Else
                        ZZSuma = Val(.Cells(5).Value) / 1.21
                    End If

                Catch ex As Exception
                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Finally

                    cn.Close()

                End Try

                WImpre4 = Val(.Cells(4).Value)

                If WTipoiva = 2 Then
                    If Val(ZZSuma) <> 0 Then
                        WImpre4 = ZZSuma
                    Else
                        WImpre4 = WImpre4 / 1.21
                    End If
                End If

                XImpre4 = WImpre4

                If Val(ZFechaCompa) >= 20071201 Then
                    Select Case WTipoIb
                        Case 0, 1
                            WRete = CDbl(XImpre4) * (CDbl(WPorceIb) / 100)
                            'Call redondeo(WRete)
                            WImpoRetenido = WImpoRetenido + WRete

                            WRenglon = WRenglon + 1

                            row = Tabla.NewRow

                            row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                            row.Item("Tipo") = 1
                            row.Item("Orden") = Val(txtOrdenPago.Text)
                            row.Item("Renglon") = WRenglon
                            row.Item("Empresa") = WEmpNombre
                            row.Item("Direccion") = WEmpDireccion
                            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                            row.Item("Localidad") = WEmpLocalidad
                            row.Item("Fecha") = txtFecha.Text
                            row.Item("Cuit") = WEmpCuit
                            row.Item("Copia") = ImpreCopia(1)
                            row.Item("NroIb") = WNroIb
                            row.Item("NroAgente") = "" 'WNroAgente
                            row.Item("NombrePrv") = txtRazonSocial.Text
                            row.Item("DireccionPrv") = WPrvDireccion
                            row.Item("CuitPrv") = WPrvCuit
                            row.Item("NroIbPrv") = WPrvIb
                            row.Item("Tipo1") = XImpre1
                            row.Item("Numero1") = XImpre2
                            row.Item("Fecha1") = XImpre3
                            row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(WPorceIb) & " %"
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = CDbl(WPorceIb)
                            row.Item("Retencion1") = WRete

                            Tabla.Rows.Add(row)

                            row = Tabla.NewRow

                            row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                            row.Item("Tipo") = 2
                            row.Item("Orden") = Val(txtOrdenPago.Text)
                            row.Item("Renglon") = WRenglon
                            row.Item("Empresa") = WEmpNombre
                            row.Item("Direccion") = WEmpDireccion
                            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                            row.Item("Localidad") = WEmpLocalidad
                            row.Item("Fecha") = txtFecha.Text
                            row.Item("Cuit") = WEmpCuit
                            row.Item("Copia") = ImpreCopia(1)
                            row.Item("NroIb") = WNroIb
                            row.Item("NroAgente") = "" 'WNroAgente
                            row.Item("NombrePrv") = txtRazonSocial.Text
                            row.Item("DireccionPrv") = WPrvDireccion
                            row.Item("CuitPrv") = WPrvCuit
                            row.Item("NroIbPrv") = WPrvIb
                            row.Item("Tipo1") = XImpre1
                            row.Item("Numero1") = XImpre2
                            row.Item("Fecha1") = XImpre3
                            row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(WPorceIb) & " %"
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = CDbl(WPorceIb)
                            row.Item("Retencion1") = WRete

                            Tabla.Rows.Add(row)
                            
                        Case Else
                    End Select
                Else
                    Select Case WTipoIb
                        Case 0
                            WPorceIb = "0,75"
                            WRete = Val(XImpre4) * (0.75 / 100)
                            Call redondeo(WRete)
                            WImpoRetenido = WImpoRetenido + WRete

                            WRenglon = WRenglon + 1

                            row = Tabla.NewRow

                            row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                            row.Item("Tipo") = 1
                            row.Item("Orden") = Val(txtOrdenPago.Text)
                            row.Item("Renglon") = WRenglon
                            row.Item("Empresa") = WEmpNombre
                            row.Item("Direccion") = WEmpDireccion
                            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                            row.Item("Localidad") = WEmpLocalidad
                            row.Item("Fecha") = txtFecha.Text
                            row.Item("Cuit") = WEmpCuit
                            row.Item("Copia") = ImpreCopia(1)
                            row.Item("NroIb") = WNroIb
                            row.Item("NroAgente") = "" 'WNroAgente
                            row.Item("NombrePrv") = txtRazonSocial.Text
                            row.Item("DireccionPrv") = WPrvDireccion
                            row.Item("CuitPrv") = WPrvCuit
                            row.Item("NroIbPrv") = WPrvIb
                            row.Item("Tipo1") = XImpre1
                            row.Item("Numero1") = XImpre2
                            row.Item("Fecha1") = XImpre3
                            row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(WPorceIb) & " %"
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = CDbl(WPorceIb)
                            row.Item("Retencion1") = WRete

                            Tabla.Rows.Add(row)

                            row = Tabla.NewRow

                            row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                            row.Item("Tipo") = 2
                            row.Item("Orden") = Val(txtOrdenPago.Text)
                            row.Item("Renglon") = WRenglon
                            row.Item("Empresa") = WEmpNombre
                            row.Item("Direccion") = WEmpDireccion
                            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                            row.Item("Localidad") = WEmpLocalidad
                            row.Item("Fecha") = txtFecha.Text
                            row.Item("Cuit") = WEmpCuit
                            row.Item("Copia") = ImpreCopia(1)
                            row.Item("NroIb") = WNroIb
                            row.Item("NroAgente") = "" 'WNroAgente
                            row.Item("NombrePrv") = txtRazonSocial.Text
                            row.Item("DireccionPrv") = WPrvDireccion
                            row.Item("CuitPrv") = WPrvCuit
                            row.Item("NroIbPrv") = WPrvIb
                            row.Item("Tipo1") = XImpre1
                            row.Item("Numero1") = XImpre2
                            row.Item("Fecha1") = XImpre3
                            row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(WPorceIb) & " %"
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = CDbl(WPorceIb)
                            row.Item("Retencion1") = WRete

                            Tabla.Rows.Add(row)

                        Case Else
                            WPorceIb = "1,75"
                            WRete = Val(XImpre4) * (1.75 / 100)
                            Call redondeo(WRete)
                            WImpoRetenido = WImpoRetenido + WRete

                            WRenglon = WRenglon + 1

                            row = Tabla.NewRow

                            row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                            row.Item("Tipo") = 1
                            row.Item("Orden") = Val(txtOrdenPago.Text)
                            row.Item("Renglon") = WRenglon
                            row.Item("Empresa") = WEmpNombre
                            row.Item("Direccion") = WEmpDireccion
                            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                            row.Item("Localidad") = WEmpLocalidad
                            row.Item("Fecha") = txtFecha.Text
                            row.Item("Cuit") = WEmpCuit
                            row.Item("Copia") = ImpreCopia(1)
                            row.Item("NroIb") = WNroIb
                            row.Item("NroAgente") = "" 'WNroAgente
                            row.Item("NombrePrv") = txtRazonSocial.Text
                            row.Item("DireccionPrv") = WPrvDireccion
                            row.Item("CuitPrv") = WPrvCuit
                            row.Item("NroIbPrv") = WPrvIb
                            row.Item("Tipo1") = XImpre1
                            row.Item("Numero1") = XImpre2
                            row.Item("Fecha1") = XImpre3
                            row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(WPorceIb) & " %"
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = CDbl(WPorceIb)
                            row.Item("Retencion1") = WRete

                            Tabla.Rows.Add(row)

                            row = Tabla.NewRow

                            row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
                            row.Item("Tipo") = 2
                            row.Item("Orden") = Val(txtOrdenPago.Text)
                            row.Item("Renglon") = WRenglon
                            row.Item("Empresa") = WEmpNombre
                            row.Item("Direccion") = WEmpDireccion
                            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                            row.Item("Localidad") = WEmpLocalidad
                            row.Item("Fecha") = txtFecha.Text
                            row.Item("Cuit") = WEmpCuit
                            row.Item("Copia") = ImpreCopia(1)
                            row.Item("NroIb") = WNroIb
                            row.Item("NroAgente") = "" 'WNroAgente
                            row.Item("NombrePrv") = txtRazonSocial.Text
                            row.Item("DireccionPrv") = WPrvDireccion
                            row.Item("CuitPrv") = WPrvCuit
                            row.Item("NroIbPrv") = WPrvIb
                            row.Item("Tipo1") = XImpre1
                            row.Item("Numero1") = XImpre2
                            row.Item("Fecha1") = XImpre3
                            row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(WPorceIb) & " %"
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = CDbl(WPorceIb)
                            row.Item("Retencion1") = WRete

                            Tabla.Rows.Add(row)

                    End Select
                End If


            End With

        Next

        ' Completamos los renglones faltantes.


        For WRenglon = 1 To 15

            row = Tabla.NewRow

            row.Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 1
            row.Item("Orden") = Val(txtOrdenPago.Text)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = txtFecha.Text
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = txtRazonSocial.Text
            row.Item("DireccionPrv") = WPrvDireccion
            row.Item("CuitPrv") = WPrvCuit
            row.Item("NroIbPrv") = WPrvIb
            row.Item("Tipo1") = ""
            row.Item("Numero1") = ""
            row.Item("Fecha1") = ""
            row.Item("Categoria1") = ""
            row.Item("Importe1") = 0
            row.Item("Porce1") = 0
            row.Item("Retencion1") = 0

            Tabla.Rows.Add(row)

            row = Tabla.NewRow

            row.Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 2
            row.Item("Orden") = Val(txtOrdenPago.Text)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = txtFecha.Text
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = txtRazonSocial.Text
            row.Item("DireccionPrv") = WPrvDireccion
            row.Item("CuitPrv") = WPrvCuit
            row.Item("NroIbPrv") = WPrvIb
            row.Item("Tipo1") = ""
            row.Item("Numero1") = ""
            row.Item("Fecha1") = ""
            row.Item("Categoria1") = ""
            row.Item("Importe1") = 0
            row.Item("Porce1") = 0
            row.Item("Retencion1") = 0

            Tabla.Rows.Add(row)
        Next


        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With




    End Sub

    Private Sub _ImprimirComprobanteRetencionGanancias(ByVal Total As String, ByVal Retencion As String)
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteRetGanancias
        Dim WEmpNombre As String = "SURFACTAN S.A."
        Dim WEmpDireccion As String = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad As String = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit As String = "30-54916508-3"
        Dim Mes As String = Val(Mid$(txtFecha.Text, 3, 2))
        Dim WCuatri As String = ""
        Dim WLeyenda(10) As String

        WLeyenda(1) = "Compra de Bienes"
        WLeyenda(2) = "Ejericio Prof. Lib. c/Aj.Inf."
        WLeyenda(3) = "Alquileres y Arrendamientos"
        WLeyenda(6) = "Locacion de Obras y/o servicios"
        WLeyenda(7) = "Transporte de Carga"
        WLeyenda(8) = "Factura M"

        If Mes <= 4 Then
            WCuatri = "Primer Cuatrimestre"
        Else
            If Mes >= 5 And Mes <= 8 Then
                WCuatri = "Segundo Cuatrimestre"
            Else
                If Mes >= 9 Then
                    WCuatri = "Tercer Cuatrimestre"
                End If
            End If
        End If

        Dim _DatosProv() As String = _TraerDatosProveedor(txtOrdenPago.Text)

        ' Por defecto son de tipo String, asi que solamente defino explicitamente las de tipo Double.
        With Tabla
            .Columns.Add("Clave")
            .Columns.Add("Tipo")
            .Columns.Add("Orden")
            .Columns.Add("Renglon")
            .Columns.Add("NroCertificado")
            .Columns.Add("Empresa")
            .Columns.Add("Direccion")
            .Columns.Add("Localidad")
            .Columns.Add("Fecha")
            .Columns.Add("Cuit")
            .Columns.Add("NombrePrv")
            .Columns.Add("DireccionPrv")
            .Columns.Add("CuitPrv")
            .Columns.Add("Concepto")
            .Columns.Add("Pagado").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Retenido").DataType = System.Type.GetType("System.Double")
        End With

        row = Tabla.NewRow

        With row
            .Item("Clave") = "1" + ceros(txtOrdenPago.Text, 6) + "00"
            .Item("Tipo") = 1
            .Item("Orden") = Val(txtOrdenPago.Text)
            .Item("Renglon") = 0
            .Item("NroCertificado") = _DatosProv(0)
            .Item("Empresa") = WEmpNombre
            .Item("Direccion") = WEmpDireccion
            .Item("Localidad") = WEmpLocalidad
            .Item("Fecha") = txtFecha.Text
            .Item("Cuit") = WEmpCuit
            .Item("NombrePrv") = _DatosProv(5)
            .Item("DireccionPrv") = _DatosProv(4)
            .Item("CuitPrv") = _DatosProv(6)
            .Item("Concepto") = WLeyenda(Val(_DatosProv(7)))
            .Item("Pagado") = CDbl(Total - Retencion)
            .Item("Pagado") = CDbl(Total)
            .Item("Retenido") = CDbl(Retencion)
        End With

        Tabla.Rows.Add(row)

        row = Tabla.NewRow

        With row
            .Item("Clave") = "2" + ceros(txtOrdenPago.Text, 6) + "00"
            .Item("Tipo") = 2
            .Item("Orden") = Val(txtOrdenPago.Text)
            .Item("Renglon") = 0
            .Item("NroCertificado") = _DatosProv(0)
            .Item("Empresa") = WEmpNombre
            .Item("Direccion") = WEmpDireccion
            .Item("Localidad") = WEmpLocalidad
            .Item("Fecha") = txtFecha.Text
            .Item("Cuit") = WEmpCuit
            .Item("NombrePrv") = _DatosProv(5)
            .Item("DireccionPrv") = _DatosProv(4)
            .Item("CuitPrv") = _DatosProv(6)
            .Item("Concepto") = WLeyenda(Val(_DatosProv(7)))
            .Item("Pagado") = CDbl(Total - Retencion)
            .Item("Pagado") = CDbl(Total)
            .Item("Retenido") = CDbl(Retencion)
        End With

        Tabla.Rows.Add(row)

        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With

    End Sub

    Private Function _TraerDatosProveedor(ByVal ordenpago As String) As String()
        Dim datos(8) As String
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT p.CertificadoGan, p.CertificadoIb, p.CertificadoIbCiudad, p.CertificadoIva, pr.Direccion, pr.Nombre, pr.Cuit, pr.Tipo " _
                                            & "FROM Pagos as p, Proveedor as pr where p.clave = '07239901' and p.Proveedor = pr.Proveedor")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    ' Agregamos los datos.
                    datos(0) = .Item("CertificadoGan").ToString()
                    datos(1) = .Item("CertificadoIb").ToString()
                    datos(2) = .Item("CertificadoIbCiudad").ToString()
                    datos(3) = .Item("CertificadoIva").ToString()
                    datos(4) = .Item("Direccion").ToString()
                    datos(5) = .Item("Nombre").ToString()
                    datos(6) = .Item("Cuit").ToString()
                    datos(7) = Val(.Item("Tipo") + 1).ToString()

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

        Return datos
    End Function

    Private Sub _ImprimirDiscriminacionDeValoresDeTerceros(ByVal XRazon As String, ByVal XCuitProveedor As String)
        Dim ZZCorte, ZZOrden, ZZRenglon, ZZProveedor, ZZFecha, ZZImporteCheque, ZZNumeroCheque, ZZFechaCheque, ZZBancoCheque, ZZCuit As String
        Dim LugarResumen As Integer = 0

        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As New OrdenPagoDiscriminacionTerceros

        _PrepararTablaOrdenPagoDiscriminacionTerceros(Tabla)

        For iRow = 0 To gridFormaPagos.Rows.Count - 1
            With gridFormaPagos.Rows(iRow)
                If Val(.Cells(5).Value) <> 0 Then
                    If Val(.Cells(0).Value) = 3 Then

                        ZZCorte = "1"
                        ZZOrden = txtOrdenPago.Text
                        ZZRenglon = Str$(LugarResumen)
                        ZZProveedor = txtProveedor.Text
                        ZZFecha = txtFecha.Text
                        ZZImporteCheque = CDbl(.Cells(5).Value)
                        ZZNumeroCheque = .Cells(1).Value
                        ZZFechaCheque = .Cells(2).Value
                        ZZBancoCheque = .Cells(4).Value
                        ZZCuit = .Cells(7).Value

                        row = Tabla.NewRow

                        With row

                            .Item("Corte") = "1"
                            .Item("Orden") = ZZOrden
                            .Item("Renglon") = ZZRenglon
                            .Item("Proveedor") = ZZProveedor
                            .Item("Fecha") = ZZFecha
                            .Item("Cuit") = ZZCuit
                            .Item("Importe") = CDbl(ZZImporteCheque)
                            .Item("Numero") = ZZNumeroCheque
                            .Item("Fecha1") = ZZFechaCheque
                            .Item("Banco") = ZZBancoCheque
                            .Item("Razon") = XRazon
                            .Item("CuitProveedor") = XCuitProveedor

                        End With

                        Tabla.Rows.Add(row)

                        row = Tabla.NewRow()

                        With row
                            .Item("Corte") = "2"
                            .Item("Orden") = ZZOrden
                            .Item("Renglon") = ZZRenglon
                            .Item("Proveedor") = ZZProveedor
                            .Item("Fecha") = ZZFecha
                            .Item("Cuit") = ZZCuit
                            .Item("Importe") = CDbl(ZZImporteCheque)
                            .Item("Numero") = ZZNumeroCheque
                            .Item("Fecha1") = ZZFechaCheque
                            .Item("Banco") = ZZBancoCheque
                            .Item("Razon") = XRazon
                            .Item("CuitProveedor") = XCuitProveedor
                        End With

                        Tabla.Rows.Add(row)

                        LugarResumen = LugarResumen + 1

                    End If
                End If
            End With
        Next iRow

        ' Completamos los renglones que resten.
        For iRow = LugarResumen To 14

            ZZCorte = "1"
            ZZOrden = txtOrdenPago.Text
            ZZRenglon = Str$(LugarResumen)
            ZZProveedor = txtProveedor.Text
            ZZFecha = txtFecha.Text
            ZZImporteCheque = ""
            ZZNumeroCheque = ""
            ZZFechaCheque = ""
            ZZBancoCheque = ""
            ZZCuit = ""

            row = Tabla.NewRow

            With row

                .Item("Corte") = "1"
                .Item("Orden") = ZZOrden
                .Item("Renglon") = ZZRenglon
                .Item("Proveedor") = ZZProveedor
                .Item("Fecha") = ZZFecha
                .Item("Cuit") = ZZCuit
                .Item("Importe") = 0
                .Item("Numero") = ZZNumeroCheque
                .Item("Fecha1") = ZZFechaCheque
                .Item("Banco") = ZZBancoCheque
                .Item("Razon") = XRazon
                .Item("CuitProveedor") = XCuitProveedor

            End With

            Tabla.Rows.Add(row)

            row = Tabla.NewRow()

            With row
                .Item("Corte") = "2"
                .Item("Orden") = ZZOrden
                .Item("Renglon") = ZZRenglon
                .Item("Proveedor") = ZZProveedor
                .Item("Fecha") = ZZFecha
                .Item("Cuit") = ZZCuit
                .Item("Importe") = 0
                .Item("Numero") = ZZNumeroCheque
                .Item("Fecha1") = ZZFechaCheque
                .Item("Banco") = ZZBancoCheque
                .Item("Razon") = XRazon
                .Item("CuitProveedor") = XCuitProveedor
            End With

            Tabla.Rows.Add(row)

            LugarResumen = LugarResumen + 1

        Next iRow

        If Tabla.Rows.Count > 0 Then

            crdoc.SetDataSource(Tabla)

            With VistaPrevia
                .CrystalReportViewer1.ReportSource = crdoc
                .ShowDialog()
                .Dispose()
            End With

        End If
    End Sub

    Private Function _DiscriminarValoreDeTerceros(ByVal Orden As String) As Boolean
        Dim discriminar As Boolean = True

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Tipo2 FROM Pagos WHERE Orden = '" & ceros(Orden, 6) & "' AND Tipo2 = '3'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If Not dr.HasRows Then
                discriminar = False
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return discriminar
    End Function


    Private Sub _PrepararTablaOrdenPagoDiscriminacionTerceros(ByRef Tabla As DataTable)
        ' Por defecto son de tipo String, asi que solamente defino explicitamente las de tipo Double.
        With Tabla
            .Columns.Add("Corte")
            .Columns.Add("Orden")
            .Columns.Add("Renglon")
            .Columns.Add("Proveedor")
            .Columns.Add("Fecha")
            .Columns.Add("Cuit")
            .Columns.Add("Importe").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Numero")
            .Columns.Add("Fecha1")
            .Columns.Add("Banco")
            .Columns.Add("Razon")
            .Columns.Add("CuitProveedor")
        End With
    End Sub

    Private Function _TraerCuentaBanco(ByVal ClaveBanco As String) As String
        Dim cuenta As String = ""

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cuenta FROM Banco WHERE Banco = '" & Trim(ClaveBanco) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                cuenta = Trim(dr.Item("Cuenta"))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return cuenta
    End Function

    Private Sub _ImprimirResumenDePago()
        'For iRow = 1 To 15
        '    If Val(WVector1.TextMatrix(iRow, 12)) <> 0 Then
        '        If Val(WVector1.TextMatrix(iRow, 7)) = 3 Then

        '            SumaTercero = SumaTercero + Val(WVector1.TextMatrix(iRow, 12))

        '            LugarResumen = LugarResumen + 1

        '            ZZCorte = "1"
        '            ZZOrden = Orden.Text
        '            ZZRenglon = Str$(LugarResumen)
        '            ZZProveedor = Proveedor.Text
        '            ZZFecha = Fecha.Text
        '            ZZImporteCheque = WVector1.TextMatrix(iRow, 12)
        '            ZZNumeroCheque = Left$(WVector1.TextMatrix(iRow, 8), 8)
        '            ZZFechaCheque = Left$(WVector1.TextMatrix(iRow, 9), 10)
        '            ZZBancoCheque = Left$(WVector1.TextMatrix(iRow, 11), 20)
        '            ZZCuit = WVector1.TextMatrix(iRow, 14)

        '            ZSql = ""
        '            ZSql = ZSql + "INSERT INTO PagosResumen ("
        '            ZSql = ZSql + "Corte ,"
        '            ZSql = ZSql + "Orden ,"
        '            ZSql = ZSql + "Renglon ,"
        '            ZSql = ZSql + "Proveedor ,"
        '            ZSql = ZSql + "Fecha ,"
        '            ZSql = ZSql + "Cuit ,"
        '            ZSql = ZSql + "ImporteCheque ,"
        '            ZSql = ZSql + "NumeroCheque ,"
        '            ZSql = ZSql + "FechaCheque ,"
        '            ZSql = ZSql + "BancoCheque ,"
        '            ZSql = ZSql + "Razon ,"
        '            ZSql = ZSql + "CuitProveedor )"
        '            ZSql = ZSql + "Values ("
        '            ZSql = ZSql + "'" + ZZCorte + "',"
        '            ZSql = ZSql + "'" + ZZOrden + "',"
        '            ZSql = ZSql + "'" + ZZRenglon + "',"
        '            ZSql = ZSql + "'" + ZZProveedor + "',"
        '            ZSql = ZSql + "'" + ZZFecha + "',"
        '            ZSql = ZSql + "'" + ZZCuit + "',"
        '            ZSql = ZSql + "'" + ZZImporteCheque + "',"
        '            ZSql = ZSql + "'" + ZZNumeroCheque + "',"
        '            ZSql = ZSql + "'" + ZZFechaCheque + "',"
        '            ZSql = ZSql + "'" + ZZBancoCheque + "',"
        '            ZSql = ZSql + "'" + ZZRazon + "',"
        '            ZSql = ZSql + "'" + ZZCuitProveedor + "')"

        '            spPagosResumen = ZSql
        '            rstPagosResumen = db.OpenRecordset(spPagosResumen, dbOpenSnapshot, dbSQLPassThrough)

        '            ZZCorte = "2"

        '            ZSql = ""
        '            ZSql = ZSql + "INSERT INTO PagosResumen ("
        '            ZSql = ZSql + "Corte ,"
        '            ZSql = ZSql + "Orden ,"
        '            ZSql = ZSql + "Renglon ,"
        '            ZSql = ZSql + "Proveedor ,"
        '            ZSql = ZSql + "Fecha ,"
        '            ZSql = ZSql + "Cuit ,"
        '            ZSql = ZSql + "ImporteCheque ,"
        '            ZSql = ZSql + "NumeroCheque ,"
        '            ZSql = ZSql + "FechaCheque ,"
        '            ZSql = ZSql + "BancoCheque ,"
        '            ZSql = ZSql + "Razon ,"
        '            ZSql = ZSql + "CuitProveedor )"
        '            ZSql = ZSql + "Values ("
        '            ZSql = ZSql + "'" + ZZCorte + "',"
        '            ZSql = ZSql + "'" + ZZOrden + "',"
        '            ZSql = ZSql + "'" + ZZRenglon + "',"
        '            ZSql = ZSql + "'" + ZZProveedor + "',"
        '            ZSql = ZSql + "'" + ZZFecha + "',"
        '            ZSql = ZSql + "'" + ZZCuit + "',"
        '            ZSql = ZSql + "'" + ZZImporteCheque + "',"
        '            ZSql = ZSql + "'" + ZZNumeroCheque + "',"
        '            ZSql = ZSql + "'" + ZZFechaCheque + "',"
        '            ZSql = ZSql + "'" + ZZBancoCheque + "',"
        '            ZSql = ZSql + "'" + ZZRazon + "',"
        '            ZSql = ZSql + "'" + ZZCuitProveedor + "')"

        '            spPagosResumen = ZSql
        '            rstPagosResumen = db.OpenRecordset(spPagosResumen, dbOpenSnapshot, dbSQLPassThrough)

        '        End If
        '    End If
        'Next iRow
    End Sub

    Private Sub _PrepararTablaOrdenPago(ByRef tabla As DataTable)
        ' Por defecto son de tipo String, asi que solamente defino explicitamente las de tipo Double.
        With tabla
            .Columns.Add("Clave")
            .Columns.Add("Tipo")
            .Columns.Add("Orden")
            .Columns.Add("Renglon")
            .Columns.Add("Fecha")
            .Columns.Add("Proveedor")
            .Columns.Add("Nombre")
            .Columns.Add("Fecha1")
            .Columns.Add("Numero1")
            .Columns.Add("Comprobante1")
            .Columns.Add("Descripcion1")
            .Columns.Add("Importe1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Numero2")
            .Columns.Add("Banco2")
            .Columns.Add("Importe2").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Fecha2")
            .Columns.Add("Neto").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Rete1").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Rete2").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Total").DataType = System.Type.GetType("System.Double")
            .Columns.Add("Observaciones")
            .Columns.Add("Empresa")
            .Columns.Add("Cuit")
            .Columns.Add("Paridad").DataType = System.Type.GetType("System.Double")
        End With
    End Sub

    Private Sub lstSeleccion_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSeleccion.MouseClick
        If Trim(lstSeleccion.SelectedItem) = "" Then : Exit Sub : End If

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

    Private Sub CLBFiltrado_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CLBFiltrado.MouseClick
        If Trim(CLBFiltrado.SelectedItem) = "" Then
            Exit Sub
        End If

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

                    _TraerCtaCte(CLBFiltrado.SelectedItem, indice)

                Case 2

                    _TraerChequeDeTercero(CLBFiltrado.SelectedItem, indice)

                Case Else
                    Exit Sub
            End Select

            CLBFiltrado.Visible = False
            txtConsulta.Text = ""
            txtConsulta.Focus()
        End If
    End Sub

    Private Sub lstConsulta_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstConsulta.MouseClick

        If Trim(_TipoConsulta) = "" Then
            Exit Sub
        End If

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


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrdenPago.KeyPress, txtProveedor.KeyPress, txtBanco.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            Debug.Print(Proceso._ValidarFecha(Trim(txtFechaAux.Text)))

            If Proceso._ValidarFecha(Trim(txtFechaAux.Text)) And WRow >= 0 And Wcol >= 0 Then

                With gridFormaPagos
                    .Rows(WRow).Cells(2).Value = txtFechaAux.Text

                    .CurrentCell = .Rows(WRow).Cells(3)
                    .Focus()

                    txtFechaAux.Visible = False
                    txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With
                
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub gridRecibos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFormaPagos.CellClick
        With gridFormaPagos
            If e.ColumnIndex = 2 Then
                Dim iRow, iCol As Integer
                iRow = e.RowIndex
                iCol = e.ColumnIndex

                .CurrentCell = .Rows(iRow).Cells(iCol + 1)

                Dim _location As Point = .GetCellDisplayRectangle(2, iRow, False).Location

                '.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                .ClearSelection()
                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - 1.5
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - 3
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(iRow).Cells(2).Value
                WRow = iRow
                Wcol = iCol
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With

    End Sub

    Private Sub gridRecibos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFormaPagos.CellEnter
        With gridFormaPagos
            If e.ColumnIndex = 2 Then
                '.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                Dim _location As Point = .GetCellDisplayRectangle(2, e.RowIndex, False).Location

                .ClearSelection()
                _location.Y += YMARGEN '183 '(4 + 180)
                _location.X += XMARGEN '(7 + 10)
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells(2).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With
    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Dim tabla As DataTable = New DataTable("Detalles")
        Dim DiasTasa As String = ""
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
        For i = 0 To gridFormaPagos.Rows.Count - 1

            With gridFormaPagos.Rows(i)

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

                    row.Item("CodigoCliente") = txtProveedor.Text
                    row.Item("Cliente") = txtRazonSocial.Text
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

        '_Imprimir(crdoc)
        _VistaPrevia(crdoc)

        MsgBox("El interes a pagar es de " + Str$(ZZSuma), MsgBoxStyle.Information, "Ordenes de Pago")
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

    Private Sub _Imprimir(ByVal crdoc As ReportDocument, Optional ByVal cant As Integer = 1)
        crdoc.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Private Sub _VistaPrevia(ByVal crdoc As ReportDocument)
        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub gridFormaPagos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridFormaPagos.CellMouseDoubleClick

        Dim iRow As DataGridViewRow

        iRow = gridFormaPagos.Rows(e.RowIndex)

        If MsgBox("¿Está seguro de querer eliminar la fila?", MsgBoxStyle.YesNo, MsgBoxStyle.Information) = DialogResult.No Then
            Exit Sub
        End If

        gridFormaPagos.Rows.Remove(iRow)

    End Sub

    Private Sub lblPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPagos.TextChanged
        ' Recalculamos los valores de Retenciones.

        ' Recalculo de Retenciones de Ganancias.
        _RecalcularRetencionGanancias()

        ' Recalculo de Retenciones por Iva.
        _RecalcularRetencionIVA()

        ' Recalculo IB Provincia
        _RecalcularIBProvincia()

        ' Recalculo IB CABA
        _RecalcularIBCABA()

    End Sub

    Private Sub _RecalcularIBCABA()
        
        Dim ZImporte, ZZSuma, ZZBase, acumCaba

        acumCaba = 0

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Not IsNothing(.Cells(4).Value) Then

                    ZImporte = 0
                    ZZSuma = 0
                    ZZBase = 0
                    
                    ZImporte = .Cells(4).Value

                    ZZSuma = Val(ZImporte) / 1.21
                    ZZBase = ZZSuma

                    acumCaba += CaculoRetencionIngresosBrutosCaba(Val(WTipoIbCaba), WPorceIbCaba, Val(ZZSuma))

                End If
            End With
        Next

        txtIBCiudad.Text = _NormalizarNumero(acumCaba)

    End Sub

    Private Sub _RecalcularIBProvincia()
        Dim acumProv, acumCaba

        Dim varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva, varOrdFecha
        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal, ZZSaldo
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma, ZZTotal, ZZBase, ZZSumaNeto

        acumProv = 0
        acumCaba = 0

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Not IsNothing(.Cells(4).Value) Then

                    ZNeto = 0
                    ZIva = 0
                    ZIva5 = 0
                    ZIva27 = 0
                    ZIva105 = 0
                    ZIb = 0
                    ZExento = 0
                    ZPorce = 0
                    ZImporte = 0
                    ZZSuma = 0
                    ZZTotal = 0
                    ZZBase = 0
                    ZZSumaNeto = 0

                    ZTipo = ""
                    ZNumero = ""
                    ZPunto = ""
                    ZLetra = ""
                    ZTotal = 0
                    ZZSaldo = 0

                    varAcuNeto = 0
                    varAcuRetenido = 0
                    varAcuAnticipo = 0
                    varAcuBruto = 0
                    varAcuIva = 0

                    varOrdFecha = Mid(ordenaFecha(txtFecha.Text), 3, 4)

                    Dim CampoAcumulado As LeeAcumulado = DaoAcumulado.buscarAcumulado(txtProveedor.Text, varOrdFecha)

                    If Not IsNothing(CampoAcumulado) Then

                        varAcuNeto = CampoAcumulado.neto
                        varAcuRetenido = CampoAcumulado.retenido
                        varAcuAnticipo = CampoAcumulado.anticipo
                        varAcuBruto = CampoAcumulado.bruto
                        varAcuIva = CampoAcumulado.iva

                    End If

                    ' Recalculo sobre porcentaje neto en Iva Comp.
                    If Not IsNothing(.Cells(4).Value) Then
                        ZTipo = .Cells(0).Value
                        ZLetra = .Cells(1).Value
                        ZPunto = .Cells(2).Value
                        ZNumero = .Cells(3).Value
                        ZImporte = .Cells(4).Value

                        Dim ZClaveCtaCtePrv As String = txtProveedor.Text & ZLetra & ZTipo & ZPunto & ZNumero

                        'acum += CaculoRetencionIngresosBrutos(Val(WTipoIb), WPorceIb, Val(_NormalizarNumero(.Cells(4).Value)))
                        ' Buscamos la factura
                        Dim CtaCtePrv As DataRow = _BuscarCtaCteProv(ZClaveCtaCtePrv)

                        'If Val(CtaCtePrv.Item("NroInterno")) = 0 Then : Exit Sub : End If

                        Dim ZNroInterno As Integer = 0

                        If Not IsNothing(CtaCtePrv) Then
                            ZNroInterno = Val(CtaCtePrv.Item("NroInterno"))

                            ZZTotal = CtaCtePrv.Item("Total")
                            ZZSaldo = CtaCtePrv.Item("Saldo")

                        End If



                        Dim ZFactura As Compra = DAOCompras.buscarCompraPorCodigo(ZNroInterno)

                        If Not IsNothing(ZFactura) Then



                            ZNeto = ZFactura.neto

                            If Val(ZImporte) = Val(ZZTotal) And ZNroInterno <> 0 Then

                                ZZSuma = ZNeto

                            Else

                                ZIva = ZFactura.iva21
                                ZIva5 = ZFactura.ivaRG
                                ZIva27 = ZFactura.iva27
                                ZIva105 = ZFactura.iva105
                                ZIb = ZFactura.percibidoIB
                                ZExento = ZFactura.exento

                                ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento

                                ZPorce = Val(ZImporte) / ZTotal

                                ZZSuma = ZNeto * ZPorce
                            End If

                        Else

                            ZZSuma = Val(ZImporte) / 1.21

                        End If

                        ZZBase = ZZSuma
                        'ZZSumaNeto += ZZSuma

                    End If

                    acumProv += CaculoRetencionIngresosBrutos(Val(WTipoIb), WPorceIb, Val(ZZSuma))
                    acumCaba += CaculoRetencionIngresosBrutosCaba(Val(WTipoIbCaba), WPorceIbCaba, Val(ZZSuma))

                End If
            End With
        Next

        txtIngresosBrutos.Text = _NormalizarNumero(acumProv)
        txtIBCiudad.Text = _NormalizarNumero(acumCaba)

    End Sub

    Private Sub _RecalcularRetencionGanancias()
        Dim varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva, varOrdFecha
        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal, ZZSaldo
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma, ZZTotal, ZZBase, ZZSumaNeto

        ZNeto = 0
        ZIva = 0
        ZIva5 = 0
        ZIva27 = 0
        ZIva105 = 0
        ZIb = 0
        ZExento = 0
        ZPorce = 0
        ZImporte = 0
        ZZSuma = 0
        ZZTotal = 0
        ZZBase = 0
        ZZSumaNeto = 0

        ZTipo = ""
        ZNumero = ""
        ZPunto = ""
        ZLetra = ""
        ZTotal = 0
        ZZSaldo = 0

        varAcuNeto = 0
        varAcuRetenido = 0
        varAcuAnticipo = 0
        varAcuBruto = 0
        varAcuIva = 0

        varOrdFecha = Mid(ordenaFecha(txtFecha.Text), 3, 4)

        Dim CampoAcumulado As LeeAcumulado = DaoAcumulado.buscarAcumulado(txtProveedor.Text, varOrdFecha)

        If Not IsNothing(CampoAcumulado) Then

            varAcuNeto = CampoAcumulado.neto
            varAcuRetenido = CampoAcumulado.retenido
            varAcuAnticipo = CampoAcumulado.anticipo
            varAcuBruto = CampoAcumulado.bruto
            varAcuIva = CampoAcumulado.iva

        End If

        ' Recalculo sobre porcentaje neto en Iva Comp.
        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Not IsNothing(.Cells(4).Value) Then
                    ZTipo = .Cells(0).Value
                    ZLetra = .Cells(1).Value
                    ZPunto = .Cells(2).Value
                    ZNumero = .Cells(3).Value
                    ZImporte = .Cells(4).Value

                    Dim ZClaveCtaCtePrv As String = txtProveedor.Text & ZLetra & ZTipo & ZPunto & ZNumero

                    'acum += CaculoRetencionIngresosBrutos(Val(WTipoIb), WPorceIb, Val(_NormalizarNumero(.Cells(4).Value)))
                    ' Buscamos la factura
                    Dim CtaCtePrv As DataRow = _BuscarCtaCteProv(ZClaveCtaCtePrv)

                    'If IsNothing(CtaCtePrv) Then : Exit Sub : End If

                    Dim ZNroInterno As Integer = 0

                    If Not IsNothing(CtaCtePrv) Then
                        ZNroInterno = Val(CtaCtePrv.Item("NroInterno"))
                        ZZTotal = CtaCtePrv.Item("Total")
                        ZZSaldo = CtaCtePrv.Item("Saldo")
                    End If


                    Dim ZFactura As Compra = DAOCompras.buscarCompraPorCodigo(ZNroInterno)

                    If Not IsNothing(ZFactura) Then

                        ZNeto = ZFactura.neto

                        If Val(ZImporte) = Val(ZZTotal) And ZNroInterno <> 0 Then

                            ZZSuma = ZNeto

                        Else

                            ZIva = ZFactura.iva21
                            ZIva5 = ZFactura.ivaRG
                            ZIva27 = ZFactura.iva27
                            ZIva105 = ZFactura.iva105
                            ZIb = ZFactura.percibidoIB
                            ZExento = ZFactura.exento

                            ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento

                            ZPorce = Val(ZImporte) / ZTotal

                            ZZSuma = ZNeto * ZPorce
                        End If

                    Else

                        ZZSuma = Val(ZImporte) / 1.21

                    End If

                    ZZBase += Val(ZImporte)
                    ZZSumaNeto += ZZSuma

                End If
            End With
        Next

        If Val(WTipoIva) = 2 Then
            ZZBase = ZZSumaNeto
        End If

        Dim varRetGan = CaculoRetencionGanancia(Val(WTipoProv), ZZBase, varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva)

        txtGanancias.Text = _NormalizarNumero(varRetGan)

    End Sub

    Private Sub _RecalcularRetencionIVA()
        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal, ZZSaldo
        Dim ZNeto, ZIva, ZZSuma, ZZTotal, ZZBase

        ZNeto = 0
        ZIva = 0
        ZImporte = 0
        ZZSuma = 0
        ZZTotal = 0
        ZZBase = 0

        ZTipo = ""
        ZNumero = ""
        ZPunto = ""
        ZLetra = ""
        ZTotal = 0
        ZZSaldo = 0

        ' Recalculo sobre porcentaje neto en Iva Comp.
        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Not IsNothing(.Cells(4).Value) Then
                    ZTipo = .Cells(0).Value
                    ZLetra = .Cells(1).Value
                    ZPunto = .Cells(2).Value
                    ZNumero = .Cells(3).Value
                    ZImporte = .Cells(4).Value

                    Dim ZClaveCtaCtePrv As String = txtProveedor.Text & ZLetra & ZTipo & ZPunto & ZNumero

                    ' Buscamos la factura
                    Dim CtaCtePrv As DataRow = _BuscarCtaCteProv(ZClaveCtaCtePrv)

                    Dim ZNroInterno As Integer = 0

                    If Not IsNothing(CtaCtePrv) Then
                        ZNroInterno = Val(CtaCtePrv.Item("NroInterno"))
                    End If

                    ZZSuma = 0

                    If Val(ZImporte) <> 0 And UCase(ZLetra) = "M" Then

                        ZNeto = ZImporte / 1.21
                        ZIva = ZImporte - ZNeto

                        If ZNeto >= 1000 Then

                            Dim ZFactura As Compra = DAOCompras.buscarCompraPorCodigo(ZNroInterno)

                            If Not IsNothing(ZFactura) Then

                                ZZSuma = ZFactura.iva21

                            Else

                                ZZSuma = Val(ZImporte) / 1.21

                            End If

                        End If

                    End If

                    ZZBase += ZZSuma

                End If
            End With
        Next

        txtIVA.Text = _NormalizarNumero(ZZBase)

    End Sub

    Private Function _BuscarCtaCteProv(ByVal _Clave As String) As DataRow

        _Clave = Trim(_Clave)

        Dim dt As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM CtaCtePrv WHERE clave = '" & _Clave & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                ' dr.Read()

                dt.Load(dr)

                Return dt.Rows(0)

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return Nothing

    End Function

    Private Function _TraerPorcentajeSegunIvaComp() As String
        Return ""
    End Function

    Private Function _NormalizarNumero(ByVal numero As String)
        Return Proceso.formatonumerico(Trim(numero))
    End Function
End Class