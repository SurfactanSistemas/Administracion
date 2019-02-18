Public Class Form1

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(TextBox1.Text) = "" Then : Exit Sub : End If

            If RadioButton1.Checked Then
                With New DetalleMovimientosMP(TextBox1.Text)
                    .Show(Me)
                End With
            Else
                With New DetallesHojaProduccion(TextBox1.Text)
                    .Show(Me)
                End With
            End If

        ElseIf e.KeyData = Keys.Escape Then
            TextBox1.Text = ""
        End If

    End Sub
End Class
