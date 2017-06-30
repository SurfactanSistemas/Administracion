Public Class CUFEProveedor

    'Dim organizadorABM As New FormOrganizer(Me, 533, 600)

    'Private Sub CUFEProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    organizadorABM.addControls(txtCUFE1, txtCUFE2, txtCUFE3)
    '    organizadorABM.addAnnexedControls(New List(Of CustomControl) From {txtCUFE1Fecha, txtCUFE2Fecha, txtCUFE3Fecha})
    '    organizadorABM.organizeForNotCRUDForm()
    'End Sub

    Private Sub CUFEProveedor_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCUFE1.Focus()
    End Sub

    Private Sub txtCUFE1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE1.KeyDown

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

    Private Sub txtCUFE1Fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE1Fecha.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE1.Text) <> "" And Trim(txtCUFE1Fecha.Text.Replace("/", "")) <> "" Then
                txtCUFE2.Focus()
            Else
                txtCUFE1Fecha.Focus()
            End If
        End If
    End Sub

    Private Sub txtCUFE2Fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE2Fecha.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE2.Text) <> "" And Trim(txtCUFE2Fecha.Text.Replace("/", "")) <> "" Then
                txtCUFE3.Focus()
            Else
                txtCUFE2Fecha.Focus()
            End If
        End If
    End Sub

    Private Sub txtCUFE3Fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUFE3Fecha.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtCUFE3.Text) <> "" And Trim(txtCUFE3Fecha.Text.Replace("/", "")) <> "" Then
                Me.Close()
            Else
                txtCUFE3Fecha.Focus()
            End If
        End If
    End Sub
End Class