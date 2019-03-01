Imports ConsultasVarias
Imports ConsultasVarias.Interfaces
Imports ConsultasVarias.Clases
Imports ConsultasVarias.Clases.Helper
Imports ConsultasVarias.Clases.Query

Public Class ListadoLaudosMPPorCodigo : Implements IAyudaMPs, IExportar

    Enum EstadosLaudos
        Aprobado = 1
        PorDesvio = 2
        Rechazado = 3
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

            Dim WCodigo As DataRow = Query.GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")

            If WCodigo Is Nothing Then Exit Sub

            txtDescMP.Text = Trim(Helper.OrDefault(WCodigo.Item("Descripcion"), ""))

            btnListar_Click(Nothing, Nothing)

            txtFechaDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub txtFechaDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtFechaDesde.Text) Then Exit Sub

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
                Return "Proveedor"
            Case 3
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

        Dim WCodigo As DataRow = Query.GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")

        If IsNothing(WCodigo) Then Exit Sub

        dgvLaudos.DataSource = Nothing

        Dim WDatos As New DataTable

        With WDatos
            .Columns.Add("Fecha")
            .Columns.Add("FechaOrd", GetType(Integer))
            .Columns.Add("idEstado", GetType(Integer))
            .Columns.Add("Laudo", GetType(Integer))
            .Columns.Add("Estado")
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Columns.Add("Cantidad")
            .Columns.Add("idPlanta", GetType(Integer))
            .Columns.Add("Planta")
            .Columns.Add("PartiOri")
            .Columns.Add("Proveedor", GetType(Long))
            .Columns.Add("DescProveedor")
            .Columns.Add("OC")
            .Columns.Add("Informe")
        End With

        Dim WEstados As List(Of Integer) = clbEstados.CheckedIndices.Cast(Of Integer)().ToList()

        Dim WFiltroInventariadas As String = " l.Marca <> 'X' And "

        If ckIncluirHistoricos.Checked Then WFiltroInventariadas = ""


        Dim WFechaDesdeOrd, WFechaHastaOrd As String

        WFechaDesdeOrd = ordenaFecha(txtFechaDesde.Text)
        WFechaHastaOrd = ordenaFecha(txtFechaHasta.Text)

        Dim WFiltroFecha As String = ""

        If Val(WFechaDesdeOrd) <> 0 And Val(WFechaHastaOrd) <> 0 Then
            WFiltroFecha = " l.FechaOrd BETWEEN '" & WFechaDesdeOrd & "' And '" & WFechaHastaOrd & "' And "
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

                _Datos = GetAll("SELECT l.Fecha, l.Laudo, l.Articulo, DescArticulo = '', l.Marca, Cantidad = CASE ISNULL(l.Marca, '') WHEN 'X' THEN l.Liberadaant + l.Devueltaant ELSE l.Liberada + l.Devuelta + l.Rechazo END, l.PartiOri, l.Orden, l.Informe, i.Proveedor, p.Nombre DescProveedor FROM Laudo l INNER JOIN Informe i ON l.Orden = i.Orden And l.informe = i.informe And l.Articulo = i.Articulo LEFT OUTER JOIN Proveedor p ON p.Proveedor = i.Proveedor where " & WFiltroInventariadas & WFiltroFecha & " l.Articulo = '" & txtCodigo.Text & "' order by l.FechaOrd", emp)

            End With

            For Each row As DataRow In _Datos.Rows
                With row
                    Dim _r As DataRow = WDatos.NewRow

                    _r.Item("Estado") = _DeterminarDescEstado(.Item("Laudo"), WidEmpresa)
                    _r.Item("idEstado") = _DeterminarIDEstado(_r.Item("Estado"))

                    If Not WEstados.ToList.Contains(_r.Item("idEstado")) Then Continue For

                    _r.Item("Fecha") = OrDefault(.Item("Fecha"), "  /  /    ")
                    _r.Item("FechaOrd") = ordenaFecha(_r.Item("Fecha"))
                    _r.Item("Codigo") = OrDefault(.Item("Articulo"), "")
                    _r.Item("Laudo") = OrDefault(.Item("Laudo"), 0)
                    _r.Item("Descripcion") = Trim(OrDefault(.Item("DescArticulo"), ""))
                    _r.Item("Cantidad") = formatonumerico(OrDefault(.Item("Cantidad"), "0"))
                    _r.Item("idPlanta") = WidEmpresa
                    _r.Item("Planta") = WDescEmpresa
                    _r.Item("PartiOri") = Trim(OrDefault(.Item("PartiOri"), ""))
                    _r.Item("Proveedor") = Val(OrDefault(.Item("Proveedor"), ""))
                    _r.Item("DescProveedor") = Trim(OrDefault(.Item("DescProveedor"), ""))
                    _r.Item("OC") = Trim(OrDefault(.Item("Orden"), ""))
                    _r.Item("Informe") = Trim(OrDefault(.Item("Informe"), ""))

                    WDatos.Rows.Add(_r)
                End With
            Next

        Next

        Dim WOrden As String = _GenerarCadenaOrdenamiento()

        WDatos.DefaultView.Sort = WOrden

        dgvLaudos.DataSource = WDatos

        For Each col As String In {"FechaOrd", "idEstado", "Codigo", "Descripcion", "idPlanta"}
            Dim c As DataGridViewColumn = dgvLaudos.Columns(col)
            If c IsNot Nothing Then c.Visible = False
        Next

        For Each col As DataGridViewColumn In dgvLaudos.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            col.MinimumWidth = 70
        Next

        Dim _c As DataGridViewColumn = dgvLaudos.Columns("DescProveedor")
        If _c IsNot Nothing Then
            _c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _c.MinimumWidth = 200
        End If

        _c = dgvLaudos.Columns("PartiOri")
        If _c IsNot Nothing Then
            _c.HeaderText = "Lote Prov."
        End If

        For Each s As String In {"Cantidad", "OC", "Informe", "Planta", "PartiOri", "Proveedor", "Laudo"}
            _c = dgvLaudos.Columns(s)
            If _c IsNot Nothing Then _c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

        dgvLaudos.InhabilitarOrdenamientoColumnas()

    End Sub

    Private Function _DeterminarIDEstado(ByVal Estado As String) As Integer

        Select Case UCase(Estado)
            Case "APROBADO"
                Return 1
            Case "DESVÍO", "DESVIO"
                Return 2
            Case "RECHAZADO"
                Return 3
            Case Else
                Return 0
        End Select

    End Function

    Private Function _DeterminarDescEstado(ByVal Lote As Object, ByVal widEmpresa As Integer) As String

        Dim WLote As Integer = OrDefault(Lote, 0)

        If widEmpresa = 1 Then

            If WLote >= 100000 And WLote <= 189999 Then Return "APROBADO"
            If WLote >= 900000 And WLote <= 989999 Then Return "APROBADO"
            If WLote >= 190000 And WLote <= 194999 Then Return "DESVÍO"
            If WLote >= 990000 And WLote <= 994999 Then Return "DESVÍO"
            If WLote >= 70000 And WLote <= 70999 Then Return "RECHAZADO"
            If WLote >= 995000 And WLote <= 999999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 2 Then

            If WLote >= 200000 And WLote <= 289999 Then Return "APROBADO"
            If WLote >= 290000 And WLote <= 294999 Then Return "DESVÍO"
            If WLote >= 74000 And WLote <= 74999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 3 Then

            If WLote >= 300000 And WLote <= 389999 Then Return "APROBADO"
            If WLote >= 390000 And WLote <= 394999 Then Return "DESVÍO"
            If WLote >= 78000 And WLote <= 78999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 4 Then

            If WLote >= 400000 And WLote <= 489999 Then Return "APROBADO"
            If WLote >= 490000 And WLote <= 494999 Then Return "DESVÍO"
            If WLote >= 75000 And WLote <= 75999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 5 Then

            If WLote >= 500000 And WLote <= 519999 Then Return "APROBADO"
            If WLote >= 590000 And WLote <= 594000 Then Return "DESVÍO"
            If WLote >= 72000 And WLote <= 72399 Then Return "RECHAZADO"

        ElseIf widEmpresa = 6 Then

            If WLote >= 520000 And WLote <= 539999 Then Return "APROBADO"
            If WLote >= 570000 And WLote <= 574999 Then Return "DESVÍO"
            If WLote >= 72400 And WLote <= 72699 Then Return "RECHAZADO"

        ElseIf widEmpresa = 7 Then

            If WLote >= 540000 And WLote <= 559999 Then Return "APROBADO"
            If WLote >= 580000 And WLote <= 584999 Then Return "DESVÍO"
            If WLote >= 72700 And WLote <= 72999 Then Return "RECHAZADO"

        End If

        Return ""
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

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        With New DetalleMovimientosMP(dgvLaudos.CurrentRow.Cells("Laudo").Value, ckIncluirHistoricos.Checked)
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        With New DetallesEnsayosMP(dgvLaudos.CurrentRow.Cells("Laudo").Value)
            .Show(Me)
        End With
    End Sub

    Private Sub dgvLaudos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLaudos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        ToolStripMenuItem2_Click(Nothing, Nothing)
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        With New Exportar
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarExportar(ByVal TipoSalida As [Enum]) Implements IExportar._ProcesarExportar
        Dim frm As New VistaPrevia
        Dim rpt As New ReporteExportarListadoLaudoMPPorCodigo
        Dim data As DataTable = (New DSAuxi).Tables("DetalleListadoLaudosMPPorCodigo").Clone

        For Each row As datagridviewrow In dgvLaudos.rows
            Dim _r As DataRow = data.NewRow
            With _r
                .Item("Codigo") = txtCodigo.Text
                .Item("DescMP") = txtDescMP.Text
                .Item("Laudo") = OrDefault(row.Cells("Laudo").Value, 0)
                .Item("Fecha") = OrDefault(row.Cells("Fecha").Value, "")
                .Item("FechaOrd") = OrDefault(row.Cells("FechaOrd").Value, 0)
                .Item("Planta") = OrDefault(row.Cells("Planta").Value, "")
                .Item("Proveedor") = OrDefault(row.Cells("Proveedor").Value, 0)
                .Item("DescProveedor") = OrDefault(row.Cells("DescProveedor").Value, "")
                .Item("Orden") = OrDefault(row.Cells("OC").Value, 0)
                .Item("Informe") = OrDefault(row.Cells("Informe").Value, 0)
                .Item("Cantidad") = Val(OrDefault(row.Cells("Cantidad").Value, 0))

                If txtFechaDesde.Text.Replace(" ", "").Length = 10 And txtFechaHasta.Text.Replace(" ", "").Length = 10 Then
                    .Item("ImpreEmision") = String.Format("Laudos Entre {0} al {1}", txtFechaDesde.Text, txtFechaHasta.Text)
                Else
                    .Item("ImpreEmision") = String.Format("Laudos al {0}", Date.Now.ToString("dd/MM/yyyy"))
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

    Private Sub cmbOrdenI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrdenI.SelectedIndexChanged

    End Sub

    Private Sub cmbOrdenI_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrdenIII.DropDownClosed, cmbOrdenII.DropDownClosed, cmbOrdenI.DropDownClosed
        btnListar_Click(Nothing, Nothing)
    End Sub
End Class