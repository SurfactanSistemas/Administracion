Imports System.IO
Imports GestorDeArchivos
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Mail_Reclamo

    Dim CarpetaAux As String = "C:\" & "Auxiliar_SolicitudFondos_MailsReclamo"
    Dim RutaGuardar As String = "\\193.168.0.2\g$\vb\NET\ArchivosRelacionadosSolicitudFondos"

    Sub New(ByVal NroSoli As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_NroSolicitud.Text = NroSoli
        txt_Asunto.Focus()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        Dim EsGestor As Boolean = False
        Dim WNumeroMail As String = 0
        Dim WFecha, WFechaOrd, WAsunto, WCuerpo, WEnvio As String
        Dim SQLCnslt As String

        WFecha = Date.Today.ToString("dd/MM/yyyy")
        WFechaOrd = ordenaFecha(WFecha)

        WAsunto = Trim(txt_Asunto.Text)
        WCuerpo = Trim(txt_Cuerpo.Text)

        'OBTENGO QUIEN ENVIA EL MAIL Y SI ES UN GESTOR
        Try
            SQLCnslt = "SELECT Descripcion, SolicitudFondosEdicion  FROM Operador WHERE Clave = '" & Operador.Clave & "'"
            Dim rowope As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowope IsNot Nothing Then
                WEnvio = Trim(rowope.Item("Descripcion"))
                Dim WSolifondosEdit As String = IIf(IsDBNull(rowope.Item("SolicitudFondosEdicion")), "", rowope.Item("SolicitudFondosEdicion"))
                If WSolifondosEdit = "S" Then
                    EsGestor = True
                End If
            End If
        Catch ex As Exception
        End Try

        'LUEGO OBTENGO SIGUIENTE EL NUMERO DE MAIL
        Try
            SQLCnslt = "SELECT MAXNUMERO = max(NumeroMail) FROM SolicitudFondos_HistorialMails WHERE NroSolicitud = '" & txt_NroSolicitud.Text & "'"
            Dim rowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowSoli IsNot Nothing Then
                WNumeroMail = IIf(IsDBNull(rowSoli.Item("MAXNUMERO")), 0, rowSoli.Item("MAXNUMERO"))
                WNumeroMail = WNumeroMail + 1
                'Else
                '    WNumeroMail = 1
            End If
        Catch ex As Exception
        End Try

        Try

            SQLCnslt = "INSERT INTO SolicitudFondos_HistorialMails (NroSolicitud , Envio, Fecha, OrdFecha, NumeroMail, Asunto, Cuerpo)" _
                        & "VALUES('" & txt_NroSolicitud.Text & "', '" & WEnvio & "', '" & WFecha & "', '" & WFechaOrd & "', '" & WNumeroMail & "', '" & WAsunto & "', '" & WCuerpo & "')"


            Try
                ' Dim DestinoMail As String = "andy_fdra@hotmail.com;andy.fdra@gmail.com"
                Dim DestinoMail As String = "sergiol@surfactan.com.ar;aam@surfactan.com.ar;lam@surfactan.com.ar"

                If EsGestor = True Then
                    DestinoMail = ObtenerDestinatarioMail(Val(txt_NroSolicitud.Text))
                    If DestinoMail = "" Then
                        MsgBox("El solicitante no tiene un mail cargado", vbExclamation)
                        Exit Sub
                    End If
                End If

                _EnviarEmail(DestinoMail, WAsunto, WCuerpo, Directory.GetFiles(CarpetaAux), True)


            Catch ex As Exception
                MsgBox("No se puedo enviar el mail de aviso. Este operador no debe tener un mail cargado o esta mal escrito", vbExclamation)
            End Try

            ExecuteNonQueries("SurfactanSa", SQLCnslt)

            If DirecctorioVacio(CarpetaAux) Then
                _SubirArchvios(txt_NroSolicitud.Text)
            End If


            MsgBox("Se envio mail correctamente")

            LimpiarPantalla()

            limpiarCarpetaDatosAux()

            Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarPantalla()
        txt_Asunto.Text = ""
        txt_Cuerpo.Text = ""
        txt_Asunto.Focus()
    End Sub


    Private Sub limpiarCarpetaDatosAux()
        If Not Directory.Exists(CarpetaAux) Then Directory.CreateDirectory(CarpetaAux)

        If Directory.Exists(CarpetaAux) Then Directory.Delete(CarpetaAux, True)

        Directory.CreateDirectory(CarpetaAux)
       
    End Sub

    Public Function DirecctorioVacio(ByVal Ruta As String) As Boolean
        Return Directory.EnumerateFileSystemEntries(Ruta).Any()
    End Function

    Private Sub _SubirArchvios(ByVal NroInterno As String)

        Dim WDestino = RutaGuardar & "\" & NroInterno
        Dim WCantCorrectas = 0

        'If RutaArchivo.Length = 0 Then : Return : End If

        Try
            'Verificamos sino existe la carpeta, sino existe la creamos
            If (Not Directory.Exists(WDestino)) Then
                Directory.CreateDirectory(WDestino)
            End If
        Catch ex As Exception

        End Try

        For Each archivo As String In Directory.GetFiles(CarpetaAux)
            Try
                Dim NombreArchivo As String = archivo.Remove(0, (CarpetaAux & "\").Length)
                If Not File.Exists(WDestino & "\" & NombreArchivo) Then
                    'Si no existe lo copio
                    File.Move(archivo, WDestino & "\" & NombreArchivo)
                    WCantCorrectas += 1
                    File.Delete(archivo)
                Else
                    'sino llegan a haber borrado los archivos y le adjuntan uno
                    ' que ya existe con el mismo nombre consutamos si sobre escribir
                    If MsgBox("El Archivo """ & Path.GetFileName(archivo) & """, ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        File.Delete(WDestino & "\" & NombreArchivo)
                        File.Move(archivo, WDestino & "\" & NombreArchivo)
                        WCantCorrectas += 1

                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return
            End Try
        Next



    End Sub

    Private Function ObtenerDestinatarioMail(ByVal NroSolicitud As Integer) As String
        Dim SQLCnslt As String = "SELECT Solicitante FROM SolicitudFondos WHERE NroSolicitud = '" & NroSolicitud & "'"
        Dim rowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        'OBTENGO QUIEN HIZO LA SOLICITUD
        If rowSoli IsNot Nothing Then

            SQLCnslt = "SELECT Email FROM Operador WHERE Descripcion = '" & rowSoli.Item("Solicitante") & "'"
            Dim rowope As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            'OBTENGO EL MAIL DE QUIEN HIZO LA SOLICITUD PARA SABER A QUIEN RESPONDER
            If rowope IsNot Nothing Then
                Dim mailDestino As String = Trim(IIf(IsDBNull(rowope.Item("Email")), "", rowope.Item("Email")))
                Return mailDestino
            End If

        End If
        Return ""
    End Function

    
    Private Sub btn_HistorialMail_Click(sender As Object, e As EventArgs) Handles btn_HistorialMail.Click
        With New Mail_Reclamo_Historial(txt_NroSolicitud.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub btn_AdjuntarArchivos_Click(sender As Object, e As EventArgs) Handles btn_AdjuntarArchivos.Click

        If Not Directory.Exists(CarpetaAux) Then
            Directory.CreateDirectory(CarpetaAux)
        End If
        With New EditorArchivos(2, CarpetaAux, Operador.Clave)
            .Show()
        End With

    End Sub
End Class