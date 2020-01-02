Public Class ActualizacionDetallesCertAnalisisYEstadoEnvases

    Private Sub rbSiCertificadoAnalisis_Click(sender As Object, e As EventArgs) Handles rbSiCertificadoAnalisis.Click, rbNoCertificadoAnalisis.Click
        txtCertificado2.Focus()
    End Sub

    Private Sub txtCertificado2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCertificado2.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtCertificado2.Text) = "" Then : Exit Sub : End If
            txtEstado2.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCertificado2.Text = ""
        End If

    End Sub

    Private Sub txtEstado2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEstado2.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtEstado2.Text) = "" Then : Exit Sub : End If
            cmbTipoVencimiento.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtEstado2.Text = ""
        End If

    End Sub

    Private Sub txtFechaVencimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaVencimiento.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFechaVencimiento.Text) = "" Then : Exit Sub : End If
            Dim length = txtFechaVencimiento.Text.Replace(" ", "").Length

            If length > 2 AndAlso length <= 10 Then
                If _ValidarFecha(txtFechaVencimiento.Text) Then
                    txtFechaElaboracion.Focus()
                End If
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaVencimiento.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '
        ' Validamos las fechas de Vencimiento y Elaboracion en caso de que estén cargadas.
        '
        Dim length As Short = txtFechaVencimiento.Text.Replace(" ", "").Length

        If length > 2 AndAlso length <= 10 Then
            If Not _ValidarFecha(txtFechaVencimiento.Text) Then
                MsgBox("Se debe indicar una Fecha de Vencimiento válida.")
                txtFechaVencimiento.Focus()
                Exit Sub
            End If
        End If

        length = txtFechaElaboracion.Text.Replace(" ", "").Length

        If length > 2 AndAlso length <= 10 Then
            If Not _ValidarFecha(txtFechaElaboracion.Text) Then
                MsgBox("Se debe indicar una Fecha de Elaboracion válida.")
                txtFechaElaboracion.Focus()
                Exit Sub
            End If
        End If

        DialogResult = Windows.Forms.DialogResult.OK

        Close()

    End Sub
End Class