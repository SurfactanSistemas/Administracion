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

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        _Abrir(New VerificacionTalonesDuplicados)
    End Sub

    Private Sub RecuentoDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecuentoDeToolStripMenuItem.Click
        _Abrir(New RecuentoInventarioMP)
    End Sub

    Private Sub RecuentoDeInventarioDeProductoTerminadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecuentoDeInventarioDeProductoTerminadoToolStripMenuItem.Click
        _Abrir(New RecuentoInventarioPT)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        _Abrir(New DiferenciaInventarioMP)
    End Sub

    Private Sub DiferenciaDeInventarioDeProductoTerminadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiferenciaDeInventarioDeProductoTerminadoToolStripMenuItem.Click
        _Abrir(New DiferenciaInventarioPT)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        _Abrir(New MPPTConLote0)
    End Sub

    Private Sub DiferenciaDeInventarioDeMateriaPrimaContraStockAnteriorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiferenciaDeInventarioDeMateriaPrimaContraStockAnteriorToolStripMenuItem.Click
        _Abrir(New DiferenciaInventarioMPStockAnterior)
    End Sub
End Class
