Imports ClasesCompartidas

Public Class ConsultaCheque

    Private Sub btnProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceso.Click
        ejecutar()
    End Sub

    Private Sub ejecutar()
        If IsNumeric(txtCheque.Text) Then
            If cmbTipo.SelectedIndex = 0 Then
                For Each row In SQLConnector.retrieveDataTable("get_cheques_terceros", txtCheque.Text).Rows
                    gridCheque.Rows.Add(row("Numero2").ToString,
                                        row("Banco").ToString,
                                        formatonumerico(redondeo(Convert.ToDouble(row("Importe2"))), "#######0.#0", "."),
                                        row("Fecha").ToString,
                                        row("Fecha2").ToString,
                                        row("Recibo").ToString,
                                        row("Cliente").ToString)
                Next
            Else
                For Each row In SQLConnector.retrieveDataTable("get_cheques_propios", txtCheque.Text).Rows
                    gridCheque.Rows.Add(row("Numero2").ToString,
                                        formatonumerico(redondeo(Convert.ToDouble(row("Importe2"))), "#######0.#0", "."),
                                        row("Importe2").ToString,
                                        row("Fecha").ToString,
                                        row("Fecha2").ToString,
                                        row("Recibo").ToString,
                                        row("Proveedor").ToString)
                Next
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub ConsultaCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbTipo.SelectedIndex = 0
    End Sub

    Private Sub txtCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheque.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ejecutar()
        End If
    End Sub

    Private Sub txtCheque_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtCheque_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class