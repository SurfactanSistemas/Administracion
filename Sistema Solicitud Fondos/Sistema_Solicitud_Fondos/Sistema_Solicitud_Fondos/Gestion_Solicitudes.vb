﻿Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Gestion_Solicitudes : Implements IActualizaSolicitudes

    Dim FinalLoad As String = "NO"
    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub Gestion_Solicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrilla()
    End Sub

    Private Sub CargarGrilla()
        Dim SQLCnslt As String = "SELECT s.NroSolicitud, s.Solicitante, s.Fecha, s.OrdFecha, " _
                                 & "Tipo = IIF(s.Tipo = 1, 'Pago Prov.',  'Varios'), " _
                                 & "Destino = IIF(s.Proveedor = '',c.Descripcion, p.Nombre), s.Titulo, " _
                                 & "Moneda = IIF(s.Moneda = 2, 'U$D',  '$'), s.Importe, s.FechaRequerida, " _
                                 & "s.OrdFechaRequerida " _
                                 & "FROM SolicitudFondos s LEFT JOIN Proveedor p ON s.Proveedor = p.Proveedor " _
                                 & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta WHERE s.OrdenPago = ''"
        Try
            Dim tablaSoli As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If tablaSoli.Rows.Count > 0 Then
                DGV_Solicitudes.DataSource = tablaSoli
            End If


            AplicarFiltro()

            FinalLoad = "SI"





        Catch ex As Exception

        End Try
    End Sub


    Private Sub ActualizarTotales()

        Dim TotalDolares As Double = 0.0
        Dim TotalPesos As Double = 0.0

        For Each row As DataGridViewRow In DGV_Solicitudes.Rows
            With row
                If Trim(.Cells("Moneda").Value) = "U$D" Then
                    TotalDolares += .Cells("Importe").Value
                Else
                    TotalPesos += .Cells("Importe").Value
                End If
            End With
        Next

        txt_TotalDolares.Text = TotalDolares
        txt_TotalPesos.Text = TotalPesos

        txt_TotalDolares.Text = formatonumerico(txt_TotalDolares.Text)
        txt_TotalPesos.Text = formatonumerico(txt_TotalPesos.Text)

    End Sub
    Private Sub AplicarFiltro()

        Dim RangosFechas(3, 1) As String

        Dim Filtro As String = ""

        'CARGO LOS RANGOS DE FECHAS A UTILIZAR
        CalcularRangosFechas(RangosFechas)


        'GENERO EL FILTRO
        If chk_SemanaActual.Checked Then
            Filtro = Filtro & " (OrdFechaRequerida >= '" & 1 & "' AND OrdFechaRequerida <= '" & RangosFechas(0, 1) & "') OR"
        End If
        If chk_SegundaSemana.Checked Then
            Filtro = Filtro & " (OrdFechaRequerida >= '" & RangosFechas(1, 0) & "' AND OrdFechaRequerida <= '" & RangosFechas(1, 1) & "') OR"
        End If
        If chk_TercerSemana.Checked Then
            Filtro = Filtro & " (OrdFechaRequerida >= '" & RangosFechas(2, 0) & "' AND OrdFechaRequerida <= '" & RangosFechas(2, 1) & "') OR"
        End If
        If chk_CuartaSemana.Checked Then
            Filtro = Filtro & " (OrdFechaRequerida >= '" & RangosFechas(3, 0) & "' AND OrdFechaRequerida <= '" & RangosFechas(3, 1) & "') OR"
        End If
        If chk_SinFecha.Checked Then
            Filtro = Filtro & " OrdFechaRequerida = '" & 0 & "' OR"
        End If

        'REMUEVO EL 'OR' DEL FINAL
        Dim Largofiltro As Integer = (Filtro.Length - 2)
        If Largofiltro > 2 Then
            Filtro = Filtro.Remove(Largofiltro, 2)
        End If

        If Filtro <> "" Then
            Filtro = Filtro & " AND "
        End If

        Filtro = Filtro & "(convert(NroSolicitud, System.String) LIKE '%" & txt_Filtro.Text & "%' OR Solicitante LIKE '%" & txt_Filtro.Text & "%' " _
                                                & "OR Fecha LIKE '%" & txt_Filtro.Text & "%' OR Tipo LIKE '%" & txt_Filtro.Text & "%' " _
                                                & "OR Destino LIKE '%" & txt_Filtro.Text & "%' OR Titulo LIKE '%" & txt_Filtro.Text & "%' " _
                                                & "OR Moneda LIKE '%" & txt_Filtro.Text & "%' OR convert(Importe, System.String) LIKE '%" & txt_Filtro.Text & "%' " _
                                                & "OR FechaRequerida LIKE '%" & txt_Filtro.Text & "%')"

        'APLICO EL FILTRO
        Dim tabla As DataTable = DGV_Solicitudes.DataSource

        tabla.DefaultView.RowFilter = Filtro

        ActualizarTotales()

    End Sub

    Sub CalcularRangosFechas(ByRef RangosFechas As Object)
        Dim FechaActual As String = Date.Today.ToString("dd/MM/yyyy")

        Dim FechaLunes As Date = IrALunes(FechaActual)

        RangosFechas(0, 0) = FechaLunes.ToString("dd/MM/yyyy")
        RangosFechas(0, 1) = FechaLunes.AddDays(6).ToString("dd/MM/yyyy")
        RangosFechas(1, 0) = FechaLunes.AddDays(7).ToString("dd/MM/yyyy")
        RangosFechas(1, 1) = FechaLunes.AddDays(13).ToString("dd/MM/yyyy")
        RangosFechas(2, 0) = FechaLunes.AddDays(14).ToString("dd/MM/yyyy")
        RangosFechas(2, 1) = FechaLunes.AddDays(20).ToString("dd/MM/yyyy")
        RangosFechas(3, 0) = FechaLunes.AddDays(21).ToString("dd/MM/yyyy")
        RangosFechas(3, 1) = FechaLunes.AddDays(27).ToString("dd/MM/yyyy")

        ordenaRangosFechas(RangosFechas)

    End Sub

    Private Sub ordenaRangosFechas(ByRef RangosFechas As Object)
        RangosFechas(0, 0) = ordenaFecha(RangosFechas(0, 0))
        RangosFechas(0, 1) = ordenaFecha(RangosFechas(0, 1))
        RangosFechas(1, 0) = ordenaFecha(RangosFechas(1, 0))
        RangosFechas(1, 1) = ordenaFecha(RangosFechas(1, 1))
        RangosFechas(2, 0) = ordenaFecha(RangosFechas(2, 0))
        RangosFechas(2, 1) = ordenaFecha(RangosFechas(2, 1))
        RangosFechas(3, 0) = ordenaFecha(RangosFechas(3, 0))
        RangosFechas(3, 1) = ordenaFecha(RangosFechas(3, 1))
    End Sub
    Private Function IrALunes(ByVal FechaActual As Date) As String
        Dim NumeroDia As Integer = FechaActual.DayOfWeek
        Do
            If NumeroDia = 0 Then
                FechaActual = FechaActual.AddDays(-6)
                Return FechaActual.ToString("dd/MM/yyyy")
            End If
            If NumeroDia = 1 Then
                Return FechaActual.ToString("dd/MM/yyyy")
            Else
                If NumeroDia > 1 Then
                    FechaActual = FechaActual.AddDays(-1)
                    NumeroDia = FechaActual.DayOfWeek
                End If
            End If
        Loop

    End Function

    Private Sub chks__CheckedChanged(sender As Object, e As EventArgs) Handles chk_TercerSemana.CheckedChanged, chk_SinFecha.CheckedChanged, chk_SemanaActual.CheckedChanged, chk_SegundaSemana.CheckedChanged, chk_CuartaSemana.CheckedChanged
        If FinalLoad = "SI" Then
            AplicarFiltro()
        End If
    End Sub



    Private Sub DGV_Solicitudes_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGV_Solicitudes.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 1, 3, 4, 5
                'String
                num1 = e.CellValue1
                num2 = e.CellValue2

            Case 0
                'INTEGER
                num1 = CInt(e.CellValue1)
                num2 = CInt(e.CellValue2)

            Case 6
                'Double
                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 2, 7
                'Fechas
                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)


            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True

    End Sub


    Private Sub DGV_Solicitudes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Solicitudes.CellMouseDoubleClick
        With New Ingreso_Solicitud(DGV_Solicitudes.CurrentRow.Cells(0).Value)
            .Show(Me)
        End With
    End Sub

    Public Sub ActualizaGrilla() Implements IActualizaSolicitudes.ActualizaGrilla
        CargarGrilla()
    End Sub

    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        AplicarFiltro()
    End Sub

    Private Sub btn_ImprimeListado_Click(sender As Object, e As EventArgs) Handles btn_ImprimeListado.Click

        Dim Tablareporte As DataTable = New DBAuxi.ListadoGrillaDataTable

        For Each row As DataGridViewRow In DGV_Solicitudes.Rows

            Tablareporte.Rows.Add(row)
        Next

        With New VistaPrevia
            .Reporte = New Reporte__Listado_Grilla()
            .Reporte.SetDataSource(Tablareporte)


        End With


    End Sub
End Class