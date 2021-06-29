Imports System.Data.SqlClient
Imports ClasesCompartidas
Imports CrystalDecisions.CrystalReports.Engine
Imports Util.Clases

Public Class Listados_Pagos_SinImprimir

    Private Sub Listados_Pagos_SinImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbx_QuienHizo.SelectedIndex = 0
        txt_FechaDesde.Text = Date.Today.AddDays(-7).ToString("dd/MM/yyyy")
        txt_FechaHasta.Text = Date.Today.ToString("dd/MM/yyyy")
        btn_Aceptar_Click(Nothing, Nothing)
        txt_FechaDesde.Focus()
        txt_FechaDesde.SelectAll()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        'VALIDACIONES
        If ValidaFecha(txt_FechaDesde.Text) = "N" Then
            MsgBox("La fecha Desde es una fecha invalida", vbExclamation)
            Exit Sub
        Else
            If ValidaFecha(txt_FechaHasta.Text) = "N" Then
                MsgBox("La fecha Hasta es una fecha invalida", vbExclamation)
                Exit Sub
            End If
        End If


        Dim Filtro As String
        Select Case cbx_QuienHizo.SelectedItem
            Case "Todos"
                Filtro = ""
            Case "Alejandro"
                Filtro = " AND UPPER(OperadorClave) = 'XINGO'"
            Case "Lucas"
                Filtro = " AND UPPER(OperadorClave) = 'LUCAS2021'"
            Case "Sergio"
                Filtro = " AND UPPER(OperadorClave) = 'SERGIO'"
            Case "Liliana"
                Filtro = " AND UPPER(OperadorClave) = 'LOGOUT'"
        End Select

        Dim DesdeFecha As String = ordenaFecha(txt_FechaDesde.Text)
        Dim HastaFecha As String = ordenaFecha(txt_FechaHasta.Text)


        Dim SQLCnslt As String = "SELECT NroPago = pa.Orden, pa.Fecha, " _
                                 & "Destino = CASE pa.proveedor WHEN '' THEN cu.Descripcion ELSE pr.Nombre END, " _
                                 & "QuienHizo = CASE UPPER(OperadorClave) WHEN 'XINGO' THEN 'Alejandro' WHEN 'SERGIO' THEN 'Sergio' WHEN 'LUCAS2021' THEN 'lucas' WHEN 'LOGOUT' THEN 'Liliana' ELSE '' END " _
                                 & "FROM Pagos pa LEFT JOIN Proveedor pr ON Pa.proveedor = pr.Proveedor LEFT JOIN Cuenta cu ON Pa.Cuenta = cu.Cuenta " _
                                 & "WHERE Renglon = '01' AND Impreso_Sergio_Lucas <> 'X' AND FechaOrd >= '" & DesdeFecha & "' AND FechaOrd <= '" & HastaFecha & "' " & Filtro & " " _
                                 & "ORDER BY FechaOrd ASC "
        Dim TablaPagos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaPagos.Rows.Count > 0 Then
            dgv_Pagos.DataSource = TablaPagos
        Else
            MsgBox("No se encuentrar Ordenes de Pago con estos parametros de busqueda", vbExclamation)
            dgv_Pagos.DataSource = TablaPagos
        End If
    End Sub

    Private Sub ImprimirSeleccionadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirSeleccionadasToolStripMenuItem.Click
        If dgv_Pagos.SelectedRows.Count > 0 Then
            For Each dgvRow As DataGridViewRow In dgv_Pagos.SelectedRows
                Try
                    Dim orden As String = dgvRow.Cells("NroPago").Value
                    Imprimir(orden)
                    ActualizaImpresionOrden(orden)
                Catch ex As Exception

                End Try
                
            Next
            btn_Aceptar_Click(Nothing, Nothing)
        Else
            MsgBox("No se selecciono ninguna fila", vbExclamation)
        End If
    End Sub

    Private Sub ActualizaImpresionOrden(ByVal orden As String)
        Dim SQLCnslt As String = "UPDATE Pagos SET Impreso_Sergio_Lucas = 'X' WHERE Orden = '" & orden & "'"
        ExecuteNonQueries("SurfactanSa", {SQLCnslt})
    End Sub



    Private Const XMAXFILAS = 30
    Private XParidadTotal As String = "0"
    Dim RazonSocial As String
    Dim Wobservaciones As String
    Dim CodProveedor As String = ""
    Dim NROORDENPAGO As String
    Dim IBCiudad As string
    Dim IngresosBrutos As String
    Dim Ganancias As String
    Dim IVA As String
    Dim WFecha As String
    Public Property GenerarPDF As Boolean
    
    Private Sub Imprimir(ByVal OrdenPago As String)
        Dim XOrdenPago As String = IIf(Trim(OrdenPago) = "", "0", Trim(OrdenPago))
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

        'INCLUIDO ANDRES
        NROORDENPAGO = OrdenPago
        Dim SQlCnslt As String = "SELECT Tipo = pa.TipoOrd ,Razon = pr.Nombre, pa.Fecha, pa.Proveedor, pa.Retencion, pa.RetIBCiudad, pa.RetIva, pa.RetGanancias, pa.CertificadoIb, pa.CertificadoIbCiudad, pa.CertificadoIva, pa.Observaciones FROM Pagos Pa LEFT JOIN Proveedor Pr ON Pa.Proveedor = pr.Proveedor WHERE Orden = '" & OrdenPago & "' AND Renglon = '01'"
        Dim RowProveedor As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
        If RowProveedor IsNot Nothing Then
            CodProveedor = RowProveedor.Item("Proveedor")
            RazonSocial = IIf(IsDBNull(RowProveedor.Item("Razon")), "", RowProveedor.Item("Razon"))
            Wobservaciones = RowProveedor.Item("Observaciones")
            Ganancias = _NormalizarNumero(RowProveedor.Item("RetGanancias"))
            IngresosBrutos = _NormalizarNumero(RowProveedor.Item("Retencion"))
            IBCiudad = _NormalizarNumero(RowProveedor.Item("RetIbCiudad"))
            IVA = _NormalizarNumero(RowProveedor.Item("retiva"))
            WFecha = RowProveedor.Item("Fecha")
            WCertificadoIb = RowProveedor.Item("CertificadoIb")
            WCertificadoIbCiudad = RowProveedor.Item("CertificadoIbCiudad")
            WCertificadoIVA = RowProveedor.Item("CertificadoIva")
            mostrarTipo(RowProveedor.Item("Tipo"))
        Else
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
            cm.CommandText = "SELECT Cuit, Nombre, Cbu FROM Proveedor WHERE Proveedor = '" & Trim(CodProveedor) & "'"
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

        Dim Pagos As New DataTable
        mostrarPagos(Pagos, OrdenPago)
        ' Recorremos los primeros 15 pagos.
        For iRow = 0 To Pagos.Rows.Count - 1

            With Pagos.Rows(iRow)

                If Val(.Item(4)) = 0 Then
                    Exit For
                End If

                Select Case Val(.Item(0))
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

                If Val(.Item("MarcaDifCambio")) = 1 Then
                    WImpresion(XCantidad, 2) = "NDC"
                End If

                If Val(.Item("MarcaCHR")) = 1 Then
                    WImpresion(XCantidad, 2) = "CHR"
                End If

                WImpresion(XCantidad, 3) = Mid(.Item(3), 1, 8)
                WImpresion(XCantidad, 4) = .Item(5)
                WImpresion(XCantidad, 5) = .Item(4)
                If Val(WImpresion(XCantidad, 2)) = 3 Or Val(WImpresion(XCantidad, 2)) = 5 Then
                    ZZTotal -= Val(formatonumerico(WImpresion(XCantidad, 5)))
                Else
                    ZZTotal += Val(formatonumerico(WImpresion(XCantidad, 5)))
                End If

                WTipo = .Item(0)
                WLetra = .Item(1)
                WPunto = .Item(2)
                WNumero = .Item(3)

                ClaveCtaprv = CodProveedor + WLetra + WTipo + WPunto + WNumero

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

            For irow = 0 To Pagos.Rows.Count - 1
                With Pagos.Rows(irow)
                    If Val(.Item(4)) <> 0 Then
                        WDebito(irow + 1, 1) = XXCuenta(irow, 1)
                        WDebito(irow + 1, 2) = Val(formatonumerico(.Item(4)))
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

        Dim formaPagos As New DataTable
        mostrarFormaPagos(formaPagos)

        For iRow = 0 To formaPagos.Rows.Count - 1
            With formaPagos.Rows(iRow)
                If Val(.Item(5)) <> 0 Then

                    WCredito(Lugar, 4) = .Item(5)

                    Select Case Val(.Item(0))
                        Case 2
                            WCredito(Lugar, 1) = "999999"
                            ClaveBanco = .Item(3)
                            WCredito(Lugar, 1) = _TraerCuentaBanco(ClaveBanco)
                        Case 3, 4
                            WCredito(Lugar, 1) = WCtaCheques
                        Case Else
                            WCredito(Lugar, 1) = WCtaEfectivo
                    End Select

                    If Val(.Item(0)) = 3 Then
                        SumaTercero = SumaTercero + Val(formatonumerico(.Item(5)))
                    ElseIf Val(.Item(0)) <> 3 Or Val(CodProveedor) = 0 Then

                        If Val(OrDefault(.Item("Tipo2"), "")) = 6 And Val(OrDefault(.Item("Cuenta"), "")) = 5 Then
                            WImpre2(Impre2, 1) = "Compensación"
                        ElseIf Val(OrDefault(.Item("Tipo2"), "")) = 2 And Val(OrDefault(.Item("Numero2"), "")) = 0 Then
                            WImpre2(Impre2, 1) = "Transf."
                        Else
                            WImpre2(Impre2, 1) = .Item(1)
                        End If

                        WImpre2(Impre2, 0) = .Item(0)

                        WImpre2(Impre2, 2) = .Item(4)
                        WImpre2(Impre2, 3) = .Item(5)
                        WImpre2(Impre2, 4) = .Item(2)

                        WCredito(Lugar, 2) = .Item(4)
                        WCredito(Lugar, 3) = .Item(1)
                        WCredito(Lugar, 4) = .Item(5)

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
        Dim WFecha1, WNumero1, WComprobante1, WDescripcion1, WNumero2, WBanco2, WFecha2, WTipo2 As String
        Dim WImporte1, WImporte2 As Double
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New InformeOrdenPago

        ' Creo las Columnas
        _PrepararTablaOrdenPago(Tabla)

        Dim WCantFacts As Integer = Pagos.Rows.Cast(Of DataRow).Count(Function(r) Val(OrDefault(r.Item("Importe"), 0)) <> 0)

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
            WTipo2 = ""

            WRenglon += 1

            If Val(WImpresion(WCiclo, 5)) <> 0 Then
                WFecha1 = WImpresion(WCiclo, 1)
                WNumero1 = WImpresion(WCiclo, 3)
                WComprobante1 = WImpresion(WCiclo, 2)
                WDescripcion1 = WImpresion(WCiclo, 4)
                WImporte1 = Val(formatonumerico(WImpresion(WCiclo, 5)))
            End If

            If Val(WImpre2(WCiclo, 3)) <> 0 Then
                WTipo2 = WImpre2(WCiclo, 0)
                WNumero2 = WImpre2(WCiclo, 1)
                WBanco2 = WImpre2(WCiclo, 2)
                WImporte2 = Val(formatonumerico(WImpre2(WCiclo, 3)))
                WFecha2 = WImpre2(WCiclo, 4)
            End If

            row = Tabla.NewRow

            With row

                .Item("Clave") = "1" + ceros(OrdenPago, 6) + ceros(WRenglon, 2)
                .Item("Tipo") = 1
                .Item("Orden") = Val(OrdenPago)
                .Item("Renglon") = WRenglon
                .Item("Fecha") = WFecha
                .Item("Proveedor") = Trim(CodProveedor)
                .Item("Nombre") = RazonSocial
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
                .Item("Rete1") = Val(formatonumerico(Ganancias))
                .Item("Rete2") = Val(formatonumerico(IngresosBrutos)) + Val(formatonumerico(IBCiudad))
                .Item("Total") = Val(IVA)
                .Item("Observaciones") = Wobservaciones
                .Item("Empresa") = WEmpresa '"Surfactan S.A."
                .Item("Cuit") = XEmpCuit
                .Item("Paridad") = Val(formatonumerico(XParidadTotal))
                .Item("Tipo2") = WTipo2

            End With

            Tabla.Rows.Add(row)

            If Not GenerarPDF AndAlso WLimite = 15 Then
                row = Tabla.NewRow()

                With row
                    .Item("Clave") = "2" + ceros(OrdenPago, 6) + ceros(WRenglon, 2)
                    .Item("Tipo") = 2
                    .Item("Orden") = Val(OrdenPago)
                    .Item("Renglon") = WRenglon
                    .Item("Fecha") = WFecha
                    .Item("Proveedor") = Trim(CodProveedor)
                    .Item("Nombre") = RazonSocial
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
                    .Item("Rete1") = Val(formatonumerico(Ganancias))
                    .Item("Rete2") = Val(formatonumerico(IngresosBrutos)) + Val(formatonumerico(IBCiudad))
                    .Item("Total") = Val(formatonumerico(IVA))
                    .Item("Observaciones") = Wobservaciones
                    .Item("Empresa") = WEmpresa '"Surfactan S.A."
                    .Item("Cuit") = XEmpCuit
                    .Item("Paridad") = Val(formatonumerico(XParidadTotal))
                    .Item("Tipo2") = WTipo2
                End With

                Tabla.Rows.Add(row)
            End If

        Next

        crdoc.SetDataSource(Tabla)

        Dim QuienFirma As String = ObtenerQuienFirma()


        Dim frm As New VistaPrevia
        frm.Reporte = crdoc
        frm.Reporte.SetParameterValue("EsTransferencia", 0)
        frm.Reporte.SetParameterValue("CuitProv", XCuitProveedor)
        frm.Reporte.SetParameterValue("CbuProv", XCBU)
        frm.Reporte.SetParameterValue("FirmaAImprimir", QuienFirma)

        Dim WFechasTransferencias = ""
        Dim WFechasECheques As String = ""
        Dim WFechasCompensaciones As String = ""
        Dim WOrdenPago As DataTable = _TraerDatosOrdenPago(OrdenPago)
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

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, OrdenPago & "OrdenPago.pdf", "C:/ImpreOrdenPagoTemp/")

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
        If _DiscriminarValoreDeTerceros(NROORDENPAGO) Then
            _ImprimirDiscriminacionDeValoresDeTerceros(XRazon, XCuitProveedor, formaPagos)
        End If

        ' Imprimimos Comprobante de Retención de Ganancias si la hubiese

        If Val(Ganancias) <> 0 Then
            _ImprimirComprobanteRetencionGanancias(ZZTotal, Ganancias)
        End If

        ' Imprimimos Comprobante de Retención de Ingresos Brutos si la hubiese.

        If Val(IngresosBrutos) <> 0 Then
            _ImprimirComprobanteRetencionIB(Pagos)
        End If

        ' Imprimimos Comprobante de Retención de Ingresos Brutos CABA si la hubiese y si estuviesemos en SURFACTAN.

        If Val(IBCiudad) <> 0 AndAlso Not _EsPellital() Then
            _ImprimirComprobanteRetencionIBCiudad(Pagos)
        End If

        ' Imprimimos Comprobante de Retención de Iva si la hubiese.

        If Val(IVA) <> 0 Then
            _ImprimirComprobanteRetencionIva(Pagos)
        End If
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

    Private Sub mostrarFormaPagos(ByRef formaPagos As DataTable)
        'gridFormaPagos.Rows.Clear()
        With formaPagos.Columns
            .Add("Tipo2")
            .Add("Numero2")
            .Add("FechaCheque")
            .Add("Banco2")
            .Add("NombreCheque")
            .Add("Importe2")
            .Add("observacion")
            .Add("cuit")
            .Add("Cuenta")
        End With

        Dim WRenglon = 0

        Dim SQLCnslt As String = "SELECT Tipo2,Banco2,Numero2, FechaCheque, Observaciones2, Importe2, Cuit FROM Pagos WHERE orden = '" & NROORDENPAGO & "'"
        Dim TablaFormapagos As DataTable = GetAll(SQLCnslt, "SurfactanSa")


        For Each formaPago As DataRow In TablaFormapagos.Rows
            formaPagos.Rows.Add()
            With formaPagos.Rows(WRenglon)
                .Item(0) = formaPago.Item("tipo2")
                .Item(1) = formaPago.Item("numero2")
                .Item(2) = formaPago.Item("fechaCheque")
                .Item(3) = formaPago.Item("banco2")
                .Item(4) = formaPago.Item("Observaciones2")
                .Item(5) = _NormalizarNumero(formaPago.Item("importe2"))
                .Item(6) = ""
                .Item(7) = formaPago.Item("Cuit")
            End With

            WClavesOP(WRenglon) = ceros(NROORDENPAGO, 6) & ceros(WRenglon + 2, 2)

            Dim WRenglonPago As DataRow = GetSingle("SELECT Cuenta FROM Pagos WHERE Clave = '" & WClavesOP(WRenglon) & "'")

            If WRenglonPago IsNot Nothing Then
                formaPagos.Rows(WRenglon).Item("Cuenta") = Trim(OrDefault(WRenglonPago("Cuenta"), ""))
            End If

            WRenglon += 1

        Next

        'sumarImportes()
    End Sub


    Private Sub mostrarPagos(ByRef pagos As DataTable, ByVal OrdenPago As String)
        With pagos.Columns
            .Add("Tipo")
            .Add("Letra")
            .Add("Punto")
            .Add("Numero")
            .Add("Importe")
            .Add("Descripcion")
            .Add("ImpoNeto")
            .Add("MarcaDifCambio")
            .Add("MarcaCHR")
        End With

        Dim renglon = 0

        Dim SQLCnslt As String = "SELECT Tipo1,Letra1,Punto1, Numero1, Importe1, Observaciones2, ImpoNeto FROM Pagos WHERE orden = '" & OrdenPago & "'"
        Dim Tablapago As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        For Each pago As DataRow In Tablapago.Rows
            pagos.Rows.Add()
            With pagos.Rows(renglon)
                .Item("Tipo") = pago.Item("Tipo1")
                .Item("Letra") = pago.Item("letra1")
                .Item("Punto") = pago.Item("punto1")
                .Item("Numero") = pago.Item("numero1")
                .Item("Importe") = _NormalizarNumero(pago.Item("importe1"))
                .Item("Descripcion") = pago.Item("Observaciones2")

                If Val(pago.Item("impoNeto")) = 0 Then
                    .Item("ImpoNeto") = _CalcularImpoNeto(pago.Item("Tipo1"), pago.Item("letra1"), pago.Item("Punto1"), pago.Item("numero1"), pago.Item("importe1"))
                Else
                    .Item("ImpoNeto") = _NormalizarNumero(pago.Item("impoNeto"))
                End If

                Dim WIVaComp As DataRow = _BuscarInfoIvaCompPorClave(pago.Item("Tipo1"), pago.Item("letra1"), pago.Item("Punto1"), pago.Item("numero1"))
                .Item("MarcaDifCambio") = "0"
                .Item("MarcaCHR") = "0"
                If Not IsNothing(WIVaComp) Then
                    .Item("MarcaDifCambio") = WIVaComp.Item("MarcaDifCambio")
                    .Item("MarcaCHR") = WIVaComp.Item("Rechazado")
                End If

            End With
            renglon += 1
        Next
        'sumarImportes()
    End Sub
    Private Sub _ImprimirComprobanteRetencionIva(ByVal Pagos As DataTable)
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteRetIva
        Dim WEmpNombre = "SURFACTAN S.A."
        Dim WEmpDireccion = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit = "30-54916508-3"
        Dim WNroIb = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, WImporte, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim WBruto, WNeto, WReteIva
        Dim WCategoria
        Dim WRenglon = 0

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Direccion, Cuit, NroIb, CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & Trim(CodProveedor) & "'")
        Dim dr As SqlDataReader

        WLetra = ""
        WTipo = ""
        WPunto = ""
        WNumero = ""
        WImporte = ""
        ZZClaveCtaCtePrv = ""
        XImpre1 = ""
        XImpre2 = ""
        XImpre3 = ""
        WPrvDireccion = ""
        WPrvCuit = ""
        WPrvIb = ""

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

        Dim WCantFacts As Integer = Pagos.Rows.Cast(Of DataRow).Count(Function(r) Val(r.item("Importe")) <> 0)
        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To Pagos.Rows.Count - 1

            With Pagos.Rows(iRow)
                WLetra = .Item(1)
                WTipo = .Item(0)
                WPunto = .Item(2)
                WNumero = .Item(3)
                WImporte = .Item(4)

                If Trim(WTipo) = "" Then : Exit For
                End If

                ZZClaveCtaCtePrv = CodProveedor + WLetra + WTipo + WPunto + WNumero

                Select Case Val(.Item(0))
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

                XImpre2 = Mid(.Item(3), 1, 8)
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

                row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 1
                row.Item("Orden") = Val(NROORDENPAGO)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = WFecha
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = RazonSocial
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

                    row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                    row.Item("Tipo") = 2
                    row.Item("Orden") = Val(NROORDENPAGO)
                    row.Item("Renglon") = WRenglon
                    row.Item("Empresa") = WEmpNombre
                    row.Item("Direccion") = WEmpDireccion
                    row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
                    row.Item("Localidad") = WEmpLocalidad
                    row.Item("Fecha") = WFecha
                    row.Item("Cuit") = WEmpCuit
                    row.Item("Copia") = ImpreCopia(1)
                    row.Item("NroIb") = WNroIb
                    row.Item("NroAgente") = "" 'WNroAgente
                    row.Item("NombrePrv") = RazonSocial
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

            row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 1
            row.Item("Orden") = Val(NROORDENPAGO)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = WFecha
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = RazonSocial
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

                row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 2
                row.Item("Orden") = Val(NROORDENPAGO)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIVA
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = WFecha
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = RazonSocial
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

        Dim QuienFirma As String = ObtenerQuienFirma()
        crdoc.SetParameterValue("FirmaAImprimir", QuienFirma)

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc


            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, NROORDENPAGO & "OrdenPagoIVA.pdf", "C:/ImpreOrdenPagoTemp/")

        Else
            Dim cantImpre = IIf(WLimite = 15, 1, 2)
            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir(cantImpre)
            End With
        End If
    End Sub


    Private Sub _ImprimirComprobanteRetencionIBCiudad(ByVal Pagos As DataTable)
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
        Dim cm = New SqlCommand("SELECT Direccion, Cuit, NroIb, CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & Trim(CodProveedor) & "'")
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

        WPrvDireccion = ""
        WPrvCuit = ""
        WPrvIb = 0
        WTipoIb = 0
        ZZTipoIbCaba = 0
        ZZTipoiva = 0
        ZZPorceIbCaba = 0

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

        Dim WCantFacts As Integer = Pagos.Rows.Cast(Of DataRow).Count(Function(r) Val(r.Item("Importe")) <> 0)
        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To WLimite - 1

            With Pagos.Rows(iRow)
                WLetra = .Item(1)
                WTipo = .Item(0)
                WPunto = .Item(2)
                WNumero = .Item(3)

                ZZClaveCtaCtePrv = CodProveedor + WLetra + WTipo + WPunto + WNumero

                Select Case Val(.Item(0))
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

                XImpre2 = Mid(.Item(3), 1, 8)
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

                WImpre4 = Val(.Item(4))

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

                row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 1
                row.Item("Orden") = Val(NROORDENPAGO)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIbCiudad
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = WFecha
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = RazonSocial
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

                    row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                    row.Item("Tipo") = 2
                    row.Item("Orden") = Val(NROORDENPAGO)
                    row.Item("Renglon") = WRenglon
                    row.Item("Empresa") = WEmpNombre
                    row.Item("Direccion") = WEmpDireccion
                    row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIbCiudad
                    row.Item("Localidad") = WEmpLocalidad
                    row.Item("Fecha") = WFecha
                    row.Item("Cuit") = WEmpCuit
                    row.Item("Copia") = ImpreCopia(1)
                    row.Item("NroIb") = WNroIb
                    row.Item("NroAgente") = "" 'WNroAgente
                    row.Item("NombrePrv") = RazonSocial
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

            row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 1
            row.Item("Orden") = Val(NROORDENPAGO)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = WFecha
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = RazonSocial
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

                row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 2
                row.Item("Orden") = Val(NROORDENPAGO)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = WFecha
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = RazonSocial
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

        Dim QuienFirma As String = ObtenerQuienFirma()
        crdoc.SetParameterValue("FirmaAImprimir", QuienFirma)

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, NROORDENPAGO & "OrdenPagoIBCABA.pdf", "C:/ImpreOrdenPagoTemp/")

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
        Dim cm = New SqlCommand("SELECT ISNULL(TipoProv, 0) TipoProv, " & "ISNULL(TipoIva, 0) TipoIva, " & "ISNULL(TipoIb, 0) TipoIb, " & "ISNULL(TipoIbCaba, 0) TipoIbCaba, " & "ISNULL(PorceIb, 0) PorceIb, " & "ISNULL(PorceIbCaba, 0) PorceIbCaba, " & "ISNULL(RetencionesRegistradas, 0) RetencionesRegistradas " & "FROM Pagos WHERE Orden = '" & NROORDENPAGO & "' And Renglon IN ('1', '01')")
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

    Private WTipoProv, WTipoIva, WTipoIb, WTipoIbCaba, WPorceIb, WPorceIbCaba As String
    Private WCertificadoGan, WCertificadoIb, WCertificadoIbCiudad, WCertificadoIVA As String
    Private Sub _ImprimirComprobanteRetencionIB(ByVal pagos As DataTable)
        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As ReportDocument = New OrdenPagoComprobanteIB
        Dim ZZTipoIb As String = ""
        Dim ZZPorceIb As String = ""
        Dim WEmpNombre = "SURFACTAN S.A."
        Dim WEmpDireccion = "Malvinas Argentinas 4589"
        Dim WEmpLocalidad = "1644 Victoria Bs.As. Argentina"
        Dim WEmpCuit = "30-54916508-3"
        Dim WNroIb = "902-913585-2"
        Dim ImpreCopia(2) As String
        Dim WLetra, WTipo, WPunto, WNumero, ZZClaveCtaCtePrv, XImpre1, XImpre2, XImpre3, XImpre4, WImpre4, WPrvDireccion, WPrvCuit, WPrvIb As String
        Dim WImpoRetenido As Double
        Dim ZFechaCompa = String.Join("", Trim(WFecha).Split("/").Reverse())
        Dim WRete As Double
        Dim WRenglon = 0

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Direccion, Cuit, NroIb, CodIb, CodIbCaba, Iva, Tipo, PorceIb, PorceIbCaba FROM Proveedor WHERE Proveedor = '" & Trim(CodProveedor) & "'")
        Dim dr As SqlDataReader

        WLetra = ""
        WTipo = ""
        WPunto = ""
        WNumero = ""
        ZZClaveCtaCtePrv = ""
        XImpre1 = ""
        XImpre2 = ""
        XImpre3 = ""
        XImpre4 = ""
        WImpre4 = ""
        WPrvDireccion = ""
        WPrvCuit = ""
        WPrvIb = ""

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

        Dim WCantFacts As Integer = pagos.Rows.Cast(Of DataRow).Count(Function(r) Val(r.Item("Importe")) <> 0)

        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To pagos.Rows.Count - 1

            With pagos.Rows(iRow)
                If Trim(.Item(4)) <> "" Then
                    WLetra = .Item(1)
                    WTipo = .Item(0)
                    WPunto = .Item(2)
                    WNumero = .Item(3)

                    ZZClaveCtaCtePrv = CodProveedor + WLetra + WTipo + WPunto + WNumero

                    Select Case Val(.Item(0))
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

                    XImpre2 = Mid(.Item(3), 1, 8)
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

                    WImpre4 = Val(.Item(6)) ' ImpoNeto
                    XImpre4 = WImpre4

                    If Val(ZFechaCompa) >= 20071201 Then
                        Select Case ZZTipoIb
                            Case 0, 1
                                WRete = CDbl(XImpre4) * (CDbl(ZZPorceIb) / 100)
                                WImpoRetenido = WImpoRetenido + WRete

                                WRenglon = WRenglon + 1

                                row = Tabla.NewRow

                                row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                                row.Item("Tipo") = 1
                                row.Item("Orden") = Val(NROORDENPAGO)
                                row.Item("Renglon") = WRenglon
                                row.Item("Empresa") = WEmpNombre
                                row.Item("Direccion") = WEmpDireccion
                                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                                row.Item("Localidad") = WEmpLocalidad
                                row.Item("Fecha") = WFecha
                                row.Item("Cuit") = WEmpCuit
                                row.Item("Copia") = ImpreCopia(1)
                                row.Item("NroIb") = WNroIb
                                row.Item("NroAgente") = "" 'WNroAgente
                                row.Item("NombrePrv") = RazonSocial
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

                                    row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                                    row.Item("Tipo") = 2
                                    row.Item("Orden") = Val(NROORDENPAGO)
                                    row.Item("Renglon") = WRenglon
                                    row.Item("Empresa") = WEmpNombre
                                    row.Item("Direccion") = WEmpDireccion
                                    row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                                    row.Item("Localidad") = WEmpLocalidad
                                    row.Item("Fecha") = WFecha
                                    row.Item("Cuit") = WEmpCuit
                                    row.Item("Copia") = ImpreCopia(1)
                                    row.Item("NroIb") = WNroIb
                                    row.Item("NroAgente") = "" 'WNroAgente
                                    row.Item("NombrePrv") = RazonSocial
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

                                row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                                row.Item("Tipo") = 1
                                row.Item("Orden") = Val(NROORDENPAGO)
                                row.Item("Renglon") = WRenglon
                                row.Item("Empresa") = WEmpNombre
                                row.Item("Direccion") = WEmpDireccion
                                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                                row.Item("Localidad") = WEmpLocalidad
                                row.Item("Fecha") = WFecha
                                row.Item("Cuit") = WEmpCuit
                                row.Item("Copia") = ImpreCopia(1)
                                row.Item("NroIb") = WNroIb
                                row.Item("NroAgente") = "" 'WNroAgente
                                row.Item("NombrePrv") = RazonSocial
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

                                    row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                                    row.Item("Tipo") = 2
                                    row.Item("Orden") = Val(NROORDENPAGO)
                                    row.Item("Renglon") = WRenglon
                                    row.Item("Empresa") = WEmpNombre
                                    row.Item("Direccion") = WEmpDireccion
                                    row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                                    row.Item("Localidad") = WEmpLocalidad
                                    row.Item("Fecha") = WFecha
                                    row.Item("Cuit") = WEmpCuit
                                    row.Item("Copia") = ImpreCopia(1)
                                    row.Item("NroIb") = WNroIb
                                    row.Item("NroAgente") = "" 'WNroAgente
                                    row.Item("NombrePrv") = RazonSocial
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

                                row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                                row.Item("Tipo") = 1
                                row.Item("Orden") = Val(NROORDENPAGO)
                                row.Item("Renglon") = WRenglon
                                row.Item("Empresa") = WEmpNombre
                                row.Item("Direccion") = WEmpDireccion
                                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                                row.Item("Localidad") = WEmpLocalidad
                                row.Item("Fecha") = WFecha
                                row.Item("Cuit") = WEmpCuit
                                row.Item("Copia") = ImpreCopia(1)
                                row.Item("NroIb") = WNroIb
                                row.Item("NroAgente") = "" 'WNroAgente
                                row.Item("NombrePrv") = RazonSocial
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

                                    row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                                    row.Item("Tipo") = 2
                                    row.Item("Orden") = Val(NROORDENPAGO)
                                    row.Item("Renglon") = WRenglon
                                    row.Item("Empresa") = WEmpNombre
                                    row.Item("Direccion") = WEmpDireccion
                                    row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                                    row.Item("Localidad") = WEmpLocalidad
                                    row.Item("Fecha") = WFecha
                                    row.Item("Cuit") = WEmpCuit
                                    row.Item("Copia") = ImpreCopia(1)
                                    row.Item("NroIb") = WNroIb
                                    row.Item("NroAgente") = "" 'WNroAgente
                                    row.Item("NombrePrv") = RazonSocial
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

            row.Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
            row.Item("Tipo") = 1
            row.Item("Orden") = Val(NROORDENPAGO)
            row.Item("Renglon") = WRenglon
            row.Item("Empresa") = WEmpNombre
            row.Item("Direccion") = WEmpDireccion
            row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
            row.Item("Localidad") = WEmpLocalidad
            row.Item("Fecha") = WFecha
            row.Item("Cuit") = WEmpCuit
            row.Item("Copia") = ImpreCopia(1)
            row.Item("NroIb") = WNroIb
            row.Item("NroAgente") = "" 'WNroAgente
            row.Item("NombrePrv") = RazonSocial
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

                row.Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + ceros(WRenglon, 2)
                row.Item("Tipo") = 2
                row.Item("Orden") = Val(NROORDENPAGO)
                row.Item("Renglon") = WRenglon
                row.Item("Empresa") = WEmpNombre
                row.Item("Direccion") = WEmpDireccion
                row.Item("Titulo") = "Nro.Certificado  : " & WCertificadoIb
                row.Item("Localidad") = WEmpLocalidad
                row.Item("Fecha") = WFecha
                row.Item("Cuit") = WEmpCuit
                row.Item("Copia") = ImpreCopia(1)
                row.Item("NroIb") = WNroIb
                row.Item("NroAgente") = "" 'WNroAgente
                row.Item("NombrePrv") = RazonSocial
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

        Dim QuienFirma As String = ObtenerQuienFirma()
        crdoc.SetParameterValue("FirmaAImprimir", QuienFirma)


        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc


            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, NROORDENPAGO & "OrdenPagoIB.pdf", "C:/ImpreOrdenPagoTemp/")

        Else
            Dim cantImpre = IIf(WLimite = 15, 1, 2)
            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir(cantImpre)
            End With
        End If
    End Sub
    Private Function _TraerDatosProveedor() As String()
        Dim datos(8) As String
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT p.CertificadoGan, p.CertificadoIb, p.CertificadoIbCiudad, p.CertificadoIva, pr.Direccion, pr.Nombre, pr.Cuit, pr.Tipo " & "FROM Pagos as p, Proveedor as pr where p.Orden = '" & Trim(NROORDENPAGO) & "' and (p.Renglon = '01' or p.Renglon = '1') and p.Proveedor = pr.Proveedor")
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
            .Item("Clave") = "1" + ceros(NROORDENPAGO, 6) + "00"
            .Item("Tipo") = 1
            .Item("Orden") = Val(NROORDENPAGO)
            .Item("Renglon") = 0
            .Item("NroCertificado") = _DatosProv(0)
            .Item("Empresa") = WEmpNombre
            .Item("Direccion") = WEmpDireccion
            .Item("Localidad") = WEmpLocalidad
            .Item("Fecha") = WFecha
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
                .Item("Clave") = "2" + ceros(NROORDENPAGO, 6) + "00"
                .Item("Tipo") = 2
                .Item("Orden") = Val(NROORDENPAGO)
                .Item("Renglon") = 0
                .Item("NroCertificado") = _DatosProv(0)
                .Item("Empresa") = WEmpNombre
                .Item("Direccion") = WEmpDireccion
                .Item("Localidad") = WEmpLocalidad
                .Item("Fecha") = WFecha
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

        Dim QuienFirma As String = ObtenerQuienFirma()
        crdoc.SetParameterValue("FirmaAImprimir", QuienFirma)

        If GenerarPDF Then

            crdoc.SetParameterValue("MostrarFirma", 1)

            Dim frm2 As New Util.VistaPrevia
            frm2.Reporte = crdoc

            Conexion.EmpresaDeTrabajo = "SurfactanSa"

            If _EsPellital() Then Conexion.EmpresaDeTrabajo = "PellitalSa"

            Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, NROORDENPAGO & "OrdenPagoGanancias.pdf", "C:/ImpreOrdenPagoTemp/")

        Else

            With New VistaPrevia
                .Reporte = crdoc
                '.Mostrar()
                .Imprimir()
            End With

        End If
    End Sub
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
    Private Sub _ImprimirDiscriminacionDeValoresDeTerceros(ByVal XRazon As String, ByVal XCuitProveedor As String, ByVal formaPagos As DataTable)
        Dim ZZOrden, ZZRenglon, ZZProveedor, ZZFecha, ZZNumeroCheque, ZZFechaCheque, ZZBancoCheque, ZZCuit As String
        Dim ZZImporteCheque As Double
        Dim LugarResumen = 0

        Dim Tabla As New DataTable("Detalles")
        Dim row As DataRow
        Dim crdoc As New OrdenPagoDiscriminacionTerceros

        _PrepararTablaOrdenPagoDiscriminacionTerceros(Tabla)

        Dim WCantFacts As Integer = formaPagos.Rows.Cast(Of DataRow).Count(Function(r) Val(r.Item(5)) <> 0 And Val(r.Item(3)) = 3)

        Dim WLimite As Integer = IIf(WCantFacts > 15, 30, 15)

        For iRow = 0 To formaPagos.Rows.Count - 1
            With formaPagos.Rows(iRow)
                If Val(.Item(5)) <> 0 Then
                    If Val(.Item(0)) = 3 Or Val(.Item(0)) = 7 Then

                        ZZOrden = NROORDENPAGO
                        ZZRenglon = Str$(LugarResumen)
                        ZZProveedor = CodProveedor
                        ZZFecha = WFecha
                        ZZImporteCheque = Val(.Item(5))
                        ZZNumeroCheque = .Item(1)
                        ZZFechaCheque = .Item(2)
                        ZZBancoCheque = .Item(4)
                        ZZCuit = .Item(7)
                        Dim ZZTipo = Val(.Item("Tipo2"))

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

            ZZOrden = NROORDENPAGO
            ZZRenglon = Str$(LugarResumen)
            ZZProveedor = CodProveedor
            ZZFecha = WFecha
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

                Helper._ExportarReporte(frm2, Enumeraciones.FormatoExportacion.PDF, NROORDENPAGO & "OrdenPagoChTerceros.pdf", "C:/ImpreOrdenPagoTemp/")

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
    Private Function ObtenerQuienFirma() As String
        Dim Respuesta As String = ""
        Dim SQLCnslt As String = "SELECT OperadorClave FROM Pagos WHERE Orden = '" & NROORDENPAGO & "'"
        Dim RowOrden As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowOrden IsNot Nothing Then
            Dim OperadorClave As String = Trim(UCase(RowOrden.Item("OperadorClave")))
            Select Case OperadorClave
                Case "39235"
                    Respuesta = "Pachi"
                Case "XINGO"
                    Respuesta = "Alejandro"
                Case "SERGIO"
                    Respuesta = "Sergio"
                Case "LUCAS2021"
                    Respuesta = "Lucas"
            End Select
        End If
        Return Respuesta
    End Function
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
            .Columns.Add("Tipo2")
        End With
    End Sub

    Dim WClavesOP(100) As String
  

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
        Dim cm = New SqlCommand("SELECT Iva21, Iva5, Iva27, Iva105, Ib, Exento, Neto  FROM IvaComp WHERE Proveedor = '" & CodProveedor & "' AND Tipo = '" & ztipo & "' AND Letra = '" & zletra & "' AND Punto = '" & zpunto & "' AND Numero = '" & znumero & "'")
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

    Private Function _NormalizarNumero(ByVal znumero As Object, Optional ByVal decimales As Integer = 2)
        If IsDBNull(znumero) Then
            znumero = ""
        End If
        Return Val(formatonumerico(Trim(znumero), decimales))
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

    Private Sub dgv_Pagos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Pagos.CellMouseClick
        dgv_Pagos.CurrentRow.Selected = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub txt_FechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaDesde.Text) = "S" Then
                    txt_FechaHasta.Focus()
                Else
                    MsgBox("No es una fecha valida verificar", vbExclamation)
                    txt_FechaDesde.SelectAll()
                End If
            Case Keys.Escape
                txt_FechaDesde.Text = ""
        End Select
    End Sub
    Private Sub txt_FechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_FechaHasta.Text) = "S" Then
                    cbx_QuienHizo.Focus()
                Else
                    MsgBox("No es una fecha valida verificar", vbExclamation)
                    txt_FechaHasta.SelectAll()
                End If
            Case Keys.Escape
                txt_FechaHasta.Text = ""
        End Select

    End Sub

    Private Sub dgv_Pagos_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Pagos.RowHeaderMouseDoubleClick
        If MsgBox("¿Desea sacar de la lista la orden Nº: " & dgv_Pagos.CurrentRow.Cells("NroPago").Value & "?", vbYesNo) = vbYes Then
            Dim dgvRow As DataGridViewRow = dgv_Pagos.CurrentRow
            dgv_Pagos.Rows.Remove(dgvRow)
        End If
    End Sub

    Private Sub btn_ImprimirTodo_Click(sender As Object, e As EventArgs) Handles btn_ImprimirTodo.Click
        If dgv_Pagos.Rows.Count > 0 Then
            For Each dgvRow As DataGridViewRow In dgv_Pagos.Rows
                Try
                    Dim orden As String = dgvRow.Cells("NroPago").Value
                    Imprimir(orden)
                    ActualizaImpresionOrden(orden)
                Catch ex As Exception

                End Try

            Next
            btn_Aceptar_Click(Nothing, Nothing)
        Else
            MsgBox("No se encuentran ordenes para imprimir en la grilla", vbExclamation)
        End If
    End Sub
End Class