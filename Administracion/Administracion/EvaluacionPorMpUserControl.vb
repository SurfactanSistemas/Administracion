Imports ConsultasVarias
Imports ConsultasVarias.Clases
Imports Microsoft.VisualBasic.Logging

Public Class EvaluacionPorMpUserControl

    Private WProveedor As String
    Private WMP As String

    Private Const YMARGEN = 2
    Private Const XMARGEN = 5
    Private WRow, Wcol As Integer

    Sub New(ByVal Proveedor As String, ByVal MP As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WProveedor = Proveedor
        WMP = MP

        dgvItemsEvaluados.SinClickDerecho = True

    End Sub

    Private Sub EvaluacionPorMpUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WRow = -1
        Wcol = -1

        Dim WFilas As New List(Of String) From {"", "Cuest Evaluacion Inicial", "Habilitacion / Licencias A: Proveedor", "Habilitacion / Licencias B: Fabricante", "GMP", "Especificacion con Vida Útil / Reanálisis", "Compromiso y Aviso de Cambios", "Trazabilidad", "Cumplimiento Envases", "FDS (En Español preferentemente)", "Hoja Técnica Completa", "Organigrama", "Impurezas Elementales", "Alergenos", "BSE/TSE", "GMO", "OVI/Residual Solvents", "Nano Partículas", "Decl. Contaminantes", "ISO 9001-2015", "BRC Food", "Kosher", "Halal", "Contramuestras", "Proceso/Ruta de Síntesis", "Métodos de Control", "Datos de la Molécula", "Irradiación - ETO - Aguas Madres", "Valores Nutricionales", "Apto para Dieta", "Control Terrorismo/BioTerrorismo", "Control de Plagas", "Orgánico", "Inorgánico", "A: Informa Fabricante - B: Es Fabricante"}

        For i = 1 To WFilas.Count - 1
            dgvItemsEvaluados.Rows.Add(i, WFilas(i), False, "", False, "", "", "", "", "")
        Next

        dgvItemsEvaluados.InhabilitarOrdenamientoColumnas()

        CheckForIllegalCrossThreadCalls = False

        For Each t As Control In {lblCodigo, lblDescripcion, lblDescComercial, txtFechaAux}
            t.Text = ""
            t.BackColor = Globales.WBackColorSecundario
        Next

        lblCodigo.Text = ""
        lblDescripcion.Text = ""
        lblDescComercial.Text = ""

        BackgroundWorker1.RunWorkerAsync()

        'Dim WDatosArticulo As DataRow = GetSingle("SELECT a.Codigo, a.Descripcion, m.Descripcion Comercial FROM Articulo a LEFT OUTER JOIN Marcas m ON m.Articulo = a.Codigo And m.Proveedor = '" & WProveedor & "' WHERE a.Codigo = '" & WMP & "'")

        'Dim WDatos As DataTable = GetAll("SELECT Renglon, Solicitado, FechaSolicitado, Entrego, FechaEntrego, Aprobo, FechaAprobo, FechaVto, Aclaraciones, EstadoMP FROM EvaluacionProvMP WHERE Proveedor = '" & WProveedor & "' And Articulo = '" & WMP & "' Order by Renglon * 1")

        'If WDatosArticulo IsNot Nothing Then
        '    With WDatosArticulo
        '        lblCodigo.Text = OrDefault(.Item("Codigo"), "")
        '        lblDescripcion.Text = Trim(OrDefault(.Item("Descripcion"), "")).ToUpper()
        '        lblDescComercial.Text = Trim(OrDefault(.Item("Comercial"), "")).ToUpper()
        '    End With
        'End If

        'Dim WEstado As Integer = 0

        'If WDatos IsNot Nothing Then

        '    For i = 1 To 34

        '        Dim WDato As DataRow() = WDatos.Select("Renglon = '" & i & "'")

        '        If WDato.Length > 0 Then
        '            With dgvItemsEvaluados.Rows(i - 1)
        '                .Cells("Solicitado").Value = Val(OrDefault(WDato(0).Item("Solicitado"), "")) = 1
        '                .Cells("Entrego").Value = Val(OrDefault(WDato(0).Item("Entrego"), "")) = 1
        '                .Cells("Aprobo").Value = Val(OrDefault(WDato(0).Item("Aprobo"), "")) = 1
        '                .Cells("FechaSolicitado").Value = Trim(OrDefault(WDato(0).Item("FechaSolicitado"), ""))
        '                .Cells("FechaEntrego").Value = Trim(OrDefault(WDato(0).Item("FechaEntrego"), ""))
        '                .Cells("FechaAprobo").Value = Trim(OrDefault(WDato(0).Item("FechaAprobo"), ""))
        '                .Cells("Vto").Value = Trim(OrDefault(WDato(0).Item("FechaVto"), ""))
        '                .Cells("Aclaraciones").Value = Trim(OrDefault(WDato(0).Item("Aclaraciones"), ""))
        '                WEstado = Val(OrDefault(WDato(0).Item("EstadoMP"), "0"))
        '            End With
        '        End If

        '    Next

        'End If

        'cmbCalificacion.SelectedIndex = WEstado

        'dgvItemsEvaluados.Columns("Vto").ReadOnly = True

        'With dgvItemsEvaluados
        '    .Rows(3).Cells("Vto").ReadOnly = False
        '    .Rows(18).Cells("Vto").ReadOnly = False
        '    .Rows(20).Cells("Vto").ReadOnly = False
        'End With

        'For Each row As DataGridViewRow In dgvItemsEvaluados.Rows
        '    _ColorearCondicional(row.Index)
        'Next

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim WDatosArticulo As DataRow = GetSingle("SELECT a.Codigo, a.Descripcion, m.Descripcion Comercial FROM Articulo a LEFT OUTER JOIN Marcas m ON m.Articulo = a.Codigo And m.Proveedor = '" & WProveedor & "' WHERE a.Codigo = '" & WMP & "'")

        Dim WDatos As DataTable = GetAll("SELECT Renglon, Solicitado, FechaSolicitado, Entrego, FechaEntrego, Aprobo, FechaAprobo, FechaVto, Aclaraciones, EstadoMP FROM EvaluacionProvMP WHERE Proveedor = '" & WProveedor & "' And Articulo = '" & WMP & "' Order by Renglon * 1")

        BackgroundWorker1.ReportProgress(1, WDatosArticulo)
        BackgroundWorker1.ReportProgress(2, WDatos)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        If e.ProgressPercentage = 1 Then
            Dim WDatosArticulo As DataRow = TryCast(e.UserState, DataRow)

            If WDatosArticulo IsNot Nothing Then
                With WDatosArticulo
                    lblCodigo.Text = OrDefault(.Item("Codigo"), "")
                    lblDescripcion.Text = Trim(OrDefault(.Item("Descripcion"), "")).ToUpper()
                    lblDescComercial.Text = Trim(OrDefault(.Item("Comercial"), "")).ToUpper()
                End With
            End If

            Exit Sub
        End If

        Dim WDatos As DataTable = TryCast(e.UserState, DataTable)

        Dim WEstado As Integer = 0

        If WDatos IsNot Nothing Then

            For i = 1 To 34

                Dim WDato As DataRow() = WDatos.Select("Renglon = '" & i & "'")

                If WDato.Length > 0 Then
                    With dgvItemsEvaluados.Rows(i - 1)
                        .Cells("Solicitado").Value = Val(OrDefault(WDato(0).Item("Solicitado"), "")) = 1
                        .Cells("Entrego").Value = Val(OrDefault(WDato(0).Item("Entrego"), "")) = 1
                        .Cells("Aprobo").Value = _ObtenerDescAprobo(Val(OrDefault(WDato(0).Item("Aprobo"), "")))
                        .Cells("FechaSolicitado").Value = Trim(OrDefault(WDato(0).Item("FechaSolicitado"), ""))
                        .Cells("FechaEntrego").Value = Trim(OrDefault(WDato(0).Item("FechaEntrego"), ""))
                        .Cells("FechaAprobo").Value = Trim(OrDefault(WDato(0).Item("FechaAprobo"), ""))
                        .Cells("Vto").Value = Trim(OrDefault(WDato(0).Item("FechaVto"), ""))
                        .Cells("Aclaraciones").Value = Trim(OrDefault(WDato(0).Item("Aclaraciones"), ""))
                        WEstado = Val(OrDefault(WDato(0).Item("EstadoMP"), "0"))
                    End With
                End If

            Next

        End If

        cmbCalificacion.SelectedIndex = WEstado

        'dgvItemsEvaluados.Columns("Vto").ReadOnly = True

        'With dgvItemsEvaluados

        '    For Each i As Short In {1, 2, 3, 18, 19, 20, 21}
        '        .Rows(i).Cells("Vto").ReadOnly = False
        '    Next

        'End With

    End Sub

    'Private Sub dgvItemsEvaluados_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemsEvaluados.CellEnter
    '    If e.ColumnIndex = 3 Then
    '        dgvItemsEvaluados.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = False
    '    End If
    'End Sub

    Public Function _ObtenerDatosItems() As DBDataGridView
        Return dgvItemsEvaluados
    End Function

    Public Function _ObtenerEstado() As Integer
        Return cmbCalificacion.SelectedIndex
    End Function

    Public Sub _DetenerASync()
        If BackgroundWorker1.IsBusy Then BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub dgvItemsEvaluados_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvItemsEvaluados.CellMouseClick

        If e.ColumnIndex = dgvItemsEvaluados.Columns("Doc").Index Then

            With New AgregarArchivosEvalProvMP(WProveedor, WMP, e.RowIndex + 1)
                .Show(Me)
            End With

        End If

    End Sub

    Private Sub _ColorearCondicional(ByVal id As Integer)

        If id < 0 Then Exit Sub

        'Try
        With dgvItemsEvaluados.Rows(id)

            For Each o As DataGridViewColumn In dgvItemsEvaluados.Columns
                .Cells(o.Index).Style.BackColor = Globales.WBackColorSecundario
            Next

            dgvItemsEvaluados.ClearSelection()

            If {1, 2, 3, 18, 19, 20, 21}.Contains(id) Then
                Dim WFechaVto As String = Trim(OrDefault(.Cells("Vto").Value, ""))

                If WFechaVto.Replace("/", "").Trim() <> "" Then

                    If Val(ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) >= Val(ordenaFecha(WFechaVto)) Then

                        For Each o As DataGridViewColumn In dgvItemsEvaluados.Columns
                            .Cells(o.Index).Style.BackColor = Color.LightCoral
                        Next

                        dgvItemsEvaluados.CurrentCell = .Cells("Aclaraciones")
                        Exit Sub
                    End If

                End If
            End If

            .Cells("Solicitado").Style.BackColor = IIf(Not .Cells("Solicitado").Value, Color.LightCoral, Globales.WBackColorSecundario)

            .Cells("Aprobo").Style.BackColor = Globales.WBackColorSecundario
            .Cells("Entrego").Style.BackColor = Globales.WBackColorSecundario

            If .Cells("Solicitado").Value Then
                If Not .Cells("Entrego").Value Then
                    .Cells("Entrego").Style.BackColor = Color.LightCoral
                End If
            End If

            If .Cells("Solicitado").Value And .Cells("Entrego").Value Then
                If Val(_ObtenerIDAprobo(OrDefault(.Cells("Aprobo").Value, ""))) = 0 Then
                    .Cells("Solicitado").Style.BackColor = Globales.WBackColorSecundario
                    .Cells("Entrego").Style.BackColor = Globales.WBackColorSecundario
                    .Cells("Aprobo").Style.BackColor = Color.LightCoral
                End If
            End If

        End With
        'Catch ex As Exception

        'End Try
    End Sub

    Private Function _ObtenerDescAprobo(ByVal i As Short) As String

        Select Case i
            Case 1
                Return "APROBADO"
            Case 2
                Return "NO APLICA"
            Case Else
                Return ""
        End Select

    End Function

    Private Function _ObtenerIDAprobo(ByVal s As String) As Integer

        Select Case s
            Case "APROBADO"
                Return 1
            Case "NO APLICA"
                Return 2
            Case Else
                Return 0
        End Select

    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        For Each row As DataGridViewRow In dgvItemsEvaluados.Rows
            _ColorearCondicional(row.Index)
        Next
    End Sub

    Private Sub dgvItemsEvaluados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemsEvaluados.CellContentClick
        If {2, 4, 6, 8}.Contains(e.ColumnIndex) Then dgvItemsEvaluados.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvItemsEvaluados_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemsEvaluados.CellValueChanged
        If {2, 4, 6, 8}.Contains(e.ColumnIndex) Then _ColorearCondicional(e.RowIndex)
    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Private Sub txtFechaAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaAux.KeyDown

        If e.KeyData = Keys.Enter Then

            With dgvItemsEvaluados

                If txtFechaAux.Text.Replace(" ", "").Length < 10 Then

                    .CurrentCell.Value = ""

                End If

                If WRow >= 0 And Wcol >= 0 Then

                    If Not _ValidarFecha(Trim(txtFechaAux.Text)) Then Exit Sub

                    .CurrentCell.Value = txtFechaAux.Text

                End If

                txtFechaAux.Visible = False
                txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.

                _ColorearCondicional(.CurrentCell.RowIndex)

                .CurrentCell = .Rows(WRow).Cells("Aclaraciones")

                .Focus()

            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If

    End Sub

    Private Sub dgvItemsEvaluados_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemsEvaluados.CellEnter
        With dgvItemsEvaluados
            'If e.ColumnIndex = 0 Then

            'End If

            cmbAux.DroppedDown = False

            Select Case e.ColumnIndex
                Case 3, 5, 7, 8

                    If (e.ColumnIndex = 8 AndAlso {1, 2, 3, 18, 19, 20, 21}.Contains(e.RowIndex)) Or e.ColumnIndex <> 8 Then

                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Globales.WBackColorSecundario

                        Dim iRow, iCol As Integer
                        iRow = e.RowIndex
                        iCol = e.ColumnIndex

                        Dim _location As Point = .GetCellDisplayRectangle(e.ColumnIndex, iRow, False).Location

                        .ClearSelection()
                        .CurrentCell.Style.SelectionBackColor = Globales.WBackColorSecundario ' Evitamos que se vea la seleccion de la celda.

                        _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                        _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
                        txtFechaAux.Location = _location
                        txtFechaAux.Text = .Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        WRow = e.RowIndex
                        Wcol = e.ColumnIndex
                        txtFechaAux.Visible = True
                        txtFechaAux.Focus()

                    Else
                        txtFechaAux.Visible = False
                    End If
                Case 6

                    .ClearSelection()
                    .CurrentCell.Style.SelectionBackColor = Globales.WBackColorSecundario ' Evitamos que se vea la seleccion de la celda.

                    cmbAux.Location = .GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location 'New Point(.Location.X, .Location.Y) '_location
                    cmbAux.Width = .CurrentCell.Size.Width
                    cmbAux.BackColor = .CurrentCell.Style.BackColor
                    cmbAux.ForeColor = .CurrentCell.Style.ForeColor

                    WRow = e.RowIndex
                    Wcol = e.ColumnIndex

                    cmbAux.Text = OrDefault(.CurrentCell.Value, "")
                    Threading.Thread.Sleep(100)
                    cmbAux.Visible = True
                    'cmbAux.DroppedDown = True
            End Select

        End With
    End Sub

    Private Sub dgvItemsEvaluados_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvItemsEvaluados.Scroll
        txtFechaAux.Visible = False
        cmbAux.DroppedDown = False
        cmbAux.Visible = False
    End Sub

    Private Sub cmbAux_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAux.DropDownClosed
        If WRow < 0 Or Wcol < 0 Then Exit Sub

        dgvItemsEvaluados.Rows(WRow).Cells(Wcol).Value = cmbAux.Text

        cmbAux.Visible = False

    End Sub
End Class
