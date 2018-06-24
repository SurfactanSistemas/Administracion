Imports ClasesCompartidas

Public Class DepuraCtaCte

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Hide()
        MenuPrincipal.Show()
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click
        SQLConnector.executeProcedure("depurar_cuentas_corrientes")
        MsgBox("Proceso Depuracion de Cuentas Corrientes", MsgBoxStyle.Information)
    End Sub

    Private Sub DepuraCtaCte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = Proceso.NombreEmpresa()
    End Sub
End Class