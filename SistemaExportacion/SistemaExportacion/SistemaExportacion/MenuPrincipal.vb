Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.IO
Imports Util
Imports Util.Clases
Imports Util.Clases.Helper
Imports Util.Clases.Query
Public Class MenuPrincipal : Implements IActualizaGrillaProforma




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

        Dim WOperador As DataRow = GetSingle("SELECT SistemaExportacion FROM Operador WHERE UPPER(Clave) = '" & Operador.Clave & "'", "SurfactanSa")
        If WOperador IsNot Nothing Then
            If WOperador.Item("SistemaExportacion") = 3 Then
                btnNuevaProforma.Enabled = False
                btnAperturaArchivos.Enabled = False
            End If
        End If



    End Sub

    Public Sub _CargarTodasLasProformas()
        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WORDFechaLimite, WPackingList, WRowIndex, WEntregado

        ' nuevas variables proforma
        Dim WMV_Buque, WETD_FechaSalida, WOrd_ETD_FechaSalida, WETA_FechaArribo, WOrd_ETA_FechaArribo,
            WPermiso_de_Embarque, WBL, WForwarder, WCombox_Estado, WFecha_Limite, WFechaCobro As String
        Dim WPesoNeto As Double
        Dim WCondicion As Integer
        'fin nuevas variables

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        'Dim WFiltro = "AND (Entregado <> '1' OR Entregado IS NULL)"
        Dim WFiltro = "AND (Entregado <> 'X' OR Entregado IS NULL)"

        If ckMostrarEntregadas.Checked Then WFiltro = ""

        Dim ZSql = "SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total,p.FechaLimite, p.FechaLimiteOrd, p.PackingList, isnull(p.Entregado, '') as Entregado, p.Condicion, p.MV_Buque, p.ETD_FechaSalida, p.ETA_FechaArribo, p.Permiso_de_Embarque, p.BL, p.Forwarder, p.Combox_Estado, p.PesoNeto, p.FechaCobro, p.OrdFechaCobro FROM ProformaExportacion as p, Cliente as c WHERE p.Cliente = c.Cliente  " & WFiltro & "  ORDER BY p.FechaOrd, p.Proforma"

        Try

            cn.ConnectionString = _ConectarA()
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
                WORDFechaLimite = ""
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
                        WORDFechaLimite = IIf(IsDBNull(.Item("FechaLimiteOrd")), "", .Item("FechaLimiteOrd"))
                        WPackingList = IIf(IsDBNull(.Item("PackingList")), "", .Item("PackingList"))
                        WEntregado = IIf(IsDBNull(.Item("Entregado")), "", .Item("Entregado"))

                        'INCLUIR NUEVOS CAMPOS
                        WCondicion = IIf(IsDBNull(dr.Item("Condicion")), 0, dr.Item("Condicion"))
                        WFecha_Limite = IIf(IsDBNull(dr.Item("FechaLimite")), "", dr.Item("FechaLimite"))
                        WMV_Buque = IIf(IsDBNull(.Item("MV_Buque")), "", .Item("MV_Buque"))
                        WPermiso_de_Embarque = IIf(IsDBNull(.Item("Permiso_de_Embarque")), "", .Item("Permiso_de_Embarque"))
                        WForwarder = IIf(IsDBNull(.Item("Forwarder")), "", .Item("Forwarder"))
                        WETA_FechaArribo = IIf(IsDBNull(.Item("ETA_FechaArribo")), "", .Item("ETA_FechaArribo"))
                        WETD_FechaSalida = IIf(IsDBNull(.Item("ETD_FechaSalida")), "", .Item("ETD_FechaSalida"))
                        WBL = IIf(IsDBNull(.Item("BL")), "", .Item("BL"))
                        WPesoNeto = IIf(IsDBNull(.Item("PesoNeto")), 0.0, .Item("PesoNeto"))
                        WCombox_Estado = IIf(IsDBNull(.Item("Combox_Estado")), "", .Item("Combox_Estado"))
                        WFechaCobro = IIf(IsDBNull(.Item("FechaCobro")), "", .Item("FechaCobro"))
                        'FIN NUEVAS INCLUCIONES




                        WRowIndex = dgvPrincipal.Rows.Add
                    End With

                    With dgvPrincipal.Rows(WRowIndex)
                        .Cells("NroProforma").Value = WProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Pais").Value = WPais
                        .Cells("Total").Value = formatonumerico(WTotal)
                        .Cells("FechaLimite").Value = IIf(Val(WORDFechaLimite) <> 0, WORDFechaLimite, "")
                        .Cells("PackingList").Value = WPackingList
                        .Cells("PackingListImg").Value = IIf(Val(WPackingList) = 0, My.Resources.cancelado, My.Resources.ok)
                        .Cells("PackingListImg").Style.BackColor = Color.White
                        .Cells("PackingListImg").Style.SelectionBackColor = Color.White
                        .Cells("Entregado").Value = UCase(WEntregado)

                        .Cells("Incoterm").Value = obtenerCondicion(WCondicion)
                        .Cells("Fecha_Limite").Value = Trim(WFecha_Limite)
                        .Cells("MV_Buque").Value = Trim(WMV_Buque)
                        .Cells("Permiso_de_Embarque").Value = Trim(WPermiso_de_Embarque)
                        .Cells("Forwarder").Value = Trim(WForwarder)
                        .Cells("ETA_FechaArribo").Value = WETA_FechaArribo
                        .Cells("ETD_FechaSalida").Value = WETD_FechaSalida
                        .Cells("BL").Value = Trim(WBL)
                        .Cells("Peso_Neto").Value = formatonumerico(WPesoNeto)
                        .Cells("Combox_Estado").Value = Trim(WCombox_Estado)
                        .Cells("Fecha_Cobro").Value = WFechaCobro

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

    Private Function obtenerCondicion(ByVal incoterm As Integer) As String
        Dim Condicion As String
        Select Case incoterm
            Case 0
                Condicion = ""
            Case 1
                Condicion = "FOB"
            Case 2
                Condicion = "CIF"
            Case 3
                Condicion = "CFR"
            Case 4
                Condicion = "CPT"
            Case 5
                Condicion = "EXW"
            Case 6
                Condicion = "FCA"
            Case 7
                Condicion = "FAS"
            Case 8
                Condicion = "CIP"
            Case 9
                Condicion = "DAF"
            Case 10
                Condicion = "DES"
            Case 11
                Condicion = "DEQ"
            Case 12
                Condicion = "DDA"
            Case 13
                Condicion = "DDP"
            Case 14
                Condicion = "DAP"
            Case 15
                Condicion = "DDU"
            Case 16
                Condicion = "DAT"
        End Select
        Return Condicion
    End Function
    Private Sub _ColorearProformasVencidasYSinPackingListRecibido()
        For Each row As DataGridViewRow In dgvPrincipal.Rows
            With row
                ' Chequeamos que tenga fecha limite indicada.
                If Trim(.Cells("FechaLimite").Value) <> "" Then

                    If Val(ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) > Val(.Cells("FechaLimite").Value) And .Cells("PackingList").Value <> "1" Then
                        .DefaultCellStyle.BackColor = Color.Red
                        .DefaultCellStyle.ForeColor = Color.White
                    End If

                End If
            End With
        Next
    End Sub

    Private Sub _Filtrar(ByVal _Filtros)
        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WRowIndex
        Dim WSQL As String = "SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total, p.Condicion, p.FechaLimite, p.MV_Buque, p.ETD_FechaSalida, p.ETA_FechaArribo, p.Permiso_de_Embarque, p.BL, p.Forwarder, p.Combox_Estado, p.PesoNeto  FROM ProformaExportacion as p, Cliente as c WHERE p.Cliente = c.Cliente AND #FILTROS# ORDER BY p.FechaOrd, p.Proforma"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        ' nuevas variables proforma
        Dim WMV_Buque, WETD_FechaSalida, WOrd_ETD_FechaSalida, WETA_FechaArribo, WOrd_ETA_FechaArribo, WPermiso_de_Embarque, WBL, WForwarder, WCombox_Estado, WFecha_Limite As String
        Dim WPesoNeto As Double
        Dim WCondicion As Integer
        'fin nuevas variables



        Try

            cn.ConnectionString = _ConectarA()
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

                        'INCLUIR NUEVOS CAMPOS
                        WCondicion = IIf(IsDBNull(dr.Item("Condicion")), 0, dr.Item("Condicion"))
                        WFecha_Limite = IIf(IsDBNull(dr.Item("FechaLimite")), "", dr.Item("FechaLimite"))
                        WMV_Buque = IIf(IsDBNull(.Item("MV_Buque")), "", .Item("MV_Buque"))
                        WPermiso_de_Embarque = IIf(IsDBNull(.Item("Permiso_de_Embarque")), "", .Item("Permiso_de_Embarque"))
                        WForwarder = IIf(IsDBNull(.Item("Forwarder")), "", .Item("Forwarder"))
                        WETA_FechaArribo = IIf(IsDBNull(.Item("ETA_FechaArribo")), "", .Item("ETA_FechaArribo"))
                        WETD_FechaSalida = IIf(IsDBNull(.Item("ETD_FechaSalida")), "", .Item("ETD_FechaSalida"))
                        WBL = IIf(IsDBNull(.Item("BL")), "", .Item("BL"))
                        WPesoNeto = IIf(IsDBNull(.Item("PesoNeto")), 0.0, .Item("PesoNeto"))
                        WCombox_Estado = IIf(IsDBNull(.Item("Combox_Estado")), "", .Item("Combox_Estado"))
                        'FIN NUEVAS INCLUCIONES




                        WRowIndex = dgvPrincipal.Rows.Add
                    End With

                    With dgvPrincipal.Rows(WRowIndex)
                        .Cells("NroProforma").Value = WProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Pais").Value = WPais
                        .Cells("Total").Value = formatonumerico(WTotal)

                        .Cells("Incoterm").Value = obtenerCondicion(WCondicion)
                        .Cells("Fecha_Limite").Value = Trim(WFecha_Limite)
                        .Cells("MV_Buque").Value = Trim(WMV_Buque)
                        .Cells("Permiso_de_Embarque").Value = Trim(WPermiso_de_Embarque)
                        .Cells("Forwarder").Value = Trim(WForwarder)
                        .Cells("ETA_FechaArribo").Value = WETA_FechaArribo
                        .Cells("ETD_FechaSalida").Value = WETD_FechaSalida
                        .Cells("BL").Value = Trim(WBL)
                        .Cells("Peso_Neto").Value = formatonumerico(WPesoNeto)
                        .Cells("Combox_Estado").Value = Trim(WCombox_Estado)

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
                    .Show(Me)
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
                Case 7 ' Razon Social
                    WFiltro = "c.Razon LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 8 ' Fecha Limite
                    WFiltro = "p.FechaLimite LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                    ' Case 9 ' Incoterm
                    '    WFiltro = "p.Condicion LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 9 ' M.V.
                    WFiltro = "p.MV_Buque LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 10 ' E.T.D
                    WFiltro = "p.ETD_FechaSalida LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 11 ' E.T.A
                    WFiltro = "p.ETA_FechaArribo LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 12 ' Peso Neto
                    WFiltro = "p.PesoNeto LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 13 ' Permiso de embarque
                    WFiltro = "p.Permiso_de_Embarque LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 14 ' BL
                    WFiltro = "p.BL LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 15 ' Forwarder
                    WFiltro = "p.Forwarder LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"
                Case 16 ' Estado grilla
                    WFiltro = "p.Combox_Estado LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"


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

            cn.ConnectionString = _ConectarA()
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

                    If Val(ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) > ordenaFecha(WFechaLimite) Then

                        With dgvPrincipal.Rows(WRowIndex)
                            .Cells("NroProforma").Value = WProforma
                            .Cells("Fecha").Value = WFecha
                            .Cells("Cliente").Value = WCliente
                            .Cells("Razon").Value = WRazon
                            .Cells("Pais").Value = WPais
                            .Cells("Total").Value = formatonumerico(WTotal)
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

            cn.ConnectionString = _ConectarA()
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
                        .Cells("Total").Value = formatonumerico(WTotal)
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
                    .Show(Me)
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
            Case 0, 5, 16

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 1, 11, 14, 15, 20

                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)

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

    Private Sub ckMostrarCerradasAprobadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckMostrarEntregadas.CheckedChanged
        _CargarTodasLasProformas()
    End Sub

    Public Sub ActualizaGrilla() Implements IActualizaGrillaProforma.ActualizaGrilla
        btnLimpiarFiltros_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click



        ' Cambiamos el tipo de cursor
        '
        Dim tipoCursor As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor

        Try
            ' Referenciamos el objeto DataTable enlazado con
            ' el control DataGridView que fueron seleccionados
            '
            Dim TablaExportar As DataTable = New DBAuxi.TablaReporteExcelDataTable()

            For Each row As DataGridViewRow In dgvPrincipal.SelectedRows
                With row
                    TablaExportar.Rows.Add(.Cells("NroProforma").Value, .Cells("Fecha").Value, .Cells("Cliente").Value, .Cells("Razon").Value,
                                           .Cells("Pais").Value, .Cells("Total").Value, .Cells("Combox_Estado").Value, .Cells("FechaLimite").Value,
                                           .Cells("PackingList").Value, .Cells("Entregado").Value, .Cells("Fecha_Limite").Value, .Cells("Incoterm").Value,
                                           .Cells("MV_Buque").Value, .Cells("ETD_FechaSalida").Value, .Cells("ETA_FechaArribo").Value, .Cells("Peso_Neto").Value,
                                            .Cells("Permiso_de_Embarque").Value, .Cells("BL").Value, .Cells("Forwarder").Value, .Cells("Fecha_Cobro").Value)
                End With
            Next


            '
            ' Creamos el reporte que utilizaremos para generar el excel
            '
            Dim Frm As New Util.VistaPrevia
            With Frm
                .Reporte = New ReporteExportarExcel()
                .Reporte.SetDataSource(TablaExportar)

            End With

            '
            'Generamos el excel 
            '
            _ExportarReporte(Frm, Enumeraciones.FormatoExportacion.Excel, "LibroExportacion")


            MessageBox.Show("Los datos han sido exportados satisfactoriamente.")

        Catch ex As Exception
            ' Se ha producido un error.
            '
            MessageBox.Show(ex.Message)

        Finally
            ' Restauramos el tipo de cursos existente
            '
            Me.Cursor = tipoCursor

        End Try
    End Sub

 


    Private Sub btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles btn_Exportar_Excel.Click

        ' Cambiamos el tipo de cursor
        '
        Dim tipoCursor As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor

        Try
            ' Referenciamos el objeto DataTable enlazado con
            ' el control DataGridView.
            '
            Dim TablaExportar As DataTable = New DBAuxi.TablaReporteExcelDataTable()

            For Each row As DataGridViewRow In dgvPrincipal.Rows
                With row
                    TablaExportar.Rows.Add(.Cells("NroProforma").Value, .Cells("Fecha").Value, .Cells("Cliente").Value, .Cells("Razon").Value,
                                           .Cells("Pais").Value, .Cells("Total").Value, .Cells("Combox_Estado").Value, .Cells("FechaLimite").Value,
                                           .Cells("PackingList").Value, .Cells("Entregado").Value, .Cells("Fecha_Limite").Value, .Cells("Incoterm").Value,
                                           .Cells("MV_Buque").Value, .Cells("ETD_FechaSalida").Value, .Cells("ETA_FechaArribo").Value, .Cells("Peso_Neto").Value,
                                            .Cells("Permiso_de_Embarque").Value, .Cells("BL").Value, .Cells("Forwarder").Value, .Cells("Fecha_Cobro").Value)
                End With
            Next


            '
            ' Creamos el reporte que utilizaremos para generar el excel
            '
            Dim Frm As New Util.VistaPrevia
            With Frm
                .Reporte = New ReporteExportarExcel()
                .Reporte.SetDataSource(TablaExportar)

            End With

            '
            'Generamos el excel 
            '
            _ExportarReporte(Frm, Enumeraciones.FormatoExportacion.Excel, "LibroExportacion")


            MessageBox.Show("Los datos han sido exportados satisfactoriamente.")

        Catch ex As Exception
            ' Se ha producido un error.
            '
            MessageBox.Show(ex.Message)

        Finally
            ' Restauramos el tipo de cursos existente
            '
            Me.Cursor = tipoCursor

        End Try
    End Sub
End Class
