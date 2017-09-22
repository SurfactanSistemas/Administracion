Public Class MenuPrincipal

    Private Sub btnNuevaProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaProforma.Click
        With Proforma
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnHistorialProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorialProforma.Click
        MsgBox("En Desarrollo. Sin Implementacion todavia.")
        Exit Sub
        With HistorialProforma
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class
