Public Class IngresoClave



    Private Sub IngresoClave_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtClave.Focus()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClave.Text) = "" Then : Exit Sub : End If



            Select Case txtClave.Text.Trim.ToUpper
                Case "POLOK", "OLULA", "GRANADA"

                    Dim WOWner As IClaveAutorizacion = CType(Owner, IClaveAutorizacion)

                    If Not IsNothing(WOWner) Then
                        WOWner.ProcesarClave(True)
                    End If

                    Close()

                Case Else

                    MsgBox("Clave Inválida", MsgBoxStyle.Exclamation)

                    txtClave.Focus()

            End Select

        ElseIf e.KeyData = Keys.Escape Then
            txtClave.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class