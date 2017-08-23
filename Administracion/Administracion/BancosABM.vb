Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class BancosABM

    Private Actualiza As Boolean
    Private TipoConsulta As String
    Private Const MAIN_HEIGHT = 280
    Private Const EXPANDED_HEIGHT = 480

    Private Sub BancosABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _LimpiarCampos()
        _ContraerFormulario()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        If Trim(txtCodigo.Text) <> "" And Trim(txtNombre.Text) <> "" Then

            ' Se permite grabar banco sin cuenta asociada, pero en caso de que si se valida que exista.
            If Trim(txtCuenta.Text) <> "" Then

                Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(Trim(txtCuenta.Text))

                If IsNothing(cuenta) Then

                    MsgBox("La Cuenta indicada no es una Cuenta Contable correcta")
                    Exit Sub

                End If

            End If

            If Actualiza Then
                _Actualizar()
            Else
                _AgregarNuevoBanco()
            End If

            _LimpiarCampos()
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtCodigo.Text) <> "" And Actualiza = True Then

            If MessageBox.Show("¿Está seguro de que quiere eliminar esta Cuenta Contable?", "Confirmación de Eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                Dim cuenta As New CuentaContable(txtCuenta.Text, txtDescripcion.Text)
                Dim banco As New Banco(txtCodigo.Text, txtNombre.Text, cuenta)
                DAOBanco.eliminarBanco(banco)

                MsgBox("El Banco ha sido eliminado correctamente", MsgBoxStyle.Information)

                _LimpiarCampos()
            End If

            txtCodigo.Focus()

        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        _LimpiarCampos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        txtFiltrar.Enabled = False
        LBConsulta_Opciones.Visible = True

        _ExpandirFormulario()

    End Sub

    Private Sub txtFiltrar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltrar.TextChanged

        LBConsulta_Filtrada.Items.Clear()

        If UCase(Trim(txtFiltrar.Text)) <> "" Then

            For Each item In LBConsulta.Items

                If UCase(item.ToString()).Contains(UCase(Trim(txtFiltrar.Text))) Then

                    LBConsulta_Filtrada.Items.Add(item.ToString())

                End If

            Next

            LBConsulta_Filtrada.Visible = True

        Else

            LBConsulta_Filtrada.Visible = False

        End If

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        Select Case e.KeyData
            Case Keys.Enter

                If Trim(txtCodigo.Text) = "" Then
                    _ListarConsulta("Nombre", "Banco")
                    Exit Sub
                End If

                _MostrarBanco()
            Case Keys.Escape
                txtCodigo.Text = ""
            Case Else

        End Select

    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown

        If e.KeyData = Keys.Enter And Trim(txtNombre.Text) <> "" Then
            txtCuenta.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtNombre.Text = ""
        End If

    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown

        If e.KeyData = Keys.Enter And Trim(txtCuenta.Text) <> "" Then
            _MostrarCuenta()
        ElseIf e.KeyData = Keys.Escape Then
            txtCuenta.Text = ""
        End If

    End Sub

    Private Sub txtCuenta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Trim(txtCuenta.Text) <> "" Then
            _MostrarCuenta()
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtFiltrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Private Sub txtCodigo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigo.MouseDoubleClick
        _ListarConsulta("Nombre", "Banco")
    End Sub

    Private Sub txtNombre_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtNombre.MouseDoubleClick
        _ListarConsulta("Nombre", "Banco")
    End Sub

    Private Sub txtCuenta_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCuenta.MouseDoubleClick
        _ListarConsulta("Descripcion", "Cuenta")
    End Sub

    Private Sub btnPrimerRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimerRegistro.Click
        _NavegarHaciaEl("primero")
    End Sub

    Private Sub btnUltimoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimoRegistro.Click
        _NavegarHaciaEl("ultimo")
    End Sub

    Private Sub btnSiguienteRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteRegistro.Click
        _NavegarHaciaEl("siguiente", txtCodigo.Text)
    End Sub

    Private Sub btnAnteriorRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorRegistro.Click
        _NavegarHaciaEl("anterior", txtCodigo.Text)
    End Sub

    Private Sub txtFiltrar_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltrar.Enter
        txtFiltrar.Text = ""
    End Sub

    Private Sub LBConsulta_Opciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Opciones.SelectedIndexChanged

        If LBConsulta_Opciones.SelectedItem = "" Then
            Exit Sub
        End If

        If LBConsulta_Opciones.SelectedIndex = 0 Then
            _ListarConsulta("Nombre", "Banco")
        Else
            _ListarConsulta("Descripcion", "Cuenta")
        End If

    End Sub

    Private Sub LBConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta.SelectedIndexChanged

        If LBConsulta.SelectedItem = "" Then
            Exit Sub
        End If

        Select Case TipoConsulta
            Case "Banco"
                _TraerBanco(LBConsulta.SelectedItem)
            Case "Cuenta"
                _TraerCuenta(LBConsulta.SelectedItem)
            Case Else
        End Select

    End Sub

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged

        If LBConsulta_Filtrada.SelectedItem = "" Then
            Exit Sub
        End If

        Select Case TipoConsulta
            Case "Banco"
                _TraerBanco(LBConsulta_Filtrada.SelectedItem)
            Case "Cuenta"
                _TraerCuenta(LBConsulta_Filtrada.SelectedItem)
            Case Else
        End Select

    End Sub

    Private Sub _MostrarBanco()
        Dim banco As Banco = DAOBanco.buscarBancoPorCodigo(Trim(txtCodigo.Text))
        If Not IsNothing(banco) Then
            txtNombre.Text = banco.nombre

            If Not IsNothing(banco.cuenta) Then

                txtCuenta.Text = banco.cuenta.id
                _MostrarCuenta()

            Else
                txtCuenta.Text = ""
                txtDescripcion.Text = ""
            End If

            Actualiza = True
        Else
            txtNombre.Text = ""
            txtCuenta.Text = ""
            txtDescripcion.Text = ""
            Actualiza = False
        End If

        txtNombre.Focus()
    End Sub

    Private Sub _MostrarCuenta()

        If Trim(txtCuenta.Text) <> "" Then

            Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(Trim(txtCuenta.Text))

            If IsNothing(cuenta) Then
                MsgBox("La cuenta indicada no se encuentra registrada. Por favor, corrobore la entrada y vuelva a intentar", MsgBoxStyle.Information)
            Else
                txtCuenta.Text = cuenta.id
                txtDescripcion.Text = cuenta.descripcion
            End If

        End If

    End Sub

    Private Sub _ListarConsulta(ByVal columnas As String, ByVal tabla As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT " + columnas + " FROM " + tabla)
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                LBConsulta.Items.Clear()

                Do While dr.Read()

                    LBConsulta.Items.Add(dr.Item(0))

                Loop

                dr.Close()

                TipoConsulta = tabla
                LBConsulta_Opciones.Visible = False
                txtFiltrar.Enabled = True
                txtFiltrar.Focus()

                _ExpandirFormulario()

            Else

                MsgBox("No hay registros que listar")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer listar los registros solicitados", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing

        End Try
    End Sub

    Private Sub _NavegarHaciaEl(ByVal direccion As String, Optional ByVal registroActual As String = "")

        Dim banco As DataTable
        Dim cuenta As CuentaContable

        banco = ClasesCompartidas.SQLConnector.retrieveDataTable("get_banco", direccion, registroActual)

        If banco.Rows.Count > 0 Then
            txtCodigo.Text = banco.Rows(0)(0)
            txtNombre.Text = banco.Rows(0)(1)

            Actualiza = True

            txtCuenta.Text = banco.Rows(0)(2)

            If Trim(txtCuenta.Text) <> "" Then

                cuenta = DAOCuentaContable.buscarCuentaContablePorCodigo(Trim(txtCuenta.Text))


                If Not IsNothing(cuenta) Then
                    txtDescripcion.Text = cuenta.descripcion
                End If

            Else

                txtDescripcion.Text = ""

            End If

            txtCodigo.Focus()

        End If


    End Sub

    Private Sub _AgregarNuevoBanco()
        Dim cuenta As New CuentaContable(txtCuenta.Text, txtDescripcion.Text)
        Dim banco As New Banco(txtCodigo.Text, txtNombre.Text, cuenta)
        DAOBanco.agregarBanco(banco)

        MsgBox("El Banco ha sido guardado correctamente", MsgBoxStyle.Information)
    End Sub

    Private Sub _Actualizar()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("Update Banco SET Nombre='" + Trim(txtNombre.Text) + "', Cuenta='" + Trim(txtCuenta.Text) + "' WHERE Banco = '" + Trim(txtCodigo.Text) + "'")

        SQLConnector.conexionSql(cn, cm)

        Try
            cm.ExecuteNonQuery()

            Dim banco As New List(Of Banco)
            banco = DAOBanco.buscarBancoPorNombre(Trim(txtNombre.Text))

            txtCodigo.Text = banco(0).id
            txtNombre.Text = banco(0).nombre

            MsgBox("Se ha actualizado correctamente la información para el Banco Actual", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Hubo un error al intentar actualizar la información del Banco Actual", MsgBoxStyle.Critical)
        Finally
            cm = Nothing
            cn.Close()
            cn = Nothing
        End Try

    End Sub

    Private Sub _LimpiarCampos()

        txtCodigo.Text = DAOBanco.siguienteCodigo()
        txtCodigo.Focus()
        txtNombre.Text = ""
        txtCuenta.Text = ""
        txtDescripcion.Text = ""
        txtFiltrar.Text = "Buscar..."
        LBConsulta_Filtrada.Items.Clear()
        LBConsulta_Filtrada.Visible = False
        Actualiza = False
        TipoConsulta = ""

    End Sub

    Private Sub _TraerBanco(ByVal nombre As String)
        Dim banco As List(Of Banco) = DAOBanco.buscarBancoPorNombre(nombre)

        If Not IsNothing(banco) Then

            txtCodigo.Text = banco(0).id
            txtNombre.Text = banco(0).nombre

            If Not IsNothing(banco(0).cuenta) Then

                txtCuenta.Text = banco(0).cuenta.id
                txtDescripcion.Text = banco(0).cuenta.descripcion
            Else
                txtCuenta.Text = ""
                txtDescripcion.Text = ""
            End If

            Actualiza = True

            _ContraerFormulario()

        End If

    End Sub

    Private Sub _TraerCuenta(ByVal descripcion)
        Dim cuenta As New List(Of CuentaContable)
        cuenta = DAOCuentaContable.buscarCuentaContablePorDescripcion(descripcion)

        If Not IsNothing(cuenta) Then

            txtCuenta.Text = cuenta(0).id
            txtDescripcion.Text = cuenta(0).descripcion

            _ContraerFormulario()

        End If
    End Sub

    Private Sub _ContraerFormulario()

        Me.Height = MAIN_HEIGHT

    End Sub

    Private Sub _ExpandirFormulario()

        Me.Height = EXPANDED_HEIGHT

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress, txtCuenta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListado.Click
        
        With VistaPrevia
            .Reporte = New ListadoBancos
            .Mostrar()
        End With

    End Sub
End Class