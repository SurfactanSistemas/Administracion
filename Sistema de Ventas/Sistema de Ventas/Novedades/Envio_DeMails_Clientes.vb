Imports Util
Imports Util.Clases.Query
Imports Microsoft.Office.Interop



Public Class Envio_DeMails_Clientes

    Private _Asunto As String
    Private _CuerpoEmail As String
    Private _LineasExtras As String
    Private _ArchivoAdjunto As String
    Private _ListaEmails() As String
    Private Const LIMITE_DE_DIRECCIONES_POR_EMAIL = 10


    Private _To As String = "surfactan@surfactan.com.ar" ' Cambiar por la direccion de Surfactan y posibles otras.




    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Try
            _Asunto = Trim(txt_Asunto.Text)

            _CuerpoEmail = Trim(txt_CuerpoEmail.Text)

            _LineasExtras = _ParsearLineasExtras()

            _ListaEmails = _ProcesarProveedoresDestinatarios()

            'WListaEmails = Trim(txtDestinatarios.Text)

            ' _ProcesarEnvioEmails()

            Label8.Visible = False
            With ProgressBar2
                .Value = 0
                .Visible = False
            End With

            MsgBox("Los correos han sido enviados.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    Private Function _ProcesarProveedoresDestinatarios() As String()
        Dim TablaDestinatarios As New DataTable

        With TablaDestinatarios.Columns
            .Add("Cliente")
            .Add("Razon")
            .Add("Email")
        End With

        Dim SQLCnslt As String = "SELECT Provincia, EmailFacturaII, Cliente, Razon " _
                                 & "FROM Cliente"

        Dim tablaCliente As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tablaCliente.Rows.Count > 0 Then

            Dim fila As Integer = 0

            For Each RowCli As DataRow In tablaCliente.Rows
                If Val(RowCli.Item("Provincia")) < 24 Then

                    Dim ZZRazon As String = RowCli.Item("Razon")
                    Dim ZZEmail As String = IIf(IsDBNull(RowCli.Item("EmailFacturaII")), "", RowCli.Item("EmailFacturaII"))
                    ZZEmail = Trim(ZZEmail)

                    If ZZEmail <> "" And Len(ZZEmail) > 8 Then

                        TablaDestinatarios.Rows.Add()

                        TablaDestinatarios.Rows(fila).Item("Cliente") = RowCli.Item("Cliente")
                        TablaDestinatarios.Rows(fila).Item("Razon") = ZZRazon
                        TablaDestinatarios.Rows(fila).Item("Email") = ZZEmail

                        fila += 1
                    End If

                End If
            Next

        End If




        Dim ZDireccion As New List(Of String)
        For Each RowDestinatario As DataRow In TablaDestinatarios.Rows

            ' Dim ZZZZCliente As String = RowDestinatario.Item("Cliente")
            ' Dim ZZRazon As String = RowDestinatario.Item("Razon")
            Dim ZZEmail As String = RowDestinatario.Item("Email")
            ZZEmail = Trim(ZZEmail)

            ZDireccion.Add(ZZEmail)

        Next




        Return ZDireccion.ToArray()
    End Function


    Private Function _ParsearLineasExtras()
        Dim LineasParseadas = ""

        If Trim(txt_LineaExtraI.Text) <> "" Then
            LineasParseadas &= Trim(txt_LineaExtraI.Text) + vbCrLf
        End If
        If Trim(txt_LineaExtraII.Text) <> "" Then
            LineasParseadas &= Trim(txt_LineaExtraII.Text) + vbCrLf
        End If
        If Trim(txt_LineaExtraIII.Text) <> "" Then
            LineasParseadas &= Trim(txt_LineaExtraIII.Text) + vbCrLf
        End If
        If Trim(txt_LineaExtraIV.Text) <> "" Then
            LineasParseadas &= Trim(txt_LineaExtraIV.Text) + vbCrLf
        End If

        Return LineasParseadas
    End Function






    Private Sub _ProcesarEnvioEmails()
        Dim _CantGrupos As Integer = Math.Floor(_ListaEmails.Length / LIMITE_DE_DIRECCIONES_POR_EMAIL)
        Dim _SubGrupoEmails As New List(Of String)
        Dim _IndiceEmailActual = 0

        With ProgressBar2
            .Visible = True
            .Value = 0
            .Maximum = _ListaEmails.Length + 5
        End With

        ' Procesamos los grupos posibles.	
        For i = 1 To _CantGrupos

            For j = 0 To LIMITE_DE_DIRECCIONES_POR_EMAIL - 1

                _SubGrupoEmails.Add(_ListaEmails(_IndiceEmailActual))

                _IndiceEmailActual += 1

                ProgressBar2.Increment(1)

            Next

            _EnviarEmail(_SubGrupoEmails) ' Descomentar para que comience a funcionar, no olvidarse tambien de descomentar el de mas abajo.	


            _SubGrupoEmails.Clear() ' Limpiamos para el siguiente grupo.	

        Next

        _SubGrupoEmails.Clear() ' Limpiamos antes de procesar los remanentes.	

        ' Procesamos los remanentes.	
        For i As Integer = _IndiceEmailActual To _ListaEmails.Length - 1
            _SubGrupoEmails.Add(_ListaEmails(i))

            ProgressBar2.Increment(1)
        Next

        _EnviarEmail(_SubGrupoEmails)

    End Sub



    Private Sub _EnviarEmail(ByVal emails As List(Of String))
        Dim _Outlook As New Outlook.Application

        Try
            Dim _Mail As Outlook.MailItem = _Outlook.CreateItem(Outlook.OlItemType.olMailItem)

            With _Mail

                .To = _To
                .BCC = String.Join(";", emails) 'WListaEmails
                .Subject = _Asunto
                .Body = _CuerpoEmail + vbCrLf + _LineasExtras

                If Trim(_ArchivoAdjunto) <> "" Then
                    .Attachments.Add(_ArchivoAdjunto)
                End If

            End With

            _Mail.Send()
            '_Mail.Display()

            _Mail = Nothing

            Me.Close()

        Catch ex As Exception
            Throw New Exception("Ocurrió un problema al querer enviar el email a los Clientes.")
        Finally
            _Outlook = Nothing
        End Try

    End Sub





    Private Sub btn_AdjunArchivo_Click(sender As Object, e As EventArgs) Handles btn_AdjunArchivo.Click
        _AdjuntarArchivo()
    End Sub

    Private Sub _AdjuntarArchivo()

        OFDAdjuntarArchivo.FileName = ""

        If OFDAdjuntarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            _ArchivoAdjunto = OFDAdjuntarArchivo.FileName

            txt_NombreArchivoAdjunto.Text = _ArchivoAdjunto

        End If

        OFDAdjuntarArchivo.Dispose()

    End Sub


    Private Sub txtNombreArchivoAdjunto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NombreArchivoAdjunto.DoubleClick
        _AdjuntarArchivo()
    End Sub


    Private Sub txtNombreArchivoAdjunto_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txt_NombreArchivoAdjunto.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub _PermitirDrag(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs)
        Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
        _ArchivoAdjunto = archivos(0)
        txt_NombreArchivoAdjunto.Text = _ArchivoAdjunto
    End Sub

    Private Sub txtNombreArchivoAdjunto_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txt_NombreArchivoAdjunto.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub btnAdjuntar_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btn_AdjunArchivo.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub btnAdjuntar_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btn_AdjunArchivo.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub txt_Asunto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Asunto.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                ' If Trim(txtAsunto.Text) = "" Then : Exit Sub : End If

                txt_CuerpoEMail.Focus()

            Case Keys.Escape
                txt_Asunto.Text = ""

        End Select


    End Sub

    Private Sub txt_LineaExtraI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_LineaExtraI.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                'If Trim(txtLineaExtraI.Text) = "" Then : Exit Sub : End If

                txt_LineaExtraII.Focus()

            Case Keys.Escape
                txt_LineaExtraI.Text = ""

        End Select
    End Sub

    Private Sub txt_LineaExtraII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_LineaExtraII.KeyDown


        Select Case e.KeyData
            Case Keys.Enter
                'If Trim(txtLineaExtraII.Text) = "" Then : Exit Sub : End If

                txt_LineaExtraIII.Focus()

            Case Keys.Escape
                txt_LineaExtraII.Text = ""
        End Select
    End Sub

    Private Sub txt_LineaExtraIII_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_LineaExtraIII.KeyDown


        Select Case e.KeyData
            Case Keys.Enter
                '   If Trim(txtLineaExtraIII.Text) = "" Then : Exit Sub : End If
                txt_LineaExtraIV.Focus()

            Case Keys.Escape
                txt_LineaExtraIII.Text = ""
        End Select

    End Sub

    Private Sub txtLineaExtraIV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_LineaExtraIV.KeyDown


        Select Case e.KeyData
            Case Keys.Escape
                txt_LineaExtraIV.Text = ""

        End Select
    End Sub


End Class