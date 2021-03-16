Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports ClasesCompartidas
Imports Util.Clases
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop.Outlook
Imports Sistema_Solicitud_Fondos

Public Class Pagos
    Dim pagos As New List(Of DetalleCompraCuentaCorriente)
    Dim cheques As New List(Of Cheque)
    Private XParidadTotal As String = "0"
    Dim _ClavesCheques As New List(Of Object)
    Dim _Carpetas(10) As String
    Dim _Claves As New List(Of Object)
    Dim WClavesOP(100) As String
    Dim WCuenta(100, 2) As String
    Dim _TipoConsulta As Integer = Nothing
    Private WCertificadoGan, WCertificadoIb, WCertificadoIbCiudad, WCertificadoIVA As String

    Dim NroSoliInterno As Integer = 0
    Public Property GenerarPDF As Boolean

    Private WGrillaReferencia As DataGridView

    Private Const XMAXFILAS = 30
    Private WRow, Wcol, WRowVarios As Integer

    Private WTipoProv, WTipoIva, WTipoIb, WTipoIbCaba, WPorceIb, WPorceIbCaba As String
    ' Para calculos de Retenciones.
    Dim varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva, varOrdFecha

    ' Utilizado para poder ser usado con consulta de cta cte prv por pantalla.
    Private _SoloLectura As String = False

    Dim XTiporeg, XNumero2, XFecha2, XBanco2, XImporte2, XDestino, XEstado, XVencimiento, XVencimiento1, XTotal, XSaldo, XSaldoUs, XOrdFecha, XOrdVencimiento, XImpre, XNeto, XDate, XParam, XSql As String

    Public Property SoloLectura As Boolean
        Get
            Return _SoloLectura
        End Get
        Set(ByVal value As Boolean)
            _SoloLectura = value
        End Set
    End Property

    Private Sub Pagos_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        pnlDifCamXFactura.Visible = False



        Text = "Ingreso de Pagos a Proveedores  " & ClasesCompartidas.Globals.NombreEmpresa()

        If SoloLectura Then
            Dim botones As New List(Of Button) From {btnAgregar, btnCalcular, btnCarpetas, btnChequesTerceros, btnConsulta, btnCtaCte, btnImprimir, btnLimpiar}

            For Each btn As Button In botones
                btn.Visible = False
            Next

            btnCerrar.Location = New Point(387, btnCerrar.Location.Y)

        Else
            btnLimpiar.PerformClick()

            txtFechaParidad.Text = txtFecha.Text
            txtParidad.Text = traerParidad()
        End If

        _PurgarSaldosCtaCtePrvs()

        btn_ConsultaSoliFondos.Visible = False

    End Sub

    Private Function _TraerDatosProveedorTipoProvinciaEmbargo() As Object
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Provincia, TipoProv, Embargo FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'")
        Dim dr As SqlDataReader
        Dim WProv = 0, WWTipoProv = 0, WEmbargo = "N"

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                WProv = IIf(IsDBNull(dr.Item("Provincia")), 0, dr.Item("Provincia"))
                WWTipoProv = IIf(IsDBNull(dr.Item("TipoProv")), 0, dr.Item("TipoProv"))
                WEmbargo = IIf(IsDBNull(dr.Item("Embargo")), "N", dr.Item("Embargo"))

                WProv = Val(WProv)
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos. No se encontró proveedor.")
        Finally

            cn.Close()

        End Try

        Return {WProv, WWTipoProv, WEmbargo}
    End Function

    Private Function _ExisteOrdenDePago(ByVal NumOrden) As Boolean
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Orden FROM Pagos WHERE Orden = '" & NumOrden & "' And ISNULL(MarcaVirtual, '') <> 'X'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            cn.Close()

        End Try

    End Function

    Private Function _FechasValidasFormasPago() As Boolean

        Dim WOrdFecha1 As String = ordenaFecha(txtFecha.Text)
        Dim WOrdFecha2, WFecha2 As String

        If gridFormaPagos.Rows.Count > 0 Then
            For Each row As DataGridViewRow In gridFormaPagos.Rows
                WFecha2 = row.Cells(2).Value
                If Not IsNothing(row) And Not IsNothing(WFecha2) Then

                    If Val(row.Cells(0).Value) = 2 Then

                        If Trim(WFecha2.Replace("/", "")) <> "" And _ValidarFecha(WFecha2) Then

                            WOrdFecha2 = ordenaFecha(WFecha2)

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
                        If Val(.Cells(4).Value) <> 0 And WCuenta(row.Index, 1) = "" Then
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

    Private Function _ExisteFactura(ByVal Clave) As Boolean
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Clave FROM CtaCtePrv WHERE Clave = '" & Clave & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return dr.HasRows

            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            cn.Close()

        End Try

        Return False
    End Function

    Private Function _ImputacionesFacturasACancelar() As Boolean
        Dim XTipo1, XLetra1, XPunto1, XNumero1, XImporte1, WXClave As String

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not IsNothing(row) And Not IsNothing(row.Cells(4).Value) Then

                With row
                    'If val(.Cells(4).Value) <> 0 Then
                    XTipo1 = .Cells(0).Value
                    XLetra1 = .Cells(1).Value
                    XPunto1 = .Cells(2).Value
                    XNumero1 = .Cells(3).Value
                    XImporte1 = .Cells(4).Value

                    WXClave = txtProveedor.Text & XLetra1 & XTipo1 & XPunto1 & XNumero1

                    If XNumero1 <> "99999999" And Val(XImporte1) <> 0 Then

                        Try
                            If Not _ExisteFactura(WXClave) Then
                                Return False
                            End If
                        Catch ex As System.Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Return False
                        End Try

                    End If
                    'End If

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
            If Val(txtBanco.Text) = 0 Then
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
                MsgBox("Error en la imputacion de facturas a cancelar")
                Return False
            End If
        End If

        ' Controlamos balanceo.
        If _NormalizarNumero(lblPagos.Text) <> _NormalizarNumero(lblFormaPagos.Text) Then
            MsgBox("Los créditos y débitos no se encuentran balanceados.", MsgBoxStyle.Critical)
            Return False
        End If

        ' Buscamos el tipo de prov y numero de provincia.

        Dim datos_prov As Object ' {Provincia, TipoProv, Embargo}

        Try
            datos_prov = _TraerDatosProveedorTipoProvinciaEmbargo()
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        ' Si la orden de pago se realiza a alguno de estos proveedores o a un proveedor del exterior tipo = 1, se tiene que cargar numero de carpeta.
        If txtProveedor.Text = "10167878480" Or txtProveedor.Text = "10000000100" Or txtProveedor.Text = "10071081483" Or txtProveedor.Text = "10069345023" Or txtProveedor.Text = "10066352912" Or (Val(datos_prov(0)) = 24 And Val(datos_prov(1)) = 1) Then

            If Val(_Carpetas(1)) = 0 And Val(_Carpetas(2)) = 0 And Val(_Carpetas(3)) = 0 And Val(_Carpetas(4)) = 0 And Val(_Carpetas(5)) = 0 And Val(_Carpetas(6)) = 0 And Val(_Carpetas(7)) = 0 And Val(_Carpetas(8)) = 0 And Val(_Carpetas(9)) = 0 And Val(_Carpetas(10)) = 0 Then
                'If entra Then
                If MsgBox("¿El pago que se esta efectuando corresponde a una Importacion?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                    MsgBox("Se debe informar el numero de carpeta correspondiente", MsgBoxStyle.Critical)
                    Return False
                End If
                'End If
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
                MsgBox("Ya existe una Orden de Pago con esta numeración. Para grabar una nueva Orden de Pago debe dejar en 0 el campo 'Orden de Pago'", MsgBoxStyle.Exclamation)
                txtOrdenPago.Focus()
                Return False
            End If
        End If

        ' Validamos las fechas cargadas.
        If Not _FechasValidasFormasPago() Then
            Return False
        End If

        Return True
    End Function

    Private Function _CS(Optional ByVal empresa As String = "SurfactanSA")
        Return _ConectarA(empresa)
    End Function

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub mostrarOrdenDePago(ByVal orden As OrdenPago)
        If IsNothing(orden) Then
            Throw New System.Exception("Orden de Pago no existente")
        End If
        btnLimpiar.PerformClick()

        If SoloLectura Then
            _LimpiarGrillas()
        End If

        txtOrdenPago.Text = orden.nroOrden
        txtFecha.Text = _Normalizarfecha(orden.fecha)
        txtObservaciones.Text = orden.observaciones
        txtFechaParidad.Text = txtFecha.Text
        txtGanancias.Text = _NormalizarNumero(orden.retGanancias)
        txtIBCiudad.Text = _NormalizarNumero(orden.retIBCiudad)
        txtIngresosBrutos.Text = _NormalizarNumero(orden.retIB)
        txtIVA.Text = _NormalizarNumero(orden.retIVA)


        mostrarProveedor(orden.proveedor)
        mostrarBanco(orden.banco)
        mostrarTipo(orden.tipo)
        mostrarPagos(orden.pagos)
        mostrarFormaPagos(orden.formaPagos)

        txtParidad.Text = _NormalizarNumero(orden.paridad, 4)
        WCertificadoIb = orden.certIb
        WCertificadoIbCiudad = orden.certIbCABA
        WCertificadoIVA = orden.certIVA

        sumarImportes()
    End Sub

    Private Sub mostrarTipo(ByVal ZTipo As Integer)
        Select Case ZTipo
            Case 1
                optCtaCte.Checked = True
            Case 5
                optChequeRechazado.Checked = True
            Case 2
                optAnticipos.Checked = True
            Case 4
                optTransferencias.Checked = True
            Case Else
                optVarios.Checked = True
        End Select
    End Sub

    Private Sub mostrarPagos(ByVal _pagos As List(Of Pago))
        'gridPagos.Rows.Clear()

        Dim renglon = 0

        For Each pago As Pago In _pagos
            With gridPagos.Rows(renglon)
                .Cells(0).Value = pago.tipo
                .Cells(1).Value = pago.letra
                .Cells(2).Value = pago.punto
                .Cells(3).Value = pago.numero
                .Cells(4).Value = _NormalizarNumero(pago.importe)
                .Cells(5).Value = pago.descripcion

                If Val(pago.impoNeto) = 0 Then
                    .Cells(6).Value = _CalcularImpoNeto(pago.tipo, pago.letra, pago.punto, pago.numero, pago.importe)
                Else
                    .Cells(6).Value = _NormalizarNumero(pago.impoNeto)
                End If

                Dim WIVaComp As DataRow = _BuscarInfoIvaCompPorClave(pago.tipo, pago.letra, pago.punto, pago.numero)
                .Cells("MarcaDifCambio").Value = "0"
                .Cells("MarcaCHR").Value = "0"
                If Not IsNothing(WIVaComp) Then
                    .Cells("MarcaDifCambio").Value = WIVaComp.Item("MarcaDifCambio")
                    .Cells("MarcaCHR").Value = WIVaComp.Item("Rechazado")
                End If

            End With
            renglon += 1
        Next
        'sumarImportes()
    End Sub

    Private Function _BuscarInfoIvaCompPorClave(ByVal tipo1 As String, ByVal letra1 As String, ByVal punto1 As String, ByVal numero1 As String) As DataRow
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Paridad, Pago, ISNULL(MarcaDifCambio, 0) As MarcaDifCambio, ISNULL(Rechazado, 0) As Rechazado FROM IvaComp WHERE Tipo =  '" & tipo1 & "' And Letra = '" & letra1 & "' And Punto = '" & punto1 & "' And Numero = '" & numero1 & "'")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            tabla.Load(dr)

            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la informacion de la factura en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try
    End Function

    Private Function _CalcularImpoNeto(ByVal ztipo, ByVal zletra, ByVal zpunto, ByVal znumero, ByVal zimporte)
        Dim WImpoNeto = 0.0
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Iva21, Iva5, Iva27, Iva105, Ib, Exento, Neto  FROM IvaComp WHERE Proveedor = '" & txtProveedor.Text & "' AND Tipo = '" & ztipo & "' AND Letra = '" & zletra & "' AND Punto = '" & zpunto & "' AND Numero = '" & znumero & "'")
        Dim dr As SqlDataReader
        Dim WIva21, WIva5, WIva27, WIva105, WIb, WExento, WNeto, WTotal, WPorce

        Try

            SQLConnector.conexionSql(cn, cm)

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr

                    WIva21 = IIf(IsDBNull(.Item("Iva21")), 0, .Item("Iva21"))
                    WIva5 = IIf(IsDBNull(.Item("Iva5")), 0, .Item("Iva5"))
                    WIva27 = IIf(IsDBNull(.Item("Iva27")), 0, .Item("Iva27"))
                    WIva105 = IIf(IsDBNull(.Item("Iva105")), 0, .Item("Iva105"))
                    WIb = IIf(IsDBNull(.Item("Ib")), 0, .Item("Ib"))
                    WExento = IIf(IsDBNull(.Item("Exento")), 0, .Item("Exento"))
                    WNeto = IIf(IsDBNull(.Item("Neto")), 0, .Item("Neto"))

                    WTotal = WIva21 + WIva5 + WIva27 + WIva105 + WIb + WExento + WNeto

                    If zimporte = WTotal Then
                        WImpoNeto = WNeto 'importe
                    Else
                        WPorce = zimporte / WTotal

                        WImpoNeto = WNeto * WPorce
                    End If


                End With

            Else
                WImpoNeto = zimporte / 1.21
            End If

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return WImpoNeto
    End Function

    Private Sub mostrarFormaPagos(ByVal formaPagos As List(Of FormaPago))
        'gridFormaPagos.Rows.Clear()

        Dim WRenglon = 0

        For Each formaPago As FormaPago In formaPagos

            With gridFormaPagos.Rows(WRenglon)
                .Cells(0).Value = formaPago.tipo
                .Cells(1).Value = formaPago.numero
                .Cells(2).Value = formaPago.fecha
                .Cells(3).Value = formaPago.banco
                .Cells(4).Value = formaPago.nombre
                .Cells(5).Value = _NormalizarNumero(formaPago.importe)
                .Cells(6).Value = ""
                .Cells(7).Value = formaPago.cuit
            End With

            WClavesOP(WRenglon) = ceros(txtOrdenPago.Text, 6) & ceros(WRenglon + 2, 2)

            Dim WRenglonPago As DataRow = GetSingle("SELECT Cuenta FROM Pagos WHERE Clave = '" & WClavesOP(WRenglon) & "'")

            If WRenglonPago IsNot Nothing Then
                gridFormaPagos.Rows(WRenglon).Cells("Cuenta").Value = Trim(OrDefault(WRenglonPago("Cuenta"), ""))
            End If

            WRenglon += 1

        Next

        'sumarImportes()
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        If IsNothing(proveedor) Then : Exit Sub
        End If

        txtProveedor.Text = proveedor.id
        txtRazonSocial.Text = proveedor.razonSocial
        WTipoProv = proveedor.tipo + 1
        WTipoIva = proveedor.codIva
        WTipoIb = proveedor.condicionIB1
        WTipoIbCaba = proveedor.condicionIB2
        WPorceIb = proveedor.porceIBProvincia
        WPorceIbCaba = proveedor.porceIBCABA



        txtFormasPagosAceptadas.Visible = False

        'Dim Prov As DataRow = GetSingle("SELECT AceptaCheques, AceptaTransferencias FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'")

        'If Prov IsNot Nothing Then

        '    If OrDefault(Prov("AceptaCheques"), "") <> "" Then
        '        txtFormasPagosAceptadas.Text = "ACEPTA E-CHEQ"
        '    End If

        '    If OrDefault(Prov("AceptaTransferencias"), "") <> "" Then
        '        If txtFormasPagosAceptadas.Text <> "" Then txtFormasPagosAceptadas.Text &= " / "
        '        txtFormasPagosAceptadas.Text &= "ACEPTA TRANSFERENCIAS"
        '    End If

        'End If

        'txtFormasPagosAceptadas.Visible = txtFormasPagosAceptadas.Text.Trim <> ""

    End Sub

    Private Sub mostrarBanco(ByVal banco As Banco)
        If IsNothing(banco) Then : Exit Sub
        End If
        txtBanco.Text = banco.id
        txtNombreBanco.Text = banco.nombre
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Trim(txtProveedor.Text) <> "" Then

                txtFormasPagosAceptadas.Text = ""
                txtFormasPagosAceptadas.Visible = False

                Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)

                If Not IsNothing(proveedor) Then
                    mostrarProveedor(proveedor)

                    btnCtaCte.PerformClick()
                Else
                    txtRazonSocial.Text = ""
                    MessageBox.Show("El proveedor ingresado es inexistente")
                    txtProveedor.Focus()
                    Exit Sub
                End If

            End If

            txtObservaciones.Focus()

        End If
    End Sub

    Private Sub txtBanco_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBanco.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Trim(txtBanco.Text) = "" And Not optVarios.Checked Then
                _TipoConsulta = 1
                _ListarCuentasContables()
                Exit Sub
            End If

            Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)
            If Not IsNothing(banco) Then
                mostrarBanco(banco)
            End If

            With gridPagos
                .CurrentCell = .Rows(0).Cells(4)
                .Focus()
            End With

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

    Private Function _TraerCambioDivisa(ByVal zfecha As String) As String
        Dim _CambioDivisa = "0"
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT CambioDivisa FROM Cambios WHERE Fecha = '" & zfecha & "'")
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

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return _CambioDivisa
    End Function

    Private Sub _ListarCtasCtes()
        Dim XClaves As New List(Of Object)
        Dim _Item As String
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT cp.NroInterno, cp.Total, cp.Saldo, cp.Impre, cp.Letra, cp.Punto, " & "cp.Numero, cp.Fecha, cp.Clave FROM CtaCtePrv as cp WHERE cp.Proveedor = '" & Trim(txtProveedor.Text) & "' and cp.Saldo <> 0 And ISNULL(cp.MarcaVirtual, '') <> 'X' ORDER BY cp.OrdFecha ASC, cp.Numero")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            lstConsulta.Items.Clear()

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    XClaves.Clear()

                    Do While .Read()
                        Dim XNroInterno, ZZSaldo, ZZSaldoUS, ZZImpre, XLetra, XPunto, XNumero, XFecha, XParidad, XPago As String

                        XNroInterno = .Item("NroInterno").ToString()
                        ZZSaldo = _NormalizarNumero(.Item("Saldo").ToString())
                        ZZSaldoUS = 0.0
                        XParidadTotal = 0.0
                        ZZImpre = .Item("Impre").ToString()
                        XLetra = .Item("Letra").ToString()
                        XPunto = .Item("Punto").ToString()
                        XNumero = .Item("Numero").ToString()
                        XFecha = .Item("Fecha").ToString()
                        XParidad = 0 '_NormalizarNumero(.Item("Paridad").ToString(), 4)
                        XPago = 0 '.Item("Pago").ToString()

                        If Val(XNroInterno) <> 0 Then

                            Dim WIvaComp As DataRow = _BuscarInfoIvaComp(XNroInterno)

                            If Not IsNothing(WIvaComp) Then
                                With WIvaComp
                                    XParidad = IIf(IsDBNull(.Item("Paridad")), "0", formatonumerico(.Item("Paridad")))
                                    XPago = IIf(IsDBNull(.Item("Pago")), "0", Val(.Item("Pago")))
                                End With
                            End If

                        End If

                        If Val(XPago) <> 2 Then


                            If Val(XParidad) <> 0 Then
                                XParidadTotal = _TraerCambioDivisa(txtFechaParidad.Text)

                                ZZSaldoUS = (Val(ZZSaldo) / Val(XParidad)) * Val(XParidadTotal)
                            End If

                        End If


                        If Val(ZZSaldoUS) = 0 Then
                            ZZSaldoUS = ""
                        End If
                        _Item = ZZImpre & "    " & XLetra & "    " & XPunto & "    " & XNumero & "    " & XFecha & RSet(formatonumerico(ZZSaldo), 12)

                        If Val(ZZSaldoUS) > 0 Then : _Item &= RSet(formatonumerico(ZZSaldoUS), 12)
                        End If

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

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try
    End Sub

    Private Function _BuscarInfoIvaComp(ByVal xNroInterno As String) As DataRow
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Paridad, Pago, ISNULL(MarcaDifCambio, 0) As MarcaDifCambio, ISNULL(Rechazado, 0) As Rechazado FROM IvaComp WHERE NroInterno =  '" & xNroInterno & "'")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            tabla.Load(dr)

            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la informacion de la factura en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try
    End Function

    Private Sub _ListarProveedores()
        Dim XClaves As New List(Of Object)
        Dim _Item As String
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
        Dim itemTemplate = "#NUMERO#  #FECHA#  #IMPORTE#  #BANCO#"
        Dim item As String

        Dim WTipoCheque As String = IIf(rbChFisico.Checked, "Tipo2 IN ('02', '2')", "Tipo2 IN ('07', '7')")

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Tiporeg, TipoReg, Estado2, Tipo2, Importe2, Numero2, " & "Fecha2, Banco2, Clave, FechaOrd2 FROM Recibos WHERE " & "TipoReg = '2' AND Estado2 <> 'X' AND " & WTipoCheque & "ORDER BY FechaOrd2, Numero2")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero2"), 6)).Replace("#FECHA#", .Item("Fecha2")).Replace("#IMPORTE#", formatonumerico(.Item("Importe2")).ToString.PadLeft(10, "_")).Replace("#BANCO#", .Item("Banco2"))

                        _ChequesRecibos.Add({item, "1" & .Item("Clave"), IIf(Not IsDBNull(.Item("FechaOrd2")), .Item("FechaOrd2"), "")})

                    Loop
                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return _ChequesRecibos
    End Function

    Private Function _TraerChequesEnRecibosProvisorios() As List(Of Object)
        Dim _ChequesRecibos As New List(Of Object)
        Dim itemTemplate = "#NUMERO#  #FECHA#  #IMPORTE#  #BANCO#"
        Dim item As String
        Dim WTipoCheque As String = IIf(rbChFisico.Checked, "Tipo2 IN ('02', '2')", "Tipo2 IN ('07', '7')")

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Tiporeg, TipoReg, Estado2, Tipo2, Importe2, Numero2, " & "Fecha2, Banco2, Clave, FechaOrd2 FROM RecibosProvi WHERE " & "TipoReg = '2' AND Estado2 = 'P' AND ReciboDefinitivo = '0' AND FechaOrd2 > '20080430' And " & WTipoCheque & "ORDER BY FechaOrd2, Numero2")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero2"), 6)).Replace("#FECHA#", .Item("Fecha2")).Replace("#IMPORTE#", formatonumerico(.Item("Importe2")).ToString.PadLeft(10, "_")).Replace("#BANCO#", .Item("Banco2"))

                        _ChequesRecibos.Add({item, "2" & .Item("Clave"), IIf(Not IsDBNull(.Item("FechaOrd2")), .Item("FechaOrd2"), ""), ceros(.Item("Numero2"), 6), .Item("Fecha2")})

                    Loop
                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return _ChequesRecibos
    End Function

    Private Sub _ListarChequesTerceros()
        Dim XClaves As New List(Of Object)
        Dim _ChequesRecibos As List(Of Object)
        Dim _ChequesRecibosProvisorios As List(Of Object)
        Dim _ChequesTotales As New List(Of Object)

        lstConsulta.Items.Clear()

        ' Traemos los cheques que se encuentran aun disponibles.
        _ChequesRecibos = _TraerChequesEnRecibos()
        _ChequesRecibosProvisorios = _TraerChequesEnRecibosProvisorios()

        ' Agrupamos todos los cheques
        _ChequesTotales.AddRange(_ChequesRecibos)
        _ChequesTotales.AddRange(_ChequesRecibosProvisorios)

        ' Los ordenamos de manera ASC
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
        Dim itemTemplate = "#NUMERO#  #VENCIMIENTO#  #SALDO#  #CLIENTE#"
        Dim item As String
        Dim XClaves As New List(Of Object)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Clave, Numero, Vencimiento1, Saldo, Cliente FROM CtaCte " & "WHERE Tipo = '50' AND Saldo <> 0 AND Cliente <> '' ORDER BY Numero")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try
            lstConsulta.Items.Clear()

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    Do While .Read()

                        item = itemTemplate.Replace("#NUMERO#", ceros(.Item("Numero"), 6)).Replace("#VENCIMIENTO#", .Item("Vencimiento1")).Replace("#SALDO#", formatonumerico(.Item("Saldo"))).Replace("#CLIENTE#", .Item("Cliente"))

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

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try
    End Sub


    Private Sub _ListarSolicitudesFondos()
        Dim XClaves As New List(Of Object)
        Dim _Item As String

        Dim SQLCnslt As String
        Dim Filtro As String = ""

        If Trim(txtProveedor.Text) <> "" Then
            SQLCnslt = "Select Proveedor FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'"
            Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If row IsNot Nothing Then
                Filtro = "AND s.Proveedor = '" & Trim(txtProveedor.Text) & "'"
            Else
                MsgBox("No es Proveedor valido el ingresado")
                Exit Sub
            End If
            
        End If
        'Dim SQLCnslt As String = "SELECT NroSolicitud, Descripcion = iif(Proveedor = '', Cuenta, Proveedor), Tipo, Moneda, Importe FROM SolicitudFondos WHERE Estado = 'AUTORIZO' AND OrdenPago = '' ORDER BY NroSolicitud"

        SQLCnslt = "SELECT s.NroSolicitud, Descripcion= IIF(s.Tipo = 1, 'Pago Prov.',  'Varios'), " _
                                 & "Destino = IIF(s.Proveedor = '',c.Descripcion, p.Nombre), s.Tipo, Moneda, s.Importe " _
                                 & "FROM SolicitudFondos s LEFT JOIN Proveedor p ON s.Proveedor = p.Proveedor " _
                                 & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta " _
                                 & "WHERE s.Estado = 'AUTORIZO' AND s.OrdenPago = '' " & Filtro & " " _
                                 & "ORDER BY s.NroSolicitud"

        Try
            Dim TablaSoli As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If TablaSoli.Rows.Count > 0 Then
                For Each row As DataRow In TablaSoli.Rows

                    With row
                        Dim Tipo As String
                        If Val(.Item("Tipo")) = 1 Then
                            Tipo = "Pago Prov."
                        Else
                            Tipo = "Varios"
                        End If
                        Dim Moneda As String
                        If Val(.Item("moneda")) = 1 Then
                            Moneda = "$"
                        Else
                            Moneda = "U$D"
                        End If
                        _Item = LSet(Trim(.Item("NroSolicitud")), 6) & "   " & Tipo & "   " & Moneda & "  " & formatonumerico(.Item("Importe")) & "    " & Trim(.Item("Destino"))

                        lstConsulta.Items.Add(_Item)

                        XClaves.Add({_Item, .Item("NroSolicitud")})


                    End With

                Next
                _Claves = XClaves

                _HabilitarConsulta()

                _TipoConsulta = 5

            Else
                _InhabilitarConsulta()
            End If
        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        End Try

    End Sub


    Private Sub _ListarCuentasContables()
        Dim XClaves As New List(Of Object)
        Dim _Item As String
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Cuenta, Descripcion FROM Cuenta ORDER BY Cuenta")
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

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsulta.Click
        lstConsulta.Visible = False
        txtConsulta.Visible = False
        lstSeleccion.Visible = True
    End Sub

    Private Function _ObtenerClaveConsulta(ByVal _Item As String) As String
        Dim clave = ""

        Try
            clave = _Claves.FindLast(Function(i) i(0) = _Item)(1)
        Catch ex As System.Exception

        End Try

        Return clave
    End Function

    Private Sub mostrarProveedor(ByVal _Item As String)
        Dim clave = ""
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

    End Sub
    Private Sub _TraerSolicitudFondos(ByVal _Item As String, Optional ByVal indice As Integer = Nothing)
        Dim zzClave As String

        If IsNothing(_Claves) Then
            Exit Sub
        End If

        If _Claves.Count = 0 Then
            Exit Sub
        End If

        zzClave = _ObtenerClaveConsulta(_Item)

        '  ' Comprobamos que no se haya utilizado antes.
        '  If _CtaCteYaUtilizada(zzClave) Then
        '      MsgBox("La Cta Cte indicada ya se encuentra en utilización.", MsgBoxStyle.Information)
        '      Exit Sub
        '  End If

        ' Comprobamos que aun haya lugar para seguir cancelando Facturas.
        If gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(OrDefault(r.Cells("Importe").Value, "")) <> 0) >= 30 Then
            MsgBox("La cantidad de facturas a cancelar supera las " & XMAXFILAS, MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim EsCuenta As String = "N"

        'BUSCAMOS LOS DATOS DE LA SOLICITUD DE FONDOS
        Dim SQLCnslt As String
        SQLCnslt = "SELECT * FROM SolicitudFondos WHERE NroSolicitud = '" & zzClave & "'"
        Dim RowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

        If RowSoli IsNot Nothing Then
            With RowSoli
                NroSoliInterno = zzClave
                If Trim(.Item("Proveedor")) = "" Then
                    'Es Cuenta
                    txtObservaciones.Text = IIf(IsDBNull(.Item("Titulo")), "", .Item("Titulo"))
                    optVarios.Checked = True

                    Dim XRow = 0

                    For i = 0 To XMAXFILAS - 1
                        If gridPagos.Rows(i).Cells(0).Value = "" Then
                            XRow = i
                            Exit For
                        End If
                    Next
                    With gridPagos.Rows(XRow)
                        .Cells(0).Value = ""
                        .Cells(1).Value = ""
                        .Cells(2).Value = ""
                        .Cells(3).Value = NroSoliInterno
                        If RowSoli.Item("Moneda") = 1 Then
                            .Cells(4).Value = formatonumerico(RowSoli.Item("Importe"))
                        Else
                            Dim Calculo As Double = RowSoli.Item("Importe") * traerParidad()
                            .Cells(4).Value = formatonumerico(Calculo)
                        End If
                    End With

                    EsCuenta = "S"

                Else
                    'Es un Proveedor
                    txtProveedor.Text = .Item("Proveedor")

                    txtObservaciones.Text = IIf(IsDBNull(.Item("Titulo")), "", .Item("Titulo"))
                    optAnticipos.Checked = True

                    Dim XRow = 0

                    For i = 0 To XMAXFILAS - 1
                        If gridPagos.Rows(i).Cells(0).Value = "" Then
                            XRow = i
                            Exit For
                        End If
                    Next
                    With gridPagos.Rows(XRow)
                        .Cells(0).Value = ""
                        .Cells(1).Value = ""
                        .Cells(2).Value = ""
                        .Cells(3).Value = NroSoliInterno
                        If RowSoli.Item("Moneda") = 1 Then
                            .Cells(4).Value = formatonumerico(RowSoli.Item("Importe"))
                        Else
                            Dim Calculo As Double = RowSoli.Item("Importe") * traerParidad()
                            .Cells(4).Value = formatonumerico(Calculo)
                        End If
                    End With



                    'gridPagos_Enter(gridPagos, New KeyEventArgs(Keys.Enter))
                End If
            End With
        End If

        If Not IsNothing(indice) Then
            lstConsulta.Items(indice) = ""
        End If

        If txtProveedor.Text <> "" Then
            txtProveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If


        _RecalcularRetenciones()



        Dim ZZPagos As Double = 0
        Dim formaPagos As Double = 0
        Dim total As Double
        Dim WRecalcular = gridPagos.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Val(row.Cells(4).Value) <> 0)

        'Recalculamos las retenciones.
        If WRecalcular And Not _ExisteOrdenDePago(txtOrdenPago.Text) Then
            _RecalcularRetenciones()
        End If

        total = Val(_NormalizarNumero(txtIVA.Text)) + Val(_NormalizarNumero(txtGanancias.Text)) + Val(_NormalizarNumero(txtIBCiudad.Text)) + Val(_NormalizarNumero(txtIngresosBrutos.Text))

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow Then
                row.Cells(4).Value = IIf(Trim(row.Cells(4).Value) <> "", formatonumerico(row.Cells(4).Value), "")
                ZZPagos += Val(_NormalizarNumero(row.Cells(4).Value))
            End If
        Next

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow Then
                row.Cells(5).Value = IIf(Trim(row.Cells(5).Value) <> "", formatonumerico(row.Cells(5).Value), "")
                formaPagos += Val(_NormalizarNumero(row.Cells(5).Value))
            End If
        Next
        txtTotal.Text = formatonumerico(total)
        lblPagos.Text = formatonumerico(ZZPagos)
        lblFormaPagos.Text = formatonumerico(formaPagos + total)
        lblDiferencia.Text = formatonumerico(ZZPagos - formaPagos - total)

        If EsCuenta = "S" Then

            WCuenta(gridPagos.CurrentRow.Index, "1") = OrDefault(RowSoli.Item("Cuenta"), "")

            gridPagos.Focus()

            If gridPagos.CurrentCell.ColumnIndex = 4 Then
                SendKeys.Send("{ENTER}")

            End If
            gridPagos.CurrentCell = gridPagos.CurrentRow.Cells(5)

            If gridPagos.CurrentCell.ColumnIndex = 5 Then
                SendKeys.Send("{ENTER}")
            End If

            'txtCuenta.Text 
            'txtCuenta_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

    End Sub




    Private Sub _TraerCtaCte(ByVal _Item As String, Optional ByVal indice As Integer = Nothing)
        Dim zzClave As String

        If IsNothing(_Claves) Then
            Exit Sub
        End If

        If _Claves.Count = 0 Then
            Exit Sub
        End If

        zzClave = _ObtenerClaveConsulta(_Item)

        ' Comprobamos que no se haya utilizado antes.
        If _CtaCteYaUtilizada(zzClave) Then
            MsgBox("La Cta Cte indicada ya se encuentra en utilización.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Comprobamos que aun haya lugar para seguir cancelando Facturas.
        If gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(OrDefault(r.Cells("Importe").Value, "")) <> 0) >= 30 Then
            MsgBox("La cantidad de facturas a cancelar supera las " & XMAXFILAS, MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Procesamos la Cta Cte seleccionada.
        _ProcesarCtaCte(zzClave)

        _RecalcularRetenciones()

        If Not IsNothing(indice) Then
            lstConsulta.Items(indice) = ""
        End If

        Dim ZZPagos As Double = 0
        Dim formaPagos As Double = 0
        Dim total As Double
        Dim WRecalcular = gridPagos.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Val(row.Cells(4).Value) <> 0)

        ' Recalculamos las retenciones.
        If WRecalcular And Not _ExisteOrdenDePago(txtOrdenPago.Text) Then
            _RecalcularRetenciones()
        End If

        total = Val(_NormalizarNumero(txtIVA.Text)) + Val(_NormalizarNumero(txtGanancias.Text)) + Val(_NormalizarNumero(txtIBCiudad.Text)) + Val(_NormalizarNumero(txtIngresosBrutos.Text))

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow Then
                row.Cells(4).Value = IIf(Trim(row.Cells(4).Value) <> "", formatonumerico(row.Cells(4).Value), "")
                ZZPagos += Val(_NormalizarNumero(row.Cells(4).Value))
            End If
        Next

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow Then
                row.Cells(5).Value = IIf(Trim(row.Cells(5).Value) <> "", formatonumerico(row.Cells(5).Value), "")
                formaPagos += Val(_NormalizarNumero(row.Cells(5).Value))
            End If
        Next
        txtTotal.Text = formatonumerico(total)
        lblPagos.Text = formatonumerico(ZZPagos)
        lblFormaPagos.Text = formatonumerico(formaPagos + total)
        lblDiferencia.Text = formatonumerico(ZZPagos - formaPagos - total)
    End Sub

    Private Function _CtaCteYaUtilizada(ByVal ZZClave As String) As Boolean
        Dim utilizada = False

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                Dim RClave As String = ceros(txtProveedor.Text, 11) & .Cells(1).Value & .Cells(0).Value & .Cells(2).Value & .Cells(3).Value

                If ZZClave = RClave Then

                    utilizada = True

                    Exit For

                End If


            End With
        Next

        Return utilizada
    End Function

    Private Sub _RecalcularNotaDeCreditoDebito(ByVal clave As String, ByVal WSaldo As String, ByVal XRow As Integer)
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT cp.Tipo, cp.NroInterno, cp.Total, cp.Saldo, cp.Impre, cp.Letra, cp.Punto, " & "cp.Numero, cp.Fecha, cp.Clave FROM CtaCtePrv as cp WHERE cp.Proveedor = '" & Trim(txtProveedor.Text) & "' and cp.Clave = '" & clave & "' and cp.Saldo <> 0 ORDER BY cp.OrdFecha DESC")
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

                    Dim XNroInterno, ZZSaldo, ZZSaldoUS, XParidad, XPago, ZZParidadTotal As String

                    XNroInterno = .Item("NroInterno").ToString()
                    ZZSaldo = WSaldo '_NormalizarNumero(.Item("Saldo").ToString())


                    XParidad = 0.0 '.Item("Paridad")
                    XPago = 0 '.Item("Pago").ToString()

                    If Val(XNroInterno) <> 0 Then

                        Dim WIvaComp As DataRow = _BuscarInfoIvaComp(XNroInterno)

                        If Not IsNothing(WIvaComp) Then
                            With WIvaComp
                                XParidad = IIf(IsDBNull(.Item("Paridad")), "0", formatonumerico(.Item("Paridad")))
                                XPago = IIf(IsDBNull(.Item("Pago")), "0", Val(.Item("Pago")))
                            End With
                        End If

                    End If

                    If Val(XPago) = 2 Then

                        If Val(XParidad) <> 0 Then
                            ZZParidadTotal = txtParidad.Text '_TraerCambioDivisa(txtFechaParidad.Text)

                            ZZSaldoUS = (Val(_NormalizarNumero(ZZSaldo)) / Val(XParidad.Replace(",", "."))) * Val(_NormalizarNumero(ZZParidadTotal, 4))

                            Dim diferencia As String = Val(_NormalizarNumero(ZZSaldoUS)) - Val(_NormalizarNumero(ZZSaldo))

                            ' Si hay diferencia se agrega una ND.
                            If Val(diferencia) <> 0 Then

                                With gridPagos.Rows(XRow)

                                    .Cells(4).Value = _NormalizarNumero(diferencia)

                                End With

                            End If

                        End If

                    End If

                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try
    End Sub

    Private Sub _ProcesarCtaCte(ByVal clave As String)
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT cp.Tipo, cp.NroInterno, cp.Total, cp.Saldo, cp.Impre, cp.Letra, cp.Punto, " & "cp.Numero, cp.Fecha, cp.Clave FROM CtaCtePrv as cp WHERE cp.Proveedor = '" & Trim(txtProveedor.Text) & "' and cp.Clave = '" & clave & "' and cp.Saldo <> 0 ORDER BY cp.OrdFecha DESC")
        Dim dr As SqlDataReader
        Dim WMarcaDifCambio = 0
        Dim WMarcaCHR = 0

        'SQLConnector.conexionSql(cn, cm)

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    Dim XTipo, XNroInterno, ZZSaldo, ZZSaldoUS, XLetra, XPunto, XNumero, XParidad, XPago, ZZParidadTotal As String
                    Dim XRow = 0

                    For i = 0 To XMAXFILAS - 1
                        If gridPagos.Rows(i).Cells(0).Value = "" Then
                            XRow = i
                            Exit For
                        End If
                    Next

                    XTipo = .Item("Tipo").ToString()
                    XNroInterno = .Item("NroInterno").ToString()
                    ZZSaldo = _NormalizarNumero(.Item("Saldo").ToString())

                    XLetra = .Item("Letra").ToString()
                    XPunto = .Item("Punto").ToString()
                    XNumero = .Item("Numero").ToString()

                    XParidad = 0.0 '.Item("Paridad")
                    XPago = 0 '.Item("Pago").ToString()

                    If Val(XNroInterno) <> 0 Then

                        Dim WIvaComp As DataRow = _BuscarInfoIvaComp(XNroInterno)

                        If Not IsNothing(WIvaComp) Then
                            With WIvaComp
                                XParidad = IIf(IsDBNull(.Item("Paridad")), "0", formatonumerico(.Item("Paridad"), 4))
                                XPago = IIf(IsDBNull(.Item("Pago")), "0", Val(.Item("Pago")))
                                WMarcaDifCambio = WIvaComp.Item("MarcaDifCambio")
                                WMarcaCHR = WIvaComp.Item("Rechazado")
                            End With
                        End If

                    End If

                    '    If WMarcaDifCambio = 1 Then
                    '        ckNoCalcRetenciones.Checked = True
                    '        ckNoCalcRetenciones_CheckedChanged(Nothing, Nothing)
                    '    End If



                    With gridPagos.Rows(XRow)
                        .Cells(0).Value = XTipo
                        .Cells(1).Value = XLetra
                        .Cells(2).Value = XPunto
                        .Cells(3).Value = XNumero
                        .Cells(4).Value = formatonumerico(ZZSaldo)

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
                        .Cells("MarcaDifCambio").Value = WMarcaDifCambio
                        .Cells("MarcaCHR").Value = WMarcaCHR
                    End With

                    If Val(XPago) = 2 Then

                        If Val(XParidad) <> 0 And WMarcaDifCambio = 0 And ckCalculaDifCambio.Checked Then
                            ZZParidadTotal = txtParidad.Text '_TraerCambioDivisa(txtFechaParidad.Text)

                            ZZSaldoUS = (Val(_NormalizarNumero(ZZSaldo)) / Val(XParidad.Replace(",", "."))) * Val(_NormalizarNumero(ZZParidadTotal, 4))

                            Dim diferencia As String = Val(_NormalizarNumero(ZZSaldoUS)) - Val(_NormalizarNumero(ZZSaldo))

                            ' Si hay diferencia se agrega una ND.
                            If Val(diferencia) <> 0 Then

                                XRow = _ProximaFilaVaciaPagos() 'gridPagos.Rows.Add()

                                With gridPagos.Rows(XRow)

                                    .Cells(0).Value = IIf(Val(diferencia) > 0, "02", "03")
                                    .Cells(1).Value = XLetra
                                    .Cells(2).Value = XPunto
                                    .Cells(3).Value = "99999999"
                                    .Cells(4).Value = _NormalizarNumero(diferencia)
                                    .Cells(5).Value = IIf(Val(diferencia) > 0, "N/D por Diferencia de Cambio ", "N/C por Diferencia de Cambio ") ' "N/D por Diferencia de Cambio "
                                    .Cells("MarcaDifCambio").Value = WMarcaDifCambio
                                    .Cells("MarcaCHR").Value = WMarcaCHR

                                End With

                            End If

                        End If

                    End If

                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try
    End Sub

    Private Sub _TraerChequeDeTercero(ByVal _Item As String, Optional ByVal indice As Integer = Nothing)
        Dim ZZClave As String

        ' Comprobamos que aun haya lugar para seguir cancelando Facturas.
        If gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(OrDefault(r.Cells("Importe").Value, "")) <> 0) >= 30 Then
            MsgBox("La cantidad de facturas a cancelar supera las " & XMAXFILAS, MsgBoxStyle.Information)
            Exit Sub
        End If

        If _Claves.Count = 0 Then
            Exit Sub
        End If

        ZZClave = _ObtenerClaveConsulta(_Item)

        If ZZClave = "" Then
            Exit Sub
        End If

        If _ChequeYaUtilizado(ZZClave) Then
            Exit Sub
        End If

        _ProcesarChequeTercero(ZZClave, indice)

        sumarImportes()
    End Sub

    Private Function _ChequeYaUtilizado(ByVal ZZClave As String) As Boolean
        Dim utilizada = False

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            With row
                Dim RClave As String = .Cells(6).Value

                If ZZClave = RClave Then

                    utilizada = True

                    Exit For

                End If

            End With
        Next

        Return utilizada
    End Function

    Private Sub _ProcesarChequeTercero(ByVal clave As String, Optional ByVal indice As Integer = Nothing)
        Dim ZSql As String = "SELECT Numero2, Fecha2, Banco2, Importe2, Cuit FROM #TABLA# WHERE Clave = '" & Mid(clave, 2, 8) & "'"
        Dim Tabla = "Recibos"
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()
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

                    Dim XTipo, XNumero, XFecha, XBanco, XImporte, XCuit, ZClave As String

                    Dim XRow = Nothing

                    For Each row As DataGridViewRow In gridFormaPagos.Rows
                        If IsNothing(row.Cells(0).Value) Or row.Cells(0).Value = "" Then
                            XRow = row.Index
                            Exit For
                        End If
                    Next

                    If IsNothing(XRow) Then
                        XRow = _ProximaFilaVaciaFormaPagos() 'gridFormaPagos.Rows.Add
                    End If

                    ZClave = clave
                    XTipo = IIf(rbChFisico.Checked, "3", "7")
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
                        .Cells(6).Value = ZClave
                        .Cells(7).Value = XCuit

                        .Cells(0).ReadOnly = True
                        .Cells(1).ReadOnly = True
                        .Cells(2).ReadOnly = True
                        .Cells(3).ReadOnly = True
                        .Cells(4).ReadOnly = True
                        .Cells(5).ReadOnly = True
                        .Cells(6).ReadOnly = True
                        .Cells(7).ReadOnly = True
                    End With


                    If Not IsNothing(indice) Then
                        lstConsulta.Items(indice) = ""
                    End If


                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try
    End Sub

    Private Sub _LimpiarGrillas()

        gridPagos.Rows.Clear()
        gridFormaPagos.Rows.Clear()

        If gridPagos.ColumnCount > 0 And gridFormaPagos.ColumnCount > 0 Then
            For i = 1 To XMAXFILAS

                gridPagos.Rows.Add("", "", "", "", "", "", "")
                gridFormaPagos.Rows.Add("", "", "", "", "", "", "", "", "")

            Next
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        'Cleanner.clean(Me)
        Dim WParidad = txtParidad.Text
        Dim WFechaParidad = txtFechaParidad.Text

        For Each _c As TextBox In Panel2.Controls.OfType(Of TextBox)()
            _c.Text = ""
        Next

        For Each _c As MaskedTextBox In Panel2.Controls.OfType(Of MaskedTextBox)()
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
        txtFechaParidad.Text = WFechaParidad 'txtFecha.Text
        ckCalculaDifCambio.Checked = False
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

        txtParidad.Text = WParidad 'traerParidad()

        txtProveedor.Focus()
        WTipoProv = ""
        WTipoIva = ""
        WTipoIb = ""
        WTipoIbCaba = ""
        WPorceIb = ""
        WPorceIbCaba = ""
        txtFechaAux.Visible = False

        optCtaCte.Checked = True

        ckNoCalcRetenciones.Checked = False

        btnEnviarAviso.Enabled = False
        btnActualizarCarpetas.Visible = False

        txtOrdenPago.Enabled = True

        txtFormasPagosAceptadas.Text = ""
        txtFormasPagosAceptadas.Visible = False

        btn_ConsultaSoliFondos.Visible = False

        'CAMBIAMOS EL SOLO LECTURA A FALSE 
        'POR SI SOLICITUD DE FONDOS LO DESHABILITO
        txtProveedor.ReadOnly = False

    End Sub

    Private Function traerParidad() As String
        Return traerParidad(txtFechaParidad.Text)
    End Function

    Private Function traerParidad(ByVal ZZfecha As String, Optional ByVal Essoli As Boolean = False) As String
        ZZfecha = _Normalizarfecha(ZZfecha)
        Dim ZZParidad As String = "0"
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand("SELECT Cambio, CambioDivisa FROM Cambios WHERE Fecha = '" & Trim(ZZfecha) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            If ZZfecha <> "" Then
                dr = cm.ExecuteReader()
                With dr
                    If .HasRows Then
                        .Read()

                        If Essoli = False Then
                            If Not IsDBNull(.Item("CambioDivisa")) Then
                                ZZParidad = _NormalizarNumero(.Item("CambioDivisa").ToString(), 4)
                            End If

                        Else
                            Dim SQLCnslt As String = "SELECT TipoDolar FROM SOlicitudFondos WHERE NroSolicitud = '" & NroSoliInterno & "'"
                            Dim RowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                            If RowSoli IsNot Nothing Then
                                If IIf(IsDBNull(RowSoli.Item("TipoDolar")), 0, RowSoli.Item("TipoDolar")) = 2 Then
                                    ZZParidad = _NormalizarNumero(.Item("Cambio").ToString(), 4)
                                Else
                                    ZZParidad = _NormalizarNumero(.Item("CambioDivisa").ToString(), 4)
                                End If

                            End If
                        End If
                       

                    Else
                        If Not GenerarPDF Then MsgBox("No hay Paridad cargada para la fecha " & ZZfecha, MsgBoxStyle.Critical)
                    End If
                End With
            End If

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la paridad en la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try

        Return ZZParidad
    End Function

    Private Function _TraerNumeroCertificado(ByVal Codigo) As Integer
        Dim WNumero As Double
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT MAX(Numero) as Numero FROM Numero WHERE Codigo = '" & Val(Codigo) & "'")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing

        SQLConnector.conexionSql(cn, cm)

        Try
            trans = cn.BeginTransaction

            cm.Transaction = trans
            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                WNumero = dr.Item("Numero")
            Else
                If Not IsNothing(trans) Then
                    trans.Rollback()
                End If
                Throw New System.Exception("No se pudo recuperar el Número de Certificado correspondiente al codigo: " & Codigo)
            End If

            dr.Close()

            cm.CommandText = "UPDATE Numero SET Numero = Numero + 1 WHERE Codigo = '" & Val(Codigo) & "'"
            cm.ExecuteNonQuery()

            trans.Commit()

        Catch ex As System.Exception
            If Not IsNothing(trans) Then
                trans.Rollback()
            End If
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            cn.Close()

        End Try

        Return WNumero + 1
    End Function

    Private Function _ExisteCtaCtePrv(ByVal Clave) As Boolean
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Clave FROM CtaCtePrv WHERE Clave = '" & Clave & "'")
        Dim dr As SqlDataReader

        Try
            SQLConnector.conexionSql(cn, cm)
            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try

        Return False
    End Function

    Private Function _SiguienteNumeroDeOrdenPago() As Integer
        Dim siguiente As Double
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 p.Orden FROM Pagos p ORDER BY p.Orden desc")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            'SQLConnector.conexionSql(cn, cm)

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                siguiente = IIf(IsDBNull(dr.Item("Orden")), 0, Val(dr.Item("Orden")))

                If siguiente = 0 Then
                    Throw New System.Exception("No se pudo consultar correctamente el siguiente numero de Orden de Pago disponible.")
                Else
                    siguiente += 1
                End If
            Else
                Throw New System.Exception("No se pudo consultar correctamente el siguiente numero de Orden de Pago disponible.")
            End If

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo consultar correctamente el siguiente numero de Orden de Pago disponible.")
        Finally


            cn.Close()



        End Try

        Return siguiente
    End Function

    Private Sub btnAgregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregar.Click
        Dim XParidad, WEntra
        Dim XOrden, XRenglon, XProveedor, XFecha, XFechaOrd, XImporte, XRetencion, XRetotra, XRetIbCiudad, XRetIva, XObservaciones, XCuenta, XTipoOrd, XTipo1, XLetra1, XPunto1, XNumero1, XImporte1, XObservaciones2, XImpoNeto, XTipo2, ZZNumero2, ZZFecha2, XFechaOrd2, ZZBanco2, ZZImporte2, XEmpresa, ZZClave, XRetganancias, XConcepto, XConsecionaria, XImpolist, XCuit, ImporteCheque, NumeroCheque, FechaCheque, BancoCheque, WLetra, WTipo, WPunto, WNumero, ZSql, XClaveCtaprv, XTipoRecibo, XClaveRecibo, XClaveCtaCte
        Dim _banco As Banco
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("")

        Dim WEsAnticipo = False

        If Not validarDatos() Then
            Exit Sub
        End If

        Dim WOrdPago As Integer
        Try
            WOrdPago = _SiguienteNumeroDeOrdenPago() 'DAOPagos.siguienteNumeroDeOrden()
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        txtOrdenPago.Text = ceros(WOrdPago, 6)

        XNeto = _CalcularSaldoBaseRetencionesGanancias()

        ' Damos de alta los numero de Certificados.
        Try
            WCertificadoGan = 0
            WCertificadoIb = 0
            WCertificadoIbCiudad = 0
            WCertificadoIVA = 0

            If Val(txtGanancias.Text) <> 0 Then
                WCertificadoGan = _TraerNumeroCertificado("91")
            End If

            If Val(txtIngresosBrutos.Text) <> 0 Then
                WCertificadoIb = _TraerNumeroCertificado("92")
            End If

            If Val(txtIBCiudad.Text) <> 0 Then
                WCertificadoIbCiudad = _TraerNumeroCertificado("94")
            End If

            If Val(txtIVA.Text) <> 0 Then
                WCertificadoIVA = _TraerNumeroCertificado("93")
            End If

        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Try
            crearNotasCreditoDebito()
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        XOrden = txtOrdenPago.Text
        XProveedor = txtProveedor.Text
        XFecha = txtFecha.Text
        XFechaOrd = ordenaFecha(XFecha)
        XImporte = _NormalizarNumero(lblFormaPagos.Text)
        XRetencion = _NormalizarNumero(txtGanancias.Text)
        XRetotra = _NormalizarNumero(txtIngresosBrutos.Text)
        XRetIbCiudad = _NormalizarNumero(txtIBCiudad.Text)
        XRetIva = _NormalizarNumero(txtIVA.Text)
        XObservaciones = Trim(txtObservaciones.Text)
        XParidad = formatonumerico(txtParidad.Text, 4)


        ' Damos de alta los Pagos.
        Dim WRenglon = 0
        Dim row As DataGridViewRow
        'For Each row As DataGridViewRow In gridPagos.Rows
        For i = 0 To XMAXFILAS - 1

            row = gridPagos.Rows(i)

            If Val(row.Cells(4).Value) <> 0 Then
                With row
                    WRenglon += 1

                    XRenglon = ceros(WRenglon, 2)

                    XCuenta = ""
                    XTipoOrd = ""
                    XTiporeg = "1"

                    If optCtaCte.Checked Then
                        XTipoOrd = "1"
                    End If
                    If optAnticipos.Checked Then
                        XTipoOrd = "2"

                        WEsAnticipo = True

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

                    If Val(.Cells(0).Value) = 0 And Trim(.Cells(1).Value) = "" And Val(.Cells(2).Value) = 0 And Val(.Cells(3).Value) = 0 Then
                        XCuenta = WCuenta(i, 1)
                    End If

                    XTiporeg = "1"

                    XTipo1 = .Cells(0).Value
                    XLetra1 = .Cells(1).Value
                    XPunto1 = .Cells(2).Value
                    XNumero1 = ceros(.Cells(3).Value, 8)
                    XImporte1 = _NormalizarNumero(.Cells(4).Value)
                    XObservaciones2 = leeizquierda(.Cells(5).Value, 30)
                    XImpoNeto = Val(.Cells(6).Value)

                    XTipo2 = ""
                    ZZNumero2 = ""
                    ZZFecha2 = ""
                    XFechaOrd2 = ""
                    If optTransferencias.Checked Then
                        ZZBanco2 = txtBanco.Text
                    Else
                        ZZBanco2 = ""
                    End If
                    ZZImporte2 = 0
                    XEmpresa = "1"
                    ZZClave = XOrden + XRenglon
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
                    ZSql &= " VALUES ('" & ZZClave & "', '" & XOrden & "', '" & XRenglon & "', '" & XProveedor & "',"
                    ZSql &= " '" & XFecha & "', '" & XFechaOrd & "', '" & XTipoOrd & "', " & Str(XRetganancias) & ", " & Str(XRetIva) & ","
                    ZSql &= " " & Str(XRetotra) & ", " & Str(XRetencion) & ", '" & XTiporeg & "', '" & XTipo1 & "', '" & XLetra1 & "',"
                    ZSql &= " '" & XPunto1 & "', '" & XNumero1 & "', " & Str(XImporte1) & ", '" & XTipo2 & "', '" & ZZNumero2 & "',"
                    ZSql &= " '" & ZZFecha2 & "', '" & ZZBanco2 & "', " & ZZImporte2 & ", '" & XObservaciones2 & "', '" & XEmpresa & "',"
                    ZSql &= " '" & XConcepto & "', '" & XObservaciones & "', " & Str(XImporte) & ", '" & XFechaOrd2 & "', '" & XConsecionaria & "',"
                    ZSql &= " " & XImpolist & ", '" & XCuenta & "', '" & formatonumerico(XImpoNeto) & "', " & Str$(XRetIbCiudad) & ", '', '', '', '', '', '', " & XParidad & ")"


                    SQLConnector.conexionSql(cn, cm)

                    Try
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As System.Exception
                        MsgBox("Hubo un problema al querer grabar la Orden de Pago en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                    ' Actualizamos la Cta Cte del Proveedor.
                    XClaveCtaprv = txtProveedor.Text & XLetra1 & XTipo1 & XPunto1 & XNumero1

                    ZSql = "UPDATE CtaCtePrv SET Saldo = Saldo - " & Str(XImporte1) & " WHERE Clave = '" & XClaveCtaprv & "'"

                    Try
                        cn.Open()
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As System.Exception
                        MsgBox("Hubo un problema al querer actualizar la Cuenta Corriente en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
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

                    XRenglon = ceros(WRenglon, 2)

                    XCuenta = ""
                    XTipoOrd = ""
                    XTiporeg = ""

                    If optCtaCte.Checked Then
                        XTipoOrd = "1"
                    End If
                    If optAnticipos.Checked Then
                        XTipoOrd = "2"
                        WEsAnticipo = True
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

                    XTiporeg = "2"

                    XTipo1 = ""
                    XLetra1 = ""
                    XPunto1 = ""
                    XNumero1 = ""
                    XImporte1 = 0
                    XImpoNeto = 0

                    XTipo2 = ceros(.Cells(0).Value, 2)
                    ZZNumero2 = ceros(.Cells(1).Value, 8)
                    ZZFecha2 = .Cells(2).Value
                    XFechaOrd2 = ordenaFecha(ZZFecha2)
                    ZZBanco2 = .Cells(3).Value
                    XObservaciones2 = .Cells(4).Value
                    ZZImporte2 = _NormalizarNumero(.Cells(5).Value)
                    XClaveRecibo = Mid(.Cells(6).Value, 2, 10)
                    XClaveCtaCte = .Cells(6).Value
                    XTipoRecibo = Microsoft.VisualBasic.Left(.Cells(6).Value, 1)
                    XCuit = .Cells(7).Value
                    Dim ZClaveRecibo = Microsoft.VisualBasic.Right$(XClaveRecibo, 8)

                    XEmpresa = "1"
                    ZZClave = XOrden + XRenglon
                    XRetganancias = 0
                    XConcepto = ""
                    XConsecionaria = ""
                    XImpolist = 0

                    If Val(XTipo2) = 6 Then
                        XCuenta = WCuenta(i, 2)
                    End If

                    If Val(XTipo2) = 2 Then
                        XTipo2 = ceros(XTipo2, 2)
                    End If

                    ZSql = "INSERT INTO Pagos "
                    ZSql &= "(Clave, Orden, Renglon, Proveedor, Fecha, Fechaord, Tipoord,"
                    ZSql &= " RetGanancias, RetIva, RetOtra, Retencion, Tiporeg, Tipo1,"
                    ZSql &= " Letra1, Punto1, Numero1, Importe1, Tipo2, Numero2, Fecha2,"
                    ZSql &= " Banco2, Importe2, Observaciones2, Empresa, Concepto, Observaciones,"
                    ZSql &= " Importe, Fechaord2, Consecionaria, Impolist, Cuenta, ImpoNeto,"
                    ZSql &= " RetIbCiudad, ClaveRecibo, ImporteCheque, NumeroCheque, FechaCheque, BancoCheque, Cuit, Paridad)"
                    ZSql &= " VALUES ('" & ZZClave & "', '" & XOrden & "', '" & XRenglon & "', '" & XProveedor & "',"
                    ZSql &= " '" & XFecha & "', '" & XFechaOrd & "', '" & XTipoOrd & "', " & Str(XRetganancias) & ", " & Str(XRetIva) & ","
                    ZSql &= " " & Str(XRetotra) & ", " & Str(XRetencion) & ", '" & XTiporeg & "', '" & XTipo1 & "', '" & XLetra1 & "',"
                    ZSql &= " '" & XPunto1 & "', '" & XNumero1 & "', " & Str(XImporte1) & ", '" & XTipo2 & "', '" & ZZNumero2 & "',"
                    ZSql &= " '" & ZZFecha2 & "', '" & ZZBanco2 & "', " & Str(ZZImporte2) & ", '" & XObservaciones2 & "', '" & XEmpresa & "',"
                    ZSql &= " '" & XConcepto & "', '" & XObservaciones & "', " & Str(XImporte) & ", '" & XFechaOrd2 & "', '" & XConsecionaria & "',"
                    ZSql &= " " & Str(XImpolist) & ", '" & XCuenta & "', " & Str(XImpoNeto) & ", " & Str(XRetIbCiudad) & ", '" & ZClaveRecibo & "', '', '', '', '', '', " & XParidad & ")"


                    Try
                        cn.Open()
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As System.Exception
                        MsgBox("Hubo un problema al querer grabar la Forma de Pago en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                    ImporteCheque = ZZImporte2
                    NumeroCheque = ZZNumero2
                    FechaCheque = ZZFecha2
                    BancoCheque = XObservaciones2


                    ZSql = ""
                    ZSql = ZSql + "UPDATE Pagos SET "
                    ZSql = ZSql + " ClaveRecibo = " + "'" + ZClaveRecibo + "',"
                    ZSql = ZSql + " RetIbCiudad = " + "'" + Str(XRetIbCiudad) + "',"
                    ZSql = ZSql + " ImporteCheque = " + "'" + Str(ImporteCheque) + "',"
                    ZSql = ZSql + " NumeroCheque = " + "'" + NumeroCheque + "',"
                    ZSql = ZSql + " FechaCheque = " + "'" + FechaCheque + "',"
                    ZSql = ZSql + " BancoCheque = " + "'" + BancoCheque + "',"
                    ZSql = ZSql + " Cuit = " + "'" + XCuit + "'"
                    ZSql = ZSql + " Where Clave = " + "'" + ZZClave + "'"

                    Try
                        cn.Open()
                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    Catch ex As System.Exception
                        MsgBox("Hubo un problema al querer Actualizar los datos de Cheques en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    Finally
                        cn.Close()
                    End Try

                    If Val(XTipo2) = 3 Or Val(XTipo2) = 7 Then

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

                        Catch ex As System.Exception
                            MsgBox("Hubo un problema al querer actualizar el estado del Cheque en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
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
                        ZSql = ZSql + "Saldo = " + "'" + Str(XSaldo) + "',"
                        ZSql = ZSql + "SaldoUs = " + "'" + Str(XSaldoUs) + "',"
                        ZSql = ZSql + "Estado2 = " + "'" + XEstado + "',"
                        ZSql = ZSql + "WDate = " + "'" + XDate + "'"
                        ZSql = ZSql + " Where Clave = " + "'" + XClaveCtaCte + "'"


                        Try

                            cn.Open()
                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                        Catch ex As System.Exception
                            MsgBox("Hubo un problema al querer actualizar la Cuenta corriente en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
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
            WNumero = ceros(txtOrdenPago.Text, 8)
            XProveedor = txtProveedor.Text

            XFecha = txtFecha.Text
            XEstado = "1"
            XVencimiento = "  /  /    "
            XVencimiento1 = "  /  /    "
            XTotal = Val(formatonumerico((lblFormaPagos.Text)))
            XTotal = Val(XTotal * -1)
            XSaldo = 0
            XOrdFecha = ordenaFecha(XFecha)
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
                ZSql &= " Total = " & Str(XTotal) & ","
                ZSql &= " Saldo = " & Str(XSaldo) & ","
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
                ZSql &= "" & Str(XTotal) & ","
                ZSql &= "" & Str(XSaldo) & ","
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

            Catch ex As System.Exception
                MsgBox("Hubo un problema al querer grabar la informacion en la Cta Cte la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            Finally
                cn.Close()
            End Try

        End If

        If optAnticipos.Checked Then

            WLetra = "A"
            WTipo = "05"
            WPunto = "0000"
            WNumero = ceros(txtOrdenPago.Text, 8)
            XProveedor = txtProveedor.Text

            XFecha = txtFecha.Text
            XEstado = "1"
            XVencimiento = "  /  /    "
            XVencimiento1 = "  /  /    "
            XTotal = Val(formatonumerico(lblFormaPagos.Text))
            XTotal = Val(XTotal * -1)
            XSaldo = XTotal
            XOrdFecha = ordenaFecha(XFecha)
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
                ZSql &= " Total = " & Str(XTotal) & ","
                ZSql &= " Saldo = " & Str(XSaldo) & ","
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
                ZSql &= "" & Str(XTotal) & ","
                ZSql &= "" & Str(XSaldo) & ","
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

            Catch ex As System.Exception
                MsgBox("Hubo un problema al querer grabar la informacion en la Cta Cte la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            Finally
                cn.Close()
            End Try

        End If

        ' Tipo6?

        ' Actualizo retenciones en caso de existir
        Dim _Clave = Microsoft.VisualBasic.Right(txtFecha.Text, 2) & Mid(txtFecha.Text, 4, 2) & txtProveedor.Text
        'XNeto = 0
        ZSql = ""
        ZSql &= "UPDATE Retencion SET Neto = Neto + " & Str(XNeto) & ", Retenido = Retenido + " & Str(XRetencion) & " WHERE Clave = '" & _Clave & "'"

        Try

            cn.Open()
            cm.CommandText = ZSql
            cm.ExecuteNonQuery()

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer Actualizar la información de Retención en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
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

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer Actualizar la informacion de la Orden de Pago en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        Dim _Empresas = Empresas 'As New List(Of String) From {}

        If _Empresas.Count > 0 Then
            For Ciclo = 1 To 10

                If Val(_Carpetas(Ciclo)) <> 0 Then

                    WEntra = "N"

                    Dim dr As SqlDataReader
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
                            dr = cm.ExecuteReader()

                            If dr.HasRows Then
                                dr.Read()
                                ZProveedor = dr.Item("Proveedor")
                                WEntra = "S"
                            End If

                        Catch ex As System.Exception
                            MsgBox("Hubo un problema al querer la información de la Orden de Compra en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
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

                                Catch ex As System.Exception
                                    MsgBox("Hubo un problema al querer Actualizar la información de la Orden de Pago en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
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

        Try

            cn.Open()
            cm.CommandText = "SELECT * FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'"
            Dim _TipoProv, _TipoIva, _TipoIb, _TipoIbCaba, _PorceIb, _PorceIbCaba As String

            Using dr As SqlDataReader = cm.ExecuteReader

                With dr
                    If .HasRows Then
                        .Read()
                        _TipoProv = OrDefault(.Item("Tipo"), "")
                        _TipoIva = OrDefault(.Item("Iva"), "")
                        _TipoIb = OrDefault(.Item("CodIb"), "")
                        _TipoIbCaba = OrDefault(.Item("CodIbCaba"), "")
                        _PorceIb = OrDefault(.Item("PorceIb"), "0")
                        _PorceIbCaba = OrDefault(.Item("PorceIbCaba"), "0")
                    End If
                End With

            End Using

            Dim WTipoAvisoMailOp = "0"

            If WEsAnticipo Then

                Select txtProveedor.Text
                    Case "10167878480", "10000000100", "10071081483", "10069345023", "10066352912", "10023969933", "10014123562"
                        If MsgBox("Se detectó que está grabando un Anticipo. ¿Desea que se envíe la OP por Mail?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            btnEnviarAviso_Click(Nothing, Nothing)
                            WTipoAvisoMailOp = "1"
                        End If
                End Select

            End If

            ' Actualizamos los numero de Certificados de Retenciones y datos historicos.
            ZSql = ""
            ZSql &= "UPDATE Pagos SET "
            ZSql &= " CertificadoGan = " & "" & Val(WCertificadoGan) & ","
            ZSql &= " CertificadoIb = " & "" & Val(WCertificadoIb) & ","
            ZSql &= " CertificadoIbCiudad = " & "" & Val(WCertificadoIbCiudad) & ","
            ZSql &= " CertificadoIva = " & "" & Val(WCertificadoIVA) & ","
            ZSql &= " TipoProv = " & "'" & _TipoProv & "',"
            ZSql &= " TipoIva = " & "'" & _TipoIva & "',"
            ZSql &= " TipoIB = " & "'" & _TipoIb & "',"
            ZSql &= " TipoIBCaba = " & "'" & _TipoIbCaba & "',"
            ZSql &= " PorceIB = " & "" & formatonumerico(_PorceIb) & ","
            ZSql &= " PorceIBCaba = " & "" & formatonumerico(_PorceIbCaba) & ","
            ZSql &= " AvisoMailOp = " & "'" & WTipoAvisoMailOp & "',"
            ZSql &= " RetencionesRegistradas = '1'"
            ZSql &= " Where Orden = " & "'" & txtOrdenPago.Text & "'"


            cm.CommandText = ZSql
            cm.ExecuteNonQuery()


        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer Actualizar los datos de certificados de Retenciones de la Orden de Pagos en la Base de Datos." & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        Finally
            cn.Close()
        End Try

        Try
            If btn_ConsultaSoliFondos.Visible = True Then
                'SI ESTA VISIBLE EL BOTON DE SOLICITUD FONDOS
                'ACTUALIZAMOS LA TABLA CON EL NUMERO DE ORDEN DE PAGO
                Dim SQLCnlst As String = "UPDATE SolicitudFondos SET OrdenPago = '" & Trim(txtOrdenPago.Text) & "' WHERE NroSolicitud = '" & NroSoliInterno & "'"
                ExecuteNonQueries("SurfactanSa", {SQLCnlst})


                Dim WFormula As String = "{SolicitudFondos.NroSolicitud} = " & NroSoliInterno & ""

                With New VistaPrevia
                    .Reporte = New Reporte_SolicitudFondos
                    .Formula = WFormula
                    '.Formula = "{SolicitudFondos.NroSolicitud} > " & (NRO_SOLICITUD - 1) & " AND {SolicitudFondos.NroSolicitud} < " & (NRO_SOLICITUD + 1) & ""

                    .Imprimir()
                End With

            End If
        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer Actualizar los datos en la tabla Solicitud de Fondos o al imprimir la solicitud", MsgBoxStyle.Critical)
            Exit Sub
        End Try
        




        'MsgBox("El número de orden asignado es: " & WOrdPago)

        txtOrdenPago.Text = WOrdPago

        If txtProveedor.Text <> "" Then

            Dim WEmailOp_ As DataRow = GetSingle("SELECT MailOp FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'")

            Dim Wpasa As Boolean = False

            If WEmailOp_ IsNot Nothing Then
                Wpasa = Trim(OrDefault(WEmailOp_(0), "")) <> ""
            End If

            If Not Wpasa Then
                MsgBox("El Proveedor (" & txtProveedor.Text & ")  " & txtRazonSocial.Text.ToUpper.Trim & ", no tiene cargado un mail donde enviar el Aviso de OP.", MsgBoxStyle.Information)
            ElseIf Not FormatoCorreoValido(WEmailOp_(0)) Then
                MsgBox("El Proveedor (" & txtProveedor.Text & ")  " & txtRazonSocial.Text.ToUpper.Trim & ", no tiene cargado un mail con FORMATO VALIDO donde enviar el Aviso de OP.", MsgBoxStyle.Information)
            End If

        End If

        txtOrdenPago_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        ' Imprimimos los comprobantes pertinentes.
        btnImprimir.PerformClick()

        'SOLO ENVIAMOS MAIL SI ES ANTICIPO Y DESPACHANTE DE ADUANA Y EL USUARIO RESPONDE QUE SI
        ' btnEnviarAviso_Click(Nothing, Nothing)

        ' Limpiamos pantalla.
        btnLimpiar.PerformClick()
    End Sub

    Public Shared Function FormatoCorreoValido(ByVal correo As String) As Boolean

        correo = Trim(correo)
        Dim Listmails As New List(Of String)

        'EN CASO DE TENER PUNTO Y COMO LOS SEPARAMOS PARA COMPROBARLOS POR SEPARADO
        If correo.Contains(";") Then
            Listmails.AddRange(Split(correo, ";"))
        End If

        If Listmails.Count > 0 Then
            'ESTE CAMINO ES SI SON VARIOS MAILS
            For Each mail As String In Listmails

                Dim MailInpeccionar = Trim(mail)
                'POR CADA UNO COMPROBAMOS SI TIENEN LOS SIGNOS "<" Y ">" Y EXTRAEMOS LE MAIL DE ADENTRO
                If MailInpeccionar.Contains("<") And MailInpeccionar.Contains(">") Then
                    Dim Inicio As String = -1
                    Dim Final As String = -1
                    For i = 0 To Len(MailInpeccionar) - 1
                        If MailInpeccionar.Chars(i) = "<" Then
                            Inicio = i + 1
                        End If
                        If MailInpeccionar.Chars(i) = ">" Then
                            Final = i
                        End If
                    Next

                    If Inicio <> -1 And Final <> -1 Then
                        MailInpeccionar = MailInpeccionar.Substring(Inicio, (Final - Inicio))
                    End If

                End If



                '
                ' La siguiente expresión regular permite direcciones del siguiente estilo:
                '   sop+surfac@mail.com
                '   sop.surfac@mail.com.ar
                '   sop_surfac@mail.com
                '   sopsurfac@mail.com.ar
                ' Exige que lo posterior al @ tenga el formato mail.com o mail.com.ar
                '   Ej: sop+surfac@mail.com
                '
                '   Toma como invalido lo siguiente: soporte@surfactan
                '

                Dim sregVarios As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                Dim rgxVarios As Regex = New Regex(sregVarios)

                If rgxVarios.IsMatch(MailInpeccionar) = False Then
                    Dim sreg2 As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                    Dim rgx2 As Regex = New Regex(sreg2)
                    If rgx2.IsMatch(MailInpeccionar) = False Then
                        Return False
                    End If

                End If
            Next

            Return True

        End If


        'ESTE CAMINO ES SI NO SON VARIOS MAILS


        If correo.Contains("<") And correo.Contains(">") Then
            Dim Inicio As Integer = -1
            Dim Final As Integer = -1
            For i = 0 To Len(correo) - 1
                If correo.Chars(i) = "<" Then
                    Inicio = i + 1
                End If
                If correo.Chars(i) = ">" Then
                    Final = i
                End If
            Next

            If Inicio <> -1 And Final <> -1 Then
                correo = correo.Substring(Inicio, (Final - Inicio))
            End If

        End If


        '
        ' La siguiente expresión regular permite direcciones del siguiente estilo:
        '   sop+surfac@mail.com
        '   sop.surfac@mail.com.ar
        '   sop_surfac@mail.com
        '   sopsurfac@mail.com.ar
        ' Exige que lo posterior al @ tenga el formato mail.com o mail.com.ar
        '   Ej: sop+surfac@mail.com
        '
        '   Toma como invalido lo siguiente: soporte@surfactan
        '


        Dim sreg As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
        Dim rgx As Regex = New Regex(sreg)

        If Not rgx.IsMatch(correo) Then
            Dim sreg2 As String = "^[a-zA-Z0-9.+_]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)?\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
            Dim rgx2 As Regex = New Regex(sreg2)
            Return rgx2.IsMatch(correo)    
        End If

        Return rgx.IsMatch(correo)

    End Function

    Private Sub crearNotasCreditoDebito()
        Dim interno As String
        Dim XProveedor, XTipo, XLetra, XPunto, XNumero, XFecha, ZZVencimiento, ZZVencimiento1, XPeriodo, XImpoNeto, XIva21, XIva5, XIva27, XIb, XExento, ZZImpre
        Dim WTipoDife, WLetraDife, WPuntoDife, WNumeroDife, WNetoDife, WIvaDife
        Dim ZZOrdFecha, XContado, XEmpresa, XNetolist, XExentolist, XParidad, XPAgo, ZSqlIvaComp, ZSqlImputac, XParamIvaComp, XParamImputac
        Dim ZZClave, XTipomovi, XTipocomp, XLetracomp, XPuntocomp, XNrocomp, XRenglon, XObservaciones, XCuenta, XDebito, XCredito, XFechaOrd, XTitulo, XDebitolist, XCreditolist, RenglonDife, XSaldolist, Xlista, XAcumulado
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing


        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow And Val(row.Cells(3).Value) = 99999999 Then

                ' Buscamos el proximo numero interno.
                Try
                    interno = DAOCompras.siguienteNumeroDeInterno()
                Catch ex As System.Exception
                    Throw New System.Exception("No se pudo obtener el próximo numero interno para la nota de Crédito/Débito")
                End Try

                With row
                    WTipoDife = ceros(.Cells(0).Value, 2)
                    WLetraDife = .Cells(1).Value
                    WPuntoDife = ceros(.Cells(2).Value, 4)
                    row.Cells(3).Value = ceros(interno, 8)
                    WNumeroDife = ceros(interno, 8)
                    interno = ceros(interno, 6)

                    If UCase(Trim(WLetraDife)) = "A" Then
                        WNetoDife = Val(formatonumerico(.Cells(4).Value)) / 1.21
                        WIvaDife = Val(formatonumerico(.Cells(4).Value)) - Val(WNetoDife)
                    Else
                        WNetoDife = Val(formatonumerico(.Cells(4).Value))
                        WIvaDife = 0.0
                    End If

                End With

                ' Grabamos la Factura.

                XProveedor = txtProveedor.Text
                XTipo = WTipoDife
                XLetra = WLetraDife
                XPunto = WPuntoDife
                XNumero = WNumeroDife
                XFecha = txtFecha.Text
                ZZVencimiento = XFecha
                ZZVencimiento1 = XFecha
                XPeriodo = XFecha
                XImpoNeto = Val(formatonumerico(Val(WNetoDife)))
                XIva21 = Val(formatonumerico(Val(WIvaDife)))
                XIva5 = 0
                XIva27 = 0
                XIb = 0
                XExento = 0

                Select Case Val(WTipoDife)
                    Case 1
                        ZZImpre = "FC"
                    Case 2
                        ZZImpre = "ND"
                    Case 3
                        ZZImpre = "NC"
                    Case Else
                        ZZImpre = ""
                End Select

                ZZOrdFecha = ordenaFecha(XFecha)
                XContado = "2"
                XEmpresa = 1
                XNetolist = 0.0
                XExentolist = 0.0
                XParidad = 0.0
                XPAgo = "1"

                XParamIvaComp = "" & interno & ",'" & XProveedor & "','" & XTipo & "','" & XLetra & "','" & XPunto & "','" & XNumero & "','" & XFecha & "','" & ZZVencimiento & "','" & ZZVencimiento1 & "','" & XPeriodo & "'," & Str$(XImpoNeto) & "," & Str$(XIva21) & "," & Str$(XIva5) & "," & Str$(XIva27) & "," & Str$(XIb) & "," & Str$(XExento) & ",'" & XContado & "','" & ZZImpre & "','" & ZZOrdFecha & "'," & XEmpresa & "," & Str$(XNetolist) & "," & Str$(XExentolist) & "," & Str$(XParidad) & "," & Val(XPAgo) & ", " & "'','  /  /    ','',0,'',0,0,0,0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'',0,'' "

                ZSqlIvaComp = "INSERT INTO IvaComp (NroInterno, Proveedor, Tipo, Letra, Punto, Numero, Fecha, Vencimiento, Vencimiento1, Periodo, Neto, Iva21, Iva5, Iva27, Ib, Exento, " & " Contado, Impre, OrdFecha, Empresa, NetoList, ExentoList, Paridad, Pago, Cai, VtoCai, Despacho, Rechazado, Remito, NroInternoAsociado, Iva105, SoloIva, RetIb1, NroRetIb1, RetIb2, NroRetIb2, " & " RetIb3, NroRetIb3, RetIb4, NroRetIb4, RetIb5, NroRetIb5, RetIb6, NroRetIb6, RetIb7, NroRetIb7, RetIb8, NroRetIb8, RetIb9, NroRetIb9, RetIb10, NroRetIb10, RetIb11, NroRetIb11, " & " RetIb12, NroRetIb12, RetIb13, NroRetIb13, RetIb14, NroRetIb14) VALUES (#PARAM#)"

                Try
                    cn.ConnectionString = _CS()
                    cn.Open()
                    trans = cn.BeginTransaction

                    cm.Connection = cn
                    cm.Transaction = trans

                    cm.CommandText = ZSqlIvaComp.ToString.Replace("#PARAM#", XParamIvaComp)

                    cm.ExecuteNonQuery()

                    trans.Commit()

                Catch ex As System.Exception

                    If Not IsNothing(trans) Then
                        trans.Rollback()
                    End If

                    Throw New System.Exception("Hubo un problema al intentar grabar la Factura en la Base de Datos.")
                Finally

                    cn.Close()
                    cm.Dispose()

                End Try


                ' Grabamos las Imputaciones Correspondientes.

                RenglonDife = 1


                REM Renglon 1

                RenglonDife = ceros(RenglonDife, 2)
                XRenglon = RenglonDife

                XTipomovi = "2"
                XTipocomp = WTipoDife
                XLetracomp = WLetraDife
                XPuntocomp = WPuntoDife
                XNrocomp = WNumeroDife
                XObservaciones = ""
                Select Case Val(WTipoDife)
                    Case 2
                        XCuenta = "6107"
                        XDebito = Val(formatonumerico(Math.Abs(Val(WNetoDife))))
                        XCredito = 0
                    Case Else
                        XCuenta = "7308"
                        XDebito = 0
                        XCredito = Val(formatonumerico(Math.Abs(Val(WNetoDife))))
                End Select
                XFechaOrd = ZZOrdFecha
                XTitulo = "Compras"
                XEmpresa = "1"
                ZZClave = XTipomovi & interno & XRenglon
                XDebitolist = 0
                XCreditolist = 0

                XParamImputac = "'" & ZZClave & "','" & XTipomovi & "','" & XProveedor & "','" & XTipocomp & "','" & XLetracomp & "','" & XPuntocomp & "','" & XNrocomp & "','" & XRenglon & "','" & XFecha & "','" & XObservaciones & "','" & XCuenta & "'," & Str$(XDebito) & "," & Str$(XCredito) & ",'" & XFechaOrd & "','" & XTitulo & "'," & XEmpresa & "," & Str$(XDebitolist) & "," & Str$(XCreditolist) & "," & interno & ", '','',''"

                ZSqlImputac = "INSERT INTO Imputac (Clave, TipoMovi, Proveedor, TipoComp, LetraComp, PuntoComp, NroComp, Renglon, Fecha, Observaciones, Cuenta, Debito, Credito, FechaOrd, Titulo, Empresa, DebitoList, CreditoList, NroInterno, Periodo, PeriodoOrd, TituloII) VALUES (#PARAM#)"


                Try
                    cn.Open()
                    trans = cn.BeginTransaction

                    cm.Transaction = trans

                    cm.CommandText = ZSqlImputac.ToString.Replace("#PARAM#", XParamImputac)

                    cm.ExecuteNonQuery()

                    trans.Commit()

                Catch ex As System.Exception

                    If Not IsNothing(trans) Then
                        trans.Rollback()
                    End If

                    Throw New System.Exception("Hubo un problema al intentar grabar la Imputacion en la Base de Datos.")
                Finally

                    cn.Close()
                    cm.Dispose()

                End Try

                ' Renglon 2

                RenglonDife = RenglonDife + 1
                XRenglon = ceros(RenglonDife, 2)

                XTipomovi = "2"
                XTipocomp = WTipoDife
                XLetracomp = WLetraDife
                XPuntocomp = WPuntoDife
                XNrocomp = WNumeroDife
                'XFecha = Fecha.Text
                XObservaciones = ""
                Select Case Val(WTipoDife)
                    Case 2
                        XCuenta = "151"
                        XDebito = Val(formatonumerico(Math.Abs(Val(WIvaDife))))
                        XCredito = 0
                    Case Else
                        XCuenta = "151"
                        XDebito = 0
                        XCredito = Val(formatonumerico(Math.Abs(Val(WIvaDife))))
                End Select
                XFechaOrd = ZZOrdFecha
                XTitulo = "Compras"
                XEmpresa = "1"
                ZZClave = XTipomovi & interno & XRenglon
                XDebitolist = 0.0
                XCreditolist = 0.0

                XParamImputac = "'" & ZZClave & "','" & XTipomovi & "','" & XProveedor & "','" & XTipocomp & "','" & XLetracomp & "','" & XPuntocomp & "','" & XNrocomp & "','" & XRenglon & "','" & XFecha & "','" & XObservaciones & "','" & XCuenta & "'," & Str$(XDebito) & "," & Str$(XCredito) & ",'" & XFechaOrd & "','" & XTitulo & "'," & XEmpresa & "," & Str$(XDebitolist) & "," & Str$(XCreditolist) & "," & interno & ", '', '', ''"

                Try
                    cn.Open()
                    trans = cn.BeginTransaction

                    cm.Transaction = trans

                    cm.CommandText = ZSqlImputac.ToString.Replace("#PARAM#", XParamImputac)

                    cm.ExecuteNonQuery()

                    trans.Commit()

                Catch ex As System.Exception

                    If Not IsNothing(trans) Then
                        trans.Rollback()
                    End If

                    Throw New System.Exception("Hubo un problema al intentar grabar la Imputacion en la Base de Datos.")
                Finally

                    cn.Close()
                    cm.Dispose()

                End Try

                ' Renglon 3

                RenglonDife = RenglonDife + 1

                XRenglon = ceros(RenglonDife, 2)

                XTipomovi = "2"
                XTipocomp = WTipoDife
                XLetracomp = WLetraDife
                XPuntocomp = WPuntoDife
                XNrocomp = WNumeroDife
                'XFecha = Fecha.Text
                XObservaciones = ""
                Select Case Val(WTipoDife)
                    Case 2
                        XCuenta = "2001"
                        XDebito = 0
                        XCredito = Val(formatonumerico(Math.Abs(Val(WNetoDife)) + Math.Abs(Val(WIvaDife))))
                    Case Else
                        XCuenta = "2001"
                        XDebito = Val(formatonumerico(Math.Abs(Val(WNetoDife)) + Math.Abs(Val(WIvaDife))))
                        XCredito = 0
                End Select
                XFechaOrd = ZZOrdFecha
                XTitulo = "Compras"
                XEmpresa = "1"
                ZZClave = XTipomovi & interno & XRenglon
                XDebitolist = 0.0
                XCreditolist = 0.0

                XParamImputac = "'" & ZZClave & "','" & XTipomovi & "','" & XProveedor & "','" & XTipocomp & "','" & XLetracomp & "','" & XPuntocomp & "','" & XNrocomp & "','" & XRenglon & "','" & XFecha & "','" & XObservaciones & "','" & XCuenta & "'," & Str$(XDebito) & "," & Str$(XCredito) & ",'" & XFechaOrd & "','" & XTitulo & "'," & XEmpresa & "," & Str$(XDebitolist) & "," & Str$(XCreditolist) & "," & interno & ", '', '', ''"

                Try
                    cn.Open()
                    trans = cn.BeginTransaction

                    cm.Transaction = trans

                    cm.CommandText = ZSqlImputac.ToString.Replace("#PARAM#", XParamImputac)

                    cm.ExecuteNonQuery()

                    trans.Commit()

                Catch ex As System.Exception

                    If Not IsNothing(trans) Then
                        trans.Rollback()
                    End If

                    Throw New System.Exception("Hubo un problema al intentar grabar la Imputacion en la Base de Datos.")
                Finally

                    cn.Close()
                    cm.Dispose()

                End Try

                ' Grabamos damos de alta en la Cta Cte de Proveedores.
                XProveedor = txtProveedor.Text
                XLetra = WLetraDife
                XTipo = WTipoDife
                XPunto = WPuntoDife
                XNumero = WNumeroDife
                XFecha = txtFecha.Text
                XEstado = "1"
                ZZVencimiento = XFecha
                ZZVencimiento1 = XFecha
                XTotal = Val(formatonumerico(Val(WNetoDife) + Val(WIvaDife)))
                XSaldo = Val(formatonumerico(Val(WNetoDife) + Val(WIvaDife)))
                ZZClave = XProveedor & WLetraDife & WTipoDife & WPuntoDife & WNumeroDife
                ZZOrdFecha = ordenaFecha(XFecha)
                XOrdVencimiento = ZZOrdFecha
                Select Case Val(WTipoDife)
                    Case 1
                        ZZImpre = "FC"
                    Case 2
                        ZZImpre = "ND"
                    Case 3
                        ZZImpre = "NC"
                    Case Else
                        ZZImpre = ""
                End Select
                XEmpresa = "1"
                XSaldolist = 0.0
                Xlista = ""
                XAcumulado = 0.0
                XParidad = 0.0
                XPAgo = "1"

                XParam = "'" & ZZClave & "','" & XProveedor & "','" & XLetra & "','" & XTipo & "','" & XPunto & "','" & XNumero & "','" & XFecha & "','" & XEstado & "','" & ZZVencimiento & "','" & ZZVencimiento1 & "'," & Str$(XTotal) & "," & Str$(XSaldo) & ",'" & ZZOrdFecha & "','" & XOrdVencimiento & "','" & ZZImpre & "','" & XEmpresa & "'," & Str$(XSaldolist) & "," & interno & ",'" & Xlista & "'," & Str$(XAcumulado) & "," & Str$(XParidad) & "," & Str$(XPAgo) & ", " & "'','',0,'',0,0,0,'',0,0,'','','','','','','',''"

                XSql = "INSERT INTO CtaCtePrv (Clave, Proveedor, Letra, Tipo, Punto, Numero, fecha, Estado, Vencimiento, Vencimiento1, Total, Saldo, OrdFecha, OrdVencimiento, Impre, Empresa, SaldoList, NroInterno, Lista, Acumulado, Paridad, Pago, Observaciones, Tarjeta, NroInternoAsociado, DesProveOriginal, FacturaOriginal, Cuota, ImporteOriginal, FechaOriginal, Interes, IvaInteres, OrdFechaOriginal, Referencia, TituloI, TituloII, Auxi1, Auxi2, Auxi3, Auxi4) VALUES (#PARAM#)"


                Try
                    cn.Open()
                    trans = cn.BeginTransaction

                    cm.Transaction = trans

                    cm.CommandText = XSql.ToString.Replace("#PARAM#", XParam)

                    cm.ExecuteNonQuery()

                    trans.Commit()

                Catch ex As System.Exception

                    If Not IsNothing(trans) Then
                        trans.Rollback()
                    End If

                    Throw New System.Exception("Hubo un problema al intentar grabar la Cta Cte del Proveedor en la Base de Datos.")
                Finally

                    cn.Close()
                    cm.Dispose()

                End Try

            End If
        Next
    End Sub

    Private Sub eventoSegunTipoEnFormaDePagoPara(ByVal valor As Integer, ByVal rowIndex As Integer)
        Dim ZZNombre = ""
        Dim column As Integer

        Select Case valor
            Case 1
                ZZNombre = "Efectivo"
                column = 5
            Case 2, 3, 7
                column = 1
            Case 4
                column = 1
                sumarImportes()
            Case 5
                ZZNombre = "US$"
                column = 4
            Case 6
                ZZNombre = "Varios"

                WRowVarios = rowIndex

                WProceso.Text = 2
                pnlPedirCuenta.Visible = True
                txtCuenta.Text = WCuenta(rowIndex, WProceso.Text)
                txtCuenta.Focus()

                column = 5
            Case Else
                Exit Sub
        End Select


        With gridFormaPagos.Rows(rowIndex)
            Dim anterior As Integer = Val(.Cells("UltTipo").Value)

            ' Limpiamos la fila cada vez que se modifique el tipo.
            If anterior <> valor Then
                .Cells(0).Value = ""
                .Cells(1).Value = ""
                .Cells(2).Value = ""
                .Cells(3).Value = ""
                .Cells(4).Value = ""
                .Cells(5).Value = ""

                sumarImportes()

            ElseIf anterior = 2 Or anterior = 4 Then
                ZZNombre = .Cells(4).Value
            End If

            .Cells(0).Value = ceros(valor.ToString, 2)
            .Cells(4).Value = ZZNombre
            .Cells("UltTipo").Value = .Cells(0).Value
            gridFormaPagos.CurrentCell = .Cells(column)
        End With
    End Sub

    Private Sub sumarImportes()
        Dim ZZPagos As Double
        Dim formaPagos As Double
        Dim total As Double
        Dim WRecalcular = gridPagos.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Val(row.Cells(4).Value) <> 0)

        ' Recalculamos las retenciones.
        If WRecalcular And Not _ExisteOrdenDePago(txtOrdenPago.Text) Then
            _RecalcularRetenciones()
        End If

        total = Val(_NormalizarNumero(txtIVA.Text)) + Val(_NormalizarNumero(txtGanancias.Text)) + Val(_NormalizarNumero(txtIBCiudad.Text)) + Val(_NormalizarNumero(txtIngresosBrutos.Text))

        For Each row As DataGridViewRow In gridPagos.Rows
            If Not row.IsNewRow Then
                row.Cells(4).Value = IIf(Trim(row.Cells(4).Value) <> "", formatonumerico(row.Cells(4).Value), "")
                ZZPagos += Val(_NormalizarNumero(row.Cells(4).Value))
            End If
        Next

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            If Not row.IsNewRow Then
                row.Cells(5).Value = IIf(Trim(row.Cells(5).Value) <> "", formatonumerico(row.Cells(5).Value), "")
                formaPagos += Val(_NormalizarNumero(row.Cells(5).Value))
            End If
        Next

        txtTotal.Text = formatonumerico(Str$(total))
        lblPagos.Text = formatonumerico(Str$(ZZPagos))
        lblFormaPagos.Text = formatonumerico(Str$(formaPagos + total))
        lblDiferencia.Text = formatonumerico(Str$(ZZPagos - formaPagos - total))
    End Sub

    Private Sub gridPagos_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles gridPagos.RowsAdded
        sumarImportes()
    End Sub

    Private Sub gridFormaPagos_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles gridFormaPagos.RowsAdded
        sumarImportes()
    End Sub

    Private Sub gridPagos_UserDeletedRow(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles gridPagos.UserDeletedRow
        If e.Row.Cells(0).Value <> "" Then
            Dim detalle As DetalleCompraCuentaCorriente = pagos.Find(Function(pago) pago.tipo = e.Row.Cells(0).Value And pago.letra = e.Row.Cells(1).Value And pago.punto = e.Row.Cells(2).Value And pago.numero = e.Row.Cells(3).Value And pago.saldo = CustomConvert.toDoubleOrZero(e.Row.Cells(4).Value))
            If Not IsNothing(detalle) Then
                pagos.Remove(detalle)
            End If
        End If
        sumarImportes()
    End Sub

    Private Sub gridFormaPagos_UserDeletedRow(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles gridFormaPagos.UserDeletedRow
        If e.Row.Cells(0).Value = "03" Then
            Dim chequeABorrar As Cheque = cheques.Find(Function(cheque) cheque.numero = e.Row.Cells(1).Value And cheque.fecha = e.Row.Cells(2).Value And cheque.banco = e.Row.Cells(4).Value And cheque.importe = e.Row.Cells(5).Value)
            If Not IsNothing(chequeABorrar) Then
                cheques.Remove(chequeABorrar)
            End If
            _EliminarSeguimientoClaveCheque(e.Row.Cells(1).Value)
        End If
        sumarImportes()
    End Sub

    Private Function _ProximaFilaVaciaPagos() As Integer
        Dim XRow = 0

        For i = 0 To XMAXFILAS - 1
            If gridPagos.Rows(i).Cells(0).Value = "" Then
                XRow = i
                Exit For
            End If
        Next

        Return XRow
    End Function


    Private Function _ProximaFilaVaciaFormaPagos() As Integer
        Dim XRow = 0

        For i = 0 To XMAXFILAS - 1
            If gridFormaPagos.Rows(i).Cells(0).Value = "" Then
                XRow = i
                Exit For
            End If
        Next

        Return XRow
    End Function

    Private Sub optTransferencias_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optTransferencias.CheckedChanged
        If optTransferencias.Checked Then
            'HABILITAMOS LOS CAMPOS EN CASO DE QUE VINIERA DE UN PAGO VARIOS
            txtProveedor.Enabled = True
            txtRazonSocial.Enabled = True

            If Val(txtBanco.Text) = 0 Then
                txtBanco.Enabled = True
                txtBanco.Focus()
                Exit Sub
            End If

            With gridPagos
                '.Rows.Clear()
                Dim r = _ProximaFilaVaciaPagos()
                .CurrentCell = .Rows(r).Cells(4)
                .Focus()
            End With
            'gridPagos.Columns(5).ReadOnly = False
        End If
    End Sub

    Private Sub optAnticipos_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optAnticipos.CheckedChanged
        If optAnticipos.Checked Then
            'HABILITAMOS LOS CAMPOS EN CASO DE QUE VINIERA DE UN PAGO VARIOS
            txtProveedor.Enabled = True
            txtRazonSocial.Enabled = True
            'gridPagos.Rows.Clear()
            '_LimpiarGrillas()
            With gridPagos
                '.Rows.Clear()
                Dim r = _ProximaFilaVaciaPagos()
                '.Rows(r).Cells(5).Value = txtRazonSocial.Text
                .CurrentCell = .Rows(r).Cells(4)
                .Focus()
            End With
            'gridPagos.Columns(5).ReadOnly = True
        End If
    End Sub

    Private Sub optVarios_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optVarios.CheckedChanged
        If optVarios.Checked Then
            If Trim(txtProveedor.Text) <> "" Then
                txtProveedor.Text = ""
                txtRazonSocial.Text = ""
                MsgBox("Se limpio el campo proveedor ya que al ser pago varios no puede ser a proveedores", vbExclamation, vbOK)
            End If
            'SI ES VARIOS NO PUEDE SER PROVEEDOR, POR ESO SE LIMPIA Y SE BLOQUEA
            txtProveedor.Enabled = False
            txtRazonSocial.Enabled = False
            '_LimpiarGrillas()
            With gridPagos
                '.Rows.Clear()
                Dim r = _ProximaFilaVaciaPagos() '.Rows.Add("", "", "", "", "", txtObservaciones.Text)
                .Rows(r).Cells(5).Value = txtObservaciones.Text
                .CurrentCell = .Rows(r).Cells(4)
                .Focus()
            End With

            'gridPagos.Columns(5).ReadOnly = True
        End If
    End Sub

    Private Sub optChequeRechazado_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optChequeRechazado.CheckedChanged
        If optChequeRechazado.Checked Then
            'HABILITAMOS LOS CAMPOS EN CASO DE QUE VINIERA DE UN PAGO VARIOS
            txtProveedor.Enabled = True
            txtRazonSocial.Enabled = True
            '_LimpiarGrillas()
            With gridPagos
                '.Rows.Clear()
                Dim r = _ProximaFilaVaciaPagos()
                .Rows(r).Cells(0).Value = "00"
                .CurrentCell = .Rows(r).Cells(4)
                .Focus()
            End With
            'gridPagos.Rows.Clear()
            'gridPagos.Rows.Add("", "", "", "", "", "")
            'gridPagos.Columns(5).ReadOnly = False
        End If
    End Sub

    Private Sub optCtaCte_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optCtaCte.CheckedChanged
        If optCtaCte.Checked Then
            'HABILITAMOS LOS CAMPOS EN CASO DE QUE VINIERA DE UN PAGO VARIOS
            txtProveedor.Enabled = True
            txtRazonSocial.Enabled = True
            '_LimpiarGrillas()
            'gridPagos.Rows.Clear()
            Try
                'gridPagos.Columns(5).ReadOnly = True
            Catch ex As ArgumentOutOfRangeException
            End Try
        End If
    End Sub

    Public Sub txtOrdenPago_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtOrdenPago.KeyDown

        If e.KeyData = Keys.Enter Then

            btnEnviarAviso.Enabled = True
            btnActualizarCarpetas.Enabled = True

            If Trim(txtOrdenPago.Text) <> "" Then
                txtOrdenPago.Text = ceros(txtOrdenPago.Text, 6)

                Try

                    Dim WOrd As DataRow = GetSingle("SELECT MarcaVirtual, Carpeta1, Carpeta2, Carpeta3, Carpeta4, Carpeta5, Carpeta6, Carpeta7, Carpeta8, Carpeta9 FROM Pagos WHERE Orden = '" & txtOrdenPago.Text & "' And Renglon = '01'")

                    If WOrd IsNot Nothing Then

                        If OrDefault(WOrd.Item("MarcaVirtual"), "") = "X" Then
                            MsgBox("La Orden de Pago indicada, es una OP Virtual y por tanto no puede ser consultada por medio de este formulario.", MsgBoxStyle.Information)
                            Exit Sub
                        End If

                        For i = 1 To 9
                            _Carpetas(i) = Trim(OrDefault(WOrd.Item("Carpeta" & i), ""))
                        Next
                        'BLOQUEAMOS PARA Q NO HAGAN CAGADA, SE  VUELVE A HABILITAR CUANDO LIMPIAN EL FORM
                        txtOrdenPago.Enabled = False

                    End If

                    mostrarOrdenDePago(DAOPagos.buscarOrdenPorNumero(txtOrdenPago.Text))

                    btnEnviarAviso.Enabled = True
                    btnActualizarCarpetas.Visible = True

                    CargarNrosCuentas(txtOrdenPago.Text)

                Catch ex As System.Exception

                    Dim ord = txtOrdenPago.Text

                    btnLimpiar.PerformClick()

                    txtOrdenPago.Text = ord

                End Try

                If txtProveedor.Text <> "" Then
                    txtProveedor.Focus()
                Else
                    txtFecha.Focus()
                End If

                WGrillaReferencia = Nothing

            Else
                txtOrdenPago.Text = "0"
                txtFecha.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtOrdenPago.Text = ""
        End If
    End Sub

    Private Sub CargarNrosCuentas(ByVal OrdenPago As String)
        'PARA PODER CONSULTAR LOS NUMEROS DE CUENTAS
        Dim SQLCnslt As String = "SELECT Cuenta FROM Pagos WHERE Orden = '" & OrdenPago & "' AND Cuenta <> '' ORDER BY Clave"
        Dim TablaCuentas As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If TablaCuentas.Rows.Count > 0 Then
            Dim i As Integer = 0
            For Each row As DataRow In TablaCuentas.Rows
                WCuenta(i, 1) = row.Item("Cuenta")
                i += 1
            Next

        End If
    End Sub


    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back, Keys.Subtract
                Return True
            Case Else
                Return False
        End Select

    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Return _EsNumero(CInt(keycode)) Or _EsControl(keycode)
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Return _EsDecimal(CInt(keycode)) Or _EsControl(keycode)
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

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

            End Select


            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = gridFormaPagos.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then

                        ' Se formatea en caso de que se cargue con la Lectora Nueva de Cheques.
                        If valor.StartsWith(";") Then
                            valor = "C" & Mid(valor, 2, 29) & "E"
                        End If
                        If valor.StartsWith(",") Then
                            valor = "C" & Mid(valor, 2, 29) & "E"
                        End If

                        If Trim(valor.ToString.Length) = 31 Then
                            If _ProcesarCheque(iRow, valor) Then
                                Try
                                    If _EsChequePropio(valor) Then
                                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(2)
                                    Else
                                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow + 1).Cells(0)
                                    End If

                                Catch ex As System.Exception
                                    If _EsChequePropio(valor) Then
                                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(2)
                                    Else
                                        gridFormaPagos.CurrentCell = gridFormaPagos.Rows(_ProximaFilaVaciaFormaPagos).Cells(0) 'gridFormaPagos.Rows(gridFormaPagos.Rows.Add).Cells(0)
                                    End If

                                End Try

                                sumarImportes()
                            End If
                        Else
                            'valor = valor.ToString().Substring(valor.ToString.Length - 1, 1)

                            Select Case Val(valor)
                                Case 1, 2, 3, 4, 5, 6, 7

                                    eventoSegunTipoEnFormaDePagoPara(CustomConvert.toIntOrZero(valor), iRow)

                                Case Else
                                    gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol)
                            End Select

                        End If

                        Return True
                    End If

                End If


                If iCol = 3 Then
                    If gridFormaPagos.Rows(iRow).Cells(0).Value = "02" Or gridFormaPagos.Rows(iRow).Cells(0).Value = "04" Or gridFormaPagos.Rows(iRow).Cells(0).Value = "03" Then

                        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(valor)
                        If Not IsNothing(banco) Then
                            gridFormaPagos.Rows(iRow).Cells(iCol + 1).Value = banco.nombre
                        Else

                            If Trim(gridFormaPagos.Rows(iRow).Cells(iCol + 1).Value) = "" Then
                                MsgBox("Codigo de Banco Incorrecto.", MsgBoxStyle.Information)
                                Return True ' Nos quedamos en la celda.
                            End If

                        End If

                        iCol = 4 ' Desplazamos a ultima celda.
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
                        gridFormaPagos.Rows(iRow).Cells(iCol).Value = formatonumerico(valor)

                        sumarImportes()

                        Try
                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow + 1).Cells(0)
                        Catch ex As System.Exception
                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(_ProximaFilaVaciaFormaPagos).Cells(0) 'gridFormaPagos.Rows(gridFormaPagos.Rows.Add).Cells(0)
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

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then
                    If Trim(valor) <> "" And Not IsNothing(valor) Then

                    End If

                    Select Case iCol
                        Case 4
                            ' Detectamos si la siguiente fila es una nota de debito, y en caso de que si, se recalcula el monto.

                            If iRow < 14 Then ' solo se procesa hasta la anteultima fila.

                                ' Es una nota de Debito o Crédito.
                                If Val(.Rows(iRow + 1).Cells(3).Value) = 99999999 Or Val(.Rows(iRow + 1).Cells(0).Value) = 2 Or Val(.Rows(iRow + 1).Cells(0).Value) = 3 Then

                                    Dim WLetra = UCase(.Rows(iRow).Cells(1).Value)
                                    Dim WTipo = ceros(.Rows(iRow).Cells(0).Value, 2)
                                    Dim WPunto = ceros(.Rows(iRow).Cells(2).Value, 4)
                                    Dim WNumero = ceros(.Rows(iRow).Cells(3).Value, 8)
                                    Dim WSaldo = formatonumerico(.Rows(iRow).Cells(iCol).Value)

                                    Dim ZZClaveCtaCtePrv = txtProveedor.Text & WLetra & WTipo & WPunto & WNumero

                                    Try
                                        _RecalcularNotaDeCreditoDebito(ZZClaveCtaCtePrv, WSaldo, iRow + 1)
                                    Catch ex As System.Exception
                                        MsgBox(ex.Message)
                                    End Try

                                End If

                            End If

                            sumarImportes()
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                        Case 5

                            If optVarios.Checked Then

                                WRowVarios = .CurrentCell.RowIndex

                                WProceso.Text = 1
                                pnlPedirCuenta.Visible = True
                                txtCuenta.Text = WCuenta(WRowVarios, WProceso.Text)
                                txtCuenta.Focus()

                            ElseIf optTransferencias.Checked Then

                                Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)

                                If Not IsNothing(banco) Then
                                    WCuenta(.CurrentCell.RowIndex, 1) = banco.cuenta.id
                                Else
                                    WCuenta(.CurrentCell.RowIndex, 1) = "999999"
                                End If

                            ElseIf optChequeRechazado.Checked Then
                                WCuenta(.CurrentCell.RowIndex, 1) = "111"
                            Else
                                WCuenta(.CurrentCell.RowIndex, 1) = ""
                            End If

                            Try
                                .CurrentCell = .Rows(iRow + 1).Cells(0)
                            Catch ex As System.Exception
                                .CurrentCell = .Rows(iRow).Cells(0)
                            End Try

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True
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

    Private Function _FormatoValidoDeCheque(ByVal ClaveCheque As String) As Boolean
        Dim valido = False

        ClaveCheque = UCase(Trim(ClaveCheque))

        If ClaveCheque.Length = 31 And Mid(ClaveCheque, 1, 1) = "C" And Mid(ClaveCheque, ClaveCheque.Length, 1) = "E" Then
            valido = True
        End If

        Return valido
    End Function

    Private Function _BuscarClaveRecibo(ByVal Clavecheque) As String
        Dim clave = ""

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Clave FROM Recibos WHERE ClaveCheque = '" & Clavecheque & "'")
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

        Catch ex As System.Exception
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

            Catch ex As System.Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally

                cn.Close()

            End Try
        End If





        Return clave
    End Function

    Private Function _EsChequePropio(ByVal ClaveCheque) As Boolean
        Dim ZZCuenta As String = Mid$(ClaveCheque, 20, 11)

        Select Case ZZCuenta
            Case "00000035626", "00030521158", "00830029723", "05095506300"
                Return True

            Case Else
                Return False
        End Select
    End Function

    Private Function _ProcesarCheque(ByVal row As Integer, ByVal ClaveCheque As String) As Boolean
        Dim WTipo, WNumero, WFecha, WBanco, WImporte, WClave, WNomBanco, XBanco, WCuit As String
        Dim _LecturaCorrecta = True
        Dim cn = New SqlConnection()
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader


        If Not _FormatoValidoDeCheque(ClaveCheque) Then
            MsgBox("El formato del cheque no es valido.", MsgBoxStyle.Exclamation)
            Return False
        End If

        ' Chequemos si es Cheque Propio.
        If _EsChequePropio(ClaveCheque) Then

            Dim ZZNroCheque = Mid$(ClaveCheque, 12, 8)
            Dim ZZNroCuenta = Mid$(ClaveCheque, 20, 11)

            WTipo = "02"
            WClave = ClaveCheque
            'WNomBanco = DAOBanco.buscarBancoPorCodigo(ZZBanco)
            XBanco = ""
            WNomBanco = ""

            Select Case ZZNroCuenta

                Case "00000035626"
                    XBanco = "16"
                    WNomBanco = "SANTANDER"
                Case "00030521158"
                    XBanco = "3"
                    WNomBanco = "NACION (SF)"
                Case "00830029723"
                    XBanco = "8"
                    WNomBanco = "HSBC (SF"
                Case "05095506300"
                    XBanco = "12"
                    WNomBanco = "Pcia (BsAs"

            End Select

            With gridFormaPagos.Rows(row)
                .Cells(0).Value = WTipo
                .Cells(1).Value = ZZNroCheque
                .Cells(2).Value = ""
                .Cells(3).Value = XBanco
                .Cells(4).Value = WNomBanco
                .Cells(5).Value = ""
                .Cells(6).Value = WClave
            End With

            Return True
        End If

        WClave = _BuscarClaveRecibo(ClaveCheque)

        ' Chequeamos que el cheque no se haya cargado.

        'If _ChequeYaCargado(WClave) Then
        If _ChequeYaCargado(ClaveCheque) Then
            _LecturaCorrecta = False

            MsgBox("Cheque ya Cargado con anterioridad.", MsgBoxStyle.Exclamation)

            Return _LecturaCorrecta
        End If

        SQLConnector.conexionSql(cn, cm)
        Dim _Tabla = "Recibos"


        If Mid(WClave, 1, 1) = "2" Then
            _Tabla = "RecibosProvi"
        End If

        Try
            cm.CommandText = "SELECT Numero2, Fecha2, Importe2, Banco2, Cuit FROM " & _Tabla & " WHERE ClaveCheque = '" & ClaveCheque & "' AND Estado2 = 'P'"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                With dr
                    WNumero = IIf(IsDBNull(.Item("Numero2")), "", .Item("Numero2"))
                    WFecha = IIf(IsDBNull(.Item("Fecha2")), "", .Item("Fecha2"))
                    WImporte = IIf(IsDBNull(.Item("Importe2")), "", .Item("Importe2"))
                    WBanco = IIf(IsDBNull(.Item("Banco2")), "", .Item("Banco2"))
                    WCuit = IIf(IsDBNull(.Item("Cuit")), "", .Item("Cuit"))
                End With
            Else
                Return False
            End If

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar los datos del Cheque en la Base de Datos.", MsgBoxStyle.Critical)
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
                .Cells(5).Value = formatonumerico(WImporte)
                .Cells(6).Value = WClave
                .Cells(7).Value = WCuit
            End With
        End If

        Return _LecturaCorrecta
    End Function

    Private Function _ChequeYaCargado(ByVal ClaveCheque) As Boolean
        Dim _cargado = False
        Dim ZZNroCheque = Mid$(ClaveCheque, 12, 8)

        For Each row As DataGridViewRow In gridFormaPagos.Rows
            With row
                If Val(.Cells(1).Value) = ZZNroCheque Then
                    Return True
                End If
            End With
        Next

        Return _cargado
    End Function

    Private Sub _PedirInformacion(ByVal msg As String, ByRef VariableDestino As String)

        With InformacionRetenciones
            .TipoInformacion = msg

            .Valor = VariableDestino

            .ShowDialog(Me)

            VariableDestino = .Valor

            .Dispose()

        End With
    End Sub

    Private Sub _EliminarSeguimientoClaveCheque(ByVal numCheque As String)

        If Trim(numCheque) <> "" Then
            _ClavesCheques.RemoveAll(Function(c) c(4) = numCheque)
        End If
    End Sub

    Private Sub btnCarpetas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCarpetas.Click

        With CarpetasPagos

            .Carpetas(_Carpetas) ' Asignamos las carpetas en caso de que la orden de pago tenga.

            .ShowDialog()

            _Carpetas = .Carpetas ' Traemos las carpetas que se hayan asignado.

            .Dispose()

        End With
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub
            End If

            If Not _ValidarFecha(txtFecha.Text) Then
                Exit Sub
            End If

            txtProveedor.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Clear()
        End If
    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtObservaciones.KeyDown

        If e.KeyData = Keys.Enter Then
            If Not optVarios.Checked And Not optTransferencias.Checked Then
                With gridPagos
                    .CurrentCell = .Rows(0).Cells(4)
                    .Focus()
                End With
            Else
                txtBanco.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If
    End Sub

    Private Sub txtFechaParidad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaParidad.KeyDown

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

                sumarImportes()

            Else
                txtFechaParidad.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtFechaParidad.Clear()
        End If
    End Sub

    Private Sub txtParidad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtParidad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtParidad.Text) <> 0 Then
                txtGanancias.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtParidad.Text = ""
        End If
    End Sub

    Private Sub txtGanancias_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtGanancias.KeyDown
        If e.KeyData = Keys.Enter Then
            txtIngresosBrutos.Focus()
        End If
    End Sub

    Private Sub txtIngresosBrutos_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtIngresosBrutos.KeyDown
        If e.KeyData = Keys.Enter Then
            cmbTipo.Focus()
        End If
    End Sub

    Private Sub cmbTipo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbTipo.KeyDown
        If e.KeyData = Keys.Enter Then
            txtIBCiudad.Focus()
        End If
    End Sub

    Private Sub cmbTipo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipo.TextChanged
        txtIBCiudad.Focus()
    End Sub

    Private Sub txtIBCiudad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtIBCiudad.KeyDown
        If e.KeyData = Keys.Enter Then
            txtIVA.Focus()
        End If
    End Sub

    Private Sub txtIVA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtIVA.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTotal.Focus()
        End If
    End Sub

    Private Sub txtParidad_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtParidad.Leave, txtGanancias.Leave, txtIBCiudad.Leave, txtIngresosBrutos.Leave, txtIVA.Leave, txtTotal.Leave, lblDiferencia.Leave, lblFormaPagos.Leave, lblPagos.Leave
        Dim _controles As New List(Of Control) From {txtGanancias, txtIBCiudad, txtIngresosBrutos, txtIVA, txtTotal, lblDiferencia, lblFormaPagos, lblPagos}
        For Each _c As Control In _controles
            _c.Text = _NormalizarNumero(_c.Text)
        Next

        txtParidad.Text = _NormalizarNumero(txtParidad.Text, 4)
    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtProveedor.MouseDoubleClick

        _TipoConsulta = 0
        _ListarProveedores()
    End Sub

    Private Sub txtBanco_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtBanco.MouseDoubleClick

        _TipoConsulta = 1
        _ListarCuentasContables()
    End Sub

    Private Sub txtConsulta_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtConsulta.KeyPress
    End Sub

    Private Sub txtConsulta_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtConsulta.TextChanged

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

    Private Sub btnChequesTerceros_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChequesTerceros.Click
        lstSeleccion.SelectedIndex = 2
        lstSeleccion_MouseClick(Nothing, Nothing)
    End Sub

    Private Sub btnCtaCte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCtaCte.Click
        lstSeleccion.SelectedIndex = 1
        lstSeleccion_MouseClick(Nothing, Nothing)
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
        Exportar
    End Enum

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click
        Dim XOrdenPago As String = IIf(Trim(txtOrdenPago.Text) = "", "0", Trim(txtOrdenPago.Text))
        Dim XEmpCuit = "30-54916508-3"
        Dim WEmpresa = "SURFACTAN S.A."
        Dim XRazon, XCuitProveedor, WTipo, WLetra, WPunto, WNumero, ClaveCtaprv, WCtaProveedor, WCtaEfectivo, WCtaCheques, ClaveBanco As String
        Dim WRenglon, ZZTotal, XCantidad As Double
        Dim WImpresion(XMAXFILAS, 10) As String
        Dim WImpre2(XMAXFILAS, 10) As String
        Dim WDebito(XMAXFILAS, 2) As String
        Dim WCredito(XMAXFILAS, 4) As String
        Dim XXCuenta(XMAXFILAS, 2) As String
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        ' CAMBIAMOS EL CUIT SEGUN SEA O NO PELLITAL
        If _EsPellital() Then
            XEmpCuit = "30-61052459-8"
            WEmpresa = "PELLITAL S.A."
        End If

        ' Verificamos de que haya codigo de orden de pago valido para traer.
        If Val(XOrdenPago) <= 0 Then
            Exit Sub
        End If

        ' Chequeamos que la OP exista antes de Imprimir.
        If Not _ExisteOrdenDePago(XOrdenPago) Then
            Exit Sub
        End If

        XRazon = ""
        XCuitProveedor = ""
        WRenglon = 0
        ZZTotal = 0
        XCantidad = 0
        Dim XCBU As String = ""

        SQLConnector.conexionSql(cn, cm)

        ' Sacamos el resto de informacion del proveedor.
        Try
            cm.CommandText = "SELECT Cuit, Nombre, Cbu FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()
                XRazon = dr.Item("Nombre")
                XCuitProveedor = dr.Item("Cuit")
                XCBU = Trim(OrDefault(dr.Item("Cbu"), ""))

            End If

        Catch ex As System.Exception
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

                If Val(.Cells("MarcaDifCambio").Value) = 1 Then
                    WImpresion(XCantidad, 2) = "NDC"
                End If

                If Val(.Cells("MarcaCHR").Value) = 1 Then
                    WImpresion(XCantidad, 2) = "CHR"
                End If

                WImpresion(XCantidad, 3) = Mid(.Cells(3).Value, 1, 8)
                WImpresion(XCantidad, 4) = .Cells(5).Value
                WImpresion(XCantidad, 5) = .Cells(4).Value
                If Val(WImpresion(XCantidad, 2)) = 3 Or Val(WImpresion(XCantidad, 2)) = 5 Then
                    ZZTotal -= Val(formatonumerico(WImpresion(XCantidad, 5)))
                Else
                    ZZTotal += Val(formatonumerico(WImpresion(XCantidad, 5)))
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

                Catch ex As System.Exception
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
            WDebito(1, 2) = formatonumerico(ZZTotal)
        Else

            For irow = 0 To gridPagos.Rows.Count - 1
                With gridPagos.Rows(irow)
                    If Val(.Cells(4).Value) <> 0 Then
                        WDebito(irow + 1, 1) = XXCuenta(irow, 1)
                        WDebito(irow + 1, 2) = Val(formatonumerico(.Cells(4).Value))
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

                    If Val(.Cells(0).Value) = 3 Then
                        SumaTercero = SumaTercero + Val(formatonumerico(.Cells(5).Value))
                    ElseIf Val(.Cells(0).Value) <> 3 Or Val(txtProveedor.Text) = 0 Then

                        If Val(OrDefault(.Cells("Tipo2").Value, "")) = 6 And Val(OrDefault(.Cells("Cuenta").Value, "")) = 5 Then
                            WImpre2(Impre2, 1) = "Compensación"
                        ElseIf Val(OrDefault(.Cells("Tipo2").Value, "")) = 2 And Val(OrDefault(.Cells("Numero2").Value, "")) = 0 Then
                            WImpre2(Impre2, 1) = "Transf."
                        Else
                            WImpre2(Impre2, 1) = .Cells(1).Value
                        End If

                        WImpre2(Impre2, 2) = .Cells(4).Value
                        WImpre2(Impre2, 3) = .Cells(5).Value
                        WImpre2(Impre2, 4) = .Cells(2).Value

                        WCredito(Lugar, 2) = .Cells(4).Value
                        WCredito(Lugar, 3) = .Cells(1).Value
                        WCredito(Lugar, 4) = .Cells(5).Value

                        Impre2 = Impre2 + 1

                    End If

                    Lugar = Lugar + 1
                End If
            End With
        Next iRow

        If SumaTercero <> 0 Then
            For WCiclo = 1 To XMAXFILAS
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

        Dim WCantFacts As Integer = gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(OrDefault(r.Cells("Importe").Value, 0)) <> 0)

        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For WCiclo = 0 To WLimite - 1

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
                WImporte1 = Val(formatonumerico(WImpresion(WCiclo, 5)))
            End If

            If Val(WImpre2(WCiclo, 3)) <> 0 Then
                WNumero2 = WImpre2(WCiclo, 1)
                WBanco2 = WImpre2(WCiclo, 2)
                WImporte2 = Val(formatonumerico(WImpre2(WCiclo, 3)))
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
                .Item("Importe1") = Val(formatonumerico(WImporte1))
                .Item("Numero2") = WNumero2
                .Item("Banco2") = WBanco2
                .Item("Importe2") = Val(formatonumerico(WImporte2))
                .Item("Fecha2") = WFecha2
                .Item("Neto") = Val(formatonumerico(ZZTotal))
                .Item("Rete1") = Val(formatonumerico(txtGanancias.Text))
                .Item("Rete2") = Val(formatonumerico(txtIngresosBrutos.Text)) + Val(formatonumerico(txtIBCiudad.Text))
                .Item("Total") = Val(txtIVA.Text)
                .Item("Observaciones") = txtObservaciones.Text
                .Item("Empresa") = WEmpresa '"Surfactan S.A."
                .Item("Cuit") = XEmpCuit
                .Item("Paridad") = Val(formatonumerico(XParidadTotal))

            End With

            Tabla.Rows.Add(row)

            If Not GenerarPDF AndAlso WLimite = 15 Then
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
                    .Item("Importe1") = Val(formatonumerico(WImporte1))
                    .Item("Numero2") = WNumero2
                    .Item("Banco2") = WBanco2
                    .Item("Importe2") = Val(formatonumerico(WImporte2))
                    .Item("Fecha2") = WFecha2
                    .Item("Neto") = Val(formatonumerico(ZZTotal))
                    .Item("Rete1") = Val(formatonumerico(txtGanancias.Text))
                    .Item("Rete2") = Val(formatonumerico(txtIngresosBrutos.Text)) + Val(formatonumerico(txtIBCiudad.Text))
                    .Item("Total") = Val(formatonumerico(txtIVA.Text))
                    .Item("Observaciones") = txtObservaciones.Text
                    .Item("Empresa") = WEmpresa '"Surfactan S.A."
                    .Item("Cuit") = XEmpCuit
                    .Item("Paridad") = Val(formatonumerico(XParidadTotal))
                End With

                Tabla.Rows.Add(row)
            End If

        Next

        crdoc.SetDataSource(Tabla)

        Dim frm As New VistaPrevia
        frm.Reporte = crdoc
        frm.Reporte.SetParameterValue("EsTransferencia", 0)
        frm.Reporte.SetParameterValue("CuitProv", XCuitProveedor)
        frm.Reporte.SetParameterValue("CbuProv", XCBU)

        Dim WFechasTransferencias = ""
        Dim WFechasECheques As String = ""
        Dim WFechasCompensaciones As String = ""
        Dim WOrdenPago As DataTable = _TraerDatosOrdenPago(txtOrdenPago.Text)
        Dim WHayECheques As Boolean
        Dim WHayCompensaciones As Boolean


        Dim EsPorTransferencia As Boolean = GetEsPorTransferencia(WOrdenPago, WFechasTransferencias, WHayECheques, WFechasECheques, WHayCompensaciones, WFechasCompensaciones)

        If EsPorTransferencia Or WHayECheques Then
            frm.Reporte.SetParameterValue("EsTransferencia", 1)
        End If

        If GenerarPDF Then

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            frm2.Reporte.SetParameterValue("EsTransferencia", 1)
            frm2.Reporte.SetParameterValue("CuitProv", XCuitProveedor)

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, txtOrdenPago.Text & "OrdenPago.pdf", "C:/ImpreOrdenPagoTemp/")

        Else
            Dim WCantImpresiones As Short = IIf(WLimite = 15, 1, 2)
            frm.Imprimir(WCantImpresiones)
        End If


        'Dim viewer As New ReportViewer("Orden de Pago", Globals.reportPathWithName("wInformeOrdenPago.rpt"), "")

        'With viewer
        '    .reporte.SetDataSource(Tabla)

        '    Select Case Reporte.Imprimir
        '        Case Reporte.Pantalla
        '            .ShowDialog()
        '        Case Reporte.Imprimir
        '            .imprimirReporte()
        '    End Select
        '    .reporte.Dispose()
        'End With


        ' Imprimimos Discrimianción de Valores de Terceros Entregados si el Tipo2 es = 3
        If _DiscriminarValoreDeTerceros(txtOrdenPago.Text) Then
            _ImprimirDiscriminacionDeValoresDeTerceros(XRazon, XCuitProveedor)
        End If

        ' Imprimimos Comprobante de Retención de Ganancias si la hubiese

        If Val(txtGanancias.Text) <> 0 Then
            _ImprimirComprobanteRetencionGanancias(ZZTotal, txtGanancias.Text)
        End If

        ' Imprimimos Comprobante de Retención de Ingresos Brutos si la hubiese.

        If Val(txtIngresosBrutos.Text) <> 0 Then
            _ImprimirComprobanteRetencionIB()
        End If

        ' Imprimimos Comprobante de Retención de Ingresos Brutos CABA si la hubiese y si estuviesemos en SURFACTAN.

        If Val(txtIBCiudad.Text) <> 0 AndAlso Not _EsPellital() Then
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
        Dim WEmpNombre = "SURFACTAN S.A."
        Dim WEmpDireccion = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit = "30-54916508-3"
        Dim WNroIb = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, WImporte, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, WPrvDireccion, WPrvCuit, WPrvIb
        Dim WBruto, WNeto, WReteIva
        Dim WCategoria
        Dim WRenglon = 0

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Direccion, Cuit, NroIb, CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        ' CAMBIAMOS INFORMACION EMPRESA SEGUN SEA O NO PELLITAL
        If _EsPellital() Then
            WEmpCuit = "30-61052459-8"
            WEmpNombre = "PELLITAL S.A."
            WEmpDireccion = "Tucumán 3275"
            WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
            WNroIb = "902-931405-2"
        End If

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WPrvDireccion = .Item("Direccion")
                    WPrvCuit = .Item("Cuit")
                    WPrvIb = .Item("NroIb")
                    WTipoIbCaba = .Item("CodIbCaba")
                    WTipoIva = Val(.Item("Iva"))

                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Dim _ProvHist As DataRow = _TraerDatosProveHistorico()

        If Not IsNothing(_ProvHist) Then
            With _ProvHist
                If Val(.Item("RetencionesRegistradas")) = 1 Then
                    WTipoIb = .Item("TipoIb")
                    WTipoIbCaba = .Item("TipoIbCaba")
                    WTipoIva = Val(.Item("TipoIva"))
                    WPorceIb = formatonumerico(.Item("PorceIb"))
                    WPorceIbCaba = formatonumerico(.Item("PorceIbCaba"))
                    WPorceIb = WPorceIb.Replace(".", ",")
                    WPorceIbCaba = WPorceIbCaba.Replace(".", ",")
                End If
            End With
        End If

        ImpreCopia(1) = "Original"
        ImpreCopia(2) = "Duplicado"

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
            .Columns.Add("Importe1").DataType = Type.GetType("System.Double")
            .Columns.Add("Porce1").DataType = Type.GetType("System.Double")
            .Columns.Add("Retencion1").DataType = Type.GetType("System.Double")
        End With

        Dim WCantFacts As Integer = gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(r.Cells("Importe").Value) <> 0)
        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To gridPagos.Rows.Count - 1

            With gridPagos.Rows(iRow)
                WLetra = .Cells(1).Value
                WTipo = .Cells(0).Value
                WPunto = .Cells(2).Value
                WNumero = .Cells(3).Value
                WImporte = .Cells(4).Value

                If Trim(WTipo) = "" Then : Exit For
                End If

                ZZClaveCtaCtePrv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

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

                WBruto = Val(WImporte)
                WNeto = WBruto / 1.21
                WReteIva = 0.0


                'If Val(WNeto) >= 1000 And Val(WNumero) <> 0 Then

                Try
                    cn.Open()
                    cm.CommandText = "SELECT ccp.Fecha, i.Iva21 FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        XImpre3 = dr.Item("Fecha")

                        If Val(WNeto) >= 1000 And Val(WNumero) <> 0 Then
                            WReteIva = dr.Item("Iva21")
                        End If

                    Else
                        XImpre3 = ""
                        WReteIva = 0
                    End If

                Catch ex As System.Exception
                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Finally

                    cn.Close()

                End Try

                'End If

                WCategoria = "SUJETO A RETENCION 0.75%"

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
                row.Item("Importe1") = Val(WNeto)
                row.Item("Porce1") = Val(WReteIva)
                row.Item("Retencion1") = Val(WReteIva)

                Tabla.Rows.Add(row)

                If Not GenerarPDF AndAlso WLimite = 15 Then

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
                    row.Item("Importe1") = Val(WNeto)
                    row.Item("Porce1") = Val(WReteIva)
                    row.Item("Retencion1") = Val(WReteIva)

                    Tabla.Rows.Add(row)

                End If

            End With

        Next

        ' Completamos los renglones faltantes.

        Dim XRenglon = WRenglon
        For WRenglon = XRenglon To WLimite

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

            If Not GenerarPDF AndAlso WLimite = 15 Then

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

            End If

        Next


        crdoc.SetDataSource(Tabla)

        crdoc.SetParameterValue("MostrarFirma", 0)

        If _EsPellital() Then
            crdoc.SetParameterValue("TipoFirma", 1)
        Else
            crdoc.SetParameterValue("TipoFirma", 0)
        End If

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, txtOrdenPago.Text & "OrdenPagoIVA.pdf", "C:/ImpreOrdenPagoTemp/")

        Else
            Dim cantImpre = IIf(WLimite = 15, 1, 2)
            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir(cantImpre)
            End With
        End If
    End Sub

    Private Sub _ImprimirComprobanteRetencionIBCiudad()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteIBCABA
        Dim ZZTipoIbCaba, ZZTipoiva, ZZPorceIbCaba As String
        Dim WEmpNombre = "SURFACTAN S.A."
        Dim WEmpDireccion = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit = "30-54916508-3"
        Dim WNroIb = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, WPrvDireccion, WPrvCuit, WPrvIb
        Dim WCategoria, WPorce1 As String
        Dim WImpoRetenido As Double
        Dim WRete As Double
        Dim WRenglon = 0

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Direccion, Cuit, NroIb, CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        ' CAMBIAMOS INFORMACION EMPRESA SEGUN SEA O NO PELLITAL
        If _EsPellital() Then
            WEmpCuit = "30-61052459-8"
            WEmpNombre = "PELLITAL S.A."
            WEmpDireccion = "Tucumán 3275"
            WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
            WNroIb = "902-931405-2"
        End If

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
                    ZZTipoIbCaba = .Item("CodIbCaba")
                    ZZTipoiva = Val(.Item("Iva"))
                    ZZPorceIbCaba = IIf(IsDBNull(.Item("PorceIbCaba")), "0", .Item("PorceIbCaba"))

                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Dim _ProvHist As DataRow = _TraerDatosProveHistorico()

        If Not IsNothing(_ProvHist) Then
            With _ProvHist
                If Val(.Item("RetencionesRegistradas")) = 1 Then
                    WTipoIb = .Item("TipoIb")
                    ZZTipoIbCaba = .Item("TipoIbCaba")
                    ZZTipoiva = Val(.Item("TipoIva"))
                    WPorceIb = formatonumerico(.Item("PorceIb"))
                    ZZPorceIbCaba = formatonumerico(.Item("PorceIbCaba"))
                    ZZPorceIbCaba = ZZPorceIbCaba.Replace(".", ",")
                End If
            End With
        End If

        ImpreCopia(1) = "Original"
        ImpreCopia(2) = "Duplicado"

        WImpoRetenido = 0

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
            .Columns.Add("Importe1").DataType = Type.GetType("System.Double")
            .Columns.Add("Porce1").DataType = Type.GetType("System.Double")
            .Columns.Add("Retencion1").DataType = Type.GetType("System.Double")
        End With

        Dim WCantFacts As Integer = gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(r.Cells("Importe").Value) <> 0)
        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To WLimite - 1

            With gridPagos.Rows(iRow)
                WLetra = .Cells(1).Value
                WTipo = .Cells(0).Value
                WPunto = .Cells(2).Value
                WNumero = .Cells(3).Value

                ZZClaveCtaCtePrv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

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

                Try
                    cn.Open()
                    cm.CommandText = "SELECT ccp.NroInterno, ccp.Fecha, ccp.Total, ccp.Saldo, i.Rechazado, i.Neto FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                    dr = cm.ExecuteReader()

                    If dr.HasRows Then

                        dr.Read()

                        XImpre3 = dr.Item("Fecha")

                    End If

                Catch ex As System.Exception
                    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Finally

                    cn.Close()

                End Try

                WImpre4 = Val(.Cells(4).Value)

                If ZZTipoiva = 2 Then
                    WImpre4 = WImpre4 / 1.21
                End If

                XImpre4 = WImpre4

                If Val(ZZPorceIbCaba) <> 0 Then
                    WRete = CDbl(XImpre4) * (CDbl(ZZPorceIbCaba) / 100)
                Else
                    If ZZTipoIbCaba = 3 Then
                        WRete = CDbl(XImpre4) * (6 / 100)
                    Else
                        WRete = CDbl(XImpre4) * (6 / 100)
                    End If
                End If

                If CDbl(XImpre4) < 300 Then
                    Continue For
                End If

                WImpoRetenido = WImpoRetenido + WRete

                If ZZPorceIbCaba <> 0 Then
                    WCategoria = "SUJETO A RETENCION " & ZZPorceIbCaba & "%"
                Else
                    If ZZTipoIbCaba = 3 Then
                        WCategoria = "SUJETO A RETENCION 6%"
                    Else
                        WCategoria = "SUJETO A RETENCION 6%"
                    End If
                End If

                If Val(ZZPorceIbCaba) <> 0 Then
                    WPorce1 = ZZPorceIbCaba
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

                If Not GenerarPDF AndAlso WLimite = 15 Then

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

                End If

            End With

        Next

        ' Completamos los renglones faltantes.

        Dim XReglon = WRenglon
        For WRenglon = XReglon To WLimite

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

            If Not GenerarPDF AndAlso WLimite = 15 Then

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

            End If

        Next

        crdoc.SetDataSource(Tabla)

        crdoc.SetParameterValue("MostrarFirma", 0)

        If _EsPellital() Then
            crdoc.SetParameterValue("TipoFirma", 1)
        Else
            crdoc.SetParameterValue("TipoFirma", 0)
        End If

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, txtOrdenPago.Text & "OrdenPagoIBCABA.pdf", "C:/ImpreOrdenPagoTemp/")

        Else

            Dim cantImpre = IIf(WLimite = 15, 1, 2)

            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir(cantImpre)
            End With

        End If
    End Sub

    Private Function _TraerDatosProveHistorico() As DataRow

        Dim tabla As New DataTable
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT ISNULL(TipoProv, 0) TipoProv, " & "ISNULL(TipoIva, 0) TipoIva, " & "ISNULL(TipoIb, 0) TipoIb, " & "ISNULL(TipoIbCaba, 0) TipoIbCaba, " & "ISNULL(PorceIb, 0) PorceIb, " & "ISNULL(PorceIbCaba, 0) PorceIbCaba, " & "ISNULL(RetencionesRegistradas, 0) RetencionesRegistradas " & "FROM Pagos WHERE Orden = '" & txtOrdenPago.Text & "' And Renglon IN ('1', '01')")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            tabla.Load(dr)

            If tabla.Rows.Count > 0 Then Return tabla.Rows(0)

            Return Nothing

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar los datos historicos de la Orden de Pago desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally


            cn.Close()



        End Try
    End Function

    Private Sub _ImprimirComprobanteRetencionIB()
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteIB
        Dim ZZTipoIb, ZZPorceIb As String
        Dim WEmpNombre = "SURFACTAN S.A."
        Dim WEmpDireccion = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit = "30-54916508-3"
        Dim WNroIb = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim WImpoRetenido As Double
        Dim ZFechaCompa = String.Join("", Trim(txtFecha.Text).Split("/").Reverse())
        Dim WRete As Double
        Dim WRenglon = 0

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Direccion, Cuit, NroIb, CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        ' CAMBIAMOS INFORMACION EMPRESA SEGUN SEA O NO PELLITAL
        If _EsPellital() Then
            WEmpCuit = "30-61052459-8"
            WEmpNombre = "PELLITAL S.A."
            WEmpDireccion = "Tucumán 3275"
            WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
            WNroIb = "902-931405-2"
        End If

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()

                    WPrvDireccion = OrDefault(.Item("Direccion"), "")
                    WPrvCuit = OrDefault(.Item("Cuit"), "")
                    WPrvIb = OrDefault(.Item("NroIb"), "")
                    ZZTipoIb = OrDefault(.Item("CodIb"), "")
                    WTipoIbCaba = OrDefault(.Item("CodIbCaba"), "")
                    WTipoIva = Val(OrDefault(.Item("Iva"), ""))
                    ZZPorceIb = OrDefault(.Item("PorceIb"), "0")

                End If
            End With

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Dim _ProvHist As DataRow = _TraerDatosProveHistorico()

        If Not IsNothing(_ProvHist) Then
            With _ProvHist
                If Val(.Item("RetencionesRegistradas")) = 1 Then
                    ZZTipoIb = .Item("TipoIb")
                    WTipoIbCaba = .Item("TipoIbCaba")
                    WTipoIva = Val(.Item("TipoIva"))
                    ZZPorceIb = formatonumerico(.Item("PorceIb"))
                    WPorceIbCaba = formatonumerico(.Item("PorceIbCaba"))
                    ZZPorceIb = ZZPorceIb.Replace(".", ",")
                End If
            End With
        End If

        ImpreCopia(1) = "Original"
        ImpreCopia(2) = "Duplicado"

        WImpoRetenido = 0

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
            .Columns.Add("Importe1").DataType = Type.GetType("System.Double")
            .Columns.Add("Porce1").DataType = Type.GetType("System.Double")
            .Columns.Add("Retencion1").DataType = Type.GetType("System.Double")
        End With

        Dim WCantFacts As Integer = gridPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(r.Cells("Importe").Value) <> 0)

        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To gridPagos.Rows.Count - 1

            With gridPagos.Rows(iRow)
                If Trim(.Cells(4).Value) <> "" Then
                    WLetra = .Cells(1).Value
                    WTipo = .Cells(0).Value
                    WPunto = .Cells(2).Value
                    WNumero = .Cells(3).Value

                    ZZClaveCtaCtePrv = txtProveedor.Text + WLetra + WTipo + WPunto + WNumero

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

                    Try
                        cn.Open()
                        cm.CommandText = "SELECT ccp.NroInterno, ccp.Fecha, ccp.Total, ccp.Saldo, i.Rechazado, i.Neto FROM CtaCtePrv as ccp, IvaComp as i WHERE ccp.Clave = '" & ZZClaveCtaCtePrv & "' AND ccp.NroInterno = i.NroInterno"

                        dr = cm.ExecuteReader()

                        If dr.HasRows Then
                            dr.Read()

                            XImpre3 = dr.Item("Fecha")

                        End If

                    Catch ex As System.Exception
                        MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                    Finally

                        cn.Close()

                    End Try

                    WImpre4 = Val(.Cells(6).Value) ' ImpoNeto
                    XImpre4 = WImpre4

                    If Val(ZFechaCompa) >= 20071201 Then
                        Select Case ZZTipoIb
                            Case 0, 1
                                WRete = CDbl(XImpre4) * (CDbl(ZZPorceIb) / 100)
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
                                row.Item("Categoria1") = IIf(Val(XImpre4) <> 0, "SUJETO A RETENCION " & CDbl(ZZPorceIb) & " %", "")
                                row.Item("Importe1") = CDbl(XImpre4)
                                row.Item("Porce1") = IIf(Val(XImpre4) <> 0, CDbl(ZZPorceIb), 0)
                                row.Item("Retencion1") = WRete

                                Tabla.Rows.Add(row)

                                If Not GenerarPDF AndAlso WLimite = 15 Then
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
                                    row.Item("Categoria1") = IIf(Val(XImpre4) <> 0, "SUJETO A RETENCION " & CDbl(ZZPorceIb) & " %", "")
                                    row.Item("Importe1") = CDbl(XImpre4)
                                    row.Item("Porce1") = IIf(Val(XImpre4) <> 0, CDbl(ZZPorceIb), 0)
                                    row.Item("Retencion1") = WRete

                                    Tabla.Rows.Add(row)
                                End If

                        End Select
                    Else
                        Select Case ZZTipoIb
                            Case 0
                                ZZPorceIb = "0,75"
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
                                row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(ZZPorceIb) & " %"
                                row.Item("Importe1") = CDbl(XImpre4)
                                row.Item("Porce1") = CDbl(ZZPorceIb)
                                row.Item("Retencion1") = WRete

                                Tabla.Rows.Add(row)

                                If Not GenerarPDF AndAlso WLimite = 15 Then
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
                                    row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(ZZPorceIb) & " %"
                                    row.Item("Importe1") = CDbl(XImpre4)
                                    row.Item("Porce1") = CDbl(ZZPorceIb)
                                    row.Item("Retencion1") = WRete

                                    Tabla.Rows.Add(row)
                                End If

                            Case Else
                                ZZPorceIb = "1,75"
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
                                row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(ZZPorceIb) & " %"
                                row.Item("Importe1") = CDbl(XImpre4)
                                row.Item("Porce1") = CDbl(ZZPorceIb)
                                row.Item("Retencion1") = WRete

                                Tabla.Rows.Add(row)

                                If Not GenerarPDF AndAlso WLimite = 15 Then
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
                                    row.Item("Categoria1") = "SUJETO A RETENCION " & CDbl(ZZPorceIb) & " %"
                                    row.Item("Importe1") = CDbl(XImpre4)
                                    row.Item("Porce1") = CDbl(ZZPorceIb)
                                    row.Item("Retencion1") = WRete

                                    Tabla.Rows.Add(row)
                                End If

                        End Select
                    End If


                End If
            End With

        Next

        ' Completamos los renglones faltantes.

        Dim XRenglon = WRenglon
        For WRenglon = XRenglon + 1 To WLimite

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

            If Not GenerarPDF AndAlso WLimite = 15 Then
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
            End If

        Next

        crdoc.SetDataSource(Tabla)

        crdoc.SetParameterValue("MostrarFirma", 0)

        If _EsPellital() Then
            crdoc.SetParameterValue("TipoFirma", 1)
        Else
            crdoc.SetParameterValue("TipoFirma", 0)
        End If

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, txtOrdenPago.Text & "OrdenPagoIB.pdf", "C:/ImpreOrdenPagoTemp/")

        Else
            Dim cantImpre = IIf(WLimite = 15, 1, 2)
            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir(cantImpre)
            End With
        End If
    End Sub

    Private Sub _ImprimirComprobanteRetencionGanancias(ByVal Total As String, ByVal Retencion As String)
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteRetGanancias
        Dim WEmpNombre = "SURFACTAN S.A."
        Dim WEmpDireccion = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit = "30-54916508-3"
        Dim WLeyenda(10) As String

        ' CAMBIAMOS INFORMACION EMPRESA SEGUN SEA O NO PELLITAL
        If _EsPellital() Then
            WEmpCuit = "30-61052459-8"
            WEmpNombre = "PELLITAL S.A."
            WEmpDireccion = "Tucumán 3275"
            WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        End If

        WLeyenda(1) = "Compra de Bienes"
        WLeyenda(2) = "Ejericio Prof. Lib. c/Aj.Inf."
        WLeyenda(3) = "Alquileres y Arrendamientos"
        WLeyenda(6) = "Locacion de Obras y/o servicios"
        WLeyenda(7) = "Transporte de Carga"
        WLeyenda(8) = "Factura M"

        Dim _DatosProv() As String = _TraerDatosProveedor()

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
            .Columns.Add("Pagado").DataType = Type.GetType("System.Double")
            .Columns.Add("Retenido").DataType = Type.GetType("System.Double")
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
            .Item("Pagado") = Val(formatonumerico(Total)) - Val(formatonumerico(Retencion))
            .Item("Pagado") = Val(formatonumerico(Total))
            .Item("Retenido") = Val(formatonumerico(Retencion))
        End With

        Tabla.Rows.Add(row)

        If Not GenerarPDF Then
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
                .Item("Pagado") = Val(formatonumerico(Total)) - Val(formatonumerico(Retencion))
                .Item("Pagado") = Val(formatonumerico(Total))
                .Item("Retenido") = Val(formatonumerico(Retencion))
            End With

            Tabla.Rows.Add(row)
        End If

        crdoc.SetDataSource(Tabla)

        crdoc.SetParameterValue("MostrarFirma", 0)

        If _EsPellital() Then
            crdoc.SetParameterValue("TipoFirma", 1)
        Else
            crdoc.SetParameterValue("TipoFirma", 0)
        End If

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, txtOrdenPago.Text & "OrdenPagoGanancias.pdf", "C:/ImpreOrdenPagoTemp/")

        Else

            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir()
            End With

        End If
    End Sub

    Private Function _TraerDatosProveedor() As String()
        Dim datos(8) As String
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT p.CertificadoGan, p.CertificadoIb, p.CertificadoIbCiudad, p.CertificadoIva, pr.Direccion, pr.Nombre, pr.Cuit, pr.Tipo " & "FROM Pagos as p, Proveedor as pr where p.Orden = '" & Trim(txtOrdenPago.Text) & "' and (p.Renglon = '01' or p.Renglon = '1') and p.Proveedor = pr.Proveedor")
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


        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



        End Try

        Return datos
    End Function

    Private Sub _ImprimirDiscriminacionDeValoresDeTerceros(ByVal XRazon As String, ByVal XCuitProveedor As String)
        Dim ZZOrden, ZZRenglon, ZZProveedor, ZZFecha, ZZNumeroCheque, ZZFechaCheque, ZZBancoCheque, ZZCuit As String
        Dim ZZImporteCheque As Double
        Dim LugarResumen = 0

        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As New OrdenPagoDiscriminacionTerceros

        _PrepararTablaOrdenPagoDiscriminacionTerceros(Tabla)

        Dim WCantFacts As Integer = gridFormaPagos.Rows.Cast(Of DataGridViewRow).Count(Function(r) Val(r.Cells(5).Value) <> 0 And Val(r.Cells(3).Value) = 3)

        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To gridFormaPagos.Rows.Count - 1
            With gridFormaPagos.Rows(iRow)
                If Val(.Cells(5).Value) <> 0 Then
                    If Val(.Cells(0).Value) = 3 Or Val(.Cells(0).Value) = 7 Then

                        ZZOrden = txtOrdenPago.Text
                        ZZRenglon = Str$(LugarResumen)
                        ZZProveedor = txtProveedor.Text
                        ZZFecha = txtFecha.Text
                        ZZImporteCheque = Val(.Cells(5).Value)
                        ZZNumeroCheque = .Cells(1).Value
                        ZZFechaCheque = .Cells(2).Value
                        ZZBancoCheque = .Cells(4).Value
                        ZZCuit = .Cells(7).Value
                        Dim ZZTipo = Val(.Cells("Tipo2").Value)

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
                            .Item("Tipo") = ZZTipo

                        End With

                        Tabla.Rows.Add(row)

                        If Not GenerarPDF AndAlso WLimite = 15 Then

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
                                .Item("Tipo") = ZZTipo
                            End With

                            Tabla.Rows.Add(row)

                        End If

                        LugarResumen = LugarResumen + 1

                    End If
                End If
            End With
        Next iRow

        ' Completamos los renglones que resten.
        For i As Integer = LugarResumen To WLimite - 1

            ZZOrden = txtOrdenPago.Text
            ZZRenglon = Str$(LugarResumen)
            ZZProveedor = txtProveedor.Text
            ZZFecha = txtFecha.Text
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
                .Item("Tipo") = 0

            End With

            Tabla.Rows.Add(row)

            If Not GenerarPDF AndAlso WLimite = 15 Then
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
                    .Item("Tipo") = 0
                End With

                Tabla.Rows.Add(row)
            End If

            LugarResumen = LugarResumen + 1

        Next i

        If Tabla.Rows.Count > 0 Then

            crdoc.SetDataSource(Tabla)

            If GenerarPDF Then

                Dim frm2 As New Util.VistaPrevia
                frm2.Reporte = crdoc

                Conexion.EmpresaDeTrabajo = "SurfactanSa"

                If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

                Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, txtOrdenPago.Text & "OrdenPagoChTerceros.pdf", "C:/ImpreOrdenPagoTemp/")

            Else

                Dim cantImpre As Short = IIf(WLimite = 15, 1, 2)

                With New VistaPrevia
                    .Reporte = crdoc
                    '.Mostrar()
                    .Imprimir(cantImpre)
                End With

            End If

        End If
    End Sub

    Private Function _DiscriminarValoreDeTerceros(ByVal Orden As String) As Boolean
        Dim discriminar = True

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Tipo2 FROM Pagos WHERE Orden = '" & ceros(Orden, 6) & "' AND ((Tipo2 = '3' Or Tipo2 = '03') OR (Tipo2 = '7' Or Tipo2 = '07'))")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If Not dr.HasRows Then
                discriminar = False
            End If

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally


            cn.Close()



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
            .Columns.Add("Importe").DataType = Type.GetType("System.Double")
            .Columns.Add("Numero")
            .Columns.Add("Fecha1")
            .Columns.Add("Banco")
            .Columns.Add("Razon")
            .Columns.Add("CuitProveedor")
            .Columns.Add("Tipo").DataType = Type.GetType("System.Int32")
        End With
    End Sub

    Private Function _TraerCuentaBanco(ByVal ClaveBanco As String) As String
        Dim ZZCuenta = ""

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Cuenta FROM Banco WHERE Banco = '" & Trim(ClaveBanco) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                ZZCuenta = Trim(dr.Item("Cuenta"))

            End If

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return ZZCuenta
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
            .Columns.Add("Importe1").DataType = Type.GetType("System.Double")
            .Columns.Add("Numero2")
            .Columns.Add("Banco2")
            .Columns.Add("Importe2").DataType = Type.GetType("System.Double")
            .Columns.Add("Fecha2")
            .Columns.Add("Neto").DataType = Type.GetType("System.Double")
            .Columns.Add("Rete1").DataType = Type.GetType("System.Double")
            .Columns.Add("Rete2").DataType = Type.GetType("System.Double")
            .Columns.Add("Total").DataType = Type.GetType("System.Double")
            .Columns.Add("Observaciones")
            .Columns.Add("Empresa")
            .Columns.Add("Cuit")
            .Columns.Add("Paridad").DataType = Type.GetType("System.Double")
        End With
    End Sub

    Private Sub lstSeleccion_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstSeleccion.MouseClick
        If Trim(lstSeleccion.SelectedItem) = "" Then : Exit Sub
        End If

        If Trim(lstSeleccion.SelectedItem) <> "" Then

            With lstSeleccion

                _TipoConsulta = .SelectedIndex

                Select Case .SelectedIndex
                    Case 0
                        'CHEQUEAMOS QUE SI EL BOTON ESTA ACTIVO NO PUEDE CAMBIAR EL PROVEEDOR
                        If btn_ConsultaSoliFondos.Visible = False Then
                            _ListarProveedores()
                        End If
                    Case 1
                        'CHEQUEAMOS QUE SI EL BOTON ESTA ACTIVO NO PUEDE SELECCIONAR CUENTA CORRIENTE
                        If btn_ConsultaSoliFondos.Visible = False Then
                            _ListarCtasCtes()
                        End If
                    Case 2
                        _ListarChequesTerceros()
                    Case 3
                        _ListarDocumentos()
                    Case 4
                        'CHEQUEAMOS QUE SI EL BOTON ESTA ACTIVO NO PUEDE SELECCIONAR CUENTA 
                        If btn_ConsultaSoliFondos.Visible = False Then
                            _ListarCuentasContables()
                        End If
                End Select

            End With

            txtConsulta.Focus()

        End If
    End Sub

    Private Sub CLBFiltrado_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles CLBFiltrado.MouseClick
        If Trim(CLBFiltrado.SelectedItem) = "" Then
            Exit Sub
        End If

        If Not IsNothing(_TipoConsulta) Then
            Dim indice As Integer = Nothing
            Try
                indice = lstConsulta.FindStringExact(CLBFiltrado.SelectedItem.ToString)
            Catch ex As System.Exception

            End Try

            Select Case _TipoConsulta
                Case 0
                    mostrarProveedor(CLBFiltrado.SelectedItem.ToString)
                    btnCtaCte_Click(Nothing, Nothing)
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

    Private Sub lstConsulta_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstConsulta.MouseClick

        If Trim(_TipoConsulta) = "" Then
            Exit Sub
        End If

        If Not IsNothing(_TipoConsulta) Then

            Select Case _TipoConsulta
                Case 0
                    mostrarProveedor(lstConsulta.SelectedItem.ToString)
                    btnCtaCte_Click(Nothing, Nothing)
                    btn_ConsultaSoliFondos.Visible = False
                Case 1
                    ' Ctas Ctes
                    If Trim(lstConsulta.SelectedItem) = "" Or Not optCtaCte.Checked Then
                        Exit Sub
                    End If

                    _TraerCtaCte(lstConsulta.SelectedItem, lstConsulta.SelectedIndex)
                    btn_ConsultaSoliFondos.Visible = False
                Case 2
                    If Trim(lstConsulta.SelectedItem) = "" Then
                        Exit Sub
                    End If

                    _TraerChequeDeTercero(lstConsulta.SelectedItem, lstConsulta.SelectedIndex)

                Case 5
                    If Trim(lstConsulta.SelectedItem) = "" Then
                        Exit Sub
                    End If

                    _TraerSolicitudFondos(lstConsulta.SelectedItem, lstConsulta.SelectedIndex)
                    'CAMBIO PROVEEDOR A SOLO LECTURA QUE NO LO CAMBIEN
                    txtProveedor.ReadOnly = True
                    btn_ConsultaSoliFondos.Visible = True

                    btnConsulta_Click(Nothing, Nothing)
                    btn_ConsultaSoliFondos_Click(Nothing, Nothing)

                Case Else
                    btn_ConsultaSoliFondos.Visible = False
                    Exit Sub
            End Select

        End If
    End Sub


    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtOrdenPago.KeyPress, txtProveedor.KeyPress, txtBanco.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFechaAux_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFechaAux.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            'Debug.Print(_ValidarFecha(Trim(txtFechaAux.Text)))

            If Len(Trim(txtFechaAux.Text)) = 6 Then

                Dim _mes As String = Mid(txtFechaAux.Text, 4, 2)

                If Val(_mes) < Date.Now.Month Then
                    txtFechaAux.Text = Mid(txtFechaAux.Text, 1, 2) & "/" & _mes & "/" & Date.Now.AddYears(1).ToString("yyyy")
                Else
                    txtFechaAux.Text = Mid(txtFechaAux.Text, 1, 2) & "/" & _mes & "/" & Date.Now.ToString("yyyy")
                End If

            End If

            If _ValidarFecha(Trim(txtFechaAux.Text)) And WRow >= 0 And Wcol >= 0 Then

                With gridFormaPagos

                    .Rows(WRow).Cells(2).Value = txtFechaAux.Text



                    If Trim(.Rows(WRow).Cells(3).Value) <> "" Then
                        .CurrentCell = .Rows(WRow).Cells(5)
                    Else
                        .CurrentCell = .Rows(WRow).Cells(3)
                    End If

                    .Focus()

                    txtFechaAux.Visible = False
                    txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If
    End Sub

    Private Sub gridRecibos_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles gridFormaPagos.CellClick
        With gridFormaPagos
            If e.ColumnIndex = 2 Then

                gridRecibos_CellEnter(sender, e)



            End If
        End With
    End Sub

    Private Sub gridRecibos_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles gridFormaPagos.CellEnter
        With gridFormaPagos
            Dim fila As Integer = e.RowIndex
            If .Rows(fila).Cells(0).Value <> "3" Then
                If e.ColumnIndex = 2 Then

                    Dim iRow, iCol As Integer
                    iRow = e.RowIndex
                    iCol = e.ColumnIndex

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

                End If
            End If

        End With
    End Sub

    Private Sub btnCalcular_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalcular.Click
        Dim tabla = New DataTable("Detalles")
        Dim DiasTasa = ""
        _PedirInformacion("Informe la tasa Mensual", DiasTasa)

        Dim ZZSuma As Double = 0

        Dim FechaBase As String = txtFecha.Text

        Dim row As DataRow
        Dim crdoc As ReportDocument
        crdoc = New InformeIntereses

        ' Creo las Columnas
        _PrepararTablaIntereses(tabla)

        ' Lleno la tabla con la informacion del Recibo.
        For i = 0 To gridFormaPagos.Rows.Count - 1

            With gridFormaPagos.Rows(i)

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
            .Columns.Add("Importe").DataType = Type.GetType("System.Double")
            .Columns.Add("Dias")
            .Columns.Add("Tasa")
            .Columns.Add("Intereses").DataType = Type.GetType("System.Double")
        End With
    End Sub

    Private Sub _VistaPrevia(ByVal crdoc As ReportDocument)
        With VistaPrevia
            .Reporte = crdoc
            .Mostrar()
        End With
    End Sub

    Private Sub gridFormaPagos_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles gridFormaPagos.CellMouseDoubleClick

        'Dim iRow As DataGridViewRow

        'iRow = gridFormaPagos.Rows(e.RowIndex)

        'If MsgBox("¿Está seguro de querer eliminar la fila?", MsgBoxStyle.YesNo, MsgBoxStyle.Information) = DialogResult.No Then
        '    Exit Sub
        'End If

        'gridFormaPagos.Rows.Remove(iRow)
    End Sub

    Private Sub _RecalcularRetenciones()

        txtGanancias.Text = "0.00"
        txtIBCiudad.Text = "0.00"
        txtIngresosBrutos.Text = "0.00"
        txtIVA.Text = "0.00"
        txtTotal.Text = "0.00"

        If optCtaCte.Checked Or optAnticipos.Checked Then
            If Not ckNoCalcRetenciones.Checked Then
                ' Recalculo de Retenciones de Ganancias.
                _RecalcularRetencionGanancias()

                ' Recalculo de Retenciones por Iva.
                _RecalcularRetencionIVA()

                ' Recalculo IB Provincia
                _RecalcularIBProvincia()

                ' PELLITAL NO RETIENE EN CABA
                If Not _EsPellital() Then
                    ' Recalculo IB CABA
                    _RecalcularIBCABA()
                End If

                txtTotal.Text = formatonumerico(Val(formatonumerico(txtIVA.Text)) + Val(formatonumerico(txtGanancias.Text)) + Val(formatonumerico(txtIBCiudad.Text)) + Val(formatonumerico(txtIngresosBrutos.Text)))

                'sumarImportes()
            End If
        End If
        'sumarImportes()
    End Sub

    Private Sub _RecalcularIBCABA()


        Dim ZZSuma, acumCaba

        acumCaba = 0.0

        If Val(WPorceIbCaba) <> 0 And Val(WTipoIbCaba) <> 2 Then

            For Each row As DataGridViewRow In gridPagos.Rows
                With row
                    If Trim(.Cells(4).Value) <> "" Then

                        ZZSuma = Val(.Cells(4).Value) / 1.21

                        acumCaba += CaculoRetencionIngresosBrutosCaba(Val(WTipoIbCaba), Val(formatonumerico(WPorceIbCaba)), Val(ZZSuma))
                    Else
                        Exit For
                    End If
                End With
            Next

        End If

        txtIBCiudad.Text = _NormalizarNumero(acumCaba)
    End Sub

    Private Sub _RecalcularIBProvincia()
        Dim acumProv

        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma
        Dim ZFactura As DataRow

        acumProv = 0

        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                If Trim(.Cells(4).Value) <> "" Then

                    ZZSuma = 0.0

                    ' Recalculo sobre porcentaje neto en Iva Comp.
                    If Trim(.Cells(4).Value) <> "" Then
                        ZTipo = .Cells(0).Value
                        ZLetra = .Cells(1).Value
                        ZPunto = .Cells(2).Value
                        ZNumero = .Cells(3).Value
                        ZImporte = _NormalizarNumero(.Cells(4).Value)

                        ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZPunto, ZLetra, ZNumero)

                        If Not IsNothing(ZFactura) Then

                            ZNeto = _NormalizarNumero(ZFactura.Item("Neto"))

                            ZIva = _NormalizarNumero(ZFactura.Item("Iva21"))
                            ZIva5 = _NormalizarNumero(ZFactura.Item("Iva5"))
                            ZIva27 = _NormalizarNumero(ZFactura.Item("Iva27"))
                            ZIva105 = _NormalizarNumero(ZFactura.Item("Iva105"))
                            ZIb = _NormalizarNumero(ZFactura.Item("Ib"))
                            ZExento = _NormalizarNumero(ZFactura.Item("Exento"))

                            ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento

                            If Val(_NormalizarNumero(ZImporte)) = Val(_NormalizarNumero(ZTotal)) Then

                                ZZSuma = ZNeto

                            Else

                                ZPorce = Val(ZImporte) / ZTotal

                                ZZSuma = ZNeto * ZPorce
                            End If

                        Else

                            ZZSuma = Val(ZImporte) / 1.21

                        End If

                    End If

                    acumProv += CaculoRetencionIngresosBrutos(Val(WTipoIb), Val(formatonumerico(WPorceIb)), Val(ZZSuma))
                Else
                    Exit For
                End If
            End With
        Next

        txtIngresosBrutos.Text = _NormalizarNumero(acumProv)
    End Sub

    Private Function _BuscarCompra(ByVal proveedor, ByVal ztipo, ByVal zpunto, ByVal zletra, ByVal znumero)
        Dim compra As New DataTable
        Dim cn = New SqlConnection()
        Dim cm As New SqlCommand("SELECT Neto, Iva21, Iva5, Iva27, Iva105, Ib, Exento, ISNULL(MarcaDifCambio, 0) As MarcaDifCambio FROM IvaComp WHERE Proveedor = '" & proveedor & "' and letra = '" & zletra & "' and punto = '" & ceros(zpunto, 4) & "' and numero = '" & ceros(znumero, 8) & "' and tipo = '" & ceros(ztipo, 2) & "'")
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

        Catch ex As System.Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return Nothing
    End Function

    Private Sub _RecalcularRetencionGanancias()
        Dim ZZBase As Object = _CalcularSaldoBaseRetencionesGanancias()

        Dim varRetGan = CaculoRetencionGanancia(Val(WTipoProv), ZZBase, varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva)

        txtGanancias.Text = _NormalizarNumero(varRetGan)
    End Sub

    Private Function _CalcularSaldoBaseRetencionesGanancias() As Object

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

        Dim ZZBase, ZZSumaNeto

        ZZBase = 0.0
        ZZSumaNeto = 0.0

        ' Recalculo sobre porcentaje neto en Iva Comp.
        For Each row As DataGridViewRow In gridPagos.Rows
            With row
                Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal
                Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma
                Dim ZFactura As DataRow

                If Trim(.Cells(4).Value) <> "" Then
                    ZTipo = .Cells(0).Value
                    ZLetra = .Cells(1).Value
                    ZPunto = .Cells(2).Value
                    ZNumero = .Cells(3).Value
                    ZImporte = .Cells(4).Value

                    ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZPunto, ZLetra, ZNumero)

                    If Not IsNothing(ZFactura) Then

                        ZNeto = _NormalizarNumero(ZFactura.Item("Neto"))
                        ZIva = _NormalizarNumero(ZFactura.Item("Iva21"))
                        ZIva5 = _NormalizarNumero(ZFactura.Item("Iva5"))
                        ZIva27 = _NormalizarNumero(ZFactura.Item("Iva27"))
                        ZIva105 = _NormalizarNumero(ZFactura.Item("Iva105"))
                        ZIb = _NormalizarNumero(ZFactura.Item("Ib"))
                        ZExento = _NormalizarNumero(ZFactura.Item("Exento"))

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
        Return ZZBase
    End Function

    Private Sub _RecalcularRetencionIVA()
        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte
        Dim ZNeto, ZZSuma, ZZBase
        Dim ZFactura As DataRow

        ZZBase = 0

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

                        If ZNeto >= 1000 Then

                            ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZPunto, ZLetra, ZNumero)

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

    Private Function _NormalizarNumero(ByVal znumero As Object, Optional ByVal decimales As Integer = 2)
        If IsDBNull(znumero) Then
            znumero = ""
        End If
        Return Val(formatonumerico(Trim(znumero), decimales))
    End Function

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCuenta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCuenta.Text) = "" Then : Exit Sub
            End If

            Dim valida = False

            Dim cn = New SqlConnection()
            Dim cm = New SqlCommand("SELECT Cuenta FROM Cuenta WHERE Cuenta = '" & Val(txtCuenta.Text) & "'")
            Dim dr As SqlDataReader

            Try
                cn.ConnectionString = _CS()
                cn.Open()
                cm.Connection = cn
                dr = cm.ExecuteReader()

                valida = dr.HasRows

            Catch ex As System.Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            Finally


                cn.Close()



            End Try

            If valida And WRowVarios >= 0 Then

                WCuenta(WRowVarios, WProceso.Text) = txtCuenta.Text
                txtCuenta.Text = ""
                pnlPedirCuenta.Visible = False


                Select Case Val(WProceso.Text)
                    Case 1
                        Try
                            gridPagos.CurrentCell = gridPagos.Rows(WRowVarios + 1).Cells(0)
                        Catch ex As System.Exception
                            gridPagos.CurrentCell = gridPagos.Rows(WRowVarios).Cells(0)
                        End Try

                        gridPagos.Focus()
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

    Private Function _BuscarCambioDiviza(ByVal ZZFecha As String) As Double
        Dim ZCambioDivisa = 0.0

        Dim cn = New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _CS()
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "SELECT Cambio, CambioDivisa FROM Cambios WHERE Fecha = '" & ZZFecha.Substring(0, 10) & "'"

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

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos.")
        Finally

            cn.Close()

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

    Private Sub btnDifeCambio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDifeCambio.Click
        Dim ZCambioDivisa, ZZParidadOP, ZZParidad As Double
        Dim ZZCicloDia As Integer
        Dim XTipo2, ZZNumero2, ZZFecha2 As String
        Dim ZZFechaAnterior As String

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim trans As SqlTransaction = Nothing

        cn.ConnectionString = _CS()
        cm.Connection = cn

        Try
            ZCambioDivisa = _BuscarCambioDiviza(txtFecha.Text)
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If ZCambioDivisa = 0 Then
            MsgBox("La fecha " + txtFecha.Text + " no tiene informado paridad", "Emision de Ordenes de Pago", MsgBoxStyle.Information)
            Exit Sub
        End If

        ZZParidadOP = ZCambioDivisa

        For Each row As DataGridViewRow In gridFormaPagos.Rows

            XBanco2 = ""
            XImporte2 = 0.0

            With row
                If Not IsNothing(.Cells(5)) Then
                    If Val(.Cells(5).Value) <> 0 Then

                        XTipo2 = .Cells(0).Value
                        ZZNumero2 = .Cells(1).Value
                        ZZFecha2 = .Cells(2).Value
                        XBanco2 = .Cells(3).Value
                        XImporte2 = Val(.Cells(5).Value)
                        Dim ZZFecha = ZZFecha2

                        Select Case Val(XTipo2)
                            Case 2, 3, 7

                                ZZCicloDia = 0

                                Do
                                    Try
                                        ZCambioDivisa = _BuscarCambioDiviza(ZZFecha2)
                                    Catch ex As System.Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        Exit Sub
                                    End Try

                                    ZZFechaAnterior = ZZFecha2

                                    If ZCambioDivisa = 0 Then

                                        ZZCicloDia = ZZCicloDia + 1
                                        If ZZCicloDia = 15 Then
                                            ' ReSharper disable once RedundantAssignment
                                            ZZFecha2 = ZZFechaAnterior
                                            Exit Do
                                        End If

                                        ZZFecha2 = _CalculaVencimiento(ZZFecha2, 2)

                                    Else

                                        Exit Do

                                    End If
                                Loop

                                If ZCambioDivisa = 0 Then
                                    MsgBox("La fecha " + ZZFecha + " no tiene informado paridad", MsgBoxStyle.Information)
                                    Exit Sub
                                End If
                                ZZParidad = ZCambioDivisa

                            Case Else

                                ZZParidad = ZZParidadOP

                        End Select

                        Dim ZSql = ""
                        ZSql = ZSql + "UPDATE Pagos SET "
                        ZSql = ZSql + " ImpoList = " + "'" + Str$(ZZParidad) + "',"
                        ZSql = ZSql + " ImpoListFecha = " + "'" + Date.Now.ToString("dd/MM/yyyy") + "'"
                        ZSql = ZSql + " Where Orden = '" & txtOrdenPago.Text & "' AND (Tipo2 = '" & Val(XTipo2) & "' OR Tipo2 = '" & ceros(XTipo2, 2) & "') AND Numero2 = '" & ZZNumero2 & "'" ' AND Fecha2 = '" & XFecha2 & "'" ' + "'" + WClavesOP(row.Index) + "'"


                        Try
                            cn.Open()
                            trans = cn.BeginTransaction

                            cm.CommandText = ZSql
                            cm.Transaction = trans
                            cm.ExecuteNonQuery()
                            trans.Commit()
                        Catch ex As System.Exception

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

        Dim ImprimeParidad As Boolean = _ConsultaImprecionDeParidad()

        With New VistaPrevia
            .Reporte = New AnalisisDiferenciaCambioOP
            .Reporte.SetParameterValue(0, ImprimeParidad)
            .Formula = "{Pagos.Orden} IN '" & txtOrdenPago.Text & "' TO '" & txtOrdenPago.Text & "' AND {Pagos.Impolist} <> 0 AND {Pagos.TipoReg} IN '2' TO '2' And {Pagos.Proveedor} = '" & txtProveedor.Text & "'"
            .Mostrar()
            '.Imprimir()
        End With
    End Sub

    Private Function _ConsultaImprecionDeParidad() As Boolean
        Dim ParidadInicial, ParidadAComparar As Double
        Dim ZZFecha As String
        Dim ZZNumero As String
        Dim ZZTipo As String
        Dim ZZPunto As String
        Dim ZZLetra As String
        Dim proveedor As String

        For i As Integer = 0 To 14
            ZZNumero = gridPagos.Rows(i).Cells("Numero").Value
            ZZTipo = gridPagos.Rows(i).Cells("Tipo").Value
            ZZPunto = gridPagos.Rows(i).Cells("Punto").Value
            proveedor = txtProveedor.Text
            ZZLetra = gridPagos.Rows(i).Cells("Letra").Value
            If (i = 0) Then
                ZZFecha = _BuscarFechaFacturaPorProv(ZZTipo, ZZPunto, ZZLetra, proveedor, ZZNumero)
                ParidadInicial = _BuscarCambioDiviza(ZZFecha)
            Else
                ZZFecha = _BuscarFechaFacturaPorProv(ZZTipo, ZZPunto, ZZLetra, proveedor, ZZNumero)
                ParidadAComparar = _BuscarCambioDiviza(ZZFecha)
                If (ParidadAComparar <> ParidadInicial) Then
                    Return True
                End If
            End If
        Next

        Return False

    End Function

    Private Sub txtFechaAux_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtFechaAux.Leave
        If WRow >= 0 And Wcol >= 0 Then
            If Trim(txtFechaAux.Text.Replace("/", "")) <> "" And Trim(txtFechaAux.Text).Length = 10 Then

                With gridFormaPagos

                    .Rows(WRow).Cells(2).Value = txtFechaAux.Text


                    If Trim(.Rows(WRow).Cells(3).Value) <> "" Then
                        .CurrentCell = .Rows(WRow).Cells(5)
                    Else
                        .CurrentCell = .Rows(WRow).Cells(3)
                    End If

                    .Focus()

                End With
            Else
                With gridFormaPagos
                    .Rows(WRow).Cells(2).Value = txtFechaAux.Text
                End With
            End If

            txtFechaAux.Visible = False
            txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        _RecalcularRetenciones()
    End Sub

    Private Sub gridFormaPagos_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles gridFormaPagos.RowHeaderMouseDoubleClick

        If MsgBox("¿Está seguro de querer eliminar los datos de la fila?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        _RemoverFilaFormaPagos(e.RowIndex)
    End Sub

    Private Sub _RemoverFilaFormaPagos(ByVal e As Integer)

        With gridFormaPagos
            .Rows.Remove(.Rows(e))
            .Rows.Add("", "", "", "", "", "", "", "", "")
        End With
    End Sub

    Private Sub gridPagos_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles gridPagos.RowHeaderMouseDoubleClick

        If MsgBox("¿Está seguro de querer eliminar los datos de la fila?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        _RemoverFilaPagos(e.RowIndex)
    End Sub

    Private Sub _RemoverFilaPagos(ByVal e As Integer)

        With gridPagos
            .Rows.Remove(.Rows(e))
            .Rows.Add("", "", "", "", "", "", "")
        End With
    End Sub

    Private Sub txtGanancias_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtGanancias.TextChanged, txtIBCiudad.TextChanged, txtIngresosBrutos.TextChanged, txtIVA.TextChanged, txtTotal.TextChanged
        For Each txt As TextBox In {txtGanancias, txtIBCiudad, txtIngresosBrutos, txtIVA, txtTotal}
            txt.Text = formatonumerico(txt.Text)
        Next
    End Sub

    Private Sub ckNoCalcRetenciones_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ckNoCalcRetenciones.CheckedChanged, ckNoCalcRetenciones.CheckStateChanged
        _RecalcularRetenciones()
    End Sub

    Private Sub gridPagos_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles gridPagos.Enter, gridFormaPagos.Enter
        WGrillaReferencia = CType(sender, DataGridView)
    End Sub

    Private Sub btnEliminarFila_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminarFila.Click
        If Not IsNothing(WGrillaReferencia) Then

            'MsgBox("Grilla: " & WGrillaReferencia.Name & "  Fila: " & WGrillaReferencia.CurrentRow.Index)

            If MsgBox("¿Está seguro de querer limpiar la fila?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            With WGrillaReferencia
                Select Case .Name
                    Case "gridPagos"
                        _RemoverFilaPagos(.CurrentRow.Index)
                    Case "gridFormaPagos"
                        _RemoverFilaFormaPagos(.CurrentRow.Index)
                    Case Else
                        Exit Sub
                End Select
            End With

        End If
    End Sub

    Private Sub btnEnviarAviso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviarAviso.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim WOrdenPago As DataTable = _TraerDatosOrdenPago(txtOrdenPago.Text)
            Dim EsPorTransferencia As Boolean
            Dim WProveedor As String

            If WOrdenPago.Rows.Count > 0 Then
                Dim WFechasTransferencias = ""
                Dim WFechasECheques = ""
                Dim WFechasCompensaciones As String = ""
                Dim WHayECheques As Boolean
                Dim WHayCompensaciones As Boolean

                EsPorTransferencia = GetEsPorTransferencia(WOrdenPago, WFechasTransferencias, WHayECheques, WFechasECheques, WHayCompensaciones, WFechasCompensaciones)

                With WOrdenPago.Rows(0)

                    WProveedor = OrDefault(.Item("Proveedor"), "")
                    Dim WDescProveedor = OrDefault(.Item("Nombre"), "")

                    If Trim(WProveedor) <> "" Then

                        WFechasTransferencias = WFechasTransferencias.TrimEnd(",")

                        If Helper._EsPellital Then
                            _EnviarAvisoOPDisponiblePellital(WProveedor, WDescProveedor, txtOrdenPago.Text, EsPorTransferencia, WFechasTransferencias, HayECheques:=WHayECheques, FechasECheques:=WFechasECheques)
                        Else
                            _EnviarAvisoOPDisponible(WProveedor, WDescProveedor, txtOrdenPago.Text, EsPorTransferencia, WFechasTransferencias, HayECheques:=WHayECheques, FechasECheques:=WFechasECheques, WHayCompensaciones:=WHayCompensaciones, WFechasCompensaciones:=WFechasCompensaciones)
                        End If

                        MsgBox("¡Aviso enviado correctamente!", MsgBoxStyle.Information)

                    End If

                End With

            End If

        Catch ex As System.Exception
            MsgBox(ex.Message)
            txtOrdenPago.Focus()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Function GetEsPorTransferencia(ByVal WOrdenPago As DataTable, ByRef WFechasTransferencias As String, ByRef WHayECheques As Boolean, ByRef FechasECheques As String, ByRef WHayCompensaciones As Boolean, ByRef WFechasCompensaciones As String) As Boolean
        Dim EsPorTransferencia = False
        WHayECheques = False

        For Each row As DataRow In WOrdenPago.Rows

            With row

                Dim WTipo2 = OrDefault(.Item("Tipo2"), "00")

                Select Case Val(WTipo2)
                    Case 2

                        EsPorTransferencia = Val(OrDefault(.Item("Numero2"), "")) = 0

                        If EsPorTransferencia And Not WFechasTransferencias.Contains(OrDefault(.Item("Fecha2"), "")) Then
                            WFechasTransferencias &= OrDefault(.Item("Fecha2"), "") & ","
                        End If

                    Case 6
                        EsPorTransferencia = Val(OrDefault(.Item("Cuenta"), "00")) = 5

                        WHayCompensaciones = Val(OrDefault(.Item("Cuenta"), "00")) = 5

                        If WHayCompensaciones And Not WFechasCompensaciones.Contains(OrDefault(.Item("Fecha2"), "")) Then
                            WFechasCompensaciones &= OrDefault(.Item("Fecha2"), "") & ","
                        End If

                        If EsPorTransferencia Then Exit For
                    Case 3
                    Case 7
                        WHayECheques = True

                        If Not FechasECheques.Contains(OrDefault(.Item("Fecha2"), "")) Then
                            FechasECheques &= OrDefault(.Item("Fecha2"), "") & ","
                        End If

                    Case Else
                        EsPorTransferencia = False
                End Select


            End With
        Next
        Return EsPorTransferencia
    End Function

    Private Function _TraerDatosOrdenPago(ByVal OrdenPago As String) As DataTable

        Dim tabla As New DataTable

        Using cn As New SqlConnection

            cn.ConnectionString = _ConectarA()
            cn.Open()

            Using cm As New SqlCommand()
                cm.Connection = cn
                cm.CommandText = "SELECT pr.Nombre, p.Proveedor, p.Fecha2, p.Tipo2, p.Importe2, p.Numero2, p.Importe, p.Cuenta FROM Pagos p INNER JOIN Proveedor pr ON pr.Proveedor = p.Proveedor WHERE p.Orden = '" & OrdenPago & "' and p.TipoReg IN ('02', '2') Order by p.Tipo2"

                Using dr As SqlDataReader = cm.ExecuteReader

                    If dr.HasRows Then
                        tabla.Load(dr)
                    End If

                End Using
            End Using
        End Using

        Return tabla
    End Function

    Private Sub _EnviarAvisoOPDisponible(ByVal Proveedor As String, ByVal DescProveedor As String, Optional ByVal OrdenPago As String = "", Optional ByVal EsPorTransferencia As Boolean = False, Optional ByVal wFechasTransferencias As String = "", Optional ByVal PorTransferenciaYCheques As Boolean = False, Optional ByVal HayECheques As Boolean = False, Optional ByVal FechasECheques As String = "", Optional ByVal WHayCompensaciones As Boolean = False, Optional ByVal WFechasCompensaciones As String = "")

        If Proveedor.Trim = "" Then Exit Sub
        If EsPorTransferencia And Trim(OrdenPago) = "" Then Exit Sub

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT ISNULL(MailOP, '') MailOP FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Dim WMailOp As String = dr.Item("MailOp")

                If WMailOp.Trim = "" Then
                    Throw New System.Exception("El Proveedor no posee un mail asociado para que se envíen avisos de OP.")
                End If

                Dim WBody As String

                If EsPorTransferencia Then

                    'WBody = "Informamos que durante el transcurso del día de hoy, SURFACTAN S.A. le realizará una transferencia"
                    WBody = "Informamos que durante el transcurso del día de hoy, SURFACTAN S.A. le realizará un pago mediante los siguientes métodos de pagos: " & "<br/>"

                    If Not WHayCompensaciones Then

                        WBody &= "<br/>" & "- Transferencia Bancaria"

                        If wFechasTransferencias.Trim <> "" Then

                            If wFechasTransferencias.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & wFechasTransferencias & "</strong>."

                        End If

                    End If

                    If HayECheques Then

                        'WBody &= vbCrLf & "Además, través de Cheque(s) Electrónico(s)"
                        WBody &= "<br/>" & "- Cheque(s) Electrónico(s)"

                        If FechasECheques.Trim <> "" Then

                            If FechasECheques.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & FechasECheques.TrimEnd(",") & "</strong>"

                        End If

                    End If

                    If WHayCompensaciones Then

                        WBody &= "<br/>" & "- Compensación de Pago"

                        If WFechasCompensaciones.Trim <> "" Then

                            If WFechasCompensaciones.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & WFechasCompensaciones & "</strong>."

                        End If

                    End If

                ElseIf HayECheques Then

                    'WBody = "Informamos que en el día de la fecha, SURFACTAN S.A. le ha realizado un pago a través de Cheque(s) Electrónico(s)"
                    WBody = "Informamos que en el día de la fecha, SURFACTAN S.A. le ha realizado un pago mediante los siguientes metodos de pago:" & "<br/>"

                    WBody &= "<br/>" & "- Cheque(s) Electrónico(s)"

                    If FechasECheques.Trim <> "" Then

                        If FechasECheques.Split(",").Count > 1 Then
                            WBody &= " con las siguientes fechas: "
                        Else
                            WBody &= " con fecha: "
                        End If

                        WBody &= "<strong>" & FechasECheques & "</strong>"

                    End If

                    If WHayCompensaciones Then

                        WBody &= "<br/>" & "- Compensación de Pago"

                        If WFechasCompensaciones.Trim <> "" Then

                            If WFechasCompensaciones.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & WFechasCompensaciones & "</strong>."

                        End If

                    End If

                    If PorTransferenciaYCheques Then
                        'WBody &= "<br/>" & "- Cheque(s) que deberá retirar por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir del día de <strong>mañana</strong>, los <strong>Martes y Juevess</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>."
                        WBody &= "<br/>" & "- Cheque(s) que deberá retirar por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los días <strong>Martes y Juevess</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>."
                        'WBody &= "." & "<br/>" & "<br/>" & "Además tiene Cheque(s) para retirar por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los <strong>Martes y Juevess</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>"
                    Else
                        WBody &= "." & "<br/>" & "<br/>" & "Adjuntamos Orden de Pago y retenciones si correspondiesen."
                    End If

                Else

                    WBody = "Informamos que se encuentra a su disposición un pago que podrá ser retirado por nuestras oficinas <em>(Malvinas Argentinas 4495, B1644CAQ Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los días <strong>Martes y Jueves</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>"

                End If

                If Trim(DescProveedor) <> "" Then
                    WBody = "Sres. <strong>" & DescProveedor.Trim.ToUpper & "</strong> <br/>" & "<br/>" & WBody
                End If

                Select Case Proveedor

                    Case "10167878480", "10000000100", "10071081483", "10069345023", "10066352912", "10023969933", "10014123562"
                        WBody = WBody & "<br/>" & "<br/>" & "En caso de cualquier consulta, por favor dirigirla a <strong><em>facturacion@surfactan.com.ar</em></strong> o <strong><em>biglesias@surfactan.com.ar</em></strong>"
                End Select

                Dim WAdjuntos As New List(Of String)

                If (EsPorTransferencia Or HayECheques) And Not PorTransferenciaYCheques Then
                    WAdjuntos = _PrepararAdjuntos(OrdenPago)
                End If

                For Each wAdjunto As String In WAdjuntos
                    If Not File.Exists(wAdjunto) Then
                        Throw New System.Exception("No existe el archivo " & wAdjunto)
                    End If
                Next

                '_EnviarEmail(WMailOp, "mlarias@surfactan.com.ar", "Orden de Pago - SURFACTAN S.A. - ", WBody, WAdjuntos.ToArray)
                _EnviarEmail(WMailOp, "", "Orden de Pago - SURFACTAN S.A. - ", WBody, WAdjuntos.ToArray)

                _MarcarOPComoEnviada(OrdenPago)

            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer procesar el envío de mail por OP Disponible." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try
    End Sub

    Private Sub _EnviarAvisoOPDisponiblePellital(ByVal Proveedor As String, ByVal DescProveedor As String, Optional ByVal OrdenPago As String = "", Optional ByVal EsPorTransferencia As Boolean = False, Optional ByVal wFechasTransferencias As String = "", Optional ByVal PorTransferenciaYCheques As Boolean = False, Optional ByVal HayECheques As Boolean = False, Optional ByVal FechasECheques As String = "")

        If Proveedor.Trim = "" Then Exit Sub
        If EsPorTransferencia And Trim(OrdenPago) = "" Then Exit Sub

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT ISNULL(MailOP, '') MailOP FROM Proveedor WHERE Proveedor = '" & Proveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                Dim WMailOp As String = dr.Item("MailOp")

                If WMailOp.Trim = "" Then
                    Throw New System.Exception("El Proveedor no posee un mail asociado para que se envíen avisos de OP.")
                End If

                Dim WBody As String

                If EsPorTransferencia Then

                    WBody = "Informamos que durante el transcurso del día de hoy, PELLITAL S.A. le realizará una transferencia"

                    If wFechasTransferencias.Trim <> "" Then

                        If wFechasTransferencias.Split(",").Count > 1 Then
                            WBody &= " con las siguientes fechas: "
                        Else
                            WBody &= " con fecha: "
                        End If

                        WBody &= "<strong>" & wFechasTransferencias & "</strong>"

                    End If

                    If HayECheques Then

                        WBody &= " y a través de Cheque(s) Electrónico(s)"

                        If FechasECheques.Trim <> "" Then

                            If FechasECheques.Split(",").Count > 1 Then
                                WBody &= " con las siguientes fechas: "
                            Else
                                WBody &= " con fecha: "
                            End If

                            WBody &= "<strong>" & FechasECheques.TrimEnd(",") & "</strong>"

                        End If

                    End If

                ElseIf HayECheques Then

                    WBody = "Informamos que en el día de la fecha, PELLITAL S.A. le ha realizado un pago a través de Cheque(s) Electrónico(s)"

                    If FechasECheques.Trim <> "" Then

                        If FechasECheques.Split(",").Count > 1 Then
                            WBody &= " con las siguientes fechas: "
                        Else
                            WBody &= " con fecha: "
                        End If

                        WBody &= "<strong>" & FechasECheques & "</strong>"

                    End If

                    If PorTransferenciaYCheques Then
                        WBody &= "." & "<br/>" & "<br/>" & "Además tiene Cheque(s) para retirar por nuestras oficinas <em>(Tucumán 3475, B1644 Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los <strong>Martes y Juevess</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>"
                    Else
                        WBody &= "." & "<br/>" & "<br/>" & "Adjuntamos Orden de Pago y retenciones si correspondiesen."
                    End If

                Else

                    WBody = "Informamos que se encuentra a su disposición un pago que podrá ser retirado por nuestras oficinas <em>(Tucumán 3475, B1644 Victoria, Buenos Aires)</em>, a partir de la <strong>semana próxima</strong>, los días <strong>Martes y Jueves</strong> en el horario de <strong>14:00 a 17:00 hs.</strong>"

                End If

                If Trim(DescProveedor) <> "" Then
                    WBody = "Sres. <strong>" & DescProveedor.Trim.ToUpper & "</strong> <br/>" & "<br/>" & WBody
                End If

                'Select Case Proveedor
                '    Case "10167878480", "10000000100", "10071081483", "10069345023", "10066352912"
                '        WBody = WBody & "<br/>" & "<br/>" & "En caso de cualquier consulta, por favor dirigirla a <strong><em>fgmonti@surfactan.com.ar</em></strong>"
                'End Select

                Dim WAdjuntos As New List(Of String)

                If (EsPorTransferencia Or HayECheques) And Not PorTransferenciaYCheques Then
                    WAdjuntos = _PrepararAdjuntos(OrdenPago)
                End If

                For Each wAdjunto As String In WAdjuntos
                    If Not File.Exists(wAdjunto) Then
                        Throw New System.Exception("No existe el archivo " & wAdjunto)
                    End If
                Next

                _EnviarEmail(WMailOp, "", "Orden de Pago - PELLITAL S.A. - ", WBody, WAdjuntos.ToArray)

                _MarcarOPComoEnviada(OrdenPago)

            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer procesar el envío de mail por OP Disponible." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally


            cn.Close()



        End Try
    End Sub


    Private Function _PrepararAdjuntos(ByVal ordenPago As String) As List(Of String)
        Dim WAdjuntos As New List(Of String)

        If Val(ordenPago) <> 0 Then

            Dim cn = New SqlConnection()
            Dim cm = New SqlCommand("SELECT Orden FROM Pagos WHERE Orden = '" & ordenPago & "' And Renglon IN ('01', '1')")
            Dim dr As SqlDataReader

            Try

                cn.ConnectionString = _ConectarA()
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    With New Pagos
                        .WindowState = FormWindowState.Minimized
                        .GenerarPDF = True
                        .Show(Me)
                        .txtOrdenPago.Text = ordenPago
                        .txtOrdenPago_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                        .btnImprimir.PerformClick()
                        .Close()
                    End With

                    For Each o As String In Directory.GetFiles("C:/ImpreOrdenPagoTemp", ordenPago & "OrdenPago*")
                        WAdjuntos.Add(o)
                    Next
                    'WAdjuntos.Add("C:/ImpreOrdenPagoTemp/" & ordenPago & "OrdenPago.pdf")

                End If

            Catch ex As System.Exception
                Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
            Finally


                cn.Close()



            End Try

        End If

        Return WAdjuntos
    End Function

    Private Sub _MarcarOPComoEnviada(ByVal OrdenPago As Object)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("UPDATE Pagos SET AvisoMailOp = '1' WHERE Orden = '" & OrdenPago & "'")

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

        Catch ex As System.Exception
            Throw New System.Exception("No se pudo marcar la Orden de Pago '" & OrdenPago & "' como 'ENVIADA'." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()



        End Try
    End Sub

    Private Sub _EnviarEmail(ByVal _to As String, ByVal _bcc As String, ByVal _subject As String, ByVal _body As String, ByVal _adjuntos() As String)
        Dim _Outlook As New Application

        Try
            Dim _Mail As MailItem = _Outlook.CreateItem(OlItemType.olMailItem)

            With _Mail

                '
                ' (NO BORRAR) Obtenemos la Instancia de Inspector para que nos agrege la firma que se encuentra definida por defecto.
                '
                'Dim WInspector = .GetInspector

                .To = _to
                '.To = "gferreyra@surfactan.com.ar"
                .BCC = _bcc
                .Subject = _subject
                '.Body = _body
                Dim WFirmaAct As String = ""
                'WFirmaAct &= "<br/>" & "<h2><u><strong>CRONOGRAMA DE PRÓXIMAS ACTIVIDADES</strong></u></h2>"
                'WFirmaAct &= "<h4>" & "<p>- Viernes 20/12/2019 y 27/12/2019, los pagos se realizarán en forma normal.</p>"
                'WFirmaAct &= "" & "<p>- Los días 30/12/2019 y 31/12/2019, <strong>SURFACTAN</strong> no tendrá actividades.</p>"
                'WFirmaAct &= "" & "<p>- Los pagos del 03/01/2020, se trasladan al día 10/01/2020.</p></h4>"

                If _EsPellital() Then
                    .HTMLBody = "<p>" & _body & "</p>" & "<br/><br/><p><strong>Atentamente</strong><br/>PELLITAL S.A</p>" & WFirmaAct & .HTMLBody
                Else
                    .HTMLBody = "<p>" & _body & "</p>" & "<br/><br/><p><strong>Atentamente</strong><br/>SURFACTAN S.A</p>" & WFirmaAct & .HTMLBody
                End If

                For Each adjunto As String In _adjuntos
                    If Trim(adjunto) <> "" Then
                        .Attachments.Add(adjunto)
                    End If
                Next

                .Send()
                '.Display()

            End With

        Catch ex As System.Exception
            Throw New System.Exception("Ocurrió un problema al querer enviar Aviso de Orden de Pago disponible." & vbCrLf & vbCrLf & " Motivo: " & ex.Message)
        End Try
    End Sub

    Private Sub btnActualizarCarpetas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnActualizarCarpetas.Click

        With New ActualizarCarpetasPagos(txtOrdenPago.Text)

            .Carpetas(_Carpetas) ' Asignamos las carpetas en caso de que la orden de pago tenga.

            .ShowDialog()

            _Carpetas = .Carpetas ' Traemos las carpetas que se hayan asignado.

            .Dispose()

        End With
    End Sub

    Private Sub btnDifCambioXFactura_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDifCambioXFactura.Click

        If gridPagos.Rows.Cast(Of DataGridViewRow).Any(Function(r) Val(OrDefault(r.Cells("Importe").Value, "")) <> 0) Then

            For Each Factura As DataGridViewRow In GridPagosXFacturas.Rows
                Factura.Cells("Check").Value = False
            Next
            pnlDifCamXFactura.Visible = True
            _CargarGridPagosXFactura()

        End If

    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnVolver.Click
        pnlDifCamXFactura.Visible = False
    End Sub

    Private Sub _CargarGridPagosXFactura()

        For i As Integer = 0 To 14
            GridPagosXFacturas.Rows.Add()
            GridPagosXFacturas.Rows(i).Cells("NumeroXFactura").Value = ""
            GridPagosXFacturas.Rows(i).Cells("Fecha").Value = ""
            GridPagosXFacturas.Rows(i).Cells("ImportePesos").Value = ""
            GridPagosXFacturas.Rows(i).Cells("Paridad").Value = ""
            GridPagosXFacturas.Rows(i).Cells("ImporteDolares").Value = ""
            GridPagosXFacturas.Rows(i).Cells("Tipo3").Value = ""
            GridPagosXFacturas.Rows(i).Cells("Letra3").Value = ""
            GridPagosXFacturas.Rows(i).Cells("Punto3").Value = ""
        Next

        Dim ZZNumero As String
        Dim ZZTipo As String
        Dim ZZPunto As String
        Dim ZZLetra As String
        Dim CodProveedor As String = txtProveedor.Text

        Dim filasNuevas As Integer = 0
        For i As Integer = 0 To 14

            If (gridPagos.Rows(i).Cells("Importe").Value <> "") Then
                GridPagosXFacturas.Rows(filasNuevas).Cells("NumeroXFactura").Value = gridPagos.Rows(i).Cells("Numero").Value
                GridPagosXFacturas.Rows(filasNuevas).Cells("Tipo3").Value = gridPagos.Rows(i).Cells("Tipo").Value
                GridPagosXFacturas.Rows(filasNuevas).Cells("Punto3").Value = gridPagos.Rows(i).Cells("Punto").Value
                GridPagosXFacturas.Rows(filasNuevas).Cells("Letra3").Value = gridPagos.Rows(i).Cells("Letra").Value

                ZZNumero = GridPagosXFacturas.Rows(filasNuevas).Cells("NumeroXFactura").Value
                ZZTipo = GridPagosXFacturas.Rows(filasNuevas).Cells("Tipo3").Value
                ZZPunto = GridPagosXFacturas.Rows(filasNuevas).Cells("Punto3").Value
                ZZLetra = GridPagosXFacturas.Rows(filasNuevas).Cells("Letra3").Value

                GridPagosXFacturas.Rows(filasNuevas).Cells("Fecha").Value = _BuscarFechaFacturaPorProv(ZZTipo, ZZPunto, ZZLetra, CodProveedor, ZZNumero)

                If GridPagosXFacturas.Rows(filasNuevas).Cells("Fecha").Value = "NoSeEncontro" Then Continue For

                Dim ZZFecha As DateTime = Convert.ToDateTime(GridPagosXFacturas.Rows(filasNuevas).Cells("Fecha").Value)
                If (ZZFecha.DayOfWeek = 0) Then
                    ZZFecha.AddDays(1)
                Else
                    If (ZZFecha.DayOfWeek = 6) Then
                        ZZFecha.AddDays(2)
                    End If
                End If
                Dim ZZImportePesos, Div As String
                Dim ZZParidad As Double
                GridPagosXFacturas.Rows(filasNuevas).Cells("ImportePesos").Value = gridPagos.Rows(i).Cells("Importe").Value
                ZZImportePesos = GridPagosXFacturas.Rows(filasNuevas).Cells("ImportePesos").Value
                GridPagosXFacturas.Rows(filasNuevas).Cells("Paridad").Value = formatonumerico(_BuscarParidadFacturaPorProv(ZZTipo, ZZPunto, ZZLetra, CodProveedor, ZZNumero))

                If GridPagosXFacturas.Rows(filasNuevas).Cells("Paridad").Value = 0 Then
                    GridPagosXFacturas.Rows(filasNuevas).Cells("Paridad").Value = formatonumerico(txtParidad.Text)
                End If
                'redondeo(_BuscarCambioDiviza(Fecha))
                ZZParidad = Val(GridPagosXFacturas.Rows(filasNuevas).Cells("Paridad").Value)

                If ZZParidad = 0 Then
                    Div = 0
                Else
                    Div = Val(ZZImportePesos) / Val(formatonumerico(ZZParidad))
                End If

                GridPagosXFacturas.Rows(filasNuevas).Cells("ImporteDolares").Value = formatonumerico(Div)
                filasNuevas = filasNuevas + 1
            End If

        Next

    End Sub

    Private Function _BuscarFechaFacturaPorProv(ByVal zTipo As String, ByVal zPunto As String, ByVal zLetra As String, ByVal Proveedor As String, ByVal zNumero As String) As String
        Dim cn As New SqlConnection(_ConectarA())
        cn.Open()
        Dim SQLconsul As String
        SQLconsul = "SELECT Fecha From CtaCtePrv WHERE Proveedor = '" & Proveedor & "' AND Numero = '" & zNumero & "' AND Letra = '" & zLetra & "' AND Tipo = '" & zTipo & "' AND Punto = '" & zPunto & "'"
        Dim cmd As New SqlCommand(SQLconsul, cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        If (dr.HasRows) Then
            If (dr.Read()) Then
                Dim Devolver As String = dr.Item("Fecha")
                Return Devolver
            End If
        End If
        Return "NoSeEncontro"
    End Function

    Private Function _BuscarParidadFacturaPorProv(ByVal zTipo As String, ByVal zPunto As String, ByVal zLetra As String, ByVal Proveedor As String, ByVal zNumero As String) As Double
        Dim cn As New SqlConnection(_ConectarA())
        cn.Open()
        Dim SQLconsul As String
        SQLconsul = "SELECT Paridad From CtaCtePrv WHERE Proveedor = '" & Proveedor & "' AND Numero = '" & zNumero & "' AND Letra = '" & zLetra & "' AND Tipo = '" & zTipo & "' AND Punto = '" & zPunto & "'"
        Dim cmd As New SqlCommand(SQLconsul, cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        If (dr.HasRows) Then
            If (dr.Read()) Then
                Dim Devolver As String = dr.Item("Paridad")
                Return Devolver
            End If
        End If
        Return "NoSeEncontro"
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Dim tablaChequesAdolar As New DBAuxi.TablaChequesDifCambioXFacturaDataTable

        Dim Fechaord As String = ordenaFecha(txtFechaParidad.Text)
        Dim importeDolar As Double = Val(formatonumerico(txtTotal.Text)) / Val(formatonumerico(txtParidad.Text))
        tablaChequesAdolar.Rows.Add("00", "Retenciones", "", txtTotal.Text, txtParidad.Text, formatonumerico(importeDolar), txtTotal.Text, False, Fechaord, txtTotal.Text)
        For i As Integer = 1 To XMAXFILAS
            If (gridFormaPagos.Rows(i - 1).Cells("Importe2").Value <> "") Then
                tablaChequesAdolar.Rows.Add()
                tablaChequesAdolar.Rows(i).Item("Tipo") = gridFormaPagos.Rows(i - 1).Cells("Tipo2").Value
                tablaChequesAdolar.Rows(i).Item("Numero") = gridFormaPagos.Rows(i - 1).Cells("Numero2").Value
                tablaChequesAdolar.Rows(i).Item("Fecha") = gridFormaPagos.Rows(i - 1).Cells("Fecha2").Value
                tablaChequesAdolar.Rows(i).Item("Importe") = gridFormaPagos.Rows(i - 1).Cells("Importe2").Value
                Dim ZZFecha As String = tablaChequesAdolar.Rows(i).Item("Fecha")

                If ZZFecha.Replace(" ", "").Length < 10 And (Val(tablaChequesAdolar.Rows(i).Item("Tipo")) <> 2 And Val(tablaChequesAdolar.Rows(i).Item("Tipo")) <> 3) Then
                    ZZFecha = txtFechaParidad.Text
                ElseIf ZZFecha.Replace(" ", "").Length < 10 Then
                    Continue For
                End If

                Dim FechaAVerificar As DateTime
                FechaAVerificar = DateTime.ParseExact(ZZFecha, "dd/MM/yyyy", New CultureInfo("en-US"))
                If (FechaAVerificar.DayOfWeek = 6) Then
                    FechaAVerificar = FechaAVerificar.AddDays(2)
                Else
                    If (FechaAVerificar.DayOfWeek = 0) Then
                        FechaAVerificar = FechaAVerificar.AddDays(1)
                    End If
                End If

                tablaChequesAdolar.Rows(i).Item("Paridad") = _BuscarCambioDiviza(FechaAVerificar.ToString("dd/MM/yyyy"))

                If (tablaChequesAdolar.Rows(i).Item("Paridad") = 0) Then
                    For j As Integer = 0 To 29
                        FechaAVerificar = FechaAVerificar.AddDays(1)
                        If (FechaAVerificar.DayOfWeek = 6) Then
                            FechaAVerificar = FechaAVerificar.AddDays(2)

                        Else
                            If (FechaAVerificar.DayOfWeek = 0) Then
                                FechaAVerificar = FechaAVerificar.AddDays(1)
                            End If
                        End If
                        tablaChequesAdolar.Rows(i).Item("Paridad") = _BuscarCambioDiviza(FechaAVerificar.ToString())
                        If (tablaChequesAdolar.Rows(i).Item("Paridad") <> 0) Then
                            Exit For
                        End If
                    Next
                End If

                If (tablaChequesAdolar.Rows(i).Item("Paridad") = 0) Then
                    MsgBox("Hay cheques no se acreditaron, por tanto, no se puede calcular")
                    Exit Sub
                End If


                Dim ZZParidad As Double = Val(formatonumerico(tablaChequesAdolar.Rows(i).Item("Paridad").ToString))
                If ZZParidad = 0 Then ZZParidad = 1

                Dim CalculoImpDolares As Double = Val(gridFormaPagos.Rows(i - 1).Cells("Importe2").Value) / ZZParidad
                tablaChequesAdolar.Rows(i).Item("ImporteDolares") = formatonumerico(CalculoImpDolares)
                tablaChequesAdolar.Rows(i).Item("SaldoCheque") = gridFormaPagos.Rows(i - 1).Cells("Importe2").Value
                tablaChequesAdolar.Rows(i).Item("UsadoParaListar") = False
                tablaChequesAdolar.Rows(i).Item("FechaOrdenada") = ordenaFecha(gridFormaPagos.Rows(i - 1).Cells("Fecha2").Value)
                tablaChequesAdolar.Rows(i).Item("SaldoAMostrar") = gridFormaPagos.Rows(i - 1).Cells("Importe2").Value
            End If

        Next

        Dim TotalDebitosDolares As Double = 0
        Dim TablaSeleccionados As New DBAuxi.TablaSeleccionadosDataTable

        Dim lista As List(Of DataGridViewRow) = (From row As DataGridViewRow In GridPagosXFacturas.Rows Where (row.Cells("Check").Value = True)).ToList()

        For i As Integer = 0 To lista.Count - 1
            TablaSeleccionados.Rows.Add(lista.Item(i).Cells("NumeroXFactura").Value, lista.Item(i).Cells("Fecha").Value, lista.Item(i).Cells("ImportePesos").Value, lista.Item(i).Cells("Paridad").Value, lista.Item(i).Cells("ImporteDolares").Value)
        Next

        Dim ArrayNumerosSeleccionados(TablaSeleccionados.Rows.Count) As String
        Dim ArrayMontosEnPesosAmostrar(tablaChequesAdolar.Rows.Count) As String

        If (TablaSeleccionados.Rows.Count > 0) Then
            For i As Integer = 0 To TablaSeleccionados.Rows.Count - 1
                ArrayNumerosSeleccionados(i) = TablaSeleccionados.Rows(i).Item("Numero")
            Next
        End If

        Dim tablachesquesAQueFactura As New DBAuxi.TablaChequesAQueFacturaDataTable

        Dim totalSaldocheques As Double

        For Each Factura As DataGridViewRow In GridPagosXFacturas.Rows
            If (Factura.Cells("ImportePesos").Value <> Nothing) Then
                TotalDebitosDolares = Val(Factura.Cells("ImportePesos").Value)
                totalSaldocheques = 0
                If (tablaChequesAdolar.Rows.Count > 0) Then
                    Dim contadorCheques = -1

                    For Each row As DataRow In (tablaChequesAdolar.Select("", "FechaOrdenada"))

                        contadorCheques = contadorCheques + 1

                        If Val(OrDefault(row.Item("SaldoCheque"), "")) <> 0 Then

                            If (row.Item("Importe") = row.Item("SaldoAMostrar")) Then
                                totalSaldocheques = totalSaldocheques + Val(row.Item("Importe"))

                                If (TotalDebitosDolares > totalSaldocheques) Then
                                    row.Item("SaldoCheque") = "0"

                                    For j As Integer = 0 To TablaSeleccionados.Rows.Count

                                        If (IIf(IsDBNull(ArrayNumerosSeleccionados(j)), "XXXXX", ArrayNumerosSeleccionados(j)) = Factura.Cells("NumeroXFactura").Value) Then
                                            row.Item("UsadoParaListar") = True
                                            ArrayMontosEnPesosAmostrar(contadorCheques) = row.Item("SaldoAMostrar")
                                            tablachesquesAQueFactura.Rows.Add(Factura.Cells("NumeroXFactura").Value, row.Item("Numero"), row.Item("Importe"), row.Item("ImporteDolares"), ArrayMontosEnPesosAmostrar(contadorCheques))
                                        End If
                                    Next

                                Else
                                    Dim Diferencia As Double
                                    Dim SaldoRestante As Double = redondeo(totalSaldocheques - TotalDebitosDolares)
                                    row.Item("SaldoCheque") = Val(SaldoRestante)
                                    Diferencia = Val(row.Item("Importe")) - Val(SaldoRestante)
                                    row.Item("SaldoAMostrar") = formatonumerico(Diferencia)
                                    row.Item("SaldoAMostrar") = row.Item("SaldoAMostrar").replace(",", ".")
                                    For j As Integer = 0 To TablaSeleccionados.Rows.Count
                                        If (IIf(IsDBNull(ArrayNumerosSeleccionados(j)), "XXXXX", ArrayNumerosSeleccionados(j)) = Factura.Cells("NumeroXFactura").Value) Then
                                            row.Item("UsadoParaListar") = True
                                            ArrayMontosEnPesosAmostrar(contadorCheques) = row.Item("SaldoAMostrar")
                                            Dim ValorAdolar As String = Val(row.Item("SaldoAMostrar").ToString().Replace(",", ".")) / Val(row.Item("Paridad").ToString().Replace(",", "."))
                                            ValorAdolar = redondeo(ValorAdolar).ToString().Replace(",", ".")
                                            tablachesquesAQueFactura.Rows.Add(Factura.Cells("NumeroXFactura").Value, row.Item("Numero"), row.Item("Importe"), ValorAdolar, ArrayMontosEnPesosAmostrar(contadorCheques))
                                            Exit For
                                        End If
                                    Next

                                    Exit For

                                End If
                            Else
                                totalSaldocheques = totalSaldocheques + Val(row.Item("SaldoCheque").ToString().Replace(",", "."))
                                If (TotalDebitosDolares > totalSaldocheques) Then

                                    For j As Integer = 0 To TablaSeleccionados.Rows.Count
                                        If (IIf(IsDBNull(ArrayNumerosSeleccionados(j)), "XXXXX", ArrayNumerosSeleccionados(j)) = Factura.Cells("NumeroXFactura").Value) Then
                                            If (row.Item("UsadoParaListar") = False) Then
                                                row.Item("UsadoParaListar") = True
                                                Dim ImporteRestante As String = formatonumerico(Val(row.Item("Saldocheque").ToString().Replace(",", ".")) - Val(ArrayMontosEnPesosAmostrar(contadorCheques)))
                                                ArrayMontosEnPesosAmostrar(contadorCheques) = row.Item("SaldoCheque").ToString().Replace(",", ".")
                                                Dim ValorAdolar As String = Val(row.Item("SaldoCheque").ToString().Replace(",", ".")) / Val(row.Item("Paridad").ToString().Replace(",", "."))
                                                ValorAdolar = redondeo(ValorAdolar).ToString().Replace(",", ".")
                                                tablachesquesAQueFactura.Rows.Add(Factura.Cells("NumeroXFactura").Value, row.Item("Numero"), row.Item("Importe"), ValorAdolar, ImporteRestante.Replace(",", "."))
                                            Else
                                                Dim ImporteRestante As String = formatonumerico(Val(row.Item("Importe").ToString().Replace(",", ".")) - Val(ArrayMontosEnPesosAmostrar(contadorCheques)))
                                                ArrayMontosEnPesosAmostrar(contadorCheques) = row.Item("Importe").ToString().Replace(",", ".")
                                                Dim ValorAdolar As String = Val(ImporteRestante.Replace(",", ".")) / Val(row.Item("Paridad").ToString().Replace(",", "."))
                                                ValorAdolar = redondeo(ValorAdolar).ToString().Replace(",", ".")
                                                tablachesquesAQueFactura.Rows.Add(Factura.Cells("NumeroXFactura").Value, row.Item("Numero"), row.Item("Importe"), formatonumerico(ValorAdolar), ImporteRestante.Replace(",", "."))
                                            End If

                                        End If
                                        row.Item("SaldoCheque") = "0"
                                    Next
                                Else
                                    Dim Diferencia As Double
                                    Dim SaldoRestante As Double = redondeo(totalSaldocheques - TotalDebitosDolares)

                                    row.Item("SaldoCheque") = Val(SaldoRestante)

                                    Diferencia = totalSaldocheques - Val(SaldoRestante)

                                    row.Item("SaldoAMostrar") = formatonumerico(Diferencia)
                                    row.Item("SaldoAMostrar") = row.Item("SaldoAMostrar").replace(",", ".")

                                    For j As Integer = 0 To TablaSeleccionados.Rows.Count

                                        If (IIf(IsDBNull(ArrayNumerosSeleccionados(j)), "XXXXX", ArrayNumerosSeleccionados(j)) = Factura.Cells("NumeroXFactura").Value) Then

                                            row.Item("UsadoParaListar") = True
                                            ArrayMontosEnPesosAmostrar(contadorCheques) = row.Item("SaldoAMostrar")

                                            Dim ValorAdolar As String = Val(row.Item("SaldoAMostrar").ToString().Replace(",", ".")) / Val(row.Item("Paridad").ToString().Replace(",", "."))

                                            ValorAdolar = formatonumerico(ValorAdolar).ToString().Replace(",", ".")
                                            tablachesquesAQueFactura.Rows.Add(Factura.Cells("NumeroXFactura").Value, row.Item("Numero"), row.Item("Importe"), formatonumerico(ValorAdolar), ArrayMontosEnPesosAmostrar(contadorCheques))

                                            Exit For

                                        End If

                                    Next

                                    Exit For

                                End If
                            End If
                        End If
                    Next
                End If
            End If

        Next

        '            Dim DolaresCalculados As String = "0"
        '            Dim tablaOrdenada() As DataRow
        '            tablaOrdenada = tablaChequesAdolar.Select("", "FechaOrdenada").Clone()
        '            For i = 0 To tablaChequesAdolar.Rows.Count - 1
        '                Dim sumaArray As String
        '                sumaArray = Val(IIf(IsDBNull(sumaArray), "0", sumaArray)) + Val(IIf(IsDBNull(ArrayMontosEnPesosAmostrar(i)), "0", ArrayMontosEnPesosAmostrar(i)))
        '                sumaArray = sumaArray.Replace(",", ".")
        '                DolaresCalculados = Val(DolaresCalculados) + (Val(IIf(IsDBNull(ArrayMontosEnPesosAmostrar(i)), "0", ArrayMontosEnPesosAmostrar(i))) / Val(tablaOrdenada(i).Item("Paridad").ToString().Replace(",", ".")))
        '                DolaresCalculados = redondeo(DolaresCalculados).ToString().Replace(",", ".")
        '        Next

        For Each Factura As DataRow In TablaSeleccionados.Rows
            Dim TotalFacturaPesos As Double = 0
            Dim TotalFacturaDolares As Double = 0
            For Each cheque As DataRow In tablachesquesAQueFactura.Rows
                If (Factura.Item("Numero") = cheque("NumeroFactura")) Then
                    TotalFacturaPesos += Val(formatonumerico(cheque("ImporteUsado")))
                    TotalFacturaDolares += Val(formatonumerico(cheque("ValorEnDolares")))
                    TotalFacturaDolares = redondeo(TotalFacturaDolares)
                End If
            Next
            Factura.Item("TotalChequesPesos") = Val(formatonumerico(TotalFacturaPesos))
            Factura.Item("TotalChequesDolares") = Val(formatonumerico(TotalFacturaDolares))
            Factura.Item("Diferencia") = Val(formatonumerico(Factura.Item("ImporteDolares"))) - Val(formatonumerico(Factura.Item("TotalChequesDolares")))
        Next
        Dim ParidadDelDia As String = _BuscarCambioDiviza(Date.Today)

        ' GridPagosXFacturas.DataSource = tablachesquesAQueFactura
        With New VistaPrevia
            .Reconectar = False
            .Reporte = New AnalisisDiferenciaCambioXFacturas()
            Dim ds As New DataSet
            ds.Tables.AddRange({tablaChequesAdolar, tablachesquesAQueFactura, TablaSeleccionados})
            .Reporte.SetDataSource(ds)
            .Reporte.SetParameterValue(0, txtOrdenPago.Text)
            .Reporte.SetParameterValue(1, txtProveedor.Text)
            .Reporte.SetParameterValue(2, txtFecha.Text)
            .Reporte.SetParameterValue(3, txtRazonSocial.Text)
            .Reporte.SetParameterValue(4, ParidadDelDia)
            .Reporte.SetParameterValue(5, txtParidad.Text)
            .Mostrar()
        End With

    End Sub

    Private Sub rbChElectronico_MouseClick(sender As Object, e As MouseEventArgs) Handles rbChFisico.MouseClick, rbChElectronico.MouseClick
        btnChequesTerceros_Click(Nothing, Nothing)
    End Sub



    Private Sub btn_ConsultaSoliFondos_Click(sender As Object, e As EventArgs) Handles btn_ConsultaSoliFondos.Click

        If NroSoliInterno <> 0 Then
            Dim Paridad As String = traerParidad(txtFechaParidad.Text, True)
            If Val(txtParidad.Text) <> Val(Paridad) Then
                MsgBox("Se modifico la paridad a la asignada en la solicitud de fondos")
                txtParidad.Text = Paridad
            End If

            With New MostrarSoliFondos(NroSoliInterno, txtParidad.Text)
                .Show(Me)
            End With
        End If
    End Sub

    Private Sub btn_ListarSolicitudesFondos_Click(sender As Object, e As EventArgs) Handles btn_ListarSolicitudesFondos.Click
        lstConsulta.Items.Clear()
        _ListarSolicitudesFondos()
    End Sub

    Private Sub gridFormaPagos_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles gridFormaPagos.CellLeave

        If gridFormaPagos.Focused Or gridFormaPagos.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            gridFormaPagos.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = gridFormaPagos.CurrentCell.ColumnIndex
            Dim iRow = gridFormaPagos.CurrentCell.RowIndex
            If iCol = 3 Then
                Dim valor = gridFormaPagos.Rows(iRow).Cells(iCol).Value
                If gridFormaPagos.Rows(iRow).Cells(0).Value = "02" Or gridFormaPagos.Rows(iRow).Cells(0).Value = "04" Or gridFormaPagos.Rows(iRow).Cells(0).Value = "03" Then

                    'LO LIMPIO ANTES DE CARGARLO
                    gridFormaPagos.Rows(iRow).Cells(iCol + 1).Value = ""

                    Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(valor)
                    If Not IsNothing(banco) Then
                        gridFormaPagos.Rows(iRow).Cells(iCol + 1).Value = banco.nombre
                    Else

                        If Trim(gridFormaPagos.Rows(iRow).Cells(iCol + 1).Value) = "" Then
                            MsgBox("El codigo de banco es incorrecto, verificar", MsgBoxStyle.Information)

                            gridFormaPagos.CurrentCell = gridFormaPagos.Rows(iRow).Cells(iCol)

                            If Not gridFormaPagos.Focused Then
                                gridFormaPagos.Focus()
                            End If

                        End If

                    End If
                End If
            End If
        End If

    End Sub


End Class