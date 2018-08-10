Public Class MenuPrincipal

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

    Private Sub IngresoDeTalónDeInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeTalónDeInventarioToolStripMenuItem.Click
        _Abrir(New IngresoTalonInventario)
    End Sub

    Private Sub _Abrir(ByVal _f As Form)
        _f.Show(Me)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = String.Format("{0} S.A.", IIf(Helper._EsPellital, "PELLITAL", "SURFACTAN"))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.Show()
        Close()
    End Sub

    Private Sub VerificacionDeCorrelatividadDeTalonesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerificacionDeCorrelatividadDeTalonesToolStripMenuItem.Click
        _Abrir(New VerificacionCorrelatividades)
    End Sub
End Class
