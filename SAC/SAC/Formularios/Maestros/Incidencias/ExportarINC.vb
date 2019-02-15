Public Class ExportarINC

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Try

            Dim WOwner = TryCast(Owner, IExportarINC)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarExportarINC(ComboBox1.SelectedIndex)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub ExportarSAC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub
End Class