Public Class CUFEProveedor

    Private Sub CUFEProveedor_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCUFE1.Focus()
    End Sub

    Private Sub txtCUFE1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE1.KeyDown, txtCUFE3Fecha.KeyDown, txtCUFE2Fecha.KeyDown, txtCUFE1Fecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE1.Text) <> "" Then
                txtCUFE1Fecha.Focus()
            Else
                txtCUFE2.Focus()
            End If

        End If

    End Sub

    Private Sub txtCUFE2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE2.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE2.Text) <> "" Then
                txtCUFE2Fecha.Focus()
            Else
                txtCUFE3.Focus()
            End If

        End If
    End Sub

    Private Sub txtCUFE3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE3.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE3.Text) <> "" Then
                txtCUFE3Fecha.Focus()
            Else
                Me.Close()
            End If

        End If
    End Sub

    Private Sub txtCUFE1Fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE1.Text) <> "" And Trim(txtCUFE1Fecha.Text) <> "" Then
                txtCUFE2.Focus()
            Else
                txtCUFE1Fecha.Focus()
            End If
        End If
    End Sub

    Private Sub txtCUFE2Fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE2.Text) <> "" And Trim(txtCUFE2Fecha.Text) <> "" Then
                txtCUFE3.Focus()
            Else
                txtCUFE2Fecha.Focus()
            End If
        End If
    End Sub

    Private Sub txtCUFE3Fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE3.Text) <> "" And Trim(txtCUFE3Fecha.Text) <> "" Then
                Me.Close()
            Else
                txtCUFE3Fecha.Focus()
            End If
        End If
    End Sub
End Class