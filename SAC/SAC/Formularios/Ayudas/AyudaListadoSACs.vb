Public Class AyudaListadoSACs

    Private Sub AyudaListadoSACs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        Dim WTipos As DataTable = GetAll("SELECT Codigo, LTRIM(Descripcion) Descripcion FROM TipoSac")
        With WTipos
            .Rows.Add(0, "Todos")
            .DefaultView.Sort = "Codigo ASC"
        End With

        With cmbTipo
            .DataSource = WTipos
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .SelectedIndex = 0
        End With

        cmbEstados.SelectedIndex = 0
        cmbOrigenes.SelectedIndex = 0

        Dim WEmisores As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        With WEmisores
            .Rows.Add(0, "Todos")
            .DefaultView.Sort = "Codigo"
        End With

        With cmbEmisores
            .DataSource = WEmisores
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .SelectedIndex = 0
        End With

        Dim WCentros As DataTable = GetAll("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM CentroSac WHERE ISNULL(Descripcion, '') <> '' ORDER BY Descripcion")

        With WCentros
            .Rows.Add(0, "Todos")
            .DefaultView.Sort = "Codigo"
        End With

        With cmbCentros
            .DataSource = WCentros
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .SelectedIndex = 0
        End With

        Dim WResponsables As DataTable = WEmisores.Copy

        WResponsables.DefaultView.Sort = "Codigo"

        With cmbResponsables
            .DataSource = WResponsables
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .SelectedIndex = 0
        End With

        BackgroundWorker1.RunWorkerAsync()
        With dgvListado
            With .DefaultCellStyle
                .BackColor = WBackColorSecundario
                .SelectionBackColor = Globales.WBackColorTerciario
                .SelectionForeColor = Color.White
            End With
            For Each c As DataGridViewColumn In .Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim WFiltros As String = ""

            If cmbTipo.SelectedIndex > 0 Then
                If WFiltros <> "" Then WFiltros &= " AND "
                WFiltros &= "Tipo = '" & OrDefault(CType(cmbTipo.SelectedItem, DataRowView).Item("Codigo"), 0) & "'"
            End If

            If cmbEstados.SelectedIndex > 0 Then
                If WFiltros <> "" Then WFiltros &= " AND "
                WFiltros &= "Estado = '" & cmbEstados.SelectedIndex & "'"
            End If

            If cmbOrigenes.SelectedIndex > 0 Then
                If WFiltros <> "" Then WFiltros &= " AND "
                WFiltros &= "Origen = '" & cmbOrigenes.SelectedIndex & "'"
            End If

            If cmbEmisores.SelectedIndex > 0 Then
                If WFiltros <> "" Then WFiltros &= " AND "
                WFiltros &= "ResponsableEmisor = '" & OrDefault(CType(cmbEmisores.SelectedItem, DataRowView).Item("Codigo"), 0) & "'"
            End If

            If cmbResponsables.SelectedIndex > 0 Then
                If WFiltros <> "" Then WFiltros &= " AND "
                WFiltros &= "ResponsableDestino = '" & OrDefault(CType(cmbResponsables.SelectedItem, DataRowView).Item("Codigo"), 0) & "'"
            End If

            If cmbCentros.SelectedIndex > 0 Then
                If WFiltros <> "" Then WFiltros &= " AND "
                WFiltros &= "Centro = '" & OrDefault(CType(cmbCentros.SelectedItem, DataRowView).Item("Codigo"), 0) & "'"
            End If

            If WFiltros <> "" Then
                WFiltros = " WHERE " & WFiltros
            End If

            Dim WSacs As DataTable = GetAll("SELECT Clave, ID = cast(Numero as varchar(6)) + ' / ' + cast(Ano as char(4)), Tipo, DescTipo = CASE WHEN ISNULL(t.Abreviatura, '') = '' THEN LTRIM(RTRIM(t.Descripcion)) ELSE LTRIM(RTRIM(t.Abreviatura)) END, Titulo = CASE WHEN LTRIM(Titulo) = '' THEN LTRIM(Referencia) ELSE LTRIM(Titulo) END FROM CargaSAC cs LEFT OUTER JOIN TipoSac t ON t.Codigo = cs.Tipo " & WFiltros & " Order by Ano Desc, Tipo, Numero")
            BackgroundWorker1.ReportProgress(10, WSacs)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        dgvListado.DataSource = CType(e.UserState, DataTable)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        With dgvListado
            If .Rows.Count > 0 Then
                .CurrentCell = .Rows(0).Cells("ID")
                .Focus()
            End If
        End With
    End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        Try
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

            Visible = False

            Dim WClaveSAC = OrDefault(dgvListado.CurrentRow.Cells("Clave").Value, "")

            If Trim(WClaveSAC) = "" Then Exit Sub

            Dim WOwner As IAyudaListadoSACs = CType(Owner, IAyudaListadoSACs)

            If WOwner IsNot Nothing Then WOwner._ProcesarAyudaListadoSACs(WClaveSAC)

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbTipo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.DropDownClosed, cmbEstados.DropDownClosed, cmbOrigenes.DropDownClosed, cmbEmisores.DropDownClosed, cmbResponsables.DropDownClosed, cmbCentros.DropDownClosed
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class