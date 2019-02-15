Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting

Public Class GraficoDiario
    Public Property Tabla As DataTable

    Public Property TablaGrilla As DataTable

    Public Property TablaConsolidados As DataTable

    Public Property Tipo As Integer

    Public Property Titulo As String

    Public Property SumarDiario As Boolean

    Public WColorBasico

    Private _wValoresDibujados As String()

    Private Sub Grafico_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        _wValoresDibujados = {Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}

        '_ProcesarGrafico()

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        If DataGridView1.Rows.Count > 0 Then
            WColorBasico = DataGridView1.Rows(0).DefaultCellStyle.BackColor
        End If

        With Me
            .Height = Configuration.ConfigurationManager.AppSettings("H")
            .Left = Configuration.ConfigurationManager.AppSettings("L")
            .Top = Configuration.ConfigurationManager.AppSettings("T")
            .Width = Configuration.ConfigurationManager.AppSettings("W")
        End With

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

        If Not _wValoresDibujados Is Nothing Then
            For i = 0 To _wValoresDibujados.Length - 1
                _wValoresDibujados(i) = Nothing
            Next
        End If

        Select Case Tipo
            Case 1
                _ProcesarMesAnteriorEntrLineas()
            Case -1 '2
                _ProcesarMesAnteriorEntrePeriodo()
            Case 2
                _ProcesarMesAnteriorEntrePeriodoConsolidado()
            Case Else
                Close()
        End Select


        If Not IsNothing(TablaGrilla) AndAlso TablaGrilla.Rows.Count > 0 Then
            TablaGrilla.DefaultView.Sort = "Linea , Tipo"

            Dim WTablaGrilla As New DataTable

            With WTablaGrilla.Columns

                .Add("Linea")
                .Add("DescLinea")
                .Add("Tipo")
                .Add("DescTipo")
                .Add("Fecha")
                .Add("Actual")
                .Add("MesAnterior")
                .Add("AnioAnterior")
                .Add("Acumulado")
                .Add("AcumuladoVentas")
                .Add("AcumuladoKilos").AutoIncrement = True

            End With

            Dim WRow As DataRow

            For Each row As DataRow In TablaGrilla.Rows

                With row

                    WRow = WTablaGrilla.NewRow

                    WRow.Item("Linea") = .Item("Linea")
                    WRow.Item("DescLinea") = _NombreLineaSegunNumero(.Item("Linea"))
                    WRow.Item("Tipo") = .Item("Tipo")
                    WRow.Item("Fecha") = .Item("Dia") & "/" & .Item("Mes") & "/" & .Item("Ano")
                    WRow.Item("DescTipo") = _DescripcionSegunTipo(.Item("Tipo"))
                    WRow.Item("Actual") = formatonumerico(.Item("Importe1"))
                    WRow.Item("MesAnterior") = formatonumerico(.Item("Importe2"))
                    WRow.Item("AnioAnterior") = formatonumerico(.Item("Importe3"))
                    WRow.Item("AcumuladoVentas") = formatonumerico(.Item("Importe4"))

                    WRow.Item("Acumulado") = WRow.Item("AcumuladoVentas")

                    WTablaGrilla.Rows.Add(WRow)

                End With

            Next

            Dim WVectow(2, 6) As Double

            For Each row As DataRow In WTablaGrilla.Rows
                Select Case Val(row.Item("Tipo"))
                    Case 1

                        WVectow(1, 1) += Val(formatonumerico(row.Item("Actual")))
                        WVectow(1, 2) += Val(formatonumerico(row.Item("MesAnterior")))
                        WVectow(1, 3) += Val(formatonumerico(row.Item("AnioAnterior")))
                        WVectow(1, 4) += Val(formatonumerico(row.Item("AcumuladoVentas")))
                        WVectow(1, 5) += Val(formatonumerico(row.Item("Acumulado")))

                    Case 2

                        WVectow(2, 1) += Val(formatonumerico(row.Item("Actual")))
                        WVectow(2, 2) += Val(formatonumerico(row.Item("MesAnterior")))
                        WVectow(2, 3) += Val(formatonumerico(row.Item("AnioAnterior")))
                        WVectow(2, 4) += Val(formatonumerico(row.Item("AcumuladoVentas")))
                        WVectow(2, 5) += Val(formatonumerico(row.Item("Acumulado")))

                    Case Else
                        Continue For
                End Select
            Next


            WRow = WTablaGrilla.NewRow

            With WRow

                .Item("Linea") = 99
                .Item("DescLinea") = "Consolidado"
                .Item("Tipo") = 99
                .Item("DescTipo") = ""
                .Item("Actual") = formatonumerico(WVectow(1, 1))
                .Item("MesAnterior") = formatonumerico(WVectow(1, 2))
                .Item("AnioAnterior") = formatonumerico(WVectow(1, 3))
                .Item("Acumulado") = formatonumerico(WVectow(1, 5))
                .Item("AcumuladoVentas") = formatonumerico(WVectow(1, 4))

            End With

            WTablaGrilla.Rows.Add(WRow)

            WRow = WTablaGrilla.NewRow

            With WRow

                .Item("Linea") = 99
                .Item("DescLinea") = "Consolidado"
                .Item("Tipo") = 99
                .Item("DescTipo") = ""
                .Item("Actual") = formatonumerico(WVectow(2, 1))
                .Item("MesAnterior") = formatonumerico(WVectow(2, 2))
                .Item("AnioAnterior") = formatonumerico(WVectow(2, 3))
                .Item("Acumulado") = formatonumerico(WVectow(2, 5))
                .Item("AcumuladoVentas") = formatonumerico(WVectow(2, 4))

            End With

            WTablaGrilla.Rows.Add(WRow)


            Select Case Tipo
                Case 1, 2

                    With DataGridView1

                        WTablaGrilla.DefaultView.Sort = "Linea ASC, Tipo ASC"

                        .DataSource = WTablaGrilla

                        For i = 4 To 10
                            .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Next

                        Dim Wtemp = ""

                        For Each row As DataGridViewRow In .Rows

                            row.DefaultCellStyle.BackColor = Color.White

                            If Wtemp <> row.Cells(1).Value Then
                                Wtemp = row.Cells(1).Value
                                Continue For
                            End If

                            row.Cells(1).Value = ""

                        Next

                        '.Columns(2).HeaderText = "Fecha"
                        .Columns(5).HeaderText = "Actual"
                        .Columns(6).HeaderText = "Mes Anterior"
                        .Columns(7).HeaderText = "Año Anterior"
                        .Columns(8).HeaderText = "Acumulado Diario"
                        .Columns(9).HeaderText = "Acumulado Ventas"

                        .Columns(0).Visible = False
                        .Columns(2).Visible = False
                        .Columns(4).Visible = False
                        .Columns(9).Visible = False
                        .Columns(10).Visible = False

                    End With

            End Select

        End If

    End Sub

    Private Sub _ProcesarMesAnteriorEntrePeriodoConsolidado()

        Dim WMes = ""
        Dim WSeries() As String = {"", "Actual", "Mes Anterior", "Año Anterior", "Acumulado " & Date.Now.ToString("dd/MM/yyyy")}

        Dim WLimiteColumnas As Integer = IIf(SumarDiario, 3, 4)

        For Each row As DataRow In Tabla.Rows

            For i = 1 To WLimiteColumnas

                WMes = ""
                WMes = WSeries(i)

                If Chart1.Series.IsUniqueName(WMes) Then
                    Chart1.Series.Add(WMes)
                End If

            Next

        Next
        Dim WTipo = ""
        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To WLimiteColumnas

                    WMes = ""

                    WTipo = _DescripcionSegunTipo(row.Item("Tipo"))

                    WMes = WSeries(i)

                    Dim WValor As Double = Val(formatonumerico(.Item("Importe" & i)))

                    If i > 3 Then
                        WValor = Val(formatonumerico(.Item("Importe4")))
                    ElseIf i = 1 And SumarDiario Then
                        WValor += Val(formatonumerico(.Item("Importe4")))
                    End If

                    Chart1.Series(WMes).Points.AddXY(WTipo, WValor)

                Next

            End With

        Next

        _HabilitarLabels()
    End Sub


    Private Sub _ProcesarMesAnteriorEntrePeriodo()

        Dim WMes = ""

        For Each row As DataRow In Tabla.Rows

            WMes = ""
            WMes = row.Item("Mes") & "/" & row.Item("Ano")

            If Chart1.Series.IsUniqueName(WMes) Then
                Chart1.Series.Add(WMes)
            End If

        Next

        For Each row As DataRow In Tabla.Rows

            With row

                WMes = ""
                WMes = row.Item("Mes") & "/" & row.Item("Ano")

                Chart1.Series(WMes).Points.AddXY(row.Item("Dia") & "/" & row.Item("Mes"), formatonumerico(.Item("Importe")))

            End With

        Next

        _HabilitarLabels()
    End Sub

    Private Sub _ProcesarMesAnteriorEntrLineas()

        Dim WMes = ""
        Dim WSeries() As String = {"", "Actual", "Mes Anterior", "Año Anterior", "Acumulado " & Date.Now.ToString("dd/MM/yyyy")}

        Dim WLimiteColumnas As Integer = IIf(SumarDiario, 3, 4)

        For Each row As DataRow In Tabla.Select("", "Tipo")

            For i = 1 To WLimiteColumnas

                WMes = ""
                WMes = _DescripcionSegunTipo(row.Item("Tipo")) & " - " & WSeries(i)

                If Chart1.Series.IsUniqueName(WMes) Then
                    Chart1.Series.Add(WMes)
                End If

            Next

        Next

        For Each row As DataRow In Tabla.Select("", "Tipo")

            With row

                For i = 1 To WLimiteColumnas

                    WMes = ""
                    WMes = _DescripcionSegunTipo(row.Item("Tipo")) & " - " & WSeries(i)

                    Dim WValor As Double = Val(formatonumerico(.Item("Importe" & i)))

                    If i > 3 Then
                        WValor = Val(formatonumerico(.Item("Importe4")))
                    ElseIf i = 1 And SumarDiario Then
                        WValor += Val(formatonumerico(.Item("Importe4")))
                    End If

                    Chart1.Series(WMes).Points.AddXY(_NombreLineaSegunNumero(.Item("Linea")), WValor)

                Next

            End With

        Next

        _HabilitarLabels()
    End Sub

    Private Sub _HabilitarLabels()

        For Each serie In Chart1.Series
            _LabelsComoPorcentaje()
        Next

        Dim gd As New Grid

        gd.LineWidth = 0

        With Chart1.ChartAreas(0)
            .AxisX.MajorGrid = gd
            .AxisX.Interval = 1
        End With

        With Chart1
            .Titles.Clear()
            .Titles.Add("Titulo")
            .Titles(0).Text = Titulo
            .Titles(0).Font = New Font(FontFamily.GenericSansSerif, 11, GraphicsUnit.Point)
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick

        _RedibujarDatos(e.RowIndex)

    End Sub

    Private Sub _RedibujarDatos(ByVal rowIndex As Integer)
        ComparacionesMensualesValorUnico._RegraficarConsolidado(DataGridView1.Rows(rowIndex).Cells("DescTipo").Value, True)
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = SeriesChartType.Line

            _LabelsComoPorcentaje()

        Next

    End Sub

    Private Sub _LabelsComoPorcentaje()
        Dim aux As Double

        Dim WValorComparativo() As Double = {0, 0}
        Dim WIndice As Short = 0

        aux = 0.0

        For i = 0 To Chart1.Series.Count - 1 Step 4

            Debug.Print("Indice " & i)

            WIndice = 0

            For Each p As DataPoint In Chart1.Series(i).Points

                WValorComparativo(WIndice) = p.YValues(0)
                WIndice += 1

                p.Label = formatonumerico(p.YValues(0))

            Next

            WIndice = 0

            For Each p As DataPoint In Chart1.Series(i + 1).Points

                aux = p.YValues(0)

                p.Label = formatonumerico(aux) & " (" & formatonumerico(((100 * aux) / WValorComparativo(WIndice)) - 100) & " %)"

                WIndice += 1

            Next

            WIndice = 0

            For Each p As DataPoint In Chart1.Series(i + 2).Points

                aux = p.YValues(0)

                p.Label = formatonumerico(aux) & " (" & formatonumerico(((100 * aux) / WValorComparativo(WIndice)) - 100) & " %)"

                WIndice += 1

            Next

            If Not SumarDiario Then
                WIndice = 0

                For Each p As DataPoint In Chart1.Series(i + 3).Points

                    aux = p.YValues(0)

                    p.Label = formatonumerico(aux) & " (" & formatonumerico(((100 * aux) / WValorComparativo(WIndice)) - 100) & " %)"

                    WIndice += 1

                Next
            End If

        Next

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = SeriesChartType.Pie

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

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        For Each serie As Series In Chart1.Series

            serie.ChartType = SeriesChartType.Column

            _LabelsComoPorcentaje()

        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("DELETE FROM ComandoII")
        Dim ZSQL = ""
        Dim WImporte1, WImporte2, WImporte3, WImporte4, WImporte5, WImporte6 As Double
        Dim WDia As String
        Dim WDatos(9, 2, 3) As String ' Linea, Ventas|Kilos, Actual|MesAnt|AñoAnt

        Try
            ' Limpiamos los datos que esten presentes con anterioridad.
            cn.ConnectionString = _ConectarA
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

            For Each row As DataGridViewRow In DataGridView1.Rows

                If Val(row.Cells("Linea").Value) > 9 Then Exit For

                WDatos(row.Cells("Linea").Value, row.Cells("Tipo").Value, 1) = formatonumerico(row.Cells(5).Value)
                WDatos(row.Cells("Linea").Value, row.Cells("Tipo").Value, 2) = formatonumerico(row.Cells(6).Value)
                WDatos(row.Cells("Linea").Value, row.Cells("Tipo").Value, 3) = formatonumerico(row.Cells(7).Value)

                WDia = row.Cells("Fecha").Value

            Next

            For i = 1 To 9


                If IsNothing(WDatos(i, 1, 1)) Then Continue For

                WImporte1 = IIf(IsNothing(WDatos(i, 1, 1)), 0, Val(WDatos(i, 1, 1)))
                WImporte2 = IIf(IsNothing(WDatos(i, 1, 2)), 0, Val(WDatos(i, 1, 2)))
                WImporte3 = IIf(IsNothing(WDatos(i, 1, 3)), 0, Val(WDatos(i, 1, 3)))
                WImporte4 = IIf(IsNothing(WDatos(i, 2, 1)), 0, Val(WDatos(i, 2, 1)))
                WImporte5 = IIf(IsNothing(WDatos(i, 2, 2)), 0, Val(WDatos(i, 2, 2)))
                WImporte6 = IIf(IsNothing(WDatos(i, 2, 3)), 0, Val(WDatos(i, 2, 3)))

                ZSQL = ""
                ZSQL = "INSERT INTO ComandoII (Tipo, Venta1, Venta2, Venta3, Kilos1, Kilos2, Kilos3, Impre1, Impre2, Impre3, Descripcion)"
                ZSQL &= " VALUES(" & i & ", " & Str$(WImporte1) & ", " & Str$(WImporte2) & ", " & Str$(WImporte3) & ", " & Str$(WImporte4) & ", " & Str$(WImporte5) & ", " & Str$(WImporte6) & ", '" & WDia & "', 'Mes Ant', 'Año Ant', '" & _NombreLineaSegunNumero(i) & "')"

                cm.CommandText = ZSQL
                cm.ExecuteNonQuery()

            Next


        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        With VistaPrevia
            .Reporte = New listacomandodiario
            .Imprimir()
        End With

    End Sub

    Private Sub _ImprimirGrafico()
        PrintDocument1.DefaultPageSettings.Landscape = True
        Chart1.Printing.PrintDocument = PrintDocument1 ' this enables the adding of other material to the page on which the chart is printed
        Chart1.Printing.Print(False) ' True/False -> show print dialog
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Chart1.Printing.PrintPaint(e.Graphics, New Rectangle(0, 0, Chart1.Width, Chart1.Height)) ' draw the chart
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        _ImprimirGrafico()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        _RedibujarDatos(e.RowIndex)

    End Sub

End Class