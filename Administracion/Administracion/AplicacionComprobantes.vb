Imports ClasesCompartidas

Public Class AplicacionComprobantes

    Dim proveedorActual As String 'Lo uso para insertar y actualizar

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        If IsNothing(proveedor) Then : Exit Sub : End If
        txtProveedor.Text = proveedor.id
        txtRazon.Text = proveedor.razonSocial
        ' Uso la variable global ya que sin querer pueden llegar a haber cambiado el texto y romperia todo
        proveedorActual = txtProveedor.Text
        Proceso()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        Me.Height = 630
        lstAyuda.Visible = True
        txtAyuda.Visible = True
        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")
        txtAyuda.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub

    Private Sub btnProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceso.Click
        Dim proveedor = DAOProveedor.buscarProveedorPorCodigo(ceros(txtProveedor.Text, 11))
        If Not IsNothing(proveedor) Then
            mostrarProveedor(proveedor)
            ' cargar tabla
            '                ctacteprv()
            '                Tipo
            '                Letra
            '                Punto
            '                Numero
            '                Fecha
            '                Importe
            '                Saldo
            '                Aplica

            '1 y 2 positivo
            '3 y 5 negativo
        Else
            txtProveedor.Text = ""
            txtRazon.Text = ""
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub dtgCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Enter And dtgCuentas.Rows.Count > 0) Then
            If dtgCuentas.CurrentCell.ColumnIndex = 7 Then

                If IsNothing(dtgCuentas.Rows(dtgCuentas.CurrentCell.RowIndex).Cells(dtgCuentas.CurrentCell.ColumnIndex).Value) Then
                    dtgCuentas.Rows(dtgCuentas.CurrentCell.RowIndex).Cells(dtgCuentas.CurrentCell.ColumnIndex).Value = 0
                End If

                Dim tipo As String = dtgCuentas.Rows(dtgCuentas.CurrentCell.RowIndex).Cells(0).Value
                Dim saldoNuevo As Double
                Dim valorAplica As Double = Convert.ToDouble(dtgCuentas.Rows(dtgCuentas.CurrentCell.RowIndex).Cells(dtgCuentas.CurrentCell.ColumnIndex).Value)

                Select Case tipo
                    Case "01", "02"
                        saldoNuevo = Convert.ToDouble(txtSaldo.Text) + valorAplica
                    Case "03", "05"
                        saldoNuevo = Convert.ToDouble(txtSaldo.Text) - valorAplica
                End Select

                txtSaldo.Text = saldoNuevo.ToString
            End If
        End If
    End Sub

    Private Sub AplicacionComprobantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gridFormasBuilder As New GridBuilder(dtgCuentas)
        gridFormasBuilder.addTextColumn(0, "Tipo", True)
        gridFormasBuilder.addTextColumn(1, "Letra", True)
        gridFormasBuilder.addTextColumn(2, "Punto", True)
        gridFormasBuilder.addTextColumn(3, "Numero", True)
        gridFormasBuilder.addDateColumn(4, "Fecha", True)
        gridFormasBuilder.addFloatColumn(5, "Importe", True)
        gridFormasBuilder.addFloatColumn(6, "Saldo", True)
        gridFormasBuilder.addFloatColumn(7, "Aplica", True)
    End Sub

    Private Sub Proceso()
        txtAyuda.Visible = False
        lstAyuda.Visible = False

        Dim WRenglon As Integer
        Dim WSuma As Double

        dtgCuentas.Rows.Clear()
        WRenglon = 0

        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo

        REM dada fix CAMBIAR Al uso de dao!!
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_deuda", txtProveedor.Text, "P")

        For Each row As DataRow In tabla.Rows

            Dim CamposCtaCtePrv As New CtaCteProveedoresDeuda(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString)
            dtgCuentas.Rows.Add()

            dtgCuentas.Item(0, WRenglon).Value = CamposCtaCtePrv.Tipo
            dtgCuentas.Item(1, WRenglon).Value = CamposCtaCtePrv.letra
            dtgCuentas.Item(2, WRenglon).Value = CamposCtaCtePrv.punto
            dtgCuentas.Item(3, WRenglon).Value = CamposCtaCtePrv.numero
            dtgCuentas.Item(4, WRenglon).Value = CamposCtaCtePrv.fecha

            Dim arregloMonto As Double = 1
            If (CamposCtaCtePrv.Tipo = "03" Or CamposCtaCtePrv.Tipo = "05") Then
                arregloMonto = -1
            End If
            dtgCuentas.Item(5, WRenglon).Value = formatonumerico(CamposCtaCtePrv.total, "########0.#0", ".")
            dtgCuentas.Item(5, WRenglon).Value = dtgCuentas.Item(5, WRenglon).Value * arregloMonto
            dtgCuentas.Item(6, WRenglon).Value = formatonumerico(CamposCtaCtePrv.saldo, "########0.#0", ".")
            dtgCuentas.Item(6, WRenglon).Value = dtgCuentas.Item(6, WRenglon).Value * arregloMonto

            WRenglon = WRenglon + 1
            WSuma = WSuma + CamposCtaCtePrv.saldo

        Next

        dtgCuentas.AllowUserToAddRows = False
        txtAyuda.Text = ""

        txtSaldo.Text = "0.00"


        If dtgCuentas.Rows.Count > 0 Then
            dtgCuentas.CurrentCell = dtgCuentas.Item(7, 0)
            dtgCuentas.Rows(0).Cells(7).Selected = True
            dtgCuentas.Focus()
        Else
            txtProveedor.Focus()
            MsgBox("El proveedor no posee datos para ser listados.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnGraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGraba.Click
        Dim saldo As Double = Convert.ToDouble(txtSaldo.Text)

        If saldo <> 0 Then
            MsgBox("Importe a aplicar no balancea")
        Else
            For Each row As DataGridViewRow In dtgCuentas.Rows
                If Not row.IsNewRow Then
                    SQLConnector.retrieveDataTable("actualizar_cuenta_corriente_proveedor", row.Cells(0).Value.ToString, row.Cells(1).Value.ToString, row.Cells(2).Value.ToString, row.Cells(3).Value.ToString, row.Cells(4).Value.ToString, CustomConvert.toDoubleOrZero(row.Cells(7).Value), proveedorActual)
                End If
            Next
            limpiar()
        End If
    End Sub

    Private Sub limpiar()
        dtgCuentas.Rows.Clear()
        txtAyuda.Text = ""
        txtProveedor.Text = ""
        txtRazon.Text = ""
        txtProveedor.Focus()
    End Sub

    ' Rutinas de Filtrado Dinámico.
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
        Dim texto As TextBox = txtAyuda

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)

        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtProveedor.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            btnProceso.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtProveedor.Text = ""
        End If

    End Sub
End Class
