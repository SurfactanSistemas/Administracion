﻿Imports ClasesCompartidas
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
    Dim _Carpetas(10) As String
    Dim _Claves As New List(Of Object)
    Dim WClavesOP(100) As String
    Dim WCuenta(100, 2) As String
    Dim _TipoConsulta As Integer = Nothing
    Private WCertificadoIb, WCertificadoIbCiudad, WCertificadoIVA As String

    Private Const XMAXFILAS = 15
    Private Const YMARGEN = 250
    Private Const XMARGEN = 426
    Private WRow, Wcol, WRowVarios As Integer

    Private WTipoProv, WTipoIva, WTipoIb, WTipoIbCaba, WPorceIb, WPorceIbCaba As String
    ' Para calculos de Retenciones.
    Dim varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva, varOrdFecha

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
            XChequeCheque, XCuentaCheque, XCuit, XClaveCuit, XNet, XProveedor, XRetIbCiudad, XTipoOrd As String

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

    Private Function _TraerDatosProveedorTipoProvinciaEmbargo() As Object
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Provincia, TipoProv, Embargo FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'")
        Dim dr As SqlDataReader
        Dim WProv = 0, WTipoProv = 0, WEmbargo = "N"

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                WProv = IIf(IsDBNull(dr.Item("Provincia")), 0, Val(dr.Item("Provincia")))
                WTipoProv = IIf(IsDBNull(dr.Item("TipoProv")), 0, Val(dr.Item("TipoProv")))
                WEmbargo = IIf(IsDBNull(dr.Item("Embargo")), "N", Trim(dr.Item("Embargo")))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos. No se encontró proveedor.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return {WProv, WTipoProv, WEmbargo}

    End Function

    Private Function _ExisteOrdenDePago(ByVal NumOrden) As Boolean
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT TOP 1 Orden FROM Orden WHERE Orden = '" & NumOrden & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return False

    End Function

    Private Function _FechasValidasFormasPago() As Boolean

        Dim WOrdFecha1 = Proceso.ordenaFecha(txtFecha.Text), WOrdFecha2 = 0, WFecha2 = ""

        If gridFormaPagos.Rows.Count > 0 Then
            For Each row As DataGridViewRow In gridFormaPagos.Rows
                WFecha2 = row.Cells(2).Value
                If Not IsNothing(row) And Not IsNothing(WFecha2) Then

                    If Val(row.Cells(0).Value) = 2 Then

                        If Trim(WFecha2.Replace("/", "")) <> "" And Proceso._ValidarFecha(WFecha2) Then

                            WOrdFecha2 = Proceso.ordenaFecha(WFecha2)

                            If WOrdFecha2 < WOrdFecha1 Then
                                MsgBox("La Fecha de los valores informados no puede ser menor a la fecha de emision de la orden de pago", MsgBoxStyle.Critical)
                                Return False
                            End If

                        Else
                            MsgBox("La Fecha de los valores informados es incorrecta", MsgBoxStyle.Critical)
                            Return False
                        End If

                    End If

                End If
            Next
        End If

        Return True
    End Function

    Private Function _ImputacionesConceptoVariosCorrectas() As Boolean
        If gridPagos.Rows.Count > 0 Then

            For Each row As DataGridViewRow In gridPagos.Rows
                If Not IsNothing(row) And Not IsNothing(row.Cells(4).Value) Then

                    With row
                        If Val(.Cells(4).Value) <> 0 And Trim(.Cells(0).Value) = "" Then
                            MsgBox("No se ha imputado correctamente el concepto del pago", MsgBoxStyle.Critical)
                            Return False
                        End If
                    End With

                End If
            Next

        End If

        Return True
    End Function

    Private Function _ValoresCorrectosAEntregar() As Boolean

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not IsNothing(row) And Not IsNothing(row.Cells(5).Value) Then
                With row
                    If Val(.Cells(5).Value) <> 0 And Val(.Cells(0).Value) = 0 Then
                        MsgBox("No se han informado correctamente los valores a entregar", MsgBoxStyle.Critical)
                        Return False
                    End If
                End With
            End If
        Next

        Return True
    End Function

    Private Function _ExisteFactura(ByVal XClave) As Boolean
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave FROM CtaCtePrv WHERE Clave = '" & XClave & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return dr.HasRows

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return False
    End Function

    Private Function _ImputacionesFacturasACancelar() As Boolean
        Dim XTipo1 = "", XLetra1 = "", XPunto1 = "", XNumero1 = "", XImporte1 = "", XClave = ""

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not IsNothing(row) And Not IsNothing(row.Cells(4).Value) Then
                XTipo1 = ""
                XLetra1 = ""
                XPunto1 = ""
                XNumero1 = ""
                XImporte1 = ""
                XClave = ""

                With row
                    If Trim(.Cells(0).Value) <> "" Then
                        XTipo1 = .Cells(0).Value
                        XLetra1 = .Cells(1).Value
                        XPunto1 = .Cells(2).Value
                        XNumero1 = .Cells(3).Value
                        XImporte1 = .Cells(4).Value

                        XClave = txtProveedor.Text & XLetra1 & XTipo1 & XPunto1 & XNumero1

                        If XNumero1 <> "99999999" And Val(XImporte1) <> 0 Then

                            Try
                                If Not _ExisteFactura(XClave) Then
                                    Return False
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                                Return False
                            End Try

                        End If
                    End If

                End With
            End If
        Next

        Return True
    End Function

    '
    ' Validamos campos segun tipo de Orden de Pago.
    '
    Private Function validarDatos() As Boolean

        ' Sólo se exige proveedor para los casos de pagos por CtaCte y Anticipos.
        If Val(txtProveedor.Text) = 0 And (optCtaCte.Checked Or optAnticipos.Checked) Then
            MsgBox("Se debe informar un Proveedor para el tipo de pago informado.", MsgBoxStyle.Information)
            Return False
        End If

        ' Se exige banco en caso de que sea tipo Transferencias.
        If optTransferencias.Checked Then
            if Val(txtBanco.Text) = 0 Then
                MsgBox("Se debe informar un banco valido para el tipo de pago informado", MsgBoxStyle.Information)
                Return False
            Else
                ' Se corrobora que sea valido el banco informado.
                Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)

                If IsNothing(banco) Then
                    MsgBox("Se debe informar un banco valido para el tipo de pago informado", MsgBoxStyle.Information)
                    Return False
                End If
            End If
        End If

        ' Validamos imputaciones correctas cuando es Concepto Varios.
        If optVarios.Checked Then

            If Not _ImputacionesConceptoVariosCorrectas() Then
                Return False
            End If

        End If

        ' Verificamos que se hayan informado los valores a entregar.
        If Not _ValoresCorrectosAEntregar() Then
            Return False
        End If

        ' Verificar imputaciones en Facturas a Cancelar.
        If optCtaCte.Checked Then
            If Not _ImputacionesFacturasACancelar() Then
                Return False
            End If
        End If

        ' Controlamos balanceo.
        If Val(lblPagos.Text) <> Val(lblFormaPagos.Text) Then
            MsgBox("Los créditos y débitos no se encuentran balanceados.", MsgBoxStyle.Critical)
            Return False
        End If

        ' Buscamos el tipo de prov y numero de provincia.

        Dim datos_prov As Object = {0, 0, "N"} ' {Provincia, TipoProv, Embargo}

        Try
            datos_prov = _TraerDatosProveedorTipoProvinciaEmbargo()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        ' Si la orden de pago se realiza a alguno de estos proveedores o a un proveedor del exterior tipo = 1, se tiene que cargar numero de carpeta.
        If txtProveedor.Text = "10167878480" Or txtProveedor.Text = "10000000100" Or txtProveedor.Text = "10071081483" Or txtProveedor.Text = "10069345023" Or txtProveedor.Text = "10066352912" Or (Val(datos_prov(0)) = 24 And Val(datos_prov(1)) = 1) Then
            Dim entra As Boolean = False

            For i = 1 To _Carpetas.Length
                If _Carpetas(i) <> "" Then
                    entra = True
                End If
            Next

            If entra Then
                If MsgBox("¿El pago que se esta efectuando corresponde a una Importacion?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                    MsgBox("e debe informar el numero de carpeta correspondiente", MsgBoxStyle.Critical)
                    Return False
                End If
            End If
        End If

        ' Si el proveedor se encuentra embargado por arba, se consulta si se quiere proseguir con la generacion de la orden de pago.
        If Val(txtProveedor.Text) <> 0 And Val(lblFormaPagos.Text) > 1000 Then
            If UCase(datos_prov(2)) = "S" Then

                If MsgBox("El proveedor tiene embargos por parte de Arba" + Chr(13) + "¿Desea cancelar la emision de la orden de pago?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                    Return False
                End If

            End If
        End If

        ' Corroboramos que no exista una Orden de Pago con el mismo numero que el actual.
        If Val(txtOrdenPago.Text) <> 0 Then
            If _ExisteOrdenDePago(txtOrdenPago.Text) Then
                Return False
            End If
        End If

        ' Validamos las fechas cargadas.
        If Not _FechasValidasFormasPago() Then
            Return False
        End If

        Return True

    End Function

    Private Function hayMovimientos()
        Return CustomConvert.toDoubleOrZero(lblPagos.Text) <> 0
    End Function

    Private Function noHayDiferencia()
        Return CustomConvert.toDoubleOrZero(lblDiferencia.Text) = 0
    End Function

    Private Function bancosValidos()
        'For Each row As DataGridViewRow In gridFormaPagos.Rows
        '    If Not row.IsNewRow And row.Cells(0).Value = "02" Then
        '        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(row.Cells(3).Value)
        '        If IsNothing(banco) Then : Return False : End If
        '    End If
        'Next
        Return True
    End Function

    Private Function _CS(Optional ByVal empresa As String = "SurfactanSA")
        Return Proceso._ConectarA(empresa)
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
        'txtFechaParidad.Text = Proceso._Normalizarfecha(orden.fechaParidad)
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

        sumarImportes()
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
        'sumarImportes()
    End Sub

    Private Sub mostrarFormaPagos(ByVal formaPagos As List(Of FormaPago))
        gridFormaPagos.Rows.Clear()

        Dim WRenglon As Integer = 0

        For Each formaPago As FormaPago In formaPagos

            gridFormaPagos.Rows.Add(formaPago.tipo, formaPago.numero, formaPago.fecha, formaPago.banco, formaPago.nombre, _NormalizarNumero(formaPago.importe), "", formaPago.cuit)

            WClavesOP(WRenglon) = Proceso.ceros(txtOrdenPago.Text, 6) & Proceso.ceros(WRenglon + 2, 2)

            WRenglon += 1

        Next

        'sumarImportes()
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

        _RecalcularRetenciones()

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

        'SQLConnector.conexionSql(cn, cm)

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    Dim XTipo, XNroInterno, XTotal, XSaldo, XSaldoUS, XImpre, XLetra, XPunto, XNumero, XFecha, XClave, XParidad, XPago, XParidadTotal As String
                    Dim XRow As Integer = 0

                    For i = 0 To XMAXFILAS - 1
                        If gridPagos.Rows(i).Cells(0).Value = "" Then
                            XRow = i
                            Exit For
                        End If
                    Next

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

                    Dim XRow = Nothing

                    For Each row As DataGridViewRow In gridFormaPagos.Rows
                        If IsNothing(row.Cells(0).Value) Or row.Cells(0).Value = "" Then
                            XRow = row.Index
                            Exit For
                        End If
                    Next

                    If IsNothing(XRow) Then
                        XRow = gridFormaPagos.Rows.Add
                    End If

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
                    Dim XRow As Integer = 0

                    For i = 0 To XMAXFILAS - 1
                        If gridPagos.Rows(i).Cells(0).Value = "" Then
                            XRow = i
                            Exit For
                        End If
                    Next

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

    Private Sub _LimpiarGrillas()

        gridPagos.Rows.Clear()
        gridFormaPagos.Rows.Clear()

        For i = 1 To XMAXFILAS

            gridPagos.Rows.Add("", "", "", "", "", "", "")
            gridFormaPagos.Rows.Add("", "", "", "", "", "", "", "", "")

        Next

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

        pnlPedirCuenta.Visible = False
        WRowVarios = -1

        cmbTipo.SelectedIndex = 0

        txtIBCiudad.Text = "0.00"
        txtIngresosBrutos.Text = "0.00"
        txtGanancias.Text = "0.00"
        txtIVA.Text = "0.00"
        txtFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        txtFechaParidad.Text = txtFecha.Text

        _LimpiarGrillas()
        
        pagos.Clear()
        
        _ClavesCheques.Clear()
        cheques.Clear()

        'Array.Clear(_Claves, 0, _Claves.Length)
        Array.Clear(WClavesOP, 0, WClavesOP.Length)
        Array.Clear(WCuenta, 0, WCuenta.Length)

        For i = 0 To _Carpetas.Length - 1
            _Carpetas(i) = ""
        Next

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

    Private Function _ActualizarNumeroCertificado(ByVal Codigo) As Integer
        Dim WNumero As Integer = 0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT MAX(Numero) as Numero FROM Numero WHERE Codigo = '" & Val(Codigo) & "'")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction

        SQLConnector.conexionSql(cn, cm)

        Try
            trans = cn.BeginTransaction

            cm.Transaction = trans
            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                WNumero = dr.Item("Numero") + 1
            End If

            dr.Close()

            cm.CommandText = "UPDATE Numero SET Numero = " & Val(WNumero) & " WHERE Codigo = '" & Val(Codigo) & "'"
            cm.ExecuteNonQuery()

            trans.Commit()

        Catch ex As Exception
            If Not IsNothing(trans) Then
                trans.Rollback()
            End If
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally
            dr = Nothing
            cn.Close()
            cm = Nothing
            trans = Nothing
        End Try

        Return WNumero
    End Function

    Private Function _ExisteCtaCtePrv(ByVal Clave) As Boolean
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Clave FROM CtaCtePrv WHERE Clave = '" & Clave & "'")
        Dim dr As SqlDataReader

        Try
            SQLConnector.conexionSql(cn, cm)
            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return False
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim WCertificadoGan, WCertificadoIb, WCertificadoIbCiudad, WCertificadoIva, XParidad, WEntra
        Dim XOrden, XRenglon, XProveedor, XFecha, XFechaOrd, XImporte, XRetencion, XRetotra, XRetIbCiudad, XRetIva, XObservaciones, XCuenta, XTipoOrd, ZValida, ZLetra, ZTipo, ZPunto, ZNumero, XTipo1, XLetra1, XPunto1, XNumero1, XImporte1, XObservaciones2, XImpoNeto, XTipo2, XNumero2, XFecha2, XFechaOrd2, XBanco2, XImporte2, XEmpresa, XClave, XRetganancias, XConcepto, XConsecionaria, XImpolist, ClaveRecibo, XCuit, ImporteCheque, NumeroCheque, FechaCheque, BancoCheque, WLetra, WTipo, WPunto, WNumero, WImporte, ZSql, XClaveCtaprv, XTipoRecibo, XClaveRecibo, XClaveCtaCte
        Dim _banco As Banco = Nothing
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        If Not validarDatos() Then
            Exit Sub
        End If

        Dim WOrdPago As Integer = 0
        Try
            WOrdPago = DAOPagos.siguienteNumeroDeOrden()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        txtOrdenPago.Text = Proceso.ceros(WOrdPago, 6)

        ' Damos de alta los numero de Certificados.
        Try
            WCertificadoGan = _ActualizarNumeroCertificado("91")
            WCertificadoIb = _ActualizarNumeroCertificado("92")
            WCertificadoIbCiudad = _ActualizarNumeroCertificado("94")
            WCertificadoIva = _ActualizarNumeroCertificado("93")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Try
            crearNotasCreditoDebito()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        XOrden = txtOrdenPago.Text
        XProveedor = txtProveedor.Text
        XFecha = txtFecha.Text
        XFechaOrd = Proceso.ordenaFecha(XFecha)
        XImporte = lblFormaPagos.Text
        XRetencion = txtGanancias.Text
        XRetotra = txtIngresosBrutos.Text
        XRetIbCiudad = txtIBCiudad.Text
        XRetIva = txtIVA.Text
        XObservaciones = Trim(txtObservaciones.Text)
        XParidad = Proceso.formatonumerico(txtParidad.Text, 4)


        ' Damos de alta los Pagos.
        Dim WRenglon As Integer = 0
        Dim row As DataGridViewRow = Nothing
        'For Each row As DataGridViewRow In gridPagos.Rows
        For i = 0 To XMAXFILAS - 1

            row = gridPagos.Rows(i)

            If Val(row.Cells(4).Value) <> 0 Then
                With row
                    WRenglon += 1

                    XRenglon = Proceso.ceros(WRenglon, 2)

                    ZSql = ""

                    XClaveCtaprv = ""
                    XCuenta = ""
                    XTipoOrd = ""
                    ZValida = ""
                    ZLetra = ""
                    ZTipo = ""
                    ZPunto = ""
                    ZNumero = ""
                    XTipo1 = ""
                    XLetra1 = ""
                    XPunto1 = ""
                    XNumero1 = ""
                    XImporte1 = ""
                    XObservaciones2 = ""
                    XImpoNeto = ""
                    XTipo2 = ""
                    XNumero2 = ""
                    XFecha2 = ""
                    XFechaOrd2 = ""
                    XBanco2 = ""
                    XImporte2 = ""
                    XEmpresa = "1"
                    XClave = ""
                    XRetganancias = ""
                    XConcepto = ""
                    XConsecionaria = ""
                    XImpolist = ""
                    ClaveRecibo = ""
                    XCuit = ""
                    ImporteCheque = ""
                    NumeroCheque = ""
                    FechaCheque = ""
                    BancoCheque = ""
                    WLetra = ""
                    WTipo = ""
                    WPunto = ""
                    WNumero = ""
                    WImporte = ""
                    XTiporeg = "1"
                    XClaveCtaCte = ""

                    If optCtaCte.Checked Then
                        XTipoOrd = "1"
                    End If
                    If optAnticipos.Checked Then
                        XTipoOrd = "2"
                    End If
                    If optVarios.Checked Then
                        XTipoOrd = "3"
                        XCuenta = WCuenta(i, 1)
                    End If
                    If optTransferencias.Checked Then

                        XTipoOrd = "4"
                        _banco = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)

                        If Not IsNothing(_banco) Then
                            XCuenta = _banco.cuenta
                        Else
                            XCuenta = "999999"
                        End If

                    End If
                    If optChequeRechazado.Checked Then
                        XTipoOrd = "5"
                        XCuenta = "111"
                    End If
                    'If Tipo6.Value = True Then
                    '    XTipoOrd = "6"
                    'End If

                    If Val(.Cells(0).Value) = 0 And Trim(.Cells(1).Value) = "" And Val(.Cells(2).Value) = 0 And Val(.Cells(3).Value) = 0 Then
                        XCuenta = WCuenta(i, 1)
                    End If

                    XTiporeg = "1"

                    XTipo1 = .Cells(0).Value
                    XLetra1 = .Cells(1).Value
                    XPunto1 = .Cells(2).Value
                    XNumero1 = .Cells(3).Value
                    XImporte1 = .Cells(4).Value
                    XObservaciones2 = .Cells(5).Value
                    XImpoNeto = Val(.Cells(6).Value)

                    XTipo2 = ""
                    XNumero2 = ""
                    XFecha2 = ""
                    XFechaOrd2 = ""
                    If optTransferencias.Checked Then
                        XBanco2 = txtBanco.Text
                    Else
                        XBanco2 = ""
                    End If
                    XImporte2 = 0
                    XEmpresa = "1"
                    XClave = XOrden + XRenglon
                    XRetganancias = 0
                    XConcepto = ""
                    XConsecionaria = ""
                    XImpolist = 0

                    ZSql = "INSERT INTO Pagos "
                    ZSql &= "(Clave, Orden, Renglon, Proveedor, Fecha, Fechaord, Tipoord,"
                    ZSql &= " RetGanancias, RetIva, RetOtra, Retencion, Tiporeg, Tipo1,"
                    ZSql &= " Letra1, Punto1, Numero1, Importe1, Tipo2, Numero2, Fecha2,"
                    ZSql &= " Banco2, Importe2, Observaciones2, Empresa, Concepto, Observaciones,"
                    ZSql &= " Importe, Fechaord2, Consecionaria, Impolist, Cuenta, ImpoNeto,"
                    ZSql &= " RetIbCiudad, ClaveRecibo, ImporteCheque, NumeroCheque, FechaCheque, BancoCheque, Cuit, Paridad)"
                    ZSql &= " VALUES ('" & XClave & "', '" & XOrden & "', '" & XRenglon & "', '" & XProveedor & "',"
                    ZSql &= " '" & XFecha & "', '" & XFechaOrd & "', '" & XTipoOrd & "', " & XRetganancias & ", " & XRetIva & ","
                    ZSql &= " " & XRetotra & ", " & XRetencion & ", '" & XTiporeg & "', '" & XTipo1 & "', '" & XLetra1 & "',"
                    ZSql &= " '" & XPunto1 & "', '" & XNumero1 & "', " & XImporte1 & ", '" & XTipo2 & "', '" & XNumero2 & "',"
                    ZSql &= " '" & XFecha2 & "', '" & XBanco2 & "', " & XImporte2 & ", '" & XObservaciones2 & "', '" & XEmpresa & "',"
                    ZSql &= " '" & XConcepto & "', '" & XObservaciones & "', " & XImporte & ", '" & XFechaOrd2 & "', '" & XConsecionaria & "',"
                    ZSql &= " " & XImpolist & ", '" & XCuenta & "', " & XImpoNeto & ", " & XRetIbCiudad & ", '', '', '', '', '', '', " & XParidad & ")"


                    SQLConnector.conexionSql(cn, cm)

                    Try
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                    ' Actualizamos la Cta Cte del Proveedor.
                    XClaveCtaprv = txtProveedor.Text & XLetra1 & XTipo1 & XPunto1 & XNumero1

                    ZSql = "UPDATE CtaCtePrv SET Saldo = Saldo - " & XImporte1 & " WHERE Clave = '" & XClaveCtaprv & "'"

                    Try
                        cn.Open()
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                End With
            End If

            row = gridFormaPagos.Rows(i)

            With row

                If Val(.Cells(0).Value) > 0 And Val(.Cells(5).Value) <> 0 Then
                    WRenglon += 1

                    XRenglon = Proceso.ceros(WRenglon, 2)

                    ZSql = ""

                    XClaveCtaprv = ""
                    XCuenta = ""
                    XTipoOrd = ""
                    ZValida = ""
                    ZLetra = ""
                    ZTipo = ""
                    ZPunto = ""
                    ZNumero = ""
                    XTipo1 = ""
                    XLetra1 = ""
                    XPunto1 = ""
                    XNumero1 = ""
                    XImporte1 = ""
                    XObservaciones2 = ""
                    XImpoNeto = ""
                    XTipo2 = ""
                    XNumero2 = ""
                    XFecha2 = ""
                    XFechaOrd2 = ""
                    XBanco2 = ""
                    XImporte2 = ""
                    XEmpresa = "1"
                    XClave = ""
                    XRetganancias = ""
                    XConcepto = ""
                    XConsecionaria = ""
                    XImpolist = ""
                    ClaveRecibo = ""
                    XCuit = ""
                    ImporteCheque = ""
                    NumeroCheque = ""
                    FechaCheque = ""
                    BancoCheque = ""
                    WLetra = ""
                    WTipo = ""
                    WPunto = ""
                    WNumero = ""
                    WImporte = ""
                    XTiporeg = ""
                    XTipoRecibo = ""
                    XClaveRecibo = ""
                    XClaveCtaCte = ""

                    If optCtaCte.Checked Then
                        XTipoOrd = "1"
                    End If
                    If optAnticipos.Checked Then
                        XTipoOrd = "2"
                    End If
                    If optVarios.Checked Then
                        XTipoOrd = "3"
                    End If
                    If optTransferencias.Checked Then
                        XTipoOrd = "4"
                    End If
                    If optChequeRechazado.Checked Then
                        XTipoOrd = "5"
                    End If
                    'If Tipo6.Value = True Then
                    '    XTipoOrd = "6"
                    'End If

                    XTiporeg = "2"

                    XTipo1 = ""
                    XLetra1 = ""
                    XPunto1 = ""
                    XNumero1 = ""
                    XImporte1 = 0
                    XImpoNeto = 0

                    XTipo2 = .Cells(0).Value
                    XNumero2 = .Cells(1).Value
                    XFecha2 = .Cells(2).Value
                    XFechaOrd2 = Proceso.ordenaFecha(XFecha2)
                    XBanco2 = .Cells(3).Value
                    XObservaciones2 = .Cells(4).Value
                    XImporte2 = .Cells(5).Value
                    XClaveRecibo = Mid(.Cells(6).Value, 2, 10)
                    XClaveCtaCte = .Cells(6).Value
                    XTipoRecibo = Microsoft.VisualBasic.Left(.Cells(6).Value, 1)
                    XCuit = .Cells(7).Value

                    XEmpresa = "1"
                    XClave = XOrden + XRenglon
                    XRetganancias = 0
                    XConcepto = ""
                    XConsecionaria = ""
                    XImpolist = 0

                    If Val(XTipo2) = 6 Then
                        XCuenta = WCuenta(i, 2)
                    End If
                    If Val(XTipo2) = 2 Then
                        XTipo2 = Proceso.ceros(XTipo2, 2)
                    End If

                    ZSql = "INSERT INTO Pagos "
                    ZSql &= "(Clave, Orden, Renglon, Proveedor, Fecha, Fechaord, Tipoord,"
                    ZSql &= " RetGanancias, RetIva, RetOtra, Retencion, Tiporeg, Tipo1,"
                    ZSql &= " Letra1, Punto1, Numero1, Importe1, Tipo2, Numero2, Fecha2,"
                    ZSql &= " Banco2, Importe2, Observaciones2, Empresa, Concepto, Observaciones,"
                    ZSql &= " Importe, Fechaord2, Consecionaria, Impolist, Cuenta, ImpoNeto,"
                    ZSql &= " RetIbCiudad, ClaveRecibo, ImporteCheque, NumeroCheque, FechaCheque, BancoCheque, Cuit, Paridad)"
                    ZSql &= " VALUES ('" & XClave & "', '" & XOrden & "', '" & XRenglon & "', '" & XProveedor & "',"
                    ZSql &= " '" & XFecha & "', '" & XFechaOrd & "', '" & XTipoOrd & "', " & XRetganancias & ", " & XRetIva & ","
                    ZSql &= " " & XRetotra & ", " & XRetencion & ", '" & XTiporeg & "', '" & XTipo1 & "', '" & XLetra1 & "',"
                    ZSql &= " '" & XPunto1 & "', '" & XNumero1 & "', " & XImporte1 & ", '" & XTipo2 & "', '" & XNumero2 & "',"
                    ZSql &= " '" & XFecha2 & "', '" & XBanco2 & "', " & XImporte2 & ", '" & XObservaciones2 & "', '" & XEmpresa & "',"
                    ZSql &= " '" & XConcepto & "', '" & XObservaciones & "', " & XImporte & ", '" & XFechaOrd2 & "', '" & XConsecionaria & "',"
                    ZSql &= " " & XImpolist & ", '" & XCuenta & "', " & XImpoNeto & ", " & XRetIbCiudad & ", '" & XClaveRecibo & "', '', '', '', '', '', " & XParidad & ")"


                    Try
                        cn.Open()
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                    ImporteCheque = XImporte2
                    NumeroCheque = XNumero2
                    FechaCheque = XFecha2
                    BancoCheque = XObservaciones2

                    Dim ZClaveRecibo = Microsoft.VisualBasic.Right$(XClaveRecibo, 8)

                    ZSql = ""
                    ZSql = ZSql + "UPDATE Pagos SET "
                    ZSql = ZSql + " ClaveRecibo = " + "'" + ZClaveRecibo + "',"
                    ZSql = ZSql + " RetIbCiudad = " + "'" + XRetIbCiudad + "',"
                    ZSql = ZSql + " ImporteCheque = " + "'" + ImporteCheque + "',"
                    ZSql = ZSql + " NumeroCheque = " + "'" + NumeroCheque + "',"
                    ZSql = ZSql + " FechaCheque = " + "'" + FechaCheque + "',"
                    ZSql = ZSql + " BancoCheque = " + "'" + BancoCheque + "',"
                    ZSql = ZSql + " Cuit = " + "'" + XCuit + "'"
                    ZSql = ZSql + " Where Clave = " + "'" + XClave + "'"

                    Try
                        cn.Open()
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                    If Val(XTipo2) = 3 Then

                        XEstado2 = "X"
                        XDestino = "O.P:" + txtOrdenPago.Text

                        If Val(XTipoRecibo) = 1 Then

                            ZSql = ""
                            ZSql = ZSql + "UPDATE Recibos SET "
                            ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                            ZSql = ZSql + "Destino = " + "'" + XDestino + "'"
                            ZSql = ZSql + " Where Clave = " + "'" + ZClaveRecibo + "'"

                        Else
                            ZSql = ""
                            ZSql = ZSql + "UPDATE RecibosProvi SET "
                            ZSql = ZSql + "Estado2 = " + "'" + "X" + "',"
                            ZSql = ZSql + "Destino = " + "'" + XDestino + "'"
                            ZSql = ZSql + " Where Clave = " + "'" + ZClaveRecibo + "'"

                        End If

                        Try
                            cn.Open()
                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                            Exit Sub
                        Finally
                            cn.Close()
                        End Try

                    End If

                    If Val(XTipo2) = 4 Then

                        XSaldo = ""
                        XSaldoUs = ""
                        XEstado = "1"
                        XDate = Date.Now().ToString("MM-dd-yyyy")

                        ZSql = ""
                        ZSql = ZSql + "UPDATE CtaCte SET "
                        ZSql = ZSql + "Saldo = " + "'" + XSaldo + "',"
                        ZSql = ZSql + "SaldoUs = " + "'" + XSaldoUs + "',"
                        ZSql = ZSql + "Estado2 = " + "'" + XEstado + "',"
                        ZSql = ZSql + "WDate = " + "'" + XDate + "'"
                        ZSql = ZSql + " Where Clave = " + "'" + XClaveCtaCte + "'"


                        Try

                            cn.Open()
                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                            Exit Sub
                        Finally
                            cn.Close()
                        End Try

                    End If

                End If

            End With
        Next

        If optCtaCte.Checked Then


            WLetra = "A"
            WTipo = "04"
            WPunto = "0000"
            WNumero = Proceso.ceros(txtOrdenPago.Text, 8)
            XProveedor = txtProveedor.Text

            XFecha = txtFecha.Text
            XEstado = "1"
            XVencimiento = "  /  /    "
            XVencimiento1 = "  /  /    "
            XTotal = Proceso.formatonumerico(Val(lblFormaPagos.Text) * -1)
            XSaldo = 0
            XOrdFecha = Proceso.ordenaFecha(XFecha)
            XOrdVencimiento = "00000000"
            XImpre = "OP"
            XEmpresa = "1"

            XClaveCtaprv = XProveedor + WLetra + WTipo + WPunto + WNumero

            If _ExisteCtaCtePrv(XClaveCtaprv) Then

                ZSql = ""
                ZSql &= "UPDATE CtaCtePrv SET"
                ZSql &= " Proveedor = '" & XProveedor & "',"
                ZSql &= " Letra  = '" & WLetra & "',"
                ZSql &= " Tipo = '" & WTipo & "',"
                ZSql &= " Punto = '" & WPunto & "',"
                ZSql &= " Numero = '" & WNumero & "',"
                ZSql &= " Fecha = '" & XFecha & "',"
                ZSql &= " Estado = '" & XEstado & "',"
                ZSql &= " Vencimiento = '" & XVencimiento & "',"
                ZSql &= " Vencimiento1 = '" & XVencimiento1 & "',"
                ZSql &= " Total = " & XTotal & ","
                ZSql &= " Saldo = " & XSaldo & ","
                ZSql &= " OrdFecha = '" & XOrdFecha & "',"
                ZSql &= " OrdVencimiento = '" & XOrdVencimiento & "',"
                ZSql &= " Impre = '" & XImpre & "',"
                ZSql &= " Empresa = '" & XEmpresa & "',"
                ZSql &= " SaldoList = '',"
                ZSql &= " NroInterno = 0,"
                ZSql &= " Lista = '',"
                ZSql &= " Acumulado = 0"
                ZSql &= " WHERE Clave = '" & XClaveCtaprv & "'"

            Else

                ZSql = ""
                ZSql &= "INSERT INTO CtaCtePrv"
                ZSql &= " (Clave, Proveedor, Letra, Tipo, Punto, Numero, fecha, Estado, Vencimiento, Vencimiento1, Total, Saldo, OrdFecha, OrdVencimiento, Impre, Empresa, SaldoList, NroInterno, Lista, Acumulado, Pago, Paridad, ImporteOriginal, Cuota, FacturaOriginal, NroInternoAsociado, DesProveOriginal, Tarjeta, Observaciones, Interes, IvaInteres, Referencia, TituloI, TituloII, Auxi1, Auxi2, Auxi3, Auxi4, FechaOriginal, OrdFechaOriginal) VALUES ("
                ZSql &= "'" & XClaveCtaprv & "',"
                ZSql &= "'" & XProveedor & "',"
                ZSql &= "'" & WLetra & "',"
                ZSql &= "'" & WTipo & "',"
                ZSql &= "'" & WPunto & "',"
                ZSql &= "'" & WNumero & "',"
                ZSql &= "'" & XFecha & "',"
                ZSql &= "'" & XEstado & "',"
                ZSql &= "'" & XVencimiento & "',"
                ZSql &= "'" & XVencimiento1 & "',"
                ZSql &= "" & XTotal & ","
                ZSql &= "" & XSaldo & ","
                ZSql &= "'" & XOrdFecha & "',"
                ZSql &= "'" & XOrdVencimiento & "',"
                ZSql &= "'" & XImpre & "',"
                ZSql &= "'" & XEmpresa & "',"
                ZSql &= " '', '', '', '', '', '', 0, 0, 0, 0,'','','', 0, 0,'','','','','','','', '', '')"

            End If


            Try

                cn.Open()
                cm.CommandText = ZSql
                cm.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Exit Sub
            Finally
                cn.Close()
            End Try

        End If

        If optAnticipos.Checked Then

            WLetra = "A"
            WTipo = "05"
            WPunto = "0000"
            WNumero = Proceso.ceros(txtOrdenPago.Text, 8)
            XProveedor = txtProveedor.Text

            XFecha = txtFecha.Text
            XEstado = "1"
            XVencimiento = "  /  /    "
            XVencimiento1 = "  /  /    "
            XTotal = Proceso.formatonumerico(Val(lblFormaPagos.Text) * -1)
            XSaldo = XTotal
            XOrdFecha = Proceso.ordenaFecha(XFecha)
            XOrdVencimiento = "00000000"
            XImpre = "AN"
            XEmpresa = "1"

            XClaveCtaprv = XProveedor + WLetra + WTipo + WPunto + WNumero

            If _ExisteCtaCtePrv(XClaveCtaprv) Then

                ZSql = ""
                ZSql &= "UPDATE CtaCtePrv SET"
                ZSql &= " Proveedor = '" & XProveedor & "',"
                ZSql &= " Letra  = '" & WLetra & "',"
                ZSql &= " Tipo = '" & WTipo & "',"
                ZSql &= " Punto = '" & WPunto & "',"
                ZSql &= " Numero = '" & WNumero & "',"
                ZSql &= " Fecha = '" & XFecha & "',"
                ZSql &= " Estado = '" & XEstado & "',"
                ZSql &= " Vencimiento = '" & XVencimiento & "',"
                ZSql &= " Vencimiento1 = '" & XVencimiento1 & "',"
                ZSql &= " Total = " & XTotal & ","
                ZSql &= " Saldo = " & XSaldo & ","
                ZSql &= " OrdFecha = '" & XOrdFecha & "',"
                ZSql &= " OrdVencimiento = '" & XOrdVencimiento & "',"
                ZSql &= " Impre = '" & XImpre & "',"
                ZSql &= " Empresa = '" & XEmpresa & "',"
                ZSql &= " SaldoList = '',"
                ZSql &= " NroInterno = 0,"
                ZSql &= " Lista = '',"
                ZSql &= " Paridad = '',"
                ZSql &= " Pago = '',"
                ZSql &= " Acumulado = 0"
                ZSql &= " WHERE Clave = '" & XClaveCtaprv & "'"

            Else

                ZSql = ""
                ZSql &= "INSERT INTO CtaCtePrv"
                ZSql &= " (Clave, Proveedor, Letra, Tipo, Punto, Numero, fecha, Estado, Vencimiento, Vencimiento1, Total, Saldo, OrdFecha, OrdVencimiento, Impre, Empresa, SaldoList, NroInterno, Lista, Acumulado, Pago, Paridad, ImporteOriginal, Cuota, FacturaOriginal, NroInternoAsociado, DesProveOriginal, Tarjeta, Observaciones, Interes, IvaInteres, Referencia, TituloI, TituloII, Auxi1, Auxi2, Auxi3, Auxi4, FechaOriginal, OrdFechaOriginal) VALUES ("
                ZSql &= "'" & XClaveCtaprv & "',"
                ZSql &= "'" & XProveedor & "',"
                ZSql &= "'" & WLetra & "',"
                ZSql &= "'" & WTipo & "',"
                ZSql &= "'" & WPunto & "',"
                ZSql &= "'" & WNumero & "',"
                ZSql &= "'" & XFecha & "',"
                ZSql &= "'" & XEstado & "',"
                ZSql &= "'" & XVencimiento & "',"
                ZSql &= "'" & XVencimiento1 & "',"
                ZSql &= "" & XTotal & ","
                ZSql &= "" & XSaldo & ","
                ZSql &= "'" & XOrdFecha & "',"
                ZSql &= "'" & XOrdVencimiento & "',"
                ZSql &= "'" & XImpre & "',"
                ZSql &= "'" & XEmpresa & "',"
                ZSql &= " '', '', '', '', '', '', 0, 0, 0, 0,'','','', 0, 0,'','','','','','','', '', '')"

            End If


            Try

                cn.Open()
                cm.CommandText = ZSql
                cm.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Exit Sub
            Finally
                cn.Close()
            End Try

        End If

        ' Tipo6?

        ' Actualizo retenciones en caso de existir
        Dim _Clave = Microsoft.VisualBasic.Right(txtFecha.Text, 2) & Mid(txtFecha.Text, 4, 2) & txtProveedor.Text
        XNeto = 0
        ZSql = ""
        ZSql &= "UPDATE Retencion SET Neto = Neto + " & XNeto & ", Retenido = Retenido + " & XRetencion & " WHERE Clave = '" & _Clave & "'"

        Try

            cn.Open()
            cm.CommandText = ZSql
            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        ' Actualizamos los valores de las carpetas.

        ZSql = ""
        ZSql = ZSql & "UPDATE Pagos SET "
        ZSql = ZSql & " Carpeta = " & Val(_Carpetas(1)) & ","
        ZSql = ZSql & " ImpoCarpeta = 0,"
        ZSql = ZSql & " Carpeta1 = " & Val(_Carpetas(2)) & ","
        ZSql = ZSql & " ImpoCarpeta1 = 0,"
        ZSql = ZSql & " Carpeta2 = " & Val(_Carpetas(3)) & ","
        ZSql = ZSql & " ImpoCarpeta2 = 0,"
        ZSql = ZSql & " Carpeta3 = " & Val(_Carpetas(4)) & ","
        ZSql = ZSql & " ImpoCarpeta3 = 0,"
        ZSql = ZSql & " Carpeta4 = " & Val(_Carpetas(5)) & ","
        ZSql = ZSql & " ImpoCarpeta4 = 0,"
        ZSql = ZSql & " Carpeta5 = " & Val(_Carpetas(6)) & ","
        ZSql = ZSql & " Carpeta6 = " & Val(_Carpetas(7)) & ","
        ZSql = ZSql & " Carpeta7 = " & Val(_Carpetas(8)) & ","
        ZSql = ZSql & " Carpeta8 = " & Val(_Carpetas(9)) & ","
        ZSql = ZSql & " Carpeta9 = " & Val(_Carpetas(10)) & ","
        ZSql = ZSql & " Titulo = '',"
        ZSql = ZSql & " TituloI = ''"
        ZSql = ZSql & " Where Orden = " & "'" & txtOrdenPago.Text & "'"

        Try

            cn.Open()
            cm.CommandText = ZSql
            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        XEmpresa = "1"

        Dim _Empresas As New List(Of String) From {}

        Select Case Val(XEmpresa)
            Case 1, 3, 5, 6, 7, 10, 11

                _Empresas.AddRange({"SurfactanSA", "surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"})

            Case Else

        End Select

        If _Empresas.Count > 0 Then
            For Ciclo = 1 To 10

                If Val(_Carpetas(Ciclo)) <> 0 Then

                    WEntra = "N"

                    Dim dr As SqlDataReader = cm.ExecuteReader()
                    Dim ZProveedor = ""

                    For Each _Empresa As String In _Empresas

                        ZSql = ""
                        ZSql = ZSql + "Select Proveedor"
                        ZSql = ZSql + " FROM Orden"
                        ZSql = ZSql + " Where Orden.Carpeta = " + "'" + _Carpetas(Ciclo) + "'"

                        Try
                            cn.ConnectionString = _CS(_Empresa)
                            cn.Open()
                            cm.CommandText = ZSql
                            
                            If dr.HasRows Then
                                dr.Read()
                                ZProveedor = dr.Item("Proveedor")
                                WEntra = "S"
                            End If

                        Catch ex As Exception
                            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                            Exit Sub
                        Finally
                            cn.Close()
                        End Try

                        If WEntra <> "N" Then
                            If txtProveedor.Text <> ZProveedor Then
                                ZSql = ""
                                ZSql = ZSql + "UPDATE Orden SET "
                                ZSql = ZSql + " PagoDespacho = 1"
                                ZSql = ZSql + " Where Orden.Carpeta = " + "'" + _Carpetas(Ciclo) + "'"

                                Try

                                    cn.Open()
                                    cm.CommandText = ZSql
                                    cm.ExecuteNonQuery()

                                Catch ex As Exception
                                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                                    Exit Sub
                                Finally
                                    cn.Close()
                                End Try

                            End If

                            Exit For

                        End If

                    Next

                End If

            Next
        End If

        ' Reconectamos a la base original.
        cn.ConnectionString = _CS()

        ' Actualizamos los numero de Certificados de Retenciones.
        ZSql = ""
        ZSql &= "UPDATE Pagos SET "
        ZSql &= " CertificadoGan = " & "" & Val(WCertificadoGan) & ","
        ZSql &= " CertificadoIb = " & "" & Val(WCertificadoIb) & ","
        ZSql &= " CertificadoIbCiudad = " & "" & Val(WCertificadoIbCiudad) & ","
        ZSql &= " CertificadoIva = " & "" & Val(WCertificadoIva) & ""
        ZSql &= " Where Orden = " & "'" & txtOrdenPago.Text & "'"

        Try

            cn.Open()
            cm.CommandText = ZSql
            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        MsgBox("El número de orden asignado es: " & WOrdPago)

        ' Imprimimos los comprobantes pertinentes.
        btnImprimir.PerformClick()

        ' Limpiamos pantalla.
        btnLimpiar.PerformClick()

    End Sub

    Private Sub crearNotasCreditoDebito()
        Dim pagos As New List(Of Pago)
        Dim ultimoNumero As String = 0
        Dim tipoDoc As String = ""
        Dim neto As Double

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow And Val(row.Cells(3).Value) = 99999999 Then

                If Val(row.Cells(0).Value) = 2 Then
                    tipoDoc = "ND"
                Else
                    tipoDoc = "NC"
                End If

                neto = _NormalizarNumero(row.Cells(4).Value) / 1.21

                Dim interno As Integer = DAOCompras.siguienteNumeroDeInterno()
                Dim compra As New Compra(
                                         interno,
                                         DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text),
                                         Str$(row.Cells(0).Value),
                                         tipoDoc,
                                         "1",
                                         "2",
                                         Str$(row.Cells(1).Value),
                                         Str$(row.Cells(2).Value),
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
            ' ultimoNumero = row.Cells(3).Value
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
                column = 5
            Case 2
                column = 1
            Case 3
                gridFormaPagos.Rows(rowIndex).Cells(0).Value = ""
                chequeRow = rowIndex
                lstSeleccion.SelectedIndex = 2
                lstSeleccion_MouseClick(Nothing, Nothing)
                Exit Sub
            Case 4
                column = 1
            Case 5
                nombre = "US$"
                column = 4
            Case 6
                nombre = "Varios"

                WRowVarios = rowIndex

                WProceso.Text = 2
                pnlPedirCuenta.Visible = True
                txtCuenta.Text = WCuenta(rowIndex, WProceso.Text)
                txtCuenta.Focus()

                column = 5
            Case Else
                Exit Sub
        End Select
        gridFormaPagos.CurrentCell.Value = ceros(val.ToString, 2)

        gridFormaPagos.Rows(rowIndex).Cells(4).Value = nombre
        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(rowIndex).Cells(column)
    End Sub

    Private Sub gridFormaPagos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFormaPagos.CellValueChanged
        'sumarImportes()
        'llenarConCerosNumero()
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
        'If e.KeyCode = Keys.Enter Then
        '    Dim iCol = gridFormaPagos.CurrentCell.ColumnIndex
        '    Dim iRow = gridFormaPagos.CurrentCell.RowIndex
        '    If iCol = 0 And iRow > -1 Then
        '        Dim val = gridFormaPagos.Rows(iRow).Cells(iCol).Value
        '        eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(val), iRow, iCol)
        '    End If
        'End If
    End Sub

    Private Sub gridPagos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPagos.CellValueChanged
        'sumarImportes()
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
        lblFormaPagos.Text = (formaPagos + total)
        lblDiferencia.Text = (pagos - formaPagos - total)
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
            With gridPagos
                .Rows.Clear()
                Dim r = .Rows.Add("", "", "", "", "", txtObservaciones.Text)
                .CurrentCell = .Rows(r).Cells(4)
                .Focus()
            End With

            'gridPagos.Columns(5).ReadOnly = True
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

                            Select Case Val(valor)
                                Case 1, 2, 3, 4, 5, 6

                                    eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(valor), iRow, iCol)

                                Case Else
                                    gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol)
                            End Select

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

                        sumarImportes()

                        Try
                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow + 1).Cells(0)
                        Catch ex As Exception
                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(gridFormaPagos.Rows.Add).Cells(0)
                        End Try
                        'gridFormaPagos.CurrentCell = gridFormaPagos.Rows(gridFormaPagos.Rows.Add()).Cells(0)
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

        With gridPagos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor = IIf(IsNothing(.CurrentCell.Value), "", .CurrentCell.Value)


                Select Case iCol
                    Case 3

                        If Not _EsNumeroOControl(keyData) Then
                            Return True
                        End If

                    Case 4
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then
                    If Trim(valor) <> "" And Not IsNothing(valor) Then

                    End If

                    Select Case iCol
                        Case 5
                            Try
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            Catch ex As Exception
                                .CurrentCell = .Rows(iRow).Cells(0)
                            End Try

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select
                ElseIf msg.WParam.ToInt32() = Keys.Escape Then

                    .CurrentCell.Value = ""

                    Select Case iCol
                        Case 5
                            .CurrentCell = .Rows(iRow).Cells(4)
                            .CurrentCell = .Rows(iRow).Cells(5)
                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                            .CurrentCell = .Rows(iRow).Cells(iCol)
                    End Select

                End If

            End If
        End With


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


        'If _Carpetas.Count > 0 Then

        ' Validamos que todas las carpetas, ademas de validas, correspondan al proveedor en cuestión.
        'If Not _CarpetasCorrespondenAProveedor(txtProveedor.Text) Then
        '    MsgBox("El Proveedor de la Carpeta no coincide con el indicado en la Orden de Pago.", MsgBoxStyle.Critical)
        '    btnCarpetas.PerformClick()
        'End If

        'End If

    End Sub

    'Private Function _CarpetasCorrespondenAProveedor(ByVal _Proveedor As String)
    '    Dim corresponden As Boolean = True
    '    _Proveedor = Trim(_Proveedor)

    '    For Each _C As String In _Carpetas

    '        If Trim(_C) <> "" Then
    '            If _Proveedor <> "10167878480" And _Proveedor <> "10000000100" And _Proveedor <> "10071081483" And _Proveedor <> "10069345023" And _Proveedor <> "10066352912" Then
    '                If _Proveedor <> Trim(_C) Then
    '                    ' Indicamos que hay algunas de las carpetas que no se corresponde con el proveedor y salimos.
    '                    corresponden = False
    '                    Exit For
    '                End If
    '            End If
    '        End If

    '    Next

    '    Return corresponden
    'End Function

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
                    XTotal -= Val(WImpresion(XCantidad, 5))
                Else
                    XTotal += Val(WImpresion(XCantidad, 5))
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
                        WDebito(irow + 1, 2) = Val(.Cells(4).Value)
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
        Dim Impre2 = 0.0
        Dim SumaTercero = 0.0

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
                        SumaTercero = SumaTercero + Val(.Cells(5).Value)
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
                WImporte1 = Val(WImpresion(WCiclo, 5))
            End If

            If Val(WImpre2(WCiclo, 3)) <> 0 Then
                WNumero2 = WImpre2(WCiclo, 1)
                WBanco2 = WImpre2(WCiclo, 2)
                WImporte2 = Val(WImpre2(WCiclo, 3))
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
                .Item("Rete1") = Val(txtGanancias.Text)
                .Item("Rete2") = Val(txtIngresosBrutos.Text) + Val(txtIBCiudad.Text)
                .Item("Total") = Val(txtIVA.Text)
                .Item("Observaciones") = txtObservaciones.Text
                .Item("Empresa") = "Surfactan S.A."
                .Item("Cuit") = XEmpCuit
                .Item("Paridad") = Val(XParidadTotal)

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
                .Item("Rete1") = Val(txtGanancias.Text)
                .Item("Rete2") = Val(txtIngresosBrutos.Text) + Val(txtIBCiudad.Text)
                .Item("Total") = Val(txtIVA.Text)
                .Item("Observaciones") = txtObservaciones.Text
                .Item("Empresa") = "Surfactan S.A."
                .Item("Cuit") = XEmpCuit
                .Item("Paridad") = Val(XParidadTotal)
            End With

            Tabla.Rows.Add(row)

        Next

        crdoc.SetDataSource(Tabla)

        With VistaPrevia
            .Reporte = crdoc
            .Mostrar()
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
            .Reporte = crdoc
            .Mostrar()
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
        Dim WLetra, WTipo, WPunto, WNumero, ZNroInterno, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, ZZTotal, ZZSaldo, ZZSuma, WPrvDireccion, WPrvCuit, WPrvIb
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
                ZZTotal = 0.0
                ZZSaldo = 0.0
                ZZSuma = 0.0

                Try
                    cn.Open()
                    cm.CommandText = "SELECT ccp.NroInterno, ccp.Fecha, ccp.Total, ccp.Saldo, i.Rechazado, i.Neto FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        ZNroInterno = dr.Item("NroInterno")
                        ZRechazado = IIf(IsDBNull(dr.Item("Rechazado")), "0", dr.Item("Rechazado"))
                        XImpre3 = dr.Item("Fecha")
                        ZZSuma = dr.Item("Neto")

                    Else
                        ZZSuma = Val(.Cells(4).Value) / 1.21
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
            .Reporte = crdoc
            .Mostrar()
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
        Dim WLetra, WTipo, WPunto, WNumero, ZNroInterno, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim ZZTotal, ZZSaldo, ZZSuma As Double
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
                ZZTotal = 0.0
                ZZSaldo = 0.0
                ZZSuma = 0.0

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
                        ZZSuma = Val(.Cells(4).Value) / 1.21
                    End If

                Catch ex As Exception
                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Finally

                    cn.Close()

                End Try

                'WImpre4 = Val(.Cells(4).Value)
                WImpre4 = ZZSuma

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
                            row.Item("Categoria1") = IIf(Val(XImpre4) <> 0, "SUJETO A RETENCION " & CDbl(WPorceIb) & " %", "")
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = IIf(Val(XImpre4) <> 0, CDbl(WPorceIb), 0)
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
                            row.Item("Categoria1") = IIf(Val(XImpre4) <> 0, "SUJETO A RETENCION " & CDbl(WPorceIb) & " %", "")
                            row.Item("Importe1") = CDbl(XImpre4)
                            row.Item("Porce1") = IIf(Val(XImpre4) <> 0, CDbl(WPorceIb), 0)
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
            .Reporte = crdoc
            .Mostrar()
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
            .Reporte = crdoc
            .Mostrar()
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
        Dim ZZCorte, ZZOrden, ZZRenglon, ZZProveedor, ZZFecha, ZZNumeroCheque, ZZFechaCheque, ZZBancoCheque, ZZCuit As String
        Dim ZZImporteCheque = 0.0
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
                        ZZImporteCheque = Val(.Cells(5).Value)
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
                            .Item("Importe") = Val(ZZImporteCheque)
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
                            .Item("Importe") = Val(ZZImporteCheque)
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
            ZZImporteCheque = 0.0
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
                .Reporte = crdoc
                .Mostrar()
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
                    If Trim(lstConsulta.SelectedItem) = "" Or Not optCtaCte.Checked Then
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
            .Reporte = crdoc
            .Mostrar()
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

    Private Sub _RecalcularRetenciones()

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

        ' Recalculo de Retenciones de Ganancias.
        _RecalcularRetencionGanancias()

        ' Recalculo de Retenciones por Iva.
        _RecalcularRetencionIVA()

        ' Recalculo IB Provincia
        _RecalcularIBProvincia()

        ' Recalculo IB CABA
        _RecalcularIBCABA()

        sumarImportes()

    End Sub

    Private Sub _RecalcularIBCABA()

        Dim ZZSuma, acumCaba

        acumCaba = 0.0

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Trim(.Cells(4).Value) <> "" Then

                    ZZSuma = 0.0

                    ZZSuma = Val(.Cells(4).Value) / 1.21

                    acumCaba += CaculoRetencionIngresosBrutosCaba(Val(WTipoIbCaba), WPorceIbCaba, Val(ZZSuma))
                Else
                    Exit For
                End If
            End With
        Next

        txtIBCiudad.Text = acumCaba

    End Sub

    Private Sub _RecalcularIBProvincia()
        Dim acumProv, acumCaba

        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal, ZZSaldo
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma, ZZTotal, ZZSumaNeto
        Dim ZFactura As DataRow = Nothing
        Dim ZNroInterno As Integer = 0

        acumProv = 0
        acumCaba = 0

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Trim(.Cells(4).Value) <> "" Then

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
                    ZZSumaNeto = 0

                    ZTipo = ""
                    ZNumero = ""
                    ZPunto = ""
                    ZLetra = ""
                    ZTotal = 0
                    ZZSaldo = 0

                    ' Recalculo sobre porcentaje neto en Iva Comp.
                    If Trim(.Cells(4).Value) <> "" Then
                        ZTipo = .Cells(0).Value
                        ZLetra = .Cells(1).Value
                        ZPunto = .Cells(2).Value
                        ZNumero = .Cells(3).Value
                        ZImporte = .Cells(4).Value

                        ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZLetra, ZNumero)

                        If Not IsNothing(ZFactura) Then

                            ZNeto = ZFactura.Item("Neto")

                            ZIva = ZFactura.Item("Iva21")
                            ZIva5 = ZFactura.Item("Iva5")
                            ZIva27 = ZFactura.Item("Iva27")
                            ZIva105 = ZFactura.Item("Iva105")
                            ZIb = ZFactura.Item("Ib")
                            ZExento = ZFactura.Item("Exento")

                            ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento

                            If Val(ZImporte) = Val(ZTotal) Then

                                ZZSuma = ZNeto

                            Else

                                ZPorce = Val(ZImporte) / ZTotal

                                ZZSuma = ZNeto * ZPorce
                            End If

                        Else

                            ZZSuma = Val(ZImporte) / 1.21

                        End If

                    End If

                    acumProv += CaculoRetencionIngresosBrutos(Val(WTipoIb), WPorceIb, Val(ZZSuma))
                Else
                    Exit For
                End If
            End With
        Next

        txtIngresosBrutos.Text = _NormalizarNumero(acumProv)

    End Sub

    Private Function _BuscarCompra(ByVal proveedor, ByVal tipo, ByVal letra, ByVal numero)
        Dim compra As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As New SqlCommand("SELECT Neto, Iva21, Iva5, Iva27, Iva105, Ib, Exento FROM IvaComp WHERE Proveedor = '" & proveedor & "' and letra = '" & letra & "' and numero = '" & numero & "' and tipo = '" & tipo & "'")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader

            If dr.HasRows Then

                compra.Load(dr)

                Return compra.Rows(0)

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

    Private Function _BuscarCompra(ByVal NroInterno As Integer)
        Dim compra As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm = "SELECT Iva21, Iva5, Iva27, Iva105, Ib, Exento, Neto FROM IvaComp WHERE NroInterno = '" & NroInterno & "'"
        Dim dr As New SqlDataAdapter(cm, cn)

        Try
            cn.ConnectionString = _CS()
            cn.Open()

            dr.Fill(compra)

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If compra.Rows.Count > 0 Then
            Return Proceso._NormalizarFila(compra.Rows(0))
        Else
            Return Nothing
        End If
    End Function

    Private Sub _RecalcularRetencionGanancias()
        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal, ZZSaldo
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma, ZZTotal, ZZBase, ZZSumaNeto
        Dim ZNroInterno As Integer = 0
        Dim ZFactura As DataRow = Nothing

        ZNeto = 0.0
        ZIva = 0.0
        ZIva5 = 0.0
        ZIva27 = 0.0
        ZIva105 = 0.0
        ZIb = 0.0
        ZExento = 0.0
        ZPorce = 0.0
        ZImporte = 0.0
        ZZSuma = 0.0
        ZZTotal = 0.0
        ZZBase = 0.0
        ZZSumaNeto = 0.0

        ZTipo = ""
        ZNumero = ""
        ZPunto = ""
        ZLetra = ""
        ZTotal = 0.0
        ZZSaldo = 0.0

        ' Recalculo sobre porcentaje neto en Iva Comp.
        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Trim(.Cells(4).Value) <> "" Then
                    ZTipo = .Cells(0).Value
                    ZLetra = .Cells(1).Value
                    ZPunto = .Cells(2).Value
                    ZNumero = .Cells(3).Value
                    ZImporte = .Cells(4).Value

                    ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZLetra, ZNumero)

                    If Not IsNothing(ZFactura) Then

                        ZNeto = ZFactura.Item("Neto")
                        ZIva = ZFactura.Item("Iva21")
                        ZIva5 = ZFactura.Item("Iva5")
                        ZIva27 = ZFactura.Item("Iva27")
                        ZIva105 = ZFactura.Item("Iva105")
                        ZIb = ZFactura.Item("Ib")
                        ZExento = ZFactura.Item("Exento")

                        ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento


                        If Val(ZImporte) = Val(ZTotal) Then

                            ZZSuma = ZNeto

                        Else

                            ZPorce = Val(ZImporte) / ZTotal

                            ZZSuma = ZNeto * ZPorce
                        End If

                    Else

                        ZZSuma = Val(ZImporte) / 1.21

                    End If

                    ZZBase += Val(ZImporte)
                    ZZSumaNeto += ZZSuma
                Else
                    Exit For
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
        Dim ZFactura As DataRow = Nothing
        Dim ZNroInterno As Integer = 0

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
                If Trim(.Cells(4).Value) <> "" Then
                    ZTipo = .Cells(0).Value
                    ZLetra = .Cells(1).Value
                    ZPunto = .Cells(2).Value
                    ZNumero = .Cells(3).Value
                    ZImporte = .Cells(4).Value


                    ZZSuma = 0.0

                    If Val(ZImporte) <> 0 And UCase(ZLetra) = "M" Then

                        ZNeto = ZImporte / 1.21
                        ZIva = ZImporte - ZNeto

                        If ZNeto >= 1000 Then

                            ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZLetra, ZNumero)

                            If Not IsNothing(ZFactura) Then

                                ZZSuma = ZFactura.Item("Iva21")

                            Else

                                ZZSuma = Val(ZImporte) / 1.21

                            End If

                        End If

                    End If

                    ZZBase += ZZSuma
                Else
                    Exit For
                End If
            End With
        Next

        txtIVA.Text = _NormalizarNumero(ZZBase)

    End Sub

    Private Function _BuscarCtaCteProv(ByVal _Clave As String) As DataRow

        _Clave = Trim(_Clave)

        Dim dt As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT NroInterno, Total, Saldo FROM CtaCtePrv WHERE clave = '" & _Clave & "'")
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

    Private Sub gridPagos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridPagos.CellMouseDoubleClick
        Dim iRow As DataGridViewRow

        iRow = gridPagos.Rows(e.RowIndex)

        If MsgBox("¿Está seguro de querer eliminar la fila?", MsgBoxStyle.YesNo, MsgBoxStyle.Information) = DialogResult.No Then
            Exit Sub
        End If

        gridPagos.Rows.Remove(iRow)
    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCuenta.Text) = "" Then : Exit Sub : End If

            Dim valida As Boolean = False

            Dim cn As SqlConnection = New SqlConnection()
            Dim cm As SqlCommand = New SqlCommand("SELECT Cuenta FROM Cuenta WHERE Cuenta = '" & Val(txtCuenta.Text) & "'")
            Dim dr As SqlDataReader

            Try
                cn.ConnectionString = _CS()
                cn.Open()
                cm.Connection = cn
                dr = cm.ExecuteReader()

                valida = dr.HasRows

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                dr = Nothing
                cn.Close()
                cn = Nothing
                cm = Nothing

            End Try

            If valida And WRowVarios >= 0 Then
                WCuenta(WRowVarios, WProceso.Text) = txtCuenta.Text
                txtCuenta.Text = ""
                pnlPedirCuenta.Visible = False


                Select Case Val(WProceso.Text)
                    Case 1
                        If gridPagos.CurrentCell.RowIndex < XMAXFILAS - 1 Then
                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(WRowVarios + 1).Cells(0)
                        Else
                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(WRowVarios).Cells(0)
                        End If
                        gridFormaPagos.Focus()
                    Case 2
                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(WRowVarios).Cells(5)
                        gridFormaPagos.Focus()
                End Select


                WRowVarios = -1
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCuenta.Text = ""
        End If

    End Sub

    Private Function _BuscarCambioDiviza(ByVal Fecha As String) As Double
        Dim ZCambioDivisa = 0.0

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "SELECT Cambio, CambioDivisa FROM Cambios WHERE Fecha = '" & Fecha & "'"

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                With dr
                    .Read()
                    ZCambioDivisa = IIf(IsDBNull(.Item("CambioDivisa")), "0", .Item("CambioDivisa"))
                    If ZCambioDivisa = 0 And .Item("Cambio") <> 0 Then
                        MsgBox("La fecha " + txtFecha.Text + " no tiene informado cambio divisa y se tomara el cambio de ventas", MsgBoxStyle.Information)
                        ZCambioDivisa = .Item("Cambio")
                    End If

                End With
            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ZCambioDivisa

    End Function

    Private Function _CalculaVencimiento(ByVal WFecha As String, ByVal Plazo As Integer)

        Dim Dg As Integer
        Dim Ano As Integer
        Dim WAno As String
        Dim Mes As Integer
        Dim WMes As String
        Dim Dia As Integer
        Dim WDia As String
        Dim Di As Integer
        Dim aa As Integer
        Dim Ds(20) As Integer

        Ds(1) = 31
        Ds(2) = 28
        Ds(3) = 31
        Ds(4) = 30
        Ds(5) = 31
        Ds(6) = 30
        Ds(7) = 31
        Ds(8) = 31
        Ds(9) = 30
        Ds(10) = 31
        Ds(11) = 30
        Ds(12) = 31

        REM   DATA "0101","0105","2505", , ,"0907", ,"1210", ,"2512", , , , , ,

        Dg = 0
        WAno = Mid$(WFecha, 7, 4)
        Ano = Val(WAno)
        WMes = Mid$(WFecha, 4, 2)
        Mes = Val(WMes)
        WDia = Mid$(WFecha, 1, 2)
        Dia = Val(WDia)

        'CANTIDAD DE DIAS HASTA LA FECHA

        Dg = Dia + Plazo - 1

        Do
            For aa = Mes To 12
                If (Ano Mod 4 = 0) And Mes = 2 Then Ds(2) = 29 Else Ds(2) = 28
                If Dg <= Ds(aa) Then Exit Do
                Dg = Dg - Ds(aa)
            Next aa
            Ano = Ano + 1
            Mes = 1
        Loop

        Dia = Dg
        WDia$ = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Dia), 2, Len(Str$(Dia)) - 1), 2)

        Mes = aa
        WMes = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Mes), 2, Len(Str$(Mes)) - 1), 2)

        WAno = Microsoft.VisualBasic.Right$("0" + Mid$(Str$(Ano), 2, Len(Str$(Ano)) - 1), 4)

        Return WDia + "/" + WMes + "/" + WAno
    End Function

    Private Sub btnDifeCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDifeCambio.Click
        Dim ZCambioDivisa = 0.0, ZZParidadOP = 0.0, ZZSumaI = 0.0, ZZSumaII = 0.0, ZZRete = 0.0, ZZParidad = 0.0, ZZCicloDia = 0
        Dim XTipo2 = "", XNumero2 = "", XFecha2 = "", XFechaOrd2 = "", XBanco2 = "", XObservaciones2 = "", XImporte2 = 0.0
        Dim TipoRecibos = "", ClaveRecibos = "", Cuit = "", ClaveCtacte = "", ZZFechaAnterior = "", XFec2 = ""

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim trans As SqlTransaction

        cn.ConnectionString = _CS()
        cm.Connection = cn

        Try
            ZCambioDivisa = _BuscarCambioDiviza(txtFecha.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If ZCambioDivisa = 0 Then
            MsgBox("La fecha " + txtFecha.Text + " no tiene informado paridad", "Emision de Ordenes de Pago", MsgBoxStyle.Information)
            Exit Sub
        End If

        ZZParidadOP = ZCambioDivisa


        ZZSumaI = 0
        ZZSumaII = 0

        ZZRete = Val(txtIBCiudad.Text) + Val(txtIVA.Text) + Val(txtGanancias.Text) + Val(txtIngresosBrutos.Text)
        ZZSumaII = ZZSumaII + (ZZRete / ZZParidadOP)

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Not IsNothing(.Cells("Importe")) Then
                    If Val(.Cells("Importe").Value) <> 0 Then
                        ZZSumaI += (Val(.Cells("Importe").Value) / ZZParidadOP)
                    End If
                End If
            End With
        Next

        For Each row As DataGridViewRow In gridFormaPagos.Rows

            XTipo2 = ""
            XNumero2 = ""
            XFecha2 = ""
            XFechaOrd2 = ""
            XBanco2 = ""
            XObservaciones2 = ""
            XImporte2 = 0.0
            TipoRecibos = ""
            ClaveRecibos = ""
            Cuit = ""
            ClaveCtacte = ""
            ZZParidad = 0.0

            With row
                If Not IsNothing(.Cells(5)) Then
                    If Val(.Cells(5).Value) <> 0 Then

                        XTipo2 = .Cells(0).Value
                        XNumero2 = .Cells(1).Value
                        XFecha2 = .Cells(2).Value
                        XFechaOrd2 = Proceso.ordenaFecha(XFecha2)
                        XBanco2 = .Cells(3).Value
                        XObservaciones2 = .Cells(4).Value
                        XImporte2 = Val(.Cells(5).Value)
                        ClaveCtacte = .Cells("XClave").Value
                        TipoRecibos = Mid(ClaveCtacte, 1, 1)
                        ClaveRecibos = Mid(ClaveCtacte, 2, 10)
                        Cuit = .Cells(6).Value


                        Select Case XTipo2
                            Case 2, 3

                                ZZCicloDia = 0

                                Do
                                    Try
                                        ZCambioDivisa = _BuscarCambioDiviza(XFecha2)
                                    Catch ex As Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        Exit Sub
                                    End Try

                                    ZZFechaAnterior = XFecha2

                                    If ZCambioDivisa = 0 Then

                                        ZZCicloDia = ZZCicloDia + 1
                                        If ZZCicloDia = 15 Then
                                            XFecha2 = ZZFechaAnterior
                                            Exit Do
                                        End If

                                        XFecha2 = _CalculaVencimiento(XFecha2, 2)

                                    Else

                                        Exit Do

                                    End If
                                Loop

                                If ZCambioDivisa = 0 Then
                                    MsgBox("La fecha " + XFecha2 + " no tiene informado paridad", "Emision de Ordenes de Pago", MsgBoxStyle.Information)
                                    Exit Sub
                                End If
                                ZZParidad = ZCambioDivisa

                            Case Else

                                ZZParidad = ZZParidadOP

                        End Select

                        Dim ZSql = ""
                        ZSql = ZSql + "UPDATE Pagos SET "
                        ZSql = ZSql + " ImpoList = " + "'" + Str$(ZZParidad) + "'"
                        ZSql = ZSql + " Where Clave = " + "'" + WClavesOP(row.Index) + "'"


                        Try
                            cn.Open()
                            trans = cn.BeginTransaction

                            cm.CommandText = ZSql
                            cm.Transaction = trans
                            cm.ExecuteNonQuery()
                            trans.Commit()
                        Catch ex As Exception

                            If Not IsNothing(trans) Then
                                trans.Rollback()
                            End If

                            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                            Exit Sub
                        Finally

                            cn.Close()

                        End Try

                    End If
                End If
            End With

        Next

        With VistaPrevia
            .Reporte = New AnalisisDiferenciaCambioOP
            .Formula = "{Pagos.Orden} = '" & txtOrdenPago.Text & "' AND {Pagos.Impolist} <> 0"
            .Mostrar()
        End With

    End Sub

End Class