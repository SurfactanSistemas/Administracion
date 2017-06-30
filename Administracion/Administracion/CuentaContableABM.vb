Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class CuentaContableABM

    Private Actualiza As Boolean
    Private Const MAIN_HEIGHT = 270
    Private Const EXPANDED_HEIGHT = 440

    Private Sub CuentaContableABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualiza = False
        _ContraerFormulario()
    End Sub

    Private Sub CuentaContableABM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Escape Then

            _LimpiarCampos()

        End If
    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave

        If Trim(txtCodigo.Text) <> "" Then
            mostrarCuenta()
        End If

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        If Trim(txtCodigo.Text) <> "" And Trim(txtDescripcion.Text) <> "" Then

            If Actualiza Then
                _Actualizar()
            Else
                _AgregarNuevaCuenta()
            End If

            _LimpiarCampos()

        Else
            txtCodigo.Focus()
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtCodigo.Text) <> "" Then
            If MessageBox.Show("¿Está seguro de que quiere eliminar esta Cuenta Contable?", "Confirmación de Eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                DAOCuentaContable.eliminarCuentaContable(txtCodigo.Text)

                MsgBox("El Banco ha sido eliminado correctamente", MsgBoxStyle.Information)

                _LimpiarCampos()

            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        _LimpiarCampos()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        _ListarConsulta()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub

    Private Sub txtCodigo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigo.MouseDoubleClick
        _ListarConsulta()
    End Sub

    Private Sub txtDescripcion_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDescripcion.MouseDoubleClick
        _ListarConsulta()
    End Sub

    Private Sub LBConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta.SelectedIndexChanged
        _TraerCuentaContable(LBConsulta.SelectedItem)
    End Sub

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged
        _TraerCuentaContable(LBConsulta_Filtrada.SelectedItem)
        LBConsulta_Filtrada.Visible = False
        txtFiltrar.Text = "Buscar..."
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

    Private Sub txtFiltrar_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltrar.Enter
        txtFiltrar.Text = ""
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyData = Keys.Enter And Trim(txtCodigo.Text) <> "" Then

            mostrarCuenta()
            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then

            txtCodigo.Text = ""

        End If
    End Sub

    Private Sub mostrarCuenta()
        Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(txtCodigo.Text)
        If Not IsNothing(cuenta) Then

            txtCodigo.Text = cuenta.id
            txtDescripcion.Text = cuenta.descripcion
            Actualiza = True

        Else
            txtDescripcion.Text = ""
            Actualiza = False
        End If
    End Sub

    Private Sub _LimpiarCampos()
        txtCodigo.Text = ""
        txtCodigo.Focus()
        txtDescripcion.Text = ""
        txtFiltrar.Text = "Buscar..."
        Actualiza = False
        LBConsulta_Filtrada.Visible = False
        _ContraerFormulario()
    End Sub

    Private Sub _TraerCuentaContable(ByVal descripcion As String)
        Dim cuenta As New List(Of CuentaContable)
        cuenta = DAOCuentaContable.buscarCuentaContablePorDescripcion(descripcion)

        txtCodigo.Text = cuenta(0).id
        txtDescripcion.Text = cuenta(0).descripcion
        txtDescripcion.Focus()
        Actualiza = True

        txtFiltrar.Text = "Buscar..."

        _ContraerFormulario()
    End Sub

    Private Sub _AgregarNuevaCuenta()

        Dim cuenta As New CuentaContable(txtCodigo.Text, txtDescripcion.Text)
        DAOCuentaContable.agregarCuentaContable(cuenta)

        MsgBox("Se ha registrado correctamente la Cuenta Contable", MsgBoxStyle.Information)

    End Sub

    Private Sub _Actualizar()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("Update Cuenta SET Descripcion='" + Trim(txtDescripcion.Text) + "' WHERE Cuenta = '" + Trim(txtCodigo.Text) + "'")

        SQLConnector.conexionSql(cn, cm)

        Try
            cm.ExecuteNonQuery()

            Dim cuenta As New List(Of CuentaContable)
            cuenta = DAOCuentaContable.buscarCuentaContablePorDescripcion(txtDescripcion.Text)

            txtCodigo.Text = cuenta(0).id
            txtDescripcion.Text = cuenta(0).descripcion

            MsgBox("Se ha actualizado correctamente la Cuenta Corriente actual", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Hubo un error al querer actualizar la Cuenta Corriente Actual", MsgBoxStyle.Critical)
        Finally
            cm = Nothing
            cn.Close()
            cn = Nothing
        End Try

    End Sub

    Private Sub _ListarConsulta()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM Cuenta")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                LBConsulta.Items.Clear()
                LBConsulta_Filtrada.Visible = False

                Do While dr.Read()

                    LBConsulta.Items.Add(dr.Item(0))

                Loop

                dr.Close()

                _ExpandirFormulario()
                txtFiltrar.Focus()
            Else
                MsgBox("No hay Cuentas Contables registradas", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar las Cuentas Corrientes registradas", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing

        End Try
    End Sub

    Private Sub _NavegarHaciaEl(ByVal direccion As String, Optional ByVal registroActual As String = "")

        Dim cuenta As DataTable
        cuenta = ClasesCompartidas.SQLConnector.retrieveDataTable("get_cuenta", direccion, registroActual)


        If cuenta.Rows.Count > 0 Then
            txtCodigo.Text = cuenta.Rows(0)(0)
            txtDescripcion.Text = cuenta.Rows(0)(1)
        End If

    End Sub

    Private Sub _ContraerFormulario()

        Me.Height = MAIN_HEIGHT

    End Sub

    Private Sub _ExpandirFormulario()

        Me.Height = EXPANDED_HEIGHT

    End Sub
End Class
