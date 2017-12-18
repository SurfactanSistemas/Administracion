Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.DataVisualization

Public Class Grafico
    Public Property Tabla As DataTable

    Public Property Tipo As Integer

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
            Case Else
                Close()
        End Select

    End Sub

    Private Sub _ProcesarAnual()
        
        Dim wacu = 0.0

        With Tabla.Rows(0)

            For i = 1 To 12

                If Not IsDBNull(.Item("Titulo" & i)) AndAlso Chart1.Series.IsUniqueName(.Item("Titulo" & i)) Then

                    Chart1.Series.Add(.Item("Titulo" & i))

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

        _HabilitarLabels()
        
    End Sub

    Private Sub _ProcesarAcumuladoFamilia()

        Dim wacu = 0.0

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

        For Each row As DataRow In Tabla.Rows

            With row

                Chart1.Series.Add(.Item(1))

                For i = 1 To 12
                    wacu += IIf(IsDBNull(.Item("Valor" & i)), 0, Val(Helper.formatonumerico(.Item("Valor" & i))))
                Next

                Chart1.Series(row.Item(1).ToString).Points.AddXY(.Item(1), wacu)

            End With

            wacu = 0.0

        Next

        _HabilitarLabels()
    End Sub

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
    End Sub
End Class