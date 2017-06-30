Imports ClasesCompartidas
Imports System.IO

Public Class ListadoRetencionIBCiudad

    Private Sub ListadoRetencionIBCiudad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDesdeFecha.Text = "  /  /    "
        txthastafecha.Text = "  /  /    "

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
                txtDesdeFecha.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txthastafecha.Text = "  /  /    "
            Me.txthastafecha.SelectionStart = 0
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        Dim varDesde, varHasta As String
        Dim varUno, varDos, varTres As String
        Dim varFormula, varEmpresa, varTitulo As String
        Dim x As Char = Chr(34)

        varDesde = ordenaFecha(txtDesdeFecha.Text)
        varHasta = ordenaFecha(txthastafecha.Text)

        varEmpresa = "Surfactan S.A."
        varTitulo = "Desde el " + txtDesdeFecha.Text + " al " + txthastafecha.Text

        SQLConnector.retrieveDataTable("modificar_pagos_titulo", varEmpresa, varTitulo, varDesde, varHasta)

        varUno = "{Pagos.Fechaord} in " + x + varDesde + x + " to " + x + varHasta + x
        varDos = " and {Pagos.RetIbCiudad} <> 0"
        varTres = " and {Pagos.Renglon} = " + x + "01" + x

        varFormula = varUno + varDos + varTres

        Dim viewer As New ReportViewer("Listado de Retenciones de Ingresos Brutos (CABA)", Globals.reportPathWithName("wListIbCiudadnet.rpt"), varFormula)

        If opcPantalla.Checked = True Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
        End If

    End Sub

End Class