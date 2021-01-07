Imports Microsoft.Office.Core

Public Class inicio

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Trim(txt_Mail.Text) <> "" Then
            With New EditorArchivos(txtAccion.Text, txtRuta.Text, txt_ContraUsuario.Text, True, txt_Mail.Text, txt_TituloMail.Text, txt_CuerpoMail.Text)
                .Show()
            End With
        Else
            With New EditorArchivos(txtAccion.Text, txtRuta.Text, txt_ContraUsuario.Text)
                .Show()
            End With
        End If

    End Sub

    Private Sub _ProcesarEjecucionPorComandoSinMail(ByVal Comandos As String())
        If Comandos.Length > 1 Then
            Dim Accion As String = Comandos(1)
            Dim Ruta As String = "" ' Comandos(2)
            Dim ContraOperador As String = "" 'Comandos(3)
            Dim Habilitado As Boolean = False 'Comandos(4)

            If Comandos.Length > 2 Then Ruta = Comandos(2)
            If Comandos.Length > 3 Then ContraOperador = Comandos(3)
            If Comandos.Length > 4 Then Habilitado = Comandos(4)

            With New EditorArchivos(Accion, Ruta, ContraOperador, Habilitado)
                .Show()
            End With
        End If
    End Sub

    Private Sub _ProcesarEjecucionPorComando(ByVal Comandos As String())
        If Comandos.Length > 1 Then
            Dim Accion As String = Comandos(1)
            Dim Ruta As String = "" ' Comandos(2)
            Dim ContraOperador As String = "" 'Comandos(3)
            Dim Habilitado As Boolean = False 'Comandos(4)
            Dim mail As String = "" 'Comandos(5)
            Dim Titulo As String = "" 'Comandos(6)
            Dim CuerpoMail As String = "" 'Comandos(7)

            If Comandos.Length > 2 Then Ruta = Comandos(2)
            If Comandos.Length > 3 Then ContraOperador = Comandos(3)
            If Comandos.Length > 4 Then Habilitado = Comandos(4)
            If Comandos.Length > 5 Then mail = Comandos(5)
            If Comandos.Length > 6 Then Titulo = Comandos(6)
            If Comandos.Length > 7 Then CuerpoMail = Comandos(7)

            'Dim Ruta As String = Comandos(2)
            'Dim ContraOperador As String = Comandos(3)
            'Dim Habilitado As Boolean = Comandos(4)
            'Dim mail As String = Comandos(5)
            'Dim Titulo As String = Comandos(6)
            'Dim CuerpoMail As String = Comandos(7)

            With New EditorArchivos(Accion, Ruta, ContraOperador, Habilitado, mail, Titulo, CuerpoMail)
                .Show()
            End With
        End If
    End Sub

    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CONSULTAMOS LA LONGITUD PARA SABER SI INCLUYE O NO EL MAIL
        If Environment.GetCommandLineArgs().Length > 5 Then
            'MsgBox("mas de 2")
            _ProcesarEjecucionPorComando(Environment.GetCommandLineArgs())

            Me.Close()
        Else
            'MsgBox("menos de 2")
            _ProcesarEjecucionPorComandoSinMail(Environment.GetCommandLineArgs())

            Me.Close()
        End If

    End Sub


End Class