﻿Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query
Public Class AutoGestionSolicitudes


    Private Sub Gestion_Solicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrilla()
    End Sub

    Private Sub CargarGrilla()
        Dim SQLCnslt As String = "SELECT s.NroSolicitud, s.Solicitante, s.Fecha, s.OrdFecha, " _
                                 & "Tipo = IIF(s.Tipo = 1, 'Prov.',  'Varios'), " _
                                 & "Destino = IIF(s.Proveedor = '',c.Descripcion, p.Nombre), s.Titulo, " _
                                 & "Moneda = IIF(s.Moneda = 2, 'U$D',  '$'), s.Importe, s.FechaRequerida, " _
                                 & "s.OrdFechaRequerida, Estado = IIF(s.Estado = '', '', s.Estado) " _
                                 & "FROM SolicitudFondos s LEFT JOIN Proveedor p ON s.Proveedor = p.Proveedor " _
                                 & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta " _
                                 & "WHERE s.OrdenPago = '' AND s.Solicitante = '" & Operador.Descripcion & "'" _
                                 & "ORDER BY s.NroSolicitud"
        Try
            Dim tablaSoli As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If tablaSoli.Rows.Count > 0 Then
                DGV_Solicitudes.DataSource = tablaSoli
            End If
            PintarAutorizadosRechazados()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PintarAutorizadosRechazados()
        For Each row As DataGridViewRow In DGV_Solicitudes.Rows
            With row
                If Trim(IIf(IsDBNull(.Cells("Estado").Value), "", .Cells("Estado").Value)) = "AUTORIZO" Then
                    row.DefaultCellStyle.BackColor = Color.Green
                End If
                If Trim(IIf(IsDBNull(.Cells("Estado").Value), "", .Cells("Estado").Value)) = "RECHAZADO" Then
                    row.DefaultCellStyle.BackColor = Color.Red
                End If
            End With
        Next
    End Sub
    Private Sub DGV_Solicitudes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Solicitudes.CellMouseDoubleClick
        If e.ColumnIndex > -1 Then
            With New Ingreso_Solicitud(DGV_Solicitudes.CurrentRow.Cells(0).Value)
                .Show(Me)
            End With
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

    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        AplicarFiltro()
    End Sub

    Private Sub AplicarFiltro()

        Dim Filtro As String = ""
        
        Filtro = Filtro & "(convert(NroSolicitud, System.String) LIKE '%" & txt_Filtro.Text & "%' OR Solicitante LIKE '%" & txt_Filtro.Text & "%' " _
                                                & "OR Fecha LIKE '%" & txt_Filtro.Text & "%' OR Destino LIKE '%" & txt_Filtro.Text & "%'" _
                                                & " OR Titulo LIKE '%" & txt_Filtro.Text & "%' OR FechaRequerida LIKE '%" & txt_Filtro.Text & "%')"

        'APLICO EL FILTRO
        Dim tabla As DataTable = DGV_Solicitudes.DataSource

        tabla.DefaultView.RowFilter = Filtro

        ActualizarTotales()

        PintarAutorizadosRechazados()

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
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

    Private Sub btn_ImprimeListado_Click(sender As Object, e As EventArgs) Handles btn_ImprimeListado.Click
        Dim Tablareporte As DataTable = New DBAuxi.ListadoGrillaDataTable

        Dim ImportePesos As Double
        Dim ImporteDolares As Double


        For Each row As DataGridViewRow In DGV_Solicitudes.Rows
            With row

                If Trim(.Cells("Moneda").Value) = "$" Then
                    ImportePesos = .Cells("Importe").Value
                    ImporteDolares = 0.0
                Else
                    ImportePesos = 0.0
                    ImporteDolares = .Cells("Importe").Value
                End If

                Dim SQLCnslt As String = "SELECT Efectivo_Chk, Transferencia_Chk, ECheq_Chk, CheqTerceros_Chk, CheqPropio_Chk " _
                                         & "FROM SolicitudFondos WHERE NroSolicitud = '" & .Cells("NroSolicitud").Value & "'"
                Dim RowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")


                Tablareporte.Rows.Add(.Cells("NroSolicitud").Value, .Cells("Solicitante").Value, .Cells("Fecha").Value,
                                                .Cells("OrdFecha").Value, .Cells("Tipo").Value, .Cells("Destino").Value,
                                                .Cells("Titulo").Value, .Cells("Moneda").Value, ImportePesos,
                                                .Cells("FechaRequerida").Value, .Cells("OrdFechaRequerida").Value, ImporteDolares,
                                                RowSoli.Item("Efectivo_Chk"), RowSoli.Item("Transferencia_Chk"), RowSoli.Item("ECheq_Chk"),
                                                RowSoli.Item("CheqTerceros_Chk"), RowSoli.Item("CheqPropio_Chk"))
            End With
        Next



        With New VistaPrevia
            .Reporte = New Reporte_Listado_Grilla()
            .Reporte.SetDataSource(Tablareporte)
            .Reporte.SetParameterValue(0, "")
            .Mostrar()
        End With

    End Sub
End Class