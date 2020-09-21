Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports Util
Imports Util.Interfaces
Imports Util.Clases
Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class ListadoLaudosMPPorCodigo : Implements IAyudaMPs, IExportar

    Enum EstadosLaudos
        Aprobado = 1
        PorDesvio = 2
        Rechazado = 3
    End Enum

    Private Sub ListadoLaudosMPPorCodigo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        Dim WEstados As New Data.DataTable

        txtDescMP.BackColor = Globales.WBackColorTerciario

        With WEstados
            .Columns.Add("Estado", GetType(Integer))
            .Columns.Add("Descripcion")
            .Rows.Add(0, "TODOS")
            .Rows.Add(EstadosLaudos.Aprobado, "APROBADOS")
            .Rows.Add(EstadosLaudos.PorDesvio, "POR DESVIO")
            .Rows.Add(EstadosLaudos.Rechazado, "RECHAZADOS")
        End With

        With CType(clbEstados, System.Windows.Forms.ListBox)
            .DataSource = WEstados
            .DisplayMember = "Descripcion"
            .ValueMember = "Estado"
        End With

        Dim WPlantas As New Data.DataTable

        With WPlantas
            .Columns.Add("Planta", GetType(Integer))
            .Columns.Add("Descripcion")
            .Columns.Add("Base")
            .Rows.Add(0, "TODOS", "")
            .Rows.Add(1, "SURFACTAN I", "SurfactanSa")
            .Rows.Add(3, "SURFACTAN II", "Surfactan_II")
            .Rows.Add(5, "SURFACTAN III", "Surfactan_III")
            .Rows.Add(6, "SURFACTAN IV", "Surfactan_IV")
            .Rows.Add(7, "SURFACTAN V", "Surfactan_V")
            .Rows.Add(10, "SURFACTAN VI", "Surfactan_VI")
            .Rows.Add(11, "SURFACTAN VII", "Surfactan_VII")
        End With

        With CType(clbPlantas, System.Windows.Forms.ListBox)
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

        btnCalcularSaldos.Enabled = False

        If IsNothing(WCodigo) Then Exit Sub

        dgvLaudos.DataSource = Nothing

        Dim WDatos As New Data.DataTable

        With WDatos
            .Columns.Add("Fecha")
            .Columns.Add("FechaOrd", GetType(Integer))
            .Columns.Add("idEstado", GetType(Integer))
            .Columns.Add("Laudo", GetType(Integer))
            .Columns.Add("Estado")
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Columns.Add("Cantidad")
            .Columns.Add("Saldo", GetType(Double))
            .Columns.Add("idPlanta", GetType(Integer))
            .Columns.Add("Planta")
            .Columns.Add("PartiOri")
            .Columns.Add("Proveedor", GetType(Long))
            .Columns.Add("DescProveedor")
            .Columns.Add("OC")
            .Columns.Add("Informe")
            .Columns.Add("Version", GetType(Integer))
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

            Dim _Datos As Data.DataTable
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

                    _r.Item("Saldo") = 0

                    Dim WVersion = 0
                    Dim WProducto = _r.Item("Codigo")
                    Dim WFecha = _r.Item("Fecha")

                    Dim WBaseEspecif = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

                    Dim WEspecif As DataRow = GetSingle(String.Format("SELECT Version FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) <= '{1}' And right(FechaFinal, 4) + SUBSTRING(FechaFinal, 4, 2) + LEFT(FechaFinal, 2) >= '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)

                    If WEspecif Is Nothing Then
                        WEspecif = GetSingle(String.Format("SELECT Version FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) > '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
                    End If

                    If WEspecif Is Nothing Then
                        WEspecif = GetSingle(String.Format("SELECT Version FROM EspecificacionesUnifica WHERE Producto = '{0}'", WProducto), WBaseEspecif)
                    End If

                    If WEspecif IsNot Nothing Then
                        WVersion = OrDefault(WEspecif.Item("Version"), 0)
                    End If

                    _r.Item("Version") = WVersion

                    WDatos.Rows.Add(_r)
                End With
            Next

        Next

        Dim WOrden As String = _GenerarCadenaOrdenamiento()

        WDatos.DefaultView.Sort = WOrden

        dgvLaudos.DataSource = WDatos

        If dgvLaudos.Rows.Count > 0 Then btnCalcularSaldos.Enabled = True

        For Each col As String In {"FechaOrd", "idEstado", "Codigo", "Descripcion", "Saldo", "idPlanta"}
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

        ElseIf widEmpresa = 3 Then

            If WLote >= 200000 And WLote <= 289999 Then Return "APROBADO"
            If WLote >= 290000 And WLote <= 294999 Then Return "DESVÍO"
            If WLote >= 74000 And WLote <= 74999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 5 Then

            If WLote >= 300000 And WLote <= 389999 Then Return "APROBADO"
            If WLote >= 390000 And WLote <= 394999 Then Return "DESVÍO"
            If WLote >= 78000 And WLote <= 78999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 6 Then

            If WLote >= 400000 And WLote <= 489999 Then Return "APROBADO"
            If WLote >= 490000 And WLote <= 494999 Then Return "DESVÍO"
            If WLote >= 75000 And WLote <= 75999 Then Return "RECHAZADO"

        ElseIf widEmpresa = 7 Then

            If WLote >= 500000 And WLote <= 519999 Then Return "APROBADO"
            If WLote >= 590000 And WLote <= 594000 Then Return "DESVÍO"
            If WLote >= 72000 And WLote <= 72399 Then Return "RECHAZADO"

        ElseIf widEmpresa = 10 Then

            If WLote >= 520000 And WLote <= 539999 Then Return "APROBADO"
            If WLote >= 570000 And WLote <= 574999 Then Return "DESVÍO"
            If WLote >= 72400 And WLote <= 72699 Then Return "RECHAZADO"

        ElseIf widEmpresa = 11 Then

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

        If BackgroundWorker1.IsBusy Then Exit Sub

        With New DetalleMovimientosMP(dgvLaudos.CurrentRow.Cells("Laudo").Value, ckIncluirHistoricos.Checked)
            .Show(Me)
        End With
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

        If BackgroundWorker1.IsBusy Then Exit Sub

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
        Dim data As Data.DataTable = (New DSAuxi).Tables("DetalleListadoLaudosMPPorCodigo").Clone

        For Each row As DataGridViewRow In dgvLaudos.Rows
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

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ProgressBar1.Value = 0
        ProgressBar1.Maximum = dgvLaudos.Rows.Count
        dgvLaudos.Columns("Saldo").Visible = True

        btnCalcularSaldos.Text = "Calculando Saldos..."

        For Each row As DataGridViewRow In dgvLaudos.Rows
            With row
                .Cells("Saldo").Value = _CalcularSaldo(txtCodigo.Text, .Cells("Laudo").Value, Conexion.DeterminarSegunIDIDBasePara(.Cells("idPlanta").Value))
            End With

            ProgressBar1.Increment(1)

        Next

        btnCalcularSaldos.Text = "Calcular SALDOS"

        btnCalcularSaldos.Enabled = False
        ProgressBar1.Value = 0

    End Sub

    Private Function _ObtenerEmpresaOriginal(ByVal _Lote As Object) As Object

        For Each empresa As Object In Conexion.Empresas

            Dim emp As String = empresa

            Dim WLaudo As DataRow = GetSingle("SELECT Articulo, Fecha, PartiOri FROM Laudo WHERE Laudo = '" & _Lote & "' And Renglon IN ('1', '01')", emp)

            If WLaudo IsNot Nothing Then Return empresa

        Next

        Return Nothing
    End Function

    Private Function _CalcularSaldo(ByVal Producto As Object, ByVal Hoja As Object, ByVal emp As Object) As Double

        Dim WCodMP As String = ""
        Dim WReventa As Object = 0
        Dim WFechaCierre As String = ""
        Dim WFechaCierreOrd As String = ""
        Dim WDescMP As String = ""
        Dim WTipoMat As String = ""
        Dim WMarca As String = ""
        Dim WPartiOrig As String = ""
        Dim Auxi = ""

        Dim WLote = Hoja

        Dim WMovimientos As New Data.DataTable

        With WMovimientos.Columns
            .Add("Entrada")
            .Add("Salida")
            .Add("Marca")
        End With

        Dim WFiltroMarca As String = " And ISNULL(Marca, '') <> 'X' "

        Dim empresa As String = emp

        Dim WEmpresaOrig As String = _ObtenerEmpresaOriginal(Hoja)

        Dim WLaudo As DataRow = GetSingle("SELECT Articulo, Fecha, PartiOri FROM Laudo WHERE Laudo = '" & WLote & "' And Renglon IN ('1', '01')", WEmpresaOrig)

        WPartiOrig = OrDefault(WLaudo.Item("PartiOri"), "")

        WCodMP = OrDefault(WLaudo.Item("Articulo"), "")

        WTipoMat = WCodMP.ToString.Substring(0, 2)

        For Each _emp As String In Conexion.Empresas

            empresa = _emp

            Auxi = WLote

            Dim WArticulo As DataRow = GetSingle("SELECT Reventa, FechaCierre, Descripcion FROM Articulo WHERE Codigo = '" & WCodMP & "'", empresa)

            With WArticulo
                WReventa = OrDefault(.Item("Reventa"), 0)
                WDescMP = OrDefault(.Item("Descripcion"), "")
                WFechaCierre = OrDefault(.Item("FechaCierre"), "")
                WFechaCierreOrd = ordenaFecha(WFechaCierre)
            End With

            If Val(WReventa) = 1 Then WTipoMat = "DY"

            Auxi = WLote

            ' Busco el Número de Lote según la Partida Original.
            Select Case UCase(WTipoMat)
                Case "DY", "DS", "DQ"

                    Auxi = WPartiOrig

                    Dim WAuxi As DataRow = GetSingle("SELECT Laudo As Lote FROM Laudo WHERE Articulo = '" & WCodMP & "' And PartiOri = '" & WPartiOrig & "' And Renglon IN ('1', '01')", empresa)

                    If WAuxi Is Nothing Then
                        WAuxi = GetSingle("SELECT Lote FROM Guia WHERE Articulo = '" & WCodMP & "' And PartiOri = '" & WPartiOrig & "'", empresa)
                    End If

                    If WAuxi IsNot Nothing Then
                        Auxi = OrDefault(WAuxi.Item("Lote"), 0)
                    End If

                Case "DK", "NS", "NQ"

                    Dim WAuxi2 As String = WTipoMat & "00" & Microsoft.VisualBasic.Right(WCodMP, 7)
                    Auxi = WPartiOrig

                    Dim WAuxi As DataRow = GetSingle("SELECT Lote FROM EntDev WHERE Terminado = '" & WAuxi2 & "' And Codigo = '" & WPartiOrig & "'", empresa)

                    If WAuxi IsNot Nothing Then Auxi = OrDefault(WAuxi.Item("Lote"), 0)

            End Select

            '
            ' Busco el o los Laudos que se correspondan con el Lote o PartiOrig segun sea o no Reventa.
            '
            Dim WSql As String = ""
            If Val(WReventa) = 1 And Trim(WPartiOrig) <> "" Then
                WSql = "SELECT Laudo, Liberada, LiberadaAnt, Marca, Fecha, Orden FROM Laudo WHERE Articulo = '" & WCodMP & "' And PartiOri = '" & WPartiOrig & "'"
            Else
                WSql = "SELECT Laudo, Liberada, LiberadaAnt, Marca, Fecha, Orden FROM Laudo WHERE Articulo = '" & WCodMP & "' And Laudo = '" & Auxi & "'"
            End If

            Dim WLaudos As Data.DataTable = GetAll(WSql, empresa)

            Dim WDescr, WNumero, WFecha, WFechaOrd, WObservaciones, WLiberada As String
            WMarca = ""
            If WLaudos.Rows.Count > 0 Then

                For Each row As DataRow In WLaudos.Rows
                    With row
                        WLiberada = OrDefault(.Item("Liberada"), 0)
                        WMarca = OrDefault(.Item("Marca"), "")

                        If WMarca = "X" Then WLiberada = OrDefault(.Item("LiberadaAnt"), 0)

                        WLiberada = formatonumerico(WLiberada)
                    End With

                    If Val(WLiberada) <> 0 Then
                        Dim r = WMovimientos.NewRow
                        With r
                            .Item("Entrada") = formatonumerico(WLiberada)
                            .Item("Salida") = ""
                            .Item("Marca") = WMarca
                        End With
                        WMovimientos.Rows.Add(r)
                    End If

                Next

            End If

            '
            ' Busco uso en Hojas de Producción posteriores a la Fecha de Cierre
            '

            Dim WHojas As Data.DataTable = GetAll("SELECT Fecha, Hoja, Canti1, Canti2, Canti3, Lote1, Lote2, Lote3, Marca FROM Hoja WHERE Tipo = 'M' " & WFiltroMarca & " And (RIGHT(Fecha, 4) + SUBSTRING(Fecha, 4, 2) + LEFT(Fecha, 2)) >= '" & WFechaCierreOrd & "' And (Lote1 = '" & WLote & "' Or Lote2 = '" & WLote & "' Or Lote3 = '" & WLote & "')", empresa)
            WMarca = ""
            For Each row As DataRow In WHojas.Rows
                With row
                    For i = 1 To 3
                        Auxi = OrDefault(.Item("Lote" & i), 0)

                        If Val(Auxi) = Val(WLote) Then
                            WLiberada = OrDefault(.Item("Canti" & i), 0)
                            WLiberada = formatonumerico(WLiberada)
                            WMarca = OrDefault(.Item("Marca"), "")

                            Dim r = WMovimientos.NewRow
                            With r
                                .Item("Salida") = formatonumerico(WLiberada)
                                .Item("Entrada") = ""
                                .Item("Marca") = WMarca
                            End With
                            WMovimientos.Rows.Add(r)

                        End If

                    Next
                End With
            Next

            '
            ' Busco uso en Movimientos Varios.
            '

            Dim WMovVars As Data.DataTable = GetAll("SELECT Cantidad, Marca, Movi, Codigo, Fecha, Observaciones FROM MovVar WHERE Tipo = 'M' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)
            WMarca = ""
            For Each row As DataRow In WMovVars.Rows
                With row

                    WLiberada = OrDefault(.Item("Cantidad"), 0)

                    'If OrDefault(.Item("CantidadAnt"), 0) <> 0 Then WLiberada = OrDefault(.Item("CantidadAnt"), 0)

                    WLiberada = formatonumerico(WLiberada)
                    Auxi = OrDefault(.Item("Movi"), "")
                    WMarca = OrDefault(.Item("Marca"), "")

                    Dim r = WMovimientos.NewRow
                    With r
                        .Item("Salida") = IIf(Auxi = "E", "", formatonumerico(WLiberada))
                        .Item("Entrada") = IIf(Auxi = "S", "", formatonumerico(WLiberada))
                        .Item("Marca") = WMarca
                    End With
                    WMovimientos.Rows.Add(r)

                End With
            Next

            '
            ' Busco uso en Movimientos Varios.
            '

            Dim WGuiasInt As Data.DataTable = GetAll("SELECT Cantidad, CantidadAnt, Marca, Codigo, Fecha, Movi, TipoMov, Destino FROM Guia WHERE Tipo = 'M' " & WFiltroMarca & " And (Lote = '" & WLote & "' Or Partida = '" & WLote & "' Or (PartiOri = '" & WPartiOrig & "' And PartiOri <> ''))", empresa)
            WMarca = ""
            For Each row As DataRow In WGuiasInt.Rows
                With row

                    WLiberada = OrDefault(.Item("Cantidad"), 0)

                    If OrDefault(.Item("CantidadAnt"), 0) <> 0 And WMarca = "X" Then WLiberada = OrDefault(.Item("CantidadAnt"), 0)

                    WLiberada = formatonumerico(WLiberada)
                    WMarca = OrDefault(.Item("Marca"), "")
                    Dim WMovi = OrDefault(.Item("Movi"), "")

                    Dim r = WMovimientos.NewRow
                    With r
                        .Item("Salida") = IIf(WMovi = "E", "", formatonumerico(WLiberada))
                        .Item("Entrada") = IIf(WMovi = "S", "", formatonumerico(WLiberada))
                        .Item("Marca") = WMarca
                    End With
                    WMovimientos.Rows.Add(r)

                End With
            Next

            '
            ' Busco uso en Movimientos de Laboratorio.
            '

            Dim WMovLab As Data.DataTable = GetAll("SELECT Cantidad, Codigo, Movi, Fecha, Marca, Observaciones FROM MovLab WHERE Tipo = 'M' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)
            WMarca = ""
            For Each row As DataRow In WMovLab.Rows
                With row

                    WLiberada = OrDefault(.Item("Cantidad"), 0)

                    WLiberada = formatonumerico(WLiberada)
                    Auxi = OrDefault(.Item("Movi"), "")
                    WMarca = OrDefault(.Item("Marca"), "")

                    Dim r = WMovimientos.NewRow
                    With r
                        .Item("Salida") = IIf(Auxi = "E", "", formatonumerico(WLiberada))
                        .Item("Entrada") = IIf(Auxi = "S", "", formatonumerico(WLiberada))
                        .Item("Marca") = WMarca
                    End With
                    WMovimientos.Rows.Add(r)

                End With
            Next

            Auxi = WCodMP

            If WTipoMat = "DK" Then Auxi = "DY-" & Microsoft.VisualBasic.Right(WCodMP, 7)
            If WTipoMat = "NS" Then Auxi = "DS-" & Microsoft.VisualBasic.Right(WCodMP, 7)
            If WTipoMat = "NQ" Then Auxi = "DQ-" & Microsoft.VisualBasic.Right(WCodMP, 7)

            'If WFiltroMarca <> "" Then WFiltroMarca = " And e.Marca <> 'X' "

            Dim WEstadisticas As Data.DataTable = GetAll("SELECT Cliente = c.Razon, e.Marca, e.Tipo, e.TipoPro, e.Fecha, e.Numero, e.Cliente, e.LoteAdicional, e.Lote1, e.Lote2, e.Lote3, e.Lote4, e.Lote5, e.Canti1, e.Canti2, e.Canti3, e.Canti4, e.Canti5 FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE e.TipoProDy = 'M' " & WFiltroMarca & " And e.ArticuloDy = '" & Auxi & "'", empresa)
            WMarca = ""
            For Each row As DataRow In WEstadisticas.Rows

                Dim XLotes(12, 2) As String
                Dim WTipo

                With row
                    WTipo = OrDefault(.Item("Tipo"), 0)
                    Auxi = OrDefault(.Item("TipoPro"), 0)

                    Select Case UCase(WTipoMat)
                        Case "DK", "NS", "NK"
                            If WTipo = 2 Then
                                WMarca = OrDefault(.Item("Marca"), "")
                                WLiberada = Math.Abs(Val(formatonumerico(OrDefault(.Item("Canti1"), "0"))))

                                Dim r = WMovimientos.NewRow
                                With r
                                    .Item("Salida") = formatonumerico(WLiberada)
                                    .Item("Entrada") = ""
                                    .Item("Marca") = WMarca
                                End With
                                WMovimientos.Rows.Add(r)

                            End If
                        Case Else
                            If (WTipo = 2 And Auxi = WTipoMat) Or WTipo = 1 Then
                                WMarca = OrDefault(.Item("Marca"), "")

                                For i = 1 To 5
                                    XLotes(i, 1) = OrDefault(.Item("Lote" & i), "")
                                    XLotes(i, 2) = OrDefault(.Item("Canti" & i), "")
                                Next

                                Dim WLoteAdicional As String = OrDefault(.Item("LoteAdicional"), "")
                                WLoteAdicional = WLoteAdicional.PadRight(98, "0")

                                XLotes(6, 1) = Mid$(WLoteAdicional, 1, 8)
                                XLotes(6, 2) = Mid$(WLoteAdicional, 9, 6)
                                XLotes(7, 1) = Mid$(WLoteAdicional, 15, 8)
                                XLotes(7, 2) = Mid$(WLoteAdicional, 23, 6)
                                XLotes(8, 1) = Mid$(WLoteAdicional, 29, 8)
                                XLotes(8, 2) = Mid$(WLoteAdicional, 37, 6)
                                XLotes(9, 1) = Mid$(WLoteAdicional, 43, 8)
                                XLotes(9, 2) = Mid$(WLoteAdicional, 51, 6)
                                XLotes(10, 1) = Mid$(WLoteAdicional, 57, 8)
                                XLotes(10, 2) = Mid$(WLoteAdicional, 65, 6)
                                XLotes(11, 1) = Mid$(WLoteAdicional, 71, 8)
                                XLotes(11, 2) = Mid$(WLoteAdicional, 79, 6)
                                XLotes(12, 1) = Mid$(WLoteAdicional, 85, 8)
                                XLotes(12, 2) = Mid$(WLoteAdicional, 93, 6)

                            End If
                    End Select

                End With

                For i = 1 To 12

                    Auxi = XLotes(i, 1)

                    If Val(Auxi) = WLote Then

                        WLiberada = Math.Abs(Val(formatonumerico(XLotes(i, 2))))

                        Dim r = WMovimientos.NewRow
                        With r

                            If Val(WTipo) = 2 Then
                                .Item("Entrada") = formatonumerico(WLiberada)
                                .Item("Salida") = ""
                            Else
                                .Item("Salida") = formatonumerico(WLiberada)
                                .Item("Entrada") = ""
                            End If

                            .Item("Marca") = WMarca

                        End With
                        WMovimientos.Rows.Add(r)

                    End If

                Next

            Next


        Next

        Dim WSaldo As Double = 0

        For Each m As DataRow In WMovimientos.Rows
            If OrDefault(m.Item("Marca"), "") <> "X" Then
                WSaldo += Val(m.Item("Entrada"))
                WSaldo -= Val(m.Item("Salida"))
            End If
        Next

        Return Val(formatonumerico(WSaldo))

    End Function

    Private Sub btnCalcularSaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularSaldos.Click
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnExportarListadoEnsayosPorPartida_Click(sender As Object, e As EventArgs) Handles btnExportarListadoEnsayosPorPartida.Click

        '
        ' Creamos el Objeto Excel para comenzar a Trabajar.
        '
        'Dim oApp As New Excel.Application()
        Dim OApp As New Excel.Application()
        Dim oBook As Excel.Workbook = OApp.Workbooks.Add
        Dim oSheet As Excel.Worksheet = OApp.ActiveSheet

        OApp.Visible = False

        Dim celda As Excel.Range = oSheet.Cells(2, 1)

        Dim WColumna As Integer = 2
        Dim WFila As Integer = 3

        ProgressBar1.Value = 0
        ProgressBar1.Maximum = dgvLaudos.Rows.Count

        'If tablaDatos Is Nothing Then Exit Sub

        Dim tablaDatos As Data.DataTable = TryCast(dgvLaudos.DataSource, Data.DataTable)

        Dim WDatoAProcesar As Data.DataTable = tablaDatos.Clone

        Dim WDatoAImportar As DataGridViewRow() = dgvLaudos.SelectedRows.Cast(Of DataGridViewRow).ToArray

        If WDatoAImportar.Length = 0 Then

            WDatoAImportar = dgvLaudos.Rows.Cast(Of DataGridViewRow).ToArray

        End If

        For Each row As DataGridViewRow In WDatoAImportar
            WDatoAProcesar.ImportRow(tablaDatos.Select("Laudo = " & row.Cells("Laudo").Value)(0))
        Next

        If WDatoAProcesar.Rows.Count = 0 Then Exit Sub

        Dim WUltimaVersion As Integer = 0

        'For i = 0 To WUltimaColumna - 1
        For Each row As DataRow In WDatoAProcesar.Select("", "Version, Laudo DESC")
            'Dim row As DataRow = tablaDatos.Rows(i)

            With row

                If OrDefault(.Item("idEstado"), 4) <> ListadoHojasPTPorCodigo.EstadosLaudos.SinActualizar Then

                    If WUltimaVersion < .Item("Version") Then

                        If WUltimaVersion = 0 Then
                            oSheet = OApp.ActiveSheet
                        Else
                            oSheet = OApp.Sheets.Add
                            oSheet.Activate()
                            WColumna = 2
                        End If

                        WUltimaVersion = .Item("Version")

                        oSheet.Name = "Versión " & WUltimaVersion

                    End If

                    celda = oSheet.Cells(2, 1)

                    WColumna += 1
                    celda = oSheet.Cells(3, WColumna)
                    celda.Value = OrDefault(.Item("Laudo"), "")
                    celda.EntireColumn.AutoFit()
                    celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlMedium)
                    celda.Font.Bold = True

                    WFila = 3

                    Dim WEnsayos As Data.DataTable = _TraerDatosEnsayosHoja(.Item("Laudo"))

                    For Each ens As DataRow In WEnsayos.Rows
                        With ens

                            WFila += 1

                            'oSheet.Cells(WFila, 1) = _TraerDescripcionEnsayo(Trim(ens.Item("Ensayo")))
                            oSheet.Cells(WFila, 1) = Trim(ens.Item("Ensayo"))
                            oSheet.Cells(WFila, 2) = Trim(ens.Item("ValorStd"))
                            oSheet.Cells(2, WColumna) = ens.Item("Fecha")

                            If Trim(ens.Item("Valor")) = "" Then
                                oSheet.Cells(WFila, WColumna) = Trim(ens.Item("ValorReg"))
                            Else
                                oSheet.Cells(WFila, WColumna) = Trim(ens.Item("Valor"))
                                oSheet.Cells(WFila, 2) = Trim(ens.Item("ValorReg"))
                            End If

                            If OrDefault(oSheet.Cells(WFila, WColumna).Value, "").ToString = "" AndAlso Trim(ens.Item("Ensayo")) <> "" Then oSheet.Cells(WFila, WColumna) = "'---"

                        End With

                        celda = oSheet.Cells(WFila, WColumna)
                        celda.EntireColumn.AutoFit()
                        celda.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        celda.ColumnWidth = celda.ColumnWidth + 2
                        celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlThin)

                        celda = oSheet.Cells(2, WColumna)
                        celda.EntireColumn.AutoFit()
                        celda.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        celda.ColumnWidth = celda.ColumnWidth + 2
                        celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlThin)

                    Next

                End If

            End With

            ProgressBar1.Increment(1)

        Next

        For Each sheet As Worksheet In OApp.Sheets

            oSheet = sheet
            oSheet.Activate()

            celda = oSheet.Cells(2, 2)
            celda.Value = "Fecha Ingreso"
            celda.EntireColumn.AutoFit()
            celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlMedium)

            celda = oSheet.Cells(3, 1)
            celda.Value = "Determinación Analítica"
            celda.EntireColumn.AutoFit()
            celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlMedium)

            celda = oSheet.Cells(3, 2)
            celda.Value = "Especificación"
            celda.EntireColumn.AutoFit()
            celda.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlMedium)

        Next

        'OApp.Visible = True
        'OApp.UserControl = True

        ProgressBar1.Value = 0

        '
        'Cerramos la interfaz.
        '
        Dim WArchivo As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "/" & "prueba" & ".xlsx"

        IO.File.Delete(WArchivo)

        oBook.SaveAs(WArchivo)
        oBook.Close()

        OApp.Quit()

        If IO.File.Exists(WArchivo) Then Process.Start(WArchivo)

        MsgBox("Los datos se han exportado correctamente y se han guardado en " & WArchivo, MsgBoxStyle.Information, "Exportación de datos de Laudos de MP.")

        GC.Collect()
        GC.WaitForPendingFinalizers()

    End Sub

    Private Function _TraerDatosEnsayosHoja(ByVal Hoja As String) As Data.DataTable

        Dim WEnsayos As New Data.DataTable
        Dim WFecha, WProducto As String

        With WEnsayos.Columns
            .Add("Ensayo")
            .Add("Version", GetType(Integer))
            .Add("ValorStd")
            .Add("ValorReg")
            .Add("Valor")
            .Add("Fecha")
        End With

        Dim WDatosEnsayos As DataRow = Nothing

        For Each emp As String In Globales.Empresas

            WDatosEnsayos = GetSingle(String.Format("SELECT TOP 1 Fecha, Producto, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10, Valor11, Valor12, Valor13, Valor14, Valor15, Valor16, Valor17, Valor18, Valor19, Valor20, Valor21, Valor22, Valor23, Valor24, Valor25, Valor26, Valor27, Valor28, Valor29, Valor30 FROM Prueart WHERE Prueba IN ('1{0}', '2{0}')", Hoja.PadLeft(6, "0")), emp)

            If WDatosEnsayos Is Nothing Then Continue For

            With WDatosEnsayos
                WFecha = OrDefault(.Item("Fecha"), "")
                WProducto = OrDefault(.Item("Producto"), "")

                For i = 1 To 30

                    Dim r As DataRow = WEnsayos.NewRow

                    r.Item("Ensayo") = ""
                    r.Item("Version") = 0
                    r.Item("ValorStd") = ""
                    r.Item("ValorReg") = OrDefault(.Item("Valor" & i), "")
                    r.Item("Fecha") = OrDefault(.Item("Fecha"), "  /  /    ")
                    r.Item("Valor") = "" 'OrDefault(.Item("ValorNumero" & i), "")

                    'If Trim(r.Item("ValorReg")) <> "" Then WEnsayos.Rows.Add(r)
                    WEnsayos.Rows.Add(r)

                Next

            End With

            Dim WBaseEspecif = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")
            Dim WLimite As Short = 10

            Dim WEspecif As DataRow = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) <= '{1}' And right(FechaFinal, 4) + SUBSTRING(FechaFinal, 4, 2) + LEFT(FechaFinal, 2) >= '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
            Dim WEspecifII As DataRow

            If WEspecif IsNot Nothing Then WEspecifII = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersionII WHERE Producto = '{0}' And Version = '{1}' Order by Producto, Version", WProducto, WEspecif("Version")), WBaseEspecif)

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) > '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
                If WEspecif IsNot Nothing Then WEspecifII = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaVersionII WHERE Producto = '{0}' And Version = '{1}' Order by Producto, Version", WProducto, WEspecif("Version")), WBaseEspecif)
            End If

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecificacionesUnifica WHERE Producto = '{0}'", WProducto), WBaseEspecif)
                WEspecifII = GetSingle(String.Format("SELECT * FROM EspecificacionesUnificaIII WHERE Producto = '{0}'", WProducto), WBaseEspecif)
                WLimite = 20
            End If

            If WEspecif IsNot Nothing Then

                Dim WRenglonEns = 0

                For i = 1 To WLimite
                    'If WRenglonEns < WEnsayos.Rows.Count Then
                    If Val(OrDefault(WEspecif.Item("Ensayo" & i), "")) <> 0 Then
                        WEnsayos.Rows(WRenglonEns).Item("Version") = OrDefault(WEspecif.Item("Version"), 0)
                        WEnsayos.Rows(WRenglonEns).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & i), "")
                        WEnsayos.Rows(WRenglonEns).Item("ValorStd") = Trim(OrDefault(WEspecif.Item("Valor" & i), "")) ' & " " & Trim(OrDefault(WEspecif.Item("Valor" & i & "" & i), ""))
                        WRenglonEns += 1
                        'End If
                    End If
                Next
                
                If WLimite = 10 Then
                    For i = 1 To 10
                        'If WRenglonEns < WEnsayos.Rows.Count Then
                        If Val(OrDefault(WEspecif.Item("Ensayo" & (i + 10)), "")) <> 0 Then
                            WEnsayos.Rows(WRenglonEns).Item("Version") = OrDefault(WEspecif.Item("Version"), 0)
                            WEnsayos.Rows(WRenglonEns).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & (i + 10)), "")
                            WEnsayos.Rows(WRenglonEns).Item("ValorStd") = Trim(OrDefault(WEspecif.Item("ZValor" & i), "")) ' & " " & Trim(OrDefault(WEspecif.Item("Valor" & i & "" & i), ""))
                            WRenglonEns += 1
                        End If
                        'End If
                    Next
                End If

                If WEspecifII IsNot Nothing Then

                    For i = 21 To 30
                        ' If WRenglonEns < WEnsayos.Rows.Count Then
                        If Val(OrDefault(WEspecifII.Item("Ensayo" & i), "")) <> 0 Then
                            WEnsayos.Rows(WRenglonEns).Item("Version") = OrDefault(WEspecifII.Item("Version"), 0)
                            WEnsayos.Rows(WRenglonEns).Item("Ensayo") = OrDefault(WEspecifII.Item("Ensayo" & i), "")
                            WEnsayos.Rows(WRenglonEns).Item("ValorStd") = Trim(OrDefault(WEspecifII.Item("Valor" & i), "")) '& " " & Trim(OrDefault(WEspecif.Item("Valor" & i & "" & i), ""))
                            WRenglonEns += 1
                        End If
                        'End If
                    Next

                End If

            End If

            Dim ZEns As Data.DataTable = (New DataView(WEnsayos)).ToTable(True, "Ensayo")

            For Each _e As DataRow In ZEns.Rows

                With _e

                    Dim WEns As DataRow = GetSingle("SELECT ISNULL(Descripcion, '') Descripcion FROM Ensayos WHERE Codigo = '" & _e.Item("Ensayo") & "'", WBaseEspecif)

                    If WEns Is Nothing Then Continue For

                    Dim XEns As DataRow() = WEnsayos.Select("Ensayo = '" & _e("Ensayo") & "'")

                    For Each xe As DataRow In XEns

                        xe("Ensayo") = _e("Ensayo").ToString.PadLeft(4, "0") & "  " & Trim(WEns("Descripcion"))

                    Next

                End With

            Next

            Exit For

        Next

        If WEnsayos Is Nothing Then WEnsayos = New Data.DataTable

        Return WEnsayos

    End Function
End Class