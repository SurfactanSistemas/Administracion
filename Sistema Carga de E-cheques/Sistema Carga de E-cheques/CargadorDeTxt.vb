Imports Util.Clases.Helper
Imports Util.Clases.Query
Public Class CargadorDeTxt

    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub

    Private Sub CargadorDeTxt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_Archivo.Text = "C:\Users\soporte3\Desktop\lucas91000075943309202012181152518740000251841507314ConsultaChequesRecibidos.txt"
    End Sub

    Private Sub btn_ObtenerDatos_Click(sender As Object, e As EventArgs) Handles btn_ObtenerDatos.Click
        If Trim(txt_Archivo.Text) <> "" Then
            Dim Tabla = txt_A_Datatable(txt_Archivo.Text, True, ";")

            RemoverDatosInesesarios(Tabla)

            Dim ChequesAgregar As DataTable = ListaFiltrada(Tabla)

            ' With ChequesAgregar.Columns
            '     .Add("chk")
            ' End With

            dgv_Cheques.DataSource = Tabla
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
            Dim WOrdFechaPago As String = ordenafecha(WFechaPago)
            Dim WCuitEmisor As String = rowTabla.Item(3)
            Dim AuxFechaEmision As Date = rowTabla.Item(4)
            Dim WFechaEmision As String = AuxFechaEmision.ToString("dd/MM/yyyy")
            Dim WOrdFechaEmision As String = ordenafecha(WFechaEmision)
            Dim WCaracterCheque As String = rowTabla.Item(5)
            Dim WModoCheque As String = rowTabla.Item(6)
            Dim WCuitEndoso As String = rowTabla.Item(7)
            Dim WRazonEndoso As String = rowTabla.Item(8)


            SQLCnslt = ""
        Next

    End Function

    Private Sub RemoverDatosInesesarios(ByRef Tabla As DataTable)
        For i As Integer = 40 To 0 Step -1
            If i = 1 Or i = 2 Or i = 5 Or i = 6 Or i = 7 Or i = 10 Or i = 20 Or i = 23 Or i = 24 Then
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



End Class