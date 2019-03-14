Imports System.Text.RegularExpressions
Imports ConsultasVarias
Imports ConsultasVarias.Clases
Imports ConsultasVarias.Clases.Globales
Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper

Public Class ListadoDevoluciones:Implements IExportar

    Private WCargadoPorCmd As Boolean = False

    Sub New(Optional ByVal WHoja As Object = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WCargadoPorCmd = Not IsNothing(WHoja)

        If WCargadoPorCmd Then

            If Regex.IsMatch(WHoja, "^[0-9]+") Then
                rbPorPartida.Checked = True
                RadioButton1_Click(Nothing, Nothing)
            Else
                rbPorCodigo.Checked = True
                RadioButton1_Click(Nothing, Nothing)
            End If

            txtBuscar.Text = WHoja
            txtBuscar_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        End If

    End Sub

    Private Sub ListadoDevoluciones_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtDescTerminado.BackColor = WBackColorTerciario
        For Each c As Control In {txtBuscar, txtCodigo, txtDescTerminado, txtFechaDesde, txtFechaHasta}
            If Not WCargadoPorCmd Then c.Text = ""
        Next

        'clbClientes.Items.Clear()
        'clbEstados.Items.Clear()

        dgvDevoluciones.InhabilitarOrdenamientoColumnas()

        cmbOrdenI.SelectedIndex = 0
        cmbOrdenII.SelectedIndex = 1
        cmbOrdenIII.SelectedIndex = 2

        '
        ' Cargamos los clientes.
        '
        Dim WClientes As DataTable = GetAll("SELECT Cliente, Razon = Cliente  + '   ' + LTRIM(Razon) FROM Cliente ORDER BY Razon")
        WClientes.Rows.Add("", " TODOS")
        WClientes.DefaultView.Sort = "Razon"
        With CType(clbClientes, ListBox)
            .DataSource = WClientes
            .DisplayMember = "Razon"
            .ValueMember = "Cliente"
            For i = 0 To .Items.Count - 1
                clbClientes.SetItemChecked(i, True)
            Next
        End With

        For i = 0 To clbEstados.Items.Count - 1
            clbEstados.SetItemChecked(i, True)
        Next

    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbPorPartida.Click, rbPorCodigo.Click
        With txtBuscar

            If rbPorCodigo.Checked Then
                .Mask = ">LL-00000-000"
            Else
                .Mask = ">&&&&&&&&&&&&&&&&&&&&"
            End If
            txtBuscar.Text = ""
            .SelectionStart = 0
            .SelectionLength = txtBuscar.Text.Length
            .Focus()
        End With
    End Sub

    Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBuscar.KeyDown

        If e.KeyData = Keys.Enter Then

            If rbPorCodigo.Checked And txtBuscar.Text.Replace(" ", "").Length < 12 Then Exit Sub
            If rbPorPartida.Checked And Val(txtBuscar.Text) = 0 Then Exit Sub

            Dim WDatos As DataRow = Nothing

            txtDescTerminado.Text = ""
            txtCodigo.Text = ""

            If rbPorCodigo.Checked Then

                Dim WCodigo As String = txtBuscar.Text

                If WCodigo.StartsWith("DK") Then WCodigo = "DY-" & Helper.Right(txtBuscar.Text, 9)
                If WCodigo.StartsWith("NW") Then WCodigo = "DW-" & Helper.Right(txtBuscar.Text, 9)
                If WCodigo.StartsWith("NK") Then WCodigo = "PT-" & Helper.Right(txtBuscar.Text, 9)

                If Microsoft.VisualBasic.Left(WCodigo, 2) = "DY" Then

                    Dim WProd = "DY-" & Helper.Right(WCodigo, 7)

                    WDatos = GetSingle("SELECT Codigo, Descripcion FROM Articulo WHERE Codigo = '" & WProd & "'")

                Else
                    WDatos = GetSingle("SELECT Codigo, Descripcion FROM Terminado WHERE Codigo = '" & txtBuscar.Text & "'")
                End If

                If WDatos Is Nothing Then
                    MsgBox("No se encuentra un producto asociado al Código '" & txtBuscar.Text & "'", MsgBoxStyle.Information)
                    Exit Sub
                End If

            Else

                For Each emp As String In Empresas
                    '
                    ' Lo busco como MATERIA PRIMA de REVENTA.
                    '
                    WDatos = GetSingle("SELECT l.Articulo As Codigo, a.Descripcion FROM Laudo l INNER JOIN Articulo a ON a.Codigo = l.Articulo WHERE left(Articulo, 2) IN ('DY', 'DW') And (PartiOri = '" & txtBuscar.Text.Trim & "' OR (ISNULL(PartiOri, '') = '' And Laudo = '" & txtBuscar.Text.Trim & "') Or Laudo = '" & txtBuscar.Text.Trim & "') Order by FechaOrd desc", emp)

                    '
                    ' En caso de no encontrar coincidencia, busco como PRODUCTO TERMINADO.
                    '
                    If WDatos Is Nothing Then
                        WDatos = GetSingle("SELECT h.Producto As Codigo, t.Descripcion FROM Hoja h INNER JOIN Terminado t ON t.Codigo = h.Producto WHERE LEFT(Producto, 2) IN ('DY', 'DW', 'PT') And Hoja = '" & txtBuscar.Text.Trim & "' ", emp)
                    End If

                    If WDatos IsNot Nothing Then Exit For
                Next

                If WDatos Is Nothing Then
                    MsgBox("No se encuentra un producto asociado a la Partida o Lote de Proveedor '" & txtBuscar.Text & "'", MsgBoxStyle.Information)
                    Exit Sub
                End If

            End If

            txtDescTerminado.Text = WDatos.Item("Descripcion")
            txtCodigo.Text = WDatos.Item("Codigo")

            btnFiltrar_Click(Nothing, Nothing)

            txtFechaDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtBuscar.Text = ""
        End If

    End Sub

    Private Sub txtFechaDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaDesde.Text.Replace(" ", "").Length < 10 Then Exit Sub

            If Not _ValidarFecha(txtFechaDesde.Text) Then Exit Sub

            txtFechaHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaDesde.Text = ""
        End If

    End Sub

    Private Sub txtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFechaHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtFechaHasta.Text.Replace(" ", "").Length < 10 Then Exit Sub

            If Not _ValidarFecha(txtFechaHasta.Text) Then Exit Sub

            btnFiltrar_Click(Nothing, Nothing)

            cmbOrdenI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaHasta.Text = ""
        End If

    End Sub

    Private Sub cmbOrdenI_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOrdenI.DropDownClosed
        cmbOrdenII.Focus()
    End Sub

    Private Sub cmbOrdenII_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOrdenII.DropDownClosed
        cmbOrdenIII.Focus()
    End Sub

    Private Sub cmbOrdenI_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbOrdenI.KeyDown

        If e.KeyData = Keys.Enter Then

            cmbOrdenII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbOrdenI.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbOrdenII_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbOrdenII.KeyDown

        If e.KeyData = Keys.Enter Then

            cmbOrdenIII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbOrdenII.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFiltrar.Click

        Cursor = Cursors.WaitCursor

        Dim WFechaDesdeOrd, WFechaHastaOrd, WFiltroFecha As String

        WFechaDesdeOrd = ordenaFecha(txtFechaDesde.Text)
        WFechaHastaOrd = ordenaFecha(txtFechaHasta.Text)

        WFiltroFecha = ""

        If Val(WFechaDesdeOrd) <> 0 And Val(WFechaHastaOrd) <> 0 Then WFiltroFecha = " FechaOrd BETWEEN '" & WFechaDesdeOrd & "' AND '" & WFechaHastaOrd & "'"

        Dim WOrdenI, WOrdenII, WOrdenIII, WFiltroOrden As String

        WOrdenI = _GenerarStringOrdenamiento(cmbOrdenI.SelectedIndex)
        WOrdenII = _GenerarStringOrdenamiento(cmbOrdenII.SelectedIndex)
        WOrdenIII = _GenerarStringOrdenamiento(cmbOrdenIII.SelectedIndex)

        WFiltroOrden = ""

        If WOrdenI.Trim <> "" Then WFiltroOrden = WOrdenI & ","
        If WOrdenII.Trim <> "" And Not WOrdenI.Contains(WOrdenII) Then WFiltroOrden &= WOrdenII & ","
        If WOrdenIII.Trim <> "" And Not WOrdenII.Contains(WOrdenIII) And Not WOrdenI.Contains(WOrdenIII) Then WFiltroOrden &= WOrdenIII

        WFiltroOrden = WFiltroOrden.TrimEnd(",")

        Dim WFiltroCodigo As String = ""
        Dim WCodigo As String = ""

        If (txtBuscar.Text.Replace(" ", "").Length = 12 And rbPorCodigo.Checked) Or (rbPorPartida.Checked And txtBuscar.Text <> "") Then

            WCodigo = Helper.Left(txtCodigo.Text, 2) & "-" & txtCodigo.Text.Substring(3, txtCodigo.Text.Length - 3).PadLeft(9, "0")

        End If

        If WCodigo <> "" Then

            If WCodigo.StartsWith("DY") Then WCodigo = WCodigo.Replace("DY", "DK")
            If WCodigo.StartsWith("DW") Then WCodigo = WCodigo.Replace("DW", "NW")
            If WCodigo.StartsWith("PT") Then WCodigo = WCodigo.Replace("PT", "NK")

            WFiltroCodigo = " Terminado = '" & WCodigo & "' "

            If rbPorPartida.Checked And txtBuscar.Text <> "" Then
                WFiltroCodigo &= " And Lote = '" & txtBuscar.Text.Trim & "'"
            End If

        End If

        Dim WDevols As New DataTable

        With WDevols
            .Columns.Add("Devolucion")
            .Columns.Add("Fecha")
            .Columns.Add("FechaOrd")
            .Columns.Add("Cantidad")
            .Columns.Add("Codigo")
            .Columns.Add("Observaciones")
            .Columns.Add("Partida")
            .Columns.Add("Cliente")
            .Columns.Add("DescCliente")
            .Columns.Add("PartiOri")
            .Columns.Add("Empresa")
            .Columns.Add("Estado")
        End With

        Dim WFiltroEstados As String = ""

        For Each item As Object In clbEstados.CheckedIndices
            WFiltroEstados &= "'" & clbEstados.Items(item).ToString & "',"
        Next

        WFiltroEstados = WFiltroEstados.TrimEnd(",")

        Dim WFiltroClientes As String = ""

        If clbClientes.Items.Count > 0 AndAlso Not clbClientes.GetSelected(0) Then
            For Each item As Object In clbClientes.CheckedItems
                WFiltroClientes &= "'" & CType(item, DataRowView).Item("Cliente") & "',"
            Next
        End If

        WFiltroClientes = WFiltroClientes.TrimEnd(",")

        If WFiltroCodigo <> "" Then WFiltroCodigo = " WHERE " & WFiltroCodigo

        If WFiltroFecha <> "" Then

            If WFiltroCodigo = "" Then
                WFiltroFecha = " WHERE " & WFiltroFecha
            Else
                WFiltroFecha = " And " & WFiltroFecha
            End If

        End If

        If WFiltroEstados <> "" Then
            If WFiltroCodigo = "" And WFiltroFecha = "" Then
                WFiltroEstados = " WHERE Estado IN (" & WFiltroEstados & ") "
            Else
                WFiltroEstados = " And Estado IN (" & WFiltroEstados & ") "
            End If
        End If

        If WFiltroClientes <> "" Then
            If WFiltroCodigo = "" And WFiltroFecha = "" And WFiltroEstados = "" Then
                WFiltroClientes = " WHERE Cliente IN (" & WFiltroClientes & ") "
            Else
                WFiltroClientes = " And Cliente IN (" & WFiltroClientes & ") "
            End If
        End If

        For Each emp As String In Empresas
            Dim WDevoluciones As DataTable = GetAll("SELECT * FROM EntDev " & WFiltroCodigo & " " & WFiltroFecha & " " & WFiltroEstados & " " & WFiltroClientes, emp)

            For Each row As DataRow In WDevoluciones.Rows
                With row

                    Dim _r As DataRow = WDevols.NewRow

                    _r.Item("Devolucion") = Trim(OrDefault(.Item("Codigo"), ""))
                    _r.Item("Fecha") = OrDefault(.Item("Fecha"), "")
                    _r.Item("FechaOrd") = ordenaFecha(_r.Item("Fecha"))
                    _r.Item("Cantidad") = formatonumerico(OrDefault(.Item("Cantidad"), 0))
                    _r.Item("Observaciones") = Trim(OrDefault(.Item("Observaciones"), ""))
                    _r.Item("Partida") = Trim(OrDefault(.Item("Lote"), ""))
                    _r.Item("Codigo") = Trim(OrDefault(.Item("Terminado"), ""))
                    _r.Item("Cliente") = Trim(OrDefault(.Item("Cliente"), ""))
                    _r.Item("DescCliente") = ""
                    Dim WCliente As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & _r.Item("Cliente") & "'")
                    If WCliente IsNot Nothing Then _r.Item("DescCliente") = Trim(OrDefault(WCliente.Item("Razon"), ""))
                    _r.Item("PartiOri") = Trim(OrDefault(.Item("PartiOri"), ""))
                    _r.Item("Estado") = _TraerEstadoProducto(_r.Item("Partida"), _r.Item("Codigo"), _r.Item("Cantidad"), emp, OrDefault(.Item("Estado"), "SIN DEFINIR"))
                    _r.Item("Empresa") = emp

                    WDevols.Rows.Add(_r)

                End With
            Next

        Next

        WDevols.DefaultView.Sort = WFiltroOrden

        Cursor = Cursors.Default

        dgvDevoluciones.DataSource = WDevols

        VerDevolucionesParaEsteCódigoToolStripMenuItem.Enabled = False

        If (txtBuscar.Text.Replace(" ", "").Length < 12 And rbPorCodigo.Checked) Or rbPorPartida.Checked Then
            VerDevolucionesParaEsteCódigoToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Function _TraerEstadoProducto(ByVal _Hoja As String, ByVal _Terminado As String, ByVal _Cantidad As String, ByVal _Empresa As String, ByVal Defecto As String) As String

        For Each emp As String In Empresas

            Dim WHoja As DataRow = GetSingle("SELECT Producto FROM Hoja WHERE Tipo = 'T' And Terminado = '" & _Terminado & "' And Lote1 = '" & _Hoja & "' And Cantidad = '" & _Cantidad & "'", emp)

            If WHoja IsNot Nothing Then
                Return Helper.Left(WHoja.Item("Producto"), 2).ToUpper
            End If

        Next

        Return Defecto

    End Function

    Private Function _GenerarStringOrdenamiento(ByVal selectedIndex As Integer) As String

        Select Case selectedIndex
            Case 0
                Return "FechaOrd DESC"
            Case 1
                Return "Cliente"
            Case 2
                Return "Estado"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListadoDevoluciones_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtBuscar.Focus()
    End Sub

    Private Sub clbEstados_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles clbEstados.MouseUp, clbClientes.MouseUp
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

    Private Sub dgvDevoluciones_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDevoluciones.CellMouseDoubleClick
        Try

            '
            ' Busco el producto al cual nos referimos.
            '
            Dim WCodigo As String = OrDefault(dgvDevoluciones.CurrentRow.Cells("Codigo").Value, "")
            Dim WPartida As String = OrDefault(dgvDevoluciones.CurrentRow.Cells("Partida").Value, "")

            If WCodigo.Trim = "" Then Exit Sub

            '
            ' Según el producto, determinamos que tipos de datos tenemos que buscar y listar.
            '
            If {"DK", "DW"}.Contains(UCase(Helper.Left(WCodigo, 2))) Then
                With New DetallesEnsayosMP(WPartida)
                    .Show(Me)
                End With
            Else
                With New DetallesEnsayosPT(WPartida)
                    .Show(Me)
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerEnsayosDeProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerEnsayosDeProductoToolStripMenuItem.Click
        Try
            If dgvDevoluciones.SelectedRows.Count = 0 Then
                For Each cell As DataGridViewCell In dgvDevoluciones.SelectedCells
                    dgvDevoluciones.Rows(cell.RowIndex).Selected = True
                Next
            End If

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                Exit Sub
            End If

            '
            ' Busco el producto al cual nos referimos.
            '
            Dim WCodigo As String = OrDefault(dgvDevoluciones.SelectedRows(0).Cells("Codigo").Value, "")
            Dim WPartida As String = OrDefault(dgvDevoluciones.SelectedRows(0).Cells("Partida").Value, "")

            If WCodigo.Trim = "" Then Exit Sub

            '
            ' Según el producto, determinamos que tipos de datos tenemos que buscar y listar.
            '
            If {"DK", "DW"}.Contains(UCase(Helper.Left(WCodigo, 2))) Then
                With New DetallesEnsayosMP(WPartida)
                    .Show(Me)
                End With
            Else
                With New DetallesEnsayosPT(WPartida)
                    .Show(Me)
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerMovimientosDeProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerMovimientosDeProductoToolStripMenuItem.Click
        Try

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                For Each cell As DataGridViewCell In dgvDevoluciones.SelectedCells
                    dgvDevoluciones.Rows(cell.RowIndex).Selected = True
                Next
            End If

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                Exit Sub
            End If

            '
            ' Busco el producto al cual nos referimos.
            '
            Dim WCodigo As String = OrDefault(dgvDevoluciones.SelectedRows(0).Cells("Codigo").Value, "")
            Dim WPartida As String = OrDefault(dgvDevoluciones.SelectedRows(0).Cells("Partida").Value, "")

            If WCodigo.Trim = "" Then Exit Sub

            '
            ' Según el producto, determinamos que tipos de datos tenemos que buscar y listar.
            '
            If {"DK", "DW"}.Contains(UCase(Helper.Left(WCodigo, 2))) Then
                With New DetalleMovimientosMP(WPartida)
                    .Show(Me)
                End With
            Else
                With New DetalleMovimientosPT(WPartida)
                    .Show(Me)
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerDevolucionesParaEstaPartidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDevolucionesParaEstaPartidaToolStripMenuItem.Click
        Try

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                For Each cell As DataGridViewCell In dgvDevoluciones.SelectedCells
                    dgvDevoluciones.Rows(cell.RowIndex).Selected = True
                Next
            End If

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                Exit Sub
            End If

            '
            ' Busco el producto al cual nos referimos.
            '
            Dim WPartida As String = OrDefault(dgvDevoluciones.SelectedRows(0).Cells("Partida").Value, "")

            If WPartida.Trim = "" Then Exit Sub

            rbPorPartida.Checked = True
            RadioButton1_Click(Nothing, Nothing)
            txtBuscar.Text = WPartida

            txtBuscar_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            btnFiltrar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerDevolucionesParaEsteCódigoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDevolucionesParaEsteCódigoToolStripMenuItem.Click
        Try

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                For Each cell As DataGridViewCell In dgvDevoluciones.SelectedCells
                    dgvDevoluciones.Rows(cell.RowIndex).Selected = True
                Next
            End If

            If dgvDevoluciones.SelectedRows.Count = 0 Then
                Exit Sub
            End If

            '
            ' Busco el producto al cual nos referimos.
            '
            Dim WCodigo As String = OrDefault(dgvDevoluciones.SelectedRows(0).Cells("Codigo").Value, "")

            If WCodigo.Trim = "" Then Exit Sub

            rbPorCodigo.Checked = True
            RadioButton1_Click(Nothing, Nothing)
            txtBuscar.Text = WCodigo

            txtBuscar_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            btnFiltrar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtBuscar, txtCodigo, txtDescTerminado, txtFechaDesde, txtFechaHasta}
            c.Text = ""
        Next

        cmbOrdenI.SelectedIndex = 0
        cmbOrdenII.SelectedIndex = 1
        cmbOrdenIII.SelectedIndex = 2

        For i = 0 To clbClientes.Items.Count - 1
            clbClientes.SetItemChecked(i, True)
        Next

        For i = 0 To clbEstados.Items.Count - 1
            clbEstados.SetItemChecked(i, True)
        Next

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        With New Exportar
            .Show(Me)
        End With
    End Sub

    Public Sub _ProcesarExportar(ByVal TipoSalida As [Enum]) Implements IExportar._ProcesarExportar
        Dim frm As New VistaPrevia
        frm.Reporte = New ReporteDevolucionesClientes

        Dim tabla As DataTable

        tabla = New DSAuxi.DevolClientesDataTable

        For Each row As DataGridViewRow In dgvDevoluciones.Rows
            With row
                Dim r As DataRow = tabla.NewRow

                r.Item("Nro") = OrDefault(.Cells("Devolucion").Value, 0)
                r.Item("Fecha") = OrDefault(.Cells("Fecha").Value, "")
                r.Item("Codigo") = OrDefault(.Cells("Codigo").Value, "")
                r.Item("Partida") = OrDefault(.Cells("Partida").Value, 0)
                r.Item("Cantidad") = OrDefault(.Cells("Cantidad").Value, 0)
                r.Item("LoteProv") = OrDefault(.Cells("PartiOri").Value, "")
                r.Item("Observaciones") = OrDefault(.Cells("Observaciones").Value, "")
                r.Item("Cliente") = OrDefault(.Cells("Cliente").Value, "")
                r.Item("NombreCliente") = OrDefault(.Cells("DescCliente").Value, "")
                r.Item("Estado") = OrDefault(.Cells("Estado").Value, "")

                tabla.Rows.Add(r)
            End With
        Next

        frm.Reporte.SetDataSource(tabla)

        Helper._ExportarReporte(frm, TipoSalida)
    End Sub
End Class