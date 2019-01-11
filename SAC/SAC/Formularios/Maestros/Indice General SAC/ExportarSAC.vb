Public Class ExportarSAC

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Try

            Dim WOwner = CType(Owner, IExportarSac)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarExportarSac(CheckBox1.Checked, CheckBox2.Checked, ComboBox1.SelectedIndex, CheckBox3.Checked)
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