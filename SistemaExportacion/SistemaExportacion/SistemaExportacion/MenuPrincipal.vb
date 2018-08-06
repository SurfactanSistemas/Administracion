Imports System.Data.SqlClient

Public Class MenuPrincipal

    Private Sub btnNuevaProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaProforma.Click

        With Proforma
            If Not .Visible Then
                .ShowDialog()
                .Dispose()
            Else
                .Focus()
            End If
        End With

        _CargarTodasLasProformas()
    End Sub

    Private Sub btnHistorialProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorialProforma.Click
        'MsgBox("En Desarrollo. Sin Implementacion todavia.")
        'Exit Sub
        With HistorialProforma

            If Not .Visible Then
                If dgvPrincipal.SelectedRows.Count = 1 Then
                    .NroProforma = dgvPrincipal.CurrentRow.Cells(0).Value
                ElseIf dgvPrincipal.SelectedCells.Count > 0 Then

                    ' Nos quedamos con la primera fila de las seleccionadas.
                    With dgvPrincipal
                        Dim PrimeraCelda = .SelectedCells.Item(.SelectedCells.Count - 1).RowIndex

                        HistorialProforma.NroProforma = .Rows(PrimeraCelda).Cells(0).Value
                    End With
                End If

                .Show()
            Else
                .Focus()
            End If

        End With
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarTodasLasProformas()
    End Sub

    Public Sub _CargarTodasLasProformas()
        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WFechaLimite, WPackingList, WRowIndex, WEntregado
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim WFiltro = "AND (Entregado <> 'X' OR Entregado IS NULL)"

        If ckMostrarEntregadas.Checked then WFiltro = ""

        Dim ZSql = "SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total, p.FechaLimiteOrd, p.PackingList, isnull(p.Entregado, '') as Entregado FROM ProformaExportacion as p, Cliente as c WHERE p.Cliente = c.Cliente  " & WFiltro & "  ORDER BY p.FechaOrd, p.Proforma"

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            cm.CommandText = ZSql
            dr = cm.ExecuteReader()
            
            dgvPrincipal.Rows.Clear()

            If dr.HasRows Then

                WProforma = ""
                WFecha = ""
                WCliente = ""
                WRazon = ""
                WPais = ""
                WTotal = 0.0
                WFechaLimite = ""
                WPackingList = ""
                WEntregado = ""
                WRowIndex = 0

                Do While dr.Read()

                    WProforma = ""
                    WFecha = ""
                    WCliente = ""
                    WRazon = ""
                    WPais = ""
                    WTotal = 0.0

                    With dr
                        WProforma = IIf(IsDBNull(.Item("Proforma")), "", .Item("Proforma"))
                        WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                        WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                        WPais = IIf(IsDBNull(.Item("Pais")), "", .Item("Pais"))
                        WTotal = IIf(IsDBNull(.Item("Total")), 0.0, .Item("Total"))
                        WFechaLimite = IIf(IsDBNull(.Item("FechaLimiteOrd")), "", .Item("FechaLimiteOrd"))
                        WPackingList = IIf(IsDBNull(.Item("PackingList")), "", .Item("PackingList"))
                        WEntregado = IIf(IsDBNull(.Item("Entregado")), "", .Item("Entregado"))

                        WRowIndex = dgvPrincipal.Rows.Add
                    End With

                    With dgvPrincipal.Rows(WRowIndex)
                        .Cells("NroProforma").Value = WProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Pais").Value = WPais
                        .Cells("Total").Value = Helper.formatonumerico(WTotal)
                        .Cells("FechaLimite").Value = IIf(Val(WFechaLimite) <> 0, WFechaLimite, "")
                        .Cells("PackingList").Value = WPackingList
                        .Cells("PackingListImg").Value = IIf(Val(WPackingList) = 0, My.Resources.cancelado, My.Resources.ok)
                        .Cells("PackingListImg").Style.BackColor = Color.White
                        .Cells("PackingListImg").Style.SelectionBackColor = Color.White
                        .Cells("Entregado").Value = UCase(WEntregado)
                    End With

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer listar las Proformas desde la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Try
            _ColorearProformasVencidasYSinPackingListRecibido()
        Catch ex As Exception
            MsgBox("Hubo un problema al querer marcar las proformas vencidas.", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _ColorearProformasVencidasYSinPackingListRecibido()
        For Each row As DataGridViewRow In dgvPrincipal.Rows
            With row
                ' Chequeamos que tenga fecha limite indicada.
                If Trim(.Cells("FechaLimite").Value) <> "" Then

                    If Val(Helper.ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) > Val(.Cells("FechaLimite").Value) And .Cells("PackingList").Value <> "1" Then
                        .DefaultCellStyle.BackColor = Color.Red
                        .DefaultCellStyle.ForeColor = Color.White
                    End If

                End If
            End With
        Next
    End Sub

    Private Sub _Filtrar(ByVal _Filtros)
        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WRowIndex
        Dim WSQL As String = "SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total FROM ProformaExportacion as p, Cliente as c WHERE p.Cliente = c.Cliente AND #FILTROS# ORDER BY p.FechaOrd, p.Proforma"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = WSQL.Replace("#FILTROS#", _Filtros)

            dr = cm.ExecuteReader()

            dgvPrincipal.Rows.Clear()

            If dr.HasRows Then

                WProforma = ""
                WFecha = ""
                WCliente = ""
                WRazon = ""
                WPais = ""
                WTotal = 0.0
                WRowIndex = 0

                Do While dr.Read()

                    WProforma = ""
                    WFecha = ""
                    WCliente = ""
                    WRazon = ""
                    WPais = ""
                    WTotal = 0.0

                    With dr
                        WProforma = IIf(IsDBNull(.Item("Proforma")), "", .Item("Proforma"))
                        WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                        WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                        WPais = IIf(IsDBNull(.Item("Pais")), "", .Item("Pais"))
                        WTotal = IIf(IsDBNull(.Item("Total")), 0.0, .Item("Total"))

                        WRowIndex = dgvPrincipal.Rows.Add
                    End With

                    With dgvPrincipal.Rows(WRowIndex)
                        .Cells("NroProforma").Value = WProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Pais").Value = WPais
                        .Cells("Total").Value = Helper.formatonumerico(WTotal)
                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer filtrar las Proformas de la Base de Datos.")
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub dgvPrincipal_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrincipal.CellContentDoubleClick
        
        If Not IsNothing(dgvPrincipal.Rows(e.RowIndex).Cells(0).Value) Then

            With Proforma
                If Not .Visible Then
                    .NroProforma = dgvPrincipal.Rows(e.RowIndex).Cells(0).Value
                    .Show()
                Else
                    .Focus()
                End If
                
            End With

        End If

    End Sub

    Private Sub txtFiltrarPor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrarPor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFiltrarPor.Text) = "" Then
                _CargarTodasLasProformas()
                Exit Sub
            End If

            If cmbTipoFiltro.SelectedIndex < 1 Then : Exit Sub : End If

            Dim WFiltro = ""

            Select Case cmbTipoFiltro.SelectedIndex
                Case 1  ' Nro Proforma
                    WFiltro = "p.Proforma LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 2 ' Fecha
                    WFiltro = "p.Fecha LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 3 ' Cliente
                    WFiltro = "(p.Cliente LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR c.Razon LIKE '%" & Trim(txtFiltrarPor.Text) & "%')"
                Case 4 ' Pais
                    WFiltro = "p.Pais LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                    'Case 5 ' Monto
                    '    WFiltro = "p.Total LIKE '%" & Trim(TextBox1.Text).Replace(",", ".") & "%'"
                Case Else
                    Exit Sub
            End Select

            Try
                _Filtrar(WFiltro)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                _CargarTodasLasProformas()
                Exit Sub
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtFiltrarPor.Text = ""
        End If

    End Sub

    Private Sub cmbTipoFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoFiltro.SelectedIndexChanged

        _CargarTodasLasProformas()

        Select Case cmbTipoFiltro.SelectedIndex
            Case 5

                txtFiltrarPor.Enabled = False
                _TraerProformasSinPackingList()

            Case 6

                txtFiltrarPor.Enabled = False
                _TraerProformasVencidasSinPackingList()

            Case Else

                txtFiltrarPor.Enabled = True
                txtFiltrarPor.Text = ""
                txtFiltrarPor.Focus()

        End Select


    End Sub

    Private Sub _TraerProformasVencidasSinPackingList()

        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WFechaLimite, WPackingList, WRowIndex
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total, p.FechaLimiteOrd, p.PackingList FROM ProformaExportacion as p, Cliente as c WHERE p.FechaLimite <> '  /  /    ' AND PackingList = '0' AND p.Cliente = c.Cliente ORDER BY p.FechaOrd, p.Proforma")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()
            dgvPrincipal.Rows.Clear()

            If dr.HasRows Then

                WProforma = ""
                WFecha = ""
                WCliente = ""
                WRazon = ""
                WPais = ""
                WTotal = 0.0
                WFechaLimite = ""
                WPackingList = ""
                WRowIndex = 0

                Do While dr.Read()

                    WProforma = ""
                    WFecha = ""
                    WCliente = ""
                    WRazon = ""
                    WPais = ""
                    WTotal = 0.0

                    With dr
                        WProforma = IIf(IsDBNull(.Item("Proforma")), "", .Item("Proforma"))
                        WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                        WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                        WPais = IIf(IsDBNull(.Item("Pais")), "", .Item("Pais"))
                        WTotal = IIf(IsDBNull(.Item("Total")), 0.0, .Item("Total"))
                        WFechaLimite = IIf(IsDBNull(.Item("FechaLimiteOrd")), "", .Item("FechaLimiteOrd"))
                        WPackingList = IIf(IsDBNull(.Item("PackingList")), "", .Item("PackingList"))

                        WRowIndex = dgvPrincipal.Rows.Add
                    End With

                    If Val(Helper.ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) > Helper.ordenaFecha(WFechaLimite) Then

                        With dgvPrincipal.Rows(WRowIndex)
                            .Cells("NroProforma").Value = WProforma
                            .Cells("Fecha").Value = WFecha
                            .Cells("Cliente").Value = WCliente
                            .Cells("Razon").Value = WRazon
                            .Cells("Pais").Value = WPais
                            .Cells("Total").Value = Helper.formatonumerico(WTotal)
                            .Cells("FechaLimite").Value = IIf(Val(WFechaLimite) <> 0, WFechaLimite, "")
                            .Cells("PackingList").Value = WPackingList
                        End With

                    End If

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer listar las Proformas desde la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Try
            _ColorearProformasVencidasYSinPackingListRecibido()
        Catch ex As Exception
            MsgBox("Hubo un problema al querer marcar las proformas vencidas.", MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub _TraerProformasSinPackingList()

        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WFechaLimite, WPackingList, WRowIndex
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total, p.FechaLimiteOrd, p.PackingList FROM ProformaExportacion as p, Cliente as c WHERE PackingList = '0' AND p.Cliente = c.Cliente ORDER BY p.FechaOrd, p.Proforma")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()
            dgvPrincipal.Rows.Clear()

            If dr.HasRows Then

                WProforma = ""
                WFecha = ""
                WCliente = ""
                WRazon = ""
                WPais = ""
                WTotal = 0.0
                WFechaLimite = ""
                WPackingList = ""
                WRowIndex = 0

                Do While dr.Read()

                    WProforma = ""
                    WFecha = ""
                    WCliente = ""
                    WRazon = ""
                    WPais = ""
                    WTotal = 0.0

                    With dr
                        WProforma = IIf(IsDBNull(.Item("Proforma")), "", .Item("Proforma"))
                        WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        WCliente = IIf(IsDBNull(.Item("Cliente")), "", .Item("Cliente"))
                        WRazon = IIf(IsDBNull(.Item("Razon")), "", .Item("Razon"))
                        WPais = IIf(IsDBNull(.Item("Pais")), "", .Item("Pais"))
                        WTotal = IIf(IsDBNull(.Item("Total")), 0.0, .Item("Total"))
                        WFechaLimite = IIf(IsDBNull(.Item("FechaLimiteOrd")), "", .Item("FechaLimiteOrd"))
                        WPackingList = IIf(IsDBNull(.Item("PackingList")), "", .Item("PackingList"))

                        WRowIndex = dgvPrincipal.Rows.Add
                    End With

                    'If Val(Helper.ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) > Helper.ordenaFecha(WFechaLimite) Then

                    With dgvPrincipal.Rows(WRowIndex)
                        .Cells("NroProforma").Value = WProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Pais").Value = WPais
                        .Cells("Total").Value = Helper.formatonumerico(WTotal)
                        .Cells("FechaLimite").Value = IIf(Val(WFechaLimite) <> 0, WFechaLimite, "")
                        .Cells("PackingList").Value = WPackingList
                    End With

                    'End If

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer listar las Proformas desde la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Try
            _ColorearProformasVencidasYSinPackingListRecibido()
        Catch ex As Exception
            MsgBox("Hubo un problema al querer marcar las proformas vencidas.", MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub dgvPrincipal_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrincipal.CellDoubleClick
        If Not IsNothing(dgvPrincipal.Rows(e.RowIndex).Cells(0).Value) Then

            With Proforma
                If Not .Visible Then
                    .NroProforma = dgvPrincipal.Rows(e.RowIndex).Cells(0).Value
                    .Show()
                Else
                    .Focus()
                End If
                
            End With

        End If
    End Sub

    Private Sub btnAperturaArchivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAperturaArchivos.Click
        With ConsultaArticulosProforma
            If Not .Visible Then
                .Show()
            Else
                .Focus()
            End If

        End With
    End Sub

    Private Sub btnLimpiarFiltros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltros.Click

        _CargarTodasLasProformas()
        cmbTipoFiltro.SelectedIndex = 0
        txtFiltrarPor.Focus()

    End Sub

    Private Sub dgvPrincipal_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgvPrincipal.SortCompare
        Dim num1, num2

        Select Case e.Column.Index
            Case 0, 5

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 1

                num1 = Helper.ordenaFecha(e.CellValue1)
                num2 = Helper.ordenaFecha(e.CellValue2)

            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True
    End Sub

    Private Sub ckMostrarCerradasAprobadas_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles ckMostrarEntregadas.CheckedChanged
        _CargarTodasLasProformas()
    End Sub
End Class
