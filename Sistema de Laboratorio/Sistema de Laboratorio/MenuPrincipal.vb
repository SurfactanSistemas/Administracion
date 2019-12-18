Imports System.IO.Ports

Public Class MenuPrincipal
    Private Sub Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub ControlesIntermedisToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ControlesIntermedisToolStripMenuItem.Click
        Abrir(New IngresoEnsayosIntermediosPT)
    End Sub

    Private Sub btnCambioEmpresa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCambioEmpresa.Click
        With New Login
            .Show()
            .txtClave.Text = Clave
        End With
        Close()
    End Sub

    Private Sub EspecificacionesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EspecificacionesToolStripMenuItem.Click
        Abrir(New IngresoEspecificacionesPT)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        FarmaIngresoDeEnsayosProductosTerminadosToolStripMenuItem.Visible = Base = "Surfactan_III"
        ProductosTerminadosToolStripMenuItem.Visible = Base <> "Surfactan_III"
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

    Private Sub AutorizaciónDePedidosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AutorizaciónDePedidosToolStripMenuItem.Click
        With New ListadoAutorizacionPedidos
            .Show(Me)
        End With
    End Sub

    Private Sub ListaDeEspecificacionesDePTAFechaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListaDeEspecificacionesDePTAFechaToolStripMenuItem.Click
        With New ListadoEspecifPTFecha
            .Show(Me)
        End With
    End Sub

    Private Sub DatosAImprimirEnCertificadosDeAnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosAImprimirEnCertificadosDeAnálisisToolStripMenuItem.Click
        With New IngresoDatosMostrarEnCertificadosAnalisis
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

    Private Sub EmisiónDeCertificadoDeAnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisiónDeCertificadoDeAnálisisToolStripMenuItem.Click
        With New EmisionCertificadoAnalisis
         .Show(Me)
        End With
    End Sub
    
    Private Sub EmisionDeEtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisionDeEtiquetasToolStripMenuItem.Click
        With New ImpresionEtiquetasMuestras
            .Show(Me)
        End With
    End Sub

    Private Sub LotesVencidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotesVencidosToolStripMenuItem.Click
        With New VerificacionLoteVencidoMP
            .Show(Me)
        End With
    End Sub

    Private Sub VerificacionDeVencimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerificacionDeVencimientosToolStripMenuItem.Click
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
End Class