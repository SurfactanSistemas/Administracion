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

        Chart1.Series.Clear()
        Chart1.ResetAutoValues()
        
        Select Case Tipo
            Case 1
                _ProcesarAcumulado()
            Case 2
                _ProcesarAcumuladoFamilia()
            Case 3
                _ProcesarAnual()
        End Select


    End Sub

    Private Sub _ProcesarAnual()
        
        Dim wacu = 0.0

        For i = 1 To 12

            If Not IsDBNull(Tabla.Rows(0).Item("Titulo" & i)) AndAlso Chart1.Series.IsUniqueName(Tabla.Rows(0).Item("Titulo" & i)) Then
                Chart1.Series.Add(Tabla.Rows(0).Item("Titulo" & i))
            End If

        Next

        For Each row As DataRow In Tabla.Rows

            For i = 1 To 12
                wacu = 0.0
                If Not IsDBNull(row.Item("Valor" & i)) Then
                    wacu = Val(Helper.formatonumerico(row.Item("Valor" & i)))
                End If

                If wacu <> 0 Then

                    Chart1.Series(row.Item("Titulo" & i).ToString).Points.AddXY(row.Item(1), wacu)

                End If

            Next

            wacu = 0.0

        Next

        _HabilitarLabels()
        
    End Sub

    Private Sub _ProcesarAcumuladoFamilia()

        Dim wacu = 0.0

        For Each row As DataRow In Tabla.Rows

            Chart1.Series.Add(row.Item(2))

            For i = 1 To 12
                wacu = 0.0
                If Not IsDBNull(row.Item("Valor" & i)) Then
                    wacu = Val(Helper.formatonumerico(row.Item("Valor" & i)))
                End If

                If wacu <> 0 Then

                    Chart1.Series(row.Item(2).ToString).Points.AddXY(row.Item(i + 15), wacu)

                End If

            Next

            wacu = 0.0

        Next

        _HabilitarLabels()

    End Sub

    Private Sub _ProcesarAcumulado()
        Dim wacu = 0.0

        For Each row As DataRow In Tabla.Rows

            Chart1.Series.Add(row.Item(1))

            For i = 1 To 12
                wacu += IIf(IsDBNull(row.Item("Valor" & i)), 0, Val(Helper.formatonumerico(row.Item("Valor" & i))))
            Next

            Chart1.Series(row.Item(1).ToString).Points.AddXY(row.Item(1), wacu)
            
            wacu = 0.0

        Next

        _HabilitarLabels()
    End Sub

    Private Sub _HabilitarLabels()

        Dim aux = 0.0

        For Each serie In Chart1.Series

            If Chart1.Series(serie.Name).Points.Count > 1 Then
                aux = Chart1.Series(serie.Name).Points.Sum(Function(p) p.YValues(0))
            End If


            For Each p As DataPoint In serie.Points

                p.IsValueShownAsLabel = True
                p.CustomProperties = "DrawSideBySide=True"

                If Chart1.Series(serie.Name).Points.Count > 1 Then
                    p.Label = p.YValues(0) & " (% " & Helper.formatonumerico((p.YValues(0) * 100) / aux) & " )"
                End If
                
            Next
        Next

        Dim gd As New Charting.Grid

        gd.LineWidth = 0

        Chart1.ChartAreas(0).AxisX.MajorGrid = gd

        Chart1.ChartAreas(0).AxisX.Interval = 1

    End Sub
End Class