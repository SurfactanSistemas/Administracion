Imports System.Configuration
Imports Sistema_Solicitud_Fondos
Imports Util

Public Class MenuPrincipal
    ReadOnly forms As New List(Of Form)
    Dim loginOpen As Boolean = False

    Private Sub abrir(ByVal form As Form)
        Try
            _PurgarSaldosCtaCtePrvs()
        Catch ex As Exception
            '""
        End Try
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

    Private Sub btnCambio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCambio.Click
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

    Private Sub IngresosDeCuentasContablesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresosDeCuentasContablesToolStripMenuItem.Click
        abrir(New CuentaContableABM)
    End Sub

    Private Sub IngresoDeBancosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeBancosToolStripMenuItem.Click
        abrir(New BancosABM)
    End Sub

    Private Sub IngresoDeProveedoresToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeProveedoresToolStripMenuItem.Click
        abrir(New ProveedoresABM)
    End Sub

    Private Sub IngresoDeRubrosDeProveedoresToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeRubrosDeProveedoresToolStripMenuItem.Click
        abrir(New RubrosProveedorABM)
    End Sub

    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DepositosToolStripMenuItem.Click
        abrir(New Depositos)
    End Sub

    Private Sub SifereToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SifereToolStripMenuItem.Click
        abrir(New ProcesoSifere)
    End Sub

    Private Sub RetencionEsOpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RetencionEsOpToolStripMenuItem.Click
        abrir(New ProcesoRetencionesPagos)
    End Sub

    Private Sub RetencionesRecibvosaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RetencionesRecibvosaToolStripMenuItem.Click
        abrir(New ProcesoReteRecibos)
    End Sub

    Private Sub FinDelSistemaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FinDelSistemaToolStripMenuItem.Click
        Close()
        End
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem2.Click
        abrir(New ProcesoPercepciones)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        abrir(New CierreMes)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem4.Click
        abrir(New DepuraCtaCte)
    End Sub

    Private Sub ConsultaDeCuentaCorrientePorPantallaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConsultaDeCuentaCorrientePorPantallaToolStripMenuItem.Click
        abrir(New CuentaCorrientePantalla)
    End Sub

    Private Sub SaldoDeCuentaCorrienteDeProveedoresToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaldoDeCuentaCorrienteDeProveedoresToolStripMenuItem.Click
        abrir(New ListadoSaldosCuentaCorrienteProveedores)
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem8.Click
        abrir(New ListadoProyeccionCobros)
    End Sub

    Private Sub IngresoDeNovedadesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeNovedadesToolStripMenuItem.Click
        abrir(New Compras)
    End Sub

    Private Sub MenuPrincipal_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not loginOpen Then
            'End
        End If
    End Sub

    Private Sub CuentaCorrienteDeProveedoresToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentaCorrienteDeProveedoresToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedores)
    End Sub

    Private Sub IngresoDePagosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDePagosToolStripMenuItem.Click
        abrir(New Pagos)
    End Sub

    Private Sub ListadoDeValoresEnCarteraToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeValoresEnCarteraToolStripMenuItem.Click

    End Sub

    Private Sub CargaDeInteresesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CargaDeInteresesToolStripMenuItem.Click
        abrir(New CargaIntereses)
    End Sub

    Private Sub ModificaciuonDeNterfesesYaCargadosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ModificaciuonDeNterfesesYaCargadosToolStripMenuItem.Click
        abrir(New ModificaIntereses)
    End Sub

    Private Sub ListadoDeValoresEnCarteraToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeValoresEnCarteraToolStripMenuItem1.Click
        abrir(New ListadoValoresEnCartera)
    End Sub

    Private Sub ListadoDeValoresEnCarteraPorCuitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeValoresEnCarteraPorCuitToolStripMenuItem.Click
        abrir(New ListadoValoresEnCarteraCuit)
    End Sub

    Private Sub SdfsdToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SdfsdToolStripMenuItem.Click
        abrir(New ListadoAsientoResumen)
    End Sub


    Private Sub SubdiarioDeIvaComprasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubdiarioDeIvaComprasToolStripMenuItem.Click
        abrir(New ListadoIvaCompras)
    End Sub

    Private Sub ListadoDeImputacionesDeCajaYBancoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeImputacionesDeCajaYBancoToolStripMenuItem.Click
        abrir(New ListadoImputacionesContable)
    End Sub

    Private Sub LisyaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LisyaToolStripMenuItem.Click
        abrir(New ListadoDepositos)
    End Sub


    Private Sub ListadoDeRecibosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeRecibosToolStripMenuItem1.Click
        abrir(New ListadoRecibos)
    End Sub

    Private Sub ListadoDeOrdenesDePagoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeOrdenesDePagoToolStripMenuItem1.Click
        abrir(New ListadoPagos)
    End Sub

    Private Sub ListadoDePagosPosdatadosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDePagosPosdatadosToolStripMenuItem.Click
        abrir(New ListadoPagosPosdatados)
    End Sub

    Private Sub MovmietosDeBancosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MovmietosDeBancosToolStripMenuItem.Click
        abrir(New ListadoMovimientosBancos)
    End Sub

    Private Sub ListadoDeChequesEmitidosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeChequesEmitidosToolStripMenuItem.Click
        abrir(New ListadoChequesEmitidos)
    End Sub

    Private Sub ListadoDeCuentaCorrienteDeProveedoresAFechaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeCuentaCorrienteDeProveedoresAFechaToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresFecha)
    End Sub

    Private Sub ListadoDeRetencionesDeIngresosBrutosPcToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeRetencionesDeIngresosBrutosPcToolStripMenuItem.Click
        abrir(New ListadoRetencionIB)
    End Sub

    Private Sub ListadoDeRetencionesDeIngresosBrutosCiudadDeBuenosAiresToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeRetencionesDeIngresosBrutosCiudadDeBuenosAiresToolStripMenuItem1.Click
        abrir(New ListadoRetencionIBCiudad)
    End Sub

    Private Sub ListadoDeCuentasCorrientesDeProveedoresAnaliticosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeCuentasCorrientesDeProveedoresAnaliticosToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresAnalisitico)
    End Sub

    Private Sub ListadoDeProyeccionDeCuentaCorrientesDeProveedoresAnaliticosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeProyeccionDeCuentaCorrientesDeProveedoresAnaliticosToolStripMenuItem.Click
        abrir(New ListadoProyeccionCobrosAnalitico)
    End Sub

    Private Sub ControlDeRecibosProvisoriosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ControlDeRecibosProvisoriosToolStripMenuItem1.Click
        abrir(New ListadoRecibosProvisorios)
    End Sub

    Private Sub ListadoDeDeudaDePymeNacionToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeDeudaDePymeNacionToolStripMenuItem1.Click
        abrir(New ListadoDeudaPyme)
    End Sub

    Private Sub ConsultaDeChequesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConsultaDeChequesToolStripMenuItem.Click
        abrir(New ConsultaCheque)
    End Sub

    Private Sub CuantaCorrienteDeProveedoresSelectivoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuantaCorrienteDeProveedoresSelectivoToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresSelectivoPrueba)
    End Sub

    Private Sub AplicacionDeCorpobantesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AplicacionDeCorpobantesToolStripMenuItem.Click
        abrir(New AplicacionComprobantes)
    End Sub

    Private Sub IngresoDeRecibosProvisoriosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeRecibosProvisoriosToolStripMenuItem1.Click
        abrir(New RecibosProvisorios)
    End Sub

    Private Sub IngresoDeRecibosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeRecibosToolStripMenuItem1.Click
        abrir(New Recibos)
    End Sub

    Private Sub ConsultaDeRemitosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConsultaDeRemitosToolStripMenuItem.Click
        abrir(New ConsultaRemitos)
    End Sub

    Private Sub EnvioEnEMailAProveedoresToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EnvioEnEMailAProveedoresToolStripMenuItem.Click
        abrir(New EnvioEmailProveedores)
    End Sub

    Private Sub IngresoDeProveedorAPagoSemanalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoDeProveedorAPagoSemanalToolStripMenuItem.Click
        abrir(New ListadoCuentaCorrienteProveedoresSelectivoPreparacion)
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem6.Click
        abrir(New ProcesoPercepcionesIvaCompras)
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem7.Click
        abrir(New ProcesoPercepcionesYRetencionesCiudadNuevo)
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem9.Click
        abrir(New ProcesoPercepcionesGananciasAduana)
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem10.Click
        abrir(New ProcesoPercepcionesAduanerasSIAPRE)
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem11.Click
        abrir(New ProcesoRecuperoIva)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem5.Click
        abrir(New ProcesoCiti)
    End Sub

    Private Sub EnvioEnEMailAClientesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EnvioEnEMailAClientesToolStripMenuItem.Click

        If Not _EsPellital() Then Process.Start("\\193.168.0.2\g$\vb\Net\EmailsClientes\Ejecutable\EmailClientes.exe")

    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        _PurgarSaldosCtaCtePrvs()

        Dim WPermitidos() = ConfigurationManager.AppSettings("PERMISOS_OP_VIRTUAL").ToString.Split(",")
        Dim WNombrePC = Proceso.getNombrePC

        Dim PermisoOp = (From N In WPermitidos Where UCase(Trim(N)) = UCase(Trim(WNombrePC))).Any()

        OrdenDePagoVirtualToolStripMenuItem.Visible = PermisoOp

    End Sub

    Private Sub EnvíoDeAvisoDeOPAProveedoresPorEMailToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EnvíoDeAvisoDeOPAProveedoresPorEMailToolStripMenuItem.Click
        abrir(New AvisoOPAProveedores)
    End Sub

    Private Sub EnvíoDeEmailPorAnticipoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EnvíoDeEmailPorAnticipoToolStripMenuItem.Click
        With New GestionAvisosOPDisponiblesProveedores
            .Show(Me)
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ExecuteNonQueries({"UPDATE ConsultaChequesRecibosII SET Orden = '', Deposito = '', EnPagos = '', EnDepositos = '', Indefinido = ''"})

        Dim WDatos As DataTable = GetAll("SELECT Numero2, Importe2, Clave FROM ConsultaChequesRecibosII")

        For Each row As DataRow In WDatos.Rows
            With row

                If Microsoft.VisualBasic.Left(.Item("Numero2").ToString, 4) <> "0000" Then
                    Dim WPago As DataRow = GetSingle("SELECT Orden, Importe2 FROM Pagos WHERE Numero2 = '" & OrDefault(.Item("Numero2"), "").ToString.PadLeft(8, "0") & "'")

                    If WPago IsNot Nothing Then
                        If Val(formatonumerico(.Item("Importe2"))) = Val(formatonumerico(WPago.Item("Importe2"))) Then
                            ExecuteNonQueries({"UPDATE ConsultaChequesRecibosii SET EnPagos = '1', Orden = '" & WPago.Item("Orden") & "' WHERE Clave = '" & .Item("Clave") & "'"})
                            Continue For
                        End If

                        Dim WDeposito As DataRow = GetSingle("SELECT Deposito, Importe2 FROM Depositos WHERE Numero2 = '" & OrDefault(.Item("Numero2"), "").ToString.PadLeft(8, "0") & "'")

                        If WDeposito IsNot Nothing Then
                            If Val(formatonumerico(.Item("Importe2"))) = Val(formatonumerico(WDeposito.Item("Importe2"))) Then
                                ExecuteNonQueries({"UPDATE ConsultaChequesRecibosii SET EnDepositos = '1', Deposito = '" & WDeposito.Item("Deposito") & "' WHERE Clave = '" & .Item("Clave") & "'"})
                                Continue For
                            End If
                        End If
                    End If

                End If

                ExecuteNonQueries({"UPDATE ConsultaChequesRecibosii SET Indefinido = '1' WHERE Clave = '" & .Item("Clave") & "'"})

            End With
        Next

        MsgBox("Listo")

    End Sub

    Private Sub ArqueoDeChequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArqueoDeChequesToolStripMenuItem.Click

    End Sub

    Private Sub PrincipalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrincipalToolStripMenuItem.Click
        With New ArqueoDeCheques
            .Show(Me)
        End With
    End Sub

    Private Sub SecundarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SecundarioToolStripMenuItem.Click
        With New ArqueoDeChequesSecundario
            .Show(Me)
        End With
    End Sub

    Private Sub OrdenDePagoVirtualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDePagoVirtualToolStripMenuItem.Click
        With New PagosVirtual
            .Show(Me)
        End With
    End Sub

    Private Sub InformeRecepcionSinFacturasRegistradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformeRecepcionSinFacturasRegistradasToolStripMenuItem.Click
        With New InformeRep_SinFac_registradas
            .Show(Me)
        End With
    End Sub

    Private Sub SolicitudDeFondosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolicitudDeFondosToolStripMenuItem.Click
        With New Sistema_Solicitud_Fondos.Login("Crear")
            .Show()
        End With
    End Sub

    Private Sub GestionarSolicitudDeFondosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionarSolicitudDeFondosToolStripMenuItem.Click
        With New Sistema_Solicitud_Fondos.Login("Gestion")
            .Show()
        End With

    End Sub
End Class