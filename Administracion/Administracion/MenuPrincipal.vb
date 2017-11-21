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

    Private Sub IngresosDeCuentasContablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosDeCuentasContablesToolStripMenuItem.Click
        abrir(New CuentaContableABM)
    End Sub

    Private Sub IngresoDeBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeBancosToolStripMenuItem.Click
        abrir(New BancosABM)
    End Sub

    Private Sub IngresoDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeProveedoresToolStripMenuItem.Click
        abrir(New ProveedoresABM)
    End Sub

    Private Sub IngresoDeRubrosDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeRubrosDeProveedoresToolStripMenuItem.Click
        abrir(New RubrosProveedorABM)
    End Sub

    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepositosToolStripMenuItem.Click
        abrir(New Depositos)
    End Sub

    Private Sub SifereToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SifereToolStripMenuItem.Click
        abrir(New ProcesoSifere)
    End Sub

    Private Sub RetencionEsOpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionEsOpToolStripMenuItem.Click
        abrir(New ProcesoRetencionesPagos)
    End Sub

    Private Sub RetencionesRecibvosaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesRecibvosaToolStripMenuItem.Click
        abrir(New ProcesoReteRecibos)
    End Sub

    Private Sub FinDelSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinDelSistemaToolStripMenuItem.Click
        Close()
        End
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        abrir(New ProcesoPercepciones)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        abrir(New CierreMes)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        abrir(New DepuraCtaCte)
    End Sub

    Private Sub ConsultaDeCuentaCorrientePorPantallaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDeCuentaCorrientePorPantallaToolStripMenuItem.Click
        abrir(New CuentaCorrientePantalla)
    End Sub

    Private Sub SaldoDeCuentaCorrienteDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldoDeCuentaCorrienteDeProveedoresToolStripMenuItem.Click
        abrir(New ListadoSaldosCuentaCorrienteProveedores)
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoAsientoResumen)
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        abrir(New ListadoProyeccionCobros)
    End Sub

    Private Sub IngresoDeNovedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeNovedadesToolStripMenuItem.Click
        abrir(New Compras)
    End Sub

    Private Sub MenuPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not loginOpen Then
            'End
        End If
    End Sub

    Private Sub CuentaCorrienteDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaCorrienteDeProveedoresToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedores)
    End Sub

    Private Sub IngresoDePagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDePagosToolStripMenuItem.Click
        abrir(New Pagos)
    End Sub

    Private Sub ListadoDeValoresEnCarteraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeValoresEnCarteraToolStripMenuItem.Click

    End Sub

    Private Sub CargaDeInteresesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargaDeInteresesToolStripMenuItem.Click
        abrir(New CargaIntereses)
    End Sub

    Private Sub ModificaciuonDeNterfesesYaCargadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaciuonDeNterfesesYaCargadosToolStripMenuItem.Click
        abrir(New ModificaIntereses)
    End Sub

    Private Sub ListadoDeValoresEnCarteraToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeValoresEnCarteraToolStripMenuItem1.Click
        abrir(New ListadoValoresEnCartera)
    End Sub

    Private Sub ListadoDeValoresEnCarteraPorCuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeValoresEnCarteraPorCuitToolStripMenuItem.Click
        abrir(New ListadoValoresEnCarteraCuit)
    End Sub

    Private Sub SdfsdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SdfsdToolStripMenuItem.Click
        abrir(New ListadoAsientoResumen)
    End Sub

   
    Private Sub SubdiarioDeIvaComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubdiarioDeIvaComprasToolStripMenuItem.Click
        abrir(New ListadoIvaCompras)
    End Sub

    Private Sub ListadoDeImputacionesDeCajaYBancoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeImputacionesDeCajaYBancoToolStripMenuItem.Click
        abrir(New ListadoImputacionesContable)
    End Sub

    Private Sub LisyaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LisyaToolStripMenuItem.Click
        abrir(New ListadoDepositos)
    End Sub

    
    Private Sub ListadoDeRecibosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeRecibosToolStripMenuItem1.Click
        abrir(New ListadoRecibos)
    End Sub

    Private Sub ListadoDeOrdenesDePagoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeOrdenesDePagoToolStripMenuItem1.Click
        abrir(New ListadoPagos)
    End Sub

    Private Sub ListadoDePagosPosdatadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDePagosPosdatadosToolStripMenuItem.Click
        abrir(New ListadoPagosPosdatados)
    End Sub

    Private Sub MovmietosDeBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovmietosDeBancosToolStripMenuItem.Click
        abrir(New ListadoMovimientosBancos)
    End Sub

    Private Sub ListadoDeChequesEmitidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeChequesEmitidosToolStripMenuItem.Click
        abrir(New ListadoChequesEmitidos)
    End Sub

    Private Sub ListadoDeCuentaCorrienteDeProveedoresAFechaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCuentaCorrienteDeProveedoresAFechaToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresFecha)
    End Sub

    Private Sub ListadoDeDiferenciaDeCambioCobranzaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoDiferenciaCambioCobranza)
    End Sub

    Private Sub ListadoDeDiferenciaDeCambioAcreditacionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoDiferenciaCambioAcreditacion)
    End Sub

    Private Sub ListadoDeDiferencaiDeCambioDeFacturasDeExportacionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoDiferenciaCambioExterior)
    End Sub

    Private Sub ListadoDeRetencionesDeIngresosBrutosPcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeRetencionesDeIngresosBrutosPcToolStripMenuItem.Click
        abrir(New ListadoRetencionIB)
    End Sub

    Private Sub ListadoDeRetencionesDeIngresosBrutosCiudadDeBuenosAiresToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeRetencionesDeIngresosBrutosCiudadDeBuenosAiresToolStripMenuItem1.Click
        abrir(New ListadoRetencionIBCiudad)
    End Sub

    Private Sub ListadoDeCuentasCorrientesDeProveedoresAnaliticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCuentasCorrientesDeProveedoresAnaliticosToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresAnalisitico)
    End Sub

    Private Sub ListadoDeProyeccionDeCuentaCorrientesDeProveedoresAnaliticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeProyeccionDeCuentaCorrientesDeProveedoresAnaliticosToolStripMenuItem.Click
        abrir(New ListadoProyeccionCobrosAnalitico)
    End Sub

    Private Sub ListadoDeAgendaDeVencimientosDeLertasYDespachosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoAgenda)
    End Sub

    Private Sub ControlDeRecibosProvisoriosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeRecibosProvisoriosToolStripMenuItem1.Click
        abrir(New ListadoRecibosProvisorios)
    End Sub

    Private Sub ListadoDeDeudaDePymeNacionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeDeudaDePymeNacionToolStripMenuItem1.Click
        abrir(New ListadoDeudaPyme)
    End Sub

    Private Sub ListadoDeProyeccionDePagosDeImportacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        abrir(New ListadoPagosImportaciones)
    End Sub

    Private Sub ConsultaDeChequesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDeChequesToolStripMenuItem.Click
        abrir(New ConsultaCheque)
    End Sub

    Private Sub CuantaCorrienteDeProveedoresSelectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuantaCorrienteDeProveedoresSelectivoToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresSelectivo)
    End Sub

    Private Sub AplicacionDeCorpobantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AplicacionDeCorpobantesToolStripMenuItem.Click
        abrir(New AplicacionComprobantes)
    End Sub

    Private Sub IngresoDeRecibosProvisoriosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeRecibosProvisoriosToolStripMenuItem1.Click
        abrir(New RecibosProvisorios)
    End Sub

    Private Sub IngresoDeRecibosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeRecibosToolStripMenuItem1.Click
        abrir(New Recibos)
    End Sub

    Private Sub ConsultaDeRemitosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDeRemitosToolStripMenuItem.Click
        abrir(New ConsultaRemitos)
    End Sub

    Private Sub EnvioEnEMailAProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvioEnEMailAProveedoresToolStripMenuItem.Click
        abrir(New EnvioEmailProveedores)
    End Sub

    Private Sub IngresoDeProveedorAPagoSemanalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeProveedorAPagoSemanalToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresSelectivoPreparacion)
    End Sub

End Class