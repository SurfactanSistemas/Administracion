Public Class Contactos



    Private Sub Contactos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtNombre1.Focus()
    End Sub

    Private Sub txtNombre1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre1.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre1.Text) <> "" Then
                txtCargo1.Focus()
            Else
                txtNombre2.Focus()
            End If

        End If

    End Sub

    Private Sub txtNombre2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre2.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre2.Text) <> "" Then
                txtCargo2.Focus()
            Else
                txtNombre3.Focus()
            End If

        End If
    End Sub

    Private Sub txtNombre3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre3.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre3.Text) <> "" Then
                txtCargo3.Focus()
            Else
                Me.Close()
            End If

        End If
    End Sub

    Private Sub txtCargo1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCargo1.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre1.Text) <> "" Then
                txtTelefono1.Focus()
            Else
                txtNombre2.Focus()
            End If

        End If

    End Sub

    Private Sub txtTelefono1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono1.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre1.Text) <> "" Then
                txtEmail1.Focus()
            Else
                txtNombre2.Focus()
            End If

        End If
    End Sub

    Private Sub txtEmail1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail1.KeyDown
        If e.KeyData = Keys.Enter Then
            txtNombre2.Focus()
        End If
    End Sub

    Private Sub txtCargo2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCargo2.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre2.Text) <> "" Then
                txtTelefono2.Focus()
            Else
                txtNombre3.Focus()
            End If

        End If
    End Sub

    Private Sub txtTelefono2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono2.KeyDown
        If e.KeyData = Keys.Enter Then

            If Trim(txtNombre2.Text) <> "" Then
                txtEmail2.Focus()
            Else
                txtNombre3.Focus()
            End If

        End If
    End Sub

    Private Sub txtEmail2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail2.KeyDown
        If e.KeyData = Keys.Enter Then
            txtNombre3.Focus()
        End If
    End Sub

    Private Sub txtCargo3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCargo3.KeyDown
        If e.KeyData = Keys.Enter Then

            txtTelefono3.Focus()

        End If
    End Sub

    Private Sub txtTelefono3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono3.KeyDown
        If e.KeyData = Keys.Enter Then

            txtEmail3.Focus()

        End If
    End Sub

    Private Sub txtEmail3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail3.KeyDown
        Me.Close()
    End Sub
End Class