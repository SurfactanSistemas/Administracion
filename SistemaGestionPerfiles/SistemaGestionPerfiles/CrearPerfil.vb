Imports Util.Clases.Query

Public Class CrearPerfil

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Recuerde que una vez creado un perfil no podra eliminarlo" & vbCrLf &
               "¿Desea confirmar este perfil?", vbYesNo) = vbYes Then

            Dim SQlCnslt As String = "INSERT INTO Perfiles(Perfil) values('" & txt_Nombre.Text & "')"

            ExecuteNonQueries("SurfactanSa", SQlCnslt)

            Dim WOwner As ICrearPerfil = TryCast(Owner, ICrearPerfil)
            If WOwner IsNot Nothing Then
                WOwner.Actualiza()
            End If
            Close()

        End If
    End Sub
End Class