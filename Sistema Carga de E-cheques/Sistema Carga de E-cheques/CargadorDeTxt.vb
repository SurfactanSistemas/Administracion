Imports System.Globalization
Imports Util.Clases.Helper
Imports Util.Clases.Query
Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO



Public Class CargadorDeTxt

    Dim DragActivo As Boolean = False

    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub



    Private Sub btn_ObtenerDatos_Click(sender As Object, e As EventArgs) Handles btn_ObtenerDatos.Click
        Dim tablafinal As DataTable
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


    Private Function ListaFiltrada(ByVal Tabla As DataTable) As DataTable
        Dim TablaFiltrada As New DataTable
        With TablaFiltrada.Columns
            .Add("N.Cheque")
            .Add("BancoEmisor")
            .Add("FechaPago")
            .Add("CuitEmisor")
            .Add("FechaEmision")
            .Add("CaracterCheque")
            .Add("ModoCheque")
            .Add("CuitEndoso")
            .Add("RazonEndoso")
        End With

        Dim SQLCnslt As String = ""

        For Each rowTabla As DataRow In Tabla.Rows

            Dim WNCheque As String = rowTabla.Item(0)
            Dim WBancoEmisor As String = rowTabla.Item(1)
            Dim AuxFechaPago As Date = rowTabla.Item(2)
            Dim WFechaPago As String = AuxFechaPago.ToString("dd/MM/yyyy")
            Dim WOrdFechaPago As String = ordenaFecha(WFechaPago)
            Dim WCuitEmisor As String = rowTabla.Item(3)
            Dim AuxFechaEmision As Date = rowTabla.Item(4)
            Dim WFechaEmision As String = AuxFechaEmision.ToString("dd/MM/yyyy")
            Dim WOrdFechaEmision As String = ordenaFecha(WFechaEmision)
            Dim WCaracterCheque As String = rowTabla.Item(5)
            Dim WModoCheque As String = rowTabla.Item(6)
            Dim WCuitEndoso As String = rowTabla.Item(7)
            Dim WRazonEndoso As String = rowTabla.Item(8)


            SQLCnslt = ""
        Next

    End Function

    Private Sub RemoverDatosInesesarios(ByRef Tabla As DataTable)
        For i As Integer = 40 To 0 Step -1
            If i = 1 Or i = 2 Or i = 4 Or i = 5 Or i = 6 Or i = 7 Or i = 10 Or i = 20 Or i = 23 Or i = 24 Then
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
End Class