Public Class DatosIB

    Private Sub DatosIB_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        NormalizarNumero(Nothing, Nothing)
        txtRetIB1.Focus()
    End Sub

    Private Sub txtRetIB15_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB15.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB15.Text) <> 0 Then
                _SaltarA(txtCompIB15)
            Else
                _SaltarA(txtRetIB16)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB15.Text = ""
        End If

    End Sub

    Private Sub txtCompIB15_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB15.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB16)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB15.Text = ""
        End If

    End Sub
    Private Sub txtRetIB16_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB16.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB16.Text) <> 0 Then
                _SaltarA(txtCompIB16)
            Else
                _SaltarA(txtRetIB17)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB16.Text = ""
        End If

    End Sub

    Private Sub txtCompIB16_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB16.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB17)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB16.Text = ""
        End If

    End Sub
    Private Sub txtRetIB17_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB17.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB17.Text) <> 0 Then
                _SaltarA(txtCompIB17)
            Else
                _SaltarA(txtRetIB18)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB17.Text = ""
        End If

    End Sub

    Private Sub txtCompIB17_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB17.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB18)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB17.Text = ""
        End If

    End Sub
    Private Sub txtRetIB18_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB18.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB18.Text) <> 0 Then
                _SaltarA(txtCompIB18)
            Else
                _SaltarA(txtRetIB19)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB18.Text = ""
        End If

    End Sub

    Private Sub txtCompIB18_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB18.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB19)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB18.Text = ""
        End If

    End Sub

    Private Sub txtRetIB19_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB19.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB19.Text) <> 0 Then
                _SaltarA(txtCompIB19)
            Else
                _SaltarA(txtRetIB20)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB19.Text = ""
        End If

    End Sub

    Private Sub txtCompIB19_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB19.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB20)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB19.Text = ""
        End If

    End Sub

    Private Sub txtRetIB20_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB20.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB20.Text) <> 0 Then
                _SaltarA(txtCompIB20)
            Else
                _SaltarA(txtRetIB21)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB20.Text = ""
        End If

    End Sub

    Private Sub txtCompIB20_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB20.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB21)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB20.Text = ""
        End If

    End Sub

    Private Sub txtRetIB21_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB21.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB21.Text) <> 0 Then
                _SaltarA(txtCompIB21)
            Else
                _SaltarA(txtRetIB22)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB21.Text = ""
        End If

    End Sub

    Private Sub txtCompIB21_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB21.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB22)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB21.Text = ""
        End If

    End Sub

    Private Sub txtRetIB22_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB22.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB22.Text) <> 0 Then
                _SaltarA(txtCompIB22)
            Else
                _SaltarA(txtRetIB23)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB22.Text = ""
        End If

    End Sub

    Private Sub txtCompIB22_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB22.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB23)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB22.Text = ""
        End If

    End Sub
    Private Sub txtRetIB1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB1.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB1.Text) <> 0 Then
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

            If Val(txtRetIB2.Text) <> 0 Then
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
            If Val(txtRetIB3.Text) <> 0 Then
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

            If Val(txtRetIB4.Text) <> 0 Then
                _SaltarA(txtCompIB4)
            Else
                _SaltarA(txtRetIB5)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB4.Text = ""
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

            If Val(txtRetIB5.Text) <> 0 Then
                _SaltarA(txtCompIB5)
            Else
                _SaltarA(txtRetIB12)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB5.Text = ""
        End If

    End Sub

    Private Sub txtCompIB5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB5.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB12)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB5.Text = ""
        End If

    End Sub

    Private Sub txtRetIB6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB6.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB6.Text) <> 0 Then
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

            If Val(txtRetIB7.Text) <> 0 Then
                _SaltarA(txtCompIB7)
            Else
                _SaltarA(txtRetIB15)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB7.Text = ""
        End If

    End Sub

    Private Sub txtCompIB7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB7.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB15)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB7.Text = ""
        End If

    End Sub


    Private Sub txtRetIB23_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB23.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB23.Text) <> 0 Then
                _SaltarA(txtCompIB23)
            Else
                Me.Close()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB23.Text = ""
        End If

    End Sub

    Private Sub txtCompIB23_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB23.KeyDown

        If e.KeyData = Keys.Enter Then

            Me.Close()

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB23.Text = ""
        End If

    End Sub

    Private Sub txtRetIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB8.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB8.Text) <> 0 Then
                _SaltarA(txtCompIB8)
            Else
                _SaltarA(txtRetIB9)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB8.Text = ""
        End If

    End Sub

    Private Sub _SaltarA(ByRef SiguienteControl As Control)
        SiguienteControl.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub NormalizarNumero(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIB1.Leave, txtRetIB2.Leave, txtRetIB3.Leave, txtRetIB4.Leave, txtRetIB5.Leave, txtRetIB6.Leave, txtRetIB7.Leave, txtRetIB8.Leave, txtRetIB11.Leave, txtRetIB10.Leave, txtRetIB14.Leave, txtRetIB12.Leave, txtRetIB13.Leave, txtRetIB9.Leave, txtRetIB23.Leave, txtRetIB22.Leave, txtRetIB21.Leave, txtRetIB20.Leave, txtRetIB19.Leave, txtRetIB18.Leave, txtRetIB17.Leave, txtRetIB16.Leave, txtRetIB15.Leave
        For Each t As TextBox In {txtRetIB1, txtRetIB2, txtRetIB3, txtRetIB4, txtRetIB5, txtRetIB6, txtRetIB7, txtRetIB8, txtRetIB9, txtRetIB10, txtRetIB11, txtRetIB12, txtRetIB13, txtRetIB14, txtRetIB15, txtRetIB16, txtRetIB17, txtRetIB18, txtRetIB19, txtRetIB20, txtRetIB21, txtRetIB22, txtRetIB23}

            t.Text = Proceso.formatonumerico(t.Text)

        Next
    End Sub

    Private Sub SoloNumeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCompIB1.KeyPress, txtCompIB2.KeyPress, txtCompIB3.KeyPress, txtCompIB4.KeyPress, txtCompIB5.KeyPress, txtCompIB6.KeyPress, txtCompIB7.KeyPress, txtCompIB8.KeyPress, txtCompIB10.KeyPress, txtCompIB14.KeyPress, txtCompIB9.KeyPress, txtCompIB12.KeyPress, txtCompIB13.KeyPress, txtCompIB11.KeyPress, txtCompIB23.KeyPress, txtCompIB22.KeyPress, txtCompIB21.KeyPress, txtCompIB20.KeyPress, txtCompIB19.KeyPress, txtCompIB18.KeyPress, txtCompIB17.KeyPress, txtCompIB16.KeyPress, txtCompIB15.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetIB1.KeyPress, txtRetIB2.KeyPress, txtRetIB3.KeyPress, txtRetIB4.KeyPress, txtRetIB5.KeyPress, txtRetIB6.KeyPress, txtRetIB7.KeyPress, txtRetIB8.KeyPress, txtRetIB9.KeyPress, txtRetIB10.KeyPress, txtRetIB11.KeyPress, txtRetIB12.KeyPress, txtRetIB13.KeyPress, txtRetIB14.KeyPress, txtRetIB23.KeyPress, txtRetIB22.KeyPress, txtRetIB21.KeyPress, txtRetIB20.KeyPress, txtRetIB19.KeyPress, txtRetIB18.KeyPress, txtRetIB17.KeyPress, txtRetIB16.KeyPress, txtRetIB15.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRetIB9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB9.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB9.Text) <> 0 Then
                _SaltarA(txtCompIB9)
            Else
                _SaltarA(txtRetIB10)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB9.Text = ""
        End If

    End Sub

    Private Sub txtRetIB10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB10.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB10.Text) <> 0 Then
                _SaltarA(txtCompIB10)
            Else
                _SaltarA(txtRetIB11)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB10.Text = ""
        End If

    End Sub

    Private Sub txtRetIB11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB11.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB11.Text) <> 0 Then
                _SaltarA(txtCompIB11)
            Else
                _SaltarA(txtRetIB4)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB9.Text = ""
        End If

    End Sub

    Private Sub txtRetIB12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB12.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB12.Text) <> 0 Then
                _SaltarA(txtCompIB12)
            Else
                _SaltarA(txtRetIB13)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB12.Text = ""
        End If

    End Sub

    Private Sub txtRetIB13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB13.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB13.Text) <> 0 Then
                _SaltarA(txtCompIB13)
            Else
                _SaltarA(txtRetIB14)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB13.Text = ""
        End If

    End Sub

    Private Sub txtRetIB14_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB14.KeyDown

        If e.KeyData = Keys.Enter Then

            If Val(txtRetIB14.Text) <> 0 Then
                _SaltarA(txtCompIB14)
            Else
                _SaltarA(txtRetIB6)
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtRetIB14.Text = ""
        End If

    End Sub

    Private Sub txtCompIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB8.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB9)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB8.Text = ""
        End If

    End Sub

    Private Sub txtCompIB9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB9.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB10)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB9.Text = ""
        End If

    End Sub

    Private Sub txtCompIB10_keydown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB10.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB11)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB10.Text = ""
        End If

    End Sub

    Private Sub txtCompIB11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB11.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB4)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB11.Text = ""
        End If

    End Sub

    Private Sub txtCompIB12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB12.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB13)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB12.Text = ""
        End If

    End Sub

    Private Sub txtCompIB13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB13.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB14)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB13.Text = ""
        End If

    End Sub

    Private Sub txtCompIB14_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompIB14.KeyDown

        If e.KeyData = Keys.Enter Then

            _SaltarA(txtRetIB6)

        ElseIf e.KeyData = Keys.Escape Then
            txtCompIB14.Text = ""
        End If

    End Sub


End Class