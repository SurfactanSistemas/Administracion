Public Class ExportarIndice

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Try

            Dim WOwner = CType(Owner, IExportarIndice)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarExportarIndice(CheckBox1.Checked, ComboBox1.SelectedIndex)
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
        CheckBox1.Checked = True
        ComboBox1.SelectedIndex = 0
    End Sub
End Class