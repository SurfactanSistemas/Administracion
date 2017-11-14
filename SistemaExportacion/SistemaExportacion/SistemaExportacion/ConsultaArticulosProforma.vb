Imports System.Data.SqlClient

Public Class ConsultaArticulosProforma

    Private Sub ConsultaArticulosProforma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _CargarArticulos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub _CargarArticulos()
        Dim WNroProforma, WFecha, WCliente, WRazon, WCodigo, WDescripcion, WCantidad, WPrecio, WRow
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("select pe.Proforma, pe.Fecha, pe.Cliente, cli.Razon, pe.Producto, t.Descripcion, pe.Cantidad, pe.Precio from ProformaExportacion as pe, Terminado as t, Cliente as cli where pe.Producto = t.Codigo and pe.Cliente = cli.Cliente ORDER BY Proforma, Renglon")
        Dim dr As SqlDataReader

        WNroProforma = ""
        WFecha = ""
        WCliente = ""
        WRazon = ""
        WCodigo = ""
        WDescripcion = ""
        WCantidad = 0.0
        WPrecio = 0.0
        WRow = 0

        Try
            cn.ConnectionString = Helper._ConectarA()
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            dgvPrincipal.Rows.Clear()

            If dr.HasRows Then

                Do While dr.Read()

                    WNroProforma = IIf(IsDBNull(dr.Item("Proforma")), "", Trim(dr.Item("Proforma")))
                    WFecha = IIf(IsDBNull(dr.Item("Fecha")), "", Trim(dr.Item("Fecha")))
                    WCliente = IIf(IsDBNull(dr.Item("Cliente")), "", Trim(dr.Item("Cliente")))
                    WRazon = IIf(IsDBNull(dr.Item("Razon")), "", Trim(dr.Item("Razon")))
                    WCodigo = IIf(IsDBNull(dr.Item("Producto")), "", Trim(dr.Item("Producto")))
                    WDescripcion = IIf(IsDBNull(dr.Item("Descripcion")), "", Trim(dr.Item("Descripcion")))
                    WCantidad = IIf(IsDBNull(dr.Item("Cantidad")), 0.0, Trim(dr.Item("Cantidad")))
                    WPrecio = IIf(IsDBNull(dr.Item("Precio")), 0.0, Trim(dr.Item("Precio")))

                    WRow = dgvPrincipal.Rows.Add()

                    With dgvPrincipal.Rows(WRow)

                        .Cells("NroProforma").Value = WNroProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Codigo").Value = WCodigo
                        .Cells("Descripcion").Value = WDescripcion
                        .Cells("Cantidad").Value = Helper.formatonumerico(WCantidad)
                        .Cells("Precio").Value = Helper.formatonumerico(WPrecio)

                    End With

                Loop

            End If

        Catch ex As Exception
            Throw New Exception("No se pudieron consultar correctamente los articulos de las proformaas actuales." & vbCrLf & " Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub cmbTipoFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoFiltro.SelectedIndexChanged
        If cmbTipoFiltro.SelectedIndex = 0 Then
            _CargarArticulos()
            txtFiltrarPor.Text = ""
        Else
            txtFiltrarPor.Focus()
        End If
    End Sub

    Private Sub txtFiltrarPor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrarPor.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtFiltrarPor.Text) = "" Then
                _CargarArticulos()
                Exit Sub
            End If

            If cmbTipoFiltro.SelectedIndex < 1 Then : Exit Sub : End If

            Dim WFiltro = ""

            Select Case cmbTipoFiltro.SelectedIndex
                Case 1 ' Cliente
                    WFiltro = "(pe.Cliente LIKE '%" & Trim(txtFiltrarPor.Text) & "%' OR cli.Razon LIKE '%" & Trim(txtFiltrarPor.Text) & "%')"

                Case 2 ' Articulo
                    WFiltro = "pe.Producto LIKE '%" & Trim(txtFiltrarPor.Text) & "%'"

                Case Else
                    Exit Sub
            End Select

            Try
                _Filtrar(WFiltro)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                _CargarArticulos()
                Exit Sub
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtFiltrarPor.Text = ""
        End If
    End Sub

    Private Sub _Filtrar(ByVal _Filtros)
        'Dim WProforma, WFecha, WCliente, WRazon, WPais, WTotal, WRowIndex
        Dim WNroProforma, WFecha, WCliente, WRazon, WCodigo, WDescripcion, WCantidad, WPrecio, WRow
        Dim WSQL As String = "SELECT pe.Proforma, pe.Fecha, pe.Cliente, cli.Razon, pe.Producto, t.Descripcion, pe.Cantidad, pe.Precio FROM ProformaExportacion AS pe, Terminado AS t, Cliente AS cli WHERE pe.Producto = t.Codigo AND pe.Cliente = cli.Cliente AND #FILTROS# ORDER BY Proforma, Renglon"
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        WNroProforma = ""
        WFecha = ""
        WCliente = ""
        WRazon = ""
        WCodigo = ""
        WDescripcion = ""
        WCantidad = 0.0
        WPrecio = 0.0
        WRow = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = WSQL.Replace("#FILTROS#", _Filtros)

            dr = cm.ExecuteReader()

            dgvPrincipal.Rows.Clear()

            If dr.HasRows Then

                Do While dr.Read()

                    WNroProforma = ""
                    WFecha = ""
                    WCliente = ""
                    WRazon = ""
                    WCodigo = ""
                    WDescripcion = ""
                    WCantidad = 0.0
                    WPrecio = 0.0
                    WRow = 0

                    WNroProforma = IIf(IsDBNull(dr.Item("Proforma")), "", Trim(dr.Item("Proforma")))
                    WFecha = IIf(IsDBNull(dr.Item("Fecha")), "", Trim(dr.Item("Fecha")))
                    WCliente = IIf(IsDBNull(dr.Item("Cliente")), "", Trim(dr.Item("Cliente")))
                    WRazon = IIf(IsDBNull(dr.Item("Razon")), "", Trim(dr.Item("Razon")))
                    WCodigo = IIf(IsDBNull(dr.Item("Producto")), "", Trim(dr.Item("Producto")))
                    WDescripcion = IIf(IsDBNull(dr.Item("Descripcion")), "", Trim(dr.Item("Descripcion")))
                    WCantidad = IIf(IsDBNull(dr.Item("Cantidad")), 0.0, Trim(dr.Item("Cantidad")))
                    WPrecio = IIf(IsDBNull(dr.Item("Precio")), 0.0, Trim(dr.Item("Precio")))

                    WRow = dgvPrincipal.Rows.Add()

                    With dgvPrincipal.Rows(WRow)

                        .Cells("NroProforma").Value = WNroProforma
                        .Cells("Fecha").Value = WFecha
                        .Cells("Cliente").Value = WCliente
                        .Cells("Razon").Value = WRazon
                        .Cells("Codigo").Value = WCodigo
                        .Cells("Descripcion").Value = WDescripcion
                        .Cells("Cantidad").Value = Helper.formatonumerico(WCantidad)
                        .Cells("Precio").Value = Helper.formatonumerico(WPrecio)

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub dgvPrincipal_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgvPrincipal.SortCompare
        Dim num1, num2

        Select Case e.Column.Index
            Case 0, 6, 7

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
End Class