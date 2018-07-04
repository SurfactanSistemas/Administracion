Public Class MenuPrincipal

    'Private Sub MuestraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    With IngresoOrdenTrabajo
    '        .Show()
    '        .WindowState = FormWindowState.Normal
    '        .Focus()
    '    End With

    'End Sub

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

    Private Sub IngresoDeRemitoVarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeRemitoVarioToolStripMenuItem.Click
        IngresoRemitoVario.Show(Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.Show()
    End Sub
End Class
