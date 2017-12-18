Imports System.Text.RegularExpressions
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.DataVisualization

Public Class Grafico
    Public Property Tabla As DataTable

    Public Property Tipo As Integer

    Public Property Titulo As String

    Private Sub Grafico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ProcesarGrafico()
    End Sub

    Public Sub _ProcesarGrafico()

        If Tabla.Rows.Count = 0 Then
            MsgBox("No hay datos que graficar.", MsgBoxStyle.Exclamation)
            Close()
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

    End Sub

    Private Sub _ProcesarComparativoMensual()

        Dim wacu = 0.0

        Titulo = "Anual" & vbCrLf & " - "

        For Each row As DataRow In Tabla.Rows

            With row


                If Not IsDBNull(.Item("Titulo1")) AndAlso Chart1.Series.IsUniqueName(Microsoft.VisualBasic.Right(Trim(.Item("Titulo1")), 4)) Then

                    Chart1.Series.Add(Microsoft.VisualBasic.Right(Trim(.Item("Titulo1")), 4))

                End If

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

        Titulo &= " " & Tabla.Rows(0).Item(2) & ", "

        ' Eliminamos la ultima coma
        Titulo = ReplaceLastComma(UCase(Trim(Titulo).Substring(0, Trim(Titulo).Length - 1)) & " -")

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAnual()
        
        Dim wacu = 0.0

        Titulo = "Anual" & vbCrLf & " - "

        With Tabla.Rows(0)

            For i = 1 To 12

                If Not IsDBNull(.Item("Titulo" & i)) AndAlso Chart1.Series.IsUniqueName(.Item("Titulo" & i)) Then

                    Chart1.Series.Add(.Item("Titulo" & i))

                    Titulo &= " " & .Item("Titulo" & i) & ", "

                End If

            Next

        End With

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


        ' Eliminamos la ultima coma
        Titulo = ReplaceLastComma(UCase(Trim(Titulo).Substring(0, Trim(Titulo).Length - 1)) & " -")

        _HabilitarLabels()
        
    End Sub

    Private Sub _ProcesarAcumuladoFamilia()

        Dim wacu = 0.0

        Titulo = "Mensual por Linea" & vbCrLf & " - "

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

                Titulo &= " " & .Item(2) & ", "

            End With

            wacu = 0.0

        Next


        ' Eliminamos la ultima coma
        Titulo = ReplaceLastComma(UCase(Trim(Titulo).Substring(0, Trim(Titulo).Length - 1)) & " -")

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumulado()
        Dim wacu = 0.0
        Dim aux = ""

        Titulo = "Consolidado" & vbCrLf & " - "

        For Each row As DataRow In Tabla.Rows

            With row

                Chart1.Series.Add(.Item(1))

                For i = 1 To 12

                    If Not IsDBNull(.Item("Valor" & i)) Then
                        wacu += Val(Helper.formatonumerico(.Item("Valor" & i)))
                        Titulo &= " " & .Item("Titulo" & i) & ", "
                    End If

                Next

                Chart1.Series(row.Item(1).ToString).Points.AddXY(.Item(1), wacu)

            End With

            wacu = 0.0

        Next

        ' Eliminamos la ultima coma
        Titulo = ReplaceLastComma(UCase(Trim(Titulo).Substring(0, Trim(Titulo).Length - 1)) & " -")

        _HabilitarLabels()
    End Sub

    Private Function ReplaceLastComma(ByVal s As String)
        Static re As New Regex("\s*,\s*([^,]*)$")
        Return re.Replace(s, " y $1")
    End Function

    Private Sub _HabilitarLabels()

        Dim aux = 0.0

        For Each serie In Chart1.Series

            With Chart1.Series(serie.Name).Points
                If .Count > 1 Then
                    aux = .Sum(Function(p) p.YValues(0))
                End If
            End With

            For Each p As DataPoint In serie.Points

                With p
                    .IsValueShownAsLabel = True
                    .CustomProperties = "DrawSideBySide=True"
                    If Chart1.Series(serie.Name).Points.Count > 1 Then
                        .Label = .YValues(0) & " (% " & Helper.formatonumerico((.YValues(0) * 100) / aux) & " )"
                    End If
                End With

            Next
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
        End With
    End Sub
End Class