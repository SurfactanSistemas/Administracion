Imports ClasesCompartidas
Imports System.IO

Public Class ListadoPagosPosdatados

    Private Sub ListadoPagosPosdatados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

        txtDesdeBanco.Text = "0"
        txtHastaBanco.Text = "9999"

        opcPantalla.Checked = False
        opcImpesora.Checked = True
    End Sub

    Private Sub txtdesdefecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeFecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtDesdeFecha.Text) = "S" Then
                txthastafecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeFecha.Text = "  /  /    "
            Me.txtDesdeFecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txthastafecha_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txthastafecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txthastafecha.Text) = "S" Then
                txtDesdeBanco.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub txtdesdebanco_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtDesdeBanco.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtHastaBanco.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtDesdeBanco.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthastabanco_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtHastaBanco.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDesdeFecha.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtHastaBanco.Text = ""
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(466, 475)

        lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
            lstAyuda.DataSource = DAOBanco.buscarBancoPorNombre(txtAyuda.Text)
        End If
    End Sub

    Private Sub mostrarbanco(ByVal banco As Banco)
        txtDesdeBanco.Text = banco.id
        txtHastaBanco.Text = banco.id
        txtDesdeBanco.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarbanco(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        Dim txtDesde As String
        Dim txtHasta As String
        Dim txtUno As String
        Dim txtDos As String
        Dim txtTres As String
        Dim txtCuatro As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)

        txtDesde = ordenaFecha(txtDesdeFecha.Text)
        txtHasta = ordenaFecha(txthastafecha.Text)

        txtUno = "{Pagos.Fechaord2} in " + x + txtDesde + x + " to " + x + txtHasta + x
        txtDos = " and {Pagos.Importe2} <> 0 "
        txtTres = " and {Pagos.Banco2} in " + txtDesdeBanco.Text + " to " + txtHastaBanco.Text
        txtCuatro = " and {Pagos.FechaOrd} <> {Pagos.FechaOrd2}"
        txtFormula = txtUno + txtDos + txtTres + txtCuatro

        Dim viewer As New ReportViewer("Listado de Pagos Posdatados", Globals.reportPathWithName("wListaPosdatnet.rpt"), txtFormula)

        If opcPantalla.Checked = True Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
        End If


    End Sub

    Private Sub txtDesdeBanco_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeBanco.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub


    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstAyuda
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedIndex = origen.FindStringExact(filtrado.SelectedItem.ToString)

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub
    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeBanco.KeyPress, txtHastaBanco.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class