Public Class MenuPrincipal

    Private Sub FinDeSistemasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinDeSistemasToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PedidosPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosPendientesToolStripMenuItem.Click
        With ListadoPedidosPendientes
            .Show()
        End With
    End Sub

    Private Sub IngresoRubroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoRubroToolStripMenuItem.Click
        With IngresoRubros
            .Show()
        End With
    End Sub

    Private Sub IngresoVendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoVendedoresToolStripMenuItem.Click
        With IngresoVendedores
            .Show()
        End With
    End Sub

    Private Sub CondicionDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CondicionDePagoToolStripMenuItem.Click
        With IngresoCondiPago
            .Show()
        End With
    End Sub

    Private Sub IngresoDeLineasDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeLineasDeVentasToolStripMenuItem.Click
        With IngresoLineasDeVentas
            .Show()
        End With
    End Sub

    Private Sub IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem.Click
        With IngresoFliaMP
            .Show()
        End With
    End Sub
End Class
