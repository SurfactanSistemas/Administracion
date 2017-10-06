Imports System.Data.SqlClient

Public Class MenuPrincipal

    Private Sub btnNuevaProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaProforma.Click
        With Proforma
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnHistorialProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorialProforma.Click
        'MsgBox("En Desarrollo. Sin Implementacion todavia.")
        'Exit Sub
        With HistorialProforma
            .Show()
        End With
    End Sub

    Private Sub MenuPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _CargarTodasLasProformas()
    End Sub

    Private Sub _CargarTodasLasProformas()
        Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WRowIndex
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT DISTINCT p.Proforma, p.FechaOrd, p.Fecha, p.Cliente, c.Razon, p.Pais, p.Total FROM ProformaExportacion as p, Cliente as c WHERE p.Cliente = c.Cliente ORDER BY p.FechaOrd, p.Proforma")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                WProforma = ""
                WFecha = ""
                WCliente = ""
                WRazon = ""
                WPais = ""
                WTotal = 0.0
                WRowIndex = 0

                dgvPrincipal.Rows.Clear()

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
            MsgBox("Hubo un problema al querer listar las Proformas desde la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

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
                .NroProforma = dgvPrincipal.Rows(e.RowIndex).Cells(0).Value
                .Show()
            End With

        End If

    End Sub

    Private Sub txtFiltrarPor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrarPor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFiltrarPor.Text) = "" Then : Exit Sub : End If

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
        txtFiltrarPor.Focus()
    End Sub
End Class
