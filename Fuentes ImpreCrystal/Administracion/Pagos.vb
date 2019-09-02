Imports ClasesCompartidas

Public Class Pagos

    Dim queryController As QueryController
    Dim pagos As New List(Of DetalleCompraCuentaCorriente)
    Dim cheques As New List(Of Cheque)

    Private Sub Pagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbTipo.SelectedIndex = 0
        lstSeleccion.Items.Add(New QueryController("Proveedores", AddressOf DAOProveedor.buscarProveedorPorNombre, AddressOf mostrarProveedor))
        lstSeleccion.Items.Add(New QueryController("Cuentas Corrientes", AddressOf cuentasCorrientesDelProveedorActual, AddressOf mostrarCuentaCorriente, False))
        lstSeleccion.Items.Add(New QueryController("Cheques Terceros", AddressOf DAODeposito.buscarCheques, AddressOf mostrarCheque, False))
        lstSeleccion.Items.Add(New QueryController("Cuentas Contables", AddressOf DAOCuentaContable.buscarCuentaContablePorDescripcion, AddressOf mostrarCuentaContable))
        lstSeleccion.SelectedIndex = 0

        Dim gridPagosBuilder As New GridBuilder(gridPagos)
        gridPagosBuilder.addTextColumn(0, "Tipo")
        gridPagosBuilder.addTextColumn(1, "Letra")
        gridPagosBuilder.addNumericColumn(2, "Punto")
        gridPagosBuilder.addNumericColumn(3, "Número")
        gridPagosBuilder.addFloatColumn(4, "Importe")
        gridPagosBuilder.addTextColumn(5, "Descripción")

        Dim gridFormasBuilder As New GridBuilder(gridFormaPagos)
        gridFormasBuilder.addTextColumn(0, "Tipo")
        gridFormasBuilder.addNumericColumn(1, "Número")
        gridFormasBuilder.addDateColumn(2, "Fecha")
        gridFormasBuilder.addNumericColumn(3, "Banco")
        gridFormasBuilder.addTextColumn(4, "Nombre")
        gridFormasBuilder.addFloatColumn(5, "Importe")

        Dim commonEventHandler As New CommonEventsHandler
        commonEventHandler.setIndexTab(Me)
    End Sub

    Private Function validarDatos() As Boolean
        Dim validador As New Validator

        validador.validate(Me)
        validador.alsoValidate(consistenciaEntreProveedorYGrillas(), "Algunos campos de las grillas no coinciden con el proveedor que se desea grabar")

        Return validador.flush
    End Function

    Private Function consistenciaEntreProveedorYGrillas()
        Return pagos.All(Function(cuenta) cuenta.proveedor.id = txtProveedor.Text)
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtObservaciones_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.Leave
        gridPagos.CurrentCell = gridPagos.Rows(0).Cells(0)
        gridPagos.Select()
        gridPagos.Focus()
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
        pagos.Add(cuenta)
        gridPagos.Rows.Add(cuenta.tipo, cuenta.letra, cuenta.punto, cuenta.numero, cuenta.saldo, "")
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        txtProveedor.Text = proveedor.id
        txtRazonSocial.Text = proveedor.razonSocial
    End Sub

    Private Sub mostrarBanco(ByVal banco As Banco)
        txtBanco.Text = banco.id
        txtNombreBanco.Text = banco.nombre
    End Sub

    Private Sub mostrarCuentaContable(ByVal cuenta As CuentaContable)
        'TODO
    End Sub

    Private Sub mostrarCheque(ByVal cheque As Cheque)
        cheques.Add(cheque)
        gridFormaPagos.Rows.Add("03", cheque.numero, cheque.fecha, "", cheque.banco, cheque.importe)
    End Sub

    Private Sub txtProveedor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProveedor.Leave
        Dim proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
        If Not IsNothing(proveedor) Then
            mostrarProveedor(proveedor)
        Else
            txtRazonSocial.Text = ""
        End If
    End Sub

    Private Sub txtBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBanco.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtBanco_Leave(sender, Nothing)
        End If
    End Sub

    Private Sub txtBanco_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBanco.Leave
        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(txtBanco.Text)
        If Not IsNothing(banco) Then
            mostrarBanco(banco)
        Else
            txtNombreBanco.Text = ""
        End If
    End Sub

    Private Sub txtOrdenPago_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdenPago.Leave
        txtOrdenPago.Text = ceros(txtOrdenPago.Text, 6)
    End Sub

    Private Sub lstSeleccion_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSeleccion.DoubleClick
        queryController = lstSeleccion.SelectedItem
        lstSeleccion.Visible = False
        lstConsulta.Visible = True
        txtConsulta.Visible = queryController.usesQueryText
        lstConsulta.DataSource = queryController.query.Invoke("")
        txtConsulta.Focus()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        lstSeleccion.Visible = True
    End Sub

    Private Sub txtConsulta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsulta.KeyDown
        If e.KeyValue = Keys.Enter Then
            lstConsulta.DataSource = queryController.query.Invoke(txtConsulta.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub lstConsulta_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConsulta.DoubleClick
        queryController.showMethod.Invoke(lstConsulta.SelectedValue)
        lstConsulta.Visible = False
        txtConsulta.Visible = False
        txtConsulta.Text = ""
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Cleanner.clean(Me)
        gridPagos.Rows.Clear()
        pagos.Clear()
        gridFormaPagos.Rows.Clear()
        cheques.Clear()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If validarDatos() Then
            MsgBox("Agregaste") 'Agregar
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged

    End Sub
End Class