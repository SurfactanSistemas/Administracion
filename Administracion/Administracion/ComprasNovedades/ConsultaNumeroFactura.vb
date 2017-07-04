Imports ClasesCompartidas

Public Class ConsultaNumeroFactura
    Public numero As Integer = 0

    Private Sub ConsultaNumeroFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim handler As New CommonEventsHandler
        handler.setIndexTabNotCRUDForm(Me)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        _DeterminarNumeroInterno()
    End Sub

    Private Sub _DeterminarNumeroInterno()
        numero = DAOCompras.buscarNumeroIntero(txtCodigoProveedor.Text, txtTipo.Text, txtLetra.Text, txtPunto.Text, txtNumero.Text)
        If numero = 0 Then
            MsgBox("No se encontró un número de factura con esos datos")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub txtCodigoProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtCodigoProveedor.Text)
            If Not IsNothing(proveedor) Then
                txtNombreProveedor.Text = proveedor.razonSocial

                cmbTipo.Focus()
            Else
                MsgBox("Proveedor no encontrado", MsgBoxStyle.Information)
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoProveedor.Text = ""
        End If

    End Sub

    Private Sub ConsultaNumeroFactura_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCodigoProveedor.Focus()
        cmbTipo.SelectedIndex = 0
    End Sub

    Private Sub txtLetra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLetra.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtLetra.Text) <> "" Then

                txtLetra.Text = txtLetra.Text.ToUpper

                If IsNumeric(Trim(txtLetra.Text)) Then
                    e.SuppressKeyPress = True
                    Exit Sub
                Else
                    txtPunto.Focus()
                End If

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtLetra.Text = ""
        End If

    End Sub

    Private Sub txtPunto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPunto.KeyDown

        If e.KeyData = Keys.Enter Then
            txtPunto.Text = ceros(txtPunto.Text, 4)

            txtNumero.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtPunto.Text = ""
        End If

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown

        If e.KeyData = Keys.Enter Then
            txtNumero.Text = ceros(txtNumero.Text, 8)

            _DeterminarNumeroInterno()

        ElseIf e.KeyData = Keys.Escape Then
            txtNumero.Text = ""
        End If

    End Sub

    Private Sub txtLetra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLetra.KeyPress

        If IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub cmbTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.TextChanged
        If cmbTipo.SelectedIndex <> -1 Then
            txtTipo.Text = "0" & cmbTipo.SelectedIndex + 1
        End If

        txtLetra.Focus()
    End Sub

    Private Sub cmbTipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo.KeyDown

        If e.KeyData = Keys.Enter Then
            txtLetra.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            cmbTipo.SelectedIndex = 0
        End If

    End Sub
End Class