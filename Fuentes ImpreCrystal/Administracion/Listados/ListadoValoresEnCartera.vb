Imports ClasesCompartidas
Imports System.IO

Public Class ListadoValoresEnCartera

    Private Sub ListadoValoresEnCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAyuda.Text = ""
        txtFecha1.Text = "  /  /    "
        txtFecha2.Text = "  /  /    "
        txtFecha3.Text = "  /  /    "
        txtFecha4.Text = "  /  /    "
        txtDesdeFecha.Text = "  /  /    "
        txtHastaFecha.Text = "  /  /    "
        txtCliente.Text = ""
        txtRazonSocial.Text = ""
        opcPantalla.Checked = False
        opcImpesora.Checked = True
    End Sub

    Private Sub txtfecha1_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha1.Text) = "S" Then
                txtFecha2.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha1.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha2_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha2.Text) = "S" Then
                txtFecha3.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha2.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha3_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha3.Text) = "S" Then
                txtFecha4.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha3.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtfecha4_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtFecha4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFecha4.Text) = "S" Then
                txtDesdeFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFecha4.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                txtHastaFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeFecha.Text = "  /  /    "
        End If
    End Sub

    Private Sub txthastafecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtHastaFecha.Text) = "S" Then
                txtCliente.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaFecha.Text = "  /  /    "
        End If
    End Sub

    Private Sub txtcliente_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtCliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Dim CampoCliente As Cliente = DAOCliente.buscarClientePorCodigo(txtCliente.Text)
            txtRazonSocial.Text = CampoCliente.razon.ToString
            txtFecha1.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtCliente.Text = ""
            txtRazonSocial.Text = ""
        End If
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(500, 520)

        lstAyuda.DataSource = DAOCliente.buscarClientePorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtAyuda.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOCliente.buscarClientePorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
        End If
    End Sub

    Private Sub mostrarCliente(ByVal cliente As Cliente)
        txtCliente.Text = cliente.id
        txtRazonSocial.Text = cliente.razon
        txtCliente.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarCliente(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

End Class