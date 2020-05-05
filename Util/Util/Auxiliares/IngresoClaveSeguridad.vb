Public Class IngresoClaveSeguridad

    Private Sub IngresoClaveSeguridad_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtClave.Focus()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtClave.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClave.Text) = "" Then : Exit Sub : End If

            Dim WOwner As IIngresoClaveSeguridad = CType(Owner, IIngresoClaveSeguridad)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarIngresoClaveSeguridad(txtClave.Text)
            End If

            Close()

        ElseIf e.KeyData = Keys.Escape Then
            txtClave.Text = ""
        End If

    End Sub
End Class