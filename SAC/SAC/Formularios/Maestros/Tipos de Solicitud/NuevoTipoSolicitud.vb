Public Class NuevoTipoSolicitud

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
        Dim WUltimo As DataRow = Query.GetSingle("SELECT ISNULL(Max(Codigo), 0) Ultimo FROM TipoSac")

        Return WUltimo.Item("Ultimo") + 1
    End Function

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If
            Dim c = txtCodigo.Text

            btnLimpiar.PerformClick()

            txtCodigo.Text = c

            Dim WTipoSolic As DataRow = GetSingle("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM TipoSac WHERE Codigo = '" & txtCodigo.Text & "'")

            If Not IsNothing(WTipoSolic) Then
                txtCodigo.Text = WTipoSolic.Item("Codigo")
                txtDescripcion.Text = WTipoSolic.Item("Descripcion")

            End If

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = _ProximoNumero()
        txtDescripcion.Text = ""
        txtCodigo.Focus()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            txtDescripcion.Text = Microsoft.VisualBasic.Left(txtDescripcion.Text, 50)

            Query.ExecuteNonQueries("DELETE FROM TipoSac WHERE Codigo = '" & txtCodigo.Text & "'", "INSERT INTO TipoSac (Codigo, Descripcion) VALUES (" & txtCodigo.Text & ", '" & txtDescripcion.Text & "')")

            Dim WOwner As INuevoTipoSolicitud = CType(Owner, INuevoTipoSolicitud)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoTipoSolicitud(txtCodigo.Text)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("¿Está seguro de querer eliminar este Tipo de Solicitud de Sac?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            Query.ExecuteNonQueries("DELETE FROM TipoSac WHERE Codigo = '" & txtCodigo.Text & "'")

            Dim WOwner As INuevoTipoSolicitud = CType(Owner, INuevoTipoSolicitud)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoTipoSolicitud(txtCodigo.Text)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class