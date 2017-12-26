
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.DataVisualization

Public Class Grafico
    Public Property Tabla As DataTable

    Public Property TablaGrilla As DataTable

    Public Property Tipo As Integer

    Public Property Titulo As String

    Private Sub Grafico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ProcesarGrafico()

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

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

                If Tipo = 1 Then

                    .Columns(0).Visible = False
                    .Columns(2).Visible = False
                    .Columns(3).Visible = False

                Else

                    For Each row As DataGridViewRow In .Rows

                        If linea <> Trim(row.Cells(1).Value) Then
                            linea = Trim(row.Cells(1).Value)
                            Continue For
                        End If

                        row.Cells(1).Value = ""

                    Next

                End If


                '
                ' Cambiamos los nombres de las columnas con los valores de las fechas en las que se realizó la consulta.
                '

                If Tipo = 1 Then

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

                    Next
                End If

                If Tipo = 1 Then
                    .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Descending)
                    .CurrentCell = .Rows(0).Cells("Descripcion")
                Else
                    .Columns(0).Visible = False
                    .Columns(3).Visible = False
                    .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    .CurrentCell = .Rows(0).Cells(1)
                End If

                .Focus()

            End With

        End If

    End Sub

    Private Sub _ProcesarComparativoMensual()

        Dim wacu = 0.0

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

                        Chart1.Series(Microsoft.VisualBasic.Right(Trim(.Item("Titulo" & i)), 4)).Points.AddXY(.Item("Titulo" & i), wacu)

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAnual()

        Dim wacu = 0.0

        Titulo = "COMPARACION ANUAL"


        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To 12

                    wacu = 0.0

                    If Not IsDBNull(.Item("Valor" & i)) Then

                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))

                    End If

                    If wacu <> 0 Then

                        Chart1.Series(.Item("Titulo" & i).ToString).Points.AddXY(.Item(1), wacu)

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumuladoFamilia()

        Dim wacu = 0.0

        Titulo = "COMPARATIVO MENSUAL" & vbCrLf & " - " & Tabla.Rows(0).Item(1).ToString.Trim & " -"

        For Each row As DataRow In Tabla.Rows

            With row

                Chart1.Series.Add(.Item(2))

                For i = 1 To 12

                    wacu = 0.0

                    If Not IsDBNull(.Item("Valor" & i)) Then
                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))
                    End If


                    If wacu <> 0 Then

                        Chart1.Series(.Item(2).ToString).Points.AddXY(.Item(i + 15), wacu)

                    End If

                Next

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumulado()
        Dim wacu = 0.0

        Titulo = "CONSOLIDADO" & vbCrLf & " - "

        Titulo &= Tabla.Rows(0).Item("Titulo") & " -"

        For Each row As DataRow In Tabla.Rows
            If Not IsDBNull(row.Item("Descripcion")) AndAlso Chart1.Series.IsUniqueName(row.Item("Descripcion")) Then
                Chart1.Series.Add(row.Item("Descripcion"))
            End If
        Next

        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To 12

                    If Not IsDBNull(.Item("Valor" & i)) Then
                        wacu = Val(Helper.formatonumerico(.Item("Valor" & i)))
                    End If

                    If wacu <> 0 And (Not IsDBNull(.Item("Descripcion")) AndAlso Trim(.Item("Descripcion")) <> "") Then
                        Chart1.Series(.Item("Descripcion")).Points.AddXY(.Item("Titulo" & i), wacu)
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

        If Tipo = 1 Then

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

            Dim aux = 0.0, WA = "", WLinea = ""

            For Each r As DataGridViewRow In DataGridView1.Rows

                WA = IIf(IsDBNull(r.Cells(1).Value), "", r.Cells(1).Value)

                If WA <> WLinea And WA <> "" Then
                    WLinea = WA
                End If

                If r.Cells(2).Value = valor Then

                    aux = 0.0

                    For i = 4 To 15

                        aux += IIf(IsDBNull(r.Cells(i).Value), 0, r.Cells(i).Value)

                    Next

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

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            _LabelsComoPorcentaje(serie)

        Next

    End Sub

    Private Sub _LabelsComoPorcentaje(ByVal serie As Series)
        Dim aux As Double

        aux = 0.0

        If serie.Points.Count > 1 Then
            aux = serie.Points.Sum(Function(p) p.YValues(0))
        End If

        For Each p As DataPoint In serie.Points

            With p
                .IsValueShownAsLabel = True
                .CustomProperties = "DrawSideBySide=True"
                If Chart1.Series(serie.Name).Points.Count > 1 Then
                    .Label = "% " & Helper.formatonumerico((.YValues(0) * 100) / aux)
                End If
            End With

        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each serie As Series In Chart1.Series

            serie.ChartType = DataVisualization.Charting.SeriesChartType.Pie

            Dim aux = 0

            For Each p As DataPoint In serie.Points
                With p
                    .IsValueShownAsLabel = True
                    .CustomProperties = "DrawSideBySide=True"
                    If Chart1.Series(serie.Name).Points.Count > 1 Then
                        .Label = DataGridView1.Columns(4 + aux).HeaderText
                        aux += 1
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
End Class