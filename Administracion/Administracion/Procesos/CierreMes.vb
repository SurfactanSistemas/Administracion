Imports ClasesCompartidas
Imports System.IO

Public Class CierreMes

    Private Sub CierreMes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtMes.Text = ""
        txtAno.Text = ""

    End Sub

    Private Sub txtmes_KeyPress(ByVal sender As Object, _
                    ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                    Handles txtMes.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtAno.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtMes.Text = ""
        End If
    End Sub



    Private Sub txtano_KeyPress(ByVal sender As Object, _
                    ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                    Handles txtAno.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtMes.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAno.Text = ""
        End If
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu.Click
        Me.Close()
    End Sub
End Class