Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class CuentaCorrientePantalla

    Private _NrosInternos As New List(Of Object)
    Private WPOSINICIALCONSULTA As Point
    Private WPOSINICIALCERRAR As Point
    Private WPOSINICIALLIMPIAR As Point

    Private Sub CuentaCorrientePantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Proceso.NombreEmpresa()

        WPOSINICIALCONSULTA = btnConsulta.Location
        WPOSINICIALCERRAR = btnCancela.Location
        WPOSINICIALLIMPIAR = btnLimpiar.Location

        opcPendiente.Checked = True
        opcCompleto.Checked = False

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

                WRenglon = WRenglon + 1
                WSuma = WSuma + row.Item("Saldo") 'CamposCtaCtePrv.saldo

                _NrosInternos.Add({row.Item("Numero"), row.Item("NroInterno")})

            Next
        Else
            GRilla.Rows.Add()
        End If

        GRilla.AllowUserToAddRows = False
        txtSaldo.Text = formatonumerico(WSuma)
    End Sub

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

            boxPantallaProveedores.Visible = True

            'Dim WProveedores = DAOProveedor.buscarProveedoresActivoPorNombre("")

            Dim WProveedores As New DataTable

            WProveedores = _TraerProveedoresActivos()

            lstAyuda.Items.Clear()

            If Not IsNothing(WProveedores) Then

                For Each WProveedor As DataRow In WProveedores.Rows

                    lstAyuda.Items.Add(WProveedor.Item("Proveedor").PadLeft(11) & Space(5) & WProveedor.Item("Nombre"))

                Next

            End If

            txtAyuda.Text = ""
            txtAyuda.Focus()

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

    Private Sub mostrarProveedor(ByVal proveedor As DataRow)

        If IsNothing(proveedor) Then : Exit Sub
        End If

        ' Reseteamos resumen de montos automático.
        GroupBox1.Visible = False
        btnCancela.Location = WPOSINICIALCERRAR 'New Point(342, 541)
        btnConsulta.Location = WPOSINICIALCONSULTA 'New Point(213, 541)
        btnLimpiar.Location = WPOSINICIALLIMPIAR 'New Point(471, 541)


        'lstFiltrada.Visible = False
        txtProveedor.Text = proveedor.Item("Proveedor")
        txtRazon.Text = proveedor.Item("Nombre")
        boxPantallaProveedores.Visible = False
        Call _Proceso()

        GRilla.CurrentCell = GRilla.Rows(0).Cells(0) ' Nos posicionamos en la grilla.
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

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub opcCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcCompleto.CheckedChanged
        Call _Proceso()
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
            Case "FC", "ND", "NC"
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
        Dim cm = New SqlCommand("SELECT Proveedor, RTRIM(LTRIM(Nombre)) Nombre FROM Proveedor WHERE Proveedor = '" & WProveedor & "' ")
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
        GRilla.Rows.Clear()

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

End Class