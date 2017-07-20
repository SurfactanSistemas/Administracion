Public Class DatosIB

    Private Sub DatosIB_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtRetIB1.Focus()
    End Sub

    Private Sub txtRetIB1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB1.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB1.Text) <> "" Then
                _SaltarA(txtCompIB1)
            Else
                _SaltarA(txtRetIB2)
            End If
        End If
    End Sub

    Private Sub txtCompIB1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB1.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB2)
        End If
    End Sub

    Private Sub txtRetIB2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB2.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB2.Text) <> "" Then
                _SaltarA(txtCompIB2)
            Else
                _SaltarA(txtRetIB3)
            End If
        End If
    End Sub

    Private Sub txtCompIB2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB2.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB3)
        End If
    End Sub

    Private Sub txtRetIB3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB3.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB3.Text) <> "" Then
                _SaltarA(txtCompIB3)
            Else
                _SaltarA(txtRetIB8)
            End If
        End If
    End Sub

    Private Sub txtCompIB3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB3.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB8)
        End If
    End Sub

    Private Sub txtRetIB4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB4.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB4.Text) <> "" Then
                _SaltarA(txtCompIB4)
            Else
                _SaltarA(txtRetIB5)
            End If
        End If
    End Sub

    Private Sub txtCompIB4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB4.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB5)
        End If
    End Sub

    Private Sub txtRetIB5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB5.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB5.Text) <> "" Then
                _SaltarA(txtCompIB5)
            Else
                _SaltarA(txtRetIB6)
            End If
        End If
    End Sub

    Private Sub txtCompIB5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB5.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB6)
        End If
    End Sub

    Private Sub txtRetIB6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB6.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB6.Text) <> "" Then
                _SaltarA(txtCompIB6)
            Else
                _SaltarA(txtRetIB7)
            End If
        End If
    End Sub

    Private Sub txtCompIB6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB6.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB7)
        End If
    End Sub

    Private Sub txtRetIB7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB7.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB7.Text) <> "" Then
                _SaltarA(txtCompIB7)
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtCompIB7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB7.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub txtRetIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB8.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB7.Text) <> "" Then
                _SaltarA(txtCompIB8)
            Else
                _SaltarA(txtRetIB4)
            End If
        End If
    End Sub

    Private Sub txtCompIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB8.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB4)
        End If
    End Sub

    Private Sub _SaltarA(ByRef SiguienteControl As Control)
        SiguienteControl.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DatosIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub
End Class