Imports ConsultasVarias
Imports ConsultasVarias.Interfaces
Imports ConsultasVarias.Clases
Imports ConsultasVarias.Clases.Helper
Imports ConsultasVarias.Clases.Query

Public Class ListadoHojasPTPorCodigo : Implements IAyudaMPs, IExportar

    Enum EstadosLaudos
        Aprobado = 1
        PorDesvio = 2
        Rechazado = 3
        SinActualizar = 4
    End Enum

    Private Sub ListadoLaudosMPPorCodigo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Dim WEstados As New DataTable

        txtDescMP.BackColor = Globales.WBackColorTerciario

        With WEstados
            .Columns.Add("Estado", GetType(Integer))
            .Columns.Add("Descripcion")
            .Rows.Add(0, "TODOS")
            .Rows.Add(EstadosLaudos.Aprobado, "APROBADOS")
            .Rows.Add(EstadosLaudos.PorDesvio, "POR DESVIO")
            .Rows.Add(EstadosLaudos.Rechazado, "RECHAZADOS")
            .Rows.Add(EstadosLaudos.SinActualizar, "SIN ANALIZAR")
        End With

        With CType(clbEstados, ListBox)
            .DataSource = WEstados
            .DisplayMember = "Descripcion"
            .ValueMember = "Estado"
        End With

        Dim WPlantas As New DataTable

        With WPlantas
            .Columns.Add("Planta", GetType(Integer))
            .Columns.Add("Descripcion")
            .Columns.Add("Base")
            .Rows.Add(0, "TODOS", "")
            .Rows.Add(1, "SURFACTAN I", "SurfactanSa")
            .Rows.Add(2, "SURFACTAN II", "Surfactan_II")
            .Rows.Add(3, "SURFACTAN III", "Surfactan_III")
            .Rows.Add(4, "SURFACTAN IV", "Surfactan_IV")
            .Rows.Add(5, "SURFACTAN V", "Surfactan_V")
            .Rows.Add(6, "SURFACTAN VI", "Surfactan_IV")
            .Rows.Add(7, "SURFACTAN VII", "Surfactan_VII")
        End With

        With CType(clbPlantas, ListBox)
            .DataSource = WPlantas
            .DisplayMember = "Descripcion"
            .ValueMember = "Planta"
        End With

        For Each o As CheckedListBox In {clbEstados, clbPlantas}
            For i = 0 To o.Items.Count - 1
                o.SetItemCheckState(i, CheckState.Checked)
            Next
        Next

        cmbOrdenI.SelectedIndex = 0
        cmbOrdenII.SelectedIndex = 1
        cmbOrdenIII.SelectedIndex = 2

        For Each c As Control In {txtCodigo, txtDescMP, txtFechaDesde, txtFechaHasta}
            c.Text = ""
        Next

        ckIncluirHistoricos.Checked = False
        ckIncluirSEs.Checked = False

    End Sub

    Private Sub clbEstados_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles clbEstados.MouseUp, clbPlantas.MouseUp
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

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtCodigo.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            txtDescMP.Text = ""

            Dim WCodigo As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")

            If WCodigo Is Nothing Then Exit Sub

            txtDescMP.Text = Trim(OrDefault(WCodigo.Item("Descripcion"), ""))

            btnListar_Click(Nothing, Nothing)

            txtFechaDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub txtFechaDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not _ValidarFecha(txtFechaDesde.Text) Then Exit Sub

            txtFechaHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaDesde.Text = ""
        End If

    End Sub

    Private Function _ObtenerCampoDeOrdenamiento(ByVal c As ComboBox) As String

        Select Case c.SelectedIndex
            Case 0
                Return "FechaOrd DESC"
            Case 1
                Return "idPlanta"
            Case 2
                Return "idEstado"
        End Select
        Return ""
    End Function

    Private Function _GenerarCadenaOrdenamiento() As String

        Dim WOrdenI, WOrdenII, WOrdenIII, WOrden As String

        WOrdenI = _ObtenerCampoDeOrdenamiento(cmbOrdenI)
        WOrdenII = _ObtenerCampoDeOrdenamiento(cmbOrdenII)
        WOrdenIII = _ObtenerCampoDeOrdenamiento(cmbOrdenIII)

        WOrden &= WOrdenI & ","
        If Not WOrden.Contains(WOrdenII) Then WOrden &= WOrdenII & ","
        If Not WOrden.Contains(WOrdenIII) Then WOrden &= WOrdenIII

        Return WOrden.TrimEnd(",")

    End Function

    Private Sub btnListar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnListar.Click

        Dim WCodigo As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")

        If IsNothing(WCodigo) Then Exit Sub

        dgvLaudos.DataSource = Nothing

        Dim WDatos As New DataTable

        With WDatos
            .Columns.Add("Fecha")
            .Columns.Add("FechaOrd", GetType(Integer))
            .Columns.Add("idEstado", GetType(Integer))
            .Columns.Add("Hoja", GetType(Integer))
            .Columns.Add("Estado")
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Columns.Add("Cantidad")
            .Columns.Add("idPlanta", GetType(Integer))
            .Columns.Add("Planta")
        End With

        Dim WEstados As List(Of Integer) = clbEstados.CheckedIndices.Cast(Of Integer)().ToList()

        Dim WFiltroInventariadas As String = " h.Marca <> 'X' And "

        If ckIncluirHistoricos.Checked Then WFiltroInventariadas = ""


        Dim WFechaDesdeOrd, WFechaHastaOrd As String

        WFechaDesdeOrd = ordenaFecha(txtFechaDesde.Text)
        WFechaHastaOrd = ordenaFecha(txtFechaHasta.Text)

        Dim WFiltroFecha As String = ""

        If Val(WFechaDesdeOrd) <> 0 And Val(WFechaHastaOrd) <> 0 Then
            WFiltroFecha = " h.FechaOrd BETWEEN '" & WFechaDesdeOrd & "' And '" & WFechaHastaOrd & "' And "
        End If


        For Each p As Object In clbPlantas.CheckedItems

            Dim _Datos As DataTable
            Dim WDescEmpresa As String = ""
            Dim WidEmpresa As Integer = 0

            With CType(p, DataRowView)
                Dim emp As String = .Item("Base")

                If emp = "" Then Continue For

                WDescEmpresa = .Item("Descripcion")
                WidEmpresa = .Item("Planta")

                Dim WProd As String = txtCodigo.Text.PadRight(12, " ").Substring(2, 10)

                _Datos = GetAll("SELECT h.Fecha, h.Hoja, h.MarcaLabora, h.Producto, DescTerminado = t.Descripcion, h.Marca, h.Teorico, Cantidad = CASE ISNULL(h.Marca, '') WHEN 'X' THEN h.Realant ELSE h.Real END, Real = CASE ISNULL(h.Marca, '') WHEN 'X' THEN h.Realant ELSE h.Real END FROM Hoja h INNER JOIN Terminado t ON t.Codigo = h.Producto where " & WFiltroInventariadas & WFiltroFecha & " h.Producto LIKE '%" & WProd & "' And h.Renglon = 1 order by h.FechaOrd", emp)
            End With

            For Each row As DataRow In _Datos.Rows
                With row
                    Dim _r As DataRow = WDatos.NewRow

                    Dim WTipoProd As String = Microsoft.VisualBasic.Left(.Item("Producto"), 2)
                    Dim WRealControl As String = OrDefault(.Item("Real"), 0)

                    _r.Item("idEstado") = _DeterminarIDEstado(WTipoProd, WRealControl)
                    _r.Item("Estado") = _DeterminarDescEstado(_r.Item("idEstado"))

                    _r.Item("Codigo") = UCase(.Item("Producto"))
                    _r.Item("Descripcion") = Trim(OrDefault(.Item("DescTerminado"), ""))

                    If Not WEstados.ToList.Contains(_r.Item("idEstado")) Then Continue For
                    If Microsoft.VisualBasic.Left(_r.Item("Codigo"), 2).ToUpper = "SE" And Not ckIncluirSEs.Checked Then Continue For

                    _r.Item("Fecha") = OrDefault(.Item("Fecha"), "  /  /    ")
                    _r.Item("FechaOrd") = ordenaFecha(_r.Item("Fecha"))
                    _r.Item("Hoja") = OrDefault(.Item("Hoja"), 0)
                    _r.Item("Cantidad") = formatonumerico(OrDefault(.Item("Cantidad"), "0"))

                    If Val(_r.Item("Cantidad")) = 0 Then _r.Item("Cantidad") = formatonumerico(OrDefault(.Item("Teorico"), "0"))

                    _r.Item("idPlanta") = WidEmpresa
                    _r.Item("Planta") = WDescEmpresa

                    WDatos.Rows.Add(_r)
                End With
            Next

        Next

        Dim WOrden As String = _GenerarCadenaOrdenamiento()

        WDatos.DefaultView.Sort = WOrden

        dgvLaudos.DataSource = WDatos

        For Each col As String In {"FechaOrd", "idEstado", "idPlanta"}
            Dim c As DataGridViewColumn = dgvLaudos.Columns(col)
            If c IsNot Nothing Then c.Visible = False
        Next

        For Each col As DataGridViewColumn In dgvLaudos.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            col.MinimumWidth = 90
        Next

        Dim _c As DataGridViewColumn = dgvLaudos.Columns("Descripcion")
        If _c IsNot Nothing Then
            _c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _c.MinimumWidth = 200
        End If

        _c = dgvLaudos.Columns("PartiOri")
        If _c IsNot Nothing Then
            _c.HeaderText = "Lote Prov."
        End If

        For Each s As String In {"Cantidad", "OC", "Informe", "Planta", "PartiOri", "Proveedor", "Hoja"}
            _c = dgvLaudos.Columns(s)
            If _c IsNot Nothing Then _c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

        dgvLaudos.InhabilitarOrdenamientoColumnas()

    End Sub

    Private Function _DeterminarIDEstado(ByVal Estado As String, ByVal WReal As Double) As Integer

        Dim ID As Integer = 0

        Select Case UCase(Estado)
            Case "PT", "SE"
                ID = 1
            Case "RE"
                ID = 2
            Case "NK"
                ID = 3
            Case Else
                Return 0
        End Select

        If WReal = 0 Then Return 4

        Return ID

    End Function

    Private Function _DeterminarDescEstado(ByVal Lote As Object) As String

        Select Case Val(Lote)
            Case 1
                Return "APROBADO"
            Case 2
                Return "POR DESVIO"
            Case 3
                Return "RECHAZADO"
            Case 4
                Return "SIN ACTUALIZAR"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub txtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not _ValidarFecha(txtFechaHasta.Text) Then Exit Sub

            btnListar_Click(Nothing, Nothing)

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaHasta.Text = ""
        End If

    End Sub

    Private Sub txtCodigo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtCodigo.DoubleClick
        With New AyudaMPs
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaMPs(ByVal Codigo As String, ByVal Descripcion As String) Implements IAyudaMPs._ProcesarAyudaMPs
        txtCodigo.Text = Codigo
        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem5.Click
        dgvLaudos.CopiarSeleccion()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem6.Click
        dgvLaudos.CopiarSeleccion(True)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        With New DetalleMovimientosPT(dgvLaudos.CurrentRow.Cells("Hoja").Value, ckIncluirHistoricos.Checked)
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem2.Click
        With New DetallesEnsayosPT(dgvLaudos.CurrentRow.Cells("Hoja").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub dgvLaudos_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvLaudos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        ToolStripMenuItem2_Click(Nothing, Nothing)
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportar.Click
        With New Exportar
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarExportar(ByVal TipoSalida As [Enum]) Implements IExportar._ProcesarExportar
        Dim frm As New VistaPrevia
        Dim rpt As New ReporteExportarListadoHojasPTPorCodigo
        Dim data As DataTable = (New DSAuxi).Tables("DetalleListadoLaudosMPPorCodigo").Clone

        For Each row As DataGridViewRow In dgvLaudos.Rows
            Dim _r As DataRow = data.NewRow
            With _r
                .Item("Codigo") = txtCodigo.Text
                .Item("DescMP") = txtDescMP.Text
                .Item("Laudo") = OrDefault(row.Cells("Hoja").Value, 0)
                .Item("Fecha") = OrDefault(row.Cells("Fecha").Value, "")
                .Item("FechaOrd") = OrDefault(row.Cells("FechaOrd").Value, 0)
                .Item("Planta") = OrDefault(row.Cells("Planta").Value, "")
                .Item("Auxi1") = OrDefault(row.Cells("Producto").Value, "")
                .Item("Auxi2") = OrDefault(row.Cells("Descripcion").Value, "")
                .Item("Cantidad") = Val(OrDefault(row.Cells("Cantidad").Value, 0))

                If txtFechaDesde.Text.Replace(" ", "").Length = 10 And txtFechaHasta.Text.Replace(" ", "").Length = 10 Then
                    .Item("ImpreEmision") = String.Format("Hojas de Producción Entre {0} al {1}", txtFechaDesde.Text, txtFechaHasta.Text)
                Else
                    .Item("ImpreEmision") = String.Format("Hojas de Producción al {0}", Date.Now.ToString("dd/MM/yyyy"))
                End If

            End With

            data.Rows.Add(_r)
        Next

        rpt.SetDataSource(data)

        With frm
            .Reporte = rpt
        End With

        _ExportarReporte(frm, TipoSalida, "Listado de Laudos de MP (" & txtCodigo.Text & ")")

    End Sub

    Private Sub cmbOrdenI_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOrdenI.SelectedIndexChanged

    End Sub

    Private Sub cmbOrdenI_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOrdenIII.DropDownClosed, cmbOrdenII.DropDownClosed, cmbOrdenI.DropDownClosed
        btnListar_Click(Nothing, Nothing)
    End Sub
End Class