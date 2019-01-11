Public Class MenuPrincipal
    Private Sub Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ControlesIntermedisToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ControlesIntermedisToolStripMenuItem.Click
        Abrir(New IngresoEnsayosIntermediosPT)
    End Sub
End Class