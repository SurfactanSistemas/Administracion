﻿Imports Util
Imports Util.Clases

Public Class AutoGestionSolicitudes : Implements IActualizaSolicitudes


    Private Sub Gestion_Solicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_Fecha_Hasta.Text = Date.Today.ToString("dd/MM/yyyy")
        txt_Fecha_Desde.Text = Date.Today.AddMonths(-3).ToString("dd/MM/yyyy")
        CargarGrilla()
    End Sub

    Private Sub CargarGrilla()

        Dim Filtro As String = ""
        If Not chk_Rechazados.Checked Then
            'Filtro = "AND (upper(s.Estado) <> 'RECHAZADO' or s.Estado IS NULL)"
            Filtro = "AND (upper(s.Estado) = 'AUTORIZO' or s.Estado IS NULL) AND s.OrdenPago = '' "
        Else
            Filtro = "AND (s.OrdFecha >= '" & ordenaFecha(txt_Fecha_Desde.Text) & "' AND s.OrdFecha <= '" & ordenaFecha(txt_Fecha_Hasta.Text) & "') "
        End If
        Dim SQLCnslt As String = "SELECT s.NroSolicitud, s.Solicitante, s.Fecha, s.OrdFecha, " _
                           & "Tipo = IIF(s.Tipo = 1, 'Prov.',  'Varios'), " _
                           & "Destino = IIF(s.Proveedor = '',c.Descripcion, p.Nombre), s.Titulo, " _
                           & "Moneda = IIF(s.Moneda = 2, 'U$D',  '$'), s.Importe, s.FechaRequerida, " _
                           & "s.OrdFechaRequerida, Estado = IIF(s.Estado = '', '', s.Estado), " _
                           & "s.OrdenPago " _
                           & "FROM SolicitudFondos s LEFT JOIN Proveedor p ON s.Proveedor = p.Proveedor " _
                           & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta " _
                           & "WHERE (s.Solicitante = '" & Trim(Operador.Descripcion) & "' OR s.Operador_Sector = '" & Trim(Operador.Solifondos_Sector) & "')" _
                           & "" & Filtro & "" _
                           & "ORDER BY s.OrdFechaRequerida asc"
        ' Dim SQLCnslt As String = "SELECT s.NroSolicitud, s.Solicitante, s.Fecha, s.OrdFecha, " _
        '                          & "Tipo = IIF(s.Tipo = 1, 'Prov.',  'Varios'), " _
        '                          & "Destino = IIF(s.Proveedor = '',c.Descripcion, p.Nombre), s.Titulo, " _
        '                          & "Moneda = IIF(s.Moneda = 2, 'U$D',  '$'), s.Importe, s.FechaRequerida, " _
        '                          & "s.OrdFechaRequerida, Estado = IIF(s.Estado = '', '', s.Estado) " _
        '                          & "FROM SolicitudFondos s LEFT JOIN Proveedor p ON s.Proveedor = p.Proveedor " _
        '                          & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta " _
        '                          & "WHERE s.OrdenPago = '' AND (s.Solicitante = '" & Trim(Operador.Descripcion) & "' OR s.Operador_Sector = '" & Trim(Operador.Solifondos_Sector) & "')" _
        '                          & "" & Filtro & "" _
        '                          & "ORDER BY s.OrdFechaRequerida asc"
        Try
            Dim tablaSoli As DataTable = Query.GetAll(SQLCnslt, "SurfactanSa")
            If tablaSoli.Rows.Count >= 0 Then
                DGV_Solicitudes.DataSource = tablaSoli
            End If
            PintarAutorizadosRechazados()
            ActualizarTotales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CambiarNumeroMillones(ByVal TotalPesos As Double, ByVal TotalDolares As Double)

        ' Valores numéricos que deseamos formatear.
        '
        'Dim valorNumericoEntero As Decimal = 25693929D
        'Dim valorNumericoDecimal As Decimal = 35878.3826D

        ' Mostramos el resultado con el carácter separador de miles
        ' existente en la cultura del subproceso actual. 
        '
        txt_TotalPesos.Text = String.Format("{0:N2}", TotalPesos)

        ' Mostramos el resultado con los caracteres separadores de miles
        ' y decimal, incluyendo tres dígitos decimales. 
        '
        txt_TotalDolares.Text = String.Format("{0:N2}", TotalDolares) ' 

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

        CambiarNumeroMillones(Val(txt_TotalPesos.Text), Val(txt_TotalDolares.Text))

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

                Dim SQLCnslt As String = "SELECT Efectivo_Chk, Transferencia_Chk, ECheq_Chk, CheqTerceros_Chk, CheqPropio_Chk, Tarjeta_Chk, DebitoAutomatico_Chk " _
                                         & "FROM SolicitudFondos WHERE NroSolicitud = '" & .Cells("NroSolicitud").Value & "'"
                Dim RowSoli As DataRow = Query.GetSingle(SQLCnslt, "SurfactanSa")


                Tablareporte.Rows.Add(.Cells("NroSolicitud").Value, .Cells("Solicitante").Value, .Cells("Fecha").Value,
                                                .Cells("OrdFecha").Value, .Cells("Tipo").Value, .Cells("Destino").Value,
                                                .Cells("Titulo").Value, .Cells("Moneda").Value, ImportePesos,
                                                .Cells("FechaRequerida").Value, .Cells("OrdFechaRequerida").Value, ImporteDolares,
                                                RowSoli.Item("Efectivo_Chk"), RowSoli.Item("Transferencia_Chk"), RowSoli.Item("ECheq_Chk"),
                                                RowSoli.Item("CheqTerceros_Chk"), RowSoli.Item("CheqPropio_Chk"), RowSoli.Item("Tarjeta_Chk"), RowSoli.Item("DebitoAutomatico_Chk"))
            End With
        Next



        With New VistaPrevia
            .Reporte = New Reporte_Listado_Grilla()
            .Reporte.SetDataSource(Tablareporte)
            .Reporte.SetParameterValue(0, "")
            .Mostrar()
        End With

    End Sub

    Private Sub DGV_Solicitudes_Sorted(sender As Object, e As EventArgs) Handles DGV_Solicitudes.Sorted
        PintarAutorizadosRechazados()
    End Sub

    Private Sub chk_Rechazados_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Rechazados.CheckedChanged
        CargarGrilla()
        If chk_Rechazados.Checked Then
            lbl_Desde.Visible = True
            lbl_Hasta.Visible = True
            txt_Fecha_Desde.Visible = True
            txt_Fecha_Hasta.Visible = True
        Else
            lbl_Desde.Visible = False
            lbl_Hasta.Visible = False
            txt_Fecha_Desde.Visible = False
            txt_Fecha_Hasta.Visible = False
        End If
    End Sub



    Private Sub btn_EliminarSolicitud_Click(sender As Object, e As EventArgs) Handles btn_EliminarSolicitud.Click
        If MsgBox("¿Desea rechazar y eliminar la solicitudes seleccionada?", vbYesNo) = vbYes Then

            Try
                Dim ListaConsultas As New List(Of String)
                Dim contador As Integer = 0
                For Each row As DataGridViewRow In DGV_Solicitudes.SelectedRows

                    Dim SQLCnslt As String = "UPDATE SolicitudFondos SET Estado = 'ELIMINADA' WHERE NroSolicitud = '" & row.Cells("NroSolicitud").Value & "'"
                    ListaConsultas.Add(SQLCnslt)

                    ' Try
                    '     SQLCnslt = "SELECT Email FROM Operador WHERE Descripcion = '" & row.Cells("Solicitante").Value & "'"
                    '     Dim rowope As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    '     'SE AVISA POR MAIL QUE NO SE RECHAZO SU SOLICITUD
                    '     If rowope IsNot Nothing Then
                    '         _EnviarEmail(rowope.Item("Email"), "Rechazo de Solicitud de Fondos", "Se a rechazado la solicitud de fondos numero : " & row.Cells("NroSolicitud").Value & " Para " & Trim(row.Cells("Destino").Value) & " con un monto de " & row.Cells("Moneda").Value & " " & row.Cells("Importe").Value & "", Nothing, True)
                    '     End If
                    ' Catch ex As Exception
                    '     MsgBox("No se puedo enviar el mail de aviso. Este operador no debe tener un mail cargado o esta mal escrito", vbExclamation)
                    ' End Try

                    contador += 1

                Next

                Query.ExecuteNonQueries("SurfactanSa", ListaConsultas.ToArray())
                ' 'Dim SQLCnslt As String = "Delete FROM SolicitudFondos WHERE NroSolicitud = '" & NroSolicutud & "'"
                ' Dim SQLCnslt As String = "UPDATE SolicitudFondos SET Estado = 'RECHAZADO' WHERE NroSolicitud = '" & NroSolicutud & "'"
                ' 
                ' ExecuteNonQueries("SurfactanSa", SQLCnslt)

                MsgBox("Se rechazaron " & contador & " solicitudes")

                CargarGrilla()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Public Sub ActualizaGrilla() Implements IActualizaSolicitudes.ActualizaGrilla
        CargarGrilla()
    End Sub

    Private Sub txt_Fecha_Desde_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha_Desde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha_Desde.Text) = "S" Then
                    txt_Fecha_Hasta.Focus()
                Else
                    MsgBox("La fecha en el campo Desde no es valida", vbExclamation)
                    txt_Fecha_Desde.Focus()
                End If
        End Select
    End Sub

    Private Sub txt_Fecha_Hasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha_Hasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha_Hasta.Text) = "S" Then
                    If ValidaFecha(txt_Fecha_Desde.Text) = "S" Then
                        If ordenaFecha(txt_Fecha_Desde.Text) <= ordenaFecha(txt_Fecha_Hasta.Text) Then
                            CargarGrilla()
                        Else
                            MsgBox("La fecha desde debe ser inferior a la fecha Hasta", vbExclamation)
                        End If
                    Else
                        MsgBox("La fecha en el campo Desde no es valida", vbExclamation)
                    End If
                Else
                    MsgBox("La fecha Hasta es invalida, verificar", vbExclamation)
                    txt_Fecha_Hasta.Focus()
                End If
        End Select
    End Sub
End Class