Imports System.IO
Imports GestorDeArchivos
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Mail_Modificacion

    Dim CarpetaAux As String = "C:\" & "Auxiliar_InsumosIntermedios_MailsReclamo"
    Dim RutaGuardar As String = "\\193.168.0.2\g$\vb\NET\ArchivosRelacionadosInsumosIntermedios"

    Sub New(ByVal NroSoli As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_NroSolicitud.Text = NroSoli
        txt_Asunto.Text = "Se a modificado la solicitud de insumos Nº: " & txt_NroSolicitud.Text
        txt_Asunto.ReadOnly = True

        If Not Directory.Exists(CarpetaAux) Then
            Directory.CreateDirectory(CarpetaAux)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click

        Dim WNumeroMail As String = 0
        Dim WFecha, WFechaOrd, WAsunto, WCuerpo, WEnvio As String
        Dim SQLCnslt As String

        WFecha = ""
        WFechaOrd = ""
        WAsunto = ""
        WCuerpo = ""
        WEnvio = ""

        WFecha = Date.Today.ToString("dd/MM/yyyy")
        WFechaOrd = ordenaFecha(WFecha)

        WAsunto = Trim(txt_Asunto.Text)
        WCuerpo = Trim(txt_Cuerpo.Text)

        Try

            Dim DestinoMail As String

            DestinoMail = ObtenerDestinatarioMail(Val(txt_NroSolicitud.Text))
            If DestinoMail = "" Then
                MsgBox("El solicitante no tiene un mail cargado", vbExclamation)
                Exit Sub
            End If


            _EnviarEmail(DestinoMail, WAsunto, WCuerpo, Directory.GetFiles(CarpetaAux), True)


        Catch ex As Exception
            MsgBox("No se puedo enviar el mail de aviso. Este operador no debe tener un mail cargado o esta mal escrito", vbExclamation)
        End Try



        If DirecctorioVacio(CarpetaAux) Then
            _SubirArchvios(txt_NroSolicitud.Text)
        End If


        MsgBox("Se envio mail correctamente")

        LimpiarPantalla()

        limpiarCarpetaDatosAux()

        Close()

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
        Dim SQLCnslt As String = "SELECT Operador FROM Insumos_Provisorios WHERE Solicitud = '" & NroSolicitud & "'"
        Dim rowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        'OBTENGO QUIEN HIZO LA SOLICITUD
        If rowSoli IsNot Nothing Then

            SQLCnslt = "SELECT Email FROM Operador WHERE Operador = '" & rowSoli.Item("Operador") & "'"
            Dim rowope As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            'OBTENGO EL MAIL DE QUIEN HIZO LA SOLICITUD PARA SABER A QUIEN RESPONDER
            If rowope IsNot Nothing Then
                Dim mailDestino As String = Trim(IIf(IsDBNull(rowope.Item("Email")), "", rowope.Item("Email")))
                Return mailDestino
            End If

        End If
        Return ""
    End Function


    Private Sub btn_AdjuntarArchivos_Click(sender As Object, e As EventArgs) Handles btn_AdjuntarArchivos.Click

        If Not Directory.Exists(CarpetaAux) Then
            Directory.CreateDirectory(CarpetaAux)
        End If
        With New EditorArchivos(2, CarpetaAux, Operador.Clave)
            .Show()
        End With

    End Sub
End Class