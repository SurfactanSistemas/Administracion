Imports ConsultasVarias

Public Class MenuPrincipal
    Private WProceso As Byte = 0

    Private Sub Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub ControlesIntermedisToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ControlesIntermedisToolStripMenuItem.Click
        Abrir(New IngresoEnsayosIntermediosPT)
    End Sub

    Private Sub btnCambioEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambioEmpresa.Click
        With New Login
            .Show()
            .txtClave.Text = Operador.Clave
        End With
        Close()
    End Sub

    Private Sub EspecificacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EspecificacionesToolStripMenuItem.Click
        Abrir(New IngresoEspecificacionesPT)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FarmaIngresoDeEnsayosProductosTerminadosToolStripMenuItem.Visible = Operador.Base = "Surfactan_III"
        ProductosTerminadosToolStripMenuItem.Visible = Operador.Base <> "Surfactan_III"
    End Sub

    Private Sub ProductosTerminadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosTerminadosToolStripMenuItem.Click
        MsgBox("No desarrollado. Loguearse en Surfactan III", MsgBoxStyle.Information)
        btnCambioEmpresa_Click(Nothing, Nothing)
    End Sub

    Private Sub FinDeSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinDeSistemaToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub EnsayosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnsayosToolStripMenuItem.Click
        With New ListaEnsayos
            .Show(Me)
        End With
    End Sub

    Private Sub ListadoDeEnsayosEnMPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeEnsayosEnMPToolStripMenuItem.Click

        Dim frm = New ProcesarListadoEnsayosEnMateriaPrima()
        frm.Show()

    End Sub
End Class