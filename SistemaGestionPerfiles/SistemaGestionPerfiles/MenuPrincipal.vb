Public Class MenuPrincipal

    Private Sub FinDeSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinDeSistemaToolStripMenuItem.Click
        Close()
    End Sub

    
  
    Private Sub GestionarPerfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionarPerfilesToolStripMenuItem.Click
        With GestionDePerfiles
            .Show(Me)
        End With
    End Sub
End Class
