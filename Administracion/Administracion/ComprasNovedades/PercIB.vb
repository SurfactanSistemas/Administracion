Public Class PercIB

    Private Sub DatosIB_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        _NormalizarValores()
        txtRetIB1.Focus()
    End Sub

    Private Sub txtRetIB1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB1.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB2)
        End If
    End Sub

    Private Sub txtRetIB2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB2.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB3)
        End If
    End Sub

    Private Sub txtRetIB3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB3.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB4)
        End If
    End Sub

    Private Sub txtRetIB4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB4.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB5)
        End If
    End Sub

    Private Sub txtRetIB5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB5.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB6)
        End If
    End Sub

    Private Sub txtRetIB6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB6.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB7)
        End If
    End Sub

    Private Sub txtRetIB7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB7.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB8)
        End If
    End Sub

    Private Sub txtRetIB8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB8.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB9)
        End If
    End Sub

    Private Sub txtRetIB9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB9.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB10)
        End If
    End Sub

    Private Sub txtRetIB10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB10.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB11)
        End If
    End Sub

    Private Sub txtRetIB11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB11.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB12)
        End If
    End Sub

    Private Sub txtRetIB12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB12.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB13)
        End If
    End Sub

    Private Sub txtRetIB13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB13.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtRetIB14)
        End If
    End Sub

    Private Sub txtRetIB14_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetIB14.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.Close()
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

    Private Sub txtRetIB1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetIB1.Leave, txtRetIB2.Leave, txtRetIB3.Leave, txtRetIB4.Leave, txtRetIB5.Leave, txtRetIB5.Leave, txtRetIB6.Leave, txtRetIB7.Leave, txtRetIB8.Leave, txtRetIB9.Leave, txtRetIB10.Leave, txtRetIB11.Leave, txtRetIB12.Leave, txtRetIB13.Leave, txtRetIB14.Leave
        _NormalizarValores()
    End Sub

    Private Sub _NormalizarValores()
        Dim campos As New List(Of TextBox) From {txtRetIB1, txtRetIB2, txtRetIB3, txtRetIB4, txtRetIB5, txtRetIB5, txtRetIB6, txtRetIB7, txtRetIB8, txtRetIB9, txtRetIB10, txtRetIB11, txtRetIB12, txtRetIB13, txtRetIB14}

        For Each c As TextBox In campos

            If c.Text = "" Then
                c.Text = "0"
            End If

            c.Text = CustomConvert.asStringWithDecimalPlaces(Trim(c.Text.Replace(".", ",")), 2)
        Next
    End Sub
End Class