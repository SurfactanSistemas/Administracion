Imports Personal.Clases

Public Class MenuPrincipal

    'Private Sub MuestraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    With IngresoOrdenTrabajo
    '        .Show()
    '        .WindowState = FormWindowState.Normal
    '        .Focus()
    '    End With

    'End Sub



    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Login.Dispose()
        Close()
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Conexion.EmpresaDeTrabajo = "SURFACTAN"

    End Sub

    Private Sub MenuPrincipal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ' Menu 1: Maestros.
        With Me
            '.IngresiDeOrdenesDeTrabajoToolStripMenuItem.Enabled = Conexion.WAtributosOperador(1, 1)
        End With

    End Sub

    Private Sub ConsultaDeInformacionPersonalToolStripMenuItem_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles ConsultaDeInformacionPersonalToolStripMenuItem.Click

        With ConsultaInformacionPersonal
            .Show
        End With

    End Sub
End Class
