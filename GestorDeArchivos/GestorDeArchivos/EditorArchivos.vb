Imports System.Collections.Specialized
Imports System.Configuration
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop

Public Class EditorArchivos
    Private ReadOnly WAccion
    Private ReadOnly WPath
    Private ReadOnly WMail
    Private ReadOnly WTituloMail
    Private ReadOnly WCuerpoMail

    Dim Mailenviado As Boolean = False

    Private Const EXTENSIONES_PERMITIDAS = "*.bmp|*.png|*.jpg|*.jpeg|*.pdf|*.doc|*.docx|*.xls|*.xlsx|*.txt"

    Sub New(ByVal Accion As Integer, ByVal Ruta As String, Optional ByVal Habilitado As Boolean = True, Optional ByVal mail As String = "", Optional ByVal Titulo As String = "", Optional ByVal CuerpoMail As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WAccion = Accion

        WPath = Ruta

        WMail = mail
        WTituloMail = Titulo
        WCuerpoMail = CuerpoMail


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
            Catch ex As System.Exception
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
                Catch ex As System.Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    Private Sub dgvArchivos_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles dgvArchivos.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub _PermitirDrag(ByVal e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

        ' Make sure that the format is a file drop.

        If (e.Data.GetDataPresent("FileGroupDescriptor")) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub


    ''' Handle File Drops
    '''
    ''' DragEventArgs ''' Path to the actual file or temp file
    ''' Returns the full path to the file being dropped or to a temp file that contains the file in memory (for use with Outlook or other program drag drops)
    Friend Function _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs) As String
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
                _SubirArchvios(archivos)
                ' We have a file so lets pass it to the calling form
                ' Dim Filename As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
                ' HandleFileDrops = Filename(0)
            ElseIf e.Data.GetDataPresent("FileGroupDescriptor") Then
                ' We have a embedded file. First lets try to get the file name out of memory
                Dim theStream As Stream = CType(e.Data.GetData("FileGroupDescriptor"), Stream)
                Dim fileGroupDescriptor(512) As Byte
                theStream.Read(fileGroupDescriptor, 0, 512)
                Dim fileName As System.Text.StringBuilder = New System.Text.StringBuilder("")
                Dim i As Integer = 76
                While Not (fileGroupDescriptor(i) = 0)
                    fileName.Append(Convert.ToChar(fileGroupDescriptor(i)))
                    System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)
                End While
                theStream.Close()
                ' We should have the file name or if its a email the subject line. Create our temp file based on the temp path and this info
                Directory.CreateDirectory("C:\Temporales")
                Dim myTempFile As String = "C:\Temporales\" + fileName.ToString()

                ' Look to see if this is a email message. If so save that temporarily and get the temp file.
                If InStr(myTempFile, ".msg") > 0 Then
                    Dim objOL As New Microsoft.Office.Interop.Outlook.Application
                    Dim objMI As Microsoft.Office.Interop.Outlook.MailItem
                    If objOL.ActiveExplorer.Selection.Count > 1 Then
                        MsgBox("You can only drag and drop one item at a time into this screen. The first item you selected will be used.", vbExclamation)
                    End If
                    For Each objMI In objOL.ActiveExplorer.Selection()
                        objMI.SaveAs(myTempFile)
                        Exit For
                    Next
                    objOL = Nothing
                    objMI = Nothing
                Else



                    ' If its a attachment we need to pull the file itself out of memory
                    Dim ms As MemoryStream = CType(e.Data.GetData("FileContents", True), MemoryStream)
                    Dim FileBytes(CInt(ms.Length)) As Byte
                    ' read the raw data into our variable
                    ms.Position = 0
                    ms.Read(FileBytes, 0, CInt(ms.Length))
                    ms.Close()
                    ' save the raw data into our temp file
                    Dim fs As FileStream = New FileStream(myTempFile, FileMode.OpenOrCreate, FileAccess.Write)
                    fs.Write(FileBytes, 0, FileBytes.Length)
                    fs.Close()
                End If
                ' Make sure we have a actual file and also if we do make sure we erase it when done
                If File.Exists(myTempFile) Then
                    ' Assign the file name to the add dialog
                    _ProcesarDragDeArchivo = myTempFile
                    Dim Archivos(15) As String
                    Dim posicion As Integer = -1
                    For Each WNombreArchivo As String In Directory.GetFiles("C:\Temporales").Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

                        Dim InfoArchivo As FileInfo
                        InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)

                        With InfoArchivo
                            posicion += 1
                            Archivos(posicion) = Trim(.FullName)
                        End With

                    Next

                    _SubirArchvios(Archivos)
                    'LUEGO DE PASAR LOS ARCHIVOS A LA CARPETA DESTINO LOS BORRAMOS DE LA TEMPORAL
                    For Each Ruta As String In Archivos
                        If Ruta IsNot Nothing Then
                            File.Delete(Ruta)
                        End If

                    Next
                Else
                    _ProcesarDragDeArchivo = String.Empty
                End If
            Else
                Throw New System.Exception("An exception has occurred.")
            End If
        Catch ex As System.Exception
            MsgBox("No se puede copiar el archivo desde la memoria.Por favor guarde el archivo en su equipo y luego arrastrelo al sistema.", "Error ")
            _ProcesarDragDeArchivo = String.Empty
        End Try

    End Function





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

                    Catch ex As System.Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Return
                    End Try

                End If

            End If

        Next

        'SI SE ENVIO EL MAIL, LO ENVIAMOS
        If Mailenviado = False Then
            If WMail <> "" Then
                EnviarMail()
            End If

        End If

        If WCantCorrectas > 0 Then
            MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information)
        End If

        _CargarArchivosRelacionados()
    End Sub

    Private Sub EnviarMail()

       
        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem

      
        Try
           

            oApp = New Outlook.Application()

            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = WTituloMail
            oMsg.Body = WCuerpoMail

            oMsg.To = WMail
           
            oMsg.Send()

            
            MsgBox("Aviso Enviado correctamente a " & WMail, MsgBoxStyle.Information)

            Mailenviado = True

        Catch ex As System.Exception

            Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        End Try


    End Sub


    Private Sub dgvArchivos_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles dgvArchivos.DragDrop
        _ProcesarDragDeArchivo(e)
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
        Catch ex As System.Exception
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
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        If My.Computer.Clipboard.ContainsFileDropList() Then
            Dim Ruta As New List(Of String)
            Dim archivo As Integer = -1
            For Each direccion As String In My.Computer.Clipboard.GetFileDropList()
                Ruta.Add(direccion)
            Next

            _SubirArchvios(Ruta.ToArray())


        Else


            If Clipboard.ContainsData("FileGroupDescriptor") Then

                'Get the Filename:

                Dim theStream As System.IO.Stream = DirectCast(Clipboard.GetData("FileGroupDescriptor"), System.IO.Stream)
                Dim fileGroupDescriptor As Byte() = New Byte(511) {}
                theStream.Read(fileGroupDescriptor, 0, 512)

                Dim fileName As New System.Text.StringBuilder("")
                Dim i As Integer
                i = 76
                While fileGroupDescriptor(i) <> 0
                    fileName.Append(Convert.ToChar(fileGroupDescriptor(i)))
                    i += 1
                End While
                theStream.Close()

                Directory.CreateDirectory("C:\Temporales")
                Dim theFile As String = "C:\Temporales\" + fileName.ToString()

                'Get the data and save it to a file:

                Dim ms As System.IO.MemoryStream = DirectCast(Clipboard.GetData("FileContents"), System.IO.MemoryStream)
                Dim fileBytes As Byte() = New Byte(ms.Length - 1) {}
                ms.Position = 0
                ms.Read(fileBytes, 0, CInt(ms.Length))

                Dim fs As New System.IO.FileStream(theFile, System.IO.FileMode.Create)
                fs.Write(fileBytes, 0, CInt(fileBytes.Length))
                fs.Close()

                Dim Archivos(15) As String
                Dim posicion As Integer = -1
                For Each WNombreArchivo As String In Directory.GetFiles("C:\Temporales").Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

                    Dim InfoArchivo As FileInfo
                    InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)

                    With InfoArchivo
                        posicion += 1
                        Archivos(posicion) = Trim(.FullName)
                    End With

                Next

                _SubirArchvios(Archivos)
                'LUEGO DE PASAR LOS ARCHIVOS A LA CARPETA DESTINO LOS BORRAMOS DE LA TEMPORAL
                For Each Ruta As String In Archivos
                    If Ruta IsNot Nothing Then
                        File.Delete(Ruta)
                    End If

                Next


            Else
                MsgBox("no tiene archivo")
            End If



        End If





    End Sub
End Class
