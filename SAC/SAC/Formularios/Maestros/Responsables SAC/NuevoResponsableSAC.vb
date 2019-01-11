Public Class NuevoResponsableSac

    Sub New(Optional ByVal WCodigo As Object = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtCodigo.Text = WCodigo

        If txtCodigo.Text.Trim = "" Then
            txtCodigo.Text = _ProximoNumero()
        End If

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Function _ProximoNumero() As String
        Dim WUltimo As DataRow = GetSingle("SELECT ISNULL(Max(Codigo), 0) Ultimo FROM ResponsableSac")

        Return WUltimo.Item("Ultimo") + 1
    End Function

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If
            Dim c = txtCodigo.Text

            btnLimpiar.PerformClick()

            txtCodigo.Text = c

            Dim WTipoSolic As DataRow = GetSingle("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion, LTRIM(RTRIM(Email)) Email, LTRIM(RTRIM(ClaveSeguridad)) ClaveSeguridad FROM ResponsableSac WHERE Codigo = '" & txtCodigo.Text & "'")

            If Not IsNothing(WTipoSolic) Then
                txtCodigo.Text = WTipoSolic.Item("Codigo")
                txtDescripcion.Text = WTipoSolic.Item("Descripcion")
                txtEmail.Text = WTipoSolic.Item("Email")
                txtClaveSegunridad.Text = WTipoSolic.Item("ClaveSeguridad")

            End If

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = _ProximoNumero()
        txtDescripcion.Text = ""
        txtEmail.Text = ""
        txtClaveSegunridad.Text = ""
        txtCodigo.Focus()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click
        Try
            If {txtDescripcion, txtClaveSegunridad, txtCodigo}.Any(Function(txt) txt.Text.Trim = "") Then
                Throw New Exception("Los campos 'Descripcion', 'Codigo', y 'Clave' son obligatorios y no pueden estar vacíos.")
            End If

            txtDescripcion.Text = Microsoft.VisualBasic.Left(txtDescripcion.Text, 50)
            txtEmail.Text = Microsoft.VisualBasic.Left(txtEmail.Text, 50)
            txtClaveSegunridad.Text = Microsoft.VisualBasic.Left(txtClaveSegunridad.Text, 10)

            ExecuteNonQueries("DELETE FROM ResponsableSac WHERE Codigo = '" & txtCodigo.Text & "'", "INSERT INTO ResponsableSac (Codigo, Descripcion, Email, ClaveSeguridad) VALUES (" & txtCodigo.Text & ", '" & txtDescripcion.Text & "', '" & txtEmail.Text & "', '" & txtClaveSegunridad.Text & "')")

            Dim WOwner = CType(Owner, INuevoResponsableSac)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoResponsableSac(txtCodigo.Text)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("¿Está seguro de querer eliminar este Responsable Sac?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            ExecuteNonQueries("DELETE FROM ResponsableSac WHERE Codigo = '" & txtCodigo.Text & "'")

            Dim WOwner = CType(Owner, INuevoResponsableSac)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoResponsableSac(txtCodigo.Text)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcion.Text) = "" Then : Exit Sub : End If

            txtEmail.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEmail.KeyDown

        If e.KeyData = Keys.Enter Then

            txtClaveSegunridad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtEmail.Text = ""
        End If

    End Sub

    Private Sub txtClaveSegunridad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtClaveSegunridad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClaveSegunridad.Text) = "" Then : Exit Sub : End If

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtClaveSegunridad.Text = ""
        End If

    End Sub

    Private Sub NuevoResponsableSAC_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub
End Class