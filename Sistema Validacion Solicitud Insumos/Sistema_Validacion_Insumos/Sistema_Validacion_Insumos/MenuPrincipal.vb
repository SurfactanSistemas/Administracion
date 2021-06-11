Public Class MenuPrincipal

    Private Sub GestorDeInsumosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorDeInsumosToolStripMenuItem.Click
        With New Gestor_Insumos
            .Show()
        End With
    End Sub
End Class
