Imports ClasesCompartidas
Imports System.IO

Public Class ListadoValoresEnCarteraCuit

    Private Sub ListadoValoresEnCarteraCuit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "
        txtCuit.Text = ""

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
                txtCuit.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    'Private Sub txtcuit_KeyPress(ByVal sender As Object, _
    '               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    '               Handles txtCuit.KeyPress
    '    If e.KeyChar = Convert.ToChar(Keys.Return) Then
    '        e.Handled = True
    '        txtDesdeFecha.Focus()
    '    ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
    '        e.Handled = True
    '        txtCuit.Text = ""
    '    End If
    'End Sub


    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)

        Dim varUno, varDos As String

        Dim varEmpresa As String
        Dim varFormula As String
        Dim x As Char = Chr(34)
        Dim varDesdefechaOrd, varHastafechaOrd As String

        varEmpresa = "Surfactan S.A."

        varDesdefechaOrd = ordenaFecha(txtDesdeFecha.Text)
        varHastafechaOrd = ordenaFecha(txthastafecha.Text)

        varUno = "{Recibos.fechaord2} in " + x + varDesdefechaOrd + x + " to " + x + varHastafechaOrd + x
        varDos = " and {recibos.cuit} in " + x + txtCuit.Text + x + " to " + x + txtCuit.Text + x

        varFormula = varUno + varDos

        Dim viewer As New ReportViewer("Listado de Valores en Cartera por Cuit", Globals.reportPathWithName("listavalorescuitnet.rpt"), varFormula)

        With viewer

            Select Case TipoImpresion
                Case Reporte.Pantalla
                    .ShowDialog()
                Case Reporte.Imprimir
                    .imprimirReporte()
            End Select

        End With

    End Sub

    Private Sub txtCuit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuit.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCuit.Text) = "" Then : Exit Sub : End If

            If Not Proceso.CuitValido(Trim(txtCuit.Text)) Then
                Exit Sub
            End If

            txtDesdeFecha.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtCuit.Text = ""
        End If

    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub
End Class