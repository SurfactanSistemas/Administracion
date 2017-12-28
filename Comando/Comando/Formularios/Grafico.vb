
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.DataVisualization

Public Class Grafico
    Public Property Tabla As DataTable

    Public Property TablaGrilla As DataTable

    Public Property TablaConsolidados As DataTable

    Public Property Tipo As Integer

    Public Property Titulo As String

    Public WColorBasico

    Private _wValoresDibujados As String()

    Private Sub Grafico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _wValoresDibujados = {Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}

        '_ProcesarGrafico()

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        If DataGridView1.Rows.Count > 0 Then
            WColorBasico = DataGridView1.Rows(0).DefaultCellStyle.BackColor
        End If

    End Sub

    Public Sub _ProcesarGrafico()

        If Tabla.Rows.Count = 0 Then
            MsgBox("No hay datos que graficar.", MsgBoxStyle.Exclamation)
            Close()
            Exit Sub
        End If

        With Chart1
            .Series.Clear()
            .ResetAutoValues()
        End With

        For i = 0 To _wValoresDibujados.Length - 1
            _wValoresDibujados(i) = Nothing
        Next

        Select Case Tipo
            Case 1
                _ProcesarAcumulado()
            Case 2
                _ProcesarAcumuladoFamilia()
            Case 3
                _ProcesarAnual()
            Case 4
                _ProcesarComparativoMensual()
            Case Else
                Close()
        End Select

        TablaGrilla.DefaultView.Sort = "Tipo ASC, Corte ASC"

        If TablaGrilla.Rows.Count > 0 Then

            With DataGridView1

                For Each c As DataGridViewColumn In .Columns
                    c.Visible = True
                Next

                .DataSource = TablaGrilla.DefaultView

                Dim linea = ""

                If Tipo = -1 Then

                    .Columns(0).Visible = False
                    .Columns(2).Visible = False
                    .Columns(3).Visible = False

                Else
                    Dim aux
                    For Each row As DataGridViewRow In .Rows
                        aux = row.Cells(1).Value
                        If Not IsDBNull(aux) AndAlso linea <> Trim(aux) Then
                            linea = Trim(row.Cells(1).Value)
                            Continue For
                        End If

                        row.Cells(1).Value = ""

                    Next

                End If


                '
                ' Cambiamos los nombres de las columnas con los valores de las fechas en las que se realizó la consulta.
                '

                If Tipo = -1 Then

                    For i = 4 To 15

                        .Columns(i).HeaderText = "- - -"

                        If Not IsDBNull(DataGridView1.Rows(1).Cells(i + 12).Value) Then
                            .Columns(i).HeaderText = Trim(DataGridView1.Rows(1).Cells(i + 12).Value)
                        End If

                        .Columns(i + 12).Visible = False
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Next

                Else

                    For i = 4 To 15

                        .Columns(i).HeaderText = "- - -"

                        If Not IsDBNull(DataGridView1.Rows(0).Cells(i + 12).Value) Then
                            .Columns(i).HeaderText = Trim(DataGridView1.Rows(0).Cells(i + 12).Value)
                        End If

                        .Columns(i + 12).Visible = False
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(i).Width = 80

                    Next
                End If

                If Tipo = -1 Then
                    .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Descending)
                    .CurrentCell = .Rows(0).Cells("Descripcion")
                Else
                    .Columns(0).Visible = False
                    .Columns(3).Visible = False

                    .Columns(2).Width = 70

                    With .Columns(1)
                        .MinimumWidth = 90
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    End With

                    .Columns(.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(.Columns.Count - 1).HeaderText = "Total"

                    .Columns(1).HeaderText = "Linea"
                    .Columns(2).HeaderText = "Concepto"

                    .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    .CurrentCell = .Rows(0).Cells(1)
                End If


                .Focus()

            End With
            
            If Tipo = 1 Or Tipo = 3 Then
                '_MostrarConsolidados()
                _ProcesarAcumulados2(DataGridView1.Rows)
            End If

            For Each row As DataGridViewRow In DataGridView1.Rows

                row.DefaultCellStyle.BackColor = WColorBasico

                If Not IsDBNull(row.Cells("Titulo").Value) AndAlso _wValoresDibujados.Contains(row.Cells("Titulo").Value) Then
                    row.DefaultCellStyle.BackColor = Color.LightBlue
                End If

            Next

        End If

    End Sub

    Private Sub _MostrarConsolidados()

        _LimpiarConsolidadosAgregadosAnteriormente()

        For Each _str As String In From _str1 In _wValoresDibujados Where Not IsNothing(_str1)
            _ProcesarAcumulados(_str)
        Next

    End Sub

    Private Sub _LimpiarConsolidadosAgregadosAnteriormente()

        If DataGridView1.Rows.Count > TablaGrilla.Rows.Count Then

            Dim aux As DataGridViewRow

            For i = TablaGrilla.Rows.Count To DataGridView1.Rows.Count - 1

                aux = DataGridView1.Rows(i)

                DataGridView1.Rows.Remove(aux)

            Next

        End If

    End Sub

    Private Sub _ProcesarAcumulados2(ByVal _rows As DataGridViewRowCollection)
        Dim WFilaVenta = 0, WFilaKilos = 0, WFilaPedidos = 0, WFilaAtrasos = 0
        Dim WVenta = 0.0, WKilos = 0.0, WPedidos = 0.0, WAtrasos = 0.0
        Dim valorCelda = ""
        Dim r As DataGridViewRow

        WFilaVenta = _rows.Count - 4
        WFilaKilos = _rows.Count - 3
        WFilaPedidos = _rows.Count - 2
        WFilaAtrasos = _rows.Count - 1

        With DataGridView1

            For i = 4 To 15

                .Rows(WFilaVenta).Cells(i).Value = 0
                .Rows(WFilaKilos).Cells(i).Value = 0
                .Rows(WFilaPedidos).Cells(i).Value = 0
                .Rows(WFilaAtrasos).Cells(i).Value = 0

            Next

        End With

        For Each row As DataGridViewRow In _rows
            valorCelda = ""
            With row

                Select Case row.Index
                    Case WFilaVenta, WFilaKilos, WFilaPedidos, WFilaAtrasos
                        Continue For
                End Select

                If Not IsDBNull(.Cells("Titulo").Value) Then
                    valorCelda = Trim(.Cells("Titulo").Value)
                End If

                Select Case UCase(valorCelda)
                    Case "VENTAS U$S"
                        r = DataGridView1.Rows(WFilaVenta)
                        For i = 4 To 15
                            WVenta = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WVenta = Val(Helper.formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WVenta += Val(Helper.formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(Helper.formatonumerico(WVenta))
                        Next

                    Case "KILOS"

                        r = DataGridView1.Rows(WFilaKilos)
                        For i = 4 To 15
                            WKilos = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WKilos = Val(Helper.formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WKilos += Val(Helper.formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(Helper.formatonumerico(WKilos))
                        Next

                    Case "PEDIDOS"

                        r = DataGridView1.Rows(WFilaPedidos)
                        For i = 4 To 15
                            WPedidos = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WPedidos = Val(Helper.formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WPedidos += Val(Helper.formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(Helper.formatonumerico(WPedidos))
                        Next

                    Case "ATRASO"

                        r = DataGridView1.Rows(WFilaAtrasos)
                        For i = 4 To 15
                            WAtrasos = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WAtrasos = Val(Helper.formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WAtrasos += Val(Helper.formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(Helper.formatonumerico(WAtrasos))
                        Next
                End Select

            End With

            With DataGridView1
                .Rows(WFilaVenta).Cells("Titulo").Value = "Ventas U$S"
                .Rows(WFilaVenta).Cells("Descripcion").Value = "Consolidado"
                .Rows(WFilaKilos).Cells("Titulo").Value = "Kilos"
                .Rows(WFilaPedidos).Cells("Titulo").Value = "Pedidos"
                .Rows(WFilaAtrasos).Cells("Titulo").Value = "Atrasos"

            End With

        Next
    End Sub

    Private Sub _ProcesarAcumulados(ByVal str As String)

        Dim aux = DataGridView1.DataSource
        Dim WTabla As DataTable

        If TypeOf aux Is DataView Then
            WTabla = aux.toTable.Copy
        ElseIf TypeOf aux Is DataTable Then
            WTabla = aux.Copy
        Else
            Exit Sub
        End If

        WTabla.TableName = "Consolidados"

        Dim _r() As DataRow = TablaConsolidados.Select("Descripcion = '" & str & "'")

        If _r.Count > 0 Then

            For i = 0 To _r.Count - 1
                Dim WR As DataRow = WTabla.NewRow
                WR = _r(i)

                WR.Item("Titulo") = WR.Item("Descripcion")
                WR.Item("Descripcion") = "Consolidado"

                WTabla.ImportRow(WR)
            Next

            DataGridView1.DataSource = WTabla

        End If

    End Sub

    Private Sub _ProcesarComparativoMensual()

        Dim wacu = 0.0
        Dim WIndice = 0
        Dim aux = ""

        Titulo = "COMPARATIVO ENTRE PERIODOS" & vbCrLf & " - "

        For Each row As DataRow In Tabla.Rows

            With row


                For i = 1 To 12
                    If Not IsDBNull(.Item("Titulo" & i)) AndAlso Chart1.Series.IsUniqueName(Microsoft.VisualBasic.Right(Trim(.Item("Titulo" & i)), 4)) Then

                        Chart1.Series.Add(Microsoft.VisualBasic.Right(Trim(.Item("Titulo" & i)), 4))

                    End If
                Next


            End With

        Next

        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To 12

                    wacu = 0.0

                    If Not IsDBNull(.Item("Valor" & i)) Then

                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))

                    End If

                    If wacu <> 0 Then

                        aux = Microsoft.VisualBasic.Right(Trim(.Item("Titulo" & i)), 4)

                        Chart1.Series(aux).Points.AddXY(.Item("Titulo" & i), wacu)

                        If Not _wValoresDibujados.Contains(aux) Then
                            _wValoresDibujados(WIndice) = aux
                            WIndice += 1
                        End If

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAnual()

        Dim wacu = 0.0
        Dim WIndice = 0

        Titulo = "COMPARACION ANUAL"

        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To 12

                    wacu = 0.0

                    If Not IsDBNull(.Item("Valor" & i)) Then

                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))

                    End If

                    If wacu <> 0 Then

                        If Not IsDBNull(.Item("Titulo" & i)) AndAlso Chart1.Series.IsUniqueName(.Item("Titulo" & i)) Then
                            Chart1.Series.Add(.Item("Titulo" & i))
                        End If

                        Chart1.Series(.Item("Titulo" & i).ToString).Points.AddXY(.Item(1), wacu)

                        If Not _wValoresDibujados.Contains(.Item("Titulo" & i)) Then

                            _wValoresDibujados(WIndice) = .Item("Titulo" & i)
                            WIndice += 1

                        End If

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumuladoFamilia()

        Dim wacu = 0.0
        Dim WIndice = 0


        Titulo = Tabla.Rows(0).Item(1).ToString.Trim & vbCrLf & " - " & Tabla.Rows(0).Item(16).ToString.Trim

        For i = 27 To 16 Step -1

            If Not IsDBNull(Tabla.Rows(0).Item(i)) Then
                Titulo &= " al " & Tabla.Rows(0).Item(i).ToString.Trim & " -"
                Exit For
            End If

        Next

        For Each row As DataRow In Tabla.Rows

            With row

                If (Not IsDBNull(.Item(2)) And Not IsDBNull(.Item(1))) AndAlso Chart1.Series.IsUniqueName(.Item(2) & " (" & .Item(1) & ")") Then
                    Chart1.Series.Add(.Item(2) & " (" & .Item(1) & ")")
                End If

                For i = 1 To 12

                    wacu = 0.0

                    If Not IsDBNull(.Item("Valor" & i)) Then
                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))
                    End If


                    If wacu <> 0 Then

                        Chart1.Series((.Item(2) & " (" & .Item(1) & ")").ToString).Points.AddXY(.Item(i + 15), wacu)

                        If Not _wValoresDibujados.Contains(.Item(1)) Then
                            _wValoresDibujados(WIndice) = .Item(1)
                            WIndice += 1
                        End If

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumulado()
        Dim wacu = 0.0
        Dim WIndice = 0

        Titulo = "CONSOLIDADO" & vbCrLf & " - "

        Titulo &= Tabla.Rows(0).Item("Titulo") & " -"

        For Each row As DataRow In Tabla.Rows
            If Not IsDBNull(row.Item(1)) AndAlso Chart1.Series.IsUniqueName(row.Item(1)) Then
                Chart1.Series.Add(row.Item(1))
            End If
        Next

        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To 12

                    If Not IsDBNull(.Item("Valor" & i)) Then
                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))
                    End If

                    If wacu <> 0 And (Not IsDBNull(.Item(1)) AndAlso Trim(.Item(1)) <> "") Then
                        Chart1.Series(.Item(1)).Points.AddXY(.Item("Titulo" & i), wacu)

                        If Not _wValoresDibujados.Contains(.Item(1)) Then
                            _wValoresDibujados(WIndice) = .Item(1)
                            WIndice += 1
                        End If

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()
    End Sub

    Private Sub _HabilitarLabels()

        For Each serie In Chart1.Series
            _LabelsComoPorcentaje(serie)
        Next

        Dim gd As New Charting.Grid

        gd.LineWidth = 0

        With Chart1.ChartAreas(0)
            .AxisX.MajorGrid = gd
            .AxisX.Interval = 1
        End With

        With Chart1
            .Titles.Clear()
            .Titles.Add("Titulo")
            .Titles(0).Text = Titulo
            .Titles(0).Font = New Font(FontFamily.GenericSansSerif, 12, GraphicsUnit.Point)
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        With ComparacionesMensualesValorUnico
            .WindowState = FormWindowState.Normal
            .Focus()
            .txtMesDesde.Focus()
        End With

    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick

        If Tipo = -1 Then

            Dim tabla = TablaGrilla.DataSet.Tables(1).Select("", "Descripcion DESC")

            With Chart1

                .Series.Clear()
                .ResetAutoValues()
            End With


            Chart1.Series.Add(tabla(e.RowIndex).Item(1))

            For i = 4 To 15

                If Not IsDBNull(tabla(e.RowIndex).Item(i)) AndAlso tabla(e.RowIndex).Item(i) <> 0 Then
                    Chart1.Series(tabla(e.RowIndex).Item(1).ToString).Points.AddXY(tabla(e.RowIndex).Item(i + 12), tabla(e.RowIndex).Item(i))
                End If

            Next

            _HabilitarLabels()

        ElseIf Tipo = 3 Then

            With Chart1

                .Series.Clear()
                .ResetAutoValues()

            End With

            Dim valor = ""

            valor = DataGridView1.CurrentRow.Cells(2).Value

            Chart1.Series.Add(valor)

            Dim aux = 0.0, WA = "", WLinea = "", WAuxi = ""

            For Each r As DataGridViewRow In DataGridView1.Rows

                WA = IIf(IsDBNull(r.Cells(1).Value), "", r.Cells(1).Value)

                If WA <> WLinea And WA <> "" Then
                    WLinea = WA
                End If

                r.DefaultCellStyle.BackColor = WColorBasico

                WAuxi = IIf(IsDBNull(r.Cells(2).Value), "", r.Cells(2).Value)

                If WAuxi = valor Then

                    aux = 0.0

                    For i = 4 To 15

                        aux += IIf(IsDBNull(r.Cells(i).Value), 0, r.Cells(i).Value)

                    Next

                    Chart1.Series(valor).Points.AddXY(WLinea, aux)

                    r.DefaultCellStyle.BackColor = Color.LightBlue

                End If

            Next

            _HabilitarLabels()

        ElseIf Tipo = 2 Then


            With Chart1

                .Series.Clear()
                .ResetAutoValues()

            End With

            Dim valor = ""

            valor = DataGridView1.CurrentRow.Cells(2).Value

            Dim aux = 0.0, WA = "", WLinea = ""

            For Each r As DataGridViewRow In DataGridView1.Rows

                WA = IIf(IsDBNull(r.Cells(2).Value), "", r.Cells(2).Value)

                If WA <> WLinea And WA <> "" Then
                    WLinea = WA
                End If

                r.DefaultCellStyle.BackColor = WColorBasico

                If r.Cells(2).Value = valor Then

                    If Chart1.Series.IsUniqueName(WLinea) Then
                        Chart1.Series.Add(WLinea)
                    End If

                    aux = 0.0

                    For i = 4 To 15

                        aux = IIf(IsDBNull(r.Cells(i).Value), 0, r.Cells(i).Value)

                        If Not IsDBNull(r.Cells(i + 12).Value) Then
                            Chart1.Series(WLinea).Points.AddXY(r.Cells(i + 12).Value, aux)
                        End If

                    Next

                    r.DefaultCellStyle.BackColor = Color.LightBlue

                End If

            Next

            _HabilitarLabels()


        ElseIf Tipo = 1 Then

            With Chart1

                .Series.Clear()
                .ResetAutoValues()

            End With

            Dim valor = ""

            valor = DataGridView1.CurrentRow.Cells(2).Value

            Dim aux = 0.0, WLinea = "", aux2 = ""
            
            For i = 4 To 15

                aux = 0.0
                WLinea = ""
                aux2 = ""

                For Each r As DataGridViewRow In DataGridView1.Rows

                    r.DefaultCellStyle.BackColor = WColorBasico

                    aux2 = IIf(IsDBNull(r.Cells(2).Value), "", r.Cells(2).Value)

                    If aux2 = valor Then

                        If Chart1.Series.IsUniqueName(valor) Then
                            Chart1.Series.Add(valor)
                        End If

                        aux += IIf(IsDBNull(r.Cells(i).Value), 0, r.Cells(i).Value)

                        If Not IsDBNull(r.Cells(i + 12).Value) Then
                            WLinea = r.Cells(i + 12).Value
                        End If

                        r.DefaultCellStyle.BackColor = Color.LightBlue

                    End If

                Next

                If Trim(WLinea) <> "" Then
                    Chart1.Series(valor).Points.AddXY(WLinea, aux)
                End If

            Next

            _HabilitarLabels()

        Else


            Dim tabla = TablaGrilla.DataSet.Tables(1).Select("", "Descripcion DESC")

            With Chart1

                .Series.Clear()
                .ResetAutoValues()

            End With

            Chart1.Series.Add(tabla(e.RowIndex).Item(2))

            For i = 4 To 15

                If Not IsDBNull(tabla(e.RowIndex).Item(i)) AndAlso tabla(e.RowIndex).Item(i) <> 0 Then
                    Chart1.Series(tabla(e.RowIndex).Item(2).ToString).Points.AddXY(tabla(e.RowIndex).Item(i + 12), tabla(e.RowIndex).Item(i))
                End If

            Next

            _HabilitarLabels()

        End If

        If Tipo = 1 Or Tipo = 3 Then

            For i = 0 To _wValoresDibujados.Length - 1
                _wValoresDibujados(i) = Nothing
            Next

            _wValoresDibujados(0) = DataGridView1.CurrentRow.Cells(2).Value

            '_MostrarConsolidados()

            _ProcesarAcumulados2(DataGridView1.Rows)

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            _LabelsComoPorcentaje(serie)

        Next

    End Sub

    Private Sub _LabelsComoPorcentaje(ByVal serie As Series)
        Dim aux As Double
        Dim WValores(2, 12)
        Dim WAuxi = 0

        aux = 0.0

        If serie.Points.Count > 1 Then
            aux = serie.Points.Sum(Function(p) p.YValues(0))
        End If

        ' Seguir trabajando en las leyendas de las diferencias.
        If Tipo = -1 Then

            'Dim valorActual = 0.0, valorPeriodoPasado = 0.0

            'valorActual = Val(Helper.formatonumerico(.YValues(0)))
            'valorPeriodoPasado = Val(Helper.formatonumerico(.YValues(1)))

            '.Label = "% " & Helper.formatonumerico(((valorActual / valorPeriodoPasado) - 1) * 100)

        Else

            Dim WConPorce() = {"VENTAS U$S", "KILOS", "PEDIDOS"}
            Dim ComoPorce = False

            For Each p As DataPoint In serie.Points

                With p
                    .IsValueShownAsLabel = True
                    .CustomProperties = "DrawSideBySide=True"
                    If Chart1.Series(serie.Name).Points.Count > 1 Then

                        ComoPorce = False

                        For i = 0 To WConPorce.Length - 1
                            If serie.Name.Contains(WConPorce(i)) Then
                                ComoPorce = True
                                Exit For
                            End If
                        Next

                        If ComoPorce Then
                            .Label = "% " & Helper.formatonumerico((.YValues(0) * 100) / aux)
                        Else
                            .Label = Helper.formatonumerico(.YValues(0))
                        End If

                    End If

                End With

            Next

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = DataVisualization.Charting.SeriesChartType.Pie

            For Each p As DataPoint In serie.Points
                With p
                    .IsValueShownAsLabel = True
                    .CustomProperties = "DrawSideBySide=True"
                    If Chart1.Series(serie.Name).Points.Count > 1 Then
                        p.Label = p.AxisLabel & " (" & p.Label & ")"
                    End If
                End With
            Next

        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = DataVisualization.Charting.SeriesChartType.Column

            _LabelsComoPorcentaje(serie)

        Next
    End Sub

    'Private Sub DataGridView1_ColumnHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseDoubleClick
    '    MsgBox(DataGridView1.Columns(e.ColumnIndex).Width)
    'End Sub
End Class