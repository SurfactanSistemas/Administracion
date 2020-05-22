Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports Util

Public Class CuentaCorrientePantalla : Implements IAyudaGeneral

    Private _NrosInternos As New List(Of Object)
    Private WPOSINICIALCONSULTA As Point
    Private WPOSINICIALCERRAR As Point
    Private WPOSINICIALLIMPIAR As Point

    Private Sub CuentaCorrientePantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()

        WPOSINICIALCONSULTA = btnConsulta.Location
        WPOSINICIALCERRAR = btnCancela.Location
        WPOSINICIALLIMPIAR = btnLimpiar.Location

        opcPendiente.Checked = True
        opcCompleto.Checked = False
        pnlSelectivo.Visible = False

        GRilla.Columns("Fecha").ValueType = GetType(Date)
        GRilla.Columns("Vencimiento").ValueType = GetType(Date)

        Proceso._PurgarSaldosCtaCtePrvs()
    End Sub

    Private Sub _Proceso()

        Dim WRenglon As Integer
        Dim WSuma As Double

        GRilla.Rows.Clear()
        _NrosInternos.Clear()
        WRenglon = 0

        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo
        Dim WTipo As Char
        WTipo = "T"

        If (opcPendiente.Checked) Then
            WTipo = "P"
        End If
        WSuma = 0

        REM dada fix CAMBIAR Al uso de dao!!
        Dim tabla As DataTable
        tabla = _BuscarCuentaCorrienteProveedorDeuda(txtProveedor.Text, WTipo) 'SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_deuda", txtProveedor.Text, WTipo)

        If tabla.Rows.Count > 0 Then

            For Each row As DataRow In tabla.Rows

                GRilla.Rows.Add()

                GRilla.Item("Tipo", WRenglon).Value = row.Item("Impre") 'CamposCtaCtePrv.Impre

                If row.Item("NroInterno") <> 0 Then
                    Dim WIvaComp As DataRow = _TraerDatosIvaComp(row.Item("NroInterno"))

                    If Not IsNothing(WIvaComp) Then
                        GRilla.Item("Tipo", WRenglon).Value = IIf(WIvaComp.Item("MarcaDifCambio") = 1, "NDC", row.Item("Impre"))
                    End If

                End If

                GRilla.Item("Letra", WRenglon).Value = row.Item("Letra") 'CamposCtaCtePrv.letra
                GRilla.Item("Punto", WRenglon).Value = row.Item("Punto") 'CamposCtaCtePrv.punto
                GRilla.Item("Numero", WRenglon).Value = row.Item("Numero") 'CamposCtaCtePrv.numero
                GRilla.Item("Importe", WRenglon).Value = formatonumerico(row.Item("Total"))

                If row.Item("Total") < 0 Then

                    GRilla.Item("Credito", WRenglon).Value = formatonumerico(-1 * row.Item("Total"))

                Else

                    GRilla.Item("Debito", WRenglon).Value = formatonumerico(row.Item("Total"))

                End If

                GRilla.Item("Saldo", WRenglon).Value = formatonumerico(row.Item("Saldo"))
                GRilla.Item("Fecha", WRenglon).Value = row.Item("Fecha") 'CamposCtaCtePrv.fecha
                GRilla.Item("OrdFecha", WRenglon).Value = Proceso.ordenaFecha(row.Item("Fecha"))
                GRilla.Item("Vencimiento", WRenglon).Value = row.Item("Vencimiento") 'CamposCtaCtePrv.vencimiento
                GRilla.Item("OrdVencimiento", WRenglon).Value = Proceso.ordenaFecha(row.Item("Vencimiento"))

                If OrDefault(row.Item("MarcaVirtual"), "") = "X" Then
                    GRilla.Rows(WRenglon).DefaultCellStyle.BackColor = IIf(OrDefault(row.Item("Impre"), "") = "OP", Color.LightBlue, Color.GreenYellow)
                End If

                GRilla.CurrentCell = GRilla.Rows(WRenglon).Cells(0)
                GRilla.Focus()

                WRenglon = WRenglon + 1
                WSuma = WSuma + row.Item("Saldo") 'CamposCtaCtePrv.saldo

                _NrosInternos.Add({row.Item("Numero"), row.Item("NroInterno")})

                GRilla.Refresh()

            Next
        Else
            GRilla.Rows.Add()
        End If

        GRilla.AllowUserToAddRows = False
        txtSaldo.Text = formatonumerico(WSuma)
    End Sub

    Private Function _TraerDatosIvaComp(ByVal nroInterno As Object) As DataRow

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ISNULL(MarcaDifCambio, 0) As MarcaDifCambio FROM IvaComp WHERE NroInterno = '" & nroInterno & "'")
        Dim dr As SqlDataReader

        Try

            SQLConnector.conexionSql(cn, cm)

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                Dim WTabla As New DataTable

                WTabla.Load(dr)

                If WTabla.Rows.Count > 0 Then
                    Return WTabla.Rows(0)
                Else
                    Return Nothing
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

        Return Nothing

    End Function

    Private Function _BuscarCuentaCorrienteProveedorDeuda(ByVal WProveedor As String, ByVal wTipo As Char) As DataTable
        Dim _tabla As New DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim ZSql = ""

        Try

            ZSql = "select LTRIM(RTRIM(ISNULL(CtaCtePrv.Tipo, ''))) as Tipo " _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.Letra, ''))) as Letra" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.Punto, ''))) as Punto" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.Numero, ''))) as Numero" _
                & ", ISNULL(CtaCtePrv.Total, 0) as Total" _
                & ", ISNULL(CtaCtePrv.Saldo, 0) as Saldo" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.fecha, ''))) as Fecha" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.Vencimiento, ''))) as Vencimiento" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.NroInterno, 0))) as NroInterno" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.Impre, ''))) as Impre" _
                & ", LTRIM(RTRIM(ISNULL(CtaCtePrv.MarcaVirtual, ''))) as MarcaVirtual" _
                & " FROM CtaCtePrv" _
                & " WHERE CtaCtePrv.Proveedor = '" & WProveedor & "'" _
                & "#PARCIAL#" _
                & " ORDER BY CtaCtePrv.Proveedor, CtaCtePrv.OrdFecha, CtaCtePrv.Tipo,CtaCtePrv.Numero"

            If wTipo = "P" Then
                ZSql = ZSql.Replace("#PARCIAL#", " AND Saldo <> 0")
            Else
                ZSql = ZSql.Replace("#PARCIAL#", "")
            End If


            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn
            cm.CommandText = ZSql

            dr = cm.ExecuteReader()

            _tabla.Load(dr)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer los Movimientos del Proveedor desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _tabla
    End Function

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        Try
            With New AyudaGeneral(GetAll("SELECT Proveedor As Codigo, Nombre As Descripcion FROM Proveedor ORDER BY Proveedor"), "AYUDA DE PROVEEDORES")
                .ShowDialog(Me)
            End With
            'boxPantallaProveedores.Visible = True

            ''Dim WProveedores = DAOProveedor.buscarProveedoresActivoPorNombre("")

            'Dim WProveedores As New DataTable

            'WProveedores = _TraerProveedoresActivos()

            'lstAyuda.Items.Clear()

            'If Not IsNothing(WProveedores) Then

            '    For Each WProveedor As DataRow In WProveedores.Rows

            '        lstAyuda.Items.Add(WProveedor.Item("Proveedor").PadLeft(11) & Space(5) & WProveedor.Item("Nombre"))

            '    Next

            'End If

            'txtAyuda.Text = ""
            'txtAyuda.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function _TraerProveedoresActivos() As DataTable

        Dim tabla As New DataTable
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Proveedor, Nombre FROM Proveedor WHERE Inhabilitado <> '1' OR Inhabilitado is null")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer listar los Proveedores Activos desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla

    End Function

    Private Sub _TraerSaldoCuentaProveedor(ByVal proveedor As DataRow)

        Dim cliente As String = IIf(IsDBNull(proveedor.Item("ClienteAsociado")), "", proveedor.Item("ClienteAsociado"))
        Dim WSaldo = "0"

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        If Trim(cliente) = "" Then
            lblSaldoCuentaProveedor.Text = Proceso.formatonumerico(WSaldo)
            Exit Sub
        End If

        Try
            cm.CommandText = "SELECT TOP 1 Cliente FROM CtaCte WHERE Cliente = '" & Trim(cliente) & "'"
            SQLConnector.conexionSql(cn, cm)
            dr = cm.ExecuteReader()

            With dr
                If Not .HasRows Then
                    Exit Sub
                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Information)
        Finally

            'dr = Nothing
            cn.Close()
            'cn = Nothing
            'cm = Nothing

        End Try

        Try
            cm.CommandText = "SELECT SUM(Saldo) as SaldoTotal FROM CtaCte WHERE Cliente = '" & Trim(cliente) & "'"
            SQLConnector.conexionSql(cn, cm)
            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then
                    .Read()
                    WSaldo = .Item("SaldoTotal")

                    gbSaldoCtaCliente.Visible = True
                Else
                    gbSaldoCtaCliente.Visible = False
                End If
            End With

        Catch ex As Exception
            gbSaldoCtaCliente.Visible = False
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Information)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        lblClienteAsociado.Text = Trim(cliente)
        lblSaldoCuentaProveedor.Text = "$ " & formatonumerico(WSaldo)
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As DataRow)

        If IsNothing(proveedor) Then : Exit Sub
        End If

        ' Reseteamos resumen de montos automático.
        gbSaldoCtaCliente.Visible = False
        GroupBox1.Visible = False
        btnCancela.Location = WPOSINICIALCERRAR 'New Point(342, 541)
        btnConsulta.Location = WPOSINICIALCONSULTA 'New Point(213, 541)
        btnLimpiar.Location = WPOSINICIALLIMPIAR 'New Point(471, 541)


        'lstFiltrada.Visible = False
        txtProveedor.Text = proveedor.Item("Proveedor")
        txtRazon.Text = proveedor.Item("Nombre")
        boxPantallaProveedores.Visible = False
        _TraerProveedorSelectivo()
        _TraerSaldoCuentaProveedor(proveedor)
        Call _Proceso()

        'GRilla.CurrentCell = GRilla.Rows(0).Cells(0) ' Nos posicionamos en la grilla.
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click

        If String.IsNullOrEmpty(lstAyuda.SelectedItem) Then Exit Sub

        Dim Wcodigo = Microsoft.VisualBasic.Left$(lstAyuda.SelectedItem, 11)

        Dim WProveedor As New DataTable

        WProveedor = _TraerProveedorPorCodigo(WCodigo)

        'Dim WProveedor = DAOProveedor.buscarProveedorPorCodigo(Wcodigo)

        If IsNothing(WProveedor) Then Exit Sub

        If WProveedor.Rows.Count > 0 Then
            mostrarProveedor(WProveedor.Rows(0))
        End If

    End Sub

    Private Function _TraerProveedorPorCodigo(ByVal WCodigo As String) As DataTable

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT * FROM Proveedor WHERE Proveedor = '" & WCodigo & "'")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos completos del Proveedor desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla

    End Function

    Private Sub _TraerProveedorSelectivo()
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Proveedor, Fecha FROM ProveedorSelectivo WHERE Proveedor = '" & Trim(txtProveedor.Text) & "' AND FechaOrd >= '" & String.Join("", Date.Now.ToString("dd/MM/yyyy").Split("/").Reverse()) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                CBProveedorSelectivo.Checked = True
                txtFechaSelectivo.Text = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))

            Else
                CBProveedorSelectivo.Checked = False
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los datos de Proveedor selectivo desde la Base de Datos." & vbCrlf & "Motivo: " & ex.Message, MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub opcCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcCompleto.CheckedChanged
        Call _Proceso()
    End Sub

    Private Function _AltaProveedorSelectivo(ByVal CodProveedor As String, ByVal WFecha As String) As Boolean
        Dim exito = False
        Dim XFecha As String = Trim(WFecha)
        Dim _FechaOrd As String = String.Join("", XFecha.Split("/").Reverse())
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("INSERT INTO ProveedorSelectivo (Proveedor, Fecha, FechaOrd) Values ('" & CodProveedor & "', '" & XFecha & "', '" & _FechaOrd & "')")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()
            exito = True

        Catch ex As Exception
            MsgBox("Hubo un problema al querer agregar al proveedor al listado de Proveedores Selectivo en la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return exito
    End Function

    Private Function _BuscarFechaSelectivo() As String

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT TOP 1 Fecha FROM ProveedorSelectivo ORDER BY FechaOrd DESC")
        Dim dr As SqlDataReader
        Dim WFecha = ""

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                WFecha = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try


        Return WFecha


    End Function

    Private Function _EliminarProveedorSelectivo(ByVal codProv As String, ByVal WFecha As String) As Boolean
        Dim exito = False
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("DELETE FROM ProveedorSelectivo WHERE Proveedor = '" & Trim(codProv) & "' AND Fecha = '" & WFecha & "'")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()
            exito = True

        Catch ex As Exception
            MsgBox("Hubo un problema al querer eliminar el Proveedor del periodo actual.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return exito
    End Function

    Private Sub CBProveedorSelectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBProveedorSelectivo.Click

        If CBProveedorSelectivo.Checked Then

            txtFechaSelectivo.Text = _BuscarFechaSelectivo()
            pnlSelectivo.Visible = True
            txtFechaSelectivo.Focus()

        Else

            _GrabarSelectivo(txtFechaSelectivo.Text)
            pnlSelectivo.Visible = False

        End If

    End Sub

    Private Sub _GrabarSelectivo(ByVal WFecha As String)

        If Trim(txtProveedor.Text) <> "" Then
            If CBProveedorSelectivo.Checked Then

                If MsgBox("¿Está seguro de que quiere colocar al proveedor actual al listado de Proveedores Selectivos?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

                    If Not _AltaProveedorSelectivo(txtProveedor.Text, WFecha) Then
                        CBProveedorSelectivo.Checked = False
                        MsgBox("Hubo un error al querer colocar al proveeedor en la lista de Proveedores Selectivo.", MsgBoxStyle.Critical)
                    End If

                Else
                    CBProveedorSelectivo.Checked = False
                End If

            Else

                If MsgBox("¿Está seguro de que quiere eliminar al proveedor actual del listado de Proveedores Selectivos?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

                    If Not _EliminarProveedorSelectivo(txtProveedor.Text, WFecha) Then
                        CBProveedorSelectivo.Checked = True
                        MsgBox("Hubo un error al querer eliminar al proveeedor de la lista de Proveedores Selectivo.", MsgBoxStyle.Critical)
                    End If

                Else
                    CBProveedorSelectivo.Checked = True
                End If

            End If
        End If
    End Sub

    Private Sub GRilla_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GRilla.CellMouseDoubleClick
        Dim _NroInterno = ""
        Dim WNumero = "" ' Guardamos el numero de factura para buscar el nro interno.

        If e.RowIndex >= 0 Then
            WNumero = GRilla.Rows(e.RowIndex).Cells("Numero").Value
        Else
            Exit Sub
        End If

        If IsNothing(WNumero) Then Exit Sub

        Try
            _NroInterno = _NrosInternos.FindLast(Function(n) n(0) = WNumero)(1)
        Catch ex As Exception
            _NroInterno = Nothing
        End Try

        ' Comprobamos que se encuentre un nro interno.
        If IsNothing(_NroInterno) Then
            Exit Sub
        End If


        Select Case GRilla.Rows(e.RowIndex).Cells(0).Value
            Case "OP", "AN"
                With Pagos
                    .SoloLectura = True
                    .txtOrdenPago.Text = WNumero
                    .txtOrdenPago_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    .ShowDialog()
                End With
            Case "FC", "ND", "NC", "OC"
                With ConsultaDatosFactura

                    .NroInterno = _NroInterno

                    .ShowDialog()

                End With
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyData = Keys.Enter Then

            GroupBox1.Visible = False

            If Trim(txtProveedor.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            Try
                Dim WProveedor As DataTable = _TraerDatosProveedor(txtProveedor.Text)

                If WProveedor.Rows.Count > 0 Then

                    txtProveedor.Text = WProveedor.Rows(0).Item("Proveedor")
                    txtRazon.Text = WProveedor.Rows(0).Item("Nombre")

                    mostrarProveedor(WProveedor(0))

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Dim CampoProveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
            'If IsNothing(CampoProveedor) Then
            '    MsgBox("Proveedor incorrecto")
            '    txtProveedor.Focus()
            'Else
            '    mostrarProveedor(CampoProveedor)

            '    If GRilla.Rows.Count > 0 Then
            '        GRilla.CurrentCell = GRilla.Rows(0).Cells(0)
            '    Else
            '        txtProveedor.Focus()
            '    End If

            'End If

        ElseIf e.KeyData = Keys.Escape Then
            txtProveedor.Text = ""
            txtRazon.Text = ""
        End If
        If Not IsNumeric(e.KeyCode) Then
            e.Handled = True
        End If
    End Sub

    Private Function _TraerDatosProveedor(ByVal WProveedor As String) As datatable
        Dim tabla As New DataTable
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT * FROM Proveedor WHERE Proveedor = '" & WProveedor & "' ")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Proceso._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos del Proveedor desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return tabla

    End Function

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick

        btnConsulta.PerformClick()
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstAyuda
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)

        ' Sacamos de vista los resultados filtrados.
    End Sub

    Private Sub lblSaldoCuentaProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSaldoCuentaProveedor.MouseDoubleClick
        _AbrirDetallesFactura()
    End Sub

    Private Sub _AbrirDetallesFactura()
        With CtaCtePrvPantallaDetallesCliente
            .Cliente = lblClienteAsociado.Text
            .SaldoTotal = lblSaldoCuentaProveedor.Text

            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub lblClienteAsociado_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClienteAsociado.MouseDoubleClick
        _AbrirDetallesFactura()
    End Sub

    Private Sub GRilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GRilla.CellMouseUp
        Dim _filas As New List(Of DataGridViewRow)
        Dim _WTotalFC, _WTotalND, _WTotalNC, _WTotalPagos, _Valor As Double
        Dim comienzo, final, actual As Integer

        comienzo = 0
        final = 0
        actual = 0

        _WTotalFC = 0
        _WTotalNC = 0
        _WTotalND = 0
        _WTotalPagos = 0

        If GRilla.SelectedCells.Count < 2 Then : Exit Sub
        End If

        Dim _c

        For Each _cell As DataGridViewCell In GRilla.SelectedCells
            _c = _cell
            If IsNothing(_filas.Find(Function(_f) _f.Index = _c.RowIndex)) Then

                _filas.Add(GRilla.Rows(_cell.RowIndex))

            End If
        Next

        For Each _rows As DataGridViewRow In _filas
            _Valor = 0

            With _rows

                If Not IsNothing(.Cells("Importe").Value) Then

                    _Valor = Proceso.formatonumerico(.Cells("Importe").Value).replace(".", ",")

                    If _Valor <> 0 Then
                        Select Case .Cells("Tipo").Value
                            Case "FC"
                                _WTotalFC += _Valor
                            Case "ND"
                                _WTotalND += _Valor
                            Case "NC"
                                _WTotalNC += _Valor
                            Case "OP", "AN"
                                _WTotalPagos += _Valor
                        End Select

                    End If

                End If
                actual = Val(Proceso.ordenaFecha(.Cells("Fecha").Value.ToString))

                ' Determinamos el rango en el cual estamos trabajando.
                If comienzo = 0 Or final = 0 Then
                    comienzo = actual
                    final = actual
                ElseIf comienzo > actual Then
                    comienzo = actual
                ElseIf final < actual Then
                    final = actual
                End If

            End With

        Next

        ' Asignamos los totales.
        lblTotalFC.Text = "$ " & _WTotalFC
        lblTotalND.Text = "$ " & _WTotalND
        lblTotalNC.Text = "$ " & _WTotalNC
        lblTotalPagos.Text = "$ " & _WTotalPagos

        ' Animamos los botones para dar lugar al panel con la información de los totales.
        For i = btnCancela.Location.X To 280 Step -1
            btnConsulta.Location = New Point(i - 258, btnCancela.Location.Y)
            btnCancela.Location = New Point(i - 129, btnCancela.Location.Y)
            btnLimpiar.Location = New Point(i, btnCancela.Location.Y)
            Threading.Thread.Sleep(0.8)
        Next

        ' Mostramos el panel y le colocamos el titulo junto con el periodo determinado mas arriba.
        GroupBox1.Visible = True
        GroupBox1.Text = "Montos detallados por periodo: " & Proceso.DesOrdenaFecha(comienzo) & " al " & Proceso.DesOrdenaFecha(final)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtProveedor.Text = ""
        txtRazon.Text = ""
        txtSaldo.Text = "0.00"
        opcCompleto.Checked = True
        CBProveedorSelectivo.Checked = False
        gbSaldoCtaCliente.Visible = False

        GroupBox1.Visible = False
        btnCancela.Location = WPOSINICIALCERRAR ' New Point(342, 541)
        btnConsulta.Location = WPOSINICIALCONSULTA ' New Point(213, 541)
        btnLimpiar.Location = WPOSINICIALLIMPIAR 'New Point(471, 541)

        txtProveedor.Focus()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSaldo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub GRilla_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles GRilla.SortCompare

        GRilla.ClearSelection()

        Dim num1, num2

        Select Case e.Column.Index
            Case 1, 3, 4, 5

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 2, 6

                num1 = Proceso.ordenaFecha(e.CellValue1)
                num2 = Proceso.ordenaFecha(e.CellValue2)

            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True
    End Sub

    Private Sub btnCerrarConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        boxPantallaProveedores.Visible = False
        txtProveedor.Focus()
    End Sub

    Private Sub btnCerrarFechaSelectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarFechaSelectivo.Click
        pnlSelectivo.Visible = False
        CBProveedorSelectivo.Checked = False
        txtFechaSelectivo.Clear()
    End Sub

    Private Sub btnGrabarSelectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarSelectivo.Click

        If Proceso._ValidarFecha(txtFechaSelectivo.Text) Then

            _GrabarSelectivo(txtFechaSelectivo.Text)
            pnlSelectivo.Visible = False

        End If

    End Sub

    Private Sub txtFechaSelectivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaSelectivo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaSelectivo.Text).Length < 10 Then : Exit Sub : End If

            If Not Proceso._ValidarFecha(txtFechaSelectivo.Text) Then

                MsgBox("Fecha Invalida", MsgBoxStyle.Exclamation)
                txtFechaSelectivo.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaSelectivo.Clear()
        End If

    End Sub

    Public Sub _ProcesarAyudaGeneral(row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        txtProveedor.Text = row.Cells("Codigo").Value
        txtProveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub
End Class