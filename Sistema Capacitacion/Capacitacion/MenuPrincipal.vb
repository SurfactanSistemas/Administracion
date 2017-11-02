Public Class MenuPrincipal

    Private Sub MenuPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Close()
    End Sub

    Private Sub IngresoSectoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoSectoresToolStripMenuItem.Click
        SectoresPrincipal.Show()
        'AMBSectores.Show()
    End Sub

    Private Sub IngresoTemasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoTemasToolStripMenuItem.Click
        TemasPrincipal.Show()
        'AMBTareas.Show()
    End Sub

    Private Sub IngresoDeCursosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeCursosToolStripMenuItem.Click
        CursosPrincipal.Show()
        'AMBCursos.Show()
    End Sub

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class