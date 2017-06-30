Public Class MenuPrincipal
    Dim forms As New List(Of Form)
    Dim loginOpen As Boolean = False

    Private Sub abrir(ByVal form As Form)
        Dim opennedForm As Form = forms.Find(Function(openForm) openForm.GetType() = form.GetType())
        If IsNothing(opennedForm) OrElse opennedForm.IsDisposed Then
            forms.Add(form)
            form.Show()
            forms.Remove(opennedForm)
        Else
            form.Dispose()
            opennedForm.Focus()
        End If
    End Sub

    Private Sub btnCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambio.Click
        Dim msgResult = vbYes
        If forms.Any(Function(form) form.Visible) Then
            msgResult = MsgBox("¿Se cerrarán todos los formularios abiertos, está seguro que desea cambiar de empresa?", vbYesNo, "Cambiar de Empresa")
        End If
        If msgResult = vbYes Then
            forms.ForEach(Sub(form) form.Dispose())
            Login.Show()
            loginOpen = True
            Close()
        End If
    End Sub

    Private Sub FinDelSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinDelSistemaToolStripMenuItem.Click
        Close()
        End
    End Sub


    Private Sub MenuPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not loginOpen Then
            End
        End If
    End Sub

    Private Sub AsdasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub EstadisticaDeVentasPorRubroYClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorRubroYClienteToolStripMenuItem.Click
        abrir(New ListadoEstaRubroLinea)
    End Sub

    Private Sub EstadisticaDeVentasPorVendedorRuboYLineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorVendedorRuboYLineaToolStripMenuItem.Click
        abrir(New ListadoEstaVendedorRubroLinea)
    End Sub

    Private Sub EstadisticaDeVentasPorVededorClienteYLineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorVededorClienteYLineaToolStripMenuItem.Click
        abrir(New ListadoEstaVendedorClienteLinea)
    End Sub

    Private Sub EstadisticaDeVentasPorVendedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorVendedorToolStripMenuItem.Click
        abrir(New ListadoEstaVendedorLinea)
    End Sub

    Private Sub EstadisticaDeVentasPorLineaYProductoIndToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorLineaYProductoIndToolStripMenuItem.Click
        abrir(New ListadoEstaLineaProductoInd)
    End Sub

    Private Sub EstadisticaDeVentasPorLineaYProductoIndToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorLineaYProductoIndToolStripMenuItem1.Click
        abrir(New ListadoEstaLineaProducto)
    End Sub

    Private Sub EstsdisticaDeVentasPorProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstsdisticaDeVentasPorProductoToolStripMenuItem.Click
        abrir(New ListadoEstaProductoCliente)
    End Sub

    Private Sub EstadisticaDeVentasPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasPorClienteToolStripMenuItem.Click
        abrir(New ListadoEstaClienteLinea)
    End Sub

    Private Sub RankingDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RankingDeVentasToolStripMenuItem.Click
        abrir(New ListadoEstaRanking)
    End Sub

    Private Sub EstadisticaDeVentasAnualesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoEstaAnual)
    End Sub

    Private Sub EstadisticaDeVentasAnualesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasAnualesToolStripMenuItem.Click
        abrir(New ListadoEstaAnual)
    End Sub

    Private Sub EstadisticaDeVentasComparativaEntreAñosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaDeVentasComparativaEntreAñosToolStripMenuItem.Click
        abrir(New ListadoEstaInterAnual)
    End Sub

    Private Sub EmisionDeGraficosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisionDeGraficosToolStripMenuItem.Click
        abrir(New ListadoGrafico)
    End Sub

    Private Sub EmiiosnDeGraficosAnualesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmiiosnDeGraficosAnualesToolStripMenuItem.Click
        abrir(New ListadoGraficoAnual)
    End Sub
End Class