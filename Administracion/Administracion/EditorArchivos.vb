Imports System.Configuration
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class EditorArchivos
    Private ReadOnly WAccion
    Private ReadOnly WPath
    Private ReadOnly WHabilitado


    Private Const EXTENSIONES_PERMITIDAS = "*.bmp|*.png|*.jpg|*.jpeg|*.pdf|*.doc|*.docx|*.xls|*.xlsx"

    Sub New(ByVal Accion As Integer, ByVal Ruta As String, Optional ByVal Habilitado As Boolean = True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WAccion = Accion

        WPath = Ruta

        WHabilitado = Habilitado
        Button1.Enabled = Habilitado
        Button2.Enabled = Habilitado

    End Sub

    Private Sub AgregarArchivosEvalProvMP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        '
        ' Creamos la carpeta que contendrá los archivos en caso de que no se encuentre creada ya.
        '
        If WAccion = 2 Then
            Directory.CreateDirectory(WPath)

            _CargarArchivosRelacionados()
        Else
            Try
                Process.Start(WPath, "f")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


    End Sub


#Region "Rutina Archivos"


    '
    ' Rutinas de Archivos.
    '
    Private Sub dgvArchivos_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvArchivos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        With dgvArchivos.Rows(e.RowIndex)
            If Not IsNothing(.Cells("PathArchivo").Value) Then

                Try
                    Process.Start(.Cells("PathArchivo").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    Private Sub dgvArchivos_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles dgvArchivos.DragEnter
        If WHabilitado = True Then
            _PermitirDrag(e)
        End If

    End Sub

    Private Sub _PermitirDrag(ByVal e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub _ProcesarDragDeArchivo(ByVal e As DragEventArgs)

        If WHabilitado = True Then
            Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
            _SubirArchvios(archivos)
        End If
        
    End Sub

    Private Sub _SubirArchvios(ByVal archivos As String())

        Dim WDestino = ""
        Dim WCantCorrectas = 0

        If archivos.Length = 0 Then : Return : End If

        For Each archivo In archivos

            If File.Exists(archivo) Then

                If EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(archivo).ToLower()) Then

                    WDestino = WPath & "\" & Path.GetFileName(archivo)

                    Try
                        If Not File.Exists(WDestino) Then
                            File.Copy(archivo, WDestino)
                            WCantCorrectas += 1
                        Else
                            If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                File.Copy(archivo, WDestino, True)
                                WCantCorrectas += 1
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Return
                    End Try

                End If

            End If

        Next

        If WCantCorrectas > 0 Then
            MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information)
        End If

        _CargarArchivosRelacionados()
    End Sub

    Private Sub dgvArchivos_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles dgvArchivos.DragDrop
        If WHabilitado = True Then
            _ProcesarDragDeArchivo(e)
        End If
    End Sub

    Private Sub _CargarArchivosRelacionados()

        Dim InfoArchivo As FileInfo

        dgvArchivos.Rows.Clear()

        ' Recorremos unicamente aquellos archivos que tengan una extensión que esté entre las permitidas por la aplicación.
        For Each WNombreArchivo As String In Directory.GetFiles(WPath).Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

            InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)

            With InfoArchivo
                dgvArchivos.Rows.Add(.CreationTime.ToString("dd/MM/yyyy"), UCase(.Name), _ObtenerIconoSegunTipoArchivo(.Extension), .FullName)
            End With

        Next

    End Sub

    Private Function _ObtenerIconoSegunTipoArchivo(ByVal extension As String)
        Dim Wicono = Nothing

        Select Case UCase(extension)

            Case ".DOC", ".DOCX"
                Wicono = My.Resources.Word_icon
            Case ".XLS", ".XLSX", ".XLSM"
                Wicono = My.Resources.Excel_icon
            Case ".PDF"
                Wicono = My.Resources.pdf_icono
            Case ".JPG", ".JPEG", ".BMP", ".ICO", ".PNG"
                Wicono = My.Resources.imagen_icono
            Case ".TXT"
                Wicono = My.Resources.txt_icono
            Case Else
                Wicono = My.Resources.archivo_default
        End Select

        Return Wicono
    End Function

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            With OpenFileDialog2
                .Filter = "Imágenes (bmp, jpg, png) | " & String.Join(";", EXTENSIONES_PERMITIDAS.Split("|"))
                If .ShowDialog() = DialogResult.OK Then
                    Dim WArchivos() = .FileNames

                    If WArchivos.Length > 0 Then
                        _SubirArchvios(WArchivos)
                    End If

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Try
            If dgvArchivos.SelectedRows.Count > 0 Then

                If MsgBox("¿Está seguro de querer eliminar todos los archivos indicados?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

                For Each row As DataGridViewRow In dgvArchivos.SelectedRows
                    With row

                        If OrDefault(.Cells("PathArchivo").Value, "") = "" Then Continue For

                        File.Delete(.Cells("PathArchivo").Value)

                    End With
                Next

                _CargarArchivosRelacionados()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class
