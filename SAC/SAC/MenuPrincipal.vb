Public Class MenuPrincipal

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Login.Dispose()
        Close()
    End Sub

    Private Sub Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Val(Operador.CodigoResponsableSac) = 0 Or Val(Operador.Codigo) = 3 Or Val(Operador.Codigo) = 21 Then
            For Each i As ToolStripMenuItem In {TiposDeSolicitudToolStripMenuItem, ResponsablesToolStripMenuItem}
                i.Enabled = False
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.Show()
        Close()
    End Sub

    Private Sub TiposDeSolicitudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeSolicitudToolStripMenuItem.Click
        Abrir(New ListadoTiposSolicitud)
    End Sub

    Private Sub ResponsablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResponsablesToolStripMenuItem.Click
        Abrir(New ListadoResponsablesSAC)
    End Sub
End Class
