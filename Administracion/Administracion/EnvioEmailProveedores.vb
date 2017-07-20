Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class EnvioEmailProveedores

    Private _Asunto As String
    Private _CuerpoEmail As String
    Private _LineasExtras As String
    Private _ArchivoAdjunto As String
    Private _ListaEmails() As String
    Private Const LIMITE_DE_DIRECCIONES_POR_EMAIL = 10
    Private _To As String = "gferreyra@surfactan.com.ar" ' Cambiar por la direccion de Surfactan y posibles otras.
    Private _Bcc As String = "gferreyra@surfactan.com.ar" ' Solo a manera de prueba para el envio de email. BORRAR DESPUES.

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        If Trim(txtAsunto.Text) <> "" And Trim(txtCuerpoEmail.Text) <> "" Then

            _Asunto = Trim(txtAsunto.Text)

            _CuerpoEmail = Trim(txtCuerpoEmail.Text)

            _LineasExtras = _ParsearLineasExtras()

            _ListaEmails = _TraerProveedoresDestinatarios()

            _ProcesarEnvioEmails()

        End If

    End Sub

    Private Sub _ProcesarEnvioEmails()
        Dim _CantGrupos As Integer = Math.Floor(_ListaEmails.Length / LIMITE_DE_DIRECCIONES_POR_EMAIL)
        Dim _SubGrupoEmails As New List(Of String)
        Dim _IndiceEmailActual As Integer = 0

        ' Procesamos los grupos posibles.
        For i As Integer = 1 To _CantGrupos

            For j As Integer = 0 To LIMITE_DE_DIRECCIONES_POR_EMAIL - 1

                _SubGrupoEmails.Add(_ListaEmails(_IndiceEmailActual))

                _IndiceEmailActual += 1

            Next

            Try
                '_EnviarEmail(_SubGrupoEmails) ' Descomentar para que comience a funcionar, no olvidarse tambien de descomentar el de mas abajo.
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            _SubGrupoEmails.Clear() ' Limpiamos para el siguiente grupo.

        Next

        _SubGrupoEmails.Clear() ' Limpiamos antes de procesar los remanentes.

        ' Procesamos los remanentes.
        For i As Integer = _IndiceEmailActual To _ListaEmails.Length - 1
            _SubGrupoEmails.Add(_ListaEmails(i))
        Next

        Try
            '_EnviarEmail(_SubGrupoEmails) ' Descomentar para que comience a funcionar.
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _EnviarEmail(ByVal emails As List(Of String))
        Dim _Outlook As New Outlook.Application

        Try
            Dim _Mail As Outlook.MailItem = _Outlook.CreateItem(Outlook.OlItemType.olMailItem)

            With _Mail

                .To = _To
                .BCC = String.Join(";", emails)
                .Subject = _Asunto
                .Body = _CuerpoEmail + vbCrLf + _LineasExtras

                If Trim(_ArchivoAdjunto) <> "" Then
                    .Attachments.Add(_ArchivoAdjunto)
                End If

            End With



            '_Mail.Send()

            '_Mail = Nothing

            'Me.Close()

        Catch ex As Exception
            Throw New Exception("Ocurrió un problema al querer enviar el email a los proveedores.")
        Finally
            _Outlook = Nothing
        End Try

    End Sub

    Private Function _ParsearLineasExtras()
        Dim LineasParseadas As String = ""

        If Trim(txtLineaExtraI.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraI.Text) + vbCrLf
        End If
        If Trim(txtLineaExtraII.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraII.Text) + vbCrLf
        End If
        If Trim(txtLineaExtraIII.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraIII.Text) + vbCrLf
        End If
        If Trim(txtLineaExtraIV.Text) <> "" Then
            LineasParseadas &= Trim(txtLineaExtraIV.Text) + vbCrLf
        End If

        Return LineasParseadas
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntar.Click
        _AdjuntarArchivo()
    End Sub

    Private Sub EnvioEmailProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAsunto.Text = ""
        txtCuerpoEmail.Text = ""
        txtLineaExtraI.Text = ""
        txtLineaExtraII.Text = ""
        txtLineaExtraIII.Text = ""
        txtLineaExtraIV.Text = ""
        txtNombreArchivoAdjunto.Text = ""
    End Sub

    Private Function _TraerProveedoresDestinatarios() As String()
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim _LimiteDireccionesPorEmail As Integer = 10
        Dim _FechaUltimo As String
        Dim _Inhabilitado As String = ""
        Dim _EmailProveedores As New List(Of String)

        'Calculo un año hacia atrás a partir del dia de hoy.
        _FechaUltimo = _ObtenerFechaLimite()

        Try
            cn.ConnectionString = "Data Source=193.168.0.7;Initial Catalog=SurfactanSA;User ID=usuarioadmin; Password=usuarioadmin"

            cm.CommandText = "SELECT DISTINCT IvaComp.Proveedor, Proveedor.Email, Proveedor.Inhabilitado FROM IvaComp, Proveedor WHERE IvaComp.Proveedor = Proveedor.Proveedor AND IvaComp.Ordfecha >= '" + _FechaUltimo + "' AND Proveedor.Email <> ''"
            cm.Connection = cn

            cn.Open()

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    _Inhabilitado = IIf(IsDBNull(dr.Item("Inhabilitado")), "0", dr.Item("Inhabilitado"))

                    If _Inhabilitado <> "1" Then
                        _EmailProveedores.Add(Trim(dr.Item("Email")).ToString())
                    End If

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar las direcciones de E-Mail de los Proveedores.", MsgBoxStyle.Critical)
        Finally
            cn.Close()
            cm = Nothing
            dr = Nothing
        End Try

        ' Debido a que se ingresan email por proveedor al estilo email@empresa.com; email2@empresa.com,
        ' primero unimos los registros para luego separarlos nuevamente.
        Return String.Join(";", _EmailProveedores).Replace(" ", "").Split(";")

    End Function

    Private Function _ObtenerFechaLimite()
        Dim fecha As String = ""

        fecha += (Today.Year - 1).ToString()

        If Today.Month > 9 Then
            fecha += Today.Month.ToString()
        Else
            fecha += "0" + Today.Month.ToString()
        End If

        Return fecha + "01"
    End Function

    Private Sub _AdjuntarArchivo()

        OFDAdjuntarArchivo.FileName = ""

        If OFDAdjuntarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            _ArchivoAdjunto = OFDAdjuntarArchivo.FileName

            txtNombreArchivoAdjunto.Text = _ArchivoAdjunto

        End If

        OFDAdjuntarArchivo.Dispose()

    End Sub

    Private Sub txtNombreArchivoAdjunto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreArchivoAdjunto.DoubleClick
        _AdjuntarArchivo()
    End Sub


    Private Sub txtNombreArchivoAdjunto_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtNombreArchivoAdjunto.DragEnter
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
        txtNombreArchivoAdjunto.Text = _ArchivoAdjunto
    End Sub

    Private Sub txtNombreArchivoAdjunto_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtNombreArchivoAdjunto.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub btnAdjuntar_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAdjuntar.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub btnAdjuntar_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAdjuntar.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub
End Class