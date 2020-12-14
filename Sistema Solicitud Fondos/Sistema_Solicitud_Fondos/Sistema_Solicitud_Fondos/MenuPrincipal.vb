Public Class MenuPrincipal

    Private Sub FinDeSistemasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinDeSistemasToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub IngresoDeSolicitudToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeSolicitudToolStripMenuItem.Click
        With New Ingreso_Solicitud
            .Show()
        End With
    End Sub

    Private Sub GestionSolicitudesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionSolicitudesToolStripMenuItem.Click
        With New Gestion_Solicitudes
            .Show()
        End With
    End Sub
End Class
