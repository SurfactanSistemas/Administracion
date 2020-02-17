Public Class MenuPrincipal

    Private Sub FinDeSistemasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinDeSistemasToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PedidosPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosPendientesToolStripMenuItem.Click
        With ListadoPedidosPendientes
            .Show()
        End With
    End Sub
End Class
