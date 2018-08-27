Public Class MenuPrincipal

    Private Sub _Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Login.Dispose()
        Close()
    End Sub

    Private Sub MenuPrincipal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ' Menu 1: Maestros.
        With Me
            '.IngresiDeOrdenesDeTrabajoToolStripMenuItem.Enabled = Conexion.WAtributosOperador(1, 1)
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.Show()
        Close()
    End Sub

    Private Sub DeclaraciónJuradaMateriasPrimasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeclaraciónJuradaMateriasPrimasToolStripMenuItem.Click
        _Abrir(New DeclaracionJuradaMP)
    End Sub

    Private Sub DeclaraciónJuradaProductosTerminadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeclaraciónJuradaProductosTerminadosToolStripMenuItem.Click
        _Abrir(New DeclaracionJuradaPT)
    End Sub
End Class
