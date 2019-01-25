Public Class ListadoIncidencias : Implements INuevaIncidencia, ISeleccionNuevaIncidencia

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListadoIncidencias_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtDesde.Text = ""
        txtHasta.Text = ""
        cmbEstados.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0

        btnFiltrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFiltrar.Click

        Dim WDesdeFecha As String = ordenaFecha(txtDesde.Text)
        Dim WHastaFecha As String = ordenaFecha(txtHasta.Text)
        Dim WEstado As Integer = IIf(cmbEstados.SelectedIndex > 0, cmbEstados.SelectedIndex, 0)
        Dim WTipoIncidencia As Integer = IIf(cmbTipo.SelectedIndex > 0, cmbTipo.SelectedIndex, 0)

        Dim ZSql = ""
        ZSql = "SELECT Incidencia, Fecha, Tipo, Estado, Titulo, Referencia, DescTipo = CASE ISNULL(Tipo, 0) WHEN 1 THEN 'General' WHEN 2 THEN 'Rechazo MP' ELSE '' END, " _
            & " DescEstado = CASE ISNULL(Estado, 0) WHEN 1 THEN 'Genera SAC' WHEN 2 THEN 'No Genera SAC' ELSE 'Pend. Análisis' END " _
            & " FROM CargaIncidencias WHERE Renglon = 1 "

        If Val(WDesdeFecha) <> 0 And Val(WHastaFecha) <> 0 Then
            ZSql &= " And FechaOrd BETWEEN '" & WDesdeFecha & "' And '" & WHastaFecha & "' "
        End If

        If WEstado <> 0 Then
            WEstado -= 1
            ZSql &= " And Estado = '" & WEstado & "'"
        End If

        If WTipoIncidencia <> 0 Then
            ZSql &= " And Tipo = '" & WTipoIncidencia & "'"
        End If

        ZSql &= " Order by Incidencia"

        Dim WIncidencias As DataTable = GetAll(ZSql)

        dgvIncidencias.DataSource = WIncidencias

        txtDesde.Focus()

    End Sub

    Private Sub ListadoIncidencias_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not _ValidarFecha(txtDesde.Text) Then Exit Sub

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHasta.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not _ValidarFecha(txtHasta.Text) Then Exit Sub

            With cmbEstados
                .DroppedDown = True
                .Focus()
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If
    End Sub

    Private Sub cmbEstados_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbEstados.KeyDown, cmbTipo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(cmbEstados.Text) = "" Then : Exit Sub : End If

            btnFiltrar.PerformClick()

        End If

    End Sub

    Private Sub cmbEstados_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEstados.DropDownClosed, cmbTipo.DropDownClosed
        btnFiltrar.PerformClick()
    End Sub

    Private Sub dgvIncidencias_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvIncidencias.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WIncidencia As Integer = OrDefault(dgvIncidencias.CurrentRow.Cells("Incidencia").Value, 0)
        Dim WTipo As Integer = OrDefault(dgvIncidencias.CurrentRow.Cells("Tipo").Value, -1)

        If WIncidencia = 0 Then Exit Sub
        If WTipo = -1 Then Exit Sub

        Select Case WTipo
            Case TipoIncidencias.General
                With New DetallesIncidencia(WIncidencia)
                    .Show(Me)
                End With
            Case TipoIncidencias.RechazoMP
                With New DetallesIncidenciaRechazoMP(WIncidencia)
                    .Show(Me)
                End With
        End Select

    End Sub

    Public Sub _ProcesarNuevaIncidencia(ByVal WIncidencia As Object) Implements INuevaIncidencia._ProcesarNuevaIncidencia
        btnFiltrar.PerformClick()
    End Sub

    Private Sub btnNuevaIncidencia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevaIncidencia.Click
        With New SeleccionTipoIncidencia
            .Show(Me)
        End With
    End Sub

    Public Sub ISeleccionNuevaIncidencia__ProcesarNuevaIncidencia(ByVal opt As Object) Implements ISeleccionNuevaIncidencia._ProcesarNuevaIncidencia
        Select Case CType(opt, TipoIncidencias)
            Case TipoIncidencias.General
                With New DetallesIncidencia
                    .Show(Me)
                End With
            Case TipoIncidencias.RechazoMP
                With New DetallesIncidenciaRechazoMP
                    .Show(Me)
                End With
        End Select
    End Sub
End Class