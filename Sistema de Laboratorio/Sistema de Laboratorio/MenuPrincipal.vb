Public Class MenuPrincipal

    Private Sub btnCambioEmpresa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCambioEmpresa.Click
        With New Login
            .Show()
            .txtClave.Text = Clave
        End With
        Close()
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        AutorizaciónDePedidosToolStripMenuItem.Visible = Base = "Surfactan_III"
    End Sub

    Private Sub FinDeSistemaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FinDeSistemaToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub EnsayosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EnsayosToolStripMenuItem.Click
        With New ListaEnsayos
            .Show(Me)
        End With
    End Sub

    Private Sub ListadoDeEnsayosEnMPToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeEnsayosEnMPToolStripMenuItem.Click
        Dim frm = New ProcesarListadoEnsayosEnMateriaPrima()
        frm.Show(Me)
    End Sub

    Private Sub ListadoDeEspecificacionesDeMPAFechaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeEspecificacionesDeMPAFechaToolStripMenuItem.Click
        Dim frm = New ListadoEspecificacionesMPAFecha
        frm.Show(Me)
    End Sub

    Private Sub EspecificacionesPorVersiónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EspecificacionesPorVersiónToolStripMenuItem.Click
        With New EspecificacionesMPPorVersion
            .Show(Me)
        End With
    End Sub

    Private Sub EmisiónDeEtiquetasSimplesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EmisiónDeEtiquetasSimplesToolStripMenuItem.Click
        With New EmisionEtiquetasSimples
            .Show(Me)
        End With
    End Sub

    Private Sub HToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HToolStripMenuItem.Click
        With New FrasesHP("H")
            .Show(Me)
        End With
    End Sub

    Private Sub PToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PToolStripMenuItem.Click
        With New FrasesHP("P")
            .Show(Me)
        End With
    End Sub

    Private Sub MateriasPrimasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MateriasPrimasToolStripMenuItem1.Click
        With New IngresoDatosAdicMP("MP")
            .Show(Me)
            .pnlConsultarDatos.Visible = False
            .masktxtCodigo.Focus()
            .txtConsultaDatos.Visible = False
        End With
    End Sub

    Private Sub ProductosTerminadosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ProductosTerminadosToolStripMenuItem1.Click
        With New IngresoDatosAdicMP("PT")
            .Show(Me)
            .pnlConsultarDatos.Visible = False
            .masktxtCodigo.Focus()
            .txtConsultaDatos.Visible = False
        End With
    End Sub

    Private Sub ListadoDeEnsayosDePTToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListadoDeEnsayosDePTToolStripMenuItem.Click
        With New ListadoDeEnsayoDePT
            .Show(Me)
        End With
    End Sub

    Private Sub ListaDeEspecificacionesDePTAFechaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListaDeEspecificacionesDePTAFechaToolStripMenuItem.Click
        With New ListadoEspecifPTFecha
            .Show(Me)
        End With
    End Sub

    Private Sub ListaDePTVencidosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListaDePTVencidosToolStripMenuItem.Click
        With New ListadoPTVencidos
            .Show(Me)
        End With
    End Sub

    Private Sub ConsultaDeEspecificacionesPorVersionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConsultaDeEspecificacionesPorVersionToolStripMenuItem.Click
        With New ConsDeEspefXVersion
            .Show(Me)
        End With
    End Sub

    Private Sub EmisionDeEtiquetasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EmisionDeEtiquetasToolStripMenuItem.Click
        With New ImpresionEtiquetasMuestras
            .Show(Me)
        End With
    End Sub

    Private Sub LotesVencidosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LotesVencidosToolStripMenuItem.Click
        With New VerificacionLoteVencidoMP
            .Show(Me)
        End With
    End Sub

    Private Sub VerificacionDeVencimientosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VerificacionDeVencimientosToolStripMenuItem.Click
        With New VerificacionDeVencimientosMP
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoDeEspecificacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeEspecificacionesToolStripMenuItem.Click
        With New IngresoEspecificacionesPT
            .Show(Me)
        End With
    End Sub
    
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        With New IngresoEnsayosIntermediosPT
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        With New IngresoDatosMostrarEnCertificadosAnalisis
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        With New EmisionCertificadoAnalisis
            .Show(Me)
        End With
    End Sub

    Private Sub EspecificacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EspecificacionesToolStripMenuItem1.Click
        With New IngresoEspecificacionesMP
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoDeEnsayosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresoDeEnsayosToolStripMenuItem.Click
        With New IngresoEnsayosLaboratorioMP
            .Show(Me)
        End With
    End Sub
    
    Private Sub MovimientosVariosDeLaboratorioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientosVariosDeLaboratorioToolStripMenuItem.Click
        With New MovimientosVariosDeLaboratorio
            .Show(Me)
        End With
    End Sub

    Private Sub AutorizaciónDePedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizaciónDePedidosToolStripMenuItem.Click
        With New ListadoAutorizacionPedidos
        .Show(Me)
        End With
    End Sub
    
    Private Sub InformeDeRecepcionDeDrogaDeLaboratorioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeDeRecepcionDeDrogaDeLaboratorioToolStripMenuItem.Click
        With New InformeRecepcionDrogaLAB
            .Show(Me)
        End With
    End Sub

    Private Sub IngresoYActualizacionDeHojaDeProduccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoYActualizacionDeHojaDeProduccionToolStripMenuItem.Click
        With New IngresoActualizacionHojaProduccionFarma
            .Show(Me)
        End With
    End Sub
End Class