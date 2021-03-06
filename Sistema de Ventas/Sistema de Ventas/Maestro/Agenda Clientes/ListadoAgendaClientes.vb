﻿Imports Util.Clases
Imports Util.Clases.Query

Public Class ListadoAgendaClientes :Implements INotificacionCambios

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvAgenda.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("Cliente LIKE '%{0}%' OR Fecha LIKE '%{0}%' OR Razon LIKE '%{0}%' OR Anotaciones LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub ListadoAgendaClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtDesde.Text = ""
        txtHasta.Text = ""

        CheckForIllegalCrossThreadCalls = False

        txtHasta_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub txtDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            'If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            'If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtFiltrar.Focus()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim WDesde As String = Helper.ordenaFecha(txtDesde.Text)
        Dim WHasta As String = Helper.ordenaFecha(txtHasta.Text)

        Dim WFiltroFechas As String

        If Val(WHasta) = 0 Or Val(WDesde) = 0 Then
            WFiltroFechas = ""
        ElseIf Val(WHasta) < Val(WDesde) Then
            MsgBox("Las Fechas deben ser contiguas.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            WFiltroFechas = " ac.FechaOrd BETWEEN '" & WDesde & "' AND '" & WHasta & "' AND"
        End If

        Dim WDatos As DataTable = GetAll("SELECT ac.ID, ac.Fecha, ac.Cliente, Razon = RTRIM(c.Razon), ac.Horario, Anotaciones = UPPER(RTRIM(ac.Anotaciones)) FROM AgendaClientes ac INNER JOIN Cliente c ON c.Cliente = ac.Cliente WHERE " & WFiltroFechas & " ac.Baja <> '1' ORDER BY ac.FechaOrd, ac.Cliente")

        WDatos.Columns.Add("Sel")

        BackgroundWorker1.ReportProgress(1, WDatos)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim tabla As DataTable = TryCast(e.UserState, DataTable)

        dgvAgenda.DataSource = tabla

        If tabla IsNot Nothing Then
            Dim WMax As DataRow = tabla.Rows.Cast(Of DataRow).First()
            Dim WMin As DataRow = tabla.Rows.Cast(Of DataRow).Last()

            If WMax IsNot Nothing And WMin IsNot Nothing Then
                txtHasta.Text = WMin("Fecha")
                txtDesde.Text = WMax("Fecha")
            End If

        End If

    End Sub

    Private Sub dgvAgenda_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAgenda.CellMouseClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

        If e.ColumnIndex = dgvAgenda.Columns("Sel").Index Then
            dgvAgenda.CurrentRow.Cells("Sel").Value = IIf(Val(Helper.OrDefault(dgvAgenda.CurrentRow.Cells("Sel").Value, "")) = 0, 1, 0)
        End If

    End Sub

    Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click

        Dim tabla As DataTable = TryCast(dgvAgenda.DataSource, DataTable)

        If tabla Is Nothing Then Exit Sub

        Dim Zsql As New List(Of String)

        For Each r As DataRow In tabla.Select("Sel = 1")
            Zsql.Add(String.Format("UPDATE AgendaClientes SET Baja = '1' WHERE ID = '{0}'", r("ID")))

            Dim WCli As DataRow = GetSingle(String.Format("SELECT Fecha, Anotacion, Hora, FechaII, HoraII, AnotacionII FROM Cliente WHERE Cliente = '{0}' And (Fecha = '{1}' Or FechaII = '{1}')", r("Cliente"), r("Fecha")))

            ' Limpiamos también la entrada en el formato viejo.
            If WCli IsNot Nothing Then
                Dim WFecha As String = Helper.OrDefault(WCli("Fecha"), "")

                If WFecha = r("Fecha") Then
                    Zsql.Add(String.Format("UPDATE Cliente Set Fecha = '  /  /    ', Hora = '', Anotacion = '' WHERE Cliente = '{0}'", r("Cliente")))
                Else
                    Zsql.Add(String.Format("UPDATE Cliente Set FechaII = '  /  /    ', HoraII = '', AnotacionII = '' WHERE Cliente = '{0}'", r("Cliente")))
                End If

            End If

        Next

        If Zsql.Count > 0 Then

            If MsgBox("¿Está seguro de dar de baja las entradas agendadas?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            ExecuteNonQueries(Zsql.ToArray)

            If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()

        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        With New AltaAgenda
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub NotificarCambios() Implements INotificacionCambios.NotificarCambios
        txtDesde.Text = ""
        txtHasta.Text = ""
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub dgvAgenda_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAgenda.CellMouseDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

        Dim Cli, Fec As String

        Cli = Helper.OrDefault(dgvAgenda.CurrentRow.Cells("Cliente").Value, "")
        Fec = Helper.OrDefault(dgvAgenda.CurrentRow.Cells("Fecha").Value, "")

        With New AltaAgenda(Cli, Fec)
            .ShowDialog(Me)
        End With

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim datos As DataTable = GetAll("SELECT ac.Fecha, ac.Cliente, c.Razon, c.Telefono, ac.Horario, Anotaciones = UPPER(ac.Anotaciones) FROM AgendaClientes ac INNER JOIN Cliente c ON c.Cliente = ac.Cliente WHERE Baja <> '1' And FechaOrd BETWEEN '" & Helper.ordenaFecha(txtDesde.Text) & "' And '" & Helper.ordenaFecha(txtHasta.Text) & "' ORDER BY ac.FechaOrd, ac.Cliente")

        If datos Is Nothing Then Exit Sub

        Dim tabla As DataTable = New DBAuxi.AgendaClientesDataTable

        For Each r As datarow In datos.Rows
            Dim t As DataRow = tabla.NewRow

            t("Cliente") = r("Cliente")
            t("Razon") = UCase(r("Razon"))
            t("Anotaciones") = r("Anotaciones")
            t("Horario") = r("Horario")
            t("Telefono") = r("Telefono")
            t("Fecha") = r("Fecha")
            t("FechaOrd") = Helper.ordenaFecha(r("Fecha"))

            tabla.Rows.Add(t)
        Next

        Dim rpt As New ReporteAgendaClientes

        rpt.SetDataSource(tabla)

        rpt.SetParameterValue("ImpreRangoFechas", String.Format("Entre Fechas {0} - {1}", txtDesde.Text, txtHasta))

        With New Util.VistaPrevia
            .Reporte = rpt
            .Mostrar()
        End With
    End Sub
End Class