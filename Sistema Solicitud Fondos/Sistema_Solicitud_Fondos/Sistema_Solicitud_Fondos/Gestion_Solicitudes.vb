Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Gestion_Solicitudes : Implements IActualizaSolicitudes, IContraseña

    Dim FinalLoad As String = "NO"
    Dim Fechas(3, 1) As String

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

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
                                 & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta WHERE s.OrdenPago = '' " _
                                 & "AND (s.Estado = 'AUTORIZO' OR s.Estado = '' OR s.Estado is NULL) " _
                                 & "ORDER BY s.NroSolicitud"
        Try
            Dim tablaSoli As DataTable = GetAll(SQLCnslt, "SurfactanSa")
            If tablaSoli.Rows.Count > 0 Then
                DGV_Solicitudes.DataSource = tablaSoli
            Else
                tablaSoli = New DBAuxi.GrillaGestorDataTable()
                DGV_Solicitudes.DataSource = tablaSoli
            End If


            AplicarFiltro()

            PintarAutorizadosRechazados()

            FinalLoad = "SI"

            ActualizarTotales()

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
                                                & "OR Fecha LIKE '%" & txt_Filtro.Text & "%' OR Destino LIKE '%" & txt_Filtro.Text & "%'" _
                                                & " OR Titulo LIKE '%" & txt_Filtro.Text & "%' OR FechaRequerida LIKE '%" & txt_Filtro.Text & "%')"

        'APLICO EL FILTRO
        Dim tabla As DataTable = DGV_Solicitudes.DataSource

        tabla.DefaultView.RowFilter = Filtro

        ActualizarTotales()

        PintarAutorizadosRechazados()

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

        CargaFechasAGlobal(RangosFechas)

    End Sub

    Private Sub CargaFechasAGlobal(ByVal RangosFechas As Object)
        Fechas(0, 0) = DesOrdenaFecha(RangosFechas(0, 0))
        Fechas(0, 1) = DesOrdenaFecha(RangosFechas(0, 1))
        Fechas(1, 0) = DesOrdenaFecha(RangosFechas(1, 0))
        Fechas(1, 1) = DesOrdenaFecha(RangosFechas(1, 1))
        Fechas(2, 0) = DesOrdenaFecha(RangosFechas(2, 0))
        Fechas(2, 1) = DesOrdenaFecha(RangosFechas(2, 1))
        Fechas(3, 0) = DesOrdenaFecha(RangosFechas(3, 0))
        Fechas(3, 1) = DesOrdenaFecha(RangosFechas(3, 1))
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
        If e.ColumnIndex > -1 Then
            With New Ingreso_Solicitud(DGV_Solicitudes.CurrentRow.Cells(1).Value)
                .Show(Me)
            End With
        End If
    End Sub

    Public Sub ActualizaGrilla() Implements IActualizaSolicitudes.ActualizaGrilla
        CargarGrilla()
    End Sub

    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        AplicarFiltro()
    End Sub

    Private Sub btn_ImprimeListado_Click(sender As Object, e As EventArgs) Handles btn_ImprimeListado.Click


        Dim SubTitulo As String = ""

        SubTitulo = GenerarSubTitulo()



        Dim Tablareporte As DataTable = New DBAuxi.ListadoGrillaDataTable

        Dim ImportePesos As Double
        Dim ImporteDolares As Double

        For Each row As DataGridViewRow In DGV_Solicitudes.Rows
            With row
                'FILTRO LOS QUE ESTAN AUTORIZADOS; QUE SOLO QUEDEN LOS PENDIENTES
                Dim Estado As String = IIf(IsDBNull(.Cells("Estado").Value), "", .Cells("Estado").Value)
                If Trim(Estado) <> "AUTORIZO" Then
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
                End If

            End With
        Next



        With New VistaPrevia
            .Reporte = New Reporte_Listado_Grilla()
            .Reporte.SetDataSource(Tablareporte)
            .Reporte.SetParameterValue(0, SubTitulo)
            .Mostrar()
        End With


    End Sub

    Private Function GenerarSubTitulo()
        Dim SubTitulo As String = "Rango Fechas: "


        If chk_SemanaActual.Checked Then
            SubTitulo = SubTitulo & Fechas(0, 0) & " a " & Fechas(0, 1)
        End If

        If chk_SegundaSemana.Checked Then
            If chk_SemanaActual.Checked Then
                SubTitulo = SubTitulo.Replace(Fechas(0, 1), Fechas(1, 1))
            Else
                SubTitulo = SubTitulo & Fechas(1, 0) & " a " & Fechas(1, 1)
            End If

        End If

        If chk_TercerSemana.Checked Then
            If chk_SegundaSemana.Checked Then
                SubTitulo = SubTitulo.Replace(Fechas(1, 1), Fechas(2, 1))
            Else
                If chk_SemanaActual.Checked Then
                    SubTitulo = SubTitulo & " - "
                End If
                SubTitulo = SubTitulo & Fechas(2, 0) & " a " & Fechas(2, 1)
            End If

        End If

        If chk_CuartaSemana.Checked Then
            If chk_TercerSemana.Checked Then
                SubTitulo = SubTitulo.Replace(Fechas(2, 1), Fechas(3, 1))
            Else
                If chk_SemanaActual.Checked Or chk_SegundaSemana.Checked Then
                    SubTitulo = SubTitulo & " - "
                End If
                SubTitulo = SubTitulo & Fechas(3, 0) & " a " & Fechas(3, 1)
            End If

        End If

        If chk_SinFecha.Checked Then
            SubTitulo = SubTitulo & " - Sin Fechas"
        End If

        Return SubTitulo

    End Function

    '  Private Sub DGV_Solicitudes_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Solicitudes.RowHeaderMouseDoubleClick
    '      If MsgBox("¿Desea rechazar la solicitud de fondos Nro: " & DGV_Solicitudes.CurrentRow.Cells("NroSolicitud").Value & " ?", vbYesNo) = vbYes Then
    '          With New SoliContra(DGV_Solicitudes.CurrentRow.Cells("NroSolicitud").Value)
    '              .Show(Me)
    '          End With
    '      End If
    '  End Sub

    Public Sub Autorizado(Permiso As String, NroSolicutud As Integer) Implements IContraseña.Autorizado
        If Permiso = "S" Then
            Try
                Dim ListaConsultas As New List(Of String)
                Dim contador As Integer = 0
                For Each row As DataGridViewRow In DGV_Solicitudes.Rows
                    If row.Cells("chk").Value = True Then
                        Dim SQLCnslt As String = "UPDATE SolicitudFondos SET Estado = 'RECHAZADO' WHERE NroSolicitud = '" & row.Cells("NroSolicitud").Value & "'"
                        ListaConsultas.Add(SQLCnslt)

                        contador += 1
                    End If
                Next

                ExecuteNonQueries("SurfactanSa", ListaConsultas.ToArray())
                ' 'Dim SQLCnslt As String = "Delete FROM SolicitudFondos WHERE NroSolicitud = '" & NroSolicutud & "'"
                ' Dim SQLCnslt As String = "UPDATE SolicitudFondos SET Estado = 'RECHAZADO' WHERE NroSolicitud = '" & NroSolicutud & "'"
                ' 
                ' ExecuteNonQueries("SurfactanSa", SQLCnslt)

                MsgBox("Se rechazaron " & contador & " solicitudes")

                ActualizaGrilla()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub AutorizarSolicitudes() Implements IContraseña.AutorizarSolicitudes
        Dim listaAutorizar As New List(Of String)
        Dim SQLCnslt As String = ""
        For Each row As DataGridViewRow In DGV_Solicitudes.Rows
            With row
                If .Cells("chk").Value = True Then
                    SQLCnslt = "UPDATE SolicitudFondos SET Estado = 'AUTORIZO' WHERE NroSolicitud = '" & .Cells("NroSolicitud").Value & "'"
                    listaAutorizar.Add(SQLCnslt)
                End If
            End With
        Next

        Try
            ExecuteNonQueries("SurfactanSa", listaAutorizar.ToArray())

            ActualizaGrilla()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btn_Autorizar_Click(sender As Object, e As EventArgs) Handles btn_Autorizar.Click
        If MsgBox("¿Desea autorizar las solicitudes marcadas?", vbYesNo) = vbYes Then
            With New SoliContra()
                .Show(Me)
            End With
        End If

    End Sub


    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        If MsgBox("¿Desea rechazar y eliminar las solicitudes marcadas?", vbYesNo) = vbYes Then
            With New SoliContra(-1)
                .Show(Me)
            End With
        End If
    End Sub

    Private Sub DGV_Solicitudes_Sorted(sender As Object, e As EventArgs) Handles DGV_Solicitudes.Sorted
        PintarAutorizadosRechazados()
    End Sub

    Private Sub btn_ActualizarGrilla_Click(sender As Object, e As EventArgs) Handles btn_ActualizarGrilla.Click
        ActualizaGrilla()
    End Sub
End Class