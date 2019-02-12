Public Class NuevoTipoINC

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
        Dim WUltimo As DataRow = GetSingle("SELECT ISNULL(Max(Tipo), 0) Ultimo FROM TiposINC")

        Return WUltimo.Item("Ultimo") + 1
    End Function

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If
            Dim c = txtCodigo.Text

            btnLimpiar.PerformClick()

            txtCodigo.Text = c

            Dim WTipoSolic As DataRow = GetSingle("SELECT Tipo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TiposINC WHERE Tipo = '" & txtCodigo.Text & "'")

            If Not IsNothing(WTipoSolic) Then
                txtCodigo.Text = WTipoSolic.Item("Tipo")
                txtDescripcion.Text = WTipoSolic.Item("Descripcion")
            End If

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = _ProximoNumero()
        txtDescripcion.Text = ""
        txtCodigo.Focus()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click
        Try
            If {txtDescripcion, txtCodigo}.Any(Function(txt) txt.Text.Trim = "") Then
                Throw New Exception("Los campos 'Descripcion' y 'Estado' son obligatorios y no pueden estar vacíos.")
            End If

            txtDescripcion.Text = Microsoft.VisualBasic.Left(txtDescripcion.Text, 50)

            ExecuteNonQueries("DELETE FROM TiposINC WHERE Tipo = '" & txtCodigo.Text & "'", "INSERT INTO TiposINC (Tipo, Descripcion) VALUES (" & txtCodigo.Text & ", '" & txtDescripcion.Text.Trim.SliceLeft(30) & "')")

            Dim WOwner = TryCast(Owner, INuevoTipoINC)

            If Not IsNothing(WOwner) Then WOwner._ProcesarNuevoTipoINC(txtCodigo.Text, txtDescripcion.Text)

            'Close()

            btnLimpiar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("¿Está seguro de querer eliminar este Tipo?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            ExecuteNonQueries("DELETE FROM TiposINC WHERE Tipo = '" & txtCodigo.Text & "'")

            Dim WOwner = TryCast(Owner, INuevoTipoINC)

            If Not IsNothing(WOwner) Then WOwner._ProcesarNuevoTipoINC(txtCodigo.Text, txtDescripcion.Text)

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

    Private Sub NuevoResponsableSAC_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcion.Text) = "" Then : Exit Sub : End If

            btnGrabar_Click(Nothing, Nothing)

            Close()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub
End Class