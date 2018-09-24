Imports Inventario.Clases

Public Class MenuPrincipal

    Sub New(Optional ByVal v As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If v Then
            CierreStockPtaVToolStripMenuItem.Enabled = False
            ActualizaciónDeStockToolStripMenuItem.Enabled = False
            ActualizaciónStockPtaVToolStripMenuItem.Enabled = False
            ToolStripMenuItem5.Enabled = False
            ToolStripMenuItem4.Enabled = False
            ActualizacionDeStockPorAjusteDeMovimientosVariosToolStripMenuItem.Enabled = False
        End If

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

    Private Sub IngresoDeTalónDeInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeTalónDeInventarioToolStripMenuItem.Click
        _Abrir(New IngresoTalonInventario)
    End Sub

    Private Sub _Abrir(ByVal _f As Form)
        _f.Show(Me)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label2.Text = String.Format("{0} S.A.", IIf(Helper._EsPellital, "PELLITAL", "SURFACTAN"))

        If Conexion.EmpresaDeTrabajo.ToUpper <> "SURFACTAN_V" Then
            ActualizaciónDeStockToolStripMenuItem.Enabled = True
            ToolStripMenuItem5.Enabled = True
            ActualizaciónStockPtaVToolStripMenuItem.Enabled = False
            CierreStockPtaVToolStripMenuItem.Enabled = False
        Else
            ActualizaciónDeStockToolStripMenuItem.Enabled = False
            ToolStripMenuItem5.Enabled = False
            ActualizaciónStockPtaVToolStripMenuItem.Enabled = True
            CierreStockPtaVToolStripMenuItem.Enabled = True
        End If

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

    Private Sub DiferenciaDeInventarioDeMateriaPrimaContraStockAnteriorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Abrir(New DiferenciaInventarioMPStockAnterior)
    End Sub

    Private Sub DiferenciaDeInventarioDeProductoTerminadoContraStockAnteriorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Abrir(New DiferenciaInventarioPTStockAnterior)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        _Abrir(New LimpiarCargaInventario)
    End Sub

    Private Sub ControlDeMarcaDeLoteControlDeLoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeMarcaDeLoteControlDeLoteToolStripMenuItem.Click
        _Abrir(New ControlMarcaLote)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        _Abrir(New CierreStock)
    End Sub

    Private Sub ActualizaciónDeStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaciónDeStockToolStripMenuItem.Click
        _Abrir(New ActualizacionStock)
    End Sub

    Private Sub ActualizaciónStockPtaVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaciónStockPtaVToolStripMenuItem.Click
        _Abrir(New ActualizacionStockPtaV)
    End Sub

    Private Sub CierreStockPtaVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreStockPtaVToolStripMenuItem.Click
        _Abrir(New CierreStockPtaV)
    End Sub

    Private Sub ActualizacionDeStockPorAjusteDeMovimientosVariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizacionDeStockPorAjusteDeMovimientosVariosToolStripMenuItem.Click
        _Abrir(New AjusteInventarioMPMovVarios)
    End Sub
End Class
