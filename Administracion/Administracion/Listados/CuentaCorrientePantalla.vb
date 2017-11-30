Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class CuentaCorrientePantalla
    Private _NrosInternos As New List(Of Object)
    Private WPOSINICIALCONSULTA As Point
    Private WPOSINICIALCERRAR As Point
    Private WPOSINICIALLIMPIAR As Point

    Private Sub CuentaCorrientePantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WPOSINICIALCONSULTA = btnConsulta.Location
        WPOSINICIALCERRAR = btnCancela.Location
        WPOSINICIALLIMPIAR = btnLimpiar.Location

        opcPendiente.Checked = True
        opcCompleto.Checked = False

        GRilla.Columns(6).ValueType = GetType(Date)
    End Sub

    Private Sub _Proceso()

        Dim WRenglon As Integer
        Dim WSuma As Double

        GRilla.Rows.Clear()
        GRilla.Rows.Add()
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
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_deuda", txtProveedor.Text, WTipo)

        If tabla.Rows.Count > 0 Then
            _NrosInternos.Clear()

            For Each row As DataRow In tabla.Rows

                Dim CamposCtaCtePrv As New CtaCteProveedoresDeuda(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString, row.Item(9).ToString)

                GRilla.Rows.Add()

                GRilla.Item(0, WRenglon).Value = CamposCtaCtePrv.Impre
                GRilla.Item(1, WRenglon).Value = CamposCtaCtePrv.letra
                GRilla.Item(2, WRenglon).Value = CamposCtaCtePrv.punto
                GRilla.Item(3, WRenglon).Value = CamposCtaCtePrv.numero
                GRilla.Item(4, WRenglon).Value = formatonumerico(CamposCtaCtePrv.total, "########0.#0", ".")
                GRilla.Item(5, WRenglon).Value = formatonumerico(CamposCtaCtePrv.saldo, "########0.#0", ".")
                GRilla.Item(6, WRenglon).Value = CamposCtaCtePrv.fecha
                GRilla.Item(8, WRenglon).Value = Proceso.ordenaFecha(CamposCtaCtePrv.fecha)
                GRilla.Item(7, WRenglon).Value = CamposCtaCtePrv.vencimiento
                GRilla.Item(9, WRenglon).Value = Proceso.ordenaFecha(CamposCtaCtePrv.vencimiento)

                WRenglon = WRenglon + 1
                WSuma = WSuma + CamposCtaCtePrv.saldo

                _NrosInternos.Add({CamposCtaCtePrv.numero, CamposCtaCtePrv.NroInterno})

            Next
        End If

        GRilla.AllowUserToAddRows = False
        txtSaldo.Text = formatonumerico(WSuma, "########0.#0", ".")
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        boxPantallaProveedores.Visible = True

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Focus()
    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAyuda.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
        End If
    End Sub

    Private Sub _TraerSaldoCuentaProveedor(ByVal proveedor As Proveedor)

        If IsNothing(proveedor.cliente) Then : Exit Sub
        End If

        Dim cliente As String = proveedor.cliente.id
        Dim saldo As String = "0,00"

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader

        If Trim(cliente) = "" Then
            lblSaldoCuentaProveedor.Text = saldo
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
                    saldo = .Item("SaldoTotal")

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
        lblSaldoCuentaProveedor.Text = "$ " & formatonumerico(saldo, "########0.#0", ".")
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)

        If IsNothing(proveedor) Then : Exit Sub
        End If

        ' Reseteamos resumen de montos automático.
        gbSaldoCtaCliente.Visible = False
        GroupBox1.Visible = False
        btnCancela.Location = WPOSINICIALCERRAR 'New Point(342, 541)
        btnConsulta.Location = WPOSINICIALCONSULTA 'New Point(213, 541)
        btnLimpiar.Location = WPOSINICIALLIMPIAR 'New Point(471, 541)


        'lstFiltrada.Visible = False
        txtProveedor.Text = proveedor.id
        txtRazon.Text = proveedor.razonSocial
        boxPantallaProveedores.Visible = False
        _TraerProveedorSelectivo()
        _TraerSaldoCuentaProveedor(proveedor)
        Call _Proceso()

        GRilla.CurrentCell = GRilla.Rows(0).Cells(0) ' Nos posicionamos en la grilla.
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub

    Private Sub _TraerProveedorSelectivo()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Proveedor FROM ProveedorSelectivo WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                CBProveedorSelectivo.Checked = True
            Else
                CBProveedorSelectivo.Checked = False
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

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub opcCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcCompleto.CheckedChanged
        Call _Proceso()
    End Sub

    Private Function _AltaProveedorSelectivo(ByVal CodProveedor As String) As Boolean
        Dim exito As Boolean = False
        Dim _Fecha As String = Date.Now.ToString("dd/MM/yyyy")
        Dim _FechaOrd As String = String.Join("", _Fecha.Split("/").Reverse())
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("INSERT INTO ProveedorSelectivo (Proveedor, Fecha, FechaOrd) Values ('" & CodProveedor & "', '" & _Fecha & "', '" & _FechaOrd & "')")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()
            exito = True

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return exito
    End Function

    Private Function _EliminarProveedorSelectivo(ByVal codProv As String) As Boolean
        Dim exito As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM ProveedorSelectivo WHERE Proveedor = '" & Trim(codProv) & "'")

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

        If Trim(txtProveedor.Text) <> "" Then
            If CBProveedorSelectivo.Checked Then

                If MsgBox("¿Está seguro de que quiere colocar al proveedor actual al listado de Proveedores Selectivos?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

                    If Not _AltaProveedorSelectivo(txtProveedor.Text) Then
                        CBProveedorSelectivo.Checked = False
                        MsgBox("Hubo un error al querer colocar al proveeedor en la lista de Proveedores Selectivo.", MsgBoxStyle.Critical)
                    End If

                Else
                    CBProveedorSelectivo.Checked = False
                End If

            Else

                If MsgBox("¿Está seguro de que quiere eliminar al proveedor actual del listado de Proveedores Selectivos?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

                    If Not _EliminarProveedorSelectivo(txtProveedor.Text) Then
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
        Dim _NroInterno As String = ""
        Dim _Numero As String = "" ' Guardamos el numero de factura para buscar el nro interno.

        If e.RowIndex >= 0 Then
            _Numero = GRilla.Rows(e.RowIndex).Cells(3).Value
        Else
            Exit Sub
        End If

        Try
            _NroInterno = _NrosInternos.FindLast(Function(n) n(0) = _Numero)(1)
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
                    .txtOrdenPago.Text = Val(GRilla.Rows(e.RowIndex).Cells(3).Value)
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

            Dim CampoProveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
            If IsNothing(CampoProveedor) Then
                MsgBox("Proveedor incorrecto")
                txtProveedor.Focus()
            Else
                mostrarProveedor(CampoProveedor)

                If GRilla.Rows.Count > 0 Then
                    GRilla.CurrentCell = GRilla.Rows(0).Cells(0)
                Else
                    txtProveedor.Focus()
                End If

            End If

        ElseIf e.KeyData = Keys.Escape Then
            'e.Handled = True
            'txtRazon.Focus()
            txtProveedor.Text = ""
            txtRazon.Text = ""
            'gbSaldoCtaCliente.Visible = False
        End If
        If Not IsNumeric(e.KeyCode) Then
            e.Handled = True
        End If
    End Sub

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

        Debug.Print("==================================================")

        If GRilla.SelectedCells.Count < 2 Then : Exit Sub
        End If

        For Each _cell As DataGridViewCell In GRilla.SelectedCells
            If IsNothing(_filas.Find(Function(_f) _f.Index = _cell.RowIndex)) Then

                _filas.Add(GRilla.Rows(_cell.RowIndex))

            End If
        Next

        For Each _rows As DataGridViewRow In _filas
            _Valor = 0

            With _rows

                If Not IsNothing(.Cells(4).Value) Then

                    _Valor = Proceso.formatonumerico(.Cells(4).Value).replace(".", ",")

                    If .Cells(4).Value <> "" Then
                        Select Case .Cells(0).Value
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
                actual = Val(Proceso.ordenaFecha(.Cells(6).Value.ToString))

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
            Case 2, 3, 4, 5

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 6, 7

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