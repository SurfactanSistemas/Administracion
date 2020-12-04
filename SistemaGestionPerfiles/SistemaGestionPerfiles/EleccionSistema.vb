Public Class EleccionSistema

    Sub New(ByVal Perfil As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_Perfil.Text = Perfil

    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If cbx_Sistemas.SelectedItem <> "" And cbx_Planta.SelectedItem <> "" Then
            With New EditarPermisos(txt_Perfil.Text, cbx_Sistemas.SelectedItem, cbx_Planta.SelectedItem)
                .Show()
            End With
            Close()
        End If
        
    End Sub
End Class