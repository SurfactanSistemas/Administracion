Imports Util
Imports Util.Clases.Helper
Public Class FechaReprog

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        If ValidaFecha(txt_Fecha.Text) <> "S" Then
            MsgBox("La fecha ingresada es invalida, verificar")
            txt_Fecha.Focus()
            txt_Fecha.SelectAll()
            Exit Sub
        End If

        Dim WOwner As IPasarFecha = TryCast(Owner, IPasarFecha)

        If WOwner IsNot Nothing Then
            WOwner.pasaFecha(txt_Fecha.Text, txt_Observaciones.Text)
            Close()
        End If

    End Sub

End Class