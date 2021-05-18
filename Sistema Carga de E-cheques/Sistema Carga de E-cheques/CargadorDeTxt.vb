Imports System.Configuration
Imports Util.Clases.Helper
Imports Util.Clases.Query
Imports System.IO


Public Class CargadorDeTxt

    Dim DragActivo As Boolean = False
    Dim RutaCarpeta As String
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        RutaCarpeta = ConfigurationManager.AppSettings("ARCHIVOS_A_CARGAR")

        CargarArchivos()
    End Sub

    Private Sub CargarArchivos()
        If Directory.Exists(RutaCarpeta) Then
            For Each file As String In Directory.GetFiles(RutaCarpeta)
                DGV_RutasArchivos.Rows.Add(file)
            Next
            btn_ObtenerDatos_Click(Nothing, Nothing)
            'btn_CargarEnTabla_Click(Nothing, Nothing)


            Dim listaArchivos As New List(Of String)
            For Each file As String In Directory.GetFiles(RutaCarpeta)
                listaArchivos.Add(file)
            Next

            For Each item As DataGridViewRow In DGV_RutasArchivos.Rows
                File.Delete(item.Cells(0).Value)
            Next

        Else

        End If
    End Sub

    Private Sub btn_ObtenerDatos_Click(sender As Object, e As EventArgs) Handles btn_ObtenerDatos.Click
        Dim tablafinal As new DataTable
        Dim Primera As Integer = 1
        If DGV_RutasArchivos.Rows.Count > 0 Then
            For Each row As DataGridViewRow In DGV_RutasArchivos.Rows
                If Primera = 1 Then
                    tablafinal = txt_A_Datatable(row.Cells("Rutas").Value, True, ";")
                    RemoverDatosInesesarios(tablafinal)
                    Primera += 1
                Else
                    Dim Tabla = txt_A_Datatable(row.Cells("Rutas").Value, True, ";")
                    RemoverDatosInesesarios(Tabla)
                    For Each rowTabla As DataRow In Tabla.Rows
                        tablafinal.ImportRow(rowTabla)
                    Next
                End If

            Next
            dgv_Cheques.DataSource = tablafinal

        End If

        If dgv_Cheques.Columns("Monto") IsNot Nothing Then
            dgv_Cheques.Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            For Each rowCheques As DataGridViewRow In dgv_Cheques.Rows
                rowCheques.Cells("monto").Value = formatonumerico(rowCheques.Cells("monto").Value)
            Next
        End If


    End Sub

    Private Sub RemoverDatosInesesarios(ByRef Tabla As DataTable)

        For i As Integer = 40 To 0 Step -1
            If i = 0 Or i = 1 Or i = 2 Or i = 4 Or i = 5 Or i = 6 Or i = 7 Or i = 10 Or i = 20 Or i = 23 Or i = 24 Then
                Continue For
            End If
            Tabla.Columns.RemoveAt(i)
        Next

    End Sub
    Private Function txt_A_Datatable(ByVal filename As String, ByVal header As Boolean, ByVal delimiter As String) As DataTable
        'Nueva tabla de datos 
        Dim dt As DataTable = New DataTable

        ' Leer el contenido del archivo de texto en una matriz 
        Dim sr As IO.StreamReader = New IO.StreamReader(filename)
        Dim txtlines() As String = sr.ReadToEnd.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        sr.Close()

        ''No devuelve nada si no hay nada en el archivo de texto
        If txtlines.Count = 0 Then
            Return Nothing
        End If

        Dim column_count As Integer = 0
        For Each col As String In txtlines(0).Split({delimiter}, StringSplitOptions.None)
            If header Then
                'If there's a header then add it by it's name
                'Si hay un encabezado, agréguelo junto al nombre 

                dt.Columns.Add(col)
                dt.Columns(column_count).Caption = col

            Else
                'Si no hay encabezado, agréguelo por el recuento de columnas
                dt.Columns.Add(String.Format("Column{0}", column_count))
                dt.Columns(column_count).Caption = String.Format("Column{0}", column_count + 1)
            End If

            column_count += 1
        Next

        If header Then
            For rows As Integer = 1 To txtlines.Count - 1 'start at uno porque hay un encabezado para la primera línea (0) 
                'Declarar una nueva fila de datos 
                Dim dr As DataRow = dt.NewRow

                ' Establecer el recuento de columnas de nuevo a 0, podemos reutilizar esta variable;] 
                column_count = 0
                For Each col As String In txtlines(rows).Split({delimiter}, StringSplitOptions.None) 'Each column in the row
                    ' La columna en la señal se establece para la fila de datos
                    dr(column_count) = col
                    column_count += 1
                Next

                'Agregar la fila 
                dt.Rows.Add(dr)
            Next
        Else
            For rows As Integer = 0 To txtlines.Count - 1 'comienza en cero porque no hay encabezado 
                ' Declare una nueva fila de datos 
                Dim dr As DataRow = dt.NewRow

                ' Establece el recuento de columnas de nuevo a 0, podemos reutilizar esta variable;] 
                column_count = 0
                For Each col As String In txtlines(rows).Split({delimiter}, StringSplitOptions.None) 'Each column in the row
                    'La columna en cue está configurada para el datarow 
                    dr(column_count) = col
                    column_count += 1
                Next

                ' Agrega la fila
                dt.Rows.Add(dr)
            Next
        End If

        Return dt
    End Function



    Private Sub txt_Archivo_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_RutasArchivos.DragDrop
        _ProcesarDragDeArchivo(e)
    End Sub

    Friend Function _ProcesarDragDeArchivo(ByVal e As System.Windows.Forms.DragEventArgs) As String

        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim archivos() As String = e.Data.GetData(DataFormats.FileDrop)
                'CAMBIAMOS LA BANDERA PARA SABER QUE ESTAMOS ARRASTRANDO UN ARCHIVO
                DragActivo = True

                For Each archivo In archivos
                    DGV_RutasArchivos.Rows.Add(archivo)
                Next


                'With New SeleccionarCarpetas(WPath, True, archivos)
                '    .Show(Me)
                'End With
                DragActivo = True
                '_SubirArchvios(archivos)

                ' We have a file so lets pass it to the calling form
                ' Dim Filename As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
                ' HandleFileDrops = Filename(0)

            End If
        Catch ex As System.Exception
            MsgBox("No se puede copiar el archivo desde la memoria.Por favor guarde el archivo en su equipo y luego arrastrelo al sistema.", "Error ")
            _ProcesarDragDeArchivo = String.Empty
        Finally
            TopMost = False
        End Try

        Return ""

    End Function

    Private Sub txt_Archivo_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_RutasArchivos.DragEnter
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

    Private Sub txt_Archivo_DragLeave(sender As Object, e As EventArgs) Handles DGV_RutasArchivos.DragLeave
        TopMost = False
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        Dim listaEliminar As New List(Of Integer)
        Dim contadorFila As Integer = 0
        For Each row As DataGridViewRow In dgv_Cheques.Rows
            If row.Cells.Item("Chk").Value = True Then
                listaEliminar.Add(contadorFila)
            End If
            contadorFila += 1
        Next
        listaEliminar.Sort()
        listaEliminar.Reverse()
        Dim tabla As DataTable = dgv_Cheques.DataSource
        For i = 0 To listaEliminar.Count - 1
            tabla.Rows.RemoveAt(listaEliminar.Item(i))
        Next

    End Sub

    Private Sub btn_CargarEnTabla_Click(sender As Object, e As EventArgs) Handles btn_CargarEnTabla.Click
        Dim Cantidad_Grabada As Integer = 0
        Dim Cantidad_YaExistentes As Integer = 0
        Try
            Dim SQLCnslt As String = ""
            Dim ListaSQLCnslt As New List(Of String)

            Dim tabla As DataTable = dgv_Cheques.DataSource
            For Each rowTabla As DataRow In tabla.Rows

                Dim WRazonEmisor As String = rowTabla.Item(0)
                Dim WNCheque As String = rowTabla.Item(1)
                Dim WBancoEmisor As String = rowTabla.Item(2)
                Dim WImporte As Double = Val(rowTabla.Item(3))
                Dim AuxFechaPago As Date = rowTabla.Item(4)
                Dim WFechaPago As String = AuxFechaPago.ToString("dd/MM/yyyy")
                Dim WOrdFechaPago As String = ordenaFecha(WFechaPago)
                Dim WCuitEmisor As String = rowTabla.Item(5)
                Dim AuxFechaEmision As Date = rowTabla.Item(6)
                Dim WFechaEmision As String = AuxFechaEmision.ToString("dd/MM/yyyy")
                Dim WOrdFechaEmision As String = ordenaFecha(WFechaEmision)
                Dim WCaracterCheque As String = rowTabla.Item(7)
                Dim WModoCheque As String = rowTabla.Item(8)
                Dim WCuitEndoso As String = rowTabla.Item(9)
                Dim WRazonEndoso As String = rowTabla.Item(10)

                Dim WCLAVE As String = WNCheque & "-" & WCuitEmisor & "-" & formatonumerico(WImporte.ToString())

                If VerificarExiste(WCLAVE) Then
                    Cantidad_YaExistentes += 1
                    CambiarColor_en_Grilla(WNCheque, WCuitEmisor, WImporte, False)
                    Continue For
                End If

                SQLCnslt = "INSERT INTO Carga_ChequesE (Clave, NroCheque, BancoEmisor, Importe, FechaPago, OrdFechaPago, CuitEmisor, " _
                            & "Emisor_Razon, FechaEmisor , OrdFechaEmisor, Caracter_Cheque, Modo_Cheque, Endoso_Documento, Endoso_Razon, Marca_Usado) " _
                            & "VALUES('" & WCLAVE & "', '" & WNCheque & "', '" & WBancoEmisor & "', '" & formatonumerico(WImporte) & "', '" & WFechaPago & "', " _
                            & "'" & WOrdFechaPago & "', '" & WCuitEmisor & "', '" & WRazonEmisor & "', '" & WFechaEmision & "', '" & WOrdFechaEmision & "', " _
                            & "'" & WCaracterCheque & "', '" & WModoCheque & "', '" & WCuitEndoso & "', '" & WRazonEndoso & "', '" & "" & "')"

                ListaSQLCnslt.Add(SQLCnslt)

                Cantidad_Grabada += 1
                CambiarColor_en_Grilla(WNCheque, WCuitEmisor, WImporte, True)

            Next
            Try
                If ListaSQLCnslt.Count > 0 Then
                    ExecuteNonQueries("SurfactanSa", ListaSQLCnslt.ToArray())
                End If


            Catch ex As Exception
                MsgBox("No se puedieron grabar los cheques en la tabla.", vbExclamation)
                Exit Sub
            End Try

            With New CarteldeProcesados(Cantidad_Grabada, Cantidad_YaExistentes)
                .Show()
            End With
        Catch ex As Exception
            MsgBox("No se encontraron cheques en la tabla.", vbExclamation)
            Exit Sub
        End Try
        
        

    End Sub

    Private Sub CambiarColor_en_Grilla(ByVal WNCheque As String, ByVal WCuitEmisor As String, ByVal WImporte As Double, ByVal Accion As Boolean)
        For Each row As DataGridViewRow In dgv_Cheques.Rows
            With row
                If (.Cells(1).Value = WNCheque) And (.Cells(5).Value = WCuitEmisor) And (Val(.Cells(3).Value) = Val(WImporte)) Then
                    If Accion = True Then
                        row.DefaultCellStyle.BackColor = Color.Green
                        row.DefaultCellStyle.ForeColor = Color.White
                    Else
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White
                    End If

                End If
            End With
        Next
    End Sub

    Private Function VerificarExiste(ByVal WCLAVE As String)
        Dim SQLCnslt As String = "SELECT Clave FROM Carga_ChequesE WHERE Clave = '" & WCLAVE & "'"
        Dim RowCarga As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowCarga IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
