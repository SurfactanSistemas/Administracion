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

    Private Sub PreciosPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreciosPorClienteToolStripMenuItem.Click
        With New PreciosPorCliente
            .Show(Me)
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

    Private Sub AgendaDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaDeClientesToolStripMenuItem.Click
        With New ListadoAgendaClientes
            .Show(Me)
        End With
    End Sub

    Private Sub SubdiarioDeIvaVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubdiarioDeIvaVentasToolStripMenuItem.Click
        With Listado_IvaVentas
            .Show()
        End With
    End Sub

    Private Sub ListadoDeMercaderiaEnRemitosAFacturasPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeMercaderiaEnRemitosAFacturasPorClienteToolStripMenuItem.Click
        With Listado_Mercaderia_Remitos_FactuCliente
            .Show()
        End With
    End Sub

    Private Sub ListadoDeMercaderiaEnRemitosAFacturasPorClienteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ListadoDeMercaderiaEnRemitosAFacturasPorClienteToolStripMenuItem1.Click
        With Listado_Mercaderia_Remitos_FactuArticulo
            .Show()
        End With
    End Sub

    Private Sub ListadoDeVentasFueraDeFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeVentasFueraDeFechaToolStripMenuItem.Click
        With Listado_Ventas_FueraDeFecha
            .Show()
        End With
    End Sub

    Private Sub ListadoDePreciosGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePreciosGrupoToolStripMenuItem.Click
        With Listado_Precios_Grupo
            .Show()
        End With
    End Sub

    Private Sub ListadoDePreciosComparativoGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePreciosComparativoGrupoToolStripMenuItem.Click
        With Listado_Precios_Compara_Grupos
            .Show()
        End With
    End Sub

    Private Sub ListadoDePreciosComparativosClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePreciosComparativosClienteToolStripMenuItem.Click
        With Listado_Precios_Compara_Cliente
            .Show()
        End With
    End Sub

    Private Sub ListadoGralDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoGralDePreciosToolStripMenuItem.Click
        With Listado_GralProductos
            .Show()
        End With
    End Sub

    Private Sub ListadoCalcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoCalcToolStripMenuItem.Click
        With Listado_CalculoCosto_NacionalizacionMercaderia
            .Show()
        End With
    End Sub

    Private Sub ListadoDeAnalisisDeDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeAnalisisDeDevolucionesToolStripMenuItem.Click
        With Listado_Analisis_Devolucionesvb
            .Show()
        End With
    End Sub

    Private Sub ListadoDePedidosPendientesDeFazonPellitalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePedidosPendientesDeFazonPellitalToolStripMenuItem.Click
        With Listado_Pedi_Pendi_Fazon_Pellital
            .Show()
        End With
    End Sub

    Private Sub ListadoDeClientesPorVendedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeClientesPorVendedorToolStripMenuItem.Click
        With Listado_Clientes_XVendedor
            .Show()
        End With
    End Sub

    Private Sub ListadoDeMinutasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeMinutasToolStripMenuItem.Click
        With Listado_Minutas
            .Show()
        End With
    End Sub

    Private Sub ListadoDeVerificacionDePTSinVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeVerificacionDePTSinVentasToolStripMenuItem.Click
        With Listado_PT_SinVentas
            .Show()
        End With
    End Sub

    Private Sub ListadoDeVerificacionDeDYSinVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeVerificacionDeDYSinVentasToolStripMenuItem.Click
        With Listado_DY_SinVentas
            .Show()
        End With
    End Sub

    Private Sub ListadoDeRemitosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeRemitosToolStripMenuItem.Click
        With Listado_Remitos
            .Show()
        End With
    End Sub
End Class
