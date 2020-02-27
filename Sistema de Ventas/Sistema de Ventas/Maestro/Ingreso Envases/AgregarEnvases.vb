Public Class AgregarEnvases

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress, txtPeso.KeyPress, txtTipo.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtAbreviatura.Focus()
            Case Keys.Escape
                txtDescripcion.Text = ""
        End Select
    End Sub

    Private Sub txtAbreviatura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAbreviatura.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtKilos.Focus()
            Case Keys.Escape
                txtAbreviatura.Text = ""
        End Select
    End Sub

    Private Sub txtKilos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKilos.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtTipo.Focus()
            Case Keys.Escape
                txtKilos.Text = ""
        End Select
    End Sub

    Private Sub txtTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtPeso.Focus()
            Case Keys.Escape
                txtTipo.Text = ""
        End Select
    End Sub

    Private Sub txtPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeso.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnGrabar.Click(Nothing, Nothing)
            Case Keys.Escape
                txtPeso.Text = ""
        End Select
    End Sub
End Class