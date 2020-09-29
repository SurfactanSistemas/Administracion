Public Class inicio


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With New EditorArchivos(txtAccion.Text, txtRuta.Text)
            .Show()
        End With
    End Sub

    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _ProcesarEjecucionPorComando(Environment.GetCommandLineArgs())

        Me.Close()
    End Sub

    Private Sub _ProcesarEjecucionPorComando(ByVal Comandos As String())
        If Comandos.Length > 1 Then
            Dim Accion As String = Comandos(1)
            Dim Ruta As String = Comandos(2)
            With New EditorArchivos(Accion, Ruta)
                .Show()
            End With
        End If
    End Sub
End Class