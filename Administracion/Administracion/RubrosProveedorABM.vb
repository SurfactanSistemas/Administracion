Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class RubrosProveedorABM

    Private Actualiza As Boolean
    Private Const MAIN_HEIGHT = 270
    Private Const EXPANDED_HEIGHT = 440

    Private Sub RubrosProveedorABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _LimpiarCampos()
    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        _MostrarRubro()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        If Trim(txtCodigo.Text) <> "" And Trim(txtDescripcion.Text) <> "" Then

            If Actualiza Then
                _Actualizar()
            Else
                Dim rubro As New RubroProveedor(txtCodigo.Text, txtDescripcion.Text)
                DAORubroProveedor.agregarRubroProveedor(rubro)

                MsgBox("Se ha registrado correctamente el Rubro", MsgBoxStyle.Information)

                _LimpiarCampos()
            End If

        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Trim(txtCodigo.Text) <> "" And Trim(txtDescripcion.Text) <> "" Then

            If MessageBox.Show("¿Está seguro de que quiere eliminar este Rubro?", "Confirmación de Eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                Dim rubro As New RubroProveedor(txtCodigo.Text, txtDescripcion.Text)

                Try

                    DAORubroProveedor.eliminarRubroProveedor(rubro)

                    MsgBox("El Rubro ha sido eliminado correctamente", MsgBoxStyle.Information)

                    _LimpiarCampos()

                Catch ex As Exception

                End Try

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

    Private Sub LBConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta.SelectedIndexChanged
        _TraerRubro(LBConsulta.SelectedItem)
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

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged
        _TraerRubro(LBConsulta_Filtrada.SelectedItem)
        LBConsulta_Filtrada.Visible = False
        txtFiltrar.Text = ""
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

            _MostrarRubro()
            txtDescripcion.Focus()
        ElseIf e.KeyData = Keys.Escape Then

            txtCodigo.Text = ""

        End If
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub _TraerRubro(ByVal descripcion As String)
        Dim rubro As New List(Of RubroProveedor)
        rubro = DAORubroProveedor.buscarRubroProveedorPorDescripcion(descripcion)

        txtCodigo.Text = rubro(0).codigo
        txtDescripcion.Text = rubro(0).descripcion
        txtDescripcion.Focus()
        Actualiza = True

        txtFiltrar.Text = ""

        _ContraerFormulario()
    End Sub

    Private Sub _MostrarRubro()

        Dim rubro As RubroProveedor = DAORubroProveedor.buscarRubroProveedorPorCodigo(txtCodigo.Text)
        If Not IsNothing(rubro) Then
            txtDescripcion.Text = rubro.descripcion
            Actualiza = True
        Else
            txtDescripcion.Text = ""
            Actualiza = False
        End If

    End Sub

    Private Sub _ContraerFormulario()

        Me.Height = MAIN_HEIGHT

    End Sub

    Private Sub _ExpandirFormulario()

        Me.Height = EXPANDED_HEIGHT

    End Sub

    Private Sub _ListarConsulta()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Descripcion FROM TipoProv")
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
                MsgBox("No hay Rubros registradas", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los Rubros registrados", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing

        End Try
    End Sub

    Private Sub _LimpiarCampos()
        txtCodigo.Text = DAORubroProveedor.siguienteCodigo()
        txtCodigo.SelectAll()
        txtDescripcion.Text = ""
        txtFiltrar.Text = ""
        Actualiza = False
        LBConsulta_Filtrada.Visible = False
        _ContraerFormulario()
    End Sub

    Private Sub _Actualizar()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("Update TipoProv SET Descripcion='" + Trim(txtDescripcion.Text) + "' WHERE Codigo = '" + Trim(txtCodigo.Text) + "'")

        SQLConnector.conexionSql(cn, cm)

        Try
            cm.ExecuteNonQuery()

            MsgBox("Se ha actualizado correctamente el Rubro actual", MsgBoxStyle.Information)

            _LimpiarCampos()

        Catch ex As Exception
            MsgBox("Hubo un error al querer actualizar el Rubro Actual", MsgBoxStyle.Critical)
        Finally
            cm = Nothing
            cn.Close()
            cn = Nothing
        End Try

    End Sub

    Private Sub _NavegarHaciaEl(ByVal direccion As String, Optional ByVal registroActual As String = "")

        Dim rubro As DataTable
        rubro = ClasesCompartidas.SQLConnector.retrieveDataTable("get_rubro", direccion, registroActual)

        If rubro.Rows.Count > 0 Then
            txtCodigo.Text = rubro.Rows(0)(0)
            txtDescripcion.Text = rubro.Rows(0)(1)
        End If

    End Sub
End Class