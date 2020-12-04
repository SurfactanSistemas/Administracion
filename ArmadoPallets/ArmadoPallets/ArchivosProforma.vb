Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports Util.Clases.Helper
Public Class ArchivosProforma

    ' Para controles de grilla.
    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 4.9
    Private WRow, Wcol As Integer

    ' Constantes
    Private Const PRODUCTOS_MAX = 6
    Private Const EXTENSIONES_PERMITIDAS = "*.docx|*.doc|*.xls|*.xlsx|*.xlsm|*.pdf|*.bmp|*.png|*.jpg|*.jpeg|*.ico|*.txt"
    ' Private Const EXTENSIONES_PERMITIDAS = "*.bmp|*.png|*.jpg|*.jpeg"
    Private TIPO_ESPECIFICACIONES() As String = {"", "Envase", "Entrega", "Varios"}

    Private _NroProforma As String

    Public Property NroProforma() As String
        Get
            Return _NroProforma
        End Get
        Set(ByVal value As String)
            _NroProforma = value
        End Set
    End Property

    Private Sub ArchivosProforma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsNothing(Me.NroProforma) Then
            Try

                txtNroProforma.Text = ceros(Me.NroProforma, 6)

                _TraerHistorialYArchivos()

                TabControl1.SelectTab(0)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Me.Close()
            End Try
        End If

        ' txtFechaAux.Visible = False

        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

        WRow = -1
        Wcol = -1

    End Sub
    
    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProforma.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Function _Left(ByVal texto, ByVal largo) As String
        Return Microsoft.VisualBasic.Left(Trim(texto), largo)
    End Function

 
    
   
    Private Sub _TraerHistorialYArchivos()

        _BuscarClienteProforma()
        
        _CargarArchivosRelacionados()
        
    End Sub

  Private Sub btnArchivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivos.Click
        ' Abrimos ventana de archivos Relacionados.
        'With ArchivosRelacionados
        '    .NroProforma = txtNroProforma.Text
        '    .Show()
        'End With

        TabControl1.SelectTab(0)
        'Process.Start("explorer.exe", "C:\")
        Try
            _AdjuntarArchivos()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub _AdjuntarArchivos()
        Dim _ArchivosAdjuntos() As String

        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            _ArchivosAdjuntos = OpenFileDialog1.FileNames

            'txtNombreArchivoAdjunto.Text = _ArchivoAdjunto

            _SubirArchivos(_ArchivosAdjuntos)

        End If

        OpenFileDialog1.Dispose()

        _TraerHistorialYArchivos()


    End Sub

  
    '
    ' MANEJO DE PESTAÑA ARCHIVOS.
    '

    Private Function _RutaCarpetaArchivos()
        Return Configuration.ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS")
    End Function

    Private Sub _CargarArchivosRelacionados()
        Dim WRutaArchivosRelacionados As String = ""

        dgvArchivos.Rows.Clear()

        If Not Directory.Exists(_RutaCarpetaArchivos) Then
            Throw New Exception("No se ha logrado tener acceso a la Carpeta Compartida de Archivos Relacionados.")
            Exit Sub
        End If

        If txtNroProforma.Text.Trim.Length < 6 Then : txtNroProforma.Text = ceros(txtNroProforma.Text, 6) : End If

        WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text & "\" & "Packing List"

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
                dgvArchivos.Rows.Add(.CreationTime.ToString("dd/MM/yyyy"), UCase(.Name), _ObtenerIconoSegunTipoArchivo(.Extension), .FullName)
            End With

        Next

    End Sub

    Private Function _ObtenerIconoSegunTipoArchivo(ByVal extension As String)
        Dim icono = Nothing

        'My.Resources.pdf_icon


        Select Case UCase(extension)

            Case ".DOC", ".DOCX"
                icono = My.Resources.Word_icon
            Case ".XLS", ".XLSX", ".XLSM"
                icono = My.Resources.Excel_icon
            Case ".PDF"
                icono = My.Resources.pdf_icono
            Case ".JPG", ".JPEG", ".BMP", ".ICO", ".PNG"
                icono = My.Resources.imagen_icono
            Case ".TXT"
                icono = My.Resources.txt_icono
            Case Else
                icono = My.Resources.archivo_default
        End Select


        Return icono
    End Function

    Private Sub _BuscarClienteProforma()
        If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Cliente, c.Razon FROM ProformaExportacion as p, Cliente as c WHERE Proforma = '" & txtNroProforma.Text & "' AND p.Cliente = c.Cliente")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr
                    txtCliente.Text = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                    txtDescripcionCliente.Text = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                End With

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar los datos del Cliente correspondiente a la Proforma en la Base de Datos.", MsgBoxStyle.Critical)
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub


    Private Sub dgvArchivos_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragEnter
        _PermitirDrag(e)
    End Sub

    Private Sub _PermitirDrag(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs)

        If Trim(txtNroProforma.Text).Length < 6 Then : txtNroProforma.Text = ceros(txtNroProforma.Text, 6) : End If

        Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)


        If archivos.Length = 0 Then : Exit Sub : End If

        _SubirArchivos(archivos)

        'If WCantCorrectas > 0 Then
        '    MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information)
        'End If

        _CargarArchivosRelacionados()

    End Sub

    Private Sub _SubirArchivos(ByVal archivos() As String)
        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text & "\" & "Packing List"
        Dim WDestino As String = ""
        Dim WCantCorrectas = 0

        For Each archivo In archivos

            If File.Exists(archivo) Then

                If EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(archivo).ToLower()) Then

                    WDestino = WRutaArchivosRelacionados & "\" & Path.GetFileName(archivo)

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
                        Exit Sub
                    End Try

                End If

            End If

        Next

    End Sub

    Private Sub dgvArchivos_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Private Sub dgvArchivos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArchivos.RowHeaderMouseDoubleClick

        With dgvArchivos.Rows(e.RowIndex)

            Dim WRutaArchivo = .Cells("RutaArchi").Value

            If IsNothing(WRutaArchivo) Then : Exit Sub : End If

            If Trim(WRutaArchivo) = "" Then : Exit Sub : End If

            If Not File.Exists(WRutaArchivo) Then : Exit Sub : End If

            If MsgBox("¿Está seguro de que quiere eliminar el archivo de manera definitiva?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then : Exit Sub : End If

            Try
                File.Delete(WRutaArchivo)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            _TraerHistorialYArchivos()

            TabControl1.SelectTab(0)
        End With

    End Sub

   

 
    Private Sub PegarArchivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarArchivosToolStripMenuItem.Click
        Dim _Archivos() As String

        ReDim _Archivos(Clipboard.GetFileDropList.Count)

        For i = 0 To Clipboard.GetFileDropList.Count - 1
            _Archivos(i) = Clipboard.GetFileDropList.Item(i)
        Next

        _SubirArchivos(_Archivos)

        _TraerHistorialYArchivos()

    End Sub

    Private Sub dgvArchivos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchivos.CellDoubleClick
        If dgvArchivos.SelectedRows.Count > 0 Then : Exit Sub : End If
        With dgvArchivos.Rows(e.RowIndex)

            If Not IsNothing(.Cells("RutaArchi").Value) Then

                Try
                    Process.Start(.Cells("RutaArchi").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    

    Private Sub dgvArchivos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchivos.CellContentDoubleClick
        With dgvArchivos.Rows(e.RowIndex)
            If Not IsNothing(.Cells("RutaArchi").Value) Then

                Try
                    Process.Start(.Cells("RutaArchi").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub
End Class