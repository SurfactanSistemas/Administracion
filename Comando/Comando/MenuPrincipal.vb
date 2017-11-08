Public Class MenuPrincipal

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ComparaciónMensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparaciónMensualToolStripMenuItem.Click
        ComparacionesMensuales.Show()
    End Sub
End Class
