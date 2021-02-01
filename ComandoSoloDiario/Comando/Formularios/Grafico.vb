
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Grafico
    Public Property Tabla As DataTable

    Public Property TablaGrilla As DataTable

    Public Property TablaConsolidados As DataTable

    Public Property Tipo As Integer

    Public Property Titulo As String
    Public Property ComparativoAnualizado As Boolean = False

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
            Case 5
                _ProcesarAcumulado3()
            Case Else
                Close()
        End Select

        If TablaGrilla IsNot Nothing Then
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
                        .Sort(.Columns(1), ListSortDirection.Descending)
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

                        .Sort(.Columns(0), ListSortDirection.Ascending)
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
                                WVenta = Val(formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WVenta += Val(formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(formatonumerico(WVenta))
                        Next

                    Case "KILOS"

                        r = DataGridView1.Rows(WFilaKilos)
                        For i = 4 To 15
                            WKilos = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WKilos = Val(formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WKilos += Val(formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(formatonumerico(WKilos))
                        Next

                    Case "PEDIDOS"

                        r = DataGridView1.Rows(WFilaPedidos)
                        For i = 4 To 15
                            WPedidos = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WPedidos = Val(formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WPedidos += Val(formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(formatonumerico(WPedidos))
                        Next

                    Case "ATRASO"

                        r = DataGridView1.Rows(WFilaAtrasos)
                        For i = 4 To 15
                            WAtrasos = 0.0

                            If Not IsDBNull(r.Cells(i).Value) Then
                                WAtrasos = Val(formatonumerico(r.Cells(i).Value))
                            End If

                            If Not IsDBNull(.Cells(i).Value) Then

                                WAtrasos += Val(formatonumerico(.Cells(i).Value))

                            End If

                            r.Cells(i).Value = Val(formatonumerico(WAtrasos))
                        Next
                End Select

            End With

            With DataGridView1
                .Rows(WFilaVenta).Cells("Titulo").Value = "Ventas U$S"
                .Rows(WFilaVenta).Cells("Descripcion").Value = "Consolidado"
                .Rows(WFilaKilos).Cells("Titulo").Value = "Kilos"
                .Rows(WFilaPedidos).Cells("Titulo").Value = "Pedidos"
                .Rows(WFilaAtrasos).Cells("Titulo").Value = "Atraso"

            End With

        Next
    End Sub

    Private Sub _ProcesarComparativoMensual()

        Dim wacu = 0.0
        Dim WIndice = 0, WIndice2 = 0, WIndice3 = 0, WIndiceLineas = 0
        Dim aux = ""
        Dim WValores(9) As String
        Dim WLineas(9) As String
        Dim WSeries() As String

        ReDim WSeries(Tabla.Rows.Count)

        Titulo = "COMPARATIVO ENTRE PERIODOS" & vbCrLf & " - "

        If Tabla.Rows.Count > 0 Then

            For i = 0 To Tabla.Rows.Count - 1

                If Not IsDBNull(Tabla.Rows(i).Item(1)) AndAlso Not WLineas.Contains(Tabla.Rows(i).Item(1)) Then

                    WLineas(WIndiceLineas) = Tabla.Rows(i).Item(1)
                    WIndiceLineas += 1

                End If

            Next

            For Each wl In From wl1 In WLineas Where Not IsNothing(wl1)
                Titulo &= wl & ", "
            Next

            Titulo = Titulo.Substring(0, Trim(Titulo).Length - 1)

            Titulo = ReplaceLastComma(Titulo)

            Titulo &= " -" & vbCrLf & " - "

            Titulo &= "Meses: " & _Left(Tabla.Rows(0).Item(16), 2) & " Al "

            Dim WUltimoMes = 0
            For i = 27 To 16 Step -1

                If Not IsDBNull(Tabla.Rows(0).Item(i)) Then

                    Titulo &= _Left(Tabla.Rows(0).Item(i), 2)
                    WUltimoMes = i
                    Exit For

                End If

            Next

            Titulo &= " -" & vbCrLf & "- Periodos: " & _Right(Tabla.Rows(0).Item(16), 4)

            For i = 1 To Tabla.Rows.Count - 1

                If Not Titulo.Contains(_Right(Tabla.Rows(i).Item(WUltimoMes), 4)) Then Titulo &= ", " & _Right(Tabla.Rows(i).Item(WUltimoMes), 4)

            Next

            Titulo &= " -" & vbCrLf

            Titulo = ReplaceLastComma(Titulo)

        End If

        ' Determinamos las Series.
        WIndice3 = 0

        For Each _row As DataRow In Tabla.Rows

            aux = "Período: " & _row.Item("Titulo1")

            For i = 27 To 16 Step -1

                If Not IsDBNull(_row.Item(i)) Then

                    aux &= " al " & _row.Item(i)

                    Exit For
                End If

            Next

            WSeries(WIndice3) = aux
            WIndice3 += 1
        Next

        Chart1.Series.Clear()

        For i = 0 To WIndice3 - 1

            If Chart1.Series.IsUniqueName(WSeries(i)) Then

                Chart1.Series.Add(WSeries(i))

            End If

        Next

        Dim ztemp = ""
        WIndice3 = 0

        For Each row As DataRow In Tabla.Rows

            With row

                If row.Item("Titulo") = "Costo" Then Continue For

                For i = 1 To 12

                    'If i = 12 Then Stop
                    
                    If Not ComparativoAnualizado Then wacu = 0.0

                    If Not IsDBNull(.Item("Valor" & i)) Then

                        wacu = Val(formatonumerico(.Item("Valor" & i)))

                    End If

                    'If wacu <> 0 Then
                    ztemp = IIf(IsDBNull(.Item("Titulo" & i)), "", .Item("Titulo" & i))

                    aux = Microsoft.VisualBasic.Right(Trim(ztemp), 4)

                    If ztemp = "" Then
                        Exit For
                    End If

                    If Not ComparativoAnualizado Then Chart1.Series(WSeries(WIndice3)).Points.AddXY(ztemp, wacu)

                    If Not WValores.Contains(.Item(2)) Then

                        WValores(WIndice2) = .Item(2)

                        WIndice2 += 1
                    End If

                    If ComparativoAnualizado AndAlso Trim(OrDefault(WValores(WIndice2 - 1), "")) <> "" Then ztemp = WValores(WIndice2 - 1)

                    If Not _wValoresDibujados.Contains(.Item(2)) Then
                        _wValoresDibujados(WIndice) = .Item(2)

                        WIndice += 1
                    End If

                    'End If

                Next

            End With

            If ComparativoAnualizado Then Chart1.Series(WSeries(WIndice3)).Points.AddXY(ztemp, wacu)

            wacu = 0.0
            WIndice3 += 1
        Next

        Titulo &= "( "

        For i = 0 To WValores.Length - 1
            If Not IsNothing(WValores(i)) Then
                Titulo &= WValores(i) & ","
            End If
        Next

        Titulo = Titulo.Substring(0, Titulo.Length - 1) & " )"

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAnual()

        Dim wacu = 0.0
        Dim WIndice = 0

        If Tabla.Rows.Count > 0 Then
            Titulo = "COMPARACION ANUAL" & vbCrLf & " - " & Tabla.Rows(0).Item(2) & " -" & vbCrLf & "( "
        End If

        For Each row As DataRow In Tabla.Rows

            With row

                For i = 1 To 12

                    If Not IsDBNull(.Item("Titulo" & i)) AndAlso .Item("Titulo" & i) = "Costo" Then Continue For

                    wacu = 0.0



                    If Not IsDBNull(.Item("Valor" & i)) Then

                        wacu = Val(formatonumerico(.Item("Valor" & i)))

                    End If

                    'If wacu <> 0 Then

                    If Not IsDBNull(.Item("Titulo" & i)) AndAlso Chart1.Series.IsUniqueName(.Item("Titulo" & i)) Then
                        Chart1.Series.Add(.Item("Titulo" & i))

                        Titulo &= .Item("Titulo" & i) & ","
                    ElseIf IsDBNull(.Item("Titulo" & i)) Then
                        Continue For
                    End If

                    Chart1.Series(.Item("Titulo" & i).ToString).Points.AddXY(.Item(1), wacu)

                    If Not _wValoresDibujados.Contains(.Item("Titulo" & i)) Then

                        _wValoresDibujados(WIndice) = .Item("Titulo" & i)
                        WIndice += 1

                    End If

                    ' End If

                Next

            End With

            wacu = 0.0

        Next

        Titulo = Titulo.Substring(0, Titulo.Length - 1) & " )"

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumuladoFamilia()

        Dim wacu = 0.0
        Dim WIndice = 0
        Dim Wvalores(10) As String
        Dim windice2 = 0

        Dim WNombres(11) As String
        Dim WInd = 0

        Titulo = ""

        For Each row As DataRow In Tabla.Rows
            If Not IsDBNull(row.Item(1)) AndAlso Trim(row.Item(1)) <> "" Then

                If Not WNombres.Contains(row.Item(1)) Then
                    WNombres(WInd) = row.Item(1)
                    WInd += 1
                End If

            End If
        Next

        For i = 0 To WInd
            If Not IsNothing(WNombres(i)) Then
                Titulo &= WNombres(i) & ", "
            End If
        Next

        Titulo = Titulo.Substring(0, Trim(Titulo).Length - 1)

        Titulo = ReplaceLastComma(Titulo)

        Titulo &= vbCrLf & " - " & Tabla.Rows(0).Item(16).ToString.Trim

        For i = 27 To 16 Step -1

            If Not IsDBNull(Tabla.Rows(0).Item(i)) Then
                Titulo &= " al " & Tabla.Rows(0).Item(i).ToString.Trim & " -" & vbCrLf & "( "
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
                        wacu = Val(formatonumerico(.Item("Valor" & i)))
                    End If


                    'If wacu <> 0 Then

                    Chart1.Series((.Item(2) & " (" & .Item(1) & ")").ToString).Points.AddXY(.Item(i + 15), wacu)

                    If Not Wvalores.Contains(.Item(2)) Then
                        Wvalores(windice2) = .Item(2)
                        windice2 += 1
                    End If

                    If Not _wValoresDibujados.Contains(.Item(2)) Then
                        _wValoresDibujados(WIndice) = .Item(2)
                        WIndice += 1
                    End If

                    'End If

                Next

            End With

            wacu = 0.0

        Next

        For i = 0 To Wvalores.Length - 1
            If Not IsNothing(Wvalores(i)) Then
                Titulo &= Wvalores(i) & ","
            End If
        Next

        Titulo = Titulo.Substring(0, Titulo.Length - 1) & " )"

        _HabilitarLabels()

    End Sub

    Private Function ReplaceLastComma(ByVal s As String)
        Static re As New Regex("\s*,\s*([^,]*)$")
        Return re.Replace(s, " y $1")
    End Function

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
                        wacu = Val(formatonumerico(.Item("Valor" & i)))
                    End If

                    If (Not IsDBNull(.Item(1)) AndAlso Trim(.Item(1)) <> "") Then
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

    Private Sub _ProcesarAcumulado3()
        Dim wacu = 0.0
        Dim wacu1 = 0.0
        Dim wacu2 = 0.0
        Dim wacu3 = 0.0

        Titulo = "CONSOLIDADO" & vbCrLf & " - "

        Titulo &= Tabla.Rows(0).Item("Titulo") & " -"

        'For Each row As DataRow In Tabla.Rows
        '    If Not IsDBNull(row.Item(1)) AndAlso Chart1.Series.IsUniqueName(row.Item(1)) Then
        '        Chart1.Series.Add(row.Item(1))
        '    End If
        'Next

        Chart1.Series.Add(Tabla.Rows(0).Item("Titulo1"))
        Chart1.Series.Add(Tabla.Rows(0).Item("Titulo2"))
        Chart1.Series.Add(Tabla.Rows(0).Item("Titulo3"))

        For Each row As DataRow In Tabla.Rows

            With row

                wacu = Val(formatonumerico(OrDefault(.Item("Valor1"), 0)))

                wacu1 += wacu

                wacu = Val(formatonumerico(OrDefault(.Item("Valor2"), 0)))

                wacu2 += wacu

                wacu = Val(formatonumerico(OrDefault(.Item("Valor3"), 0)))

                wacu3 += wacu

            End With

        Next

        Chart1.Series(Tabla.Rows(0).Item("Titulo1")).Points.AddXY(Tabla.Rows(0).Item("Titulo"), wacu1)
        Chart1.Series(Tabla.Rows(0).Item("Titulo2")).Points.AddXY(Tabla.Rows(0).Item("Titulo"), wacu2)
        Chart1.Series(Tabla.Rows(0).Item("Titulo3")).Points.AddXY(Tabla.Rows(0).Item("Titulo"), wacu3)

        wacu = 0.0

        _HabilitarLabels()
    End Sub

    Private Sub _HabilitarLabels()

        For Each serie In Chart1.Series
            _LabelsComoPorcentaje(serie)
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

        ComparacionesMensualesValorUnico.Dispose()

        With New ComparacionesMensualesValorUnico
            .Show()
            .rbMensualComparativo.Checked = True
        End With

        Close()

    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick

        _RedibujarDatos(e.RowIndex)

    End Sub

    Private Sub _RedibujarDatos(ByVal rowIndex As Integer)

        If Tipo = -1 Then

            Dim WTabla = TablaGrilla.DataSet.Tables(1).Select("", "Descripcion DESC")

            With Chart1

                .Series.Clear()
                .ResetAutoValues()
            End With


            Chart1.Series.Add(WTabla(rowIndex).Item(1))

            For i = 4 To 15

                If Not IsDBNull(WTabla(rowIndex).Item(i)) AndAlso WTabla(rowIndex).Item(i) <> 0 Then
                    Chart1.Series(WTabla(rowIndex).Item(1).ToString).Points.AddXY(WTabla(rowIndex).Item(i + 12), WTabla(rowIndex).Item(i))
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

            If Tabla.Rows.Count > 0 Then
                Titulo = "COMPARACION ANUAL" & vbCrLf & " - " & Tabla.Rows(0).Item(2) & " -" & vbCrLf & "( " & valor & " )"
            End If

            Chart1.Series.Add(valor)

            Dim aux = 0.0, WA = "", WLinea = "", WAuxi = ""

            For Each r As DataGridViewRow In DataGridView1.Rows

                If r.Index >= DataGridView1.Rows.Count - 4 Then Exit For

                WA = IIf(IsDBNull(r.Cells(1).Value), "", r.Cells(1).Value)

                If WA <> WLinea And WA <> "" Then
                    WLinea = WA
                End If

                WAuxi = IIf(IsDBNull(r.Cells(2).Value), "", r.Cells(2).Value)

                If WAuxi = valor Then

                    aux = 0.0

                    For i = 4 To 15

                        aux += IIf(IsDBNull(r.Cells(i).Value), 0, r.Cells(i).Value)

                    Next

                    Chart1.Series(valor).Points.AddXY(WLinea, aux)

                End If

            Next

            For Each row As DataGridViewRow In DataGridView1.Rows

                row.DefaultCellStyle.BackColor = WColorBasico

                If row.Cells(2).Value = valor Then
                    row.DefaultCellStyle.BackColor = Color.LightBlue
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

            Titulo = Tabla.Rows(0).Item(1).ToString.Trim & vbCrLf & " - " & Tabla.Rows(0).Item(16).ToString.Trim

            For i = 27 To 16 Step -1

                If Not IsDBNull(Tabla.Rows(0).Item(i)) Then
                    Titulo &= " al " & Tabla.Rows(0).Item(i).ToString.Trim & " -"
                    Exit For
                End If

            Next

            Titulo &= vbCrLf & "( " & valor & " )"

            Dim aux = 0.0, WA = "", WLinea = ""

            For Each r As DataGridViewRow In DataGridView1.Rows

                'If r.Index > DataGridView1.Rows.Count - 4 Then Continue For

                WA = IIf(IsDBNull(r.Cells(1).Value), "", r.Cells(1).Value)

                If WA = "" Then
                    For i = r.Index To 0 Step -1

                        WA = IIf(IsDBNull(DataGridView1.Rows(i).Cells(1).Value), "", DataGridView1.Rows(i).Cells(1).Value)

                        If WA <> "" Then
                            Exit For
                        End If

                    Next
                End If

                If WA = "" Then
                    Exit Sub
                End If

                WLinea = valor & " (" & WA & ")"

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

            Dim valorComparable = DataGridView1.Rows(rowIndex).Cells("Titulo").Value

            If valorComparable = "Precio" Then Exit Sub

            Dim rows() As DataRow = TablaConsolidados.Select("Descripcion = '" & valorComparable & "'")
            Dim Waux = 0.0

            If rows.Count > 0 Then

                With Chart1

                    .Series.Clear()
                    .ResetAutoValues()

                End With

                For i = 4 To 15

                    Waux = 0.0

                    Waux = IIf(IsDBNull(rows(0).Item(i)), 0, rows(0).Item(i))

                    If Chart1.Series.IsUniqueName(valorComparable) Then
                        Chart1.Series.Add(valorComparable)
                    End If

                    If Waux <> 0 Then
                        Chart1.Series(valorComparable).Points.AddXY(rows(0).Item(i + 12), Waux)
                    End If

                Next

                For Each row As DataGridViewRow In DataGridView1.Rows

                    row.DefaultCellStyle.BackColor = WColorBasico

                    If row.Cells("Titulo").Value = valorComparable Then
                        row.DefaultCellStyle.BackColor = Color.LightBlue
                    End If

                Next

                _HabilitarLabels()

            End If

        ElseIf Tipo = 4 Then

            ComparacionesMensualesValorUnico._RegraficarConsolidado(DataGridView1.Rows(rowIndex).Cells("Titulo").Value)

        Else


            Dim WTabla = TablaGrilla.DataSet.Tables(1).Select("", "Descripcion DESC")

            With Chart1

                .Series.Clear()
                .ResetAutoValues()

            End With

            Chart1.Series.Add(WTabla(rowIndex).Item(2))

            For i = 4 To 15

                If Not IsDBNull(WTabla(rowIndex).Item(i)) AndAlso WTabla(rowIndex).Item(i) <> 0 Then
                    Chart1.Series(WTabla(rowIndex).Item(2).ToString).Points.AddXY(WTabla(rowIndex).Item(i + 12), WTabla(rowIndex).Item(i))
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

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)

        For Each serie As Series In Chart1.Series

            serie.ChartType = SeriesChartType.Line

            _LabelsComoPorcentaje(serie)

        Next

    End Sub

    Private Sub _LabelsComoPorcentaje(ByVal serie As Series)
        Dim aux As Double

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
                    If Chart1.Series(serie.Name).Points.Count > 0 Then

                        ComoPorce = False

                        For i = 0 To WConPorce.Length - 1
                            If UCase(serie.Name).Contains(WConPorce(i)) Then
                                ComoPorce = True
                                Exit For
                            End If
                        Next

                        If aux = 0 Then
                            ComoPorce = False
                        End If

                        If ComoPorce Then
                            .Label = "% " & formatonumerico((.YValues(0) * 100) / aux)
                        Else
                            .Label = formatonumerico(.YValues(0))
                        End If

                    End If

                End With

            Next

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)

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

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)

        For Each serie As Series In Chart1.Series

            serie.ChartType = SeriesChartType.Column

            _LabelsComoPorcentaje(serie)

        Next
    End Sub

    'Private Sub DataGridView1_ColumnHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseDoubleClick
    '    MsgBox(DataGridView1.Columns(e.ColumnIndex).Width)
    'End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("DELETE FROM ComandoII")
        Dim WCampo = ""
        Dim WCampos = ""
        Dim WValores = ""
        Dim aux = ""
        Dim WRow() As DataRow
        Dim WTabla As DataTable
        Dim WLineaDes = ""

        Try
            ' Limpiamos los datos que esten presentes con anterioridad.
            cn.ConnectionString = _ConectarA
            cn.Open()
            cm.Connection = cn

            cm.ExecuteNonQuery()

            If TypeOf DataGridView1.DataSource Is DataView Then
                WTabla = DataGridView1.DataSource.toTable.Copy
            ElseIf TypeOf DataGridView1.DataSource Is DataTable Then
                WTabla = DataGridView1.DataSource.Copy
            Else
                Exit Sub
            End If

            For i = 1 To 9

                WRow = WTabla.Select("Tipo = " & i)

                If WRow.Length = 0 Then Continue For

                WLineaDes = WRow(0).Item("Descripcion")
                WCampo = ""

                WCampos = "Tipo, Descripcion,"
                WValores = i & ",'" & WLineaDes & "',"

                For x = 1 To 12
                    WCampos &= "Impre" & x & ","
                    WValores &= "'" & WRow(0).Item("Titulo" & x) & "',"
                Next

                For j = 0 To WRow.Length - 1

                    WCampo = WRow(j).Item("Titulo")

                    Select Case UCase(WCampo)
                        Case "VENTAS U$S"
                            WCampo = "Venta"
                        Case "KILOS"
                            WCampo = "Kilos"
                        Case "STOCK"
                            WCampo = "Stock"
                        Case "ATRASO"
                            WCampo = "Atraso"
                        Case "PEDIDOS"
                            WCampo = "Pedidos"
                        Case "ROTACIÓN"
                            WCampo = "Rotacion"
                        Case "FACTOR"
                            WCampo = "Factor"
                        Case "PRECIO"
                            WCampo = "Precio"
                        Case "% VENTA"
                            WCampo = "PorceVenta"
                        Case "% ATRASO"
                            WCampo = "PorceAtraso"
                        Case Else
                            WCampo = ""
                    End Select

                    If WCampo = "" Then Continue For

                    For x = 1 To 12

                        WCampos &= WCampo & x & ","

                        aux = IIf(IsDBNull(WRow(j).Item("Valor" & x)), "0", WRow(j).Item("Valor" & x))

                        WValores &= formatonumerico(aux) & ","

                    Next

                Next

                If WCampos.EndsWith(",") Then
                    WCampos = WCampos.Substring(0, WCampos.Length - 1)
                End If

                If WValores.EndsWith(",") Then
                    WValores = WValores.Substring(0, WValores.Length - 1)
                End If
                cm.CommandText = "INSERT INTO ComandoII (" & WCampos & ") VALUES (" & WValores & ")"

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
            .Reporte = New listacomando
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

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class