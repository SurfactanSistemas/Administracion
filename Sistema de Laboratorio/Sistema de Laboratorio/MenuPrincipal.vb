Imports Microsoft.Win32

Public Class MenuPrincipal
    Private Sub Abrir(ByVal frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "EnableBalloonTips", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "EnableBalloonTips", 1, RegistryValueKind.DWord)
        End If
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
End Class