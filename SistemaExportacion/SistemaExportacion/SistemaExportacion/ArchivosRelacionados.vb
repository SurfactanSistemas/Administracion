Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class ArchivosRelacionados

    Private Const EXTENSIONES_PERMITIDAS = "*.docx|*.doc|*.xls|*.xlsx|*.pdf|*.bmp|*.png|*.jpg|*.jpeg|*.ico|*.txt"

    Private _NroProforma As String
    Public Property NroProforma() As String
        Get
            Return _NroProforma
        End Get
        Set(ByVal value As String)
            _NroProforma = Helper.ceros(value, 6)
        End Set
    End Property

    Private Function _RutaCarpetaArchivos()
        Return Configuration.ConfigurationManager.AppSettings("ARCHIVOS_RELACIONADOS")
    End Function

    Private Sub ArchivosRelacionados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Me.NroProforma) Then
            ' Cargamos los archivos de la carpeta.

            txtNroProforma.Text = Me.NroProforma
            _BuscarClienteProforma()

            Try
                _CargarArchivosRelacionados()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

        End If

    End Sub

    Private Sub _CargarArchivosRelacionados()
        Dim WRutaArchivosRelacionados As String = ""
        If Not Directory.Exists(_RutaCarpetaArchivos) Then
            Throw New Exception("No se ha logrado tener acceso a la Carpeta Compartida de Archivos Relacionados.")
            Exit Sub
        End If

        If txtNroProforma.Text.Trim.Length < 6 Then : txtNroProforma.Text = Helper.ceros(txtNroProforma.Text, 6) : End If

        WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text

        ' Creamos la Carpeta en caso de que no exista aún.
        If Not Directory.Exists(WRutaArchivosRelacionados) Then
            Try
                Directory.CreateDirectory(WRutaArchivosRelacionados)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If

        Dim InfoArchivo As FileInfo

        dgvArchivos.Rows.Clear()

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
            Case ".XLS", ".XLSX"
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

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub _BuscarClienteProforma()
        If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Cliente, c.Razon FROM ProformaExportacion as p, Cliente as c WHERE Proforma = '" & txtNroProforma.Text & "' AND p.Cliente = c.Cliente")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = Helper._ConectarA
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

    Private Sub dgvArchivos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArchivos.CellMouseDoubleClick
        With dgvArchivos.Rows(e.RowIndex)
            If Not IsNothing(.Cells("RutaArchivo").Value) Then

                Try
                    Process.Start(.Cells("RutaArchivo").Value, "f")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End With
    End Sub

    Private Sub txtNroProforma_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroProforma.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNroProforma.Text) = "" Then : Exit Sub : End If

            Try
                _BuscarClienteProforma()

                _CargarArchivosRelacionados()

                With dgvArchivos
                    If .Rows.Count > 0 Then
                        .CurrentCell = .Rows(0).Cells(0)
                        .Focus()
                    Else
                        txtNroProforma.SelectAll()
                    End If
                End With

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtNroProforma.Text = ""
        End If

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

        If Trim(txtNroProforma.Text).Length < 6 Then : txtNroProforma.Text = Helper.ceros(txtNroProforma.Text, 6) : End If

        Dim WRutaArchivosRelacionados = _RutaCarpetaArchivos() & "\" & txtNroProforma.Text
        Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim WDestino As String = ""
        Dim WCantCorrectas = 0

        If archivos.Length = 0 Then : Exit Sub : End If

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

        If WCantCorrectas > 0 Then
            MsgBox("Se subieron correctamente " & WCantCorrectas & " Archivo(s)", MsgBoxStyle.Information)
        End If

        _CargarArchivosRelacionados()

    End Sub

    Private Sub dgvArchivos_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvArchivos.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub
End Class