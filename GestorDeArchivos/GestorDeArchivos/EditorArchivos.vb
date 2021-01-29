Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports Util.Clases.Query


Public Class EditorArchivos : Implements SelectorCarpetas
    Private ReadOnly WAccion
    Private ReadOnly WPath
    Private ReadOnly WMail
    Private ReadOnly WTituloMail
    Private ReadOnly WCuerpoMail
    Private ReadOnly WOperador

    Dim DragActivo As Boolean = False
    Dim DragDesdeOutLOOK As Boolean = False
    Dim CarpetasDrag(7) As String
    Dim Pegando As Boolean = False
    Dim Mailenviado As Boolean = False
    Dim filaCambioNombre As Integer = -1

    Private Const EXTENSIONES_PERMITIDAS = "*.bmp|*.png|*.jpg|*.jpeg|*.pdf|*.doc|*.docx|*.xls|*.xlsx|*.txt|*.rar|*.zip"

    Sub New(ByVal Accion As Integer, ByVal Ruta As String, Optional ByVal ClaveOperador As String = "", Optional ByVal Habilitado As Boolean = True, Optional ByVal mail As String = "", Optional ByVal Titulo As String = "", Optional ByVal CuerpoMail As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WAccion = Accion

        WPath = Ruta


        Try
            Dim SQLCnslt As String = "SELECT Descripcion FROM Operador WHERE UPPER(Clave) = '" & UCase(ClaveOperador) & "'"
            Dim RowOpe As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowOpe IsNot Nothing Then
                WOperador = Trim(RowOpe.Item("Descripcion"))
            Else
                WOperador = Trim(ClaveOperador)
                ' WOperador = "ANDRES"
            End If
        Catch ex As Exception

        End Try

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
        Select Case WAccion
            Case 1
                Try
                    Process.Start(WPath, "f")
                    Me.Close()
                Catch ex As System.Exception
                    MsgBox(ex.Message)
                End Try
            Case 2
                If Not Directory.Exists(WPath) Then
                    Directory.CreateDirectory(WPath)
                End If

                _CargarArchivosRelacionados()
            Case 3
                If Not Directory.Exists(WPath) Then
                    Directory.CreateDirectory(WPath)
                End If

                'MODIFICO EL TAMAÑO DE LA VENTANA 
                'Y HAGO VISIBLE EL GROUPBOX
                Me.Size = New Size(674, 462)
                gbx_Carpetas.Visible = True

                crearCarpetas(WPath)

                ActualizarCarpetas()

                'Label3.Visible = True
                'cmb_Carpeta.Visible = True
                'cmb_Carpeta.SelectedIndex = 0

                _CargarArchivosRelacionados()

        End Select

    End Sub

    Private Sub ActualizarCarpetas()

        Dim MostrarMensaje As Boolean = True

        cmb_Carpeta.Items.Clear()

        Dim Nombre_Para_rbn As String
        Dim CantidadArchivos As Integer
        For i = 0 To 7
            Select Case i
                Case 0
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath)
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_General.Visible = True
                    Else
                        Img_General.Visible = False
                    End If

                    'ACTUALIZO EL TEXT CON EL NOMBRE Y LA CANTIDAD DE ARCHIVOS
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") General"
                    rbn_General.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 1
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\Proforma")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_Proforma.Visible = True
                    Else
                        Img_Proforma.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") Proforma"
                    rbn_Proforma.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 2
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\SIMI")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_SIMI.Visible = True
                    Else
                        Img_SIMI.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") SIMI"
                    rbn_SIMI.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 3
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\Orden de Compra")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_OrdenDeCompra.Visible = True
                    Else
                        Img_OrdenDeCompra.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") Orden de Compra"
                    rbn_OrdenDeCompra.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 4
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\Packing List")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_PackingList.Visible = True
                    Else
                        Img_PackingList.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") Packing List"
                    rbn_PackingList.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 5
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\COAS")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_COAS.Visible = True
                    Else
                        Img_COAS.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") COAS"
                    rbn_COAS.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 6
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\BL")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_BL.Visible = True
                    Else
                        Img_BL.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") BL"
                    rbn_BL.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)
                Case 7
                    CantidadArchivos = 0
                    For Each Archivo As String In Directory.GetFiles(WPath & "\INVOICE")
                        CantidadArchivos += 1
                    Next
                    If CantidadArchivos > 0 Then
                        Img_INVOIS.Visible = True
                    Else
                        Img_INVOIS.Visible = False
                        MostrarMensaje = False
                    End If
                    Nombre_Para_rbn = "(" & (CantidadArchivos).ToString.PadLeft(2, "0") & ") INVOICE"
                    rbn_INVOIS.Text = Nombre_Para_rbn
                    'cmb_Carpeta.Items.Add(_item)

            End Select
        Next

        If MostrarMensaje Then
            lbl_CarpetasCompletas.Visible = True
        Else
            lbl_CarpetasCompletas.Visible = False
        End If

    End Sub
    Private Sub crearCarpetas(ByVal WPath As String)
        For i = 0 To 7
            Select Case i
                Case 0
                    If Not Directory.Exists(WPath & "\Proforma") Then
                        Directory.CreateDirectory(WPath & "\Proforma")
                    End If
                Case 1
                    If Not Directory.Exists(WPath & "\SIMI") Then
                        Directory.CreateDirectory(WPath & "\SIMI")
                    End If

                Case 2
                    If Not Directory.Exists(WPath & "\Orden de Compra") Then
                        Directory.CreateDirectory(WPath & "\Orden de Compra")
                    End If

                Case 3
                    If Not Directory.Exists(WPath & "\Packing List") Then
                        Directory.CreateDirectory(WPath & "\Packing List")
                    End If

                Case 4
                    If Not Directory.Exists(WPath & "\COAS") Then
                        Directory.CreateDirectory(WPath & "\COAS")
                    End If

                Case 5
                    If Not Directory.Exists(WPath & "\BL") Then
                        Directory.CreateDirectory(WPath & "\BL")
                    End If

                Case 6
                    If Not Directory.Exists(WPath & "\INVOICE") Then
                        Directory.CreateDirectory(WPath & "\INVOICE")
                    End If
            End Select
        Next
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
                'CAMBIAMOS LA BANDERA PARA SABER QUE ESTAMOS ARRASTRANDO UN ARCHIVO
                DragActivo = True
                'LLAMAMOS A LA VENTAN PARA QUE DIGA A QUE CARPETAS COPIAR
                With New SeleccionarCarpetas(WPath, True, archivos)
                    .Show(Me)
                End With
                DragActivo = True
                '_SubirArchvios(archivos)

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
                ' Dim myTempFile As String = "C:\Temporales\" + fileName.ToString()

                Dim NombreArchivo As String = fileName.ToString()
                NombreArchivo = Regex.Replace(NombreArchivo, "[^\w\\-]", "")



                Dim Extencion As String = obtenerExtencion(fileName.ToString())
                removerExtencion(NombreArchivo, Extencion)
                Dim myTempFile As String = "C:\Temporales\" & NombreArchivo & Extencion




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
                    'CAMBIAMOS LA BANDERA PARA SABER QUE ESTAMOS ARRASTRANDO UN ARCHIVO
                    DragActivo = True
                    'TAMBIEN CAMBIAMOS LA DE OUTLOOK PARA SABER QUE 
                    'HAY QUE BORRAR LOS ARCHIVOS DE LA CARPETA AUXILIAR
                    DragDesdeOutLOOK = True

                    'LLAMAMOS A LA VENTAN PARA QUE DIGA A QUE CARPETAS COPIAR
                    If WAccion = 3 Then
                        With New SeleccionarCarpetas(WPath, True, Archivos)
                            .Show(Me)
                        End With
                    Else
                        _SubirArchvios(Archivos)
                    End If


                    ' _SubirArchvios(Archivos)

                    ' 'LUEGO DE PASAR LOS ARCHIVOS A LA CARPETA DESTINO LOS BORRAMOS DE LA TEMPORAL
                    ' For Each Ruta As String In Archivos
                    '     If Ruta IsNot Nothing Then
                    '         File.Delete(Ruta)
                    '     End If
                    '
                    'Next
                Else
                    _ProcesarDragDeArchivo = String.Empty
                End If
            Else
                Throw New System.Exception("An exception has occurred.")
            End If
        Catch ex As System.Exception
            MsgBox("No se puede copiar el archivo desde la memoria.Por favor guarde el archivo en su equipo y luego arrastrelo al sistema.", "Error ")
            _ProcesarDragDeArchivo = String.Empty
        Finally
            TopMost = False
        End Try

    End Function

    Private Sub removerExtencion(ByRef NombreArchivo As String, ByVal Extension As String)
        Dim CantNombre As Integer = NombreArchivo.Length
        Dim CantExtension As Integer = Extension.Length - 1

        Dim posicionDeInicio As Integer = CantNombre - CantExtension

        NombreArchivo = NombreArchivo.Remove(posicionDeInicio, CantExtension)

    End Sub

    Private Function obtenerExtencion(ByVal nombreArchivo As String) As String

        If nombreArchivo.Contains(".rar") Then
            Return ".rar"
        End If
        If nombreArchivo.Contains(".zip") Then
            Return ".zip"
        End If
        If nombreArchivo.Contains(".txt") Then
            Return ".txt"
        End If
        If nombreArchivo.Contains(".xlsx") Then
            Return ".xlsx"
        End If
        If nombreArchivo.Contains(".xls") Then
            Return ".xls"
        End If
        If nombreArchivo.Contains(".docx") Then
            Return ".docx"
        End If
        If nombreArchivo.Contains(".doc") Then
            Return ".doc"
        End If
        If nombreArchivo.Contains(".pdf") Then
            Return ".pdf"
        End If
        If nombreArchivo.Contains(".jpeg") Then
            Return ".jpeg"
        End If
        If nombreArchivo.Contains(".jpg") Then
            Return ".jpg"
        End If
        If nombreArchivo.Contains(".png") Then
            Return ".png"
        End If
        If nombreArchivo.Contains(".bmp") Then
            Return ".bmp"
        End If

    End Function


    Private Sub _SubirArchvios(ByVal archivos As String(), Optional ByVal Carpetas As Object = Nothing)



        Me.BringToFront()
        Me.Focus()

        Dim WDestino = ""
        Dim WCantCorrectas = 0

        If archivos.Length = 0 Then : Return : End If

        For Each archivo In archivos

            If File.Exists(archivo) Then

                If EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(archivo).ToLower()) Then

                    If gbx_Carpetas.Visible Then

                        If Pegando = True Then
                            'ESTE ES EL CAMINO QUE VA A TOMAR DESPUES DE 
                            'PEGAR UN ARCHIVO Y ELEGIR LAS CARPETAS
                            For i = 0 To 7

                                If Trim(Carpetas(i)) = "" Then
                                    Continue For
                                End If

                                'Dim RutaAUsar As String = ObtenerRutaRadioButons()
                                WDestino = Carpetas(i) & "\" & Path.GetFileName(archivo)

                                Try
                                    If Not File.Exists(WDestino) Then
                                        File.Copy(archivo, WDestino)
                                        WCantCorrectas += 1
                                    Else
                                        If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo, MessageBoxOptions.ServiceNotification) = MsgBoxResult.Yes Then
                                            File.Copy(archivo, WDestino, True)
                                            WCantCorrectas += 1
                                        End If
                                    End If

                                    'GENERAMOS EL REGISTRO EN EL HISTORIAL DE ARCHIVOS
                                    GenerarRegistroHistorial(WDestino, WOperador)

                                Catch ex As System.Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                    Return
                                End Try

                            Next

                            'VUELVO A PASAR EL PEGANDO A FALSE 
                            'PARA ACTUALIZAR AL BANDERA
                            Pegando = False
                        Else
                            If DragActivo Then
                                'ESTE ES EL CAMINO QUE VA A TOMAR CUANDO SE ARRASTRE UN ARCHIVO
                                For i = 0 To 7
                                    If Trim(CarpetasDrag(i)) = "" Then
                                        Continue For
                                    End If
                                    'Dim RutaAUsar As String = ObtenerRutaRadioButons()
                                    'WDestino = RutaAUsar & "\" & Path.GetFileName(archivo)
                                    WDestino = CarpetasDrag(i) & "\" & Path.GetFileName(archivo)


                                    Try
                                        If Not File.Exists(WDestino) Then
                                            File.Copy(archivo, WDestino)
                                            WCantCorrectas += 1
                                        Else
                                            If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo, MessageBoxOptions.ServiceNotification) = MsgBoxResult.Yes Then
                                                File.Copy(archivo, WDestino, True)
                                                WCantCorrectas += 1
                                            End If
                                        End If

                                        'GENERAMOS EL REGISTRO EN EL HISTORIAL DE ARCHIVOS
                                        GenerarRegistroHistorial(WDestino, WOperador)

                                    Catch ex As System.Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        Return
                                    End Try
                                Next

                            Else
                                For i = 0 To 7


                                    If Trim(CarpetasDrag(i)) = "" Then
                                        Continue For
                                    End If
                                    'ESTE ES EL CAMINO QUE VA A TOMAR CUANDO 
                                    'SE AGREGUE USANDO EL BOTON AGREGAR ARCHIVO
                                    'WDestino = WPath & "\" & Path.GetFileName(archivo)
                                    WDestino = CarpetasDrag(i) & "\" & Path.GetFileName(archivo)



                                    Try
                                        If Not File.Exists(WDestino) Then
                                            File.Copy(archivo, WDestino)
                                            WCantCorrectas += 1
                                        Else
                                            If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo, MessageBoxOptions.ServiceNotification) = MsgBoxResult.Yes Then
                                                File.Copy(archivo, WDestino, True)
                                                WCantCorrectas += 1
                                            End If
                                        End If

                                        'GENERAMOS EL REGISTRO EN EL HISTORIAL DE ARCHIVOS
                                        GenerarRegistroHistorial(WDestino, WOperador)

                                    Catch ex As System.Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        Return
                                    End Try
                                Next

                            End If


                        End If





                    Else
                        'ESTE ES EL CAMINO QUE VA A TOMAR CUANDO SE ABRA CON LA OPCION 2
                        WDestino = WPath & "\" & Path.GetFileName(archivo)


                        Try
                            If Not File.Exists(WDestino) Then
                                File.Copy(archivo, WDestino)
                                WCantCorrectas += 1
                            Else
                                If MsgBox("El Archivo " & Path.GetFileName(archivo) & ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo, MessageBoxOptions.ServiceNotification) = MsgBoxResult.Yes Then
                                    File.Copy(archivo, WDestino, True)
                                    WCantCorrectas += 1
                                End If
                            End If

                            'GENERAMOS EL REGISTRO EN EL HISTORIAL DE ARCHIVOS
                            GenerarRegistroHistorial(WDestino, WOperador)

                        Catch ex As System.Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Return
                        End Try
                    End If


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
            MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information, MessageBoxOptions.ServiceNotification)
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
        Dim WRutaArchivosRelacionados As String = ""

        dgvArchivos.Rows.Clear()

        If Not Directory.Exists(WPath) Then
            Throw New Exception("No se ha logrado tener acceso a la Carpeta Compartida de Archivos Relacionados.")
            Exit Sub
        End If
        If WAccion = 3 Then

            WRutaArchivosRelacionados = ObtenerRutaRadioButons()

        Else
            WRutaArchivosRelacionados = WPath
        End If

        'WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text

        ' Creamos la Carpeta en caso de que no exista aún.
        If Not Directory.Exists(WRutaArchivosRelacionados) Then
            Try
                Directory.CreateDirectory(WRutaArchivosRelacionados)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If

        Dim InfoArchivo As FileInfo


        ' Recorremos unicamente aquellos archivos que tengan una extensión que esté entre las permitidas por la aplicación.
        For Each WNombreArchivo As String In Directory.GetFiles(WRutaArchivosRelacionados).Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

            InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)

            With InfoArchivo
                dgvArchivos.Rows.Add(.CreationTime.ToString("dd/MM/yyyy"), UCase(.Name), _ObtenerIconoSegunTipoArchivo(.Extension), .FullName, _ObtenerOperador(.FullName))
            End With

        Next


        'Dim InfoArchivo As FileInfo
        '
        'dgvArchivos.Rows.Clear()
        '
        '' Recorremos unicamente aquellos archivos que tengan una extensión que esté entre las permitidas por la aplicación.
        'For Each WNombreArchivo As String In Directory.GetFiles(WPath).Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))
        '
        '    InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo)
        '
        '    With InfoArchivo
        '        dgvArchivos.Rows.Add(.CreationTime.ToString("dd/MM/yyyy"), UCase(.Name), _ObtenerIconoSegunTipoArchivo(.Extension), .FullName)
        '    End With
        '
        'Next

        If WAccion = 3 Then
            ActualizarCarpetas()
        End If


    End Sub


    Private Function ObtenerRutaRadioButons() As String

        Dim RutaCarpeta As String = ""

        For Each ctrl As Control In gbx_Carpetas.Controls
            If (ctrl.GetType() Is GetType(RadioButton)) Then
                Dim rbn As RadioButton = CType(ctrl, RadioButton)
                If rbn.Checked Then
                    Select Case rbn.Name
                        Case "rbn_General"
                            RutaCarpeta = WPath
                        Case "rbn_Proforma"
                            RutaCarpeta = WPath & "\Proforma"
                        Case "rbn_SIMI"
                            RutaCarpeta = WPath & "\SIMI"
                        Case "rbn_OrdenDeCompra"
                            RutaCarpeta = WPath & "\Orden de Compra"
                        Case "rbn_PackingList"
                            RutaCarpeta = WPath & "\Packing List"
                        Case "rbn_COAS"
                            RutaCarpeta = WPath & "\COAS"
                        Case "rbn_BL"
                            RutaCarpeta = WPath & "\BL"
                        Case "rbn_INVOIS"
                            RutaCarpeta = WPath & "\INVOICE"
                    End Select
                    Return RutaCarpeta
                End If

            End If
        Next

    End Function

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
            Case ".ZIP"
                Wicono = My.Resources.icoZIP
            Case ".RAR"
                Wicono = My.Resources.icoRAR
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
                        With New SeleccionarCarpetas(WPath, True, WArchivos)
                            .Show(Me)
                        End With
                        '_SubirArchvios(WArchivos)
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

                'SI SE ENVIO EL MAIL, LO ENVIAMOS
                If Mailenviado = False Then
                    If WMail <> "" Then
                        EnviarMail()
                    End If

                End If

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
        With New SeleccionarCarpetas(WPath)
            .Show(Me)
        End With

    End Sub

    ' Private Sub cmb_Carpeta_DropDownClosed(sender As Object, e As EventArgs) Handles cmb_Carpeta.DropDownClosed
    '     _CargarArchivosRelacionados()
    ' End Sub


    Private Sub rbn_General_Click(sender As Object, e As EventArgs) Handles rbn_General.Click, rbn_Proforma.Click, rbn_SIMI.Click, rbn_PackingList.Click, rbn_OrdenDeCompra.Click, rbn_INVOIS.Click, rbn_COAS.Click, rbn_BL.Click
        _CargarArchivosRelacionados()
    End Sub

    Private Sub dgvArchivos_DragOver(sender As Object, e As DragEventArgs) Handles dgvArchivos.DragOver
        'MsgBox("")
        TopMost = True
    End Sub

    Private Sub dgvArchivos_DragLeave(sender As Object, e As EventArgs) Handles dgvArchivos.DragLeave
        TopMost = False
    End Sub

    Private Function _ObtenerOperador(ByVal RutaArchivo As String) As String
        Try
            Dim SQLCnslt As String = "SELECT Operador FROM HistorialGestorArchivos WHERE RutaArchivo = '" & RutaArchivo & "'"
            Dim RowHistorial As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowHistorial IsNot Nothing Then
                Return RowHistorial.Item("Operador")
            Else
                Return ""
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub GenerarRegistroHistorial(ByVal RutaArchivo As String, ByVal Operador As String)
        Try
            Dim SQLCnslt As String = "SELECT Operador FROM HistorialGestorArchivos WHERE RutaArchivo = '" & RutaArchivo & "'"
            Dim RowHistorial As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            Dim Fecha As String = Date.Today.ToString("dd/MM/yyyy")
            Dim OrdFecha As String = Date.Today.ToString("yyyyMMdd")
            If RowHistorial IsNot Nothing Then
                If Trim(RowHistorial.Item("Operador")) = Trim(WOperador) Then
                    SQLCnslt = "UPDATE HistorialGestorArchivos SET Fecha = '" & Fecha & "', " _
                                    & "OrdFecha = '" & OrdFecha & "' " _
                                    & "WHERE RutaArchivo = '" & RutaArchivo & "'"
                Else
                    SQLCnslt = "UPDATE HistorialGestorArchivos SET Fecha = '" & Fecha & "', " _
                                & "OrdFecha = '" & OrdFecha & "', " _
                                & "Operador = '" & WOperador & "' " _
                                & "WHERE RutaArchivo = '" & RutaArchivo & "'"
                End If
            Else
                SQLCnslt = "INSERT INTO HistorialGestorArchivos (RutaArchivo, Fecha, OrdFecha, Operador) " _
                            & "VALUES ('" & RutaArchivo & "', '" & Fecha & "', '" & OrdFecha & "', '" & WOperador & "')"
            End If

            ExecuteNonQueries("SurfactanSa", SQLCnslt)

        Catch ex As Exception

        End Try




    End Sub

    Private Sub CambiarNombreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarNombreToolStripMenuItem.Click
        Try
            filaCambioNombre = dgvArchivos.CurrentRow.Index
            pnl_CambioNombre.Visible = True
            Dim Extencion As String = obtenerExtencion(LCase(dgvArchivos.CurrentRow.Cells("DescArchivo").Value))
            txt_NuevoNombre.Text = (LCase(dgvArchivos.CurrentRow.Cells("DescArchivo").Value)).ToString().Replace(Extencion, "")
            txt_NuevoNombre.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ActualizarEnHistorial(ByVal NombreViejo As String, ByVal NuevoNombre As String)
        Dim WRutaArchivosRelacionados As String = ObtenerRutaRadioButons()
        Dim WFecha As String = Date.Today.ToString("dd/MM/yyyy")
        Dim WOrdFecha As String = Date.Today.ToString("yyyyMMdd")
        Dim SQLCnslt As String = "UPDATE HistorialGestorArchivos SET RutaArchivo = '" & WRutaArchivosRelacionados & "\" & NuevoNombre & "', " _
                                 & "Fecha = '" & WFecha & "', OrdFecha = '" & WOrdFecha & "' " _
                                 & "WHERE RutaArchivo = '" & NombreViejo & "'"
        Try
            ExecuteNonQueries("SurfactanSa", SQLCnslt)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CambiarNombre(ByVal NuevoNombre As String)
        Try

            Dim WRutaArchivosRelacionados As String = ObtenerRutaRadioButons()

            For Each WNombreArchivo As String In Directory.GetFiles(WRutaArchivosRelacionados).Where(Function(s) EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower()))

                If Trim(WNombreArchivo) = Trim(dgvArchivos.Rows(filaCambioNombre).Cells("PathArchivo").Value) Then
                    Dim Extencion As String = obtenerExtencion(WNombreArchivo)
                    Dim NombreViejo As String = WNombreArchivo
                    FileSystem.RenameFile(WNombreArchivo, NuevoNombre & Extencion)

                    ActualizarEnHistorial(NombreViejo, NuevoNombre & Extencion)

                    'ACTUALIZO LA GRILLA PARA QUE SE VEA EL CAMBIO
                    _CargarArchivosRelacionados()
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txt_NuevoNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_NuevoNombre.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_NuevoNombre.Text) <> "" Then
                    txt_NuevoNombre.Text = Regex.Replace(txt_NuevoNombre.Text, "[^\w\\-]", " ")
                    CambiarNombre(txt_NuevoNombre.Text)
                    pnl_CambioNombre.Visible = False
                End If
            Case Keys.Escape
                txt_NuevoNombre.Text = ""

        End Select
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        pnl_CambioNombre.Visible = False
    End Sub

    Public Sub Pasavector(VectorCarpetas As Object) Implements SelectorCarpetas.Pasavector
        Pegando = True
        If My.Computer.Clipboard.ContainsFileDropList() Then



            Dim Ruta As New List(Of String)
            Dim archivo As Integer = -1
            For Each direccion As String In My.Computer.Clipboard.GetFileDropList()
                Ruta.Add(direccion)
            Next

            _SubirArchvios(Ruta.ToArray(), VectorCarpetas)


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


                Dim NombreArchivo As String = fileName.ToString()
                NombreArchivo = Regex.Replace(NombreArchivo, "[^\w\\-]", "")



                Dim Extencion As String = obtenerExtencion(fileName.ToString())
                removerExtencion(NombreArchivo, Extencion)
                Directory.CreateDirectory("C:\Temporales")
                Dim theFile As String = "C:\Temporales\" & NombreArchivo & Extencion


                'Directory.CreateDirectory("C:\Temporales")
                ' Dim theFile As String = "C:\Temporales\" + fileName.ToString()

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

                _SubirArchvios(Archivos, VectorCarpetas)
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

    Public Sub PasavectorDragOn(VectorCarpetas As Object, WArchivos As Object) Implements SelectorCarpetas.PasavectorDragOn
        CarpetasDrag = VectorCarpetas
        _SubirArchvios(WArchivos)
        'SOLO HACEMOS ESTO SI ES UN DRAGON
        'SINO FILTRARA ESTO AL AGREGAR CON EL BOTON N
        'LOS BORRARIA LOS ARCHIVOS DE LA UBICACION DE DONDE LOS OBTUVIERAMOS
        If DragActivo Then
            'LUEGO DE PASAR LOS ARCHIVOS A LA CARPETA DESTINO 
            'LOS BORRAMOS DE LA TEMPORAL SI EL ARCHIVO VIENE DE OUTLOOK
            If DragDesdeOutLOOK Then
                For Each Ruta As String In WArchivos
                    If Ruta IsNot Nothing Then
                        File.Delete(Ruta)
                    End If

                Next
                'DEVOLVEMOS LA BANDERA A FALSE
                DragDesdeOutLOOK = False
            End If
            'DEVOLVEMOS LA BANDERA A FALSE
            DragActivo = False
        End If

    End Sub
End Class
