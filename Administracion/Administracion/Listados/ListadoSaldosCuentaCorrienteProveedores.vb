Imports ClasesCompartidas
Imports System.IO

'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared

Public Class ListadoSaldosCuentaCorrienteProveedores

    Private Sub LitadoSaldosCuentaCorrienteProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtAyuda.Text = ""
        txtDesdeProveedor.Text = "0"
        txtHastaProveedor.Text = "99999999999"
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(602, 470)

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        txtDesdeProveedor.Text = proveedor.id
        txtHastaProveedor.Text = proveedor.id
        txtDesdeProveedor.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
        REM txtDesdeProveedor.Text = lstAyuda.SelectedValue.id
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        'Dim viewer As New ReportViewer("saldos de ctacte", Globals.reportPathWithName("bancosnew.rpt"))

        Dim txtUno As String
        Dim txtDos As String
        Dim txtFormula As String
        Dim x As Char = Chr(34)

        txtUno = "{CtaCtePrv.Proveedor} in " + x + txtDesdeProveedor.Text + x + " to " + x + txtHastaProveedor.Text + x
        txtDos = " and {CtaCtePrv.Saldo} <> 0"
        txtFormula = txtUno + txtDos

        Dim viewer As New ReportViewer("saldos de ctacte", Globals.reportPathWithName("wsaldoprvnet.rpt"), txtFormula)


        Select Case TipoImpresion
            Case Reporte.Imprimir
                viewer.imprimirReporte()
            Case Reporte.Pantalla
                viewer.Show()
            Case Else

        End Select

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

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick, txtHastaProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress, txtHastaProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub

    Private Sub txtDesdeProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesdeProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesdeProveedor.Text) = "" Then : Exit Sub : End If

            txtHastaProveedor.Text = txtDesdeProveedor.Text
            txtHastaProveedor.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeProveedor.Text = ""
        End If

    End Sub

    Private Sub txtHastaProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHastaProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaProveedor.Text) = "" Then : Exit Sub : End If
            txtDesdeProveedor.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtHastaProveedor.Text = ""
        End If

    End Sub

End Class