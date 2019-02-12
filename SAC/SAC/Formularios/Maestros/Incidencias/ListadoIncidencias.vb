Public Class ListadoIncidencias : Implements INuevaIncidencia, ISeleccionNuevaIncidencia

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListadoIncidencias_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtDesde.Text = ""
        txtHasta.Text = ""

        _CargarEstados()
        _CargarTipos()

        For Each o As CheckedListBox In {clbEstados, clbTipos}
            For i = 0 To o.Items.Count - 1
                o.SetItemCheckState(i, CheckState.Checked)
            Next
        Next

        btnFiltrar_Click(Nothing, Nothing)
    End Sub

    Private Sub _CargarTipos()
        Dim WTipos As DataTable = GetAll("SELECT Tipo As Codigo, Descripcion FROM TiposINC ORDER BY Tipo")

        WTipos.Rows.Add(-1, "TODOS")

        WTipos.DefaultView.Sort = "Codigo"

        With CType(clbTipos, ListBox)
            .DataSource = WTipos
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
        End With
    End Sub

    Private Sub _CargarEstados()
        Dim WEstados As DataTable = GetAll("SELECT Estado As Codigo, Descripcion FROM EstadosINC ORDER BY Estado")

        WEstados.Rows.Add(-1, "TODOS")

        WEstados.DefaultView.Sort = "Codigo"

        With CType(clbEstados, ListBox)
            .DataSource = WEstados
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
        End With
    End Sub

    Private Function _GenerarStringConsulta(ByVal clb As CheckedListBox) As String

        Dim WString = ""

        For Each o As Object In clb.CheckedItems
            WString &= CType(o, DataRowView).Item("Codigo") & ","
        Next

        WString = WString.TrimEnd(",")
        Return WString

    End Function

    Private Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFiltrar.Click

        Dim WDesdeFecha As String = ordenaFecha(txtDesde.Text)
        Dim WHastaFecha As String = ordenaFecha(txtHasta.Text)

        '
        ' Armamos el filtro de los Estados en caso que corresponda.
        '
        Dim WFiltroEstados As String = ""

        If clbEstados.GetItemCheckState(0) <> CheckState.Checked Then
            For Each o As Object In clbEstados.CheckedItems
                WFiltroEstados &= CType(o, DataRowView).Item("Codigo") & ","
            Next
            WFiltroEstados = WFiltroEstados.TrimEnd(",")
        End If


        '
        ' Armamos el filtro de los Tipos en caso que corresponda.
        '
        Dim WFiltroTipos As String = ""

        If clbTipos.GetItemCheckState(0) <> CheckState.Checked Then
            For Each o As Object In clbTipos.CheckedItems
                WFiltroTipos &= CType(o, DataRowView).Item("Codigo") & ","
            Next
            WFiltroTipos = WFiltroTipos.TrimEnd(",")
        End If

        Dim ZSql = ""
        ZSql = "SELECT Incidencia, Fecha, Tipo, Estado, Titulo, Referencia, DescTipo = CASE ISNULL(Tipo, 0) WHEN 1 THEN 'General' WHEN 2 THEN 'Rechazo MP' ELSE '' END, " _
            & " DescEstado = CASE ISNULL(Estado, 0) WHEN 1 THEN 'Genera SAC' WHEN 2 THEN 'No Genera SAC' ELSE 'Pend. Análisis' END " _
            & " FROM CargaIncidencias WHERE Renglon = 1 "

        If Val(WDesdeFecha) <> 0 And Val(WHastaFecha) <> 0 Then
            ZSql &= " And FechaOrd BETWEEN '" & WDesdeFecha & "' And '" & WHastaFecha & "' "
        End If

        If WFiltroEstados.Trim <> "" Then ZSql &= " And Estado IN (" & WFiltroEstados & ") "
        If WFiltroTipos.Trim <> "" Then ZSql &= " And Tipo IN (" & WFiltroTipos & ") "

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


    Private Sub clbEstados_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles clbEstados.MouseUp
        With CType(sender, CheckedListBox)
            If .SelectedIndex = 0 Then
                For i = 1 To .Items.Count - 1

                    If .GetItemCheckState(0) = CheckState.Checked Then
                        .SetItemChecked(i, True)
                    Else
                        .SetItemChecked(i, False)
                    End If

                Next
            Else
                .SetItemChecked(0, False)
            End If
        End With
    End Sub

    Private Sub clbTipos_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles clbTipos.MouseUp
        With CType(sender, CheckedListBox)
            If .SelectedIndex = 0 Then
                For i = 1 To .Items.Count - 1

                    If .GetItemCheckState(0) = CheckState.Checked Then
                        .SetItemChecked(i, True)
                    Else
                        .SetItemChecked(i, False)
                    End If

                Next
            Else
                .SetItemChecked(0, False)
            End If
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim frm As New ListadoEstadosINC
        frm.ShowDialog(Me)
        '
        ' Recargamos la lista de Estados.
        '
        _CargarEstados()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New ListadoTiposINC
        frm.ShowDialog(Me)
        '
        ' Recargamos la lista de Tipos.
        '
        _CargarTipos()
    End Sub
End Class