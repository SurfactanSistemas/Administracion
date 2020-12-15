
Imports System.IO
Imports System.Runtime.InteropServices
Imports Util
Imports Util.Interfaces
Imports Util.Clases
Imports Util.Clases.Helper
Imports Util.Clases.Query
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class ListadoHojasPTPorCodigo : Implements IAyudaMPs, IExportar

    Enum EstadosLaudos
        Aprobado = 1
        PorDesvio = 2
        Rechazado = 3
        SinActualizar = 4
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
            .Rows.Add(EstadosLaudos.SinActualizar, "SIN ANALIZAR")
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
            .Rows.Add(2, "SURFACTAN II", "Surfactan_II")
            .Rows.Add(3, "SURFACTAN III", "Surfactan_III")
            .Rows.Add(4, "SURFACTAN IV", "Surfactan_IV")
            .Rows.Add(5, "SURFACTAN V", "Surfactan_V")
            .Rows.Add(6, "SURFACTAN VI", "Surfactan_VI")
            .Rows.Add(7, "SURFACTAN VII", "Surfactan_VII")
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

        btnCalcularSaldos.Enabled = False

        dgvLaudos.DataSource = Nothing

        Dim WDatos As New Data.DataTable

        With WDatos
            .Columns.Add("Fecha")
            .Columns.Add("FechaOrd", GetType(Integer))
            .Columns.Add("idEstado", GetType(Integer))
            .Columns.Add("Hoja", GetType(Integer))
            .Columns.Add("Estado")
            .Columns.Add("Codigo")
            .Columns.Add("Descripcion")
            .Columns.Add("Cantidad")
            .Columns.Add("Saldo", GetType(Double))
            .Columns.Add("idPlanta", GetType(Integer))
            .Columns.Add("Version", GetType(Integer))
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

        Dim WTipoProdConsulta As String = ""

        For Each p As Object In clbPlantas.CheckedItems

            Dim _Datos As Data.DataTable
            Dim WDescEmpresa As String = ""
            Dim WidEmpresa As Integer = 0

            With CType(p, DataRowView)
                Dim emp As String = .Item("Base")

                If emp = "" Then Continue For

                WDescEmpresa = .Item("Descripcion")
                WidEmpresa = .Item("Planta")

                Dim WProd As String = txtCodigo.Text.PadRight(12, " ").Substring(2, 10)
                WTipoProdConsulta = Helper.Left(txtCodigo.Text, 2)

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

                    If Not WEstados.ToList.Contains(_r.Item("idEstado")) Then Continue For

                    If Helper.Left(_r.Item("Codigo"), 2) = WTipoProdConsulta Or (Helper.Left(_r.Item("Codigo"), 2) = "SE" And ckIncluirSEs.Checked) Then

                        _r.Item("Descripcion") = Trim(OrDefault(.Item("DescTerminado"), ""))

                        _r.Item("Fecha") = OrDefault(.Item("Fecha"), "  /  /    ")
                        _r.Item("FechaOrd") = ordenaFecha(_r.Item("Fecha"))
                        _r.Item("Hoja") = OrDefault(.Item("Hoja"), 0)
                        _r.Item("Cantidad") = formatonumerico(OrDefault(.Item("Cantidad"), "0"))

                        If Val(_r.Item("Cantidad")) = 0 Then _r.Item("Cantidad") = formatonumerico(OrDefault(.Item("Teorico"), "0"))

                        _r.Item("idPlanta") = WidEmpresa
                        _r.Item("Planta") = WDescEmpresa

                        Dim WVersion = 0
                        Dim WProducto = _r.Item("Codigo")
                        Dim WFecha = _r.Item("Fecha")

                        Dim WBaseEspecif = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

                        Dim WEspecif As DataRow = GetSingle(String.Format("SELECT Version FROM EspecifUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) <= '{1}' And right(FechaFinal, 4) + SUBSTRING(FechaFinal, 4, 2) + LEFT(FechaFinal, 2) >= '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)

                        If WEspecif Is Nothing Then
                            WEspecif = GetSingle(String.Format("SELECT Version FROM EspecifUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) > '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
                        End If

                        If WEspecif Is Nothing Then
                            WEspecif = GetSingle(String.Format("SELECT Version FROM EspecifUnifica WHERE Producto = '{0}'", WProducto), WBaseEspecif)
                        End If

                        If WEspecif IsNot Nothing Then
                            WVersion = OrDefault(WEspecif.Item("Version"), 0)
                        End If

                        _r.Item("Version") = WVersion

                        '
                        ' Calculamos el saldo de la hoja.
                        '

                        _r.Item("Saldo") = 0 '_CalcularSaldoDeHoja(WProducto, _r.Item("Hoja"), Conexion.DeterminarSegunIDIDBasePara(WidEmpresa))

                        WDatos.Rows.Add(_r)

                    End If

                End With
            Next

        Next

        Dim WOrden As String = _GenerarCadenaOrdenamiento()

        WDatos.DefaultView.Sort = WOrden

        dgvLaudos.DataSource = WDatos

        If dgvLaudos.Rows.Count > 0 Then btnCalcularSaldos.Enabled = True

        For Each col As String In {"FechaOrd", "idEstado", "idPlanta", "Saldo", "Version"}
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

    Private Function _ObtenerEmpresaOriginal(ByVal _Lote As Object) As Object

        For Each empresa As Object In Globales.Empresas

            Dim emp As String = empresa

            Dim WHoja1 As DataRow = GetSingle("SELECT Producto, Fecha FROM Hoja WHERE Hoja = '" & _Lote & "' And Renglon IN ('1', '01') ", emp)

            If WHoja1 IsNot Nothing Then Return empresa

        Next

        Return Nothing
    End Function

    Private Function _CalcularSaldoDeHoja(ByVal Producto As Object, ByVal Hoja As Object, ByVal emp As String) As Double
        Dim WCodPT As String = ""
        Dim WReventa As Object = 0
        Dim WFechaCierre As String = ""
        Dim WFechaCierreOrd As String = ""
        Dim WDescPT As String = ""
        Dim WTipoPT As String = ""
        Dim WPartiOrig As String = ""
        Dim Auxi = ""
        Dim WMarca = ""
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

        If Trim(WEmpresaOrig) = "" Then Return -1

        WMarca = ""

        Dim WHoja1 As DataRow = GetSingle("SELECT Producto, Fecha FROM Hoja WHERE Hoja = '" & WLote & "' And Renglon IN ('1', '01') ", WEmpresaOrig)

        WCodPT = OrDefault(WHoja1.Item("Producto"), "")

        WTipoPT = WCodPT.ToString.Substring(0, 2)

        Dim WTerminado As DataRow = GetSingle("SELECT FechaCierre, Descripcion FROM Terminado WHERE Codigo = '" & WCodPT & "'", empresa)

        With WTerminado
            WDescPT = OrDefault(.Item("Descripcion"), "")
            WFechaCierre = OrDefault(.Item("FechaCierre"), "")
            WFechaCierreOrd = ordenaFecha(WFechaCierre)
        End With

        Auxi = WLote

        '
        ' Busco la o las Hojas que correspondan con el Lote o PartiOrig segun sea o no Reventa.
        '

        Dim WHojas2 As DataRow = GetSingle("SELECT Real, Marca, RealAnt, Teorico FROM Hoja WHERE Producto = '" & WCodPT & "' And Hoja = '" & Auxi & "' And Renglon IN ('1', '01')" & WFiltroMarca, empresa)

        Dim WLiberada As String

        WMarca = ""

        If WHojas2 IsNot Nothing Then

            With WHojas2

                WLiberada = OrDefault(.Item("Real"), 0)
                WMarca = OrDefault(.Item("Marca"), "")

                If OrDefault(.Item("RealAnt"), 0) <> 0 And UCase(Trim(WMarca)) = "X" Then
                    WLiberada = OrDefault(.Item("RealAnt"), 0)
                End If

                If WLiberada = 0 Then
                    WLiberada = OrDefault(.Item("Teorico"), 0)
                End If

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

        End If

        '
        ' Busco uso en Hojas de Producción posteriores a la Fecha de Cierre
        '

        Dim WHojas As Data.DataTable = GetAll("SELECT Lote1, Lote2, Lote3, Canti1, Canti2, Canti3, Marca FROM Hoja WHERE Tipo = 'T' " & WFiltroMarca & " And (Lote1 = '" & WLote & "' Or Lote2 = '" & WLote & "' Or Lote3 = '" & WLote & "')", empresa)

        For Each row As DataRow In WHojas.Rows
            WMarca = ""
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

        Dim WMovVars As Data.DataTable = GetAll("SELECT Cantidad, Movi, Marca FROM MovVar WHERE Tipo = 'T' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)

        WMarca = ""
        For Each row As DataRow In WMovVars.Rows
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

        '
        ' Busco uso en Movimientos Varios.
        '

        Dim WGuiasInt As Data.DataTable = GetAll("SELECT Cantidad, Marca, CantidadAnt, Movi FROM Guia WHERE Tipo = 'T' " & WFiltroMarca & " And (Lote = '" & WLote & "' Or Partida = '" & WLote & "')", empresa)
        WMarca = ""
        For Each row As DataRow In WGuiasInt.Rows
            With row

                WLiberada = OrDefault(.Item("Cantidad"), 0)
                WMarca = OrDefault(.Item("Marca"), "")

                'If OrDefault(.Item("CantidadAnt"), 0) <> 0 And UCase(Trim(WMarca)) = "X" Then
                If OrDefault(.Item("CantidadAnt"), 0) <> 0 And UCase(Trim(WMarca)) = "X" Then
                    WLiberada = OrDefault(.Item("CantidadAnt"), 0)
                End If

                WLiberada = formatonumerico(WLiberada)

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

        Dim WMovLab As Data.DataTable = GetAll("SELECT Cantidad, Marca, Movi FROM MovLab WHERE Tipo = 'T' " & WFiltroMarca & " And Lote = '" & WLote & "'", empresa)
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
                End With
                WMovimientos.Rows.Add(r)

            End With
        Next

        Auxi = WCodPT

        If WFiltroMarca <> "" Then WFiltroMarca = " And ISNULL(e.Marca, '') <> 'X'"

        Dim WEstadisticas As Data.DataTable = GetAll("SELECT Cliente = c.Cliente + '  ' + RTRIM(c.Razon), e.Marca, e.Tipo, e.TipoPro, e.Fecha, e.Numero, e.Cliente, e.LoteAdicional, e.Lote1, e.Lote2, e.Lote3, e.Lote4, e.Lote5, e.Canti1, e.Canti2, e.Canti3, e.Canti4, e.Canti5 FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE e.Articulo = '" & Auxi & "' " & WFiltroMarca & "", empresa)
        WMarca = ""
        For Each row As DataRow In WEstadisticas.Rows

            Dim XLotes(12, 2) As String
            Dim WTipo

            With row
                Auxi = OrDefault(.Item("TipoPro"), 0)
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

            End With

            For i = 1 To 12

                Auxi = XLotes(i, 1)

                If Val(Auxi) = WLote Then

                    WLiberada = Math.Abs(Val(formatonumerico(XLotes(i, 2))))

                    Dim r = WMovimientos.NewRow
                    With r

                        If Val(WTipo) = 1 Then
                            .Item("Salida") = formatonumerico(WLiberada)
                            .Item("Entrada") = ""
                        Else
                            .Item("Entrada") = formatonumerico(WLiberada)
                            .Item("Salida") = ""
                        End If

                        .Item("Marca") = WMarca

                    End With
                    WMovimientos.Rows.Add(r)

                End If

            Next
        Next


        If WFiltroMarca <> "" Then WFiltroMarca = " And ISNULL(Marca, '') <> 'X' "

        Dim WConsignaciones As Data.DataTable = GetAll("SELECT Cantidad, Marca, Facturado FROM Consig WHERE Terminado = '" & WCodPT & "' and ISNULL(Cantidad, 0) <> 0 And Lote = '" & WLote & "'" & WFiltroMarca, empresa)
        WMarca = ""
        For Each row As DataRow In WConsignaciones.Rows
            With row
                WLiberada = OrDefault(.Item("Cantidad"), 0) - OrDefault(.Item("Facturado"), 0)
                WLiberada = formatonumerico(WLiberada)
                WMarca = OrDefault(.Item("Marca"), "")

                Dim r = WMovimientos.NewRow
                With r
                    .Item("Salida") = formatonumerico(WLiberada)
                    .Item("Entrada") = ""
                    .Item("Marca") = WMarca
                End With
                WMovimientos.Rows.Add(r)
            End With
        Next


        Dim WSaldo As Double = 0

        For Each m As DataRow In WMovimientos.Rows
            If m.Item("Marca") <> "X" Then
                WSaldo += Val(m.Item("Entrada"))
                WSaldo -= Val(m.Item("Salida"))
            End If
        Next

        Return WSaldo

    End Function

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
        With New AyudaPTs
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
        Dim data As Data.DataTable = (New DSAuxi).Tables("DetalleListadoLaudosMPPorCodigo").Clone

        For Each row As DataGridViewRow In dgvLaudos.Rows
            Dim _r As DataRow = data.NewRow
            With _r
                .Item("Codigo") = txtCodigo.Text
                .Item("DescMP") = txtDescMP.Text
                .Item("Laudo") = OrDefault(row.Cells("Hoja").Value, 0)
                .Item("Fecha") = OrDefault(row.Cells("Fecha").Value, "")
                .Item("FechaOrd") = OrDefault(row.Cells("FechaOrd").Value, 0)
                .Item("Planta") = OrDefault(row.Cells("Planta").Value, "")
                .Item("Auxi1") = OrDefault(row.Cells("Codigo").Value, "")
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

    Private Sub btnExportarListadoEnsayosPorPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarListadoEnsayosPorPartida.Click

        Try
            '
            ' Creamos el Objeto Excel para comenzar a Trabajar.
            '
            'Dim oApp As New Excel.Application()
            Dim OApp As New Excel.Application()
            Dim oBook As Excel.Workbook = OApp.Workbooks.Add
            Dim oSheet As Excel.Worksheet = OApp.ActiveSheet

            OApp.Visible = False
            OApp.Interactive = False

            Dim celda As Excel.Range = oSheet.Cells(2, 1)

            Dim WColumna As Integer = 2
            Dim WFila As Integer = 3

            ProgressBar1.Value = 0
            ProgressBar1.Maximum = dgvLaudos.Rows.Count

            Dim tablaDatos As Data.DataTable = TryCast(dgvLaudos.DataSource, Data.DataTable)

            If tablaDatos Is Nothing Then Exit Sub

            Dim WUltimaVersion As Integer = 0

            'For i = 0 To WUltimaColumna - 1
            For Each row As DataRow In tablaDatos.Select("", "Version, Hoja Desc")
                'Dim row As DataRow = tablaDatos.Rows(i)

                With row

                    If OrDefault(.Item("idEstado"), 4) <> EstadosLaudos.SinActualizar Then

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
                        celda.Value = OrDefault(.Item("Hoja"), "")
                        celda.EntireColumn.AutoFit()
                        celda.BorderAround(LineStyle:=XlLineStyle.xlContinuous, Weight:=XlBorderWeight.xlMedium)
                        celda.Font.Bold = True

                        WFila = 3

                        Dim WEnsayos As Data.DataTable = _TraerDatosEnsayosHoja(.Item("Hoja"))

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

            OApp.Visible = True
            OApp.UserControl = True
            OApp.Interactive = True

            ProgressBar1.Value = 0

            '
            'Cerramos la interfaz.
            '
            oSheet = Nothing
            'oBook.Close(False)
            'oBook.SaveAs()
            'oBook = Nothing

            oBook.Close()
            OApp.Quit()

            OApp = Nothing
        Catch ex As COMException
            Using sw As New StreamWriter(Environment.SpecialFolder.Desktop & "sql.txt")
                sw.WriteLine(ex.Message & vbCrLf & ex.TargetSite.ToString & vbCrLf & ex.StackTrace)
            End Using
        End Try

    End Sub

    Private Function _TraerDescripcionEnsayo(ByVal Ensayo As String) As String
        Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo & "'", "Surfactan_II")

        If Not IsNothing(WEnsayo) Then
            Return Ensayo.PadLeft(4, "0") & "  " & Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))
        End If

        Return ""

    End Function

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

            If emp.ToUpper = "SURFACTAN_III" Then
                ' Verificamos si se trata o no de un producto de Farma (Planta III).
                WDatosEnsayos = GetSingle(String.Format("SELECT TOP 1 Clave FROM PrueterFarma WHERE Partida = {0} And Renglon = 1 ", Hoja), emp)
                If WDatosEnsayos IsNot Nothing Then
                    Return _MostrarEnsayosFarma(Hoja)
                End If

            Else
                WDatosEnsayos = GetSingle(String.Format("SELECT TOP 1 Fecha, Producto, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10 FROM Prueter WHERE Prueba IN ('1{0}', '2{0}')", Hoja.PadLeft(6, "0")), emp)
            End If

            If WDatosEnsayos Is Nothing Then Continue For

            With WDatosEnsayos
                WFecha = OrDefault(.Item("Fecha"), "")
                WProducto = OrDefault(.Item("Producto"), "")

                For i = 1 To 10

                    Dim r As DataRow = WEnsayos.NewRow

                    r.Item("Ensayo") = ""
                    r.Item("Version") = 0
                    r.Item("ValorStd") = ""
                    r.Item("ValorReg") = OrDefault(.Item("Valor" & i), "")
                    r.Item("Fecha") = OrDefault(.Item("Fecha"), "  /  /    ")
                    r.Item("Valor") = "" 'OrDefault(.Item("ValorNumero" & i), "")

                    If Trim(r.Item("ValorReg")) <> "" Then WEnsayos.Rows.Add(r)
                    'WEnsayos.Rows.Add(r)

                Next

            End With

            Dim WBaseEspecif = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

            Dim WEspecif As DataRow = GetSingle(String.Format("SELECT * FROM EspecifUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) <= '{1}' And right(FechaFinal, 4) + SUBSTRING(FechaFinal, 4, 2) + LEFT(FechaFinal, 2) >= '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecifUnificaVersion WHERE Producto = '{0}' And right(FechaInicio, 4) + SUBSTRING(FechaInicio, 4, 2) + LEFT(FechaInicio, 2) > '{1}' Order by Producto, Version", WProducto, ordenaFecha(WFecha)), WBaseEspecif)
            End If

            If WEspecif Is Nothing Then
                WEspecif = GetSingle(String.Format("SELECT * FROM EspecifUnifica WHERE Producto = '{0}'", WProducto), WBaseEspecif)
            End If

            If WEspecif IsNot Nothing Then

                Dim WRenglonEns = 0

                For i = 1 To 10
                    If WRenglonEns < WEnsayos.Rows.Count Then
                        If Val(OrDefault(WEspecif.Item("Ensayo" & i), "")) <> 0 Then
                            WEnsayos.Rows(WRenglonEns).Item("Version") = OrDefault(WEspecif.Item("Version"), 0)
                            WEnsayos.Rows(WRenglonEns).Item("Ensayo") = OrDefault(WEspecif.Item("Ensayo" & i), "")
                            WEnsayos.Rows(WRenglonEns).Item("ValorStd") = Trim(OrDefault(WEspecif.Item("Valor" & i), "")) & " " & Trim(OrDefault(WEspecif.Item("Valor" & i & "" & i), ""))
                            WRenglonEns += 1
                        End If
                    End If
                Next

            End If

            For Each _e As DataRow In WEnsayos.Rows
                With _e
                    Dim WEns As DataRow = GetSingle("SELECT ISNULL(Descripcion, '') Descripcion FROM Ensayos WHERE Codigo = '" & _e.Item("Ensayo") & "'", WBaseEspecif)

                    If WEns Is Nothing Then Continue For

                    _e.Item("Ensayo") = _e.Item("Ensayo").ToString.PadLeft(4, "0") & "  " & Trim(WEns.Item("Descripcion"))

                End With
            Next

            Exit For

        Next

        If WEnsayos Is Nothing Then WEnsayos = New Data.DataTable

        Return WEnsayos

    End Function

    Private Function _MostrarEnsayosFarma(ByVal Hoja As String) As Data.DataTable
        Dim WEnsayos As New Data.DataTable
        Dim WDatosEnsayos As Data.DataTable = Nothing

        With WEnsayos.Columns
            .Add("Ensayo")
            .Add("Fecha")
            .Add("ValorStd")
            .Add("ValorReg")
            .Add("Valor")
        End With

        WDatosEnsayos = GetAll("SELECT TOP 50 ptf.Codigo, ptf.Fecha, ptf.Estado, ptf.Resultado, ptf.Valor, ptf.ValorReal, ptf.TipoEspecif, ptf.DesdeEspecif, ptf.HastaEspecif, ptf.UnidadEspecif, ptf.MenorIgualEspecif, ptf.Confecciono FROM PrueterFarma ptf INNER JOIN Hoja h ON h.Hoja = ptf.Partida And h.Producto = ptf.Producto And h.Renglon = 1 WHERE ptf.Partida = " & Hoja & " Order By ptf.Clave", "Surfactan_III")

        If WDatosEnsayos.Rows.Count = 0 Then Exit Function

        Dim WEns = 0
        Dim WEspecificacion = ""
        Dim WValor = ""
        Dim WTipoEspecif = ""
        Dim WDesdeEspecif = ""
        Dim WHastaEspecif = ""
        Dim WUnidadEspecif = ""
        Dim WMenorIgualEspecif = ""
        Dim WImpreParametro = ""
        Dim WImpreResultado = ""
        Dim WFecha = ""

        If OrDefault(WDatosEnsayos.Rows(0).Item("Estado"), 0) = 1 Then
            For Each row As DataRow In WDatosEnsayos.Rows
                With row
                    WEns = OrDefault(.Item("Codigo"), 0)
                    WEspecificacion = OrDefault(.Item("Valor"), "")
                    WFecha = OrDefault(.Item("Fecha"), "  /  /    ")
                    WValor = OrDefault(.Item("ValorReal"), "")
                    WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                    WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                    WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                    WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                    WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                    WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)
                    WImpreResultado = _GenerarImpreResultado(WValor, WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                    Dim r = WEnsayos.NewRow

                    With r
                        .Item("Ensayo") = WEns
                        .Item("Fecha") = WFecha
                        .Item("ValorStd") = WEspecificacion
                        .Item("ValorReg") = WImpreParametro
                        .Item("Valor") = WImpreResultado
                    End With

                    WEnsayos.Rows.Add(r)

                End With

            Next

        Else
            For Each row As DataRow In WDatosEnsayos.Rows
                With row
                    WEns = OrDefault(.Item("Codigo"), 0)
                    WEspecificacion = OrDefault(.Item("Valor"), "")
                    WFecha = OrDefault(.Item("Fecha"), "  /  /    ")
                    WValor = OrDefault(.Item("Resultado"), "")

                    Dim r = WEnsayos.NewRow

                    With r
                        .Item("Ensayo") = WEns
                        .Item("Fecha") = WFecha
                        .Item("ValorStd") = WEspecificacion
                        .Item("ValorReg") = WValor
                        .Item("Valor") = ""
                    End With

                    WEnsayos.Rows.Add(r)

                End With
            Next

        End If

        Return WEnsayos

    End Function

    Private Function _GenerarImpreResultado(ByVal wValor As Object, ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wMenorIgualEspecif As Object)
        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If Val(wTipoEspecif) = 0 Then

            Select Case UCase(Trim(wValor))
                Case "S"
                    Return "Cumple"
                Case "N"
                    Return "No Cumple"
            End Select

        Else

            Return String.Format("{0} {1}", Trim(wValor), Trim(wUnidadEspecif))

        End If

        Return ""
    End Function

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wMenorIgualEspecif As Object) As String
        ' If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If Val(wTipoEspecif) = 0 Then
            Return "Cumple Ensayo"
        Else

            If Val(wDesdeEspecif) = 0 And {99, 999, 9999}.Contains(Math.Truncate(Val(wHastaEspecif))) Then Return "Registrar e Informar."

            If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                    Return String.Format("{0} - {1} {2}", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
                End If

                If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                    If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Máximo {0} {1}", wHastaEspecif, wUnidadEspecif)

                    Return String.Format("Menor a {0} {1}", wHastaEspecif, wUnidadEspecif)

                End If

                If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                    If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Mínimo {0} {1}", wHastaEspecif, wUnidadEspecif)

                    Return String.Format("Mayor a {0} {1}", wHastaEspecif, wUnidadEspecif)

                End If

            End If
        End If

        Return ""
    End Function

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        dgvLaudos.Columns("Saldo").Visible = True

        ProgressBar1.Value = 0
        ProgressBar1.Maximum = dgvLaudos.Rows.Count

        btnCalcularSaldos.Text = "Calculando saldos..."

        For Each row As DataGridViewRow In dgvLaudos.Rows
            With row
                .Cells("Saldo").Value = _CalcularSaldoDeHoja(txtCodigo.Text, .Cells("Hoja").Value, Conexion.DeterminarSegunIDIDBasePara(.Cells("idPlanta").Value))
            End With
            ProgressBar1.Increment(1)

            btnCalcularSaldos.Text = btnCalcularSaldos.Text.Trim & "."
            btnCalcularSaldos.Text = btnCalcularSaldos.Text.PadRight(20, " ")

            If btnCalcularSaldos.Text.EndsWith("...") Then btnCalcularSaldos.Text = "Calculando saldos"

        Next

        btnCalcularSaldos.Text = "Calcula SALDOS"
        btnCalcularSaldos.Enabled = False

        ProgressBar1.Value = 0


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularSaldos.Click
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class