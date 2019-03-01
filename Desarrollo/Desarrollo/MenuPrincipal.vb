Imports Desarrollo.Clases

Public Class MenuPrincipal

    Private Sub IngresiDeOrdenesDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresiDeOrdenesDeTrabajoToolStripMenuItem.Click

        With IngresoOrdenTrabajo
            .Show()
            .WindowState = FormWindowState.Normal
            .Focus()
        End With

    End Sub

    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        With Login
            .Visible = True
            .Focus()
        End With
    End Sub

    Private Sub AnálisisDeDesarrolloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnálisisDeDesarrolloToolStripMenuItem.Click

        With AnalisisDesarrollo
            .Show()
            .WindowState = FormWindowState.Normal
            .Focus()
        End With

    End Sub

    Private Sub MenuPrincipal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' TODO Crear rutina para habilitar y deshabilitar opciones de menú segun atributos.

        ' Menu 1: Maestros.
        With Me
            .IngresiDeOrdenesDeTrabajoToolStripMenuItem.Enabled = Conexion.WAtributosOperador(1, 1)
            .IngresoDePruebasDeEnsayoToolStripMenuItem.Enabled = Conexion.WAtributosOperador(1, 2)
            ' 3 y 4 quedan por ahora en desuso.
            .AnálisisDeDesarrolloToolStripMenuItem.Enabled = Conexion.WAtributosOperador(1, 5)
        End With

    End Sub

    Private Sub IngresoDePruebasDeEnsayoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDePruebasDeEnsayoToolStripMenuItem.Click

        With New IngresoPruebasEnsayo
            .Show()
            '.WindowState = FormWindowState.Normal
            .Focus()
        End With

    End Sub

    Private Sub MenuPrincipal_FormClosed( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Login.Dispose()
    End Sub
End Class
