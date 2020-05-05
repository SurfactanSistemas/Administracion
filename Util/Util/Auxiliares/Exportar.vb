Imports Util.Clases

Public Class Exportar

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Try

            Dim TipoSalida As [Enum] = Enumeraciones.FormatoExportacion.PorPantalla

            Select Case ComboBox1.SelectedIndex
                Case 0
                    TipoSalida = Enumeraciones.FormatoExportacion.Impresion
                Case 1
                    TipoSalida = Enumeraciones.FormatoExportacion.PorPantalla
                Case 2
                    TipoSalida = Enumeraciones.FormatoExportacion.PDF
                Case 3
                    TipoSalida = Enumeraciones.FormatoExportacion.Excel
                Case 4
                    TipoSalida = Enumeraciones.FormatoExportacion.Word
                Case 5
                    TipoSalida = Enumeraciones.FormatoExportacion.PorMailComoAdjunto
            End Select

            Dim WOwner = CType(Owner, IExportar)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarExportar(TipoSalida)
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