Public Class MenuPrincipal

    Private Sub IngresiDeOrdenesDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresiDeOrdenesDeTrabajoToolStripMenuItem.Click

        With IngresoOrdenTrabajo
            .Show()
            .WindowState = FormWindowState.Normal
            .Focus()
        End With

    End Sub

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Close()
    End Sub
End Class
