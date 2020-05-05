Imports Util
Imports Util.Clases

Public Class MenuPrincipal

    Private Sub FinDeSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinDeSistemaToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ConsultaPorCódigoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPorCódigoToolStripMenuItem.Click
        With New ListadoLaudosMPPorCodigo
            .Show(Me)
        End With
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conexion.EmpresaDeTrabajo = "SurfactanSa"

        WindowState = FormWindowState.Minimized

        Dim WArgs As String() = Environment.GetCommandLineArgs()

        If WArgs.Length > 1 Then

            Hide()

            Dim WTipo As Integer = 0
            Dim WHojaProducto As String = ""

            If WArgs.Length > 1 Then WTipo = WArgs(1)
            If WArgs.Length > 2 Then WHojaProducto = WArgs(2)

            _ProcesarSegunTipoConsulta(WTipo, WHojaProducto)

            Close()

        End If

        '_ProcesarSegunTipoConsulta(3, "PT-25021-100")

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub _ProcesarSegunTipoConsulta(ByVal wTipo As Integer, ByVal wHoja As String)

        Dim frm As Form

        Select Case wTipo
            Case 1 ' Movimientos de Hoja de Producción.

                frm = New DetalleMovimientosPT(wHoja, True)
                frm.Show()

            Case 2 ' Ensayos de Hoja de Produccion.

                frm = New DetallesEnsayosPT(wHoja)
                frm.Show()

            Case 3 ' Devoluciones por Hoja de Produccion.

                frm = New ListadoDevoluciones(wHoja)
                frm.Show()

        End Select

    End Sub

    Private Sub ConsultaPorCódigoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPorCódigoToolStripMenuItem1.Click
        With New ListadoHojasPTPorCodigo
            .Show(Me)
        End With
    End Sub

    Private Sub VerDevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDevolucionesToolStripMenuItem.Click
        With New ListadoDevoluciones
            .Show(Me)
        End With
    End Sub

    Private Sub ConsultaPorLaudoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPorLaudoToolStripMenuItem.Click
        With New DetalleMovimientosMP
            .show(Me)
        End With
    End Sub

    Private Sub ConsultaPorHojaDeProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPorHojaDeProducciónToolStripMenuItem.Click
        With New DetalleMovimientosPT
            .Show(Me)
        End With
    End Sub
End Class
