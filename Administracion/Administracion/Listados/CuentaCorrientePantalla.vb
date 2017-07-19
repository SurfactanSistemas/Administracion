Imports ClasesCompartidas
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Public Class CuentaCorrientePantalla

    Dim dataGridBuilder As GridBuilder
    Dim Aa As Integer
    Private _NrosInternos As New List(Of Object)

    Private Sub CuentaCorrientePantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dataGridBuilder = New GridBuilder(GRilla)

        opcPendiente.Checked = True
        opcCompleto.Checked = False

    End Sub

    Private Sub Proceso()

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

                Dim CamposCtaCtePrv As New CtaCteProveedoresDeuda(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString)


                GRilla.Rows.Add()

                GRilla.Item(0, WRenglon).Value = CamposCtaCtePrv.Tipo
                GRilla.Item(1, WRenglon).Value = CamposCtaCtePrv.letra
                GRilla.Item(2, WRenglon).Value = CamposCtaCtePrv.punto
                GRilla.Item(3, WRenglon).Value = CamposCtaCtePrv.numero
                GRilla.Item(4, WRenglon).Value = formatonumerico(CamposCtaCtePrv.total, "########0.#0", ".")
                GRilla.Item(5, WRenglon).Value = formatonumerico(CamposCtaCtePrv.saldo, "########0.#0", ".")
                GRilla.Item(6, WRenglon).Value = CamposCtaCtePrv.fecha
                GRilla.Item(7, WRenglon).Value = CamposCtaCtePrv.vencimiento

                WRenglon = WRenglon + 1
                WSuma = WSuma + CamposCtaCtePrv.saldo

                _NrosInternos.Add({CamposCtaCtePrv.numero, CamposCtaCtePrv.NroInterno})

            Next

            GRilla.AllowUserToAddRows = False
            txtSaldo.Text = formatonumerico(WSuma, "########0.#0", ".")
        End If

    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        boxPantallaProveedores.Visible = True

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtAyuda.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
        End If
    End Sub

    Private Sub _TraerSaldoCuentaProveedor(ByVal cliente As String)
        Dim saldo As String = "0,00"

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT SUM(Saldo) as SaldoTotal FROM CtaCte WHERE Cliente = '" & Trim(cliente) & "'")
        Dim dr As SqlDataReader


        If Trim(cliente) = "" Then
            lblSaldoCuentaProveedor.Text = saldo
            Exit Sub
        End If

        Try
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
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
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
        txtProveedor.Text = proveedor.id
        txtRazon.Text = proveedor.razonSocial
        boxPantallaProveedores.Visible = False
        _TraerProveedorSelectivo()
        _TraerSaldoCuentaProveedor(proveedor.cliente.id)
        Call Proceso()

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
        Call Proceso()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim opc As DialogResult = MsgBox("¿Desea salir de esta aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
        'If opc = Windows.Forms.DialogResult.Yes Then
        '    Aa = 1
        '    'End
        'Else
        '    'e.Cancel = True
        '    Aa = 2
        'End If
        'Stop
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
        Dim _Numero As String = GRilla.Rows(e.RowIndex).Cells(3).Value.ToString ' Guardamos el numero de factura para buscar el nro interno.
        Dim _Datos As New List(Of Object)

        _NroInterno = _NrosInternos.FindLast(Function(n) n(0) = _Numero)(1)

        ' Comprobamos que se encuentre un nro interno.
        If IsNothing(_NroInterno) Then
            Exit Sub
        End If

        With ConsultaDatosFactura
            .NroInterno = _NroInterno

            .ShowDialog()

        End With
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyData = Keys.Enter Then

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
            e.Handled = True
            txtRazon.Focus()
        End If
        If Not IsNumeric(e.KeyCode) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick

        If Trim(txtProveedor.Text) = "" Then
            btnConsulta.PerformClick()
            Exit Sub
        End If

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
        origen.SelectedIndex = origen.FindStringExact(filtrado.SelectedItem.ToString)

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)

        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
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
End Class