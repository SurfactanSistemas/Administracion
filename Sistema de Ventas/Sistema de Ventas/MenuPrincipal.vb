Public Class MenuPrincipal

    Private Sub FinDeSistemasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinDeSistemasToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PedidosPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosPendientesToolStripMenuItem.Click
        With ListadoPedidosPendientes
            .Show()
        End With
    End Sub

    Private Sub IngresoRubroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoRubroToolStripMenuItem.Click
        With IngresoRubros
            .Show()
        End With
    End Sub

    Private Sub IngresoVendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoVendedoresToolStripMenuItem.Click
        With IngresoVendedores
            .Show()
        End With
    End Sub

    Private Sub CondicionDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CondicionDePagoToolStripMenuItem.Click
        With IngresoCondiPago
            .Show()
        End With
    End Sub

    Private Sub IngresoDeLineasDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeLineasDeVentasToolStripMenuItem.Click
        With IngresoLineasDeVentas
            .Show()
        End With
    End Sub

    Private Sub IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeFamiliasDeMateriasPrimasToolStripMenuItem.Click
        With IngresoFliaMP
            .Show()
        End With
    End Sub

    Private Sub IngresoDeEnvasesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeEnvasesToolStripMenuItem.Click
        With IngresoEnvases
            .Show()
        End With
    End Sub

    Private Sub IngresoDeGastosDeImportacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeGastosDeImportacionToolStripMenuItem.Click
        With IngresoConcepDGastosImportacion
            .Show()
        End With
    End Sub

    Private Sub ConsultaDeVersionesDeComposicionDePTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeVersionesDeComposicionDePTToolStripMenuItem.Click
        With ConsultaDeVersionesComposicionPT
            .Show()
        End With
    End Sub

    Private Sub ConsultaDeRevisionesDeEnsayosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeRevisionesDeEnsayosToolStripMenuItem.Click
        With Consulta_de_revisiones_de_ensayos
            .Show()
        End With
    End Sub

    Private Sub IngresoDeCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeCambiosToolStripMenuItem.Click
        With Ingreso_Cambios
            .Show()
        End With
    End Sub

    Private Sub PedidosDesarrolloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosDesarrolloToolStripMenuItem.Click
        With OrdenesTrabajoDesarrollo
            .Show()
        End With
    End Sub

    Private Sub HojaDeRutaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HojaDeRutaToolStripMenuItem.Click
        With ConsultaHojaDeRuta
            .Show()
        End With
    End Sub

    Private Sub VerificacionDeCostoDeProductosTerminadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificacionDeCostoDeProductosTerminadosToolStripMenuItem.Click
        With VerificacionCostoDePT
            .Show()
        End With
    End Sub

    Private Sub ListadoDeCashFlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeCashFlowToolStripMenuItem.Click
        With ListadoCashFlow
            .Show()
        End With
    End Sub

    Private Sub ListadoDeVentasPorProvinciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeVentasPorProvinciaToolStripMenuItem.Click
        With Listado_VentasXProvincia
            .Show()
        End With
    End Sub

    Private Sub AutorizacionDePedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizacionDePedidosToolStripMenuItem.Click
        With AutorizacionDePedidos
            .Show()
        End With
    End Sub

    Private Sub IngresoGastosDeImportacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoGastosDeImportacionToolStripMenuItem.Click
        With IngresoGastosImportacion
            .Show()
        End With
    End Sub

    Private Sub IngresoGastosDeImportacionParcialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoGastosDeImportacionParcialToolStripMenuItem.Click
        With IngresoGastosDeImportacionParcial
            .Show()
        End With
    End Sub

    Private Sub IngresoDeSolicitudPedidoDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeSolicitudPedidoDeVentaToolStripMenuItem.Click
        '  With Ingreso_Solicitud_Pedido_Venta
        '  .Show()
        ' End With
    End Sub

    Private Sub CuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentaToolStripMenuItem.Click
        With CuentaCorrientes_DeClientes
            .Show()
        End With
    End Sub

    Private Sub SaldosDeCtaCteDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaldosDeCtaCteDeClientesToolStripMenuItem.Click
        With SaldoDe_CtaCte_deCliente
            .Show()
        End With
    End Sub
End Class
