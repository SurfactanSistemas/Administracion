Public Class inicio

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Trim(txt_Mail.Text) <> "" Then
            With New EditorArchivos(txtAccion.Text, txtRuta.Text, True, txt_Mail.Text, txt_TituloMail.Text, txt_CuerpoMail.Text)
                .Show()
            End With
        Else
            With New EditorArchivos(txtAccion.Text, txtRuta.Text)
                .Show()
            End With
        End If

    End Sub

    Private Sub _ProcesarEjecucionPorComandoSinMail(ByVal Comandos As String())
        If Comandos.Length > 1 Then
            Dim Accion As String = Comandos(1)
            Dim Ruta As String = Comandos(2)

            With New EditorArchivos(Accion, Ruta)
                .Show()
            End With
        End If
    End Sub
  
    Private Sub _ProcesarEjecucionPorComando(ByVal Comandos As String())
        If Comandos.Length > 1 Then
            Dim Accion As String = Comandos(1)
            Dim Ruta As String = Comandos(2)
            Dim Habilitado As Boolean = Comandos(3)
            Dim mail As String = Comandos(4)
            Dim Titulo As String = Comandos(5)
            Dim CuerpoMail As String = Comandos(6)

            With New EditorArchivos(Accion, Ruta, habilitado, mail, Titulo, CuerpoMail)
                .Show()
            End With
        End If
    End Sub

    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If Environment.GetCommandLineArgs().Length > 3 Then
            'MsgBox("mas de 2")
            _ProcesarEjecucionPorComando(Environment.GetCommandLineArgs())

            Me.Close()
        Else
            ' MsgBox("menos de 2")
            _ProcesarEjecucionPorComandoSinMail(Environment.GetCommandLineArgs())

            Me.Close()
        End If
    End Sub
End Class