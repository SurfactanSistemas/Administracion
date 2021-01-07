Public Class MenuPrincipal

    Private Sub IngresoDeSolicitudToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeSolicitudToolStripMenuItem.Click
        With New CargadorDeTxt
            .Show()
        End With
    End Sub
End Class
