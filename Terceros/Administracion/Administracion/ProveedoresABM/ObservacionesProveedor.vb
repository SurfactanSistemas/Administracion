Public Class ObservacionesProveedor

    Private Sub ObservacionesProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = ClasesCompartidas.Globals.NombreEmpresa()
    End Sub

    Private Sub ObservacionesProveedor_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        CustomTextBox1.Focus()
    End Sub
End Class