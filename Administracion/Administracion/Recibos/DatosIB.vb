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

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB1.Text = ""
        End If

    End Sub

    Private Sub txtCompIB1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB1.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB2)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB1.Text = ""
        End If

    End Sub

    Private Sub txtRetIB2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB2.KeyDown
        
        If e.KeyData = Keys.Enter Then

            If Trim(txtRetIB2.Text) <> "" Then
                _SaltarA(txtCompIB2)
            Else
                _SaltarA(txtRetIB3)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB2.Text = ""
        End If

    End Sub

    Private Sub txtCompIB2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB2.KeyDown
        
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB3)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB2.Text = ""
        End If

    End Sub

    Private Sub txtRetIB3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB3.KeyDown
        
        If e.KeyData = Keys.Enter Then
            If Trim(txtRetIB3.Text) <> "" Then
                _SaltarA(txtCompIB3)
            Else
                _SaltarA(txtRetIB8)
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB3.Text = ""
        End If

    End Sub

    Private Sub txtCompIB3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB3.KeyDown
        
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB8)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB3.Text = ""
        End If

    End Sub

    Private Sub txtRetIB4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB4.KeyDown
        
        If e.KeyData = Keys.Enter Then

            If Trim(txtRetIB4.Text) <> "" Then
                _SaltarA(txtCompIB4)
            Else
                _SaltarA(txtRetIB5)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB3.Text = ""
        End If

    End Sub

    Private Sub txtCompIB4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB4.KeyDown
        
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB5)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB4.Text = ""
        End If

    End Sub

    Private Sub txtRetIB5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB5.KeyDown
        
        If e.KeyData = Keys.Enter Then

            If Trim(txtRetIB5.Text) <> "" Then
                _SaltarA(txtCompIB5)
            Else
                _SaltarA(txtRetIB6)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB5.Text = ""
        End If

    End Sub

    Private Sub txtCompIB5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB5.KeyDown
        
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB6)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB5.Text = ""
        End If

    End Sub

    Private Sub txtRetIB6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB6.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtRetIB6.Text) <> "" Then
                _SaltarA(txtCompIB6)
            Else
                _SaltarA(txtRetIB7)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB6.Text = ""
        End If

    End Sub

    Private Sub txtCompIB6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB6.KeyDown
        
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB7)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB6.Text = ""
        End If

    End Sub

    Private Sub txtRetIB7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB7.KeyDown
        
        If e.KeyData = Keys.Enter Then

            If Trim(txtRetIB7.Text) <> "" Then
                _SaltarA(txtCompIB7)
            Else
                Me.Close()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB7.Text = ""
        End If

    End Sub

    Private Sub txtCompIB7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB7.KeyDown
        
        If e.KeyData = Keys.Enter Then

            Me.Close()

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB7.Text = ""
        End If

    End Sub

    Private Sub txtRetIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB8.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtRetIB7.Text) <> "" Then
                _SaltarA(txtCompIB8)
            Else
                _SaltarA(txtRetIB4)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB8.Text = ""
        End If

    End Sub

    Private Sub txtCompIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB8.KeyDown
        
        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB4)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB8.Text = ""
        End If

    End Sub

    Private Sub _SaltarA(ByRef SiguienteControl As Control)
        SiguienteControl.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub NormalizarNumero(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIB1.Leave, txtRetIB2.Leave, txtRetIB3.Leave, txtRetIB4.Leave, txtRetIB5.Leave, txtRetIB6.Leave, txtRetIB7.Leave, txtRetIB8.Leave
        txtRetIB1.Text = Proceso.formatonumerico(txtRetIB1.Text)
        txtRetIB2.Text = Proceso.formatonumerico(txtRetIB2.Text)
        txtRetIB3.Text = Proceso.formatonumerico(txtRetIB3.Text)
        txtRetIB4.Text = Proceso.formatonumerico(txtRetIB4.Text)
        txtRetIB5.Text = Proceso.formatonumerico(txtRetIB5.Text)
        txtRetIB6.Text = Proceso.formatonumerico(txtRetIB6.Text)
        txtRetIB7.Text = Proceso.formatonumerico(txtRetIB7.Text)
        txtRetIB8.Text = Proceso.formatonumerico(txtRetIB8.Text)
    End Sub

    Private Sub SoloNumeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCompIB1.KeyPress, txtCompIB2.KeyPress, txtCompIB3.KeyPress, txtCompIB4.KeyPress, txtCompIB5.KeyPress, txtCompIB6.KeyPress, txtCompIB7.KeyPress, txtCompIB8.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetIB1.KeyPress, txtRetIB2.KeyPress, txtRetIB3.KeyPress, txtRetIB4.KeyPress, txtRetIB5.KeyPress, txtRetIB6.KeyPress, txtRetIB7.KeyPress, txtRetIB8.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub
End Class